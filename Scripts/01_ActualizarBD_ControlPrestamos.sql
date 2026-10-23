/* =====================================================================
   SISTEMA ALMACÉN 2025 - ACTUALIZACIÓN DE BASE DE DATOS
   ---------------------------------------------------------------------
   Objetivo: que el sistema mantenga el flujo completo
     Usuario -> Solicitud -> Préstamo (Pendiente) -> Devolución (Devuelto)
     Usuario/Área -> Solicitud -> Salida (descuenta stock)

   Qué hace este script (se puede ejecutar varias veces sin romper nada):
     1. Material.Stock pasa de nchar(3) a INT (para poder sumar/restar).
     2. Prestamo recibe las columnas Estado, FechaDevolucion y StockDescontado.
     3. Salidas recibe la columna StockDescontado.
     4. Los préstamos que ya tienen devolución quedan como 'Devuelto'.
     5. Se reescriben los procedimientos de registro para validar y mover
        el stock dentro de transacciones.
     6. Se corrigen las vistas de consulta (tenían CROSS JOIN).
     7. Se crean vistas y procedimientos para Control, Consultas y Reportes.

   Cómo ejecutarlo:
     Visual Studio > Explorador de servidores (o SQL Server Management Studio)
     > conectar a (localdb)\MSSQLLocalDB > base BD_Almacén2025
     > Nueva consulta > pegar este script > Ejecutar.
     ¡Haz una copia del .mdf antes, por si acaso!
   ===================================================================== */

USE [BD_Almacén2025];
GO

/* =====================================================================
   1. MATERIAL.STOCK -> INT
   ===================================================================== */
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
           WHERE TABLE_NAME = 'Material' AND COLUMN_NAME = 'Stock' AND DATA_TYPE <> 'int')
BEGIN
    DECLARE @sql NVARCHAR(MAX);

    -- Quitar restricciones DEFAULT que pudiera tener la columna
    SELECT @sql = N'ALTER TABLE dbo.Material DROP CONSTRAINT ' + QUOTENAME(dc.name)
    FROM sys.default_constraints dc
    JOIN sys.columns c ON c.object_id = dc.parent_object_id AND c.column_id = dc.parent_column_id
    WHERE dc.parent_object_id = OBJECT_ID('dbo.Material') AND c.name = 'Stock';
    IF @sql IS NOT NULL EXEC (@sql);

    -- Quitar estadísticas creadas sobre la columna (impiden cambiar el tipo)
    SET @sql = N'';
    SELECT @sql = @sql + N'DROP STATISTICS dbo.Material.' + QUOTENAME(s.name) + N';'
    FROM sys.stats s
    JOIN sys.stats_columns sc ON sc.object_id = s.object_id AND sc.stats_id = s.stats_id
    JOIN sys.columns c ON c.object_id = sc.object_id AND c.column_id = sc.column_id
    WHERE s.object_id = OBJECT_ID('dbo.Material') AND c.name = 'Stock'
      AND NOT EXISTS (SELECT 1 FROM sys.indexes i WHERE i.object_id = s.object_id AND i.index_id = s.stats_id);
    IF LEN(@sql) > 0 EXEC (@sql);

    -- Valores no numéricos o vacíos pasan a 0
    EXEC (N'UPDATE dbo.Material SET Stock = ''0''
            WHERE Stock IS NULL OR TRY_CAST(LTRIM(RTRIM(Stock)) AS INT) IS NULL;');

    EXEC (N'ALTER TABLE dbo.Material ALTER COLUMN Stock INT NOT NULL;');
END
GO

/* =====================================================================
   2. PRESTAMO: Estado, FechaDevolucion, StockDescontado
      StockDescontado = 1 indica que al registrar el préstamo se descontó
      el stock (préstamos nuevos). Los préstamos antiguos quedan en 0 para
      que su devolución NO sume stock que nunca se restó.
   ===================================================================== */
IF COL_LENGTH('dbo.Prestamo', 'Estado') IS NULL
    ALTER TABLE dbo.Prestamo ADD Estado NVARCHAR(15) NOT NULL
        CONSTRAINT DF_Prestamo_Estado DEFAULT (N'Pendiente');
GO
IF COL_LENGTH('dbo.Prestamo', 'FechaDevolucion') IS NULL
    ALTER TABLE dbo.Prestamo ADD FechaDevolucion DATETIME NULL;
GO
IF COL_LENGTH('dbo.Prestamo', 'StockDescontado') IS NULL
    ALTER TABLE dbo.Prestamo ADD StockDescontado BIT NOT NULL
        CONSTRAINT DF_Prestamo_StockDescontado DEFAULT (0);
GO
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Prestamo_Estado')
    ALTER TABLE dbo.Prestamo ADD CONSTRAINT CK_Prestamo_Estado
        CHECK (Estado IN (N'Pendiente', N'Devuelto'));
GO
IF COL_LENGTH('dbo.Salidas', 'StockDescontado') IS NULL
    ALTER TABLE dbo.Salidas ADD StockDescontado BIT NOT NULL
        CONSTRAINT DF_Salidas_StockDescontado DEFAULT (0);
GO

/* 4. Préstamos que ya tienen devolución registrada -> Devuelto */
UPDATE p
   SET p.Estado = N'Devuelto',
       p.FechaDevolucion = (SELECT MAX(d.Fecha) FROM dbo.Devoluciones d WHERE d.IDPrestamo = p.IDPrestamo)
  FROM dbo.Prestamo p
 WHERE p.Estado <> N'Devuelto'
   AND EXISTS (SELECT 1 FROM dbo.Devoluciones d WHERE d.IDPrestamo = p.IDPrestamo);
GO

/* =====================================================================
   5. PROCEDIMIENTOS DE MAESTROS (Material con Stock INT)
   ===================================================================== */
IF OBJECT_ID('dbo.RegistrarMaterial', 'P') IS NOT NULL DROP PROCEDURE dbo.RegistrarMaterial;
GO
CREATE PROCEDURE dbo.RegistrarMaterial
    @Nombre NVARCHAR(30), @Descripcion NVARCHAR(100), @Tipo NVARCHAR(15),
    @Estado NVARCHAR(15), @Stock INT
AS
BEGIN
    SET NOCOUNT ON;
    IF @Stock IS NULL OR @Stock < 0
        THROW 50001, N'El stock debe ser un número mayor o igual a 0.', 1;
    INSERT INTO dbo.Material (Nombre, Descripcion, Tipo, Estado, Stock)
    VALUES (@Nombre, @Descripcion, @Tipo, @Estado, @Stock);
END
GO

IF OBJECT_ID('dbo.ModificarMaterial', 'P') IS NOT NULL DROP PROCEDURE dbo.ModificarMaterial;
GO
CREATE PROCEDURE dbo.ModificarMaterial
    @IDMaterial INT, @Nombre NVARCHAR(30), @Descripcion NVARCHAR(100), @Tipo NVARCHAR(15),
    @Estado NVARCHAR(15), @Stock INT
AS
BEGIN
    SET NOCOUNT ON;
    IF @Stock IS NULL OR @Stock < 0
        THROW 50001, N'El stock debe ser un número mayor o igual a 0.', 1;
    UPDATE dbo.Material
       SET Nombre = @Nombre, Descripcion = @Descripcion, Tipo = @Tipo, Estado = @Estado, Stock = @Stock
     WHERE IDMaterial = @IDMaterial;
END
GO

IF OBJECT_ID('dbo.EliminarMaterial', 'P') IS NOT NULL DROP PROCEDURE dbo.EliminarMaterial;
GO
CREATE PROCEDURE dbo.EliminarMaterial
    @IDMaterial INT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.DetallePrestamo WHERE IDMaterial = @IDMaterial)
       OR EXISTS (SELECT 1 FROM dbo.DetalleSalidas WHERE IDmaterial = @IDMaterial)
        THROW 50002, N'No se puede eliminar: el material tiene préstamos o salidas registradas.', 1;
    DELETE FROM dbo.Material WHERE IDMaterial = @IDMaterial;
END
GO

/* Corrige CargarPrestamo (antes devolvía la tabla Personal) */
IF OBJECT_ID('dbo.CargarPrestamo', 'P') IS NOT NULL DROP PROCEDURE dbo.CargarPrestamo;
GO
CREATE PROCEDURE dbo.CargarPrestamo
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IDPrestamo, DNIPersonal, IDSolicitud, Fecha, Estado, FechaDevolucion
      FROM dbo.Prestamo
     ORDER BY IDPrestamo DESC;
END
GO

/* =====================================================================
   5b. PRÉSTAMOS
   RegistrarPrestamo y RegistrarDetallePrestamo se llaman desde VB dentro
   de una misma transacción (ClsPrestamo.RegistrarPrestamoCompleto).
   Si algún detalle no tiene stock, se lanza error y se deshace todo.
   ===================================================================== */
IF OBJECT_ID('dbo.RegistrarPrestamo', 'P') IS NOT NULL DROP PROCEDURE dbo.RegistrarPrestamo;
GO
CREATE PROCEDURE dbo.RegistrarPrestamo
    @IDPrestamo INT = 0,
    @DNIPersonal NCHAR(8),
    @IDSolicitud INT,
    @Fecha DATETIME,
    @NuevoId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM dbo.Solicitud WHERE IDSolicitud = @IDSolicitud)
        THROW 50010, N'La solicitud indicada no existe. Registre primero la solicitud del usuario.', 1;
    IF NOT EXISTS (SELECT 1 FROM dbo.Personal WHERE DNIPersonal = @DNIPersonal)
        THROW 50011, N'El personal indicado no existe.', 1;

    INSERT INTO dbo.Prestamo (DNIPersonal, IDSolicitud, Fecha, Estado, StockDescontado)
    VALUES (@DNIPersonal, @IDSolicitud, ISNULL(@Fecha, GETDATE()), N'Pendiente', 1);

    SET @NuevoId = SCOPE_IDENTITY();
END
GO

IF OBJECT_ID('dbo.RegistrarDetallePrestamo', 'P') IS NOT NULL DROP PROCEDURE dbo.RegistrarDetallePrestamo;
GO
CREATE PROCEDURE dbo.RegistrarDetallePrestamo
    @IDDetallePrestamo INT = 0,
    @IDPrestamo INT,
    @IDMaterial INT,
    @Cantidad INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Stock INT, @Nombre NVARCHAR(30), @msg NVARCHAR(400);

    IF @Cantidad IS NULL OR @Cantidad <= 0
        THROW 50020, N'La cantidad debe ser mayor a 0.', 1;

    IF NOT EXISTS (SELECT 1 FROM dbo.Prestamo WHERE IDPrestamo = @IDPrestamo AND Estado = N'Pendiente')
        THROW 50021, N'El préstamo no existe o ya fue devuelto.', 1;

    SELECT @Stock = Stock, @Nombre = RTRIM(Nombre)
      FROM dbo.Material WITH (UPDLOCK, ROWLOCK)
     WHERE IDMaterial = @IDMaterial;

    IF @Stock IS NULL
    BEGIN
        SET @msg = N'El material con ID ' + CAST(@IDMaterial AS NVARCHAR(10)) + N' no existe.';
        THROW 50022, @msg, 1;
    END

    IF @Stock < @Cantidad
    BEGIN
        SET @msg = N'Stock insuficiente para "' + @Nombre + N'". Disponible: '
                 + CAST(@Stock AS NVARCHAR(10)) + N', solicitado: ' + CAST(@Cantidad AS NVARCHAR(10)) + N'.';
        THROW 50023, @msg, 1;
    END

    UPDATE dbo.Material SET Stock = Stock - @Cantidad WHERE IDMaterial = @IDMaterial;

    INSERT INTO dbo.DetallePrestamo (IDPrestamo, IDMaterial, Cantidad)
    VALUES (@IDPrestamo, @IDMaterial, @Cantidad);
END
GO

IF OBJECT_ID('dbo.EliminarDetallePrestamo', 'P') IS NOT NULL DROP PROCEDURE dbo.EliminarDetallePrestamo;
GO
CREATE PROCEDURE dbo.EliminarDetallePrestamo
    @IDDetallePrestamo INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;
        -- Si el préstamo sigue pendiente y había descontado stock, se devuelve al almacén
        UPDATE m SET m.Stock = m.Stock + dp.Cantidad
          FROM dbo.Material m
          JOIN dbo.DetallePrestamo dp ON dp.IDMaterial = m.IDMaterial
          JOIN dbo.Prestamo p ON p.IDPrestamo = dp.IDPrestamo
         WHERE dp.IDDetallePrestamo = @IDDetallePrestamo
           AND p.Estado = N'Pendiente' AND p.StockDescontado = 1;

        DELETE FROM dbo.DetallePrestamo WHERE IDDetallePrestamo = @IDDetallePrestamo;
        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END
GO

IF OBJECT_ID('dbo.EliminarPrestamo', 'P') IS NOT NULL DROP PROCEDURE dbo.EliminarPrestamo;
GO
CREATE PROCEDURE dbo.EliminarPrestamo
    @IDPrestamo INT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.Devoluciones WHERE IDPrestamo = @IDPrestamo)
        THROW 50030, N'No se puede eliminar: el préstamo ya tiene una devolución registrada.', 1;
    BEGIN TRY
        BEGIN TRAN;
        UPDATE m SET m.Stock = m.Stock + x.Cant
          FROM dbo.Material m
          JOIN (SELECT dp.IDMaterial, SUM(dp.Cantidad) AS Cant
                  FROM dbo.DetallePrestamo dp
                  JOIN dbo.Prestamo p ON p.IDPrestamo = dp.IDPrestamo
                 WHERE dp.IDPrestamo = @IDPrestamo AND p.Estado = N'Pendiente' AND p.StockDescontado = 1
                 GROUP BY dp.IDMaterial) x ON x.IDMaterial = m.IDMaterial;

        DELETE FROM dbo.DetallePrestamo WHERE IDPrestamo = @IDPrestamo;
        DELETE FROM dbo.Prestamo WHERE IDPrestamo = @IDPrestamo;
        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END
GO

/* =====================================================================
   5c. SALIDAS (salida definitiva: descuenta stock y no se devuelve)
   ===================================================================== */
IF OBJECT_ID('dbo.RegistrarSalidas', 'P') IS NOT NULL DROP PROCEDURE dbo.RegistrarSalidas;
GO
CREATE PROCEDURE dbo.RegistrarSalidas
    @IDSalidas INT = 0,
    @DNIPersonal NCHAR(8),
    @IDSolicitud INT,
    @Fecha DATETIME,
    @NuevoId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM dbo.Solicitud WHERE IDSolicitud = @IDSolicitud)
        THROW 50040, N'La solicitud indicada no existe. Registre primero la solicitud del usuario.', 1;
    IF NOT EXISTS (SELECT 1 FROM dbo.Personal WHERE DNIPersonal = @DNIPersonal)
        THROW 50041, N'El personal indicado no existe.', 1;

    INSERT INTO dbo.Salidas (DNIPersonal, IDSolicitud, Fecha, StockDescontado)
    VALUES (@DNIPersonal, @IDSolicitud, ISNULL(@Fecha, GETDATE()), 1);

    SET @NuevoId = SCOPE_IDENTITY();
END
GO

IF OBJECT_ID('dbo.RegistrarDetalleSalidas', 'P') IS NOT NULL DROP PROCEDURE dbo.RegistrarDetalleSalidas;
GO
CREATE PROCEDURE dbo.RegistrarDetalleSalidas
    @IDDetalleSalidas INT = 0,
    @IDSalidas INT,
    @IDMaterial INT,
    @Cantidad INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Stock INT, @Nombre NVARCHAR(30), @msg NVARCHAR(400);

    IF @Cantidad IS NULL OR @Cantidad <= 0
        THROW 50050, N'La cantidad debe ser mayor a 0.', 1;

    IF NOT EXISTS (SELECT 1 FROM dbo.Salidas WHERE IDSalidas = @IDSalidas)
        THROW 50051, N'La salida no existe.', 1;

    SELECT @Stock = Stock, @Nombre = RTRIM(Nombre)
      FROM dbo.Material WITH (UPDLOCK, ROWLOCK)
     WHERE IDMaterial = @IDMaterial;

    IF @Stock IS NULL
    BEGIN
        SET @msg = N'El material con ID ' + CAST(@IDMaterial AS NVARCHAR(10)) + N' no existe.';
        THROW 50052, @msg, 1;
    END

    IF @Stock < @Cantidad
    BEGIN
        SET @msg = N'Stock insuficiente para "' + @Nombre + N'". Disponible: '
                 + CAST(@Stock AS NVARCHAR(10)) + N', solicitado: ' + CAST(@Cantidad AS NVARCHAR(10)) + N'.';
        THROW 50053, @msg, 1;
    END

    UPDATE dbo.Material SET Stock = Stock - @Cantidad WHERE IDMaterial = @IDMaterial;

    INSERT INTO dbo.DetalleSalidas (IDSalidas, IDmaterial, Cantidad)
    VALUES (@IDSalidas, @IDMaterial, @Cantidad);
END
GO

IF OBJECT_ID('dbo.EliminarDetalleSalidas', 'P') IS NOT NULL DROP PROCEDURE dbo.EliminarDetalleSalidas;
GO
CREATE PROCEDURE dbo.EliminarDetalleSalidas
    @IDDetalleSalidas INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;
        UPDATE m SET m.Stock = m.Stock + ds.Cantidad
          FROM dbo.Material m
          JOIN dbo.DetalleSalidas ds ON ds.IDmaterial = m.IDMaterial
          JOIN dbo.Salidas s ON s.IDSalidas = ds.IDSalidas
         WHERE ds.IDDetalleSalidas = @IDDetalleSalidas AND s.StockDescontado = 1;

        DELETE FROM dbo.DetalleSalidas WHERE IDDetalleSalidas = @IDDetalleSalidas;
        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END
GO

IF OBJECT_ID('dbo.EliminarSalidas', 'P') IS NOT NULL DROP PROCEDURE dbo.EliminarSalidas;
GO
CREATE PROCEDURE dbo.EliminarSalidas
    @IDSalidas INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;
        UPDATE m SET m.Stock = m.Stock + x.Cant
          FROM dbo.Material m
          JOIN (SELECT ds.IDmaterial, SUM(ds.Cantidad) AS Cant
                  FROM dbo.DetalleSalidas ds
                  JOIN dbo.Salidas s ON s.IDSalidas = ds.IDSalidas
                 WHERE ds.IDSalidas = @IDSalidas AND s.StockDescontado = 1
                 GROUP BY ds.IDmaterial) x ON x.IDmaterial = m.IDMaterial;

        DELETE FROM dbo.DetalleSalidas WHERE IDSalidas = @IDSalidas;
        DELETE FROM dbo.Salidas WHERE IDSalidas = @IDSalidas;
        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END
GO

/* Corrige ModificarSalidas (usaba la columna DNIUsuario que no existe en Salidas) */
IF OBJECT_ID('dbo.ModificarSalidas', 'P') IS NOT NULL DROP PROCEDURE dbo.ModificarSalidas;
GO
CREATE PROCEDURE dbo.ModificarSalidas
    @IDSalidas INT, @DNIPersonal NCHAR(8), @IDSolicitud INT, @Fecha DATETIME
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Salidas
       SET DNIPersonal = @DNIPersonal, IDSolicitud = @IDSolicitud, Fecha = @Fecha
     WHERE IDSalidas = @IDSalidas;
END
GO

/* =====================================================================
   5d. DEVOLUCIONES
   Registrar una devolución cierra el préstamo (Estado = 'Devuelto') y
   regresa al stock todo el material prestado. Todo en una transacción.
   ===================================================================== */
IF OBJECT_ID('dbo.RegistrarDevoluciones', 'P') IS NOT NULL DROP PROCEDURE dbo.RegistrarDevoluciones;
GO
CREATE PROCEDURE dbo.RegistrarDevoluciones
    @IDPrestamo INT,
    @Fecha DATETIME,
    @Condicion NCHAR(100),
    @Observacion NCHAR(500),
    @NuevoId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Estado NVARCHAR(15), @Descontado BIT;

    SELECT @Estado = Estado, @Descontado = StockDescontado
      FROM dbo.Prestamo WHERE IDPrestamo = @IDPrestamo;

    IF @Estado IS NULL
        THROW 50060, N'El préstamo indicado no existe.', 1;
    IF @Estado = N'Devuelto'
        THROW 50061, N'Este préstamo ya fue devuelto.', 1;

    BEGIN TRY
        BEGIN TRAN;

        INSERT INTO dbo.Devoluciones (IDPrestamo, Fecha, Condicion, Observacion)
        VALUES (@IDPrestamo, ISNULL(@Fecha, GETDATE()), @Condicion, @Observacion);
        SET @NuevoId = SCOPE_IDENTITY();

        UPDATE dbo.Prestamo
           SET Estado = N'Devuelto', FechaDevolucion = ISNULL(@Fecha, GETDATE())
         WHERE IDPrestamo = @IDPrestamo;

        IF @Descontado = 1
            UPDATE m SET m.Stock = m.Stock + x.Cant
              FROM dbo.Material m
              JOIN (SELECT IDMaterial, SUM(Cantidad) AS Cant
                      FROM dbo.DetallePrestamo
                     WHERE IDPrestamo = @IDPrestamo
                     GROUP BY IDMaterial) x ON x.IDMaterial = m.IDMaterial;

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END
GO

IF OBJECT_ID('dbo.ModificarDevoluciones', 'P') IS NOT NULL DROP PROCEDURE dbo.ModificarDevoluciones;
GO
CREATE PROCEDURE dbo.ModificarDevoluciones
    @IDDevoluciones INT, @IDPrestamo INT, @Fecha DATETIME,
    @Condicion NCHAR(100), @Observacion NCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @PrestamoActual INT;
    SELECT @PrestamoActual = IDPrestamo FROM dbo.Devoluciones WHERE IDDevoluciones = @IDDevoluciones;

    IF @PrestamoActual IS NULL
        THROW 50070, N'La devolución no existe.', 1;
    IF @PrestamoActual <> @IDPrestamo
        THROW 50071, N'No se puede cambiar el préstamo de una devolución. Elimine la devolución y registre una nueva.', 1;

    BEGIN TRY
        BEGIN TRAN;
        UPDATE dbo.Devoluciones
           SET Fecha = @Fecha, Condicion = @Condicion, Observacion = @Observacion
         WHERE IDDevoluciones = @IDDevoluciones;

        UPDATE dbo.Prestamo SET FechaDevolucion = @Fecha WHERE IDPrestamo = @IDPrestamo;
        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END
GO

/* Eliminar una devolución vuelve a dejar el préstamo como Pendiente */
IF OBJECT_ID('dbo.EliminarDevoluciones', 'P') IS NOT NULL DROP PROCEDURE dbo.EliminarDevoluciones;
GO
CREATE PROCEDURE dbo.EliminarDevoluciones
    @IDDevoluciones INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @IDPrestamo INT, @Descontado BIT, @msg NVARCHAR(400);

    SELECT @IDPrestamo = d.IDPrestamo, @Descontado = p.StockDescontado
      FROM dbo.Devoluciones d
      LEFT JOIN dbo.Prestamo p ON p.IDPrestamo = d.IDPrestamo
     WHERE d.IDDevoluciones = @IDDevoluciones;

    IF @IDPrestamo IS NULL
        THROW 50080, N'La devolución no existe.', 1;

    BEGIN TRY
        BEGIN TRAN;

        DELETE FROM dbo.Devoluciones WHERE IDDevoluciones = @IDDevoluciones;

        IF NOT EXISTS (SELECT 1 FROM dbo.Devoluciones WHERE IDPrestamo = @IDPrestamo)
        BEGIN
            IF @Descontado = 1
            BEGIN
                -- El material vuelve a estar "en manos" del usuario: se descuenta otra vez
                IF EXISTS (SELECT 1
                             FROM dbo.Material m
                             JOIN (SELECT IDMaterial, SUM(Cantidad) AS Cant FROM dbo.DetallePrestamo
                                    WHERE IDPrestamo = @IDPrestamo GROUP BY IDMaterial) x
                               ON x.IDMaterial = m.IDMaterial
                            WHERE m.Stock < x.Cant)
                BEGIN
                    SET @msg = N'No se puede eliminar la devolución: el material ya fue prestado o entregado a otra persona y no hay stock suficiente.';
                    THROW 50081, @msg, 1;
                END

                UPDATE m SET m.Stock = m.Stock - x.Cant
                  FROM dbo.Material m
                  JOIN (SELECT IDMaterial, SUM(Cantidad) AS Cant FROM dbo.DetallePrestamo
                         WHERE IDPrestamo = @IDPrestamo GROUP BY IDMaterial) x
                    ON x.IDMaterial = m.IDMaterial;
            END

            UPDATE dbo.Prestamo SET Estado = N'Pendiente', FechaDevolucion = NULL
             WHERE IDPrestamo = @IDPrestamo;
        END

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END
GO

IF OBJECT_ID('dbo.CargarDevoluciones', 'P') IS NOT NULL DROP PROCEDURE dbo.CargarDevoluciones;
GO
CREATE PROCEDURE dbo.CargarDevoluciones
AS
BEGIN
    SET NOCOUNT ON;
    -- Las 5 primeras columnas mantienen el orden original (FrmDevoluciones las usa por índice)
    SELECT d.IDDevoluciones, d.IDPrestamo, d.Fecha,
           RTRIM(d.Condicion) AS Condicion, RTRIM(d.Observacion) AS Observacion,
           RTRIM(s.DNIUsuario) AS DNIUsuario, RTRIM(u.ApellidosNombres) AS Usuario
      FROM dbo.Devoluciones d
      LEFT JOIN dbo.Prestamo p ON p.IDPrestamo = d.IDPrestamo
      LEFT JOIN dbo.Solicitud s ON s.IDSolicitud = p.IDSolicitud
      LEFT JOIN dbo.Usuarios u ON u.DNIUsuario = s.DNIUsuario
     ORDER BY d.IDDevoluciones DESC;
END
GO

/* =====================================================================
   6. VISTAS
   ===================================================================== */

/* Vista base: un registro por material prestado, con usuario y personal */
IF OBJECT_ID('dbo.VistaPrestamos', 'V') IS NOT NULL DROP VIEW dbo.VistaPrestamos;
GO
CREATE VIEW dbo.VistaPrestamos
AS
SELECT p.IDPrestamo,
       p.Fecha                          AS FechaPrestamo,
       p.Estado,
       p.FechaDevolucion,
       p.IDSolicitud,
       RTRIM(s.DNIUsuario)              AS DNIUsuario,
       RTRIM(u.ApellidosNombres)        AS Usuario,
       RTRIM(u.ProgramaEstudios)        AS ProgramaEstudios,
       RTRIM(u.TipoUsuarios)            AS TipoUsuario,
       RTRIM(u.Telefono)                AS TelefonoUsuario,
       RTRIM(p.DNIPersonal)             AS DNIPersonal,
       RTRIM(pe.Apellidosnombres)       AS Personal,
       dp.IDDetallePrestamo,
       dp.IDMaterial,
       RTRIM(m.Nombre)                  AS Material,
       RTRIM(m.Tipo)                    AS TipoMaterial,
       dp.Cantidad,
       DATEDIFF(DAY, p.Fecha, ISNULL(p.FechaDevolucion, GETDATE())) AS Dias
  FROM dbo.Prestamo p
  LEFT JOIN dbo.DetallePrestamo dp ON dp.IDPrestamo = p.IDPrestamo
  LEFT JOIN dbo.Material m         ON m.IDMaterial  = dp.IDMaterial
  LEFT JOIN dbo.Solicitud s        ON s.IDSolicitud = p.IDSolicitud
  LEFT JOIN dbo.Usuarios u         ON u.DNIUsuario  = s.DNIUsuario
  LEFT JOIN dbo.Personal pe        ON pe.DNIPersonal = p.DNIPersonal;
GO

IF OBJECT_ID('dbo.VistaSalidas', 'V') IS NOT NULL DROP VIEW dbo.VistaSalidas;
GO
CREATE VIEW dbo.VistaSalidas
AS
SELECT sa.IDSalidas,
       sa.Fecha                         AS FechaSalida,
       sa.IDSolicitud,
       RTRIM(s.DNIUsuario)              AS DNIUsuario,
       RTRIM(u.ApellidosNombres)        AS Usuario,
       RTRIM(u.ProgramaEstudios)        AS ProgramaEstudios,
       RTRIM(sa.DNIPersonal)            AS DNIPersonal,
       RTRIM(pe.Apellidosnombres)       AS Personal,
       ds.IDDetalleSalidas,
       ds.IDmaterial                    AS IDMaterial,
       RTRIM(m.Nombre)                  AS Material,
       RTRIM(m.Tipo)                    AS TipoMaterial,
       ds.Cantidad
  FROM dbo.Salidas sa
  LEFT JOIN dbo.DetalleSalidas ds ON ds.IDSalidas  = sa.IDSalidas
  LEFT JOIN dbo.Material m        ON m.IDMaterial  = ds.IDmaterial
  LEFT JOIN dbo.Solicitud s       ON s.IDSolicitud = sa.IDSolicitud
  LEFT JOIN dbo.Usuarios u        ON u.DNIUsuario  = s.DNIUsuario
  LEFT JOIN dbo.Personal pe       ON pe.DNIPersonal = sa.DNIPersonal;
GO

IF OBJECT_ID('dbo.VistaDevoluciones', 'V') IS NOT NULL DROP VIEW dbo.VistaDevoluciones;
GO
CREATE VIEW dbo.VistaDevoluciones
AS
SELECT d.IDDevoluciones,
       d.Fecha                 AS FechaDevolucion,
       RTRIM(d.Condicion)      AS Condicion,
       RTRIM(d.Observacion)    AS Observacion,
       d.IDPrestamo,
       vp.FechaPrestamo,
       vp.DNIUsuario,
       vp.Usuario,
       vp.DNIPersonal,
       vp.Personal,
       vp.IDMaterial,
       vp.Material,
       vp.Cantidad
  FROM dbo.Devoluciones d
  LEFT JOIN dbo.VistaPrestamos vp ON vp.IDPrestamo = d.IDPrestamo;
GO

/* ---- Vistas usadas por las consultas y reportes Crystal existentes ----
   Se mantienen las mismas columnas (y en el mismo orden) para no romper
   el DataSet tipado ni los .rpt; solo se agregan columnas al final.   */
IF OBJECT_ID('dbo.VistaConsulta_Material', 'V') IS NOT NULL DROP VIEW dbo.VistaConsulta_Material;
GO
CREATE VIEW dbo.VistaConsulta_Material
AS
-- Antes hacía CROSS JOIN con Personal (repetía cada material por cada persona)
SELECT CAST(N'' AS NCHAR(8))     AS DNIPersonal,
       m.IDMaterial, m.Nombre, m.Tipo, m.Descripcion, m.Estado, m.Stock,
       ISNULL(x.Prestado, 0)     AS CantidadPrestada
  FROM dbo.Material m
  LEFT JOIN (SELECT dp.IDMaterial, SUM(dp.Cantidad) AS Prestado
               FROM dbo.DetallePrestamo dp
               JOIN dbo.Prestamo p ON p.IDPrestamo = dp.IDPrestamo
              WHERE p.Estado = N'Pendiente'
              GROUP BY dp.IDMaterial) x ON x.IDMaterial = m.IDMaterial;
GO

IF OBJECT_ID('dbo.VistaConsulta_Salidas', 'V') IS NOT NULL DROP VIEW dbo.VistaConsulta_Salidas;
GO
CREATE VIEW dbo.VistaConsulta_Salidas
AS
SELECT ds.IDSalidas, sa.DNIPersonal, pe.Apellidosnombres, m.Nombre,
       ds.IDmaterial AS IDMaterial, ds.Cantidad, sa.Fecha,
       RTRIM(so.DNIUsuario) AS DNIUsuario, RTRIM(u.ApellidosNombres) AS Usuario
  FROM dbo.DetalleSalidas ds
  INNER JOIN dbo.Salidas sa   ON sa.IDSalidas   = ds.IDSalidas
  INNER JOIN dbo.Material m   ON m.IDMaterial   = ds.IDmaterial
  INNER JOIN dbo.Personal pe  ON pe.DNIPersonal = sa.DNIPersonal
  LEFT  JOIN dbo.Solicitud so ON so.IDSolicitud = sa.IDSolicitud
  LEFT  JOIN dbo.Usuarios u   ON u.DNIUsuario   = so.DNIUsuario;
GO

IF OBJECT_ID('dbo.VistaConsulta_Devoluciones', 'V') IS NOT NULL DROP VIEW dbo.VistaConsulta_Devoluciones;
GO
CREATE VIEW dbo.VistaConsulta_Devoluciones
AS
-- Antes hacía CROSS JOIN con Material (mostraba todos los materiales en cada devolución)
SELECT d.IDDevoluciones, dp.IDMaterial, m.Nombre, d.IDPrestamo, pe.Apellidosnombres,
       d.Fecha, dp.Cantidad, RTRIM(d.Condicion) AS Condicion,
       RTRIM(so.DNIUsuario) AS DNIUsuario, RTRIM(u.ApellidosNombres) AS Usuario
  FROM dbo.Devoluciones d
  INNER JOIN dbo.Prestamo p         ON p.IDPrestamo   = d.IDPrestamo
  INNER JOIN dbo.DetallePrestamo dp ON dp.IDPrestamo  = p.IDPrestamo
  INNER JOIN dbo.Material m         ON m.IDMaterial   = dp.IDMaterial
  INNER JOIN dbo.Personal pe        ON pe.DNIPersonal = p.DNIPersonal
  LEFT  JOIN dbo.Solicitud so       ON so.IDSolicitud = p.IDSolicitud
  LEFT  JOIN dbo.Usuarios u         ON u.DNIUsuario   = so.DNIUsuario;
GO

/* =====================================================================
   7. CONTROL
   Todos aceptan @Texto (opcional) para filtrar desde la pantalla.
   ===================================================================== */

/* 3.1 Materiales disponibles */
IF OBJECT_ID('dbo.Control_MaterialesDisponibles', 'P') IS NOT NULL DROP PROCEDURE dbo.Control_MaterialesDisponibles;
GO
CREATE PROCEDURE dbo.Control_MaterialesDisponibles
    @Texto NVARCHAR(100) = N''
AS
BEGIN
    SET NOCOUNT ON;
    SET @Texto = LTRIM(RTRIM(ISNULL(@Texto, N'')));
    SELECT v.IDMaterial              AS [ID],
           RTRIM(v.Nombre)           AS [Material],
           RTRIM(v.Tipo)             AS [Tipo],
           RTRIM(v.Estado)           AS [Estado],
           RTRIM(v.Descripcion)      AS [Descripción],
           v.Stock                   AS [Disponible],
           v.CantidadPrestada        AS [Prestado],
           v.Stock + v.CantidadPrestada AS [Total]
      FROM dbo.VistaConsulta_Material v
     WHERE v.Stock > 0
       AND RTRIM(v.Estado) <> N'OBSOLETOS'
       AND (@Texto = N'' OR v.Nombre LIKE N'%' + @Texto + N'%' OR CAST(v.IDMaterial AS NVARCHAR(10)) = @Texto)
     ORDER BY v.Nombre;
END
GO

/* 3.2 Materiales prestados  ->  "¿Quién tiene este material?" */
IF OBJECT_ID('dbo.Control_MaterialesPrestados', 'P') IS NOT NULL DROP PROCEDURE dbo.Control_MaterialesPrestados;
GO
CREATE PROCEDURE dbo.Control_MaterialesPrestados
    @Texto NVARCHAR(100) = N''
AS
BEGIN
    SET NOCOUNT ON;
    SET @Texto = LTRIM(RTRIM(ISNULL(@Texto, N'')));
    SELECT vp.IDMaterial      AS [ID Mat.],
           vp.Material        AS [Material],
           vp.Cantidad        AS [Cantidad],
           vp.DNIUsuario      AS [DNI usuario],
           vp.Usuario         AS [Lo tiene],
           vp.ProgramaEstudios AS [Programa],
           vp.TelefonoUsuario AS [Teléfono],
           vp.IDPrestamo      AS [Préstamo],
           vp.FechaPrestamo   AS [Fecha préstamo],
           vp.Dias            AS [Días],
           vp.Personal        AS [Atendido por]
      FROM dbo.VistaPrestamos vp
     WHERE vp.Estado = N'Pendiente'
       AND vp.IDMaterial IS NOT NULL
       AND (@Texto = N'' OR vp.Material LIKE N'%' + @Texto + N'%' OR CAST(vp.IDMaterial AS NVARCHAR(10)) = @Texto)
     ORDER BY vp.Material, vp.FechaPrestamo;
END
GO

/* 3.3 Préstamos pendientes  ->  "¿Quién todavía no ha devuelto?" */
IF OBJECT_ID('dbo.Control_PrestamosPendientes', 'P') IS NOT NULL DROP PROCEDURE dbo.Control_PrestamosPendientes;
GO
CREATE PROCEDURE dbo.Control_PrestamosPendientes
    @Texto NVARCHAR(100) = N''
AS
BEGIN
    SET NOCOUNT ON;
    SET @Texto = LTRIM(RTRIM(ISNULL(@Texto, N'')));
    SELECT p.IDPrestamo                         AS [Préstamo],
           p.Fecha                              AS [Fecha],
           DATEDIFF(DAY, p.Fecha, GETDATE())    AS [Días],
           RTRIM(s.DNIUsuario)                  AS [DNI usuario],
           RTRIM(u.ApellidosNombres)            AS [Usuario],
           RTRIM(u.ProgramaEstudios)            AS [Programa],
           RTRIM(u.Telefono)                    AS [Teléfono],
           STUFF((SELECT N', ' + CAST(dp.Cantidad AS NVARCHAR(10)) + N' ' + RTRIM(m.Nombre)
                    FROM dbo.DetallePrestamo dp
                    JOIN dbo.Material m ON m.IDMaterial = dp.IDMaterial
                   WHERE dp.IDPrestamo = p.IDPrestamo
                   FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, N'') AS [Materiales],
           RTRIM(pe.Apellidosnombres)           AS [Atendido por],
           p.Estado                             AS [Estado]
      FROM dbo.Prestamo p
      LEFT JOIN dbo.Solicitud s  ON s.IDSolicitud  = p.IDSolicitud
      LEFT JOIN dbo.Usuarios u   ON u.DNIUsuario   = s.DNIUsuario
      LEFT JOIN dbo.Personal pe  ON pe.DNIPersonal = p.DNIPersonal
     WHERE p.Estado = N'Pendiente'
       AND (@Texto = N''
            OR s.DNIUsuario LIKE @Texto + N'%'
            OR u.ApellidosNombres LIKE N'%' + @Texto + N'%'
            OR CAST(p.IDPrestamo AS NVARCHAR(10)) = @Texto)
     ORDER BY p.Fecha;
END
GO

/* 3.4 Devoluciones */
IF OBJECT_ID('dbo.Control_Devoluciones', 'P') IS NOT NULL DROP PROCEDURE dbo.Control_Devoluciones;
GO
CREATE PROCEDURE dbo.Control_Devoluciones
    @Texto NVARCHAR(100) = N''
AS
BEGIN
    SET NOCOUNT ON;
    SET @Texto = LTRIM(RTRIM(ISNULL(@Texto, N'')));
    SELECT vd.IDDevoluciones   AS [Devolución],
           vd.FechaDevolucion  AS [Fecha devolución],
           vd.IDPrestamo       AS [Préstamo],
           vd.FechaPrestamo    AS [Fecha préstamo],
           vd.DNIUsuario       AS [DNI usuario],
           vd.Usuario          AS [Usuario],
           vd.Material         AS [Material],
           vd.Cantidad         AS [Cantidad],
           vd.Condicion        AS [Condición],
           vd.Observacion      AS [Observación]
      FROM dbo.VistaDevoluciones vd
     WHERE (@Texto = N''
            OR vd.DNIUsuario LIKE @Texto + N'%'
            OR vd.Usuario LIKE N'%' + @Texto + N'%'
            OR vd.Material LIKE N'%' + @Texto + N'%'
            OR CAST(vd.IDPrestamo AS NVARCHAR(10)) = @Texto)
     ORDER BY vd.FechaDevolucion DESC, vd.IDDevoluciones DESC;
END
GO

/* 3.5 Historial por usuario (préstamos + salidas) */
IF OBJECT_ID('dbo.Control_HistorialUsuario', 'P') IS NOT NULL DROP PROCEDURE dbo.Control_HistorialUsuario;
GO
CREATE PROCEDURE dbo.Control_HistorialUsuario
    @Texto NVARCHAR(100) = N''
AS
BEGIN
    SET NOCOUNT ON;
    SET @Texto = LTRIM(RTRIM(ISNULL(@Texto, N'')));
    SELECT h.[DNI usuario], h.[Usuario], h.[Operación], h.[N°], h.[Fecha],
           h.[Material], h.[Cantidad], h.[Estado], h.[Fecha devolución], h.[Atendido por]
      FROM (
            SELECT vp.DNIUsuario AS [DNI usuario], vp.Usuario AS [Usuario], N'Préstamo' AS [Operación],
                   vp.IDPrestamo AS [N°], vp.FechaPrestamo AS [Fecha], vp.Material AS [Material],
                   vp.Cantidad AS [Cantidad], vp.Estado AS [Estado],
                   vp.FechaDevolucion AS [Fecha devolución], vp.Personal AS [Atendido por]
              FROM dbo.VistaPrestamos vp
            UNION ALL
            SELECT vs.DNIUsuario, vs.Usuario, N'Salida', vs.IDSalidas, vs.FechaSalida, vs.Material,
                   vs.Cantidad, N'Entregado', NULL, vs.Personal
              FROM dbo.VistaSalidas vs
           ) h
     WHERE @Texto <> N''
       AND (h.[DNI usuario] = @Texto OR h.[Usuario] LIKE N'%' + @Texto + N'%')
     ORDER BY h.[Usuario], h.[Fecha] DESC;
END
GO

/* =====================================================================
   8. CONSULTAS
   ===================================================================== */

/* Buscar usuario (por DNI o nombre) con resumen de su actividad */
IF OBJECT_ID('dbo.Consulta_BuscarUsuario', 'P') IS NOT NULL DROP PROCEDURE dbo.Consulta_BuscarUsuario;
GO
CREATE PROCEDURE dbo.Consulta_BuscarUsuario
    @Texto NVARCHAR(100) = N''
AS
BEGIN
    SET NOCOUNT ON;
    SET @Texto = LTRIM(RTRIM(ISNULL(@Texto, N'')));
    SELECT RTRIM(u.DNIUsuario)        AS [DNI],
           RTRIM(u.ApellidosNombres)  AS [Apellidos y nombres],
           RTRIM(u.ProgramaEstudios)  AS [Programa],
           RTRIM(u.TipoUsuarios)      AS [Tipo],
           RTRIM(u.Ciclo)             AS [Ciclo],
           RTRIM(u.Telefono)          AS [Teléfono],
           (SELECT COUNT(*) FROM dbo.Prestamo p JOIN dbo.Solicitud s ON s.IDSolicitud = p.IDSolicitud
             WHERE s.DNIUsuario = u.DNIUsuario AND p.Estado = N'Pendiente') AS [Préstamos pendientes],
           (SELECT COUNT(*) FROM dbo.Prestamo p JOIN dbo.Solicitud s ON s.IDSolicitud = p.IDSolicitud
             WHERE s.DNIUsuario = u.DNIUsuario) AS [Total préstamos],
           (SELECT COUNT(*) FROM dbo.Salidas sa JOIN dbo.Solicitud s ON s.IDSolicitud = sa.IDSolicitud
             WHERE s.DNIUsuario = u.DNIUsuario) AS [Total salidas]
      FROM dbo.Usuarios u
     WHERE @Texto = N''
        OR u.DNIUsuario LIKE @Texto + N'%'
        OR u.ApellidosNombres LIKE N'%' + @Texto + N'%'
     ORDER BY u.ApellidosNombres;
END
GO

/* "¿Qué materiales tiene esta persona?" (solo préstamos pendientes) */
IF OBJECT_ID('dbo.Consulta_MaterialesDeUsuario', 'P') IS NOT NULL DROP PROCEDURE dbo.Consulta_MaterialesDeUsuario;
GO
CREATE PROCEDURE dbo.Consulta_MaterialesDeUsuario
    @DNIUsuario NVARCHAR(8)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT vp.IDPrestamo     AS [Préstamo],
           vp.FechaPrestamo  AS [Fecha],
           vp.Dias           AS [Días],
           vp.IDMaterial     AS [ID Mat.],
           vp.Material       AS [Material],
           vp.Cantidad       AS [Cantidad],
           vp.Personal       AS [Atendido por]
      FROM dbo.VistaPrestamos vp
     WHERE vp.DNIUsuario = LTRIM(RTRIM(@DNIUsuario))
       AND vp.Estado = N'Pendiente'
       AND vp.IDMaterial IS NOT NULL
     ORDER BY vp.FechaPrestamo;
END
GO

/* Buscar préstamo: por N°, DNI, nombre de usuario o material; filtro de estado */
IF OBJECT_ID('dbo.Consulta_BuscarPrestamo', 'P') IS NOT NULL DROP PROCEDURE dbo.Consulta_BuscarPrestamo;
GO
CREATE PROCEDURE dbo.Consulta_BuscarPrestamo
    @Texto NVARCHAR(100) = N'',
    @Estado NVARCHAR(15) = N''      -- '', 'Pendiente' o 'Devuelto'
AS
BEGIN
    SET NOCOUNT ON;
    SET @Texto = LTRIM(RTRIM(ISNULL(@Texto, N'')));
    SET @Estado = LTRIM(RTRIM(ISNULL(@Estado, N'')));
    SELECT p.IDPrestamo                AS [Préstamo],
           p.Fecha                     AS [Fecha],
           p.Estado                    AS [Estado],
           p.FechaDevolucion           AS [Fecha devolución],
           p.IDSolicitud               AS [Solicitud],
           RTRIM(s.DNIUsuario)         AS [DNI usuario],
           RTRIM(u.ApellidosNombres)   AS [Usuario],
           STUFF((SELECT N', ' + CAST(dp.Cantidad AS NVARCHAR(10)) + N' ' + RTRIM(m.Nombre)
                    FROM dbo.DetallePrestamo dp
                    JOIN dbo.Material m ON m.IDMaterial = dp.IDMaterial
                   WHERE dp.IDPrestamo = p.IDPrestamo
                   FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, N'') AS [Materiales],
           RTRIM(pe.Apellidosnombres)  AS [Atendido por]
      FROM dbo.Prestamo p
      LEFT JOIN dbo.Solicitud s ON s.IDSolicitud  = p.IDSolicitud
      LEFT JOIN dbo.Usuarios u  ON u.DNIUsuario   = s.DNIUsuario
      LEFT JOIN dbo.Personal pe ON pe.DNIPersonal = p.DNIPersonal
     WHERE (@Estado = N'' OR p.Estado = @Estado)
       AND (@Texto = N''
            OR CAST(p.IDPrestamo AS NVARCHAR(10)) = @Texto
            OR s.DNIUsuario LIKE @Texto + N'%'
            OR u.ApellidosNombres LIKE N'%' + @Texto + N'%'
            OR EXISTS (SELECT 1 FROM dbo.DetallePrestamo dp
                         JOIN dbo.Material m ON m.IDMaterial = dp.IDMaterial
                        WHERE dp.IDPrestamo = p.IDPrestamo AND m.Nombre LIKE N'%' + @Texto + N'%'))
     ORDER BY p.IDPrestamo DESC;
END
GO

/* Detalle (materiales) de un préstamo */
IF OBJECT_ID('dbo.Consulta_DetallePrestamo', 'P') IS NOT NULL DROP PROCEDURE dbo.Consulta_DetallePrestamo;
GO
CREATE PROCEDURE dbo.Consulta_DetallePrestamo
    @IDPrestamo INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT dp.IDDetallePrestamo AS [Detalle],
           dp.IDMaterial        AS [ID Mat.],
           RTRIM(m.Nombre)      AS [Material],
           RTRIM(m.Tipo)        AS [Tipo],
           dp.Cantidad          AS [Cantidad]
      FROM dbo.DetallePrestamo dp
      LEFT JOIN dbo.Material m ON m.IDMaterial = dp.IDMaterial
     WHERE dp.IDPrestamo = @IDPrestamo;
END
GO

/* Datos de un material (stock) para validar en pantalla */
IF OBJECT_ID('dbo.Consulta_StockMaterial', 'P') IS NOT NULL DROP PROCEDURE dbo.Consulta_StockMaterial;
GO
CREATE PROCEDURE dbo.Consulta_StockMaterial
    @IDMaterial INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IDMaterial, RTRIM(Nombre) AS Nombre, RTRIM(Tipo) AS Tipo, RTRIM(Estado) AS Estado, Stock
      FROM dbo.Material
     WHERE IDMaterial = @IDMaterial;
END
GO

/* Solicitudes con usuario (para los buscadores de Préstamo y Salida) */
IF OBJECT_ID('dbo.Consulta_Solicitudes', 'P') IS NOT NULL DROP PROCEDURE dbo.Consulta_Solicitudes;
GO
CREATE PROCEDURE dbo.Consulta_Solicitudes
AS
BEGIN
    SET NOCOUNT ON;
    SELECT so.IDSolicitud, RTRIM(so.DNIUsuario) AS DNIUsuario, RTRIM(u.ApellidosNombres) AS Usuario,
           so.Fecha,
           CASE WHEN EXISTS (SELECT 1 FROM dbo.Prestamo p WHERE p.IDSolicitud = so.IDSolicitud)
                  OR EXISTS (SELECT 1 FROM dbo.Salidas s WHERE s.IDSolicitud = so.IDSolicitud)
                THEN N'Atendida' ELSE N'Sin atender' END AS Situacion
      FROM dbo.Solicitud so
      LEFT JOIN dbo.Usuarios u ON u.DNIUsuario = so.DNIUsuario
     ORDER BY so.IDSolicitud DESC;
END
GO

/* =====================================================================
   9. REPORTES (con rango de fechas opcional)
   ===================================================================== */
IF OBJECT_ID('dbo.Reporte_Materiales', 'P') IS NOT NULL DROP PROCEDURE dbo.Reporte_Materiales;
GO
CREATE PROCEDURE dbo.Reporte_Materiales
    @Desde DATETIME = NULL, @Hasta DATETIME = NULL   -- no se usan; se aceptan por uniformidad
AS
BEGIN
    SET NOCOUNT ON;
    SELECT v.IDMaterial AS [ID], RTRIM(v.Nombre) AS [Material], RTRIM(v.Tipo) AS [Tipo],
           RTRIM(v.Estado) AS [Estado], RTRIM(v.Descripcion) AS [Descripción],
           v.Stock AS [Disponible], v.CantidadPrestada AS [Prestado],
           v.Stock + v.CantidadPrestada AS [Total],
           ISNULL((SELECT SUM(ds.Cantidad) FROM dbo.DetalleSalidas ds WHERE ds.IDmaterial = v.IDMaterial), 0) AS [Entregado (salidas)]
      FROM dbo.VistaConsulta_Material v
     ORDER BY v.Nombre;
END
GO

IF OBJECT_ID('dbo.Reporte_Prestamos', 'P') IS NOT NULL DROP PROCEDURE dbo.Reporte_Prestamos;
GO
CREATE PROCEDURE dbo.Reporte_Prestamos
    @Desde DATETIME = NULL, @Hasta DATETIME = NULL, @Estado NVARCHAR(15) = N''
AS
BEGIN
    SET NOCOUNT ON;
    SET @Estado = LTRIM(RTRIM(ISNULL(@Estado, N'')));
    SELECT vp.IDPrestamo AS [Préstamo], vp.FechaPrestamo AS [Fecha], vp.Estado AS [Estado],
           vp.FechaDevolucion AS [Fecha devolución], vp.DNIUsuario AS [DNI usuario],
           vp.Usuario AS [Usuario], vp.Material AS [Material], vp.Cantidad AS [Cantidad],
           vp.Dias AS [Días], vp.Personal AS [Atendido por]
      FROM dbo.VistaPrestamos vp
     WHERE (@Desde IS NULL OR vp.FechaPrestamo >= @Desde)
       AND (@Hasta IS NULL OR vp.FechaPrestamo < DATEADD(DAY, 1, @Hasta))
       AND (@Estado = N'' OR vp.Estado = @Estado)
     ORDER BY vp.FechaPrestamo DESC, vp.IDPrestamo DESC;
END
GO

IF OBJECT_ID('dbo.Reporte_Devoluciones', 'P') IS NOT NULL DROP PROCEDURE dbo.Reporte_Devoluciones;
GO
CREATE PROCEDURE dbo.Reporte_Devoluciones
    @Desde DATETIME = NULL, @Hasta DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT vd.IDDevoluciones AS [Devolución], vd.FechaDevolucion AS [Fecha devolución],
           vd.IDPrestamo AS [Préstamo], vd.FechaPrestamo AS [Fecha préstamo],
           vd.DNIUsuario AS [DNI usuario], vd.Usuario AS [Usuario], vd.Material AS [Material],
           vd.Cantidad AS [Cantidad], vd.Condicion AS [Condición], vd.Observacion AS [Observación]
      FROM dbo.VistaDevoluciones vd
     WHERE (@Desde IS NULL OR vd.FechaDevolucion >= @Desde)
       AND (@Hasta IS NULL OR vd.FechaDevolucion < DATEADD(DAY, 1, @Hasta))
     ORDER BY vd.FechaDevolucion DESC;
END
GO

IF OBJECT_ID('dbo.Reporte_Salidas', 'P') IS NOT NULL DROP PROCEDURE dbo.Reporte_Salidas;
GO
CREATE PROCEDURE dbo.Reporte_Salidas
    @Desde DATETIME = NULL, @Hasta DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT vs.IDSalidas AS [Salida], vs.FechaSalida AS [Fecha], vs.DNIUsuario AS [DNI usuario],
           vs.Usuario AS [Usuario / Área], vs.ProgramaEstudios AS [Programa],
           vs.Material AS [Material], vs.Cantidad AS [Cantidad], vs.Personal AS [Entregado por]
      FROM dbo.VistaSalidas vs
     WHERE (@Desde IS NULL OR vs.FechaSalida >= @Desde)
       AND (@Hasta IS NULL OR vs.FechaSalida < DATEADD(DAY, 1, @Hasta))
     ORDER BY vs.FechaSalida DESC, vs.IDSalidas DESC;
END
GO

IF OBJECT_ID('dbo.Reporte_PrestamosPendientes', 'P') IS NOT NULL DROP PROCEDURE dbo.Reporte_PrestamosPendientes;
GO
CREATE PROCEDURE dbo.Reporte_PrestamosPendientes
    @Desde DATETIME = NULL, @Hasta DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT vp.IDPrestamo AS [Préstamo], vp.FechaPrestamo AS [Fecha], vp.Dias AS [Días],
           vp.DNIUsuario AS [DNI usuario], vp.Usuario AS [Usuario], vp.TelefonoUsuario AS [Teléfono],
           vp.Material AS [Material], vp.Cantidad AS [Cantidad], vp.Personal AS [Atendido por]
      FROM dbo.VistaPrestamos vp
     WHERE vp.Estado = N'Pendiente'
       AND (@Desde IS NULL OR vp.FechaPrestamo >= @Desde)
       AND (@Hasta IS NULL OR vp.FechaPrestamo < DATEADD(DAY, 1, @Hasta))
     ORDER BY vp.Dias DESC, vp.Usuario;
END
GO

PRINT N'Base de datos actualizada correctamente.';
GO

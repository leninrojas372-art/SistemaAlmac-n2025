/* =====================================================================
   SISTEMA ALMACÉN 2025 - ACTUALIZACIÓN 2: DETALLE DE SOLICITUD
   ---------------------------------------------------------------------
   Ejecutar DESPUÉS de 01_ActualizarBD_ControlPrestamos.sql
   (se puede ejecutar varias veces sin romper nada).

   Qué hace:
     1. Agrega Solicitud.Estado  (Pendiente / Atendida / Anulada).
     2. Crea la tabla DetalleSolicitud (qué materiales y cuántos pidió el usuario).
     3. Las solicitudes antiguas que ya tienen préstamo o salida quedan como Atendida.
     4. Procedimientos para registrar, modificar, anular y consultar solicitudes
        con su detalle.
     5. RegistrarPrestamo y RegistrarSalidas marcan la solicitud como Atendida
        (y no permiten atender una solicitud Anulada).
     6. Nueva consulta de control: solicitudes pendientes de atender.

   La solicitud NO descuenta stock: solo registra el pedido.
   El stock se descuenta al registrar el préstamo o la salida.
   ===================================================================== */

USE [BD_Almacén2025];
GO

/* =====================================================================
   1. SOLICITUD.ESTADO
   ===================================================================== */
IF COL_LENGTH('dbo.Solicitud', 'Estado') IS NULL
    ALTER TABLE dbo.Solicitud ADD Estado NVARCHAR(15) NOT NULL
        CONSTRAINT DF_Solicitud_Estado DEFAULT (N'Pendiente');
GO
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Solicitud_Estado')
    ALTER TABLE dbo.Solicitud ADD CONSTRAINT CK_Solicitud_Estado
        CHECK (Estado IN (N'Pendiente', N'Atendida', N'Anulada'));
GO

/* 3. Solicitudes que ya fueron atendidas con un préstamo o una salida */
UPDATE s SET s.Estado = N'Atendida'
  FROM dbo.Solicitud s
 WHERE s.Estado = N'Pendiente'
   AND (EXISTS (SELECT 1 FROM dbo.Prestamo p WHERE p.IDSolicitud = s.IDSolicitud)
        OR EXISTS (SELECT 1 FROM dbo.Salidas sa WHERE sa.IDSolicitud = s.IDSolicitud));
GO

/* =====================================================================
   2. TABLA DETALLESOLICITUD
   ===================================================================== */
IF OBJECT_ID('dbo.DetalleSolicitud', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.DetalleSolicitud
    (
        IDDetalleSolicitud INT IDENTITY(1,1) NOT NULL
            CONSTRAINT PK_DetalleSolicitud PRIMARY KEY,
        IDSolicitud        INT NOT NULL
            CONSTRAINT FK_DetalleSolicitud_Solicitud REFERENCES dbo.Solicitud (IDSolicitud),
        IDMaterial         INT NOT NULL
            CONSTRAINT FK_DetalleSolicitud_Material REFERENCES dbo.Material (IDMaterial),
        Cantidad           INT NOT NULL
            CONSTRAINT CK_DetalleSolicitud_Cantidad CHECK (Cantidad > 0)
    );
    CREATE INDEX IX_DetalleSolicitud_IDSolicitud ON dbo.DetalleSolicitud (IDSolicitud);
END
GO

/* =====================================================================
   4. PROCEDIMIENTOS DE SOLICITUD
   ===================================================================== */

/* Registrar cabecera. Mantiene los mismos parámetros de antes y agrega
   @NuevoId (opcional) para poder registrar el detalle a continuación. */
IF OBJECT_ID('dbo.RegistrarSolicitud', 'P') IS NOT NULL DROP PROCEDURE dbo.RegistrarSolicitud;
GO
CREATE PROCEDURE dbo.RegistrarSolicitud
    @IDSolicitud INT = 0,
    @DNIUsuario  NVARCHAR(8),
    @Fecha       DATETIME,
    @NuevoId     INT = NULL OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM dbo.Usuarios WHERE DNIUsuario = LTRIM(RTRIM(@DNIUsuario)))
        THROW 50100, N'El usuario indicado no existe. Regístrelo primero en Maestros > Usuarios.', 1;

    INSERT INTO dbo.Solicitud (DNIUsuario, Fecha, Estado)
    VALUES (LTRIM(RTRIM(@DNIUsuario)), ISNULL(@Fecha, GETDATE()), N'Pendiente');

    SET @NuevoId = SCOPE_IDENTITY();
END
GO

IF OBJECT_ID('dbo.RegistrarDetalleSolicitud', 'P') IS NOT NULL DROP PROCEDURE dbo.RegistrarDetalleSolicitud;
GO
CREATE PROCEDURE dbo.RegistrarDetalleSolicitud
    @IDSolicitud INT,
    @IDMaterial  INT,
    @Cantidad    INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @msg NVARCHAR(400);

    IF @Cantidad IS NULL OR @Cantidad <= 0
        THROW 50101, N'La cantidad solicitada debe ser mayor a 0.', 1;

    IF NOT EXISTS (SELECT 1 FROM dbo.Solicitud WHERE IDSolicitud = @IDSolicitud AND Estado = N'Pendiente')
        THROW 50102, N'Solo se pueden agregar materiales a una solicitud en estado Pendiente.', 1;

    IF NOT EXISTS (SELECT 1 FROM dbo.Material WHERE IDMaterial = @IDMaterial)
    BEGIN
        SET @msg = N'El material con ID ' + CAST(@IDMaterial AS NVARCHAR(10)) + N' no existe.';
        THROW 50103, @msg, 1;
    END

    /* Si el material ya estaba en la solicitud, se suma la cantidad */
    IF EXISTS (SELECT 1 FROM dbo.DetalleSolicitud WHERE IDSolicitud = @IDSolicitud AND IDMaterial = @IDMaterial)
        UPDATE dbo.DetalleSolicitud SET Cantidad = Cantidad + @Cantidad
         WHERE IDSolicitud = @IDSolicitud AND IDMaterial = @IDMaterial;
    ELSE
        INSERT INTO dbo.DetalleSolicitud (IDSolicitud, IDMaterial, Cantidad)
        VALUES (@IDSolicitud, @IDMaterial, @Cantidad);
END
GO

/* Borra el detalle para volver a grabarlo (al modificar una solicitud pendiente) */
IF OBJECT_ID('dbo.EliminarDetallesSolicitud', 'P') IS NOT NULL DROP PROCEDURE dbo.EliminarDetallesSolicitud;
GO
CREATE PROCEDURE dbo.EliminarDetallesSolicitud
    @IDSolicitud INT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM dbo.Solicitud WHERE IDSolicitud = @IDSolicitud AND Estado = N'Pendiente')
        THROW 50104, N'Solo se pueden modificar los materiales de una solicitud en estado Pendiente.', 1;
    DELETE FROM dbo.DetalleSolicitud WHERE IDSolicitud = @IDSolicitud;
END
GO

IF OBJECT_ID('dbo.ModificarSolicitud', 'P') IS NOT NULL DROP PROCEDURE dbo.ModificarSolicitud;
GO
CREATE PROCEDURE dbo.ModificarSolicitud
    @IDSolicitud INT,
    @DNIUsuario  NVARCHAR(8),
    @Fecha       DATETIME
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Estado NVARCHAR(15);
    SELECT @Estado = Estado FROM dbo.Solicitud WHERE IDSolicitud = @IDSolicitud;

    IF @Estado IS NULL
        THROW 50105, N'La solicitud no existe.', 1;
    IF @Estado <> N'Pendiente'
        THROW 50106, N'Solo se puede modificar una solicitud en estado Pendiente.', 1;
    IF NOT EXISTS (SELECT 1 FROM dbo.Usuarios WHERE DNIUsuario = LTRIM(RTRIM(@DNIUsuario)))
        THROW 50100, N'El usuario indicado no existe.', 1;

    UPDATE dbo.Solicitud
       SET DNIUsuario = LTRIM(RTRIM(@DNIUsuario)), Fecha = @Fecha
     WHERE IDSolicitud = @IDSolicitud;
END
GO

IF OBJECT_ID('dbo.AnularSolicitud', 'P') IS NOT NULL DROP PROCEDURE dbo.AnularSolicitud;
GO
CREATE PROCEDURE dbo.AnularSolicitud
    @IDSolicitud INT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM dbo.Solicitud WHERE IDSolicitud = @IDSolicitud AND Estado = N'Pendiente')
        THROW 50107, N'Solo se puede anular una solicitud en estado Pendiente.', 1;
    UPDATE dbo.Solicitud SET Estado = N'Anulada' WHERE IDSolicitud = @IDSolicitud;
END
GO

IF OBJECT_ID('dbo.EliminarSolicitud', 'P') IS NOT NULL DROP PROCEDURE dbo.EliminarSolicitud;
GO
CREATE PROCEDURE dbo.EliminarSolicitud
    @IDSolicitud INT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.Prestamo WHERE IDSolicitud = @IDSolicitud)
       OR EXISTS (SELECT 1 FROM dbo.Salidas WHERE IDSolicitud = @IDSolicitud)
        THROW 50108, N'No se puede eliminar: la solicitud ya fue atendida con un préstamo o una salida. Puede dejarla como está.', 1;

    BEGIN TRY
        BEGIN TRAN;
        DELETE FROM dbo.DetalleSolicitud WHERE IDSolicitud = @IDSolicitud;
        DELETE FROM dbo.Solicitud WHERE IDSolicitud = @IDSolicitud;
        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END
GO

/* Lista de solicitudes para el formulario (las 3 primeras columnas no cambian de orden) */
IF OBJECT_ID('dbo.CargarSolicitud', 'P') IS NOT NULL DROP PROCEDURE dbo.CargarSolicitud;
GO
CREATE PROCEDURE dbo.CargarSolicitud
AS
BEGIN
    SET NOCOUNT ON;
    SELECT so.IDSolicitud, RTRIM(so.DNIUsuario) AS DNIUsuario, so.Fecha, so.Estado,
           RTRIM(u.ApellidosNombres) AS Usuario,
           STUFF((SELECT N', ' + CAST(ds.Cantidad AS NVARCHAR(10)) + N' ' + RTRIM(m.Nombre)
                    FROM dbo.DetalleSolicitud ds
                    JOIN dbo.Material m ON m.IDMaterial = ds.IDMaterial
                   WHERE ds.IDSolicitud = so.IDSolicitud
                   FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, N'') AS Materiales
      FROM dbo.Solicitud so
      LEFT JOIN dbo.Usuarios u ON u.DNIUsuario = so.DNIUsuario
     ORDER BY so.IDSolicitud DESC;
END
GO

/* Datos de una solicitud (cabecera) */
IF OBJECT_ID('dbo.Consulta_Solicitud', 'P') IS NOT NULL DROP PROCEDURE dbo.Consulta_Solicitud;
GO
CREATE PROCEDURE dbo.Consulta_Solicitud
    @IDSolicitud INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT so.IDSolicitud, RTRIM(so.DNIUsuario) AS DNIUsuario, RTRIM(u.ApellidosNombres) AS Usuario,
           so.Fecha, so.Estado
      FROM dbo.Solicitud so
      LEFT JOIN dbo.Usuarios u ON u.DNIUsuario = so.DNIUsuario
     WHERE so.IDSolicitud = @IDSolicitud;
END
GO

/* Materiales pedidos en una solicitud, con el stock disponible actual */
IF OBJECT_ID('dbo.Consulta_DetalleSolicitud', 'P') IS NOT NULL DROP PROCEDURE dbo.Consulta_DetalleSolicitud;
GO
CREATE PROCEDURE dbo.Consulta_DetalleSolicitud
    @IDSolicitud INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ds.IDMaterial         AS IDMaterial,
           RTRIM(m.Nombre)       AS Material,
           RTRIM(m.Estado)       AS EstadoMaterial,
           ds.Cantidad           AS Cantidad,
           m.Stock               AS Stock
      FROM dbo.DetalleSolicitud ds
      JOIN dbo.Material m ON m.IDMaterial = ds.IDMaterial
     WHERE ds.IDSolicitud = @IDSolicitud
     ORDER BY m.Nombre;
END
GO

/* Solicitudes para los buscadores de Préstamo y Salida (pendientes primero) */
IF OBJECT_ID('dbo.Consulta_Solicitudes', 'P') IS NOT NULL DROP PROCEDURE dbo.Consulta_Solicitudes;
GO
CREATE PROCEDURE dbo.Consulta_Solicitudes
AS
BEGIN
    SET NOCOUNT ON;
    SELECT so.IDSolicitud, RTRIM(so.DNIUsuario) AS DNIUsuario, RTRIM(u.ApellidosNombres) AS Usuario,
           so.Fecha, so.Estado,
           STUFF((SELECT N', ' + CAST(ds.Cantidad AS NVARCHAR(10)) + N' ' + RTRIM(m.Nombre)
                    FROM dbo.DetalleSolicitud ds
                    JOIN dbo.Material m ON m.IDMaterial = ds.IDMaterial
                   WHERE ds.IDSolicitud = so.IDSolicitud
                   FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, N'') AS Materiales
      FROM dbo.Solicitud so
      LEFT JOIN dbo.Usuarios u ON u.DNIUsuario = so.DNIUsuario
     WHERE so.Estado <> N'Anulada'
     ORDER BY CASE so.Estado WHEN N'Pendiente' THEN 0 ELSE 1 END, so.IDSolicitud DESC;
END
GO

/* 6. CONTROL: solicitudes pendientes de atender */
IF OBJECT_ID('dbo.Control_SolicitudesPendientes', 'P') IS NOT NULL DROP PROCEDURE dbo.Control_SolicitudesPendientes;
GO
CREATE PROCEDURE dbo.Control_SolicitudesPendientes
    @Texto NVARCHAR(100) = N''
AS
BEGIN
    SET NOCOUNT ON;
    SET @Texto = LTRIM(RTRIM(ISNULL(@Texto, N'')));
    SELECT so.IDSolicitud                        AS [Solicitud],
           so.Fecha                              AS [Fecha],
           DATEDIFF(DAY, so.Fecha, GETDATE())    AS [Días],
           RTRIM(so.DNIUsuario)                  AS [DNI usuario],
           RTRIM(u.ApellidosNombres)             AS [Usuario],
           RTRIM(u.ProgramaEstudios)             AS [Programa],
           STUFF((SELECT N', ' + CAST(ds.Cantidad AS NVARCHAR(10)) + N' ' + RTRIM(m.Nombre)
                    FROM dbo.DetalleSolicitud ds
                    JOIN dbo.Material m ON m.IDMaterial = ds.IDMaterial
                   WHERE ds.IDSolicitud = so.IDSolicitud
                   FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, N'') AS [Materiales solicitados],
           CASE WHEN EXISTS (SELECT 1 FROM dbo.DetalleSolicitud ds
                               JOIN dbo.Material m ON m.IDMaterial = ds.IDMaterial
                              WHERE ds.IDSolicitud = so.IDSolicitud AND m.Stock < ds.Cantidad)
                THEN N'Falta stock' ELSE N'Hay stock' END AS [Disponibilidad]
      FROM dbo.Solicitud so
      LEFT JOIN dbo.Usuarios u ON u.DNIUsuario = so.DNIUsuario
     WHERE so.Estado = N'Pendiente'
       AND (@Texto = N''
            OR so.DNIUsuario LIKE @Texto + N'%'
            OR u.ApellidosNombres LIKE N'%' + @Texto + N'%'
            OR CAST(so.IDSolicitud AS NVARCHAR(10)) = @Texto)
     ORDER BY so.Fecha, so.IDSolicitud;
END
GO

/* =====================================================================
   5. PRÉSTAMO Y SALIDA: marcan la solicitud como Atendida
   ===================================================================== */
IF OBJECT_ID('dbo.RegistrarPrestamo', 'P') IS NOT NULL DROP PROCEDURE dbo.RegistrarPrestamo;
GO
CREATE PROCEDURE dbo.RegistrarPrestamo
    @IDPrestamo  INT = 0,
    @DNIPersonal NCHAR(8),
    @IDSolicitud INT,
    @Fecha       DATETIME,
    @NuevoId     INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @EstadoSol NVARCHAR(15);
    SELECT @EstadoSol = Estado FROM dbo.Solicitud WHERE IDSolicitud = @IDSolicitud;

    IF @EstadoSol IS NULL
        THROW 50010, N'La solicitud indicada no existe. Registre primero la solicitud del usuario.', 1;
    IF @EstadoSol = N'Anulada'
        THROW 50012, N'La solicitud está anulada y no se puede atender.', 1;
    IF NOT EXISTS (SELECT 1 FROM dbo.Personal WHERE DNIPersonal = @DNIPersonal)
        THROW 50011, N'El personal indicado no existe.', 1;

    INSERT INTO dbo.Prestamo (DNIPersonal, IDSolicitud, Fecha, Estado, StockDescontado)
    VALUES (@DNIPersonal, @IDSolicitud, ISNULL(@Fecha, GETDATE()), N'Pendiente', 1);

    SET @NuevoId = SCOPE_IDENTITY();

    UPDATE dbo.Solicitud SET Estado = N'Atendida' WHERE IDSolicitud = @IDSolicitud;
END
GO

IF OBJECT_ID('dbo.RegistrarSalidas', 'P') IS NOT NULL DROP PROCEDURE dbo.RegistrarSalidas;
GO
CREATE PROCEDURE dbo.RegistrarSalidas
    @IDSalidas   INT = 0,
    @DNIPersonal NCHAR(8),
    @IDSolicitud INT,
    @Fecha       DATETIME,
    @NuevoId     INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @EstadoSol NVARCHAR(15);
    SELECT @EstadoSol = Estado FROM dbo.Solicitud WHERE IDSolicitud = @IDSolicitud;

    IF @EstadoSol IS NULL
        THROW 50040, N'La solicitud indicada no existe. Registre primero la solicitud del usuario.', 1;
    IF @EstadoSol = N'Anulada'
        THROW 50042, N'La solicitud está anulada y no se puede atender.', 1;
    IF NOT EXISTS (SELECT 1 FROM dbo.Personal WHERE DNIPersonal = @DNIPersonal)
        THROW 50041, N'El personal indicado no existe.', 1;

    INSERT INTO dbo.Salidas (DNIPersonal, IDSolicitud, Fecha, StockDescontado)
    VALUES (@DNIPersonal, @IDSolicitud, ISNULL(@Fecha, GETDATE()), 1);

    SET @NuevoId = SCOPE_IDENTITY();

    UPDATE dbo.Solicitud SET Estado = N'Atendida' WHERE IDSolicitud = @IDSolicitud;
END
GO

/* Al eliminar un préstamo o una salida, si la solicitud ya no tiene ninguna
   operación asociada, vuelve a quedar Pendiente */
IF OBJECT_ID('dbo.EliminarPrestamo', 'P') IS NOT NULL DROP PROCEDURE dbo.EliminarPrestamo;
GO
CREATE PROCEDURE dbo.EliminarPrestamo
    @IDPrestamo INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @IDSolicitud INT;
    SELECT @IDSolicitud = IDSolicitud FROM dbo.Prestamo WHERE IDPrestamo = @IDPrestamo;

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

        IF NOT EXISTS (SELECT 1 FROM dbo.Prestamo WHERE IDSolicitud = @IDSolicitud)
           AND NOT EXISTS (SELECT 1 FROM dbo.Salidas WHERE IDSolicitud = @IDSolicitud)
            UPDATE dbo.Solicitud SET Estado = N'Pendiente'
             WHERE IDSolicitud = @IDSolicitud AND Estado = N'Atendida';
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
    DECLARE @IDSolicitud INT;
    SELECT @IDSolicitud = IDSolicitud FROM dbo.Salidas WHERE IDSalidas = @IDSalidas;
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

        IF NOT EXISTS (SELECT 1 FROM dbo.Prestamo WHERE IDSolicitud = @IDSolicitud)
           AND NOT EXISTS (SELECT 1 FROM dbo.Salidas WHERE IDSolicitud = @IDSolicitud)
            UPDATE dbo.Solicitud SET Estado = N'Pendiente'
             WHERE IDSolicitud = @IDSolicitud AND Estado = N'Atendida';
        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END
GO

/* Un material usado en solicitudes tampoco se puede eliminar */
IF OBJECT_ID('dbo.EliminarMaterial', 'P') IS NOT NULL DROP PROCEDURE dbo.EliminarMaterial;
GO
CREATE PROCEDURE dbo.EliminarMaterial
    @IDMaterial INT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.DetallePrestamo WHERE IDMaterial = @IDMaterial)
       OR EXISTS (SELECT 1 FROM dbo.DetalleSalidas WHERE IDmaterial = @IDMaterial)
       OR EXISTS (SELECT 1 FROM dbo.DetalleSolicitud WHERE IDMaterial = @IDMaterial)
        THROW 50002, N'No se puede eliminar: el material tiene solicitudes, préstamos o salidas registradas.', 1;
    DELETE FROM dbo.Material WHERE IDMaterial = @IDMaterial;
END
GO

/* Un usuario con solicitudes tampoco se puede eliminar (evita registros huérfanos) */
IF OBJECT_ID('dbo.EliminarUsuarios', 'P') IS NOT NULL DROP PROCEDURE dbo.EliminarUsuarios;
GO
CREATE PROCEDURE dbo.EliminarUsuarios
    @DNIUsuario NCHAR(8)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.Solicitud WHERE DNIUsuario = LTRIM(RTRIM(@DNIUsuario)))
        THROW 50109, N'No se puede eliminar: el usuario tiene solicitudes registradas.', 1;
    DELETE FROM dbo.Usuarios WHERE DNIUsuario = @DNIUsuario;
END
GO

PRINT N'Detalle de solicitud instalado correctamente.';
GO

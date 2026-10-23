# Sistema Almacén 2025: actualización

## 1. Cómo instalarla (hazlo en este orden)

1. **Copia de seguridad.** Copia la carpeta `BD_Actualizada` (los archivos `.mdf` y `.ldf`) a otro lugar.
2. **Actualiza la base de datos.**
   - En Visual Studio abre **Ver → Explorador de objetos de SQL Server** (o usa SQL Server Management Studio).
   - Conéctate a `(localdb)\MSSQLLocalDB` y selecciona la base **BD_Almacén2025**.
   - Clic derecho → **Nueva consulta**. Pega todo el contenido de `Scripts/01_ActualizarBD_ControlPrestamos.sql` y ejecútalo.
   - Al final debe aparecer: `Base de datos actualizada correctamente.`
   - El script **no borra datos** y se puede volver a ejecutar sin problema.
3. **Abre la solución** `SistemaAlmacén2025.sln`, luego **Compilar → Recompilar solución** y ejecuta el programa.

> Si Visual Studio muestra un aviso sobre el DataSet tipado (`BD_Almacén2025DataSet`), ignóralo:
> las vistas conservan las mismas columnas que usan tus reportes Crystal.

---

## 2. Qué se cambió en la base de datos

| Cambio | Para qué sirve |
|---|---|
| `Prestamo.Estado` (`Pendiente` / `Devuelto`) | Responder "¿quién no ha devuelto?" |
| `Prestamo.FechaDevolucion` | Saber cuándo se devolvió |
| `Prestamo.StockDescontado`, `Salidas.StockDescontado` | Los préstamos y salidas **antiguos** no tocan el stock al devolverse o eliminarse (su stock nunca se descontó) |
| `Material.Stock` pasa de `nchar(3)` a `INT` | Para poder sumar y restar (antes el máximo era 999 y era texto) |
| Préstamos que ya tenían devolución | Quedan como `Devuelto` automáticamente |

**Movimiento de stock (automático y en transacción):**

- **Préstamo:** resta del stock. Si un material no alcanza, **no se guarda nada** y se muestra el motivo.
- **Devolución:** marca el préstamo como `Devuelto` y devuelve al stock todo lo prestado.
- **Salida:** resta del stock de forma definitiva.
- **Eliminar una devolución:** el préstamo vuelve a quedar `Pendiente` y el stock se descuenta otra vez.

**Correcciones en la BD:**

- `CargarPrestamo` devolvía la tabla Personal.
- `ModificarSalidas` usaba una columna que no existe.
- Las vistas `VistaConsulta_Material` y `VistaConsulta_Devoluciones` usaban `CROSS JOIN`, así que repetían filas.

---

## 3. El menú queda así

```
Archivo        → Cerrar sesión, Salir
1. Maestros    → Materiales, Usuarios, Personal
2. Operaciones → Solicitud de material, Préstamo, Salida, Devolución
3. Control     → Materiales disponibles, Materiales prestados, Préstamos pendientes,
                 Devoluciones, Historial por usuario
4. Consultas   → Buscar material, Buscar usuario, Buscar préstamo, Buscar salida, Buscar devolución
5. Reportes    → Materiales, Préstamos, Devoluciones, Salidas, Préstamos pendientes
```

### Las 3 preguntas del encargado

| Pregunta | Dónde se responde |
|---|---|
| **¿Quién tiene este material?** | Control → Materiales prestados (escribe el nombre del material) |
| **¿Qué materiales tiene esta persona?** | Consultas → Buscar usuario (selecciónalo y mira la pestaña "Materiales que tiene ahora") |
| **¿Quién todavía no ha devuelto?** | Control → Préstamos pendientes (solo muestra préstamos en estado Pendiente) |

- Los préstamos con **más de 7 días** se resaltan en rojo. Para cambiar el número, edita `DiasAlertaPrestamo` en `Control/ModUtilidades.vb`.
- En *Préstamos pendientes*, **doble clic** abre Devoluciones con el préstamo ya cargado.
- Todas las pantallas de Control, Consultas y Reportes tienen botones **IMPRIMIR** (con vista previa) y **EXCEL** (exporta a CSV).
- Los reportes de Materiales, Devoluciones y Salidas también tienen el botón **VER EN CRYSTAL**, que usa tus reportes `.rpt` existentes.

---

## 4. Cambios en el código

**Archivos nuevos**

- `Control/ClsControl.vb`: consultas de Control, Consultas y Reportes.
- `Control/ModSesion.vb`: guarda quién inició sesión. Préstamo y Salida proponen a esa persona como "atendido por".
- `Control/ModUtilidades.vb`: formato de grillas, exportar a Excel y resaltar préstamos atrasados.
- `Control/FrmControl.vb`: módulo 3 completo (5 pestañas).
- `Consultas/FrmConsulta_Usuario.vb` y `Consultas/FrmConsulta_Prestamo.vb`.
- `Reportes/FrmReporteListado.vb`: los 5 reportes con filtro de fechas.
- `Reportes/ClsImpresionGrid.vb`: imprime cualquier grilla.
- `CRUD/Clases/ClsItemDetalle.vb`

**Archivos modificados**

- `ClsConexion`: una sola cadena de conexión (`ClsConexion.Cadena`) y mensajes de error legibles. Los métodos Registrar, Modificar y Eliminar ahora devuelven `True`/`False`, y el mensaje de "registrado correctamente" solo aparece si de verdad se guardó.
- `FrmPrestamo` / `FrmSalidas`: validan el stock antes de agregar a la lista y guardan todo en una sola transacción. Avisan si prestas un material *fungible* o entregas uno *no fungible*. Con la tecla Supr quitas un material de la lista.
- `FrmDevoluciones`: pide confirmación mostrando los materiales que se devuelven. El buscador muestra **solo préstamos pendientes**.
- `FrmAcceso`: guarda la sesión, se oculta al ingresar y la tecla Enter equivale a INGRESAR.
- `FrmSolicitud`: pone la fecha de hoy por defecto y valida el formato de la fecha.
- Buscadores corregidos:
  - personal para préstamo o salida: consultaba la tabla equivocada y ahora ya no muestra la contraseña;
  - usuario para solicitud: consultaba la tabla equivocada;
  - material para salida: se caía, porque buscaba `IDMaterial` en la tabla Salidas.

---

## 5. Limitaciones (para una siguiente versión)

- **La devolución es del préstamo completo.** Si se prestaron 3 materiales, se devuelven los 3 juntos. Para devoluciones parciales haría falta una tabla `DetalleDevolucion`.
- **La solicitud no guarda qué materiales se pidieron.** Solo guarda usuario y fecha; los materiales quedan en el detalle del préstamo o de la salida.
- **"Área" no es un campo aparte.** Se usa el usuario que hace la solicitud y su programa de estudios.
- **Las contraseñas del personal se guardan en texto plano**, como antes.

---

## 6. Crystal Reports (opcional)

El proyecto compila **sin** Crystal Reports. Los botones IMPRIMIR usan la vista previa propia del sistema.
Si instalas *SAP Crystal Reports for Visual Studio* y quieres volver a usar los `.rpt`:
Proyecto → Propiedades → Compilar → Opciones de compilación avanzadas → **Constantes personalizadas**: `CRYSTAL=True`.

---

## 7. Actualización 2: Detalle de solicitud

**Ejecuta primero `Scripts/01_ActualizarBD_ControlPrestamos.sql` (si no lo hiciste) y luego `Scripts/02_DetalleSolicitud.sql`.**

Base de datos:
- Tabla nueva **DetalleSolicitud** (IDDetalleSolicitud, IDSolicitud, IDMaterial, Cantidad).
- **Solicitud.Estado**: Pendiente / Atendida / Anulada. Las solicitudes antiguas que ya tenían préstamo o salida quedan como *Atendida*.
- Al registrar un préstamo o una salida, la solicitud pasa a *Atendida*. Una solicitud *Anulada* no se puede atender.
- Si se elimina el préstamo o la salida, la solicitud vuelve a *Pendiente*.

Sistema:
- **Solicitud de material**: ahora se agregan los materiales y cantidades pedidos (combo con el stock actual). Botón nuevo **ANULAR**. Las solicitudes atendidas o anuladas quedan en solo lectura.
- **Préstamo y Salida**: al elegir la solicitud, sus materiales se cargan solos en la lista (si falta stock se carga solo lo disponible y se avisa). Se pueden quitar o agregar materiales antes de registrar.
- **Control → Solicitudes pendientes de atender**: pestaña nueva con los pedidos sin atender (en amarillo si falta stock). Doble clic para atenderla con un préstamo o una salida.
- La solicitud **no descuenta stock**: el stock se descuenta al registrar el préstamo o la salida.

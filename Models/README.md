# Estructura de Datos del Proyecto TPV Hostelería

## Modelos de Datos

Este proyecto ahora utiliza clases de C# para gestionar los datos de ejemplo.

### Carpeta `Models/`

#### `Producto.cs`
Representa un producto del menú con las siguientes propiedades:
- **Nombre**: Nombre del producto
- **Descripcion**: Descripción breve
- **Precio**: Precio en decimal
- **Emoji**: Icono emoji del producto
- **Categoria**: Categoría principal (Entrantes, Platos, Postres, Bebidas)
- **Subcategoria**: Subcategoría (Ensaladas, Huevos, etc.)
- **Alergenos**: Lista de alérgenos
- **PrecioFormateado**: Propiedad calculada que devuelve el precio con formato "X,XX €"

#### `Cliente.cs`
Representa un cliente del sistema con las siguientes propiedades:
- **Nombre**: Nombre completo del cliente
- **Direccion**: Dirección del cliente
- **Telefono**: Número de teléfono
- **Email**: Correo electrónico
- **Alergias**: Lista de alergias alimentarias
- **PuntosAcumulados**: Puntos de fidelización
- **MetodoPagoPreferido**: Método de pago preferido (Efectivo/Tarjeta)
- **NombreConIcono**: Propiedad calculada que devuelve el nombre con icono

#### `DatosEjemplo.cs`
Clase estática que proporciona datos de ejemplo para el sistema:
- **ObtenerProductos()**: Devuelve una lista de 9 productos de ejemplo
- **ObtenerClientes()**: Devuelve una lista de 3 clientes de ejemplo

## Productos Actuales

| Categoría | Subcategoría | Producto | Precio |
|-----------|--------------|----------|---------|
| Entrantes | Ensaladas | Ensalada César | 9,50 € |
| Entrantes | Huevos | Huevos Rotos | 12,00 € |
| Entrantes | Arroces y Pastas | Paella | 15,50 € |
| Entrantes | Arroces y Pastas | Espaguetis Carbonara | 11,00 € |
| Entrantes | Asados | Pollo Asado | 13,50 € |
| Entrantes | Pescados | Bacalao al Pil Pil | 18,00 € |
| Platos | - | Cocido Madrileño | 14,50 € |
| Postres | - | Tarta de Queso | 5,50 € |
| Bebidas | - | Cerveza | 2,50 € |

## Clientes Actuales

| Nombre | Dirección | Teléfono | Email | Puntos |
|--------|-----------|----------|-------|---------|
| Alberto Cortés | C/Finlandia, 27 | 606428412 | Alberto.Cortes1@alu.uclm.es | 150 |
| Iván Jesús Mora | Av. de España, 15, 3ºB | 695847231 | ivan.mora@outlook.es | 85 |
| Jesus Márquez | C/ Toledo, 42, 1ºA | 612395847 | marquez.garcia@gmail.com | 220 |

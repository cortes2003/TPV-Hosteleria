using System;
using System.Collections.Generic;

namespace TPV_Hosteleria.Models
{
    /// <summary>
    /// Clase para representar los datos de ejemplo del sistema
    /// </summary>
    public static class DatosEjemplo
    {
        /// <summary>
        /// Obtiene la lista de productos de ejemplo organizados por categoría
        /// </summary>
        public static List<Producto> ObtenerProductos()
        {
            return new List<Producto>
            {
                // ENTRANTES - Ensaladas
                new Producto
                {
                    Nombre = "Ensalada César",
                    Descripcion = "Lechuga, pollo...",
                    Precio = 9.50m,
                    Emoji = "??",
                    Categoria = "Entrantes",
                    Subcategoria = "Ensaladas",
                    Alergenos = new List<string> { "Gluten" },
                    Imagen = "Ensalada_Cesar.png"
                },

                // ENTRANTES - Huevos
                new Producto
                {
                    Nombre = "Huevos Rotos",
                    Descripcion = "Jamón y patatas",
                    Precio = 12.00m,
                    Emoji = "??",
                    Categoria = "Entrantes",
                    Subcategoria = "Huevos",
                    Alergenos = new List<string>(),
                    Imagen = "huevos-rotos-con-jamon.png"
                },

                // ENTRANTES - Arroces y Pastas
                new Producto
                {
                    Nombre = "Paella",
                    Descripcion = "Arroz, mariscos...",
                    Precio = 15.50m,
                    Emoji = "??",
                    Categoria = "Entrantes",
                    Subcategoria = "Arroces y Pastas",
                    Alergenos = new List<string> { "Pescado" },
                    Imagen = "paella-valenciana.jpg"
                },
                new Producto
                {
                    Nombre = "Espaguetis Carbonara",
                    Descripcion = "Pasta, huevo, bacon",
                    Precio = 11.00m,
                    Emoji = "??",
                    Categoria = "Entrantes",
                    Subcategoria = "Arroces y Pastas",
                    Alergenos = new List<string> { "Gluten", "Huevos" },
                    Imagen = "espaguetis-a-la-carbonara.jpg"
                },

                // ENTRANTES - Asados
                new Producto
                {
                    Nombre = "Pollo Asado",
                    Descripcion = "Pollo, especias...",
                    Precio = 13.50m,
                    Emoji = "??",
                    Categoria = "Entrantes",
                    Subcategoria = "Asados",
                    Alergenos = new List<string>(),
                    Imagen = "Pollo_Asado.jpg"
                },

                // ENTRANTES - Pescados
                new Producto
                {
                    Nombre = "Bacalao al Pil Pil",
                    Descripcion = "Bacalao, ajo, aceite",
                    Precio = 18.00m,
                    Emoji = "??",
                    Categoria = "Entrantes",
                    Subcategoria = "Pescados",
                    Alergenos = new List<string> { "Pescado" },
                    Imagen = "bacalao-al-pil-pil.jpg"
                },

                // PLATOS
                new Producto
                {
                    Nombre = "Cocido Madrileño",
                    Descripcion = "Garbanzos, carne...",
                    Precio = 14.50m,
                    Emoji = "??",
                    Categoria = "Platos",
                    Subcategoria = "",
                    Alergenos = new List<string> { "Gluten" },
                    Imagen = "Cocido.jpg"
                },

                // POSTRES
                new Producto
                {
                    Nombre = "Tarta de Queso",
                    Descripcion = "Queso, galleta...",
                    Precio = 5.50m,
                    Emoji = "??",
                    Categoria = "Postres",
                    Subcategoria = "",
                    Alergenos = new List<string> { "Lácteos", "Gluten" },
                    Imagen = "tarta-queso.jpg"
                },

                // BEBIDAS
                new Producto
                {
                    Nombre = "Cerveza",
                    Descripcion = "Caña, 0.5L",
                    Precio = 2.50m,
                    Emoji = "??",
                    Categoria = "Bebidas",
                    Subcategoria = "",
                    Alergenos = new List<string> { "Gluten" },
                    Imagen = "cerveza.jpg"
                }
            };
        }

        /// <summary>
        /// Obtiene la lista de clientes de ejemplo
        /// </summary>
        public static List<Cliente> ObtenerClientes()
        {
            return new List<Cliente>
            {
                new Cliente
                {
                    Nombre = "Alberto Cortés",
                    Direccion = "C/Finlandia, 27",
                    Telefono = "606428412",
                    Email = "Alberto.Cortes1@alu.uclm.es",
                    Alergias = new List<string> { "Gluten", "Lácteos", "Frutos Secos" },
                    PuntosAcumulados = 150,
                    MetodoPagoPreferido = "Tarjeta"
                },
                new Cliente
                {
                    Nombre = "Iván Jesús Mora",
                    Direccion = "Av. de España, 15, 3ºB",
                    Telefono = "695847231",
                    Email = "ivan.mora@outlook.es",
                    Alergias = new List<string> { "Pescado", "Huevos" },
                    PuntosAcumulados = 85,
                    MetodoPagoPreferido = "Efectivo"
                },
                new Cliente
                {
                    Nombre = "Jesus Márquez",
                    Direccion = "C/ Toledo, 42, 1ºA",
                    Telefono = "612395847",
                    Email = "marquez.garcia@gmail.com",
                    Alergias = new List<string> { "Mariscos", "Soja", "Gluten" },
                    PuntosAcumulados = 220,
                    MetodoPagoPreferido = "Tarjeta"
                }
            };
        }

        /// <summary>
        /// Obtiene la lista de pedidos de ejemplo
        /// </summary>
        public static List<Pedido> ObtenerPedidos()
        {
            return new List<Pedido>
            {
                new Pedido
                {
                    NumeroPedido = "#1024",
                    Fecha = new DateTime(2024, 1, 15, 14, 30, 0),
                    TipoEntrega = "Para tomar aquí",
                    HoraEntrega = "15:00",
                    NombreCliente = "Juan Pérez",
                    Direccion = "",
                    Productos = new List<string> { "2x Paella Valenciana", "1x Ensalada César", "3x Coca-Cola" },
                    MetodoPago = "Tarjeta",
                    Total = 45.50m,
                    Estado = "En elaboración",
                    ColorEstado = "#FFAA00"
                },
                new Pedido
                {
                    NumeroPedido = "#1023",
                    Fecha = new DateTime(2024, 1, 15, 13, 15, 0),
                    TipoEntrega = "A Domicilio",
                    HoraEntrega = "14:00",
                    NombreCliente = "María García",
                    Direccion = "Calle Mayor 15, 3ºB",
                    Productos = new List<string> { "1x Pizza Margarita", "1x Pasta Carbonara", "2x Agua Mineral" },
                    MetodoPago = "Efectivo",
                    Total = 28.90m,
                    Estado = "Entregado",
                    ColorEstado = "#00FF2F"
                },
                new Pedido
                {
                    NumeroPedido = "#1022",
                    Fecha = new DateTime(2024, 1, 15, 12, 45, 0),
                    TipoEntrega = "Para recoger",
                    HoraEntrega = "13:30",
                    NombreCliente = "Carlos Ruiz",
                    Direccion = "",
                    Productos = new List<string> { "3x Hamburguesa Completa", "3x Patatas Fritas", "3x Fanta Naranja" },
                    MetodoPago = "Tarjeta",
                    Total = 35.70m,
                    Estado = "Recogido",
                    ColorEstado = "#AF76E8"
                },
                new Pedido
                {
                    NumeroPedido = "#1021",
                    Fecha = new DateTime(2024, 1, 15, 11, 20, 0),
                    TipoEntrega = "Para tomar aquí",
                    HoraEntrega = "12:00",
                    NombreCliente = "Ana Martínez",
                    Direccion = "",
                    Productos = new List<string> { "1x Menú del Día", "1x Tarta de Queso", "1x Café Solo" },
                    MetodoPago = "Tarjeta",
                    Total = 16.50m,
                    Estado = "Pagado",
                    ColorEstado = "#00BBFF"
                },
                new Pedido
                {
                    NumeroPedido = "#1020",
                    Fecha = new DateTime(2024, 1, 15, 10, 30, 0),
                    TipoEntrega = "A Domicilio",
                    HoraEntrega = "11:30",
                    NombreCliente = "Pedro Sánchez",
                    Direccion = "Av. Libertad 45, 1ºA",
                    Productos = new List<string> { "2x Sushi Variado", "1x Edamame", "2x Té Verde" },
                    MetodoPago = "Efectivo",
                    Total = 42.00m,
                    Estado = "Pendiente de pago",
                    ColorEstado = "#FF4B1A"
                }
            };
        }
    }
}

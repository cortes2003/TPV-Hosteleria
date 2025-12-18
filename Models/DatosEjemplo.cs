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
                    Alergenos = new List<string> { "Gluten" }
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
                    Alergenos = new List<string>()
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
                    Alergenos = new List<string> { "Pescado" }
                },
                new Producto
                {
                    Nombre = "Espaguetis Carbonara",
                    Descripcion = "Pasta, huevo, bacon",
                    Precio = 11.00m,
                    Emoji = "??",
                    Categoria = "Entrantes",
                    Subcategoria = "Arroces y Pastas",
                    Alergenos = new List<string> { "Gluten", "Huevos" }
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
                    Alergenos = new List<string>()
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
                    Alergenos = new List<string> { "Pescado" }
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
                    Alergenos = new List<string> { "Gluten" }
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
                    Alergenos = new List<string> { "Lácteos", "Gluten" }
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
                    Alergenos = new List<string> { "Gluten" }
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
    }
}

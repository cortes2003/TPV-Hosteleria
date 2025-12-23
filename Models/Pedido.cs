using System;
using System.Collections.Generic;

namespace TPV_Hosteleria.Models
{
    /// <summary>
    /// Clase para representar un pedido
    /// </summary>
    public class Pedido
    {
        public string NumeroPedido { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoEntrega { get; set; }
        public string HoraEntrega { get; set; }
        public string NombreCliente { get; set; }
        public string Direccion { get; set; }
        public List<string> Productos { get; set; }
        public string MetodoPago { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
        public string ColorEstado { get; set; }

        public Pedido()
        {
            Productos = new List<string>();
        }

        /// <summary>
        /// Devuelve la fecha formateada
        /// </summary>
        public string FechaFormateada
        {
            get { return Fecha.ToString("dd/MM/yyyy - HH:mm"); }
        }

        /// <summary>
        /// Devuelve el total formateado con el símbolo de euro
        /// </summary>
        public string TotalFormateado
        {
            get { return $"{Total:F2} €"; }
        }

        /// <summary>
        /// Devuelve el icono emoji según el tipo de entrega
        /// </summary>
        public string IconoEntrega
        {
            get
            {
                switch (TipoEntrega)
                {
                    case "Para tomar aquí":
                        return "🍽";
                    case "Para recoger":
                        return "🛍";
                    case "A Domicilio":
                        return "🏠";
                    default:
                        return "🍽";
                }
            }
        }

        /// <summary>
        /// Devuelve el icono emoji según el método de pago
        /// </summary>
        public string IconoPago
        {
            get
            {
                return MetodoPago == "Efectivo" ? "💶" : "💳";
            }
        }

        /// <summary>
        /// Devuelve el color del texto según el estado (para legibilidad)
        /// </summary>
        public string ColorTexto
        {
            get
            {
                // Todos los textos usan color oscuro para mejor legibilidad
                return "#333333";
            }
        }
    }
}

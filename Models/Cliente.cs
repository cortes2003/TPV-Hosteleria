using System;
using System.Collections.Generic;

namespace TPV_Hosteleria.Models
{
    /// <summary>
    /// Clase para representar un cliente
    /// </summary>
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public List<string> Alergias { get; set; }
        public int PuntosAcumulados { get; set; }
        public string MetodoPagoPreferido { get; set; }

        public Cliente()
        {
            Alergias = new List<string>();
            PuntosAcumulados = 0;
        }

        /// <summary>
        /// Devuelve el nombre completo del cliente con icono
        /// </summary>
        public string NombreConIcono
        {
            get { return $"?? {Nombre}"; }
        }
    }
}

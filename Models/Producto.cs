using System;
using System.Collections.Generic;

namespace TPV_Hosteleria.Models
{
    /// <summary>
    /// Clase para representar un producto del menú
    /// </summary>
    public class Producto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Emoji { get; set; }
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public List<string> Alergenos { get; set; }
        public string Imagen { get; set; }

        public Producto()
        {
            Alergenos = new List<string>();
        }

        /// <summary>
        /// Devuelve el precio formateado con el símbolo de euro
        /// </summary>
        public string PrecioFormateado
        {
            get { return $"{Precio:F2} €"; }
        }

        /// <summary>
        /// Devuelve la ruta completa de la imagen para el binding
        /// </summary>
        public string RutaImagen
        {
            get
            {
                if (string.IsNullOrEmpty(Imagen))
                    return null;
                return $"/Imagenes/{Imagen}";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TPV_Hosteleria.Models;

namespace TPV_Hosteleria
{
    /// <summary>
    /// Lógica de interacción para VentanaVerProducto.xaml
    /// </summary>
    public partial class VentanaVerProducto : Window
    {
        private Producto productoOriginal;
        public Producto ProductoActualizado { get; private set; }
        
        public VentanaVerProducto(Producto producto)
        {
            InitializeComponent();
            productoOriginal = producto;
            txtNombreProducto.Text = producto.Nombre;
            txtIngredientes.Text = producto.Descripcion;
            txtPrecio.Text = producto.Precio.ToString();
            txtCategoriaProducto.Text = producto.Categoria;
            txtSubcategoriaProducto.Text = producto.Subcategoria;
            
            // Cargar la imagen del producto
            if (!string.IsNullOrEmpty(producto.RutaImagen))
            {
                try
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(producto.RutaImagen);
                    bitmap.EndInit();
                    imgProducto.Source = bitmap;
                }
                catch
                {
                    // Si no se puede cargar la imagen, dejar el espacio vacío
                    imgProducto.Source = null;
                }
            }
            
            // Marcar los checkboxes de alérgenos según el producto
            if (producto.Alergenos != null)
            {
                chkPescado.IsChecked = producto.Alergenos.Contains("Pescado");
                chkGluten.IsChecked = producto.Alergenos.Contains("Gluten");
                chkHuevos.IsChecked = producto.Alergenos.Contains("Huevos");
                chkMaiz.IsChecked = producto.Alergenos.Contains("Maíz");
                chkFrutosSecos.IsChecked = producto.Alergenos.Contains("Frutos Secos");
                chkLacteos.IsChecked = producto.Alergenos.Contains("Lácteos");
            }
        }

        public void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void btnGuardar_click(object sender, RoutedEventArgs e)
        {
            // Validar que los campos obligatorios estén completos
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("El precio es obligatorio", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Parsear precio
            decimal precio = 0;
            if (!decimal.TryParse(txtPrecio.Text, out precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un número válido mayor que 0", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Recopilar alérgenos seleccionados
            List<string> alergenos = new List<string>();
            if (chkPescado.IsChecked == true) alergenos.Add("Pescado");
            if (chkGluten.IsChecked == true) alergenos.Add("Gluten");
            if (chkHuevos.IsChecked == true) alergenos.Add("Huevos");
            if (chkMaiz.IsChecked == true) alergenos.Add("Maíz");
            if (chkFrutosSecos.IsChecked == true) alergenos.Add("Frutos Secos");
            if (chkLacteos.IsChecked == true) alergenos.Add("Lácteos");

            // Actualizar el producto original con los nuevos valores
            productoOriginal.Nombre = txtNombreProducto.Text.Trim();
            productoOriginal.Precio = precio;
            productoOriginal.Descripcion = txtIngredientes.Text.Trim();
            productoOriginal.Alergenos = alergenos;
            
            // Guardar referencia al producto actualizado
            ProductoActualizado = productoOriginal;

            // Cerrar la ventana
            this.Close();
        }

    }
}

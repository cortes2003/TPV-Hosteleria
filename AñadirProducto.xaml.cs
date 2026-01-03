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
    /// Lógica de interacción para AñadirProducto.xaml
    /// </summary>
    public partial class AñadirProducto : Window
    {
        // Propiedad pública para que Home.xaml.cs pueda acceder al producto guardado
        public Producto ProductoGuardado { get; private set; }
        public string rutaArchivo = "";
        public AñadirProducto()
        {
            InitializeComponent();
            
            // Desactivar subcategoría por defecto
            cbxSubcategoriaProducto.IsEnabled = false;
        }

        private void cargarImagen(object sender, RoutedEventArgs e)
        {
            // Funcionalidad de cargar imagen (opcional, se puede dejar vacío por ahora)
        }

        /// <summary>
        /// Evento que se dispara cuando se cambia la selección de categoría
        /// Habilita o deshabilita el ComboBox de subcategoría según la categoría seleccionada
        /// </summary>
        private void cbxCategoriaProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxCategoriaProducto.SelectedItem != null)
            {
                ComboBoxItem categoriaSeleccionada = (ComboBoxItem)cbxCategoriaProducto.SelectedItem;
                string categoria = categoriaSeleccionada.Content.ToString();
                
                // Habilitar subcategoría solo si es "Entrantes"
                if (categoria.Contains("Entrantes"))
                {
                    cbxSubcategoriaProducto.IsEnabled = true;
                }
                else
                {
                    cbxSubcategoriaProducto.IsEnabled = false;
                    cbxSubcategoriaProducto.SelectedIndex = -1; // Limpiar selección
                }
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            // Validar que los campos obligatorios estén completos
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (cbxCategoriaProducto.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una categoría", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Warning);
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

            // Obtener categoría seleccionada (quitando el emoji)
            ComboBoxItem categoriaItem = (ComboBoxItem)cbxCategoriaProducto.SelectedItem;
            string categoriaCompleta = categoriaItem.Content.ToString();
            string categoria = categoriaCompleta.Substring(categoriaCompleta.IndexOf(' ') + 1); // Quitar emoji

            // Obtener subcategoría si está seleccionada
            string subcategoria = "";
            if (cbxSubcategoriaProducto.SelectedItem != null)
            {
                ComboBoxItem subcategoriaItem = (ComboBoxItem)cbxSubcategoriaProducto.SelectedItem;
                subcategoria = subcategoriaItem.Content.ToString();
            }

            // Recopilar alérgenos seleccionados
            List<string> alergenos = new List<string>();
            if (chkPescado.IsChecked == true) alergenos.Add("Pescado");
            if (chkGluten.IsChecked == true) alergenos.Add("Gluten");
            if (chkHuevos.IsChecked == true) alergenos.Add("Huevos");
            if (chkMaiz.IsChecked == true) alergenos.Add("Maíz");
            if (chkFrutosSecos.IsChecked == true) alergenos.Add("Frutos Secos");
            if (chkLacteos.IsChecked == true) alergenos.Add("Lácteos");

            // Obtener ingredientes (descripción)
            string descripcion = txtIngredientes.Text.Trim();

            // Asignar un emoji por defecto según la categoría
            string emoji = "🍽️"; // Emoji por defecto
            switch (categoria)
            {
                case "Entrantes":
                    emoji = "🥗";
                    break;
                case "Platos":
                    emoji = "🍖";
                    break;
                case "Postres":
                    emoji = "🍰";
                    break;
                case "Bebidas":
                    emoji = "🥤";
                    break;
            }
            // Crear el nuevo producto
            ProductoGuardado = new Producto
            {
                Nombre = txtNombreProducto.Text.Trim(),
                Precio = precio,
                Categoria = categoria,
                Subcategoria = subcategoria,
                Descripcion = descripcion,
                Alergenos = alergenos,
                Emoji = emoji,
                Imagen = rutaArchivo
            };
            // Cerrar la ventana
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            // No guardar nada, simplemente cerrar la ventana
            ProductoGuardado = null;
            this.Close();
        }
        //Boton de carga de la imagen en el producto (Falta que se guarde en la iterfaz)
        private void btnCargarImagen_click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog buscarImagen = new System.Windows.Forms.OpenFileDialog();
            buscarImagen.Filter = "Archivos de Imagen (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp|Todos los archivos (*.*)|*.*";
            if (buscarImagen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string rutaImagen = buscarImagen.FileName;
                rutaArchivo = System.IO.Path.GetFileName(rutaImagen);
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(rutaImagen);
                bitmap.EndInit();
                imgProducto.Source = bitmap;
            }
            if (!string.IsNullOrEmpty(rutaArchivo))
            {
                string carpetaDestino = "../../Imagenes/";

                string rutaDestino = System.IO.Path.Combine(carpetaDestino, rutaArchivo);

                if (!System.IO.File.Exists(rutaDestino))
                {
                    System.IO.File.Copy(buscarImagen.FileName, rutaDestino, true);
                }
            }
        }
    }
}


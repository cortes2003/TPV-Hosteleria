using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace TPV_Hosteleria
{
    /// <summary>
    /// Clase para representar un producto en el ticket
    /// </summary>
    public class ProductoTicket : INotifyPropertyChanged
    {
        private int _cantidad;
        private string _nombre;
        private decimal _precioUnitario;

        public int Cantidad
        {
            get { return _cantidad; }
            set
            {
                if (_cantidad != value)
                {
                    _cantidad = value;
                    OnPropertyChanged("Cantidad");
                    OnPropertyChanged("CantidadTexto");
                    OnPropertyChanged("PrecioTotal");
                    OnPropertyChanged("PrecioTotalTexto");
                }
            }
        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged("Nombre");
                }
            }
        }

        public decimal PrecioUnitario
        {
            get { return _precioUnitario; }
            set
            {
                if (_precioUnitario != value)
                {
                    _precioUnitario = value;
                    OnPropertyChanged("PrecioUnitario");
                    OnPropertyChanged("PrecioTotal");
                    OnPropertyChanged("PrecioTotalTexto");
                }
            }
        }

        public string CantidadTexto
        {
            get { return $"{Cantidad}x"; }
        }

        public decimal PrecioTotal
        {
            get { return Cantidad * PrecioUnitario; }
        }

        public string PrecioTotalTexto
        {
            get { return $"{PrecioTotal:F2} €"; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private ObservableCollection<ProductoTicket> productosTicket;

        public Home(string nombreUsuario)
        {
            InitializeComponent();
            txtNombreUsuario.Text = "Hola, " + nombreUsuario;
            txtUltimoAcceso.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            // Inicializar la lista de productos del ticket (datos de ejemplo)
            productosTicket = new ObservableCollection<ProductoTicket>
            {
                //Al principio la dejamos vacia, antes habíamos puesto valores para que se viera la idea
            };

            // Asignar el ItemsSource del ListView
            lstTicket.ItemsSource = productosTicket;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            // Crear y mostrar la ventana de información
            VentanaInformacion ventanaInfo = new VentanaInformacion();
            ventanaInfo.ShowDialog();
        }

        /// <summary>
        /// Evento para aumentar la cantidad de un producto
        /// </summary>
        private void btnSumarProducto_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag is ProductoTicket producto)
            {
                producto.Cantidad++;
            }
        }

        /// <summary>
        /// Evento para reducir la cantidad de un producto
        /// Si la cantidad llega a 0, se elimina del ticket
        /// </summary>
        private void btnRestarProducto_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag is ProductoTicket producto)
            {
                producto.Cantidad--;
                
                // Si la cantidad llega a 0, eliminar el producto del ticket
                if (producto.Cantidad <= 0)
                {
                    productosTicket.Remove(producto);
                }
            }
        }
        
        /// <summary>
        /// Método genérico para manejar la eliminación de productos y clientes
        /// Busca el Border contenedor y lo oculta si el usuario confirma
        /// </summary>
        private void EliminarElemento(object sender)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Navegar hacia arriba en el árbol visual para encontrar el Border
                DependencyObject parent = VisualTreeHelper.GetParent(btn);
                while (parent != null && !(parent is Border))
                {
                    parent = VisualTreeHelper.GetParent(parent);
                }
                
                // Mostrar ventana de confirmación
                VentanaEliminar ventanaEliminar = new VentanaEliminar();
                ventanaEliminar.ShowDialog();
                
                // Si el usuario confirmó la eliminación, ocultar el elemento
                if (ventanaEliminar.Confirmado && parent != null)
                {
                    ((UIElement)parent).Visibility = Visibility.Collapsed;
                }
            }
        }
        
        // Eventos de eliminación de productos
        private void btnEliminarP1_Click(object sender, RoutedEventArgs e) => EliminarElemento(sender);
        private void btnEliminarP2_Click(object sender, RoutedEventArgs e) => EliminarElemento(sender);
        private void btnEliminarP3_Click(object sender, RoutedEventArgs e) => EliminarElemento(sender);
        private void btnEliminarP4_Click(object sender, RoutedEventArgs e) => EliminarElemento(sender);
        private void btnEliminarP5_Click(object sender, RoutedEventArgs e) => EliminarElemento(sender);
        private void btnEliminarP6_Click(object sender, RoutedEventArgs e) => EliminarElemento(sender);
        private void btnEliminarP7_Click(object sender, RoutedEventArgs e) => EliminarElemento(sender);
        private void btnEliminarP8_Click(object sender, RoutedEventArgs e) => EliminarElemento(sender);
        private void btnEliminarP9_Click(object sender, RoutedEventArgs e) => EliminarElemento(sender);
        
        // Eventos de eliminación de clientes
        private void btnEliminarC1_Click(object sender, RoutedEventArgs e) => EliminarElemento(sender);
        private void btnEliminarC2_Click(object sender, RoutedEventArgs e) => EliminarElemento(sender);
        private void btnEliminarC3_Click(object sender, RoutedEventArgs e) => EliminarElemento(sender);

        private void txtClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) 
            { 
              txtClientes.Text = "Juan Pérez"; //Esto simula que se elige un cliente haciendo una busqueda
            } 
        }

        private void cbTomarAqui_Checked(object sender, RoutedEventArgs e)
        {
            if (cbTomarAqui.IsChecked == true)
            {
                cbRecoger.IsChecked = false;
                cbDomicilio.IsChecked = false;
            }
        }

        private void cbRecoger_Checked(object sender, RoutedEventArgs e)
        {
            if (cbRecoger.IsChecked == true)
            {
                cbTomarAqui.IsChecked = false;
                cbDomicilio.IsChecked = false;
            }
        }

        private void cbDomicilio_Checked(object sender, RoutedEventArgs e)
        {
            if (cbDomicilio.IsChecked == true)
            {
                cbTomarAqui.IsChecked = false;
                cbRecoger.IsChecked = false;
            }
        }

        private void btnAñadirP1_Click(object sender, RoutedEventArgs e)
        {
            string textoCompleto = txtPrecioP1.Text; //Ejemplo: "9.50 €"
            string precioLimpio = textoCompleto.Replace(" €", ""); //He tenido que hacer esto, porque no puedo hacer decimal.Parse si tengo el símbolo de euro
            //Esto es para comprobar que el producto ya esta en la lista o no
            foreach (var producto in productosTicket)
            {
                if (producto.Nombre == txtNombreP1.Text)
                {
                    producto.Cantidad++;
                    return;
                }
            }
            ProductoTicket productoNuevo = new ProductoTicket  
            {
                Cantidad = 1,
                Nombre = txtNombreP1.Text,
                PrecioUnitario = decimal.Parse(precioLimpio)
            };            
            productosTicket.Add(productoNuevo);                        
            lstTicket.ItemsSource = productosTicket;
        }

        private void btnAñadirP2_Click(object sender, RoutedEventArgs e)
        {
            string textoCompleto = txtPrecioP2.Text;
            string precioLimpio = textoCompleto.Replace(" €", ""); //He tenido que hacer esto, porque no puedo hacer decimal.Parse si tengo el símbolo de euro
            //Esto es para comprobar que el producto ya esta en la lista o no
            foreach (var producto in productosTicket)
            {
                if (producto.Nombre == txtNombreP2.Text)
                {
                    producto.Cantidad++;
                    return;
                }
            }
            ProductoTicket productoNuevo = new ProductoTicket
            {
                Cantidad = 1,
                Nombre = txtNombreP2.Text, 
                PrecioUnitario = decimal.Parse(precioLimpio)
            };
            productosTicket.Add(productoNuevo);
            lstTicket.ItemsSource = productosTicket;
        }

        private void btnAñadirP3_Click(object sender, RoutedEventArgs e)
        {
            string textoCompleto = txtPrecioP3.Text;
            string precioLimpio = textoCompleto.Replace(" €", ""); //He tenido que hacer esto, porque no puedo hacer decimal.Parse si tengo el símbolo de euro
            //Esto es para comprobar que el producto ya esta en la lista o no
            foreach (var producto in productosTicket)
            {
                if (producto.Nombre == txtNombreP3.Text)
                {
                    producto.Cantidad++;
                    return;
                }
            }
            ProductoTicket productoNuevo = new ProductoTicket
            {
                Cantidad = 1,
                Nombre = txtNombreP3.Text, //Binding
                PrecioUnitario = decimal.Parse(precioLimpio)
            };
            productosTicket.Add(productoNuevo);
            lstTicket.ItemsSource = productosTicket;
        }

        private void btnAñadirP4_Click(object sender, RoutedEventArgs e)
        {
            string textoCompleto = txtPrecioP4.Text;
            string precioLimpio = textoCompleto.Replace(" €", ""); //He tenido que hacer esto, porque no puedo hacer decimal.Parse si tengo el símbolo de euro
            //Esto es para comprobar que el producto ya esta en la lista o no
            foreach (var producto in productosTicket)
            {
                if (producto.Nombre == txtNombreP4.Text)
                {
                    producto.Cantidad++;
                    return;
                }
            }
            ProductoTicket productoNuevo = new ProductoTicket
            {
                Cantidad = 1,
                Nombre = txtNombreP4.Text, //Binding
                PrecioUnitario = decimal.Parse(precioLimpio)
            };
            productosTicket.Add(productoNuevo);
            lstTicket.ItemsSource = productosTicket;
        }

        private void btnAñadirP5_Click(object sender, RoutedEventArgs e)
        {
            string textoCompleto = txtPrecioP5.Text;
            string precioLimpio = textoCompleto.Replace(" €", ""); //He tenido que hacer esto, porque no puedo hacer decimal.Parse si tengo el símbolo de euro
            //Esto es para comprobar que el producto ya esta en la lista o no
            foreach (var producto in productosTicket)
            {
                if (producto.Nombre == txtNombreP5.Text)
                {
                    producto.Cantidad++;
                    return;
                }
            }
            ProductoTicket productoNuevo = new ProductoTicket
            {
                Cantidad = 1,
                Nombre = txtNombreP5.Text, //Binding
                PrecioUnitario = decimal.Parse(precioLimpio)
            };
            productosTicket.Add(productoNuevo);
            lstTicket.ItemsSource = productosTicket;
        }

        private void btnAñadirP6_Click(object sender, RoutedEventArgs e)
        {
            string textoCompleto = txtPrecioP6.Text;
            string precioLimpio = textoCompleto.Replace(" €", ""); //He tenido que hacer esto, porque no puedo hacer decimal.Parse si tengo el símbolo de euro
            //Esto es para comprobar que el producto ya esta en la lista o no
            foreach (var producto in productosTicket)
            {
                if (producto.Nombre == txtNombreP6.Text)
                {
                    producto.Cantidad++;
                    return;
                }
            }
            ProductoTicket productoNuevo = new ProductoTicket
            {
                Cantidad = 1,
                Nombre = txtNombreP6.Text, //Binding
                PrecioUnitario = decimal.Parse(precioLimpio)
            };
            productosTicket.Add(productoNuevo);
            lstTicket.ItemsSource = productosTicket;
        }

        private void btnAñadirP7_Click(object sender, RoutedEventArgs e)
        {
            string textoCompleto = txtPrecioP7.Text;
            string precioLimpio = textoCompleto.Replace(" €", ""); //He tenido que hacer esto, porque no puedo hacer decimal.Parse si tengo el símbolo de euro
            //Esto es para comprobar que el producto ya esta en la lista o no
            foreach (var producto in productosTicket)
            {
                if (producto.Nombre == txtNombreP7.Text)
                {
                    producto.Cantidad++;
                    return;
                }
            }
            ProductoTicket productoNuevo = new ProductoTicket
            {
                Cantidad = 1,
                Nombre = txtNombreP7.Text, //Binding
                PrecioUnitario = decimal.Parse(precioLimpio)
            };
            productosTicket.Add(productoNuevo);
            lstTicket.ItemsSource = productosTicket;
        }

        private void btnAñadirP8_Click(object sender, RoutedEventArgs e)
        {
            string textoCompleto = txtPrecioP8.Text;
            string precioLimpio = textoCompleto.Replace(" €", ""); //He tenido que hacer esto, porque no puedo hacer decimal.Parse si tengo el símbolo de euro
            //Esto es para comprobar que el producto ya esta en la lista o no
            foreach (var producto in productosTicket)
            {
                if (producto.Nombre == txtNombreP8.Text)
                {
                    producto.Cantidad++;
                    return;
                }
            }
            ProductoTicket productoNuevo = new ProductoTicket
            {
                Cantidad = 1,
                Nombre = txtNombreP8.Text, //Binding
                PrecioUnitario = decimal.Parse(precioLimpio)
            };
            productosTicket.Add(productoNuevo);
            lstTicket.ItemsSource = productosTicket;
        }

        private void btnAñadirP9_Click(object sender, RoutedEventArgs e)
        {
            string textoCompleto = txtPrecioP9.Text;
            string precioLimpio = textoCompleto.Replace(" €", ""); //He tenido que hacer esto, porque no puedo hacer decimal.Parse si tengo el símbolo de euro
            //Esto es para comprobar que el producto ya esta en la lista o no
            foreach (var producto in productosTicket)
            {
                if (producto.Nombre == txtNombreP9.Text)
                {
                    producto.Cantidad++;
                    return;
                }
            }
            ProductoTicket productoNuevo = new ProductoTicket
            {
                Cantidad = 1,
                Nombre = txtNombreP9.Text, //Binding
                PrecioUnitario = decimal.Parse(precioLimpio)
            };
            productosTicket.Add(productoNuevo);
            lstTicket.ItemsSource = productosTicket;
        }
    }
}

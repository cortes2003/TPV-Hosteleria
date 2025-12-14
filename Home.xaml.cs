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
                new ProductoTicket { Cantidad = 1, Nombre = "Ensalada César", PrecioUnitario = 9.50m },
                new ProductoTicket { Cantidad = 2, Nombre = "Huevos Rotos", PrecioUnitario = 12.00m }
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
        
        private void mostrarVentanaEliminar()
        {
            VentanaEliminar ventanaEliminar = new VentanaEliminar();
            ventanaEliminar.ShowDialog();
        }
        private void btnEliminarP1_Click(object sender, RoutedEventArgs e)
        {
            mostrarVentanaEliminar();
        }

        private void btnEliminarP2_Click(object sender, RoutedEventArgs e)
        {
            mostrarVentanaEliminar();
        }

        private void btnEliminarC1_Click(object sender, RoutedEventArgs e)
        {
            mostrarVentanaEliminar();
        }

        private void btnEliminarC2_Click(object sender, RoutedEventArgs e)
        {
            mostrarVentanaEliminar();
        }

        private void btnEliminarC3_Click(object sender, RoutedEventArgs e)
        {
            mostrarVentanaEliminar();
        }

        private void btnEliminarP3_Click(object sender, RoutedEventArgs e)
        {
            mostrarVentanaEliminar();
        }

        private void btnEliminarP4_Click(object sender, RoutedEventArgs e)
        {
            mostrarVentanaEliminar();
        }

        private void btnEliminarP5_Click(object sender, RoutedEventArgs e)
        {
            mostrarVentanaEliminar();
        }

        private void btnEliminarP6_Click(object sender, RoutedEventArgs e)
        {
            mostrarVentanaEliminar();
        }

        private void btnEliminarP7_Click(object sender, RoutedEventArgs e)
        {
            mostrarVentanaEliminar();
        }

        private void btnEliminarP8_Click(object sender, RoutedEventArgs e)
        {
            mostrarVentanaEliminar();
        }

        private void btnEliminarP9_Click(object sender, RoutedEventArgs e)
        {
            mostrarVentanaEliminar();
        }

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
            string precioLimpio = textoCompleto.Replace("€", "").Trim(); //He tenido que hacer esto, porque no puedo hacer decimal.Parse si tengo el símbolo de euro
            ProductoTicket productoNuevo = new ProductoTicket  
            {
                Cantidad = 1,
                Nombre = txtNombreP1.Text, //Binding
                PrecioUnitario = decimal.Parse(precioLimpio)
            };
            productosTicket.Add(productoNuevo);
            lstTicket.ItemsSource = productosTicket;
        }

        private void btnAñadirP2_Click(object sender, RoutedEventArgs e)
        {
            string textoCompleto = txtPrecioP2.Text; //Ejemplo: "9.50 €"
            string precioLimpio = textoCompleto.Replace("€", "").Trim(); //He tenido que hacer esto, porque no puedo hacer decimal.Parse si tengo el símbolo de euro
            ProductoTicket productoNuevo = new ProductoTicket
            {
                Cantidad = 1,
                Nombre = txtNombreP2.Text, //Binding
                PrecioUnitario = decimal.Parse(precioLimpio)
            };
            productosTicket.Add(productoNuevo);
            lstTicket.ItemsSource = productosTicket;
        }
    }
}

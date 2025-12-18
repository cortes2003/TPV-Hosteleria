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
using TPV_Hosteleria.Models;

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
        private List<Producto> listaProductos;
        private List<Cliente> listaClientes;

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

            // Cargar datos de ejemplo desde las clases del modelo
            CargarDatosEjemplo();
        }

        /// <summary>
        /// Carga los datos de ejemplo de productos y clientes desde las clases del modelo
        /// </summary>
        private void CargarDatosEjemplo()
        {
            listaProductos = DatosEjemplo.ObtenerProductos();
            listaClientes = DatosEjemplo.ObtenerClientes();

            // Vincular la lista de clientes al ItemsControl
            itemsClientes.ItemsSource = listaClientes;

            // Vincular productos por categoría
            itemsBebidas.ItemsSource = listaProductos.Where(p => p.Categoria == "Bebidas").ToList();
            itemsPostres.ItemsSource = listaProductos.Where(p => p.Categoria == "Postres").ToList();
            itemsPlatos.ItemsSource = listaProductos.Where(p => p.Categoria == "Platos").ToList();

            // Vincular productos por subcategoría de Entrantes
            itemsEnsaladas.ItemsSource = listaProductos.Where(p => p.Subcategoria == "Ensaladas").ToList();
            itemsHuevos.ItemsSource = listaProductos.Where(p => p.Subcategoria == "Huevos").ToList();
            itemsArrocesPastas.ItemsSource = listaProductos.Where(p => p.Subcategoria == "Arroces y Pastas").ToList();
            itemsAsados.ItemsSource = listaProductos.Where(p => p.Subcategoria == "Asados").ToList();
            itemsPescados.ItemsSource = listaProductos.Where(p => p.Subcategoria == "Pescados").ToList();
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
        
        // Métodos obsoletos de eliminación de productos eliminados
        // Los productos ahora usan btnEliminarProducto_Click genérico
        
        /// <summary>
        /// Evento para eliminar un cliente desde la tarjeta generada dinámicamente
        /// </summary>
        private void btnEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag is Cliente cliente)
            {
                // Mostrar ventana de confirmación
                VentanaEliminar ventanaEliminar = new VentanaEliminar();
                ventanaEliminar.ShowDialog();
                
                // Si el usuario confirmó la eliminación, remover de la lista
                if (ventanaEliminar.Confirmado)
                {
                    listaClientes.Remove(cliente);
                    // Refrescar el ItemsControl
                    itemsClientes.ItemsSource = null;
                    itemsClientes.ItemsSource = listaClientes;
                }
            }
        }

        /// <summary>
        /// Evento genérico para añadir un producto al ticket desde tarjeta dinámica
        /// </summary>
        private void btnAñadirProducto_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag is Producto producto)
            {
                // Comprobar si el producto ya está en el ticket
                foreach (var item in productosTicket)
                {
                    if (item.Nombre == producto.Nombre)
                    {
                        item.Cantidad++;
                        return;
                    }
                }
                
                // Si no está, añadirlo
                ProductoTicket productoNuevo = new ProductoTicket
                {
                    Cantidad = 1,
                    Nombre = producto.Nombre,
                    PrecioUnitario = producto.Precio
                };
                productosTicket.Add(productoNuevo);
            }
        }

        /// <summary>
        /// Evento genérico para eliminar un producto desde tarjeta dinámica
        /// </summary>
        private void btnEliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag is Producto producto)
            {
                // Mostrar ventana de confirmación
                VentanaEliminar ventanaEliminar = new VentanaEliminar();
                ventanaEliminar.ShowDialog();
                
                // Si el usuario confirmó la eliminación, remover de la lista
                if (ventanaEliminar.Confirmado)
                {
                    listaProductos.Remove(producto);
                    // Refrescar los ItemsControls de productos SIN recargar desde DatosEjemplo
                    RefrescarProductos();
                }
            }
        }

        /// <summary>
        /// Refresca todos los ItemsControls de productos sin recargar desde DatosEjemplo
        /// </summary>
        private void RefrescarProductos()
        {
            // Vincular productos por categoría
            itemsBebidas.ItemsSource = null;
            itemsBebidas.ItemsSource = listaProductos.Where(p => p.Categoria == "Bebidas").ToList();
            
            itemsPostres.ItemsSource = null;
            itemsPostres.ItemsSource = listaProductos.Where(p => p.Categoria == "Postres").ToList();
            
            itemsPlatos.ItemsSource = null;
            itemsPlatos.ItemsSource = listaProductos.Where(p => p.Categoria == "Platos").ToList();

            // Vincular productos por subcategoría de Entrantes
            itemsEnsaladas.ItemsSource = null;
            itemsEnsaladas.ItemsSource = listaProductos.Where(p => p.Subcategoria == "Ensaladas").ToList();
            
            itemsHuevos.ItemsSource = null;
            itemsHuevos.ItemsSource = listaProductos.Where(p => p.Subcategoria == "Huevos").ToList();
            
            itemsArrocesPastas.ItemsSource = null;
            itemsArrocesPastas.ItemsSource = listaProductos.Where(p => p.Subcategoria == "Arroces y Pastas").ToList();
            
            itemsAsados.ItemsSource = null;
            itemsAsados.ItemsSource = listaProductos.Where(p => p.Subcategoria == "Asados").ToList();
            
            itemsPescados.ItemsSource = null;
            itemsPescados.ItemsSource = listaProductos.Where(p => p.Subcategoria == "Pescados").ToList();
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

    }
}

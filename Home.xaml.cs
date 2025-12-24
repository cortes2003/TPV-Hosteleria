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
        private List<Pedido> listaPedidos;
        private ICollectionView vistaFiltrada;
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
            //Lista de estados de los pedidos
            List<EstadosPedido> listaEstados = new List<EstadosPedido>
            {
                new EstadosPedido{estado="En elaboración", colorCirculo="#FFAA00"},
                new EstadosPedido{estado="Entregado", colorCirculo="#00FF2F"},
                new EstadosPedido{estado="Recogido", colorCirculo="#AF76E8"},
                new EstadosPedido{estado="Pagado", colorCirculo="#00BBFF"},
                new EstadosPedido{estado="Pendiente de pago", colorCirculo="#FF4B1A"}
            };
            cmbxEstadoPedido.ItemsSource = listaEstados;//Carga de los estados de los pedidos en su combobox correspondiente
            // Cargar datos de ejemplo desde las clases del modelo
            CargarDatosEjemplo();
            FiltrarPedidos();
        }

        /// <summary>
        /// Carga los datos de ejemplo de productos y clientes desde las clases del modelo
        /// </summary>
        private void CargarDatosEjemplo()
        {
            listaProductos = DatosEjemplo.ObtenerProductos();
            listaClientes = DatosEjemplo.ObtenerClientes();
            listaPedidos = DatosEjemplo.ObtenerPedidos();

            // Vincular la lista de clientes al ItemsControl
            itemsClientes.ItemsSource = listaClientes;

            // Vincular la lista de pedidos al ItemsControl
            itemsPedidos.ItemsSource = listaPedidos;

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
        private void recalcularPrecioTicket()
        {
            //Esto para actualizar el precio del subtotal
            decimal subtotal = 0;
            decimal total = 0;
            foreach (var producto in productosTicket)
            {
                subtotal += producto.PrecioTotal;
            }
            total = subtotal;

            decimal descuentoPuntos = 5; //Hemos dicho que son 5 euros de descuento si usa puntos
            if (cbPuntos.IsChecked==true)
            {
                if (total <= descuentoPuntos)
                {
                    total = 0;
                } else
                {
                    total = total - descuentoPuntos;
                }
            }

            decimal costeDomicilio = 3; //Hemos dicho que el coste de llevarlo a domicilio es 3 euros
            if (cbDomicilio.IsChecked == true)
            {
                total = total + costeDomicilio;
            }

            txtPrecioSubTotal.Text = $"{subtotal:F2} €";
            txtPrecioTotalTicket.Text = $"{total:F2} €";
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
            recalcularPrecioTicket();
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
            recalcularPrecioTicket();
        }
        
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
            recalcularPrecioTicket();
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
                txtEnvio.Visibility = Visibility.Hidden;
                txtPrecioEnvio.Visibility = Visibility.Hidden;
                recalcularPrecioTicket();
            }
        }

        private void cbRecoger_Checked(object sender, RoutedEventArgs e)
        {
            if (cbRecoger.IsChecked == true)
            {
                cbTomarAqui.IsChecked = false;
                cbDomicilio.IsChecked = false;
                txtEnvio.Visibility = Visibility.Hidden;
                txtPrecioEnvio.Visibility = Visibility.Hidden;
                recalcularPrecioTicket();
            }
        }

        private void cbDomicilio_Checked(object sender, RoutedEventArgs e)
        {
            if (cbDomicilio.IsChecked == true)
            {
                cbTomarAqui.IsChecked = false;
                cbRecoger.IsChecked = false;
                recalcularPrecioTicket();
                txtEnvio.Visibility = Visibility.Visible;
                txtPrecioEnvio.Visibility = Visibility.Visible;
            }
        }
        private void cbDomicilio_Unchecked(object sender, RoutedEventArgs e)
        {
            recalcularPrecioTicket();
            txtEnvio.Visibility = Visibility.Hidden;
            txtPrecioEnvio.Visibility = Visibility.Hidden;
        }

        private void btnEfectivo_Click(object sender, RoutedEventArgs e)
        {
            btnEfectivo.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6F00"));
            btnEfectivo.Foreground = Brushes.White;
            btnEfectivo.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6F00"));
            
            btnTarjeta.Background = Brushes.White;
            btnTarjeta.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
            btnTarjeta.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DDDDDD"));
        }

        private void btnTarjeta_Click(object sender, RoutedEventArgs e)
        {
            btnTarjeta.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6F00"));
            btnTarjeta.Foreground = Brushes.White;
            btnTarjeta.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6F00"));
            
            btnEfectivo.Background = Brushes.White;
            btnEfectivo.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
            btnEfectivo.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DDDDDD"));
        }

        /// <summary>
        /// Evento para abrir la ventana de añadir cliente
        /// </summary>
        private void btnAñadirCliente_Click(object sender, RoutedEventArgs e)
        {
            // Crear y mostrar la ventana de añadir cliente
            AñadirCliente ventanaAñadirCliente = new AñadirCliente();
            ventanaAñadirCliente.ShowDialog();
            
            // Si se guardó un cliente, refrescar la lista
            if (ventanaAñadirCliente.ClienteGuardado != null)
            {
                listaClientes.Add(ventanaAñadirCliente.ClienteGuardado);
                // Refrescar el ItemsControl
                itemsClientes.ItemsSource = null;
                itemsClientes.ItemsSource = listaClientes;
            }
        }

        /// <summary>
        /// Evento para abrir la ventana de añadir producto
        /// </summary>
        private void btnAñadirNuevoProducto_Click(object sender, RoutedEventArgs e)
        {
            // Crear y mostrar la ventana de añadir producto
            AñadirProducto ventanaAñadirProducto = new AñadirProducto();
            ventanaAñadirProducto.ShowDialog();
            
            // Si se guardó un producto, refrescar la lista
            if (ventanaAñadirProducto.ProductoGuardado != null)
            {
                listaProductos.Add(ventanaAñadirProducto.ProductoGuardado);
                // Refrescar los ItemsControls de productos
                RefrescarProductos();
            }
        }
        private void FiltrarPedidos()
        {
            vistaFiltrada = CollectionViewSource.GetDefaultView(listaPedidos);
            vistaFiltrada.Filter = (obj) =>
            {
                var pedido = obj as Pedido;
                if (pedido == null) return false;
                bool coincideFecha = dtpFechaPedidos.SelectedDate == null || pedido.Fecha.Date == dtpFechaPedidos.SelectedDate.Value.Date;
                EstadosPedido est = (EstadosPedido) cmbxEstadoPedido.SelectedItem;
                bool coincideEstado = cmbxEstadoPedido.SelectedItem == null || est.estado==pedido.Estado;
                bool coincideCliente= string.IsNullOrEmpty(txtClientePedidos.Text)||pedido.NombreCliente.ToLower().Contains(txtClientePedidos.Text.ToLower());
                bool coincideTipoEntrega=cmbxTipoEntrega.SelectedItem == null || cmbxTipoEntrega.SelectedItem.ToString().Contains(pedido.TipoEntrega);
                return coincideFecha && coincideEstado && coincideCliente && coincideTipoEntrega; 
            };
        }
        private void filtrar_changed(object sender, EventArgs e)
        {
            vistaFiltrada?.Refresh();
        }

        private void btnLimpiarBusqueda_Click(object sender, RoutedEventArgs e)
        {
            dtpFechaPedidos.SelectedDate = null;
            cmbxEstadoPedido.SelectedItem = null;
            txtClientePedidos.Text = null;
            cmbxTipoEntrega.SelectedItem = null;
            vistaFiltrada?.Refresh();
        }

        private void cbPuntos_Checked(object sender, RoutedEventArgs e)
        {
            recalcularPrecioTicket();
        }

        private void cbPuntos_Unchecked(object sender, RoutedEventArgs e)
        {
            recalcularPrecioTicket();
        }
    }
}

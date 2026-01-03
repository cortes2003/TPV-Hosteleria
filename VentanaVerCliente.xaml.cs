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
    /// Lógica de interacción para VentanaVerCliente.xaml
    /// </summary>
    public partial class VentanaVerCliente : Window
    {
        private Cliente clienteOriginal;
        private string metodoPagoSeleccionado = "";
        public Cliente ClienteActualizado { get; private set; }
        
        public VentanaVerCliente(Cliente cliente)
        {
            InitializeComponent();
            clienteOriginal = cliente;
            txtNombreApellidosCliente.Text = cliente.Nombre;
            txtTelefonosCliente.Text = cliente.Telefono;
            txtEmailsCliente.Text = cliente.Email;
            txtDireccionCliente.Text = cliente.Direccion;
            txtPuntosCliente.Text = cliente.PuntosAcumulados.ToString();
            
            // Marcar los checkboxes de alergias según el cliente
            if (cliente.Alergias != null)
            {
                chkPescado.IsChecked = cliente.Alergias.Contains("Pescado");
                chkGluten.IsChecked = cliente.Alergias.Contains("Gluten");
                chkHuevos.IsChecked = cliente.Alergias.Contains("Huevos");
                chkMaiz.IsChecked = cliente.Alergias.Contains("Maíz");
                chkFrutosSecos.IsChecked = cliente.Alergias.Contains("Frutos Secos");
                chkLacteos.IsChecked = cliente.Alergias.Contains("Lácteos");
            }
            
            // Establecer el método de pago preferido
            metodoPagoSeleccionado = cliente.MetodoPagoPreferido;
            if (!string.IsNullOrEmpty(cliente.MetodoPagoPreferido))
            {
                if (cliente.MetodoPagoPreferido == "Efectivo")
                {
                    btnEfectivo.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6F00"));
                    btnEfectivo.Foreground = Brushes.White;
                    btnEfectivo.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6F00"));
                }
                else if (cliente.MetodoPagoPreferido == "Tarjeta")
                {
                    btnTarjeta.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6F00"));
                    btnTarjeta.Foreground = Brushes.White;
                    btnTarjeta.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6F00"));
                }
            }
            
            // Agregar eventos de clic a los botones de pago
            btnEfectivo.Click += btnEfectivo_Click;
            btnTarjeta.Click += btnTarjeta_Click;
        }
        
        private void btnEfectivo_Click(object sender, RoutedEventArgs e)
        {
            btnEfectivo.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6F00"));
            btnEfectivo.Foreground = Brushes.White;
            btnEfectivo.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6F00"));
            
            btnTarjeta.Background = Brushes.White;
            btnTarjeta.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
            btnTarjeta.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DDDDDD"));
            
            metodoPagoSeleccionado = "Efectivo";
        }

        private void btnTarjeta_Click(object sender, RoutedEventArgs e)
        {
            btnTarjeta.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6F00"));
            btnTarjeta.Foreground = Brushes.White;
            btnTarjeta.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6F00"));
            
            btnEfectivo.Background = Brushes.White;
            btnEfectivo.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
            btnEfectivo.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DDDDDD"));
            
            metodoPagoSeleccionado = "Tarjeta";
        }
        
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            ClienteActualizado = null;
            this.Close();
        }
        
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            // Validar que los campos obligatorios estén completos
            if (string.IsNullOrWhiteSpace(txtNombreApellidosCliente.Text))
            {
                MessageBox.Show("El nombre es obligatorio", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefonosCliente.Text))
            {
                MessageBox.Show("El teléfono es obligatorio", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmailsCliente.Text))
            {
                MessageBox.Show("El email es obligatorio", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Recopilar las alergias seleccionadas
            List<string> alergias = new List<string>();
            if (chkPescado.IsChecked == true) alergias.Add("Pescado");
            if (chkGluten.IsChecked == true) alergias.Add("Gluten");
            if (chkHuevos.IsChecked == true) alergias.Add("Huevos");
            if (chkMaiz.IsChecked == true) alergias.Add("Maíz");
            if (chkFrutosSecos.IsChecked == true) alergias.Add("Frutos Secos");
            if (chkLacteos.IsChecked == true) alergias.Add("Lácteos");

            // Parsear puntos acumulados
            int puntosAcumulados = 0;
            if (!string.IsNullOrWhiteSpace(txtPuntosCliente.Text))
            {
                int.TryParse(txtPuntosCliente.Text, out puntosAcumulados);
            }

            // Actualizar el cliente original con los nuevos valores
            clienteOriginal.Nombre = txtNombreApellidosCliente.Text.Trim();
            clienteOriginal.Telefono = txtTelefonosCliente.Text.Trim();
            clienteOriginal.Email = txtEmailsCliente.Text.Trim();
            clienteOriginal.Direccion = txtDireccionCliente.Text.Trim();
            clienteOriginal.Alergias = alergias;
            clienteOriginal.PuntosAcumulados = puntosAcumulados;
            clienteOriginal.MetodoPagoPreferido = metodoPagoSeleccionado;
            
            // Guardar referencia al cliente actualizado
            ClienteActualizado = clienteOriginal;

            // Cerrar la ventana
            this.Close();
        }
    }
}

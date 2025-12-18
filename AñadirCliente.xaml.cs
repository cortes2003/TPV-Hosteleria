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
    /// Lógica de interacción para AñadirCliente.xaml
    /// </summary>
    public partial class AñadirCliente : Window
    {
        // Propiedad pública para que Home.xaml.cs pueda acceder al cliente guardado
        public Cliente ClienteGuardado { get; private set; }
        
        private string metodoPagoSeleccionado = "";

        public AñadirCliente()
        {
            InitializeComponent();
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

            // Parsear puntos acumulados (valor por defecto 0 si está vacío o no es válido)
            int puntosAcumulados = 0;
            if (!string.IsNullOrWhiteSpace(txtPuntosCliente.Text))
            {
                int.TryParse(txtPuntosCliente.Text, out puntosAcumulados);
            }

            // Crear el nuevo cliente
            ClienteGuardado = new Cliente
            {
                Nombre = txtNombreApellidosCliente.Text.Trim(),
                Telefono = txtTelefonosCliente.Text.Trim(),
                Email = txtEmailsCliente.Text.Trim(),
                Direccion = txtDireccionCliente.Text.Trim(),
                Alergias = alergias,
                PuntosAcumulados = puntosAcumulados,
                MetodoPagoPreferido = metodoPagoSeleccionado
            };

            // Cerrar la ventana
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            // No guardar nada, simplemente cerrar la ventana
            ClienteGuardado = null;
            this.Close();
        }

        private void btnEfectivo_Click(object sender, RoutedEventArgs e)
        {
            btnEfectivo.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6F00"));
            btnEfectivo.Foreground = Brushes.White;
            btnEfectivo.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6F00"));
            
            btnTarjeta.Background = Brushes.White;
            btnTarjeta.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
            btnTarjeta.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DDDDDD"));
            
            // Guardar método de pago seleccionado
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
            
            // Guardar método de pago seleccionado
            metodoPagoSeleccionado = "Tarjeta";
        }
    }
}


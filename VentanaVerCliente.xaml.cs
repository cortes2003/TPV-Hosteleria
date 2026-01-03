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
        public VentanaVerCliente(Cliente cliente)
        {
            InitializeComponent();
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
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TPV_Hosteleria
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    ///
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, RoutedEventArgs e)
        {
            // Si no se ha introducido el login
            if (String.IsNullOrEmpty(txtUsuario.Text)
            || String.IsNullOrEmpty(passContrasena.Password))
            {
                // feedback al usuario
                lblEstado.Foreground = Brushes.Red;
                lblEstado.Content = "Introduzca el usuario y la contraseña";
            }
            else
            {
                if (txtUsuario.Text.Equals(usuario)
                && passContrasena.Password.Equals(password))
                {
                    Application.Current.Shutdown();
                }
                else
                {
                    // feedback al usuario
                    lblEstado.Foreground = Brushes.Red;
                    lblEstado.Content = "Combinación usuario-contraseña incorrecta";
                }
            }
        }

        private void txtUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

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
    public partial class MainWindow : Window
    {
        // Credenciales harcodeadas (como pide el enunciado para probar)
        private const string usuarioValido = "ipo";
        private const string passwordValido = "ipo";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, RoutedEventArgs e)
        {
            // 1. Validar que no estén vacíos
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtPassword.Password))
            {
                txtError.Text = "Introduzca usuario y contraseña";
                txtError.Visibility = Visibility.Visible;
                return; // Salimos
            }

            // 2. Validar credenciales
            if (txtUsuario.Text == usuarioValido && txtPassword.Password == passwordValido)
            {
                // --- LOGIN CORRECTO ---

                // A. Crear la ventana Home pasándole el nombre del usuario
                Home ventanaHome = new Home(txtUsuario.Text);

                // B. Mostrar la ventana Home
                ventanaHome.Show();

                // C. Cerrar la ventana actual (Login)
                this.Close();
            }
            else
            {
                // --- LOGIN INCORRECTO ---
                txtError.Text = "Usuario o contraseña incorrectos";
                txtError.Visibility = Visibility.Visible;

                // Opcional: Limpiar contraseña
                txtPassword.Password = "";
                txtPassword.Focus();
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) //Para cuando pulsemos enter mientras estamos escribiendo el usuario
            {
                txtPassword.IsEnabled = true;
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnAcceder_Click(sender, e);
            }
        }
    }
}
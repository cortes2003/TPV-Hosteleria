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

namespace TPV_Hosteleria
{
    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        // Modificamos el constructor para pedir el nombre del usuario
        public Home(string nombreUsuario)
        {
            InitializeComponent();

            // 1. Asignar el nombre del usuario al TextBlock
            txtNombreUsuario.Text = "Hola, " + nombreUsuario;

            // 2. Asignar la fecha y hora actual al TextBlock
            txtUltimoAcceso.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

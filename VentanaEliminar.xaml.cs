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
    /// Lógica de interacción para VentanaEliminar.xaml
    /// </summary>
    public partial class VentanaEliminar : Window
    {
        /// <summary>
        /// Propiedad para indicar si el usuario confirmó la eliminación
        /// </summary>
        public bool Confirmado { get; private set; }

        public VentanaEliminar()
        {
            InitializeComponent();
            Confirmado = false;
        }

        /// <summary>
        /// Evento cuando se pulsa el botón SI - Confirmar eliminación
        /// </summary>
        private void btnSi_Click(object sender, RoutedEventArgs e)
        {
            Confirmado = true;
            this.Close();
        }

        /// <summary>
        /// Evento cuando se pulsa el botón NO - Cancelar eliminación
        /// </summary>
        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            Confirmado = false;
            this.Close();
        }
    }
}

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
            //Aqui hay que inicializar cada texto dependiendo de lo que haya en el home de clientes, tambien hace falta crear la clase cliente igual que producto en home
            
        }
    }
}

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
    /// Lógica de interacción para AñadirCliente.xaml
    /// </summary>
    public partial class AñadirCliente : Window
    {
        public AñadirCliente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

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
    }
}

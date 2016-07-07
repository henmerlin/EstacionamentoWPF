using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Estacionamento.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void AbrirWindowCliente(object sender, RoutedEventArgs e)
        {
            Window form = new Clientes();
            form.ShowDialog();
        }

        private void AbrirWindowVagas(object sender, RoutedEventArgs e)
        {
            Window form = new Vagas();
            form.ShowDialog();
        }

        private void AbrirWindowMarcas(object sender, RoutedEventArgs e)
        {
            Window form = new Marcas();
            form.ShowDialog();
        }

        private void AbrirWindowModelos(object sender, RoutedEventArgs e)
        {
            Window form = new Modelos();
            form.ShowDialog();
        }

        private void AbrirWindowServico(object sender, RoutedEventArgs e)
        {
            Window form = new Servicos();
            form.ShowDialog();
        }

        private void AbrirWindowVeiculos(object sender, RoutedEventArgs e)
        {
            Window form = new Veiculos();
            form.ShowDialog();
        }

        private void AbrirWindowListarVagas(object sender, RoutedEventArgs e)
        {
            Form form = new ListarVagas();
            form.ShowDialog();
        }
        


    }
}

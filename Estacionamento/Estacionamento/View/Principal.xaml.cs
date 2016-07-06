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

        private void Cadastro_Funcionario(object sender, RoutedEventArgs e)
        {

        }


    }
}

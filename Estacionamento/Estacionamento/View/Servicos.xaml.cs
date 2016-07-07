using Estacionamento.DAL;
using Estacionamento.Model;
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

namespace Estacionamento.View
{
    /// <summary>
    /// Interaction logic for Servicos.xaml
    /// </summary>
    public partial class Servicos : Window
    {

        Servico s = new Servico();
        public Servicos()
        {
            InitializeComponent();
        }


        private void Gravar(object sender, RoutedEventArgs e)
        {
            s = new Servico();
            s.Cliente.Nome = txt_cliente.Text;
            s.Veiculo.Cliente = txt_Veiculo;


        }
        private void Buscar(object sender, RoutedEventArgs e)
        {

        }



    
    }
}

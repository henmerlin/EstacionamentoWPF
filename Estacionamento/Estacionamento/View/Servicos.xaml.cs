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


        private void GravarServico(object sender, RoutedEventArgs e)
        {
            s = new Servico();

            //Veiculo v = new Veiculo();
            //v.Placa = txtBuscaPlaca.Text;

            //s.Veiculo = VeiculoDAO.VerificarVeiculoPorPlaca(v);
            //s.Cliente = s.Veiculo.Cliente;
            //s.DataInicio = DateTime.Now;

            if (ServicoDAO.AdicionarServico(s))
            {
                MessageBox.Show("Serviço iniciado com sucesso!", "Cadastro de Serviços",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Não foi possível gravar!", "Cadastro de Serviços",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }

            txtBuscaPlaca.Text = "";
            txtBuscaPlaca.Focus();

        }
        private void Buscar(object sender, RoutedEventArgs e)
        {
            s = new Servico();

            Veiculo v = new Veiculo();
            v.Placa = txtBuscaPlaca.Text;


            if (!string.IsNullOrEmpty(txtBuscaPlaca.Text))
            {
                s = ServicoDAO.VerificarServicoPorPlaca(VeiculoDAO.VerificarVeiculoPorPlaca(v));
                if (s != null)
                {
                    lbCliente.Content = s.Cliente.Nome;
                    lbMarca.Content = s.Veiculo.Modelo.Nome;
                    lbVaga.Content = s.Vaga.Id + " " + s.Vaga.Referencia;
                    HabilitarBotoes();
                }
                else
                {
                    MessageBox.Show("Placa não encontrada, para iniciar - pressione Iniciar Serviço!", "Cadastro de Serviço",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher o campo da busca", "Cadastro de Serviço",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private void Cancelar(object sender, RoutedEventArgs e)
        {
            DesabilitarBotoes();
        }
        public void HabilitarBotoes()
        {
            btn_edit.IsEnabled = true;
            btn_remove.IsEnabled = true;
            btn_cancel.IsEnabled = true;
            btn_save.IsEnabled = false;
        }

        public void DesabilitarBotoes()
        {
            btn_edit.IsEnabled = false;
            btn_remove.IsEnabled = false;
            btn_cancel.IsEnabled = false;
            btn_save.IsEnabled = true;
            lbCliente.Content = "";
            lbDuracao.Content = "";
            lbMarca.Content = "";
            lbModelo.Content = "";
            txtBuscaPlaca.Focus();
        }

        private void Remover(object sender, RoutedEventArgs e)
        {
            //if (MessageBox.Show("Deseja remover o registro?", "Cadastro de Servico",
            //    MessageBoxButton.YesNo, MessageBoxImage.Question) ==
            //    MessageBoxResult.Yes)
            //{
            //    if (ClienteDAO.RemoverCliente(c))
            //    {
            //        MessageBox.Show("Cliente removido com sucesso", "Cadastra Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Cliente não removido!", "Cadastra Cliente", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //    DesabilitarBotoes();
            //}
            //else
            //{
            //    DesabilitarBotoes();
            //}
        }
    }
}

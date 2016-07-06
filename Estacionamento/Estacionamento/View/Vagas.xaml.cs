using Estacionamento.DAL;
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
    /// Interaction logic for Clientes.xaml
    /// </summary>
    public partial class Vagas : Window
    {

        private Vaga v = new Vaga();

        public Vagas()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            v = new Vaga();
            v.Referencia = txtReferencia.Text;


            if (VagaDAO.AdicionarVaga(v))
            {
                MessageBox.Show("Gravado com sucesso!", "Cadastro de Vaga",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
               MessageBox.Show("Não foi possível gravar!", "Cadastro de Vaga",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }

            txtReferencia.Text = "";
            txtReferencia.Focus();
        }

        private void btnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            v = new Vaga();
            if (!string.IsNullOrEmpty(txtNrVaga.Text))
            {


                v.Id = int.Parse(txtNrVaga.Text);

                v = VagaDAO.VerificarVagaPorId(v);
                if (v != null)
                {
                    txtReferencia.Text = v.Referencia;
                    HabilitarBotoes();
                }
                else
                {
                    MessageBox.Show("Vaga não encontrada!", "Cadastro de Vaga",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher o campo da busca", "Cadastro de Vaga",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void HabilitarBotoes()
        {
            btnAlterar.IsEnabled = true;
            btnRemover.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            btnGravar.IsEnabled = false;
        }

        public void DesabilitarBotoes()
        {
            btnAlterar.IsEnabled = false;
            btnRemover.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            btnGravar.IsEnabled = true;
            txtReferencia.Clear();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DesabilitarBotoes();
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja remover o registro?", "Cadastro de Vaga",
                MessageBoxButton.YesNo, MessageBoxImage.Question) ==
                MessageBoxResult.Yes)
            {
                if (VagaDAO.RemoverVaga(v))
                {
                    MessageBox.Show("Vaga removida com sucesso", "Cadastra Vaga", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Vaga não removida!", "Cadastra Vaga", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                DesabilitarBotoes();
            }
            else
            {
                DesabilitarBotoes();
            }
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Deseja alterar o registro?", "Cadastro de Vaga",
                MessageBoxButton.YesNo, MessageBoxImage.Question) ==
                MessageBoxResult.Yes)
            {
                v.Referencia = txtReferencia.Text;
                if (VagaDAO.AlterarVaga(v))
                {
                    MessageBox.Show("Vaga alterada com sucesso", "Cadastra Vaga", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Vaga não alterada!", "Cadastra Vaga", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                DesabilitarBotoes();
            }
            else
            {
                DesabilitarBotoes();
            }
        }
    }
}

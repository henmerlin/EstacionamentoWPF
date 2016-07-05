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


            if (ClienteDAO.AdicionarCliente(c))
            {
                MessageBox.Show("Gravado com sucesso!", "Cadastro de Cliente",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Não foi possível gravar!", "Cadastro de Cliente",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }

            txtNome.Text = "";
            txtNome.Focus();
        }

        private void btnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            c = new Cliente();
            if (!string.IsNullOrEmpty(txtBuscarCliente.Text))
            {
                c.Cpf = txtBuscarCliente.Text;
                c = ClienteDAO.VerificarClientePorCPF(c);
                if (c != null)
                {
                    txtNome.Text = c.Nome;
                    txtCpf.Text = c.Cpf;
                    txtTelefone.Text = c.Telefone;
                    HabilitarBotoes();
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado!", "Cadastro de Cliente",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher o campo da busca", "Cadastro de Cliente",
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
            txtBuscarCliente.Clear();
            txtCpf.Clear();
            txtNome.Clear();
            txtTelefone.Clear();
            txtBuscarCliente.Focus();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DesabilitarBotoes();
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja remover o registro?", "Cadastro de Cliente",
                MessageBoxButton.YesNo, MessageBoxImage.Question) ==
                MessageBoxResult.Yes)
            {
                if (ClienteDAO.RemoverCliente(c))
                {
                    MessageBox.Show("Cliente removido com sucesso", "Cadastra Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Cliente não removido!", "Cadastra Cliente", MessageBoxButton.OK, MessageBoxImage.Error);
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

            if (MessageBox.Show("Deseja alterar o registro?", "Cadastro de Cliente",
                MessageBoxButton.YesNo, MessageBoxImage.Question) ==
                MessageBoxResult.Yes)
            {
                c.Nome = txtNome.Text;
                c.Cpf = txtCpf.Text;
                c.Telefone = txtTelefone.Text;
                if (ClienteDAO.AlterarCliente(c))
                {
                    MessageBox.Show("Cliente alterado com sucesso", "Cadastra Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Cliente não alterado!", "Cadastra Cliente", MessageBoxButton.OK, MessageBoxImage.Error);
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

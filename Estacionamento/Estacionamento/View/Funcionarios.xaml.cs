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
using Estacionamento.DAL;
using Estacionamento.Model;
namespace Estacionamento.Views
{
    /// <summary>
    /// Interaction logic for Funcionarios.xaml
    /// </summary>
    /// 
    public partial class Funcionarios : Window
    {

        private Funcionario f = new Funcionario();

        public frmCadastroFuncionario()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            f = new Funcionario();
            f.Nome = txtNome.Text;
            f.Cpf = txtCpf.Text;
            f.Telefone = txtTelefone.Text;
            if (FuncionarioDAO.AdicionarFuncionario(f))
            {
                MessageBox.Show("Gravado com sucesso!", "Cadastro de Funcionário",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Não foi possível gravar!", "Cadastro de Funcionário",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }

            txtNome.Text = "";
            txtNome.Focus();

        }

        private void btnBuscarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            f = new Funcionario();
            if (!string.IsNullOrEmpty(txtBuscaFuncionario.Text))
            {
               f.Cpf = txtBuscaFuncionario.Text;
               f=FuncionarioDAO.VerificaCPF(f);
                if (f != null)
                {
                    txtNome.Text = f.Nome;
                    txtCpf.Text = f.Cpf;
                    txtTelefone.Text = f.Telefone;
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
            txtBuscaFuncionario.Clear();
            txtCpf.Clear();
            txtNome.Clear();
            txtTelefone.Clear();
            txtBuscaFuncionario.Focus();
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
                if (FuncionarioDAO.RemoverFuncionario(f))
                {
                    MessageBox.Show("Funcionário removido com sucesso", "Cadastro Funcionário", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Funcionário não removido!", "Cadastro Funcionário", MessageBoxButton.OK, MessageBoxImage.Error);
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

            if (MessageBox.Show("Deseja alterar o registro?", "Cadastro de Funcionário",
                MessageBoxButton.YesNo, MessageBoxImage.Question) ==
                MessageBoxResult.Yes)
            {
                txtNome.Text = f.Nome;
                txtCpf.Text = f.Cpf;
                txtTelefone.Text = f.Telefone;
                if (FuncionarioDAO.AlterarFuncionario(f))
                {
                    MessageBox.Show("Funcionário alterado com sucesso", "Cadastro Funcionário", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Funcionário não alterado!", "Cadastro FUncionário", MessageBoxButton.OK, MessageBoxImage.Error);
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

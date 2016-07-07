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
    public partial class Marcas : Window
    {

        private Marca m = new Marca();

        public Marcas()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            m = new Marca();
            m.Nome = txtNomeMarca.Text;

            if (MarcaDAO.AdicionarMarca(m))
            {
                MessageBox.Show("Gravado com sucesso!", "Cadastro de Marca",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
               MessageBox.Show("Não foi possível gravar!", "Cadastro de Marca",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }

            txtNomeMarca.Text = "";
            txtNomeMarca.Focus();
        }

        private void btnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            m = new Marca();

            if (!string.IsNullOrEmpty(txtBuscarMarca.Text))
            {
                m.Nome = txtBuscarMarca.Text;
                m = MarcaDAO.VerificarMarcaPorNome(m);
                if (m != null)
                {
                    txtNomeMarca.Text = m.Nome;
                    HabilitarBotoes();
                }
                else
                {
                    MessageBox.Show("Marca não encontrada!", "Cadastro de Marca",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher o campo da busca", "Cadastro de Marca",
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
            txtNomeMarca.Clear();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DesabilitarBotoes();
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja remover o registro?", "Cadastro de Marca",
                MessageBoxButton.YesNo, MessageBoxImage.Question) ==
                MessageBoxResult.Yes)
            {
                if (MarcaDAO.RemoverMarca(m))
                {
                    MessageBox.Show("Marca removida com sucesso", "Cadastra Marca", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Marca não removida!", "Cadastra Marca", MessageBoxButton.OK, MessageBoxImage.Error);
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

            if (MessageBox.Show("Deseja alterar o registro?", "Cadastro de Marca",
                MessageBoxButton.YesNo, MessageBoxImage.Question) ==
                MessageBoxResult.Yes)
            {
                m.Nome = txtNomeMarca.Text;
                if (MarcaDAO.AlterarMarca(m))
                {
                    MessageBox.Show("Marca alterada com sucesso", "Cadastra Marca", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Marca não alterada!", "Cadastra Marca", MessageBoxButton.OK, MessageBoxImage.Error);
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

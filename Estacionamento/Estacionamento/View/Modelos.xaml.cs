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
    /// Interaction logic for Clientes.xaml
    /// </summary>
    public partial class Modelos : Window
    {

        private Modelo m = new Modelo();
        private Marca marca = new Marca();

        public Modelos()
        {
            InitializeComponent();

            comboBoxMarca.ItemsSource = MarcaDAO.RetornarLista();
            comboBoxMarca.DisplayMemberPath = "Nome";
            comboBoxMarca.SelectedValuePath = "Id";

        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            m = new Modelo();
            m.Nome = txtNomeModelo.Text;

            marca = MarcaDAO.VerificarMarcaPorNome((Marca)comboBoxMarca.SelectedItem);
            m.Marca = marca;

            if (ModeloDAO.AdicionarModelo(m))
            {
                MessageBox.Show("Gravado com sucesso!", "Cadastro de Modelo",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Não foi possível gravar!", "Cadastro de Modelo",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }

            txtNomeModelo.Text = "";
            txtNomeModelo.Focus();
        }

        private void btnBuscarModelo_Click(object sender, RoutedEventArgs e)
        {
            m = new Modelo();

            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                m.Nome = txtBuscar.Text;
                m = ModeloDAO.VerificarModeloPorNome(m);
                if (m != null)
                {
                    txtNomeModelo.Text = m.Nome;
                    comboBoxMarca.SelectedItem = m.Nome;
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
            txtNomeModelo.Clear();
            txtNomeModelo.Focus();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DesabilitarBotoes();
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja remover o registro?", "Cadastro de Modelo",
                MessageBoxButton.YesNo, MessageBoxImage.Question) ==
                MessageBoxResult.Yes)
            {
                if (ModeloDAO.RemoverModelo(m))
                {
                    MessageBox.Show("Modelo removido com sucesso", "Cadastra Modelo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Modelo não removido!", "Cadastra Modelo", MessageBoxButton.OK, MessageBoxImage.Error);
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

            if (MessageBox.Show("Deseja alterar o registro?", "Cadastro de Modelo",
                MessageBoxButton.YesNo, MessageBoxImage.Question) ==
                MessageBoxResult.Yes)
            {

                m.Nome = txtNomeModelo.Text;
                marca = MarcaDAO.VerificarMarcaPorNome((Marca)comboBoxMarca.SelectedItem);
                m.Marca = marca;

                if (ModeloDAO.AlterarModelo(m))
                {
                    MessageBox.Show("Modelo alterado com sucesso", "Cadastra Modelo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Modelo não alterado!", "Cadastra Modelo", MessageBoxButton.OK, MessageBoxImage.Error);
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

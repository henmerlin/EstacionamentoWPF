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
    public partial class Veiculos : Window
    {

        private Veiculo v = new Veiculo();

        private Marca marca = new Marca();

        public Veiculos()
        {
            InitializeComponent();

            comboBoxMarca.ItemsSource = MarcaDAO.RetornarLista();
            comboBoxMarca.DisplayMemberPath = "Nome";
            comboBoxMarca.SelectedValuePath = "Id";

            comboBoxCliente.ItemsSource = ClienteDAO.RetornarLista();
            comboBoxCliente.DisplayMemberPath = "Nome";
            comboBoxCliente.SelectedValuePath = "Id";

            comboBoxModelo.ItemsSource = ModeloDAO.RetornarLista();
            comboBoxModelo.DisplayMemberPath = "Nome";
            comboBoxModelo.SelectedValuePath = "Id";


        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {

            v = new Veiculo();
            v.Cliente = (Cliente)comboBoxCliente.SelectedItem;
            v.Modelo = (Modelo)comboBoxModelo.SelectedItem;
            v.Placa = txtPlaca.Text;

            if (VeiculoDAO.AdicionarVeiculo(v))
            {
                MessageBox.Show("Gravado com sucesso!", "Cadastro de Veiculo",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
               MessageBox.Show("Não foi possível gravar!", "Cadastro de Veiculo",
                MessageBoxButton.OK, MessageBoxImage.Error);
               DesabilitarBotoes();
            }

            txtPlaca.Text = "";
            txtPlaca.Focus();
          
        }


        private void btnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            v = new Veiculo();

            if (!string.IsNullOrEmpty(txtBuscarPlaca.Text))
            {
                v.Placa = txtBuscarPlaca.Text;
                v = VeiculoDAO.VerificarVeiculoPorPlaca(v);
                if (v != null)
                {
                    txtPlaca.Text = v.Placa;
                    comboBoxCliente.SelectedItem = v.Cliente;
                    comboBoxMarca.SelectedItem = v.Modelo.Marca;
                    comboBoxModelo.SelectedItem = v.Modelo;
                    HabilitarBotoes();
                }
                else
                {
                    MessageBox.Show("Veiculo não encontrado!", "Cadastro de Veiculo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    DesabilitarBotoes();
                }
                
            }
            else
            {
                MessageBox.Show("Favor preencher o campo da busca", "Cadastro de Veiculo",
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
            comboBoxMarca.SelectedItem = "";
            comboBoxModelo.SelectedItem = "";
            comboBoxCliente.SelectedItem = "";
            txtPlaca.Text = "";
            txtPlaca.Clear();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DesabilitarBotoes();
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja remover o registro?", "Cadastro de Veiculo",
                MessageBoxButton.YesNo, MessageBoxImage.Question) ==
                MessageBoxResult.Yes)
            {
                if (VeiculoDAO.RemoverVeiculo(v))
                {
                    MessageBox.Show("Veiculo removido com sucesso", "Cadastra Veiculo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Veiculo não removido!", "Cadastra Veiculo", MessageBoxButton.OK, MessageBoxImage.Error);
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
                v.Cliente = (Cliente)comboBoxCliente.SelectedItem;
                v.Modelo = (Modelo)comboBoxModelo.SelectedItem;
                v.Placa = txtPlaca.Text;

                if (VeiculoDAO.AlterarVeiculo(v))
                {
                    MessageBox.Show("Veiculo alterado com sucesso", "Cadastra Veiculo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Veiculo não alterado!", "Cadastra Veiculo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                DesabilitarBotoes();
            }
            else
            {
                DesabilitarBotoes();
            }
        }

        private void comboBoxMarca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            marca = MarcaDAO.VerificarMarcaPorNome((Marca)comboBoxMarca.SelectedItem);

            comboBoxModelo.ItemsSource = marca.ListaDeModelos;
            comboBoxModelo.DisplayMemberPath = "Nome";
            comboBoxModelo.SelectedValuePath = "Id";
        }
    }
}

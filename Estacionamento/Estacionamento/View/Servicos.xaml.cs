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
        


        }
        private void Buscar(object sender, RoutedEventArgs e)
        {

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
            txtBuscaServico.Clear();
            txt_cliente.Clear();
            txt_Marca.Clear();
            txt_Modelo.Clear();
            txt_Placa.Clear();
            txt_Vaga.Clear();
            txtBuscaServico.Focus();
        }

        private void Remover(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja remover o registro?", "Cadastro de Servico",
                MessageBoxButton.YesNo, MessageBoxImage.Question) ==
                MessageBoxResult.Yes)
            {
                if (ServicoDAO.RemoverServico(s))
                {
                    MessageBox.Show("Servico removido com sucesso", "Cadastro Servico", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Servico não removido!", "Cadastro Servico", MessageBoxButton.OK, MessageBoxImage.Error);
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

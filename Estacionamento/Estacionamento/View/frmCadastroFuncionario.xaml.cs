﻿using System;
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

namespace WpfVendas.Views
{
    /// <summary>
    /// Interaction logic for frmCadastroCliente.xaml
    /// </summary>
    /// 
    public partial class frmCadastroCliente : Window
    {

        private Funcionario f = new Funcionario();

        public frmCadastroCliente()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            f = new Funcionario();
            f.Nome = txtNome.Text;
            f.Cpf = txtCpf.Text;
           
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

        private void btnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            f = new Funcionario();
            if (!string.IsNullOrEmpty(txtBuscarFuncionario.Text))
            {
                f.Cpf = txtBuscarFuncionario.Text;
                f = FuncionarioDAO.VerificaCPF(f);
                if (f != null)
                {
                    txtNome.Text = f.Nome;
                    txtCpf.Text = c.ClienteCpf;
                    txtTelefone.Text = c.ClienteTelefone;
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
                c.ClienteNome = txtNome.Text;
                c.ClienteCpf = txtCpf.Text;
                c.ClienteTelefone = txtTelefone.Text;
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

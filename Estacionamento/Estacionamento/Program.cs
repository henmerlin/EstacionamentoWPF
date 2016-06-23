using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Model;
using Estacionamento.DAL;

namespace Estacionamento
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente c = new Cliente();
            List<Cliente> ListaDeClientes = new List<Cliente>();
            Funcionario f = new Funcionario();
            List<Funcionario> ListaDeFuncionarios = new List<Funcionario>();
            Carro ca = new Carro();
            List<Carro> ListaDeCarros = new List<Carro>();
            Marca m = new Marca();
            List<Marca> ListaDeMarcas = new List<Marca>();
            string opcao;
                     

           
            do
            {

                Console.Clear();
                Console.WriteLine("Menu");
                Console.WriteLine("1- Cadastrar Cliente: ");
                Console.WriteLine("2- Cadastrar Funcionário: ");
                Console.WriteLine("3- Listar Cliente: ");
                Console.WriteLine("4- Listar Funcionário: ");
                Console.WriteLine("5- Cadastrar Carro: ");
                Console.WriteLine("6- Listar Carro: ");
                Console.WriteLine("0- Sair do Sistema.... ");
                opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        
                        c = new Cliente();
                        Console.WriteLine("Cadastro de Cliente");
                        Console.WriteLine("Digite o nome:");
                        c.Nome = Console.ReadLine();
                        Console.WriteLine("Digite o CPF:");
                        c.Cpf = Console.ReadLine();      
                        if (ClienteDAO.AdicionarCliente(c))
                        {

                            Console.WriteLine("Cliente cadastrado com sucesso!!!");
                        }
                        else
                        {
                            ClienteDAO clienteDAO = new ClienteDAO();
                            ClienteDAO.AdicionarCliente(c);
                            Console.WriteLine("Cliente já cadastrado!!!");
                        }


                                break;
                    case "2":
                        f = new Funcionario();
                        Console.WriteLine("Cadastro de Funcionário");
                        Console.WriteLine("Digite o nome:");
                        f.Nome = Console.ReadLine();
                        Console.WriteLine("Digite o CPF:");
                        f.Cpf = Console.ReadLine();
                        if (FuncionarioDAO.AdicionarFuncionario(f))
                        {

                            Console.WriteLine("Funcionário cadastrado com sucesso!!!");
                        }
                        else
                        {
                            FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
                            FuncionarioDAO.AdicionarFuncionario(f);
                            Console.WriteLine("Funcionário já cadastrado!!!");
                        }

                        break;




                    case "3":
                        
                        if (ClienteDAO.RetornarLista().Count > 0)
                        {
                            Console.WriteLine("Visualização de Clientes");
                            foreach (Cliente clienteCadastrado in ClienteDAO.RetornarLista())
                            {
                                Console.WriteLine(clienteCadastrado);
                                Console.WriteLine("");
                            }
                        }
                        else
                        {
                            Console.WriteLine("A lista esta vazia!!!");
                        }
                        break;



                    case "4":
                        
                        if (FuncionarioDAO.RetornarLista().Count > 0)
                        {
                            Console.WriteLine("Visualização de Funcionários");
                            foreach (Funcionario funcionarioCadastrado in FuncionarioDAO.RetornarLista())
                            {
                                Console.WriteLine(funcionarioCadastrado);
                                Console.WriteLine("");
                            }
                        }
                        else
                        {
                            
                            Console.WriteLine("A lista esta vazia!!!");
                        }
                        break;

                    case "5":
                       
                        ca = new Carro();
                        Console.WriteLine("Cadastro de Carros"); //excessão de cadastro com marca exixtente 
                          do
                        {
                            Console.WriteLine("Digite a Marca do Veiculo:");
                            ca.Marca.Nome = Console.ReadLine();
                            if (MarcaDAO.VerificaNome(m) == null)
                            {
                                Console.WriteLine("Marca não encontrada !!!");
                            }
                        } while (MarcaDAO.VerificaNome(m) == null);
                        ca.Marca = MarcaDAO.VerificaNome(m);

                        Console.WriteLine("Digite o Modelo:");
                        ca.Modelo= Console.ReadLine();
                        Console.WriteLine("Digite a Placa:");
                        ca.Placa = Console.ReadLine();
                        if (CarroDAO.AdicionarCarro(ca))
                        {

                            Console.WriteLine("Carro cadastrado com sucesso!!!");
                        }
                        else
                        {
                            CarroDAO carroDAO = new CarroDAO();
                            CarroDAO.AdicionarCarro(ca);
                            Console.WriteLine("Carro já cadastrado!!!");
                        }

                        break;

                    case "6":
                        if (CarroDAO.RetornarLista().Count > 0)
                        {
                            Console.WriteLine("Visualização de Carros");
                            foreach (Carro carroCadastrado in CarroDAO.RetornarLista())
                            {
                                Console.WriteLine(carroCadastrado);
                                Console.WriteLine("");
                            }
                        }
                        else
                        {

                            Console.WriteLine("A lista esta vazia!!!");
                        }
                        break;



                    case "0":
                        Console.WriteLine("Saindo......");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!!!!");
                        break;

                        
                }


                Console.ReadKey();

            } while(!opcao.Equals("0"));


        }
    }
}

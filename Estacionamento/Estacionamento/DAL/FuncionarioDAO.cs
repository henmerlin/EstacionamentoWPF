using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Model;

namespace Estacionamento.DAL
{
    class FuncionarioDAO
    {

        private static Context ctx = Singleton.Instance.Context;

        private static List<Funcionario> ListaDeFuncionario = new List<Funcionario>();


        public static bool AdicionarFuncionario(Funcionario f)
        {
            if (VerificaCPF(f) == null)
            {
               ListaDeFuncionario.Add(f);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Funcionario> RetornarLista()
        {

            return ListaDeFuncionario;

        }


        public static Funcionario VerificaCPF(Funcionario f)
        {

            foreach (Funcionario funcionarioCadastrado in FuncionarioDAO.RetornarLista())
            {
                if (f.Cpf.Equals(funcionarioCadastrado.Cpf))
                {
                    return funcionarioCadastrado;

                }
            }

            return null;

        }
    }
}

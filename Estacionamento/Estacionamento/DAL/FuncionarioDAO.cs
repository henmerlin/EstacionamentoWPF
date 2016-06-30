using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.DAL;

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

        public static bool RemoverFuncionario(Funcionario f)
        {
            try
            {
                ctx.Funcionarios.Remove(f);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AlterarFuncionario(Funcionario f)
        {
            try
            {
                ctx.Entry(f).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}

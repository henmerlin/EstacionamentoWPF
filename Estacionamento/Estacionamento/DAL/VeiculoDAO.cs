using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Model;
using System.Runtime.Remoting.Contexts;

namespace Estacionamento.DAL
{
    class VeiculoDAO
    {

        private static Context ctx = Singleton.Instance.Context;

        private static List<Veiculo> ListaDeCarros = new List<Veiculo>();       

        public static bool AdicionarCarro(Veiculo ca)
        {
            if (VerificaPlaca(ca) == null)
            {
                ListaDeCarros.Add(ca);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Veiculo> RetornarLista()
        {

            return ListaDeCarros;

        }


        public static Veiculo VerificaPlaca(Veiculo ca)
        {

            foreach (Veiculo carroCadastrado in VeiculoDAO.RetornarLista())
            {
                if (ca.Placa.Equals(carroCadastrado.Placa))
                {
                    return carroCadastrado;

                }
            }

            return null;

        }
    }
}

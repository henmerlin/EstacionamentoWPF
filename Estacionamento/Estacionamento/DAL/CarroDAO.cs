using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Model;

namespace Estacionamento.DAL
{
    class CarroDAO
    {
        private static List<Carro> ListaDeCarros = new List<Carro>();       


        public static bool AdicionarCarro(Carro ca)
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

        public static List<Carro> RetornarLista()
        {

            return ListaDeCarros;

        }


        public static Carro VerificaPlaca(Carro ca)
        {

            foreach (Carro carroCadastrado in CarroDAO.RetornarLista())
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

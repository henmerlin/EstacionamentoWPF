using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Model;

namespace Estacionamento.DAL
{
    class MarcaDAO
    {
        private static List<Marca> ListaDeMarcas = new List<Marca>();

        public static bool AdicionarMarca(Marca m)
        {
            if (VerificaNome(m) == null)
            {
                ListaDeMarcas.Add(m);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Marca> RetornarLista()
        {

            return ListaDeMarcas;

        }


        public static Marca VerificaNome(Marca m)
        {

            foreach (Marca marcaCadastrado in MarcaDAO.RetornarLista())
            {
                if (m.Nome.Equals(marcaCadastrado.Nome))
                {
                    return marcaCadastrado;

                }
            }

            return null;

        }
    }
}

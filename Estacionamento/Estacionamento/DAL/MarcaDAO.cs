using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.DAL;

namespace Estacionamento.DAL
{
    class MarcaDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarMarca(Marca m)
        {
            if (VerificaNome(m) == null)
            {
                ctx.Marcas.Add(m);
                ctx.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Marca> RetornarLista()
        {

            return ctx.Marcas.ToList();

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

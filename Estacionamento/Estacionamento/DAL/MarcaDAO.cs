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
            try
            {
                ctx.Marcas.Add(m);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Marca VerificarMarcaPorNome(Marca m)
        {
            return ctx.Marcas.FirstOrDefault(x => m.Nome.Equals(m.Nome));
        }

        public static List<Marca> RetornarLista()
        {
            return ctx.Marcas.ToList();
        }

        public static bool RemoverMarca(Marca m)
        {
            try
            {
                ctx.Marcas.Remove(m);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AlterarMarca(Marca m)
        {
            try
            {
                ctx.Entry(m).State = System.Data.Entity.EntityState.Modified;
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

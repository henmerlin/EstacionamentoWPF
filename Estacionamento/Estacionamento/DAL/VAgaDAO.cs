using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.DAL
{
    class VagaDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarVaga(Vaga v)
        {
            try
            {
                ctx.Vagas.Add(v);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Vaga VerificarVagaPorId(Vaga v)
        {
            return ctx.Vagas.FirstOrDefault(x => v.Id.Equals(v.Id));
        }

        public static List<Vaga> RetornarLista()
        {
            return ctx.Vagas.ToList();
        }

        public static bool RemoverVaga(Vaga v)
        {
            try
            {
                ctx.Vagas.Remove(v);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AlterarVaga(Vaga v)
        {
            try
            {
                ctx.Entry(v).State = System.Data.Entity.EntityState.Modified;
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

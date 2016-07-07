using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.DAL;
using Estacionamento.Model;

namespace Estacionamento.DAL
{
    class ModeloDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarModelo(Modelo m)
        {
            try
            {
                ctx.Modelos.Add(m);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Modelo VerificarModeloPorNome(Modelo m)
        {
            return ctx.Modelos.FirstOrDefault(x => x.Nome.Equals(m.Nome));
        }

        public static List<Modelo> VerificarModeloPorMarca(Marca m)
        {
            return ctx.Modelos.Where(x => x.Marca == m).ToList();
        }

        public static List<Modelo> RetornarLista()
        {
            return ctx.Modelos.ToList();
        }

        public static bool RemoverModelo(Modelo m)
        {
            try
            {
                ctx.Modelos.Remove(m);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AlterarModelo(Modelo m)
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
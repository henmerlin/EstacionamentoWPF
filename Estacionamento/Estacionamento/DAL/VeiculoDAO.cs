using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.DAL;

namespace Estacionamento.DAL
{
    class VeiculoDAO
    {

        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarVeiculo(Veiculo v)
        {
            try
            {
                ctx.Veiculos.Add(v);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Veiculo VerificarVeiculoPorPlaca(Veiculo v)
        {
           return ctx.Veiculos.
                Include("Cliente").
                Include("Modelo").
                FirstOrDefault(x => x.Placa.Equals(v.Placa));
        }

        public static Veiculo VerificarVeiculoPorId(Veiculo v)
        {
            return ctx.Veiculos.FirstOrDefault(x => x.Id.Equals(v.Id));
        }

        public static List<Veiculo> RetornarLista()
        {
            return ctx.Veiculos.ToList();
        }

        public static bool RemoverVeiculo(Veiculo v)
        {
            try
            {
                ctx.Veiculos.Remove(v);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AlterarVeiculo(Veiculo v)
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

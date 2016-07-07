using Estacionamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.DAL
{
    class ServicoDAO
    {


        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarServico(Servico s)
        {
            try
            {
                ctx.Servicos.Add(s);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Servico VerificarServicoPorPlacaVeiculo(Veiculo v)
        {
            return ctx.Servicos.Include("Vaga").
                            Include("Veiculo").
                            Include("Veiculo.Modelo").
                            Include("Veiculo.Modelo.Marca").
                            Include("Cliente").
                            SingleOrDefault(x => x.Veiculo.Placa.Equals(v.Placa) );
        }

        public static Servico VerificarServicoAbertoPorPlacaVeiculo(Veiculo v)
        {
            return ctx.Servicos.Include("Vaga").
                            Include("Veiculo").
                            Include("Veiculo.Modelo").
                            Include("Veiculo.Modelo.Marca").
                            Include("Cliente").
                            SingleOrDefault(x => (x.Veiculo.Placa.Equals(v.Placa) && x.DataFim == null));
        }


        public static List<Servico> RetornarServico()
        {
            return ctx.Servicos.ToList();
        }

        public static bool RemoverServico(Servico s)
        {
            try
            {
                ctx.Servicos.Remove(s);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static bool AlterarServico(Servico s)
        {
            try
            {
                ctx.Entry(s).State = System.Data.Entity.EntityState.Modified;
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

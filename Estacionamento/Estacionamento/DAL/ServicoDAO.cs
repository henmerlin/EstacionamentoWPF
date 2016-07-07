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

        public static List<Servico> RetornarServico()
        {
            return ctx.Servicos.ToList();
        }








        }

    
}

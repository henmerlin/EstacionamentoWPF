using Estacionamento.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.DAL
{
    class Context : DbContext
    {
        public Context()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Veiculo> Veiculos { get; set; }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }

        public DbSet<Servico> Servicos { get; set; }

        public DbSet<Funcionario> Funcionarios { get; set; }


    }
}

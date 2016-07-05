using Estacionamento.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Model
{
    [Table("Modelos")]
    class Modelo
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public Marca Marca { get; set; }

    }
}

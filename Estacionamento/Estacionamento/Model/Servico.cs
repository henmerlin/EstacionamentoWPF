using Estacionamento.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Model
{
    [Table("Servicos")]
    class Servico
    {

        [Key]
        public int Id { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public Vaga Vaga { get; set; }

        public Veiculo Veiculo { get; set; }

    }
}

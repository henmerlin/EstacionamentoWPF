using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.DAL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Estacionamento.DAL
{
    [Table("Vagas")]
    class Vaga
    {
       
        [Key]
        public  int Id { get; set; }

        public string Referencia { get; set; }

        public bool Ocupada { get; set; }

    }
}

using Estacionamento.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.DAL
{
    [Table("Marca")]
    class Marca
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public List<Modelo> ListaDeModelos { get; set; }


    }
}

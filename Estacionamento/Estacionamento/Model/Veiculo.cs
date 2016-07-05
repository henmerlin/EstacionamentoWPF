using Estacionamento.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Estacionamento.DAL
{
    [Table("Veiculos")]
    class Veiculo
    {
        public int Id { get; set; }

        public Modelo Modelo { get; set; }

        public Cliente Cliente { get; set; }

        public string Placa { get; set; }


    }
}

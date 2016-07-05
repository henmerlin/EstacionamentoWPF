using Estacionamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Estacionamento.DAL
{
    class Veiculo
    {
        public int Id { get; set; }

        public Modelo Modelo { get; set; }

        public Cliente Cliente { get; set; }

        public string Placa { get; set; }


    }
}

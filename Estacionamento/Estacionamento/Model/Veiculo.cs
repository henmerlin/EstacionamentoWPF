using Estacionamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Estacionamento.DAL
{
    class Veiculo
    {
        public int Id { get; set; }

        public Marca Marca { get; set; }

        public Modelo Modelo { get; set; }
        
        public string Placa { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + "\nMarca: " + Marca + "\nModelo: " + Modelo + "\nTipo: "+ Tipo+"\nPlaca:" +Placa;
        }
    }
}

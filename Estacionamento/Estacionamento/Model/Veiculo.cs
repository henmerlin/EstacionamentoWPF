using System;
using System.Collections.Generic;
using System.Linq;s
namespace Estacionamento.Model
{
    class Veiculo
    {
        public int Id { get; set; }

        public Marca Marca { get; set; }

        public string Modelo { get; set; }

        public string Tipo { get; set; }

        public string Placa { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + "\nMarca: " + Marca + "\nModelo: " + Modelo + "\nTipo: "+ Tipo+"\nPlaca:" +Placa;
        }
    }
}

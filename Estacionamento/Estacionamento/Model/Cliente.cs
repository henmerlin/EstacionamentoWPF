using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.DAL
{
    class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + "\nNome: " + Nome + "\nCpf: " + Cpf;
        }
    }
}

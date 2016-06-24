using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Model;

namespace Estacionamento.Model
{
    class Vaga
    {
        public string tamanho { get; set; }

        public Cliente Cliente { get; set; }

    public Funcionario Funcionario { get; set; }

    public List<Veiculo> ListaDeVeiculos { get; set; }

}
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Model;

namespace Estacionamento.Model
{
    class Vaga
    {
       
        public  int Id { get; set; }

        public string Referencia { get; set; }

        public override string ToString()
        {
            return "ID: "+ Id+"\nReferência: "+Referencia;
        }

    }
}

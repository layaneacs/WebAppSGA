﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.ApplicationCore.Entity
{
    public class Cliente
    {
        public Cliente()
        {
            // contrutor
        }

        public int Id_Cliente { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
    }

}
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Filtro
    {
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        //public string Guia { get; set; }
        public int IdOrden { get; set; }
        public string IdentificacionCliente { get; set; }
    }
}

using System;
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

    public class MensajeDto {
        public string MensajeSms { get; set; }
        public string MensajeEmail { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }

}

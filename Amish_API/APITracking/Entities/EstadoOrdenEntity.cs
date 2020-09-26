using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class EstadoOrdenEntity
    {
        public int IdEstado { get; set; }
        public int IdWaybill { get; set; }
        public string Comentario{ get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}

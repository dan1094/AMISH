using System;

namespace Entities
{
    public class OrdenEntity
    {
        //Id de la orden
        public int IdOrden { get; set; }
        public OperadorLogisticoEntity Operador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaEntregaMinima { get; set; }
        public DateTime FechaEntregaMaxima { get; set; }

        #region Medidas Paquete
        public int Peso { get; set; }
        //public float Ancho { get; set; }
        //public float Alto { get; set; }

        //public float Largo { get; set; }
        public string tamanio { get; set; }
        public string UrlFoto { get; set; }
        #endregion

        public FacturaEntity Factura { get; set; }

        public DateTime FechaUltimaActualizacion { get; set; }
        public EstadoOrdenEntity Estado { get; set; }

        //public EstadoOrdenEntity Estado { get; set; } // Puede ser una lista aca en esta entidad

    }
}

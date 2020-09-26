using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class FacturaEntity
    {
        public int IdFactura { get; set; }
        public DateTime? FechaCompra { get; set; }

        #region Cliente 
        public string IdentificacionCliente { get; set; }
        public string NombreCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string EmailCliente { get; set; }
        #endregion

        #region Vendedor 
        public string IdentificacionVendedor { get; set; }
        public string NombreVendedor { get; set; }
        public string TelefonoVendedor { get; set; }
        public string DireccionVendedor { get; set; }
        public string EmailVendedor { get; set; }
        #endregion
    }
}

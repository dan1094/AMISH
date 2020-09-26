using Data;
using Entities;
using System;
using System.Collections.Generic;

namespace Rule
{
    public class FacturasRule : RuleBase
    {
        public List<FacturaEntity> ListarFacturas(int idVendedor)
        {
            using (FacturasData data = new FacturasData())
            {
                return data.ListarFacturas(idVendedor);
            }
        }        
    }
}

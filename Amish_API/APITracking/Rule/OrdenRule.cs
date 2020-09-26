using Data;
using Entities;
using System;
using System.Collections.Generic;

namespace Rule
{
    public class OrdenRule : RuleBase
    {
        public OrdenEntity CrearOrden(OrdenEntity orden)
        {
            using (OrdenData data = new OrdenData())
            {
                return data.CrearOrden(orden);
            }
        }
        public List<OrdenEntity> ConsultaOrdenes(Filtro filtro)
        {
            using (OrdenData data = new OrdenData())
            {
                return data.ConsultaOrdenes(filtro);
            }
        }

        /// <summary>
        /// Actualiza datos especificos de la orden
        /// </summary>
        /// <param name="orden"></param>
        /// <returns></returns>
        //public bool ActualizarDetalleOrden(OrdenEntity orden)
        //{
        //    using (OrdenData data = new OrdenData())
        //    {
        //        return data.ActualizarDetalleOrden(orden);
        //    }
        //}
        
    }
}

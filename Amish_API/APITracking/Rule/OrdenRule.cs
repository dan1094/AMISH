using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rule
{
    public class OrdenRule : RuleBase
    {
        public bool CrearOrden(OrdenEntity orden)
        {
            using (OrdenData data = new OrdenData())
            {
                MensajeDto respuesta = data.CrearOrden(orden);

                //Enviar Correo 
                if (!string.IsNullOrEmpty(respuesta.Correo)) EnviarEmailCambioEstado(respuesta.Correo, respuesta.MensajeEmail);
                //Enviar mensaje
                if (!string.IsNullOrEmpty(respuesta.Telefono)) EnviarSmsCambioEstado(respuesta.Telefono, respuesta.MensajeSms);
                return true;
            }
        }
        public List<OrdenEntity> ConsultaOrdenes(Filtro filtro)
        {
            using (OrdenData data = new OrdenData())
            using (EstadosData dataestados = new EstadosData())
            {
                var ordenes = data.ConsultaOrdenes(filtro);
                if (ordenes != null)
                {
                    var estados = dataestados.ConsultaEstados();
                    EstadoEntity estado = null;
                    ordenes.ForEach(ord =>
                    {
                        estado = estados.FirstOrDefault(f => f.IdEstado == ord.Estado.IdEstado);
                        if (estado == null) estado = new EstadoEntity();
                        ord.Estado.Comentario = estado.Descripcion;
                    });
                }

                return ordenes;
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

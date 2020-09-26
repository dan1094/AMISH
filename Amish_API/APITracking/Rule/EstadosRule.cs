using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using System.Linq;

namespace Rule
{
    public class EstadosRule : RuleBase
    {
        public List<EstadoEntity> ConsultarEstados()
        {
            using (EstadosData data = new EstadosData())
            {
                return data.ConsultaEstados();
            }
        }
        public List<EstadoOrdenEntity> ConsultarEstadosOrden(int idOrden)
        {
            using (EstadosData data = new EstadosData())
            {
                return data.ConsultaEstadosOrden(idOrden);
            }
        }
        public bool ActualizarEstadoOrden(EstadoOrdenEntity estado)
        {
            MensajeDto respuesta = null;
            using (EstadosData data = new EstadosData())
            {
                respuesta = data.ActualizarEstadoOrden(estado);
            }
            if (respuesta != null)
            {
                //Enviar Correo 
                if (!string.IsNullOrEmpty(respuesta.Correo)) EnviarEmailCambioEstado(respuesta.Correo, respuesta.Mensaje);
                //Enviar mensaje
                if (!string.IsNullOrEmpty(respuesta.Mensaje)) EnviarSmsCambioEstado(respuesta.Telefono, respuesta.Mensaje);

            }

            return true;
        }
    }
}

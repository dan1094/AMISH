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
            string correo = string.Empty, telefono = string.Empty, mensaje = string.Empty;
            using (EstadosData data = new EstadosData())
            using (OrdenData dataOrden = new OrdenData())
            {
                var estados = data.ConsultaEstados();
                var orden = dataOrden.ConsultaOrdenes(new Filtro { IdOrden = estado.IdWaybill }).FirstOrDefault();
                data.ActualizarEstadoOrden(estado);
                if (orden != null)
                {
                    correo = orden.Factura.EmailCliente;
                    telefono = orden.Factura.TelefonoCliente;
                }
                mensaje = estados.FirstOrDefault(f => f.IdEstado == estado.IdEstado).Mensaje;
            }

            //Enviar Correo 
            if (!string.IsNullOrEmpty(correo)) EnviarEmailCambioEstado(correo, mensaje);
            //Enviar mensaje
            if (!string.IsNullOrEmpty(mensaje)) EnviarSmsCambioEstado(telefono, mensaje);

            return true;
        }

        private void EnviarEmailCambioEstado(string correo, string mensaje)
        {
            string strUrlApi = "http://co2cvw163a:47001/api/Email/registrarCorreo";
            var obj = new
            {
                encabezado = new
                {
                    idOperacion = 9,
                    fechaEnvio = "2020-09-26"
                },
                clienteIdentificacion = new
                {
                    tipoIdentificacion = 1,
                    numeroIdentificacion = "1019046353"
                },
                para = correo,
                cc = "",
                cco = "",
                asunto = "Test de envio de correo electronico",
                mensaje = new
                {
                    plantilla = new
                    {
                        id = 0,
                        datos = new { }
                    },
                    mensaje = $"<html><body>{mensaje}</body></html>"
                },
                adjuntos = new List<string>().ToArray()
            };


            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            string respEmail = RequestPost(strUrlApi, json);

        }
        private void EnviarSmsCambioEstado(string telefono, string mensaje)
        {
            string url = "https://api.masivapp.com/SmsHandlers/sendhandler.ashx?action=sendmessage&username=Api_LH6SK&password=CT6S47QWKW&recipient="
                + telefono + "&messagedata=" + mensaje;

            RequestGet(url);
        }
    }
}

using AmishApp.Models;
using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmishApp.Services
{
    public class EstadosServicio : Conexion
    {
        public List<StatusModel> GetStatus(string urlApi)
        {
            urlApi += $"Estados/GetEstados";

            string response = RequestGet(urlApi);

            var json = JsonConvert.DeserializeObject<Response<List<EstadoEntity>>>(response);

            List<StatusModel> lista = new List<StatusModel>();
            if (json.Data != null)
            {
                json.Data.ForEach(est =>
                {
                    StatusModel registro = new StatusModel
                    {
                        Description = est.Descripcion,
                        StatusId = est.IdEstado.ToString()
                    };
                    lista.Add(registro);
                });
            }

            return lista;
        }

        public List<OrderStatusModel> GetOrderStatus(string urlApi, int idOrder)
        {
            urlApi += $"Estados/ConsultarEstadosOrden?idOrden={idOrder}";

            string response = RequestGet(urlApi);
            var json = JsonConvert.DeserializeObject<Response<List<EstadoOrdenEntity>>>(response);

            List<OrderStatusModel> lista = new List<OrderStatusModel>();

            if (json.Data != null)
            {

                json.Data.ForEach(est =>
                {
                    OrderStatusModel registro = new OrderStatusModel
                    {
                        Comments = est.Comentario,
                        StatusProperty = new StatusModel
                        {
                            StatusId = est.IdEstado.ToString(),
                            Description = est.Comentario
                        },
                        Update = est.FechaActualizacion

                    };
                    lista.Add(registro);
                });
            }

            return lista;
        }

        public bool UpdateOrderStatus(string urlApi, int idStatus, int idOrder)
        {
            urlApi += $"Estados/ActualizarEstadoOrden";
            var obj = new
            {
                idWaybill = idOrder,
                idEstado = idStatus
            };
            string objJson = JsonConvert.SerializeObject(obj, Formatting.Indented);
            string response = RequestPost(urlApi, objJson);                       

            return true;
        }

    }
}

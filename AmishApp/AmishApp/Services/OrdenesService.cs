using AmishApp.Models;
using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmishApp.Services
{
    public class OrdenesService : Conexion
    {
        public WayBillModel GetOrder(string urlApi, int idOrder)
        {
            urlApi += $"Ordenes/ListarOrdenes";
            var obj = new
            {
                idOrden = idOrder
            };
            string objJson = JsonConvert.SerializeObject(obj, Formatting.Indented);
            string response = RequestPost(urlApi, objJson);

            var json = JsonConvert.DeserializeObject<Response<List<OrdenEntity>>>(response);

            WayBillModel wayBillModelResponse = new WayBillModel();

            if (json.Data != null)
            {
                var result = json.Data.FirstOrDefault();
                wayBillModelResponse = new WayBillModel()
                {
                    BillProperty = new BillModel()
                    {
                        BuyDate = result.FechaCreacion,
                        IdBill = result.Factura.IdFactura.ToString(),
                        ProductId = "555",
                        ClientProperty = new ClientModel()
                        {
                            Address = result.Factura.DireccionCliente,
                            PhoneNumber = result.Factura.TelefonoCliente,
                            DocumentId = result.Factura.IdentificacionCliente,
                            Email = result.Factura.EmailCliente,
                            Name = result.Factura.NombreCliente,
                            UserType = "Cliente"
                        },
                        SellerProperty = new SellerModel()
                        {
                            Address = result.Factura.DireccionVendedor,
                            PhoneNumber = result.Factura.TelefonoVendedor,
                            DocumentId = result.Factura.IdentificacionVendedor,
                            Email = result.Factura.EmailVendedor,
                            Name = result.Factura.NombreVendedor,
                            UserType = "Vendedor"
                        }
                    },
                    MaxDeliveryDate = result.FechaEntregaMaxima,
                    MinDeliveryDate = result.FechaEntregaMinima,
                    StatusProperty = new StatusModel
                    {
                        StatusId = result.Estado.IdEstado.ToString(),
                        Description = result.Estado.Comentario,

                    },
                    OperatorProperty = new OperatorModel { DocumentId = result.Operador.IdOperador.ToString() },
                    WayBillId = result.IdOrden.ToString(),
                    WeightPackage = result.Peso.ToString(),
                    UrlproductImage = result.UrlFoto,
                };
            }

            return wayBillModelResponse;
        }

        public bool CrearOrder(string urlApi, WayBillModel order)
        {
            urlApi += $"Ordenes/CrearOrden";
            var obj = new
            {
                operador = new
                {
                    idOperador = order.OperatorProperty.DocumentId
                },
                fechaEntregaMinima = order.MinDeliveryDate,
                fechaEntregaMaxima = order.MaxDeliveryDate,
                peso = order.WeightPackage,
                tamanio = "10x15x9",//dimensiones,
                urlFoto = order.UrlproductImage,
                factura = new
                {
                    idFactura = order.BillProperty.IdBill
                }
            };
            string objJson = JsonConvert.SerializeObject(obj, Formatting.Indented);
            string response = RequestPost(urlApi, objJson);

            return true;
        }
    }
}

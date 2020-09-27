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



        //WayBillModel wayBillModelResponse = new WayBillModel()
        //{
        //    BillProperty = new BillModel()
        //    {
        //        BuyDate = DateTime.Now,
        //        IdBill = "56434",
        //        ProductId = "555",
        //        ClientProperty = new ClientModel()
        //        {
        //            Address = "Calle Falsa 123",
        //            PhoneNumber = "3016346988",
        //            DocumentId = "456789",
        //            Email = "acalarconfra@gmail.com",
        //            Name = "Andrés Camilo Alarcón Franco",
        //            UserType = "Cliente"
        //        },
        //        SellerProperty = new SellerModel()
        //        {
        //            Address = "Comercializadora 123",
        //            PhoneNumber = "3015555555",
        //            DocumentId = "456789444",
        //            Email = "falso@gmail.com",
        //            Name = "Pepe",
        //            UserType = "Vendedor"
        //        }
        //    }
        //};
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
                    }
                };
            }

            return wayBillModelResponse;
        }

    }
}

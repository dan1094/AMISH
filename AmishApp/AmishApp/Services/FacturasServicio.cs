using AmishApp.Models;
using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmishApp.Services
{
    public class FacturasServicio : Conexion
    {
        public List<BillModel> GetFacturas(string urlApi)
        {
            urlApi += $"Facturas/ListarFacturas";

            string response = RequestGet(urlApi);

            var json = JsonConvert.DeserializeObject<Response<List<FacturaEntity>>>(response);

            List<BillModel> lista = new List<BillModel>();
            if (json.Data != null)
            {
                json.Data.ForEach(est =>
                {
                    BillModel registro = new BillModel
                    {
                        IdBill = est.IdFactura.ToString(),
                        BuyDate = est.FechaCompra.Value,
                        ProductId = "555",
                        ClientProperty = new ClientModel
                        {
                            Address = est.DireccionCliente,
                            DocumentId = est.IdentificacionCliente,
                            PhoneNumber = est.TelefonoCliente,
                            Email = est.EmailCliente,
                            Name = est.NombreCliente,
                            UserType = "Cliente"
                        },
                        SellerProperty = new SellerModel
                        {
                            Address = est.DireccionVendedor,
                            DocumentId = est.IdentificacionVendedor,
                            PhoneNumber = est.TelefonoVendedor,
                            Email = est.EmailVendedor,
                            Name = est.NombreVendedor,
                            UserType = "Vendedor"
                        },
                    };
                    lista.Add(registro);
                });
            }
            return lista;
        }

    }
}

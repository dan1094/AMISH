using Entities;
using Microsoft.AspNetCore.Mvc;
using Rule;
using System;
using System.Collections.Generic;
using System.Net;

namespace APITracking.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        [HttpGet]
        public Response<List<FacturaEntity>> ListarFacturas(int identificacionVendedor)
        {
            Response<List<FacturaEntity>> response = new Response<List<FacturaEntity>>();
            //if (identificacionVendedor == 0)
            //{
            //    response.StatusCode = HttpStatusCode.BadRequest;
            //    response.Message = "identificacionVendedor requerido";
            //    return response;
            //}
            try
            {
                using (FacturasRule rule = new FacturasRule())
                {
                    var r = rule.ListarFacturas(identificacionVendedor);
                    if (r.Count > 0)
                    {
                        response.Data = r;
                        response.Message = $"{r.Count} registros";
                        response.StatusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        response.Data = null;
                        response.Message = "No se encontraron registros";
                        response.StatusCode = HttpStatusCode.NotFound;
                    }
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
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
    public class OrdenesController : ControllerBase
    {
        [HttpPost]
        public Response<List<OrdenEntity>> ListarOrdenes(Filtro filtro)
        {
            Response<List<OrdenEntity>> response = new Response<List<OrdenEntity>>();
            try
            {
                using (OrdenRule rule = new OrdenRule())
                {
                    var r = rule.ConsultaOrdenes(filtro);
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

        [HttpPost]
        public Response<bool> CrearOrden(OrdenEntity orden) {

            Response<bool> response = new Response<bool>();
            try
            {
                using (OrdenRule rule = new OrdenRule())
                {
                    var r = rule.CrearOrden(orden);
                    if (r)
                    {
                        response.Data = r;
                        response.Message = $"Orden creada";
                        response.StatusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        response.Data = r;
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

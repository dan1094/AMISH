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
    public class EstadosController : ControllerBase
    {
        [HttpGet]
        public Response<List<EstadoEntity>> GetEstados()
        {
            Response<List<EstadoEntity>> response = new Response<List<EstadoEntity>>();
            try
            {
                using (EstadosRule rule = new EstadosRule())
                {
                    var r = rule.ConsultarEstados();
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

        [HttpGet]
        public Response<List<EstadoOrdenEntity>> ConsultarEstadosOrden(int idOrden)
        {
            Response<List<EstadoOrdenEntity>> response = new Response<List<EstadoOrdenEntity>>();
            if (idOrden == 0)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "idOrden requerido";
                return response;
            }
            try
            {
                using (EstadosRule rule = new EstadosRule())
                {
                    var r = rule.ConsultarEstadosOrden(idOrden);
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
        public Response<bool> ActualizarEstadoOrden(EstadoOrdenEntity estado)
        {
            Response<bool> response = new Response<bool>();

            if (estado.IdWaybill == 0)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "idWaybill requerido";
                return response;
            }
            else if (estado.IdEstado == 0)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "idEstado requerido";
                return response;
            }

            try
            {
                using (EstadosRule rule = new EstadosRule())
                {
                    var r = rule.ActualizarEstadoOrden(estado);
                    if (r)
                    {
                        response.Data = r;
                        response.Message = $"Registro actualizado";
                        response.StatusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        response.Data = false;
                        response.Message = "No se actualizo el registro";
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

using System;
using System.Collections.Generic;
using System.Data;
using Entities;
using MySqlConnector;
//using MySqlConnector;

namespace Data
{
    public class OrdenData : ConexionMySql
    {
        public MensajeDto CrearOrden(OrdenEntity orden)
        {
            MySqlCommand cmd = GetMySqlCommandInstance("Proc_InsOrdenes");

            cmd.Parameters.Add(new MySqlParameter("idFactura", orden.Factura.IdFactura));
            cmd.Parameters.Add(new MySqlParameter("FechaMin", orden.FechaEntregaMinima));
            cmd.Parameters.Add(new MySqlParameter("FechaMax", orden.FechaEntregaMaxima));
            cmd.Parameters.Add(new MySqlParameter("Peso", orden.Peso));
            cmd.Parameters.Add(new MySqlParameter("Tamano",orden.tamanio ));
            cmd.Parameters.Add(new MySqlParameter("Foto", orden.UrlFoto));
            cmd.Parameters.Add(new MySqlParameter("idProveedor", orden.Operador.IdOperador));

            MensajeDto retorno = null;
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    retorno = new MensajeDto
                    {
                        MensajeSms = reader.IsDBNull(reader.GetOrdinal("MensajeSms")) ? string.Empty : (string)reader["MensajeSms"],
                        MensajeEmail = reader.IsDBNull(reader.GetOrdinal("MensajeEmail")) ? string.Empty : (string)reader["MensajeEmail"],
                        Telefono = reader.IsDBNull(reader.GetOrdinal("TelefonoCliente")) ? string.Empty : (string)reader["TelefonoCliente"],
                        Correo = reader.IsDBNull(reader.GetOrdinal("EmailCliente")) ? string.Empty : (string)reader["EmailCliente"],
                    };
                }
            }

            DisposeCommand(cmd);
            return retorno;

        }
        public List<OrdenEntity> ConsultaOrdenes(Filtro filtro)
        {
            MySqlCommand cmd = GetMySqlCommandInstance("Proc_GetOrdenes");
            cmd.Parameters.Add(new MySqlParameter("inu_IdWayBill", filtro.IdOrden));

            List<OrdenEntity> retorno = new List<OrdenEntity>();
            OrdenEntity orden = null;

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    orden = new OrdenEntity
                    {
                        IdOrden = (int)reader["IdWayBill"],
                        FechaEntregaMinima = reader.IsDBNull(reader.GetOrdinal("FechaEntregaMinima")) ? new DateTime() : (DateTime)reader["FechaEntregaMinima"],
                        FechaEntregaMaxima = reader.IsDBNull(reader.GetOrdinal("FechaEntregaMaxima")) ? new DateTime() : (DateTime)reader["FechaEntregaMaxima"],
                        FechaCreacion = reader.IsDBNull(reader.GetOrdinal("FechaCreacion")) ? new DateTime() : (DateTime)reader["FechaCreacion"],
                        Peso = reader.IsDBNull(reader.GetOrdinal("PesoProducto")) ? 0 : (int)reader["PesoProducto"],
                        tamanio = reader.IsDBNull(reader.GetOrdinal("TamañoProducto")) ? string.Empty : (string)reader["TamañoProducto"],
                        UrlFoto = reader.IsDBNull(reader.GetOrdinal("FotoProducto")) ? string.Empty : (string)reader["FotoProducto"],
                        Operador = new OperadorLogisticoEntity
                        {
                            IdOperador = reader.IsDBNull(reader.GetOrdinal("idProveedor")) ? 0 : (int)reader["idProveedor"],
                            Nombre = reader.IsDBNull(reader.GetOrdinal("NombreOperador")) ? string.Empty : (string)reader["NombreOperador"],
                        },
                        Factura = new FacturaEntity
                        {
                            IdFactura = (int)reader["idFactura"],
                            IdentificacionCliente = reader.IsDBNull(reader.GetOrdinal("NumDocCliente")) ? string.Empty : (string)reader["NumDocCliente"],
                            NombreCliente = reader.IsDBNull(reader.GetOrdinal("NomCliente")) ? string.Empty : (string)reader["NomCliente"],
                            TelefonoCliente = reader.IsDBNull(reader.GetOrdinal("TelCliente")) ? string.Empty : (string)reader["TelCliente"],
                            DireccionCliente = reader.IsDBNull(reader.GetOrdinal("DirCliente")) ? string.Empty : (string)reader["DirCliente"],
                            EmailCliente = reader.IsDBNull(reader.GetOrdinal("EmailCliente")) ? string.Empty : (string)reader["EmailCliente"],
                            FechaCompra = reader.IsDBNull(reader.GetOrdinal("FechaCompra")) ? new DateTime() : (DateTime)reader["FechaCompra"],
                            IdentificacionVendedor = reader.IsDBNull(reader.GetOrdinal("NumDocVendedor")) ? string.Empty : (string)reader["NumDocVendedor"],
                            NombreVendedor = reader.IsDBNull(reader.GetOrdinal("NomVendedor")) ? string.Empty : (string)reader["NomVendedor"],
                            TelefonoVendedor = reader.IsDBNull(reader.GetOrdinal("TelVendedor")) ? string.Empty : (string)reader["TelVendedor"],
                            DireccionVendedor = reader.IsDBNull(reader.GetOrdinal("DirVendedor")) ? string.Empty : (string)reader["DirVendedor"],

                        },
                        FechaUltimaActualizacion = reader.IsDBNull(reader.GetOrdinal("FechaActualizacion")) ? new DateTime() : (DateTime)reader["FechaActualizacion"],
                        Estado = new EstadoOrdenEntity
                        {
                            IdEstado = reader.IsDBNull(reader.GetOrdinal("idEstado")) ? 0 : (int)reader["idEstado"]
                        }
                    };
                    retorno.Add(orden);
                }
            }

            DisposeCommand(cmd);
            return retorno;
        }

    }
}

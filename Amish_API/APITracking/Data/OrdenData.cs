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
        public OrdenEntity CrearOrden(OrdenEntity orden)
        {
            return null;
        }
        public List<OrdenEntity> ConsultaOrdenes(Filtro filtro)
        {
            MySqlCommand cmd = GetMySqlCommandInstance("SELECT * FROM facturas");

            List<FacturaEntity> retorno = new List<FacturaEntity>();
            FacturaEntity orden = null;

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    orden = new FacturaEntity
                    {
                        IdFactura = (int)reader["idFactura"],
                        IdentificacionCliente = reader.IsDBNull(reader.GetOrdinal("NumDocCliente")) ? string.Empty : (string)reader["NumDocCliente"],
                        FechaCompra = reader.IsDBNull(reader.GetOrdinal("FechaCompra")) ? (DateTime?)null : (DateTime)reader["FechaCompra"],
                    };
                    retorno.Add(orden);
                }
            }

            DisposeCommand(cmd);
            return null;
        }
       
        //public bool ActualizarDetalleOrden(OrdenEntity orden)
        //{
        //    return false;
        //}

    }
}

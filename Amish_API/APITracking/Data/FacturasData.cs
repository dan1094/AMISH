using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using Entities;
using MySqlConnector;
//using MySqlConnector;

namespace Data
{
    public class FacturasData : ConexionMySql
    {
        public List<FacturaEntity> ListarFacturas(int idVendedor)
        {
            MySqlCommand cmd = GetMySqlCommandInstance("Proc_GetFacturasDisponibles");

            //cmd.Parameters.Add(new MySqlParameter("inu_idwaybill", ));
            List<FacturaEntity> retorno = new List<FacturaEntity>();
            FacturaEntity registro = null;

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    registro = new FacturaEntity
                    {
                        IdFactura = (int)reader["idFactura"],
                        IdentificacionCliente = (string)reader["NumDocCliente"],
                        NombreCliente = (string)reader["NomCliente"],
                        FechaCompra = (DateTime)reader["FechaCompra"]
                    };
                    retorno.Add(registro);
                }
            }

            DisposeCommand(cmd);
            return retorno;
        }             

    }
}

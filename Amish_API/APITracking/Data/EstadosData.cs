using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using Entities;
using MySqlConnector;
//using MySqlConnector;

namespace Data
{
    public class EstadosData : ConexionMySql
    {               
        public List<EstadoEntity> ConsultaEstados()
        {
            MySqlCommand cmd = GetMySqlCommandInstance("SELECT idEstado, Descripcion FROM estados");
            cmd.CommandType = CommandType.Text;

            List<EstadoEntity> retorno = new List<EstadoEntity>();
            EstadoEntity registro = null;

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    registro = new EstadoEntity
                    {
                        IdEstado = (int)reader["idEstado"],
                        Descripcion = (string)reader["Descripcion"],
                        Mensaje = (string)reader["Mensaje"],
                    };
                    retorno.Add(registro);
                }
            }

            DisposeCommand(cmd);
            return retorno;
        }

        public List<EstadoOrdenEntity> ConsultaEstadosOrden(int idOrden)
        {
            MySqlCommand cmd = GetMySqlCommandInstance("SELECT * FROM ordenesestados");
            cmd.CommandType = CommandType.Text;

            List<EstadoOrdenEntity> retorno = new List<EstadoOrdenEntity>();
            EstadoOrdenEntity registro = null;

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    registro = new EstadoOrdenEntity
                    {
                        IdEstado = (int)reader["idEstado"],
                       // de = reader.IsDBNull(reader.GetOrdinal("NumDocCliente")) ? string.Empty : (string)reader["NumDocCliente"],
                    };
                    retorno.Add(registro);
                }
            }

            DisposeCommand(cmd);
            return retorno;
        }

        public bool ActualizarEstadoOrden(EstadoOrdenEntity estado)
        {
            MySqlCommand cmd = GetMySqlCommandInstance("Proc_ActualizarEdo");

            cmd.Parameters.Add(new MySqlParameter("inu_idwaybill", estado.IdWaybill));
            cmd.Parameters.Add(new MySqlParameter("inu_idedo", estado.IdEstado));
            cmd.Parameters.Add(new MySqlParameter("ich_comentario", estado.Comentario));

            cmd.ExecuteNonQuery();
            DisposeCommand(cmd);
            return true;
        }

    }
}

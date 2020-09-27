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
            MySqlCommand cmd = GetMySqlCommandInstance("Proc_GetEstados");

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
                    };
                    retorno.Add(registro);
                }
            }

            DisposeCommand(cmd);
            return retorno;
        }

        public List<EstadoOrdenEntity> ConsultaEstadosOrden(int idOrden)
        {
            MySqlCommand cmd = GetMySqlCommandInstance("Proc_GetEstadosOrden");

            cmd.Parameters.Add(new MySqlParameter("inu_idwaybill", idOrden));
            List<EstadoOrdenEntity> retorno = new List<EstadoOrdenEntity>();
            EstadoOrdenEntity registro = null;

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    registro = new EstadoOrdenEntity
                    {
                        IdEstado = (int)reader["idEstado"],
                        IdWaybill = (int)reader["IdWayBill"],
                        Comentario = reader.IsDBNull(reader.GetOrdinal("Comentario")) ? string.Empty : (string)reader["Comentario"],
                        FechaActualizacion = reader.IsDBNull(reader.GetOrdinal("FechaActualizacion")) ? new DateTime() : (DateTime)reader["FechaActualizacion"],

                    };
                    retorno.Add(registro);
                }
            }

            DisposeCommand(cmd);
            return retorno;
        }

        public MensajeDto ActualizarEstadoOrden(EstadoOrdenEntity estado)
        {
            MySqlCommand cmd = GetMySqlCommandInstance("Proc_ActualizarEdo");

            cmd.Parameters.Add(new MySqlParameter("inu_idwaybill", estado.IdWaybill));
            cmd.Parameters.Add(new MySqlParameter("inu_idedo", estado.IdEstado));
            cmd.Parameters.Add(new MySqlParameter("ich_comentario", estado.Comentario));

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

    }
}

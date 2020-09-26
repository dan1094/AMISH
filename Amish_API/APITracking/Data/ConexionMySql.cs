//using MySqlConnector;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Data;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Data
{
    public class ConexionMySql : IDisposable
    {

        //public MySqlConnection Connection { get; }

        //public ConexionMySql(string connectionString)
        //{
        //    Connection = new MySqlConnection(connectionString);
        //}

        //public void Dispose() => Connection.Dispose();


        private MySqlConnection _mySqlConnnection = null;

        public void Dispose() { }

        virtual protected string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;                
        }

        protected MySqlConnection Conn
        {
            get
            {
                return _mySqlConnnection;
            }
        }

        protected MySqlCommand GetMySqlCommandInstance(string strSPName)
        {
            open_Conn();
            MySqlCommand cmd = new MySqlCommand(strSPName, Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 1800;
            return cmd;
        }

        protected void open_Conn()
        {
            if (_mySqlConnnection == null)
            {
                _mySqlConnnection = new MySqlConnection(GetConnectionString());
                _mySqlConnnection.Open();
            }
            int i = 0;
            while (_mySqlConnnection.State != System.Data.ConnectionState.Open)
            {
                if (i < 5)
                {
                    try
                    {
                        _mySqlConnnection.Open();
                    }
                    catch
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                }
            }
        }

        protected void Close_Conn()
        {
            try
            {
                _mySqlConnnection.Close();
                _mySqlConnnection.Dispose();
                _mySqlConnnection = null;
            }
            catch
            { }
        }

        protected void DisposeCommand(MySqlCommand mySqlCommand)
        {
            mySqlCommand.Dispose();
            Close_Conn();
        }
    }
}

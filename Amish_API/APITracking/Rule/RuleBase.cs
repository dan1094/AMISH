using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Rule
{
    public class RuleBase : IDisposable
    {
        public void Dispose() { }

        //public static void EscribirArchivoError(Exception ex)
        //{
        //    EscribirLog("----------------------------------------------------------------------------------");
        //    EscribirLog(string.Format("Message: {0} ", ex.Message));
        //    EscribirLog(string.Format("Exception: {0}",
        //         ex.InnerException != null ? ex.InnerException.Message : string.Empty));
        //    EscribirLog(string.Format("Trace: {0} ", ex.StackTrace));
        //}

        //public static void EscribirLog(string msg)
        //{
        //    try
        //    {
        //        string nombre = string.Format("LogApiEmbargos_{0:dd_MM_yyyy}.txt", DateTime.Now);
        //        string rutaArchivo = System.Configuration.ConfigurationManager.AppSettings["LogError"];
        //        string comp = Path.Combine(rutaArchivo, nombre);
        //        //Open the File
        //        StreamWriter sw = new StreamWriter(comp, true, Encoding.UTF8);
        //        sw.WriteLine(string.Format("{0} - {1}", DateTime.Now, msg));
        //        sw.Close();
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        //Request in C#
        public static string RequestPost(string url, string jsonContent)
        {
            long length = 0;
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                //request.KeepAlive = false;

                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                Byte[] byteArray = encoding.GetBytes(jsonContent);

                request.ContentLength = byteArray.Length;
                request.ContentType = @"application/json";
                request.Accept = @"application/json";

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                Stream dataStream = request.GetRequestStream();

                dataStream.Write(byteArray, 0, byteArray.Length);


                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    length = response.ContentLength;

                    //Response.Write(((HttpWebResponse)response).StatusDescription);
                    // Get the stream containing content returned by the server.
                    dataStream = response.GetResponseStream();
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();
                    // Display the content.
                    // Response.Write(responseFromServer);
                    return responseFromServer;
                }
            }
            catch (WebException ex)
            {
                return ex.Message + " " + ex.StackTrace;// Log exception and throw as for GET example above
            }
            return null;
        }
        public static string RequestGet(string url)
        {
            //long length = 0;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                // request.Method = "GET";

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    //length = response.ContentLength;
                    //dataStream = response.GetResponseStream();
                    //treamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    return responseFromServer;
                }
            }
            catch (WebException ex)
            {
                return ex.Message + " " + ex.StackTrace;// Log exception and throw as for GET example above
            }
            return null;
        }
        public void EnviarEmailCambioEstado(string correo, string mensaje)
        {
            string strUrlApi = "http://co2cvw163a:47001/api/Email/registrarCorreo";
            var obj = new
            {
                encabezado = new
                {
                    idOperacion = 9,
                    fechaEnvio = "2020-09-26"
                },
                clienteIdentificacion = new
                {
                    tipoIdentificacion = 1,
                    numeroIdentificacion = "1019046353"
                },
                para = correo,
                cc = "",
                cco = "",
                asunto = "Test de envio de correo electronico",
                mensaje = new
                {
                    plantilla = new
                    {
                        id = 0,
                        datos = new { }
                    },
                    mensaje = $"<html><body>{mensaje}</body></html>"
                },
                adjuntos = new List<string>().ToArray()
            };


            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            string respEmail = RequestPost(strUrlApi, json);

        }
        public void EnviarSmsCambioEstado(string telefono, string mensaje)
        {
            string url = "https://api.masivapp.com/SmsHandlers/sendhandler.ashx?action=sendmessage&username=Api_LH6SK&password=CT6S47QWKW&recipient="
                + telefono + "&messagedata=" + mensaje;

            RequestGet(url);
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AmishApp.Services
{
    public class Conexion
    {  
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
    }
}

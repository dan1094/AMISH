using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;

namespace Entities
{
    /// <summary>
    ///  model for a process result, all application methods return this class
    /// </summary>
    [DefaultMember("Item")]
    public sealed class Response<T>
    {
        /// <summary>
        /// Status Code of a logic process.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        /// <summary>
        /// Message of a logic process.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Data of a logic process.
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public Response(HttpStatusCode statusCode, string message, T data)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            this.Data = data;
        }

        /// <summary>
        /// Constructor vacio
        /// </summary>
        public Response() { }
    }

}

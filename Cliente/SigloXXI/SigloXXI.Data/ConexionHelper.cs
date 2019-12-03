using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public static class ConexionHelper
    {
        private static RestClient _cliente;
        public static string Url { get; set; }
        public static RestClient Cliente
        {
            get
            {
                _cliente = new RestClient(Url);
                _cliente.Authenticator = new HttpBasicAuthenticator(".net", "123"); 
                return _cliente;
            }
            set { _cliente = value; }
        }
    }
}

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
        private static HttpClient _cliente;
        public static string Url { get; set; }
        public static HttpClient Cliente
        {
            get
            {
                _cliente = new HttpClient();
                return _cliente;
            }
            set { _cliente = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Clientes
    {
        public int Rut { get; set; }
        public char Dv { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Url { get; set; }

        public Clientes()
        {
            Url = "http://weasdf.ddns.net:8082";
        }

        public bool CrearCliente(Clientes cliente)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
            var queryParams = new Dictionary<string, string>
            {
                {"rut", cliente.Rut.ToString() },
                {"dv",  cliente.Dv.ToString()},
                {"nombre",  cliente.Nombre},
                {"apellido",  cliente.Apellido},
                {"rol",  cliente.Correo},
                {"correo",  cliente.Telefono},
            };
            return JsonHelper<Users>.Post(queryParams, "/clientes/crear-clientes");
        }

        public bool ActualizarClientes(Clientes cliente)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
            var queryParams = new Dictionary<string, string>
            {
              {"rut", cliente.Rut.ToString() },
                {"dv",  cliente.Dv.ToString()},
                {"nombre",  cliente.Nombre},
                {"apellido",  cliente.Apellido},
                {"rol",  cliente.Correo},
                {"correo",  cliente.Telefono},
            };
            return JsonHelper<Users>.Put(queryParams, "/clientes/actualizar-clientes/" + cliente.Rut);
        }

        public List<Clientes> ObtenerClientes()
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Clientes>.Url = Url;
            var result = JsonHelper<Clientes>.GetList("/clientes/obtener-clientes");
            return result;
        }

        public Clientes ObtenerCliente(int rut)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Clientes>.Url = Url;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Clientes>.Get(queryParams, "/clientes/buscar-clientes/" + rut.ToString());
            return res;
        }

        public bool EliminarCliente(int rut)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Clientes>.Url = Url;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Clientes>.Delete(queryParams, "/clientes/eliminar-clientes/" + rut);

        }

    }  

}

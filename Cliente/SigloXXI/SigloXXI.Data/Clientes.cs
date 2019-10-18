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
        public string Token { get; set; }
        public bool CrearCliente(Clientes cliente)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"rut", cliente.Rut.ToString() },
                {"dv",  cliente.Dv.ToString()},
                {"nombre",  cliente.Nombre},
                {"apellido",  cliente.Apellido},
                {"correo",  cliente.Correo},
                {"telefono",  cliente.Telefono},
            };
            JsonHelper<Clientes>.Token = this.Token;
            return JsonHelper<Clientes>.Post(queryParams, "/clientes/crear-cliente");
        }

        public bool ActualizarClientes(Clientes cliente)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"rut", cliente.Rut.ToString() },
                {"dv",  cliente.Dv.ToString()},
                {"nombre",  cliente.Nombre},
                {"apellido",  cliente.Apellido},
                {"correo",  cliente.Correo},
                {"telefono",  cliente.Telefono},
            };
            JsonHelper<Clientes>.Token = this.Token;
            return JsonHelper<Clientes>.Put(queryParams, "/clientes/actualizar-cliente/" + cliente.Rut);
        }

        public List<Clientes> ObtenerClientes()
        {
            JsonHelper<Clientes>.Token = this.Token;
            var result = JsonHelper<Clientes>.GetList("/clientes/obtener-clientes");
            return result;
        }

        public Clientes ObtenerCliente(int rut)
        {
            JsonHelper<Clientes>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Clientes>.Get(queryParams, "/clientes/buscar-cliente/" + rut.ToString());
            return res;
        }

        public bool EliminarCliente(int rut)
        {
            JsonHelper<Clientes>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Clientes>.Delete(queryParams, "/clientes/eliminar-clientes/" + rut);
        }
    }
}
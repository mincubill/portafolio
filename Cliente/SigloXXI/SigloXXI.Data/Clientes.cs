using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Clientes
    {
        public int rut { get; set; }
        public char dv { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string Token { get; set; }
        public Clientes CrearCliente(Clientes cliente)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"rut", cliente.rut.ToString() },
                {"dv",  cliente.dv.ToString()},
                {"nombre",  cliente.nombre},
                {"apellido",  cliente.apellido},
                {"correo",  cliente.correo},
                {"telefono",  cliente.telefono},
            };
            JsonHelper<Clientes>.Token = this.Token;
            return JsonHelper<Clientes>.Post(queryParams, "/clientes/crear-cliente");
        }

        public Clientes ActualizarClientes(Clientes cliente)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"rut", cliente.rut.ToString() },
                {"dv",  cliente.dv.ToString()},
                {"nombre",  cliente.nombre},
                {"apellido",  cliente.apellido},
                {"correo",  cliente.correo},
                {"telefono",  cliente.telefono},
            };
            JsonHelper<Clientes>.Token = this.Token;
            return JsonHelper<Clientes>.Put(queryParams, "/clientes/actualizar-cliente/" + cliente.rut);
        }

        public List<Clientes> ObtenerClientes()
        {
            JsonHelper<Clientes>.Token = this.Token;
            var result = JsonHelper<Clientes>.GetListNoToke("/clientes/obtener-clientes");
            return result;
        }

        public Clientes ObtenerCliente(int rut)
        {
            JsonHelper<Clientes>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Clientes>.GetNoToken(queryParams, "/clientes/buscar-cliente/" + rut.ToString());
            return res;
        }

        public bool EliminarCliente(int rut)
        {
            JsonHelper<Clientes>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Clientes>.Delete(queryParams, "/clientes/eliminar-cliente/" + rut);
        }
    }
}
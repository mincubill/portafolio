using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Proveedores
    {
        public string rut { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public string Token { get; set; }

        public bool CrearProveedor(Proveedores proveedor)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"rut", proveedor.rut },
                {"nombre",  proveedor.nombre},
                {"telefono",  proveedor.telefono},
                {"direccion",  proveedor.direccion},
                {"correo",  proveedor.correo},
            };
            JsonHelper<Proveedores>.Token = this.Token;
            return JsonHelper<Proveedores>.Post(queryParams, "/proveedores/crear-proveedor");
        }

        public bool ActualizarProveedor(Proveedores proveedor)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"rut", proveedor.rut },
                {"nombre",  proveedor.nombre},
                {"telefono",  proveedor.telefono},
                {"direccion",  proveedor.direccion},
                {"correo",  proveedor.correo},
            };
            JsonHelper<Proveedores>.Token = this.Token;
            return JsonHelper<Proveedores>.Put(queryParams, "/proveedores/actualizar-proveedor/" + proveedor.rut);
        }

        public List<Proveedores> ObtenerProveedores()
        {
            JsonHelper<Proveedores>.Token = this.Token;
            var result = JsonHelper<Proveedores>.GetList("/proveedores/obtener-proveedores");
            return result;
        }

        public Proveedores ObtenerProveedor(string rut)
        {
            JsonHelper<Proveedores>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Proveedores>.Get(queryParams, "/proveedores/buscar-proveedor/" + rut);
            return res;
        }

        public bool EliminarProveedor(string rut)
        {
            JsonHelper<Proveedores>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Proveedores>.Delete(queryParams, "/proveedores/eliminar-proveedor/" + rut);
        }
    }
}
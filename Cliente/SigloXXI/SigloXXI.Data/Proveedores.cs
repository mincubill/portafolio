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
                {"Rut", proveedor.rut },
                {"Nombre",  proveedor.nombre},
                {"Telefono",  proveedor.telefono},
                {"Direccion",  proveedor.direccion},
                {"Correo",  proveedor.correo},
            };
            JsonHelper<Proveedores>.Token = this.Token;
            return JsonHelper<Proveedores>.Post(queryParams, "/proveedores/crear-proveedor");
        }

        public bool ActualizarProveedor(Proveedores proveedor)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"Rut", proveedor.rut },
                {"Nombre",  proveedor.nombre},
                {"Telefono",  proveedor.telefono},
                {"Direccion",  proveedor.direccion},
                {"Correo",  proveedor.correo},
            };
            JsonHelper<Proveedores>.Token = this.Token;
            return JsonHelper<Proveedores>.Put(queryParams, "/proveedores/actualizar-proveedor/" + proveedor.rut);
        }

        public List<Proveedores> ObtenerProveedores()
        {
            var result = JsonHelper<Proveedores>.GetList("/proveedores/obtener-proveedor");
            return result;
        }

        public Proveedores ObtenerProveedor(int rut)
        {
            JsonHelper<Proveedores>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Proveedores>.Get(queryParams, "/proveedores/buscar-proveedor/" + rut.ToString());
            return res;
        }

        public bool EliminarProveedor(int rut)
        {
            JsonHelper<Proveedores>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Proveedores>.Delete(queryParams, "/proveedores/eliminar-proveedor/" + rut.ToString());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Proveedores
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Token { get; set; }

        public bool CrearProveedor(Proveedores proveedor)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"Rut", proveedor.Rut },
                {"Nombre",  proveedor.Nombre},
                {"Telefono",  proveedor.Telefono},
                {"Direccion",  proveedor.Direccion},
                {"Correo",  proveedor.Correo},
            };
            JsonHelper<Proveedores>.Token = this.Token;
            return JsonHelper<Proveedores>.Post(queryParams, "/proveedores/crear-proveedor");
        }

        public bool ActualizarProveedor(Proveedores proveedor)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"Rut", proveedor.Rut },
                {"Nombre",  proveedor.Nombre},
                {"Telefono",  proveedor.Telefono},
                {"Direccion",  proveedor.Direccion},
                {"Correo",  proveedor.Correo},
            };
            JsonHelper<Proveedores>.Token = this.Token;
            return JsonHelper<Proveedores>.Put(queryParams, "/proveedores/actualizar-proveedor/" + proveedor.Rut);
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
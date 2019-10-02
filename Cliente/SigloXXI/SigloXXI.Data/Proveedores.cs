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
        public string Url { get; set; }
        public Proveedores()
        {
            Url = "http://weasdf.ddns.net:8082";
        }

        public bool CrearProveedor(Proveedores proveedor)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
            var queryParams = new Dictionary<string, string>
            {
                {"Rut", proveedor.Rut },
                {"Nombre",  proveedor.Nombre},
                {"Telefono",  proveedor.Telefono},
                {"Direccion",  proveedor.Direccion},
                {"Correo",  proveedor.Correo},
            };
            return JsonHelper<Proveedores>.Post(queryParams, "/proveedores/crear-proveedor");
        }

        public bool ActualizarProveedor(Proveedores proveedor)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
            var queryParams = new Dictionary<string, string>
            {
                {"Rut", proveedor.Rut },
                {"Nombre",  proveedor.Nombre},
                {"Telefono",  proveedor.Telefono},
                {"Direccion",  proveedor.Direccion},
                {"Correo",  proveedor.Correo},
            };
            return JsonHelper<Users>.Put(queryParams, "/proveedores/actualizar-proveedor/" + proveedor.Rut);
        }

        public List<Proveedores> ObtenerProveedores()
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Proveedores>.Url = Url;
            var result = JsonHelper<Proveedores>.GetList("/proveedores/obtener-proveedor");
            return result;
        }

        public Proveedores ObtenerProveedor(int rut)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Proveedores>.Url = Url;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Proveedores>.Get(queryParams, "/proveedores/buscar-proveedor/" + rut.ToString());
            return res;
        }

        public bool EliminarProveedor(int rut)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Proveedores>.Url = Url;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Proveedores>.Delete(queryParams, "/proveedores/eliminar-proveedor/" + rut.ToString());
        }
    }
}

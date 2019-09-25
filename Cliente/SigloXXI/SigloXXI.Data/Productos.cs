using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public string Categoria { get; set; }
        public string Url { get; set; }
        public Productos()
        {
            Url = "http://192.168.1.13:8082";
        }

        public bool CrearProducto(Productos producto)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
            var queryParams = new Dictionary<string, string>
            {
                {"id", producto.Id.ToString() },
                {"nombre",  producto.Nombre},
                {"descripcion",  producto.Descripcion},
                {"cantidad",  producto.Cantidad.ToString()},
                {"precio",  producto.Precio.ToString()},
                {"categoria",  Categoria},
               
            };
            return JsonHelper<Productos>.Post(queryParams, "/productos/crear-producto");
        }

        public bool ActualizarProducto(Productos producto)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
            var queryParams = new Dictionary<string, string>
            {
                {"id", producto.Id.ToString() },
                {"nombre",  producto.Nombre},
                {"descripcion",  producto.Descripcion},
                {"cantidad",  producto.Cantidad.ToString()},
                {"precio",  producto.Precio.ToString()},
                {"categoria",  Categoria},
            };
            return JsonHelper<Users>.Put(queryParams, "/productos/actualizar-producto/" + producto.Id);
        }

        public List<Productos> ObtenerProductos()
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Productos>.Url = Url;
            var result = JsonHelper<Productos>.GetList("/productos/obtener-productos");
            return result;
        }

        public Productos ObtenerProducto(int id)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Productos>.Url = Url;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Productos>.Get(queryParams, "/productos/buscar-producto/" + id.ToString());
            return res;
        }

        public bool EliminarProducto(int id)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Productos>.Url = Url;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Productos>.Delete(queryParams, "/productos/eliminar-producto/" + id.ToString());
        }
    }
}

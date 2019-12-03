using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Productos
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public int precio { get; set; }
        public string categoria { get; set; }
        public string Token { get; set; }

        public Productos CrearProducto(Productos producto)
        {
            var queryParams = new Dictionary<string, string>
            {
                //{"id", producto.Id.ToString() },
                {"nombre",  producto.nombre},
                {"descripcion",  producto.descripcion},
                {"cantidad",  producto.cantidad.ToString()},
                {"precio",  producto.precio.ToString()},
                {"categoria",  categoria},
               
            };
            JsonHelper<Productos>.Token = this.Token;
            return JsonHelper<Productos>.Post(queryParams, "/productos/crear-producto");
        }

        public Productos ActualizarProducto(Productos producto)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"id", producto.id.ToString() },
                {"nombre",  producto.nombre},
                {"descripcion",  producto.descripcion},
                {"cantidad",  producto.cantidad.ToString()},
                {"precio",  producto.precio.ToString()},
                {"categoria",  categoria},
            };
            JsonHelper<Productos>.Token = this.Token;
            return JsonHelper<Productos>.Put(queryParams, "/productos/actualizar-producto/" + producto.id);
        }

        public List<Productos> ObtenerProductos()
        {
            JsonHelper<Productos>.Token = Token;
            var result = JsonHelper<Productos>.GetList("/productos/obtener-productos");
            return result;
        }

        public Productos ObtenerProducto(int id)
        {
            var queryParams = new Dictionary<string, string>();
            JsonHelper<Productos>.Token = Token;
            var res = JsonHelper<Productos>.Get(queryParams, "/productos/buscar-producto/" + id.ToString());
            return res;
        }

        public bool EliminarProducto(int id)
        {
            var queryParams = new Dictionary<string, string>();
            JsonHelper<Productos>.Token = Token;
            return JsonHelper<Productos>.Delete(queryParams, "/productos/eliminar-producto/" + id.ToString());
        }
    }
}

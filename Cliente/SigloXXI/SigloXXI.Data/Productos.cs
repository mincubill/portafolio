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
        public string Token { get; set; }

        public bool CrearProducto(Productos producto)
        {
            var queryParams = new Dictionary<string, string>
            {
                //{"id", producto.Id.ToString() },
                {"nombre",  producto.Nombre},
                {"descripcion",  producto.Descripcion},
                {"cantidad",  producto.Cantidad.ToString()},
                {"precio",  producto.Precio.ToString()},
                {"categoria",  Categoria},
               
            };
            JsonHelper<Productos>.Token = this.Token;
            return JsonHelper<Productos>.Post(queryParams, "/productos/crear-producto");
        }

        public bool ActualizarProducto(Productos producto)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"id", producto.Id.ToString() },
                {"nombre",  producto.Nombre},
                {"descripcion",  producto.Descripcion},
                {"cantidad",  producto.Cantidad.ToString()},
                {"precio",  producto.Precio.ToString()},
                {"categoria",  Categoria},
            };
            JsonHelper<Productos>.Token = this.Token;
            return JsonHelper<Users>.Put(queryParams, "/productos/actualizar-producto/" + producto.Id);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Ingredientes
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int Platillo_Id { get; set; }
        public int Producto_Id { get; set; }
        public string Url { get; set; }
        public Ingredientes()
        {
            Url = "http://weasdf.ddns.net:8082";
        }

        public bool CrearIngrediente(Ingredientes ingrediente)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
            var queryParams = new Dictionary<string, string>
            {
                {"Id", ingrediente.Id.ToString() },
                {"Cantidad",  ingrediente.Cantidad.ToString()},
                {"Id platillo",  ingrediente.Platillo_Id.ToString()},
                {"Id producto",  ingrediente.Producto_Id.ToString()},

            };
            return JsonHelper<Ingredientes>.Post(queryParams, "/ingredientes/crear-ingrediente");
        }

        public bool ActualizarIngrediente(Ingredientes ingrediente)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
            var queryParams = new Dictionary<string, string>
            {
                {"Id", ingrediente.Id.ToString() },
                {"Cantidad",  ingrediente.Cantidad.ToString()},
                {"Id platillo",  ingrediente.Platillo_Id.ToString()},
                {"Id producto",  ingrediente.Producto_Id.ToString()},
            };
            return JsonHelper<Users>.Put(queryParams, "/ingredientes/actualizar-ingrediente/" + ingrediente.Id);
        }

        public List<Ingredientes> ObtenerIngredientes()
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Ingredientes>.Url = Url;
            var result = JsonHelper<Ingredientes>.GetList("/ingredientes/obtener-ingrediente");
            return result;
        }

        public Ingredientes ObtenerIngrediente(int id)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Ingredientes>.Url = Url;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Ingredientes>.Get(queryParams, "/ingredientes/buscar-ingrediente/" + id.ToString());
            return res;
        }

        public bool EliminarIngrediente(int id)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Ingredientes>.Url = Url;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Ingredientes>.Delete(queryParams, "/ingredientes/eliminar-ingrediente/" + id.ToString());
        }
    }
}

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
        public string Token { get; set; }

        public bool CrearIngrediente(Ingredientes ingrediente)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"Id", ingrediente.Id.ToString() },
                {"Cantidad",  ingrediente.Cantidad.ToString()},
                {"Id platillo",  ingrediente.Platillo_Id.ToString()},
                {"Id producto",  ingrediente.Producto_Id.ToString()},

            };
            JsonHelper<Ingredientes>.Token = this.Token;
            return JsonHelper<Ingredientes>.Post(queryParams, "/ingredientes/crear-ingrediente");
        }

        public bool ActualizarIngrediente(Ingredientes ingrediente)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"Id", ingrediente.Id.ToString() },
                {"Cantidad",  ingrediente.Cantidad.ToString()},
                {"Id platillo",  ingrediente.Platillo_Id.ToString()},
                {"Id producto",  ingrediente.Producto_Id.ToString()},
            };
            JsonHelper<Ingredientes>.Token = this.Token;
            return JsonHelper<Ingredientes>.Put(queryParams, "/ingredientes/actualizar-ingrediente/" + ingrediente.Id);
        }

        public List<Ingredientes> ObtenerIngredientes()
        {
            JsonHelper<Ingredientes>.Token = this.Token;
            var result = JsonHelper<Ingredientes>.GetList("/ingredientes/obtener-ingrediente");
            return result;
        }

        public Ingredientes ObtenerIngrediente(int id)
        {
            JsonHelper<Ingredientes>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Ingredientes>.Get(queryParams, "/ingredientes/buscar-ingrediente/" + id.ToString());
            return res;
        }

        public bool EliminarIngrediente(int id)
        {
            JsonHelper<Ingredientes>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Ingredientes>.Delete(queryParams, "/ingredientes/eliminar-ingrediente/" + id.ToString());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Ingredientes
    {
        public int id { get; set; }
        public int cantidad { get; set; }
        public int platilloId { get; set; }
        public Productos productoId { get; set; }
        public string Token { get; set; }

        public bool CrearIngrediente(Ingredientes ingrediente)
        {
            JsonHelper<Ingredientes>.Token = this.Token;
            return JsonHelper<Ingredientes>.Post(ingrediente, "/ingredientes/crear-ingrediente");
        }

        public bool ActualizarIngrediente(Ingredientes ingrediente)
        {
            JsonHelper<Ingredientes>.Token = this.Token;
            return JsonHelper<Ingredientes>.Put(ingrediente, "/ingredientes/actualizar-ingrediente/" + ingrediente.id);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Platillo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Tiempo { get; set; }
        public string Token { get; set; }

        public bool CrearPlatillo(Platillo platillo)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"id", platillo.Id.ToString() },
                {"nombre",  platillo.Nombre},
                {"tiempo",  platillo.Tiempo.ToString()},

            };
            JsonHelper<Platillo>.Token = this.Token;
            return JsonHelper<Platillo>.Post(queryParams, "/platillos/crear-platillo");
        }

        public bool ActualizarPlatillo(Platillo platillo)
        {
            
            var queryParams = new Dictionary<string, string>
            {
                {"id", platillo.Id.ToString() },
                {"nombre",  platillo.Nombre},
                {"tiempo",  platillo.Tiempo.ToString()},
            };
            JsonHelper<Platillo>.Token = this.Token;
            return JsonHelper<Platillo>.Put(queryParams, "/productos/actualizar-producto/" + platillo.Id);
        }

        public List<Platillo> ObtenerPlatillos()
        {
            JsonHelper<Platillo>.Token = this.Token;
            var result = JsonHelper<Platillo>.GetList("/platillos/obtener-platillo");
            return result;
        }

        public Platillo ObtenerPlatillo(int id)
        {
            JsonHelper<Platillo>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Platillo>.Get(queryParams, "/platillos/buscar-platillo/" + id.ToString());
            return res;
        }

        public bool EliminarPlatillo(int id)
        {
            JsonHelper<Platillo>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Platillo>.Delete(queryParams, "/platillos/eliminar-platillos/" + id.ToString());
        }
    }
}
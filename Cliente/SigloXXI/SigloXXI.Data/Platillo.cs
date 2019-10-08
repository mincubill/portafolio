using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    class Platillo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Tiempo { get; set; }
        public string Url { get; set; }

        public Platillo()
        {
            Url = "http://weasdf.ddns.net:8082";
        }

        public bool CrearPlatillo(Platillo platillo)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
            var queryParams = new Dictionary<string, string>
            {
                {"id", platillo.Id.ToString() },
                {"nombre",  platillo.Nombre},
                {"tiempo",  platillo.Tiempo.ToString()},

            };
            return JsonHelper<Productos>.Post(queryParams, "/platillos/crear-platillo");
        }

        public bool ActualizarPlatillo(Platillo platillo)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
            var queryParams = new Dictionary<string, string>
            {
                {"id", platillo.Id.ToString() },
                {"nombre",  platillo.Nombre},
                {"tiempo",  platillo.Tiempo.ToString()},
            };
            return JsonHelper<Users>.Put(queryParams, "/productos/actualizar-producto/" + platillo.Id);
        }

        public List<Platillo> ObtenerPlatillos()
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Platillo>.Url = Url;
            var result = JsonHelper<Platillo>.GetList("/platillos/obtener-platillo");
            return result;
        }

        public Platillo ObtenerPlatillo(int id)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Platillo>.Url = Url;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Platillo>.Get(queryParams, "/platillos/buscar-platillo/" + id.ToString());
            return res;
        }

        public bool EliminarPlatillo(int id)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Platillo>.Url = Url;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Platillo>.Delete(queryParams, "/platillos/eliminar-platillos/" + id.ToString());
        }
    }
}

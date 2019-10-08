using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Mesas
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Capacidad { get; set; }
        public string Url { get; set; }
        public Mesas()
        {
            Url = "http://weasdf.ddns.net:8082";
        }

        public bool CrearMesa(Mesas mesa)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
            var queryParams = new Dictionary<string, string>
            {
                {"id", mesa.Id.ToString() },
                { "numero",  mesa.Numero.ToString() },
                {"capacidad",  mesa.Capacidad.ToString() },
            };
            return JsonHelper<Productos>.Post(queryParams, "/mesas/crear-mesa");
        }

        public bool ActualizarMesa(Mesas mesa)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
            var queryParams = new Dictionary<string, string>
            {
                {"id", mesa.Id.ToString() },
                { "numero",  mesa.Numero.ToString() },
                {"capacidad",  mesa.Capacidad.ToString() },
            };
            return JsonHelper<Users>.Put(queryParams, "/mesas/actualizar-mesa/" + mesa.Id);
        }

        public List<Mesas> ObtenerMesas()
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Mesas>.Url = Url;
            var result = JsonHelper<Mesas>.GetList("/mesas/obtener-mesas");
            return result;
        }

        public Mesas ObtenerMesa(int id)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Mesas>.Url = Url;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Mesas>.Get(queryParams, "/mesas/buscar-mesa/" + id.ToString());
            return res;
        }

        public bool EliminarMesa(int id)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Mesas>.Url = Url;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Mesas>.Delete(queryParams, "/mesas/eliminar-mesa/" + id.ToString());
        }
    }
}

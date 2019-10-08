using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Documentos
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public int Tipo { get; set; }
        public string Url { get; set; }
        public Documentos()
        {
            Url = "http://weasdf.ddns.net:8082";
        }

        public bool CrearDocumento(Documentos documento)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
            var queryParams = new Dictionary<string, string>
            {
                {"Id", documento.Id.ToString() },
                {"Fecha",  documento.Fecha.ToString()},
                {"Tipo",  documento.Tipo.ToString()},
                {"Hora",  documento.Hora},
            };
            return JsonHelper<Documentos>.Post(queryParams, "/documentos/crear-documento");
        }

        public bool ActualizarDocumento(Documentos documento)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Users>.Url = Url;
            var queryParams = new Dictionary<string, string>
            {
                {"Id", documento.Id.ToString() },
                {"Fecha",  documento.Fecha.ToString()},
                {"Tipo",  documento.Tipo.ToString()},
                {"Hora",  documento.Hora},
            };
            return JsonHelper<Users>.Put(queryParams, "/documentos/actualizar-documento/" + documento.Id);
        }

        public List<Documentos> ObtenerDocumentos()
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Documentos>.Url = Url;
            var result = JsonHelper<Documentos>.GetList("/documentos/obtener-documento");
            return result;
        }

        public Documentos ObtenerDocumento(int id)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Documentos>.Url = Url;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Documentos>.Get(queryParams, "/documentos/buscar-documento/" + id.ToString());
            return res;
        }

        public bool EliminarDocumento(int id)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Documentos>.Url = Url;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Documentos>.Delete(queryParams, "/documentos/eliminar-documento/" + id.ToString());
        }
    }
}

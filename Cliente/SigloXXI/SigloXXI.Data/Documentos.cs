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
        public string Token { get; set; }
        
        public bool CrearDocumento(Documentos documento)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"Id", documento.Id.ToString() },
                {"Fecha",  documento.Fecha.ToString()},
                {"Tipo",  documento.Tipo.ToString()},
                {"Hora",  documento.Hora},
            };
            JsonHelper<Documentos>.Token = this.Token;
            return JsonHelper<Documentos>.Post(queryParams, "/documentos/crear-documento");
        }

        public bool ActualizarDocumento(Documentos documento)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"Id", documento.Id.ToString() },
                {"Fecha",  documento.Fecha.ToString()},
                {"Tipo",  documento.Tipo.ToString()},
                {"Hora",  documento.Hora},
            };
            JsonHelper<Documentos>.Token = this.Token;
            return JsonHelper<Documentos>.Put(queryParams, "/documentos/actualizar-documento/" + documento.Id);
        }

        public List<Documentos> ObtenerDocumentos()
        {
            JsonHelper<Documentos>.Token = this.Token;
            var result = JsonHelper<Documentos>.GetList("/documentos/obtener-documento");
            return result;
        }

        public Documentos ObtenerDocumento(int id)
        {
            JsonHelper<Documentos>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Documentos>.Get(queryParams, "/documentos/buscar-documento/" + id.ToString());
            return res;
        }

        public bool EliminarDocumento(int id)
        {
            JsonHelper<Documentos>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Documentos>.Delete(queryParams, "/documentos/eliminar-documento/" + id.ToString());
        }
    }
}
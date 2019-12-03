using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Documentos
    {
        public int id { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public TipoDocumento tipo { get; set; }
        public List<PedidoHeader> pedidoH { get; set; }
        public List<OrdenHeader> ordenHId { get; set; }
        public string Token { get; set; }
        
        public bool CrearDocumento(Documentos documento)
        {
            JsonHelper<Documentos>.Token = this.Token;
            return JsonHelper<Documentos>.Post(documento, "/documentos/crear-documento");
        }

        public bool ActualizarDocumento(Documentos documento)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"Id", documento.id.ToString() },
                {"Fecha",  documento.fecha.ToString()},
                {"Tipo",  documento.tipo.ToString()},
                {"Hora",  documento.hora},
            };
            JsonHelper<Documentos>.Token = this.Token;
            return JsonHelper<Documentos>.Put(queryParams, "/documentos/actualizar-documento/" + documento.id);
        }

        public List<Documentos> ObtenerDocumentos()
        {
            JsonHelper<Documentos>.Token = this.Token;
            var result = JsonHelper<Documentos>.GetList("/documentos/obtener-documentos");
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

    public enum TipoDocumento
    {
       Boleta = 1,
       OrdenDeCompra = 2,
       NotaCredito = 3,
       NotaDebito = 4,
    }
}
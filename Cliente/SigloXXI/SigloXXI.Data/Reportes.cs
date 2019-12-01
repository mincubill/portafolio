using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Reportes
    {
        public int mesMayorIngreso { get; set; }
        public int ingresoMensual { get; set; }
        public string Token { get; set; }

        public Reportes ObtenerMesConMasIngreso()
        {
            var queryParams = new Dictionary<string, string>();
            JsonHelper<Reportes>.Token = this.Token;
            return JsonHelper<Reportes>.Get(queryParams, "/reportes/obtener-reportes");
        }

        public List<Documentos> MovimientosDelDia()
        {
            var queryParams = new Dictionary<string, string>();
            JsonHelper<Documentos>.Token = this.Token;
            var ordenes = new Documentos { Token = this.Token }.ObtenerDocumentos().
                Where(d => (d.ordenHId.Count > 0 || d.ordenHId != null)).ToList();
            return ordenes;
        }
    }
}

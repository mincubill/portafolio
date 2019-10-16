using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class OrdenHeader
    {
        public int id { get; set; }
        public int total { get; set; }
        public EstadoOrden estado { get; set; }
        public int documentoId { get; set; }
        public Mesas mesaId { get; set; }
        public List<OrdenBody> ordenBId { get; set; }
        public string Token { get; set; }

        public bool CrearOrden_H(OrdenHeader orden_h)
        {
            var queryParams = new Dictionary<string, string>
            {
              
            };
            JsonHelper<OrdenHeader>.Token = this.Token;
            return JsonHelper<OrdenHeader>.Post(queryParams, "/orden_H/crear-ordenh");
        }

        public bool ActualizarOrden_H(OrdenHeader orden_h)
        {
            var queryParams = new Dictionary<string, string>
            {

            };
            JsonHelper<OrdenHeader>.Token = this.Token;
            return JsonHelper<OrdenHeader>.Put(queryParams, "/orden_H/actualizar-orden_h/" + orden_h.id);
        }

        public List<OrdenHeader> Obtenerordenes()
        {
            JsonHelper<OrdenHeader>.Token = this.Token;
            var result = JsonHelper<OrdenHeader>.GetList("/ordenh/obtener-ordenh/");
            return result;
        }

        public OrdenHeader ObtenerOrden(int id)
        {
            JsonHelper<OrdenHeader>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<OrdenHeader>.Get(queryParams, "/ordenh/buscar-ordenh/" + id.ToString());
            return res;
        }

        public bool EliminarOrdenH(int id)
        {
            JsonHelper<OrdenHeader>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<OrdenHeader>.Delete(queryParams, "/ordenH/eliminar-orden_h/" + id.ToString());
        }

    }
    public enum EstadoOrden
    {
        Pagado = 1,
        NoPagado = 0
    }
}
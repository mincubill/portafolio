using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class OrdenH
    {
        public int id { get; set; }
        public int total { get; set; }
        public EstadoOrden estado { get; set; }
        public int documentoId { get; set; }
        public Mesas mesaId { get; set; }
        public List<OrdenBody> ordenBId { get; set; }
        public string Token { get; set; }

        public bool CrearOrden_H(OrdenH orden_h)
        {
            var queryParams = new Dictionary<string, string>
            {
              
            };
            JsonHelper<OrdenH>.Token = this.Token;
            return JsonHelper<OrdenH>.Post(queryParams, "/orden_H/crear-ordenh");
        }

        public bool ActualizarOrden_H(OrdenH orden_h)
        {
            var queryParams = new Dictionary<string, string>
            {

            };
            JsonHelper<OrdenH>.Token = this.Token;
            return JsonHelper<OrdenH>.Put(queryParams, "/orden_H/actualizar-orden_h/" + orden_h.id);
        }

        public List<OrdenH> Obtenerordenes()
        {
            JsonHelper<OrdenH>.Token = this.Token;
            var result = JsonHelper<OrdenH>.GetList("/ordenh/obtener-ordenh/");
            return result;
        }

        public OrdenH ObtenerOrden(int id)
        {
            JsonHelper<OrdenH>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<OrdenH>.Get(queryParams, "/ordenh/buscar-ordenh/" + id.ToString());
            return res;
        }

        public bool EliminarOrdenH(int id)
        {
            JsonHelper<OrdenH>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<OrdenH>.Delete(queryParams, "/ordenH/eliminar-orden_h/" + id.ToString());
        }

    }
    public enum EstadoOrden
    {
        Pagado = 1,
        NoPagado = 0
    }
}
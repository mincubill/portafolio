using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Orden_H
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public int Estado { get; set; }
        public int Documento_Id { get; set; }
        public int Mesa_Id { get; set; }
        public string Token { get; set; }

        public bool CrearOrden_H(Orden_H orden_h)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"Id", orden_h.Id.ToString() },
                {"Total",  orden_h.Total.ToString()},
                {"Estado",  orden_h.Estado.ToString()},
                {"Documento Id",  orden_h.Documento_Id.ToString()},
                {"Mesa Id",  orden_h.Mesa_Id.ToString()},
            };
            JsonHelper<Orden_H>.Token = this.Token;
            return JsonHelper<Orden_H>.Post(queryParams, "/orden_H/crear-ordenh");
        }

        public bool ActualizarOrden_H(Orden_H orden_h)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"Id", orden_h.Id.ToString() },
                {"Total",  orden_h.Total.ToString()},
                {"Estado",  orden_h.Estado.ToString()},
                {"Documento Id",  orden_h.Documento_Id.ToString()},
                {"Mesa Id",  orden_h.Mesa_Id.ToString()},
            };
            JsonHelper<Orden_H>.Token = this.Token;
            return JsonHelper<Orden_H>.Put(queryParams, "/orden_H/actualizar-orden_h/" + orden_h.Id);
        }

        public List<Orden_H> Obtenerorden_H()
        {
            JsonHelper<Orden_H>.Token = this.Token;
            var result = JsonHelper<Orden_H>.GetList("/orden_H/obtener-orden_h");
            return result;
        }

        public Orden_H ObtenerOrdenH(int id)
        {
            JsonHelper<Orden_H>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Orden_H>.Get(queryParams, "/orden_H/buscar-orden_h/" + id.ToString());
            return res;
        }

        public bool EliminarOrdenH(int id)
        {
            JsonHelper<Orden_H>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Orden_H>.Delete(queryParams, "/ordenH/eliminar-orden_h/" + id.ToString());
        }

    }
}
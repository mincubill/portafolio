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
        public string Token { get; set; }

        public bool CrearMesa(Mesas mesa)
        {
            
            var queryParams = new Dictionary<string, string>
            {
                {"id", mesa.Id.ToString() },
                { "numero",  mesa.Numero.ToString() },
                {"capacidad",  mesa.Capacidad.ToString() },
            };
            JsonHelper<Mesas>.Token = this.Token;
            return JsonHelper<Mesas>.Post(queryParams, "/mesas/crear-mesa");
        }

        public bool ActualizarMesa(Mesas mesa)
        {
           
            var queryParams = new Dictionary<string, string>
            {
                {"id", mesa.Id.ToString() },
                { "numero",  mesa.Numero.ToString() },
                {"capacidad",  mesa.Capacidad.ToString() },
            };
            JsonHelper<Mesas>.Token = this.Token;
            return JsonHelper<Mesas>.Put(queryParams, "/mesas/actualizar-mesa/" + mesa.Id);
        }

        public List<Mesas> ObtenerMesas()
        {
            JsonHelper<Mesas>.Token = this.Token;
            var result = JsonHelper<Mesas>.GetList("/mesas/obtener-mesas");
            return result;
        }

        public Mesas ObtenerMesa(int id)
        {
            JsonHelper<Mesas>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Mesas>.Get(queryParams, "/mesas/buscar-mesa/" + id.ToString());
            return res;
        }

        public bool EliminarMesa(int id)
        {
            JsonHelper<Mesas>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Mesas>.Delete(queryParams, "/mesas/eliminar-mesa/" + id.ToString());
        }
    }
}
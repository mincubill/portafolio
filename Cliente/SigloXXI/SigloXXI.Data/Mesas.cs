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

        public List<Mesas> ObtenerMesas()
        {
            var result = JsonHelper<Mesas>.GetList("/mesas/obtener-mesas");
            return result;
        }

        public Mesas ObtenerMesa(int id)
        {

            return new Mesas();
        }

        public bool CrearMesas(Mesas mesa)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"id", mesa.Id.ToString() },
                {"numero",  mesa.Numero.ToString()},
                {"capacidad",  mesa.Capacidad.ToString()},
            };
            return JsonHelper<Mesas>.Post(queryParams, "/mesas/crear-mesa");
        }

        public bool EditarMesa(Mesas mesas)
        {
            var id = mesas.Id;
            return false;
        }

        public bool EliminarMesa(int Id)
        {
            var id = Id;
            return false;
        }
    }
}

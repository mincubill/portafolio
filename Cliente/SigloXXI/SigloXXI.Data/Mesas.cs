using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Mesas
    {
        public int id { get; set; }
        public int numero { get; set; }
        public int capacidad { get; set; }
        public EstadoMesa estado { get; set; }
        public string Token { get; set; }

        public Mesas CrearMesa(Mesas mesa)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "id", mesa.id.ToString() },
                { "numero",  mesa.numero.ToString() },
                { "capacidad",  mesa.capacidad.ToString() },
                { "estado", ((int)mesa.estado).ToString() },
            };
            JsonHelper<Mesas>.Token = this.Token;
            return JsonHelper<Mesas>.Post(queryParams, "/mesas/crear-mesa");
        }

        public Mesas ActualizarMesa(Mesas mesa)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "id", mesa.id.ToString() },
                { "numero", mesa.numero.ToString() },
                { "capacidad", mesa.capacidad.ToString() },
                { "estado", ((int)mesa.estado).ToString() },
            };
            JsonHelper<Mesas>.Token = this.Token;
            return JsonHelper<Mesas>.Put(queryParams, "/mesas/actualizar-mesa/" + mesa.id);
        }

        public Mesas ActualizarMesaNoToken(Mesas mesa)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "id", mesa.id.ToString() },
                { "numero",  mesa.numero.ToString() },
                { "capacidad",  mesa.capacidad.ToString() },
                { "estado",  ((int)mesa.estado).ToString() },
            };
            return JsonHelper<Mesas>.PutNoToken(queryParams, "/mesas/actualizar-mesa/" + mesa.id);
        }

        public List<Mesas> ObtenerMesas()
        {
            JsonHelper<Mesas>.Token = this.Token;
            var result = JsonHelper<Mesas>.GetListNoToke("/mesas/obtener-mesas");
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

        public bool MarcarMesa(int id)
        {
            if (ObtenerMesa(id).estado == EstadoMesa.Disponible)
            {
                var queryParams = new Dictionary<string, string>();
                JsonHelper<Mesas>.Get(queryParams, "/mesas/cambiar-estado-no-disponible/" + id.ToString());
                return true;
            }
            else
            {
                var queryParams = new Dictionary<string, string>();
                JsonHelper<Mesas>.Get(queryParams, "/mesas/cambiar-estado-disponible/" + id.ToString());
                return true;

            }
        }

        public Mesas SeleccionMesa(int cantPersonas)
        {
            Mesas mesa = new Mesas();
            var queryParams = new Dictionary<string, string>();
            mesa = mesa.ObtenerMesas().OrderBy(m => m.capacidad).FirstOrDefault(m => m.capacidad >= cantPersonas && m.estado == EstadoMesa.Disponible);
            mesa.estado = EstadoMesa.Ocupada;
            var res = ActualizarMesaNoToken(mesa);
            JsonHelper<Mesas>.GetNoToken(queryParams, "/mesas/cambiar-estado-no-disponible/" + res.id.ToString());

            return res;
        }
    }

    public enum EstadoMesa
    {
        Ocupada = 2,
        Disponible = 1,
    }
}

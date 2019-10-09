using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public int CantidadPersonas { get; set; }
        public int ClienteId { get; set; }
        public int MesaId { get; set; }
        public string Url { get; set; }

        public Reserva()
        {
            Url = "http://weasdf.ddns.net:8082";
        }

        public bool CrearReserva(Reserva reserva)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Reserva>.Url = Url;
            var queryParams = new Dictionary<string, string>
            {
                {"id", reserva.Id.ToString() },
                {"fecha",  reserva.Fecha.ToShortDateString()},
                {"hora",  reserva.Hora.ToShortTimeString()},
                {"cantidadPersonas",  reserva.CantidadPersonas.ToString()},
                {"clienteId",  reserva.ClienteId.ToString()},
                {"mesaId",  reserva.MesaId.ToString()},

            };
            return JsonHelper<Reserva>.Post(queryParams, "/reservas/crear-reserva");
        }

        public bool EliminarReserva(int id)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Reserva>.Url = Url;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Reserva>.Delete(queryParams, "/reservas/eliminar-reserva/" + id.ToString());
        }

        public bool ActualizarReserva(Reserva reserva)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Reserva>.Url = Url;
            var queryParams = new Dictionary<string, string>
            {
                {"id", reserva.Id.ToString() },
                {"fecha",  reserva.Fecha.ToShortDateString()},
                {"hora",  reserva.Hora.ToShortTimeString()},
                {"cantidadPersonas",  reserva.CantidadPersonas.ToString()},
                {"clienteId",  reserva.ClienteId.ToString()},
                {"mesaId",  reserva.MesaId.ToString()},
            };
            return JsonHelper<Reserva>.Put(queryParams, "/reservas/actualizar-reserva/" + reserva.Id);
        }

        public List<Reserva> ObtenerReserva()
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Reserva>.Url = Url;
            var result = JsonHelper<Reserva>.GetList("/reservas/obtener-reserva");
            return result;
        }

        public Reserva ObtenerReserva(int id)
        {
            var url = new UriBuilder(Url);
            ConexionHelper.Cliente.BaseAddress = new Uri(Url);
            JsonHelper<Reserva>.Url = Url;
            var queryParams = new Dictionary<string, string>();
            var res = JsonHelper<Reserva>.Get(queryParams, "/reservas/buscar-reserva/" + id.ToString());
            return res;
        }        
    }
}

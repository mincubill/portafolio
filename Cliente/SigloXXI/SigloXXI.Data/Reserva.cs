using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class Reserva
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public int cantidadPersonas { get; set; }
        public Clientes clienteId { get; set; }
        public Mesas mesaId { get; set; }
        public string Token { get; set; }

        public bool CrearReserva(Reserva reserva)
        {
            JsonHelper<Reserva>.Token = this.Token;
            return JsonHelper<Reserva>.Post(reserva, "/reservas/crear-reserva");
        }

        public List<Reserva> ObtenerReservas()
        {
            JsonHelper<Reserva>.Token = this.Token;
            return JsonHelper<Reserva>.GetList("/reservas/obtener-reservas");
        }

        public Reserva ObtenterReseva(int id)
        {
            JsonHelper<Reserva>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Reserva>.Get(queryParams, "/reservas/buscar-reserva/" + id.ToString());
        }

        public bool ActualizarReserva(Reserva reserva)
        {
            JsonHelper<Reserva>.Token = this.Token;
            return JsonHelper<Reserva>.Put(reserva, "/reservas/buscar-reserva/" + id.ToString());
        }

        public bool EliminarReserva(int id)
        {
            JsonHelper<Reserva>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Reserva>.Delete(queryParams, "/reservas/eliminar-reserva/" + id.ToString());
        }
    }
}

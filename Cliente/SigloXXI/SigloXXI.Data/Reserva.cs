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
        public string fecha { get; set; }
        public string hora { get; set; }
        public int cantidadPersonas { get; set; }
        public Clientes clienteId { get; set; }
        public Mesas mesaId { get; set; }
        public EstadoReserva estado { get; set; }
        public string Token { get; set; }

        public bool CrearReserva(Reserva reserva)
        {
            JsonHelper<Reserva>.Token = this.Token;
            reserva.mesaId = SeleccionMesa(reserva.cantidadPersonas);
            return JsonHelper<Reserva>.Post(reserva, "/reservas/crear-reserva");
        }

        public List<Reserva> ObtenerReservas()
        {
            JsonHelper<Reserva>.Token = this.Token;
            return JsonHelper<Reserva>.GetList("/reservas/obtener-reservas");
        }

        public Reserva ObtenterReserva(int id)
        {
            JsonHelper<Reserva>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Reserva>.Get(queryParams, "/reservas/buscar-reserva/" + id.ToString());
        }

        public bool ActualizarReserva(Reserva reserva)
        {
            JsonHelper<Reserva>.Token = this.Token;
            return JsonHelper<Reserva>.Put(reserva, "/reservas/actualizar-reserva/" + id.ToString());
        }

        public bool EliminarReserva(int id)
        {
            JsonHelper<Reserva>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Reserva>.Delete(queryParams, "/reservas/eliminar-reserva/" + id.ToString());
        }

        public Reserva ValidarReserva(int id)
        {
            JsonHelper<Reserva>.Token = this.Token;
            var queryParams = new Dictionary<string, string>();
            return JsonHelper<Reserva>.Get(queryParams, "/reservas/cambiar-estado-reserva/" + id.ToString());
        }

        private Mesas SeleccionMesa(int cantPersonas)
        {
            Mesas mesa = new Mesas() { Token = this.Token };
            mesa = mesa.ObtenerMesas().OrderBy(m => m.capacidad).FirstOrDefault(m => m.capacidad >= cantPersonas && m.estado == EstadoMesa.Disponible);
            return mesa;
        }
    }
    public enum EstadoReserva
    {
        Ocupada = 2,
        NoOcupada = 1,
    }
}

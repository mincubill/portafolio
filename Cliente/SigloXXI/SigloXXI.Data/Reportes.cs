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

        public List<Documentos> MovimientosDelDia(string fechaDia)
        {
            DateTime fecha = DateTime.Parse(fechaDia);
            var queryParams = new Dictionary<string, string>();
            JsonHelper<Documentos>.Token = this.Token;
            var ordenes = new Documentos { Token = this.Token }.ObtenerDocumentos().
                Where(d => (d.ordenHId.Count > 0 || d.ordenHId != null) && DateTime.Parse(d.fecha) == fecha).ToList();
            return ordenes;
        }

        public List<Documentos> PedidosProveedoresDelDia(string fechaDia)
        {
            DateTime fecha = DateTime.Parse(fechaDia);
            var queryParams = new Dictionary<string, string>();
            JsonHelper<Documentos>.Token = this.Token;
            var pedidos = new Documentos { Token = this.Token }.ObtenerDocumentos().
                Where(d => (d.pedidoH.Count > 0 || d.pedidoH != null) && DateTime.Parse(d.fecha) == fecha).ToList();
            return pedidos;
        }

        public Dictionary<string, int> PlatilloMasConsumidoPorMes(int numeroMes, int anyo)
        {
            var fechaInicial = new DateTime(anyo, numeroMes, 1);
            int diasDelMes = DateTime.DaysInMonth(anyo, numeroMes);
            var fechaFinal = new DateTime(anyo, numeroMes, diasDelMes);
            var queryParams = new Dictionary<string, string>();
            JsonHelper<Documentos>.Token = this.Token;

            var docConOrdenes = new Documentos { Token = this.Token }.ObtenerDocumentos().
                Where(d => (d.ordenHId.Count > 0) &&
                (DateTime.Parse(d.fecha) >= fechaInicial && DateTime.Parse(d.fecha) <= fechaFinal)).ToList();
            var platillos = new List<OrdenBody>();

            foreach (var d in docConOrdenes)
            {
                foreach (var o in d.ordenHId)
                {
                    foreach (var ob in o.ordenBId)
                    {
                        platillos.Add(ob);
                    }
                }
            }
            var platillosConsumidos = platillos.GroupBy(p => p.platilloId.nombre).ToDictionary(x => x.Key, x => x.ToList().Count).
                OrderByDescending(k => k.Value).ToDictionary(x => x.Key, x => x.Value);

            return platillosConsumidos;
        }
    }
}

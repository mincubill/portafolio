using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class PedidoBody
    {
        public int id { get; set; }
        public int cantidad { get; set; }
        public int subtotal { get; set; }
        public Productos productoId { get; set; }
        public string Token { get; set; }

        public void CalcularTotal()
        {
            if(productoId != null)
            {
                subtotal = cantidad * productoId.precio;
            }
        }
    }
}

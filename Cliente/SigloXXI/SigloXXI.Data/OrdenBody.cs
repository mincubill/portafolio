using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigloXXI.Data
{
    public class OrdenBody
    {
        public int id { get; set; }
        public int cantidad { get; set; }
        public int subTotal { get; set; }
        public Platillo platilloId { get; set; }
    }
}

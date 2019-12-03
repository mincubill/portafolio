using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SigloXXI.Models
{
    public class PedidoHeaderModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Código: ")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Total: ")]
        public int Total { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Id proveedor: ")]
        public string ProveedorRut { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Id documento: ")]
        public List<PedidoBodyModel> DetallePedido { get; set; }
    }
}
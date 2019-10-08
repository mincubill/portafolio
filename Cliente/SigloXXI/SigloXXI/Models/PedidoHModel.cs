using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SigloXXI.Models
{
    public class PedidoHModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Código: ")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Total: ")]
        public int Total { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Id proveedor: ")]
        public string Proveedor_Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Id documento: ")]
        public int Documento_Id { get; set; }
    }
}
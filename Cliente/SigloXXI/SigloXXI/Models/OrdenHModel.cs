using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SigloXXI.Models
{
    public class OrdenHModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Código: ")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Total: ")]
        public int Total { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Estado: ")]
        public int Estado { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Documento_Id: ")]
        public int Documento_Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Mesa_Id: ")]
        public int Mesa_Id { get; set; }
    }
}
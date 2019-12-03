using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SigloXXI.Models
{
    public class MesaModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Id: ")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Numero: ")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Capacidad: ")]
        public int Capacidad { get; set; }
    }
}
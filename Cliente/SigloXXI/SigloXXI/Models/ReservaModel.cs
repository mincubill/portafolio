using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SigloXXI.Data;

namespace SigloXXI.Models
{
    public class ReservaModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Fecha: ")]
        public string fecha { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Hora: ")]
        public string hora { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Cantidad de personas: ")]
        public int cantidadPersonas { get; set; }
        public int clienteId { get; set; }
        public int mesaId { get; set; }
    }
}
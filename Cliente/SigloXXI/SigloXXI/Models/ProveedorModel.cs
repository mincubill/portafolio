using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SigloXXI.Models
{
    public class ProveedorModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Rut: ")]
        public string Rut { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nombre: ")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Telefono: ")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Direccion: ")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Correo: ")]
        public string Correo { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace SigloXXI.Models
{
    public class ClienteModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Rut: ")]
        public int Rut{ get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Dv: ")]
        public string Dv { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nombre: ")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Apellido: ")]
        public int Correo { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Correo: ")]
        public int Telefono { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Telefono: ")]
        public string Categoria { get; set; }
    }
}
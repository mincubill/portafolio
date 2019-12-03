using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SigloXXI.Models
{
    public class PlatilloModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Id: ")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nombre: ")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Tiempo: ")]
        public int Tiempo { get; set; }

        public List<IngredienteModel> Ingrediente { get; set; }
    }
}
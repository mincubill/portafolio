using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SigloXXI.Models
{
    public class ProductoModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Codigo: ")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nombre: ")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Descripcion: ")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Cantidad: ")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Precio: ")]
        public int Precio { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Categoria: ")]
        public string Categoria { get; set; }
    }
}
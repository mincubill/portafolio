﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace SigloXXI.Models
{
    public class IngredienteModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Codigo: ")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Cantidad: ")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Id Platillo: ")]
        public int Platillo_Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Id producto: ")]
        public ProductoModel Producto { get; set; }
    }
}
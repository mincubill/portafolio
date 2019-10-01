﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace SigloXXI.Models
{
    public class Documento
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Código: ")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Fecha: ")]
        public string Fecha { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Hora: ")]
        public string Hora { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Tipo: ")]
        public int Tipo { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SigloXXI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nombre de usuario: ")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Contraseña: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int Privilege { get; set; }

    }
}
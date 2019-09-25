using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SigloXXI.Models
{
    public class LoginModel
    {
        public int Rut { get; set; }
        public char Dv { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nombre de usuario: ")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Contraseña: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Rol { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }

    }
}
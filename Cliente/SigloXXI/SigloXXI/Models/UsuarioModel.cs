using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SigloXXI.Models
{
    public class UsuarioModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Rut: ")]
        public int Rut { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "DV")]
        public char Dv { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nombre de usuario: ")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Contraseña: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nombre: ")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Apellido: ")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Rol: ")]
        public Rol Rol { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Correo: ")]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Fecha de nacicimiento: ")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
    }
    public enum Rol
    {
        Admin = 1,
        Bodega = 2,
    }
}
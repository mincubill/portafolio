using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SigloXXI.Models;
using SigloXXI.Data;

namespace SigloXXI.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult AgregarUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarUsuario(UsuarioModel model)
        {
            var user = new Users
            {
                Apellido = model.Apellido,
                Correo = model.Correo,
                Dv = model.Dv,
                FechaNacimiento = model.FechaNacimiento,
                Nombre = model.Nombre,
                PassWord = model.Password,
                rol = (int)model.Rol,
                Rut = model.Rut,
                UserName = model.UserName,
            };
            user.CrearUsuario(user);
            return View();
        }

        [HttpGet]
        public ActionResult VerUsuarios()
        {
            var user = new Users();
            ViewData["Usuarios"] = user.ObtenerUsuarios();
            return View();
        }
    }
}
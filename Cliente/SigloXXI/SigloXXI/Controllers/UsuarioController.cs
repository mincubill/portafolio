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
                Url = "http://weasdf.ddns.net:8082",
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
            return RedirectToAction("VerUsuarios");
        }

        [HttpGet]
        public ActionResult VerUsuarios()
        {
            var user = new Users() { Url = "http://weasdf.ddns.net:8082" };
            ViewData["Usuarios"] = user.ObtenerUsuarios();
            return View();
        }

        [HttpGet]
        public ActionResult EditarUsuarios(string rut)
        {
            var user = new Users() { Url = "http://weasdf.ddns.net:8082" };
            user = user.ObtenerUsuario(int.Parse(rut));
            ViewData["Usuario"] = user;
            UsuarioModel model = new UsuarioModel()
            {
                Apellido = user.Apellido,
                Correo = user.Correo,
                Dv = user.Dv,
                FechaNacimiento = user.FechaNacimiento,
                Nombre = user.Nombre,
                Password = user.PassWord,
                Rol = (Rol)user.rol,
                Rut = user.Rut,
                UserName = user.UserName,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarUsuarios(UsuarioModel model)
        {
            var user = new Users
            {
                Url = "http://weasdf.ddns.net:8082",
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
            user.ActualizarUsuario(user);
            return RedirectToAction("VerUsuarios");
        }

        
        public ActionResult EliminarUsuarios(string rut)
        {
            var user = new Users() { Url = "http://weasdf.ddns.net:8082" };
            user.EliminarUsuario(int.Parse(rut));
            return RedirectToAction("VerUsuarios");

        }
    }
}
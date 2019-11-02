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
        private string _token;
        public UsuarioController()
        {
        }
        [HttpGet]
        public ActionResult AgregarUsuario()
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AgregarUsuario(UsuarioModel model)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var user = new Usuario
            {
                Token = _token,
                Apellido = model.Apellido,
                Correo = model.Correo,
                Dv = model.Dv,
                FechaNacimiento = model.FechaNacimiento,
                Nombre = model.Nombre,
                PassWord = model.Password,
                rol = (SigloXXI.Data.RolUsuario)model.Rol,
                Rut = model.Rut,
                UserName = model.UserName,
            };
            user.CrearUsuario(user);
            return RedirectToAction("VerUsuarios");
        }

        [HttpGet]
        public ActionResult VerUsuarios()
        {
            _token = Session["Token"].ToString();
            var user = new Usuario() { Token = _token };
            ViewData["Usuarios"] = user.ObtenerUsuarios();
            return View();
        }

        [HttpGet]
        public ActionResult EditarUsuarios(string rut)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var user = new Usuario();
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
                Rol = (SigloXXI.Models.RolUsuario)user.rol,
                Rut = user.Rut,
                UserName = user.UserName,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarUsuarios(UsuarioModel model)
        {
            var user = new Usuario
            {
                Token = _token,
                Apellido = model.Apellido,
                Correo = model.Correo,
                Dv = model.Dv,
                FechaNacimiento = model.FechaNacimiento,
                Nombre = model.Nombre,
                PassWord = model.Password,
                rol = (SigloXXI.Data.RolUsuario)model.Rol,
                Rut = model.Rut,
                UserName = model.UserName,
            };
            user.ActualizarUsuario(user);
            return RedirectToAction("VerUsuarios");
        }


        public ActionResult EliminarUsuarios(string rut)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var user = new Usuario() { Token = _token};
            user.EliminarUsuario(int.Parse(rut));
            return RedirectToAction("VerUsuarios");

        }
    }
}
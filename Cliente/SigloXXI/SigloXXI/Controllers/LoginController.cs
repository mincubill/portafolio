using SigloXXI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SigloXXI.Data;

namespace SigloXXI.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            Session["Access"] = "";
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //Here we are checking the values with hardcoded admin and admin
                //You can check these values from a database
                var user = new Users();
                var tempUser = user.IniciarSesion(model.UserName, model.Password);
                if (tempUser != null)
                {
                    model.Rut = tempUser.Rut;
                    model.Dv = tempUser.Dv;
                    model.Correo = tempUser.Correo;
                    model.FechaNacimiento = tempUser.FechaNacimiento;
                    model.Nombre = tempUser.Nombre;
                    model.Apellido = tempUser.Apellido;
                    //Store the Username in session
                    Session["UserName"] = tempUser.UserName;
                    Session["Rol"] = tempUser.rol;
                    //Then redirect to the Index Action method of Home Controller
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User Name or Password");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Logout()
        {
            Session["UserName"] = null;
            Session["Rol"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
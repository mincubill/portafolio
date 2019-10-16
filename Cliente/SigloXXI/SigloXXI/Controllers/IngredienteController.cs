using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SigloXXI.Data;
using SigloXXI.Models;
using System.Web.Mvc;

namespace SigloXXI.Controllers
{
    public class IngredienteController : Controller
    {
        string _token;
        public ActionResult VerIngredientes()
        {
            _token = Session["Token"].ToString();
            var ingredientes = new Ingredientes() { Token = _token };
            ViewData["Ingredientes"] = ingredientes.ObtenerIngredientes();
            return View();
        }
        [HttpGet]
        public ActionResult AgregarIngredientes()
        {
            _token = Session["Token"].ToString();
            return View();
        }

        [HttpPost]
        public ActionResult AgregarIngredientes(IngredienteModel model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditarIngrediente(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditarIngredientes(IngredienteModel model)
        {
            return View();
        }

        public ActionResult EliminarIngredientes(int id)
        {
            _token = Session["Token"].ToString();
            var ingredientes = new Ingredientes() { Token = _token } ;
            ingredientes.EliminarIngrediente(id);
            return RedirectToAction("VerIngredientes");
        }
    }
}
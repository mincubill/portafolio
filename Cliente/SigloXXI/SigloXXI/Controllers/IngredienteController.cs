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
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var ingredientes = new Ingredientes() { Token = _token };
            ViewData["Ingredientes"] = ingredientes.ObtenerIngredientes();
            return View();
        }
        [HttpGet]
        public ActionResult AgregarIngredientes()
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AgregarIngredientes(IngredienteModel model)
        {
            _token = Session["Token"].ToString();
            var ingredientes = new Ingredientes()
            {
                
            };
            ingredientes.CrearIngrediente(ingredientes);
            return RedirectToAction("VerIngredientes");
        }

        [HttpGet]
        public ActionResult EditarIngrediente(int id)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var ingredientes = new Ingredientes() { Token = _token };
            ingredientes = ingredientes.ObtenerIngrediente(id);
            IngredienteModel model = new IngredienteModel
            {
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarIngredientes(IngredienteModel model)
        {
            _token = Session["Token"].ToString();
            var ingredientes = new Ingredientes()
            {
                Token = _token,
                
            };
            ingredientes.ActualizarIngrediente(ingredientes);
            return RedirectToAction("VerIngredientes");

        }

        public ActionResult EliminarIngredientes(int id)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var ingredientes = new Ingredientes() { Token = _token } ;
            ingredientes.EliminarIngrediente(id);
            return RedirectToAction("VerIngredientes");
        }
    }
}
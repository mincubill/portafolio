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
        public ActionResult VerIngredientes()
        {
            var ingredientes = new Ingredientes();
            ViewData["Ingredientes"] = prod.ObtenerIngredientes();
            return View();
        }
        [HttpGet]
        public ActionResult AgregarIngredientes()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarIngredientes(IngredienteModel model)
        {
            var ingredientes = new Ingredientes()
            {       
                Id = model.Id,
                Cantidad = model.Cantidad,
                Platillo_Id = model.Platillo_Id,
                Producto_Id = model.Producto_Id,
            };
            ingredientes.CrearIngrediente(ingredientes);
            return RedirectToAction("VerIngredientes");
        }

        [HttpGet]
        public ActionResult EditarIngrediente(int id)
        {
            var ingredientes = new Ingredientes();
            ingredientes = ingredientes.ObtenerIngrediente(id);
            IngredienteModel model = new IngredienteModel
            {
                Id = ingredientes.Id,
                Cantidad = ingredientes.Cantidad,
                Platillo_Id = ingredientes.Platillo_Id,
                Producto_Id = ingredientes.Producto_Id,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarIngredientes(IngredienteModel model)
        {
            var ingredientes = new Ingredientes()
            {
                Id = model.Id,
                Cantidad = model.Cantidad,
                Platillo_Id = model.Platillo_Id,
                Producto_Id = model.Producto_Id,
            };
            ingredientes.ActualizarIngrediente(ingredientes);
            return RedirectToAction("VerIngredientes");

        }

        public ActionResult EliminarIngredientes(int id)
        {
            var ingredientes = new Ingredientes();
            ingredientes.EliminarIngrediente(id);
            return RedirectToAction("VerIngredientes");
        }
    }
}
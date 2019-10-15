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
            _token = Session["Token"].ToString();
            var ingredientes = new Ingredientes()
            {
                Token = _token,
                id = model.Id,
                cantidad = model.Cantidad,
                platilloId = model.Platillo_Id,
                producto_Id = model.Producto_Id,
            };
            ingredientes.CrearIngrediente(ingredientes);
            return RedirectToAction("VerIngredientes");
        }

        [HttpGet]
        public ActionResult EditarIngrediente(int id)
        {
            _token = Session["Token"].ToString();
            var ingredientes = new Ingredientes() { Token = _token };
            ingredientes = ingredientes.ObtenerIngrediente(id);
            IngredienteModel model = new IngredienteModel
            {
                Id = ingredientes.id,
                Cantidad = ingredientes.cantidad,
                Platillo_Id = ingredientes.platilloId,
                Producto_Id = ingredientes.producto_Id,
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
                id = model.Id,
                cantidad = model.Cantidad,
                platilloId = model.Platillo_Id,
                producto_Id = model.Producto_Id,
            };
            ingredientes.ActualizarIngrediente(ingredientes);
            return RedirectToAction("VerIngredientes");

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
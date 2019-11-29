using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SigloXXI.Data;
using SigloXXI.Models;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SigloXXI.Controllers
{
    public class PlatilloController : Controller
    {
        string _token;
        public ActionResult VerPlatillos()
        {
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            _token = Session["Token"].ToString();
            var plat = new Platillo() { Token = _token };
            ViewData["Platillo"] = plat.ObtenerPlatillos();
            return View();
        }

        [HttpGet]
        public ActionResult AgregarPlatillo()
        {
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            _token = Session["Token"].ToString();
            var ingredientes = new Productos { Token = _token }.ObtenerProductos().
                Where(i => i.categoria.ToUpper() == "INGREDIENTE").ToList();
            ViewData["Ingredientes"] = ingredientes;
            return View();
        }

        [HttpPost]
        public ActionResult AgregarPlatillo(string data)
        {
            _token = Session["Token"].ToString();
            var platilloModel = JsonConvert.DeserializeObject<PlatilloModel>(data);

            Platillo platillo = new Platillo()
            {
                Token = _token,
                nombre = platilloModel.Nombre,
                tiempo = platilloModel.Tiempo,
                ingredienteId = platilloModel.Ingrediente.Select(i =>
                   new Ingredientes
                   {
                       cantidad = i.Cantidad,
                       productoId = new Productos
                       {
                           id = i.Producto.Id,
                       }
                   }).ToList(),
            };
            platillo.CrearPlatillo(platillo);
            return RedirectToAction("VerPlatillos");
        }

        [HttpGet]
        public ActionResult EditarPlatillo(int id)
        {
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            _token = Session["Token"].ToString();
            var plat = new Platillo() { Token = _token };
            plat = plat.ObtenerPlatillo(id);
            PlatilloModel model = new PlatilloModel
            {
                Id = plat.id,
                Nombre = plat.nombre,
                Tiempo = plat.tiempo,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarPlatillo(PlatilloModel model)
        {
            _token = Session["Token"].ToString();
            var plat = new Platillo()
            {
                Token = _token,
                id = model.Id,
                nombre = model.Nombre,
                tiempo = model.Tiempo,
            };
            plat.ActualizarPlatillo(plat);
            return RedirectToAction("VerPlatillos");
        }

        public ActionResult EliminarPlatillo(int id)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var plat = new Platillo() { Token = _token };
            plat.EliminarPlatillo(id);
            return RedirectToAction("VerPlatillos");
        }

        public ActionResult VerDetalles(int id)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var plat = new Platillo() { Token = _token };
            var ingredientes = plat.ObtenerPlatillo(1).ingredienteId;
            ViewData["Detalles"] = ingredientes;
            return View();
        }
    }
}
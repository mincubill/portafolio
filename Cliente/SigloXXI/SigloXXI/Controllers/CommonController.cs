using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SigloXXI.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult Administrador()
        {
            return View();
        }

        public ActionResult Bartender()
        {
            return View();
        }

        public ActionResult Bodega()
        {
            return View();
        }

        public ActionResult Cocina()
        {
            return View();
        }

        public ActionResult Finazas()
        {
            return View();
        }

        public ActionResult Mesero()
        {
            return View();
        }
    }
}
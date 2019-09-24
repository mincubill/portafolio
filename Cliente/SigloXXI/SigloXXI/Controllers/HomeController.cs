using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SigloXXI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Index()
        {
            if(Session["Rol"] == null)
            {
                Session["Rol"] = "";
            }
            return View();
        }
    }
}
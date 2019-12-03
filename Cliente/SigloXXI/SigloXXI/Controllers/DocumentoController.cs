using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SigloXXI.Models;
using SigloXXI.Data;

namespace SigloXXI.Controllers
{
    public class DocumentoController : Controller
    {
        string _token;
        
        public ActionResult VerDocumento(int id)
        {
            _token = Session["Token"].ToString();
            if (string.IsNullOrEmpty(_token))
            {
                RedirectToAction("Index", "Home");
            }
            var documento = new Documentos() { Token = _token }.ObtenerDocumento(id);
            ViewData["Documento"] = documento;
            return View();
        }
        
    }
}
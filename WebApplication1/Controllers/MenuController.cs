using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/
        //[HttpPost]
        public ActionResult Menu(string valor, int valor2)
        {
            ViewData["titulo"] = valor;

            HttpContext.Session.Add("_SessionEmpresa", valor2);
            HttpContext.Session.Add("_SessionPerfil", valor);

            //string nombEmpresa = Session["_nombEmpresa"].ToString();

            return View("Index");
        }
	}
}
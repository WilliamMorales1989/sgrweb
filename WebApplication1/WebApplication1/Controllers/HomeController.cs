using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult ContactCopia()
        {
            ViewBag.Message = "Your contact page.";
            
            return View();
        }

        [AllowAnonymous]
        public ActionResult getEmpresas(int id = 1)
        {
            List<object> devolver;
            switch (id)
            {
                case 1:
                    devolver = new List<object>
                                {
                                    new {nombre = "hola1.1", id = 1},
                                    new {nombre = "hola1.2", id = 2},
                                    new {nombre = "hola1.3", id = 3}
                                };
                    break;
                case 2:
                    devolver = new List<object>
                                {
                                    new {nombre = "hola2.1", id = 1},
                                    new {nombre = "hola2.2", id = 2},
                                    new {nombre = "hola3.3", id = 3}
                                };
                    break;
                case 3:
                    devolver = new List<object>
                                {
                                    new {nombre = "hola3.1", id = 1},
                                    new {nombre = "hola3.2", id = 2},
                                    new {nombre = "hola3.3", id = 3}
                                };
                    break;
                default:
                    devolver = new List<object>
                                {
                                    new {nombre = "default1", id = 1},
                                    new {nombre = "default2", id = 2},
                                    new {nombre = "default3", id = 3}
                                };
                    break;
            }
            return Json(devolver, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getCategorias()
        {
            List<CategoriasModels> categorias = new List<CategoriasModels>()
            {
                new CategoriasModels {Id = 1, Title = "Categoria 1"},            
                new CategoriasModels {Id = 2, Title = "Categoria 2"},
                new CategoriasModels {Id = 3, Title = "Categoria 3"}
            };

            return Json(categorias, JsonRequestBehavior.AllowGet);
        }
    }
}
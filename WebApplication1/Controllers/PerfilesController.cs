using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PerfilesController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            string cadena = HttpContext.Session["_Sessiongrupos"].ToString();


            String usuarioAdmin = "Administrador SGR";
            int firstCharacterAdmin = cadena.IndexOf(usuarioAdmin);

            String usuarioProd = "Produccion SGR";
            int firstCharacterProd = cadena.IndexOf(usuarioProd);

            String usuarioNegocio = "Usuarionegocio SGR";
            int firstCharacterNegocio = cadena.IndexOf(usuarioNegocio);

            if (firstCharacterAdmin != -1 && firstCharacterProd != -1 && firstCharacterNegocio != -1)
            {
                ViewData["num"] = 7;
            }
            else if (firstCharacterAdmin != -1 && firstCharacterNegocio != -1)
            {
                ViewData["num"] = 6;
            }
            else if (firstCharacterProd != -1 && firstCharacterNegocio != -1)
            {
                ViewData["num"] = 5;
            }
            else if (firstCharacterAdmin != -1 && firstCharacterProd != -1)
            {
                ViewData["num"] = 4;
            }
            else if (firstCharacterNegocio != -1)
            {
                ViewData["num"] = 3;
            }
            else if (firstCharacterProd != -1)
            {
                ViewData["num"] = 2;
            }
            else if (firstCharacterAdmin != -1)
            {
                ViewData["num"] = 1;
            }
            return View();
        }

        public ActionResult getEmpresas(EmpresaModel empresa)
        {
            List<ListaBodega> nombreBodega = empresa.ListarBodegas("MAUCAM");

            return Json(nombreBodega, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getCategorias(int perfil)
        {
            //Combo valor = new Combo();

            /*SetPerfil(7);

            int perfil = GetPerfil();*/

            List<PerfilesModels> categorias = new List<PerfilesModels>();
            if (perfil == 1)
            {
                List<PerfilesModels> categorias1 = new List<PerfilesModels>(){
                    new PerfilesModels { Id = 1, Nombre = "Administrador SGR" }
                };
                return Json(categorias1, JsonRequestBehavior.AllowGet);
            }
            if (perfil == 2)
            {
                List<PerfilesModels> categorias1 = new List<PerfilesModels>(){
                    new PerfilesModels { Id = 2, Nombre = "Producción SGR" }
                };
                return Json(categorias1, JsonRequestBehavior.AllowGet);

            }
            if (perfil == 3)
            {
                List<PerfilesModels> categorias1 = new List<PerfilesModels>(){
                    new PerfilesModels { Id = 3, Nombre = "Usuario Negocio SGR" }
                };
                return Json(categorias1, JsonRequestBehavior.AllowGet);
            }
            if (perfil == 4)
            {
                List<PerfilesModels> categorias1 = new List<PerfilesModels>(){
                    new PerfilesModels { Id = 1, Nombre = "Administrador SGR" },
                    new PerfilesModels { Id = 2, Nombre = "Producción SGR" }
                };
                return Json(categorias1, JsonRequestBehavior.AllowGet);
            }
            if (perfil == 5)
            {
                List<PerfilesModels> categorias1 = new List<PerfilesModels>(){
                    new PerfilesModels { Id = 2, Nombre = "Producción SGR" },
                    new PerfilesModels { Id = 3, Nombre = "Usuario Negocio SGR" }
                };
                return Json(categorias1, JsonRequestBehavior.AllowGet);
            }
            if (perfil == 6)
            {
                List<PerfilesModels> categorias1 = new List<PerfilesModels>(){
                    new PerfilesModels { Id = 1, Nombre = "Administrador SGR" },
                    new PerfilesModels { Id = 3, Nombre = "Usuario Negocio SGR" }
                };
                return Json(categorias1, JsonRequestBehavior.AllowGet);
            }
            if (perfil == 7)
            {
                List<PerfilesModels> categorias1 = new List<PerfilesModels>(){
                    new PerfilesModels { Id = 1, Nombre = "Administrador SGR" },
                    new PerfilesModels { Id = 2, Nombre = "Producción SGR" },
                    new PerfilesModels { Id = 3, Nombre = "Usuario Negocio SGR" }
                };
                return Json(categorias1, JsonRequestBehavior.AllowGet);
            }
            return Json(categorias, JsonRequestBehavior.AllowGet);
        }
	}
}
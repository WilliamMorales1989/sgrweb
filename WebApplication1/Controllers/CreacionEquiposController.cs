using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Linq;
using LinqToExcel;
using System.IO;

namespace WebApplication1.Controllers
{
    public class CreacionEquiposController : Controller
    {
        public List<CreacionEquiposModels> ToEntidadHojaExcelList(HttpPostedFileBase pathDelFicheroExcel)
        {
            string archivoruta = @"C:\ArchivosSGR\" + pathDelFicheroExcel.FileName;
            var book = new ExcelQueryFactory(archivoruta);
            var resultado = (from row in book.Worksheet("Hoja1")
                             let item = new CreacionEquiposModels
                             {
                                 Serie = row["SERIE"].Cast<string>(),
                                 Macaddress1 = row["MACADDRESS2"].Cast<string>()
                             }
                             select item).ToList();


            book.Dispose();
            int empresaUsuario = int.Parse(HttpContext.Session["_SessionEmpresa"].ToString());
            ViewData["EmpresaUsuario"] = empresaUsuario;
            return resultado;
        }

        private readonly List<CreacionEquiposModels> clients = new List<CreacionEquiposModels>() 
        { 


        };



        // GET: Client
        public ActionResult Index()
        {
           return View(clients);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase archivo, string Hoja)
        {
            try
            {
                if (!archivo.Equals(null))
                {
                    
                    return View(ToEntidadHojaExcelList(archivo));
                }

                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            
        }

        public JsonResult getTipoEquipos(int empresa, TipoModel model)
        {
            List<ListaTiposEquipos> nombreEmpresa = model.listarTipos(empresa);
            return Json(nombreEmpresa, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getBodegaUsuario(int empresa, Bodega model)
        {
            string usuario = "MAUCAM";// HttpContext.Session["_SessionUsuario"].ToString();

            List<ListaBodegaUsuario> BodegaUsuario = model.listarTipos(empresa, usuario);
            return Json(BodegaUsuario, JsonRequestBehavior.AllowGet);
        }


        [AllowAnonymous]
        public ActionResult getMarcaEquipos(Marcas marcas, int idTipo)
        {
            int empresaUsuario = int.Parse(HttpContext.Session["_SessionEmpresa"].ToString());
            HttpContext.Session.Add("_SessionMarcaEquipo", idTipo);

            List<ListaMarcas> nombreBodega = marcas.listarTipos(empresaUsuario, idTipo);

            return Json(nombreBodega, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult getModeloEquipos(Modelos modelos, int idTipo)
        {
            int empresaUsuario = int.Parse(HttpContext.Session["_SessionEmpresa"].ToString());
            int idMarca = int.Parse(HttpContext.Session["_SessionMarcaEquipo"].ToString());
            List<ListaModelos> nombreBodega = modelos.listarMarca(empresaUsuario, idTipo, idMarca);



            return Json(nombreBodega, JsonRequestBehavior.AllowGet);
        }

    }
}
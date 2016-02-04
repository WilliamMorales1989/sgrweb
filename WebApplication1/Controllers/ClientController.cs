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
    public class ClientController : Controller
    {
        public List<Client> ToEntidadHojaExcelList(HttpPostedFileBase pathDelFicheroExcel)
        {
            string archivoruta = @"C:\ArchivosSGR\" + pathDelFicheroExcel.FileName;
            var book = new ExcelQueryFactory(archivoruta);
            var resultado = (from row in book.Worksheet("Hoja1")
                             let item = new Client
                             {
                                 Serie = row["SERIE"].Cast<string>(),
                                 Macaddress1 = row["MACADDRESS2"].Cast<string>()
                             }
                             select item).ToList();

            book.Dispose();
            return resultado;
        }

        private readonly List<Client> clients = new List<Client>()
        {
        
        
        };

        // GET: Client
        public ActionResult ClientView()
        {
            return View(clients);
        }

        [HttpPost]
        public ActionResult ClientView(HttpPostedFileBase archivo, string Hoja)
        {
            if(!archivo.Equals(null))
            {
                return View(ToEntidadHojaExcelList(archivo));
            }
            
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CategoriasModels
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public CategoriasModels() {}
    }
    public class EmpresaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public EmpresaModel() { }
    }
}
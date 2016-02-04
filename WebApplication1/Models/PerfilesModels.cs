using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.SGR;

namespace WebApplication1.Models
{
    public class PerfilesModels
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public PerfilesModels() { }
    }

    public class EmpresaModel
    {
        public List<ListaBodega> ListarBodegas(string NombreUsuario)
        {
            SGR.SGRConsultas webservice = new SGR.SGRConsultas();
            string resp1, resp2;
            var ejemplo = webservice.EmpresaXUsuario(NombreUsuario, out resp1, out resp2);

            List<ListaBodega> listar = new List<ListaBodega>();
            //ListaBodega valor = new ListaBodega();

            for (int i = 0; i < ejemplo.Length; i++)
            {
                ListaBodega valor = new ListaBodega();

                valor.Id = int.Parse(ejemplo[i].CodEmpresa);
                valor.NombreEmpresa = ejemplo[i].NomEmpresa;
                valor.NombreUsuario = ejemplo[i].NomUsuario;

                listar.Add(valor);
            }

            return listar;
        }
    }

    public class ListaBodega
    {
        public int Id { get; set; }
        public String NombreEmpresa { get; set; }
        public String NombreUsuario { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CreacionEquiposModels
    {
        public string Serie { get; set; }
        public string Macaddress1 { get; set; }

        public string Email { get; set; }
        public string Hoja { get; set; }
        public string Archivo { get; set; }

        public CreacionEquiposModels() {}
    }

    public class TipoModel
    {
        public List<ListaTiposEquipos> listarTipos(int EmpresaUsuario)
        {
            SGR.SGRConsultas sgr = new SGR.SGRConsultas();
            string resp1, resp2;
            var tipoEquipo = sgr.EquiposXEmpresa(EmpresaUsuario.ToString(), out resp1, out resp2);

            List<ListaTiposEquipos> Listar = new List<ListaTiposEquipos>();
            Listar.Add(new ListaTiposEquipos() { Id = 0, NombreTipoEquipo = "Seleccione una opcion"});

            for (int i = 0; i < tipoEquipo.Length; i++)
            {
                for (int j = 0; j < tipoEquipo[i].equipos.Length; j++)
                {
                    ListaTiposEquipos listarNombre = new ListaTiposEquipos();

                    listarNombre.Id = int.Parse(tipoEquipo[i].equipos[j].codequipo);
                    listarNombre.NombreTipoEquipo = tipoEquipo[i].equipos[j].nomequipo;

                    Listar.Add(listarNombre);
                }
                
            }
            return Listar;
        }
    }

    public class ListaTiposEquipos
    {
        public int Id { get; set; }
        public String NombreTipoEquipo { get; set; }
    }

    public class Bodega
    {
        public List<ListaBodegaUsuario> listarTipos(int EmpresaUsuario, string Usuario)
        {
            /*SGRAprov.Aprovisionamiento invoke = new SGRAprov.Aprovisionamiento();
            SGRAprov.
            SGRAprov.HeaderRequest sgrheader = new SGRAprov.HeaderRequest();

            sgrheader.Aplicacion = "SGR";
            sgrheader.Controller = "DAC";
            sgrheader.System = "TV";
            

            SGRAprov.BodyRequest sgrbody = new SGRAprov.BodyRequest();*/



            SGR.SGRConsultas sgr = new SGR.SGRConsultas();
            string resp1, resp2;
            var BodegaUsuario = sgr.BodegasXUsuario(Usuario, EmpresaUsuario.ToString(), out resp1, out resp2);

            List<ListaBodegaUsuario> ListarBodega = new List<ListaBodegaUsuario>();
            ListarBodega.Add(new ListaBodegaUsuario() { CodAlmacen = "0", NomAlmacen = "Seleccione una opcion" });

            for (int i = 0; i < BodegaUsuario.Length; i++)
            {
                for (int j = 0; j < BodegaUsuario[i].almacenes.Length; j++)
                {
                    ListaBodegaUsuario listarNombre = new ListaBodegaUsuario();
                    listarNombre.CodAlmacen = BodegaUsuario[i].almacenes[j].codAlmacen;
                    listarNombre.NomAlmacen = BodegaUsuario[i].almacenes[j].nomAlmacen;
                    listarNombre.Ciudad = BodegaUsuario[i].almacenes[j].Ciudad;

                    ListarBodega.Add(listarNombre);
                }
            }

            return ListarBodega;
        }
    }


    public class ListaBodegaUsuario
    {
        public String CodAlmacen { get; set; }
        public String NomAlmacen { get; set; }
        public String Ciudad { get; set; }
    }


    public class Marcas
    {
        public List<ListaMarcas> listarTipos(int EmpresaUsuario, int tipo)
        {
            SGR.SGRConsultas sgr = new SGR.SGRConsultas();
            string resp1, resp2;
            var MarcaEquipo = sgr.ModelosXMarca(EmpresaUsuario.ToString(), tipo.ToString(), out resp1, out resp2);

            List<ListaMarcas> ListarMarca = new List<ListaMarcas>();
            ListarMarca.Add(new ListaMarcas() { IdMarca = "0", NomMarca = "Seleccione una opcion" });

            for (int i = 0; i < MarcaEquipo.tiposequipos.Length; i++)
            {
                for (int j = 0; j < MarcaEquipo.tiposequipos[i].marcas.Length; j++)
                {
                    ListaMarcas listarNombre = new ListaMarcas();
                    listarNombre.IdMarca = MarcaEquipo.tiposequipos[i].marcas[j].idmarca;
                    listarNombre.NomMarca = MarcaEquipo.tiposequipos[i].marcas[j].nommarca;

                    ListarMarca.Add(listarNombre);
                }
            }

            return ListarMarca;
        }
    }


    public class ListaMarcas
    {
        public String IdMarca { get; set; }
        public String NomMarca { get; set; }
    }


    public class Modelos
    {
        public List<ListaModelos> listarMarca(int EmpresaUsuario, int IdTipo, int idMarca)
        {
            SGR.SGRConsultas sgr = new SGR.SGRConsultas();
            string resp1, resp2;

            var ModeloEquipo = sgr.ModelosXMarca(EmpresaUsuario.ToString(), idMarca.ToString(), out resp1, out resp2);

            List<ListaModelos> ListarModelo = new List<ListaModelos>();
            ListarModelo.Add(new ListaModelos() { IdModelo = "0", NomModelo = "Seleccione una opcion" });

            for (int i = 0; i < ModeloEquipo.tiposequipos.Length; i++)
            {
                for (int j = 0; j < ModeloEquipo.tiposequipos[i].marcas.Length; j++)
                {
                    if (ModeloEquipo.tiposequipos[i].marcas[j].idmarca.Equals(IdTipo.ToString()))
                    {

                        for(int x = 0; x < ModeloEquipo.tiposequipos[i].marcas[j].modelos.Length; x++)
                        {
                                ListaModelos listarNombre = new ListaModelos();
                                listarNombre.IdModelo = ModeloEquipo.tiposequipos[i].marcas[j].modelos[x].idmodelo;
                                listarNombre.NomModelo = ModeloEquipo.tiposequipos[i].marcas[j].modelos[x].nommodelo;
                                ListarModelo.Add(listarNombre);
                        }
                    }
                    
                }
            }

            return ListarModelo;
        }
    }


    public class ListaModelos
    {
        public String IdModelo { get; set; }
        public String NomModelo { get; set; }
        public String CodArticulo { get; set; }
        public String NomArticulo { get; set; }
    }

}
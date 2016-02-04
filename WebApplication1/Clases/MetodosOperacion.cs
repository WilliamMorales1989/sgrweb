using System;
using System.Text;
using System.Collections;
using System.DirectoryServices;
using System.Web.Mvc;
using WebApplication1.Controllers;
using System.Web;

namespace FormsAuth
{
    public class MetodosOperacion : AuthorizeAttribute
    {
        private String _path;
        private String _filterAttribute;
        string w_UserAD;

        //- Método que separa el dominio y el usuario
        public void UsuarioId(string p_Username)
        {
            string w_Usuario;
            string w_Dominio;
            char[] delimiterChars = { '\\' };
            try
            {
                string[] Datos = p_Username.Split(delimiterChars);
                w_Dominio = Datos[0];
                w_Usuario = Datos[1];
                w_UserAD = w_Usuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        //- Método que valida el usuario en el Active Directory
        public bool ValidarUsuarioActiveDirectory(string _Path, string userId, string password)
        {
            DirectoryEntry deEntry = new DirectoryEntry(_Path, userId, password);
            DirectorySearcher dsSearcher = new DirectorySearcher(deEntry);
            bool bandera = false;
            try
            {
                UsuarioId(userId);
                dsSearcher.Filter = "(SAMAccountName=" + w_UserAD.Trim() + ")";
                dsSearcher.PropertiesToLoad.Add("cn");
                SearchResult result = dsSearcher.FindOne();
                if (!string.IsNullOrEmpty(result.ToString()))
                {
                    bandera = true;
                }
                else
                {
                    bandera = false;
                }
                _path = result.Path;
                _filterAttribute = (String)result.Properties["cn"][0];
            }
            catch (Exception)
            {
                return false;
            }
            return bandera;
        }

        public String ValidaRoles(string userId)
        {
            HttpContext ctx = System.Web.HttpContext.Current;

            MetodosOperacion MO = new MetodosOperacion();
            String domainAndUsername = "TVCABLEUIO" + @"\" + userId;
            //Administradores Gestion Mensajeria|Ingreso Campañas Gestion de Mensajeria
            String valor = MO.GetGroups(domainAndUsername, Roles);
            return valor;
        }

        [HttpPost]
        public String GetGroups(String _path, String roles)
        {
            //DirectoryEntry deEntry = new DirectoryEntry(_Path, userId, password);
            DirectorySearcher dsSearcher = new DirectorySearcher(_path);
            //bool bandera = false;            
            UsuarioId(_path);
            dsSearcher.Filter = "(SAMAccountName=" + w_UserAD.Trim() + ")";
            dsSearcher.PropertiesToLoad.Add("cn");
            SearchResult resultado = dsSearcher.FindOne();
            _path = resultado.Path;
            _filterAttribute = (String)resultado.Properties["cn"][0];

            DirectorySearcher search = new DirectorySearcher(_path);
            search.Filter = "(cn=" + _filterAttribute + ")";
            search.PropertiesToLoad.Add("memberOf");
            StringBuilder groupNames = new StringBuilder();

            try
            {
                SearchResult result = search.FindOne();

                int propertyCount = result.Properties["memberOf"].Count;

                String dn;
                int equalsIndex, commaIndex;

                for (int propertyCounter = 0; propertyCounter < propertyCount; propertyCounter++)
                {
                    dn = (String)result.Properties["memberOf"][propertyCounter];

                    equalsIndex = dn.IndexOf("=", 1);
                    commaIndex = dn.IndexOf(",", 1);
                    if (-1 == equalsIndex)
                    {
                        return null;
                    }

                    groupNames.Append(dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1));
                    groupNames.Append("|");

                }


            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los nombres de los grupos " + ex.Message);
            }

            return groupNames.ToString();

        }
    }
}
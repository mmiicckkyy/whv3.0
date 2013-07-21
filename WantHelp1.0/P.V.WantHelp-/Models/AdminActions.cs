using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P.V.WantHelp_.Models;
namespace P.V.WantHelp_.Models
{
    public class AdminActions
    {
        PlataformaVirtualEntities server;
        UsersContext userserver;
        public AdminActions()
        {
            server = new PlataformaVirtualEntities();
            userserver = new UsersContext();
        }
        /** Lista a los usuarios**/
        public List<UserProfile> getUsers()
        {
            return userserver.UserProfiles.ToList();
        }
        public List<Usuario> getUsuario()
        {
            return server.Usuario.ToList();
        }
        public List<webpages_Roles> getRoles()
        {
            return server.webpages_Roles.ToList();
        }
        public List<webpages_UsersInRoles> getRolesQueTieneUsuario(int idUser)
        {
            return server.webpages_UsersInRoles.Where(a => a.UserId == idUser).ToList();
        }
        /** Insertar **/
        public bool InsertarRol(webpages_Roles roles)
        {
            server.webpages_Roles.Add(roles);
            try
            {
                server.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool insertUsuarioRol(webpages_UsersInRoles roles_usuario)
        {
            server.webpages_UsersInRoles.Add(roles_usuario);
            try {
                server.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }
        public bool GuardarArchivo(ResultUpload archivo, int idUs)
        {
            Material mtrl = new Material()
            {
                Id_Usu =idUs,
                Id_Curso=1,
                archivos = archivo.fileroute,
                urlBase=archivo.fileroute,
                urlHost="http://localhost:2606/"+archivo.fileroute
            };
            server.Material.Add(mtrl);
            server.SaveChanges();
            return true;
        }
        internal List<Material> getFiles(int p)
        {
            return server.Material.Where(a => a.Id_Usu == p).ToList();
        }
        /** Get Id **/
        public Usuario getUsuario(int id)
        {
            return server.Usuario.Where(a => a.UserId == id).FirstOrDefault();
        }
        public UserProfile getUserPr(int id)
        {
            return userserver.UserProfiles.Where(a => a.UserId == id).First();
        }

        internal bool insertarRol(webpages_Roles roles)
        {
            throw new NotImplementedException();
        }

        public List<PermisosDeMenu> getpermisos(int idus)
        {
            List<PermisosDeMenu> resultado = server.webpages_UsersInRoles.
                Where(a => a.UserId == idus)
                .Select(b => new PermisosDeMenu()
                {
                    idRol = b.RoleId,
                    label = b.webpages_Roles.RoleName,
                    urls = b.webpages_Roles.UrlHost
                }).ToList();
            webpages_Roles p = new webpages_Roles();
            /*foreach (var item in resultado){
                item.url=p.urldireccion;
            }*/
            return resultado;
        }
        internal object getUserId(string p)
        {
            return userserver.UserProfiles.Where(a => a.UserName == p).FirstOrDefault().UserId;
        }
        public List<UserProfile> getUseRoles()
        {
            return userserver.UserProfiles.ToList();
        }
        internal int getUserIdUsuario(int p)
        {
            return server.Usuario.Where(a => a.UserId == p).FirstOrDefault().Id_Usu;
        }
    }
}
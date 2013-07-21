using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P.V.WantHelp_.Models;

namespace P.V.WantHelp_.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        [Authorize(Roles = "CrearRol")]
        public ActionResult CrearRoles()
        {

            return View();
        }
        [Authorize(Roles = "CrearRol")]
        [HttpPost]
        public ActionResult CrearRoles(webpages_Roles roles)
        {
            AdminActions contexto = new AdminActions();
            if (contexto.insertarRol(roles))
            {
                return View("RolInsertado");
            };
            return View();
        }
        [Authorize(Roles = "AsignarRoles")]
        public ActionResult Index()
        {
            AdminActions contexto = new AdminActions();
            List<UserProfile> Usuarios = contexto.getUsers();
            return View(Usuarios);
        }
        [Authorize(Roles = "AsignarRoles")]
        public ActionResult AsignarRol(int id)
        {
            AdminActions contexto = new AdminActions();
            UserProfile usuario = contexto.getUserPr(id);
            List<webpages_Roles> lista = contexto.getRoles();
            VistaRolesUsuario modelovista = new VistaRolesUsuario();
            modelovista.user = usuario;
            modelovista.rolesUser = lista;
            return View(modelovista);
        }
        [Authorize(Roles = "AsignarRoles")]
        public ActionResult AgregarRol(string id)
        {
            int idUs = Convert.ToInt32(id.Split('|')[0]);
            int idRol = Convert.ToInt32(id.Split('|')[1]);
            webpages_UsersInRoles rolAsignado = new webpages_UsersInRoles();
            rolAsignado.UserId = idUs;
            rolAsignado.RoleId = idRol;
            AdminActions contexto = new AdminActions();
            if (contexto.insertUsuarioRol(rolAsignado))
            {
                return View("exitoAsignacion");
            }

            return View();
        }
    }
}

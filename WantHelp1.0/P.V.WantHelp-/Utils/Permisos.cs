using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P.V.WantHelp_.Models;

namespace P.V.WantHelp_.Utils
{
    public class Permisos
    {
        private List<PermisosDeMenu> permisos;
        public Permisos(int idUs)
        {

            AdminActions contexto = new AdminActions();
            permisos = new List<PermisosDeMenu>();
            permisos = contexto.getpermisos(Convert.ToInt32(idUs));
        }
        public List<PermisosDeMenu> getPermisos()
        {
            return permisos;
        }
    }
}
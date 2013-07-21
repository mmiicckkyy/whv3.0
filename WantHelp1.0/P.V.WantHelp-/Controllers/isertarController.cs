using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P.V.WantHelp_.Models;

namespace P.V.WantHelp_.Controllers
{
    public class isertarController : Controller
    {
        //
        // GET: /isertar/

        public ActionResult crearusuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult crearusuario(Usuario user)
        {
            isertar contexto = new isertar();
            if (contexto.insertarusuario(user)) {
                return View("Index");
            }
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P.V.WantHelp_.Models;
using P.V.WantHelp_.Utils;
using WebMatrix.WebData;

namespace P.V.WantHelp_.Controllers
{
    public class RolesController : Controller
    {
        private contextodb db = new contextodb();

        //
        // GET: /Roles/

        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                Permisos check = new Permisos(Convert.ToInt32(Session["idus"]));
                ViewBag.Menus = check.getPermisos();
            };
            return View(db.webpages_Roles.ToList());
        }
        
        //
        // GET: /Roles/Details/5

        public ActionResult Details(int id = 0)
        {
            webpages_Roles webpages_roles = db.webpages_Roles.Find(id);
            if (webpages_roles == null)
            {
                return HttpNotFound();
            }
            return View(webpages_roles);
        }

        //
        // GET: /Roles/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create

        [HttpPost]
        public ActionResult Create(webpages_Roles webpages_roles)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    webpages_roles.UrlHost = "http://localhost:2606/" + webpages_roles.RoleName;
                    db.webpages_Roles.Add(webpages_roles);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(webpages_roles);

            }
            catch{
                
               return View("rolexistente");
            }
            
            
        }
        
        
        //
        // GET: /Roles/Edit/5

        public ActionResult Edit(int id = 0)
        {
            webpages_Roles webpages_roles = db.webpages_Roles.Find(id);
            if (webpages_roles == null)
            {
                return HttpNotFound();
            }
            return View(webpages_roles);
        }

        //
        // POST: /Roles/Edit/5

        [HttpPost]
        public ActionResult Edit(webpages_Roles webpages_roles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webpages_roles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(webpages_roles);
        }

        //
        // GET: /Roles/Delete/5

        public ActionResult Delete(int id = 0)
        {
            webpages_Roles webpages_roles = db.webpages_Roles.Find(id);
            if (webpages_roles == null)
            {
                return HttpNotFound();
            }
            return View(webpages_roles);
        }

        //
        // POST: /Roles/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                webpages_Roles webpages_roles = db.webpages_Roles.Find(id);
                db.webpages_Roles.Remove(webpages_roles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("asignado");
                
            }
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
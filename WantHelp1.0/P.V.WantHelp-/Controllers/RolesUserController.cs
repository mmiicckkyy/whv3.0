using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P.V.WantHelp_.Models;

namespace P.V.WantHelp_.Controllers
{
    public class RolesUserController : Controller
    {
        private contextodb db = new contextodb();

        //
        // GET: /RolesUser/

        public ActionResult Index()
        {
            var webpages_usersinroles = db.webpages_UsersInRoles.Include(w => w.webpages_Roles);
            return View(webpages_usersinroles.ToList());
        }

        //
        // GET: /RolesUser/Details/5

        public ActionResult Details(int id = 0)
        {
            webpages_UsersInRoles webpages_usersinroles = db.webpages_UsersInRoles.Find(id);
            if (webpages_usersinroles == null)
            {
                return HttpNotFound();
            }
            return View(webpages_usersinroles);
        }

        //
        // GET: /RolesUser/Create

        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.webpages_Roles, "RoleId", "RoleName");
            ViewBag.Id_Usu = new SelectList(db.Usuario, "Id_Usu", "Nombre");
            return View();
        }
        public ActionResult Crear()
        {
            /*Usuario uss = new Usuario();
            var usuar = uss.Nombre;*/
            ViewBag.RoleId = new SelectList(db.webpages_Roles,"Id_Usu","RoleName");
            return View();
        }

        //
        // POST: /RolesUser/Create

        [HttpPost]
        public ActionResult Create(webpages_UsersInRoles webpages_usersinroles, Usuario userrid)
        {
            if (ModelState.IsValid)
            {
                webpages_UsersInRoles wpur = new webpages_UsersInRoles();
                wpur.UserId = userrid.Id_Usu;
                wpur.RoleId = webpages_usersinroles.RoleId;
                //db.webpages_UsersInRoles.Add(webpages_usersinroles);
                db.webpages_UsersInRoles.Add(wpur);
                //if (wpur.RoleId==webpages_usersinroles.RoleId &&wpur.UserId==webpages_usersinroles.UserId)
                //return View("existeElRegistro");
                try { db.SaveChanges(); }
                catch { return View("existeElRegistro"); }

                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.webpages_Roles, "RoleId", "RoleName", webpages_usersinroles.RoleId);
            return View(webpages_usersinroles);
        }

        //
        // GET: /RolesUser/Edit/5

        public ActionResult Edit(int id = 0)
        {
            webpages_UsersInRoles webpages_usersinroles = db.webpages_UsersInRoles.Find(id);
            if (webpages_usersinroles == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.webpages_Roles, "RoleId", "RoleName", webpages_usersinroles.RoleId);
            return View(webpages_usersinroles);
        }

        //
        // POST: /RolesUser/Edit/5

        [HttpPost]
        public ActionResult Edit(webpages_UsersInRoles webpages_usersinroles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webpages_usersinroles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.webpages_Roles, "RoleId", "RoleName", webpages_usersinroles.RoleId);
            return View(webpages_usersinroles);
        }
        public ActionResult EditConfirmed()
        {
            
            return RedirectToAction("Create");


        }

        //
        // GET: /RolesUser/Delete/5

        public ActionResult Delete(int id = 0)
        {
            webpages_UsersInRoles webpages_usersinroles = db.webpages_UsersInRoles.Find(id);
            if (webpages_usersinroles == null)
            {
                return HttpNotFound();
            }
            return View(webpages_usersinroles);
        }

        //
        // POST: /RolesUser/Delete/5

        /*[HttpPost, ActionName("Delete")]*/
        public ActionResult DeleteConfirmed(string id)
        {
            int idUs = Convert.ToInt32(id.Split(' ')[0]);
            int idRol = Convert.ToInt32(id.Split(' ')[1]);

            webpages_UsersInRoles webpages_usersinroles = db.webpages_UsersInRoles.Where(a => a.RoleId == idRol && a.UserId == idUs).FirstOrDefault();
                db.webpages_UsersInRoles.Remove(webpages_usersinroles);
                db.SaveChanges();
                return RedirectToAction("Index");
            
                
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
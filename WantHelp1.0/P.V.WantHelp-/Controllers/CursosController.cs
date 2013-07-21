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
    public class CursosController : Controller
    {
        private contextodb db = new contextodb();

        //
        // GET: /Cursos/

        public ActionResult Index()
        {
            return View(db.Cursos.ToList());
        }

        //
        // GET: /Cursos/Details/5

        public ActionResult Details(int id = 0)
        {
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        //
        // GET: /Cursos/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cursos/Create

        [HttpPost]
        public ActionResult Create(Cursos cursos)
        {
            if (ModelState.IsValid)
            {
                db.Cursos.Add(cursos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cursos);
        }/*
        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Crear(Cursos Cursos, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if(image=!null)
                {
                    
                }
                AdminActions contexto= new AdminActions();
                Cursos curso = new Cursos();
                var data1 new byte[urlBase.ContentLength];
                urlBase.InputStream.Read(data1,0,urlBase.ContentLength);
                var path1=ControllerContext.HttpContext.Server.MapPath("/Content/Libros");
                var filename1 = Path.Combine(path1, Path.GetFileName(contenido.FileName));
                System.IO.File.WriteAllBytes(Path.Combine(path1, filename1), data1);
                curso.urlBase= (urlBase.FileName).ToString();
                
                curso.urlBase= 
            }
        }*/
        //
        // GET: /Cursos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        //
        // POST: /Cursos/Edit/5

        [HttpPost]
        public ActionResult Edit(Cursos cursos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cursos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cursos);
        }

        //
        // GET: /Cursos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        //
        // POST: /Cursos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cursos cursos = db.Cursos.Find(id);
            db.Cursos.Remove(cursos);
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
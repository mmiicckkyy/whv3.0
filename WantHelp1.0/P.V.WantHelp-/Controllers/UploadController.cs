/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P.V.WantHelp_.Models;
using WebMatrix.WebData;

namespace P.V.WantHelp_.Controllers
{
    public class UploadController : Controller
    {
        //
        // GET: /UploadController/

        public ActionResult Index()
        {
            return View();
        }
        public void guardar(ResultUpload datos)
        {
            AdminActions contexto = new AdminActions();
            Usuario user = contexto.getUsuario(WebSecurity.CurrentUserId);
            contexto.GuardarArchivos(datos, user.id);
        }
        /*
         Subir archivos
         *//*
        [HttpPost]
        public JsonResult SaveFiles()
        {
            HttpFileCollectionBase files = Request.Files;
            string path = Server.MapPath("~/archivos/");
            string nombres_de_arcnivos = "";
            string respuesta = "";
            for (int i = 0; i < files.Count; i++)
            {
                if (files[i].ContentLength > 0)
                {
                    string[] archivoenpartes = files[i].FileName.Split('.');
                    if (archivoenpartes.Length == 0)
                    {
                        respuesta = "false";
                        return Json(data: respuesta);
                    }
                    nombres_de_arcnivos += files[i].FileName + "|";
                    string extension = archivoenpartes[1];
                    string nombredearchivo = archivoenpartes[0];
                    string name = DateTime.Now.GetHashCode().ToString();
                    files[i].SaveAs(path + name + "." + extension);
                    respuesta += "/archivos/" + name + "." + extension;
                }
                else
                {
                    respuesta = "false";
                }
            }

            return Json(data: new ResultUpload() { filename = nombres_de_arcnivos, fileroute = respuesta });
        }
        public ActionResult getArchivos()
        {

            AdminActions contexto = new AdminActions();
            Usuario user = contexto.getUsuario(WebSecurity.CurrentUserId);
            List<files> lista;
            if (user != null)
                lista = contexto.getFiles(user.id);
            else
                lista = new List<files>();
            return View(lista);
        }
    }
}
*/
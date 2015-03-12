using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAlumnos.Models;

namespace WebAlumnos.Controllers
{
    public class CursosController : Controller
    {

        CursosEntities db = new CursosEntities();

        // GET: Cursos
        public ActionResult Index()
        {
            return View(db.Curso);
        }

        public ActionResult Alta()
        {
            return View(new Curso());
        }

        public ActionResult ListadoAjax()
        {
            return PartialView("Listado_cursos", db.Curso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alta(Curso model)
        {
            if (ModelState.IsValid)
            {
                db.Curso.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Borrar(int id)
        {
            var model = db.Curso.Find(id);

            try
            {
                db.Curso.Remove(model);
                db.SaveChanges();
            }
            catch (Exception ee)
            {
               Console.WriteLine(ee);
            }

            return RedirectToAction("Index");

        }

        public ActionResult Modificar(int id)
        {
            var curso = db.Curso.Find(id);

            return View(curso);
        }

        [HttpPost]
        public ActionResult Modificar(Curso model)
        {
            if (ModelState.IsValid)
            {
                var m = db.Curso.Find(model.id);
                m.nombre = model.nombre;
                m.inicio = model.inicio;
                m.fin = model.fin;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult AltaAjax(Curso model)
        {
            db.Curso.Add(model);

            try
            {
                db.SaveChanges();
                return Json("OK");
            }
            catch (Exception ee)
            {
                return Json("Error");
            }
        }

        // Cuando destruya el controlador cierra la conexion. Evitamos usar "using", que daba problemas con el "lazy loading".
        protected override void Dispose(bool disposing)
        {
         base.Dispose(disposing);
            db.Dispose();
        }

    }
}
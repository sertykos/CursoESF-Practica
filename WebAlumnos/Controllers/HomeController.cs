using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAlumnos.Models;

namespace WebAlumnos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new CursosEntities();            
                return View(db.Alumnos.ToList());
                 
        }

        public ActionResult Alta()
        {
            return View(new Alumnos());
        }

        [HttpPost]
        public ActionResult Alta(Alumnos model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new CursosEntities())
                {
                    db.Alumnos.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Buscar()
        {
            var bus = Request.Form["busqueda"];

            var db = new CursosEntities();

            var al = db.Alumnos.Where(o => o.apellidos.Contains(bus));
            return View(al);
        }
        
    }
}
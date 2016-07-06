using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using examenII_Lenguajes;

namespace examenII_Lenguajes.Controllers
{
    public class EstudianteController : Controller
    {
        private DBExamenContext1 db = new DBExamenContext1();

        // GET: Estudiante
        public ActionResult Index()
        {
            return View(db.tbEstudiante.ToList());
        }

        // GET: Estudiante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEstudiante tbEstudiante = db.tbEstudiante.Find(id);
            if (tbEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(tbEstudiante);
        }

        // GET: Estudiante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudiante/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEstudiante,carnet,nombre,apellido1,apellido2")] tbEstudiante tbEstudiante)
        {
            if (ModelState.IsValid)
            {
                db.tbEstudiante.Add(tbEstudiante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbEstudiante);
        }

        // GET: Estudiante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEstudiante tbEstudiante = db.tbEstudiante.Find(id);
            if (tbEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(tbEstudiante);
        }

        // POST: Estudiante/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEstudiante,carnet,nombre,apellido1,apellido2")] tbEstudiante tbEstudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbEstudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbEstudiante);
        }

        // GET: Estudiante/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEstudiante tbEstudiante = db.tbEstudiante.Find(id);
            if (tbEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(tbEstudiante);
        }

        // POST: Estudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbEstudiante tbEstudiante = db.tbEstudiante.Find(id);
            db.tbEstudiante.Remove(tbEstudiante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

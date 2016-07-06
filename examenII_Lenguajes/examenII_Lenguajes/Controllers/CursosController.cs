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
    public class CursosController : Controller
    {
        private DBExamenContext1 db = new DBExamenContext1();

        // GET: Cursos
        public ActionResult Index()
        {
            return View(db.tbCurso.ToList());
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCurso tbCurso = db.tbCurso.Find(id);
            if (tbCurso == null)
            {
                return HttpNotFound();
            }
            return View(tbCurso);
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCurso,nombre,creditos,descripcion")] tbCurso tbCurso)
        {
            if (ModelState.IsValid)
            {
                db.tbCurso.Add(tbCurso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbCurso);
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCurso tbCurso = db.tbCurso.Find(id);
            if (tbCurso == null)
            {
                return HttpNotFound();
            }
            return View(tbCurso);
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCurso,nombre,creditos,descripcion")] tbCurso tbCurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbCurso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbCurso);
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCurso tbCurso = db.tbCurso.Find(id);
            if (tbCurso == null)
            {
                return HttpNotFound();
            }
            return View(tbCurso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbCurso tbCurso = db.tbCurso.Find(id);
            db.tbCurso.Remove(tbCurso);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MisionTIC.Models;

namespace MisionTIC.Controllers
{
    public class CopiasController : Controller
    {
        private BibliotecaTicEntities db = new BibliotecaTicEntities();

        // GET: Copias
        public ActionResult Index()
        {
            var copia = db.Copia.Include(c => c.Libro);
            return View(copia.ToList());
        }

        // GET: Copias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Copia copia = db.Copia.Find(id);
            if (copia == null)
            {
                return HttpNotFound();
            }
            return View(copia);
        }

        // GET: Copias/Create
        public ActionResult Create()
        {
            ViewBag.IdLibro = new SelectList(db.Libro, "IdLibro", "NombreLibro");
            return View();
        }

        // POST: Copias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCopia,Estado,IdLibro")] Copia copia)
        {
            if (ModelState.IsValid)
            {
                db.Copia.Add(copia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLibro = new SelectList(db.Libro, "IdLibro", "TipoLibro", copia.IdLibro);
            return View(copia);
        }

        // GET: Copias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Copia copia = db.Copia.Find(id);
            if (copia == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLibro = new SelectList(db.Libro, "IdLibro", "TipoLibro", copia.IdLibro);
            return View(copia);
        }

        // POST: Copias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCopia,Estado,IdLibro")] Copia copia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(copia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLibro = new SelectList(db.Libro, "IdLibro", "TipoLibro", copia.IdLibro);
            return View(copia);
        }

        // GET: Copias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Copia copia = db.Copia.Find(id);
            if (copia == null)
            {
                return HttpNotFound();
            }
            return View(copia);
        }

        // POST: Copias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Copia copia = db.Copia.Find(id);
            db.Copia.Remove(copia);
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

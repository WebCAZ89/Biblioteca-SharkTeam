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
    public class LectorsController : Controller
    {
        private BibliotecaTicEntities db = new BibliotecaTicEntities();

        // GET: Lectors
        public ActionResult Index()
        {
            return View(db.Lector.ToList());
        }

        // GET: Lectors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lector lector = db.Lector.Find(id);
            if (lector == null)
            {
                return HttpNotFound();
            }
            return View(lector);
        }

        // GET: Lectors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lectors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Identifiacion,NombreLector,FechaNacimientoLec,TelefonoLector,CorreoLector")] Lector lector)
        {
            if (ModelState.IsValid)
            {
                db.Lector.Add(lector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lector);
        }

        // GET: Lectors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lector lector = db.Lector.Find(id);
            if (lector == null)
            {
                return HttpNotFound();
            }
            return View(lector);
        }

        // POST: Lectors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Identifiacion,NombreLector,FechaNacimientoLec,TelefonoLector,CorreoLector")] Lector lector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lector);
        }

        // GET: Lectors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lector lector = db.Lector.Find(id);
            if (lector == null)
            {
                return HttpNotFound();
            }
            return View(lector);
        }

        // POST: Lectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lector lector = db.Lector.Find(id);
            db.Lector.Remove(lector);
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

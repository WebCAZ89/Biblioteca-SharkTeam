using MisionTIC.Models;
using MisionTIC.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MisionTIC.Controllers
{
    public class LibrosController : Controller
    {
        // Lista
        public ActionResult Lista()
        {

            BibliotecaTicEntities db = new BibliotecaTicEntities();
            List<Libro> list = db.Libro.ToList();

            db.Dispose();               
            return View(list);
        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(Libro model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BibliotecaTicEntities db = new BibliotecaTicEntities();
                    db.Libro.Add(model);

                    db.SaveChanges();
                    db.Dispose();

                    return Redirect("~/Libros/Lista");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Editar(int Id)
        {
            BibliotecaTicEntities db = new BibliotecaTicEntities();
            Libro d = db.Libro.Where(x => x.IdLibro == Id).FirstOrDefault();

            db.Dispose();
            return View(d);
        }
        [HttpPost]
        public ActionResult Save(Libro s)
        {
            BibliotecaTicEntities db = new BibliotecaTicEntities();
            Libro d = db.Libro.Where(x => x.IdLibro == s.IdLibro).FirstOrDefault();

            d.NombreLibro = s.NombreLibro;
            d.TipoLibro = s.TipoLibro;
            d.EditorialLibro = s.EditorialLibro;
            d.AnoLibro = s.AnoLibro;
            d.IdAutor = s.IdAutor;

            db.SaveChanges();
            db.Dispose();
            return Redirect("~/Libros/Lista");
        }
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            Libro model = new Libro();
            using (BibliotecaTicEntities db = new BibliotecaTicEntities())
            {
                var oTabla = db.Libro.Find(Id);
                db.Libro.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Libros/Lista");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using MisionTIC.Models;
using MisionTIC.Models.viewModels;

namespace MisionTIC.Controllers
{
    public class AutoresController : Controller
    {
        // GET: Autor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Lista()
        {
            List<Autors> list;
            using (BibliotecaTicEntities db = new BibliotecaTicEntities())
            {
                list = (from d in db.Autor
                        select new Autors
                        {
                            Id = d.IdAutor,
                            Nombre = d.NombreAutor,
                            Nacionalidad = d.NacionalidadAutor,
                            FechaNacimiento = (DateTime)d.FechaNacimientoAutor
                        }).ToList();
            }
            return View(list);
        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(Autors model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BibliotecaTicEntities db = new BibliotecaTicEntities())
                    {
                        var oTabla = new Autor();
                        oTabla.NombreAutor = model.Nombre;
                        oTabla.NacionalidadAutor = model.Nacionalidad;
                        oTabla.FechaNacimientoAutor = model.FechaNacimiento;

                        db.Autor.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Autores/Lista");
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
            Autors model = new Autors();
            using (BibliotecaTicEntities db = new BibliotecaTicEntities())
            {
                var oTabla = db.Autor.Find(Id);
                model.Nombre = oTabla.NombreAutor;
                model.Nacionalidad = oTabla.NacionalidadAutor;
                model.FechaNacimiento = (DateTime)oTabla.FechaNacimientoAutor;
                model.Id = oTabla.IdAutor;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(Autors model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BibliotecaTicEntities db = new BibliotecaTicEntities())
                    {
                        var oTabla = db.Autor.Find(model.Id);
                        oTabla.NombreAutor = model.Nombre;
                        oTabla.NacionalidadAutor = model.Nacionalidad;
                        oTabla.FechaNacimientoAutor = model.FechaNacimiento;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Autores/Lista");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            Autors model = new Autors();
            using (BibliotecaTicEntities db = new BibliotecaTicEntities())
            {
                var oTabla = db.Autor.Find(Id);
                db.Autor.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Autores/Lista");
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MisionTIC.Models;
using MisionTIC.Models.viewModels;

namespace MisionTIC.Controllers
{
    public class AutorController : Controller
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
                                Id = d.Id,
                                Nombre = d.Nombre,
                                Nacionalidad = d.Nacionalidad,
                                FechaNacimiento = (DateTime)d.FechaNacimiento
                            }).ToList();
            }
            return View(list);
        }
    }
}
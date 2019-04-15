using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TesteCDMedico.Controllers
{
    public class PaisesController : Controller
    {
        private CadeMedicoEntities db = new CadeMedicoEntities();

        // GET: Paises
        public ActionResult Index()
        {
            return View(db.PAISES.ToList());

        }
        public ActionResult Adicionar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Adicionar(PAISES pais)
        {
            if (ModelState.IsValid)
            {
                db.PAISES.Add(pais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(pais);

        }

        public ActionResult Editar(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAISES pais = db.PAISES.Find(id);
            if (pais == null)
            {

                return HttpNotFound();
            }

            return View(pais);



        }

        [HttpPost]
        public ActionResult Editar(PAISES pais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pais);
        }
        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           PAISES pais = db.PAISES.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(long id)
        {
            PAISES pais = db.PAISES.Find(id);
            db.PAISES.Remove(pais);
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
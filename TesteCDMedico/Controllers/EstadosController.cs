using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TesteCDMedico.Controllers
{
    public class EstadosController : Controller
    {
        // GET: Estados
        private CadeMedicoEntities db = new CadeMedicoEntities();
        public ActionResult Index()

        {
            var estado = db.ESTADOS.Include(m => m.PAISES).ToList();
           
            return View(estado);
        }
        public ActionResult Adicionar()

        {
            ViewBag.IDPais = new SelectList(db.PAISES, "IDPais","Pais");

            return View();
        }
        [HttpPost]
        public ActionResult Adicionar(ESTADOS estado)
        {
            if (ModelState.IsValid)
            {
                db.ESTADOS.Add(estado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPais = new SelectList(db.PAISES, "IDPais","Pais");
         
            return View();
        }


        public ActionResult Editar(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           ESTADOS estado = db.ESTADOS.Find(id);
            if (estado == null)
            {

                return HttpNotFound();
            }

            ViewBag.IDPais = new SelectList(db.PAISES, "IDPais","Pais", estado.IDPais);

            return View(estado);



        }

        [HttpPost]
        public ActionResult Editar(ESTADOS estado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPaise = new SelectList(db.PAISES, "IDPais","Pais", estado.IDPais);

            return View(estado);
        }
        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           ESTADOS estado = db.ESTADOS.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(long id)
        {
            ESTADOS estado = db.ESTADOS.Find(id);
            db.ESTADOS.Remove(estado);
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
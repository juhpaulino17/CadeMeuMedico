using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TesteCDMedico.Controllers
{
    public class CidadesController : Controller
    { // GET: Medicos
        private CadeMedicoEntities db = new CadeMedicoEntities();
        public ActionResult Index()
        {
            var cidade = db.CIDADES.Include(m => m.ESTADOS).ToList();
            return View(cidade);
        }
        public ActionResult Adicionar()

        {
            ViewBag.IDEstados = new SelectList(db.ESTADOS, "IDEstados","Estado");
        
            return View();
        }
        [HttpPost]
        public ActionResult Adicionar(CIDADES cidade)
        {
            if (ModelState.IsValid)
            {
                db.CIDADES.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDEstados = new SelectList(db.ESTADOS, "IDEstados","Estado");
           
            return View(cidade);
        }


        public ActionResult Editar(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CIDADES cidade = db.CIDADES.Find(id);
            if (cidade == null)
                {

                return HttpNotFound();
            }

            ViewBag.IDEstados = new SelectList(db.ESTADOS, "IDEstados", "Estado", cidade.IDEstados);

            return View(cidade);
            

    
        }

        [HttpPost]
        public ActionResult Editar(CIDADES cidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDEstados = new SelectList(db.ESTADOS, "IDEstados", "Estado", cidade.IDEstados);

            return View(cidade);
        }
        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CIDADES cidade = db.CIDADES.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }
            [HttpPost,ActionName("Excluir")]
            [ValidateAntiForgeryToken]
            public ActionResult Excluir (long id)
        {
            CIDADES cidade= db.CIDADES.Find(id);
            db.CIDADES.Remove(cidade);
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
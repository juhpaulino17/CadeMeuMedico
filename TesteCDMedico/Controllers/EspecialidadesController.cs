using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TesteCDMedico.Controllers
{
    public class EspecialidadesController : Controller

    {
        private CadeMedicoEntities db = new CadeMedicoEntities();

        // GET: ESPECIALIDADES
        public ActionResult Index()
        {
            return View(db.ESPECIALIDADES.ToList());

        }
        public ActionResult Adicionar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Adicionar(ESPECIALIDADES especialidade)
        {
            if (ModelState.IsValid)
            {
                db.ESPECIALIDADES.Add(especialidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(especialidade);

        }

        public ActionResult Editar(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult (HttpStatusCode.BadRequest);
            }
           ESPECIALIDADES especialidade= db.ESPECIALIDADES.Find(id);
            if (especialidade == null)
            {

                return HttpNotFound();
            }

            return View(especialidade);



        }

        [HttpPost]
        public ActionResult Editar(ESPECIALIDADES especialidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        
            return View(especialidade);
        }
        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           ESPECIALIDADES especialidade = db.ESPECIALIDADES.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(especialidade);
        }
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(long id)
        {
          ESPECIALIDADES especialidade = db.ESPECIALIDADES.Find(id);
            db.ESPECIALIDADES.Remove(especialidade);
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

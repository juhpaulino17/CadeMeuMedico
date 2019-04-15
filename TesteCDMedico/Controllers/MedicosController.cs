using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace TesteCDMedico.Controllers
{
    public class MedicosController : Controller
    {
        // GET: Medicos
        private CadeMedicoEntities db = new CadeMedicoEntities();
        public ActionResult Index()
        {
            var medico = db.MEDICOS.Include(m => m.CIDADES).Include(m => m.ESPECIALIDADES).ToList();
            return View(medico);
        }
        public ActionResult Adicionar()

        {
            ViewBag.IDCidade = new SelectList(db.CIDADES, "IDCidade", "Cidade");
            ViewBag.IDEspecialidade = new SelectList(db.ESPECIALIDADES, "IDEspecialidades", "Especialidade");

            return View();
        }
        [HttpPost]
        public ActionResult Adicionar(MEDICOS medico)
        {
            if (ModelState.IsValid)
            {
                db.MEDICOS.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCidade = new SelectList(db.CIDADES, "IDCidade", "Cidade", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.ESPECIALIDADES, "IDEspecialidades", "Especialidade", medico.IDEspecialidade);

            return View(medico);
        }


        public ActionResult Editar(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEDICOS medico = db.MEDICOS.Find(id);
            if (medico == null)
                {

                return HttpNotFound();
            }

            ViewBag.IDCidade = new SelectList(db.CIDADES, "IDCidade", "Cidade", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.ESPECIALIDADES, "IDEspecialidades", "Especialidade", medico.IDEspecialidade);
            return View(medico);
            

    
        }

        [HttpPost]
        public ActionResult Editar(MEDICOS medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCidade = new SelectList(db.CIDADES, "IDCidade", "Cidade", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.ESPECIALIDADES, "IDEspecialidades", "Especialidade", medico.IDEspecialidade);
            return View(medico);
        }
        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEDICOS medico = db.MEDICOS.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }
            [HttpPost,ActionName("Excluir")]
            [ValidateAntiForgeryToken]
            public ActionResult Excluir (long id)
        {
            MEDICOS medico = db.MEDICOS.Find(id);
            db.MEDICOS.Remove(medico);
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


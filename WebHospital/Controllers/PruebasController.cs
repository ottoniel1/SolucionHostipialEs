using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebHospital.Models;

namespace WebHospital.Controllers
{
    public class PruebasController : Controller
    {
        private bd_hospitalEscUAIEntities db = new bd_hospitalEscUAIEntities();

        // GET: Pruebas
        public ActionResult Index()
        {
            var prueba = db.Prueba.Include(p => p.Paciente);
            return View(prueba.ToList());
        }

        // GET: Pruebas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prueba prueba = db.Prueba.Find(id);
            if (prueba == null)
            {
                return HttpNotFound();
            }
            return View(prueba);
        }

        // GET: Pruebas/Create
        public ActionResult Create()
        {
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "Codigo_paciente");
            return View();
        }

        // POST: Pruebas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idprueba,idPaciente,prueba_rapVIH,carga_viral,CD4,cripto,histo,TB_lam,comentario,estado")] Prueba prueba)
        {
            if (ModelState.IsValid)
            {
                db.Prueba.Add(prueba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "Codigo_paciente", prueba.idPaciente);
            return View(prueba);
        }

        // GET: Pruebas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prueba prueba = db.Prueba.Find(id);
            if (prueba == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "Codigo_paciente", prueba.idPaciente);
            return View(prueba);
        }

        // POST: Pruebas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idprueba,idPaciente,prueba_rapVIH,carga_viral,CD4,cripto,histo,TB_lam,comentario,estado")] Prueba prueba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prueba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "Codigo_paciente", prueba.idPaciente);
            return View(prueba);
        }

        // GET: Pruebas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prueba prueba = db.Prueba.Find(id);
            if (prueba == null)
            {
                return HttpNotFound();
            }
            return View(prueba);
        }

        // POST: Pruebas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prueba prueba = db.Prueba.Find(id);
            db.Prueba.Remove(prueba);
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

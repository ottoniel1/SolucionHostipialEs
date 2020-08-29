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
    public class TipopacientesController : Controller
    {
        private bd_hospitalEscUAIEntities db = new bd_hospitalEscUAIEntities();

        // GET: Tipopacientes
        public ActionResult Index()
        {
            var tablatipopaciente = from EP in db.Tipopaciente
                                    where EP.estado == true
                                   select EP;
            return View(tablatipopaciente.ToList());
            
        }

        // GET: Tipopacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipopaciente tipopaciente = db.Tipopaciente.Find(id);
            if (tipopaciente == null)
            {
                return HttpNotFound();
            }
            return View(tipopaciente);
        }

        // GET: Tipopacientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipopacientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtipopaciente,iniciales,descripciontipopaciente,estado")] Tipopaciente tipopaciente)
        {
            if (ModelState.IsValid)
            {
                db.Tipopaciente.Add(tipopaciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipopaciente);
        }

        // GET: Tipopacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipopaciente tipopaciente = db.Tipopaciente.Find(id);
            if (tipopaciente == null)
            {
                return HttpNotFound();
            }
            return View(tipopaciente);
        }

        // POST: Tipopacientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtipopaciente,iniciales,descripciontipopaciente,estado")] Tipopaciente tipopaciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipopaciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipopaciente);
        }

        // GET: Tipopacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipopaciente tipopaciente = db.Tipopaciente.Find(id);
            if (tipopaciente == null)
            {
                return HttpNotFound();
            }
            return View(tipopaciente);
        }

        // POST: Tipopacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipopaciente tipopaciente = db.Tipopaciente.Find(id);
            db.Tipopaciente.Remove(tipopaciente);
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

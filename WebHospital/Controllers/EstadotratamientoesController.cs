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
    public class EstadotratamientoesController : Controller
    {
        private bd_hospitalEscUAIEntities db = new bd_hospitalEscUAIEntities();

        // GET: Estadotratamientoes
        public ActionResult Index()
        {
            return View(db.Estadotratamiento.ToList());
        }

        // GET: Estadotratamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadotratamiento estadotratamiento = db.Estadotratamiento.Find(id);
            if (estadotratamiento == null)
            {
                return HttpNotFound();
            }
            return View(estadotratamiento);
        }

        // GET: Estadotratamientoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estadotratamientoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idestadotratamiento,Estadotratamiento1,estado")] Estadotratamiento estadotratamiento)
        {
            if (ModelState.IsValid)
            {
                db.Estadotratamiento.Add(estadotratamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadotratamiento);
        }

        // GET: Estadotratamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadotratamiento estadotratamiento = db.Estadotratamiento.Find(id);
            if (estadotratamiento == null)
            {
                return HttpNotFound();
            }
            return View(estadotratamiento);
        }

        // POST: Estadotratamientoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idestadotratamiento,Estadotratamiento1,estado")] Estadotratamiento estadotratamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadotratamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadotratamiento);
        }

        // GET: Estadotratamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadotratamiento estadotratamiento = db.Estadotratamiento.Find(id);
            if (estadotratamiento == null)
            {
                return HttpNotFound();
            }
            return View(estadotratamiento);
        }

        // POST: Estadotratamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estadotratamiento estadotratamiento = db.Estadotratamiento.Find(id);
            db.Estadotratamiento.Remove(estadotratamiento);
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

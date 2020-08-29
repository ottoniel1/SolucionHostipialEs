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
    public class EstadopacientesController : Controller
    {
        private bd_hospitalEscUAIEntities db = new bd_hospitalEscUAIEntities();

        // GET: Estadopacientes
        public ActionResult Index()
        {
            return View(db.Estadopaciente.ToList());
        }

        // GET: Estadopacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadopaciente estadopaciente = db.Estadopaciente.Find(id);
            if (estadopaciente == null)
            {
                return HttpNotFound();
            }
            return View(estadopaciente);
        }

        // GET: Estadopacientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estadopacientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEstadopaciente,estadodelpaciente,fecha_estadop,estado")] Estadopaciente estadopaciente)
        {
            if (ModelState.IsValid)
            {
                db.Estadopaciente.Add(estadopaciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadopaciente);
        }

        // GET: Estadopacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadopaciente estadopaciente = db.Estadopaciente.Find(id);
            if (estadopaciente == null)
            {
                return HttpNotFound();
            }
            return View(estadopaciente);
        }

        // POST: Estadopacientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEstadopaciente,estadodelpaciente,fecha_estadop,estado")] Estadopaciente estadopaciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadopaciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadopaciente);
        }

        // GET: Estadopacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadopaciente estadopaciente = db.Estadopaciente.Find(id);
            if (estadopaciente == null)
            {
                return HttpNotFound();
            }
            return View(estadopaciente);
        }

        // POST: Estadopacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estadopaciente estadopaciente = db.Estadopaciente.Find(id);
            db.Estadopaciente.Remove(estadopaciente);
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

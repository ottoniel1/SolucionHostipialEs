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
    public class TratamientoesController : Controller
    {
        private bd_hospitalEscUAIEntities db = new bd_hospitalEscUAIEntities();

        // GET: Tratamientoes
        public ActionResult Index()
        {
            var tratamiento = db.Tratamiento.Include(t => t.Estadotratamiento).Include(t => t.Paciente);
            return View(tratamiento.ToList());
        }

        // GET: Tratamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento tratamiento = db.Tratamiento.Find(id);
            if (tratamiento == null)
            {
                return HttpNotFound();
            }
            return View(tratamiento);
        }

        // GET: Tratamientoes/Create
        public ActionResult Create()
        {
            ViewBag.idestadotratamiento = new SelectList(db.Estadotratamiento, "idestadotratamiento", "Estadotratamiento1");
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "Codigo_paciente");
            return View();
        }

        // POST: Tratamientoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtratamiento,idPaciente,idestadotratamiento,fecha_inicio,nombre_tratamiento,descripcion_tratamiento,estado")] Tratamiento tratamiento)
        {
            if (ModelState.IsValid)
            {
                db.Tratamiento.Add(tratamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idestadotratamiento = new SelectList(db.Estadotratamiento, "idestadotratamiento", "Estadotratamiento1", tratamiento.idestadotratamiento);
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "Codigo_paciente", tratamiento.idPaciente);
            return View(tratamiento);
        }

        // GET: Tratamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento tratamiento = db.Tratamiento.Find(id);
            if (tratamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idestadotratamiento = new SelectList(db.Estadotratamiento, "idestadotratamiento", "Estadotratamiento1", tratamiento.idestadotratamiento);
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "Codigo_paciente", tratamiento.idPaciente);
            return View(tratamiento);
        }

        // POST: Tratamientoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtratamiento,idPaciente,idestadotratamiento,fecha_inicio,nombre_tratamiento,descripcion_tratamiento,estado")] Tratamiento tratamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tratamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idestadotratamiento = new SelectList(db.Estadotratamiento, "idestadotratamiento", "Estadotratamiento1", tratamiento.idestadotratamiento);
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "Codigo_paciente", tratamiento.idPaciente);
            return View(tratamiento);
        }

        // GET: Tratamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento tratamiento = db.Tratamiento.Find(id);
            if (tratamiento == null)
            {
                return HttpNotFound();
            }
            return View(tratamiento);
        }

        // POST: Tratamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tratamiento tratamiento = db.Tratamiento.Find(id);
            db.Tratamiento.Remove(tratamiento);
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

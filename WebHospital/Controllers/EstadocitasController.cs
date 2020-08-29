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
    public class EstadocitasController : Controller
    {
        private bd_hospitalEscUAIEntities db = new bd_hospitalEscUAIEntities();

        // GET: Estadocitas
        public ActionResult Index()
        {
            var estadocita = db.Estadocita.Include(e => e.Cita).Include(e => e.Medicamento).Include(e => e.Paciente);
            return View(estadocita.ToList());
        }

        // GET: Estadocitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadocita estadocita = db.Estadocita.Find(id);
            if (estadocita == null)
            {
                return HttpNotFound();
            }
            return View(estadocita);
        }

        // GET: Estadocitas/Create
        public ActionResult Create()
        {
            ViewBag.idcita = new SelectList(db.Cita, "idcita", "idcita");
            ViewBag.idmedicamento = new SelectList(db.Medicamento, "idmedicamento", "Nombre_medicamento");
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "Codigo_paciente");
            return View();
        }

        // POST: Estadocitas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEstadocita,idcita,idPaciente,idmedicamento,fecha_estadocita,estado_citap,estado")] Estadocita estadocita)
        {
            if (ModelState.IsValid)
            {
                db.Estadocita.Add(estadocita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcita = new SelectList(db.Cita, "idcita", "idcita", estadocita.idcita);
            ViewBag.idmedicamento = new SelectList(db.Medicamento, "idmedicamento", "Nombre_medicamento", estadocita.idmedicamento);
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "Codigo_paciente", estadocita.idPaciente);
            return View(estadocita);
        }

        // GET: Estadocitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadocita estadocita = db.Estadocita.Find(id);
            if (estadocita == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcita = new SelectList(db.Cita, "idcita", "idcita", estadocita.idcita);
            ViewBag.idmedicamento = new SelectList(db.Medicamento, "idmedicamento", "Nombre_medicamento", estadocita.idmedicamento);
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "Codigo_paciente", estadocita.idPaciente);
            return View(estadocita);
        }

        // POST: Estadocitas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEstadocita,idcita,idPaciente,idmedicamento,fecha_estadocita,estado_citap,estado")] Estadocita estadocita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadocita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcita = new SelectList(db.Cita, "idcita", "idcita", estadocita.idcita);
            ViewBag.idmedicamento = new SelectList(db.Medicamento, "idmedicamento", "Nombre_medicamento", estadocita.idmedicamento);
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "Codigo_paciente", estadocita.idPaciente);
            return View(estadocita);
        }

        // GET: Estadocitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadocita estadocita = db.Estadocita.Find(id);
            if (estadocita == null)
            {
                return HttpNotFound();
            }
            return View(estadocita);
        }

        // POST: Estadocitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estadocita estadocita = db.Estadocita.Find(id);
            db.Estadocita.Remove(estadocita);
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

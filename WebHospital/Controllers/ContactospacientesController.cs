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
    public class ContactospacientesController : Controller
    {
        private bd_hospitalEscUAIEntities db = new bd_hospitalEscUAIEntities();

        // GET: Contactospacientes
        public ActionResult Index()
        {
            var contactospaciente = db.Contactospaciente.Include(c => c.Departamento).Include(c => c.Municipio).Include(c => c.Paciente);
            return View(contactospaciente.ToList());
        }

        // GET: Contactospacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contactospaciente contactospaciente = db.Contactospaciente.Find(id);
            if (contactospaciente == null)
            {
                return HttpNotFound();
            }
            return View(contactospaciente);
        }

        // GET: Contactospacientes/Create
        public ActionResult Create()
        {
            ViewBag.idDepartamento = new SelectList(db.Departamento, "idDepartamento", "Nombre_depto");
            ViewBag.idMunicipio = new SelectList(db.Municipio, "idMunicipio", "Nombre_muni");
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "Codigo_paciente");
            return View();
        }

        // POST: Contactospacientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idcontactospaciente,idPaciente,nombre_contacto1,nombre_contacto2,apellido_contacto1,apellido_contacto2,telefono,direccion,idDepartamento,idMunicipio,estado")] Contactospaciente contactospaciente)
        {
            if (ModelState.IsValid)
            {
                db.Contactospaciente.Add(contactospaciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDepartamento = new SelectList(db.Departamento, "idDepartamento", "Nombre_depto", contactospaciente.idDepartamento);
            ViewBag.idMunicipio = new SelectList(db.Municipio, "idMunicipio", "Nombre_muni", contactospaciente.idMunicipio);
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "Codigo_paciente", contactospaciente.idPaciente);
            return View(contactospaciente);
        }

        // GET: Contactospacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contactospaciente contactospaciente = db.Contactospaciente.Find(id);
            if (contactospaciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDepartamento = new SelectList(db.Departamento, "idDepartamento", "Nombre_depto", contactospaciente.idDepartamento);
            ViewBag.idMunicipio = new SelectList(db.Municipio, "idMunicipio", "Nombre_muni", contactospaciente.idMunicipio);
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "Codigo_paciente", contactospaciente.idPaciente);
            return View(contactospaciente);
        }

        // POST: Contactospacientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idcontactospaciente,idPaciente,nombre_contacto1,nombre_contacto2,apellido_contacto1,apellido_contacto2,telefono,direccion,idDepartamento,idMunicipio,estado")] Contactospaciente contactospaciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactospaciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDepartamento = new SelectList(db.Departamento, "idDepartamento", "Nombre_depto", contactospaciente.idDepartamento);
            ViewBag.idMunicipio = new SelectList(db.Municipio, "idMunicipio", "Nombre_muni", contactospaciente.idMunicipio);
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "Codigo_paciente", contactospaciente.idPaciente);
            return View(contactospaciente);
        }

        // GET: Contactospacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contactospaciente contactospaciente = db.Contactospaciente.Find(id);
            if (contactospaciente == null)
            {
                return HttpNotFound();
            }
            return View(contactospaciente);
        }

        // POST: Contactospacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contactospaciente contactospaciente = db.Contactospaciente.Find(id);
            db.Contactospaciente.Remove(contactospaciente);
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

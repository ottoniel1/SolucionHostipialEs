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
    public class PacientesController : Controller
    {
        private bd_hospitalEscUAIEntities db = new bd_hospitalEscUAIEntities();

        // GET: Pacientes
        public ActionResult Index()
        {
            var paciente = db.Paciente.Include(p => p.Departamento).Include(p => p.Estadopaciente).Include(p => p.Municipio).Include(p => p.Tipopaciente).Include(p => p.Usuario);
            return View(paciente.ToList());
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            ViewBag.idDepartamento = new SelectList(db.Departamento, "idDepartamento", "Nombre_depto");
            ViewBag.idEstadopaciente = new SelectList(db.Estadopaciente, "idEstadopaciente", "estadodelpaciente");
            ViewBag.idMunicipio = new SelectList(db.Municipio, "idMunicipio", "Nombre_muni");
            ViewBag.idtipopaciente = new SelectList(db.Tipopaciente, "idtipopaciente", "iniciales");
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "Nombre_Usuario");
            return View();
        }

        // POST: Pacientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPaciente,idEstadopaciente,idtipopaciente,idUsuario,idDepartamento,idMunicipio,Codigo_paciente,Nombre_paciente1,Nombre_paciente2,Apellido_paciente1,Apellido_paciente2,Fecha_nacimiento,edad,sexo,orientacion_sexual,telefono,fecha_registro,direccion,estado")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Paciente.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDepartamento = new SelectList(db.Departamento, "idDepartamento", "Nombre_depto", paciente.idDepartamento);
            ViewBag.idEstadopaciente = new SelectList(db.Estadopaciente, "idEstadopaciente", "estadodelpaciente", paciente.idEstadopaciente);
            ViewBag.idMunicipio = new SelectList(db.Municipio, "idMunicipio", "Nombre_muni", paciente.idMunicipio);
            ViewBag.idtipopaciente = new SelectList(db.Tipopaciente, "idtipopaciente", "iniciales", paciente.idtipopaciente);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "Nombre_Usuario", paciente.idUsuario);
            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDepartamento = new SelectList(db.Departamento, "idDepartamento", "Nombre_depto", paciente.idDepartamento);
            ViewBag.idEstadopaciente = new SelectList(db.Estadopaciente, "idEstadopaciente", "estadodelpaciente", paciente.idEstadopaciente);
            ViewBag.idMunicipio = new SelectList(db.Municipio, "idMunicipio", "Nombre_muni", paciente.idMunicipio);
            ViewBag.idtipopaciente = new SelectList(db.Tipopaciente, "idtipopaciente", "iniciales", paciente.idtipopaciente);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "Nombre_Usuario", paciente.idUsuario);
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPaciente,idEstadopaciente,idtipopaciente,idUsuario,idDepartamento,idMunicipio,Codigo_paciente,Nombre_paciente1,Nombre_paciente2,Apellido_paciente1,Apellido_paciente2,Fecha_nacimiento,edad,sexo,orientacion_sexual,telefono,fecha_registro,direccion,estado")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDepartamento = new SelectList(db.Departamento, "idDepartamento", "Nombre_depto", paciente.idDepartamento);
            ViewBag.idEstadopaciente = new SelectList(db.Estadopaciente, "idEstadopaciente", "estadodelpaciente", paciente.idEstadopaciente);
            ViewBag.idMunicipio = new SelectList(db.Municipio, "idMunicipio", "Nombre_muni", paciente.idMunicipio);
            ViewBag.idtipopaciente = new SelectList(db.Tipopaciente, "idtipopaciente", "iniciales", paciente.idtipopaciente);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "Nombre_Usuario", paciente.idUsuario);
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paciente paciente = db.Paciente.Find(id);
            db.Paciente.Remove(paciente);
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

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
    public class ControlpermisoesController : Controller
    {
        private bd_hospitalEscUAIEntities db = new bd_hospitalEscUAIEntities();

        // GET: Controlpermisoes
        public ActionResult Index()
        {
            var controlpermiso = db.Controlpermiso.Include(c => c.Permiso).Include(c => c.Tipousuario);
            return View(controlpermiso.ToList());
        }

        // GET: Controlpermisoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Controlpermiso controlpermiso = db.Controlpermiso.Find(id);
            if (controlpermiso == null)
            {
                return HttpNotFound();
            }
            return View(controlpermiso);
        }

        // GET: Controlpermisoes/Create
        public ActionResult Create()
        {
            ViewBag.idPermiso = new SelectList(db.Permiso, "idPermiso", "nombre_permiso");
            ViewBag.idtipo_usuario = new SelectList(db.Tipousuario, "idtipo_usuario", "nombre_tipousuario");
            return View();
        }

        // POST: Controlpermisoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idcontrol_permiso,nombrecontrolpermiso,idtipo_usuario,idPermiso,estado")] Controlpermiso controlpermiso)
        {
            if (ModelState.IsValid)
            {
                db.Controlpermiso.Add(controlpermiso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPermiso = new SelectList(db.Permiso, "idPermiso", "nombre_permiso", controlpermiso.idPermiso);
            ViewBag.idtipo_usuario = new SelectList(db.Tipousuario, "idtipo_usuario", "nombre_tipousuario", controlpermiso.idtipo_usuario);
            return View(controlpermiso);
        }

        // GET: Controlpermisoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Controlpermiso controlpermiso = db.Controlpermiso.Find(id);
            if (controlpermiso == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPermiso = new SelectList(db.Permiso, "idPermiso", "nombre_permiso", controlpermiso.idPermiso);
            ViewBag.idtipo_usuario = new SelectList(db.Tipousuario, "idtipo_usuario", "nombre_tipousuario", controlpermiso.idtipo_usuario);
            return View(controlpermiso);
        }

        // POST: Controlpermisoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idcontrol_permiso,nombrecontrolpermiso,idtipo_usuario,idPermiso,estado")] Controlpermiso controlpermiso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(controlpermiso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPermiso = new SelectList(db.Permiso, "idPermiso", "nombre_permiso", controlpermiso.idPermiso);
            ViewBag.idtipo_usuario = new SelectList(db.Tipousuario, "idtipo_usuario", "nombre_tipousuario", controlpermiso.idtipo_usuario);
            return View(controlpermiso);
        }

        // GET: Controlpermisoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Controlpermiso controlpermiso = db.Controlpermiso.Find(id);
            if (controlpermiso == null)
            {
                return HttpNotFound();
            }
            return View(controlpermiso);
        }

        // POST: Controlpermisoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Controlpermiso controlpermiso = db.Controlpermiso.Find(id);
            db.Controlpermiso.Remove(controlpermiso);
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

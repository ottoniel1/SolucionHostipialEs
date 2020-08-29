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
    public class TipousuariosController : Controller
    {
        private bd_hospitalEscUAIEntities db = new bd_hospitalEscUAIEntities();

        // GET: Tipousuarios
        public ActionResult Index()
        {
            var tablatipousuario = from EP in db.Tipousuario
                                      where EP.estado == true
                                      select EP;
            return View(tablatipousuario.ToList());
        }

        // GET: Tipousuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipousuario tipousuario = db.Tipousuario.Find(id);
            if (tipousuario == null)
            {
                return HttpNotFound();
            }
            return View(tipousuario);
        }

        // GET: Tipousuarios/Create
        public ActionResult Create()
        {
         
            return View();
            
        }

        // POST: Tipousuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtipo_usuario,nombre_tipousuario,estado")] Tipousuario tipousuario)
        {
            if (ModelState.IsValid)
            {
                tipousuario.estado = true;
                db.Tipousuario.Add(tipousuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipousuario);
        }

        // GET: Tipousuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipousuario tipousuario = db.Tipousuario.Find(id);
            if (tipousuario == null)
            {
                return HttpNotFound();
            }
            return View(tipousuario);
        }

        // POST: Tipousuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtipo_usuario,nombre_tipousuario,estado")] Tipousuario tipousuario)
        {
            if (ModelState.IsValid)
            {
                tipousuario.estado = true;
                db.Entry(tipousuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipousuario);
        }

        // GET: Tipousuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipousuario tipousuario = db.Tipousuario.Find(id);
            if (tipousuario == null)
            {
                return HttpNotFound();
            }
            return View(tipousuario);
        }

        // POST: Tipousuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipousuario tipousuario = db.Tipousuario.Find(id);
            tipousuario.estado = false;
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

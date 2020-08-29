using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebHospital.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Irtipousuario()
        {
            return RedirectToAction("Index", "Tipousuarios");
        }

        public ActionResult Irtpuesto()
        {
            return RedirectToAction("Index", "Puestoes");
        }

        public ActionResult Ircontrolpermiso()
        {
            return RedirectToAction("Index", "Controlpermisoes");
        }

        public ActionResult Irempleado()
        {
            return RedirectToAction("Index", "Empleadoes");
        }

        public ActionResult Irusuario()
        {
            return RedirectToAction("Index", "Usuarios");
        }

        public ActionResult Irdepartamento()
        {
            return RedirectToAction("Index", "Departamentoes");
        }

        public ActionResult Irpaciente()
        {
            return RedirectToAction("Index", "Pacientes");
        }

        public ActionResult Irestadotratamiento()
        {
            return RedirectToAction("Index", "Estadotratamientoes");
        }

        public ActionResult Irtratamiento()
        {
            return RedirectToAction("Index", "Tratamientoes");
        }

        public ActionResult Irmedicamento()
        {
            return RedirectToAction("Index", "Medicamentoes");
        }

        public ActionResult Ircita()
        {
            return RedirectToAction("Index", "Citas");
        }

        public ActionResult Irestadocita()
        {
            return RedirectToAction("Index", "Estadocitas");
        }

    }
}
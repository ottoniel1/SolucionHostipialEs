using WebHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebHospital.Controllers
{
    public class LoginController : Controller
    {
        //private bd_hospitalEscUAIEntities db = new bd_hospitalEscUAIEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Validacion(String codigo, String contrasena)
        {


            using (Models.bd_hospitalEscUAIEntities db = new Models.bd_hospitalEscUAIEntities())
            {
                var us = (from uv in db.Usuario
                         where uv.Nombre_Usuario == codigo && uv.contraseña_usuario == contrasena
                         select uv).FirstOrDefault();
                if (us == null)
                {
                    ViewBag.Error = "usuairo o contrasenioa invalida";
                    return View();
                }
                Session["User"] = us;

            }

          

            return View("Index");

        }
    }
}
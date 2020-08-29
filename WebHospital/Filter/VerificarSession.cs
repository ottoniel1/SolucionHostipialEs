using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebHospital.Controllers;
using WebHospital.Models;

namespace WebHospital.Filter
{
    public class VerificarSession : ActionFilterAttribute
    {
        private Usuario usuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            try
            {
                usuario = (Usuario)HttpContext.Current.Session["User"];
                if (usuario == null)
                {
                    if (filterContext.Controller is LoginController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Login/Index");

                    }
                }
            }catch(Exception ex)
            {
                filterContext.HttpContext.Response.Redirect("/Login/Index");

            }
        }

    }
}
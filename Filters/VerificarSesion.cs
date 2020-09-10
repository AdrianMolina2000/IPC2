using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPC2.Controllers;
using IPC2.Models;

namespace IPC2.Filters
{
    public class VerificarSesion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (usuarios)HttpContext.Current.Session["User"];

            if(oUser == null)
            {
                if(filterContext.Controller is CuentaController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Cuenta/Login");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
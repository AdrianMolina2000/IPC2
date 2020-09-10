using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPC2.Controllers
{
    public class CerrarController : Controller
    {
        // GET: Cerrar
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Login", "Cuenta");
        }
    }
}
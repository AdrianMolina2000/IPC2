using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPC2.Models;
using System.Data.SqlClient;

namespace IPC2.Controllers
{
    public class CuentaController : Controller
    {
        public static string usuario;

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Verify(Cuenta account)
        {
            using(OthelloEntities db = new OthelloEntities())
            {
                var lst = from d in db.usuarios
                          where d.nickname == account.Nickname && d.contraseña == account.Password
                          select d;
                if (lst.Count() > 0)
                {
                    usuarios oUser = lst.First();
                    Session["User"] = oUser;
                    usuario = oUser.nickname;
                    TempData["Usuario"] = oUser.nickname;
                    return Redirect("~/Home/Index");
                }
                else
                {
                    return Redirect("~/Cuenta/Login");
                }
            }
        }

    }
}
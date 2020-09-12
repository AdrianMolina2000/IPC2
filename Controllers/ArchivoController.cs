using IPC2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPC2.Controllers
{
    public class ArchivoController : Controller
    {
        // GET: Archivo
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Archi model)
        {
            string RutaSitio = Server.MapPath("~/");
            string PathArchivo1 = Path.Combine(RutaSitio+"/files/archivo1.xml");
            if (!ModelState.IsValid)

            {
                return View("~/Home/Index", model);
            }

            model.Archivo1.SaveAs(PathArchivo1);

            return Redirect("~/Home/Index");
        }
    }
}
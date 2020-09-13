using IPC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace IPC2.Controllers
{
    public class JugarController : Controller
    {
        // GET: Jugar
        public ActionResult Single()
        {

            return View();
        }

        public ActionResult Cargar()
        {
            if (TempData["tableroData"] == null)
            {
                ViewBag.ShowList = false;
                return View();
            }
            else
            {
                List<Fichas> empList = (List<Fichas>)TempData["tableroData"];
                ViewBag.ShowList = true;
                return View(empList);
            }
        }
        [HttpPost]
        public ActionResult UploadXML()
        {
            try
            {
                List<Fichas> empList = new List<Fichas>();
                var xmlFile = Request.Files[0];
                if (xmlFile != null && xmlFile.ContentLength > 0)
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(xmlFile.InputStream);
                    XmlNodeList empNodes = xmlDocument.SelectNodes("tablero/ficha");
                    foreach (XmlNode emp in empNodes)
                    {
                        empList.Add(new Fichas()
                        {
                            color = emp["color"].InnerText,
                            columna = emp["columna"].InnerText,
                            fila = emp["fila"].InnerText,
                        });
                    }
                    TempData["tableroData"] = empList;
                }
                return RedirectToAction("Cargar");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Cargar");
            }
        }
    }
}
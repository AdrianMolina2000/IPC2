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
        public static List<Ficha2> listaFichas = new List<Ficha2>();
        public static Ficha2[] listaFichas2 = new Ficha2[64];

        public void Cambiar(Ficha2 nueva)
        {
            //ABAJO
            if (nueva.numero < 56)
            {
                if (listaFichas2[nueva.numero + 8] == null)
                {
                    int nu = 0;
                }
                else if (listaFichas2[nueva.numero].color != listaFichas2[nueva.numero + 8].color)
                {
                    Ficha2[] listaFichasCambio = listaFichas2;
                    List<int> indices = new List<int>();

                    for (int i = nueva.numero + 8; i < 64; i += 8)
                    {
                        if ((i+8)>64||listaFichas2[i + 8] == null)
                        {
                            break;
                        }
                        else if (listaFichas2[i].color == listaFichas2[i + 8].color)
                        {
                            indices.Add(i);
                        }
                        else if (listaFichas2[i].color != listaFichas2[nueva.numero].color)
                        {
                            indices.Add(i);
                            foreach (var item in indices)
                            {
                                listaFichas2[item].color = nueva.color;
                            }
                            break;
                        }
                    }

                }
            }

            //ARRIBA
            if (nueva.numero > 8)
            {
                if (listaFichas2[nueva.numero - 8] == null)
                {
                    int nu = 0;
                }
                else if (listaFichas2[nueva.numero].color != listaFichas2[nueva.numero - 8].color)
                {
                    Ficha2[] listaFichasCambio = listaFichas2;
                    List<int> indices = new List<int>();

                    for (int i = nueva.numero - 8; i > 0; i -= 8)
                    {
                        if ((i-8)<0||listaFichas2[i - 8] == null)
                        {
                            break;
                        }
                        else if (listaFichas2[i].color == listaFichas2[i - 8].color)
                        {
                            indices.Add(i);
                        }
                        else if (listaFichas2[i].color != listaFichas2[nueva.numero].color)
                        {
                            indices.Add(i);
                            foreach (var item in indices)
                            {
                                listaFichas2[item].color = nueva.color;
                            }
                            break;
                        }
                    }

                }
            }

            //IZQUIERDA
            if (nueva.numero > 0)
            {
                if (listaFichas2[nueva.numero - 1] == null)
                {
                    int nu = 0;
                }
                else if (listaFichas2[nueva.numero].color != listaFichas2[nueva.numero - 1].color)
                {
                    Ficha2[] listaFichasCambio = listaFichas2;
                    List<int> indices = new List<int>();

                    for (int i = nueva.numero - 1; i > 0; i -= 1)
                    {
                        if (listaFichas2[i - 1] == null)
                        {
                            break;
                        }
                        else if (listaFichas2[i].color == listaFichas2[i - 1].color)
                        {
                            indices.Add(i);
                        }
                        else if (listaFichas2[i].color != listaFichas2[nueva.numero].color)
                        {
                            indices.Add(i);
                            foreach (var item in indices)
                            {
                                listaFichas2[item].color = nueva.color;
                            }
                            break;
                        }
                    }

                }
            }

            //DERECHA
            if (nueva.numero < 64)
            {
                if (nueva.numero + 1 == 64 || listaFichas2[nueva.numero + 1] == null)
                {
                    int nu = 0;
                }
                else if (listaFichas2[nueva.numero].color != listaFichas2[nueva.numero + 1].color)
                {
                    Ficha2[] listaFichasCambio = listaFichas2;
                    List<int> indices = new List<int>();

                    for (int i = nueva.numero + 1; i < 64; i += 1)
                    {
                        if ((i+1)>63||listaFichas2[i + 1] == null)
                        {
                            break;
                        }
                        else if (listaFichas2[i].color == listaFichas2[i + 1].color)
                        {
                            indices.Add(i);
                        }
                        else if (listaFichas2[i].color != listaFichas2[nueva.numero].color)
                        {
                            indices.Add(i);
                            foreach (var item in indices)
                            {
                                listaFichas2[item].color = nueva.color;
                            }
                            break;
                        }
                    }

                }
            }

            //ARRIBA-DERECHA
            if (nueva.numero > 7)
            {
                if (listaFichas2[nueva.numero - 7] == null)
                {
                    int nu = 0;
                }
                else if (listaFichas2[nueva.numero].color != listaFichas2[nueva.numero - 7].color)
                {
                    Ficha2[] listaFichasCambio = listaFichas2;
                    List<int> indices = new List<int>();

                    for (int i = nueva.numero - 7; i >= 0; i -= 7)
                    {
                        if ((i-7)<0||listaFichas2[i - 7] == null)
                        {
                            break;
                        }
                        else if (listaFichas2[i].color == listaFichas2[i - 7].color)
                        {
                            indices.Add(i);
                        }
                        else if (listaFichas2[i].color != listaFichas2[nueva.numero].color)
                        {
                            indices.Add(i);
                            foreach (var item in indices)
                            {
                                listaFichas2[item].color = nueva.color;
                            }
                            break;
                        }
                    }

                }
            }

            //ABAJO-DERECHA
            if (nueva.numero < 55)
            {
                if (listaFichas2[nueva.numero + 9] == null)
                {
                    int nu = 0;
                }
                else if (listaFichas2[nueva.numero].color != listaFichas2[nueva.numero + 9].color)
                {
                    Ficha2[] listaFichasCambio = listaFichas2;
                    List<int> indices = new List<int>();

                    for (int i = nueva.numero + 9; i < 64; i += 9)
                    {
                        if ((i+9)>64||listaFichas2[i + 9] == null)
                        {
                            break;
                        }
                        else if (listaFichas2[i].color == listaFichas2[i + 9].color)
                        {
                            indices.Add(i);
                        }
                        else if (listaFichas2[i].color != listaFichas2[nueva.numero].color)
                        {
                            indices.Add(i);
                            foreach (var item in indices)
                            {
                                listaFichas2[item].color = nueva.color;
                            }
                            break;
                        }
                    }

                }
            }

            //ABAJO-IZQUIERDA
            if (nueva.numero < 57)
            {
                if (listaFichas2[nueva.numero + 7] == null)
                {
                    int nu = 0;
                }
                else if (listaFichas2[nueva.numero].color != listaFichas2[nueva.numero + 7].color)
                {
                    Ficha2[] listaFichasCambio = listaFichas2;
                    List<int> indices = new List<int>();

                    for (int i = nueva.numero + 7; i < 57; i += 7)
                    {
                        if (listaFichas2[i + 7] == null)
                        {
                            break;
                        }
                        else if (listaFichas2[i].color == listaFichas2[i + 7].color)
                        {
                            indices.Add(i);
                        }
                        else if (listaFichas2[i].color != listaFichas2[nueva.numero].color)
                        {
                            indices.Add(i);
                            foreach (var item in indices)
                            {
                                listaFichas2[item].color = nueva.color;
                            }
                            break;
                        }
                    }

                }
            }

            //ARRIBA-IZQUIERDA
            if (nueva.numero > 7)
            {
                if ((nueva.numero-9)<0|| listaFichas2[nueva.numero - 9] == null)
                {
                    int nu = 0;
                }
                else if (listaFichas2[nueva.numero].color != listaFichas2[nueva.numero - 9].color)
                {
                    Ficha2[] listaFichasCambio = listaFichas2;
                    List<int> indices = new List<int>();

                    for (int i = nueva.numero - 9; i >= 0; i -= 9)
                    {
                        if ( (i-9)<0||listaFichas2[i - 9] == null)
                        {
                            break;
                        }
                        else if (listaFichas2[i].color == listaFichas2[i - 9].color)
                        {
                            indices.Add(i);
                        }
                        else if (listaFichas2[i].color != listaFichas2[nueva.numero].color)
                        {
                            indices.Add(i);
                            foreach (var item in indices)
                            {
                                listaFichas2[item].color = nueva.color;
                            }
                            break;
                        }
                    }

                }
            }
        }


        // GET: Jugar
        [HttpPost]
        public ActionResult Single(int id, string color)
        {
            listaFichas2[id] = new Ficha2(id, color);
            if(color == "blanco")
            {
                TempData["Turno"] = "negro";
            }
            else
            {
                TempData["Turno"] = "blanco";
            }

            Cambiar(listaFichas2[id]);

            return View(listaFichas2);
        }

        public ActionResult Single()
        {
            listaFichas2[0] = new Ficha2(0, "negro");
            listaFichas2[27] = new Ficha2(27, "negro");
            listaFichas2[36] = new Ficha2(36, "negro");
            listaFichas2[28] = new Ficha2(28, "blanco");
            listaFichas2[35] = new Ficha2(35, "blanco");
            TempData["Turno"] = "negro";
            return View(listaFichas2);
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
            catch (Exception)
            {
                return RedirectToAction("Cargar");
            }
        }

    }
}
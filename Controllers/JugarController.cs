using IPC2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace IPC2.Controllers
{
    public class JugarController : Controller
    {
        public static Fichas[,] bidiFichas = new Fichas[8,8];
        public static Fichas[,] bidiFichas2;
        public static Random random = new Random();
        public void Cambiar(int fila, int columna)
        {

            //ARRIBA
            if (fila > 0)
            {
                if (bidiFichas[fila - 1, columna].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas[fila, columna].color != bidiFichas[fila - 1, columna].color)
                {
                    List<int> indices = new List<int>();

                    for (int i = fila - 1; i > 0; i -= 1)
                    {
                        if ((i - 1) < 0 || bidiFichas[i - 1, columna].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas[i, columna].color == bidiFichas[i - 1, columna].color)
                        {
                            indices.Add(i);
                        }
                        else if (bidiFichas[i, columna].color != bidiFichas[fila, columna].color)
                        {
                            indices.Add(i);
                            foreach (var item in indices)
                            {
                                bidiFichas[item, columna].color = bidiFichas[fila, columna].color;
                            }
                            break;
                        }
                    }

                }
            }

            //ARRIBA-DERECHA
            if (fila > 0 && columna < 7)
            {
                if (bidiFichas[fila - 1, columna + 1].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas[fila, columna].color != bidiFichas[fila - 1, columna + 1].color)
                {
                    Stack<int> indiceX = new Stack<int>();
                    Stack<int> indiceY = new Stack<int>();

                    indiceX.Push(0);
                    indiceY.Push(0);
                    
                    int i = fila - 1;
                    int j = columna + 1;
                    
                    while(i>0 && j<8)
                    {
                        if ((i - 1) < 0 || (j + 1) > 7 || bidiFichas[i - 1, j+1].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas[i, j].color == bidiFichas[i - 1, j + 1].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                        }
                        else if (bidiFichas[i, j].color != bidiFichas[fila, columna].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                            int maximo = indiceX.Count();
                            for (int k = 0; k < maximo-1; k++)
                            {
                                int x = indiceY.Pop();
                                int y = indiceX.Pop();
                                bidiFichas[x, y].color = bidiFichas[fila, columna].color;
                            }
                            break;
                        }
                        i -= 1;
                        j += 1;
                    }
                }
            }


            //DERECHA
            if (columna < 7)
            {
                if (bidiFichas[fila, columna + 1].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas[fila, columna].color != bidiFichas[fila, columna + 1].color)
                {
                    List<int> indices = new List<int>();

                    for (int i = columna + 1; i < 8; i += 1)
                    {
                        if ((i + 1) > 7 || bidiFichas[fila, i + 1].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas[fila, i].color == bidiFichas[fila, i + 1].color)
                        {
                            indices.Add(i);
                        }
                        else if (bidiFichas[fila, i].color != bidiFichas[fila, columna].color)
                        {
                            indices.Add(i);
                            foreach (var item in indices)
                            {
                                bidiFichas[fila, item].color = bidiFichas[fila, columna].color;
                            }
                            break;
                        }
                    }

                }
            }

            //DERECHA-ABAJO
            if (fila < 7 && columna < 7)
            {
                if (bidiFichas[fila + 1, columna + 1].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas[fila, columna].color != bidiFichas[fila + 1, columna + 1].color)
                {
                    Stack<int> indiceX = new Stack<int>();
                    Stack<int> indiceY = new Stack<int>();

                    indiceX.Push(0);
                    indiceY.Push(0);

                    int i = fila + 1;
                    int j = columna + 1;

                    while (i < 8 && j < 8)
                    {
                        if ((i + 1) > 7 || (j + 1) > 7 || bidiFichas[i + 1, j + 1].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas[i, j].color == bidiFichas[i + 1, j + 1].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                        }
                        else if (bidiFichas[i, j].color != bidiFichas[fila, columna].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                            int maximo = indiceX.Count();
                            for (int k = 0; k < maximo - 1; k++)
                            {
                                int x = indiceY.Pop();
                                int y = indiceX.Pop();
                                bidiFichas[x, y].color = bidiFichas[fila, columna].color;
                            }
                            break;
                        }
                        i += 1;
                        j += 1;
                    }
                }
            }


            //ABAJO
            if ( fila < 7)
            {
                if (bidiFichas[fila + 1, columna].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas[fila, columna].color != bidiFichas[fila+1, columna].color)
                {
                    List<int> indices = new List<int>();

                    for (int i = fila + 1; i < 8; i += 1)
                    {
                        if ((i+1)>7|| bidiFichas[i + 1, columna].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas[i,columna].color == bidiFichas[i + 1, columna].color)
                        {
                            indices.Add(i);
                        }
                        else if (bidiFichas[i, columna].color != bidiFichas[fila,columna].color)
                        {
                            indices.Add(i);
                            foreach (var item in indices)
                            {
                                bidiFichas[item, columna].color = bidiFichas[fila, columna].color;
                            }
                            break;
                        }
                    }

                }
            }

            //ABAJO-IZQUIERDA
            if (fila < 7 && columna > 0)
            {
                if (bidiFichas[fila + 1, columna - 1].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas[fila, columna].color != bidiFichas[fila + 1, columna - 1].color)
                {
                    Stack<int> indiceX = new Stack<int>();
                    Stack<int> indiceY = new Stack<int>();

                    indiceX.Push(0);
                    indiceY.Push(0);

                    int i = fila + 1;
                    int j = columna - 1;

                    while (i < 8 && j > 0)
                    {
                        if ((i + 1) > 7 || (j - 1) < 0 || bidiFichas[i + 1, j - 1].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas[i, j].color == bidiFichas[i + 1, j - 1].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                        }
                        else if (bidiFichas[i, j].color != bidiFichas[fila, columna].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                            int maximo = indiceX.Count();
                            for (int k = 0; k < maximo - 1; k++)
                            {
                                int x = indiceY.Pop();
                                int y = indiceX.Pop();
                                bidiFichas[x, y].color = bidiFichas[fila, columna].color;
                            }
                            break;
                        }
                        i += 1;
                        j -= 1;
                    }
                }
            }

            //IZQUIERDA
            if (columna > 0)
            {
                if (bidiFichas[fila, columna - 1].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas[fila, columna].color != bidiFichas[fila, columna - 1].color)
                {
                    List<int> indices = new List<int>();

                    for (int i = columna - 1; i > 0; i -= 1)
                    {
                        if ((i - 1) < 0 || bidiFichas[fila, i - 1].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas[fila, i].color == bidiFichas[fila, i - 1].color)
                        {
                            indices.Add(i);
                        }
                        else if (bidiFichas[fila, i].color != bidiFichas[fila, columna].color)
                        {
                            indices.Add(i);
                            foreach (var item in indices)
                            {
                                bidiFichas[fila, item].color = bidiFichas[fila, columna].color;
                            }
                            break;
                        }
                    }

                }
            }

            //IZQUIERDA-ARRIBA
            if (fila > 0 && columna > 0)
            {
                if (bidiFichas[fila - 1, columna - 1].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas[fila, columna].color != bidiFichas[fila - 1, columna - 1].color)
                {
                    Stack<int> indiceX = new Stack<int>();
                    Stack<int> indiceY = new Stack<int>();

                    indiceX.Push(0);
                    indiceY.Push(0);

                    int i = fila - 1;
                    int j = columna - 1;

                    while (i > 0 && j > 0)
                    {
                        if ((i - 1) < 0 || (j - 1) < 0 || bidiFichas[i - 1, j - 1].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas[i, j].color == bidiFichas[i - 1, j - 1].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                        }
                        else if (bidiFichas[i, j].color != bidiFichas[fila, columna].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                            int maximo = indiceX.Count();
                            for (int k = 0; k < maximo - 1; k++)
                            {
                                int x = indiceY.Pop();
                                int y = indiceX.Pop();
                                bidiFichas[x, y].color = bidiFichas[fila, columna].color;
                            }
                            break;
                        }
                        i -= 1;
                        j -= 1;
                    }
                }
            }


        }

        public void Verificar(string color)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (bidiFichas[i, j].color.Equals(color))
                    {

                        //ARRIBA
                        if (i > 0)
                        {
                            if (bidiFichas[i - 1, j].color == "")
                            {
                                var si = 0;
                            }
                            else if (bidiFichas[i, j].color != bidiFichas[i - 1, j].color)
                            {
                                for (int k = i - 1; k > 0; k -= 1)
                                {
                                    if ((k - 1) < 0 )
                                    {
                                        break;
                                    }

                                    else if (bidiFichas[k, j].color.Equals(bidiFichas[k - 1, j].color))
                                    {
                                        continue;
                                    }
                                    else if (bidiFichas[k - 1, j].color.Equals(""))
                                    {
                                        bidiFichas[k-1, j].permitida = "si";
                                        break;
                                    }
                                    else if (bidiFichas[i, k].color != bidiFichas[k-1, j].color)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas[i, k].color.Equals(bidiFichas[k - 1, j].color))
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                        //ARRIBA-DERECHA
                        if (i > 0 && j < 7)
                        {
                            if (bidiFichas[i - 1, j + 1].color.Equals(""))
                            {
                                var si = 0;
                            }
                            else if (bidiFichas[i, j].color != bidiFichas[i - 1, j + 1].color)
                            {
                                //Stack<int> indiceX = new Stack<int>();
                                //Stack<int> indiceY = new Stack<int>();

                                //indiceX.Push(0);
                                //indiceY.Push(0);

                                int k = i - 1;
                                int l = j + 1;

                                while (k > 0 && l < 8)
                                {
                                    if ((k - 1) < 0 || (l + 1) > 7)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas[k, l].color.Equals(bidiFichas[k - 1, l + 1].color))
                                    {
                                        //indiceY.Push(k);
                                        //indiceX.Push(l);
                                        k -= 1;
                                        l += 1;
                                        continue;
                                    }
                                    else if (bidiFichas[k-1, l+1].color.Equals(""))
                                    {
                                        //indiceY.Push(k);
                                        //indiceX.Push(l);
                                        //int maximo = indiceX.Count();
                                        //for (int m = 0; m < maximo - 2; m++)
                                        //{
                                        //    indiceY.Pop();
                                        //    indiceX.Pop();
                                        //}
                                        bidiFichas[k - 1, l + 1].permitida = "si";
                                        break;
                                    }
                                    else if (bidiFichas[k, l].color != bidiFichas[k-1, l + 1].color)
                                    {
                                        break;
                                    }
                                    k -= 1;
                                    l += 1;
                                }
                            }
                        }
                       

                        //DERECHA
                        if (j < 7)
                        {
                            if (bidiFichas[i, j + 1].color == "")
                            {
                                var si = 0;
                            }
                            else if (bidiFichas[i, j].color != bidiFichas[i, j + 1].color)
                            {
                                for (int k = j + 1; k < 8; k += 1)
                                {
                                    if ((k + 1) > 7)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas[i, k].color.Equals(bidiFichas[i, k + 1].color))
                                    {
                                        continue;
                                    }

                                    else if (bidiFichas[i, k + 1].color.Equals(""))
                                    {
                                        bidiFichas[i, k + 1].permitida = "si";
                                        break;
                                    }

                                    else if (bidiFichas[i, k].color != bidiFichas[i, k + 1].color)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas[i, k].color.Equals(bidiFichas[i, k + 1].color))
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                        //DERECHA-ABAJO
                        if (i < 7 && j < 7)
                        {
                            if (bidiFichas[i + 1, j + 1].color.Equals(""))
                            {
                                var si = 0;
                            }
                            else if (bidiFichas[i, j].color != bidiFichas[i + 1, j + 1].color)
                            {
                                //Stack<int> indiceX = new Stack<int>();
                                //Stack<int> indiceY = new Stack<int>();

                                //indiceX.Push(0);
                                //indiceY.Push(0);

                                int k = i + 1;
                                int l = j + 1;

                                while (k < 8 && l < 8)
                                {
                                    if ((k + 1) > 7 || (l + 1) > 7)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas[k, l].color.Equals(bidiFichas[k + 1, l + 1].color))
                                    {
                                        //indiceY.Push(k);
                                        //indiceX.Push(l);
                                        k += 1;
                                        l += 1;
                                        continue;
                                    }
                                    else if (bidiFichas[k + 1, l + 1].color.Equals(""))
                                    {
                                        //indiceY.Push(k);
                                        //indiceX.Push(l);
                                        //int maximo = indiceX.Count();
                                        //for (int m = 0; m < maximo - 2; m++)
                                        //{
                                        //    indiceY.Pop();
                                        //    indiceX.Pop();
                                        //}
                                        bidiFichas[k + 1, l + 1].permitida = "si";
                                        break;
                                    }
                                    else if (bidiFichas[k, l].color != bidiFichas[k + 1, l + 1].color)
                                    {
                                        break;
                                    }
                                    k += 1;
                                    l += 1;
                                }
                            }
                        }

                        //ABAJO
                        if (i < 7)
                        {
                            if (bidiFichas[i + 1, j].color == "")
                            {
                                var si = 0;
                            }
                            else if (bidiFichas[i, j].color != bidiFichas[i + 1, j].color)
                            {
                                for (int k = i + 1; k > 0; k += 1)
                                {
                                    if ((k + 1) > 7)
                                    {
                                        break;
                                    }

                                    else if (bidiFichas[k, j].color.Equals(bidiFichas[k + 1, j].color))
                                    {
                                        continue;
                                    }
                                    else if (bidiFichas[k + 1, j].color.Equals(""))
                                    {
                                        bidiFichas[k + 1, j].permitida = "si";
                                        break;
                                    }
                                    else if (bidiFichas[i, k].color != bidiFichas[k + 1, j].color)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas[i, k].color.Equals(bidiFichas[k + 1, j].color))
                                    {
                                        break;
                                    }
                                }

                            }
                        }

                        //ABAJO-IZQUIERDA
                        if (i < 7 && j > 0)
                        {
                            if (bidiFichas[i + 1, j - 1].color.Equals(""))
                            {
                                var si = 0;
                            }
                            else if (bidiFichas[i, j].color != bidiFichas[i + 1, j - 1].color)
                            {
                                //Stack<int> indiceX = new Stack<int>();
                                //Stack<int> indiceY = new Stack<int>();

                                //indiceX.Push(0);
                                //indiceY.Push(0);

                                int k = i + 1;
                                int l = j - 1;

                                while (k < 8 && l > 0)
                                {
                                    if ((k + 1) > 7 || (l - 1) < 0)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas[k, l].color.Equals(bidiFichas[k + 1, l - 1].color))
                                    {
                                        k += 1;
                                        l -= 1;
                                        continue;
                                    }
                                    else if (bidiFichas[k + 1, l - 1].color.Equals(""))
                                    {
                                        //indiceY.Push(k);
                                        //indiceX.Push(l);
                                        //int maximo = indiceX.Count();
                                        //for (int m = 0; m < maximo - 2; m++)
                                        //{
                                        //    indiceY.Pop();
                                        //    indiceX.Pop();
                                        //}
                                        bidiFichas[k + 1, l - 1].permitida = "si";
                                        break;
                                    }
                                    else if (bidiFichas[k, l].color != bidiFichas[k + 1, l - 1].color)
                                    {
                                        break;
                                    }
                                    k += 1;
                                    l -= 1;
                                }
                            }
                        }

                        //IZQUIERDA
                        if (j > 0)
                        {
                            if (bidiFichas[i, j - 1].color.Equals(""))
                            {
                                var si = 0;
                            }
                            else if (bidiFichas[i, j].color != bidiFichas[i, j - 1].color)
                            {
                                for (int k = j - 1; k < 8; k -= 1)
                                {
                                    if ((k - 1) < 0)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas[i, k].color.Equals(bidiFichas[i, k - 1].color))
                                    {
                                        continue;
                                    }

                                    else if (bidiFichas[i, k - 1].color.Equals(""))
                                    {
                                        bidiFichas[i, k - 1].permitida = "si";
                                        break;
                                    }

                                    else if (bidiFichas[i, k].color != bidiFichas[i, k - 1].color)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas[i, k].color.Equals(bidiFichas[i, k - 1].color))
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                        //ARRIBA-IZQUIERDA
                        if (i > 0 && j > 0)
                        {
                            if (bidiFichas[i - 1, j - 1].color.Equals(""))
                            {
                                var si = 0;
                            }
                            else if (bidiFichas[i, j].color != bidiFichas[i - 1, j - 1].color)
                            {
                                //Stack<int> indiceX = new Stack<int>();
                                //Stack<int> indiceY = new Stack<int>();

                                //indiceX.Push(0);
                                //indiceY.Push(0);

                                int k = i - 1;
                                int l = j - 1;

                                while (k > 0 && l > 0)
                                {
                                    if ((k - 1) < 0 || (l - 1) < 0)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas[k, l].color.Equals(bidiFichas[k - 1, l - 1].color))
                                    {
                                        //indiceY.Push(k);
                                        //indiceX.Push(l);
                                        k -= 1;
                                        l -= 1;
                                        continue;
                                    }
                                    else if (bidiFichas[k - 1, l - 1].color.Equals(""))
                                    {
                                        //indiceY.Push(k);
                                        //indiceX.Push(l);
                                        //int maximo = indiceX.Count();
                                        //for (int m = 0; m < maximo - 2; m++)
                                        //{
                                        //    indiceY.Pop();
                                        //    indiceX.Pop();
                                        //}
                                        //bidiFichas[indiceY.Pop() - 1, indiceX.Pop() - 1].permitida = "si";
                                        bidiFichas[k-1, l-1].permitida = "si";
                                        break;
                                    }
                                    else if (bidiFichas[k, l].color != bidiFichas[k - 1, l - 1].color)
                                    {
                                        break;
                                    }
                                    k -= 1;
                                    l -= 1;
                                }
                            }
                        }
                    }
                }
            }
        }//Fin de verificar



        public int contarNegras()
        {
            int contador = 0;
            for(int i = 0; i<8; i++)
            {
                for(int j = 0; j<8; j++)
                {
                    if (bidiFichas[i, j].color.Equals("fa-circle"))
                    {
                        contador += 1;
                    }
                    
                }
            }
            return contador;
        }

        public int contarBlancas()
        {
            int contador = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (bidiFichas[i, j].color.Equals("fa-circle white"))
                    {
                        contador += 1;
                    }

                }
            }
            return contador;
        }


        // GET: Jugar
        [HttpPost]
        public ActionResult Single(int fila, int columna, string color)
        {
            bidiFichas[fila, columna] = new Fichas(fila.ToString(), columna.ToString(), color);
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    bidiFichas[i, j].permitida = "no";
                }
            }

            string turno = color;

            ViewBag.turno = "";
            if(color == "fa-circle white")
            {
                TempData["Turno"] = "fa-circle";
                turno = "fa-circle";
                ViewBag.turno = "negras";
            }
            else
            {
                TempData["Turno"] = "fa-circle white";
                turno = "fa-circle white";
                ViewBag.turno = "blancas";
            }

            Cambiar(fila, columna);
            Verificar(turno);


            int verificadas = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(bidiFichas[i, j].permitida.Equals("si"))
                    {
                        verificadas += 1;
                    }
                }
            }

            ViewBag.mensaje = "";

            if (verificadas == 0)
            {
                if (TempData["Turno"].Equals("fa-circle white"))
                {
                    TempData["Turno"] = "fa-circle";
                    ViewBag.turno = "negras";
                    ViewBag.mensaje = "No quedan tiros disponibles, turno saltado";
                    Verificar("fa-circle");
                }
                else
                {
                    TempData["Turno"] = "fa-circle white";
                    ViewBag.turno = "blancas";
                    ViewBag.mensaje = "No quedan tiros disponibles, turno saltado";
                    Verificar("fa-circle white");
                }
            }

            ViewBag.ganador = "";
            if (contarBlancas() + contarNegras() == 64)
            {
                if (contarNegras() > contarBlancas())
                {
                    ViewBag.ganador = "El ganador es: Fichas Negras";
                    using (var db = new OthelloEntities())
                    {
                        Partida partidita = new Partida();
                        partidita.id_tipo_partida = 2;
                        partidita.id_estado = 1;

                        Partida_Jugador partida_jug = new Partida_Jugador();
                        partida_jug.id_partida = partidita.id_partida;
                        partida_jug.nickname = TempData["Usuario"].ToString();

                        db.Partida.Add(partidita);
                        db.Partida_Jugador.Add(partida_jug);

                        db.SaveChanges();
                    }
                }
                else
                {
                    ViewBag.ganador = "El ganador es: Fichas Blancas";
                    using (var db = new OthelloEntities())
                    {
                        Partida partidita = new Partida();
                        partidita.id_tipo_partida = 2;
                        partidita.id_estado = 2;

                        Partida_Jugador partida_jug = new Partida_Jugador();
                        partida_jug.id_partida = partidita.id_partida;
                        partida_jug.nickname = TempData["Usuario"].ToString();

                        db.Partida.Add(partidita);
                        db.Partida_Jugador.Add(partida_jug);

                        db.SaveChanges();
                    }
                }
                
            }

            ViewBag.numeroBlancas = contarBlancas();
            ViewBag.numeroNegras = contarNegras();
            return View(bidiFichas);
        }

        public ActionResult Single()
        {

            for(int i = 0; i<8; i++)
            {
                for(int j = 0; j<8; j++)
                {
                    bidiFichas[i, j] = new Fichas(i.ToString(), j.ToString());
                }
            }


            bidiFichas[3,3] = new Fichas("3","3", "fa-circle white");
            bidiFichas[4,4] = new Fichas("4","4", "fa-circle white");
            bidiFichas[4,3] = new Fichas("4","3", "fa-circle");
            bidiFichas[3,4] = new Fichas("3","4", "fa-circle");

            ViewBag.numeroBlancas = contarBlancas();
            ViewBag.numeroNegras = contarNegras();
            TempData["Turno"] = "fa-circle";
            ViewBag.turno = "negras";
            Verificar("fa-circle");
            return View(bidiFichas);
        }

        public ActionResult Single2()
        {

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    bidiFichas[i, j] = new Fichas(i.ToString(), j.ToString());
                }
            }


            bidiFichas[3, 3] = new Fichas("3", "3", "fa-circle white");
            bidiFichas[4, 4] = new Fichas("4", "4", "fa-circle white");
            bidiFichas[4, 3] = new Fichas("4", "3", "fa-circle");
            bidiFichas[3, 4] = new Fichas("3", "4", "fa-circle");

            ViewBag.numeroBlancas = contarBlancas();
            ViewBag.numeroNegras = contarNegras();
            TempData["Turno"] = "fa-circle";
            ViewBag.turno = "negras";
            Verificar("fa-circle");
            return View(bidiFichas);
        }

        [HttpPost]
        public ActionResult Single2(int fila, int columna, string color)
        {
            List<Fichas> tirosMaquina = new List<Fichas>();

            bidiFichas[fila, columna] = new Fichas(fila.ToString(), columna.ToString(), color);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    bidiFichas[i, j].permitida = "no";
                }
            }

            /*
            string turno = color;

            ViewBag.turno = "";
            if (color == "fa-circle white")
            {
                TempData["Turno"] = "fa-circle";
                turno = "fa-circle";
                ViewBag.turno = "negras";
            }
            else
            {
                TempData["Turno"] = "fa-circle white";
                turno = "fa-circle white";
                ViewBag.turno = "blancas";
            }
            */

            Cambiar(fila, columna);
            Verificar("fa-circle white");

            int verificadas = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (bidiFichas[i, j].permitida.Equals("si"))
                    {
                        verificadas += 1;
                        tirosMaquina.Add(bidiFichas[i,j]);
                    }
                }
            }

            ViewBag.mensaje = "";
    
            
            if (verificadas != 0)
            {
                //RANDOM
                int r = random.Next(tirosMaquina.Count());
                Fichas fichaObtenida = tirosMaquina[r];

                bidiFichas[Int32.Parse(fichaObtenida.fila), Int32.Parse(fichaObtenida.columna)] = new Fichas(fichaObtenida.fila, fichaObtenida.color, "fa-circle white");

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        bidiFichas[i, j].permitida = "no";
                    }
                }

                Cambiar(Int32.Parse(fichaObtenida.fila), Int32.Parse(fichaObtenida.columna));
                Verificar("fa-circle");
            }



            if (contarBlancas() + contarNegras() == 64)
            {
                if (contarNegras() > contarBlancas())
                {
                    ViewBag.ganador = "El ganador es: Fichas Negras";
                    using (var db = new OthelloEntities())
                    {
                        Partida partidita = new Partida();
                        partidita.id_tipo_partida = 1;
                        partidita.id_estado = 1;

                        Partida_Jugador partida_jug = new Partida_Jugador();
                        partida_jug.id_partida = partidita.id_partida;
                        partida_jug.nickname = TempData["Usuario"].ToString();

                        db.Partida.Add(partidita);
                        db.Partida_Jugador.Add(partida_jug);

                        db.SaveChanges();
                    }
                }
                else
                {
                    ViewBag.ganador = "El ganador es: Fichas Blancas";
                    using (var db = new OthelloEntities())
                    {
                        Partida partidita = new Partida();
                        partidita.id_tipo_partida = 1;
                        partidita.id_estado = 2;

                        Partida_Jugador partida_jug = new Partida_Jugador();
                        partida_jug.id_partida = partidita.id_partida;
                        partida_jug.nickname = TempData["Usuario"].ToString();

                        db.Partida.Add(partidita);
                        db.Partida_Jugador.Add(partida_jug);

                        db.SaveChanges();
                    }
                }
            }

            TempData["Turno"] = "fa-circle";
            ViewBag.numeroBlancas = contarBlancas();
            ViewBag.numeroNegras = contarNegras();
            return View(bidiFichas);
        }

        [HttpPost]
        public ActionResult Iniciar()
        {

            return RedirectToAction("Single");
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
                
                string[] letras = { "A", "B", "C", "D", "E", "F", "G", "H" };

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        bidiFichas[i, j] = new Fichas(i.ToString(), j.ToString());
                    }
                }

                foreach (var item in empList)
                {
                    string color = "";
                    int posicion = 0;
                    for(int i = 0; i<8; i++)
                    {
                        if (letras[i] == item.columna)
                        {
                            break;
                        }
                        else
                        {
                            posicion++;
                        }
                    }
                    if(item.color == "negro")
                    {
                        color = "fa-circle";
                    }
                    else
                    {
                        color = "fa-circle white";
                    }

                    int fila = Int32.Parse(item.fila) - 1;
                    bidiFichas[fila, posicion] = new Fichas(fila.ToString(), posicion.ToString(), color);
                }
                
                TempData["Turno"] = "fa-circle";
                ViewBag.turno = "negras";
                Verificar("fa-circle");
                ViewBag.ShowList = true;
                return View(bidiFichas);
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


        [HttpPost]
        public ActionResult GuardarTablero()
        {
            string[] letras= { "A", "B", "C", "D", "E", "F", "G", "H"};

            using (StreamWriter outputFile = new StreamWriter("C:\\Users\\Amc\\Desktop\\AS\\Programacion\\Visual\\IPC2 Proyect\\IPC2\\files\\guardado.xml"))
            {
                outputFile.WriteLine("<tablero>");
                for(int i = 0; i < 8; i++)
                {
                    for (int j=0; j<8; j++)
                    {
                        if (bidiFichas[i,j].color.Equals("fa-circle"))
                        {
                            outputFile.WriteLine("  <ficha>");
                            outputFile.WriteLine("      <color>negro</color>");
                            outputFile.WriteLine("      <fila>"+(i+1)+"</fila>");
                            outputFile.WriteLine("      <columna>"+letras[j]+"</columna>");
                            outputFile.WriteLine("  </ficha>");
                        }
                        else if(bidiFichas[i, j].color.Equals("fa-circle white"))
                        {
                            outputFile.WriteLine("  <ficha>");
                            outputFile.WriteLine("      <color>blanco</color>");
                            outputFile.WriteLine("      <fila>" + (i+1) + "</fila>");
                            outputFile.WriteLine("      <columna>" + letras[j] + "</columna>");
                            outputFile.WriteLine("  </ficha>");
                        }

                    }
                   
                }
                outputFile.WriteLine("</tablero>");
            }
            return Redirect("~/Home/Index");
        }

        
        [HttpPost]
        public ActionResult Xtream(int filas, int columnas)
        {
            bidiFichas2 = new Fichas[filas, columnas];


            ViewBag.filas = filas;
            ViewBag.columnas = columnas;
            return View();
        }

    }
}
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

        public static Fichas[,] bidiFichas = new Fichas[8, 8];
        public static Fichas[,] bidiFichas2;
        public static Fichas[,] bidiFichas3;

        public static List<string> coloresJ1;
        public static int indice1 = 0;
        public static int indice2 = 0;
        public static List<string> coloresJ2;

        public static Random random = new Random();

        public static int filasXtreme;
        public static int columnasXtreme;
        public static string modalidadXtream;

        public static double tiempo1 = 0;
        public static double tiempo2 = 0;

        public static TableroConfi configuraciones = new TableroConfi();
        public static Campeonato torneito = new Campeonato();
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

                    while (i > 0 && j < 8)
                    {
                        if ((i - 1) < 0 || (j + 1) > 7 || bidiFichas[i - 1, j + 1].color.Equals(""))
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
                            for (int k = 0; k < maximo - 1; k++)
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
            if (fila < 7)
            {
                if (bidiFichas[fila + 1, columna].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas[fila, columna].color != bidiFichas[fila + 1, columna].color)
                {
                    List<int> indices = new List<int>();

                    for (int i = fila + 1; i < 8; i += 1)
                    {
                        if ((i + 1) > 7 || bidiFichas[i + 1, columna].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas[i, columna].color == bidiFichas[i + 1, columna].color)
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
                                    if ((k - 1) < 0)
                                    {
                                        break;
                                    }

                                    else if (bidiFichas[k, j].color.Equals(bidiFichas[k - 1, j].color))
                                    {
                                        continue;
                                    }
                                    else if (bidiFichas[k - 1, j].color.Equals(""))
                                    {
                                        bidiFichas[k - 1, j].permitida = "si";
                                        break;
                                    }
                                    else if (bidiFichas[k, j].color != bidiFichas[k - 1, j].color)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas[k, j].color.Equals(bidiFichas[k - 1, j].color))
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
                                    else if (bidiFichas[k - 1, l + 1].color.Equals(""))
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
                                    else if (bidiFichas[k, l].color != bidiFichas[k - 1, l + 1].color)
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
                                    else if (bidiFichas[k, j].color != bidiFichas[k + 1, j].color)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas[k, j].color.Equals(bidiFichas[k + 1, j].color))
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
                                        bidiFichas[k - 1, l - 1].permitida = "si";
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
        }


        public bool buscarL1(string color)
        {
            for (int i = 0; i < coloresJ1.Count(); i++)
            {
                if (color.Equals(coloresJ1[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public bool buscarL2(string color)
        {
            for (int i = 0; i < coloresJ2.Count(); i++)
            {
                if (color.Equals(coloresJ2[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public void VerificarX(string color)
        {
            for (int i = 0; i < filasXtreme; i++)
            {
                for (int j = 0; j < columnasXtreme; j++)
                {

                    if (bidiFichas2[i, j].color.Equals(color))
                    {

                        //ARRIBA
                        if (i > 0)
                        {
                            if (bidiFichas2[i - 1, j].color.Equals(""))
                            {
                                var si = 0;
                            }
                            else if (bidiFichas2[i, j].color != bidiFichas2[i - 1, j].color)
                            {
                                for (int k = i - 1; k > 0; k -= 1)
                                {
                                    if ((k - 1) < 0)
                                    {
                                        break;
                                    }

                                    else if (bidiFichas2[k, j].color.Equals(bidiFichas2[k - 1, j].color))
                                    {
                                        continue;
                                    }
                                    else if (bidiFichas2[k - 1, j].color.Equals(""))
                                    {
                                        bidiFichas2[k - 1, j].permitida = "si";
                                        break;
                                    }
                                    else if (bidiFichas2[i, k].color != bidiFichas2[k - 1, j].color)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas2[i, k].color.Equals(bidiFichas2[k - 1, j].color))
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                        //ARRIBA-DERECHA
                        if (i > 0 && j < (columnasXtreme - 1))
                        {
                            if (bidiFichas2[i - 1, j + 1].color.Equals(""))
                            {
                                var si = 0;
                            }
                            else if (bidiFichas2[i, j].color != bidiFichas2[i - 1, j + 1].color)
                            {

                                int k = i - 1;
                                int l = j + 1;

                                while (k > 0 && l < columnasXtreme)
                                {
                                    if ((k - 1) < 0 || (l + 1) > (columnasXtreme - 1))
                                    {
                                        break;
                                    }
                                    else if (bidiFichas2[k, l].color.Equals(bidiFichas2[k - 1, l + 1].color))
                                    {
                                        k -= 1;
                                        l += 1;
                                        continue;
                                    }
                                    else if (bidiFichas2[k - 1, l + 1].color.Equals(""))
                                    {
                                        bidiFichas2[k - 1, l + 1].permitida = "si";
                                        break;
                                    }
                                    else if (bidiFichas2[k, l].color != bidiFichas2[k - 1, l + 1].color)
                                    {
                                        break;
                                    }
                                    k -= 1;
                                    l += 1;
                                }
                            }
                        }


                        //DERECHA
                        if (j < (columnasXtreme - 1))
                        {
                            if (bidiFichas2[i, j + 1].color == "")
                            {
                                var si = 0;
                            }
                            else if (bidiFichas2[i, j].color != bidiFichas2[i, j + 1].color)
                            {
                                for (int k = j + 1; k < columnasXtreme; k += 1)
                                {
                                    if ((k + 1) > (columnasXtreme - 1))
                                    {
                                        break;
                                    }
                                    else if (bidiFichas2[i, k].color.Equals(bidiFichas2[i, k + 1].color))
                                    {
                                        continue;
                                    }

                                    else if (bidiFichas2[i, k + 1].color.Equals(""))
                                    {
                                        bidiFichas2[i, k + 1].permitida = "si";
                                        break;
                                    }

                                    else if (bidiFichas2[i, k].color != bidiFichas2[i, k + 1].color)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas2[i, k].color.Equals(bidiFichas2[i, k + 1].color))
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                        //DERECHA-ABAJO
                        if (i < (filasXtreme - 1) && j < (columnasXtreme - 1))
                        {
                            if (bidiFichas2[i + 1, j + 1].color.Equals(""))
                            {
                                var si = 0;
                            }
                            else if (bidiFichas2[i, j].color != bidiFichas2[i + 1, j + 1].color)
                            {
                                int k = i + 1;
                                int l = j + 1;

                                while (k < filasXtreme && l < columnasXtreme)
                                {
                                    if ((k + 1) > (filasXtreme - 1) || (l + 1) > (columnasXtreme - 1))
                                    {
                                        break;
                                    }
                                    else if (bidiFichas2[k, l].color.Equals(bidiFichas2[k + 1, l + 1].color))
                                    {
                                        k += 1;
                                        l += 1;
                                        continue;
                                    }
                                    else if (bidiFichas2[k + 1, l + 1].color.Equals(""))
                                    {
                                        bidiFichas2[k + 1, l + 1].permitida = "si";
                                        break;
                                    }
                                    else if (bidiFichas2[k, l].color != bidiFichas2[k + 1, l + 1].color)
                                    {
                                        break;
                                    }
                                    k += 1;
                                    l += 1;
                                }
                            }
                        }

                        //ABAJO
                        if (i < (filasXtreme - 1))
                        {
                            if (bidiFichas2[i + 1, j].color == "")
                            {
                                var si = 0;
                            }
                            else if (bidiFichas2[i, j].color != bidiFichas2[i + 1, j].color)
                            {
                                for (int k = i + 1; k > 0; k += 1)
                                {
                                    if ((k + 1) > (filasXtreme - 1))
                                    {
                                        break;
                                    }

                                    else if (bidiFichas2[k, j].color.Equals(bidiFichas2[k + 1, j].color))
                                    {
                                        continue;
                                    }
                                    else if (bidiFichas2[k + 1, j].color.Equals(""))
                                    {
                                        bidiFichas2[k + 1, j].permitida = "si";
                                        break;
                                    }
                                    else if (bidiFichas2[i, k].color != bidiFichas2[k + 1, j].color)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas2[i, k].color.Equals(bidiFichas2[k + 1, j].color))
                                    {
                                        break;
                                    }
                                }

                            }
                        }

                        //ABAJO-IZQUIERDA
                        if (i < (filasXtreme - 1) && j > 0)
                        {
                            if (bidiFichas2[i + 1, j - 1].color.Equals(""))
                            {
                                var si = 0;
                            }
                            else if (bidiFichas2[i, j].color != bidiFichas2[i + 1, j - 1].color)
                            {
                                int k = i + 1;
                                int l = j - 1;

                                while (k < filasXtreme && l > 0)
                                {
                                    if ((k + 1) > (filasXtreme - 1) || (l - 1) < 0)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas2[k, l].color.Equals(bidiFichas2[k + 1, l - 1].color))
                                    {
                                        k += 1;
                                        l -= 1;
                                        continue;
                                    }
                                    else if (bidiFichas2[k + 1, l - 1].color.Equals(""))
                                    {
                                        bidiFichas2[k + 1, l - 1].permitida = "si";
                                        break;
                                    }
                                    else if (bidiFichas2[k, l].color != bidiFichas2[k + 1, l - 1].color)
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
                            if (bidiFichas2[i, j - 1].color.Equals(""))
                            {
                                var si = 0;
                            }
                            else if (bidiFichas2[i, j].color != bidiFichas2[i, j - 1].color)
                            {
                                for (int k = j - 1; k < columnasXtreme; k -= 1)
                                {
                                    if ((k - 1) < 0)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas2[i, k].color.Equals(bidiFichas2[i, k - 1].color))
                                    {
                                        continue;
                                    }

                                    else if (bidiFichas2[i, k - 1].color.Equals(""))
                                    {
                                        bidiFichas2[i, k - 1].permitida = "si";
                                        break;
                                    }

                                    else if (bidiFichas2[i, k].color != bidiFichas2[i, k - 1].color)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas2[i, k].color.Equals(bidiFichas2[i, k - 1].color))
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                        //ARRIBA-IZQUIERDA
                        if (i > 0 && j > 0)
                        {
                            if (bidiFichas2[i - 1, j - 1].color.Equals(""))
                            {
                                var si = 0;
                            }
                            else if (bidiFichas2[i, j].color != bidiFichas2[i - 1, j - 1].color)
                            {
                                int k = i - 1;
                                int l = j - 1;

                                while (k > 0 && l > 0)
                                {
                                    if ((k - 1) < 0 || (l - 1) < 0)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas2[k, l].color.Equals(bidiFichas2[k - 1, l - 1].color))
                                    {
                                        k -= 1;
                                        l -= 1;
                                        continue;
                                    }
                                    else if (bidiFichas2[k - 1, l - 1].color.Equals(""))
                                    {
                                        bidiFichas2[k - 1, l - 1].permitida = "si";
                                        break;
                                    }
                                    else if (bidiFichas2[k, l].color != bidiFichas2[k - 1, l - 1].color)
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
        }

        public void VerificarX2(string color)
        {
            for (int i = 0; i < filasXtreme; i++)
            {
                for (int j = 0; j < columnasXtreme; j++)
                {

                    if (bidiFichas3[i, j].color.Equals(color))
                    {

                        //ARRIBA
                        if (i > 0)
                        {
                            if (bidiFichas3[i - 1, j].color.Equals(""))
                            {
                                var si = 0;
                            }
                            else if (bidiFichas3[i, j].color != bidiFichas3[i - 1, j].color)
                            {
                                for (int k = i - 1; k > 0; k -= 1)
                                {
                                    if ((k - 1) < 0)
                                    {
                                        break;
                                    }

                                    else if (bidiFichas3[k, j].color.Equals(bidiFichas3[k - 1, j].color))
                                    {
                                        continue;
                                    }
                                    else if (bidiFichas3[k - 1, j].color.Equals(""))
                                    {
                                        bidiFichas2[k - 1, j].permitida = "si";
                                        break;
                                    }
                                    else if (bidiFichas3[k, j].color != bidiFichas3[k - 1, j].color)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas3[k, j].color.Equals(bidiFichas3[k - 1, j].color))
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                        //ARRIBA-DERECHA
                        if (i > 0 && j < (columnasXtreme - 1))
                        {
                            if (bidiFichas3[i - 1, j + 1].color.Equals(""))
                            {
                                var si = 0;
                            }
                            else if (bidiFichas3[i, j].color != bidiFichas3[i - 1, j + 1].color)
                            {

                                int k = i - 1;
                                int l = j + 1;

                                while (k > 0 && l < columnasXtreme)
                                {
                                    if ((k - 1) < 0 || (l + 1) > (columnasXtreme - 1))
                                    {
                                        break;
                                    }
                                    else if (bidiFichas3[k, l].color.Equals(bidiFichas3[k - 1, l + 1].color))
                                    {
                                        k -= 1;
                                        l += 1;
                                        continue;
                                    }
                                    else if (bidiFichas3[k - 1, l + 1].color.Equals(""))
                                    {
                                        bidiFichas2[k - 1, l + 1].permitida = "si";
                                        break;
                                    }
                                    else if (bidiFichas3[k, l].color != bidiFichas3[k - 1, l + 1].color)
                                    {
                                        break;
                                    }
                                    k -= 1;
                                    l += 1;
                                }
                            }
                        }


                        //DERECHA
                        if (j < (columnasXtreme - 1))
                        {
                            if (bidiFichas3[i, j + 1].color == "")
                            {
                                var si = 0;
                            }
                            else if (bidiFichas3[i, j].color != bidiFichas3[i, j + 1].color)
                            {
                                for (int k = j + 1; k < columnasXtreme; k += 1)
                                {
                                    if ((k + 1) > (columnasXtreme - 1))
                                    {
                                        break;
                                    }
                                    else if (bidiFichas3[i, k].color.Equals(bidiFichas3[i, k + 1].color))
                                    {
                                        continue;
                                    }

                                    else if (bidiFichas3[i, k + 1].color.Equals(""))
                                    {
                                        bidiFichas2[i, k + 1].permitida = "si";
                                        break;
                                    }

                                    else if (bidiFichas3[i, k].color != bidiFichas3[i, k + 1].color)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas3[i, k].color.Equals(bidiFichas3[i, k + 1].color))
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                        //DERECHA-ABAJO
                        if (i < (filasXtreme - 1) && j < (columnasXtreme - 1))
                        {
                            if (bidiFichas3[i + 1, j + 1].color.Equals(""))
                            {
                                var si = 0;
                            }
                            else if (bidiFichas3[i, j].color != bidiFichas3[i + 1, j + 1].color)
                            {
                                int k = i + 1;
                                int l = j + 1;

                                while (k < filasXtreme && l < columnasXtreme)
                                {
                                    if ((k + 1) > (filasXtreme - 1) || (l + 1) > (columnasXtreme - 1))
                                    {
                                        break;
                                    }
                                    else if (bidiFichas3[k, l].color.Equals(bidiFichas3[k + 1, l + 1].color))
                                    {
                                        k += 1;
                                        l += 1;
                                        continue;
                                    }
                                    else if (bidiFichas3[k + 1, l + 1].color.Equals(""))
                                    {
                                        bidiFichas2[k + 1, l + 1].permitida = "si";
                                        break;
                                    }
                                    else if (bidiFichas3[k, l].color != bidiFichas3[k + 1, l + 1].color)
                                    {
                                        break;
                                    }
                                    k += 1;
                                    l += 1;
                                }
                            }
                        }

                        //ABAJO
                        if (i < (filasXtreme - 1))
                        {
                            if (bidiFichas3[i + 1, j].color == "")
                            {
                                var si = 0;
                            }
                            else if (bidiFichas3[i, j].color != bidiFichas3[i + 1, j].color)
                            {
                                for (int k = i + 1; k > 0; k += 1)
                                {
                                    if ((k + 1) > (filasXtreme - 1))
                                    {
                                        break;
                                    }

                                    else if (bidiFichas3[k, j].color.Equals(bidiFichas3[k + 1, j].color))
                                    {
                                        continue;
                                    }
                                    else if (bidiFichas3[k + 1, j].color.Equals(""))
                                    {
                                        bidiFichas2[k + 1, j].permitida = "si";
                                        break;
                                    }
                                    else if (bidiFichas3[k, j].color != bidiFichas3[k + 1, j].color)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas3[k, j].color.Equals(bidiFichas3[k + 1, j].color))
                                    {
                                        break;
                                    }
                                }

                            }
                        }

                        //ABAJO-IZQUIERDA
                        if (i < (filasXtreme - 1) && j > 0)
                        {
                            if (bidiFichas3[i + 1, j - 1].color.Equals(""))
                            {
                                var si = 0;
                            }
                            else if (bidiFichas3[i, j].color != bidiFichas3[i + 1, j - 1].color)
                            {
                                int k = i + 1;
                                int l = j - 1;

                                while (k < filasXtreme && l > 0)
                                {
                                    if ((k + 1) > (filasXtreme - 1) || (l - 1) < 0)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas3[k, l].color.Equals(bidiFichas3[k + 1, l - 1].color))
                                    {
                                        k += 1;
                                        l -= 1;
                                        continue;
                                    }
                                    else if (bidiFichas3[k + 1, l - 1].color.Equals(""))
                                    {
                                        bidiFichas2[k + 1, l - 1].permitida = "si";
                                        break;
                                    }
                                    else if (bidiFichas3[k, l].color != bidiFichas3[k + 1, l - 1].color)
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
                            if (bidiFichas3[i, j - 1].color.Equals(""))
                            {
                                var si = 0;
                            }
                            else if (bidiFichas3[i, j].color != bidiFichas3[i, j - 1].color)
                            {
                                for (int k = j - 1; k < columnasXtreme; k -= 1)
                                {
                                    if ((k - 1) < 0)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas3[i, k].color.Equals(bidiFichas3[i, k - 1].color))
                                    {
                                        continue;
                                    }

                                    else if (bidiFichas3[i, k - 1].color.Equals(""))
                                    {
                                        bidiFichas2[i, k - 1].permitida = "si";
                                        break;
                                    }

                                    else if (bidiFichas3[i, k].color != bidiFichas3[i, k - 1].color)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas3[i, k].color.Equals(bidiFichas3[i, k - 1].color))
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                        //ARRIBA-IZQUIERDA
                        if (i > 0 && j > 0)
                        {
                            if (bidiFichas3[i - 1, j - 1].color.Equals(""))
                            {
                                var si = 0;
                            }
                            else if (bidiFichas3[i, j].color != bidiFichas3[i - 1, j - 1].color)
                            {
                                int k = i - 1;
                                int l = j - 1;

                                while (k > 0 && l > 0)
                                {
                                    if ((k - 1) < 0 || (l - 1) < 0)
                                    {
                                        break;
                                    }
                                    else if (bidiFichas3[k, l].color.Equals(bidiFichas3[k - 1, l - 1].color))
                                    {
                                        k -= 1;
                                        l -= 1;
                                        continue;
                                    }
                                    else if (bidiFichas3[k - 1, l - 1].color.Equals(""))
                                    {
                                        bidiFichas2[k - 1, l - 1].permitida = "si";
                                        break;
                                    }
                                    else if (bidiFichas3[k, l].color != bidiFichas3[k - 1, l - 1].color)
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
        }

        public void CambiarX(int fila, int columna)
        {

            //ARRIBA
            if (fila > 0)
            {
                if (bidiFichas2[fila - 1, columna].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas2[fila, columna].color != bidiFichas2[fila - 1, columna].color)
                {
                    List<int> indices = new List<int>();

                    for (int i = fila - 1; i > 0; i -= 1)
                    {
                        if ((i - 1) < 0 || bidiFichas2[i - 1, columna].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas2[i, columna].color == bidiFichas2[i - 1, columna].color)
                        {
                            indices.Add(i);
                        }
                        else if (bidiFichas2[i, columna].color != bidiFichas2[fila, columna].color)
                        {
                            indices.Add(i);
                            foreach (var item in indices)
                            {
                                bidiFichas2[item, columna].color = bidiFichas2[fila, columna].color;
                            }
                            break;
                        }
                    }

                }
            }

            //ARRIBA-DERECHA
            if (fila > 0 && columna < (columnasXtreme - 1))
            {
                if (bidiFichas2[fila - 1, columna + 1].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas2[fila, columna].color != bidiFichas2[fila - 1, columna + 1].color)
                {
                    Stack<int> indiceX = new Stack<int>();
                    Stack<int> indiceY = new Stack<int>();

                    indiceX.Push(0);
                    indiceY.Push(0);

                    int i = fila - 1;
                    int j = columna + 1;

                    while (i > 0 && j < columnasXtreme)
                    {
                        if ((i - 1) < 0 || (j + 1) > (columnasXtreme - 1) || bidiFichas2[i - 1, j + 1].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas2[i, j].color == bidiFichas2[i - 1, j + 1].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                        }
                        else if (bidiFichas2[i, j].color != bidiFichas2[fila, columna].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                            int maximo = indiceX.Count();
                            for (int k = 0; k < maximo - 1; k++)
                            {
                                int x = indiceY.Pop();
                                int y = indiceX.Pop();
                                bidiFichas2[x, y].color = bidiFichas2[fila, columna].color;
                            }
                            break;
                        }
                        i -= 1;
                        j += 1;
                    }
                }
            }


            //DERECHA
            if (columna < (columnasXtreme - 1))
            {
                if (bidiFichas2[fila, columna + 1].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas2[fila, columna].color != bidiFichas2[fila, columna + 1].color)
                {
                    List<int> indices = new List<int>();

                    for (int i = columna + 1; i < filasXtreme; i += 1)
                    {
                        if ((i + 1) > (filasXtreme - 1) || bidiFichas2[fila, i + 1].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas2[fila, i].color == bidiFichas2[fila, i + 1].color)
                        {
                            indices.Add(i);
                        }
                        else if (bidiFichas2[fila, i].color != bidiFichas2[fila, columna].color)
                        {
                            indices.Add(i);
                            foreach (var item in indices)
                            {
                                bidiFichas2[fila, item].color = bidiFichas2[fila, columna].color;
                            }
                            break;
                        }
                    }

                }
            }

            //DERECHA-ABAJO
            if (fila < (filasXtreme - 1) && columna < (columnasXtreme - 1))
            {
                if (bidiFichas2[fila + 1, columna + 1].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas2[fila, columna].color != bidiFichas2[fila + 1, columna + 1].color)
                {
                    Stack<int> indiceX = new Stack<int>();
                    Stack<int> indiceY = new Stack<int>();

                    indiceX.Push(0);
                    indiceY.Push(0);

                    int i = fila + 1;
                    int j = columna + 1;

                    while (i < filasXtreme && j < columnasXtreme)
                    {
                        if ((i + 1) > (filasXtreme - 1) || (j + 1) > (columnasXtreme - 1) || bidiFichas2[i + 1, j + 1].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas2[i, j].color == bidiFichas2[i + 1, j + 1].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                        }
                        else if (bidiFichas2[i, j].color != bidiFichas2[fila, columna].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                            int maximo = indiceX.Count();
                            for (int k = 0; k < maximo - 1; k++)
                            {
                                int x = indiceY.Pop();
                                int y = indiceX.Pop();
                                bidiFichas2[x, y].color = bidiFichas2[fila, columna].color;
                            }
                            break;
                        }
                        i += 1;
                        j += 1;
                    }
                }
            }


            //ABAJO
            if (fila < (filasXtreme - 1))
            {
                if (bidiFichas2[fila + 1, columna].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas2[fila, columna].color != bidiFichas2[fila + 1, columna].color)
                {
                    List<int> indices = new List<int>();

                    for (int i = fila + 1; i < filasXtreme; i += 1)
                    {
                        if ((i + 1) > (filasXtreme - 1) || bidiFichas2[i + 1, columna].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas2[i, columna].color == bidiFichas2[i + 1, columna].color)
                        {
                            indices.Add(i);
                        }
                        else if (bidiFichas2[i, columna].color != bidiFichas2[fila, columna].color)
                        {
                            indices.Add(i);
                            foreach (var item in indices)
                            {
                                bidiFichas2[item, columna].color = bidiFichas2[fila, columna].color;
                            }
                            break;
                        }
                    }

                }
            }

            //ABAJO-IZQUIERDA
            if (fila < (filasXtreme - 1) && columna > 0)
            {
                if (bidiFichas2[fila + 1, columna - 1].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas2[fila, columna].color != bidiFichas2[fila + 1, columna - 1].color)
                {
                    Stack<int> indiceX = new Stack<int>();
                    Stack<int> indiceY = new Stack<int>();

                    indiceX.Push(0);
                    indiceY.Push(0);

                    int i = fila + 1;
                    int j = columna - 1;

                    while (i < filasXtreme && j > 0)
                    {
                        if ((i + 1) > (filasXtreme - 1) || (j - 1) < 0 || bidiFichas2[i + 1, j - 1].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas2[i, j].color == bidiFichas2[i + 1, j - 1].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                        }
                        else if (bidiFichas2[i, j].color != bidiFichas2[fila, columna].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                            int maximo = indiceX.Count();
                            for (int k = 0; k < maximo - 1; k++)
                            {
                                int x = indiceY.Pop();
                                int y = indiceX.Pop();
                                bidiFichas2[x, y].color = bidiFichas2[fila, columna].color;
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
                if (bidiFichas2[fila, columna - 1].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas2[fila, columna].color != bidiFichas2[fila, columna - 1].color)
                {
                    List<int> indices = new List<int>();

                    for (int i = columna - 1; i > 0; i -= 1)
                    {
                        if ((i - 1) < 0 || bidiFichas2[fila, i - 1].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas2[fila, i].color == bidiFichas2[fila, i - 1].color)
                        {
                            indices.Add(i);
                        }
                        else if (bidiFichas2[fila, i].color != bidiFichas2[fila, columna].color)
                        {
                            indices.Add(i);
                            foreach (var item in indices)
                            {
                                bidiFichas2[fila, item].color = bidiFichas2[fila, columna].color;
                            }
                            break;
                        }
                    }

                }
            }

            //IZQUIERDA-ARRIBA
            if (fila > 0 && columna > 0)
            {
                if (bidiFichas2[fila - 1, columna - 1].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas2[fila, columna].color != bidiFichas2[fila - 1, columna - 1].color)
                {
                    Stack<int> indiceX = new Stack<int>();
                    Stack<int> indiceY = new Stack<int>();

                    indiceX.Push(0);
                    indiceY.Push(0);

                    int i = fila - 1;
                    int j = columna - 1;

                    while (i > 0 && j > 0)
                    {
                        if ((i - 1) < 0 || (j - 1) < 0 || bidiFichas2[i - 1, j - 1].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas2[i, j].color == bidiFichas2[i - 1, j - 1].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                        }
                        else if (bidiFichas2[i, j].color != bidiFichas2[fila, columna].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                            int maximo = indiceX.Count();
                            for (int k = 0; k < maximo - 1; k++)
                            {
                                int x = indiceY.Pop();
                                int y = indiceX.Pop();
                                bidiFichas2[x, y].color = bidiFichas2[fila, columna].color;
                            }
                            break;
                        }
                        i -= 1;
                        j -= 1;
                    }
                }
            }
        }

        public void CambiarX2(int fila, int columna)
        {

            //ARRIBA
            if (fila > 0)
            {
                if (bidiFichas3[fila - 1, columna].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas3[fila, columna].color != bidiFichas3[fila - 1, columna].color)
                {
                    List<int> indices = new List<int>();

                    for (int i = fila - 1; i > 0; i -= 1)
                    {
                        if ((i - 1) < 0 || bidiFichas3[i - 1, columna].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas3[i, columna].color == bidiFichas3[i - 1, columna].color)
                        {
                            indices.Add(i);
                        }
                        else if (bidiFichas3[i, columna].color != bidiFichas3[fila, columna].color)
                        {
                            indices.Add(i);
                            foreach (var item in indices)
                            {
                                bidiFichas2[item, columna].color = bidiFichas2[fila, columna].color;
                            }
                            break;
                        }
                    }

                }
            }

            //ARRIBA-DERECHA
            if (fila > 0 && columna < (columnasXtreme - 1))
            {
                if (bidiFichas3[fila - 1, columna + 1].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas3[fila, columna].color != bidiFichas3[fila - 1, columna + 1].color)
                {
                    Stack<int> indiceX = new Stack<int>();
                    Stack<int> indiceY = new Stack<int>();

                    indiceX.Push(0);
                    indiceY.Push(0);

                    int i = fila - 1;
                    int j = columna + 1;

                    while (i > 0 && j < columnasXtreme)
                    {
                        if ((i - 1) < 0 || (j + 1) > (columnasXtreme - 1) || bidiFichas3[i - 1, j + 1].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas3[i, j].color == bidiFichas3[i - 1, j + 1].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                        }
                        else if (bidiFichas3[i, j].color != bidiFichas3[fila, columna].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                            int maximo = indiceX.Count();
                            for (int k = 0; k < maximo - 1; k++)
                            {
                                int x = indiceY.Pop();
                                int y = indiceX.Pop();
                                bidiFichas2[x, y].color = bidiFichas2[fila, columna].color;
                            }
                            break;
                        }
                        i -= 1;
                        j += 1;
                    }
                }
            }


            //DERECHA
            if (columna < (columnasXtreme - 1))
            {
                if (bidiFichas3[fila, columna + 1].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas3[fila, columna].color != bidiFichas3[fila, columna + 1].color)
                {
                    List<int> indices = new List<int>();

                    for (int i = columna + 1; i < columnasXtreme; i += 1)
                    {
                        if ((i + 1) > (columnasXtreme - 1) || bidiFichas3[fila, i + 1].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas3[fila, i].color == bidiFichas3[fila, i + 1].color)
                        {
                            indices.Add(i);
                        }
                        else if (bidiFichas3[fila, i].color != bidiFichas3[fila, columna].color)
                        {
                            indices.Add(i);
                            foreach (var item in indices)
                            {
                                bidiFichas2[fila, item].color = bidiFichas2[fila, columna].color;
                            }
                            break;
                        }
                    }

                }
            }

            //DERECHA-ABAJO
            if (fila < (filasXtreme - 1) && columna < (columnasXtreme - 1))
            {
                if (bidiFichas3[fila + 1, columna + 1].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas3[fila, columna].color != bidiFichas3[fila + 1, columna + 1].color)
                {
                    Stack<int> indiceX = new Stack<int>();
                    Stack<int> indiceY = new Stack<int>();

                    indiceX.Push(0);
                    indiceY.Push(0);

                    int i = fila + 1;
                    int j = columna + 1;

                    while (i < filasXtreme && j < columnasXtreme)
                    {
                        if ((i + 1) > (filasXtreme - 1) || (j + 1) > (columnasXtreme - 1) || bidiFichas3[i + 1, j + 1].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas3[i, j].color == bidiFichas3[i + 1, j + 1].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                        }
                        else if (bidiFichas3[i, j].color != bidiFichas3[fila, columna].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                            int maximo = indiceX.Count();
                            for (int k = 0; k < maximo - 1; k++)
                            {
                                int x = indiceY.Pop();
                                int y = indiceX.Pop();
                                bidiFichas2[x, y].color = bidiFichas2[fila, columna].color;
                            }
                            break;
                        }
                        i += 1;
                        j += 1;
                    }
                }
            }


            //ABAJO
            if (fila < (filasXtreme - 1))
            {
                if (bidiFichas3[fila + 1, columna].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas3[fila, columna].color != bidiFichas3[fila + 1, columna].color)
                {
                    List<int> indices = new List<int>();

                    for (int i = fila + 1; i < filasXtreme; i += 1)
                    {
                        if ((i + 1) > (filasXtreme - 1) || bidiFichas3[i + 1, columna].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas3[i, columna].color == bidiFichas3[i + 1, columna].color)
                        {
                            indices.Add(i);
                        }
                        else if (bidiFichas3[i, columna].color != bidiFichas3[fila, columna].color)
                        {
                            indices.Add(i);
                            foreach (var item in indices)
                            {
                                bidiFichas2[item, columna].color = bidiFichas2[fila, columna].color;
                            }
                            break;
                        }
                    }

                }
            }

            //ABAJO-IZQUIERDA
            if (fila < (filasXtreme - 1) && columna > 0)
            {
                if (bidiFichas3[fila + 1, columna - 1].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas3[fila, columna].color != bidiFichas3[fila + 1, columna - 1].color)
                {
                    Stack<int> indiceX = new Stack<int>();
                    Stack<int> indiceY = new Stack<int>();

                    indiceX.Push(0);
                    indiceY.Push(0);

                    int i = fila + 1;
                    int j = columna - 1;

                    while (i < filasXtreme && j > 0)
                    {
                        if ((i + 1) > (filasXtreme - 1) || (j - 1) < 0 || bidiFichas3[i + 1, j - 1].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas3[i, j].color == bidiFichas3[i + 1, j - 1].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                        }
                        else if (bidiFichas3[i, j].color != bidiFichas3[fila, columna].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                            int maximo = indiceX.Count();
                            for (int k = 0; k < maximo - 1; k++)
                            {
                                int x = indiceY.Pop();
                                int y = indiceX.Pop();
                                bidiFichas2[x, y].color = bidiFichas2[fila, columna].color;
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
                if (bidiFichas3[fila, columna - 1].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas3[fila, columna].color != bidiFichas3[fila, columna - 1].color)
                {
                    List<int> indices = new List<int>();

                    for (int i = columna - 1; i > 0; i -= 1)
                    {
                        if ((i - 1) < 0 || bidiFichas3[fila, i - 1].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas3[fila, i].color == bidiFichas3[fila, i - 1].color)
                        {
                            indices.Add(i);
                        }
                        else if (bidiFichas3[fila, i].color != bidiFichas3[fila, columna].color)
                        {
                            indices.Add(i);
                            foreach (var item in indices)
                            {
                                bidiFichas2[fila, item].color = bidiFichas2[fila, columna].color;
                            }
                            break;
                        }
                    }

                }
            }

            //IZQUIERDA-ARRIBA
            if (fila > 0 && columna > 0)
            {
                if (bidiFichas3[fila - 1, columna - 1].color == "")
                {
                    int nu = 0;
                }
                else if (bidiFichas3[fila, columna].color != bidiFichas3[fila - 1, columna - 1].color)
                {
                    Stack<int> indiceX = new Stack<int>();
                    Stack<int> indiceY = new Stack<int>();

                    indiceX.Push(0);
                    indiceY.Push(0);

                    int i = fila - 1;
                    int j = columna - 1;

                    while (i > 0 && j > 0)
                    {
                        if ((i - 1) < 0 || (j - 1) < 0 || bidiFichas3[i - 1, j - 1].color.Equals(""))
                        {
                            break;
                        }
                        else if (bidiFichas3[i, j].color == bidiFichas3[i - 1, j - 1].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                        }
                        else if (bidiFichas3[i, j].color != bidiFichas3[fila, columna].color)
                        {
                            indiceY.Push(i);
                            indiceX.Push(j);
                            int maximo = indiceX.Count();
                            for (int k = 0; k < maximo - 1; k++)
                            {
                                int x = indiceY.Pop();
                                int y = indiceX.Pop();
                                bidiFichas2[x, y].color = bidiFichas2[fila, columna].color;
                            }
                            break;
                        }
                        i -= 1;
                        j -= 1;
                    }
                }
            }
        }

        public int contarNegras()
        {
            int contador = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
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

        public int contarJ1()
        {
            int contador = 0;
            for (int i = 0; i < filasXtreme; i++)
            {
                for (int j = 0; j < columnasXtreme; j++)
                {
                    if (buscarL1(bidiFichas2[i, j].color))
                    {
                        contador += 1;
                    }

                }
            }
            return contador;
        }

        public int contarJ2()
        {
            int contador = 0;
            for (int i = 0; i < filasXtreme; i++)
            {
                for (int j = 0; j < columnasXtreme; j++)
                {
                    if (buscarL2(bidiFichas2[i, j].color))
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

            Cambiar(fila, columna);
            Verificar(turno);


            int verificadas = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (bidiFichas[i, j].permitida.Equals("si"))
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
                    ViewBag.ganador = "El ganador es:" + IPC2.Controllers.CuentaController.usuario;
                    using (var db = new OthelloEntities())
                    {
                        Partida partidita = new Partida();
                        partidita.id_tipo_partida = 2;
                        partidita.id_estado = 1;

                        Partida_Jugador partida_jug = new Partida_Jugador();
                        partida_jug.id_partida = partidita.id_partida;
                        partida_jug.nickname = IPC2.Controllers.CuentaController.usuario;

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
                        partida_jug.nickname = IPC2.Controllers.CuentaController.usuario;

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
                        tirosMaquina.Add(bidiFichas[i, j]);
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
                    ViewBag.ganador = "El ganador es :" + IPC2.Controllers.CuentaController.usuario;
                    using (var db = new OthelloEntities())
                    {
                        Partida partidita = new Partida();
                        partidita.id_tipo_partida = 1;
                        partidita.id_estado = 1;

                        Partida_Jugador partida_jug = new Partida_Jugador();
                        partida_jug.id_partida = partidita.id_partida;
                        partida_jug.nickname = IPC2.Controllers.CuentaController.usuario;

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
                        partida_jug.nickname = IPC2.Controllers.CuentaController.usuario;

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
                    for (int i = 0; i < 8; i++)
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
                    if (item.color == "negro")
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
            string[] letras = { "A", "B", "C", "D", "E", "F", "G", "H" };

            using (StreamWriter outputFile = new StreamWriter("C:\\Users\\Amc\\Desktop\\AS\\Programacion\\Visual\\IPC2 Proyect\\IPC2\\files\\guardado.xml"))
            {
                outputFile.WriteLine("<tablero>");
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (bidiFichas[i, j].color.Equals("fa-circle"))
                        {
                            outputFile.WriteLine("  <ficha>");
                            outputFile.WriteLine("      <color>negro</color>");
                            outputFile.WriteLine("      <fila>" + (i + 1) + "</fila>");
                            outputFile.WriteLine("      <columna>" + letras[j] + "</columna>");
                            outputFile.WriteLine("  </ficha>");
                        }
                        else if (bidiFichas[i, j].color.Equals("fa-circle white"))
                        {
                            outputFile.WriteLine("  <ficha>");
                            outputFile.WriteLine("      <color>blanco</color>");
                            outputFile.WriteLine("      <fila>" + (i + 1) + "</fila>");
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
        public ActionResult InicializarXtream(int filas, int columnas, int c1, int c2, string mo)
        {

            filasXtreme = filas;
            columnasXtreme = columnas;
            ViewBag.c1 = c1;
            ViewBag.c2 = c2;
            modalidadXtream = mo;
            return View();
        }

        [HttpPost]

        public ActionResult Xtream1(string j1c0 = "", string j1c1 = "", string j1c2 = "", string j1c3 = "", string j1c4 = "",
                                   string j2c0 = "", string j2c1 = "", string j2c2 = "", string j2c3 = "", string j2c4 = "")
        {
            coloresJ1 = new List<string>();
            coloresJ2 = new List<string>();

            if (j1c0 != "")
            {
                coloresJ1.Add(j1c0);
            }
            if (j1c1 != "")
            {
                coloresJ1.Add(j1c1);
            }
            if (j1c2 != "")
            {
                coloresJ1.Add(j1c2);
            }
            if (j1c3 != "")
            {
                coloresJ1.Add(j1c3);
            }
            if (j1c4 != "")
            {
                coloresJ1.Add(j1c4);
            }
            if (j2c0 != "")
            {
                coloresJ2.Add(j2c0);
            }
            if (j2c1 != "")
            {
                coloresJ2.Add(j2c1);
            }
            if (j2c2 != "")
            {
                coloresJ2.Add(j2c2);
            }
            if (j2c3 != "")
            {
                coloresJ2.Add(j2c3);
            }
            if (j2c4 != "")
            {
                coloresJ2.Add(j2c4);
            }


            //INICIALIZAR TABLERO
            bidiFichas2 = new Fichas[filasXtreme, columnasXtreme];
            bidiFichas3 = new Fichas[filasXtreme, columnasXtreme];

            for (int i = 0; i < filasXtreme; i++)
            {
                for (int j = 0; j < columnasXtreme; j++)
                {
                    bidiFichas2[i, j] = new Fichas(i.ToString(), j.ToString());
                }
            }

            int mitadF = (filasXtreme - 2) / 2;
            int mitadC = (columnasXtreme - 2) / 2;

            bidiFichas2[mitadF, mitadC] = new Fichas(mitadF.ToString(), mitadC.ToString(), per: "si");
            bidiFichas2[mitadF + 1, mitadC + 1] = new Fichas((mitadF + 1).ToString(), (mitadC + 1).ToString(), per: "si");
            bidiFichas2[mitadF + 1, mitadC] = new Fichas((mitadF + 1).ToString(), (mitadC + 1).ToString(), per: "si");
            bidiFichas2[mitadF, mitadC + 1] = new Fichas((mitadC + 1).ToString(), (mitadF + 1).ToString(), per: "si");




            return RedirectToAction("Xtream");
        }

        public ActionResult Xtream()
        {
            indice1 = 0;
            indice2 = 0;
            ViewBag.turno = "J1";
            ViewBag.turno_color = coloresJ1[indice1];
            indice1++;

            ViewBag.filas = filasXtreme;
            ViewBag.columnas = columnasXtreme;
            return View(bidiFichas2);
        }


        [HttpPost]

        public ActionResult Xtream(int fila, int columna, string color, string turno)
        {
            string turn = turno;
            ViewBag.filas = filasXtreme;
            ViewBag.columnas = columnasXtreme;
            ViewBag.ganador = "";
            bidiFichas2[fila, columna] = new Fichas(fila.ToString(), columna.ToString(), color);


            int mitadF = (filasXtreme - 2) / 2;
            int mitadC = (columnasXtreme - 2) / 2;

            if (turn.Equals("J1"))
            {
                if (coloresJ2.Count() == (indice2 + 1))
                {
                    ViewBag.turno_color = coloresJ2[indice2++];
                    indice2 = 0;
                    ViewBag.turno = "J2";
                    turn = "J2";
                }
                else
                {
                    ViewBag.turno_color = coloresJ2[indice2++];
                    ViewBag.turno = "J2";
                    turn = "J2";
                }
            }
            else
            {
                if (coloresJ1.Count() == (indice1 + 1))
                {
                    ViewBag.turno_color = coloresJ1[indice1++];
                    indice1 = 0;
                    ViewBag.turno = "J1";
                    turn = "J1";
                }
                else
                {
                    ViewBag.turno_color = coloresJ1[indice1++];
                    ViewBag.turno = "J1";
                    turn = "J1";
                }
            }


            if (bidiFichas2[mitadF, mitadC].color != "" && bidiFichas2[mitadF + 1, mitadC + 1].color != "" &&
                bidiFichas2[mitadF + 1, mitadC].color != "" && bidiFichas2[mitadF, mitadC + 1].color != "")
            {



                for (int i = 0; i < filasXtreme; i++)
                {
                    for (int j = 0; j < columnasXtreme; j++)
                    {
                        bidiFichas3[i, j] = new Fichas(i.ToString(), j.ToString());

                        bidiFichas3[i, j].color = bidiFichas2[i, j].color;

                        bidiFichas2[i, j].permitida = "no";




                        if (ViewBag.turno == "J1")
                        {
                            if (buscarL1(bidiFichas3[i, j].color))
                            {
                                bidiFichas3[i, j].color = ViewBag.turno_color;
                            }
                        }
                        else
                        {
                            if (buscarL2(bidiFichas3[i, j].color))
                            {
                                bidiFichas3[i, j].color = ViewBag.turno_color;
                            }
                        }


                    }
                }


                CambiarX2(fila, columna);

                VerificarX2(ViewBag.turno_color);

            }
            else
            {
                if (bidiFichas2[mitadF, mitadC].color != "")
                {
                    bidiFichas2[mitadF, mitadC].permitida = "no";
                }

                if (bidiFichas2[mitadF + 1, mitadC + 1].color != "")
                {
                    bidiFichas2[mitadF + 1, mitadC + 1].permitida = "no";
                }

                if (bidiFichas2[mitadF + 1, mitadC].color != "")
                {
                    bidiFichas2[mitadF + 1, mitadC].permitida = "no";
                }

                if (bidiFichas2[mitadF, mitadC + 1].color != "")
                {
                    bidiFichas2[mitadF, mitadC + 1].permitida = "no";
                }

            }

            int verificadas = 0;

            for (int i = 0; i < filasXtreme; i++)
            {
                for (int j = 0; j < columnasXtreme; j++)
                {
                    if (bidiFichas2[i, j].permitida.Equals("si"))
                    {
                        verificadas += 1;
                    }
                }
            }

            ViewBag.mensaje = "";

            if (verificadas == 0)
            {
                if (turn.Equals("J1"))
                {
                    if (coloresJ2.Count() == (indice2 + 1))
                    {
                        ViewBag.turno_color = coloresJ2[indice2++];
                        indice2 = 0;
                        ViewBag.turno = "J2";
                    }
                    else
                    {
                        ViewBag.turno_color = coloresJ2[indice2++];
                        ViewBag.turno = "J2";
                    }
                    ViewBag.mensaje = "Cambio de turno";
                }
                else
                {
                    if (coloresJ1.Count() == (indice1 + 1))
                    {
                        ViewBag.turno_color = coloresJ1[indice1++];
                        indice1 = 0;
                        ViewBag.turno = "J1";
                    }
                    else
                    {
                        ViewBag.turno_color = coloresJ1[indice1++];
                        ViewBag.turno = "J1";
                    }
                    ViewBag.mensaje = "Cambio de turno";
                }

                for (int i = 0; i < filasXtreme; i++)
                {
                    for (int j = 0; j < columnasXtreme; j++)
                    {

                        bidiFichas3[i, j].color = bidiFichas2[i, j].color;

                        bidiFichas2[i, j].permitida = "no";

                        if (ViewBag.turno == "J1")
                        {
                            if (buscarL1(bidiFichas3[i, j].color))
                            {
                                bidiFichas3[i, j].color = ViewBag.turno_color;
                            }
                        }
                        else
                        {
                            if (buscarL2(bidiFichas3[i, j].color))
                            {
                                bidiFichas3[i, j].color = ViewBag.turno_color;
                            }
                        }


                    }
                }

                VerificarX2(ViewBag.turno_color);


                verificadas = 0;

                for (int i = 0; i < filasXtreme; i++)
                {
                    for (int j = 0; j < columnasXtreme; j++)
                    {
                        if (bidiFichas2[i, j].permitida.Equals("si"))
                        {
                            verificadas += 1;
                        }
                    }
                }



                if (verificadas == 0)
                {
                    ViewBag.mensaje = "No queda tiro para ningun jugador";
                    ViewBag.ganador = "";
                    if (contarJ1() < contarJ2() && (contarJ1() + contarJ2() != (filasXtreme*columnasXtreme)) && (modalidadXtream.Equals("normal")))
                    {
                        ViewBag.ganador = "El ganador es: " + IPC2.Controllers.CuentaController.usuario;

                        using (var db = new OthelloEntities())
                        {
                            Partida partidita = new Partida();
                            partidita.id_tipo_partida = 3;
                            partidita.id_estado = 1;

                            Partida_Jugador partida_jug = new Partida_Jugador();
                            partida_jug.id_partida = partidita.id_partida;
                            partida_jug.nickname = IPC2.Controllers.CuentaController.usuario;

                            db.Partida.Add(partidita);
                            db.Partida_Jugador.Add(partida_jug);

                            db.SaveChanges();
                        }

                    }
                    else if (contarJ1() > contarJ2() && (contarJ1() + contarJ2() != (filasXtreme * columnasXtreme)) && (modalidadXtream.Equals("normal")))
                    {
                        ViewBag.ganador = "El ganador es: " + IPC2.Controllers.CuentaController.usuario;

                        using (var db = new OthelloEntities())
                        {
                            Partida partidita = new Partida();
                            partidita.id_tipo_partida = 3;
                            partidita.id_estado = 1;

                            Partida_Jugador partida_jug = new Partida_Jugador();
                            partida_jug.id_partida = partidita.id_partida;
                            partida_jug.nickname = IPC2.Controllers.CuentaController.usuario;

                            db.Partida.Add(partidita);
                            db.Partida_Jugador.Add(partida_jug);

                            db.SaveChanges();
                        }

                    }
                    else if (contarJ1() == contarJ2() && (contarJ1() + contarJ2() != (filasXtreme * columnasXtreme)))
                    {
                        ViewBag.ganador = "Empate";

                        using (var db = new OthelloEntities())
                        {
                            Partida partidita = new Partida();
                            partidita.id_tipo_partida = 3;
                            partidita.id_estado = 3;

                            Partida_Jugador partida_jug = new Partida_Jugador();
                            partida_jug.id_partida = partidita.id_partida;
                            partida_jug.nickname = IPC2.Controllers.CuentaController.usuario;

                            db.Partida.Add(partidita);
                            db.Partida_Jugador.Add(partida_jug);

                            db.SaveChanges();
                        }
                    }
                    else if (contarJ1() > contarJ2() && (contarJ1() + contarJ2() != (filasXtreme * columnasXtreme)) && (modalidadXtream.Equals("inversa"))) 
                    {
                        ViewBag.ganador = "El ganador es: Jugador Invitado";
                        using (var db = new OthelloEntities())
                        {
                            Partida partidita = new Partida();
                            partidita.id_tipo_partida = 3;
                            partidita.id_estado = 2;

                            Partida_Jugador partida_jug = new Partida_Jugador();
                            partida_jug.id_partida = partidita.id_partida;
                            partida_jug.nickname = IPC2.Controllers.CuentaController.usuario;

                            db.Partida.Add(partidita);
                            db.Partida_Jugador.Add(partida_jug);

                            db.SaveChanges();
                        }
                    }
                    else if (contarJ1() < contarJ2() && (contarJ1() + contarJ2() != (filasXtreme * columnasXtreme)) && (modalidadXtream.Equals("normal")))
                    {
                        ViewBag.ganador = "El ganador es: Jugador Invitado";
                        using (var db = new OthelloEntities())
                        {
                            Partida partidita = new Partida();
                            partidita.id_tipo_partida = 3;
                            partidita.id_estado = 2;

                            Partida_Jugador partida_jug = new Partida_Jugador();
                            partida_jug.id_partida = partidita.id_partida;
                            partida_jug.nickname = IPC2.Controllers.CuentaController.usuario;

                            db.Partida.Add(partidita);
                            db.Partida_Jugador.Add(partida_jug);

                            db.SaveChanges();
                        }
                    }
                }

            }


            if (contarJ1() + contarJ2() == (filasXtreme * columnasXtreme))
            {
                if (contarJ1() < contarJ2() && modalidadXtream.Equals("inversa"))
                {
                    ViewBag.ganador = "El ganador es: " + IPC2.Controllers.CuentaController.usuario;

                    using (var db = new OthelloEntities())
                    {
                        Partida partidita = new Partida();
                        partidita.id_tipo_partida = 3;
                        partidita.id_estado = 1;

                        Partida_Jugador partida_jug = new Partida_Jugador();
                        partida_jug.id_partida = partidita.id_partida;
                        partida_jug.nickname = IPC2.Controllers.CuentaController.usuario;

                        db.Partida.Add(partidita);
                        db.Partida_Jugador.Add(partida_jug);

                        db.SaveChanges();
                    }
                }
                else if (contarJ1() > contarJ2() && modalidadXtream.Equals("normal"))
                {
                    ViewBag.ganador = "El ganador es: " + IPC2.Controllers.CuentaController.usuario;

                    using (var db = new OthelloEntities())
                    {
                        Partida partidita = new Partida();
                        partidita.id_tipo_partida = 3;
                        partidita.id_estado = 1;

                        Partida_Jugador partida_jug = new Partida_Jugador();
                        partida_jug.id_partida = partidita.id_partida;
                        partida_jug.nickname = IPC2.Controllers.CuentaController.usuario;

                        db.Partida.Add(partidita);
                        db.Partida_Jugador.Add(partida_jug);

                        db.SaveChanges();
                    }
                }
                else if (contarJ1() == contarJ2())
                {
                    ViewBag.ganador = "Empate";

                    using (var db = new OthelloEntities())
                    {
                        Partida partidita = new Partida();
                        partidita.id_tipo_partida = 3;
                        partidita.id_estado = 3;

                        Partida_Jugador partida_jug = new Partida_Jugador();
                        partida_jug.id_partida = partidita.id_partida;
                        partida_jug.nickname = IPC2.Controllers.CuentaController.usuario;

                        db.Partida.Add(partidita);
                        db.Partida_Jugador.Add(partida_jug);

                        db.SaveChanges();
                    }
                }
                else if (contarJ1() > contarJ2() && modalidadXtream.Equals("inversa"))
                {
                    ViewBag.ganador = "El ganador es: Jugador Invitado";
                    using (var db = new OthelloEntities())
                    {
                        Partida partidita = new Partida();
                        partidita.id_tipo_partida = 3;
                        partidita.id_estado = 2;

                        Partida_Jugador partida_jug = new Partida_Jugador();
                        partida_jug.id_partida = partidita.id_partida;
                        partida_jug.nickname = IPC2.Controllers.CuentaController.usuario;

                        db.Partida.Add(partidita);
                        db.Partida_Jugador.Add(partida_jug);

                        db.SaveChanges();
                    }

                }
                else if (contarJ1() < contarJ2() && modalidadXtream.Equals("normal"))
                {
                    ViewBag.ganador = "El ganador es: Jugador Invitado";
                    using (var db = new OthelloEntities())
                    {
                        Partida partidita = new Partida();
                        partidita.id_tipo_partida = 3;
                        partidita.id_estado = 2;

                        Partida_Jugador partida_jug = new Partida_Jugador();
                        partida_jug.id_partida = partidita.id_partida;
                        partida_jug.nickname = IPC2.Controllers.CuentaController.usuario;

                        db.Partida.Add(partidita);
                        db.Partida_Jugador.Add(partida_jug);

                        db.SaveChanges();
                    }
                }
            }
            ViewBag.numeroJ1 = contarJ1();
            ViewBag.numeroJ2 = contarJ2();

            return View(bidiFichas2);
        }

        public List<string> cambiarColores(List<string> lista)
        {
            List<string> nueva = new List<string>();

            foreach (String color in lista)
            {
                if (color.Equals("rojo"))
                {
                    nueva.Add("#f23d3d");
                }
                else if (color.Equals("amarillo"))
                {
                    nueva.Add("#f2b705");
                }
                else if (color.Equals("azul"))
                {
                    nueva.Add("#024059");
                }
                else if (color.Equals("anaranjado"))
                {
                    nueva.Add("#f25c05");
                }
                else if (color.Equals("verde"))
                {
                    nueva.Add("#618033");
                }
                else if (color.Equals("violeta"))
                {
                    nueva.Add("#523380");
                }
                else if (color.Equals("blanco"))
                {
                    nueva.Add("#FFFFFF");
                }
                else if (color.Equals("negro"))
                {
                    nueva.Add("#000000");
                }
                else if (color.Equals("celeste"))
                {
                    nueva.Add("#04bfbf");
                }
                else if (color.Equals("gris"))
                {
                    nueva.Add("#7b836a");
                }
            }
            return nueva;
        }

        public string cambiarColores2(string color)
        {
            string nueva = "#000000";

            if (color.Equals("rojo"))
            {
                nueva = "#f23d3d";
            }
            else if (color.Equals("amarillo"))
            {
                nueva = "#f2b705";
            }
            else if (color.Equals("azul"))
            {
                nueva = "#024059";
            }
            else if (color.Equals("anaranjado"))
            {
                nueva = "#f25c05";
            }
            else if (color.Equals("verde"))
            {
                nueva = "#618033";
            }
            else if (color.Equals("violeta"))
            {
                nueva = "#523380";
            }
            else if (color.Equals("blanco"))
            {
                nueva = "#FFFFFF";
            }
            else if (color.Equals("negro"))
            {
                nueva = "#000000";
            }
            else if (color.Equals("celeste"))
            {
                nueva = "#04bfbf";
            }
            else if (color.Equals("gris"))
            {
                nueva = "#7b836a";
            }

            return nueva;
        }

        [HttpPost]
        public ActionResult UploadXtream()
        {
            try
            {
                List<Fichas> empList = new List<Fichas>();
                configuraciones = new TableroConfi();
                List<string> colores1 = new List<string>();
                List<string> colores2 = new List<string>();

                var xmlFile = Request.Files[0];
                if (xmlFile != null && xmlFile.ContentLength > 0)
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(xmlFile.InputStream);
                    XmlNodeList empNodes = xmlDocument.SelectNodes("partida/tablero/ficha");
                    foreach (XmlNode emp in empNodes)
                    {
                        empList.Add(new Fichas()
                        {
                            color = emp["color"].InnerText,
                            columna = emp["columna"].InnerText,
                            fila = emp["fila"].InnerText,
                        });
                    }

                    //Filas y Columnas
                    XmlNode empNodes2 = xmlDocument.SelectSingleNode("partida");
                    configuraciones.filas = empNodes2["filas"].InnerText;
                    configuraciones.columnas = empNodes2["columnas"].InnerText;

                    //Colores 1
                    XmlNodeList empNodes3 = xmlDocument.SelectNodes("partida/Jugador1/color");
                    foreach (XmlNode emp in empNodes3)
                    {
                        colores1.Add(emp.InnerText);
                    }
                    configuraciones.colores1 = colores1;

                    //Colores 2
                    XmlNodeList empNodes4 = xmlDocument.SelectNodes("partida/Jugador2/color");
                    foreach (XmlNode emp in empNodes4)
                    {
                        colores2.Add(emp.InnerText);
                    }
                    configuraciones.colores2 = colores2;

                    //modalidad
                    XmlNode empNodes5 = xmlDocument.SelectSingleNode("partida");
                    modalidadXtream = empNodes2["Modalidad"].InnerText;


                    TempData["tableroDataXtream"] = empList;
                    TempData["confi"] = configuraciones;
                }
                return RedirectToAction("CargarXtream");
            }
            catch (Exception)
            {
                return RedirectToAction("CargarXtream");
            }
        }

        public ActionResult CargarXtream()
        {
            if (TempData["tableroDataXtream"] == null)
            {
                ViewBag.ShowList = false;
                return View();
            }
            else
            {
                List<Fichas> empList = (List<Fichas>)TempData["tableroDataXtream"];
                TableroConfi confi = (TableroConfi)TempData["confi"];

                filasXtreme = Int32.Parse(confi.filas);
                columnasXtreme = Int32.Parse(confi.columnas);

                coloresJ1 = cambiarColores(confi.colores1);
                coloresJ2 = cambiarColores(confi.colores2);

                string[] letras = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T" };

                //INICIALIZAR TABLERO
                bidiFichas2 = new Fichas[filasXtreme, columnasXtreme];
                bidiFichas3 = new Fichas[filasXtreme, columnasXtreme];

                for (int i = 0; i < filasXtreme; i++)
                {
                    for (int j = 0; j < columnasXtreme; j++)
                    {
                        bidiFichas2[i, j] = new Fichas(i.ToString(), j.ToString());
                    }
                }

                int mitadF = (filasXtreme - 2) / 2;
                int mitadC = (columnasXtreme - 2) / 2;

                bidiFichas2[mitadF, mitadC] = new Fichas(mitadF.ToString(), mitadC.ToString(), per: "si");
                bidiFichas2[mitadF + 1, mitadC + 1] = new Fichas((mitadF + 1).ToString(), (mitadC + 1).ToString(), per: "si");
                bidiFichas2[mitadF + 1, mitadC] = new Fichas((mitadF + 1).ToString(), (mitadC + 1).ToString(), per: "si");
                bidiFichas2[mitadF, mitadC + 1] = new Fichas((mitadC + 1).ToString(), (mitadF + 1).ToString(), per: "si");

                foreach (var item in empList)
                {
                    int posicion = 0;
                    for (int i = 0; i < columnasXtreme; i++)
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

                    int fila = Int32.Parse(item.fila) - 1;
                    bidiFichas2[fila, posicion] = new Fichas(fila.ToString(), posicion.ToString(), cambiarColores2(item.color));
                }

                ViewBag.turno = "J1";

                if (ViewBag.turno.Equals("J1"))
            {
                if (coloresJ2.Count() == (indice2 + 1))
                {
                    ViewBag.turno_color = coloresJ2[indice2++];
                    indice2 = 0;
                    ViewBag.turno = "J2";
                }
                else
                {
                    ViewBag.turno_color = coloresJ2[indice2++];
                    ViewBag.turno = "J2";
                }
            }
            else
            {
                if (coloresJ1.Count() == (indice1 + 1))
                {
                    ViewBag.turno_color = coloresJ1[indice1++];
                    indice1 = 0;
                    ViewBag.turno = "J1";
                }
                else
                {
                    ViewBag.turno_color = coloresJ1[indice1++];
                    ViewBag.turno = "J1";
                }
            }

                for (int i = 0; i < filasXtreme; i++)
                {
                    for (int j = 0; j < columnasXtreme; j++)
                    {
                        bidiFichas3[i, j] = new Fichas(i.ToString(), j.ToString());

                        bidiFichas3[i, j].color = bidiFichas2[i, j].color;

                        bidiFichas2[i, j].permitida = "no";

                        if (ViewBag.turno == "J1")
                        {
                            if (buscarL1(bidiFichas3[i, j].color))
                            {
                                bidiFichas3[i, j].color = ViewBag.turno_color;
                            }
                        }
                        else
                        {
                            if (buscarL2(bidiFichas3[i, j].color))
                            {
                                bidiFichas3[i, j].color = ViewBag.turno_color;
                            }
                        }


                    }
                }

                VerificarX2(ViewBag.turno_color);
                ViewBag.ShowList = true;

                ViewBag.columnas = columnasXtreme;
                ViewBag.filas = filasXtreme;
                return View(bidiFichas2);
            }
        }

        [HttpPost]
        public ActionResult UploadTorneo()
        {
            try
            {
                Campeonato torneo = new Campeonato();
                
                List<Team> equipos = new List<Team>();

                var xmlFile = Request.Files[0];
                if (xmlFile != null && xmlFile.ContentLength > 0)
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(xmlFile.InputStream);

                    //Nombre Torneo
                    XmlNode empNodes = xmlDocument.SelectSingleNode("campeonato");
                    torneo.nombre = empNodes["nombre"].InnerText;

                    //Team
                    XmlNodeList empNodes2 = xmlDocument.SelectNodes("campeonato/equipo");
                    foreach (XmlNode emp in empNodes2)
                    {
                        Team equipo = new Team();
                        equipo.nombre = emp["nombreEquipo"].InnerText;

                        List<player> jugs = new List<player>();
                        
                        foreach (XmlNode empi in emp.SelectNodes("jugador"))
                        {
                            player jugador = new player(empi.InnerText);
                            jugs.Add(jugador);
                        }

                        equipo.jugadores = jugs;
                        equipos.Add(equipo);
                    }
                    torneo.equipos = equipos;
                    torneito = torneo;
                    TempData["Torneo"] = "si";
                }
                return RedirectToAction("CargarTorneo");
            }
            catch (Exception)
            {
                return RedirectToAction("CargarTorneo");
            }
        }

        public ActionResult CargarTorneo()
        {
            if (TempData["Torneo"] == null)
            {
                ViewBag.ShowList = false;
                return View();
            }
            ViewBag.ShowList = true;
            return View(torneito);
        }
    }
}
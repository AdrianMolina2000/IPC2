using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPC2.Models
{
    public class Fichas 
    {
        public Fichas()
        {

        }

        public string color { get; set; }
        public string columna { get; set; }
        public string fila { get; set; }
        public string permitida { get; set; }


        public Fichas(string fi, string col, string co = "", string per = "no")
        {
            fila = fi;
            columna = col;
            color = co;
            permitida = per;
        }
    }

    
}
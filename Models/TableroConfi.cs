using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPC2.Models
{
    public class TableroConfi
    {
        public TableroConfi()
        {

        }

        public List<string> colores1 { get; set; }
        public List<string> colores2 { get; set; }
        public string filas { get; set; }
        public string columnas { get; set; }

        public TableroConfi(List<string> c1, List<string> c2, string fi, string co)
        {
            filas = fi;
            columnas = co;
            colores1 = c1;
            colores2 = c2;
        }
    }
}



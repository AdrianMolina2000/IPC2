using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPC2.Models
{
    public class Ficha2
    {
        public Ficha2()
        {

        }

        public string color { get; set; }
        public int numero { get; set; }

        public Ficha2(int num = 0, string co = "nada")
        {
            numero = num;
            color = co;
        }
    }
}
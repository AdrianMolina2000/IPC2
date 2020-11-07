using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPC2.Models
{
    public class player
    {
        public player()
        {

        }

        public string nombre { get; set; }

        public player(string no)
        {
            nombre = no;
        }
    }
}
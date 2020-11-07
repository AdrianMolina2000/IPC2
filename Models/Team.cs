using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPC2.Models
{
    public class Team
    {
        public Team()
        {

        }

        public List<player> jugadores{ get; set; }
        public string nombre { get; set; }

        public Team(string no, List<player> ju)
        {
            nombre = no;
            jugadores = ju;
        }
    }
}
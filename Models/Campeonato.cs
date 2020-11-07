using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPC2.Models
{
    public class Campeonato
    {
        public Campeonato()
        {

        }

        public List<Team> equipos { get; set; }
        public string nombre { get; set; }

        public Campeonato(string no, List<Team> eq)
        {
            nombre = no;
            equipos = eq;
        }
    }
}
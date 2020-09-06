using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPC2.Models.ViewModels
{
    public class ListTablaViewModel
    {
        public string Nickname { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Pais { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
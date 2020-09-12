using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IPC2.Models
{
    public class Archi
    {
        [Required]
        [DisplayName("Mi Archivo")]
        public HttpPostedFileBase Archivo1 { get; set; }
    }
}
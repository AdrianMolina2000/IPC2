using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IPC2.Models.ViewModels
{
    public class TablaViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "NickName")]
        public string Nickname { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Primer Nombre")]
        public string PrimerNombre { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Segundo Nombre")]
        public string SegundoNombre { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }
        [Required]
        [Display(Name = "Segundo Apellido")]
        [StringLength(50)]
        public string SegundoApellido { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name = "Pais")]
        public string Pais { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }
    }
}
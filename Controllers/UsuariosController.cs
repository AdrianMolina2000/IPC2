using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPC2.Models;
using IPC2.Controllers;
using IPC2.Models.ViewModels;

namespace IPC2.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            List<ListTablaViewModel> lst;
            using (OthelloEntities db = new OthelloEntities())
            {
                lst = (from d  in db.usuarios
                           select new ListTablaViewModel
                           {
                               Nickname = d.nickname,
                               PrimerNombre = d.primer_nombre,
                               SegundoNombre = d.segundo_nombre,
                               PrimerApellido = d.primer_apellido,
                               SegundoApellido = d.segundo_apellido,
                               FechaNacimiento = d.fecha_nacimiento,
                               Pais = d.pais,
                               Password = d.contraseña,
                               Email = d.email
                           }).ToList();
            }
            
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (OthelloEntities db = new OthelloEntities())
                    {
                        var oTabla = new usuarios();
                        oTabla.nickname = model.Nickname;
                        oTabla.primer_nombre = model.PrimerNombre;
                        oTabla.segundo_nombre = model.SegundoNombre;
                        oTabla.primer_apellido = model.PrimerApellido;
                        oTabla.segundo_apellido = model.SegundoApellido;
                        oTabla.fecha_nacimiento = model.FechaNacimiento;
                        oTabla.pais = model.Pais;
                        oTabla.contraseña = model.Password;
                        oTabla.email = model.Email;

                        db.usuarios.Add(oTabla);
                        db.SaveChanges();
                    }
                    return  Redirect("~/Usuarios/");
                }
                return View(model);


            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
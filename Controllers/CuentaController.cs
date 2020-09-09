using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPC2.Models;
using System.Data.SqlClient;

namespace IPC2.Controllers
{
    public class CuentaController : Controller
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataReader rd;
        // GET: Usuario
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            connect.ConnectionString = "data source= localhost; database= Othello; integrated security = SSPI;";
        }
        [HttpPost]

        public ActionResult Verify(Cuenta account)
        {
            connectionString();
            connect.Open();
            command.Connection = connect;
            command.CommandText = "select * from usuarios where nickname='"+account.Nickname+"' and contraseña= '"+account.Password+"'";
            rd = command.ExecuteReader();
            if(rd.Read())
            {

                connect.Close();
                return Redirect("~/Home/Index");
            }
            else
            {
                connect.Close();
                return RedirectToAction("Login", new { message = ("No se reconocen los datos ingresados") });
            }
        }

    }
}
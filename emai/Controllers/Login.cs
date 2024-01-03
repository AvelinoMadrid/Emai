using emai.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using emai.Models;
using Microsoft.Data.SqlClient;


namespace emai.Controllers
{
    public class Account : Controller
    {
        public string EMAIConnection = "Data Source=LAPTOP-OM95FUOE\\SQLEXPRESS;Initial Catalog=EMAI;Integrated Security=True;TrustServerCertificate=True;";

        private readonly ILogger<HomeController> _logger;

        public Account(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Login()
        {
            return View();
        }

       


        [HttpPost]
        public ActionResult Login(Login user)
        {
            using (SqlConnection cn = new SqlConnection(EMAIConnection))
            {
                SqlCommand cmd = new SqlCommand("Loggeo", cn);
                cmd.Parameters.Add(new SqlParameter("@Usuario", user.Usuario));
                cmd.Parameters.Add(new SqlParameter("@Password", user.Contraseña));
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                
                user.Usuario = cmd.ExecuteNonQuery().ToString();
            }

            if(user.Usuario != null)
            {
                //Session["usuario"] = user; 
                
                return RedirectToAction("Login", "Account");// nombre del metodo y controlador;<
            }

            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }


           
        }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DColor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Dashboard()
        {
           
            return View();
        }
        public ActionResult SinPermiso()
        {
            return View();
            ViewBag.Message = "El Empleado no cuenta con permisos para ingresar";
        }

        public ActionResult CerrarSesion()
        {
            //se cierra la sescion del usuario
            FormsAuthentication.SignOut();
            Session["Empleado"] = null;

            return RedirectToAction("Login", "Login");
        }
    }
}
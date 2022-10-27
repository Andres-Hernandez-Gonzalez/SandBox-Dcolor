using CaptchaMvc.HtmlHelpers;
using DColor.DB;
using DColor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DColor.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Validar(Empleado obj)
        {
            if (!this.IsCaptchaValid(""))
            {
                ViewBag.error = "Captcha Invalido";
                return View("Index");
            }
            else
            {
                EmpleadosModels empleados = new EmpleadosModels();
                var respuesta = empleados.ValidarCredenciales(obj);
                switch (respuesta.correo)
                {
                    case "Contraseña erronea":
                    case "El correo digitado no existe":
                        ViewBag.MsjError = respuesta.correo;
                        return View("Index");
                    default:
                        if(respuesta.intentos > 3) {
                            ViewBag.MsjError = "Usuario bloqueado";
                            return View("Index");
                        }
                        else
                        {
                            FormsAuthentication.SetAuthCookie(respuesta.correo, false);
                            Session["User"] = respuesta;
                            return RedirectToAction("Dashboard", "Home");
                        }
                        
                }
            }
        }
    }
}
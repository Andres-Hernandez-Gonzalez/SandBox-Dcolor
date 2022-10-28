using CaptchaMvc.HtmlHelpers;
using DColor.DB;
using DColor.Entities;
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

        [HttpGet]
        public ActionResult GenerarToken()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GenerarToken(TokenEntiti modelo)
        {
            EmpleadosModels empleado = new EmpleadosModels();

            //Se valida que el correo ingreado exista en los registros de la bd
            if (empleado.ValidarCorreo(modelo.correo))
            {
                empleado.GenerarToken(modelo);
            }
            else
            {
                ViewBag.MjsEmail = "El Correo ingresado no coincide con nuestros registros";
                return View();

            }

            ViewBag.MjsEmailEnviado = "Se le ha envidado un Correo para cambiar su contraseña";
            return View("Index");

        }

        [HttpGet]
        public ActionResult RestablecerPassword(string token)
        {
            EmpleadosModels empleado = new EmpleadosModels();
            RecuperarPassword pass = new RecuperarPassword();
            pass.token = token;

            if (empleado.RestablecerPassword(pass) == null)
            {
                ViewBag.Error = "El Token ha expirado";
                return View("Index");
            }

            return View(pass);
        }

        [HttpPost]
        public ActionResult RestablecerPassword(RecuperarPassword model)
        {
            EmpleadosModels empleado = new EmpleadosModels();

            if (empleado.RestablecerPassword(model) != null)
            {
                ViewBag.MjsEmailEnviado = "Contraseña moficada con éxito";
                return View("Index");
            }

            return View(model);
        }
    }
}
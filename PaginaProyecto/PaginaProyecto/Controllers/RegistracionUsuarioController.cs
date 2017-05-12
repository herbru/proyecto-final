using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaginaProyecto.Models;

namespace PaginaProyecto.Controllers
{
    public class RegistracionUsuarioController : Controller
    {
        // GET: RRegistracionUsuario/RegistrarUsuario/
        public ActionResult RegistrarUsuario()
        {
            return View();
        }

        // POST : RegistracionUsuario/RegistrarUsuario/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarUsuario(Usuario oUsuario)
        {
            if (ModelState.IsValid)
            {
                oUsuario.InsertarUsuario();
                return RedirectToAction("HomeUsuario");
            }
            else
            {
                return View();
            }
        }

        // GET : RegistracionUsuario/LoguearUsuario
        public ActionResult LoguearUsuario()
        {
            return View();
        }

        // POST : RegistracionUsuario/LoguearUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoguearUsuario(Usuario oUsuario)
        {
            Usuario objUsuario = new Usuario();
            objUsuario = oUsuario.LoguearUsuario(oUsuario);
            if (objUsuario.Email == oUsuario.Email && oUsuario.Contraseña == objUsuario.Contraseña)
            {
                ViewBag.UsuarioLogueado = objUsuario;
                return RedirectToAction("HomeUsuario");
            }
            else
            {
                ViewBag.MensajeErrorLogueo = "El usuario o la contraseña no son correctos";
                return View();
            }
        }
    }
}
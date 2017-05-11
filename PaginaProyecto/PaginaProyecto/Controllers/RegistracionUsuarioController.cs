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
        // GET: RegistrarUsuario/
        public ActionResult RegistrarUsuario()
        {
            return View();
        }

        // POST : RegistrarUsuario/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarUsuario(Usuario oUsuario)
        {
            if (ModelState.IsValid)
            {
                oUsuario.InsertarUsuario();
                return View("HomeUsuario");
            }
            else
            {
                return View();
            }
        }

        public ActionResult LoguearUsuario(Usuario oUsuario)
        {
            oUsuario.LoguearUsuario();
            return View("HomeUsuario");
        }
    }
}
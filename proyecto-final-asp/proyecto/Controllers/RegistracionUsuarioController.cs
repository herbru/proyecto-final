using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto.Models;

namespace proyecto.Controllers
{
    public class RegistracionUsuarioController : Controller
    {
        // GET: /RegistracionUsuario/RegistracionUsuario
        public ActionResult RegistracionUsuario()
        {
            return View();
        }

        // POST: /RegistracionUsuario/RegistracionUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistracionUsuario(Usuario oUsuario)
        {
            if (ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
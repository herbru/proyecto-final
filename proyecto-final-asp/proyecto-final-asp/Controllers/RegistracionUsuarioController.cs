using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto_final_asp.Models;

namespace proyecto_final_asp.Controllers
{
    public class RegistracionUsuarioController : Controller
    {
        //
        // GET: /RegistracionUsuario
        public ActionResult RegistracionUsuario()
        {
            return View();
        }

        //
        // POST: /RegistracionUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistracionUsuario(Usuario oUsuario)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
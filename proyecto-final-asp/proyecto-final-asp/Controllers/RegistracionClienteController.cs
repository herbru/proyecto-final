using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto_final_asp.Controllers
{
    public class RegistracionClienteController : Controller
    {
        //
        // GET: /RegistracionCliente/
        public ActionResult ResgistracionCliente()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistracionCliente(string NombreEvento, string Email, string Contraseña)
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
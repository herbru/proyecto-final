using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto.Models;

namespace proyecto.Controllers
{
    public class RegistracionAdminController : Controller
    {
        // GET: /RegistracionAdmin/RegistracionAdmin
        public ActionResult RegistracionAdmin()
        {
            return View();
        }

        // POST: /RegstracionAdmin/RegistracionAdmin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistracionAdmin(Administrador oAdmin)
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
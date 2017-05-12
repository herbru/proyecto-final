using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaginaProyecto.Models;


namespace PaginaProyecto.Controllers
{
    public class HomeUserController : Controller
    {
        // GET: HomeUser/HomeUsuario
        public ActionResult HomeUsuario()
        {
            return View();
        }
    }
}
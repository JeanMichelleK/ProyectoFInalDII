using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EC;
using Logica;

namespace Sitio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult PaginaMenu()
        {
            if (Session["Usuario"] is Empleado)
                return View();
            else
                return RedirectToAction("FormLogueo", "Empleado");
        }
    }
}

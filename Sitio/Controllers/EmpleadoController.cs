using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EC;
using Logica;

namespace Sitio.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public ActionResult FormLogueo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FormLogueo(Empleado E)
        {
            try
            {
                Empleado Usu = FabricaLogica.GetLogicaEmpleado().Logueo(E.Usuario, E.Contraseña);
                if (Usu != null)
                {
                    Session["Usuario"] = Usu;
                    return RedirectToAction("PaginaMenu", "Home");
                }
                else
                    throw new Exception("Usuario/Contraseña incorrectos.");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
        }
        public ActionResult Deslogueo()
        {
            Session["Usuario"] = null;
            return RedirectToAction("FormLogueo", "Empleado");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EC;
using Logica;
namespace Sitio.Controllers
{
    public class VentaController : Controller
    {
        // GET: Venta
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FormVentaAlta()
        {
            try
            {
                List<Vuelo> ListaV = FabricaLogica.GetLogicaVuelo().ListadoVuelos((Empleado)Session["Usuario"]);
                ViewBag.ListarVuelos = new SelectList("CodigoV");
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
        }
        [HttpPost]
        public ActionResult FormVentaAlta(Venta V)
        {
            try
            {
                V.Usuario = (Empleado)Session["Usuario"];
                Session["Venta"] = V;
                return RedirectToAction("FormVentaAlta", "Venta");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new Venta());
            }
        }
        [HttpGet]
        public ActionResult FormPasajeVentaAlta()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FormPasajeVentaAlta(Pasaje P)
        {
            try
            {
                P.Validar();
                ((Venta)Session["Venta"]).ListaP.Add(P);
                return RedirectToAction("FormPasajeVentaAlta", "Venta");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
        }
        [HttpGet]
        public ActionResult GuardoVenta()
        {
            try
            {
                Venta V = (Venta)Session["Venta"];
                V.Validar();
                FabricaLogica.GetLogicaVenta().Alta(V, (Empleado)Session["Usuario"]);
                return RedirectToAction("FormAltaExito", "Venta");
            }
            catch (Exception ex)
            {
                Session["ErrorVenta"] = ex.Message;
                return RedirectToAction("FormAltaError", "Venta");
            }
        }
    }
}
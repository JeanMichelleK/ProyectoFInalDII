using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EC;
using Logica;

namespace Sitio.Controllers
{
    public class VueloController : Controller
    {
        // GET: Vuelo
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FormVueloAlta()
        {
            try
            {
                List<Aeropuerto> ListaA = FabricaLogica.GetLogicaAeropuerto().ListadoAeropuertos((Empleado)Session["Usuario"]);
                ViewBag.ListarAeropuertos = new SelectList(ListaA, "CodigoA", "Nombre");
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
        }
        [HttpPost]
        public ActionResult FormVueloAlta(Vuelo V)
        {
            try
            {
                V.CodigoVuelo = V.FechaHoraSalida.ToString("yyyyMMddHHmm") + V.AeropuertoPartida.CodigoA.ToString();
                V.Validar();
                FabricaLogica.GetLogicaVuelo().Alta(V, (Empleado)Session["Usuario"]);
                return RedirectToAction("FormVueloAlta","Vuelo");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new Vuelo());
            }

        }
    }
}
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
                ViewBag.ListarVuelos = new SelectList(ListaV,"CodigoVuelo","CodigoVuelo");
                Session["ListaV"] = ListaV;
                List<Cliente> ListaC = FabricaLogica.GetLogicaCliente().ListadoClientes((Empleado)Session["Usuario"]);
                ViewBag.ListaCliente = new SelectList(ListaC, "NroPasaporte", "Nombre");
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ListarVuelo = new SelectList(null);
                ViewBag.ListaCliente = new SelectList(null);
                ViewBag.Mensaje = ex.Message;
                return View();
            }
        }
        [HttpPost]
        public ActionResult FormVentaAlta(Venta V)
        {
            try
            {
                V.Vuelo = ((List<Vuelo>)Session["ListaV"]).FirstOrDefault(v => v.CodigoVuelo == V.Vuelo.CodigoVuelo);
                V.Usuario = (Empleado)Session["Usuario"];
                V.ListaP = new List<Pasaje>();
                if (V.NroPasaporte.Trim().Length > 0)
                {
                    string Pasa = V.NroPasaporte.ToString();
                    V.Cliente = FabricaLogica.GetLogicaCliente().Buscar(Pasa, (Empleado)Session["Usuario"]);
                }
                Session["Venta"] = V;
                return RedirectToAction("FormPasajeVentaAlta", "Venta");
            }
            catch (Exception ex)
            {
                List<Vuelo> ListaV = FabricaLogica.GetLogicaVuelo().ListadoVuelos((Empleado)Session["Usuario"]);
                ViewBag.ListarVuelos = new SelectList("CodigoV");
                List<Cliente> ListaC = FabricaLogica.GetLogicaCliente().ListadoClientes((Empleado)Session["Usuario"]);
                ViewBag.ListaCliente = new SelectList(ListaC, "NroPasaporte", "Nombre");
                ViewBag.Mensaje = ex.Message;
                return View(new Venta());
            }
        }
        [HttpGet]
        public ActionResult FormPasajeVentaAlta()
        {
            try
            {
                List<Cliente> ListaC = FabricaLogica.GetLogicaCliente().ListadoClientes((Empleado)Session["Usuario"]);
                ViewBag.ListaCliente = new SelectList(ListaC, "NroPasaporte", "Nombre");

            }
            catch (Exception ex)
            {
                ViewBag.ListaCliente = new SelectList(null);
                ViewBag.Mensaje = ex.Message;
                return View();
            }
            return View();
        }
        [HttpPost]
        public ActionResult FormPasajeVentaAlta(Pasaje P)
        {
            try
            {
                if (P.NroPasaporte.Trim().Length > 0)
                {
                    string Pasa = P.NroPasaporte.ToString();
                    P.Cliente = FabricaLogica.GetLogicaCliente().Buscar(Pasa, (Empleado)Session["Usuario"]);
                }
                if (((Venta)Session["Venta"]).ListaP.Any(p => p.Asiento == P.Asiento))
                {
                    List<Cliente> ListaC = FabricaLogica.GetLogicaCliente().ListadoClientes((Empleado)Session["Usuario"]);
                    ViewBag.ListaCliente = new SelectList(ListaC, "NroPasaporte", "Nombre");
                    ViewBag.Mensaje = "Ese Asiento esta ocupado.";
                    return View();
                }
                P.Validar();
                ((Venta)Session["Venta"]).ListaP.Add(P);
                return RedirectToAction("FormPasajeVentaAlta", "Venta");
            }
            catch (Exception ex)
            {
                List<Vuelo> ListaV = FabricaLogica.GetLogicaVuelo().ListadoVuelos((Empleado)Session["Usuario"]);
                ViewBag.ListarVuelos = new SelectList("CodigoV");
                List<Cliente> ListaC = FabricaLogica.GetLogicaCliente().ListadoClientes((Empleado)Session["Usuario"]);
                ViewBag.ListaCliente = new SelectList(ListaC, "NroPasaporte", "Nombre");
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
               
                V.FechaVenta = DateTime.Now;
                V.Monto = ((V.Vuelo.Precio + V.Vuelo.AeropuertoLlegada.ImpuestoLlegada / 100) + (V.Vuelo.Precio + V.Vuelo.AeropuertoPartida.ImpuestoSalida / 100)) * V.ListaP.Count;
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

        public ActionResult FormAltaExito()
        {
            return View();
        }
        public ActionResult FormAltaError()
        {
            ViewBag.Mensaje = Session["ErrorVenta"].ToString();
            return View();
        }

    }
}
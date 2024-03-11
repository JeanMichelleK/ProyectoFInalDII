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
                return RedirectToAction("FormVueloAlta", "Vuelo");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new Vuelo());
            }
        }



        public ActionResult FormVuelosListar(string filtro, string vuelosPartieron, string vuelosNoPartieron, string AeropuertoFiltro, string vuelosfechaEspec)
        {
            try
            {
                List<Vuelo> _Lista = null;
                if (Session["Lista"] == null)
                {
                    _Lista = FabricaLogica.GetLogicaVuelo().ListadoVuelos((Empleado)Session["Usuario"]);
                    Session["Lista"] = _Lista;
                }
                else
                    _Lista = (List<Vuelo>)Session["Lista"];

                if (_Lista.Count == 0)
                    throw new Exception("No hay vuelos para mostrar");
                List<Aeropuerto> _ListaA = FabricaLogica.GetLogicaAeropuerto().ListadoAeropuertos((Empleado)Session["Usuario"]);
                ViewBag.ListaA = new SelectList(_ListaA, "CodigoA", "Nombre");
                ViewBag.AeropuertoFiltro = "";
                if (!String.IsNullOrEmpty(AeropuertoFiltro) && vuelosPartieron == "" && String.IsNullOrEmpty(vuelosfechaEspec))
                {
                    _Lista = _Lista.Where(v => v.AeropuertoPartida.CodigoA == AeropuertoFiltro).ToList();
                }

                if (!String.IsNullOrEmpty(vuelosfechaEspec) && vuelosPartieron == "")
                {
                    _Lista = (from unV in _Lista
                              where unV.FechaHoraSalida.Date == Convert.ToDateTime(vuelosfechaEspec).Date
                              select unV).ToList();
                }
                if (vuelosPartieron == "Partio")
                {
                    DateTime fechaActual = DateTime.Now.Date;
                    DateTime horaActual = DateTime.Now;

                    _Lista = _Lista.Where(unV => unV.FechaHoraSalida.Date < fechaActual
                                                  || (unV.FechaHoraSalida.Date == fechaActual && unV.FechaHoraSalida.TimeOfDay < horaActual.TimeOfDay))
                                   .ToList();
                }
                if (vuelosNoPartieron == "No Partio")
                {
                    DateTime fechaActual = DateTime.Now.Date;
                    DateTime horaActual = DateTime.Now;

                    _Lista = _Lista.Where(unV => unV.FechaHoraSalida.Date >= fechaActual
                                                  && (unV.FechaHoraSalida.Date > fechaActual || unV.FechaHoraSalida.TimeOfDay >= horaActual.TimeOfDay))
                                   .ToList();
                }
                return View(_Lista);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new List<Vuelo>());
            }
        }
        }
    }

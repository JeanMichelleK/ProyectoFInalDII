using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logica;
using EC;

namespace Sitio.Controllers
{
    public class AeropuertoController : Controller
    {
        [HttpGet]
        public ActionResult FormAeropuertoListar(string DatoFiltro)
        {
            try
            {
                List<Aeropuerto> Lista = FabricaLogica.GetLogicaAeropuerto().ListadoAeropuertos((Empleado)Session["Usuario"]);
                if (Lista.Count >= 1)
                {
                    if (String.IsNullOrEmpty(DatoFiltro))
                        return View(Lista);
                    else
                    {
                        Lista = (from unA in Lista
                                 where unA.Nombre.ToUpper().StartsWith(DatoFiltro.ToUpper())
                                 select unA).ToList();
                        return View(Lista);
                    }
                }
                else
                    throw new Exception("No hay Aeropuertos para mostrar.");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return ViewBag(new List<Aeropuerto>());
            }
        }


        [HttpGet]
        public ActionResult FormAeropuertoNuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FormAeropuertoNuevo(Aeropuerto A)
        {
            try
            {
                A.Validar();
                FabricaLogica.GetLogicaAeropuerto().Alta(A, (Empleado)Session["Usuario"]);
                return RedirectToAction("FormAeropuertoListar", "Aeropuerto");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult FormAeropuertoModificar(string pCodigoA)
        {
            try
            {
                Aeropuerto A = FabricaLogica.GetLogicaAeropuerto().Buscar(pCodigoA, (Empleado)Session["Usuario"]);
                if (A != null)
                    return View(A);
                else
                    throw new Exception("No existe el Aeropuerto.");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return ViewBag(new Aeropuerto());
            }
        }

        [HttpPost]
        public ActionResult FormAeropuertoModificar(Aeropuerto A)
        {
            try
            {
                A.Validar();
                FabricaLogica.GetLogicaAeropuerto().Modificar(A, (Empleado)Session["Usuario"]);
                ViewBag.Mensaje = "Modificacion con exito.";
                return RedirectToAction("FormAeropuertoListar", "Aeropuerto");
            }
            catch (Exception ex)
            {
                ViewBag.Menaje = ex.Message;
                return View(new Aeropuerto());
            }
        }

        [HttpGet]
        public ActionResult FormAeropuertoBaja(string pCodigoA)
        {
            try
            {
                Aeropuerto A = FabricaLogica.GetLogicaAeropuerto().Buscar(pCodigoA, (Empleado)Session["Usuario"]);
                if (A != null)
                    return View(A);
                else
                    throw new Exception("No existe el Aeropuerto.");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new Aeropuerto());
            }
        }
        [HttpPost]
        public ActionResult FormAeropuertoBaja(Aeropuerto A)
        {
            try
            {
                FabricaLogica.GetLogicaAeropuerto().Baja(A, (Empleado)Session["Usuario"]);
                return RedirectToAction("FormAeropuertoListar", "Aeropuerto");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new Aeropuerto());
            }
        }

        [HttpGet]
        public ActionResult FormAeropuertoConsultar(string pCodigoA)
        {
            try
            {
                Aeropuerto A = FabricaLogica.GetLogicaAeropuerto().Buscar(pCodigoA, (Empleado)Session["Usuario"]);
                if (A != null)
                    return View(A);
                else
                    throw new Exception("No existe el Aeropuerto.");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new Aeropuerto());
            }
        }


    }
}
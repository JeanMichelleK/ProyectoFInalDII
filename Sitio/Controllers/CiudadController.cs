﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logica;
using EC;
namespace Sitio.Controllers
{
    public class CiudadController : Controller
    {

        public ActionResult FormCiudadListar(string DatoFiltro)
        {
            try
            {
                List<Ciudad> Lista = FabricaLogica.GetLogicaCiudad().ListadoCiudades((Empleado)Session["Usuario"]);
                if (Lista.Count == 0)
                    throw new Exception("No hay facturas para mostrar");

                if (!String.IsNullOrEmpty(DatoFiltro))
                {
                    Lista = (from unC in Lista
                             where unC.Nombre.ToUpper().StartsWith(DatoFiltro.ToUpper())
                             select unC).ToList();
                }
                return View(Lista);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new List<Ciudad>());
            }
        }

        [HttpGet]
        public ActionResult FormCiudadNueva()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FormCiudadNueva(Ciudad C)
        {
            try
            {
                C.Validar();
                FabricaLogica.GetLogicaCiudad().Alta(C, (Empleado)Session["Usuario"]);
                return RedirectToAction("FormCiudadListar", "Ciudad");

            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult FormCiudadModificar(string CodigoCiudad)
        {
            try
            {
                Ciudad C =  FabricaLogica.GetLogicaCiudad().Buscar(CodigoCiudad, (Empleado)Session["Usuario"]);
                if (C != null)
                    return View(C);
                else
                    throw new Exception("No existe la ciudad.");    
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new Ciudad());
            }
        }
        [HttpPost]
        public ActionResult FormCiudadModificar(Ciudad C)
        {
            try
            {
                C.Validar();
                FabricaLogica.GetLogicaCiudad().Modificar(C, (Empleado)Session["Usuario"]);
                ViewBag.Mensaje = "Modificacion con exito.";
                return RedirectToAction("FormCiudadListar", "Ciudad");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new Ciudad());
            }
        }
        [HttpGet]
        public ActionResult FormCiudadBaja(string CodigoCiudad)
        {
            try
            {
                Ciudad C = FabricaLogica.GetLogicaCiudad().Buscar(CodigoCiudad, (Empleado)Session["Usuario"]);
                if (C != null)
                    return View(C);
                else
                    throw new Exception("No existe la ciudad.");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new Ciudad());
            }
        }
        [HttpPost]
        public ActionResult FormCiudadBaja(Ciudad C)
        {
            try
            {
                FabricaLogica.GetLogicaCiudad().Baja(C, (Empleado)Session["Usuario"]);
                return RedirectToAction("FormCiudadListar", "Ciudad");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new Ciudad());
            }
        }

        [HttpGet]

        public ActionResult FormCiudadConsultar(string CodigoCiudad)
        {
            try
            {
                Ciudad C = FabricaLogica.GetLogicaCiudad().Buscar(CodigoCiudad, (Empleado)Session["Usuario"]);
                if (C != null)
                    return View(C);
                else
                    throw new Exception("No existe la ciudad.");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new Ciudad());
            }
        }
    }
}
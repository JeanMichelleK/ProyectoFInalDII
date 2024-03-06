using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logica;
using EC;

namespace Sitio.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet]
        public ActionResult FormClienteListar(string DatoFiltro)
        {
            try
            {
                List<Cliente> Lista = FabricaLogica.GetLogicaCliente().ListadoClientes((Empleado)Session["Usuario"]);
                if (Lista.Count >= 1)
                {
                    if (String.IsNullOrEmpty(DatoFiltro))
                        return View(Lista);
                    else
                    {
                        Lista = (from unC in Lista
                                 where unC.Nombre.ToUpper().StartsWith(DatoFiltro.ToUpper())
                                 select unC).ToList();
                        return View(Lista);
                    }
                }
                else
                    throw new Exception("No hay clientes para mostrar.");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return ViewBag(new List<Cliente>());
            }
        }
        [HttpGet]
        public ActionResult FormClienteNuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FormClienteNuevo(Cliente C)
        {
            try
            {
                C.Validar();
                FabricaLogica.GetLogicaCliente().Alta(C,(Empleado)Session["Usuario"]);
                return RedirectToAction("FormClienteListar", "Cliente");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
        }
        [HttpGet]
        public ActionResult FormClienteModificar(string pPasaporte)
        {
            try
            {
                Cliente C = FabricaLogica.GetLogicaCliente().Buscar(pPasaporte, (Empleado)Session["Usuario"]);
                if (C != null)
                    return View(C);
                else
                    throw new Exception("No existe el cliente.");               
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new Cliente());
            }
        }
        [HttpPost]
        public ActionResult FormClienteModificar(Cliente C)
        {
            try
            {
                C.Validar();
                FabricaLogica.GetLogicaCliente().Modificar(C, (Empleado)Session["Usuario"]);
                ViewBag.Mensaje = "Modificacion con exito.";
                return RedirectToAction("FormClienteListar", "Cliente");

            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new Cliente());
            }
        }
        [HttpGet]
        public ActionResult FormClienteBaja(string pPasaporte)
        {
            try
            {
                Cliente C = FabricaLogica.GetLogicaCliente().Buscar(pPasaporte, (Empleado)Session["Usuario"]);
                if (C != null)
                    return View(C);
                else
                    throw new Exception("No existe el cliente.");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new Cliente());
            }
        }
        [HttpPost]
        public ActionResult FormClienteBaja(Cliente C)
        {
            try
            {
                FabricaLogica.GetLogicaCliente().Baja(C, (Empleado)Session["Usuario"]);
                return RedirectToAction("FormClienteListar", "Cliente");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new Cliente());
            }
        }
        [HttpPost]
        public ActionResult FormClienteConsultar(string pPasaporte)
        {
            try
            {
                Cliente C = FabricaLogica.GetLogicaCliente().Buscar(pPasaporte, (Empleado)Session["Usuario"]);
                if (C != null)
                    return View(C);
                else
                    throw new Exception("No existe el cliente.");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new Cliente());
            }
        }
    }
}
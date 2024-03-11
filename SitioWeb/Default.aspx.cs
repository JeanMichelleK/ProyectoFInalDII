using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EF;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                Session["Cliente"] = null;
                this.GeneroContexto();
                this.CargoDDl();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }

    private void GeneroContexto()
    {
        try
        {
            ProyectoFinalEntities PFContext = new ProyectoFinalEntities();
            Session["PFContext"] = PFContext;
        }
        catch (Exception ex)
        {
            lblError3.Text = ex.Message;
        }
    }
    private void CargoDDl()
    {
        try
        {
            ProyectoFinalEntities PFContext = (ProyectoFinalEntities)Session["PFContext"];
            List<Aeropuerto> Lista = PFContext.Aeropuerto.ToList();
            ddlAeropuerto.DataSource = Lista;
            ddlAeropuerto.DataTextField = "Nombre";
            ddlAeropuerto.DataBind();
            ddlAeropuerto.Items.Insert(0, "Seleccionar");
            ddlAeropuerto.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblError3.Text = ex.Message;
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";
            lblError2.Text = "";
            lblError3.Text = "";
            ProyectoFinalEntities PFContext = (ProyectoFinalEntities)Session["PFContext"];
            List<Vuelo> ListaV = PFContext.Vuelo.ToList();
            if (ddlAeropuerto.SelectedIndex == 0)
            {
                lblError.Text = "Seleccione un Aeropuerto.";
                return;
            }
            List<object> ListaVP = (from unV in ListaV
                                    orderby unV.FechaYHoraSalida                               
                                    where unV.Aeropuerto1.Nombre == ddlAeropuerto.SelectedValue && unV.FechaYHoraSalida > DateTime.Now
                                    select new
                                    {
                                        FechaYHoraPartida = unV.FechaYHoraSalida,
                                        Destino = unV.Aeropuerto.Nombre,
                                        Ciudad = unV.Aeropuerto.Ciudad.Nombre,
                                        Pais = unV.Aeropuerto.Ciudad.Pais,
                                        PasajesVendidos = "?"
                                   }).ToList<object>();
            if (ListaVP.Count == 0)
                lblError2.Text = "No hay vuelos que partan de el Aeropuerto seleccionado.";
            gvPartidas.DataSource = ListaVP;
            gvPartidas.DataBind();

            List<object> ListaVA = (from unV in ListaV
                                    orderby unV.FechaYHoraSalida
                                    where unV.Aeropuerto.Nombre == ddlAeropuerto.SelectedValue && unV.FechaYHoraLlegada > DateTime.Now
                                    select new
                                    {
                                        FechaYHoraLlegada = unV.FechaYHoraLlegada,
                                        Partida = unV.Aeropuerto1.Nombre,
                                        Ciudad = unV.Aeropuerto1.Ciudad.Nombre,
                                        Pais = unV.Aeropuerto1.Ciudad.Pais,
                                        PasajesVendidos = "?"
                                    }).ToList<object>();
            if (ListaVA.Count == 0)
                lblError3.Text = "No hay vuelos que arriben en el Aeropuerto seleccionado.";
            gvArribos.DataSource = ListaVA;
            gvArribos.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}
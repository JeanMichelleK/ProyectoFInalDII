using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EF;

public partial class HistoricoCompras : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                this.CargoGrilla();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }

    private void CargoGrilla()
    {
        try
        {
            Cliente unC = (Cliente)Session["Cliente"];
            ProyectoFinalEntities PFContext = (ProyectoFinalEntities)Session["PFContext"];
            List<Venta> Lista = PFContext.Venta.ToList();
            List<Venta> ListaV = (from unaV in Lista
                                   orderby unaV.FechaVenta
                                   where unaV.Cliente == unC
                                   select unaV
                                   ).ToList<Venta>();
            gvCompras.DataSource = ListaV;
            gvCompras.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void gvCompras_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ProyectoFinalEntities PFContext = (ProyectoFinalEntities)Session["PFContext"];
            Cliente unC = (Cliente)Session["Cliente"];
            int IdVenta = Convert.ToInt32(gvCompras.SelectedDataKey.Value);
            List<object> Lista = (from unP in PFContext.Venta
                                  where unP.IdVenta == IdVenta
                                  select new
                                  {
                                      Partida = unP.Vuelo.Aeropuerto1.Nombre,
                                      Ciudad = unP.Vuelo.Aeropuerto1.Ciudad.Nombre,
                                      Pais = unP.Vuelo.Aeropuerto1.Ciudad.Pais,
                                      Destino = unP.Vuelo.Aeropuerto.Nombre,
                                      CiudadDestino = unP.Vuelo.Aeropuerto.Ciudad.Nombre,
                                      PaisDestino = unP.Vuelo.Aeropuerto.Ciudad.Pais,
                                  }).ToList<object>();
            gvDatos.DataSource = Lista;
            gvDatos.DataBind();
            List<Pasaje> ListaP = (from unV in PFContext.Venta
                                   where unV.IdVenta == IdVenta
                                   from unp in unV.Pasaje
                                   select unp).ToList();
            gvPasaje.DataSource = ListaP;
            gvPasaje.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }



}

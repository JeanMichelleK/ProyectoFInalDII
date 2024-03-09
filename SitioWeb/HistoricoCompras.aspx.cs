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
            List<object> ListaV = (from unaV in Lista
                                   orderby unaV.FechaVenta
                                   where unaV.Cliente == unC
                                   select new
                                   {
                                       Fecha = unaV.FechaVenta,
                                       Vuelo = unaV.CodigoV,
                                       Monto = unaV.Monto,
                                       Empleado = unaV.Empleado.Usuario
                                   }).ToList<object>();
            gvCompras.DataSource = ListaV;
            gvCompras.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    //    protected void gvCompras_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            ProyectoFinalEntities PFContext = (ProyectoFinalEntities)Session["PFContext"];
    //            Cliente unC = (Cliente)Session["Cliente"];
    //            List<object> Lista = (from unP in PFContext.Venta
    //                                  where unP.Cliente == unC
    //                                  select new
    //                                  {
    //                                      Partida = unP.Vuelo.Aeropuerto.Nombre,

    //                                  }).ToList<object>();
    //        }
    //        catch (Exception ex)
    //        {
    //            lblError.Text = ex.Message;
    //        }
    //    }


}

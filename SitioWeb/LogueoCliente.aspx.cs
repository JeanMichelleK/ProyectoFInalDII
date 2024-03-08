using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EF;

public partial class LogueoCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogueo_Click(object sender, EventArgs e)
    {
        try
        {
            ProyectoFinalEntities PFContext = (ProyectoFinalEntities)Session["PFContext"];
            Cliente unC = PFContext.Cliente.Where(c => c.NroPasaporte == txtPasaporte.Text.Trim() && c.PassCli == txtPass.Text.Trim()).FirstOrDefault();
            if (unC != null)
            {
                Session["Cliente"] = unC;
                Response.Redirect("~/HistoricoCompras.aspx");
            }
            else
            {
                lblError.Text = "Pasaporte/Contraseña incorrectos";
                txtPasaporte.Text = "";
                txtPass.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}
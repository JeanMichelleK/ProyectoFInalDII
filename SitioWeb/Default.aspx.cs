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
        Session["Usuario"] = null;
        Session["Cliente"] = null;
        this.GeneroContexto();
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
            lblError.Text = ex.Message;
        }
    }
}
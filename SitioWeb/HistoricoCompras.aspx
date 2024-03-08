<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HistoricoCompras.aspx.cs" Inherits="HistoricoCompras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <span class="auto-style1"><strong>Compras:</strong></span><br />
        <asp:GridView ID="GridView1" runat="server" Width="645px">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <strong><span class="auto-style1">Datos:</span></strong><br />
        <asp:GridView ID="GridView2" runat="server" Width="642px">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>

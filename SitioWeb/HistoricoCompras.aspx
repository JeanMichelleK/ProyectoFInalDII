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
        <asp:GridView ID="gvCompras" runat="server" Width="645px" AutoGenerateColumns="False" style="text-align: center">
            <Columns>
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Vuelo" HeaderText="Vuelo" />
                <asp:BoundField DataField="Monto" HeaderText="Monto" />
                <asp:BoundField DataField="Empleado" HeaderText="Empleado" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <strong><span class="auto-style1">Datos:</span></strong><br />
        <asp:GridView ID="gvDatos" runat="server" Width="642px" Height="39px" style="text-align: center">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>

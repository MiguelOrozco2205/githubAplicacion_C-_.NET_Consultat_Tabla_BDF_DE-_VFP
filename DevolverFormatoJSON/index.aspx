<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DevolverFormatoJSON.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblAgregarCliente" runat="server" Text="****-Conexion a una Tabla-BDF Nativa de Visual FoxPro Y Creacion de un Archivo JSON****"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" style="margin-left: 191px; margin-bottom: 0px" Text="Consultar Tabla" Width="103px" />
            
            <asp:Button ID="Button1" runat="server" Text="Leer JSON  " OnClick="Button1_Click" Width="102px" style="margin-left: 76px" />
            <br />
            <br />
            <asp:GridView ID="GridView2" runat="server" style="margin-right: 138px">
            </asp:GridView>
            <asp:GridView ID="GridView1" runat="server" style="margin-left: 0px"></asp:GridView>
            <br />
            
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>

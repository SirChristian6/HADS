<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Menu.aspx.vb" Inherits="Practica.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h3>Gestión de Trabajos Complementarios&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="LogOut" runat="server" Text="Cerrar Sesión" />
        </h3>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Bienvenido "></asp:Label>
            <asp:Label ID="email" runat="server"></asp:Label>
        </p>
        <p>
            <asp:LinkButton ID="LinkButton1" runat="server">Inscribir Trabajo</asp:LinkButton>
        </p>
        <asp:LinkButton ID="LinkButton2" runat="server">Ver Trabajos Inscritos</asp:LinkButton>
        <p>
            <asp:LinkButton ID="LinkButton3" runat="server">Ver Trabajos Inscritos (controles)</asp:LinkButton>
        </p>
        <asp:LinkButton ID="LinkButton4" runat="server">Modificar Trabajo</asp:LinkButton>
        <p>
            <asp:LinkButton ID="LinkButton5" runat="server">Evaluar Trabajo</asp:LinkButton>
        </p>
    </form>
</body>
</html>

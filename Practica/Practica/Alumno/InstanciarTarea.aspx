<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InstanciarTarea.aspx.vb" Inherits="Practica.WebForm8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Email" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LogOut" runat="server" CausesValidation="False">Cerrar Sesión</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="Inicio" runat="server" CausesValidation="False">Ir a Inicio</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="Tareas" runat="server" CausesValidation="False">Ir a Tareas</asp:LinkButton>
            <br />
            <br />
        </div>
        <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="User" runat="server" ReadOnly="True" ValidationGroup="Instanciar"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Tarea"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tarea" runat="server" ReadOnly="True" ValidationGroup="Instanciar"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Horas Est."></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="hest" runat="server" ReadOnly="True" ValidationGroup="Instanciar"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Horas Reales"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Hreales" runat="server" TextMode="Number" ValidationGroup="Instanciar"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Hreales" ErrorMessage="Campo Requerido" ForeColor="Red" ValidationGroup="Instanciar"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="Hreales" ErrorMessage="Las horas deben ser positivas" ForeColor="Red" MaximumValue="NaN" MinimumValue="0" ValidationGroup="instanciar"></asp:RangeValidator>
        <br />
        <br />
        <asp:Button ID="Task" runat="server" Text="Instanciar Tarea" ValidationGroup="Instanciar" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <p>
            <asp:Label ID="Respuesta" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>

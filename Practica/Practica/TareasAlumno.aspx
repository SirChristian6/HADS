<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TareasAlumno.aspx.vb" Inherits="Practica.WebForm7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="email" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LogOut" runat="server">Cerrar Sesión</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="Inicio" runat="server">Ir a Inicio</asp:LinkButton>
            <br />
            <br />
        </div>
        <asp:DropDownList ID="asignatura" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig">

        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Tasks" runat="server" Text="Ver Tareas" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AmigosConnectionString %>" SelectCommand="ObtenerAsignaturaAlumnoG11" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="Email" SessionField="user" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <asp:CommandField ButtonType="Button" SelectText="Instanciar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>

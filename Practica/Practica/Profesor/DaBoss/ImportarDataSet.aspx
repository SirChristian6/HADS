<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ImportarDataSet.aspx.vb" Inherits="Practica.ImportarDataSetaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <asp:Label ID="Email" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LogOut" runat="server">Cerrar Sesion</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="Inicio" runat="server">Ir a Inicio</asp:LinkButton>
        <div>
        </div>
        <asp:DropDownList ID="Asignatura" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig" ValidationGroup="add" AutoPostBack="True">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AmigosConnectionString %>" SelectCommand="SELECT [codigoasig] FROM [ProfesoresGrupo] INNER JOIN [GruposClase] on [codigo]=[codigogrupo] WHERE ([email] = @email)">
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="user" />
            </SelectParameters>
        </asp:SqlDataSource>
            <br />
        <br />
        <asp:Button ID="Importar" runat="server" Text="Importar (DS)" />
        <br />
        <br />
        <asp:Label ID="Respuesta" runat="server"></asp:Label>
            <br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <asp:LinkButton ID="Profesor" runat="server">Menú Profesor</asp:LinkButton>
        <br />
    </form>
</body>
</html>

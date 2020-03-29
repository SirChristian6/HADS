<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ImportarXML.aspx.vb" Inherits="Practica.ImportarXML" %>

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
            <asp:LinkButton ID="LogOut" runat="server">Cerrar Sesion</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="Inicio" runat="server">Ir a Inicio</asp:LinkButton>
            <br />
        </div>
        <asp:Label ID="Label2" runat="server" Text="Seleccionar Asignatura a Importar"></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="Asignatura" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig" ValidationGroup="add" AutoPostBack="True">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AmigosConnectionString %>" SelectCommand="SELECT [codigoasig] FROM [ProfesoresGrupo] INNER JOIN [GruposClase] on [codigo]=[codigogrupo] WHERE ([email] = @email)">
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="user" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:LinkButton ID="codigo" runat="server">Ordenar por Codigo</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="descripcion" runat="server">Ordenar por Descripcion</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="hestimadas" runat="server">Ordenar por HEstimadas</asp:LinkButton>
        <br />
&nbsp;<asp:Xml ID="Xml1" runat="server"></asp:Xml>
        <br />
        <asp:Button ID="Importar" runat="server" Text="Importar (XMLD)" />
        <br />
        <br />
        <asp:Label ID="Respuesta" runat="server"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <asp:LinkButton ID="Profesor" runat="server">Menú Profesor</asp:LinkButton>
    </form>
</body>
</html>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profesor.aspx.vb" Inherits="Practica.WebForm9" %>

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
&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LogOut" runat="server">Cerrar Sesión</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="Asignaturas" runat="server">Asignaturas</asp:LinkButton>
            <br />
            <br />
        </div>
        <asp:LinkButton ID="Tareas" runat="server">Tareas</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="Grupos" runat="server">Grupos</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="XML" runat="server">Importar y XML Document</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="Exportar" runat="server">Exportar</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="DataSet" runat="server">Importar y DataSet</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="Estadisticas" runat="server">Estadisticas Alumnos</asp:LinkButton>
    </form>
</body>
</html>

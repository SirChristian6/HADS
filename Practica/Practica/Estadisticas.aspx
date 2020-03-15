<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Estadisticas.aspx.vb" Inherits="Practica.Estadisticas" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

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
            <asp:LinkButton ID="LogOut" runat="server">Cerrar Sesión</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="Inicio" runat="server">Ir a Inicio</asp:LinkButton>
            <br />
            <br />
            <br />
            <br />
            <asp:DropDownList ID="alumno" runat="server" DataSourceID="SqlDataSource1" DataTextField="email" DataValueField="email" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AmigosConnectionString %>" SelectCommand="SELECT [email] FROM [Usuarios] WHERE ([tipo] = @tipo)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="Alumno" Name="tipo" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource2">
                <series>
                    <asp:Series Name="Series1" XValueMember="codigo" YValueMembers="MediaDeHoras">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:AmigosConnectionString %>" SelectCommand="SELECT Asignaturas.codigo, AVG(EstudiantesTareas.HReales) AS MediaDeHoras FROM Asignaturas INNER JOIN TareasGenericas ON Asignaturas.codigo = TareasGenericas.CodAsig INNER JOIN EstudiantesTareas ON EstudiantesTareas.codtarea = TareasGenericas.codigo WHERE (EstudiantesTareas.Email = @email) GROUP BY Asignaturas.codigo">
                <SelectParameters>
                    <asp:ControlParameter ControlID="alumno" Name="email" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>

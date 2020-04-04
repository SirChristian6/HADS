<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Alumno.aspx.vb" Inherits="Practica.WebForm6" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

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
            <br />
            <br />
            <asp:LinkButton ID="Tasks" runat="server">Tareas Genéricas</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="OwnTasks" runat="server">Tareas Propias</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="Groups" runat="server">Grupos</asp:LinkButton>

                
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

                
        </div>
            
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0">
                    <ProgressTemplate>
                        <br />
                        Cargando... Por favor no sea impaciente :)<br />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <br />
                <asp:Label ID="Count" runat="server"></asp:Label>
                <br />
                <br />
                <asp:ListBox ID="Alumnos" runat="server" Width="200px"></asp:ListBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ListBox ID="Profesores" runat="server" Width="200px"></asp:ListBox>
                <asp:Timer ID="Timer1" runat="server" Interval="5000">
                </asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>
            
    </form>
</body>
</html>

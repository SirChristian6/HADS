<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profesor.aspx.vb" Inherits="Practica.WebForm9" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

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
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="Coordinador" runat="server">Zona Coordinador</asp:LinkButton>
            <br />


            
            
            <ajaxToolkit:DragPanelExtender ID="DragPanelExtender1" runat="server" DragHandleID="Panel2" TargetControlID="Panel1" />
            

            <br />

            <asp:Panel ID="Panel1" runat="server" BackColor="#CCCCCC" Width="266px" Height="300px">
                <asp:Panel ID="Panel2" runat="server" BackColor="#999999" ForeColor="White" Height="31px" Width="266px">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Drag me :)</asp:Panel>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="Asignaturas" runat="server">Asignaturas</asp:LinkButton>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="Tareas" runat="server">Tareas</asp:LinkButton>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="Grupos" runat="server">Grupos</asp:LinkButton>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="XML" runat="server">Importar v. XML Document</asp:LinkButton>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="Exportar" runat="server">Exportar</asp:LinkButton>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="DataSet" runat="server">Importar v. DataSet</asp:LinkButton>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="Estadisticas" runat="server">Estadisticas Alumnos</asp:LinkButton>
                <br />
            </asp:Panel>
            

            <br />
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <ajaxToolkit:DragPanelExtender ID="DragPanelExtender2" runat="server" DragHandleID="Panel4" TargetControlID="Panel3" />
            
        <asp:Panel ID="Panel3" runat="server" BackColor="#CCCCCC" Height="200px" Width="548px">
            <asp:Panel ID="Panel4" runat="server" BackColor="#999999" ForeColor="White" Height="31px" Width="548px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Drag me :)</asp:Panel>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0">
                    <ProgressTemplate>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cargando... Por favor no sea impaciente :)<br />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Count" runat="server"></asp:Label>
                <br />
                <asp:Timer ID="Timer1" runat="server" Interval="5000">
                </asp:Timer>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ListBox ID="Alumnos" runat="server" Width="200px"></asp:ListBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ListBox ID="Profesores" runat="server" Width="200px"></asp:ListBox>
            </ContentTemplate>
        </asp:UpdatePanel>
        </asp:Panel>
    </form>
</body>
</html>

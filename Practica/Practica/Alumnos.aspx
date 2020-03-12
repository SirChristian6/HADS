<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Alumnos.aspx.vb" Inherits="Practica.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <div>
            <asp:LinkButton ID="Tasks" runat="server">Tareas Genéricas</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="OwnTasks" runat="server">Tareas Propias</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="Groups" runat="server">Grupos</asp:LinkButton>

                
        </div>
            
    </form>
</body>
</html>

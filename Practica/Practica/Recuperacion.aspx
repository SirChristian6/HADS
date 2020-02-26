<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Recuperacion.aspx.vb" Inherits="Practica.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Email" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="ChangeRequest"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email" ErrorMessage="Por favor, introduzca un correo electrónico válido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="ChangeRequest"></asp:RegularExpressionValidator>
            <br />
            <br />
        </div>
        <div>
            <asp:Button ID="ChangeRequest" runat="server" Text="Solicitar Cambio de Contraseña" ValidationGroup="ChangeRequest" />
        </div>
        <div
            <asp:Label ID="Response1" runat="server"></asp:Label>
        </div>
        <div>
            &nbsp;</div>
        <div>
            <asp:Label runat="server" Text="Contraseña: "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Pass1" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Pass1" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="Change"></asp:RequiredFieldValidator>
            <br />
            <br />
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Repetir Contraseña: "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Pass2" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Pass2" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="Change"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Pass1" ControlToValidate="Pass2" ErrorMessage="Las contraseñas introducidas deben coincidir" ForeColor="Red" ValidationGroup="Change"></asp:CompareValidator>
            <br />
            <br />
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Número de Confirmación: "></asp:Label>
            &nbsp;<asp:TextBox ID="NumConfirmacion" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="NumConfirmacion" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="Change"></asp:RequiredFieldValidator>
            <br />
            <br />
        </div>
        <div>
            <asp:Button ID="Change" runat="server" Text="Cambiar Contraseña" ValidationGroup="Change" />
            <br />
            <br />
        </div>
        <div>
            <asp:Label ID="Response2" runat="server"></asp:Label>
        </div>
        <p>
            <asp:Button ID="LogIn" runat="server" Text="Volver a Iniciar Sesión" />
        </p>
    </form>
</body>
</html>

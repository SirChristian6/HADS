<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="Practica.WebForm1" %>

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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Email" runat="server" TextMode="Email" ValidationGroup="LogIn"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Email" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="LogIn"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="LogIn">Por favor, use una dirección de correo válida.</asp:RegularExpressionValidator>
            <br />
            <br />
        </div>
        <div>
            <asp:Label ID="Contraseña" runat="server" Text="Contraseña: "></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Pass" runat="server" TextMode="Password" ValidationGroup="LogIn"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Pass" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="LogIn">Campo requerido.</asp:RequiredFieldValidator>
            <br />
            <br />
        </div>
        <div>
            <asp:Button ID="LogIn" runat="server" Text="Iniciar Sesión" ValidationGroup="LogIn" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SignUp" runat="server" style="margin-bottom: 0px" Text="Registrarse" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="ChangeRequest" runat="server" Text="He olvidado mi contraseña" />
        </div>
        <p>
            <asp:Label ID="Response" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>

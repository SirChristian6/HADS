<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Registro.aspx.vb" Inherits="Practica.WebForm2" %>

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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Por favor introduzca una dirección de correo válida" ControlToValidate="Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="SignUp"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo requerido" ControlToValidate="Email" ForeColor="Red" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
            <br />
            <br />
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Nombre: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Name" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo requerido" ControlToValidate="Name" ForeColor="Red" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
            <br />
            <br />
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Apellidos: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo requerido" ControlToValidate="LastName" ForeColor="Red" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
            <br />
            <br />
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Contraseña: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Pass1" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo requerido" ControlToValidate="Pass1" ForeColor="Red" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
            
            <br />
            
            <br />
            
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Text="Repetir Contraseña: "></asp:Label>
    &nbsp;
            <asp:TextBox ID="Pass2" runat="server" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Las contraseñas introducidas no coinciden" ControlToCompare="Pass1" ControlToValidate="Pass2" ForeColor="Red" ValidationGroup="SignUp"></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo requerido" ControlToValidate="Pass2" ForeColor="Red" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
            
            <br />
            
            <br />
            
        </div>
        <div>
            <asp:Label ID="Label6" runat="server" Text="Rol: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="Role" runat="server">
                <asp:ListItem>Alumno</asp:ListItem>
                <asp:ListItem>Profesor</asp:ListItem>
            </asp:DropDownList>
        </div>

        <p style="margin-left: 40px">
            <asp:Button ID="SignUp" runat="server" Text="Crear cuenta" ValidationGroup="SignUp" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="LogIn" runat="server" Text="Ya tengo una cuenta" />
        </p>
        <asp:Label ID="Response" runat="server" Text=""></asp:Label>
        
    </form>
</body>
</html>

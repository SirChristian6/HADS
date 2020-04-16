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
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Label ID="Label1" runat="server" Text="Email: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="Email" runat="server" AutoPostBack="True"></asp:TextBox>
                    <asp:Label ID="Matriculado" runat="server"></asp:Label>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email" ErrorMessage="Por favor introduzca una dirección de correo válida" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="SignUp"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Email" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <div>
                        <asp:Label ID="Label2" runat="server" Text="Nombre: "></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="Name" runat="server" AutoCompleteType="MiddleName"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Name" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                    </div>
                    <div>
                        <asp:Label ID="Label3" runat="server" Text="Apellidos: "></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="LastName" runat="server" AutoCompleteType="LastName"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="LastName" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                    </div>
                    <div>
                        <asp:Label ID="Label4" runat="server" Text="Contraseña: "></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="Pass1" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:Label ID="Valida" runat="server"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Pass1" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                    </div>
                    <div>
                        <asp:Label ID="Label5" runat="server" Text="Repetir Contraseña: "></asp:Label>
                        &nbsp;
                        <asp:TextBox ID="Pass2" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="Pass1" ControlToValidate="Pass2" ErrorMessage="Las contraseñas introducidas no coinciden" ForeColor="Red" ValidationGroup="SignUp"></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Pass2" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
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
                        <asp:Button ID="SignUp" runat="server" Enabled="False" Text="Crear cuenta" ValidationGroup="SignUp" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="LogIn" runat="server" Text="Ya tengo una cuenta" />
                    </p>
                    <asp:Label ID="Respuesta" runat="server"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
        </div>
        
    </form>
</body>
</html>

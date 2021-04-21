<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Registro.aspx.vb" Inherits="WebApp.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 282px;
        }
        .auto-style2 {
            width: 152px;
        }
        .auto-style3 {
            height: 461px;
        }
        .auto-style4 {
            width: 152px;
            height: 26px;
        }
        .auto-style5 {
            width: 282px;
            height: 26px;
        }
        .auto-style6 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 40px" class="auto-style3">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td class="auto-style1">
            <asp:TextBox ID="TextBox1" runat="server" TextMode="Email" Width="239px"></asp:TextBox>
                    </td>
                    <td>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Email invalido</asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Campo Obligatorio</asp:RequiredFieldValidator>
                        <asp:Button ID="Button2" runat="server" Text="Comprobar VIP" />
                        <asp:Label ID="Label6" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                    </td>
                    <td class="auto-style1">
            <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 0px" Width="122px" ValidationGroup="[A-Za-z]{2,10}"></asp:TextBox>
                    </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Campo Obligatorio</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label3" runat="server" Text="Apellidos"></asp:Label>
                    </td>
                    <td class="auto-style1">
            <asp:TextBox ID="TextBox3" runat="server" ValidationGroup="[A-Za-z]{2,10}"></asp:TextBox>
                    </td>
                    <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Campo Obligatorio</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
            <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td class="auto-style5">
            <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style6">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Campo Obligatorio</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox4" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" Enabled="False">Contraseña Invalida</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label5" runat="server" Text="Repetir Password"></asp:Label>
                    </td>
                    <td class="auto-style1">
            <asp:TextBox ID="TextBox5" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Campo Obligatorio</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox5" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" Enabled="False">Contraseña Invalida</asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
&nbsp;&nbsp;Rol:
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem>Alumno</asp:ListItem>
                <asp:ListItem>Profesor</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Campo Obligatorio</asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Registrar" Width="171px" OnClientClick="~/Confirmar.aspx" PostBackUrl="~/Confirmar.aspx" />
        </div>
    </form>
</body>
</html>

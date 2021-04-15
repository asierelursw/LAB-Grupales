<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="tablausuarios.aspx.vb" Inherits="WebApp.tablausuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<asp:Table BorderWidth="1" runat="server">
    <asp:TableRow>
        <asp:TableCell>Alumnos</asp:TableCell>
        <asp:TableCell>Profesores</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell id="countalumnos" runat="server">Count(Alumnos)</asp:TableCell>
        <asp:TableCell id="countprofesores" runat="server">Count(Profesores)</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell id="correoalumnos" runat="server">Correo(Alumnos)</asp:TableCell>
        <asp:TableCell id="correoprofesores" runat="server">Correo(Profesores)</asp:TableCell>
    </asp:TableRow>
</asp:Table>
</body>
</html>

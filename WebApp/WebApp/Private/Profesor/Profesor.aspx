<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profesor.aspx.vb" Inherits="WebApp.Profesor" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript"
    src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js">
    </script>
    <script type="text/javascript" src="../JavaScript.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
     <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" ForeColor="Blue" NavigateUrl="~/Private/Logout.aspx">Cerrar Sesión</asp:HyperLink>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:LinkButton ID="LinkButton1" runat="server">Asignaturas</asp:LinkButton>
        <p>
        <asp:LinkButton ID="LinkButton2" runat="server">Tareas</asp:LinkButton>
        </p>
        <asp:LinkButton ID="LinkButton3" runat="server">Grupos</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton4" runat="server">Importar v. XML Document</asp:LinkButton>
        <p>
        <asp:LinkButton ID="LinkButton5" runat="server">Exportar</asp:LinkButton>
        </p>

        <br />
        <div id="tablasAJAX" runat="server">

        </div>

    </form>
</body>
</html>

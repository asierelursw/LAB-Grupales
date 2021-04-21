<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Coordinador.aspx.vb" Inherits="WebApp.Coordinador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                </div>
                AREA DE COORDINACION<br />
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
<br />
<br />
                Selecciona una de las asignaturas siguientes:&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server" Height="116px" Width="158px" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-12ConnectionString %>" SelectCommand="SELECT Distinct codigoasig FROM ProfesoresGrupo inner join GruposClase on codigo = codigogrupo WHERE Email = @email">
                    <SelectParameters>
                        <asp:SessionParameter Name="email" SessionField="email" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" Text="Obtener las Horas" />
<br />
                <br />
                El valor medio de Horas Reales:
                <asp:TextBox ID="TextBox1" runat="server" Height="19px" Width="59px"></asp:TextBox>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

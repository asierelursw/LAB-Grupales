<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GestionUsuarios.aspx.vb" Inherits="WebApp.GestionUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1" style="text-align: center; margin-left: 80px">
            Bienvenido al area de administrador!<br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="email" DataSourceID="SqlDataSource1" style="text-align: center" CellSpacing="2">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="email" HeaderText="email" ReadOnly="True" SortExpression="email" />
                    <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                    <asp:BoundField DataField="apellidos" HeaderText="apellidos" SortExpression="apellidos" />
                    <asp:BoundField DataField="numconfir" HeaderText="numconfir" SortExpression="numconfir" />
                    <asp:CheckBoxField DataField="confirmado" HeaderText="confirmado" SortExpression="confirmado" />
                    <asp:BoundField DataField="tipo" HeaderText="tipo" SortExpression="tipo" />
                    <asp:BoundField DataField="pass" HeaderText="pass" SortExpression="pass" />
                    <asp:BoundField DataField="codpass" HeaderText="codpass" SortExpression="codpass" />
                </Columns>
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:HADS21-12ConnectionString %>" DeleteCommand="DELETE FROM [Usuarios] WHERE [email] = @original_email AND [nombre] = @original_nombre AND [apellidos] = @original_apellidos AND [numconfir] = @original_numconfir AND [confirmado] = @original_confirmado AND [tipo] = @original_tipo AND [pass] = @original_pass AND (([codpass] = @original_codpass) OR ([codpass] IS NULL AND @original_codpass IS NULL))" InsertCommand="INSERT INTO [Usuarios] ([email], [nombre], [apellidos], [numconfir], [confirmado], [tipo], [pass], [codpass]) VALUES (@email, @nombre, @apellidos, @numconfir, @confirmado, @tipo, @pass, @codpass)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Usuarios]" UpdateCommand="UPDATE [Usuarios] SET [nombre] = @nombre, [apellidos] = @apellidos, [numconfir] = @numconfir, [confirmado] = @confirmado, [tipo] = @tipo, [pass] = @pass, [codpass] = @codpass WHERE [email] = @original_email AND [nombre] = @original_nombre AND [apellidos] = @original_apellidos AND [numconfir] = @original_numconfir AND [confirmado] = @original_confirmado AND [tipo] = @original_tipo AND [pass] = @original_pass AND (([codpass] = @original_codpass) OR ([codpass] IS NULL AND @original_codpass IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="original_email" Type="String" />
                    <asp:Parameter Name="original_nombre" Type="String" />
                    <asp:Parameter Name="original_apellidos" Type="String" />
                    <asp:Parameter Name="original_numconfir" Type="Int32" />
                    <asp:Parameter Name="original_confirmado" Type="Boolean" />
                    <asp:Parameter Name="original_tipo" Type="String" />
                    <asp:Parameter Name="original_pass" Type="String" />
                    <asp:Parameter Name="original_codpass" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="email" Type="String" />
                    <asp:Parameter Name="nombre" Type="String" />
                    <asp:Parameter Name="apellidos" Type="String" />
                    <asp:Parameter Name="numconfir" Type="Int32" />
                    <asp:Parameter Name="confirmado" Type="Boolean" />
                    <asp:Parameter Name="tipo" Type="String" />
                    <asp:Parameter Name="pass" Type="String" />
                    <asp:Parameter Name="codpass" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="nombre" Type="String" />
                    <asp:Parameter Name="apellidos" Type="String" />
                    <asp:Parameter Name="numconfir" Type="Int32" />
                    <asp:Parameter Name="confirmado" Type="Boolean" />
                    <asp:Parameter Name="tipo" Type="String" />
                    <asp:Parameter Name="pass" Type="String" />
                    <asp:Parameter Name="codpass" Type="Int32" />
                    <asp:Parameter Name="original_email" Type="String" />
                    <asp:Parameter Name="original_nombre" Type="String" />
                    <asp:Parameter Name="original_apellidos" Type="String" />
                    <asp:Parameter Name="original_numconfir" Type="Int32" />
                    <asp:Parameter Name="original_confirmado" Type="Boolean" />
                    <asp:Parameter Name="original_tipo" Type="String" />
                    <asp:Parameter Name="original_pass" Type="String" />
                    <asp:Parameter Name="original_codpass" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>

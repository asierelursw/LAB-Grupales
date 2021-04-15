
<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TareasProfesor.aspx.vb" Inherits="WebApp.TareasProfesor" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div>
            <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Font-Bold="True" Font-Size="X-Large" ForeColor="Black" Height="146px" Width="1430px">
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; PROFESOR<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; GESTIÓN TAREAS GENÉRICAS</asp:Panel>
        </div>
        <p>
            &nbsp;</p>
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" ForeColor="Blue" NavigateUrl="~/Private/Logout.aspx">Cerrar Sesión</asp:HyperLink>
            
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <br />
            Seleccionar asignatura:<br />
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="asignaturasProfesor" DataTextField="codigoasig" DataValueField="codigoasig" AutoPostBack="True">
            </asp:DropDownList>
            <asp:SqlDataSource ID="asignaturasProfesor" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-12ConnectionString %>" SelectCommand="SELECT codigoasig FROM GruposClase
WHERE codigo in (SELECT Codigogrupo FROM ProfesoresGrupo WHERE ProfesoresGrupo.Email = @email)">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="Email" />
                </SelectParameters>
                </asp:SqlDataSource>
            <br />
        
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Codigo" DataSourceID="SqlDataSource2" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" ReadOnly="True" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                    <asp:BoundField DataField="CodAsig" HeaderText="CodAsig" SortExpression="CodAsig" />
                    <asp:BoundField DataField="HEstimadas" HeaderText="HEstimadas" SortExpression="HEstimadas" />
                    <asp:CheckBoxField DataField="Explotacion" HeaderText="Explotacion" SortExpression="Explotacion" />
                    <asp:BoundField DataField="TipoTarea" HeaderText="TipoTarea" SortExpression="TipoTarea" />
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-12ConnectionString %>" SelectCommand="SELECT [Codigo], [Descripcion], [CodAsig], [HEstimadas], [Explotacion], [TipoTarea] FROM [TareasGenericas] WHERE ([CodAsig] = @CodAsig)" DeleteCommand="DELETE FROM [TareasGenericas] WHERE [Codigo] = @Codigo" InsertCommand="INSERT INTO [TareasGenericas] ([Codigo], [Descripcion], [CodAsig], [HEstimadas], [Explotacion], [TipoTarea]) VALUES (@Codigo, @Descripcion, @CodAsig, @HEstimadas, @Explotacion, @TipoTarea)" UpdateCommand="UPDATE [TareasGenericas] SET [Descripcion] = @Descripcion, [CodAsig] = @CodAsig, [HEstimadas] = @HEstimadas, [Explotacion] = @Explotacion, [TipoTarea] = @TipoTarea WHERE [Codigo] = @Codigo">
                <DeleteParameters>
                    <asp:Parameter Name="Codigo" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Codigo" Type="String" />
                    <asp:Parameter Name="Descripcion" Type="String" />
                    <asp:Parameter Name="CodAsig" Type="String" />
                    <asp:Parameter Name="HEstimadas" Type="Int32" />
                    <asp:Parameter Name="Explotacion" Type="Boolean" />
                    <asp:Parameter Name="TipoTarea" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="CodAsig" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Descripcion" Type="String" />
                    <asp:Parameter Name="CodAsig" Type="String" />
                    <asp:Parameter Name="HEstimadas" Type="Int32" />
                    <asp:Parameter Name="Explotacion" Type="Boolean" />
                    <asp:Parameter Name="TipoTarea" Type="String" />
                    <asp:Parameter Name="Codigo" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Insertar Tareas" PostBackUrl="~/Private/Profesor/InsertarTarea.aspx" />
            <br />
            <br />
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server">Cerrar Sesión</asp:LinkButton>
            <br />
            <br />
            <br />
            <br />
            <br />
                </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>

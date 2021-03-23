Imports System.IO
Imports System.Text
Imports System.Data.SqlClient
Imports System.Xml
Imports DAO.AccesodatosSQL
Public Class ImportarTareas
    Inherits System.Web.UI.Page

    Private Shared comando As New SqlCommand
    Dim conClsf As SqlConnection = New SqlConnection(“Server=tcp:hads21-12.database.windows.net,1433;Initial Catalog=HADS21-12;Persist Security Info=False;User ID=esalgueira001@ikasle.ehu.eus@hads21-12;Password=070054hmK;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
    Dim dapTareas As New SqlDataAdapter()
    Dim dstTareas As New DataSet()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            dstTareas = Session("datos")
            dapTareas = Session("adapter")
        Else
            Dim Sql = "SELECT Codigo, Descripcion, CodAsig, HEstimadas, Explotacion, TipoTarea FROM TareasGenericas WHERE CodAsig='" + DropDownList1.Text + "'"
            dapTareas = New SqlDataAdapter(Sql, conClsf)
            dapTareas.Fill(dstTareas)
            Dim tblTareas As New DataTable()
            tblTareas = dstTareas.Tables(0)
            Session("datos") = dstTareas
            Session("adapter") = dapTareas
            GridView1.DataSource = dstTareas.Tables(0)
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim Sql = "SELECT Codigo, Descripcion, CodAsig, HEstimadas, Explotacion, TipoTarea FROM TareasGenericas WHERE CodAsig='" + DropDownList1.Text + "'"
        dapTareas = New SqlDataAdapter(Sql, conClsf)
        dstTareas.Tables(0).Clear()
        dapTareas.Fill(dstTareas)
        GridView1.DataSource = dstTareas.Tables(0)
        GridView1.DataBind()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Sql = "SELECT Codigo, Descripcion, CodAsig, HEstimadas, Explotacion, TipoTarea FROM TareasGenericas WHERE CodAsig='" + DropDownList1.Text + "'"
        dapTareas = New SqlDataAdapter(Sql, conClsf)
        Dim bldTareas = New SqlCommandBuilder(dapTareas)
        dapTareas.Fill(dstTareas)
        Dim tblTareas As New DataTable()
        tblTareas = dstTareas.Tables.Item(0)
        tblTareas.TableName = "tarea"
        tblTareas.Columns.Item(0).ColumnMapping = MappingType.Attribute
        For index As Integer = 1 To tblTareas.Columns.Count
            Dim nameCaps = tblTareas.Columns.Item(index - 1).ColumnName.ToLower
            tblTareas.Columns.Item(index - 1).ColumnName = nameCaps
        Next
        dstTareas = tblTareas.DataSet
        dstTareas.DataSetName = "tareas"
        dstTareas.WriteXml(Server.MapPath("App_Data/" + DropDownList1.SelectedValue + ".xml"))
        Dim xml As New XmlDocument
        xml.Load(Server.MapPath("App_Data/" + DropDownList1.SelectedValue + ".xml"))
    End Sub
End Class
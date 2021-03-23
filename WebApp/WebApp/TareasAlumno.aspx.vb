Imports System.Data.SqlClient
Imports DAO.AccesodatosSQL
Imports System.Data.OleDb


Public Class TareasAlumno
    Inherits System.Web.UI.Page

    Public Shared connection As New SqlConnection()
    Public Shared sda As New SqlDataAdapter()


    Protected Sub Page_Load()
        If Not Page.IsPostBack() Then
            GridView1.DataSource = Session("View")
            GridView1.DataBind()
        Else
            'Session("Tareas") = sda.Table(0)
        End If
    End Sub

    'Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

    'Dim Sql = "SELECT Codigo, Descripcion, HEstimadas, TipoTarea FROM TareasGenericas WHERE CodAsig='" + DropDownList1.SelectedValue + "' AND Explotacion=1"
    '   sda = New SqlDataAdapter(Sql, connection)
    '  connection.ConnectionString = “Server=tcp:hads21-12.database.windows.net,1433;Initial Catalog=HADS21-12;Persist Security Info=False;User ID=esalgueira001@ikasle.ehu.eus@hads21-12;Password=070054hmK;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
    'Dim ds As New DataSet()
    '   sda.Fill(ds)
    '  Session("Asignaturas") = sda
    ''GridView1.DataSource = ds.Tables(0)
    'Dim view = New DataView(ds.Tables(0))
    '   view.RowFilter = "CodAsig=" & DropDownList1.SelectedValue & ""
    '  Session("View") = view
    ' GridView1.DataSource = view
    'GridView1.DataBind()
    'End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim ds As New DataSet()
        Dim Sql = "SELECT Codigo, Descripcion, HEstimadas, TipoTarea FROM TareasGenericas WHERE CodAsig='" + DropDownList1.SelectedValue + "' AND Explotacion=1"
        Dim connection As New SqlConnection()
        connection.ConnectionString = “Server=tcp:hads21-12.database.windows.net,1433;Initial Catalog=HADS21-12;Persist Security Info=False;User ID=esalgueira001@ikasle.ehu.eus@hads21-12;Password=070054hmK;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        Dim sda = New SqlDataAdapter(Sql, connection)
        sda.Fill(ds)
        GridView1.DataSource = ds.Tables(0)
        GridView1.DataBind()

    End Sub

    Protected Sub GridView1_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim codigo = GridView1.SelectedRow.Cells(1).Text
        Dim horas = GridView1.SelectedRow.Cells(3).Text
        Dim usuario = Session("Email")
        Response.Redirect("InstanciarTarea.aspx?codigo=" + codigo + " + &usuario=" + usuario + " &horas=" + horas)
    End Sub

End Class
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports DAO.AccesodatosSQL
Public Class InstanciarTareas
    Inherits System.Web.UI.Page
    Private Shared comando As New SqlCommand



    Dim conClsf As SqlConnection = New SqlConnection(“Server=tcp:hads21-12.database.windows.net,1433;Initial Catalog=HADS21-12;Persist Security Info=False;User ID=esalgueira001@ikasle.ehu.eus@hads21-12;Password=070054hmK;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
    Dim dapTareas As New SqlDataAdapter()
    Dim dstTareas As New DataSet()
    Dim tblTareas As New DataTable()
    Dim rowTareas As DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Text = Request.QueryString("usuario")
        TextBox2.Text = Request.QueryString("codigo")
        TextBox3.Text = Request.QueryString("horas")

        If Page.IsPostBack Then
            dstTareas = Session("TareasAlumno")
            dapTareas = Session("Adapter")
        Else
            Dim Sql = "SELECT Email, CodTarea, HEstimadas, HReales FROM EstudiantesTareas WHERE CodTarea='" + Request.QueryString("codigo") + "'"
            dapTareas = New SqlDataAdapter(Sql, conClsf)
            dapTareas.Fill(dstTareas)
            Session("TareasAlumno") = dstTareas
            Session("Adapter") = dapTareas
            GridView1.DataSource = dstTareas.Tables(0)
            GridView1.DataBind()
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim usuario As String = Session("Email")
        Dim codigo As String = Request.QueryString("codigo")
        Dim horas As String = Request.QueryString("horas")

        Dim Sql = "Update EstudiantesTareas SET HReales = '" & TextBox4.Text & "' WHERE Email ='" & usuario & "' AND CodTarea = '" & codigo & "';"
        conClsf.Open()
        comando = New SqlCommand(Sql, conClsf)
        comando.ExecuteNonQuery()
        conClsf.Close()
        Response.Redirect("InstanciarTarea.aspx?codigo=" + codigo + " + &usuario=" + usuario + " &horas=" + horas)
    End Sub

    Protected Sub Page_Unload(ByRefsender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        'dapTareas = Session("EstudiantesTareas")
        'dapTareas.Update(dstTareas)
        'dstTareas.AcceptChanges()
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class
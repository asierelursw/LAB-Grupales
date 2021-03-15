Imports System.Data.SqlClient
Imports DAO.AccesodatosSQL

Public Class TareasAlumno
    Inherits System.Web.UI.Page

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim ds As New DataSet()
        Dim Sql = "SELECT Codigo, Descripcion, HEstimadas AS Horas, TipoTarea AS Tipo FROM TareasGenericas WHERE CodAsig='" + DropDownList1.SelectedValue + "' AND Explotacion=1"
        Dim connection As New SqlConnection()
        connection.ConnectionString = “Server=tcp:hads21-12.database.windows.net,1433;Initial Catalog=HADS21-12;Persist Security Info=False;User ID=esalgueira001@ikasle.ehu.eus@hads21-12;Password=070054hmK;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        Dim sda = New SqlDataAdapter(Sql, connection)
        sda.Fill(ds)
        GridView1.DataSource = ds.Tables(0)
        GridView1.DataBind()

    End Sub

    Protected Sub GridView1_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim codigo = GridView1.SelectedRow.Cells(1).ToString
        Dim horas = GridView1.SelectedRow.Cells(3).ToString
        Response.Redirect("InstanciarTarea.aspx?codigo=" & codigo & " + horas=" & horas + "")
    End Sub

End Class
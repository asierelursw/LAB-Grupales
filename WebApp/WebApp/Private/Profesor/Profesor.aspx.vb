
Public Class Profesor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Response.Redirect("InsertarTarea.aspx")
    End Sub
    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles LinkButton2.Click
        Response.Redirect("TareasProfesor.aspx")
    End Sub
    Protected Sub LinkButton4_Click(sender As Object, e As EventArgs) Handles LinkButton4.Click
        Response.Redirect("ImportarTareasAlt.aspx")
    End Sub
    Protected Sub LinkButton5_Click(sender As Object, e As EventArgs) Handles LinkButton5.Click
        Response.Redirect("ExportarTareas.aspx")
    End Sub

    Protected Sub LinkButton6_Click(sender As Object, e As EventArgs) Handles LinkButton6.Click
        Response.Redirect("Coordinador.aspx")
    End Sub
End Class
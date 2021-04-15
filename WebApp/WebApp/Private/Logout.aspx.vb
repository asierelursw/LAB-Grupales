Public Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("tipo") = "alumno" Then
            Application("alumnos").remove(Session("Email"))
        ElseIf Session("tipo") = "profesor" Then
            Application("profesores").remove(Session("Email"))
        End If
        Session.Abandon()
        Response.Redirect("../Inicio.aspx")
    End Sub

End Class
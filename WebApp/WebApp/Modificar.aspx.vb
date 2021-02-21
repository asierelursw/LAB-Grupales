Imports System.Data.SqlClient
Imports DAO.AccesodatosSQL
Imports MandarMail.MandarMail
Public Class Modificar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = Conectar()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim email As String = TextBox1.Text
        Dim rng As New Random()
        Dim randomNo As Integer = rng.Next(999999) ' this is a random number between 0 and 999999.
        Dim body As String = "Su codigo de restablecer contraseña es " + randomNo.ToString
        Dim mail As New MandarMail.MandarMail
        mail.enviarEmail(email, "Modificación de contraseña", body)

        Update2(randomNo, email)


    End Sub


    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim email As String = TextBox1.Text
        Dim pass As String = TextBox3.Text

        If Update3(pass, email) = 1 Then
            MsgBox("Contraseña modificada con exito")
            cerrarconexion()
            Server.Transfer("~/Inicio.aspx")
        Else
            MsgBox("Error modificando la contraseña, revise el codigo introducido")
            Server.Transfer("~/Modificar.aspx")
        End If


    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        cerrarconexion()
    End Sub
End Class
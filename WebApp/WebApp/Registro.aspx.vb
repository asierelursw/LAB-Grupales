Imports System.Data.SqlClient
Imports System.Net.Mail
Imports DAO.AccesodatosSQL
Imports MandarMail.MandarMail

Public Class Registro
    Inherits System.Web.UI.Page
    Private Shared mail As New MandarMail.MandarMail

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = Conectar()
    End Sub

    Protected Sub Button1_Click1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rng As New Random()
        Dim randomNo As Integer = rng.Next(999999) ' this is a random number between 0 and 999999.
        Try
            Response.Write(insertarVadillo(TextBox1.Text, TextBox2.Text, TextBox3.Text, randomNo, RadioButtonList1.SelectedValue, TextBox4.Text))
            Dim body As String = "Su codigo de confirmación es " + randomNo.ToString

            If (mail.enviarEmail(TextBox1.Text, "Confirmacion de la cuenta", body)) Then
                Response.Write("    EMAIL DE CONFIRMACION ENVIADO")
            Else Response.Write("   EMAIL DE CONFIRMACION NO ENVIADO (MAL)")
            End If

        Catch ex As Exception
            MsgBox("Error obteniendo datos")
            Exit Sub
        End Try
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        cerrarconexion()
    End Sub

End Class
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

        Dim pass = TextBox4.Text
        Dim hash As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(pass)
        bytesToHash = hash.ComputeHash(bytesToHash)
        pass = ""

        For Each b As Byte In bytesToHash
            pass += b.ToString("x2")
        Next
        Try
            Response.Write(insertarVadillo(TextBox1.Text, TextBox2.Text, TextBox3.Text, randomNo, RadioButtonList1.SelectedValue, pass))
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

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim matricula As New Matriculas.Matriculas
        Dim email = TextBox1.Text
        Dim res = matricula.comprobar(email)
        Label6.Text = res.ToString
        Label6.Visible = True

    End Sub
End Class
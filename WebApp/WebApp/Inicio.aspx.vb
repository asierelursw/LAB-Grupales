Imports DAO.AccesodatosSQL
Imports System.Data.SqlClient
Public Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        cerrarconexion()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = Conectar()
        Label1.Text = result
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If EstaRegistrado(TextBox1.Text, TextBox2.Text) = "Login realizado con exito" Then
            MsgBox("Login realizado con exito")
            cerrarconexion()
            Server.Transfer("~/Inicio.aspx")
        Else
            MsgBox("Login no realizado compruebe los datos insertados")
            cerrarconexion()
            Server.Transfer("~/Inicio.aspx")
        End If

    End Sub


End Class
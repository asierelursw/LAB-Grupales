Imports System.Data.SqlClient
Imports DAO.AccesodatosSQL
Public Class Confirmar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = Conectar()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim numconfir As Integer = TextBox1.Text

        If Update(numconfir) = 1 Then
            MsgBox("Cuenta confirmada con exito")
            cerrarconexion()
            Server.Transfer("~/Inicio.aspx")
        Else
            MsgBox("Revise el codigo introducido")
            Server.Transfer("~/Confirmar.aspx")
        End If


    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        cerrarconexion()
    End Sub
End Class
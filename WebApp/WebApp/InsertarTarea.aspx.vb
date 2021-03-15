Imports DAO.AccesodatosSQL
Public Class InsertarTarea
    Inherits System.Web.UI.Page
    Public Shared bd As New DAO.AccesodatosSQL
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = Conectar()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        cerrarconexion()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        agregarTarea(TextBox1.Text, TextBox2.Text, DropDownList1.SelectedValue, TextBox4.Text, DropDownList2.SelectedValue)
        cerrarconexion()
    End Sub
End Class
Public Class Coordinador
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim asig = DropDownList1.SelectedValue
        Dim sw As New horasmedias.horasmedias
        Dim media = sw.horasmedia(asig)
        TextBox1.Text = media
    End Sub
End Class
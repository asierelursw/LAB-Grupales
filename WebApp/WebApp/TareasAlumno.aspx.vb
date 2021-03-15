Imports DAO.AccesodatosSQL

Public Class TareasAlumno
    Inherits System.Web.UI.Page

    Public Shared x As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim x = verTareas(GridView1.DataSourceID)
        'DropDownList1.DataSource = VertareasAlumno(Session("Email"))

        'Session.Add("TablaTareas", x.Table)
        'GridView1.DataSource = x.Table
        'GridView1.DataBind()
        'Session.Add("TablaTareas", x)
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged


    End Sub

    Protected Sub GridView1_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class
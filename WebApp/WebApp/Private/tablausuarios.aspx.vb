Public Class tablausuarios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim listaalumnos As String = ""
        Dim totalalumnos As Integer = 0
        For h = 0 To Application("alumnos").count - 1
            listaalumnos = listaalumnos & Application("alumnos").item(h) & "<br>"
            totalalumnos = totalalumnos + 1
        Next h

        correoalumnos.Text = listaalumnos
        countalumnos.Text = totalalumnos

        Dim listaprofesores As String = ""
        Dim totalprofesores As Integer = 0
        For h = 0 To Application("profesores").count - 1
            listaprofesores = listaprofesores & Application("profesores").item(h) & "<br>"
            totalprofesores = totalprofesores + 1
        Next h

        correoprofesores.Text = listaprofesores
        countprofesores.Text = totalprofesores

    End Sub

End Class
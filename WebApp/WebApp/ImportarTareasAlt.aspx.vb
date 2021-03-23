Imports System.Data.SqlClient
Imports System.Xml
Imports WebApp
Public Class ImportarTareasAlt
    Inherits System.Web.UI.Page
    Dim connection As New SqlConnection(“Server=tcp:hads21-12.database.windows.net,1433;Initial Catalog=HADS21-12;Persist Security Info=False;User ID=esalgueira001@ikasle.ehu.eus@hads21-12;Password=070054hmK;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label1.Text = ""

        Try
            Dim Sql As String = "SELECT DISTINCT Codigo, Descripcion, HEstimadas, Explotacion, TipoTarea, CodAsig FROM TareasGenericas WHERE Explotacion = 'True' AND Codigo NOT IN (SELECT CodTarea FROM EstudiantesTareas WHERE Email = '" & Session("Email") & "');"
            Dim da = New SqlDataAdapter(Sql, connection)
            Dim tb As New SqlCommandBuilder(da)
            Dim tds As New DataSet
            da.Fill(tds)
            Dim tdt As New DataTable
            tdt = tds.Tables(0)

            Dim XMLDoc As New XmlDocument()
            XMLDoc.Load(Server.MapPath("App_Data/" & DropDownList1.Text & ".xml"))
            Dim tlist As XmlNodeList
            Dim tarea As XmlNode

            tlist = XMLDoc.GetElementsByTagName("tarea")

            For Each tarea In tlist

                Dim row As DataRow = tdt.NewRow

                row("Codigo") = tarea.Attributes.GetNamedItem("codigo").Value

                row("Descripcion") = tarea.ChildNodes(0).InnerText

                row("CodAsig") = DropDownList1.SelectedValue

                row("HEstimadas") = tarea.ChildNodes(1).InnerText

                If (tarea.ChildNodes(2).InnerText = "False") Then
                    row("Explotacion") = 0
                Else
                    row("Explotacion") = 1
                End If

                row("TipoTarea") = tarea.ChildNodes(3).InnerText

                tdt.Rows.Add(row)
            Next

            Dim act = da.Update(tds)

            If (act = 0) Then
                Label1.Text = "ERROR TAREAS YA IMPORTADAS"
            Else
                Label1.Text = "TAREAS IMPORTADAS CORRECTAMENTE"
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Label1.Text = ""

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

        Xml1.DocumentSource = Server.MapPath("App_Data/" & DropDownList1.Text & ".xml")
        Xml1.TransformSource = Server.MapPath("App_Data/VerTablaTareas.xsl")

    End Sub
End Class
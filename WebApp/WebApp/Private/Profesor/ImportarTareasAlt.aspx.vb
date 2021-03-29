Imports System.Data.SqlClient
Imports System.Xml
Imports WebApp
Public Class ImportarTareasAlt
    Inherits System.Web.UI.Page
    Dim connection As New SqlConnection(“Server=tcp:hads21-12.database.windows.net,1433;Initial Catalog=HADS21-12;Persist Security Info=False;User ID=esalgueira001@ikasle.ehu.eus@hads21-12;Password=070054hmK;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label1.Text = ""

        Try
            Dim Sql As String = "SELECT * FROM TareasGenericas WHERE 0=1;"
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

            Dim row As DataRow

            For Each tarea In tlist

                row = tds.Tables(0).NewRow

                Dim atr As XmlAttributeCollection = tarea.Attributes

                row.Item(0) = atr.ItemOf(0).Value

                row.Item(1) = tarea.ChildNodes(0).ChildNodes(0).Value

                row.Item(2) = DropDownList1.SelectedValue

                row.Item(3) = Convert.ToInt32(tarea.ChildNodes(1).InnerText)

                row.Item(4) = tarea.ChildNodes(2).ChildNodes(0).Value

                row.Item(5) = tarea.ChildNodes(3).ChildNodes(0).Value

                tds.Tables(0).Rows.Add(row)
            Next

            Try
                Dim act = da.Update(tds)
                Label1.Text = "TAREAS IMPORTADAS CORRECTAMENTE"
            Catch ex As Exception
                Label1.Text = "ERROR TAREAS YA IMPORTADAS"
                Exit Sub
            End Try

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
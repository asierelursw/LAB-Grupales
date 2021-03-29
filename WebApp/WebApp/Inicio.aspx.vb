Imports DAO.AccesodatosSQL
Imports System.Data.SqlClient
Imports System.Web.SessionState

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
        Dim email = TextBox1.Text
        Dim pass = TextBox2.Text
        If EstaRegistrado(email, pass) = "Login realizado con exito" Then
            Session.Add("Email", email)
            Session.Add("Nombre", Nombre(email))

            If email = "admin@ehu.es" Then
                System.Web.Security.FormsAuthentication.SetAuthCookie("admin@ehu.es", True)
                MsgBox("Login realizado con exito en modo Admin")
                cerrarconexion()
                Response.Redirect("Private/Administrador/GestionUsuarios.aspx")
                Exit Sub
            End If

            If EsProfesor(email) = 1 Then
                If email = "vadillo@ehu.es" Then
                    System.Web.Security.FormsAuthentication.SetAuthCookie("vadillo@ehu.es", True)
                Else
                    System.Web.Security.FormsAuthentication.SetAuthCookie("Profesor", True)
                End If
                MsgBox("Login realizado con exito en modo profesor")
                cerrarconexion()
                Response.Redirect("Private/Profesor/Profesor.aspx")
            Else
                System.Web.Security.FormsAuthentication.SetAuthCookie("Alumno", True)
                MsgBox("Login realizado con exito en modo Alumno")
                cerrarconexion()
                Response.Redirect("Private/Alumno/alumnos.aspx")
            End If

        Else
            MsgBox("Login no realizado compruebe los datos insertados")
            cerrarconexion()
            Server.Transfer("~/Inicio.aspx")
        End If

    End Sub


End Class
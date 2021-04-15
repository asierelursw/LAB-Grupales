﻿Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)

        Dim emaila As New List(Of String)
        Dim emailp As New List(Of String)

        Application("alumnos") = emaila
        Application("profesores") = emailp
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al iniciar la sesión
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al comienzo de cada solicitud
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al intentar autenticar el uso
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando se produce un error
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando finaliza la sesión
        If Session("tipo") = "alumno" Then
            Application("alumnos").remove(Session("Email"))
        ElseIf Session("tipo") = "profesor" Then
            Application("profesores").remove(Session("Email"))
        End If
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando finaliza la aplicación
    End Sub

End Class
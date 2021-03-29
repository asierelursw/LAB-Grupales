Imports System.Data.SqlClient
Imports System.Math
Imports Ubiety.Dns.Core
Imports System.Data

Public Class AccesodatosSQL
    Private Shared conexion As New SqlConnection
    Private Shared comando As New SqlCommand
    Private Shared comando1 As New SqlCommand

    Private Shared datAdapter As New SqlDataAdapter

    Private Shared datSet As New DataSet
    Private Shared datTable As New DataTable
    Private Shared daView As New DataView
    Public Shared Function Conectar() As String
        Try
            conexion.ConnectionString = “Server=tcp:hads21-12.database.windows.net,1433;Initial Catalog=HADS21-12;Persist Security Info=False;User ID=esalgueira001@ikasle.ehu.eus@hads21-12;Password=070054hmK;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            conexion.Open()
        Catch ex As Exception
            Return "ERROR DE CONEXIÓN: " + ex.Message
        End Try
        Return "CONEXION OK"
    End Function



    Public Shared Sub cerrarconexion()
        conexion.Close()
    End Sub

    Public Shared Function insertarVadillo(ByVal email As String, ByVal nombre As String, ByVal apellidos As String, ByVal randomNo As Integer, ByVal tipo As String, ByVal pass As String) As String

        Dim st = "insert into Usuarios values ('" & email & "', '" & nombre & "', '" & apellidos & "', " & randomNo & ", " & 0 & ", '" & tipo & "', '" & pass & "', " & 0 & ")"
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        Try
            numregs = comando.ExecuteNonQuery()
        Catch ex As Exception
            Return ex.Message
        End Try
        Return (numregs & " registro(s) insertado(s) en la BD ")
    End Function

    Public Shared Function agregarTarea(ByVal codigo As String, ByVal descripcion As String, ByVal codasig As String, ByVal hestimadas As Integer, ByVal tipotarea As String) As String

        Dim st = "insert into TareasGenericas(Codigo, Descripcion, CodAsig, HEstimadas, Explotacion, TipoTarea) values ('" & codigo & "', '" & descripcion & "',  '" & codasig & "', " & hestimadas & ", '" & True & "', '" & tipotarea & "')"
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        Try
            numregs = comando.ExecuteNonQuery()
        Catch ex As Exception
            Return ex.Message
        End Try
        Return (numregs & " registro(s) insertado(s) en la BD ")
    End Function

    Public Shared Function EstaRegistrado(ByVal email As String, ByVal pass As String) As String

        Dim numregs As Integer

        Try
            numregs = contar(email, pass)
            If numregs = 1 Then

                Return "Login realizado con exito"
            Else
                Try
                    Dim hash As New System.Security.Cryptography.MD5CryptoServiceProvider
                    Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(pass)
                    bytesToHash = hash.ComputeHash(bytesToHash)
                    pass = ""

                    For Each b As Byte In bytesToHash
                        pass += b.ToString("x2")
                    Next
                    numregs = contar(email, pass)
                    If numregs = 1 Then
                        Return "Login realizado con exito"
                    Else
                        Return "Login fallido, revise los datos introducidos"
                    End If

                Catch ex As Exception
                    Return "Registro fallido, error de servicio"
                End Try

            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString(), " Unable to insert, being hacked by pepe pruebas")
            Return ex.Message
        End Try
    End Function

    ' Public Shared Function verTareas(ByVal nombredatagrid As String) As Object
    'Dim st = "Select * From TareasGenericas"
    '   comando = New SqlCommand(st, conexion)

    'Dim query = comando.ExecuteNonQuery()

    '   datAdapter = New SqlDataAdapter(st, conexion)

    '  datAdapter.Fill(datSet, "Tareas")

    ' datTable = datSet.Tables("Tareas")

    'Return datSet
    'End Function
    Public Shared Function VertareasAlumno(ByVal email As String) As Object
        Dim st = "Select Nombre From Asignaturas JOIN GruposClase ON Asignaturas.codigo = GruposClase.codigo JOIN EstudiantesGrupo on GruposClase.codigo = EstudiantesGrupo.Grupo where EstudiantesGrupo.email = '" & email & "'"
        comando = New SqlCommand(st, conexion)

        Return comando.ExecuteNonQuery()

    End Function
    Public Shared Function EsProfesor(ByVal email As String) As Integer
        Dim st = "Select count (*) from Usuarios where email = '" & email & "' and tipo = 'Profesor'"
        comando = New SqlCommand(st, conexion)
        Return comando.ExecuteScalar()
    End Function

    Public Shared Function Nombre(ByVal email As String) As String
        Dim st = "Select Nombre from Usuarios where email = '" & email & "'"
        comando = New SqlCommand(st, conexion)
        Try
            Return comando.ExecuteNonQuery()
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function contar(ByVal email As String, ByVal pass As String) As Integer
        Dim st = "Select count(*) from Usuarios where email = '" & email & "' and pass ='" & pass & "' and confirmado ='True'"
        comando = New SqlCommand(st, conexion)
        Return comando.ExecuteScalar()
    End Function

    Public Shared Function Update(ByVal numconfir As Integer) As Integer
        Dim st = "UPDATE Usuarios SET confirmado = " & 1 & " WHERE numconfir = " & numconfir
        Dim st1 = "Select count(*) from Usuarios where numconfir = " & numconfir
        comando = New SqlCommand(st, conexion)
        comando1 = New SqlCommand(st1, conexion)
        Try
            comando.ExecuteNonQuery()
            Return comando1.ExecuteScalar()
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function Update2(ByVal randomNo As Integer, ByVal email As String) As Integer
        Dim st = "UPDATE Usuarios SET codpass = " & randomNo & " WHERE email = '" & email & "'"
        comando = New SqlCommand(st, conexion)
        Try
            comando.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function Update3(ByVal pass As String, ByVal email As String) As Integer
        Dim st = "UPDATE Usuarios SET pass ='" & pass & "' where email = '" & email & "'"
        comando = New SqlCommand(st, conexion)
        Try
            comando.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function

End Class
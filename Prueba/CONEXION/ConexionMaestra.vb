
Imports System.Data.SqlClient

Module ConexionMaestra
    Public ciudad As String
    Public id_ciudad As String

    Public Conexion As New SqlConnection("Data Source=ING-LLAMAS;Initial Catalog=Tienda_Comiclandia;Persist Security Info=True;User ID=sa;Password=oscar1012")
    Sub abrir()

        If Conexion.State = 0 Then
            Conexion.Open()
        End If

    End Sub


    Sub cerrar()

        If Conexion.State = 1 Then
            Conexion.Close()
        End If

    End Sub

End Module

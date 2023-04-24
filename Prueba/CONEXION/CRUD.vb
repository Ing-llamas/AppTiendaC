
Imports System.Data.SqlClient

Imports System.Windows.Forms

Public Class CRUD


    Sub buscar_Producto(ByVal buscador As String, ByRef dt As DataTable)


        Dim da As SqlDataAdapter

        Try
            abrir()
            da = New SqlDataAdapter("buscarProducto", Conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@Buscador", buscador)

            da.Fill(dt)


            cerrar()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Sub crear_Producto(ByVal nombreProducto As String, ByVal precio As Integer, ByVal Stock As Integer, ByVal Departamento As Integer)

        Dim cmd As New SqlCommand

        Try
            abrir()
            cmd = New SqlCommand("crear_producto", Conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@NombreProducto", nombreProducto)
            cmd.Parameters.AddWithValue("@Precio", precio)
            cmd.Parameters.AddWithValue("@Stock", Stock)
            cmd.Parameters.AddWithValue("@Departamento", Departamento)

            cmd.ExecuteNonQuery()
            MessageBox.Show("El producto se agrego correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            cerrar()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Sub mostrar_Producto(ByRef dt As DataTable)


        Dim da As SqlDataAdapter

        Try
            abrir()
            da = New SqlDataAdapter("mostrar_productos", Conexion)
            da.SelectCommand.CommandType = 4

            da.Fill(dt)


            cerrar()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Sub eleminar_Producto(ByVal Id_producto As Integer)


        Dim cmd As New SqlCommand

        Try
            abrir()
            cmd = New SqlCommand("eliminar_producto", Conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@Id", Id_producto)

            cmd.ExecuteNonQuery()


            cerrar()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

    Sub editar_Producto(ByVal Id_producto As Integer, ByVal nombreProducto As String, ByVal precio As Integer, ByVal Stock As Integer, ByVal Departamento As Integer)

        Dim cmd As New SqlCommand

        Try
            abrir()
            cmd = New SqlCommand("editar_producto", Conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@Id", Id_producto)
            cmd.Parameters.AddWithValue("@NombreProducto", nombreProducto)
            cmd.Parameters.AddWithValue("@Precio", precio)
            cmd.Parameters.AddWithValue("@Stock", Stock)
            cmd.Parameters.AddWithValue("@Id_Departamento", Departamento)

            cmd.ExecuteNonQuery()


            cerrar()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Sub insertar_Pedido(ByVal Total As Integer, ByVal Cedula As String, ByVal Cantidad As String, ByRef ejecucion As Boolean)


        Dim cmd As New SqlCommand

        Try
            abrir()

            cmd = New SqlCommand("insertar_pedido", Conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@Total", Total)
            cmd.Parameters.AddWithValue("@Cedula", Cedula)
            cmd.Parameters.AddWithValue("@Direccion", Cantidad)

            cmd.ExecuteNonQuery()
            cerrar()

            ejecucion = True

        Catch ex As Exception
            ejecucion = False
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

    Sub consultar_Pedido(ByVal Id_Pedido As Integer, ByRef dt As DataTable)


        Dim da As SqlDataAdapter

        Try
            abrir()
            da = New SqlDataAdapter("consultar_pedido", Conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@Id_Pedido", Id_Pedido)

            da.Fill(dt)


            cerrar()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Sub mostrar_Pedidos(ByVal Identificacion As String, ByRef dt As DataTable)


        Dim da As SqlDataAdapter

        Try
            abrir()
            da = New SqlDataAdapter("mostrar_pedidos", Conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@Identificacion", Identificacion)

            da.Fill(dt)


            cerrar()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Sub insertar_Venta(ByVal Id_Producto As Integer, ByVal Id_Pedido As Integer, ByVal Precio As Integer, ByVal Cantidad As Integer, ByVal Sub_Total As Integer)

        Dim cmd As New SqlCommand

        Try
            abrir()


            cmd = New SqlCommand("insertar_producto_vendido", Conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@Id_Producto", Id_Producto)
            cmd.Parameters.AddWithValue("@Id_Pedido", Id_Pedido)
            cmd.Parameters.AddWithValue("@Cantidad", Cantidad)
            cmd.Parameters.AddWithValue("@Precio", Precio)
            cmd.Parameters.AddWithValue("@Sub_Total", Sub_Total)

            cmd.ExecuteNonQuery()


            cerrar()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub
    Sub mostrar_Departamentos(ByRef dt As DataSet)

        Dim da As SqlDataAdapter

        Try
            abrir()
            da = New SqlDataAdapter("mostra_Departamento", Conexion)
            da.SelectCommand.CommandType = 4

            da.Fill(dt, "Departamento")


            cerrar()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub crear_Cliente(ByVal identificacion As String, ByVal nombre As String, ByVal apellidos As String, ByVal tipo_cliente As String, ByRef ejecucion As Boolean)

        Dim cmd As New SqlCommand

        Try
            abrir()
            cmd = New SqlCommand("crear_cliente", Conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@Identificacion", identificacion)
            cmd.Parameters.AddWithValue("@Nombre", nombre)
            cmd.Parameters.AddWithValue("@Apellidos", apellidos)
            cmd.Parameters.AddWithValue("@Tipo_Cliente", tipo_cliente)

            cmd.ExecuteNonQuery()


            cerrar()
            ejecucion = True
            MessageBox.Show("El cliente se ha agregado con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            ejecucion = False
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub


    Sub consultar_Cliente(ByVal Identificacion As String, ByRef dt As DataTable)


        Dim da As SqlDataAdapter

        Try
            abrir()
            da = New SqlDataAdapter("consultar_cliente", Conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@Identificacion", Identificacion)

            da.Fill(dt)


            cerrar()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


End Class

Imports System.Data.SqlClient


Public Class Form1

    Dim url = "https://localhost:44365/api/Pedido"
    Dim Id_Producto As Integer
    Dim Id_Cantidad_Producto As Integer
    Dim numeroPedidos As Integer = 0


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostraPanel("Ventas")
        CbxTipoCliente.DropDownStyle = ComboBoxStyle.DropDownList

        DataPedido.AllowUserToAddRows = False
        DataProducto.AllowUserToAddRows = False
        DataHistorialPedidos.AllowUserToAddRows = False

        DataPedido.Columns(0).Width = 60
        DataPedido.Columns(1).Width = 330

        Dim dt As DataTable
        Dim n As Integer






    End Sub

    Private Sub BtnPrincipal_Click(sender As Object, e As EventArgs) Handles BtnPrincipal.Click

        mostraPanel("Ventas")


    End Sub

    Private Sub BtnInventario_Click(sender As Object, e As EventArgs) Handles BtnInventario.Click
        mostraPanel("Inventario")
    End Sub

    Private Sub mostraPanel(ByVal panel As String)

        If panel.Equals("Ventas") Then

            PanelVentas.Visible = True
            PanelInventario.Visible = False
            PanelClientes.Visible = False
            PanelPedidos.Visible = False
            PanelVentas.Dock = DockStyle.Fill
            consultar_Cliente()
            promocion()
            planSepare()

        ElseIf panel.Equals("Inventario") Then

            PanelInventario.Visible = True
            PanelVentas.Visible = False
            PanelClientes.Visible = False
            PanelPedidos.Visible = False
            PanelInventario.Dock = DockStyle.Fill

            mostrar_Boton_Crear_Producto()
            mostrarInventario()
            mostrarDepartamento()

        ElseIf panel.Equals("Clientes") Then

            PanelClientes.Visible = True
            PanelInventario.Visible = False
            PanelVentas.Visible = False
            PanelPedidos.Visible = False
            PanelClientes.Dock = DockStyle.Fill

        ElseIf panel.Equals("Pedidos") Then

            PanelPedidos.Visible = True
            PanelInventario.Visible = False
            PanelVentas.Visible = False
            PanelClientes.Visible = False
            PanelPedidos.Dock = DockStyle.Fill

        End If

    End Sub

    Private Sub mostrarInventario()


        Dim dt As New DataTable

        Dim funcion As New CRUD

        funcion.mostrar_Producto(dt)
        DataInventario.DataSource = dt
        DataInventario.Columns(2).Width = 130
        DataInventario.Columns(1).Width = 740
        DataInventario.Columns(2).Width = 130
        DataInventario.Columns(3).Width = 130

    End Sub
    Sub buscarProducto()
        Dim dt As New DataTable

        Dim funcion As New CRUD

        funcion.buscar_Producto(TxtBuscar.Text, dt)
        DataProducto.DataSource = dt
        DataProducto.Columns(0).Width = 25
        DataProducto.Columns(1).Width = 199


        DataProducto.Columns(2).Visible = False
        DataProducto.Columns(3).Visible = False



    End Sub
    Private Sub crearProducto()
        Dim nombreProducto As String
        Dim Precio As Integer
        Dim Stock As Integer
        Dim Departamento As Integer


        nombreProducto = TxtProducto.Text
        Precio = NumericPrecio.Value
        Stock = NumericStock.Value
        Departamento = CbxDepartamento.SelectedValue

        If Not (String.IsNullOrEmpty(nombreProducto)) Then

            Dim funcion As New CRUD
            funcion.crear_Producto(nombreProducto, Precio, Stock, Departamento)
            mostrarInventario()

        Else
            MessageBox.Show("El campo Nombre puede estar vacio", "Advertencia")

        End If



    End Sub

    Sub editar_Producto()

        Dim nombreProducto As String
        Dim Precio As Integer
        Dim Stock As Integer
        Dim Departamento As Integer


        nombreProducto = TxtProducto.Text
        Precio = NumericPrecio.Value
        Stock = NumericStock.Value
        Departamento = CbxDepartamento.SelectedValue

        If Not (String.IsNullOrEmpty(nombreProducto)) Then

            Dim funcion As New CRUD

            funcion.editar_Producto(Convert.ToInt32(Id_Producto), nombreProducto, Precio, Stock, Departamento)
            mostrarInventario()
        Else
            MessageBox.Show("El campo Nombre puede estar vacio", "Advertencia")

        End If
    End Sub
    Sub eliminar_Producto()

        Dim opcion As DialogResult
        opcion = MessageBox.Show("¿ Esta seguro que desea elimiar este producto ? ", "Eliminar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If opcion = DialogResult.Yes Then

            Label3.Text = Id_Producto
            Dim funcion As New CRUD
            funcion.eleminar_Producto(Id_Producto)
            mostrarInventario()

            TxtProducto.Text = String.Empty
            NumericPrecio.Value = 0
            NumericStock.Value = 0

        End If




    End Sub


    Sub insertar_Pedido_Original()

        'Dim funcion As New CRUD

        'Dim Total As Integer
        'Dim Cedula As String
        'Dim Direccion As String
        'Dim ejecucion As Boolean

        'If Not (String.IsNullOrEmpty(TxtTotal.Text)) Then



        '    If Not (String.IsNullOrEmpty(TxtCedula.Text)) Then


        '        If Not (String.IsNullOrEmpty(TxtDireccion.Text)) Then


        '            Total = Convert.ToInt32(TxtTotal.Text)
        '            Cedula = TxtCedula.Text
        '            Direccion = TxtDireccion.Text
        '            funcion.insertar_Pedido(Total, Cedula, Direccion, ejecucion)

        '            If ejecucion Then
        '                insertar_venta()
        '                limpiar_Pedido()

        '            End If

        '        Else
        '            MessageBox.Show("El campo direccion no puede estar vacio", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        End If



        '    Else

        '        MessageBox.Show("El campo cedula no puede estar vacio", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '    End If

        'Else
        '    MessageBox.Show("No hay ningun producto en el pedido", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If




    End Sub

    Sub limpiar_Pedido()
        DataPedido.Rows.Clear()
        TxtTotal.Text = ""
        TxtCedula.Text = ""
        TxtDireccion.Text = ""
        limpiar_Datos_Producto()

    End Sub

    Sub limpiar_Datos_Producto()

        TxtId.Text = ""
        TxtNombre.Text = ""
        TxtPrecio.Text = ""
        TxtStock.Text = ""

    End Sub

    Sub insertar_venta()

        Dim funcion As New CRUD

        Dim Id_Producto As Integer
        Dim Id_Pedidos As Integer = 2
        Dim Precio As Integer
        Dim Cantidad As Integer
        Dim Sub_total As Integer


        Try

            For Each Fila As DataGridViewRow In DataPedido.Rows


                Id_Producto = Fila.Cells("Codigo").Value
                'Id_Pedidos = Fila.Cells("C").Value
                Precio = Fila.Cells("Valor").Value
                Cantidad = Fila.Cells("Cantidad").Value
                Sub_total = Fila.Cells("Sub_Total").Value
                funcion.insertar_Venta(Id_Producto, Id_Pedidos, Precio, Cantidad, Sub_total)

            Next



        Catch ex As Exception
            MessageBox.Show("error" + ex.ToString())
        End Try




    End Sub

    Private Sub PanelInventario_Paint(sender As Object, e As PaintEventArgs) Handles PanelInventario.Paint

    End Sub

    Private Sub BtnAgregarProducto_Click(sender As Object, e As EventArgs) Handles BtnAgregarProducto.Click
        crearProducto()
    End Sub

    Private Sub mostrarDepartamento()

        Dim dt As New DataSet
        Dim funcion As New CRUD

        funcion.mostrar_Departamentos(dt)

        CbxDepartamento.ValueMember = "Id"
        CbxDepartamento.DisplayMember = "Nombre"
        CbxDepartamento.DataSource = dt.Tables("Departamento")


    End Sub

    Private Sub DataInventario_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataInventario.CellDoubleClick

        Try
            Id_Producto = Convert.ToInt32(DataInventario.SelectedCells.Item(0).Value)

            TxtProducto.Text = DataInventario.SelectedCells.Item(1).Value
            NumericPrecio.Value = DataInventario.SelectedCells.Item(2).Value
            NumericStock.Value = DataInventario.SelectedCells.Item(3).Value
            CbxDepartamento.Text = DataInventario.SelectedCells.Item(4).Value
            mostrar_Botones_Editar_Eliminar_Producto()

        Catch ex As Exception

        End Try

    End Sub


    Sub mostrar_Boton_Crear_Producto()
        BtnAgregarProducto.Visible = True
        BtnEditarProducto.Visible = False
        BtnEliminarProducto.Visible = False
    End Sub

    Sub mostrar_Botones_Editar_Eliminar_Producto()
        BtnAgregarProducto.Visible = False
        BtnEditarProducto.Visible = True
        BtnEliminarProducto.Visible = True
    End Sub

    Private Sub BtnVolver_Click(sender As Object, e As EventArgs) Handles BtnVolver.Click
        TxtProducto.Text = String.Empty
        NumericPrecio.Value = 0
        NumericStock.Value = 0

        mostrar_Boton_Crear_Producto()
    End Sub

    Private Sub BtnEliminarProducto_Click(sender As Object, e As EventArgs) Handles BtnEliminarProducto.Click
        eliminar_Producto()
    End Sub

    Private Sub BtnEditarProducto_Click(sender As Object, e As EventArgs) Handles BtnEditarProducto.Click
        editar_Producto()

    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click

        Dim sub_Total As Integer



        If Not (String.IsNullOrEmpty(TxtNombre.Text)) Or Not (String.IsNullOrEmpty(TxtPrecio.Text)) Then

            If NumeriCantidad.Value > 0 Then

                If TxtStock.Text >= NumeriCantidad.Value Then

                    sub_Total = TxtPrecio.Text * NumeriCantidad.Value
                    Me.DataPedido.Rows.Add(TxtId.Text, TxtNombre.Text, TxtPrecio.Text, NumeriCantidad.Value, sub_Total)
                    TxtStock.Text = TxtStock.Text - NumeriCantidad.Value
                    calcular_Total()
                    promocion()

                Else

                    MessageBox.Show("No hay suficiente producto en el Stock", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If


            Else
                MessageBox.Show("La cantidad debe ser mayor 0", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else
            MessageBox.Show("No se ha seleccionado un producto", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If



    End Sub

    Private Sub TxtBuscar_TextChanged(sender As Object, e As EventArgs) Handles TxtBuscar.TextChanged
        buscarProducto()
    End Sub

    Private Sub DataProducto_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataProducto.CellDoubleClick
        TxtId.Text = DataProducto.SelectedCells.Item(0).Value
        TxtNombre.Text = DataProducto.SelectedCells.Item(1).Value
        TxtPrecio.Text = DataProducto.SelectedCells.Item(2).Value
        TxtStock.Text = DataProducto.SelectedCells.Item(3).Value

        actualizar_Dato_Stock()

        NumeriCantidad.Value = 1

    End Sub

    Sub actualizar_Dato_Stock()

        Try

            For Each Fila As DataGridViewRow In DataPedido.Rows

                If (TxtId.Text = Fila.Cells("Codigo").Value) Then

                    TxtStock.Text = TxtStock.Text - Fila.Cells("Cantidad").Value

                End If



            Next



        Catch ex As Exception
            MessageBox.Show("error" + ex.ToString())
        End Try
    End Sub

    Sub calcular_Total()

        Dim total As Integer

        For Each Columna As DataGridViewColumn In DataPedido.Columns
            If Columna.Name = "Sub_Total" Then


                For Each fila As DataGridViewRow In DataPedido.Rows

                    total += Convert.ToInt32(fila.Cells(4).Value)
                Next

            End If
        Next

        TxtTotal.Text = total

    End Sub

    Private Sub PanelVentas_Paint(sender As Object, e As PaintEventArgs) Handles PanelVentas.Paint


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        insertar_Pedido()


    End Sub
    Sub insertar_Pedido()

        Dim api = New DBApi()

        Dim pedido = New Pedido()


        Try

            If Not (String.IsNullOrEmpty(TxtTotal.Text)) Then



                If Not (String.IsNullOrEmpty(TxtCedula.Text)) Then


                    If Not (String.IsNullOrEmpty(TxtDireccion.Text)) Then


                        If Not (String.IsNullOrEmpty(TxtNombreVenta.Text)) Then
                            pedido.Total = Convert.ToInt32(TxtTotal.Text)
                            pedido.Cedula = TxtCedula.Text
                            pedido.Direccion = TxtDireccion.Text
                            'Dim url = "https://localhost:44365/api/Pedido"

                            Dim headers = New List(Of Parametro)


                            Dim parametros = New List(Of Parametro)

                            Dim response = api.Post(url, headers, parametros, pedido)

                            If response Then
                                MessageBox.Show("El pedido se registro correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                insertar_venta()
                                limpiar_Pedido()



                            End If

                        Else
                            MessageBox.Show("El Cliente no esta Registrado en el sistema, Proceda a registrarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)


                        End If


                    Else
                        MessageBox.Show("El campo direccion no puede estar vacio", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If



                Else

                    MessageBox.Show("El campo cedula no puede estar vacio", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            Else
                MessageBox.Show("No hay ningun producto en el pedido", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try







    End Sub

    Private Sub NumeriCantidad_ValueChanged(sender As Object, e As EventArgs) Handles NumeriCantidad.ValueChanged



        If Not (String.IsNullOrEmpty(TxtStock.Text)) Then


            If Convert.ToInt32(TxtStock.Text) <= NumeriCantidad.Value Then

                NumeriCantidad.Value = Convert.ToInt32(TxtStock.Text)

            End If

        Else

        End If

    End Sub

    Private Sub DataPedido_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataPedido.CellDoubleClick

        'DataPedido.Rows.Remove(r)
        DataPedido.ClearSelection()

    End Sub

    Private Sub TxtIdentificacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtIdentificacion.KeyPress

        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)


    End Sub


    Private Sub BtnCliente_Click_1(sender As Object, e As EventArgs) Handles BtnCliente.Click
        mostraPanel("Clientes")

    End Sub

    Private Sub BtnCrearUsuario_Click(sender As Object, e As EventArgs) Handles BtnCrearUsuario.Click
        insertar_Usuario()
    End Sub

    Sub insertar_Usuario()

        Dim Identificacion As String
        Dim nombre As String
        Dim apellidos As String
        Dim tipo_cliente As String


        Identificacion = TxtIdentificacion.Text
        nombre = TxtNombreCliente.Text
        apellidos = TxtApellidos.Text
        tipo_cliente = CbxTipoCliente.Text

        If Not (String.IsNullOrEmpty(Identificacion)) Then

            If Not (String.IsNullOrEmpty(nombre)) Then

                If Not (String.IsNullOrEmpty(apellidos)) Then

                    If Not (String.IsNullOrEmpty(tipo_cliente)) Then
                        Dim ejecucion As Boolean
                        Dim funcion As New CRUD
                        funcion.crear_Cliente(Identificacion, nombre, apellidos, tipo_cliente, ejecucion)
                        mostrarInventario()
                        If ejecucion Then
                            limpiar_Datos_Usuario()
                        End If



                    Else

                        MessageBox.Show("Seleccione un tipo de cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If




                Else

                    MessageBox.Show("El campo Apellidos no puede estar vacio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If




            Else
                MessageBox.Show("El campo Nombres no puede estar vacio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Else
            MessageBox.Show("El campo Identificacion no puede estar vacio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If


    End Sub

    Sub limpiar_Datos_Usuario()
        TxtIdentificacion.Text = ""
        TxtNombreCliente.Text = ""
        TxtApellidos.Text = ""

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnLimpiarPedido.Click
        limpiar_Pedido()
        promocion()

    End Sub

    Private Sub BtnVentas_Click(sender As Object, e As EventArgs) Handles BtnVentas.Click
        mostraPanel("Pedidos")
        mostrar_Historial_Pedidos()
    End Sub


    Sub consultar_Pedido()


        Dim dt As New DataTable
        Dim funcion As New CRUD

        If Not (String.IsNullOrEmpty(Txt_Id_Pedido.Text)) Then
            funcion.consultar_Pedido(Txt_Id_Pedido.Text, dt)
            DataItemsPedido.DataSource = dt
            DataItemsPedido.Columns(1).Width = 310

        Else
            MessageBox.Show("Recuerde ingresar el numero de pedido que deseas consultar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub

    Private Sub Txt_Id_Pedido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Id_Pedido.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub

    Private Sub BtnMostrarPedidos_Click(sender As Object, e As EventArgs) Handles BtnMostrarPedidos.Click
        mostrar_Historial_Pedidos()
    End Sub

    Sub mostrar_Historial_Pedidos()


        Dim dt As New DataTable
        Dim funcion As New CRUD


        funcion.mostrar_Pedidos(TxtIdentificacionHistorial.Text, dt)
        DataHistorialPedidos.DataSource = dt
        DataHistorialPedidos.Columns(0).Width = 25
        DataHistorialPedidos.Columns(1).Width = 50
        DataHistorialPedidos.Columns(2).Width = 75
        DataHistorialPedidos.Columns(3).Width = 137
        'DataHistorialPedidos.Columns(3).Width = 50


    End Sub

    Private Sub DataHistorialPedidos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataHistorialPedidos.CellDoubleClick

        Txt_Id_Pedido.Text = Convert.ToInt32(DataHistorialPedidos.SelectedCells.Item(0).Value)
        consultar_Pedido()

    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click

        Dim opcion As DialogResult
        opcion = MessageBox.Show("¿ Esta seguro que desea elimiar este pedido ? ", "Eliminar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If opcion = DialogResult.Yes Then

            Dim Id As String
            Dim Api = New DBApi()

            Id = Txt_Id_Pedido.Text


            If Not (String.IsNullOrEmpty(Id)) Then

                'Dim url = "https://localhost:44365/api/Pedido"

                Dim response = Api.Delete(url, Id)

                If response Then

                    mostrar_Historial_Pedidos()

                    Dim dt As New DataTable
                    DataItemsPedido.DataSource = dt
                    Txt_Id_Pedido.Text = ""
                    MessageBox.Show("El pedido se elimino correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)



                End If

            Else
                MessageBox.Show("No hay ningun pedido para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)


            End If



        End If

    End Sub

    Private Sub DataItemsPedido_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataItemsPedido.CellContentClick

    End Sub

    Private Sub TxtCedula_TextChanged(sender As Object, e As EventArgs) Handles TxtCedula.TextChanged

        consultar_Cliente()

    End Sub

    Sub consultar_Cliente()

        Dim dt As New DataTable

        Dim funcion As New CRUD

        Dim Identificacion As String
        Dim Nombre As String
        Dim tipoCliente As String
        Dim N_Pedidos As String

        funcion.consultar_Cliente(TxtCedula.Text, dt)
        DataGridView1.DataSource = dt

        Identificacion = DataGridView1.Rows(0).Cells("Identificacion").Value
        Nombre = DataGridView1.Rows(0).Cells("Nombre Completo").Value
        tipoCliente = DataGridView1.Rows(0).Cells("Tipo_Cliente").Value
        N_Pedidos = DataGridView1.Rows(0).Cells("Nuemero de pedido").Value

        TxtNombreVenta.Text = Nombre
        TxtTipoCliente.Text = tipoCliente

        If Not (String.IsNullOrEmpty(N_Pedidos)) Then
            numeroPedidos = N_Pedidos

            promocion()
        Else
            numeroPedidos = 0

            promocion()

        End If

        planSepare()

    End Sub

    Sub promocion()


        If Not (String.IsNullOrEmpty(TxtTotal.Text)) Then

            If numeroPedidos >= 2 Then
                TxtDescuento.Text = Convert.ToInt32(TxtTotal.Text) * 0.05
            Else
                TxtDescuento.Text = ""
            End If

        End If


    End Sub

    Sub planSepare()


        If TxtTipoCliente.Text.Equals("Exclusivo") Then
            Button1.Text = "Separe"

        Else
            Button1.Text = "Comprar"
        End If

    End Sub

End Class

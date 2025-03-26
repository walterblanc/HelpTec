Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO.File
Imports System.Data.Common
Imports System
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Windows.Forms.Binding
Imports System.Data.OleDb.OleDbDataReader
Imports System.Data.OleDb.OleDbDataAdapter
Imports Microsoft.VisualBasic.FileSystem
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports MetroFramework.Forms
Imports MetroFramework.Interfaces


Public Class Form61
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Dim reser_Cliente As Double = 0
    Dim fila As Integer = 0
    Dim fila_valores As Integer = 0
    Dim indice_pago As Integer

    Public Sub New(ByVal v_Cliente As Double)
        InitializeComponent()
        reser_Cliente = v_Cliente
    End Sub
    Private Sub Form61_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        inicializo_formulario()
        cargo_Cliente()
        cargar_datagrid()
        definir_grilla_comprobantes()

        Dim xSaldo As Double = 0
        Dim xExiste As Byte
        Call existe_cliente_saldos_pendientes(xSaldo, xExiste)

        MetroTextBox15.Text = FormatNumber(xSaldo, 2)

        suma_grilla()

    End Sub
    Private Sub inicializo_formulario()
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""


        MetroTextBox6.Text = "0.00"
        MetroTextBox8.Text = "0.00"
        MetroTextBox9.Text = "0.00"

   
        MetroDateTime1.Value = Now.Date.AddDays(-60)
        MetroDateTime2.Value = Now.Date
        MetroDateTime3.Value = Now.Date

        MetroTextBox18.Text = "0.00"
        MetroTextBox15.Text = "0.00"
      
        MetroPanel2.Visible = False
    
    End Sub
    Private Sub cargo_Cliente()
        Dim r As Integer = 1
        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim Sql As String = ""
            Sql = "Select * from Clientes WHERE (Numero= " & reser_Cliente & ") And (Estado=0) "


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    MetroTextBox1.Text = drRecordSet("Numero").ToString
                    MetroTextBox2.Text = drRecordSet("RazonSocial").ToString

                    MetroDateTime1.Focus()

                End If
            End If

            drRecordSet.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub


    Private Sub cargar_datagrid()
        Dim h As Integer = 0
        Dim Sql As String = ""



        Dim xSaldoDeudor As Double = 0
        Dim xSaldoAcredor As Double = 0


        Call saldo_cuenta_corriente(reser_Cliente, FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate), _
                                    FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate), 2, _
                                     xSaldoDeudor, xSaldoAcredor)

        Dim xSaldo As Double = 0
        Dim xSaldoInicial As Double = 0


        Dim xFecha1 As String = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate)
        Dim xFecha2 As String = FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate)


        xSaldoInicial = xSaldoDeudor - xSaldoAcredor

        xSaldo = xSaldoInicial



        MetroTextBox3.Text = FormatNumber(xSaldoInicial, 2)


        Sql = "Select * from Cuenta_Corriente_Clientes Where (Estado = 0) AND (Cliente=" & reser_Cliente & ") "
        Sql = Sql & "AND (Fecha >= '" & xFecha1 & "') AND (Fecha <= '" & xFecha2 & "')  ORDER BY Fecha"

        With metroGrid1
            .Columns.Clear()
            .Rows.Clear()
            .Refresh()
        End With

        With metroGrid1
            .Rows.Clear()
            .Columns.Add("A", "Fecha")
            .Columns.Add("B", "Tipo")
            .Columns.Add("C", "Letra")
            .Columns.Add("D", "Nro.")
            .Columns.Add("E", "Detalle")
            .Columns.Add("F", "Debe")
            .Columns.Add("G", "Haber")
            .Columns.Add("H", "Saldo")
            .Columns.Add("I", "Saldo Compr.")
            .Columns(0).Width = 80
            .Columns(1).Width = 70
            .Columns(2).Width = 70
            .Columns(3).Width = 90
            .Columns(4).Width = 150
            .Columns(5).Width = 120
            .Columns(6).Width = 120
            .Columns(7).Width = 120
            .Columns(8).Width = 120
            '            .RowCount = 100
        End With

        If ConSql.State = ConnectionState.Closed Then
            ConSql.Open()
        End If

        Dim xCancelado As Double = 0
        Dim xSaldoComprobante As Double = 0



        Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
        Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
        If drRecordSet.HasRows Then 'Tiene filas
            Do While drRecordSet.Read

                xCancelado = 0
                xSaldoComprobante = 0

                If Val(drRecordSet("CodigoMovimiento").ToString) < 4 Then

                    xCancelado = saldo_comprobante(reser_Cliente, Val(drRecordSet("CodigoMovimiento").ToString), drRecordSet("LetraComprobante").ToString, drRecordSet("NumeroComprobante").ToString)
                    xCancelado = Math.Round(xCancelado, 2)
                    xSaldoComprobante = Math.Round(Convert.ToDouble(drRecordSet("Importe").ToString) - xCancelado, 2)

                End If

                With metroGrid1
                    .Rows.Add()
                    .Item(0, h).Value = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)

                    If Val(drRecordSet("CodigoMovimiento").ToString) = 1 Then
                        .Item(1, h).Value = "FA"
                    End If
                    If Val(drRecordSet("CodigoMovimiento").ToString) = 2 Then
                        .Item(1, h).Value = "ND"
                    End If
                    If Val(drRecordSet("CodigoMovimiento").ToString) = 3 Then
                        .Item(1, h).Value = "NC"
                    End If
                    If Val(drRecordSet("CodigoMovimiento").ToString) = 4 Then
                        .Item(1, h).Value = "RE"
                    End If
                    If Val(drRecordSet("CodigoMovimiento").ToString) = 5 Then
                        .Item(1, h).Value = "AD"
                    End If
                    If Val(drRecordSet("CodigoMovimiento").ToString) = 6 Then
                        .Item(1, h).Value = "AA"
                    End If

                    .Item(2, h).Value = drRecordSet("LetraComprobante").ToString
                    .Item(3, h).Value = drRecordSet("NumeroComprobante").ToString
                    .Item(4, h).Value = drRecordSet("Detalle").ToString
                    .Item(5, h).Value = " "
                    .Item(6, h).Value = " "

                    If Val(drRecordSet("DebCre").ToString) = 1 Then
                        xSaldo = xSaldo + Convert.ToDouble(drRecordSet("Importe").ToString)
                        .Item(5, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Importe").ToString), 2)
                        .Item(6, h).Value = " "
                    Else
                        xSaldo = xSaldo - Convert.ToDouble(drRecordSet("Importe").ToString)
                        .Item(5, h).Value = " "
                        .Item(6, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Importe").ToString), 2)
                    End If
                    .Item(7, h).Value = FormatNumber(xSaldo, 2)

                    If Val(drRecordSet("CodigoMovimiento").ToString) < 4 Then
                        .Item(8, h).Value = FormatNumber(xSaldoComprobante, 2)
                    End If

                    h = h + 1
                End With
            Loop
        End If

        drRecordSet.Close()


    End Sub
    Public Function saldo_comprobante(ByVal xCuenta As Double, ByVal xMovim As Byte, ByVal xLetra As String, ByVal xnumero As String) As Double
        Dim xCancelado As Double = 0
        Try
            Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
            Dim ConSql As New OleDbConnection(Conexion)

            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim Sql As String = ""
            Sql = "Select * from Cancelaciones_corriente_clientes Where (Estado = 0) "
            Sql = Sql & "AND (Cliente= " & xCuenta & ") AND (CodigoMovimiento= " & xMovim & ")  And (LetraComprobante='" & xLetra & "') And (NumeroComprobante='" & xnumero & "') "


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                Do While drRecordSet.Read
                    xCancelado = xCancelado + Convert.ToDouble(drRecordSet("Cancelado").ToString)
                Loop
            End If
            drRecordSet.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)

        Finally
            saldo_comprobante = xCancelado
        End Try


    End Function

    Private Sub saldo_cuenta_corriente(ByVal xCuenta As Double, ByVal xFecha1 As String, ByVal xFecha2 As String, ByVal xTipo As Byte, _
                              ByRef xSaldoDeudor As Double, ByRef xSaldoAcredor As Double)

        Dim xImp_Debitos As Double = 0
        Dim xImp_Creditos As Double = 0

        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim InsSql As String = ""

            If xTipo = 0 Then
                InsSql = "Select Sum (importe) as Expr from Cuenta_corriente_clientes Where (Cliente =  " & xCuenta & ") AND (Debcre=1) AND (Estado=0)"
                xImp_Debitos = calculos_sql(InsSql)

                InsSql = "Select Sum (importe) as Expr from Cuenta_corriente_clientes Where (Cliente =  " & xCuenta & ") AND (Debcre=2) AND (Estado=0)"
                xImp_Creditos = calculos_sql(InsSql)
            End If

            If xTipo = 1 Then
                InsSql = "Select Sum (importe) as Expr from Cuenta_corriente_clientes Where (Cliente =  " & xCuenta & ") AND (Debcre=1) AND (Estado=0) AND (Fecha >= '" & xFecha1 & "') AND (Fecha <= '" & xFecha2 & "') "
                xImp_Debitos = calculos_sql(InsSql)

                InsSql = "Select Sum (importe) as Expr from Cuenta_corriente_clientes Where (Cliente =  " & xCuenta & ") AND (Debcre=2) AND (Estado=0) AND (Fecha >= '" & xFecha1 & "') AND (Fecha <= '" & xFecha2 & "') "
                xImp_Creditos = calculos_sql(InsSql)
            End If

            If xTipo = 2 Then
                InsSql = "Select Sum (importe) as Expr from Cuenta_corriente_clientes Where (Cliente =  " & xCuenta & ") AND (Debcre=1) AND (Estado=0) AND (Fecha < '" & xFecha1 & "') "
                xImp_Debitos = calculos_sql(InsSql)

                InsSql = "Select Sum (importe) as Expr from Cuenta_corriente_clientes Where (Cliente =  " & xCuenta & ") AND (Debcre=2) AND (Estado=0) AND (Fecha < '" & xFecha1 & "') "
                xImp_Creditos = calculos_sql(InsSql)
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            xSaldoDeudor = xImp_Debitos
            xSaldoAcredor = xImp_Creditos
        End Try



    End Sub

    Private Function calculos_sql(ByVal Sql As String) As Double
        Dim xImporte As Double = 0
        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim cmdBuscar As New OleDbCommand(Sql, ConSql)
            Dim drBuscar As OleDbDataReader = cmdBuscar.ExecuteReader
            If drBuscar.Read = True Then
                xImporte = Val(drBuscar("Expr").ToString)
            End If
            drBuscar.Close()
            ConSql.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            calculos_sql = xImporte
        End Try

    End Function


    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        cargar_datagrid()
        definir_grilla_comprobantes()
        suma_grilla()
    End Sub

    Private Sub definir_grilla_comprobantes()
        fila = 0
        With MetroGrid2
            .Columns.Clear()
            .Rows.Clear()
            .Refresh()
        End With
        With MetroGrid2
            .Rows.Clear()
            .Columns.Add("A", "Fecha")
            .Columns.Add("B", "Tipo")
            .Columns.Add("C", "Letra")
            .Columns.Add("D", "Nro.")
            .Columns.Add("E", "Detalle")
            .Columns.Add("F", "Importe")
            .Columns.Add("G", "Resto")
            .Columns.Add("H", "a Cancelar")
            .Columns(0).Width = 80
            .Columns(1).Width = 80
            .Columns(2).Width = 82
            .Columns(3).Width = 100
            .Columns(4).Width = 240
            .Columns(5).Width = 120
            .Columns(6).Width = 120
            .Columns(7).Width = 120
            '            .RowCount = 100
        End With

    End Sub
    Private Sub metroTextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox8.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub metroGrid1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles metroGrid1.CellMouseDoubleClick
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        Dim indice As Integer = 0
        indice = e.RowIndex

        Dim aux As Double = 0

        If duplicados_en_grilla(indice) = True Then
            Exit Sub
        End If

        If metroGrid1.Rows(indice).Cells(1).Value <> "FA" And metroGrid1.Rows(indice).Cells(1).Value <> "ND" And metroGrid1.Rows(indice).Cells(1).Value <> "NC" Then
            Exit Sub
        End If

        If metroGrid1.Rows(indice).Cells(8).Value.trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "El Comprobante ya fue Imputado", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If Convert.ToDouble(metroGrid1.Rows(indice).Cells(8).Value.trim) = 0 Then
            MetroFramework.MetroMessageBox.Show(Me, "El Comprobante ya fue Imputado", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        With MetroGrid2
            .Rows.Add()
            .Item(0, fila).Value = metroGrid1.Rows(indice).Cells(0).Value
            .Item(1, fila).Value = metroGrid1.Rows(indice).Cells(1).Value
            .Item(2, fila).Value = metroGrid1.Rows(indice).Cells(2).Value
            .Item(3, fila).Value = metroGrid1.Rows(indice).Cells(3).Value
            .Item(4, fila).Value = metroGrid1.Rows(indice).Cells(4).Value

            If metroGrid1.Rows(indice).Cells(5).Value.ToString.Trim = "" Then
                .Item(5, fila).Value = metroGrid1.Rows(indice).Cells(6).Value

                aux = CDbl(metroGrid1.Rows(indice).Cells(6).Value)

            Else
                .Item(5, fila).Value = metroGrid1.Rows(indice).Cells(5).Value

                aux = CDbl(metroGrid1.Rows(indice).Cells(5).Value)

            End If


            .Item(6, fila).Value = FormatNumber(CDbl(metroGrid1.Rows(indice).Cells(8).Value), 2)
            .Item(7, fila).Value = FormatNumber(CDbl(metroGrid1.Rows(indice).Cells(8).Value), 2)
            fila = fila + 1
        End With

        suma_grilla()

    End Sub
  

    Private Function duplicados_en_grilla(ByVal x As Integer) As Boolean
        Dim r As Boolean = False
        Try
            For Fila_pag As Integer = 0 To MetroGrid2.Rows.Count - 1

                If MetroGrid2.Rows(Fila_pag).Cells(0).Value = metroGrid1.Rows(x).Cells(0).Value And _
                    MetroGrid2.Rows(Fila_pag).Cells(1).Value = metroGrid1.Rows(x).Cells(1).Value And _
                    MetroGrid2.Rows(Fila_pag).Cells(2).Value = metroGrid1.Rows(x).Cells(2).Value And _
                    MetroGrid2.Rows(Fila_pag).Cells(3).Value = metroGrid1.Rows(x).Cells(3).Value Then
                    r = True
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            duplicados_en_grilla = r
        End Try
    End Function

    Private Sub metroGrid2_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles MetroGrid2.CellMouseDoubleClick
        If MetroGrid2.Rows.Count <= 0 Then
            Exit Sub
        End If
        indice_pago = e.RowIndex
        MetroTextBox9.Text = FormatNumber(Convert.ToDouble(MetroGrid2.Rows(e.RowIndex).Cells(7).Value), 2)
        MetroTextBox8.Text = FormatNumber(Convert.ToDouble(MetroGrid2.Rows(e.RowIndex).Cells(7).Value), 2)


        MetroPanel2.Visible = True

    End Sub

    Private Sub MetroButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton4.Click
        If CDbl(MetroTextBox9.Text) < CDbl(MetroTextBox8.Text) Then
            MetroFramework.MetroMessageBox.Show(Me, "Esta imputando por arriba del valor del comprobante", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        MetroGrid2.Rows(indice_pago).Cells(7).Value = MetroTextBox8.Text

        MetroPanel2.Visible = False
        suma_grilla()

    End Sub

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        MetroPanel2.Visible = False
        suma_grilla()
    End Sub
    Private Sub MetroTextBox8_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox8.Validating
        If MetroTextBox8.Text.Trim = "" Then
            MetroTextBox8.Text = "0.00"
        End If
        If MetroTextBox8.Text.Trim <> "" Then
            MetroTextBox8.Text = FormatNumber(CDbl(MetroTextBox8.Text.Trim), 2)
        End If
    End Sub
   
  
    Private Sub suma_grilla()
        Try
            Dim x As Double = 0
            Dim xDif As Double = 0
            Dim xPend As Double = Convert.ToDouble(MetroTextBox15.Text)




            For Fila As Integer = 0 To MetroGrid2.Rows.Count - 1
                If MetroGrid2.Rows(Fila).Cells("b").Value.ToString.Trim <> "NC" Then
                    x = x + Convert.ToDouble(MetroGrid2.Rows(Fila).Cells("h").Value)
                Else
                    x = x - Convert.ToDouble(MetroGrid2.Rows(Fila).Cells("h").Value)
                End If
            Next
            MetroTextBox18.Text = FormatNumber(x, 2)
            xDif = xPend - x
            MetroTextBox6.Text = FormatNumber(xDif, 2)

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub metroGrid2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MetroGrid2.KeyDown
        Dim li_index As Integer

        If e.KeyCode = Keys.Delete Then

            If MetroGrid2.Rows.Count <= 0 Then
                Exit Sub
            End If


            e.Handled = True

            li_index = CType(sender, DataGridView).CurrentRow.Index
            MetroGrid2.Rows.RemoveAt(li_index)
            fila = fila - 1
            suma_grilla()

        End If
    End Sub

   

    Private Sub MetroButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton9.Click
        Try
          

            Dim Aux1 As Double = 0

            Aux1 = Math.Round(CDbl(MetroTextBox6.Text.Trim), 2)
            'If Aux1 = 0 Then
            '    MetroFramework.MetroMessageBox.Show(Me, "Debe especificar Importe de Pago", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Exit Sub
            'End If

            If Aux1 < 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "Ha imputado mas de lo permitido", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            grabar_cancelaciones()
          
            grabar_pendiente_imputacion(Aux1)
   
            refrescar_pantalla()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try
    End Sub

    Private Sub refrescar_pantalla()
        inicializo_formulario()
        cargar_datagrid()
        definir_grilla_comprobantes()
    
        Dim xSaldo As Double = 0
        Dim xExiste As Byte
        Call existe_cliente_saldos_pendientes(xSaldo, xExiste)

        MetroTextBox15.Text = FormatNumber(xSaldo, 2)


    End Sub
  
    Private Sub grabar_cancelaciones()
        Try

            Dim x1 As Double = 0
            Dim x2 As String = ""
            Dim x3 As String = ""

            Dim x4 As String = "S"
            Dim x5 As Byte = 0
            Dim x6 As String = ""
            Dim x7 As String = ""
            Dim x8 As Double = 0
            Dim x9 As Double
            Dim x10 As String = "0000-00000000"
            Dim x11 As Double = Convert.ToDouble(MetroTextBox15.Text.Trim)




            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")

            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If


            For Fila As Integer = 0 To MetroGrid2.Rows.Count - 1

                x1 = reser_Cliente
                x2 = FormatDateTime(MetroDateTime3.Text, DateFormat.ShortDate) '10/01/2009
                x3 = FormatDateTime(MetroGrid2.Rows(Fila).Cells("A").Value.ToString.Trim, DateFormat.ShortDate) '10/01/2009

                If MetroGrid2.Rows(Fila).Cells("B").Value.ToString.Trim = "FA" Then
                    x5 = 1
                End If
                If MetroGrid2.Rows(Fila).Cells("B").Value.ToString.Trim = "ND" Then
                    x5 = 2
                End If
                If MetroGrid2.Rows(Fila).Cells("B").Value.ToString.Trim = "NC" Then
                    x5 = 3
                End If


                x6 = MetroGrid2.Rows(Fila).Cells("C").Value.ToString.Trim
                x7 = MetroGrid2.Rows(Fila).Cells("D").Value.ToString.Trim
                x8 = Convert.ToDouble(MetroGrid2.Rows(Fila).Cells("F").Value)
                x9 = Convert.ToDouble(MetroGrid2.Rows(Fila).Cells("H").Value)
                x10 = Formatea_Numero_Comprobante(0, 0)


                Dim InsSql As String = ""
                InsSql = ""
                InsSql = "Insert into Cancelaciones_corriente_clientes ("
                InsSql = InsSql & "Cliente,Fecha,FechaComprobante,CodigoMovimiento,LetraComprobante,NumeroComprobante,Importe,Cancelado,"
                InsSql = InsSql & "LetraRecibo,NumeroRecibo,SaldoImputado,"
                InsSql = InsSql & "UsuarioAlta,FechaAlta,HoraAlta,Estado) Values ("
                InsSql = InsSql & "" & x1 & ",'" & x2 & "','" & x3 & "'," & x5 & ",'" & x6 & "','" & x7 & "'," & x8 & "," & x9 & ","
                InsSql = InsSql & "'" & x4 & "','" & x10 & "','" & x11 & "',"
                InsSql = InsSql & "" & j1 & ",'" & j2 & "','" & j3 & "',0)"
                Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
                cmdActualizar.ExecuteNonQuery()
                cmdActualizar.Dispose()


            Next

            ConSql.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Function Formatea_Numero_Comprobante(ByVal x1 As Integer, ByVal x2 As Double) As String
        Dim c3 As String

        Dim xNumeroDe4 As String
        Dim xNumeroDe8 As String

        xNumeroDe4 = x1
        xNumeroDe4 = xNumeroDe4.PadLeft(4)
        xNumeroDe4 = xNumeroDe4.Replace(" ", "0")

        xNumeroDe8 = x2
        xNumeroDe8 = xNumeroDe8.PadLeft(8)
        xNumeroDe8 = xNumeroDe8.Replace(" ", "0")

        c3 = xNumeroDe4.ToString & "-" & xNumeroDe8.ToString

        Formatea_Numero_Comprobante = c3
    End Function


   

    Private Sub grabar_pendiente_imputacion(ByVal xImporte As Double)
        Try

            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If
            Dim xSaldo As Double = 0
            Dim xExiste As Byte
            Call existe_cliente_saldos_pendientes(xSaldo, xExiste)

            Dim x1 As Double = reser_Cliente

            Dim InsSql As String = ""

            If xExiste <> 0 Then
                InsSql = "Update Clientes_Saldos_Pendientes_Imputacion SET importe= " & xImporte & " WHERE Numero = " & x1 & " "
            Else
                InsSql = "Insert Into Clientes_Saldos_Pendientes_Imputacion  (Numero,Importe) Values (" & x1 & "," & xImporte & ")"
            End If

            Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            ConSql.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try


    End Sub
    Private Sub existe_cliente_saldos_pendientes(ByRef xSaldo As Double, ByRef xExiste As Byte)

        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            xExiste = 0
            Dim cmdTemp As New OleDbCommand("Select * from Clientes_Saldos_Pendientes_Imputacion where Numero= " & reser_Cliente & " ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    xSaldo = Convert.ToDouble(drTemp("Importe").ToString())
                    xExiste = 1
                End If
            End If
            drTemp.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
        End Try

    End Sub


End Class

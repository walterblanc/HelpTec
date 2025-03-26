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


Public Class Form39
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



    Private Sub Form39_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""

        inicializo_formulario()

        cargo_Cliente()
        cargar_datagrid()
        definir_grilla_comprobantes()
        definir_grilla_valores()

        Dim xSaldo As Double = 0
        Dim xExiste As Byte
        Call existe_cliente_saldos_pendientes(xSaldo, xExiste)

        MetroTextBox15.Text = FormatNumber(xSaldo, 2)


    End Sub
    Private Sub inicializo_formulario()


        MetroTextBox4.Text = "0.00"
        MetroTextBox5.Text = "0.00"
        MetroTextBox6.Text = "0.00"
        MetroTextBox7.Text = "0.00"
        MetroTextBox8.Text = "0.00"
        MetroTextBox9.Text = "0.00"

        cargarCOMBO(MetroComboBox1, 9)

        MetroDateTime1.Value = Now.Date.AddDays(-60)
        MetroDateTime2.Value = Now.Date
        MetroDateTime3.Value = Now.Date


        MetroTextBox11.Text = ""
        MetroTextBox12.Text = ""
        MetroTextBox13.Text = "9999999"

        MetroTextBox13.Text = numeradorAutomatico(1, 2, 1)


        MetroTextBox14.Text = "0.00"
        MetroTextBox17.Text = ""
        MetroTextBox10.Text = "0.00"
        MetroTextBox18.Text = "0.00"
        MetroTextBox15.Text = "0.00"
        MetroTextBox19.Text = "0.00"

        MetroDateTime5.Value = Now.Date
        MetroDateTime4.Value = Now.Date

        MetroTextBox11.Focus()

        MetroPanel2.Visible = False
        MetroPanel1.Visible = False

    End Sub
    Private Sub cargo_Cliente()
        Dim r As Integer = 1
        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If
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
    Private Sub metroTextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox6.KeyPress
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
    Private Sub metroTextBox11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox11.KeyPress
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
    Private Sub metroTextBox17_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox17.KeyPress
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
    Private Sub metroTextBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox10.KeyPress
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


    Private Sub metroTextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox7.KeyPress
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
    Private Sub metroTextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox4.KeyPress
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
    Private Sub metroTextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox5.KeyPress
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
    'Private Sub metroGrid1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles metroGrid1.KeyDown
    '    Dim li_index As Integer

    '    If e.KeyCode = Keys.Delete Then

    '        If MetroGrid2.Rows.Count <= 0 Then
    '            Exit Sub
    '        End If


    '        e.Handled = True

    '        li_index = CType(sender, DataGridView).CurrentRow.Index
    '        MetroGrid2.Rows.RemoveAt(li_index)
    '        fila = fila - 1
    '        suma_grilla()

    '    End If
    'End Sub

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

    Private Sub MetroTextBox4_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox4.Validating
        If MetroTextBox4.Text.Trim = "" Then
            MetroTextBox4.Text = "0.00"
        End If

        If MetroTextBox4.Text.Trim <> "" Then
            MetroTextBox4.Text = FormatNumber(CDbl(MetroTextBox4.Text.Trim), 2)
        End If
        suma_parcial()
    End Sub

    Private Sub MetroTextBox6_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox6.Validating
        If MetroTextBox6.Text.Trim = "" Then
            MetroTextBox6.Text = "0.00"
        End If
        If MetroTextBox6.Text.Trim <> "" Then
            MetroTextBox6.Text = FormatNumber(CDbl(MetroTextBox6.Text.Trim), 2)
        End If
        suma_parcial()
    End Sub
    Private Sub MetroTextBox8_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox8.Validating
        If MetroTextBox8.Text.Trim = "" Then
            MetroTextBox8.Text = "0.00"
        End If
        If MetroTextBox8.Text.Trim <> "" Then
            MetroTextBox8.Text = FormatNumber(CDbl(MetroTextBox8.Text.Trim), 2)
        End If
    End Sub
    Private Sub MetroTextBox5_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox5.Validating
        If MetroTextBox5.Text.Trim = "" Then
            MetroTextBox5.Text = "0.00"
        End If

        If MetroTextBox5.Text.Trim <> "" Then
            MetroTextBox5.Text = FormatNumber(CDbl(MetroTextBox5.Text.Trim), 2)
        End If
        suma_parcial()
    End Sub
    Private Sub MetroTextBox10_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox10.Validating
        If MetroTextBox10.Text.Trim = "" Then
            MetroTextBox10.Text = "0.00"
        End If
        If MetroTextBox10.Text.Trim <> "" Then
            MetroTextBox10.Text = FormatNumber(CDbl(MetroTextBox10.Text.Trim), 2)
        End If
    End Sub
    Private Sub MetroTextBox7_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox7.Validating
        If MetroTextBox7.Text.Trim = "" Then
            MetroTextBox7.Text = "0.00"
        End If
        If MetroTextBox7.Text.Trim <> "" Then
            MetroTextBox7.Text = FormatNumber(CDbl(MetroTextBox7.Text.Trim), 2)
        End If
        suma_parcial()
    End Sub
    Private Sub suma_grilla()
        Try
            Dim x As Double = 0
            For Fila As Integer = 0 To MetroGrid2.Rows.Count - 1
                If MetroGrid2.Rows(Fila).Cells("b").Value.ToString.Trim <> "NC" Then
                    x = x + Convert.ToDouble(MetroGrid2.Rows(Fila).Cells("h").Value)
                Else
                    x = x - Convert.ToDouble(MetroGrid2.Rows(Fila).Cells("h").Value)
                End If
            Next
            MetroTextBox18.Text = FormatNumber(x, 2)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Sub MetroTextBox11_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox11.Validated
        If MetroTextBox11.Text.Trim <> "" Then
            MetroTextBox12.Text = parametroSistema(8, Val(MetroTextBox11.Text.Trim))
        End If
    End Sub
    Private Sub MetroButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton5.Click
        MetroPanel1.Visible = True
    End Sub

    Private Sub definir_grilla_valores()
        With MetroGrid3
            .Columns.Clear()
            .Rows.Clear()
            .Refresh()
        End With
        fila_valores = 0
        With MetroGrid3
            .Rows.Clear()
            .Columns.Add("Id", "Id")
            .Columns.Add("Banco", "Banco")
            .Columns.Add("Detalle", "Detalle")
            .Columns.Add("Numero", "Numero")
            .Columns.Add("Fecha", "Fecha")
            .Columns.Add("Pago", "Pago")
            .Columns.Add("Importe", "Importe")
            .Columns.Add("Obs", "Observación")
            .Columns(0).Width = 80
            .Columns(1).Width = 100
            .Columns(2).Width = 200
            .Columns(3).Width = 140
            .Columns(4).Width = 140
            .Columns(5).Width = 140
            .Columns(6).Width = 140
            .Columns(7).Width = 200
            '            .RowCount = 100
        End With


    End Sub

    Private Sub MetroButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton6.Click
        MetroTextBox11.Text = ""
        MetroTextBox17.Text = ""
        MetroTextBox10.Text = "0.00"
        MetroDateTime1.Value = Now.Date
        MetroDateTime2.Value = Now.Date

        MetroTextBox11.Focus()
    End Sub

    Private Sub MetroButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton7.Click
        If MetroTextBox11.Text = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar entidad bancaria", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If MetroTextBox12.Text = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar entidad bancaria", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If CDbl(MetroTextBox17.Text) = 0 Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar número de cheque", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If CDbl(MetroTextBox10.Text) = 0 Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar importe del cheque", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        Try
            With MetroGrid3
                .Rows.Add()
                .Item(0, fila_valores).Value = fila_valores
                .Item(1, fila_valores).Value = MetroTextBox11.Text
                .Item(2, fila_valores).Value = MetroTextBox12.Text
                .Item(3, fila_valores).Value = MetroTextBox17.Text
                .Item(4, fila_valores).Value = MetroDateTime5.Text
                .Item(5, fila_valores).Value = MetroDateTime4.Text
                .Item(6, fila_valores).Value = MetroTextBox10.Text
                fila_valores = fila_valores + 1
            End With
            suma_grilla_valores()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
    Private Sub suma_grilla_valores()
        Try
            Dim x As Double = 0
            For Fila1 As Integer = 0 To MetroGrid3.Rows.Count - 1
                x = x + Convert.ToDouble(MetroGrid3.Rows(Fila1).Cells("Importe").Value)
            Next
            MetroTextBox19.Text = FormatNumber(x, 2)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub MetroButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton8.Click
        MetroPanel1.Visible = False
        MetroTextBox5.Text = MetroTextBox19.Text
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

    Private Sub metroGrid3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MetroGrid3.KeyDown
        Dim li_index As Integer

        If e.KeyCode = Keys.Delete Then

            If MetroGrid3.Rows.Count <= 0 Then
                Exit Sub
            End If


            e.Handled = True

            li_index = CType(sender, DataGridView).CurrentRow.Index
            MetroGrid3.Rows.RemoveAt(li_index)
            fila_valores = fila_valores - 1
            suma_grilla_valores()

        End If
    End Sub

    Private Sub MetroButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton9.Click
        Try
            Dim v_Actualizar_Pendientes As Boolean = False


            If MetroTextBox14.Text.Trim = "" Then
                MetroTextBox14.Text = "0.00"
            End If

            If MetroTextBox5.Text.Trim = "" Then
                MetroTextBox5.Text = "0.00"
            End If
            If MetroTextBox5.Text.Trim <> "" Then
                MetroTextBox5.Text = FormatNumber(CDbl(MetroTextBox5.Text.Trim), 2)
            End If

            If MetroTextBox19.Text.Trim = "" Then
                MetroTextBox19.Text = "0.00"
            End If
            If MetroTextBox19.Text.Trim <> "" Then
                MetroTextBox19.Text = FormatNumber(CDbl(MetroTextBox19.Text.Trim), 2)
            End If

            If Convert.ToDouble(MetroTextBox14.Text.Trim) = 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "El Recibo no puede debe tener importe", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            If Convert.ToDouble(MetroTextBox5.Text.Trim) <> Convert.ToDouble(MetroTextBox19.Text.Trim) Then
                MetroFramework.MetroMessageBox.Show(Me, "La Suma de los Valores informados no es coincidente", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            If Convert.ToDouble(MetroTextBox18.Text.Trim) > Convert.ToDouble(MetroTextBox14.Text.Trim) Then
                MetroFramework.MetroMessageBox.Show(Me, "Esta Imputando suma de comprobantes mayor que el Recibo. Operación Permitida", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Dim Aux1 As Double = 0

            Aux1 = Math.Round(CDbl(MetroTextBox6.Text.Trim) + CDbl(MetroTextBox5.Text.Trim) + CDbl(MetroTextBox4.Text.Trim) + CDbl(MetroTextBox7.Text.Trim) + CDbl(MetroTextBox15.Text.Trim), 2)
            If Aux1 = 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "Debe especificar Importe de Pago", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            Dim Aux2 As Double = 0
            Dim Aux3 As Double = 0
            Aux2 = Math.Round(CDbl(MetroTextBox18.Text.Trim), 2)

            If Aux1 > Aux2 Then

                Aux3 = Math.Round(Aux1 - Aux2, 2)

                v_Actualizar_Pendientes = True

                Dim ok As Byte = 0
                ok = MetroFramework.MetroMessageBox.Show(Me, "Queda a favor del Cliente Pendiente de Imputación la suma de " & FormatNumber(Aux3, 2), rsv_Modulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information)

                If ok <> 6 Then
                    Exit Sub
                End If

                'Else

                '    If Aux1 < Aux2 Then
                '        If CDbl(MetroTextBox15.Text.Trim) <> 0 Then
                '            Aux3 = 0
                '            v_Actualizar_Pendientes = True
                '        End If
                '    End If

            End If



            MetroTextBox13.Text = numeradorAutomatico(1, 2, 2)

            registro_cuenta_corriente()
            registro_recibo()
            grabar_cancelaciones()

            If Convert.ToDouble(MetroTextBox5.Text.Trim) <> 0 Then
                guardar_valores()
            End If

            If v_Actualizar_Pendientes = True Then
                grabar_pendiente_imputacion(Aux3)
            End If

            Dim Largo As Boolean = False

            Call impresion_recibos(Formatea_Numero_Comprobante(0, CDbl(MetroTextBox13.Text.Trim)), reser_Cliente, Largo)

            If Largo = True Then
                Call impresion_recibos_largo(metroGrid1.CurrentRow.Cells(3).Value.ToString.Trim, reser_Cliente)
            End If

            refrescar_pantalla()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try
    End Sub

    Private Sub refrescar_pantalla()
        inicializo_formulario()
        cargar_datagrid()
        definir_grilla_comprobantes()
        definir_grilla_valores()

        Dim xSaldo As Double = 0
        Dim xExiste As Byte
        Call existe_cliente_saldos_pendientes(xSaldo, xExiste)

        MetroTextBox15.Text = FormatNumber(xSaldo, 2)


    End Sub
    Private Sub guardar_valores()
        Try

            Dim InsSql As String = ""

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


            Dim x1 As String = ""
            x1 = FormatDateTime(MetroDateTime3.Value, DateFormat.ShortDate)
            Dim x2 As String = ""
            x2 = "R"
            Dim x3 As String = ""
            x3 = Formatea_Numero_Comprobante(0, CDbl(MetroTextBox13.Text.Trim))
            Dim x4 As Double = 0
            x4 = reser_Cliente
            Dim x5 As Byte = 0
            x5 = 5


            Dim x6 As Integer = 0
            Dim x7 As String = ""
            Dim x8 As String = ""
            Dim x9 As Double = 0
            Dim x10 As Double = 0
            Dim x11 As String = ""

            For Fila As Integer = 0 To MetroGrid3.Rows.Count - 1
                x6 = Val(MetroGrid3.Rows(Fila).Cells("Banco").Value)
                x7 = FormatDateTime(MetroGrid3.Rows(Fila).Cells("Fecha").Value, DateFormat.ShortDate)
                x8 = FormatDateTime(MetroGrid3.Rows(Fila).Cells("Pago").Value, DateFormat.ShortDate)
                x9 = CDbl(MetroGrid3.Rows(Fila).Cells("Numero").Value)
                x10 = CDbl(MetroGrid3.Rows(Fila).Cells("Importe").Value)
                x11 = MetroGrid3.Rows(Fila).Cells("Detalle").Value

                InsSql = ""
                InsSql = "Insert into Valores_recibidos_ventas ("
                InsSql = InsSql & "Fecha,LetraComprobante,NumeroComprobante,Cliente,TipoComprobante,"
                InsSql = InsSql & "Banco,Emision,Pago,Numero,Importe,Detalle,"
                InsSql = InsSql & "Ua,Ha,Fa,Estado) Values ("
                InsSql = InsSql & "'" & x1 & "','" & x2 & "','" & x3 & "'," & x4 & "," & x5 & ","
                InsSql = InsSql & "" & x6 & ",'" & x7 & "','" & x8 & "'," & x9 & "," & x10 & ",'" & x11 & "',"
                InsSql = InsSql & "" & j1 & ",'" & j3 & "','" & j2 & "',0)"

                Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
                cmdActualizar.ExecuteNonQuery()
                cmdActualizar.Dispose()

            Next

            ConSql.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub grabar_cancelaciones()
        Try

            Dim x1 As Double = 0
            Dim x2 As String = ""
            Dim x3 As String = ""

            Dim x4 As String = "R"
            Dim x5 As Byte = 0
            Dim x6 As String = ""
            Dim x7 As String = ""
            Dim x8 As Double = 0
            Dim x9 As Double
            Dim x10 As String = Formatea_Numero_Comprobante(0, CDbl(MetroTextBox13.Text.Trim))
           



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
                x10 = Formatea_Numero_Comprobante(0, CDbl(MetroTextBox13.Text.Trim))


                    Dim InsSql As String = ""
                    InsSql = ""
                    InsSql = "Insert into Cancelaciones_corriente_clientes ("
                    InsSql = InsSql & "Cliente,Fecha,FechaComprobante,CodigoMovimiento,LetraComprobante,NumeroComprobante,Importe,Cancelado,"
                    InsSql = InsSql & "LetraRecibo,NumeroRecibo,"
                    InsSql = InsSql & "UsuarioAlta,FechaAlta,HoraAlta,Estado) Values ("
                    InsSql = InsSql & "" & x1 & ",'" & x2 & "','" & x3 & "'," & x5 & ",'" & x6 & "','" & x7 & "'," & x8 & "," & x9 & ","
                    InsSql = InsSql & "'" & x4 & "','" & x10 & "',"
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

    Private Sub suma_parcial()

        If MetroTextBox4.Text.Trim = "" Then
            MetroTextBox4.Text = "0.00"
        End If
        If MetroTextBox4.Text.Trim <> "" Then
            MetroTextBox4.Text = FormatNumber(CDbl(MetroTextBox4.Text.Trim), 2)
        End If


        If MetroTextBox5.Text.Trim = "" Then
            MetroTextBox5.Text = "0.00"
        End If
        If MetroTextBox5.Text.Trim <> "" Then
            MetroTextBox5.Text = FormatNumber(CDbl(MetroTextBox5.Text.Trim), 2)
        End If


        If MetroTextBox6.Text.Trim = "" Then
            MetroTextBox6.Text = "0.00"
        End If
        If MetroTextBox6.Text.Trim <> "" Then
            MetroTextBox6.Text = FormatNumber(CDbl(MetroTextBox6.Text.Trim), 2)
        End If

        If MetroTextBox7.Text.Trim = "" Then
            MetroTextBox7.Text = "0.00"
        End If
        If MetroTextBox7.Text.Trim <> "" Then
            MetroTextBox7.Text = FormatNumber(CDbl(MetroTextBox7.Text.Trim), 2)
        End If



        Dim Aux1 As Double = 0
        Aux1 = Math.Round(CDbl(MetroTextBox6.Text.Trim) + CDbl(MetroTextBox5.Text.Trim) + CDbl(MetroTextBox4.Text.Trim) + CDbl(MetroTextBox7.Text.Trim), 2)

        MetroTextBox14.Text = FormatNumber(Aux1, 2)

    End Sub
    Private Sub registro_cuenta_corriente()
        Try

            Dim Aux1 As Double = 0
    
            Aux1 = Math.Round(CDbl(MetroTextBox6.Text.Trim) + CDbl(MetroTextBox5.Text.Trim) + CDbl(MetroTextBox4.Text.Trim) + CDbl(MetroTextBox7.Text.Trim), 2)

            Dim x1 As Double = 0
            Dim x2 As String = ""
            Dim x3 As String = ""
            Dim x4 As Byte = 0
            Dim x5 As Byte = 0
            Dim x6 As String = ""
            Dim x7 As String = ""
            Dim x8 As Double = 0
            Dim x9 As String = ""


            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")

            x1 = reser_Cliente
            x2 = FormatDateTime(MetroDateTime3.Text, DateFormat.ShortDate) '10/01/2009
            x3 = FormatDateTime(MetroDateTime3.Text, DateFormat.ShortDate) '10/01/2009

            x4 = 2
            x5 = 4

            x6 = "R"
            x7 = Formatea_Numero_Comprobante(0, CDbl(MetroTextBox13.Text.Trim))
            x8 = Aux1
            x9 = "Pago según Recibo."



            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If


            Dim InsSql As String = ""
            InsSql = ""
            InsSql = "Insert into Cuenta_Corriente_Clientes ("
            InsSql = InsSql & "Cliente,Fecha,FechaImputado,DebCre,CodigoMovimiento,LetraComprobante,NumeroComprobante,Importe,Detalle,"
            InsSql = InsSql & "UsuarioAlta,FechaAlta,HoraAlta,Estado) Values ("
            InsSql = InsSql & "" & x1 & ",'" & x2 & "','" & x3 & "'," & x4 & "," & x5 & ",'" & x6 & "','" & x7 & "'," & x8 & ",'" & x9 & "',"
            InsSql = InsSql & "" & j1 & ",'" & j2 & "','" & j3 & "',0)"
            Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            ConSql.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
    Private Sub registro_recibo()
        Try


            Dim x1 As String = ""
            Dim x2 As String = ""
            Dim x3 As String = ""
            Dim x4 As Double = 0
            Dim x5 As Double = 0
            Dim x6 As Double = 0
            Dim x7 As Double = 0
            Dim x8 As Integer = 0
            Dim x9 As Double = 0


            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")

            x1 = Formatea_Numero_Comprobante(0, CDbl(MetroTextBox13.Text.Trim))
            x2 = "R"
            x3 = FormatDateTime(MetroDateTime3.Text, DateFormat.ShortDate) '10/01/2009
            x4 = reser_Cliente
            x5 = Convert.ToDouble(MetroTextBox6.Text.Trim)
            x6 = Convert.ToDouble(MetroTextBox5.Text.Trim)
            x7 = Convert.ToDouble(MetroTextBox7.Text.Trim)
            x8 = CType(MetroComboBox1.SelectedItem, ValueDescriptionPair).Value
            x9 = Convert.ToDouble(MetroTextBox4.Text.Trim)


            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If


            Dim InsSql As String = ""
            InsSql = ""
            InsSql = "Insert into Recibos ("
            InsSql = InsSql & "Recibo,Letra,Fecha,Cliente,Efectivo,Cheques,Tarjeta,IdTarjeta,Transferencia,"
            InsSql = InsSql & "Ua,Fa,Ha,Estado) Values ("
            InsSql = InsSql & "'" & x1 & "','" & x2 & "','" & x3 & "'," & x4 & "," & x5 & "," & x6 & "," & x7 & "," & x8 & "," & x9 & ","
            InsSql = InsSql & "" & j1 & ",'" & j2 & "','" & j3 & "',0)"
            Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

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


    Private Sub MetroButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton10.Click
    
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then

            If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim <> "RE" Then
                Exit Sub
            End If

            Dim Largo As Boolean = False

            Call impresion_recibos(metroGrid1.CurrentRow.Cells(3).Value.ToString.Trim, reser_Cliente, Largo)

            If Largo = True Then
                Call impresion_recibos_largo(metroGrid1.CurrentRow.Cells(3).Value.ToString.Trim, reser_Cliente)
            End If

        End If

    End Sub

    Private Sub MetroButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton11.Click

        Dim Formulario_open As New Form33(reser_Cliente, Convert.ToDateTime(FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate)), Convert.ToDateTime(FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate)))
        Formulario_open.ShowDialog()

    End Sub

    
    Private Sub MetroGrid2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MetroGrid2.CellContentClick

    End Sub

    Private Sub metroGrid1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles metroGrid1.CellContentClick

    End Sub

    Private Sub MetroButton12_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton12.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        Dim ok As Byte = 0
        ok = MetroFramework.MetroMessageBox.Show(Me, "Desea eliminar El Recibo de pago. Confirme con seguridad", rsv_Modulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If ok <> 6 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then

            If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim <> "RE" Then
                Exit Sub
            End If

            eliminar_cuenta_corriente()
            eliminar_recibo()
            eliminar_cancelaciones()
            eliminar_valores()

            refrescar_pantalla()

        End If
    End Sub

    Private Sub eliminar_cuenta_corriente()
        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim x1 As Double = 0
            Dim x7 As String = ""

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")

            x1 = reser_Cliente
            x7 = metroGrid1.CurrentRow.Cells(3).Value.ToString.Trim

            Dim InsSql As String = ""

            InsSql = "Update Cuenta_Corriente_Clientes SET Estado=9,UsuarioBaja=" & j1 & ",FechaBaja='" & j2 & "',HoraBaja='" & j3 & "' WHERE Cliente = " & x1 & " AND DebCre=2 AND CodigoMovimiento=4 AND "
            InsSql = InsSql & "LetraComprobante='R' And NumeroComprobante='" & x7 & "' "

            Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            ConSql.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub eliminar_recibo()
        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim x1 As Double = 0
            Dim x7 As String = ""

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")

            x1 = reser_Cliente
            x7 = metroGrid1.CurrentRow.Cells(3).Value.ToString.Trim

            Dim InsSql As String = ""

            InsSql = "Update Recibos SET Estado=9,Ub=" & j1 & ",Fb='" & j2 & "',Hb='" & j3 & "' WHERE Cliente = " & x1 & " AND "
            InsSql = InsSql & "Letra='R' And Recibo='" & x7 & "' "

            Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            ConSql.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
    Private Sub eliminar_cancelaciones()
        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim x1 As Double = 0
            Dim x7 As String = ""

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")

            x1 = reser_Cliente
            x7 = metroGrid1.CurrentRow.Cells(3).Value.ToString.Trim

            Dim InsSql As String = ""

            InsSql = "Update Cancelaciones_corriente_clientes SET Estado=9,UsuarioBaja=" & j1 & ",FechaBaja='" & j2 & "',HoraBaja='" & j3 & "' WHERE Cliente = " & x1 & " AND "
            InsSql = InsSql & "LetraRecibo='R' And NumeroRecibo='" & x7 & "' "

            Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            ConSql.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub eliminar_valores()
        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim x1 As Double = 0
            Dim x7 As String = ""

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")

            x1 = reser_Cliente
            x7 = metroGrid1.CurrentRow.Cells(3).Value.ToString.Trim

            Dim InsSql As String = ""

            InsSql = "Update Valores_recibidos_ventas SET Estado=9,Ub=" & j1 & ",Fb='" & j2 & "',Hb='" & j3 & "' WHERE Cliente = " & x1 & " AND "
            InsSql = InsSql & "LetraComprobante='R' And NumeroComprobante='" & x7 & "' "

            Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            ConSql.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

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
                InsSql = "Update Clientes_Saldos_Pendientes_Imputacion SET importe=" & xImporte & " WHERE Numero = " & x1 & " "
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

    
    Private Sub MetroButton13_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton13.Click
        Dim Formulario_open As New Form61(reser_Cliente)
        Formulario_open.ShowDialog()
        Me.Close()
    End Sub
End Class

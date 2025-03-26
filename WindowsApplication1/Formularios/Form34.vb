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


Public Class Form34
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Dim h As Integer = 0
    Dim indice As Integer = 0
    Dim reser_Cliente As Double = 0

    Public Sub New(ByVal v_Cliente As Double)
        InitializeComponent()
        reser_Cliente = v_Cliente
    End Sub

    Private Sub Form34_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        inicializa_form()
        inicializo_grilla()
    End Sub
    Private Sub inicializa_form()

        MetroTextBox8.Text = ""
        MetroTextBox18.Text = "0.00"
        MetroTextBox1.Text = "0.00"
        MetroTextBox2.Text = "0.00"
        MetroTextBox3.Text = "0.00"
        MetroTextBox4.Text = "0.00"
        MetroTextBox5.Text = "0.00"
        MetroTextBox6.Text = ""
        MetroDateTime4.Value = Now.Date.AddDays(-60)
        MetroDateTime3.Value = Now.Date.AddDays(180)
        MetroDateTime1.Value = Now.Date
        MetroPanel2.Visible = False
    End Sub

    Private Sub inicializo_grilla()
        Try

            With MetroGrid2
                .Columns.Clear()
                .Rows.Clear()
                .Refresh()
            End With

            With MetroGrid2
                .Rows.Clear()
                .Columns.Add("Id", "Id")
                .Columns.Add("Fecha", "Fecha")
                .Columns.Add("Tipo", "Tipo")
                .Columns.Add("Letra", "Letra")
                .Columns.Add("Numero", "Numero")
                .Columns.Add("Importe", "Importe")
                .Columns.Add("Cancelado", "Cancelado")
                .Columns.Add("Resto", "Resto")
                .Columns.Add("Final", "A Cancelar")

                .Columns(0).Width = 80
                .Columns(1).Width = 90
                .Columns(2).Width = 70
                .Columns(3).Width = 70
                .Columns(4).Width = 120
                .Columns(5).Width = 120
                .Columns(6).Width = 120
                .Columns(7).Width = 120
                .Columns(8).Width = 120
                h = 0
                '            .RowCount = 100
            End With



            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim xFecha1 As String = FormatDateTime(MetroDateTime4.Text, DateFormat.ShortDate)
            Dim xFecha2 As String = FormatDateTime(MetroDateTime3.Text, DateFormat.ShortDate)


            Dim Sql As String = ""
            Sql = "Select * from Cuenta_corriente_clientes Where (Estado = 0) And (Cliente=" & reser_Cliente & ")  "
            Sql = Sql & "AND (Fecha >= '" & xFecha1 & "') AND (Fecha <= '" & xFecha2 & "')  And (CodigoMovimiento<=3) Order By Fecha "



            Dim xCancelado As Double = 0
            Dim xResto As Double = 0
            Dim xACancelar As Double = 0
            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                Do While drRecordSet.Read
                    xCancelado = saldo_comprobante(reser_Cliente, Val(drRecordSet("CodigoMovimiento").ToString), drRecordSet("LetraComprobante").ToString, drRecordSet("NumeroComprobante").ToString)
                    xCancelado = Math.Round(xCancelado, 2)
                    xResto = Math.Round(Convert.ToDouble(drRecordSet("Importe").ToString) - xCancelado, 2)
                    xACancelar = xResto

                    With MetroGrid2
                        .Rows.Add()
                        .Item(0, h).Value = drRecordSet("Secuencia").ToString
                        .Item(1, h).Value = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)

                        If Val(drRecordSet("CodigoMovimiento").ToString) = 1 Then
                            .Item(2, h).Value = "FA"
                        End If
                        If Val(drRecordSet("CodigoMovimiento").ToString) = 2 Then
                            .Item(2, h).Value = "ND"
                        End If
                        If Val(drRecordSet("CodigoMovimiento").ToString) = 3 Then
                            .Item(2, h).Value = "NC"
                        End If

                        .Item(3, h).Value = drRecordSet("LetraComprobante").ToString
                        .Item(4, h).Value = drRecordSet("NumeroComprobante").ToString
                        .Item(5, h).Value = FormatNumber(drRecordSet("Importe").ToString, 2)

                        .Item(6, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Importe").ToString), 2)
                        .Item(7, h).Value = FormatNumber(xCancelado, 2)

                        .Item(7, h).Value = FormatNumber(xResto, 2)
                        .Item(7, h).Value = FormatNumber(xACancelar, 2)
                       
                        h = h + 1
                    End With

                Loop
            End If
            drRecordSet.Close()
            ConSql.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
        End Try

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
    Private Sub metroTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox1.KeyPress
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
    Private Sub metroTextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox3.KeyPress
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

    Private Sub metroTextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox2.KeyPress
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
    Private Sub metroTextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox8.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
     
    End Sub

    Private Sub metroGrid2_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles MetroGrid2.CellMouseDoubleClick
        If MetroGrid2.Rows.Count <= 0 Then
            Exit Sub
        End If
        indice = e.RowIndex
        MetroTextBox4.Text = MetroGrid2.Rows(e.RowIndex).Cells(7).Value
        MetroTextBox5.Text = MetroGrid2.Rows(e.RowIndex).Cells(8).Value

        MetroPanel1.Enabled = False
        MetroPanel2.Visible = True

    End Sub

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        MetroPanel1.Enabled = True
        MetroPanel2.Visible = False
    End Sub

    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click

        If CDbl(MetroTextBox4.Text) < CDbl(MetroTextBox5.Text) Then
            MetroFramework.MetroMessageBox.Show(Me, "Esta imputando por arriba del valor del comprobante", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        MetroGrid2.Rows(indice).Cells(8).Value = MetroTextBox5.Text
        suma_grilla()
        MetroPanel1.Enabled = True
        MetroPanel2.Visible = False
    End Sub
    Private Sub suma_grilla()
        Try
            Dim x As Double = 0
            For Fila As Integer = 0 To MetroGrid2.Rows.Count - 1
                x = x + Convert.ToDouble(MetroGrid2.Rows(Fila).Cells("Final").Value)
            Next
            MetroTextBox18.Text = FormatNumber(x, 2)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConSql.Close()
        End Try
    End Sub
   

    Private Sub MetroTextBox5_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox5.Validated
        If MetroTextBox5.Text.Trim = "" Then
            MetroTextBox5.Text = "0.0"
        End If
        If MetroTextBox5.Text.Trim = "." Then
            MetroTextBox5.Text = "0.0"
        End If
        MetroTextBox5.Text = FormatNumber(CDbl(MetroTextBox5.Text.Trim), 2)

    End Sub
    Private Sub MetroTextBox1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox1.Validated
        If MetroTextBox1.Text.Trim = "" Then
            MetroTextBox1.Text = "0.0"
        End If
        If MetroTextBox1.Text.Trim = "." Then
            MetroTextBox1.Text = "0.0"
        End If
        MetroTextBox1.Text = FormatNumber(CDbl(MetroTextBox1.Text.Trim), 2)

    End Sub
   
    Private Sub MetroTextBox2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox2.Validated
        If MetroTextBox2.Text.Trim = "" Then
            MetroTextBox2.Text = "0.0"
        End If
        If MetroTextBox2.Text.Trim = "." Then
            MetroTextBox2.Text = "0.0"
        End If
        MetroTextBox2.Text = FormatNumber(CDbl(MetroTextBox2.Text.Trim), 2)

    End Sub
    Private Sub MetroTextBox3_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox3.Validated
        If MetroTextBox3.Text.Trim = "" Then
            MetroTextBox3.Text = "0.0"
        End If
        If MetroTextBox3.Text.Trim = "." Then
            MetroTextBox3.Text = "0.0"
        End If
        MetroTextBox3.Text = FormatNumber(CDbl(MetroTextBox3.Text.Trim), 2)

    End Sub
    Private Sub MetroGrid2_GridColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroGrid2.GridColorChanged
        suma_grilla()
    End Sub

    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        inicializo_grilla()
    End Sub

    

    Private Sub MetroButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton5.Click
        Me.Close()
    End Sub

    Private Sub MetroButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton4.Click
        Try
            If MetroTextBox1.Text.Trim = "" Then
                MetroTextBox1.Text = "0.0"
            End If
            If MetroTextBox1.Text.Trim = "." Then
                MetroTextBox1.Text = "0.0"
            End If
            If MetroTextBox2.Text.Trim = "" Then
                MetroTextBox2.Text = "0.0"
            End If
            If MetroTextBox2.Text.Trim = "." Then
                MetroTextBox2.Text = "0.0"
            End If
            If MetroTextBox3.Text.Trim = "" Then
                MetroTextBox3.Text = "0.0"
            End If
            If MetroTextBox3.Text.Trim = "." Then
                MetroTextBox3.Text = "0.0"
            End If

            Dim Aux1 As Double = 0
            Dim Aux2 As Double = 0

            Aux1 = Math.Round(CDbl(MetroTextBox18.Text.Trim), 2)
            Aux2 = Math.Round(CDbl(MetroTextBox1.Text.Trim) + CDbl(MetroTextBox2.Text.Trim) + CDbl(MetroTextBox3.Text.Trim), 2)

            If CDbl(Aux1) <> CDbl(Aux2) Then
                MetroFramework.MetroMessageBox.Show(Me, "El total de lo imputado no coincide con la suma de los pagos", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If MetroTextBox6.Text.Trim = "" Then
                MetroFramework.MetroMessageBox.Show(Me, "Debe especificar Número Recibo", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If CDbl(MetroTextBox6.Text.Trim) = 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "Debe especificar Número Recibo", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            grabar_cancelaciones()
            registro_cuenta_corriente()

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
            Dim x10 As String = Formatea_Numero_Comprobante(0, CDbl(MetroTextBox6.Text.Trim))
            Dim x11 As Double = 0
            Dim x12 As Double = 0
            Dim x13 As Double = 0


            x11 = Convert.ToDouble(MetroTextBox1.Text.Trim)
            x12 = Convert.ToDouble(MetroTextBox2.Text.Trim)
            x13 = Convert.ToDouble(MetroTextBox3.Text.Trim)

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

            Dim xPago As Double = 0
            For Fila As Integer = 0 To MetroGrid2.Rows.Count - 1
                xPago = Convert.ToDouble(MetroGrid2.Rows(Fila).Cells("Final").Value)
                If xPago <> 0 Then

                    x1 = reser_Cliente
                    x2 = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate) '10/01/2009
                    x3 = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate) '10/01/2009

                    If MetroGrid2.Rows(Fila).Cells("Tipo").Value.ToString.Trim = "FA" Then
                        x5 = 1
                    End If
                    If MetroGrid2.Rows(Fila).Cells("Tipo").Value.ToString.Trim = "ND" Then
                        x5 = 2
                    End If
                    If MetroGrid2.Rows(Fila).Cells("Tipo").Value.ToString.Trim = "NC" Then
                        x5 = 3
                    End If


                    x6 = MetroGrid2.Rows(Fila).Cells("Letra").Value.ToString.Trim
                    x7 = MetroGrid2.Rows(Fila).Cells("Numero").Value.ToString.Trim
                    x8 = Convert.ToDouble(MetroGrid2.Rows(Fila).Cells("Importe").Value)
                    x9 = Convert.ToDouble(MetroGrid2.Rows(Fila).Cells("Final").Value)


                    Dim InsSql As String = ""
                    InsSql = ""
                    InsSql = "Insert into Cancelaciones_corriente_clientes ("
                    InsSql = InsSql & "Cliente,Fecha,FechaImputacion,CodigoMovimiento,LetraComprobante,NumeroComprobante,Importe,Cancelado,"
                    InsSql = InsSql & "LetraRecibo,NumeroRecibo,Efectivo,Valores,Transferencia,"
                    InsSql = InsSql & "UsuarioAlta,FechaAlta,HoraAlta,Estado) Values ("
                    InsSql = InsSql & "" & x1 & ",'" & x2 & "','" & x3 & "'," & x5 & ",'" & x6 & "','" & x7 & "'," & x8 & "," & x9 & ","
                    InsSql = InsSql & "'" & x4 & "','" & x10 & "'," & x11 & "," & x12 & "," & x13 & ","
                    InsSql = InsSql & "" & j1 & ",'" & j2 & "','" & j3 & "',0)"
                    Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
                    cmdActualizar.ExecuteNonQuery()
                    cmdActualizar.Dispose()

                End If
            Next

            ConSql.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Sub registro_cuenta_corriente()
        Try

            Dim Aux1 As Double = 0
            Dim Aux2 As Double = 0

            Aux1 = Math.Round(CDbl(MetroTextBox18.Text.Trim), 2)
            Aux2 = Math.Round(CDbl(MetroTextBox1.Text.Trim) + CDbl(MetroTextBox2.Text.Trim) + CDbl(MetroTextBox3.Text.Trim), 2)

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
            x2 = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate) '10/01/2009
            x3 = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate) '10/01/2009

            x4 = 2
            x5 = 4

            x6 = "R"
            x7 = Formatea_Numero_Comprobante(0, CDbl(MetroTextBox6.Text.Trim))
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

            Me.Close()

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

    Private Sub MetroGrid2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MetroGrid2.CellContentClick

    End Sub
End Class

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


Public Class Form46
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Dim reser_Cuenta As String = ""
    Public Sub New(ByVal v_Cuenta As String)
        InitializeComponent()
        reser_Cuenta = v_Cuenta
    End Sub



    Private Sub Form46_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargo_CuentaBancaria()
        cargar_datagrid()
        MetroDateTime1.Value = Now.Date.AddDays(-10)
        MetroDateTime2.Value = Now.Date.AddDays(10)
        MetroDateTime3.Value = Now.Date


        '        MetroTextBox8.Text = ""
        '        cargar_datagrid()
        '        MetroTextBox8.Focus()
    End Sub

    Private Sub cargo_CuentaBancaria()
        Dim r As Integer = 1
        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim Sql As String = ""
            Sql = "Select * from Cuentas_Bancarias WHERE (Numero= '" & reser_Cuenta & "') And (Estado=0) "


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    MetroTextBox1.Text = drRecordSet("Numero").ToString
                    MetroTextBox2.Text = drRecordSet("Detalle").ToString
                    MetroTextBox3.Text = drRecordSet("Banco").ToString
                End If
            End If

            MetroTextBox10.Text = ""
            If MetroTextBox3.Text.Trim <> "" Then
                MetroTextBox10.Text = parametroSistema(8, Val(MetroTextBox3.Text.Trim))
            End If
            drRecordSet.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
    Private Sub cargar_datagrid()
        Dim h As Integer = 0

        Dim xDetalle As String = ""
        Dim xDebcre As Integer = 0



        Dim f1 As String = ""
        f1 = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate)
        Dim f2 As String = ""
        f2 = FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate)

        Dim Acum As Double = 0
        Dim exis As Boolean = False

        Dim Sql As String = ""
        Sql = "Select * From Movimientos_Bancarios WHERE (FECHAVALOR BETWEEN '" & f1 & "' AND '" & f2 & "') AND (Estado = 0) and (Numero = '" & reser_Cuenta & "' ) Order by FechaValor"
        With metroGrid1
            .Columns.Clear()
            .Rows.Clear()
            .Refresh()
        End With

        With metroGrid1
            .Rows.Clear()
            .Columns.Add("Numero", "Numero")
            .Columns.Add("Fecha", "Fecha")
            .Columns.Add("FechaValor", "Fec.Imput.")
            .Columns.Add("Comprobante", "Comprobante")
            .Columns.Add("Detalle", "Detalle")
            .Columns.Add("Codigo", "Tipo")
            .Columns.Add("Importe", "Importe")
            .Columns.Add("Conciliado", "Conciliado")
            .Columns.Add("Id", "Id")

            .Columns(0).Width = 100
            .Columns(1).Width = 100
            .Columns(2).Width = 100
            .Columns(3).Width = 100
            .Columns(4).Width = 260
            .Columns(5).Width = 200
            .Columns(6).Width = 120
            .Columns(7).Width = 120
            .Columns(8).Width = 0

            '            .RowCount = 100
        End With

        If ConSql.State = ConnectionState.Open Then
            ConSql.Close()
        End If
        ConSql.Open()

        Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
        Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
        If drRecordSet.HasRows Then 'Tiene filas
            Do While drRecordSet.Read
                xDetalle = ""
                xDebcre = 0
                Call Codigo_Bancario(Val(drRecordSet("Codigo").ToString), xDetalle, xDebcre)
                With metroGrid1
                    .Rows.Add()
                    .Item(0, h).Value = drRecordSet("Numero").ToString
                    .Item(1, h).Value = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)
                    .Item(2, h).Value = FormatDateTime(drRecordSet("FechaValor").ToString, DateFormat.ShortDate)
                    .Item(3, h).Value = drRecordSet("Comprobante").ToString
                    .Item(4, h).Value = drRecordSet("Detalle").ToString
                    .Item(5, h).Value = xDetalle
                    .Item(6, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Importe").ToString), 2)
                    If Val(drRecordSet("Conciliado").ToString) = 1 Then
                        .Item(7, h).Value = "Conciliado"
                    Else
                        .Item(7, h).Value = " "
                    End If
                    .Item(8, h).Value = drRecordSet("Id").ToString

                    h = h + 1
                End With
            Loop
        End If

        drRecordSet.Close()


    End Sub

    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        cargar_datagrid()
    End Sub
    'Private Sub MetroLink1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink1.Click
    '    Dim Formulario_open As New Form13(0, 1)
    '    Formulario_open.ShowDialog()
    '    cargar_datagrid()
    'End Sub


    'Private Sub metroGrid1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles metroGrid1.CellMouseDoubleClick
    '    Dim numero As Double = 0
    '    If metroGrid1.Rows.Count <= 0 Then
    '        Exit Sub
    '    End If
    '    numero = metroGrid1.Rows(e.RowIndex).Cells(0).Value
    '    If rsv_Io = 0 Then
    '        Dim Formulario_open As New Form13(numero, 2)
    '        Formulario_open.ShowDialog()
    '        cargar_datagrid()
    '    End If
    '    If rsv_Io = 1 Then
    '        rsv_Seleccion = numero
    '        Me.Close()
    '    End If


    'End Sub

    'Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
    '    If metroGrid1.Rows.Count <= 0 Then
    '        Exit Sub
    '    End If

    '    If (metroGrid1.CurrentRow IsNot Nothing) Then
    '        Dim x As String = metroGrid1.CurrentRow.Cells(0).Value
    '        cambio_estado(x)
    '        cargar_datagrid()
    '    End If

    'End Sub

    'Private Sub cambio_estado(ByVal x As String)
    '    Try

    '        Dim j1 As Integer
    '        Dim j2 As String
    '        Dim j3 As String

    '        j1 = rsv_Usuario

    '        Dim fechaHoy As String
    '        fechaHoy = Today.ToString
    '        j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
    '        j3 = TimeOfDay.ToString("hh:mm:ss")



    '        Dim Sql As String = ""

    '        Sql = "Update Cuentas_Bancarias SET Estado=9,"
    '        Sql = Sql & "FechaBaja='" & j2 & "',HoraBaja='" & j3 & "',UsuarioBaja=" & j1 & " WHERE Numero= '" & x & "' "

    '        If ConSql.State = ConnectionState.Open Then
    '            ConSql.Close()
    '        End If
    '        ConSql.Open()
    '        Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
    '        cmdActualizar.ExecuteNonQuery()
    '        cmdActualizar.Dispose()

    '        cargar_datagrid()


    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        ConSql.Close()
    '    End Try

    'End Sub


    'Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
    '    cargar_datagrid()
    'End Sub

    'Private Sub MetroTextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox8.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        e.Handled = True
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub


    ''Private Sub MetroLink2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink2.Click
    ''    If metroGrid1.Rows.Count <= 0 Then
    ''        Exit Sub
    ''    End If

    ''    If (metroGrid1.CurrentRow IsNot Nothing) Then
    ''        Dim x As Double = metroGrid1.CurrentRow.Cells(0).Value
    ''        Dim Formulario_open As New Form32(x)
    ''        Formulario_open.ShowDialog()

    ''    End If
    ''End Sub

    ''Private Sub MetroLink3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink3.Click
    ''    If metroGrid1.Rows.Count <= 0 Then
    ''        Exit Sub
    ''    End If

    ''    If (metroGrid1.CurrentRow IsNot Nothing) Then
    ''        Dim x As Double = metroGrid1.CurrentRow.Cells(0).Value
    ''        '            Dim Formulario_open As New Form36(x)
    ''        Dim Formulario_open As New Form39(x)
    ''        Formulario_open.ShowDialog()

    ''    End If
    ''End Sub



    'Private Sub ModificarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarToolStripMenuItem.Click
    '    If metroGrid1.Rows.Count <= 0 Then
    '        Exit Sub
    '    End If

    '    If (metroGrid1.CurrentRow IsNot Nothing) Then
    '        Dim numero As String = metroGrid1.CurrentRow.Cells(0).Value
    '        Dim Formulario_open As New Form45(numero, 2)
    '        Formulario_open.ShowDialog()

    '        cargar_datagrid()

    '    End If
    'End Sub

    'Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
    '    Dim Formulario_open As New Form45(" ", 1)
    '    Formulario_open.ShowDialog()
    '    cargar_datagrid()
    'End Sub

    
    Private Sub MetroLink1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink1.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim numero As Double = Val(metroGrid1.CurrentRow.Cells(8).Value)
            Call conciliar_registro(numero, 1)
            cargar_datagrid()
        End If
    End Sub

    Private Sub MetroLink2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink2.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim numero As Double = Val(metroGrid1.CurrentRow.Cells(8).Value)
            Call conciliar_registro(numero, 0)
            cargar_datagrid()
        End If
    End Sub
    Private Sub conciliar_registro(ByVal numero As Double, ByVal tipo As Byte)
        Try
            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")

            Dim f1 As String = ""
            f1 = FormatDateTime(MetroDateTime3.Text, DateFormat.ShortDate)



            Dim InsSql As String = ""
            InsSql = "Update Movimientos_Bancarios Set Conciliado=" & tipo & ","
            InsSql = InsSql & "FechaConciliado='" & f1 & "',HoraConciliado='" & j3 & "',UsuarioConcilio=" & j1 & " WHERE Id = " & numero & ""
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub MetroLink3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink3.Click
        Dim Formulario_open As New Form47(reser_Cuenta, 0)
        Formulario_open.ShowDialog()
        cargar_datagrid()
    End Sub

    Private Sub MetroLink4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink4.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim numero As Double = Val(metroGrid1.CurrentRow.Cells(8).Value)
            Dim Formulario_open As New Form47(reser_Cuenta, numero)
            Formulario_open.ShowDialog()

            cargar_datagrid()

        End If
    End Sub
    Private Sub eliminar_registro(ByVal numero As Double)
        Try
            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")




            Dim InsSql As String = ""
            InsSql = "Update Movimientos_Bancarios Set Estado=9,"
            InsSql = InsSql & "FechaBaja='" & j2 & "',HoraBaja='" & j3 & "',UsuarioBaja=" & j1 & " WHERE Id = " & numero & ""
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub MetroLink5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink5.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim numero As Double = Val(metroGrid1.CurrentRow.Cells(8).Value)
            Call eliminar_registro(numero)
            cargar_datagrid()
        End If
    End Sub

    Private Sub MetroLink6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink6.Click
        Dim Formulario_open As New Form50(reser_Cuenta, 0)
        Formulario_open.ShowDialog()
    End Sub
End Class

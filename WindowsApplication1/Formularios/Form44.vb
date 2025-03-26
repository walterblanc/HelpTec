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


Public Class Form44
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)
    Dim P As Boolean = True
    Private Sub Form44_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MetroTextBox8.Text = ""
        cargar_datagrid()
        MetroTextBox8.Focus()
    End Sub
    Private Sub cargar_datagrid()
        Dim h As Integer = 0
        Dim Sql As String = ""

        If MetroTextBox8.Text.Trim = "" Then
            Sql = "Select TOP(30) * From Cuentas_Bancarias WHERE (Estado = 0) Order by Detalle"
        End If
        If MetroTextBox8.Text.Trim <> "" Then
            Dim f As String = ""
            f = MetroTextBox8.Text.Trim
            Sql = "Select * From Cuentas_Bancarias WHERE (Estado = 0) and (Detalle like '%" & f & "%' ) Order by Detalle"
        End If
        If P = True Then
            Sql = "Select TOP(30) *  From Cuentas_Bancarias WHERE (Estado = 0) Order by Detalle"
            P = False
        End If
        With metroGrid1
            .Columns.Clear()
            .Rows.Clear()
            .Refresh()
        End With

        With metroGrid1
            .Rows.Clear()
            .Columns.Add("Numero", "Numero")
            .Columns.Add("Detalle", "RazonSocial")
            .Columns.Add("Banco", "Banco")
            .Columns.Add("Cdu", "Cbu")
            .Columns.Add("Cuit", "Cuit")
            .Columns(0).Width = 80
            .Columns(1).Width = 300
            .Columns(2).Width = 260
            .Columns(3).Width = 200
            .Columns(4).Width = 100
          
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
                With metroGrid1
                    .Rows.Add()
                    .Item(0, h).Value = drRecordSet("Numero").ToString
                    .Item(1, h).Value = drRecordSet("Detalle").ToString
                    .Item(2, h).Value = parametroSistema(8, Val(drRecordSet("Banco").ToString))
                    .Item(3, h).Value = drRecordSet("Cbu").ToString
                    .Item(4, h).Value = drRecordSet("Cuit").ToString
              
                    h = h + 1
                End With
            Loop
        End If

        drRecordSet.Close()


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

    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim x As String = metroGrid1.CurrentRow.Cells(0).Value
            cambio_estado(x)
            cargar_datagrid()
        End If

    End Sub

    Private Sub cambio_estado(ByVal x As String)
        Try

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")



            Dim Sql As String = ""

            Sql = "Update Cuentas_Bancarias SET Estado=9,"
            Sql = Sql & "FechaBaja='" & j2 & "',HoraBaja='" & j3 & "',UsuarioBaja=" & j1 & " WHERE Numero= '" & x & "' "

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            cargar_datagrid()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConSql.Close()
        End Try

    End Sub


    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        cargar_datagrid()
    End Sub

    Private Sub MetroTextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox8.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    'Private Sub MetroLink2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink2.Click
    '    If metroGrid1.Rows.Count <= 0 Then
    '        Exit Sub
    '    End If

    '    If (metroGrid1.CurrentRow IsNot Nothing) Then
    '        Dim x As Double = metroGrid1.CurrentRow.Cells(0).Value
    '        Dim Formulario_open As New Form32(x)
    '        Formulario_open.ShowDialog()

    '    End If
    'End Sub

    'Private Sub MetroLink3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink3.Click
    '    If metroGrid1.Rows.Count <= 0 Then
    '        Exit Sub
    '    End If

    '    If (metroGrid1.CurrentRow IsNot Nothing) Then
    '        Dim x As Double = metroGrid1.CurrentRow.Cells(0).Value
    '        '            Dim Formulario_open As New Form36(x)
    '        Dim Formulario_open As New Form39(x)
    '        Formulario_open.ShowDialog()

    '    End If
    'End Sub



    Private Sub ModificarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarToolStripMenuItem.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim numero As String = metroGrid1.CurrentRow.Cells(0).Value
            Dim Formulario_open As New Form45b(numero, 2)
            Formulario_open.ShowDialog()

            cargar_datagrid()

        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim Formulario_open As New Form45b(" ", 1)
        Formulario_open.ShowDialog()
        cargar_datagrid()
    End Sub

    Private Sub MetroLink1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink1.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim numero As String = metroGrid1.CurrentRow.Cells(0).Value
            Dim Formulario_open As New Form46(numero)
            Formulario_open.ShowDialog()

            cargar_datagrid()

        End If
    End Sub
End Class

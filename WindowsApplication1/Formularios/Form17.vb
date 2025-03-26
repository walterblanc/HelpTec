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


Public Class Form17
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)
    Private Sub Form17_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MetroTextBox8.Text = ""
        cargar_datagrid(1)
        MetroTextBox8.Focus()
    End Sub
    Private Sub cargar_datagrid(ByVal x As Byte)
        Dim h As Integer = 0
        Dim Sql As String = ""


        If MetroTextBox8.Text.Trim = "" Then
            Sql = "Select TOP 50 * From Articulos WHERE (Estado = 0) Order by Detalle"
        End If

        If x = 1 Then
            If MetroTextBox8.Text.Trim <> "" Then
                Dim f As String = ""
                f = MetroTextBox8.Text.Trim
                Sql = "Select * From Articulos WHERE (Estado = 0) and (Detalle like '%" & f & "%' ) Order by Detalle"
            End If
        End If

        If x = 2 Then
            If MetroTextBox8.Text.Trim <> "" Then
                Dim f As String = ""
                f = MetroTextBox8.Text.Trim
                Sql = "Select * From Articulos WHERE (Estado = 0) and (Codigo like '%" & f & "%' ) Order by Codigo"
            End If
        End If

        With metroGrid1
            .Columns.Clear()
            .Rows.Clear()
            .Refresh()
        End With

        With metroGrid1
            .Rows.Clear()
            .Columns.Add("Codigo", "Codigo")
            .Columns.Add("CodigoProveedor", "Cod. Prov.")
            .Columns.Add("Detalle", "Detalle")
            .Columns.Add("Estanteria", "Estanteria")
            .Columns.Add("Sector", "Sector")
            .Columns.Add("Existencia", "Existencia")
            .Columns.Add("ExistenciaMinima", "Exist.Min.")
            .Columns.Add("Precio", "Precio")
            .Columns.Add("UltimoPrecio", "Fecha")
            .Columns(0).Width = 100
            .Columns(1).Width = 80
            .Columns(2).Width = 300
            .Columns(3).Width = 90
            .Columns(4).Width = 90
            .Columns(5).Width = 90
            .Columns(6).Width = 90
            .Columns(7).Width = 90
            .Columns(8).Width = 90
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
                    .Item(0, h).Value = drRecordSet("Codigo").ToString
                    .Item(1, h).Value = drRecordSet("CodigoProveedor").ToString
                    .Item(2, h).Value = drRecordSet("Detalle").ToString
                    .Item(3, h).Value = drRecordSet("Estanteria").ToString
                    .Item(4, h).Value = drRecordSet("Sector").ToString
                    .Item(5, h).Value = FormatNumber(drRecordSet("Existencia").ToString, 2)
                    .Item(6, h).Value = FormatNumber(drRecordSet("ExisMini").ToString, 2)
                    .Item(7, h).Value = FormatNumber(drRecordSet("Precio1").ToString, 2)
                    .Item(8, h).Value = FormatDateTime(drRecordSet("UltimoPrecio").ToString, DateFormat.ShortDate)
                    h = h + 1
                End With
            Loop
        End If

        drRecordSet.Close()


    End Sub

    Private Sub MetroLink1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink1.Click
        Dim Formulario_open As New Form15(" ", 1)
        Formulario_open.ShowDialog()
        cargar_datagrid(1)
    End Sub

    Private Sub metroGrid1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles metroGrid1.CellEnter

    End Sub
    Private Sub metroGrid1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles metroGrid1.CellMouseDoubleClick
        Dim numero As String
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If e.RowIndex = -1 Then
            Exit Sub
        End If


        numero = metroGrid1.Rows(e.RowIndex).Cells(0).Value
        If rsv_Io = 0 Then
            Dim Formulario_open As New Form10(numero, 2)
            Formulario_open.ShowDialog()
            cargar_datagrid(1)
        End If
        If rsv_Io = 1 Then
            rsv_Seleccion = numero
            Me.Close()
        End If


    End Sub

    Private Sub ModificarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarToolStripMenuItem.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim numero As String = metroGrid1.CurrentRow.Cells(0).Value
            Dim Formulario_open As New Form15(numero, 2)
            Formulario_open.ShowDialog()

            cargar_datagrid(1)

        End If

    End Sub

    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim x As String = metroGrid1.CurrentRow.Cells(0).Value
            cambio_estado(x)
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

            Sql = "Update Articulos SET Estado=9,"
            Sql = Sql & "Afm='" & j2 & "',Ahm='" & j3 & "',Aum=" & j1 & " WHERE Codigo= '" & x & "' "

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            cargar_datagrid(1)


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConSql.Close()
        End Try

    End Sub


    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        cargar_datagrid(1)
    End Sub



    Private Sub MetroTextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox8.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub ModificarPreciosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarPreciosToolStripMenuItem.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim numero As String = metroGrid1.CurrentRow.Cells(0).Value
            Dim Formulario_open As New Form18(numero, 1)
            Formulario_open.ShowDialog()

            cargar_datagrid(1)

        End If
    End Sub

    Private Sub ModificarExistenciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarExistenciaToolStripMenuItem.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim numero As String = metroGrid1.CurrentRow.Cells(0).Value
            Dim Formulario_open As New Form18(numero, 2)
            Formulario_open.ShowDialog()

            cargar_datagrid(1)

        End If

    End Sub


    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        cargar_datagrid(2)
    End Sub

    Private Sub MetroTextBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTextBox8.Click

    End Sub

    Private Sub metroGrid1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles metroGrid1.CellContentClick

    End Sub

    Private Sub MetroLink2_Click(sender As Object, e As EventArgs) Handles MetroLink2.Click
        My.Computer.Clipboard.Clear()
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim x1 As String = metroGrid1.CurrentRow.Cells(0).Value
            Dim x2 As String = metroGrid1.CurrentRow.Cells(2).Value
            Dim x3 As String = metroGrid1.CurrentRow.Cells(7).Value

            My.Computer.Clipboard.SetText(x1 & " " & x2 & " $ " & x3)

        End If
    End Sub
End Class

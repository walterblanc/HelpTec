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


Public Class Form12
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)
    Dim P As Boolean = True
    Private Sub Form12_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MetroRadioButton1.Checked = True
        MetroTextBox8.Text = ""
        cargar_datagrid()
        MetroTextBox8.Focus()
    End Sub
    Private Sub cargar_datagrid()
        Dim h As Integer = 0
        Dim Sql As String = ""

        If MetroTextBox8.Text.Trim = "" Then
            Sql = "Select TOP(30) * From Clientes WHERE (Estado = 0) Order by RazonSocial"
        End If
        If MetroTextBox8.Text.Trim <> "" Then
            Dim f As String = ""
            f = MetroTextBox8.Text.Trim
            If MetroRadioButton1.Checked = True Then
                Sql = "Select * From Clientes WHERE (Estado = 0) and (RazonSocial like '%" & f & "%' ) Order by RazonSocial"
            End If
            If MetroRadioButton2.Checked = True Then
                Sql = "Select * From Clientes WHERE (Estado = 0) and (Comercial like '%" & f & "%' ) Order by Comercial"
            End If

        End If
        If P = True Then
            Sql = "Select TOP(30) *  From Clientes WHERE (Estado = 0) Order by RazonSocial"
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
            .Columns.Add("Comercial", "Comercial")
            .Columns.Add("Domicilio", "Domicilio")
            .Columns.Add("Ciudad", "Ciudad")
            .Columns.Add("Telefono", "Telefono")
            .Columns.Add("TipoResp", "Tipo Resp.")
            .Columns(0).Width = 80
            .Columns(1).Width = 200
            .Columns(2).Width = 200
            .Columns(3).Width = 200
            .Columns(4).Width = 200
            .Columns(5).Width = 120
            .Columns(6).Width = 120
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
                    .Item(1, h).Value = drRecordSet("RazonSocial").ToString
                    .Item(2, h).Value = drRecordSet("Comercial").ToString
                    .Item(3, h).Value = drRecordSet("Domicilio").ToString
                    .Item(4, h).Value = drRecordSet("Ciudad").ToString
                    .Item(5, h).Value = drRecordSet("Telefono").ToString
                    .Item(6, h).Value = parametroSistema(2, Val(drRecordSet("Responsable").ToString))
                    h = h + 1
                End With
            Loop
        End If

        drRecordSet.Close()


    End Sub

    Private Sub MetroLink1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink1.Click
        Dim Formulario_open As New Form13(0, 1)
        Formulario_open.ShowDialog()
        cargar_datagrid()
    End Sub

   
    Private Sub metroGrid1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles metroGrid1.CellMouseDoubleClick
        Dim numero As Double = 0
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If
        numero = metroGrid1.Rows(e.RowIndex).Cells(0).Value
        If rsv_Io = 0 Then
            Dim Formulario_open As New Form13(numero, 2)
            Formulario_open.ShowDialog()
            cargar_datagrid()
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
            Dim numero As Double = metroGrid1.CurrentRow.Cells(0).Value
            Dim Formulario_open As New Form13(numero, 2)
            Formulario_open.ShowDialog()

            cargar_datagrid()

        End If

    End Sub

    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim x As Double = metroGrid1.CurrentRow.Cells(0).Value
            cambio_estado(x)
            cargar_datagrid()
        End If

    End Sub

    Private Sub cambio_estado(ByVal x As Double)
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

            Sql = "Update Clientes SET Estado=9,"
            Sql = Sql & "Afm='" & j2 & "',Ahm='" & j3 & "',Aum=" & j1 & " WHERE Numero= " & x & " "

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

    Private Sub MetroTextBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTextBox8.Click

    End Sub

    Private Sub MetroTextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox8.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub metroGrid1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles metroGrid1.CellContentClick

    End Sub

    Private Sub MetroLink2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink2.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim x As Double = metroGrid1.CurrentRow.Cells(0).Value
            Dim Formulario_open As New Form32(x)
            Formulario_open.ShowDialog()

        End If
    End Sub

    Private Sub MetroLink3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink3.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim x As Double = metroGrid1.CurrentRow.Cells(0).Value
            '            Dim Formulario_open As New Form36(x)
            Dim Formulario_open As New Form39(x)
            Formulario_open.ShowDialog()

        End If
    End Sub

  
   
End Class

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


Public Class Form27
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)
    Private Sub Form27_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MetroTextBox8.Text = ""
        cargar_datagrid()
        MetroTextBox8.Focus()
    End Sub
    Private Sub cargar_datagrid()
        Dim h As Integer = 0
        Dim Sql As String = ""

        If MetroTextBox8.Text.Trim = "" Then
            Sql = "Select * From Presupuestos WHERE (Orden=1) Order by PresupuestoNro DESC"
        End If
        If MetroTextBox8.Text.Trim <> "" Then
            Dim f As String = ""
            f = MetroTextBox8.Text.Trim
            Sql = "Select * From Presupuestos WHERE (Orden=1) And (RazonSocial like '%" & f & "%' ) Order by PresupuestoNro DESC"
        End If

        With metroGrid1
            .Columns.Clear()
            .Rows.Clear()
            .Refresh()
        End With

        With metroGrid1
            .Rows.Clear()
            .Columns.Add("Fecha", "Fecha")
            .Columns.Add("PresupuestoNro", "Número")
            .Columns.Add("Nombre", "Nombre")
            .Columns.Add("Documento", "Documento")
            .Columns.Add("Cuit", "Cuit")
            .Columns.Add("Detalle", "Detalle")
            .Columns.Add("Importe", "Importe")
            .Columns.Add("Ticket", "Ticket")
            .Columns(0).Width = 80
            .Columns(1).Width = 80
            .Columns(2).Width = 200
            .Columns(3).Width = 80
            .Columns(4).Width = 80
            .Columns(5).Width = 200
            .Columns(6).Width = 110
            .Columns(7).Width = 110
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
                    .Item(0, h).Value = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)
                    .Item(1, h).Value = drRecordSet("PresupuestoNro").ToString
                    .Item(2, h).Value = drRecordSet("Nombre").ToString
                    If Val(drRecordSet("Documento").ToString) = 0 Then
                        .Item(3, h).Value = " "
                    Else
                        .Item(3, h).Value = drRecordSet("Documento").ToString
                    End If

                    If Val(drRecordSet("Cuit").ToString) = 0 Then
                        .Item(4, h).Value = " "
                    Else
                        .Item(4, h).Value = drRecordSet("Cuit").ToString
                    End If

                    .Item(5, h).Value = drRecordSet("Detalle").ToString
                    .Item(6, h).Value = FormatNumber(drRecordSet("TotalOperacion").ToString, 2)
                    .Item(7, h).Value = drRecordSet("TicketNro").ToString
                  
                    h = h + 1
                End With
            Loop
        End If

        drRecordSet.Close()


    End Sub

    Private Sub MetroLink1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink1.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim x As Double = metroGrid1.CurrentRow.Cells(1).Value
            Call impresion_presupuesto(x)
        End If
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
End Class

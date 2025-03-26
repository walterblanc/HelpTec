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


Public Class Form58
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Private Sub Form58_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        inicializo_formulario()
        cargar_datagrid()
    End Sub
    Private Sub inicializo_formulario()
        MetroDateTime1.Value = Now.Date.AddDays(-60)
        MetroDateTime2.Value = Now.Date
        MetroTextBox2.Text = ""
    End Sub

    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub
    Private Sub metroTextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub cargar_datagrid()
        Dim h As Integer = 0
        Dim Sql As String = ""

        Dim xFecha1 As String = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate)
        Dim xFecha2 As String = FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate)

        If MetroTextBox2.Text.Trim = "" Then
            Sql = "Select * from Iva_ventas Where (Estado = 0)  "
            Sql = Sql & "AND (Fecha >= '" & xFecha1 & "') AND (Fecha <= '" & xFecha2 & "')  ORDER BY Fecha"
        Else
            Dim x As String = MetroTextBox2.Text.Trim
            Sql = "Select * from Iva_ventas Where (Estado = 0)  And Nombre like '%" & x & "%' "
            Sql = Sql & "AND (Fecha >= '" & xFecha1 & "') AND (Fecha <= '" & xFecha2 & "')  ORDER BY Fecha"
        End If

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
            .Columns.Add("E", "Cliente")
            .Columns.Add("F", "Razon Social")
            .Columns.Add("G", "Neto")
            .Columns.Add("H", "Iva 2.5")
            .Columns.Add("I", "Iva 10.5")
            .Columns.Add("J", "Iva 21")
            .Columns.Add("K", "Iva 27")
            .Columns.Add("L", "Total")
            .Columns(0).Width = 70
            .Columns(1).Width = 50
            .Columns(2).Width = 50
            .Columns(3).Width = 90
            .Columns(4).Width = 150
            .Columns(5).Width = 100
            .Columns(6).Width = 100
            .Columns(7).Width = 100
            .Columns(8).Width = 100
            .Columns(9).Width = 100
            .Columns(10).Width = 100
            .Columns(11).Width = 100
            '            .RowCount = 100
        End With

        If ConSql.State = ConnectionState.Closed Then
            ConSql.Open()
        End If

        Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
        Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
        If drRecordSet.HasRows Then 'Tiene filas
            Do While drRecordSet.Read
                With metroGrid1
                    .Rows.Add()

                    .Item(0, h).Value = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)
                    .Item(1, h).Value = drRecordSet("TipoComprobante").ToString
                    .Item(2, h).Value = drRecordSet("LetraComprobante").ToString
                    .Item(3, h).Value = drRecordSet("NumeroComprobante").ToString
                    .Item(4, h).Value = drRecordSet("Cliente").ToString
                    .Item(5, h).Value = drRecordSet("Nombre").ToString
                    .Item(6, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("NetoGravado").ToString), 2)
                    .Item(7, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Iva25").ToString), 2)
                    .Item(8, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Iva105").ToString), 2)
                    .Item(9, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Iva21").ToString), 2)
                    .Item(10, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Iva27").ToString), 2)
                    .Item(11, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Total").ToString), 2)

                    h = h + 1
                End With
            Loop
        End If

        drRecordSet.Close()


    End Sub

    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        cargar_datagrid()
    End Sub


    Private Sub MetroButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton9.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then

            Dim Tipo As String = ""
            Dim Letra As String = ""
            Dim Nro As String = ""
            Dim Prov As Double = 0
            Dim Fec As String = ""
            Dim Imp As Double = 0
            Dim TipRedef As Byte = 0


            Fec = metroGrid1.CurrentRow.Cells(0).Value.ToString.Trim
            Tipo = metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim

            If Tipo.Trim.ToUpper = "FA" Then
                TipRedef = 1
            End If
            If Tipo.Trim.ToUpper = "ND" Then
                TipRedef = 2
            End If
            If Tipo.Trim.ToUpper = "NC" Then
                TipRedef = 3
            End If


            Letra = metroGrid1.CurrentRow.Cells(2).Value.ToString.Trim
            Nro = metroGrid1.CurrentRow.Cells(3).Value.ToString.Trim
            Prov = Convert.ToDouble(metroGrid1.CurrentRow.Cells(4).Value.ToString.Trim)
            Imp = Convert.ToDouble(metroGrid1.CurrentRow.Cells(11).Value.ToString.Trim)


            Dim Formulario_open As New Form59(TipRedef, Letra, Nro)
            Formulario_open.ShowDialog()

        End If


    End Sub
End Class

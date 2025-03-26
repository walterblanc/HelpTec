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


Public Class Form21
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)
    Private Sub Form21_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MetroTextBox8.Text = ""
        MetroDateTime1.Value = Now.Date
        MetroDateTime2.Value = Now.Date
        Call cargar_datagrid(0)
        MetroTextBox8.Focus()
    End Sub
    Private Sub cargar_datagrid(ByVal x As Byte)
        Dim h As Integer = 0
        Dim Sql As String = ""

        Dim xFecha1 As String = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate)
        Dim xFecha2 As String = FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate)


        If MetroTextBox8.Text.Trim = "" Then
            Sql = "Select * From Tickets WHERE (Orden=1) And (Fecha Between '" & xFecha1 & "' AND '" & xFecha2 & "')  Order by TicketNro DESC"
        End If

        If MetroTextBox8.Text.Trim <> "" Then
            Dim f As String = ""
            f = MetroTextBox8.Text.Trim

            If x = 1 Then
                Sql = "Select * From Tickets WHERE (Orden=1) And (Nombre like '%" & f & "%' ) And (Fecha Between '" & xFecha1 & "' AND '" & xFecha2 & "') Order by TicketNro DESC"
            End If

            If x = 2 Then
                Sql = "Select * From Tickets WHERE (Orden=1) And (ClienteNombre like '%" & f & "%' ) And (Fecha Between '" & xFecha1 & "' AND '" & xFecha2 & "') Order by TicketNro DESC"
            End If

        End If

        With metroGrid1
            .Columns.Clear()
            .Rows.Clear()
            .Refresh()
        End With

        With metroGrid1
            .Rows.Clear()
            .Columns.Add("Fecha", "Fecha")
            .Columns.Add("Hora", "Hora")
            .Columns.Add("TicketNro", "Ticket Nro.")
            .Columns.Add("Nombre", "Nombre")
            .Columns.Add("Documento", "Documento")
            .Columns.Add("Cliente", "Cliente")
            .Columns.Add("Cuit", "Cuit")
            .Columns.Add("Detalle", "Detalle")
            .Columns.Add("Importe", "Importe")
            .Columns.Add("Facturado", "Est.Emit.")
            .Columns.Add("Estado", "Estado")
            .Columns.Add("Comprobantes", "Comprobantes")
            .Columns(0).Width = 70
            .Columns(1).Width = 70
            .Columns(2).Width = 80
            .Columns(3).Width = 130
            .Columns(4).Width = 80
            .Columns(5).Width = 150
            .Columns(6).Width = 80
            .Columns(7).Width = 150
            .Columns(8).Width = 110
            .Columns(9).Width = 90
            .Columns(10).Width = 90
            .Columns(11).Width = 110
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
                    .Item(1, h).Value = drRecordSet("Ha").ToString
                    .Item(2, h).Value = drRecordSet("TicketNro").ToString
                    .Item(3, h).Value = " "
                    If drRecordSet("Nombre").ToString.Trim <> "" Then
                        .Item(3, h).Value = drRecordSet("Nombre").ToString.ToUpper
                    End If

                    If Val(drRecordSet("Documento").ToString) = 0 Then
                        .Item(4, h).Value = " "
                    Else
                        .Item(4, h).Value = drRecordSet("Documento").ToString
                    End If

                    If drRecordSet("ClienteNombre").ToString.Trim = "" Then
                        .Item(5, h).Value = " "
                    Else
                        .Item(5, h).Value = drRecordSet("ClienteNombre").ToString.ToUpper
                    End If

                    If Val(drRecordSet("Cuit").ToString) = 0 Then
                        .Item(6, h).Value = " "
                    Else
                        .Item(6, h).Value = drRecordSet("Cuit").ToString
                    End If

                    .Item(7, h).Value = drRecordSet("Detalle").ToString
                    .Item(8, h).Value = FormatNumber(drRecordSet("ImpConDstoGenerAplic").ToString, 2)

                    If Val(drRecordSet("Facturado").ToString) = 0 Then
                        .Item(9, h).Value = " "
                    Else
                        .Item(9, h).Value = "Facturado"
                    End If

                    If Val(drRecordSet("Estado").ToString) = 0 Then
                        .Item(10, h).Value = " "
                    End If
                    If Val(drRecordSet("Estado").ToString) = 8 Then
                        .Item(10, h).Value = "Modificado"
                    End If
                    If Val(drRecordSet("Estado").ToString) = 9 Then
                        .Item(10, h).Value = "Eliminado"
                    End If

                    .Item(11, h).Value = ""
                    If Val(drRecordSet("Facturado").ToString) = 1 Then
                        .Item(11, h).Value = comprobantes_relaciones(Convert.ToDouble(drRecordSet("TicketNro").ToString))
                    End If


                    h = h + 1
                End With
            Loop
        End If

        drRecordSet.Close()


    End Sub

    Private Sub MetroLink1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink1.Click
        Dim Formulario_open As New Form19(0, 0)
        Formulario_open.ShowDialog()
        Call cargar_datagrid(0)
    End Sub
   

    Private Sub ModificarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarToolStripMenuItem.Click
       If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim x As Double = metroGrid1.CurrentRow.Cells(2).Value
            Dim Formulario_open As New Form19(x, 1)
            Formulario_open.ShowDialog()
            Call cargar_datagrid(0)
        End If


    End Sub

    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim x As Double = metroGrid1.CurrentRow.Cells(2).Value
            cambio_estado(x)
            Call cargar_datagrid(0)
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

            Sql = "Update Tickets SET Estado=9,"
            Sql = Sql & "Fb='" & j2 & "',Hb='" & j3 & "',Ub=" & j1 & " WHERE TicketNro= " & x & " "

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            Call cargar_datagrid(0)


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConSql.Close()
        End Try

    End Sub
    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        Call cargar_datagrid(1)
    End Sub
    Private Sub MetroTextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox8.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Private Sub metroGrid1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles metroGrid1.CellMouseDoubleClick
        Dim numero As Double = 0
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If
        numero = metroGrid1.Rows(e.RowIndex).Cells(2).Value

        Dim Formulario_open As New Form25(numero, 1)
        Formulario_open.ShowDialog()
        Call cargar_datagrid(0)
    End Sub
  
    Private Sub FacturarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturarToolStripMenuItem.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim x As Double = metroGrid1.CurrentRow.Cells(2).Value
            Dim Formulario_open As New Form25(x, 1)
            Formulario_open.ShowDialog()
            Call cargar_datagrid(0)
        End If

    End Sub

   
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim x As Double = metroGrid1.CurrentRow.Cells(2).Value
            Dim Formulario_open As New Form26(x, 3)
            Formulario_open.ShowDialog()
            Call cargar_datagrid(0)
        End If

    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim x As Double = metroGrid1.CurrentRow.Cells(2).Value
            Dim Formulario_open As New Form26(x, 4)
            Formulario_open.ShowDialog()
            Call cargar_datagrid(0)
        End If

    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim x As Double = metroGrid1.CurrentRow.Cells(2).Value
            Dim Formulario_open As New Form25(x, 3)
            Formulario_open.ShowDialog()
            Call cargar_datagrid(0)
        End If
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim x As Double = metroGrid1.CurrentRow.Cells(2).Value
            Dim Formulario_open As New Form25(x, 2)
            Formulario_open.ShowDialog()
            Call cargar_datagrid(0)
        End If
    End Sub

    Private Sub MetroLink2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink2.Click
        Call cargar_datagrid(0)
    End Sub

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        Call cargar_datagrid(2)
    End Sub

    Private Function comprobantes_relaciones(ByVal xTicket As Double) As String
        Dim r As String = ""
        Try

            Dim Sql As String = ""
            Sql = "Select * from Ventas_Resumen WHERE (TicketNro= " & xTicket & ") AND (Estado=0)"


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                Do While drRecordSet.Read
                    r = r + drRecordSet("LetraComprobante").ToString & " " & drRecordSet("NumeroComprobante").ToString & "-"
                Loop
            End If

            drRecordSet.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConSql.Close()
        Finally
            comprobantes_relaciones = r
        End Try

    End Function

    Private Sub CuponDeDevoluciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuponDeDevoluciónToolStripMenuItem.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim x As Double = metroGrid1.CurrentRow.Cells(2).Value
            Call impresion_cupon_devolucion(x, 3)
        End If
    End Sub


End Class

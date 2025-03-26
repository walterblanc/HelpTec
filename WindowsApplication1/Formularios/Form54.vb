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


Public Class Form54
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

   
 


    Private Sub Form54_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        inicializo_formulario()
        cargar_datagrid()
    End Sub
    Private Sub inicializo_formulario()
        MetroDateTime1.Value = Now.Date.AddDays(-60)
        MetroDateTime2.Value = Now.Date
    End Sub


    
    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub


    Private Sub cargar_datagrid()
        Dim h As Integer = 0
        Dim Sql As String = ""

        Dim xFecha1 As String = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate)
        Dim xFecha2 As String = FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate)

        Sql = "Select * from Iva_Compras Where (Estado = 0)  "
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
            .Columns.Add("E", "Proveedor")
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
                    .Item(1, h).Value = drRecordSet("TipoDeComprobante").ToString
                    .Item(2, h).Value = drRecordSet("Letra").ToString
                    .Item(3, h).Value = drRecordSet("NumeroDeComprobante").ToString
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

    Private Sub elimina_iva(ByVal Fec As String, ByVal TipRedef As Byte, ByVal Tipo As String, ByVal Letra As String, ByVal Nro As String, ByVal Prov As Double, ByVal Imp As Double)
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
            InsSql = "Update Iva_Compras Set Estado=9,FechaBaja='" & j2 & "',HoraBaja='" & j3 & "',UsuarioBaja=" & j1 & " "
            InsSql = InsSql & "WHERE (Fecha= '" & Fec & "') AND (TipoDeComprobante= '" & Tipo & "') AND (Letra= '" & Letra & "') AND "
            InsSql = InsSql & "(NumeroDeComprobante= '" & Nro & "') AND (Cliente= " & Prov & ") AND (Total= " & Imp & ")"
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
    Private Sub elimina_cuenta_corriente(ByVal Fec As String, ByVal TipRedef As Byte, ByVal Tipo As String, ByVal Letra As String, ByVal Nro As String, ByVal Prov As Double, ByVal Imp As Double)
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
            InsSql = "Update Cuenta_Corriente_Proveedores Set Estado=9,FechaBaja='" & j2 & "',HoraBaja='" & j3 & "',UsuarioBaja=" & j1 & " "
            InsSql = InsSql & "WHERE (Fecha= '" & Fec & "') AND (CodigoMovimiento= " & TipRedef & ") AND (LetraComprobante= '" & Letra & "') AND "
            InsSql = InsSql & "(NumeroComprobante= '" & Nro & "') AND (Cliente= " & Prov & ") AND (Importe= " & Imp & ")"
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


            elimina_iva(Fec, TipRedef, Tipo, Letra, Nro, Prov, Imp)
            elimina_cuenta_corriente(Fec, TipRedef, Tipo, Letra, Nro, Prov, Imp)

            cargar_datagrid()

        End If


    End Sub
End Class

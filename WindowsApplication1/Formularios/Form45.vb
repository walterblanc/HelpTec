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
Imports System.Threading

Public Class Form45

 
    Private Sub Form45_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MetroDateTime1.Value = Now.Date.AddDays(-7)
        MetroDateTime2.Value = Now.Date

        cargar_datagrid()
    End Sub
    Private Sub cargar_datagrid()

        Dim h As Integer = 0

        With metroGrid1
            .Columns.Clear()
            .Rows.Clear()
            .Refresh()
        End With


        With metroGrid1
            .Rows.Clear()
            .Columns.Add("Fecha", "Fecha")
            .Columns.Add("Mail", "Mail")
            .Columns.Add("Titulo", "Titulo")
            .Columns.Add("Texto", "Texto")
            .Columns.Add("Archivo", "Archivo")
            .Columns.Add("Hora", "Hora")
            .Columns.Add("Ok", "Status")

            .Columns(0).Width = 90
            .Columns(1).Width = 300
            .Columns(2).Width = 300
            .Columns(3).Width = 200
            .Columns(4).Width = 160
            .Columns(5).Width = 90
            .Columns(6).Width = 90
            '            .RowCount = 100
        End With

        Dim fx1 As DateTime = Convert.ToDateTime(MetroDateTime1.Text)
        Dim fx2 As DateTime = Convert.ToDateTime(MetroDateTime2.Text)

        If fx1 > fx2 Then
            MetroFramework.MetroMessageBox.Show(Me, "Error en el rango de fechas establecido", "Sio. Sistema integrado de Obra", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        Dim f1 As String = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate)
        Dim f2 As String = FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate)


        Dim Sql As String = ""
        Sql = "Select * From Seguimiento_Mail WHERE (Fecha Between '" & f1 & "' And '" & f2 & "' ) AND (Usuario=" & rsv_Usuario & ")Order by Fecha,Id"
   
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)

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
                    .Item(1, h).Value = drRecordSet("Mail").ToString
                    .Item(2, h).Value = drRecordSet("Titulo").ToString
                    .Item(3, h).Value = drRecordSet("Texto").ToString
                    .Item(4, h).Value = drRecordSet("Archivo").ToString
                    .Item(5, h).Value = drRecordSet("Hora").ToString

                    If Val(drRecordSet("Ok").ToString) = 0 Then
                        .Item(6, h).Value = "WAIT"
                    Else
                        .Item(6, h).Value = "OK"
                    End If

                    h = h + 1
                End With
            Loop
        End If

        drRecordSet.Close()


    End Sub

    Private Sub MetroLink5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink5.Click
        cargar_datagrid()
    End Sub

End Class

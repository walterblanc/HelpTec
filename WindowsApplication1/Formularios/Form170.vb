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

Public Class Form170
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)


    Private Sub Form170_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MetroDateTime1.Value = Now.Date
        MetroDateTime2.Value = Now.Date
        MetroTextBox12.Text = ""
    End Sub

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        Me.Close()
    End Sub
    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        If MetroTextBox12.Text.Trim = "" Then
            MessageBox.Show("Debe especificar ruta de generación de archivo", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Call hacerReporte()
    End Sub
    Private Sub hacerReporte()


        Try


            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim fila As Integer = 0
            Dim excel As New Microsoft.Office.Interop.Excel.Application
            '  Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            '  Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet


            With excel
                excel.Workbooks.Open(MetroTextBox12.Text.Trim, , False)
                excel.Visible = True
                '.SheetsInNewWorkbook = 1
                '.Workbooks.Add()
                .Worksheets(1).Select()
            End With


            fila = 2

            Dim xFecha1 As String
            Dim xFecha2 As String
            xFecha1 = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate)
            xFecha1 = String.Format("{0:yyyyMMdd}", Convert.ToDateTime(xFecha1))

            xFecha2 = FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate)
            xFecha2 = String.Format("{0:yyyyMMdd}", Convert.ToDateTime(xFecha2))

            Dim insSql As String = ""
            insSql = "Select * from Iva_Ventas Where (FechaImputacion >= '" & xFecha1 & "') And (FechaImputacion <= '" & xFecha2 & "') And (Estado=0) Order By FechaImputacion,TipoComprobante,LetraComprobante,NumeroComprobante"


            Dim cmdRecordSet2 As New OleDbCommand(insSql, ConSql)
            Dim drRecordSet2 As OleDbDataReader = cmdRecordSet2.ExecuteReader
            If drRecordSet2.HasRows Then 'Tiene filas
                Do While drRecordSet2.Read
                    With excel


                        Dim f As String = FormatDateTime(drRecordSet2("FechaImputacion").ToString, DateFormat.ShortDate)

                        .Cells(fila, 1) = "'" & f.Trim

                        If drRecordSet2("TipoComprobante").ToString = "FA" Then
                            .Cells(fila, 2) = "FAC"
                        End If
                        If drRecordSet2("TipoComprobante").ToString = "ND" Then
                            .Cells(fila, 2) = "ND"
                        End If
                        If drRecordSet2("TipoComprobante").ToString = "NC" Then
                            .Cells(fila, 2) = "NC"
                        End If
                        .Cells(fila, 3) = drRecordSet2("LetraComprobante").ToString
                        .Cells(fila, 4) = Microsoft.VisualBasic.Left(drRecordSet2("NumeroComprobante").ToString.Trim, 4)
                        .Cells(fila, 5) = Microsoft.VisualBasic.Right(drRecordSet2("NumeroComprobante").ToString.Trim, 8)
                        .Cells(fila, 6) = drRecordSet2("Nombre").ToString

                        If Val(drRecordSet2("Cuit").ToString) <> 0 Then
                            .Cells(fila, 7) = "80"
                            .Cells(fila, 8) = drRecordSet2("Cuit").ToString
                        Else
                            .Cells(fila, 7) = "99"
                            If Val(drRecordSet2("NumeroDocumento").ToString) <> 0 Then
                                .Cells(fila, 8) = drRecordSet2("NumeroDocumento").ToString
                            Else
                                .Cells(fila, 8) = "0"
                            End If
                        End If
                        .Cells(fila, 9) = "SANTA ROSA"
                        .Cells(fila, 10) = "6300"
                        .Cells(fila, 11) = "21"
                        If Val(drRecordSet2("TipoResponsable").ToString) = 1 Then
                            .Cells(fila, 12) = "RI"
                        End If
                        If Val(drRecordSet2("TipoResponsable").ToString) = 2 Then
                            .Cells(fila, 12) = "CF"
                        End If
                        If Val(drRecordSet2("TipoResponsable").ToString) = 3 Then
                            .Cells(fila, 12) = "EX"
                        End If
                        If Val(drRecordSet2("TipoResponsable").ToString) = 4 Then
                            .Cells(fila, 12) = "MT"
                        End If
                        .Cells(fila, 13) = " "
                        .Cells(fila, 14) = Convert.ToDouble(drRecordSet2("NetoGravado").ToString)
                        .Cells(fila, 15) = "21.000"
                        .Cells(fila, 16) = Convert.ToDouble(drRecordSet2("Iva21").ToString)
                        .Cells(fila, 17) = Convert.ToDouble(drRecordSet2("Iva21").ToString)
                        .Cells(fila, 18) = " "
                        .Cells(fila, 19) = "0.00"
                        .Cells(fila, 20) = " "
                        .Cells(fila, 21) = "0.00"
                        .Cells(fila, 22) = " "
                        .Cells(fila, 23) = Convert.ToDouble(drRecordSet2("Total").ToString)
                    End With
                    fila = fila + 1
                Loop
            End If

            ' excel.Columns("A:A").NumberFormat = "m/d/yyyy;@"

            'Dim fileName As String = "c:\HWventa_presentacion.xLs"
            'With excel
            '    .ActiveCell.Worksheet.SaveAs(fileName)
            '    .Quit()
            'End With


            'System.Runtime.InteropServices.Marshal.ReleaseComObject(excel)
            'excel = Nothing

            'forzar_finalizar_procesos()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConSql.Close()
        End Try

    End Sub
    Private Sub forzar_finalizar_procesos()
        Dim xlp() As Process = Process.GetProcessesByName("EXCEL")
        For Each Process As Process In xlp
            Process.Kill()
            If Process.GetProcessesByName("EXCEL").Count = 0 Then
                Exit For
            End If
        Next
    End Sub

    Private Sub MetroButton3_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton3.Click
        MetroTextBox12.Text = ""
        Dim openfiledialog1 As New OpenFileDialog
        openfiledialog1.Filter = "Archivo de Texto|*.xls"


        Dim mCaminoTxt As String
        Dim Cadena1 As String
        Dim Cadena2 As String

        Cadena1 = ApplicationLocation() & "\"
        Cadena2 = "file:\"
        mCaminoTxt = Cadena1.Replace(Cadena2, "")




        '       openfiledialog1.InitialDirectory = "C:\SistemasNet\Frank\Fe\bin\Release\"

        openfiledialog1.InitialDirectory = mCaminoTxt

        openfiledialog1.Title = "Seleccione Archivo"
        If openfiledialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            MetroTextBox12.Text = openfiledialog1.FileName
        End If

        'If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
        '    TextBox1.Text = FolderBrowserDialog1.SelectedPath
        'End If
    End Sub
    Private Function ApplicationLocation() As String
        Dim camino As String
        camino = System.IO.Path.GetDirectoryName(Reflection.Assembly. _
        GetExecutingAssembly().GetName().CodeBase.ToString())
        ApplicationLocation = camino
    End Function
End Class

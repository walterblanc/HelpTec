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



Public Class Form40
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)


    Private Sub Form40_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MetroDateTime1.Value = Now.Date
        MetroDateTime2.Value = Now.Date
        MetroTextBox1.Text = 1
        MetroTextBox12.Text = ""
        MetroCheckBox1.Checked = True
    End Sub
    Private Sub metroTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

   
    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        Me.Close()
    End Sub

   
    Private Sub MetroButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton4.Click
        hacerReporte()
    End Sub
    Private Sub hacerReporte()

        Dim dts As New DataSet
        Dim ExistenRegistros As Boolean

        ExistenRegistros = False

        Try
            Dim Aux1 As Double = 0
            Dim Aux2 As Double = 0
            Dim Aux3 As Double = 0
            Dim Aux4 As Double = 0
            Dim Aux5 As Double = 0
            Dim Aux6 As Double = 0
            Dim Aux7 As Double = 0
            Dim Aux8 As Double = 0
            Dim Aux9 As Double = 0
            Dim Aux10 As Double = 0
            Dim Aux11 As Double = 0
            Dim Aux12 As Double = 0

            Dim tabla As DataTable
            Dim campo As DataColumn
            Dim registro As DataRow
            tabla = New DataTable("reportesLibroVentas")

            campo = New DataColumn("Hoja", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("FechaDesde", GetType(System.DateTime))
            campo.DefaultValue = Now
            tabla.Columns.Add(campo)
            campo = New DataColumn("FechaHasta", GetType(System.DateTime))
            campo.DefaultValue = Now
            tabla.Columns.Add(campo)
            campo = New DataColumn("Fecha", GetType(System.DateTime))
            campo.DefaultValue = Now
            tabla.Columns.Add(campo)
            campo = New DataColumn("FechaImputacion", GetType(System.DateTime))
            campo.DefaultValue = Now
            tabla.Columns.Add(campo)
            campo = New DataColumn("TipoComprobante", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("LetraComprobante", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("NumeroComprobante", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("Cliente", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Cuit", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Nombre", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("Neto", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("NoGravados", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Iva25", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Iva105", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Iva21", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Iva27", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Exento", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Monotributo", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Percep", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Reten", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("IngBru", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)


            campo = New DataColumn("Total", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ToNeto", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ToNoGravados", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ToIva25", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ToIva105", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ToIva21", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ToIva27", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ToExento", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ToMonotributo", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ToPercep", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ToReten", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ToIngBru", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)


            campo = New DataColumn("ToTotal", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Responsable", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)



            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim xFecha1 As Date = MetroDateTime1.Value
            Dim xFecha2 As Date = MetroDateTime2.Value

            Dim xFecha As String = ""
            xFecha = FormatDateTime(MetroDateTime1.Value, DateFormat.ShortDate) '10/01/2009
            xFecha = String.Format("{0:yyyyMMdd}", Convert.ToDateTime(xFecha))

            Dim xFechaDesde As String = ""
            Dim xFechaHasta As String = ""

            xFechaDesde = xFecha

            xFecha = FormatDateTime(MetroDateTime2.Value, DateFormat.ShortDate) '10/01/2009
            xFecha = String.Format("{0:yyyyMMdd}", Convert.ToDateTime(xFecha))

            xFechaHasta = xFecha

            Dim xHoja As Byte = 1

            If Val(MetroTextBox1.Text.Trim) > 1 Then
                xHoja = Val(MetroTextBox1.Text.Trim) - 1
            Else
                xHoja = 0
            End If

            Dim insSql As String = ""
            insSql = "Select * from Iva_ventas Where Estado = 0 And FechaImputacion >= '" & xFechaDesde & "' And FechaImputacion <= '" & xFechaHasta & "' Order By FechaImputacion,TipoComprobante,LetraComprobante,NumeroComprobante"


            Dim cmdRecordSet2 As New OleDbCommand(insSql, ConSql)
            Dim drRecordSet2 As OleDbDataReader = cmdRecordSet2.ExecuteReader
            If drRecordSet2.HasRows Then 'Tiene filas
                Do While drRecordSet2.Read
                    registro = tabla.NewRow
                    registro("Hoja") = xHoja
                    registro("FechaDesde") = xFecha1
                    registro("FechaHasta") = xFecha2

                    registro("Fecha") = FormatDateTime(drRecordSet2("Fecha").ToString, DateFormat.ShortDate)
                    registro("FechaImputacion") = FormatDateTime(drRecordSet2("FechaImputacion").ToString, DateFormat.ShortDate)

                    registro("TipoComprobante") = drRecordSet2("TipoComprobante").ToString
                    registro("Responsable") = parametroSistema(2, Val(drRecordSet2("TipoResponsable").ToString))


                    registro("LetraComprobante") = drRecordSet2("LetraComprobante").ToString
                    registro("NumeroComprobante") = drRecordSet2("NumeroComprobante").ToString
                    registro("Cliente") = drRecordSet2("Cliente").ToString
                    registro("Cuit") = drRecordSet2("Cuit").ToString
                    registro("Nombre") = drRecordSet2("Nombre").ToString
                    registro("Neto") = drRecordSet2("NetoGravado").ToString
                    registro("NoGravados") = drRecordSet2("Monotributo").ToString
                    registro("Iva25") = drRecordSet2("Iva25").ToString
                    registro("Iva105") = drRecordSet2("Iva105").ToString
                    registro("Iva21") = drRecordSet2("Iva21").ToString
                    registro("Iva27") = drRecordSet2("Iva27").ToString
                    registro("Exento") = drRecordSet2("Exento").ToString
                    '            registro("Monotributo") = drRecordSet2("Monotributo").ToString

                    registro("Percep") = drRecordSet2("Percepciones").ToString
                    registro("Reten") = drRecordSet2("Retenciones").ToString
                    registro("Total") = drRecordSet2("Total").ToString

                    If drRecordSet2("TipoComprobante").ToString = "FA" Or drRecordSet2("TipoComprobante").ToString = "ND" Then
                        Aux1 = Aux1 + drRecordSet2("NetoGravado").ToString
                        Aux2 = Aux2 + drRecordSet2("ConceptosNoGravados").ToString
                        Aux12 = Aux12 + drRecordSet2("Iva25").ToString
                        Aux3 = Aux3 + drRecordSet2("Iva105").ToString
                        Aux4 = Aux4 + drRecordSet2("Iva21").ToString
                        Aux5 = Aux5 + drRecordSet2("Iva27").ToString
                        Aux6 = Aux6 + drRecordSet2("Exento").ToString
                        '             Aux8 = Aux8 + drRecordSet2("Monotributo").ToString
                        Aux7 = Aux7 + drRecordSet2("Total").ToString
                        Aux8 = Aux8 + drRecordSet2("Monotributo").ToString
                        Aux9 = Aux9 + drRecordSet2("Percepciones").ToString
                        Aux10 = Aux10 + drRecordSet2("Retenciones").ToString
                        '              Aux11 = Aux11 + drRecordSet2("ImpIngBru").ToString
                    Else
                        Aux1 = Aux1 - drRecordSet2("NetoGravado").ToString
                        Aux2 = Aux2 - drRecordSet2("ConceptosNoGravados").ToString
                        Aux12 = Aux12 - drRecordSet2("Iva25").ToString
                        Aux3 = Aux3 - drRecordSet2("Iva105").ToString
                        Aux4 = Aux4 - drRecordSet2("Iva21").ToString
                        Aux5 = Aux5 - drRecordSet2("Iva27").ToString
                        Aux6 = Aux6 - drRecordSet2("Exento").ToString
                        Aux7 = Aux7 - drRecordSet2("Total").ToString
                        '            Aux8 = Aux8 - drRecordSet2("Monotributo").ToString
                        Aux8 = Aux8 - drRecordSet2("Monotributo").ToString
                        Aux9 = Aux9 - drRecordSet2("Percepciones").ToString
                        Aux10 = Aux10 - drRecordSet2("Retenciones").ToString
                        '            Aux11 = Aux11 - drRecordSet2("ImpIngBru").ToString
                    End If

                    registro("ToNeto") = Aux1
                    registro("ToNoGravados") = Aux2
                    registro("ToIva25") = Aux12
                    registro("ToIva105") = Aux3
                    registro("ToIva21") = Aux4
                    registro("ToIva27") = Aux5
                    registro("ToExento") = Aux6
                    registro("ToMonotributo") = Aux8
                    registro("ToTotal") = Aux7
                    registro("ToPercep") = Aux9
                    registro("ToReten") = Aux10
                    registro("ToIngBru") = Aux11

                    tabla.Rows.Add(registro)

                    ExistenRegistros = True
                Loop
                dts.Tables.Add(tabla)
            End If


            If ExistenRegistros = False Then
                tabla.Dispose()
                drRecordSet2.Close()
                MessageBox.Show("     No existen movimientos para procesar listado       ", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


            'Aqui ordeno los registros en una vista Chequear

            ''Dim dv As DataView
            ''dv = New DataView(tabla, "", "CuentaGr", DataViewRowState.CurrentRows)

            drRecordSet2.Close()

       




            If MetroCheckBox1.Checked = True Then

                Dim mi_CryResumen As New CrLibroIvaVentasResumido()
                'Le indicamos al reporte que tome los datos
                'del DataSet
                mi_CryResumen.SetDataSource(dts.Tables("reportesLibroVentas"))

                'Delcaramos una instancia del formulario frmReprotes
                Dim miForma As New Form1000()
                'Le indicamos que debe mostrar mi_rptCatClientes
                miForma.CrvReportes.ReportSource = mi_CryResumen
                'que muestre el titulo "Reporte de Clientes"
                'Mostramos el formulario (el cual contiene el reporte)
                miForma.Show()
                ''dv = Nothing

            Else

                Dim mi_CryResumen As New CrLibroIvaVentas()
                'Le indicamos al reporte que tome los datos
                'del DataSet
                mi_CryResumen.SetDataSource(dts.Tables("reportesLibroVentas"))

                'Delcaramos una instancia del formulario frmReprotes
                Dim miForma As New Form1000()
                'Le indicamos que debe mostrar mi_rptCatClientes
                miForma.CrvReportes.ReportSource = mi_CryResumen
                'que muestre el titulo "Reporte de Clientes"
                'Mostramos el formulario (el cual contiene el reporte)
                miForma.Show()
                ''dv = Nothing

            End If



            ConSql.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub


    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        Try
            If MetroTextBox12.Text.Trim = "" Then
                MetroFramework.MetroMessageBox.Show(Me, "Debe especificar ruta de archivo", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Aux1 As Double = 0
            Dim Aux2 As Double = 0
            Dim Aux3 As Double = 0
            Dim Aux4 As Double = 0
            Dim Aux5 As Double = 0
            Dim Aux6 As Double = 0
            Dim Aux7 As Double = 0
            Dim Aux8 As Double = 0
            Dim Aux9 As Double = 0
            Dim Aux10 As Double = 0
            Dim Aux11 As Double = 0
            Dim Aux12 As Double = 0


            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim xFecha1 As Date = MetroDateTime1.Value
            Dim xFecha2 As Date = MetroDateTime2.Value

            Dim xFecha As String = ""
            xFecha = FormatDateTime(MetroDateTime1.Value, DateFormat.ShortDate) '10/01/2009
            xFecha = String.Format("{0:yyyyMMdd}", Convert.ToDateTime(xFecha))

            Dim xFechaDesde As String = ""
            Dim xFechaHasta As String = ""

            xFechaDesde = xFecha

            xFecha = FormatDateTime(MetroDateTime2.Value, DateFormat.ShortDate) '10/01/2009
            xFecha = String.Format("{0:yyyyMMdd}", Convert.ToDateTime(xFecha))

            xFechaHasta = xFecha



            Dim excel As New Microsoft.Office.Interop.Excel.Application
            '  Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            '  Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet


            With excel
                .SheetsInNewWorkbook = 1
                .Workbooks.Add()
                .Worksheets(1).Select()
            End With


            Dim i As Integer = 1

            With excel
                .Cells(i, 1) = "Fecha"
                .Cells(i, 2) = "Fec.Imp"
                .Cells(i, 3) = "Tipo"
                .Cells(i, 4) = "Tipo Responsable"


                .Cells(i, 5) = "Letra"
                .Cells(i, 6) = "Numero"
                .Cells(i, 7) = "Cliente"
                .Cells(i, 8) = "Cuit"
                .Cells(i, 9) = "Nombre"
                .Cells(i, 10) = "Neto Gravado"
                .Cells(i, 11) = "Iva 21%"
                .Cells(i, 12) = "Monotributo"
                .Cells(i, 13) = "Total"

            End With


            i = i + 2

            Dim insSql As String = ""
            insSql = "Select * from Iva_ventas Where Estado = 0 And FechaImputacion >= '" & xFechaDesde & "' And FechaImputacion <= '" & xFechaHasta & "' Order By FechaImputacion,TipoComprobante,LetraComprobante,NumeroComprobante"


            Dim cmdRecordSet2 As New OleDbCommand(insSql, ConSql)
            Dim drRecordSet2 As OleDbDataReader = cmdRecordSet2.ExecuteReader
            If drRecordSet2.HasRows Then 'Tiene filas
                Do While drRecordSet2.Read
                    With excel
                        .Cells(i, 1) = FormatDateTime(drRecordSet2("Fecha").ToString, DateFormat.ShortDate)
                        .Cells(i, 2) = FormatDateTime(drRecordSet2("FechaImputacion").ToString, DateFormat.ShortDate)

                        .Cells(i, 3) = drRecordSet2("TipoComprobante").ToString
                        .Cells(i, 4) = parametroSistema(2, Val(drRecordSet2("TipoResponsable").ToString))


                        .Cells(i, 5) = drRecordSet2("LetraComprobante").ToString
                        .Cells(i, 6) = drRecordSet2("NumeroComprobante").ToString
                        .Cells(i, 7) = drRecordSet2("Cliente").ToString
                        .Cells(i, 8) = drRecordSet2("Cuit").ToString
                        .Cells(i, 9) = drRecordSet2("Nombre").ToString
                        .Cells(i, 10) = drRecordSet2("NetoGravado").ToString
                        .Cells(i, 11) = drRecordSet2("Iva21").ToString
                        .Cells(i, 12) = drRecordSet2("Monotributo").ToString
                        .Cells(i, 13) = drRecordSet2("Total").ToString
                    End With
                    i = i + 1
                    If drRecordSet2("TipoComprobante").ToString = "FA" Or drRecordSet2("TipoComprobante").ToString = "ND" Then
                        Aux1 = Aux1 + drRecordSet2("NetoGravado").ToString
                        Aux2 = Aux2 + drRecordSet2("Monotributo").ToString
                        Aux12 = Aux12 + drRecordSet2("Iva25").ToString
                        Aux3 = Aux3 + drRecordSet2("Iva105").ToString
                        Aux4 = Aux4 + drRecordSet2("Iva21").ToString
                        Aux5 = Aux5 + drRecordSet2("Iva27").ToString
                        Aux6 = Aux6 + drRecordSet2("Exento").ToString
                        '             Aux8 = Aux8 + drRecordSet2("Monotributo").ToString
                        Aux7 = Aux7 + drRecordSet2("Total").ToString
                        Aux9 = Aux9 + drRecordSet2("Percepciones").ToString
                        Aux10 = Aux10 + drRecordSet2("Retenciones").ToString
                        '              Aux11 = Aux11 + drRecordSet2("ImpIngBru").ToString
                    Else
                        Aux1 = Aux1 - drRecordSet2("NetoGravado").ToString
                        Aux2 = Aux2 - drRecordSet2("Monotributo").ToString
                        Aux12 = Aux12 - drRecordSet2("Iva25").ToString
                        Aux3 = Aux3 - drRecordSet2("Iva105").ToString
                        Aux4 = Aux4 - drRecordSet2("Iva21").ToString
                        Aux5 = Aux5 - drRecordSet2("Iva27").ToString
                        Aux6 = Aux6 - drRecordSet2("Exento").ToString
                        Aux7 = Aux7 - drRecordSet2("Total").ToString
                        '            Aux8 = Aux8 - drRecordSet2("Monotributo").ToString
                        Aux9 = Aux9 - drRecordSet2("Percepciones").ToString
                        Aux10 = Aux10 - drRecordSet2("Retenciones").ToString
                        '            Aux11 = Aux11 - drRecordSet2("ImpIngBru").ToString
                    End If
                Loop

            End If

            Dim fileName As String = MetroTextBox12.Text.Trim & "\Prueba_1.xLs"
            With excel
                .Cells(i, 10) = Aux1
                .Cells(i, 11) = Aux4
                .Cells(i, 12) = Aux2
                .Cells(i, 13) = Aux7
                .Columns.AutoFit()
                .ActiveCell.Worksheet.SaveAs(fileName)
                .Quit()
            End With



            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel)
            excel = Nothing

            forzar_finalizar_procesos()

            drRecordSet2.Close()

            ConSql.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            MetroTextBox12.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
End Class

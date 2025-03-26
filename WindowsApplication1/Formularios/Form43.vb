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



Public Class Form43
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)


    Private Sub Form43_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MetroRadioButton1.Checked = True

        MetroDateTime1.Value = Now.Date
        MetroDateTime2.Value = Now.Date
        MetroTextBox1.Text = ""
    End Sub
   
    Private Sub metroTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox1.KeyPress
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
        hacerReporte(1)
        hacerReporte(2)
    End Sub
    Private Sub hacerReporte(ByVal x As Byte)
        Dim dts As New DataSet

        Try
            Dim tabla As DataTable
            Dim campo As DataColumn
            Dim registro As DataRow
            tabla = New DataTable("ReportesGenericos")
            campo = New DataColumn("fecha1", GetType(System.DateTime))
            campo.DefaultValue = Nothing
            tabla.Columns.Add(campo)
            campo = New DataColumn("fecha2", GetType(System.DateTime))
            campo.DefaultValue = Nothing
            tabla.Columns.Add(campo)
            campo = New DataColumn("fecha3", GetType(System.DateTime))
            campo.DefaultValue = Nothing
            tabla.Columns.Add(campo)
            campo = New DataColumn("fecha4", GetType(System.DateTime))
            campo.DefaultValue = Nothing
            tabla.Columns.Add(campo)
            campo = New DataColumn("fecha5", GetType(System.DateTime))
            campo.DefaultValue = Nothing
            tabla.Columns.Add(campo)
            campo = New DataColumn("fecha6", GetType(System.DateTime))
            campo.DefaultValue = Nothing
            tabla.Columns.Add(campo)
            campo = New DataColumn("fecha7", GetType(System.DateTime))
            campo.DefaultValue = Nothing
            tabla.Columns.Add(campo)
            campo = New DataColumn("literal1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("literal2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("literal3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("literal4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("literal5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("literal6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("literal7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("literal8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("literal9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("literal10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("numero1", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("numero2", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("numero3", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("numero4", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("numero5", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("numero6", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("numero7", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("numero8", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("numero9", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("numero10", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("numero11", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("numero12", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("numero13", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("numero14", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("numero15", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("numero16", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("numero17", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("numero18", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("numero19", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("numero20", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            registro = tabla.NewRow

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()



            Dim xLetra As String
            Dim xPunto As String



            Dim fecha_ant As Date = Now.Date
            Dim Numer_Ant As Double = 0
            Dim p_vez As Boolean = True
            Dim xLiteral As String = ""

            xLiteral = " "

            If MetroRadioButton1.Checked = True Then
                xLetra = "A"
            Else
                xLetra = "B"
            End If

            xPunto = Formatea_Numero_Comprobante(Val(MetroTextBox1.Text.Trim))


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

            Dim Sql As String = ""

            If x = 1 Then
                Sql = "Select * from Iva_ventas Where LetraComprobante = '" & xLetra & "' and "
                Sql = Sql & " FechaImputacion >= '" & xFechaDesde & "' And FechaImputacion <= '" & xFechaHasta & "' And  "
                Sql = Sql & " (TipoComprobante = 'FA' OR TipoComprobante = 'ND')  and "
                Sql = Sql & " left(NumeroComprobante,4) = '" & xPunto & "'  order by LetraComprobante,NumeroComprobante"
            End If
            If x = 2 Then
                Sql = "Select * from Iva_ventas Where LetraComprobante = '" & xLetra & "' and "
                Sql = Sql & " FechaImputacion >= '" & xFechaDesde & "' And FechaImputacion <= '" & xFechaHasta & "' And "
                Sql = Sql & " TipoComprobante = 'NC'  and "
                Sql = Sql & " left(NumeroComprobante,4) = '" & xPunto & "'  order by LetraComprobante,NumeroComprobante"
            End If


            Dim e As Boolean = False

            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                Do While drRecordSet.Read

                    If p_vez = True Then
                        fecha_ant = FormatDateTime(drRecordSet("FechaImputacion").ToString, DateFormat.ShortDate)
                        Numer_Ant = Val(drRecordSet("NumeroComprobante").ToString().Substring(5, 8))
                        Numer_Ant = Numer_Ant + 1
                        p_vez = False
                    Else
                        If Numer_Ant = Val(drRecordSet("NumeroComprobante").ToString().Substring(5, 8)) Then
                            Numer_Ant = Numer_Ant + 1
                            fecha_ant = FormatDateTime(drRecordSet("FechaImputacion").ToString, DateFormat.ShortDate)
                        Else
                            If Numer_Ant < Val(drRecordSet("NumeroComprobante").ToString().Substring(5, 8)) Then
                                e = True
                                Do While Numer_Ant < Val(drRecordSet("NumeroComprobante").ToString().Substring(5, 8))
                                    registro = tabla.NewRow
                                    registro("literal1") = xLetra
                                    registro("literal2") = Numer_Ant

                                    If x = 1 Then
                                        registro("literal3") = "Falta FA/ND " & " aprox. " & CStr(fecha_ant)
                                    End If
                                    If x = 2 Then
                                        registro("literal3") = "Falta NC " & " aprox. " & CStr(fecha_ant)
                                    End If

                                    registro("literal4") = "Pto de Venta : " & MetroTextBox1.Text.Trim
                                    fecha_ant = FormatDateTime(drRecordSet("FechaImputacion").ToString, DateFormat.ShortDate)
                                    tabla.Rows.Add(registro)

                                    Numer_Ant = Numer_Ant + 1
                                Loop
                                Numer_Ant = Numer_Ant + 1

                            Else
                                e = True
                                registro = tabla.NewRow
                                registro("literal1") = xLetra
                                registro("literal2") = Val(drRecordSet("NumeroComprobante").ToString().Substring(5, 8))

                                If x = 1 Then
                                    registro("literal3") = "REPETIDO FA/ND " & " aprox. " & CStr(fecha_ant)
                                End If
                                If x = 2 Then
                                    registro("literal3") = "REPETIDO NC " & " aprox. " & CStr(fecha_ant)
                                End If

                                registro("literal4") = "Pto de Venta : " & MetroTextBox1.Text.Trim
                                fecha_ant = FormatDateTime(drRecordSet("FechaImputacion").ToString, DateFormat.ShortDate)
                                tabla.Rows.Add(registro)
                            End If
                        End If
                    End If

                Loop
            End If

            If e = False Then
                Exit Sub
            End If

            dts.Tables.Add(tabla)



            Dim mi_CryResumen As New CrNumerosFaltantesIvaVentas()
            mi_CryResumen.SetDataSource(dts.Tables("ReportesGenericos"))

            Dim miForma As New Form1000()
            miForma.CrvReportes.ReportSource = mi_CryResumen
            miForma.ShowDialog()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Function Formatea_Numero_Comprobante(ByVal x1 As Integer) As String
        Dim c3 As String

        Dim xNumeroDe4 As String


        xNumeroDe4 = x1
        xNumeroDe4 = xNumeroDe4.PadLeft(4)
        xNumeroDe4 = xNumeroDe4.Replace(" ", "0")
        c3 = xNumeroDe4.ToString

        Formatea_Numero_Comprobante = c3
    End Function

    Private Sub MetroButton1_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton1.Click
        Dim Formulario_open As New Form74
        Formulario_open.ShowDialog()
    End Sub
End Class

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


Public Class Form35
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)


    Private Sub Form35_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        inicializo_formulario()
    End Sub
    Private Sub inicializo_formulario()

        MetroDateTime1.Value = Now.Date
        MetroDateTime2.Value = Now.Date

    End Sub


  
    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub


    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
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
            Dim xSaldo As Double = 0

            Dim xFecha1 As String = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate)
            Dim xFecha2 As String = FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate)

            Dim Exis As Boolean = False
            Dim insSql As String = ""

            insSql = "Select * from Cuenta_Corriente_Clientes Where (Estado = 0) "
            insSql = insSql & "AND (Fecha >= '" & xFecha1 & "') AND (Fecha <= '" & xFecha2 & "')  ORDER BY Fecha"

            Dim cmdRecordSet As New OleDbCommand(insSql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows = True Then 'Tiene filas
                Do While drRecordSet.Read
                    registro = tabla.NewRow
                    Exis = True
                    registro("Fecha1") = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate)
                    registro("Fecha2") = FormatDateTime(MetroDateTime2.Value, DateFormat.ShortDate)

                    registro("Numero1") = Convert.ToDouble(drRecordSet("Cliente").ToString)
                    registro("Literal1") = NombreCliente(Convert.ToDouble(drRecordSet("Cliente").ToString))
                    registro("Literal2") = " "

                    registro("Fecha3") = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)
                    registro("Literal4") = drRecordSet("LetraComprobante").ToString
                    registro("Literal5") = drRecordSet("NumeroComprobante").ToString
                    registro("Literal6") = drRecordSet("Detalle").ToString

                    If Val(drRecordSet("DebCre").ToString) = 1 Then
                        registro("Numero2") = 1
                        xSaldo = xSaldo + Convert.ToDouble(drRecordSet("Importe").ToString)
                        registro("Numero3") = Convert.ToDouble(drRecordSet("Importe").ToString)
                    Else
                        registro("Numero2") = 2
                        xSaldo = xSaldo - Convert.ToDouble(drRecordSet("Importe").ToString)
                        registro("Numero6") = Convert.ToDouble(drRecordSet("Importe").ToString)
                    End If

                    If Val(drRecordSet("CodigoMovimiento").ToString) = 1 Then
                        registro("Literal7") = "FA"
                    End If
                    If Val(drRecordSet("CodigoMovimiento").ToString) = 2 Then
                        registro("Literal7") = "ND"
                    End If
                    If Val(drRecordSet("CodigoMovimiento").ToString) = 3 Then
                        registro("Literal7") = "NC"
                    End If
                    If Val(drRecordSet("CodigoMovimiento").ToString) = 4 Then
                        registro("Literal7") = "RE"
                    End If
                    If Val(drRecordSet("CodigoMovimiento").ToString) = 5 Then
                        registro("Literal7") = "AD"
                    End If
                    If Val(drRecordSet("CodigoMovimiento").ToString) = 6 Then
                        registro("Literal7") = "AA"
                    End If
                    registro("Literal8") = " "
                    registro("Literal9") = " "
                    registro("Numero4") = xSaldo
                    registro("Numero5") = 0
                    tabla.Rows.Add(registro)
                Loop
                dts.Tables.Add(tabla)
            End If

            If Exis = False Then
                Exit Sub
            End If

            Dim mi_CryResumen As New CrCuentaCorrienteMovimientos()
            mi_CryResumen.SetDataSource(dts.Tables("ReportesGenericos"))

            Dim miForma As New Form1000()
            miForma.CrvReportes.ReportSource = mi_CryResumen
            miForma.Show()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
End Class

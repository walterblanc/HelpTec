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


Public Class Form31
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)



    Private Sub Form31_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MetroDateTime1.Value = Now.Date
        MetroDateTime2.Value = Now.Date
    End Sub

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        Me.Close()
    End Sub

    Private Sub MetroButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton4.Click
     

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


            Dim f1 As String = ""
            f1 = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate)
            Dim f2 As String = ""
            f2 = FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate)

            Dim Acum As Double = 0
            Dim exis As Boolean = False

            Dim Sql As String =  "Select * from Valores_recibidos_ventas WHERE (PAGO BETWEEN '" & f1 & "' AND '" & f2 & "') Order by Pago"


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                Do While drRecordSet.Read

                    If Val(drRecordSet("Estado").ToString) = 0 And Val(drRecordSet("Depositado").ToString) = 0 And Val(drRecordSet("Retirado").ToString) = 0 Then
                        exis = True

                        registro = tabla.NewRow

                        registro("fecha1") = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate)
                        registro("fecha2") = FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate)

                        If Convert.ToDouble(drRecordSet("Cliente").ToString) <> 0 Then
                            registro("numero1") = Convert.ToDouble(drRecordSet("Cliente").ToString)
                            registro("literal1") = NombreCliente(drRecordSet("Cliente").ToString)
                        End If

                        registro("numero2") = Convert.ToDouble(drRecordSet("Banco").ToString)
                        registro("literal2") = parametroSistema(8, drRecordSet("Banco").ToString)
                        registro("numero3") = Convert.ToDouble(drRecordSet("Numero").ToString)
                        registro("fecha3") = FormatDateTime(drRecordSet("Emision").ToString, DateFormat.ShortDate)
                        registro("fecha4") = FormatDateTime(drRecordSet("Pago").ToString, DateFormat.ShortDate)
                        registro("numero4") = Convert.ToDouble(drRecordSet("Importe").ToString)

                        Acum = Acum + Convert.ToDouble(drRecordSet("Importe").ToString)

                        registro("numero5") = Acum

                        tabla.Rows.Add(registro)
                    End If

                Loop
            End If

            If exis = False Then
                Exit Sub
            End If

            dts.Tables.Add(tabla)



            Dim mi_CryResumen As New CrValoresCartera()
            mi_CryResumen.SetDataSource(dts.Tables("ReportesGenericos"))

            Dim miForma As New Form1000()
            miForma.CrvReportes.ReportSource = mi_CryResumen
            miForma.Show()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

End Class

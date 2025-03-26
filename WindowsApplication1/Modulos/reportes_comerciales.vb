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
Module reportes_comerciales
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Public Sub impresion_presupuesto(ByVal Numero As Double)

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

            Dim e As Boolean = False
            Dim nom_reponsable As String = ""

            Dim Sql As String = "Select * From Presupuestos WHERE (PresupuestoNro= " & Numero & ") And (Estado=0) Order by Orden"
            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                Do While drRecordSet.Read


                    If e = False Then
                        nom_reponsable = parametroSistema(2, Val(drRecordSet("TipoResponsable").ToString))
                        e = True
                    End If
                    registro = tabla.NewRow

                    registro("fecha1") = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)
                    registro("numero1") = Convert.ToDouble(drRecordSet("PresupuestoNro").ToString)
                    registro("literal7") = drRecordSet("Documento").ToString
                    registro("literal2") = nom_reponsable
                    registro("numero3") = Convert.ToDouble(drRecordSet("Cuit").ToString)
                    registro("numero4") = Convert.ToDouble(drRecordSet("Cliente").ToString)
                    registro("literal3") = drRecordSet("RazonSocial").ToString

                    If drRecordSet("Domicilio").ToString.Trim = "" Then
                        registro("literal4") = "Santa Rosa. La Pampa"
                    Else
                        registro("literal4") = drRecordSet("Domicilio").ToString
                    End If

                    registro("numero5") = Convert.ToByte(drRecordSet("Lista").ToString)
                    registro("literal5") = drRecordSet("Codigo").ToString
                    registro("literal6") = drRecordSet("Detalle").ToString
                    registro("numero6") = Convert.ToDouble(drRecordSet("Precio").ToString)
                    registro("numero7") = Convert.ToDouble(drRecordSet("Cantidad").ToString)
                    registro("numero8") = Convert.ToDouble(drRecordSet("SubTotal").ToString)
                    registro("numero9") = Convert.ToDouble(drRecordSet("Dsto").ToString)
                    registro("numero10") = Convert.ToDouble(drRecordSet("Total").ToString)
                    registro("numero2") = Convert.ToDouble(drRecordSet("TotalOperacion").ToString)
                    registro("literal8") = drRecordSet("Observacion").ToString

                    registro("Numero11") = Convert.ToDouble(drRecordSet("DstoGenerAplic").ToString)
                    registro("Numero12") = Convert.ToDouble(drRecordSet("ImpDstoGenerAplic").ToString)
                    registro("Numero13") = Convert.ToDouble(drRecordSet("ImpConDstoGenerAplic").ToString)


                    tabla.Rows.Add(registro)

                Loop
            End If

            If e = False Then
                Exit Sub
            End If

            dts.Tables.Add(tabla)



            Dim mi_CryResumen As New CrPresupuesto()
            mi_CryResumen.SetDataSource(dts.Tables("ReportesGenericos"))

            Dim miForma As New Form1000()
            miForma.CrvReportes.ReportSource = mi_CryResumen
            miForma.ShowDialog()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
    Public Sub impresion_remito(ByVal Numero As Double)

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

            Dim e As Boolean = False
            Dim nom_reponsable As String = ""

            Dim Sql As String = "Select * From Remitos WHERE (RemitoNro= " & Numero & ") And (Estado=0) Order by Orden"
            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                Do While drRecordSet.Read


                    If e = False Then
                        nom_reponsable = parametroSistema(2, Val(drRecordSet("TipoResponsable").ToString))
                        e = True
                    End If
                    registro = tabla.NewRow

                    registro("fecha1") = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)
                    registro("numero1") = Convert.ToDouble(drRecordSet("RemitoNro").ToString)
                    registro("literal7") = drRecordSet("Documento").ToString
                    registro("literal2") = nom_reponsable
                    registro("numero3") = Convert.ToDouble(drRecordSet("Cuit").ToString)
                    registro("numero4") = Convert.ToDouble(drRecordSet("Cliente").ToString)
                    registro("literal3") = drRecordSet("RazonSocial").ToString

                    If drRecordSet("Domicilio").ToString.Trim = "" Then
                        registro("literal4") = "Santa Rosa. La Pampa"
                    Else
                        registro("literal4") = drRecordSet("Domicilio").ToString
                    End If

                    registro("numero5") = Convert.ToByte(drRecordSet("Lista").ToString)
                    registro("literal5") = drRecordSet("Codigo").ToString
                    registro("literal6") = drRecordSet("Detalle").ToString
                    registro("numero6") = Convert.ToDouble(drRecordSet("Precio").ToString)
                    registro("numero7") = Convert.ToDouble(drRecordSet("Cantidad").ToString)
                    registro("numero8") = Convert.ToDouble(drRecordSet("SubTotal").ToString)
                    registro("numero9") = Convert.ToDouble(drRecordSet("Dsto").ToString)
                    registro("numero10") = Convert.ToDouble(drRecordSet("Total").ToString)
                    registro("numero2") = Convert.ToDouble(drRecordSet("TotalOperacion").ToString)
                    registro("literal8") = drRecordSet("Observacion").ToString

                    registro("Numero11") = Convert.ToDouble(drRecordSet("DstoGenerAplic").ToString)
                    registro("Numero12") = Convert.ToDouble(drRecordSet("ImpDstoGenerAplic").ToString)
                    registro("Numero13") = Convert.ToDouble(drRecordSet("ImpConDstoGenerAplic").ToString)


                    tabla.Rows.Add(registro)

                Loop
            End If

            If e = False Then
                Exit Sub
            End If

            dts.Tables.Add(tabla)



            Dim mi_CryResumen As New CrRemito()
            mi_CryResumen.SetDataSource(dts.Tables("ReportesGenericos"))

            Dim miForma As New Form1000()
            miForma.CrvReportes.ReportSource = mi_CryResumen
            miForma.ShowDialog()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
    Public Sub impresion_recibos(ByVal Numero As String, ByVal Cliente As Double, ByRef Largo As Boolean)

        Dim dts As New DataSet

        Try
            Dim tabla As DataTable
            Dim campo As DataColumn
            Dim registro As DataRow
            tabla = New DataTable("ReportesRecibos")

            campo = New DataColumn("EncFecha1", GetType(System.DateTime))
            campo.DefaultValue = Nothing
            tabla.Columns.Add(campo)
            campo = New DataColumn("EncLit1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EncLit2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EncLit3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EncLit4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EncLit5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Efectivo", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Cheques", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Transferencia", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("IdTarjeta", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Tarjeta", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)


            'Comprobantes

            campo = New DataColumn("ComFec1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom1", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag1", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)


            campo = New DataColumn("ComFec2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom2", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag2", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom3", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag3", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom4", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag4", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom5", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag5", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom6", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag6", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom7", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag7", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom8", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag8", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom9", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag9", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom10", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag10", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            'Cuerpo Valores

            campo = New DataColumn("ValIdBco1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro1", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp1", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro2", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp2", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro3", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp3", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro4", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp4", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro5", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp5", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro6", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp6", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro7", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp7", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro8", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp8", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro9", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp9", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro10", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp10", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Pie1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)


            Dim d1 As Double = 0
            Dim d2 As String = ""
            Dim d3 As String = ""
            Dim d4 As Double = 0
            Dim d5 As Double = 0
            Dim d6 As Double = 0
            Dim d7 As Double = 0
            Dim d8 As Byte = 0


            Dim d9 As String = ""
            Dim d10 As String = ""
            Dim d11 As Byte = 0
            Dim d12 As String = ""
            Dim d13 As String = ""
            Dim d14 As Double = 0
            Dim nom_reponsable As String = " "
            Dim e As Boolean = False


            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim Sql As String = "Select * From Recibos WHERE (Cliente= " & Cliente & ") And (Recibo= '" & Numero & "') And (Letra='R') And (Estado=0) "
            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    d1 = Convert.ToDouble(drRecordSet("Cliente").ToString)
                    d2 = drRecordSet("Recibo").ToString
                    d3 = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)
                    d4 = Convert.ToDouble(drRecordSet("Efectivo").ToString)
                    d5 = Convert.ToDouble(drRecordSet("Cheques").ToString)
                    d6 = Convert.ToDouble(drRecordSet("Tarjeta").ToString)
                    d7 = Convert.ToDouble(drRecordSet("Transferencia").ToString)
                    d8 = Convert.ToByte(drRecordSet("IdTarjeta").ToString)

                    d14 = Convert.ToDouble(drRecordSet("Efectivo").ToString) + Convert.ToDouble(drRecordSet("Cheques").ToString) + _
                           Convert.ToDouble(drRecordSet("Tarjeta").ToString) + Convert.ToDouble(drRecordSet("Transferencia").ToString)

                    e = True

                End If
            End If

            drRecordSet.Close()

            If e = False Then
                Exit Sub
            End If

            d13 = ""

            Dim xEntero As Double
            Dim xDecimal As Double

            xDecimal = Math.Round(d14 - Int(d14), 2)
            xEntero = Int(d14)

            If xDecimal <> 0 Then
                d13 = Letras(Math.Round(d14, 2)) & " centavos.- - - - - - - - - -"
            Else
                d13 = Letras(Math.Round(d14, 2)) & " .- - - - - - - - - -"
            End If
            'If xDecimal = 0 Then
            '    xPagareImporteLetra = Letras(xEntero)
            'Else
            '    xPagareImporteLetra = Letras(xEntero) & " con " & Letras(xDecimal) & " centavos.-"
            'End If


            Call datos_de_Cliente(d1, d9, d10, d11, d12)
            If d11 <> 0 Then
                nom_reponsable = parametroSistema(2, d11)
            End If


            'Comienza a Registrar datos del Recibo

            registro = tabla.NewRow

            registro("EncFecha1") = FormatDateTime(d3, DateFormat.ShortDate)
            registro("EncLit1") = Numero
            registro("EncLit2") = d9
            registro("EncLit3") = d10
            registro("EncLit4") = nom_reponsable
            registro("EncLit5") = d12
            registro("Pie1") = d13


            registro("Efectivo") = d4
            registro("Cheques") = d5
            registro("Tarjeta") = d6
            registro("Transferencia") = d7
            If d8 <> 0 And d6 <> 0 Then
                registro("IdTarjeta") = parametroSistema(9, d8)
            Else
                registro("IdTarjeta") = " "
            End If


            Dim elementos As Integer = 1


            Sql = "Select * From Cancelaciones_corriente_clientes WHERE (Cliente= " & Cliente & ") And (NumeroRecibo= '" & Numero & "') And (LetraRecibo='R') And (Estado=0) "
            Dim cmdRecordSet_1 As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet_1 As OleDbDataReader = cmdRecordSet_1.ExecuteReader
            If drRecordSet_1.HasRows Then 'Tiene filas
                Do While drRecordSet_1.Read
                    If elementos = 1 Then
                        registro("ComFec1") = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                        If Val(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                            registro("ComTip1") = "FA"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                            registro("ComTip1") = "ND"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                            registro("ComTip1") = "NC"
                        End If
                        registro("ComLet1") = drRecordSet_1("LetraComprobante").ToString
                        registro("ComNro1") = drRecordSet_1("NumeroComprobante").ToString
                        registro("ComImpCom1") = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                        registro("ComImpPag1") = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    End If
                    If elementos = 2 Then
                        registro("ComFec2") = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                            registro("ComTip2") = "FA"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                            registro("ComTip2") = "ND"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                            registro("ComTip2") = "NC"
                        End If
                        registro("ComLet2") = drRecordSet_1("LetraComprobante").ToString
                        registro("ComNro2") = drRecordSet_1("NumeroComprobante").ToString
                        registro("ComImpCom2") = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                        registro("ComImpPag2") = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    End If
                    If elementos = 3 Then
                        registro("ComFec3") = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                            registro("ComTip3") = "FA"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                            registro("ComTip3") = "ND"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                            registro("ComTip3") = "NC"
                        End If
                        registro("ComLet3") = drRecordSet_1("LetraComprobante").ToString
                        registro("ComNro3") = drRecordSet_1("NumeroComprobante").ToString
                        registro("ComImpCom3") = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                        registro("ComImpPag3") = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    End If
                    If elementos = 4 Then
                        registro("ComFec4") = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                            registro("ComTip4") = "FA"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                            registro("ComTip4") = "ND"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                            registro("ComTip4") = "NC"
                        End If
                        registro("ComLet4") = drRecordSet_1("LetraComprobante").ToString
                        registro("ComNro4") = drRecordSet_1("NumeroComprobante").ToString
                        registro("ComImpCom4") = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                        registro("ComImpPag4") = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    End If
                    If elementos = 5 Then
                        registro("ComFec5") = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                            registro("ComTip5") = "FA"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                            registro("ComTip5") = "ND"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                            registro("ComTip5") = "NC"
                        End If
                        registro("ComLet5") = drRecordSet_1("LetraComprobante").ToString
                        registro("ComNro5") = drRecordSet_1("NumeroComprobante").ToString
                        registro("ComImpCom5") = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                        registro("ComImpPag5") = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    End If
                    If elementos = 6 Then
                        registro("ComFec6") = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                            registro("ComTip6") = "FA"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                            registro("ComTip6") = "ND"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                            registro("ComTip6") = "NC"
                        End If
                        registro("ComLet6") = drRecordSet_1("LetraComprobante").ToString
                        registro("ComNro6") = drRecordSet_1("NumeroComprobante").ToString
                        registro("ComImpCom6") = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                        registro("ComImpPag6") = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    End If
                    If elementos = 7 Then
                        registro("ComFec7") = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                            registro("ComTip7") = "FA"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                            registro("ComTip7") = "ND"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                            registro("ComTip7") = "NC"
                        End If
                        registro("ComLet7") = drRecordSet_1("LetraComprobante").ToString
                        registro("ComNro7") = drRecordSet_1("NumeroComprobante").ToString
                        registro("ComImpCom7") = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                        registro("ComImpPag7") = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    End If
                    If elementos = 8 Then
                        registro("ComFec8") = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                            registro("ComTip8") = "FA"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                            registro("ComTip8") = "ND"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                            registro("ComTip8") = "NC"
                        End If
                        registro("ComLet8") = drRecordSet_1("LetraComprobante").ToString
                        registro("ComNro8") = drRecordSet_1("NumeroComprobante").ToString
                        registro("ComImpCom8") = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                        registro("ComImpPag8") = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    End If
                    If elementos = 9 Then
                        registro("ComFec9") = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                            registro("ComTip9") = "FA"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                            registro("ComTip9") = "ND"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                            registro("ComTip9") = "NC"
                        End If
                        registro("ComLet9") = drRecordSet_1("LetraComprobante").ToString
                        registro("ComNro9") = drRecordSet_1("NumeroComprobante").ToString
                        registro("ComImpCom9") = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                        registro("ComImpPag9") = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    End If
                    If elementos = 10 Then
                        registro("ComFec1") = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                            registro("ComTip10") = "FA"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                            registro("ComTip10") = "ND"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                            registro("ComTip10") = "NC"
                        End If
                        registro("ComLet10") = drRecordSet_1("LetraComprobante").ToString
                        registro("ComNro10") = drRecordSet_1("NumeroComprobante").ToString
                        registro("ComImpCom10") = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                        registro("ComImpPag10") = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    End If
                    elementos = elementos + 1
                Loop
            End If

            drRecordSet_1.Close()


            If elementos > 10 Then
                Largo = True
                Exit Sub
            End If

            elementos = 1

            Sql = "Select * From Valores_recibidos_ventas WHERE (Cliente= " & Cliente & ") And (NumeroComprobante= '" & Numero & "') And (LetraComprobante='R') And (Tipocomprobante=5) And (Estado=0) "
            Dim cmdRecordSet_2 As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet_2 As OleDbDataReader = cmdRecordSet_2.ExecuteReader
            If drRecordSet_2.HasRows Then 'Tiene filas
                Do While drRecordSet_2.Read
                    If elementos = 1 Then
                        registro("ValIdBco1") = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        registro("ValBco1") = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                        registro("ValFecEmi1") = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                        registro("ValFecPag1") = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                        registro("ValNro1") = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                        registro("ValImp1") = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    End If
                    If elementos = 2 Then
                        registro("ValIdBco2") = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        registro("ValBco2") = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                        registro("ValFecEmi2") = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                        registro("ValFecPag2") = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                        registro("ValNro2") = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                        registro("ValImp2") = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    End If
                    If elementos = 3 Then
                        registro("ValIdBco3") = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        registro("ValBco3") = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                        registro("ValFecEmi3") = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                        registro("ValFecPag3") = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                        registro("ValNro3") = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                        registro("ValImp3") = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    End If
                    If elementos = 4 Then
                        registro("ValIdBco4") = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        registro("ValBco4") = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                        registro("ValFecEmi4") = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                        registro("ValFecPag4") = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                        registro("ValNro4") = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                        registro("ValImp4") = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    End If
                    If elementos = 5 Then
                        registro("ValIdBco5") = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        registro("ValBco5") = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                        registro("ValFecEmi5") = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                        registro("ValFecPag5") = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                        registro("ValNro5") = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                        registro("ValImp5") = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    End If
                    If elementos = 6 Then
                        registro("ValIdBco6") = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        registro("ValBco6") = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                        registro("ValFecEmi6") = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                        registro("ValFecPag6") = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                        registro("ValNro6") = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                        registro("ValImp6") = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    End If
                    If elementos = 7 Then
                        registro("ValIdBco7") = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        registro("ValBco7") = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                        registro("ValFecEmi7") = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                        registro("ValFecPag7") = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                        registro("ValNro7") = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                        registro("ValImp7") = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    End If
                    If elementos = 8 Then
                        registro("ValIdBco8") = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        registro("ValBco8") = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                        registro("ValFecEmi8") = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                        registro("ValFecPag8") = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                        registro("ValNro8") = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                        registro("ValImp8") = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    End If
                    If elementos = 9 Then
                        registro("ValIdBco9") = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        registro("ValBco9") = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                        registro("ValFecEmi9") = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                        registro("ValFecPag9") = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                        registro("ValNro9") = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                        registro("ValImp9") = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    End If
                    If elementos = 10 Then
                        registro("ValIdBco10") = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        registro("ValBco10") = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                        registro("ValFecEmi10") = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                        registro("ValFecPag10") = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                        registro("ValNro10") = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                        registro("ValImp10") = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    End If

                    elementos = elementos + 1

                Loop
            End If

            drRecordSet_2.Close()

            tabla.Rows.Add(registro)
            dts.Tables.Add(tabla)


            If elementos > 10 Then
                Largo = True
                Exit Sub
            End If


            Dim mi_CryResumen As New CrRecibos()
            mi_CryResumen.SetDataSource(dts.Tables("ReportesRecibos"))

            Dim miForma As New Form1000()
            miForma.CrvReportes.ReportSource = mi_CryResumen
            miForma.ShowDialog()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub datos_de_Cliente(ByVal d1 As Double, ByRef d9 As String, ByRef d10 As String, ByRef d11 As Byte, ByRef d12 As String)

        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If
            Dim cmdTemp As New OleDbCommand("Select * from Clientes where Numero= " & d1 & " ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    d9 = drTemp("RazonSocial").ToString()
                    d10 = drTemp("Domicilio").ToString.Trim & " " & drTemp("Ciudad").ToString.Trim & " " & drTemp("Provincia").ToString.Trim
                    d11 = Convert.ToByte(drTemp("Responsable").ToString())
                    d12 = Convert.ToDouble(drTemp("Cuit").ToString())
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
        End Try
    End Sub
    Private Function Letras(ByVal numero As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras As String
        Dim entero As String
        Dim dec As String
        Dim flag As String

        entero = ""
        dec = ""
        flag = ""
        palabras = ""

        '********Declara variables de tipo entero***********
        Dim num, x, y As Integer

        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "cien "
                                Else
                                    palabras = palabras & "ciento "
                                End If
                            Case "2"
                                palabras = palabras & "doscientos "
                            Case "3"
                                palabras = palabras & "trescientos "
                            Case "4"
                                palabras = palabras & "cuatrocientos "
                            Case "5"
                                palabras = palabras & "quinientos "
                            Case "6"
                                palabras = palabras & "seiscientos "
                            Case "7"
                                palabras = palabras & "setecientos "
                            Case "8"
                                palabras = palabras & "ochocientos "
                            Case "9"
                                palabras = palabras & "novecientos "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "diez "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "once "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "doce "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "trece "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "catorce "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "quince "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "dieci"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "treinta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cuarenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cincuenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "sesenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "setenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "ochenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "noventa "
                                    flag = "S"
                                Else
                                    palabras = palabras & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "uno "
                                    Else
                                        palabras = palabras & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "dos "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "tres "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "cuatro "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "cinco "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "seis "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "siete "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "ocho "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "nueve "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                    (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                    Len(entero) <= 6) Then palabras = palabras & "mil "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "millón "
                    Else
                        palabras = palabras & "millones "
                    End If
                End If
            Next y

            '**********Une la parte entera y la parte decimal*************
            If dec <> "" Then
                Letras = palabras & "con " & dec
            Else
                Letras = palabras
            End If
        Else
            Letras = ""
        End If
    End Function
    Public Sub impresion_recibos_proveedores(ByVal Numero As String, ByVal Cliente As Double, ByRef largo As Boolean)

        Dim dts As New DataSet

        Try
            Dim tabla As DataTable
            Dim campo As DataColumn
            Dim registro As DataRow
            tabla = New DataTable("ReportesRecibos")

            campo = New DataColumn("EncFecha1", GetType(System.DateTime))
            campo.DefaultValue = Nothing
            tabla.Columns.Add(campo)
            campo = New DataColumn("EncLit1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EncLit2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EncLit3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EncLit4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EncLit5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Efectivo", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Cheques", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Transferencia", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("IdTarjeta", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Tarjeta", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Descuentos", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Devoluciones", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Retenciones", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            'Comprobantes

            campo = New DataColumn("ComFec1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom1", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag1", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)


            campo = New DataColumn("ComFec2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom2", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag2", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom3", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag3", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom4", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag4", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom5", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag5", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom6", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag6", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom7", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag7", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom8", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag8", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom9", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag9", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom10", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag10", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            'Cuerpo Valores

            campo = New DataColumn("ValIdBco1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro1", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp1", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro2", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp2", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro3", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp3", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro4", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp4", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro5", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp5", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro6", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp6", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro7", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp7", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro8", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp8", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro9", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp9", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro10", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp10", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("TotalRecibo", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Pie1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)


            Dim d1 As Double = 0
            Dim d2 As String = ""
            Dim d3 As String = ""
            Dim d4 As Double = 0
            Dim d5 As Double = 0
            Dim d6 As Double = 0
            Dim d7 As Double = 0
            Dim d8 As Byte = 0


            Dim d9 As String = ""
            Dim d10 As String = ""
            Dim d11 As Byte = 0
            Dim d12 As String = ""
            Dim d13 As String = ""
            Dim d14 As Double = 0
            Dim d15 As Double = 0
            Dim d16 As Double = 0
            Dim d17 As Double = 0
            Dim d18 As Double = 0

            Dim nom_reponsable As String = " "
            Dim e As Boolean = False


            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim Sql As String = "Select * From Recibos_proveedores WHERE (Cliente= " & Cliente & ") And (Recibo= '" & Numero & "') And (Letra='R') And (Estado=0) "
            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    d1 = Convert.ToDouble(drRecordSet("Cliente").ToString)
                    d2 = drRecordSet("Recibo").ToString
                    d3 = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)
                    d4 = Convert.ToDouble(drRecordSet("Efectivo").ToString)
                    d5 = Convert.ToDouble(drRecordSet("Cheques").ToString)
                    d6 = Convert.ToDouble(drRecordSet("Tarjeta").ToString)
                    d7 = Convert.ToDouble(drRecordSet("Transferencia").ToString)
                    d8 = Convert.ToByte(drRecordSet("IdTarjeta").ToString)

                    d14 = Convert.ToDouble(drRecordSet("Efectivo").ToString) + Convert.ToDouble(drRecordSet("Cheques").ToString) + _
                           Convert.ToDouble(drRecordSet("Tarjeta").ToString) + Convert.ToDouble(drRecordSet("Transferencia").ToString)

                    d15 = Convert.ToDouble(drRecordSet("Descuentos").ToString)
                    d16 = Convert.ToDouble(drRecordSet("Devoluciones").ToString)
                    d17 = Convert.ToDouble(drRecordSet("RetencionesPago").ToString)

                    d18 = d14 + d15 + d16 + d17
                    e = True

                End If
            End If

            drRecordSet.Close()

            If e = False Then
                Exit Sub
            End If

            d13 = ""

            Dim xEntero As Double
            Dim xDecimal As Double

            xDecimal = Math.Round(d18 - Int(d18), 2)
            xEntero = Int(d18)

            If xDecimal <> 0 Then
                d13 = Letras(Math.Round(d18, 2)) & " centavos.- - - - - - - - - -"
            Else
                d13 = Letras(Math.Round(d18, 2)) & " .- - - - - - - - - -"
            End If
            'If xDecimal = 0 Then
            '    xPagareImporteLetra = Letras(xEntero)
            'Else
            '    xPagareImporteLetra = Letras(xEntero) & " con " & Letras(xDecimal) & " centavos.-"
            'End If


            Call datos_de_proveedor(d1, d9, d10, d11, d12)
            If d11 <> 0 Then
                nom_reponsable = parametroSistema(2, d11)
            End If


            'Comienza a Registrar datos del Recibo

            registro = tabla.NewRow

            registro("EncFecha1") = FormatDateTime(d3, DateFormat.ShortDate)
            registro("EncLit1") = Numero
            registro("EncLit2") = d9
            registro("EncLit3") = d10
            registro("EncLit4") = nom_reponsable
            registro("EncLit5") = d12
            registro("Pie1") = d13
            registro("TotalRecibo") = d18


            registro("Efectivo") = d4
            registro("Cheques") = d5
            registro("Tarjeta") = d6
            registro("Transferencia") = d7
            If d8 <> 0 And d6 <> 0 Then
                registro("IdTarjeta") = parametroSistema(9, d8)
            Else
                registro("IdTarjeta") = " "
            End If
            registro("Descuentos") = d15
            registro("Devoluciones") = d16
            registro("Retenciones") = d17


            Dim elementos As Integer = 1


            Sql = "Select * From Cancelaciones_corriente_proveedores WHERE (Cliente= " & Cliente & ") And (NumeroRecibo= '" & Numero & "') And (LetraRecibo='R') And (Estado=0) "
            Dim cmdRecordSet_1 As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet_1 As OleDbDataReader = cmdRecordSet_1.ExecuteReader
            If drRecordSet_1.HasRows Then 'Tiene filas
                Do While drRecordSet_1.Read
                    If elementos = 1 Then
                        registro("ComFec1") = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                        If Val(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                            registro("ComTip1") = "FA"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                            registro("ComTip1") = "ND"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                            registro("ComTip1") = "NC"
                        End If
                        registro("ComLet1") = drRecordSet_1("LetraComprobante").ToString
                        registro("ComNro1") = drRecordSet_1("NumeroComprobante").ToString
                        registro("ComImpCom1") = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                        registro("ComImpPag1") = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    End If
                    If elementos = 2 Then
                        registro("ComFec2") = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                            registro("ComTip2") = "FA"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                            registro("ComTip2") = "ND"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                            registro("ComTip2") = "NC"
                        End If
                        registro("ComLet2") = drRecordSet_1("LetraComprobante").ToString
                        registro("ComNro2") = drRecordSet_1("NumeroComprobante").ToString
                        registro("ComImpCom2") = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                        registro("ComImpPag2") = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    End If
                    If elementos = 3 Then
                        registro("ComFec3") = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                            registro("ComTip3") = "FA"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                            registro("ComTip3") = "ND"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                            registro("ComTip3") = "NC"
                        End If
                        registro("ComLet3") = drRecordSet_1("LetraComprobante").ToString
                        registro("ComNro3") = drRecordSet_1("NumeroComprobante").ToString
                        registro("ComImpCom3") = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                        registro("ComImpPag3") = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    End If
                    If elementos = 4 Then
                        registro("ComFec4") = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                            registro("ComTip4") = "FA"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                            registro("ComTip4") = "ND"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                            registro("ComTip4") = "NC"
                        End If
                        registro("ComLet4") = drRecordSet_1("LetraComprobante").ToString
                        registro("ComNro4") = drRecordSet_1("NumeroComprobante").ToString
                        registro("ComImpCom4") = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                        registro("ComImpPag4") = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    End If
                    If elementos = 5 Then
                        registro("ComFec5") = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                            registro("ComTip5") = "FA"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                            registro("ComTip5") = "ND"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                            registro("ComTip5") = "NC"
                        End If
                        registro("ComLet5") = drRecordSet_1("LetraComprobante").ToString
                        registro("ComNro5") = drRecordSet_1("NumeroComprobante").ToString
                        registro("ComImpCom5") = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                        registro("ComImpPag5") = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    End If
                    If elementos = 6 Then
                        registro("ComFec6") = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                            registro("ComTip6") = "FA"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                            registro("ComTip6") = "ND"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                            registro("ComTip6") = "NC"
                        End If
                        registro("ComLet6") = drRecordSet_1("LetraComprobante").ToString
                        registro("ComNro6") = drRecordSet_1("NumeroComprobante").ToString
                        registro("ComImpCom6") = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                        registro("ComImpPag6") = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    End If
                    If elementos = 7 Then
                        registro("ComFec7") = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                            registro("ComTip7") = "FA"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                            registro("ComTip7") = "ND"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                            registro("ComTip7") = "NC"
                        End If
                        registro("ComLet7") = drRecordSet_1("LetraComprobante").ToString
                        registro("ComNro7") = drRecordSet_1("NumeroComprobante").ToString
                        registro("ComImpCom7") = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                        registro("ComImpPag7") = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    End If
                    If elementos = 8 Then
                        registro("ComFec8") = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                            registro("ComTip8") = "FA"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                            registro("ComTip8") = "ND"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                            registro("ComTip8") = "NC"
                        End If
                        registro("ComLet8") = drRecordSet_1("LetraComprobante").ToString
                        registro("ComNro8") = drRecordSet_1("NumeroComprobante").ToString
                        registro("ComImpCom8") = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                        registro("ComImpPag8") = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    End If
                    If elementos = 9 Then
                        registro("ComFec9") = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                            registro("ComTip9") = "FA"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                            registro("ComTip9") = "ND"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                            registro("ComTip9") = "NC"
                        End If
                        registro("ComLet9") = drRecordSet_1("LetraComprobante").ToString
                        registro("ComNro9") = drRecordSet_1("NumeroComprobante").ToString
                        registro("ComImpCom9") = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                        registro("ComImpPag9") = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    End If
                    If elementos = 10 Then
                        registro("ComFec1") = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                            registro("ComTip10") = "FA"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                            registro("ComTip10") = "ND"
                        End If
                        If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                            registro("ComTip10") = "NC"
                        End If
                        registro("ComLet10") = drRecordSet_1("LetraComprobante").ToString
                        registro("ComNro10") = drRecordSet_1("NumeroComprobante").ToString
                        registro("ComImpCom10") = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                        registro("ComImpPag10") = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    End If
                    elementos = elementos + 1
                Loop
            End If

            drRecordSet_1.Close()

            If elementos > 10 Then
                largo = True
                Exit Sub
            End If

            elementos = 1

            Sql = "Select * From Valores_Emitidos WHERE (Cliente= " & Cliente & ") And (NumeroComprobante= '" & Numero & "') And (LetraComprobante='R') And (Tipocomprobante=5) And (Estado=0) "
            Dim cmdRecordSet_2 As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet_2 As OleDbDataReader = cmdRecordSet_2.ExecuteReader
            If drRecordSet_2.HasRows Then 'Tiene filas
                Do While drRecordSet_2.Read
                    If elementos = 1 Then
                        If Val(drRecordSet_2("ChequeTercero").ToString) = 1 Then
                            registro("ValIdBco1") = "*" & Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        Else
                            registro("ValIdBco1") = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        End If

                        registro("ValBco1") = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                        registro("ValFecEmi1") = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                        registro("ValFecPag1") = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                        registro("ValNro1") = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                        registro("ValImp1") = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    End If

                    If elementos = 2 Then
                        If Val(drRecordSet_2("ChequeTercero").ToString) = 1 Then
                            registro("ValIdBco2") = "*" & Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        Else
                            registro("ValIdBco2") = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        End If

                        registro("ValBco2") = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                        registro("ValFecEmi2") = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                        registro("ValFecPag2") = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                        registro("ValNro2") = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                        registro("ValImp2") = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    End If

                    If elementos = 3 Then
                        If Val(drRecordSet_2("ChequeTercero").ToString) = 1 Then
                            registro("ValIdBco3") = "*" & Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        Else
                            registro("ValIdBco3") = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        End If


                        registro("ValBco3") = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                        registro("ValFecEmi3") = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                        registro("ValFecPag3") = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                        registro("ValNro3") = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                        registro("ValImp3") = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    End If

                    If elementos = 4 Then
                        If Val(drRecordSet_2("ChequeTercero").ToString) = 1 Then
                            registro("ValIdBco4") = "*" & Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        Else
                            registro("ValIdBco4") = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        End If

                        registro("ValBco4") = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                        registro("ValFecEmi4") = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                        registro("ValFecPag4") = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                        registro("ValNro4") = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                        registro("ValImp4") = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    End If

                    If elementos = 5 Then
                        If Val(drRecordSet_2("ChequeTercero").ToString) = 1 Then
                            registro("ValIdBco5") = "*" & Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        Else
                            registro("ValIdBco5") = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        End If

                        registro("ValBco5") = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                        registro("ValFecEmi5") = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                        registro("ValFecPag5") = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                        registro("ValNro5") = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                        registro("ValImp5") = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    End If

                    If elementos = 6 Then
                        If Val(drRecordSet_2("ChequeTercero").ToString) = 1 Then
                            registro("ValIdBco6") = "*" & Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        Else
                            registro("ValIdBco6") = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        End If

                        registro("ValBco6") = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                        registro("ValFecEmi6") = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                        registro("ValFecPag6") = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                        registro("ValNro6") = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                        registro("ValImp6") = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    End If

                    If elementos = 7 Then
                        If Val(drRecordSet_2("ChequeTercero").ToString) = 1 Then
                            registro("ValIdBco7") = "*" & Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        Else
                            registro("ValIdBco7") = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        End If

                        registro("ValBco7") = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                        registro("ValFecEmi7") = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                        registro("ValFecPag7") = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                        registro("ValNro7") = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                        registro("ValImp7") = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    End If

                    If elementos = 8 Then
                        If Val(drRecordSet_2("ChequeTercero").ToString) = 1 Then
                            registro("ValIdBco8") = "*" & Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        Else
                            registro("ValIdBco8") = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        End If

                        registro("ValBco8") = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                        registro("ValFecEmi8") = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                        registro("ValFecPag8") = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                        registro("ValNro8") = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                        registro("ValImp8") = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    End If

                    If elementos = 9 Then
                        If Val(drRecordSet_2("ChequeTercero").ToString) = 1 Then
                            registro("ValIdBco9") = "*" & Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        Else
                            registro("ValIdBco9") = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        End If

                        registro("ValBco9") = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                        registro("ValFecEmi9") = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                        registro("ValFecPag9") = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                        registro("ValNro9") = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                        registro("ValImp9") = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    End If

                    If elementos = 10 Then
                        If Val(drRecordSet_2("ChequeTercero").ToString) = 1 Then
                            registro("ValIdBco10") = "*" & Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        Else
                            registro("ValIdBco10") = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                        End If

                        registro("ValBco10") = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                        registro("ValFecEmi10") = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                        registro("ValFecPag10") = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                        registro("ValNro10") = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                        registro("ValImp10") = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    End If

                    elementos = elementos + 1

                Loop
            End If

            drRecordSet_2.Close()

            If elementos > 10 Then
                largo = True
                Exit Sub
            End If


            tabla.Rows.Add(registro)


            dts.Tables.Add(tabla)



            Dim mi_CryResumen As New CrRecibosProveedores()
            mi_CryResumen.SetDataSource(dts.Tables("ReportesRecibos"))

            Dim miForma As New Form1000()
            miForma.CrvReportes.ReportSource = mi_CryResumen
            miForma.ShowDialog()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
    Private Sub datos_de_proveedor(ByVal d1 As Double, ByRef d9 As String, ByRef d10 As String, ByRef d11 As Byte, ByRef d12 As String)

        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If
            Dim cmdTemp As New OleDbCommand("Select * from Proveedores where Numero= " & d1 & " ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    d9 = drTemp("RazonSocial").ToString()
                    d10 = drTemp("Domicilio").ToString.Trim & " " & drTemp("Ciudad").ToString.Trim & " " & drTemp("Provincia").ToString.Trim
                    d11 = Convert.ToByte(drTemp("Responsable").ToString())
                    d12 = Convert.ToDouble(drTemp("Cuit").ToString())
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
        End Try
    End Sub
    Public Sub impresion_recibos_largo(ByVal Numero As String, ByVal Cliente As Double)


        Dim dts As New DataSet

        Try
            Dim tabla As DataTable
            Dim campo As DataColumn
            Dim registro As DataRow
            tabla = New DataTable("ReportesRecibos")

            campo = New DataColumn("EncFecha1", GetType(System.DateTime))
            campo.DefaultValue = Nothing
            tabla.Columns.Add(campo)
            campo = New DataColumn("EncLit1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EncLit2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EncLit3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EncLit4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EncLit5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Efectivo", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Cheques", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Transferencia", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("IdTarjeta", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Tarjeta", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)


            'Comprobantes

            campo = New DataColumn("ComFec1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom1", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag1", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)


            campo = New DataColumn("ComFec2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom2", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag2", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom3", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag3", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom4", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag4", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom5", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag5", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom6", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag6", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom7", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag7", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom8", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag8", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom9", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag9", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom10", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag10", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            'Cuerpo Valores

            campo = New DataColumn("ValIdBco1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro1", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp1", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro2", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp2", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro3", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp3", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro4", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp4", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro5", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp5", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro6", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp6", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro7", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp7", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro8", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp8", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro9", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp9", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro10", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp10", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Pie1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            Dim m_arr(50, 23) As String
            Dim jx As Byte = 0
            Dim jy As Byte = 0

            For jx = 0 To 50
                For jy = 0 To 23
                    m_arr(jx, jy) = " "
                Next
            Next

            Dim d1 As Double = 0
            Dim d2 As String = ""
            Dim d3 As String = ""
            Dim d4 As Double = 0
            Dim d5 As Double = 0
            Dim d6 As Double = 0
            Dim d7 As Double = 0
            Dim d8 As Byte = 0


            Dim d9 As String = ""
            Dim d10 As String = ""
            Dim d11 As Byte = 0
            Dim d12 As String = ""
            Dim d13 As String = ""
            Dim d14 As Double = 0
            Dim nom_reponsable As String = " "
            Dim e As Boolean = False

            Dim j As Byte = 0


            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim Sql As String = "Select * From Recibos WHERE (Cliente= " & Cliente & ") And (Recibo= '" & Numero & "') And (Letra='R') And (Estado=0) "
            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    d1 = Convert.ToDouble(drRecordSet("Cliente").ToString)
                    d2 = drRecordSet("Recibo").ToString
                    d3 = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)
                    d4 = Convert.ToDouble(drRecordSet("Efectivo").ToString)
                    d5 = Convert.ToDouble(drRecordSet("Cheques").ToString)
                    d6 = Convert.ToDouble(drRecordSet("Tarjeta").ToString)
                    d7 = Convert.ToDouble(drRecordSet("Transferencia").ToString)
                    d8 = Convert.ToByte(drRecordSet("IdTarjeta").ToString)

                    d14 = Convert.ToDouble(drRecordSet("Efectivo").ToString) + Convert.ToDouble(drRecordSet("Cheques").ToString) + _
                           Convert.ToDouble(drRecordSet("Tarjeta").ToString) + Convert.ToDouble(drRecordSet("Transferencia").ToString)

                    e = True

                End If
            End If

            drRecordSet.Close()

            If e = False Then
                Exit Sub
            End If

            d13 = ""

            Dim xEntero As Double
            Dim xDecimal As Double

            xDecimal = Math.Round(d14 - Int(d14), 2)
            xEntero = Int(d14)

            If xDecimal <> 0 Then
                d13 = Letras(Math.Round(d14, 2)) & " centavos.- - - - - - - - - -"
            Else
                d13 = Letras(Math.Round(d14, 2)) & " .- - - - - - - - - -"
            End If
            'If xDecimal = 0 Then
            '    xPagareImporteLetra = Letras(xEntero)
            'Else
            '    xPagareImporteLetra = Letras(xEntero) & " con " & Letras(xDecimal) & " centavos.-"
            'End If


            Call datos_de_Cliente(d1, d9, d10, d11, d12)
            If d11 <> 0 Then
                nom_reponsable = parametroSistema(2, d11)
            End If

            jx = 0

            Sql = "Select * From Cancelaciones_corriente_clientes WHERE (Cliente= " & Cliente & ") And (NumeroRecibo= '" & Numero & "') And (LetraRecibo='R') And (Estado=0) "
            Dim cmdRecordSet_1 As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet_1 As OleDbDataReader = cmdRecordSet_1.ExecuteReader
            If drRecordSet_1.HasRows Then 'Tiene filas
                Do While drRecordSet_1.Read

                    m_arr(jx, 0) = FormatDateTime(d3, DateFormat.ShortDate)
                    m_arr(jx, 1) = Numero
                    m_arr(jx, 2) = d9
                    m_arr(jx, 3) = d10
                    m_arr(jx, 4) = nom_reponsable
                    m_arr(jx, 5) = d12
                    m_arr(jx, 6) = d13


                    m_arr(jx, 7) = d4
                    m_arr(jx, 8) = d5
                    m_arr(jx, 9) = d6
                    m_arr(jx, 10) = d7
                    If d8 <> 0 And d6 <> 0 Then
                        m_arr(jx, 11) = parametroSistema(9, d8)
                    Else
                        m_arr(jx, 11) = " "
                    End If

                    m_arr(jx, 12) = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                    If Val(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                        m_arr(jx, 13) = "FA"
                    End If
                    If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                        m_arr(jx, 13) = "ND"
                    End If
                    If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                        m_arr(jx, 13) = "NC"
                    End If

                    m_arr(jx, 14) = drRecordSet_1("LetraComprobante").ToString
                    m_arr(jx, 15) = drRecordSet_1("NumeroComprobante").ToString
                    m_arr(jx, 16) = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                    m_arr(jx, 17) = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)

                    jx = jx + 1

                   
                Loop
            End If

            drRecordSet_1.Close()

            jx = 0

            Sql = "Select * From Valores_recibidos_ventas WHERE (Cliente= " & Cliente & ") And (NumeroComprobante= '" & Numero & "') And (LetraComprobante='R') And (Tipocomprobante=5) And (Estado=0) "
            Dim cmdRecordSet_2 As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet_2 As OleDbDataReader = cmdRecordSet_2.ExecuteReader
            If drRecordSet_2.HasRows Then 'Tiene filas
                Do While drRecordSet_2.Read

                    m_arr(jx, 0) = FormatDateTime(d3, DateFormat.ShortDate)
                    m_arr(jx, 1) = Numero
                    m_arr(jx, 2) = d9
                    m_arr(jx, 3) = d10
                    m_arr(jx, 4) = nom_reponsable
                    m_arr(jx, 5) = d12
                    m_arr(jx, 6) = d13


                    m_arr(jx, 7) = d4
                    m_arr(jx, 8) = d5
                    m_arr(jx, 9) = d6
                    m_arr(jx, 10) = d7
                    If d8 <> 0 And d6 <> 0 Then
                        m_arr(jx, 11) = parametroSistema(9, d8)
                    Else
                        m_arr(jx, 11) = " "
                    End If

                    m_arr(jx, 18) = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                    m_arr(jx, 19) = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                    m_arr(jx, 20) = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                    m_arr(jx, 21) = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                    m_arr(jx, 22) = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                    m_arr(jx, 23) = Convert.ToDouble(drRecordSet_2("Importe").ToString)

                    jx = jx + 1
 
                Loop
            End If

            drRecordSet_2.Close()


            For jx = 0 To 50

                If m_arr(jx, 12).Trim <> "" Or m_arr(jx, 18).Trim <> "" Then
                    registro = tabla.NewRow

                    registro("EncFecha1") = FormatDateTime(Convert.ToDateTime(m_arr(jx, 0)), DateFormat.ShortDate)
                    registro("EncLit1") = m_arr(jx, 1)
                    registro("EncLit2") = m_arr(jx, 2)
                    registro("EncLit3") = m_arr(jx, 3)
                    registro("EncLit4") = m_arr(jx, 4)
                    registro("EncLit5") = m_arr(jx, 5)
                    registro("Pie1") = m_arr(jx, 6)
                    registro("Efectivo") = m_arr(jx, 7)
                    registro("Cheques") = m_arr(jx, 8)
                    registro("Tarjeta") = m_arr(jx, 9)
                    registro("Transferencia") = m_arr(jx, 10)
                    If d8 <> 0 And d6 <> 0 Then
                        registro("IdTarjeta") = m_arr(jx, 11)
                    Else
                        registro("IdTarjeta") = " "
                    End If

                    If m_arr(jx, 12).Trim <> "" Then
                        registro("ComFec1") = FormatDateTime(Convert.ToDateTime(m_arr(jx, 12)), DateFormat.ShortDate)
                        registro("ComTip1") = m_arr(jx, 13)
                        registro("ComLet1") = m_arr(jx, 14)
                        registro("ComNro1") = m_arr(jx, 15)
                        registro("ComImpCom1") = Convert.ToDouble(m_arr(jx, 16))
                        registro("ComImpPag1") = Convert.ToDouble(m_arr(jx, 17))
                    End If

                    If m_arr(jx, 18).Trim <> "" Then
                        registro("ValIdBco1") = Convert.ToInt16(m_arr(jx, 18))
                        registro("ValBco1") = m_arr(jx, 19)
                        registro("ValFecEmi1") = FormatDateTime(Convert.ToDateTime(m_arr(jx, 20)), DateFormat.ShortDate)
                        registro("ValFecPag1") = FormatDateTime(FormatDateTime(Convert.ToDateTime(m_arr(jx, 21)), DateFormat.ShortDate))
                        registro("ValNro1") = Convert.ToDouble(m_arr(jx, 22))
                        registro("ValImp1") = Convert.ToDouble(m_arr(jx, 23))
                    End If

                    tabla.Rows.Add(registro)
                End If



            Next


            dts.Tables.Add(tabla)



            Dim mi_CryResumen As New CrRecibosLargos()
            mi_CryResumen.SetDataSource(dts.Tables("ReportesRecibos"))

            Dim miForma As New Form1000()
            miForma.CrvReportes.ReportSource = mi_CryResumen
            miForma.ShowDialog()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
    Public Sub impresion_recibos_proveedores_largo(ByVal Numero As String, ByVal Cliente As Double)

        Dim dts As New DataSet

        Try
            Dim tabla As DataTable
            Dim campo As DataColumn
            Dim registro As DataRow
            tabla = New DataTable("ReportesRecibos")

            campo = New DataColumn("EncFecha1", GetType(System.DateTime))
            campo.DefaultValue = Nothing
            tabla.Columns.Add(campo)
            campo = New DataColumn("EncLit1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EncLit2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EncLit3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EncLit4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EncLit5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Efectivo", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Cheques", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Transferencia", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("IdTarjeta", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Tarjeta", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Descuentos", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Devoluciones", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Retenciones", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            'Comprobantes

            campo = New DataColumn("ComFec1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom1", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag1", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)


            campo = New DataColumn("ComFec2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom2", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag2", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom3", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag3", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom4", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag4", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom5", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag5", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom6", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag6", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom7", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag7", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom8", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag8", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom9", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag9", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ComFec10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComTip10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComLet10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComNro10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpCom10", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ComImpPag10", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            'Cuerpo Valores

            campo = New DataColumn("ValIdBco1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro1", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp1", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro2", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp2", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag3", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro3", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp3", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag4", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro4", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp4", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag5", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro5", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp5", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag6", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro6", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp6", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag7", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro7", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp7", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag8", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro8", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp8", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag9", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro9", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp9", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ValIdBco10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValBco10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecEmi10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValFecPag10", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValNro10", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ValImp10", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("TotalRecibo", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Pie1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            Dim m_arr(70, 24) As String
            Dim jx As Byte = 0
            Dim jy As Byte = 0

            For jx = 0 To 70
                For jy = 0 To 24
                    m_arr(jx, jy) = " "
                Next
            Next

            Dim d1 As Double = 0
            Dim d2 As String = ""
            Dim d3 As String = ""
            Dim d4 As Double = 0
            Dim d5 As Double = 0
            Dim d6 As Double = 0
            Dim d7 As Double = 0
            Dim d8 As Byte = 0


            Dim d9 As String = ""
            Dim d10 As String = ""
            Dim d11 As Byte = 0
            Dim d12 As String = ""
            Dim d13 As String = ""
            Dim d14 As Double = 0
            Dim d15 As Double = 0
            Dim d16 As Double = 0
            Dim d17 As Double = 0
            Dim d18 As Double = 0

            Dim nom_reponsable As String = " "
            Dim e As Boolean = False


            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim Sql As String = "Select * From Recibos_proveedores WHERE (Cliente= " & Cliente & ") And (Recibo= '" & Numero & "') And (Letra='R') And (Estado=0) "
            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    d1 = Convert.ToDouble(drRecordSet("Cliente").ToString)
                    d2 = drRecordSet("Recibo").ToString
                    d3 = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)
                    d4 = Convert.ToDouble(drRecordSet("Efectivo").ToString)
                    d5 = Convert.ToDouble(drRecordSet("Cheques").ToString)
                    d6 = Convert.ToDouble(drRecordSet("Tarjeta").ToString)
                    d7 = Convert.ToDouble(drRecordSet("Transferencia").ToString)
                    d8 = Convert.ToByte(drRecordSet("IdTarjeta").ToString)

                    d14 = Convert.ToDouble(drRecordSet("Efectivo").ToString) + Convert.ToDouble(drRecordSet("Cheques").ToString) + _
                           Convert.ToDouble(drRecordSet("Tarjeta").ToString) + Convert.ToDouble(drRecordSet("Transferencia").ToString)

                    d15 = Convert.ToDouble(drRecordSet("Descuentos").ToString)
                    d16 = Convert.ToDouble(drRecordSet("Devoluciones").ToString)
                    d17 = Convert.ToDouble(drRecordSet("RetencionesPago").ToString)

                    d18 = d14 + d15 + d16 + d17
                    e = True

                End If
            End If

            drRecordSet.Close()

            If e = False Then
                Exit Sub
            End If

            d13 = ""

            Dim xEntero As Double
            Dim xDecimal As Double

            xDecimal = Math.Round(d18 - Int(d18), 2)
            xEntero = Int(d18)

            If xDecimal <> 0 Then
                d13 = Letras(Math.Round(d18, 2)) & " centavos.- - - - - - - - - -"
            Else
                d13 = Letras(Math.Round(d18, 2)) & " .- - - - - - - - - -"
            End If
            'If xDecimal = 0 Then
            '    xPagareImporteLetra = Letras(xEntero)
            'Else
            '    xPagareImporteLetra = Letras(xEntero) & " con " & Letras(xDecimal) & " centavos.-"
            'End If


            Call datos_de_proveedor(d1, d9, d10, d11, d12)
            If d11 <> 0 Then
                nom_reponsable = parametroSistema(2, d11)
            End If


            'Comienza a Registrar datos del Recibo

            jx = 0
         
            Sql = "Select * From Cancelaciones_corriente_proveedores WHERE (Cliente= " & Cliente & ") And (NumeroRecibo= '" & Numero & "') And (LetraRecibo='R') And (Estado=0) "
            Dim cmdRecordSet_1 As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet_1 As OleDbDataReader = cmdRecordSet_1.ExecuteReader
            If drRecordSet_1.HasRows Then 'Tiene filas
                Do While drRecordSet_1.Read
                    m_arr(jx, 0) = FormatDateTime(d3, DateFormat.ShortDate)
                    m_arr(jx, 1) = Numero
                    m_arr(jx, 2) = d9
                    m_arr(jx, 3) = d10
                    m_arr(jx, 4) = nom_reponsable
                    m_arr(jx, 5) = d12
                    m_arr(jx, 6) = d13


                    m_arr(jx, 7) = d4
                    m_arr(jx, 8) = d5
                    m_arr(jx, 9) = d6
                    m_arr(jx, 10) = d7
                    If d8 <> 0 And d6 <> 0 Then
                        m_arr(jx, 11) = parametroSistema(9, d8)
                    Else
                        m_arr(jx, 11) = " "
                    End If

                    m_arr(jx, 12) = FormatDateTime(drRecordSet_1("FechaComprobante").ToString, DateFormat.ShortDate)
                    If Val(drRecordSet_1("CodigoMovimiento").ToString) = 1 Then
                        m_arr(jx, 13) = "FA"
                    End If
                    If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 2 Then
                        m_arr(jx, 13) = "ND"
                    End If
                    If Convert.ToInt16(drRecordSet_1("CodigoMovimiento").ToString) = 3 Then
                        m_arr(jx, 13) = "NC"
                    End If

                    m_arr(jx, 14) = drRecordSet_1("LetraComprobante").ToString
                    m_arr(jx, 15) = drRecordSet_1("NumeroComprobante").ToString
                    m_arr(jx, 16) = Convert.ToDouble(drRecordSet_1("Importe").ToString)
                    m_arr(jx, 17) = Convert.ToDouble(drRecordSet_1("Cancelado").ToString)
                    m_arr(jx, 24) = d18

                    jx = jx + 1

                Loop
            End If

            drRecordSet_1.Close()

            jx = 0

            Sql = "Select * From Valores_Emitidos WHERE (Cliente= " & Cliente & ") And (NumeroComprobante= '" & Numero & "') And (LetraComprobante='R') And (Tipocomprobante=5) And (Estado=0) "
            Dim cmdRecordSet_2 As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet_2 As OleDbDataReader = cmdRecordSet_2.ExecuteReader
            If drRecordSet_2.HasRows Then 'Tiene filas
                Do While drRecordSet_2.Read

                    m_arr(jx, 0) = FormatDateTime(d3, DateFormat.ShortDate)
                    m_arr(jx, 1) = Numero
                    m_arr(jx, 2) = d9
                    m_arr(jx, 3) = d10
                    m_arr(jx, 4) = nom_reponsable
                    m_arr(jx, 5) = d12
                    m_arr(jx, 6) = d13


                    m_arr(jx, 7) = d4
                    m_arr(jx, 8) = d5
                    m_arr(jx, 9) = d6
                    m_arr(jx, 10) = d7
                    If d8 <> 0 And d6 <> 0 Then
                        m_arr(jx, 11) = parametroSistema(9, d8)
                    Else
                        m_arr(jx, 11) = " "
                    End If

                    m_arr(jx, 18) = Convert.ToInt16(drRecordSet_2("Banco").ToString)
                    m_arr(jx, 19) = parametroSistema(8, Convert.ToInt16(drRecordSet_2("Banco").ToString))
                    m_arr(jx, 20) = FormatDateTime(drRecordSet_2("Emision").ToString, DateFormat.ShortDate)
                    m_arr(jx, 21) = FormatDateTime(drRecordSet_2("Pago").ToString, DateFormat.ShortDate)
                    m_arr(jx, 22) = Convert.ToDouble(drRecordSet_2("Numero").ToString)
                    m_arr(jx, 23) = Convert.ToDouble(drRecordSet_2("Importe").ToString)
                    m_arr(jx, 24) = d18

                    jx = jx + 1

                Loop
            End If

            drRecordSet_2.Close()

            For jx = 0 To 70

                If m_arr(jx, 12).Trim <> "" Or m_arr(jx, 18).Trim <> "" Then
                    registro = tabla.NewRow

                    registro("EncFecha1") = FormatDateTime(Convert.ToDateTime(m_arr(jx, 0)), DateFormat.ShortDate)
                    registro("EncLit1") = m_arr(jx, 1)
                    registro("EncLit2") = m_arr(jx, 2)
                    registro("EncLit3") = m_arr(jx, 3)
                    registro("EncLit4") = m_arr(jx, 4)
                    registro("EncLit5") = m_arr(jx, 5)
                    registro("Pie1") = m_arr(jx, 6)
                    registro("Efectivo") = m_arr(jx, 7)
                    registro("Cheques") = m_arr(jx, 8)
                    registro("Tarjeta") = m_arr(jx, 9)
                    registro("Transferencia") = m_arr(jx, 10)


                    If d8 <> 0 And d6 <> 0 Then
                        registro("IdTarjeta") = m_arr(jx, 11)
                    Else
                        registro("IdTarjeta") = " "
                    End If

                    If m_arr(jx, 12).Trim <> "" Then
                        registro("ComFec1") = FormatDateTime(Convert.ToDateTime(m_arr(jx, 12)), DateFormat.ShortDate)
                        registro("ComTip1") = m_arr(jx, 13)
                        registro("ComLet1") = m_arr(jx, 14)
                        registro("ComNro1") = m_arr(jx, 15)
                        registro("ComImpCom1") = Convert.ToDouble(m_arr(jx, 16))
                        registro("ComImpPag1") = Convert.ToDouble(m_arr(jx, 17))
                    End If

                    If m_arr(jx, 18).Trim <> "" Then
                        registro("ValIdBco1") = Convert.ToInt16(m_arr(jx, 18))
                        registro("ValBco1") = m_arr(jx, 19)
                        registro("ValFecEmi1") = FormatDateTime(Convert.ToDateTime(m_arr(jx, 20)), DateFormat.ShortDate)
                        registro("ValFecPag1") = FormatDateTime(FormatDateTime(Convert.ToDateTime(m_arr(jx, 21)), DateFormat.ShortDate))
                        registro("ValNro1") = Convert.ToDouble(m_arr(jx, 22))
                        registro("ValImp1") = Convert.ToDouble(m_arr(jx, 23))
                    End If
                    registro("TotalRecibo") = m_arr(jx, 24)

                    tabla.Rows.Add(registro)
                End If
            Next


            dts.Tables.Add(tabla)


            Dim mi_CryResumen As New CrRecibosProveedoresLargos()
            mi_CryResumen.SetDataSource(dts.Tables("ReportesRecibos"))

            Dim miForma As New Form1000()
            miForma.CrvReportes.ReportSource = mi_CryResumen
            miForma.ShowDialog()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

End Module

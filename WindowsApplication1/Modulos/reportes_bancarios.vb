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
Module reportes_bancarios
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Public Sub resumen_cuenta_bancario(ByVal xNumero As String, ByVal xFecha1 As String, ByVal xFecha2 As String)
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


            Dim xNombre As String = " "
            Dim xSaldoDeudor As Double = 0
            Dim xSaldoAcredor As Double = 0


            Call saldo_cuenta_bancaria(xNumero, xFecha1, xFecha2, 2, xSaldoDeudor, xSaldoAcredor)

            Dim xSaldo As Double = 0
            Dim xSaldoInicial As Double = 0

            xSaldoInicial = xSaldoDeudor - xSaldoAcredor


            Call Cuenta_Bancaria(xNumero, xNombre)

            xSaldo = xSaldoInicial

            Dim xDetalle As String = ""
            Dim xDebcre As Integer = 0

            
            Dim Exis As Boolean = False
            Dim insSql As String = ""

            insSql = "Select * from Movimientos_Bancarios Where (Estado = 0) AND (Numero='" & xNumero & "') And (Conciliado=1) "
            insSql = insSql & "AND (FechaConciliado >= '" & xFecha1 & "') AND (FechaConciliado <= '" & xFecha2 & "')  ORDER BY FechaConciliado"

            Dim cmdRecordSet As New OleDbCommand(insSql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows = True Then 'Tiene filas
                Do While drRecordSet.Read
                    registro = tabla.NewRow
                    Exis = True
                    registro("Fecha1") = FormatDateTime(xFecha1, DateFormat.ShortDate)
                    registro("Fecha2") = FormatDateTime(xFecha2, DateFormat.ShortDate)
                    registro("Fecha3") = FormatDateTime(drRecordSet("FechaConciliado").ToString, DateFormat.ShortDate)


                    registro("Numero1") = Convert.ToDouble(drRecordSet("Comprobante").ToString)
                    registro("Numero2") = Convert.ToDouble(drRecordSet("Codigo").ToString)

                    If Convert.ToDouble(drRecordSet("Codigo").ToString) = 1 Then
                        registro("Numero3") = Convert.ToDouble(drRecordSet("Importe").ToString)
                        registro("Numero4") = 0
                        xSaldo = xSaldo + Convert.ToDouble(drRecordSet("Importe").ToString)
                    Else
                        registro("Numero3") = 0
                        registro("Numero4") = Convert.ToDouble(drRecordSet("Importe").ToString)
                        xSaldo = xSaldo - Convert.ToDouble(drRecordSet("Importe").ToString)
                    End If
                    registro("Numero6") = xSaldo

                    registro("Literal1") = xNumero
                    registro("Literal2") = xNombre

                    Call Codigo_Bancario(Val(drRecordSet("Codigo").ToString), xDetalle, xDebcre)

                    registro("Literal3") = drRecordSet("Codigo").ToString
                    registro("Literal4") = xDetalle
                    registro("Literal5") = drRecordSet("Detalle").ToString
                  
                  
                    registro("Numero5") = xSaldoInicial
                    tabla.Rows.Add(registro)
                Loop
                dts.Tables.Add(tabla)
            End If

            If Exis = False Then
                Exit Sub
            End If

            Dim mi_CryResumen As New CrResumenBancario()
            mi_CryResumen.SetDataSource(dts.Tables("ReportesGenericos"))

            Dim miForma As New Form1000()
            miForma.CrvReportes.ReportSource = mi_CryResumen
            miForma.Show()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try


    End Sub

    Private Sub Cuenta_Bancaria(ByVal xNumero As String, ByRef xNombre As String)

        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim InsSql As String = ""
            InsSql = "Select * from Cuentas_Bancarias Where Numero = '" & xNumero & "'  "

            Dim cmdBuscar As New OleDbCommand(InsSql, ConSql)
            Dim drBuscar As OleDbDataReader = cmdBuscar.ExecuteReader
            If drBuscar.Read = True Then
                xNombre = drBuscar("Detalle").ToString
              
            End If
            drBuscar.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub



    Private Sub saldo_cuenta_bancaria(ByVal xNumero As String, ByVal xFecha1 As String, ByVal xFecha2 As String, ByVal xTipo As Byte, _
                            ByRef xSaldoDeudor As Double, ByRef xSaldoAcredor As Double)

        Dim xImp_Debitos As Double = 0
        Dim xImp_Creditos As Double = 0

        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim InsSql As String = ""

            If xTipo = 0 Then
                InsSql = "Select Sum (importe) as Expr from Movimientos_Bancarios Where (Numero =  " & xNumero & ") AND (Debcre=1) AND (Estado=0)"
                xImp_Debitos = calculos_sql(InsSql)

                InsSql = "Select Sum (importe) as Expr from Movimientos_Bancarios Where (Numero =  " & xNumero & ") AND (Debcre=2) AND (Estado=0)"
                xImp_Creditos = calculos_sql(InsSql)
            End If

            If xTipo = 1 Then
                InsSql = "Select Sum (importe) as Expr from Movimientos_Bancarios Where (Numero =  " & xNumero & ") AND (Debcre=1) AND (Estado=0) AND (FechaConciliado >= '" & xFecha1 & "') AND (FechaConciliado <= '" & xFecha2 & "') "
                xImp_Debitos = calculos_sql(InsSql)

                InsSql = "Select Sum (importe) as Expr from Movimientos_Bancarios Where (numero =  " & xNumero & ") AND (Debcre=2) AND (Estado=0) AND (FechaConciliado >= '" & xFecha1 & "') AND (FechaConciliado <= '" & xFecha2 & "') "
                xImp_Creditos = calculos_sql(InsSql)
            End If

            If xTipo = 2 Then
                InsSql = "Select Sum (importe) as Expr from Movimientos_Bancarios Where (Numero =  " & xNumero & ") AND (Debcre=1) AND (Estado=0) AND (FechaConciliado < '" & xFecha1 & "') "
                xImp_Debitos = calculos_sql(InsSql)

                InsSql = "Select Sum (importe) as Expr from Movimientos_Bancarios Where (Numero =  " & xNumero & ") AND (Debcre=2) AND (Estado=0) AND (FechaConciliado < '" & xFecha1 & "') "
                xImp_Creditos = calculos_sql(InsSql)
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            xSaldoDeudor = xImp_Debitos
            xSaldoAcredor = xImp_Creditos
        End Try



    End Sub

    Private Function calculos_sql(ByVal Sql As String) As Double
        Dim xImporte As Double = 0
        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim cmdBuscar As New OleDbCommand(Sql, ConSql)
            Dim drBuscar As OleDbDataReader = cmdBuscar.ExecuteReader
            If drBuscar.Read = True Then
                xImporte = Val(drBuscar("Expr").ToString)
            End If
            drBuscar.Close()
            ConSql.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            calculos_sql = xImporte
        End Try



    End Function

End Module

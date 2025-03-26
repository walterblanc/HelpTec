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



Public Class Form41
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Dim reser_accion As Byte = 0
    Public Sub New(ByVal v_accion As Byte)
        InitializeComponent()
        reser_accion = v_accion
    End Sub
    Private Sub Form41_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MetroDateTime1.Value = Now.Date
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

            Dim tabla As DataTable
            Dim campo As DataColumn
            Dim registro As DataRow
            tabla = New DataTable("reportesSaldos")

            campo = New DataColumn("Fecha", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("Tipo", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Numero", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("Nombre", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("Domicilio", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("Telefono", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Fantasia", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Importe1", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Importe2", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Importe3", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Saldo1", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Saldo2", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Saldo3", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)


             If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim xSaldo As Double = 0

            Dim xSaldo1 As Double = 0
            Dim xSaldo2 As Double = 0
            Dim xSaldo3 As Double = 0

            Dim InsSql As String = ""

            If reser_accion = 1 Then
                InsSql = "SELECT     Clientes.Numero, Clientes.RazonSocial, Clientes.Comercial, Clientes.Domicilio, Clientes.Provincia, Clientes.Telefono, Clientes.Celular"
                InsSql = InsSql & " FROM         Clientes INNER JOIN"
                InsSql = InsSql & " Cuenta_Corriente_Clientes ON Clientes.Numero = Cuenta_Corriente_Clientes.Cliente"
                InsSql = InsSql & " WHERE     (Clientes.Estado = 0)"
                InsSql = InsSql & " GROUP BY Clientes.Numero, Clientes.RazonSocial, Clientes.Comercial, Clientes.Domicilio, Clientes.Provincia, Clientes.Telefono, Clientes.Celular"
                InsSql = InsSql & " ORDER BY Clientes.RazonSocial"
            End If

            If reser_accion = 2 Then
                InsSql = "SELECT     proveedores.Numero, proveedores.RazonSocial, proveedores.Comercial, proveedores.Domicilio, proveedores.Provincia, proveedores.Telefono, proveedores.Celular"
                InsSql = InsSql & " FROM         proveedores INNER JOIN"
                InsSql = InsSql & " Cuenta_Corriente_proveedores ON proveedores.Numero = Cuenta_Corriente_proveedores.Cliente"
                InsSql = InsSql & " WHERE     (proveedores.Estado = 0)"
                InsSql = InsSql & " GROUP BY proveedores.Numero, proveedores.RazonSocial, proveedores.Comercial, proveedores.Domicilio, proveedores.Provincia, proveedores.Telefono, proveedores.Celular"
                InsSql = InsSql & " ORDER BY proveedores.RazonSocial"
            End If



            Dim cmdBuscar As New OleDbCommand(InsSql, ConSql)
            Dim drBuscar As OleDbDataReader = cmdBuscar.ExecuteReader

            If drBuscar.HasRows = True Then 'Tiene filas
                Do While drBuscar.Read

                    If reser_accion = 1 Then

                        xSaldo = saldo_cuenta_corriente(drBuscar("Numero").ToString, FormatDateTime(MetroDateTime1.Value, DateFormat.ShortDate), _
                                    FormatDateTime(MetroDateTime1.Value, DateFormat.ShortDate), 2, 2)
                    End If
                    If reser_accion = 2 Then

                        xSaldo = saldo_cuenta_corriente_proveedores(drBuscar("Numero").ToString, FormatDateTime(MetroDateTime1.Value, DateFormat.ShortDate), _
                                    FormatDateTime(MetroDateTime1.Value, DateFormat.ShortDate), 2, 2)
                    End If


                    xSaldo1 = xSaldo1 + xSaldo

                    If xSaldo < 0 Then
                        registro = tabla.NewRow

                        registro("Fecha") = FormatDateTime(MetroDateTime1.Value, DateFormat.ShortDate)

                        If reser_accion = 1 Then
                            registro("Tipo") = "Cuenta Corriente Clientes"
                        End If
                        If reser_accion = 2 Then
                            registro("Tipo") = "Cuenta Corriente Proveedores"
                        End If

                        registro("Numero") = drBuscar("Numero").ToString
                        registro("Nombre") = drBuscar("RazonSocial").ToString
                        registro("Domicilio") = drBuscar("Domicilio").ToString
                        registro("Telefono") = drBuscar("Telefono").ToString.Trim & " " & drBuscar("Celular").ToString.Trim
                        registro("Fantasia") = drBuscar("Comercial").ToString


                        registro("Importe1") = xSaldo
                        registro("Importe2") = 0
                        registro("Importe3") = 0

                        registro("Saldo1") = xSaldo1
                        registro("Saldo2") = xSaldo2
                        registro("Saldo3") = xSaldo3


                        tabla.Rows.Add(registro)
                        ExistenRegistros = True
                    End If


                Loop
                dts.Tables.Add(tabla)
            End If

            drBuscar.Close()


            If ExistenRegistros = False Then
                tabla.Dispose()
                MessageBox.Show("     No existen movimientos para procesar listado       ", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


            Dim mi_CryResumen As New CrSaldos()
            'Le indicamos al reporte que tome los datos
            'del DataSet
            mi_CryResumen.SetDataSource(dts.Tables("reportesSaldos"))

            'Delcaramos una instancia del formulario frmReprotes
            Dim miForma As New Form1000()
            'Le indicamos que debe mostrar mi_rptCatClientes
            miForma.CrvReportes.ReportSource = mi_CryResumen
            'que muestre el titulo "Reporte de Clientes"
            'Mostramos el formulario (el cual contiene el reporte)
            miForma.Show()
            ''dv = Nothing

            ConSql.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Function saldo_cuenta_corriente(ByVal xCuenta As Double, ByVal xFecha1 As String, ByVal xFecha2 As String, _
                                ByVal xTipo As Byte, ByVal xSucursal As Byte) As Double

        Dim xImp_Debitos As Double = 0
        Dim xImp_Creditos As Double = 0
        Dim xSaldo As Double = 0

        Try

            Dim InsSql As String = ""

            If xTipo = 0 Then
                InsSql = "Select Sum (importe) as Expr from Cuenta_corriente_clientes Where (Cliente = " & xCuenta & ") AND (Debcre=1) AND (Estado=0)"
                xImp_Debitos = calculos_sql(InsSql)

                InsSql = "Select Sum (importe) as Expr from Cuenta_corriente_clientes Where (Cliente = " & xCuenta & ") AND (Debcre=2) AND (Estado=0)"
                xImp_Creditos = calculos_sql(InsSql)
            End If

            If xTipo = 1 Then
                InsSql = "Select Sum (importe) as Expr from Cuenta_corriente_clientes Where (Cliente = " & xCuenta & ") AND (Debcre=1) AND (Estado=0) AND (Fecha >= '" & xFecha1 & "') AND (Fecha <= '" & xFecha2 & "') "
                xImp_Debitos = calculos_sql(InsSql)

                InsSql = "Select Sum (importe) as Expr from Cuenta_corriente_clientes Where (Cliente = " & xCuenta & ") AND (Debcre=2) AND (Estado=0) AND (Fecha >= '" & xFecha1 & "') AND (Fecha <= '" & xFecha2 & "') "
                xImp_Creditos = calculos_sql(InsSql)
            End If

            If xTipo = 2 Then
                InsSql = "Select Sum (importe) as Expr from Cuenta_corriente_clientes Where (Cliente = " & xCuenta & ") AND (Debcre=1) AND (Estado=0) AND (Fecha <= '" & xFecha1 & "') "
                xImp_Debitos = calculos_sql(InsSql)

                InsSql = "Select Sum (importe) as Expr from Cuenta_corriente_clientes Where (Cliente = " & xCuenta & ") AND (Debcre=2) AND (Estado=0) AND (Fecha <= '" & xFecha1 & "') "
                xImp_Creditos = calculos_sql(InsSql)
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            xSaldo = xImp_Creditos - xImp_Debitos
            saldo_cuenta_corriente = xSaldo
        End Try



    End Function
    Private Function saldo_cuenta_corriente_proveedores(ByVal xCuenta As Double, ByVal xFecha1 As String, ByVal xFecha2 As String, _
                                ByVal xTipo As Byte, ByVal xSucursal As Byte) As Double

        Dim xImp_Debitos As Double = 0
        Dim xImp_Creditos As Double = 0
        Dim xSaldo As Double = 0

        Try

            Dim InsSql As String = ""

            If xTipo = 0 Then
                InsSql = "Select Sum (importe-retenciones) as Expr from Cuenta_corriente_proveedores Where (Cliente = " & xCuenta & ") AND (Debcre=1) AND (Estado=0)"
                xImp_Debitos = calculos_sql(InsSql)

                InsSql = "Select Sum (importe-retenciones) as Expr from Cuenta_corriente_proveedores Where (Cliente = " & xCuenta & ") AND (Debcre=2) AND (Estado=0)"
                xImp_Creditos = calculos_sql(InsSql)
            End If

            If xTipo = 1 Then
                InsSql = "Select Sum (importe-retenciones) as Expr from Cuenta_corriente_proveedores Where (Cliente = " & xCuenta & ") AND (Debcre=1) AND (Estado=0) AND (Fecha >= '" & xFecha1 & "') AND (Fecha <= '" & xFecha2 & "') "
                xImp_Debitos = calculos_sql(InsSql)

                InsSql = "Select Sum (importe-retenciones) as Expr from Cuenta_corriente_proveedores Where (Cliente = " & xCuenta & ") AND (Debcre=2) AND (Estado=0) AND (Fecha >= '" & xFecha1 & "') AND (Fecha <= '" & xFecha2 & "') "
                xImp_Creditos = calculos_sql(InsSql)
            End If

            If xTipo = 2 Then
                InsSql = "Select Sum (importe-retenciones) as Expr from Cuenta_corriente_proveedores Where (Cliente = " & xCuenta & ") AND (Debcre=1) AND (Estado=0) AND (Fecha <= '" & xFecha1 & "') "
                xImp_Debitos = calculos_sql(InsSql)

                InsSql = "Select Sum (importe-retenciones) as Expr from Cuenta_corriente_proveedores Where (Cliente = " & xCuenta & ") AND (Debcre=2) AND (Estado=0) AND (Fecha <= '" & xFecha1 & "') "
                xImp_Creditos = calculos_sql(InsSql)
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            xSaldo = xImp_Creditos - xImp_Debitos
            saldo_cuenta_corriente_proveedores = xSaldo
        End Try



    End Function

    Private Function calculos_sql(ByVal Sql As String) As Double
        Dim xImporte As Double = 0
        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim cmdBuscar As New OleDbCommand(Sql, ConSql)
            Dim drBuscar As OleDbDataReader = cmdBuscar.ExecuteReader
            If drBuscar.Read = True Then
                xImporte = Val(drBuscar("Expr").ToString)
            End If
            drBuscar.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            calculos_sql = xImporte
        End Try
    End Function



End Class

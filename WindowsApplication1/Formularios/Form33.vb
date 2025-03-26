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


Public Class Form33
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Dim reser_Cliente As Double = 0
    Dim reser_Fecha1 As Date = Date.Now
    Dim reser_Fecha2 As Date = Date.Now

    Public Sub New(ByVal v_Cliente As Double, ByVal v_Fecha1 As Date, ByVal v_Fecha2 As Date)
        InitializeComponent()
        reser_Cliente = v_Cliente
        reser_Fecha1 = v_Fecha1
        reser_Fecha2 = v_Fecha2
    End Sub


#Region "ControlText"
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
    Private Sub metroTextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub metroTextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox3.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub metroTextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox4.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub metroTextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox5.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub metroTextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox6.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub metroTextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox7.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub metroTextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox8.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub metroTextBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox10.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub metroTextBox26_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub metroTextBox13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
    Private Sub metroTextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
    Private Sub metroTextBox12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Private Sub metroTextBox15_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
#End Region

    Private Sub Form33_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        inicializo_formulario()
        cargarCOMBO(MetroComboBox1, 2)
        cargo_Cliente()


    End Sub
    Private Sub inicializo_formulario()
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox4.Text = ""
        MetroTextBox5.Text = ""
        MetroTextBox6.Text = ""
        MetroTextBox7.Text = ""
        MetroTextBox8.Text = ""

        MetroTextBox10.Text = ""
        MetroTextBox11.Text = ""

        MetroDateTime1.Value = reser_Fecha1
        MetroDateTime2.Value = reser_Fecha2
  
    End Sub


    Private Sub cargo_Cliente()
        Dim r As Integer = 1
        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim Sql As String = ""
            Sql = "Select * from Clientes WHERE (Numero= " & reser_Cliente & ") And (Estado=0) "


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    MetroTextBox1.Text = drRecordSet("Numero").ToString
                    MetroTextBox2.Text = drRecordSet("RazonSocial").ToString
                    MetroTextBox3.Text = drRecordSet("Comercial").ToString
                    MetroTextBox4.Text = drRecordSet("Domicilio").ToString
                    MetroTextBox5.Text = drRecordSet("Ciudad").ToString
                    MetroTextBox6.Text = drRecordSet("Provincia").ToString
                    MetroTextBox7.Text = drRecordSet("Telefono").ToString
                    MetroTextBox8.Text = drRecordSet("Celular").ToString
                    MetroTextBox10.Text = drRecordSet("email").ToString
                    MetroTextBox11.Text = drRecordSet("Cuit").ToString


                    Call buscarCombo(MetroComboBox1, Val(drRecordSet("Responsable").ToString))

                    MetroDateTime1.Focus()

                End If
            End If

            drRecordSet.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

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

            Dim xCliente As Double = 0
            Dim xNombreCliente As String = " "
            Dim xComercial As String = " "
            Dim xTelefono As String = " "
            Dim xMail As String = " "

            Dim xDomicilioCliente As String = " "


            Dim xCuenta As Double = 0
            xCuenta = Val(MetroTextBox1.Text.Trim)
            Dim xSaldoDeudor As Double = 0
            Dim xSaldoAcredor As Double = 0

   
            Call saldo_cuenta_corriente(xCuenta, FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate), _
                                        FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate), 2, _
                                         xSaldoDeudor, xSaldoAcredor)

            Dim xSaldo As Double = 0
            Dim xSaldoInicial As Double = 0


            Dim xFecha1 As String = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate)
            Dim xFecha2 As String = FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate)


            xSaldoInicial = xSaldoDeudor - xSaldoAcredor


            Call datos_cliente(xCuenta, xNombreCliente, xComercial, xTelefono, xMail, xDomicilioCliente)

            xSaldo = xSaldoInicial

            Dim Exis As Boolean = False
            Dim insSql As String = ""

            insSql = "Select * from Cuenta_Corriente_Clientes Where (Estado = 0) AND (Cliente=" & xCuenta & ") "
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
                    registro("Literal1") = xNombreCliente
                    registro("Literal2") = xDomicilioCliente

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
                    registro("Literal8") = xTelefono
                    registro("Literal9") = xMail
                    registro("Numero4") = xSaldo
                    registro("Numero5") = xSaldoInicial
                    tabla.Rows.Add(registro)
                Loop
                dts.Tables.Add(tabla)
            End If

            If Exis = False Then
                Exit Sub
            End If

            Dim mi_CryResumen As New CrResumenCliente()
            mi_CryResumen.SetDataSource(dts.Tables("ReportesGenericos"))

            Dim miForma As New Form1000()
            miForma.CrvReportes.ReportSource = mi_CryResumen
            miForma.Show()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
    Private Sub datos_cliente(ByVal xCliente As Double, ByRef xNombreCliente As String, ByRef xComercial As String, _
                              ByRef xTelefono As String, ByRef xMail As String, ByRef xDomicilioCliente As String)

        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim InsSql As String = ""
            InsSql = "Select * from Clientes Where Numero = " & xCliente & "  "

            Dim cmdBuscar As New OleDbCommand(InsSql, ConSql)
            Dim drBuscar As OleDbDataReader = cmdBuscar.ExecuteReader
            If drBuscar.Read = True Then
                xNombreCliente = drBuscar("RazonSocial").ToString
                xComercial = drBuscar("Comercial").ToString
                xDomicilioCliente = drBuscar("Domicilio").ToString.Trim
                xTelefono = drBuscar("Telefono").ToString.Trim
                xMail = drBuscar("email").ToString.Trim
            End If
            drBuscar.Close()
   
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub saldo_cuenta_corriente(ByVal xCuenta As Double, ByVal xFecha1 As String, ByVal xFecha2 As String, ByVal xTipo As Byte, _
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
                InsSql = "Select Sum (importe) as Expr from Cuenta_corriente_clientes Where (Cliente =  " & xCuenta & ") AND (Debcre=1) AND (Estado=0)"
                xImp_Debitos = calculos_sql(InsSql)

                InsSql = "Select Sum (importe) as Expr from Cuenta_corriente_clientes Where (Cliente =  " & xCuenta & ") AND (Debcre=2) AND (Estado=0)"
                xImp_Creditos = calculos_sql(InsSql)
            End If

            If xTipo = 1 Then
                InsSql = "Select Sum (importe) as Expr from Cuenta_corriente_clientes Where (Cliente =  " & xCuenta & ") AND (Debcre=1) AND (Estado=0) AND (Fecha >= '" & xFecha1 & "') AND (Fecha <= '" & xFecha2 & "') "
                xImp_Debitos = calculos_sql(InsSql)

                InsSql = "Select Sum (importe) as Expr from Cuenta_corriente_clientes Where (Cliente =  " & xCuenta & ") AND (Debcre=2) AND (Estado=0) AND (Fecha >= '" & xFecha1 & "') AND (Fecha <= '" & xFecha2 & "') "
                xImp_Creditos = calculos_sql(InsSql)
            End If

            If xTipo = 2 Then
                InsSql = "Select Sum (importe) as Expr from Cuenta_corriente_clientes Where (Cliente =  " & xCuenta & ") AND (Debcre=1) AND (Estado=0) AND (Fecha < '" & xFecha1 & "') "
                xImp_Debitos = calculos_sql(InsSql)

                InsSql = "Select Sum (importe) as Expr from Cuenta_corriente_clientes Where (Cliente =  " & xCuenta & ") AND (Debcre=2) AND (Estado=0) AND (Fecha < '" & xFecha1 & "') "
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

End Class

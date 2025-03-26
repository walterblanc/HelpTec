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


Public Class Form36
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Dim reser_Cliente As Double = 0

    Public Sub New(ByVal v_Cliente As Double)
        InitializeComponent()
        reser_Cliente = v_Cliente
    End Sub



    Private Sub Form36_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        inicializo_formulario()
        cargo_Cliente()
        cargar_datagrid()
    End Sub
    Private Sub inicializo_formulario()
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""

        MetroDateTime1.Value = Now.Date.AddDays(-30)
        MetroDateTime2.Value = Now.Date

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


    Private Sub cargar_datagrid()
        Dim h As Integer = 0
        Dim Sql As String = ""



        Dim xSaldoDeudor As Double = 0
        Dim xSaldoAcredor As Double = 0


        Call saldo_cuenta_corriente(reser_Cliente, FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate), _
                                    FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate), 2, _
                                     xSaldoDeudor, xSaldoAcredor)

        Dim xSaldo As Double = 0
        Dim xSaldoInicial As Double = 0


        Dim xFecha1 As String = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate)
        Dim xFecha2 As String = FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate)


        xSaldoInicial = xSaldoDeudor - xSaldoAcredor

        xSaldo = xSaldoInicial



        MetroTextBox3.Text = FormatNumber(xSaldoInicial, 2)


        Sql = "Select * from Cuenta_Corriente_Clientes Where (Estado = 0) AND (Cliente=" & reser_Cliente & ") "
        Sql = Sql & "AND (Fecha >= '" & xFecha1 & "') AND (Fecha <= '" & xFecha2 & "')  ORDER BY Fecha"

        With metroGrid1
            .Columns.Clear()
            .Rows.Clear()
            .Refresh()
        End With

        With metroGrid1
            .Rows.Clear()
            .Columns.Add("A", "Fecha")
            .Columns.Add("B", "Tipo")
            .Columns.Add("C", "Letra")
            .Columns.Add("D", "Nro.")
            .Columns.Add("E", "Detalle")
            .Columns.Add("F", "Debe")
            .Columns.Add("G", "Haber")
            .Columns.Add("H", "Saldo")
            .Columns(0).Width = 80
            .Columns(1).Width = 80
            .Columns(2).Width = 82
            .Columns(3).Width = 100
            .Columns(4).Width = 240
            .Columns(5).Width = 120
            .Columns(6).Width = 120
            .Columns(7).Width = 120
            '            .RowCount = 100
        End With

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

                    If Val(drRecordSet("CodigoMovimiento").ToString) = 1 Then
                        .Item(1, h).Value = "FA"
                    End If
                    If Val(drRecordSet("CodigoMovimiento").ToString) = 2 Then
                        .Item(1, h).Value = "ND"
                    End If
                    If Val(drRecordSet("CodigoMovimiento").ToString) = 3 Then
                        .Item(1, h).Value = "NC"
                    End If
                    If Val(drRecordSet("CodigoMovimiento").ToString) = 4 Then
                        .Item(1, h).Value = "RE"
                    End If
                    If Val(drRecordSet("CodigoMovimiento").ToString) = 5 Then
                        .Item(1, h).Value = "AD"
                    End If
                    If Val(drRecordSet("CodigoMovimiento").ToString) = 6 Then
                        .Item(1, h).Value = "AA"
                    End If

                    .Item(2, h).Value = drRecordSet("LetraComprobante").ToString
                    .Item(3, h).Value = drRecordSet("NumeroComprobante").ToString
                    .Item(4, h).Value = drRecordSet("Detalle").ToString
                    .Item(5, h).Value = " "
                    .Item(6, h).Value = " "

                    If Val(drRecordSet("DebCre").ToString) = 1 Then
                        xSaldo = xSaldo + Convert.ToDouble(drRecordSet("Importe").ToString)
                        .Item(5, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Importe").ToString), 2)
                        .Item(6, h).Value = " "
                    Else
                        xSaldo = xSaldo - Convert.ToDouble(drRecordSet("Importe").ToString)
                        .Item(5, h).Value = " "
                        .Item(6, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Importe").ToString), 2)
                    End If
                    .Item(7, h).Value = FormatNumber(xSaldo, 2)
                    h = h + 1
                End With
            Loop
        End If

        drRecordSet.Close()


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

   
    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        cargar_datagrid()
    End Sub
End Class

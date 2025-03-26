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


Public Class Form50
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Dim reser_Cuenta As String = ""
    Dim reser_Numero As Double = 0
    Public Sub New(ByVal v_cuenta As String, ByVal v_numero As Double)
        InitializeComponent()
        reser_Cuenta = v_cuenta
        reser_Numero = v_numero
    End Sub

    Private Sub Form50_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargo_CuentaBancaria()
        inicializo_formulario()

    End Sub
    

    Private Sub inicializo_formulario()
      
        MetroDateTime1.Value = Now.Date
        MetroDateTime2.Value = Now.Date

        MetroDateTime1.Focus()

    End Sub


    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        inicializo_formulario()
    End Sub
   
    Private Sub cargo_CuentaBancaria()
        Dim r As Integer = 1
        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim Sql As String = ""
            Sql = "Select * from Cuentas_Bancarias WHERE (Numero= '" & reser_Cuenta & "') And (Estado=0) "


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    MetroTextBox8.Text = drRecordSet("Numero").ToString
                    MetroTextBox7.Text = drRecordSet("Detalle").ToString
                    MetroTextBox6.Text = drRecordSet("Banco").ToString
                End If
            End If

            MetroTextBox10.Text = ""
            If MetroTextBox6.Text.Trim <> "" Then
                MetroTextBox10.Text = parametroSistema(8, Val(MetroTextBox6.Text.Trim))
            End If
            drRecordSet.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

   
    Private Sub MetroLink6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink6.Click
        Call resumen_cuenta_bancario(MetroTextBox8.Text.Trim, FormatDateTime(MetroDateTime1.Value, DateFormat.ShortDate), FormatDateTime(MetroDateTime2.Value, DateFormat.ShortDate))
    End Sub
End Class

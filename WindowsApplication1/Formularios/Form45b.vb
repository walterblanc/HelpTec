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


Public Class Form45b
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Dim reser_Cuenta As String = ""
    Dim reser_accion As Byte = 0
    Public Sub New(ByVal v_Cuenta As String, ByVal v_accion As Byte)
        InitializeComponent()
        reser_Cuenta = v_Cuenta
        reser_accion = v_accion
    End Sub


#Region "ControlText"
    Private Sub metroTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
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
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub metroTextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox4.KeyPress
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

    Private Sub metroTextBox11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox11.KeyPress
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

    Private Sub Form45b_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        inicializo_formulario()
        If reser_accion = 2 Then
            cargo_CuentaBancaria()
        End If


    End Sub
    Private Sub inicializo_formulario()
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox4.Text = ""
        MetroTextBox10.Text = ""
        MetroTextBox11.Text = ""

        MetroTextBox1.Enabled = True

    End Sub
    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        Me.Close()
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
                    MetroTextBox1.Text = drRecordSet("Numero").ToString
                    MetroTextBox2.Text = drRecordSet("Detalle").ToString
                    MetroTextBox3.Text = drRecordSet("Banco").ToString
                    MetroTextBox4.Text = drRecordSet("Cbu").ToString
                    MetroTextBox11.Text = drRecordSet("Cuit").ToString
                    MetroTextBox1.Enabled = False
                    MetroTextBox2.Focus()



                End If
            End If

            MetroTextBox10.Text = ""
            If MetroTextBox3.Text.Trim <> "" Then
                MetroTextBox10.Text = parametroSistema(8, Val(MetroTextBox3.Text.Trim))
            End If
            drRecordSet.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        If reser_accion = 2 Then
            Exit Sub
        End If
        inicializo_formulario()
    End Sub
    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        If MetroTextBox1.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar número de cuenta bancaria", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MetroTextBox11.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar Cuit de cuenta bancaria", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Convert.ToDouble(MetroTextBox11.Text.Trim) = 0 Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar Cuit de cuenta bancaria", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MetroTextBox11.Text.Trim <> "" Then
            If cuitValido(CDbl(MetroTextBox11.Text.Trim)) = False Then
                MetroFramework.MetroMessageBox.Show(Me, "Número de Cuit es Inválido", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If


        If reser_accion = 1 Then
            nuevo_CuentaBancaria()
        End If
        If reser_accion = 2 Then
            modifica_CuentaBancaria()
        End If

    End Sub






    Private Sub MetroTextBox3_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox3.Validated
        MetroTextBox10.Text = ""
        If MetroTextBox3.Text.Trim <> "" Then
            MetroTextBox10.Text = parametroSistema(8, Val(MetroTextBox3.Text.Trim))
        End If
    End Sub
    Private Sub nuevo_CuentaBancaria()
        Try

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")



            Dim v_1 As String = ""
            Dim v_2 As String = ""
            Dim v_3 As Integer = 0
            Dim v_4 As String = ""
            Dim v_5 As Double = 0

            If MetroTextBox1.Text.Trim = "" Then
                v_1 = " "
            Else
                v_1 = MetroTextBox1.Text.Trim
            End If

            If MetroTextBox2.Text.Trim = "" Then
                v_2 = " "
            Else
                v_2 = MetroTextBox2.Text.Trim
            End If

            If MetroTextBox3.Text.Trim = "" Then
                v_3 = 0
            Else
                v_3 = Val(MetroTextBox3.Text.Trim)
            End If

            If MetroTextBox4.Text.Trim = "" Then
                v_4 = " "
            Else
                v_4 = MetroTextBox4.Text.Trim
            End If

            If MetroTextBox11.Text.Trim = "" Then
                v_5 = 0
            Else
                v_5 = Val(MetroTextBox11.Text.Trim)
            End If



            Dim InsSql As String = ""
            InsSql = "Insert into Cuentas_Bancarias (Numero,Detalle,Banco,Cbu,Cuit,"
            InsSql = InsSql & "FechaAlta,HoraAlta,UsuarioAlta) Values ("
            InsSql = InsSql & "'" & v_1 & "','" & v_2 & "','" & v_3 & "','" & v_4 & "','" & v_5 & "',"
            InsSql = InsSql & "'" & j2 & "','" & j3 & "'," & j1 & ")"

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            Me.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
    Private Sub modifica_CuentaBancaria()
        Try
            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")



            Dim v_1 As String = ""
            Dim v_2 As String = ""
            Dim v_3 As Integer = 0
            Dim v_4 As String = ""
            Dim v_5 As Double = 0

            If MetroTextBox1.Text.Trim = "" Then
                v_1 = " "
            Else
                v_1 = MetroTextBox1.Text.Trim
            End If

            If MetroTextBox2.Text.Trim = "" Then
                v_2 = " "
            Else
                v_2 = MetroTextBox2.Text.Trim
            End If

            If MetroTextBox3.Text.Trim = "" Then
                v_3 = 0
            Else
                v_3 = Val(MetroTextBox3.Text.Trim)
            End If

            If MetroTextBox4.Text.Trim = "" Then
                v_4 = " "
            Else
                v_4 = MetroTextBox4.Text.Trim
            End If

            If MetroTextBox11.Text.Trim = "" Then
                v_5 = 0
            Else
                v_5 = Val(MetroTextBox11.Text.Trim)
            End If



            Dim InsSql As String = ""
            InsSql = "Update Cuentas_Bancarias Set Detalle='" & v_2 & "',Banco=" & v_3 & ",Cbu='" & v_4 & "',Cuit=" & v_5 & ","
            InsSql = InsSql & "FechaAlta='" & j2 & "',HoraAlta='" & j3 & "',UsuarioAlta=" & j1 & " WHERE Numero = '" & reser_Cuenta & "' And Estado = 0"
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            Me.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub MetroTextBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTextBox1.Click

    End Sub
End Class

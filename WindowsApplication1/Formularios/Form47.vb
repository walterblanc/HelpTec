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


Public Class Form47
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Dim reser_Cuenta As String = ""
    Dim reser_Numero As Double = 0
    Public Sub New(ByVal v_cuenta As String, ByVal v_numero As Double)
        InitializeComponent()
        reser_Cuenta = v_cuenta
        reser_Numero = v_numero
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

    Private Sub MetroTextBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MetroTextBox3.KeyDown
        If e.KeyCode <> Keys.F1 Then
            Exit Sub
        End If

        rsv_Io = 1
        rsv_Seleccion = ""
        Dim Formulario_open As New Form48
        Formulario_open.ShowDialog()

        If rsv_Seleccion.Trim <> "" Then
            MetroTextBox3.Text = rsv_Seleccion
            MetroTextBox3.Focus()
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
   
    Private Sub metroTextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox5.KeyPress
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

    Private Sub Form47_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargo_CuentaBancaria()
        inicializo_formulario()

        If reser_Numero <> 0 Then
            cargo_Registro()
        End If
    End Sub
    Private Sub cargo_Registro()
        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim Sql As String = ""
            Sql = "Select * from Movimientos_Bancarios WHERE (Id= '" & reser_Numero & "') "


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    MetroDateTime1.Value = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)
                    MetroDateTime2.Value = FormatDateTime(drRecordSet("FechaValor").ToString, DateFormat.ShortDate)

                    MetroTextBox1.Text = drRecordSet("Comprobante").ToString
                    MetroTextBox2.Text = drRecordSet("Detalle").ToString
                    MetroTextBox3.Text = drRecordSet("Codigo").ToString
                    MetroTextBox5.Text = drRecordSet("Importe").ToString

                    If MetroTextBox5.Text.Trim = "" Then
                        MetroTextBox5.Text = "0.00"
                    End If
                    MetroTextBox5.Text = FormatNumber(Convert.ToDouble(MetroTextBox5.Text.Trim), 2)

                    Dim xDetalle As String = ""
                    Dim xDebcre As Integer = 0

                    MetroTextBox4.Text = ""

                    If MetroTextBox3.Text.Trim <> "" Then
                        Call Codigo_Bancario(Val(MetroTextBox3.Text), xDetalle, xDebcre)
                        MetroTextBox4.Text = xDetalle
                    End If


                End If
            End If

         
            drRecordSet.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub inicializo_formulario()
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox4.Text = ""
        MetroTextBox5.Text = "0.00"
        MetroDateTime1.Value = Now.Date
        MetroDateTime2.Value = Now.Date

        MetroDateTime1.Focus()

    End Sub


    Private Sub MetroTextBox3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox3.Validating
        Dim xDetalle As String = ""
        Dim xDebcre As Integer = 0
        MetroTextBox4.Text = ""

        If MetroTextBox3.Text.Trim <> "" Then
            Call Codigo_Bancario(Val(MetroTextBox3.Text), xDetalle, xDebcre)
            MetroTextBox4.Text = xDetalle
        End If

    End Sub

    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        inicializo_formulario()
    End Sub
    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        If MetroTextBox3.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar código bancario", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If MetroTextBox4.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar código bancario", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If MetroTextBox5.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar importe", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

       
        If Convert.ToDouble(MetroTextBox5.Text.Trim) = 0 Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar Importe", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        If reser_Numero = 0 Then
            nuevo_registro()
        End If
        If reser_Numero <> 0 Then
            modifica_registro()
        End If


    End Sub

   
    Private Sub nuevo_registro()
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
            Dim v_3 As String = ""
            Dim v_4 As Double = 0
            Dim v_5 As String = ""
            Dim v_6 As Integer = 0
            Dim v_7 As Double = 0
            Dim v_8 As Byte = 0

            v_1 = MetroTextBox8.Text.Trim
            v_2 = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate)
            v_3 = FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate)
            If MetroTextBox1.Text.Trim = "" Then
                v_4 = 0
            Else
                v_4 = CDbl(MetroTextBox1.Text.Trim)
            End If
            If MetroTextBox2.Text.Trim = "" Then
                v_5 = " "
            Else
                v_5 = MetroTextBox2.Text.Trim
            End If
            If MetroTextBox3.Text.Trim = "" Then
                v_6 = 0
            Else
                v_6 = CInt(MetroTextBox3.Text.Trim)
            End If
            If MetroTextBox5.Text.Trim = "" Then
                v_7 = 0
            Else
                v_7 = CDbl(MetroTextBox5.Text.Trim)
            End If

            Dim xDetalle As String = ""
            Dim xDebcre As Integer = 0

            If MetroTextBox3.Text.Trim <> "" Then
                Call Codigo_Bancario(Val(MetroTextBox3.Text), xDetalle, xDebcre)
            End If

            v_8 = xDebcre

            Dim InsSql As String = ""
            InsSql = "Insert into Movimientos_Bancarios (Numero,Fecha,FechaValor,Comprobante,Detalle,Codigo,Importe,DebCre,"
            InsSql = InsSql & "FechaAlta,HoraAlta,UsuarioAlta) Values ("
            InsSql = InsSql & "'" & v_1 & "','" & v_2 & "','" & v_3 & "'," & v_4 & ",'" & v_5 & "'," & v_6 & "," & v_7 & "," & v_8 & ","
            InsSql = InsSql & "'" & j2 & "','" & j3 & "'," & j1 & ")"

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()


            inicializo_formulario()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
    Private Sub modifica_registro()

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
            Dim v_3 As String = ""
            Dim v_4 As Double = 0
            Dim v_5 As String = ""
            Dim v_6 As Integer = 0
            Dim v_7 As Double = 0
            Dim v_8 As Byte = 0

            v_1 = MetroTextBox8.Text.Trim
            v_2 = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate)
            v_3 = FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate)
            If MetroTextBox1.Text.Trim = "" Then
                v_4 = 0
            Else
                v_4 = CDbl(MetroTextBox1.Text.Trim)
            End If
            If MetroTextBox2.Text.Trim = "" Then
                v_5 = " "
            Else
                v_5 = MetroTextBox2.Text.Trim
            End If
            If MetroTextBox3.Text.Trim = "" Then
                v_6 = 0
            Else
                v_6 = CInt(MetroTextBox3.Text.Trim)
            End If
            If MetroTextBox5.Text.Trim = "" Then
                v_7 = 0
            Else
                v_7 = CDbl(MetroTextBox5.Text.Trim)
            End If

            Dim xDetalle As String = ""
            Dim xDebcre As Integer = 0

            If MetroTextBox3.Text.Trim <> "" Then
                Call Codigo_Bancario(Val(MetroTextBox3.Text), xDetalle, xDebcre)
            End If

            v_8 = xDebcre

            Dim InsSql As String = ""
            InsSql = "Update Movimientos_Bancarios SET Numero='" & v_1 & "',Fecha='" & v_2 & "',FechaValor='" & v_3 & "',Comprobante=" & v_4 & ","
            InsSql = InsSql & "Detalle='" & v_5 & "',Codigo=" & v_6 & ",Importe=" & v_7 & ",DebCre=" & v_8 & ","
            InsSql = InsSql & "FechaAlta='" & j2 & "',HoraAlta='" & j3 & "',UsuarioAlta=" & j1 & " WHERE Id = " & reser_Numero & " "

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
  
    Private Sub MetroTextBox5_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox5.Validating
        If MetroTextBox5.Text.Trim = "" Then
            MetroTextBox5.Text = "0.00"
        End If
        MetroTextBox5.Text = FormatNumber(Convert.ToDouble(MetroTextBox5.Text.Trim), 2)
    End Sub

    Private Sub MetroTextBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTextBox3.Click

    End Sub

    Private Sub MetroTextBox3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox3.MouseEnter

    End Sub

    Private Sub MetroTextBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTextBox5.Click

    End Sub
End Class

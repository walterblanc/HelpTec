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


Public Class Form32
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Dim reser_Cliente As Double = 0
    Dim reser_accion As Byte = 0
    Public Sub New(ByVal v_Cliente As Double)
        InitializeComponent()
        reser_Cliente = v_Cliente
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
    Private Sub metroTextBox26_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox26.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub metroTextBox13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox13.KeyPress
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
    Private Sub metroTextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox9.KeyPress
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
    Private Sub metroTextBox12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox12.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Private Sub metroTextBox15_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox15.KeyPress
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

    Private Sub Form32_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        MetroTextBox9.Text = ""
        MetroTextBox10.Text = ""
        MetroTextBox11.Text = ""
        MetroRadioButton1.Checked = True

        MetroTextBox26.Text = "J"
        MetroTextBox13.Text = ""
        MetroTextBox9.Text = ""
        MetroTextBox12.Text = ""
        MetroTextBox15.Text = "0.00"
        MetroDateTime1.Value = Now.Date

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

                    MetroTextBox13.Focus()

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
        Try
            Dim x1 As Double = 0
            Dim x2 As String = ""
            Dim x3 As String = ""
            Dim x4 As Byte = 0
            Dim x5 As Byte = 0
            Dim x6 As String = ""
            Dim x7 As String = ""
            Dim x8 As Double = 0
            Dim x9 As String = ""



            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")

            x1 = CDbl(MetroTextBox1.Text.Trim)
            x2 = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate) '10/01/2009
            x3 = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate) '10/01/2009

            If MetroRadioButton1.Checked = True Then
                x4 = 1
                x5 = 5
            End If
            If MetroRadioButton1.Checked = False Then
                x4 = 2
                x5 = 6
            End If


            If MetroTextBox9.Text.Trim = "" Then
                MetroTextBox9.Text = "0"
            End If
            If MetroTextBox13.Text.Trim = "" Then
                MetroTextBox13.Text = "0"
            End If
            If MetroTextBox15.Text.Trim = "" Then
                MetroTextBox15.Text = "0"
            End If
            If MetroTextBox15.Text.Trim = "." Then
                MetroTextBox15.Text = "0"
            End If
            If MetroTextBox12.Text.Trim = "" Then
                MetroTextBox12.Text = "Ajuste de referencia"
            End If

            x6 = "J"
            x7 = formateo_numero(Val(MetroTextBox13.Text.Trim), Val(MetroTextBox9.Text.Trim))
            x8 = CDbl(MetroTextBox15.Text.Trim)
            x9 = MetroTextBox12.Text.Trim


            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim InsSql As String = ""
            InsSql = ""
            InsSql = "Insert into Cuenta_Corriente_Clientes ("
            InsSql = InsSql & "Cliente,Fecha,FechaImputado,DebCre,CodigoMovimiento,LetraComprobante,NumeroComprobante,Importe,Detalle,"
            InsSql = InsSql & "ImputaIva,"
            InsSql = InsSql & "UsuarioAlta,FechaAlta,HoraAlta,Estado) Values ("
            InsSql = InsSql & "" & x1 & ",'" & x2 & "','" & x3 & "'," & x4 & "," & x5 & ",'" & x6 & "','" & x7 & "'," & x8 & ",'" & x9 & "',"
            InsSql = InsSql & "1,"
            InsSql = InsSql & "" & j1 & ",'" & j2 & "','" & j3 & "',0)"
            Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            ConSql.Close()

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Function formateo_numero(ByVal x1 As Integer, ByVal x2 As Double) As String
        Dim r As String = ""
        Try

            Dim xNumeroDe4 As String
            Dim xNumeroDe8 As String

            xNumeroDe4 = x1
            xNumeroDe4 = xNumeroDe4.PadLeft(4)
            xNumeroDe4 = xNumeroDe4.Replace(" ", "0")

            xNumeroDe8 = x2
            xNumeroDe8 = xNumeroDe8.PadLeft(8)
            xNumeroDe8 = xNumeroDe8.Replace(" ", "0")

            r = xNumeroDe4 & "-" & xNumeroDe8
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            formateo_numero = r
        End Try

    End Function
End Class

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


Public Class Form10
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Dim reser_proveedor As Double = 0
    Dim reser_accion As Byte = 0
    Public Sub New(ByVal v_proveedor As Double, ByVal v_accion As Byte)
        InitializeComponent()
        reser_proveedor = v_proveedor
        reser_accion = v_accion
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
    Private Sub metroTextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox9.KeyPress
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

    Private Sub Form10_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        inicializo_formulario()
        cargarCOMBO(MetroComboBox1, 2)
        If reser_accion = 2 Then
            cargo_proveedor()
        End If

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

    End Sub
    Private Sub MetroButton1_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton1.Click
        If MetroTextBox1.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Cuit del Proveedor Inválido", rsv_modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If reser_accion = 1 Then
            nuevo_proveedor()
        End If
        If reser_accion = 2 Then
            modifica_proveedor()
        End If

    End Sub

    Private Sub MetroButton2_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton2.Click
        If reser_accion = 2 Then
            Exit Sub
        End If
        inicializo_formulario()
    End Sub

    Private Sub MetroButton3_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub
    Private Sub cargo_proveedor()
        Dim r As Integer = 1
        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim Sql As String = ""
            Sql = "Select * from Proveedores WHERE (Numero= " & reser_proveedor & ") And (Estado=0) "


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
                    MetroTextBox9.Text = drRecordSet("Contacto").ToString
                    MetroTextBox10.Text = drRecordSet("email").ToString
                    MetroTextBox11.Text = drRecordSet("Cuit").ToString


                    Call buscarCombo(MetroComboBox1, Val(drRecordSet("Responsable").ToString))

                    MetroTextBox1.Enabled = False
                    MetroTextBox2.Focus()



                End If
            End If

            drRecordSet.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
    Private Sub nuevo_proveedor()
        Try

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")



            Dim v_1 As Double = 0
            Dim v_2 As String = ""
            Dim v_3 As String = ""
            Dim v_4 As String = ""
            Dim v_5 As String = ""
            Dim v_6 As String = ""
            Dim v_7 As String = ""
            Dim v_8 As String = ""
            Dim v_9 As String = ""
            Dim v_10 As String = ""
            Dim v_11 As Byte = 0
            Dim v_12 As Double = 0

            If MetroTextBox1.Text.Trim = "" Then
                v_1 = 0
            Else
                v_1 = Val(MetroTextBox1.Text.Trim)
            End If

            If MetroTextBox2.Text.Trim = "" Then
                v_2 = " "
            Else
                v_2 = MetroTextBox2.Text.Trim
            End If

            If MetroTextBox3.Text.Trim = "" Then
                v_3 = " "
            Else
                v_3 = MetroTextBox3.Text.Trim
            End If

            If MetroTextBox4.Text.Trim = "" Then
                v_4 = " "
            Else
                v_4 = MetroTextBox4.Text.Trim
            End If

            If MetroTextBox5.Text.Trim = "" Then
                v_5 = " "
            Else
                v_5 = MetroTextBox5.Text.Trim
            End If

            If MetroTextBox6.Text.Trim = "" Then
                v_6 = " "
            Else
                v_6 = MetroTextBox6.Text.Trim
            End If

            If MetroTextBox7.Text.Trim = "" Then
                v_7 = " "
            Else
                v_7 = MetroTextBox7.Text.Trim
            End If

            If MetroTextBox8.Text.Trim = "" Then
                v_8 = " "
            Else
                v_8 = MetroTextBox8.Text.Trim
            End If

            If MetroTextBox9.Text.Trim = "" Then
                v_9 = " "
            Else
                v_9 = MetroTextBox9.Text.Trim
            End If

            If MetroTextBox10.Text.Trim = "" Then
                v_10 = " "
            Else
                v_10 = MetroTextBox10.Text.Trim
            End If

            v_11 = CType(MetroComboBox1.SelectedItem, ValueDescriptionPair).Value

            If MetroTextBox11.Text.Trim = "" Then
                v_12 = 0
            Else
                v_12 = CDbl(MetroTextBox11.Text.Trim)
            End If


            Dim InsSql As String = ""
            InsSql = "Insert into Proveedores (Numero,RazonSocial,Comercial,Domicilio,Ciudad,Provincia,Telefono,Celular,Contacto,email,Responsable,Cuit,"
            InsSql = InsSql & "Af,Ah,Au) Values ("
            InsSql = InsSql & "" & v_1 & ",'" & v_2 & "','" & v_3 & "','" & v_4 & "','" & v_5 & "','" & v_6 & "','" & v_7 & "','" & v_8 & "','" & v_9 & "','" & v_10 & "'," & v_11 & "," & v_12 & ","
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
    Private Sub modifica_proveedor()
        Try

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")



            Dim v_1 As Double = 0
            Dim v_2 As String = ""
            Dim v_3 As String = ""
            Dim v_4 As String = ""
            Dim v_5 As String = ""
            Dim v_6 As String = ""
            Dim v_7 As String = ""
            Dim v_8 As String = ""
            Dim v_9 As String = ""
            Dim v_10 As String = ""
            Dim v_11 As Byte = 0
            Dim v_12 As Double = 0

            If MetroTextBox1.Text.Trim = "" Then
                v_1 = 0
            Else
                v_1 = Val(MetroTextBox1.Text.Trim)
            End If

            If MetroTextBox2.Text.Trim = "" Then
                v_2 = " "
            Else
                v_2 = MetroTextBox2.Text.Trim
            End If

            If MetroTextBox3.Text.Trim = "" Then
                v_3 = " "
            Else
                v_3 = MetroTextBox3.Text.Trim
            End If

            If MetroTextBox4.Text.Trim = "" Then
                v_4 = " "
            Else
                v_4 = MetroTextBox4.Text.Trim
            End If

            If MetroTextBox5.Text.Trim = "" Then
                v_5 = " "
            Else
                v_5 = MetroTextBox5.Text.Trim
            End If

            If MetroTextBox6.Text.Trim = "" Then
                v_6 = " "
            Else
                v_6 = MetroTextBox6.Text.Trim
            End If

            If MetroTextBox7.Text.Trim = "" Then
                v_7 = " "
            Else
                v_7 = MetroTextBox7.Text.Trim
            End If

            If MetroTextBox8.Text.Trim = "" Then
                v_8 = " "
            Else
                v_8 = MetroTextBox8.Text.Trim
            End If

            If MetroTextBox9.Text.Trim = "" Then
                v_9 = " "
            Else
                v_9 = MetroTextBox9.Text.Trim
            End If

            If MetroTextBox10.Text.Trim = "" Then
                v_10 = " "
            Else
                v_10 = MetroTextBox10.Text.Trim
            End If

            v_11 = CType(MetroComboBox1.SelectedItem, ValueDescriptionPair).Value

            If MetroTextBox11.Text.Trim = "" Then
                v_12 = 0
            Else
                v_12 = CDbl(MetroTextBox11.Text.Trim)
            End If


            Dim InsSql As String = ""
            InsSql = "Update Proveedores Set RazonSocial='" & v_2 & "',Comercial='" & v_3 & "',Domicilio='" & v_4 & "',Ciudad='" & v_5 & "',"
            InsSql = InsSql & "Provincia='" & v_6 & "',Telefono='" & v_7 & "',Celular='" & v_8 & "',Contacto='" & v_9 & "',email='" & v_10 & "',Responsable=" & v_11 & ",Cuit=" & v_12 & ","
            InsSql = InsSql & "Afm='" & j2 & "',Ah='" & j3 & "',Au=" & j1 & " WHERE Numero = " & reser_proveedor & " And Estado = 0"
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
End Class

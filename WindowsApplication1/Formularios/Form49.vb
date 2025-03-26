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


Public Class Form49
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Dim reser_Codigo As Integer = 0
    Dim reser_accion As Byte = 0
    Public Sub New(ByVal v_Codigo As Integer, ByVal v_accion As Byte)
        InitializeComponent()
        reser_Codigo = v_Codigo
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
  
#End Region

    Private Sub Form49_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        inicializo_formulario()
        If reser_accion = 2 Then
            cargo_Codigos()
        Else
            ultimo_numero()
        End If



    End Sub
    Private Sub inicializo_formulario()
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroRadioButton1.Checked = True

        MetroTextBox1.Enabled = True

    End Sub
    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub
    Private Sub cargo_Codigos()
        Dim r As Integer = 1
        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim Sql As String = ""
            Sql = "Select * from Codigos_Bancarios WHERE (Codigo= '" & reser_Codigo & "') And (Estado=0) "


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    MetroTextBox1.Text = drRecordSet("Codigo").ToString
                    MetroTextBox2.Text = drRecordSet("Detalle").ToString

                    If Val(drRecordSet("DebCre").ToString) = 1 Then
                        MetroRadioButton1.Checked = True
                    Else
                        MetroRadioButton2.Checked = True
                    End If
                    MetroTextBox1.Enabled = False
                    MetroTextBox2.Focus()
                End If
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
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar Código", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MetroTextBox2.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar Nombre del Código", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

 
        If reser_accion = 1 Then
            nuevo_Codigo()
        End If
        If reser_accion = 2 Then
            modifica_Codigo()
        End If

    End Sub

    Private Sub nuevo_Codigo()
        Try

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")



            Dim v_1 As Integer = 0
            Dim v_2 As String = ""
            Dim v_3 As Byte = 0

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

            If MetroRadioButton1.Checked = True Then
                v_3 = 1
            Else
                v_3 = 2
            End If
         


            Dim InsSql As String = ""
            InsSql = "Insert into Codigos_Bancarios (Codigo,Detalle,Debcre,"
            InsSql = InsSql & "FechaAlta,HoraAlta,UsuarioAlta) Values ("
            InsSql = InsSql & "" & v_1 & ",'" & v_2 & "'," & v_3 & ","
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
    Private Sub modifica_Codigo()
        Try
            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")



            Dim v_1 As Integer = 0
            Dim v_2 As String = ""
            Dim v_3 As Byte = 0

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

            If MetroRadioButton1.Checked = True Then
                v_3 = 1
            Else
                v_3 = 2
            End If

            Dim InsSql As String = ""
            InsSql = "Update Codigos_Bancarios Set Detalle='" & v_2 & "',DebCre=" & v_3 & ","
            InsSql = InsSql & "FechaAlta='" & j2 & "',HoraAlta='" & j3 & "',UsuarioAlta=" & j1 & " WHERE Codigo= '" & reser_Codigo & "' And Estado = 0"
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
    Private Sub ultimo_numero()
        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            MetroTextBox1.Text = 1
            MetroTextBox1.Enabled = False

            Dim Sql As String = ""
            Sql = "Select * from Codigos_Bancarios ORDER BY Codigo DESC "


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    MetroTextBox1.Text = Convert.ToDouble(drRecordSet("Codigo").ToString) + 1
                End If
            End If

            drRecordSet.Close()
            MetroTextBox2.Focus()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub


End Class

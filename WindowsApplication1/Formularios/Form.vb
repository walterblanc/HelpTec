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
Imports System.Globalization

Public Class Form
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Private Sub Form_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim oldDecimalSeparator As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator

        Dim forceDotCulture As CultureInfo
        forceDotCulture = Application.CurrentCulture.Clone()
        forceDotCulture.NumberFormat.NumberDecimalSeparator = "."
        forceDotCulture.NumberFormat.NumberGroupSeparator = ","
        Application.CurrentCulture = forceDotCulture

        rsv_Usuario = 0
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox1.Focus()



    End Sub

    Private Sub MetroButton1_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton1.Click
        Try
            If MetroTextBox1.Text.Trim = "" Then
                MetroFramework.MetroMessageBox.Show(Me, "Debe especificar nombre de Usuario", rsv_modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If MetroTextBox2.Text.Trim = "" Then
                MetroFramework.MetroMessageBox.Show(Me, "Debe especificar palabra clave", rsv_modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim v1 As String = MetroTextBox1.Text.Trim
            Dim v2 As String = MetroTextBox2.Text.Trim

            Dim x As Byte = 0

            Dim Sql As String = ""
            Sql = "Select * from Usuarios WHERE Usuario= '" & v1 & "' And Clave='" & v2 & "' "

            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    If Val(drRecordSet("Estado").ToString) <> 0 Then
                        x = 1
                    End If
                    If Val(drRecordSet("Bloqueo").ToString) <> 0 Then
                        x = 2
                    End If

                    rsv_Usuario = Val(drRecordSet("Numero").ToString)
                End If
            Else
                MetroFramework.MetroMessageBox.Show(Me, "El usuario ingresado no es válido", rsv_modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                rsv_Usuario = 0
                Exit Sub
            End If

            drRecordSet.Close()

            If x = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Usuario inactivo", rsv_modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                rsv_Usuario = 0
                Exit Sub
            End If
            If x = 2 Then
                MetroFramework.MetroMessageBox.Show(Me, "Usuario bloqueado", rsv_modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                rsv_Usuario = 0
                Exit Sub
            End If
            Me.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try


    End Sub
    Private Sub MetroButton2_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton2.Click
        End
    End Sub
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

End Class

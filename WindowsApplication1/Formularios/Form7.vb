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


Public Class Form7
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)
    Dim reser_param As Integer = 0
    Dim reser_numero As Integer = 0
    Dim reser_accion As Byte = 0
    Public Sub New(ByVal v_param As Integer, ByVal v_numero As Integer, ByVal v_accion As Byte)
        InitializeComponent()
        reser_numero = v_numero
        reser_param = v_param
        reser_accion = v_accion
    End Sub

#Region "ControlText"
    Private Sub metroTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

#End Region
    Private Sub Form7_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        inicializa_form()
        If reser_accion = 2 Then
            cargar_parametro()
        End If
    End Sub
    Private Sub inicializa_form()
        MetroTextBox1.Text = ""
    End Sub


    Private Sub MetroButton1_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton1.Click

        If MetroTextBox1.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar detalle", rsv_modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If reser_accion = 1 Then
            alta_nuevo_parametro()
        End If
        If reser_accion = 2 Then
            modificar_parametro()
        End If

    End Sub

    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub
    Private Sub alta_nuevo_parametro()
        Try

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")



            Dim x_v1 As Integer = 0
            Dim x_v2 As String = ""


            x_v1 = numero_parametro_siguiente()

            If x_v1 = 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "Error al retornar número de parámetro", rsv_modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            If MetroTextBox1.Text.Trim = "" Then
                x_v2 = " "
            Else
                x_v2 = MetroTextBox1.Text.Trim
            End If
            Dim Sql As String = ""

            Sql = "Insert Into Parametros (Param,Numero,Detalle,Estado,"
            Sql = Sql & "Af,Ah,Au) Values (" & reser_param & ", " & x_v1 & ",'" & x_v2 & "',0,"
            Sql = Sql & "'" & j2 & "','" & j3 & "'," & j1 & ")"

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConSql.Close()
        End Try

    End Sub
    Private Function numero_parametro_siguiente() As Integer
        Dim r As Integer = 1
        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim Sql As String = ""
            Sql = "Select TOP 1 * From Parametros WHERE Param=" & reser_param & " Order by Numero DESC"


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then

                    r = Val(drRecordSet("Numero").ToString) + 1
                End If
            End If

            drRecordSet.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            numero_parametro_siguiente = r
        End Try
    End Function
    Private Sub cargar_parametro()
        Dim r As Integer = 1
        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim Sql As String = ""
            Sql = "Select * From parametros WHERE Param= " & reser_param & " And Numero = " & reser_numero & " "


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    MetroTextBox1.Text = drRecordSet("Detalle").ToString
                End If
            End If

            drRecordSet.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Sub modificar_parametro()
        Try

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")



            Dim x_v1 As Integer = 0
            Dim x_v2 As String = ""
            Dim x_v3 As String = ""


            x_v1 = reser_numero

            If MetroTextBox1.Text.Trim = "" Then
                x_v2 = " "
            Else
                x_v2 = MetroTextBox1.Text.Trim
            End If

            Dim Sql As String = ""

            Sql = "Update Parametros SET Detalle='" & x_v2 & "',"
            Sql = Sql & "Afm='" & j2 & "',Ahm='" & j3 & "',Aum=" & j1 & " WHERE Param=" & reser_param & " And Numero= " & x_v1 & " "

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConSql.Close()
        End Try

    End Sub

End Class

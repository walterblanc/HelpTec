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


Public Class Form4
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)
    Dim reser_usuario As Integer = 0
    Dim reser_accion As Byte = 0
    Public Sub New(ByVal v_usuario As Integer, ByVal v_accion As Byte)
        InitializeComponent()
        reser_usuario = v_usuario
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
    End Sub

#End Region
    Private Sub Form4_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        inicializa_form()

        MetroTextBox4.Text = GenerarCadena(8)

        If reser_accion = 2 Then
            MetroTextBox4.Visible = False
            MetroButton2.Visible = False
            MetroLabel5.Visible = False
            cargar_usuario()
        End If
    End Sub
    Private Sub inicializa_form()
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox4.Text = ""
    End Sub


    Private Sub MetroButton1_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton1.Click

        If MetroTextBox1.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar nombre de Usuario", rsv_modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If MetroTextBox3.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar nombre de acceso de Usuario", rsv_modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If verifica_existencia() = True Then
            MetroFramework.MetroMessageBox.Show(Me, "Usuario existente en base", rsv_modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If reser_accion = 1 Then
            alta_nuevo_usuario()
        End If
        If reser_accion = 2 Then
            modificar_usuario()
        End If

    End Sub
    Private Function verifica_existencia() As Boolean
        Dim r As Boolean = False
        Try

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim v1 As String = MetroTextBox3.Text.Trim

            Dim Sql As String = ""

            If reser_accion = 1 Then
                Sql = "Select * from Usuarios WHERE Usuario= '" & v1 & "' "
            Else
                Sql = "Select * from Usuarios WHERE Usuario= '" & v1 & "' And Numero <> " & reser_usuario & " "
            End If

            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    r = True
                End If
            End If

            drRecordSet.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            verifica_existencia = r
        End Try
    End Function


    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub
    Private Sub alta_nuevo_usuario()
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
            Dim x_v4 As String = ""
            Dim x_v5 As String = ""


            x_v1 = numero_usuario_siguiente()

            If x_v1 = 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "Error al retornar número de usuario", rsv_modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If MetroTextBox4.Text.Trim = "" Then
                MetroFramework.MetroMessageBox.Show(Me, "Debe generar Clave Inicial", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            x_v5 = MetroTextBox4.Text.Trim

            If MetroTextBox1.Text.Trim = "" Then
                x_v2 = " "
            Else
                x_v2 = MetroTextBox1.Text.Trim
            End If
            If MetroTextBox2.Text.Trim = "" Then
                x_v3 = " "
            Else
                x_v3 = MetroTextBox2.Text.Trim
            End If
            If MetroTextBox3.Text.Trim = "" Then
                x_v4 = " "
            Else
                x_v4 = MetroTextBox3.Text.Trim
            End If

            Dim Sql As String = ""

            Sql = "Insert Into Usuarios (Numero,Nombre,email,Clave,Estado,Bloqueo,Usuario,"
            Sql = Sql & "Af,Ah,Au) Values (" & x_v1 & ",'" & x_v2 & "','" & x_v3 & "','" & x_v5 & "',0,0,'" & x_v4 & "',"
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
    Private Function numero_usuario_siguiente() As Integer
        Dim r As Integer = 1
        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim Sql As String = ""
            Sql = "Select TOP 1 * from Usuarios Order by Numero DESC"


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
            numero_usuario_siguiente = r
        End Try
    End Function
    Private Sub cargar_usuario()
        Dim r As Integer = 1
        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim Sql As String = ""
            Sql = "Select * from Usuarios WHERE Numero = " & reser_usuario & " "


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    MetroTextBox1.Text = drRecordSet("Nombre").ToString
                    MetroTextBox2.Text = drRecordSet("email").ToString
                End If
            End If

            drRecordSet.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Sub modificar_usuario()
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
            Dim x_v4 As String = ""


            x_v1 = reser_usuario

            If MetroTextBox1.Text.Trim = "" Then
                x_v2 = " "
            Else
                x_v2 = MetroTextBox1.Text.Trim
            End If
            If MetroTextBox2.Text.Trim = "" Then
                x_v3 = " "
            Else
                x_v3 = MetroTextBox2.Text.Trim
            End If
            If MetroTextBox2.Text.Trim = "" Then
                x_v3 = " "
            Else
                x_v3 = MetroTextBox2.Text.Trim
            End If

            Dim Sql As String = ""

            Sql = "Update Usuarios SET Nombre='" & x_v2 & "',email='" & x_v3 & "',Usuario='" & x_v4 & "',"
            Sql = Sql & "Afm='" & j2 & "',Ahm='" & j3 & "',Aum=" & j1 & " WHERE Numero= " & x_v1 & " "

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

    Private Sub numero_aleatorio()
        'Dim numAleatorio As New Random(CInt(Date.Now.Ticks And Integer.MaxValue))
        'MetroTextBox4.Text = System.Convert.ToString(numAleatorio.Next)

        MetroTextBox4.Text = GenerarCadena(8)

    End Sub

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        numero_aleatorio()
    End Sub
    Private Function GenerarCadena(ByVal numeroCaracteres As Integer) As String

        ' Dimensionamos un array para almacenar tanto las 
        ' letras mayúsculas como minúsculas (52 letras). 
        ' 
        Dim letras(51) As String

        ' Rellenamos el array. 
        ' 
        Dim n As Integer
        For item As Int32 = 65 To 90
            letras(n) = Chr(item)
            letras(n + 1) = letras(n).ToLower
            n += 2
        Next

        Dim cadenaAleatoria As String = String.Empty

        ' Iniciamos el generador de números aleatorios 
        ' 
        Dim rnd As New Random(DateTime.Now.Millisecond)

        For n = 0 To numeroCaracteres

            Dim numero As Integer = rnd.Next(0, 51)

            cadenaAleatoria &= letras(numero)

        Next

        Return cadenaAleatoria

    End Function
End Class

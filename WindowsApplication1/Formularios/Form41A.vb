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


Public Class Form41A
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)


    Private Sub Form41A_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox4.Text = ""
        cargar_datos_iniciales()
    End Sub
    Private Sub cargar_datos_iniciales()
        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()


            Dim cmdTemp As New OleDbCommand("Select * from Configuracion_Afip WHERE (Id = 1) ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    If Val(drTemp("Homologacion").ToString()) = 1 Then
                        MetroCheckBox1.Checked = True
                    Else
                        MetroCheckBox1.Checked = False
                    End If

                    MetroTextBox1.Text = drTemp("Certificados").ToString()
                    MetroTextBox2.Text = drTemp("Tickets").ToString()
                    MetroTextBox3.Text = drTemp("ArchiXml").ToString()
                    MetroTextBox4.Text = drTemp("Llave").ToString()
                End If
            End If
            drTemp.Close()
            ConSql.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_Modulo, MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub metroTextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox4.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub

    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        Try
            MetroTextBox1.Text = ""
            With FolderBrowserDialog1

                .Reset() ' resetea
                .Description = " Seleccionar una carpeta para pasar la copia de seguridad "
                ' Path " Mis documentos " este es que estara seleccionado por defecto, puedes cambiarlo
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                '.RootFolder = Environment.SpecialFolder.Desktop
                '.RootFolder = Environment.SpecialFolder.StartMenu

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo

                ' si se presionó el botón aceptar ...
                If ret = Windows.Forms.DialogResult.OK Then
                    'Dim ruta As ObjectModel.ReadOnlyCollection(Of String)
                    MetroTextBox1.Text = .SelectedPath
                End If

                .Dispose()

            End With
        Catch oe As Exception
            MsgBox(oe.Message, MsgBoxStyle.Critical)
        End Try


    End Sub

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        Try
            MetroTextBox2.Text = ""
            With FolderBrowserDialog1

                .Reset() ' resetea
                .Description = " Seleccionar una carpeta para pasar la copia de seguridad "
                ' Path " Mis documentos " este es que estara seleccionado por defecto, puedes cambiarlo
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                '.RootFolder = Environment.SpecialFolder.Desktop
                '.RootFolder = Environment.SpecialFolder.StartMenu

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo

                ' si se presionó el botón aceptar ...
                If ret = Windows.Forms.DialogResult.OK Then
                    'Dim ruta As ObjectModel.ReadOnlyCollection(Of String)
                    MetroTextBox2.Text = .SelectedPath
                End If

                .Dispose()

            End With
        Catch oe As Exception
            MsgBox(oe.Message, MsgBoxStyle.Critical)
        End Try


    End Sub

    Private Sub MetroButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton4.Click
        Try
            MetroTextBox3.Text = ""
            With FolderBrowserDialog1

                .Reset() ' resetea
                .Description = " Seleccionar una carpeta para pasar la copia de seguridad "
                ' Path " Mis documentos " este es que estara seleccionado por defecto, puedes cambiarlo
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                '.RootFolder = Environment.SpecialFolder.Desktop
                '.RootFolder = Environment.SpecialFolder.StartMenu

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo

                ' si se presionó el botón aceptar ...
                If ret = Windows.Forms.DialogResult.OK Then
                    'Dim ruta As ObjectModel.ReadOnlyCollection(Of String)
                    MetroTextBox3.Text = .SelectedPath
                End If

                .Dispose()

            End With
        Catch oe As Exception
            MsgBox(oe.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub MetroButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton5.Click
        If MetroTextBox1.Text.Trim.Length = 0 Then
            MetroFramework.MetroMessageBox.Show(Me, "No especifico Ruta de Certificados", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If MetroTextBox2.Text.Trim.Length = 0 Then
            MetroFramework.MetroMessageBox.Show(Me, "No especifico Ruta de Tickets", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If MetroTextBox3.Text.Trim.Length = 0 Then
            MetroFramework.MetroMessageBox.Show(Me, "No especifico Ruta de Archivos XML", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If MetroTextBox4.Text.Trim.Length = 0 Then
            MetroFramework.MetroMessageBox.Show(Me, "No especifico Llave Certificado", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Try

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")


            Dim x1 As Integer = 0
            Dim x2 As String = ""
            Dim x3 As String = ""
            Dim x4 As String = ""
            Dim x5 As String = ""

            If MetroCheckBox1.Checked = True Then
                x1 = 1
            End If

            x2 = MetroTextBox1.Text.Trim
            x3 = MetroTextBox2.Text.Trim
            x4 = MetroTextBox3.Text.Trim
            x5 = MetroTextBox4.Text.Trim

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim Sql As String = ""
            Sql = "UPDATE Configuracion_afip Set Homologacion=" & x1 & ",Certificados='" & x2 & "',Tickets='" & x3 & "',ArchiXml='" & x4 & "',Llave='" & x5 & "',"
            Sql = Sql & "Ua=" & j1 & ",Ha='" & j3 & "',Fa='" & j2 & "' WHERE ID=1"

            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            ConSql.Close()

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
End Class

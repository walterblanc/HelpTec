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


Public Class Form40A
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)


    Private Sub Form40A_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""

        MetroRadioButton1.Checked = True

        Call cargar_configuracion()

        If rsv_Afip_Certif.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Problemas en Archivo Configuración Afip", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            MetroButton1.Enabled = False
            MetroButton2.Enabled = False
            MetroButton3.Enabled = False
            MetroButton4.Enabled = False
            MetroButton5.Enabled = False
            MetroButton7.Enabled = False
        End If


    End Sub
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

    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub

    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        If isOnline() = False Then
            MetroFramework.MetroMessageBox.Show(Me, "No existe conexión a Internet", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        FEDummy_AppServer()
    End Sub

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        If isOnline() = False Then
            MetroFramework.MetroMessageBox.Show(Me, "No existe conexión a Internet", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        FEDummy_AuthServer()
    End Sub

    Private Sub MetroButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton4.Click
        If isOnline() = False Then
            MetroFramework.MetroMessageBox.Show(Me, "No existe conexión a Internet", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        FEDummy_DbServer()
    End Sub

    Private Sub MetroButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton5.Click
        If isOnline() = False Then
            MetroFramework.MetroMessageBox.Show(Me, "No existe conexión a Internet", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim s As Boolean = state_service_afip()
        If s = True Then
            MetroFramework.MetroMessageBox.Show(Me, "Todos los Servicios Funcionando", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MetroFramework.MetroMessageBox.Show(Me, "Problemas en Servicios Afip", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub MetroButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton6.Click
        Dim sPath As String = rsv_Afip_Tickets & "\ta.xml"

        If System.IO.File.Exists(sPath) Then


            My.Computer.FileSystem.DeleteFile( _
                            sPath, _
                            FileIO.UIOption.AllDialogs, _
                            FileIO.RecycleOption.SendToRecycleBin, _
                            FileIO.UICancelOption.DoNothing)


        End If

    End Sub

    Private Sub MetroButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton7.Click


        If isOnline() = False Then
            MetroFramework.MetroMessageBox.Show(Me, "No existe conexión a Internet", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If



        Dim r As String = ""

        Dim pto_vta As String = MetroTextBox1.Text.Trim.ToUpper
        Dim Tipo As String = ""
        Dim cod_err As Byte = 0
        Dim msg_err As String = ""

        If MetroTextBox2.Text.Trim.ToUpper = "A" Then
            If MetroRadioButton1.Checked = True Then
                Tipo = "01"
            End If
            If MetroRadioButton2.Checked = True Then
                Tipo = "02"
            End If
            If MetroRadioButton3.Checked = True Then
                Tipo = "03"
            End If
        Else
            If MetroRadioButton1.Checked = True Then
                Tipo = "06"
            End If
            If MetroRadioButton2.Checked = True Then
                Tipo = "07"
            End If
            If MetroRadioButton3.Checked = True Then
                Tipo = "08"
            End If
        End If
        r = consulta_ultimo_comprobante_afip(pto_vta, Tipo, cod_err, msg_err)

        If cod_err = 0 Then
            MetroTextBox3.Text = r


            If msg_err.Trim <> "" Then
                MetroFramework.MetroMessageBox.Show(Me, "Mensaje Afip" & vbCrLf & msg_err, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else
            MetroTextBox3.Text = "err"
        End If

    End Sub

End Class

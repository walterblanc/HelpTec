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


Public Class Form39A
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)


    Private Sub Form39A_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If isOnline() = False Then
            MetroFramework.MetroMessageBox.Show(Me, "No existe conexión a Internet", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            MetroButton1.Enabled = False
            Exit Sub
        End If



        Call cargar_configuracion()

        If rsv_Afip_Certif.Trim = "" Then
            MessageBox.Show("Problemas en Archivo Configuración Afip", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MetroButton1.Enabled = False
        End If
    End Sub

    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        Dim arg1 As String = ""

        '        Dim s As String = "-s wsfe -c C:\OpenSSL-Win32\bin\certificado_laarena.p12 -p laarena -v on"
        'Dim s As String = "-s wsfe -c C:\OpenSSL-Win32\bin\certificado.p12 -p laarena -v on"
        '        Dim s As String = "-s wsfe -c " & rsv_Afip_Certif & "\certificado.p12 -p laarena -v on"
        Dim s As String = "-s wsfe -c " & rsv_Afip_Certif & "\certificado.p12 -p " & rsv_Afip_Llave & " -v on"

        ' Split string based on spaces.
        Dim words As String() = s.Split(New Char() {" "c})


        Dim objObtener_Ticket_Afip As Obtener_Ticket_Afip = New Obtener_Ticket_Afip

        arg1 = Obtener_Ticket_Afip.Obtener_Ticket_Afip_Main(words)

        If Val(arg1) = 0 Then
            MetroFramework.MetroMessageBox.Show(Me, "Ticket Exitoso", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            Exit Sub
        Else
            MetroFramework.MetroMessageBox.Show(Me, "Problemas en la Solicitud de Ticket", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub
End Class

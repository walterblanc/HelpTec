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


Public Class Form1


    Private Sub MetroTile1_Click(sender As System.Object, e As System.EventArgs) Handles MetroTile1.Click
        Dim Formulario_open As New Form29
        Formulario_open.ShowDialog()

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        rsv_Modulo = "Gestión de Administración Comercial"
        configuracioninicial()

        'Fecha de implementacion 01-08-2020
        System.Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        Dim Formulario_open As New Form
        Formulario_open.ShowDialog()


        If rsv_Usuario = 0 Then
            End
        End If

        rsv_Impresora_Defecto = impresoras_disponibles(rsv_Terminal, 1)
        rsv_impresora_Termica = impresoras_disponibles(rsv_Terminal, 2)

        If rsv_Impresora_Defecto.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "No se encuentra definida la impresora por defecto", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If rsv_impresora_Termica.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "No se encuentra definida la impresora por defecto", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

    End Sub

    Private Sub MetroTile2_Click(sender As System.Object, e As System.EventArgs) Handles MetroTile2.Click
        Dim Formulario_open As New Form5
        Formulario_open.ShowDialog()


    End Sub


    Private Sub MetroTile4_Click(sender As System.Object, e As System.EventArgs) Handles MetroTile4.Click
        Dim Formulario_open As New Form20
        Formulario_open.ShowDialog()
    End Sub

   
    Private Sub MetroTile5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile5.Click
        Dim Formulario_open As New Form16
        Formulario_open.ShowDialog()

    End Sub

    Private Sub MetroTile6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile6.Click
        Dim Formulario_open As New Form8
        Formulario_open.ShowDialog()

    End Sub

    Private Sub MetroTile7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile7.Click
        Dim Formulario_open As New Form11
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile10.Click
        Dim Formulario_open As New Form2
        Formulario_open.ShowDialog()
    End Sub

   
    Private Sub MetroTile11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile11.Click
        Dim Formulario_open As New Form38A
        Formulario_open.ShowDialog()
    End Sub
End Class

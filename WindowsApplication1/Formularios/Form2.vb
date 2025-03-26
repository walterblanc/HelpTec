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


Public Class Form2

    Private Sub MetroTile1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile1.Click
        Dim Formulario_open As New Form30
        Formulario_open.ShowDialog()
    End Sub

   
    Private Sub MetroTile2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile2.Click
        Dim Formulario_open As New Form31
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile5.Click
        Dim Formulario_open As New Form35
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile3.Click
        Dim Formulario_open As New Form38
        Formulario_open.ShowDialog()

    End Sub

    Private Sub MetroTile7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile7.Click
        Dim Formulario_open As New Form40
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile4.Click
        Dim Formulario_open As New Form43
        Formulario_open.ShowDialog()

    End Sub

    Private Sub MetroTile6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile6.Click
        Dim Formulario_open As New Form44
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile8_Click(sender As System.Object, e As System.EventArgs) Handles MetroTile8.Click
        Dim Formulario_open As New Form170
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile9_Click(sender As System.Object, e As System.EventArgs) Handles MetroTile9.Click
        Dim Formulario_open As New Form171
        Formulario_open.ShowDialog()
    End Sub
End Class

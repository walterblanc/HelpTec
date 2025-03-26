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


Public Class Form20



    Private Sub Form20_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub MetroTile1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile1.Click
        Dim Formulario_open As New Form19(0, 0)
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile6.Click
        Dim Formulario_open As New Form21
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile2.Click
        Dim Formulario_open As New Form22
        Formulario_open.ShowDialog()

    End Sub

    Private Sub MetroTile3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile3.Click
        Dim Formulario_open As New Form27
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile4.Click
        Dim Formulario_open As New Form28
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile5.Click
        Dim Formulario_open As New Form56
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile7.Click
        Dim Formulario_open As New Form58
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile8.Click
        Dim Formulario_open As New Form44fe
        Formulario_open.ShowDialog()
    End Sub
End Class

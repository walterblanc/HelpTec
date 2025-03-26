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


Public Class Form5

    Private Sub MetroTile1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile1.Click
        rsv_Io = 0
        Dim Formulario_open As New Form6(3)
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile2.Click
        rsv_Io = 0
        Dim Formulario_open As New Form6(2)
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile3.Click
        rsv_Io = 0
        Dim Formulario_open As New Form6(1)
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile5.Click
        rsv_Io = 0
        Dim Formulario_open As New Form6(4)
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile4.Click
        rsv_Io = 0
        Dim Formulario_open As New Form6(5)
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile6.Click
        rsv_Io = 0
        Dim Formulario_open As New Form6(6)
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile7.Click
        rsv_Io = 0
        Dim Formulario_open As New Form6(7)
        Formulario_open.ShowDialog()

    End Sub
End Class

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


Public Class Form8

   

    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub MetroTile1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile1.Click
        rsv_Io = 0
        Dim Formulario_open As New Form9
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile6.Click
        Dim Formulario_open As New Form14
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile7.Click
        Dim Formulario_open As New Form51
        Formulario_open.ShowDialog()
    End Sub

    Private Sub MetroTile2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile2.Click
        Dim Formulario_open As New Form41(2)
        Formulario_open.ShowDialog()
    End Sub
End Class

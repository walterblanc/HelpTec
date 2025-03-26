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


Public Class Form3
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Private Sub Form3_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        cargar_datagrid()
    End Sub
    Private Sub cargar_datagrid()
        Dim h As Integer = 0
        Dim Sql As String = ""
        Sql = "Select * From Usuarios Order by Numero"

        With metroGrid1
            .Columns.Clear()
            .Rows.Clear()
            .Refresh()
        End With

        With metroGrid1
            .Rows.Clear()
            .Columns.Add("Numero", "Numero")
            .Columns.Add("Nombre", "Nombre")
            .Columns.Add("Activo", "Activo")
            .Columns.Add("email", "e-mail")
            .Columns(0).Width = 80
            .Columns(1).Width = 200
            .Columns(2).Width = 120
            .Columns(3).Width = 200
            '            .RowCount = 100
        End With

        If ConSql.State = ConnectionState.Open Then
            ConSql.Close()
        End If
        ConSql.Open()

        Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
        Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
        If drRecordSet.HasRows Then 'Tiene filas
            Do While drRecordSet.Read
                With metroGrid1
                    .Rows.Add()
                    .Item(0, h).Value = drRecordSet("Numero").ToString
                    .Item(1, h).Value = drRecordSet("Nombre").ToString
                    If Val(drRecordSet("Bloqueo").ToString) = 0 Then
                        .Item(2, h).Value = "Activo"
                    Else
                        .Item(2, h).Value = "Bloqueado"
                    End If
                    If drRecordSet("email").ToString.Trim = "" Then
                        .Item(3, h).Value = " "
                    Else
                        .Item(3, h).Value = drRecordSet("email").ToString
                    End If

                    h = h + 1
                End With
            Loop
        End If

        drRecordSet.Close()


    End Sub
    

    Private Sub MetroLink1_Click(sender As System.Object, e As System.EventArgs) Handles MetroLink1.Click
        Dim Formulario_open As New Form4(0, 1)
        Formulario_open.ShowDialog()
        cargar_datagrid()

    End Sub

   

    Private Sub metroGrid1_CellMouseDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles metroGrid1.CellMouseDoubleClick
        Dim usuario As Integer = 0
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If
        usuario = metroGrid1.Rows(e.RowIndex).Cells(0).Value
        Dim Formulario_open As New Form4(usuario, 2)
        Formulario_open.ShowDialog()

    End Sub

    Private Sub ModificarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarToolStripMenuItem.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim usuario As Integer = metroGrid1.CurrentRow.Cells(0).Value
            Dim Formulario_open As New Form4(usuario, 2)
            Formulario_open.ShowDialog()

            cargar_datagrid()

        End If
        

    End Sub

    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim usuario As Integer = metroGrid1.CurrentRow.Cells(0).Value
            cambio_estado_usuario(usuario, 1)
            cargar_datagrid()
        End If

    End Sub

    Private Sub cambio_estado_usuario(ByVal u As Integer, ByVal a As Byte)
        Try

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")



            Dim Sql As String = ""

            If a = 1 Then
                Sql = "Update Usuarios SET Estado=9,"
                Sql = Sql & "Afm='" & j2 & "',Ahm='" & j3 & "',Aum=" & j1 & " WHERE Numero= " & u & " "
            End If
            If a = 2 Then
                Sql = "Update Usuarios SET Bloqueo=0,"
                Sql = Sql & "Afm='" & j2 & "',Ahm='" & j3 & "',Aum=" & j1 & " WHERE Numero= " & u & " "
            End If
            If a = 3 Then
                Sql = "Update Usuarios SET Bloqueo=1,"
                Sql = Sql & "Afm='" & j2 & "',Ahm='" & j3 & "',Aum=" & j1 & " WHERE Numero= " & u & " "
            End If

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConSql.Close()
        End Try

    End Sub


    Private Sub ActivarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActivarToolStripMenuItem.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim usuario As Integer = metroGrid1.CurrentRow.Cells(0).Value
            cambio_estado_usuario(usuario, 2)
            cargar_datagrid()
        End If

    End Sub

    Private Sub BloquearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BloquearToolStripMenuItem.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim usuario As Integer = metroGrid1.CurrentRow.Cells(0).Value
            cambio_estado_usuario(usuario, 3)
            cargar_datagrid()
        End If

    End Sub
End Class

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


Public Class Form72
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Dim indice As Integer = 1000

    Dim h1 As Integer = 0
    Dim h2 As Integer = 0


    Private Sub Form72_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If indice = 1000 Then
            ReDim Preserve rsv_arr(0)
            rsv_arr(0) = 0
        End If
    End Sub

    Private Sub Form55_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        inicializa_form()

        inicializo_grilla_1()
        inicializo_grilla_2()

        lectura_valores()


        If EstaArrayVacio(rsv_arr) = False Then
            Dim i As Integer = 0
            Dim s As Double = 0
            For i = 0 To rsv_arr.Length - 1
                s = Convert.ToDouble(rsv_arr(i))
                Call veo_carga_anterior(s)
            Next
        End If


        'If rsv_arr.Length >= 0 Then
        '    Dim i As Integer = 0
        '    Dim s As Double = 0
        '    For i = 0 To rsv_arr.Length - 1
        '        s = Convert.ToDouble(rsv_arr(i))
        '        Call veo_carga_anterior(s)
        '    Next
        'End If

    End Sub

    Private Function EstaArrayVacio(ByVal vArray As Object) As Boolean

        Dim x As Boolean = True

        On Error Resume Next
        Dim Ret As Long
        Ret = UBound(vArray)
        If Err.Number = 9 Then
            x = True
        Else
            x = False
        End If

        EstaArrayVacio = x


    End Function



    Private Sub inicializo_grilla_1()
        With metroGrid1
            .Columns.Clear()
            .Rows.Clear()
            .Refresh()
        End With

        With metroGrid1
            .Rows.Clear()
            .Columns.Add("Id", "Id")
            .Columns.Add("Banco", "Banco")
            .Columns.Add("Detalle", "Detalle")
            .Columns.Add("Numero", "Numero")
            .Columns.Add("Fecha", "Fecha")
            .Columns.Add("Pago", "Pago")
            .Columns.Add("Importe", "Importe")
            .Columns.Add("Obs", "Observación")
            .Columns(0).Width = 80
            .Columns(1).Width = 100
            .Columns(2).Width = 200
            .Columns(3).Width = 140
            .Columns(4).Width = 140
            .Columns(5).Width = 140
            .Columns(6).Width = 140
            .Columns(7).Width = 200
            h1 = 0
            '            .RowCount = 100
        End With
    End Sub
    Private Sub metroGrid1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles metroGrid1.CellMouseDoubleClick
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        Dim indice As Integer = 0
        indice = e.RowIndex

        Dim aux As Double = 0

        If duplicados_en_grilla(indice) = True Then
            Exit Sub
        End If

        With MetroGrid2
            .Rows.Add()
            .Item(0, h2).Value = metroGrid1.Rows(indice).Cells(0).Value
            .Item(1, h2).Value = metroGrid1.Rows(indice).Cells(1).Value
            .Item(2, h2).Value = metroGrid1.Rows(indice).Cells(2).Value
            .Item(3, h2).Value = metroGrid1.Rows(indice).Cells(3).Value
            .Item(4, h2).Value = metroGrid1.Rows(indice).Cells(4).Value
            .Item(5, h2).Value = metroGrid1.Rows(indice).Cells(5).Value
            .Item(6, h2).Value = metroGrid1.Rows(indice).Cells(6).Value
            .Item(7, h2).Value = metroGrid1.Rows(indice).Cells(7).Value
            h2 = h2 + 1
        End With
    End Sub
    Private Sub veo_carga_anterior(ByVal s As Double)
        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim Sql As String = ""
            Sql = "Select * from Valores_recibidos_ventas WHERE Id=" & s & " "

            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                Do While drRecordSet.Read

                    With MetroGrid2
                        .Rows.Add()
                        .Item(0, h2).Value = drRecordSet("Id").ToString
                        .Item(1, h2).Value = drRecordSet("Banco").ToString
                        .Item(2, h2).Value = parametroSistema(8, Val(drRecordSet("Banco").ToString))
                        .Item(3, h2).Value = drRecordSet("Numero").ToString
                        .Item(4, h2).Value = FormatDateTime(drRecordSet("Emision").ToString, DateFormat.ShortDate)
                        .Item(5, h2).Value = FormatDateTime(drRecordSet("Pago").ToString, DateFormat.ShortDate)
                        .Item(6, h2).Value = FormatNumber(Convert.ToDouble(drRecordSet("Importe").ToString), 2)
                        .Item(7, h2).Value = " "
                        If Val(drRecordSet("Estado").ToString) <> 0 Then
                            .Item(7, h2).Value = "Eliminado"
                        End If
                        If Val(drRecordSet("Retirado").ToString) <> 0 Then
                            .Item(7, h2).Value = "Retirado " & FormatDateTime(drRecordSet("FechaRetiro").ToString, DateFormat.ShortDate)
                        End If
                        If Val(drRecordSet("Depositado").ToString) <> 0 Then
                            .Item(7, h2).Value = "Depositado " & FormatDateTime(drRecordSet("FechaDeposito").ToString, DateFormat.ShortDate)
                        End If
                        If Val(drRecordSet("PagoProveedor").ToString) <> 0 Then
                            .Item(7, h2).Value = "Pag. Proveedor " & FormatDateTime(drRecordSet("FechaDeposito").ToString, DateFormat.ShortDate)
                        End If

                        h2 = h2 + 1
                    End With

                Loop
            End If
            drRecordSet.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try


    End Sub

    Private Function duplicados_en_grilla(ByVal x As Integer) As Boolean
        Dim r As Boolean = False
        Try
            For Fila_pag As Integer = 0 To MetroGrid2.Rows.Count - 1

                If MetroGrid2.Rows(Fila_pag).Cells(0).Value = metroGrid1.Rows(x).Cells(0).Value And _
                    MetroGrid2.Rows(Fila_pag).Cells(1).Value = metroGrid1.Rows(x).Cells(1).Value And _
                    MetroGrid2.Rows(Fila_pag).Cells(2).Value = metroGrid1.Rows(x).Cells(2).Value And _
                    MetroGrid2.Rows(Fila_pag).Cells(3).Value = metroGrid1.Rows(x).Cells(3).Value And _
                    MetroGrid2.Rows(Fila_pag).Cells(4).Value = metroGrid1.Rows(x).Cells(4).Value And _
                    MetroGrid2.Rows(Fila_pag).Cells(5).Value = metroGrid1.Rows(x).Cells(5).Value And _
                    MetroGrid2.Rows(Fila_pag).Cells(6).Value = metroGrid1.Rows(x).Cells(6).Value And _
                    MetroGrid2.Rows(Fila_pag).Cells(7).Value = metroGrid1.Rows(x).Cells(7).Value Then
                    r = True
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            duplicados_en_grilla = r
        End Try
    End Function

    Private Sub inicializo_grilla_2()
        With MetroGrid2
            .Columns.Clear()
            .Rows.Clear()
            .Refresh()
        End With

        With MetroGrid2
            .Rows.Clear()
            .Columns.Add("Id", "Id")
            .Columns.Add("Banco", "Banco")
            .Columns.Add("Detalle", "Detalle")
            .Columns.Add("Numero", "Numero")
            .Columns.Add("Fecha", "Fecha")
            .Columns.Add("Pago", "Pago")
            .Columns.Add("Importe", "Importe")
            .Columns.Add("Obs", "Observación")
            .Columns(0).Width = 80
            .Columns(1).Width = 100
            .Columns(2).Width = 200
            .Columns(3).Width = 140
            .Columns(4).Width = 140
            .Columns(5).Width = 140
            .Columns(6).Width = 140
            .Columns(7).Width = 200
            h2 = 0
            '            .RowCount = 100
        End With
    End Sub

    Private Sub lectura_valores()
        Try


            Dim Aux1 As Double = 0
            Dim Aux2 As Double = 0

            If MetroTextBox8.Text.Trim <> "" And MetroTextBox1.Text.Trim <> "" Then
                Aux1 = Convert.ToDouble(MetroTextBox8.Text.Trim)
                Aux2 = Convert.ToDouble(MetroTextBox1.Text.Trim)
                If Aux1 > Aux2 Then
                    MetroFramework.MetroMessageBox.Show(Me, "Rango de Busqueda inválido", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If


            Dim f1 As String = ""
            f1 = FormatDateTime(MetroDateTime4.Text, DateFormat.ShortDate)
            Dim f2 As String = ""
            f2 = FormatDateTime(MetroDateTime3.Text, DateFormat.ShortDate)

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim Sql As String = ""
            If MetroTextBox8.Text.Trim = "" Then
                Sql = "Select * from Valores_recibidos_ventas WHERE (PAGO BETWEEN '" & f1 & "' AND '" & f2 & "') "
                Sql = Sql & "AND (Estado=0) And (Retirado=0) AND (PagoProveedor=0) AND (Depositado=0) "
                Sql = Sql & "Order by Pago"
            Else
                Aux1 = Convert.ToDouble(MetroTextBox8.Text.Trim)
                Aux2 = Convert.ToDouble(MetroTextBox1.Text.Trim)
                If MetroRadioButton1.Checked = True Then
                    Sql = "Select * from Valores_recibidos_ventas WHERE (Importe between  " & Aux1 & " AND " & Aux2 & ") AND (PAGO BETWEEN '" & f1 & "' AND '" & f2 & "') "
                    Sql = Sql & "AND (Estado=0) And (Retirado=0) AND (PagoProveedor=0) AND (Depositado=0) "
                    Sql = Sql & "Order by Importe"
                End If
                If MetroRadioButton2.Checked = True Then
                    Sql = "Select * from Valores_recibidos_ventas WHERE (Numero between  " & Aux1 & " AND " & Aux2 & ") AND (PAGO BETWEEN '" & f1 & "' AND '" & f2 & "') "
                    Sql = Sql & "AND (Estado=0) And (Retirado=0) AND (Depositado=0) AND (PagoProveedor=0) "
                    Sql = Sql & "Order by Numero"
                End If
            End If


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                Do While drRecordSet.Read

                    With metroGrid1
                        .Rows.Add()
                        .Item(0, h1).Value = drRecordSet("Id").ToString
                        .Item(1, h1).Value = drRecordSet("Banco").ToString
                        .Item(2, h1).Value = parametroSistema(8, Val(drRecordSet("Banco").ToString))
                        .Item(3, h1).Value = drRecordSet("Numero").ToString
                        .Item(4, h1).Value = FormatDateTime(drRecordSet("Emision").ToString, DateFormat.ShortDate)
                        .Item(5, h1).Value = FormatDateTime(drRecordSet("Pago").ToString, DateFormat.ShortDate)
                        .Item(6, h1).Value = FormatNumber(Convert.ToDouble(drRecordSet("Importe").ToString), 2)
                        .Item(7, h1).Value = " "
                        If Val(drRecordSet("Estado").ToString) <> 0 Then
                            .Item(7, h1).Value = "Eliminado"
                        End If
                        If Val(drRecordSet("Retirado").ToString) <> 0 Then
                            .Item(7, h1).Value = "Retirado " & FormatDateTime(drRecordSet("FechaRetiro").ToString, DateFormat.ShortDate)
                        End If
                        If Val(drRecordSet("Depositado").ToString) <> 0 Then
                            .Item(7, h1).Value = "Depositado " & FormatDateTime(drRecordSet("FechaDeposito").ToString, DateFormat.ShortDate)
                        End If
                        If Val(drRecordSet("PagoProveedor").ToString) <> 0 Then
                            .Item(7, h2).Value = "Pag. Proveedor " & FormatDateTime(drRecordSet("FechaDeposito").ToString, DateFormat.ShortDate)
                        End If

                        h1 = h1 + 1
                    End With

                Loop
            End If
            drRecordSet.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Sub inicializa_form()


        MetroTextBox1.Text = ""
        MetroTextBox8.Text = ""
        MetroRadioButton1.Checked = True

        MetroDateTime4.Value = Now.Date.AddDays(-60)
        MetroDateTime3.Value = Now.Date.AddDays(180)

    End Sub




    Private Sub metroGrid2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MetroGrid2.KeyDown
        Dim li_index As Integer

        If e.KeyCode = Keys.Delete Then

            If MetroGrid2.Rows.Count <= 0 Then
                Exit Sub
            End If


            e.Handled = True

            li_index = CType(sender, DataGridView).CurrentRow.Index
            MetroGrid2.Rows.RemoveAt(li_index)
            h2 = h2 - 1

        End If
    End Sub


    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        inicializo_grilla_1()
        lectura_valores()
    End Sub

#Region "ControlText"

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

    Private Sub metroTextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox8.KeyPress
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



#End Region

    Private Sub MetroButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton5.Click

        Try
            Dim i As Integer = 0

            ReDim rsv_arr(0)


            For Fila As Integer = 0 To MetroGrid2.Rows.Count - 1
                ReDim Preserve rsv_arr(i)
                rsv_arr(i) = Val(MetroGrid2.Rows(Fila).Cells("Id").Value)
                i = i + 1
            Next

            indice = i

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try



    End Sub

    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        Me.Close()
    End Sub
End Class

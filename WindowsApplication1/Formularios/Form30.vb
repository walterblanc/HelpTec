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


Public Class Form30
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)
   

    Dim h1 As Integer = 0
    Dim h2 As Integer = 0

    Private Sub Form30_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        inicializa_form()

        inicializo_grilla_1()
        inicializo_grilla_2()

        lectura_valores()

    End Sub
    Private Sub inicializa_form()
      
        MetroTextBox9.Text = ""

        MetroTextBox10.Text = ""
        MetroTextBox11.Text = ""
        MetroTextBox12.Text = ""
        MetroTextBox1.Text = ""
        MetroTextBox16.Text = ""
        MetroTextBox17.Text = ""
        MetroTextBox8.Text = ""
        MetroTextBox18.Text = "0.00"
        MetroDateTime1.Value = Now.Date
        MetroDateTime2.Value = Now.Date

        MetroRadioButton1.Checked = True

        MetroDateTime4.Value = Now.Date.AddDays(-60)
        MetroDateTime3.Value = Now.Date.AddDays(180)

    End Sub

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
            .Columns.Add("Cliente", "Cliente")
            .Columns(0).Width = 80
            .Columns(1).Width = 100
            .Columns(2).Width = 200
            .Columns(3).Width = 140
            .Columns(4).Width = 140
            .Columns(5).Width = 140
            .Columns(6).Width = 140
            .Columns(7).Width = 200
            .Columns(8).Width = 100
            '            .RowCount = 100
        End With
    End Sub
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
                Sql = "Select * from Valores_recibidos_ventas WHERE (PAGO BETWEEN '" & f1 & "' AND '" & f2 & "') Order by Pago"
            Else
                Aux1 = Convert.ToDouble(MetroTextBox8.Text.Trim)
                Aux2 = Convert.ToDouble(MetroTextBox1.Text.Trim)
                If MetroRadioButton1.Checked = True Then
                    Sql = "Select * from Valores_recibidos_ventas WHERE (Importe between  " & Aux1 & " AND " & Aux2 & ") AND (PAGO BETWEEN '" & f1 & "' AND '" & f2 & "') Order by Importe"
                End If
                If MetroRadioButton2.Checked = True Then
                    Sql = "Select * from Valores_recibidos_ventas WHERE (Numero between  " & Aux1 & " AND " & Aux2 & ") AND (PAGO BETWEEN '" & f1 & "' AND '" & f2 & "') Order by Numero"
                End If
            End If


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
                            .Item(7, h2).Value = "Pag. Proveedor " & FormatDateTime(drRecordSet("FechaPagoProveedor").ToString, DateFormat.ShortDate)
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
    Private Sub MetroTextBox9_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MetroTextBox9.KeyDown
        If e.KeyCode <> Keys.F1 Then
            Exit Sub
        End If

        rsv_Io = 1
        rsv_Seleccion = ""
        rsv_prg_orig = "Form30"
        Dim Formulario_open As New Form12
        Formulario_open.ShowDialog()

        If rsv_Seleccion.Trim <> "" Then
            MetroTextBox9.Text = rsv_Seleccion
            MetroTextBox9.Focus()
        End If

    End Sub
    Private Sub MetroTextBox9_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox9.Validated
        Try

            If MetroTextBox9.Text.Trim = "" Then
                Exit Sub

            End If

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim x As Double = Val(MetroTextBox9.Text.Trim)
            Dim Sql As String = ""
            Sql = "Select * from Clientes WHERE (Numero= " & x & ") And (Estado=0) "


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    MetroTextBox10.Text = drRecordSet("RazonSocial").ToString
                    MetroTextBox16.Text = drRecordSet("Domicilio").ToString
                End If
            End If

            drRecordSet.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try


    End Sub
    Private Sub metroGrid1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles metroGrid1.KeyDown
        Dim li_index As Integer

        If e.KeyCode = Keys.Delete Then

            If metroGrid1.Rows.Count <= 0 Then
                Exit Sub
            End If


            e.Handled = True

            li_index = CType(sender, DataGridView).CurrentRow.Index
            metroGrid1.Rows.RemoveAt(li_index)
            h1 = h1 - 1

        End If
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
    Private Sub metroTextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox9.KeyPress
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
    Private Sub metroTextBox11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox11.KeyPress
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
  
    Private Sub metroTextBox17_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox17.KeyPress
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
    Private Sub metroTextBox18_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox18.KeyPress
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
#Region "CamposNumericosFormat"
    Private Sub MetroTextBox18_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox18.Validated
        If MetroTextBox18.Text.Trim = "" Then
            MetroTextBox18.Text = "0.00"
        End If
        If MetroTextBox18.Text.Trim = "." Then
            MetroTextBox18.Text = "0.00"
        End If
    End Sub
   
  
#End Region



    

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        MetroTextBox9.Text = ""
        MetroTextBox10.Text = ""
        MetroTextBox16.Text = ""
        MetroTextBox11.Text = ""
        MetroTextBox17.Text = ""
        MetroTextBox18.Text = "0.00"
        MetroDateTime1.Value = Now.Date
        MetroDateTime2.Value = Now.Date

        MetroTextBox9.Focus()

    End Sub

    Private Sub MetroButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        If MetroTextBox11.Text = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar entidad bancaria", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If MetroTextBox12.Text = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar entidad bancaria", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If CDbl(MetroTextBox17.Text) = 0 Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar número de cheque", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If CDbl(MetroTextBox18.Text) = 0 Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar importe del cheque", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        Try
            With metroGrid1
                .Rows.Add()
                .Item(0, h1).Value = h1
                .Item(1, h1).Value = MetroTextBox11.Text
                .Item(2, h1).Value = MetroTextBox12.Text
                .Item(3, h1).Value = MetroTextBox17.Text
                .Item(4, h1).Value = MetroDateTime1.Text
                .Item(5, h1).Value = MetroDateTime2.Text
                .Item(6, h1).Value = MetroTextBox18.Text
                .Item(7, h1).Value = " "
                .Item(8, h1).Value = MetroTextBox9.Text
                h1 = h1 + 1
            End With

            MetroTextBox11.Text = ""
            MetroTextBox17.Text = ""
            MetroTextBox18.Text = "0.00"
            MetroDateTime1.Value = Now.Date
            MetroDateTime2.Value = Now.Date

            MetroTextBox11.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub



    Private Sub MetroTextBox11_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox11.Validated
        If MetroTextBox11.Text.Trim <> "" Then
            MetroTextBox12.Text = parametroSistema(8, Val(MetroTextBox11.Text.Trim))
        End If
    End Sub

    Private Sub guardar_valores()
        Try

            Dim InsSql As String = ""

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")

            Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
            Dim ConSql As New OleDbConnection(Conexion)
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()


            Dim x1 As String = ""
            x1 = FormatDateTime(Date.Now, DateFormat.ShortDate)
            Dim x2 As String = " "
            Dim x3 As String = " "
            Dim x4 As Double = 0
            If MetroTextBox9.Text.Trim <> "" Then
                x4 = CDbl(MetroTextBox9.Text.Trim)
            End If

            Dim x5 As Byte = 0
            Dim x6 As Integer = 0
            Dim x7 As String = ""
            Dim x8 As String = ""
            Dim x9 As Double = 0
            Dim x10 As Double = 0
            Dim x11 As String = ""

            For Fila As Integer = 0 To metroGrid1.Rows.Count - 1
                x6 = Val(metroGrid1.Rows(Fila).Cells("Banco").Value)
                x7 = FormatDateTime(metroGrid1.Rows(Fila).Cells("Fecha").Value, DateFormat.ShortDate)
                x8 = FormatDateTime(metroGrid1.Rows(Fila).Cells("Pago").Value, DateFormat.ShortDate)
                x9 = CDbl(metroGrid1.Rows(Fila).Cells("Numero").Value)
                x10 = CDbl(metroGrid1.Rows(Fila).Cells("Importe").Value)
                x11 = metroGrid1.Rows(Fila).Cells("Detalle").Value

                InsSql = ""
                InsSql = "Insert into Valores_recibidos_ventas ("
                InsSql = InsSql & "Fecha,LetraComprobante,NumeroComprobante,Cliente,TipoComprobante,"
                InsSql = InsSql & "Banco,Emision,Pago,Numero,Importe,Detalle,"
                InsSql = InsSql & "Ua,Ha,Fa,Estado) Values ("
                InsSql = InsSql & "'" & x1 & "','" & x2 & "','" & x3 & "'," & x4 & "," & x5 & ","
                InsSql = InsSql & "" & x6 & ",'" & x7 & "','" & x8 & "'," & x9 & "," & x10 & ",'" & x11 & "',"
                InsSql = InsSql & "" & j1 & ",'" & j3 & "','" & j2 & "',0)"

                Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
                cmdActualizar.ExecuteNonQuery()
                cmdActualizar.Dispose()

            Next

            ConSql.Close()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
    
    Private Sub MetroButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton5.Click
        guardar_valores()
    End Sub

    
    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        inicializo_grilla_2()
        lectura_valores()
    End Sub

    Private Sub MetroLink1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink1.Click
        If MetroGrid2.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (MetroGrid2.CurrentRow IsNot Nothing) Then
            Dim x As Double = MetroGrid2.CurrentRow.Cells(0).Value
            Call eliminar_valor(x)
        End If
    End Sub
    Private Sub eliminar_valor(ByVal x As Double)
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

            Sql = "Update Valores_recibidos_ventas SET Estado=9,"
            Sql = Sql & "Fb='" & j2 & "',Hb='" & j3 & "',Ub=" & j1 & " WHERE ID= " & x & " "

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            inicializo_grilla_2()
            lectura_valores()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConSql.Close()
        End Try

    End Sub

    Private Sub MetroLink2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink2.Click
        If MetroGrid2.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (MetroGrid2.CurrentRow IsNot Nothing) Then
            Dim x As Double = MetroGrid2.CurrentRow.Cells(0).Value
            Call depositar_valor(x)
        End If
    End Sub
    Private Sub depositar_valor(ByVal x As Double)
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

            Sql = "Update Valores_recibidos_ventas SET depositado=1,"
            Sql = Sql & "FechaDeposito='" & j2 & "',HoraDeposito='" & j3 & "',UsuarioDeposito=" & j1 & " WHERE ID= " & x & " "

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            inicializo_grilla_2()
            lectura_valores()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConSql.Close()
        End Try

    End Sub

    Private Sub MetroLink3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink3.Click
        If MetroGrid2.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (MetroGrid2.CurrentRow IsNot Nothing) Then
            Dim x As Double = MetroGrid2.CurrentRow.Cells(0).Value
            Call retirar_valor(x)
        End If

    End Sub
    Private Sub retirar_valor(ByVal x As Double)
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

            Sql = "Update Valores_recibidos_ventas SET Retirado=1,"
            Sql = Sql & "FechaRetiro='" & j2 & "',HoraRetiro='" & j3 & "',UsuarioRetiro=" & j1 & " WHERE ID= " & x & " "

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            inicializo_grilla_2()
            lectura_valores()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConSql.Close()
        End Try

    End Sub

    Private Sub MetroTextBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTextBox11.Click

    End Sub

    Private Sub MetroTextBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTextBox8.Click

    End Sub

    Private Sub MetroLink4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink4.Click
        If MetroGrid2.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (MetroGrid2.CurrentRow IsNot Nothing) Then
            Dim x As Double = MetroGrid2.CurrentRow.Cells(0).Value
            Dim Formulario_open As New Form57(x)
            Formulario_open.ShowDialog()
        End If
    End Sub
End Class

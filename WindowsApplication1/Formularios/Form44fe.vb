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
Imports System.Drawing.Printing


Public Class Form44fe
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)
    Dim P As Boolean = True
    Private Sub Form44fe_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MetroDateTime1.Value = FormatDateTime(Now.Date, DateFormat.ShortDate)
        MetroDateTime2.Value = FormatDateTime(Now.Date, DateFormat.ShortDate)
        PopulateInstalledPrintersCombo()
        cargar_datagrid()
        MetroTextBox1.Text = ""
    End Sub
    Private Sub cargar_datagrid()
        Try
            Dim h As Integer = 0
            Dim Sql As String = ""



            Dim xFecha As String = ""
            xFecha = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate) '10/01/2009
            xFecha = String.Format("{0:yyyyMMdd}", Convert.ToDateTime(xFecha))

            Dim xFechaDesde As String = ""
            Dim xFechaHasta As String = ""

            xFechaDesde = xFecha

            xFecha = FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate) '10/01/2009
            xFecha = String.Format("{0:yyyyMMdd}", Convert.ToDateTime(xFecha))

            xFechaHasta = xFecha

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Sql = "Select * from Iva_Ventas Where Estado = 0 And FechaImputacion >= '" & xFechaDesde & "' "
            Sql = Sql & "And FechaImputacion <= '" & xFechaHasta & "' Order By FechaImputacion,TipoComprobante,LetraComprobante,NumeroComprobante"

            With metroGrid1
                .Columns.Clear()
                .Rows.Clear()
                .Refresh()
            End With

            With metroGrid1
                .Rows.Clear()
                .Columns.Add("Fecha", "Fecha")
                .Columns.Add("Tipo", "Tipo")
                .Columns.Add("PtoVta", "Pto.Vta.")
                .Columns.Add("Letra", "Letra")
                .Columns.Add("Numero", "Numero")
                .Columns.Add("Cliente", "Cliente")
                .Columns.Add("Cuit", "Cuit")
                .Columns.Add("Nombre", "Nombre")
                .Columns.Add("Importe", "Importe")
                .Columns.Add("Mail", "Mail")

                .Columns(0).Width = 100
                .Columns(1).Width = 100
                .Columns(2).Width = 90
                .Columns(3).Width = 80
                .Columns(4).Width = 200
                .Columns(5).Width = 120
                .Columns(6).Width = 120
                .Columns(7).Width = 180
                .Columns(8).Width = 120
                .Columns(9).Width = 200
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
                        .Item(0, h).Value = FormatDateTime(drRecordSet("FechaImputacion").ToString, DateFormat.ShortDate)
                        .Item(1, h).Value = drRecordSet("TipoComprobante").ToString
                        .Item(2, h).Value = drRecordSet("PuntoDeVenta").ToString
                        .Item(3, h).Value = drRecordSet("LetraComprobante").ToString
                        .Item(4, h).Value = drRecordSet("NumeroComprobante").ToString
                        If drRecordSet("Cliente").ToString = 0 Then
                            .Item(5, h).Value = " "
                        Else
                            .Item(5, h).Value = drRecordSet("Cliente").ToString
                        End If
                        If drRecordSet("Cuit").ToString = 0 Then
                            .Item(6, h).Value = " "
                        Else
                            .Item(6, h).Value = drRecordSet("Cuit").ToString
                        End If

                        .Item(7, h).Value = drRecordSet("Nombre").ToString
                        .Item(8, h).Value = FormatNumber(drRecordSet("Total").ToString, 2)
                        .Item(9, h).Value = drRecordSet("Mail").ToString
                        h = h + 1
                    End With
                Loop
            End If

            drRecordSet.Close()



        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_Modulo, MessageBoxButtons.OK)
            ConSql.Close()

        End Try



    End Sub

    Private Sub MetroLink1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink1.Click

        If MetroComboBox1.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe seleccionar impresora", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim f As String = metroGrid1.CurrentRow.Cells(0).Value
            Dim c As Byte = 1
            Dim p As String = metroGrid1.CurrentRow.Cells(2).Value
            Dim t As Byte = 0
            Dim l As String = metroGrid1.CurrentRow.Cells(3).Value.ToString.Trim
            Dim n As String = metroGrid1.CurrentRow.Cells(4).Value.ToString.Trim

            If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "FA" Then
                t = 1
            End If
            If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "ND" Then
                t = 2
            End If
            If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "NC" Then
                t = 3
            End If

            If l = "A" Then
                Call impresion_comprobante_a(p, t, l, n, f, c, 1)
            Else
                Call impresion_comprobante_b(p, t, l, n, f, c, 1)
            End If


        End If


    End Sub



    Private Sub MetroLink2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink2.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then


            Dim txt_token As String = ""
            Dim txt_sign As String = ""
            Dim txt_cuit As String = ""
            Dim txt_ptovta As String = ""
            Dim txt_tipo As String = ""
            Dim txt_nro As String = ""


            txt_ptovta = metroGrid1.CurrentRow.Cells(2).Value

            If metroGrid1.CurrentRow.Cells(3).Value.ToString.Trim = "A" Then
                If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "FA" Then
                    txt_tipo = "1"
                End If
                If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "ND" Then
                    txt_tipo = "2"
                End If
                If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "NC" Then
                    txt_tipo = "3"
                End If
            Else
                If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "FA" Then
                    txt_tipo = "6"
                End If
                If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "ND" Then
                    txt_tipo = "7"
                End If
                If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "NC" Then
                    txt_tipo = "8"
                End If
            End If

            Dim x_nro As String = metroGrid1.CurrentRow.Cells(4).Value.ToString.Trim
            txt_nro = x_nro.Substring(5, 8)



            Call cargar_configuracion()

            If rsv_Afip_Certif.Trim = "" Then
                MessageBox.Show("Problemas en Archivo Configuración Afip", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If fecha_expir_ticket() = False Then
                MessageBox.Show("Debe Solicitar Ticket Afip. Rango Horario Vencido", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If



            Dim arg_e As Byte = 0

            Call lectura_ticket(txt_token, txt_sign, txt_cuit, arg_e)

            If arg_e Then
                MessageBox.Show("Problemas en lectura de Ticket", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If txt_token.Trim = "" Or txt_sign.Trim = "" Or txt_cuit = "" Then
                MessageBox.Show("Problemas en lectura de Ticket", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim r As String = FECompConsultar(txt_token, txt_sign, txt_cuit, txt_ptovta, txt_tipo, txt_nro)

            Dim Formulario_open As New Form45fe(r)
            Formulario_open.ShowDialog()

        End If

    End Sub

    Private Sub MetroLink3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim x As Double = metroGrid1.CurrentRow.Cells(0).Value
            '            Dim Formulario_open As New Form36(x)
            Dim Formulario_open As New Form39(x)
            Formulario_open.ShowDialog()

        End If
    End Sub



    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        cargar_datagrid()
    End Sub

    Private Sub MetroLink3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink3.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim f As String = metroGrid1.CurrentRow.Cells(0).Value
            Dim c As Byte = 1
            Dim p As String = metroGrid1.CurrentRow.Cells(2).Value
            Dim t As Byte = 0
            Dim l As String = metroGrid1.CurrentRow.Cells(3).Value.ToString.Trim
            Dim n As String = metroGrid1.CurrentRow.Cells(4).Value.ToString.Trim

            If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "FA" Then
                t = 1
            End If
            If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "ND" Then
                t = 2
            End If
            If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "NC" Then
                t = 3
            End If

            If l = "A" Then
                Exit Sub
            End If

            Call impresion_comprobante_b(p, t, l, n, f, c, 2)

        End If
    End Sub
    Private Sub PopulateInstalledPrintersCombo()

        MetroComboBox1.Items.Clear()

        Dim j As Integer = 0

        Dim instance As New Printing.PrinterSettings

        Dim impresosaPredt As String = instance.PrinterName

        ' Add list of installed printers found to the combo box.
        ' The pkInstalledPrinters string will be used to provide the display string.
        Dim i As Integer
        Dim pkInstalledPrinters As String

        For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            pkInstalledPrinters = PrinterSettings.InstalledPrinters.Item(i)

            If impresosaPredt.ToString.Trim.ToUpper = pkInstalledPrinters.ToString.ToUpper.Trim Then
                j = i
            End If

            MetroComboBox1.Items.Add(pkInstalledPrinters)
        Next
        MetroComboBox1.SelectedIndex = j

    End Sub
    Private Sub MetroLink4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink4.Click

        If MetroComboBox1.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe seleccionar impresora", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim f As String = metroGrid1.CurrentRow.Cells(0).Value
            Dim c As Byte = 2
            Dim p As String = metroGrid1.CurrentRow.Cells(2).Value
            Dim t As Byte = 0
            Dim l As String = metroGrid1.CurrentRow.Cells(3).Value.ToString.Trim
            Dim n As String = metroGrid1.CurrentRow.Cells(4).Value.ToString.Trim

            If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "FA" Then
                t = 1
            End If
            If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "ND" Then
                t = 2
            End If
            If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "NC" Then
                t = 3
            End If

            If l = "A" Then
                Call impresion_comprobante_a(p, t, l, n, f, c, 1)
            Else
                Call impresion_comprobante_b(p, t, l, n, f, c, 1)
            End If


        End If

    End Sub

    Private Sub MetroLink5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink5.Click

        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim f As String = metroGrid1.CurrentRow.Cells(0).Value
            Dim c As Byte = 1
            Dim p As String = metroGrid1.CurrentRow.Cells(2).Value
            Dim t As Byte = 0
            Dim l As String = metroGrid1.CurrentRow.Cells(3).Value.ToString.Trim
            Dim n As String = metroGrid1.CurrentRow.Cells(4).Value.ToString.Trim

            If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "FA" Then
                t = 1
            End If
            If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "ND" Then
                t = 2
            End If
            If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "NC" Then
                t = 3
            End If

            If l = "A" Then
                Call impresion_comprobante_a(p, t, l, n, f, c, 0)
            Else
                Call impresion_comprobante_b(p, t, l, n, f, c, 0)
            End If


        End If

    End Sub

    Private Sub MetroLink6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink6.Click
        If metroGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (metroGrid1.CurrentRow IsNot Nothing) Then
            Dim f As String = metroGrid1.CurrentRow.Cells(0).Value
            Dim c As Byte = 2
            Dim p As String = metroGrid1.CurrentRow.Cells(2).Value
            Dim t As Byte = 0
            Dim l As String = metroGrid1.CurrentRow.Cells(3).Value.ToString.Trim
            Dim n As String = metroGrid1.CurrentRow.Cells(4).Value.ToString.Trim

            If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "FA" Then
                t = 1
            End If
            If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "ND" Then
                t = 2
            End If
            If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "NC" Then
                t = 3
            End If

            If l = "A" Then
                Call impresion_comprobante_a(p, t, l, n, f, c, 0)
            Else
                Call impresion_comprobante_b(p, t, l, n, f, c, 0)
            End If


        End If

    End Sub

    Private Sub MetroLink7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink7.Click
        Try

            If MetroTextBox1.Text.Trim <> "" Then
                Dim x_ValidaMail = validacion_mail(MetroTextBox1.Text.Trim)
                If x_ValidaMail <> 0 Then
                    MetroFramework.MetroMessageBox.Show(Me, "El mail especificado es incorrecto !!!!.", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If


            If metroGrid1.Rows.Count <= 0 Then
                Exit Sub
            End If

            If (metroGrid1.CurrentRow IsNot Nothing) Then

                Dim archivo_pdf As String = My.Computer.FileSystem.CurrentDirectory.Trim
                Dim nom_file As String = metroGrid1.CurrentRow.Cells(7).Value.ToString.Trim

                archivo_pdf = archivo_pdf & "\Pdf\" & nom_file & "_" & DateTime.Now.ToString("T").ToString.Replace(":", "") & ".pdf"
                If File.Exists(archivo_pdf) Then
                    File.Delete(archivo_pdf)
                End If

                Dim f As String = metroGrid1.CurrentRow.Cells(0).Value
                Dim c As Byte = 1
                Dim p As String = metroGrid1.CurrentRow.Cells(2).Value
                Dim t As Byte = 0
                Dim l As String = metroGrid1.CurrentRow.Cells(3).Value.ToString.Trim
                Dim n As String = metroGrid1.CurrentRow.Cells(4).Value.ToString.Trim

                If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "FA" Then
                    t = 1
                End If
                If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "ND" Then
                    t = 2
                End If
                If metroGrid1.CurrentRow.Cells(1).Value.ToString.Trim = "NC" Then
                    t = 3
                End If

                If l = "A" Then
                    Call impresion_comprobante_a(p, t, l, n, f, c, 3, archivo_pdf)
                Else
                    Call impresion_comprobante_b(p, t, l, n, f, c, 3, archivo_pdf)
                End If

                Dim e_mail As String = ""
                Dim e_Asunto As String = ""
                Dim e_Texto As String = ""
                Dim e_File As String = ""
                Dim id_Reg_log As Long = 0

                e_mail = metroGrid1.CurrentRow.Cells(9).Value.ToString.Trim

                If MetroTextBox1.Text.Trim <> "" Then
                    e_mail = MetroTextBox1.Text.Trim
                End If

                e_Asunto = "Adjuntamos comprobante de referencia"
                e_Texto = "Este en un correo automático, no intente comunicarse o reponder a esta dirección de correo electrónico. Atte "
                e_File = archivo_pdf

                id_Reg_log = 0

                Call log_mail_enviados(e_mail, e_Asunto, e_Texto, e_File, id_Reg_log)
                Call enviar_mail(e_mail, e_Asunto, e_Texto, e_File, " ", id_Reg_log)
                Call actualizar_mail_enviado(id_Reg_log)

                MetroFramework.MetroMessageBox.Show(Me, "El mail se ha enviado satisfactoriamente !!!!.", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub metroTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub MetroLink8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLink8.Click
        Dim Formulario_open As New Form45()
        Formulario_open.ShowDialog()
    End Sub
End Class

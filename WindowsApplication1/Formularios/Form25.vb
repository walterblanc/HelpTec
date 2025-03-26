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
Imports System.Globalization

Public Class Form25
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)
    Dim reser_Ticket As Double = 0


    Dim ok_Cae As Boolean
    Dim Cae_Afip As String = ""
    Dim FecVtoCae_Afip As String = ""


    Dim reser_tipo_respo As Byte = 0
    Dim reser_letra_compro As String = " "
    Dim reser_numero_compro As String = " "
    Dim reser_contado As Byte = 0
    Dim reser_tipo_comprobante As Byte = 0

    Dim TipoDocRecep_Afip As Integer = 0
    Dim NroDocRecep_Afip As Double = 0


    Dim Total_Neto As Double = 0
    Dim Total_Neto_105 As Double = 0
    Dim Total_Neto_21 As Double = 0
    Dim Total_Exento As Double = 0

    Dim Total_Iva_105 As Double = 0
    Dim Total_Iva_21 As Double = 0

    Dim Total_Comprobante As Double = 0

    Dim h As Integer = 0

    Dim e_mail As String = ""
    Dim e_Asunto As String = ""
    Dim e_Texto As String = ""
    Dim e_File As String = ""
    Dim id_Reg_log As Long = 0

    Private Structure registro_ticket
        Dim Codigo As String
        Dim Detalle As String
        Dim Alicuota As Double
        Dim Precio As Double
        Dim Cantidad As Double
        Dim SubTotal As Double
        Dim Dsto As Double
        Dim PrecioConDsto As Double
        Dim PrecioConIva As Double
        Dim PrecioFinal As Double
        Dim Total As Double
        Dim NetoComprobante As Double
        Dim IvaComprobante As Double
        Dim TotalComprobante As Double

        Dim UnidadMedidaFiscal As String
        Dim PrecioFiscal As Double
        Dim BonifFiscal As Double
        Dim ImporteBonifFiscal As Double
        Dim AlicuotaFiscal As Double
        Dim ImporteIvaFiscal As Double
        Dim SubTotalFiscal As Double
        Dim ObservacionFiscal As String
        Dim ListaFiscal As Byte
        Dim CodUnidadMedidaFiscal As Byte

    End Structure

    Private ticket_ventas As ArrayList

    Public Sub New(ByVal v_Ticket As Double, ByVal v_accion As Byte)
        InitializeComponent()
        reser_Ticket = v_Ticket
        reser_tipo_comprobante = v_accion
    End Sub
    Private Sub Form25_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        inicializa_form()
        inicializo_grilla()


        Call cargar_puntos_venta()

        If reser_tipo_comprobante = 1 Then
            MetroLabel29.Text = "FACTURA"
        End If
        If reser_tipo_comprobante = 2 Then
            MetroLabel29.Text = "NOTA DE DEBITO"
        End If
        If reser_tipo_comprobante = 3 Then
            MetroLabel29.Text = "NOTA DE CREDITO"
        End If


        Call cargar_configuracion()

        If rsv_Afip_Certif.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Problemas en Archivo Configuración Afip", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            MetroButton4.Enabled = False
            MetroButton3.Enabled = False
        End If

        If fecha_expir_ticket() = False Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe Solicitar Ticket Afip. Rango Horario Vencido", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            MetroButton4.Enabled = False
            MetroButton3.Enabled = False
        End If


        MetroLabel29.Refresh()

        lectura_ticket_interno()

        ultimos_numero_de_comprobantes()

    End Sub

    Private Sub inicializa_form()
        MetroTextBox8.Text = ""
        MetroTextBox15.Text = ""
        MetroTextBox26.Text = "2"
        MetroTextBox14.Text = ""
        MetroTextBox9.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox1.Text = "0.00"
        MetroTextBox2.Text = ""
        MetroTextBox4.Text = "0.00"

        MetroTextBox22.Text = ""
        MetroTextBox21.Text = ""
        MetroTextBox51.Text = "0.00"

        MetroTextBox5.Text = "0.00"
        MetroTextBox6.Text = "0.00"
        MetroTextBox7.Text = "0.00"
        MetroTextBox10.Text = ""
        MetroTextBox11.Text = ""
        MetroTextBox12.Text = ""
        MetroTextBox16.Text = ""
        MetroTextBox17.Text = ""
        MetroTextBox18.Text = "0.00"
        MetroTextBox19.Text = "0.00"

        MetroTextBox23.Text = ""
        MetroTextBox24.Text = ""
        MetroTextBox25.Text = ""

        MetroDateTime1.Value = Now.Date
        MetroDateTime2.Value = Now.Date
        MetroTextBox13.Text = "CONSUMIDOR FINAL"

        cargarCOMBO(MetroComboBox1, 9)
        cargarCOMBO(MetroComboBox2, 9)
        cargarCOMBO(MetroComboBox4, 9)


        rsv_CpteAsoc_Cuit1 = ""
        rsv_CpteAsoc_Tipo1 = ""
        rsv_CpteAsoc_Letra1 = ""
        rsv_CpteAsoc_Fecha1 = Now.Date
        rsv_CpteAsoc_Pto1 = 0
        rsv_CpteAsoc_Nro1 = 0

        rsv_CpteAsoc_Cuit2 = ""
        rsv_CpteAsoc_Tipo2 = ""
        rsv_CpteAsoc_Letra2 = ""
        rsv_CpteAsoc_Fecha2 = Now.Date
        rsv_CpteAsoc_Pto2 = 0
        rsv_CpteAsoc_Nro2 = 0

        rsv_CpteAsoc_Cuit3 = ""
        rsv_CpteAsoc_Tipo3 = ""
        rsv_CpteAsoc_Letra3 = ""
        rsv_CpteAsoc_Fecha3 = Now.Date
        rsv_CpteAsoc_Pto3 = 0
        rsv_CpteAsoc_Nro3 = 0


    End Sub
    Private Sub lectura_ticket_interno()
        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim Total_105 As Double = 0
            Dim Total_21 As Double = 0

            Dim p As Boolean = True
            Dim Sql As String = "Select * from Tickets WHERE (TicketNro= " & reser_Ticket & ") And (Estado=0) Order by Orden"

            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                Do While drRecordSet.Read
                    If p = True Then
                        MetroTextBox8.Text = drRecordSet("Nombre").ToString
                        MetroTextBox15.Text = drRecordSet("Documento").ToString
                        MetroTextBox9.Text = drRecordSet("Cliente").ToString
                        MetroTextBox10.Text = drRecordSet("ClienteNombre").ToString
                        MetroTextBox26.Text = drRecordSet("CalidadRespo").ToString
                        If Val(drRecordSet("Cuit").ToString) <> 0 Then
                            MetroTextBox14.Text = drRecordSet("Cuit").ToString
                        End If
                        MetroTextBox20.Text = FormatNumber(Convert.ToDouble(drRecordSet("TotalOperacion").ToString), 2)
                        MetroTextBox5.Text = FormatNumber(Convert.ToDouble(drRecordSet("TotalOperacion").ToString), 2)
                        Total_Comprobante = Convert.ToDouble(drRecordSet("TotalOperacion").ToString)
                        p = False
                    End If

                    If Val(drRecordSet("Alicuota").ToString) = 0 Then
                        Total_Exento = Total_Exento + Convert.ToDouble(drRecordSet("Total").ToString)
                    End If
                    If Val(drRecordSet("Alicuota").ToString) = 10.5 Then
                        Total_105 = Total_105 + Convert.ToDouble(drRecordSet("Total").ToString)
                    End If
                    If Val(drRecordSet("Alicuota").ToString) = 21 Then
                        Total_21 = Total_21 + Convert.ToDouble(drRecordSet("Total").ToString)
                    End If
                Loop
            End If
            drRecordSet.Close()

            If MetroTextBox9.Text.Trim = "0" Then
                MetroTextBox9.Text = ""
            End If

            If MetroTextBox9.Text.Trim <> "" Then
                leer_cliente()
            End If

            If Total_21 <> 0 Then
                Total_Neto_21 = Math.Round(Total_21 / 1.21, 2)
                Total_Iva_21 = Math.Round(Total_21 - Total_Neto_21, 2)
            End If
            If Total_105 <> 0 Then
                Total_Neto_105 = Math.Round(Total_105 / 1.105, 2)
                Total_Iva_105 = Math.Round(Total_105 - Total_Neto_105, 2)
            End If
            Total_Neto = Total_Neto_21 + Total_Neto_105


            validar_tipo_responsable()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub MetroTextBox9_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MetroTextBox9.KeyDown
        If e.KeyCode <> Keys.F1 Then
            Exit Sub
        End If

        rsv_Io = 1
        rsv_Seleccion = ""
        rsv_prg_orig = "Form25"
        Dim Formulario_open As New Form12
        Formulario_open.ShowDialog()

        If rsv_Seleccion.Trim <> "" Then
            MetroTextBox9.Text = rsv_Seleccion
            MetroTextBox9.Focus()
        End If

    End Sub
    Private Sub MetroTextBox9_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox9.Validated
        Try

            MetroTextBox10.Text = ""
            MetroTextBox16.Text = ""

            If MetroTextBox9.Text.Trim = "" Then
                Exit Sub
            End If

            leer_cliente()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try


    End Sub
    Private Sub leer_cliente()
        Try
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
                    MetroTextBox26.Text = drRecordSet("Responsable").ToString
                    MetroTextBox14.Text = drRecordSet("Cuit").ToString
                    MetroTextBox21.Text = drRecordSet("email").ToString

                    If Convert.ToDouble(drRecordSet("NumDoc").ToString) <> 0 Then
                        MetroTextBox15.Text = drRecordSet("NumDoc").ToString
                    End If

                End If
            End If

            drRecordSet.Close()


            If MetroTextBox26.Text.Trim = "" Then
                Exit Sub
            End If
            MetroTextBox13.Text = parametroSistema(2, Val(MetroTextBox26.Text.Trim))


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub MetroTextBox26_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox26.Validated
        validar_tipo_responsable()
    End Sub
    Private Sub validar_tipo_responsable()
        MetroTextBox13.Text = ""
        Select Case MetroTextBox26.Text.Trim
            Case Is = "1"
                MetroTextBox13.Text = "RESPONSABLE INSCRIPTO"
            Case Is = "2"
                MetroTextBox13.Text = "CONSUMIDOR FINAL"
            Case Is = "3"
                MetroTextBox13.Text = "EXENTO"
            Case Is = "4"
                MetroTextBox13.Text = "MONOTRIBUTO"
        End Select


    End Sub
    Private Sub inicializo_grilla()
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
            '            .RowCount = 100
        End With
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
            h = h - 1
            suma_grilla()

        End If
    End Sub
    Private Sub suma_grilla()
        Try
            Dim x As Double = 0
            For Fila As Integer = 0 To metroGrid1.Rows.Count - 1
                x = x + Convert.ToDouble(metroGrid1.Rows(Fila).Cells("Importe").Value)
            Next
            MetroTextBox19.Text = FormatNumber(x, 2)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConSql.Close()

        End Try
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
    Private Sub metroTextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox2.KeyPress
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
    Private Sub metroTextBox22_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox22.KeyPress
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
    Private Sub metroTextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox3.KeyPress
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
    Private Sub metroTextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox4.KeyPress
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
    Private Sub metroTextBox51_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox51.KeyPress
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
    Private Sub metroTextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox5.KeyPress
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
    Private Sub metroTextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox6.KeyPress
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
    Private Sub metroTextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox7.KeyPress
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
    Private Sub metroTextBox14_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox14.KeyPress
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
    Private Sub metroTextBox15_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox15.KeyPress
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
    Private Sub metroTextBox26_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox26.KeyPress
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

    Private Sub metroTextBox21_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox21.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
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
        MetroTextBox18.Text = FormatNumber(CDbl(MetroTextBox18.Text.Trim), 2)
    End Sub
    Private Sub MetroTextBox1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox1.Validated
        If MetroTextBox1.Text.Trim = "" Then
            MetroTextBox1.Text = "0.00"
        End If
        If MetroTextBox1.Text.Trim = "." Then
            MetroTextBox1.Text = "0.00"
        End If
        MetroTextBox1.Text = FormatNumber(CDbl(MetroTextBox1.Text.Trim), 2)

        If Math.Round(Convert.ToDouble(MetroTextBox1.Text.Trim) + Convert.ToDouble(MetroTextBox4.Text.Trim) + Convert.ToDouble(MetroTextBox51.Text.Trim), 2) = Math.Round(Convert.ToDouble(MetroTextBox20.Text.Trim), 2) Then
            MetroTextBox5.Text = "0.00"
        End If

    End Sub
    Private Sub MetroTextBox4_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox4.Validated
        If MetroTextBox4.Text.Trim = "" Then
            MetroTextBox4.Text = "0.00"
        End If
        If MetroTextBox4.Text.Trim = "." Then
            MetroTextBox4.Text = "0.00"
        End If
        MetroTextBox4.Text = FormatNumber(CDbl(MetroTextBox4.Text.Trim), 2)

        If Math.Round(Convert.ToDouble(MetroTextBox1.Text.Trim) + Convert.ToDouble(MetroTextBox4.Text.Trim) + Convert.ToDouble(MetroTextBox51.Text.Trim), 2) = Math.Round(Convert.ToDouble(MetroTextBox20.Text.Trim), 2) Then
            MetroTextBox5.Text = "0.00"
        End If

    End Sub
    Private Sub MetroTextBox51_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox51.Validated
        If MetroTextBox51.Text.Trim = "" Then
            MetroTextBox51.Text = "0.00"
        End If
        If MetroTextBox51.Text.Trim = "." Then
            MetroTextBox51.Text = "0.00"
        End If
        MetroTextBox51.Text = FormatNumber(CDbl(MetroTextBox51.Text.Trim), 2)

        If Math.Round(Convert.ToDouble(MetroTextBox1.Text.Trim) + Convert.ToDouble(MetroTextBox4.Text.Trim) + Convert.ToDouble(MetroTextBox51.Text.Trim), 2) = Math.Round(Convert.ToDouble(MetroTextBox20.Text.Trim), 2) Then
            MetroTextBox5.Text = "0.00"
        End If

    End Sub

    Private Sub MetroTextBox5_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox5.Validated
        If MetroTextBox5.Text.Trim = "" Then
            MetroTextBox5.Text = "0.00"
        End If
        If MetroTextBox5.Text.Trim = "." Then
            MetroTextBox5.Text = "0.00"
        End If
        MetroTextBox5.Text = FormatNumber(CDbl(MetroTextBox5.Text.Trim), 2)
    End Sub
    Private Sub MetroTextBox6_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox6.Validated
        If MetroTextBox6.Text.Trim = "" Then
            MetroTextBox6.Text = "0.00"
        End If
        If MetroTextBox6.Text.Trim = "." Then
            MetroTextBox6.Text = "0.00"
        End If
        MetroTextBox6.Text = FormatNumber(CDbl(MetroTextBox6.Text.Trim), 2)
    End Sub
    Private Sub MetroTextBox7_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox7.Validated
        If MetroTextBox7.Text.Trim = "" Then
            MetroTextBox7.Text = "0.00"
        End If
        If MetroTextBox7.Text.Trim = "." Then
            MetroTextBox7.Text = "0.00"
        End If
        MetroTextBox7.Text = FormatNumber(CDbl(MetroTextBox7.Text.Trim), 2)
    End Sub


#End Region

    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        MetroTextBox11.Text = ""
        MetroTextBox17.Text = ""
        MetroTextBox18.Text = "0.00"
        MetroDateTime1.Value = Now.Date
        MetroDateTime2.Value = Now.Date

        MetroTextBox11.Focus()
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
                .Item(0, h).Value = h
                .Item(1, h).Value = MetroTextBox11.Text
                .Item(2, h).Value = MetroTextBox12.Text
                .Item(3, h).Value = MetroTextBox17.Text
                .Item(4, h).Value = MetroDateTime1.Text
                .Item(5, h).Value = MetroDateTime2.Text
                .Item(6, h).Value = MetroTextBox18.Text
                h = h + 1
            End With
            suma_grilla()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Sub MetroTextBox11_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox11.Validated
        If MetroTextBox11.Text.Trim <> "" Then
            MetroTextBox12.Text = parametroSistema(8, Val(MetroTextBox11.Text.Trim))
        End If
    End Sub
    Private Sub guardar_venta()
        Try
            Dim x1 As String = ""
            Dim x2 As Double = 0
            Dim x3 As String = ""
            Dim x4 As String = ""
            Dim x5 As Byte = 0
            Dim x6 As String = ""
            Dim x7 As Double = 0
            Dim x8 As Byte = 0
            Dim x9 As Double = 0
            Dim x10 As Double = 0
            Dim x11 As String = ""
            Dim x12 As String = ""
            Dim x13 As Byte = 0
            Dim x14 As Double = 0
            Dim x15 As Double = 0
            Dim x16 As Byte = 0
            Dim x17 As Double = 0
            Dim x18 As Double = 0
            Dim x19 As Double = 0
            Dim x20 As Double = 0
            Dim x21 As Double = 0
            Dim x22 As Byte = 0

            Dim x36 As Byte = 0
            Dim x37 As Double = 0
            Dim x38 As Double = 0

            Dim x39 As Double = Total_Neto_105
            Dim x40 As Double = Total_Neto_21
            Dim x41 As Double = 0
            Dim x42 As Double = 0
            Dim x43 As Double = Total_Iva_105
            Dim x44 As Double = Total_Iva_21
            Dim x45 As Double = 0
            Dim x46 As Double = 0
            Dim x47 As Double = Total_Exento
            Dim x48 As Double = 0
            Dim x49 As Double = 0
            Dim x50 As Double = Total_Comprobante

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario
            j2 = FormatDateTime(Date.Now, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")


            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            x1 = FormatDateTime(Date.Now, DateFormat.ShortDate) '10/01/2009
            x2 = reser_Ticket
            x3 = reser_letra_compro
            x4 = reser_numero_compro
            x5 = reser_tipo_comprobante

            x6 = MetroTextBox10.Text.Trim
            If MetroTextBox15.Text.Trim = "" Then
                x7 = 0
            Else
                x7 = CDbl(MetroTextBox15.Text.Trim)
            End If

            x8 = reser_tipo_respo

            If MetroTextBox14.Text.Trim = "" Then
                x9 = 0
            Else
                x9 = CDbl(MetroTextBox14.Text.Trim)
            End If

            If MetroTextBox9.Text.Trim = "" Then
                x10 = 0
            Else
                x10 = CDbl(MetroTextBox9.Text.Trim)
            End If

            If MetroTextBox10.Text.Trim = "" Then
                x11 = " "
            Else
                x11 = MetroTextBox10.Text.Trim
            End If

            If MetroTextBox16.Text.Trim = "" Then
                x12 = " "
            Else
                x12 = MetroTextBox16.Text.Trim
            End If

            x13 = CType(MetroComboBox1.SelectedItem, ValueDescriptionPair).Value

            If MetroTextBox3.Text.Trim = "" Then
                x14 = 0
            Else
                x14 = CDbl(MetroTextBox3.Text.Trim)
            End If

            If MetroTextBox1.Text.Trim = "" Then
                x15 = 0
            Else
                x15 = CDbl(MetroTextBox1.Text.Trim)
            End If


            x16 = CType(MetroComboBox2.SelectedItem, ValueDescriptionPair).Value


            If MetroTextBox2.Text.Trim = "" Then
                x17 = 0
            Else
                x17 = CDbl(MetroTextBox2.Text.Trim)
            End If

            If MetroTextBox4.Text.Trim = "" Then
                x18 = 0
            Else
                x18 = CDbl(MetroTextBox4.Text.Trim)
            End If

            x36 = CType(MetroComboBox4.SelectedItem, ValueDescriptionPair).Value

            If MetroTextBox22.Text.Trim = "" Then
                x37 = 0
            Else
                x37 = CDbl(MetroTextBox22.Text.Trim)
            End If

            If MetroTextBox51.Text.Trim = "" Then
                x38 = 0
            Else
                x38 = CDbl(MetroTextBox51.Text.Trim)
            End If

            If MetroTextBox5.Text.Trim = "" Then
                x19 = 0
            Else
                x19 = CDbl(MetroTextBox5.Text.Trim)
            End If


            If MetroTextBox6.Text.Trim = "" Then
                x20 = 0
            Else
                x20 = CDbl(MetroTextBox6.Text.Trim)
            End If

            If MetroTextBox7.Text.Trim = "" Then
                x21 = 0
            Else
                x21 = CDbl(MetroTextBox7.Text.Trim)
            End If


            x22 = reser_contado

            Dim InsSql As String = ""
            InsSql = ""
            InsSql = "Insert into Ventas_resumen ("
            InsSql = InsSql & "Fecha,TicketNro,LetraComprobante,NumeroComprobante,TipoComprobante,"
            InsSql = InsSql & "Nombre,Documento,TipoResponsable,Cuit,Cliente,"
            InsSql = InsSql & "RazonSocial,Domicilio,Tarjeta1,Cupon1,Importe1,"
            InsSql = InsSql & "Tarjeta2,Cupon2,Importe2,ImporteContado,"
            InsSql = InsSql & "Tarjeta3,Cupon3,Importe3,"
            InsSql = InsSql & "Transferencia,Valores,Contado,"
            InsSql = InsSql & "Neto105,Neto21,Neto27,Neto25,Iva105,Iva21,Iva27,Iva25,Exento,Retenciones,Percepciones,Total,"
            InsSql = InsSql & "Ua,Fa,Ha,Estado) Values ("
            InsSql = InsSql & "'" & x1 & "'," & x2 & ",'" & x3 & "','" & x4 & "'," & x5 & ","
            InsSql = InsSql & "'" & x6 & "'," & x7 & "," & x8 & "," & x9 & "," & x10 & ","
            InsSql = InsSql & "'" & x11 & "','" & x12 & "'," & x13 & "," & x14 & "," & x15 & ","
            InsSql = InsSql & "" & x16 & "," & x17 & "," & x18 & "," & x19 & ","
            InsSql = InsSql & "" & x36 & "," & x37 & "," & x38 & ","
            InsSql = InsSql & "" & x21 & "," & x22 & "," & reser_contado & ","
            InsSql = InsSql & "" & x39 & "," & x40 & "," & x41 & "," & x42 & "," & x43 & "," & x44 & "," & x45 & "," & x46 & "," & x47 & "," & x48 & "," & x49 & "," & x50 & ","
            InsSql = InsSql & "" & j1 & ",'" & j2 & "','" & j3 & "',0)"
            Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            ConSql.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
    Private Sub guardar_cuenta_corriente()
        Try
            Dim x1 As Double = 0
            Dim x2 As String = ""
            Dim x3 As String = ""
            Dim x4 As Byte = 0
            Dim x5 As Byte = 0
            Dim x6 As String = ""
            Dim x7 As String = ""
            Dim x8 As Double = 0
            Dim x9 As String = ""



            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")

            x1 = CDbl(MetroTextBox9.Text.Trim)
            x2 = FormatDateTime(Date.Now, DateFormat.ShortDate) '10/01/2009
            x3 = FormatDateTime(Date.Now, DateFormat.ShortDate) '10/01/2009

            If reser_tipo_comprobante = 1 Then
                x4 = 1
                x5 = 1
            End If
            If reser_tipo_comprobante = 2 Then
                x4 = 1
                x5 = 2
            End If
            If reser_tipo_comprobante = 3 Then
                x4 = 2
                x5 = 3
            End If

            x6 = reser_letra_compro
            x7 = reser_numero_compro
            x8 = Total_Comprobante

            x9 = "Comprobante de referencia"

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim InsSql As String = ""
            InsSql = ""
            InsSql = "Insert into Cuenta_Corriente_Clientes ("
            InsSql = InsSql & "Cliente,Fecha,FechaImputado,DebCre,CodigoMovimiento,LetraComprobante,NumeroComprobante,Importe,Detalle,"
            InsSql = InsSql & "ImputaIva,"
            InsSql = InsSql & "UsuarioAlta,FechaAlta,HoraAlta,Estado) Values ("
            InsSql = InsSql & "" & x1 & ",'" & x2 & "','" & x3 & "'," & x4 & "," & x5 & ",'" & x6 & "','" & x7 & "'," & x8 & ",'" & x9 & "',"
            InsSql = InsSql & "1,"
            InsSql = InsSql & "" & j1 & ",'" & j2 & "','" & j3 & "',0)"
            Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            ConSql.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Sub guardar_iva_ventas()
        Try

            Dim x1 As String = ""
            Dim x2 As String = ""
            Dim x3 As String = ""
            Dim x4 As String = ""
            Dim x5 As String = ""
            Dim x6 As String = ""
            Dim x7 As Double = 0
            Dim x8 As String = ""

            Dim x9 As Double = 0
            Dim x10 As Double = 0
            Dim x11 As Double = 0
            Dim x12 As Double = 0
            Dim x13 As Double = 0
            Dim x14 As Double = 0
            Dim x15 As Double = 0
            Dim x16 As Double = 0
            Dim x17 As Double = 0
            Dim x18 As Double = 0
            Dim x19 As Double = 0
            Dim x20 As Double = 0
            Dim x21 As Double = 0
            Dim x22 As Integer = 0
            Dim x23 As Byte = 0
            Dim x24 As Double = 0
            Dim x25 As String = " "
            Dim x26 As Double = 0
            Dim x27 As Double = 0

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")

            x1 = FormatDateTime(Date.Now, DateFormat.ShortDate) '10/01/2009
            x2 = FormatDateTime(Date.Now, DateFormat.ShortDate) '10/01/2009

            If reser_tipo_comprobante = 1 Then
                x3 = "FA"
            End If
            If reser_tipo_comprobante = 2 Then
                x3 = "ND"
            End If
            If reser_tipo_comprobante = 3 Then
                x3 = "NC"
            End If

            x4 = reser_letra_compro
            x5 = reser_numero_compro

            x6 = reser_tipo_respo
            If MetroTextBox9.Text.Trim = "" Then
                x7 = 0
            Else
                x7 = CDbl(MetroTextBox9.Text.Trim)
            End If

            x9 = Total_Neto
            x10 = 0
            x11 = 0
            x12 = Total_Iva_105
            x13 = Total_Iva_21
            x14 = 0
            x15 = Total_Exento
            x16 = 0
            x17 = 0
            x18 = Total_Comprobante
            x19 = Total_Neto_105
            x20 = Total_Neto_21

            If reser_tipo_respo = 2 Then
                x21 = 0
            End If

            If MetroTextBox14.Text.Trim <> "" Then
                x21 = CDbl(MetroTextBox14.Text.Trim)
            End If

            x22 = Val(MetroComboBox3.Text)

            x8 = MetroTextBox10.Text.Trim

            x23 = 1
            If MetroTextBox15.Text.Trim = "" Then
                x24 = 0
            Else
                x24 = CDbl(MetroTextBox15.Text.Trim)
            End If

            If MetroTextBox21.Text.Trim <> "" Then
                x25 = MetroTextBox21.Text.Trim
            End If


            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim InsSql As String = ""
            InsSql = ""
            InsSql = "Insert into Iva_ventas ("
            InsSql = InsSql & "Fecha,FechaImputacion,TipoComprobante,LetraComprobante,NumeroComprobante,TipoResponsable,"
            InsSql = InsSql & "Cliente,Nombre,NetoGravado,ConceptosNoGravados,Iva25,Iva105,Iva21,Iva27,Exento,"
            InsSql = InsSql & "Retenciones,Percepciones,Total,Cuit,PuntoDeVenta,"
            InsSql = InsSql & "Neto25,Neto105,Neto21,Neto27,"
            InsSql = InsSql & "TipoDocumento,NumeroDocumento,Mail,"
            InsSql = InsSql & "UsuarioAlta,FechaAlta,HoraAlta,Estado) Values ("
            InsSql = InsSql & "'" & x1 & "','" & x2 & "','" & x3 & "','" & x4 & "','" & x5 & "'," & x6 & ","
            InsSql = InsSql & "" & x7 & ",'" & x8 & "'," & x9 & "," & x10 & "," & x11 & "," & x12 & "," & x13 & "," & x14 & "," & x15 & ","
            InsSql = InsSql & "" & x16 & "," & x17 & "," & x18 & "," & x21 & "," & x22 & ","
            InsSql = InsSql & "" & x26 & "," & x19 & "," & x20 & "," & x27 & ","
            InsSql = InsSql & "" & x23 & "," & x24 & ",'" & x25 & "',"
            InsSql = InsSql & "" & j1 & ",'" & j2 & "','" & j3 & "',0)"
            Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            ConSql.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

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
            Dim x2 As String = ""
            x2 = reser_letra_compro
            Dim x3 As String = ""
            x3 = reser_numero_compro
            Dim x4 As Double = 0

            If MetroTextBox9.Text.Trim = "" Then
                x4 = 0
            Else
                x4 = Val(MetroTextBox9.Text.Trim)
            End If

            Dim x5 As Byte = 0
            x5 = 1


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

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
    Private Sub MetroButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton4.Click

        If Math.Round(Total_Neto_21 + Total_Neto_105 + Total_Exento + Total_Iva_21 + Total_Iva_105, 2) <> Math.Round(Total_Comprobante, 2) Then
            MessageBox.Show(Me, "La suma de los importes parciales de Netos + Iva No coincide con el total", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MetroTextBox21.Text.Trim <> "" Then
            Dim x_ValidaMail = validacion_mail(MetroTextBox21.Text.Trim)
            If x_ValidaMail <> 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "El mail especificado es incorrecto !!!!.", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        If duplicacion_de_comprobante() = True Then
            Dim ok As Byte = 0
            ok = MetroFramework.MetroMessageBox.Show(Me, "Existe comprobante por este monto en este día. Confirme con seguridad !!! ", rsv_Modulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information)

            If ok <> 6 Then
                Exit Sub
            End If
        End If
        grabar_comprobante(1)
    End Sub

    Private Sub grabar_comprobante(ByVal Tipo As Byte)
        If reser_tipo_comprobante <> 1 And reser_tipo_comprobante <> 2 And reser_tipo_comprobante <> 3 Then
            Exit Sub
        End If
        If reser_tipo_comprobante <> 1 Then
            If rsv_CpteAsoc_Pto1 = 0 And rsv_CpteAsoc_Nro1 = 0 Then
                MessageBox.Show("Debe especificar números de comprobantes Asociados para Emisión de Nota de Crédito/Nota de Debito", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        'Tipo=1 contado
        'Tipo=2 cuenta corriente

        If MetroTextBox26.Text.Trim = "" Then
            MetroTextBox26.Text = 2
        End If
        If reser_tipo_respo = 2 Then
            MetroTextBox14.Text = ""
        End If

        If MetroTextBox10.Text.Trim = "" Then
            MetroTextBox10.Text = MetroTextBox8.Text.Trim
        End If

        reser_tipo_respo = Val(MetroTextBox26.Text)

        If reser_tipo_respo = 2 Then
            If MetroTextBox15.Text.Trim = "" Then
                MetroFramework.MetroMessageBox.Show(Me, "Debe especificar documento para consumidor final", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If
        If reser_tipo_respo <> 2 Then
            If MetroTextBox14.Text.Trim = "" Then
                MetroFramework.MetroMessageBox.Show(Me, "Debe especificar Cuit para la calidad de Responsable de Cliente", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If cuitValido(MetroTextBox14.Text.Trim) = False Then
                MetroFramework.MetroMessageBox.Show(Me, "Número de Cuit Inválido para la calidad de Responsable de Cliente", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        If MetroTextBox8.Text.Trim = "" And MetroTextBox9.Text.Trim = "" And MetroTextBox10.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar Nombre del Cliente.", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        reser_contado = 0
        If Tipo = 1 Then
            reser_contado = 1
        End If

        If MetroTextBox1.Text.Trim = "" Then
            MetroTextBox1.Text = "0.00"
        End If
        If MetroTextBox4.Text.Trim = "" Then
            MetroTextBox4.Text = "0.00"
        End If
        If MetroTextBox5.Text.Trim = "" Then
            MetroTextBox5.Text = "0.00"
        End If
        If MetroTextBox6.Text.Trim = "" Then
            MetroTextBox6.Text = "0.00"
        End If
        If MetroTextBox7.Text.Trim = "" Then
            MetroTextBox7.Text = "0.00"
        End If
        If MetroTextBox1.Text.Trim = "." Then
            MetroTextBox1.Text = "0.00"
        End If
        If MetroTextBox4.Text.Trim = "." Then
            MetroTextBox4.Text = "0.00"
        End If
        If MetroTextBox5.Text.Trim = "." Then
            MetroTextBox5.Text = "0.00"
        End If
        If MetroTextBox6.Text.Trim = "." Then
            MetroTextBox6.Text = "0.00"
        End If
        If MetroTextBox7.Text.Trim = "." Then
            MetroTextBox7.Text = "0.00"
        End If

        If isOnline() = False Then
            MetroFramework.MetroMessageBox.Show(Me, "No existe conexión a Internet", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Call cargar_Array_Venta()

        If fecha_expir_ticket() = False Then
            MessageBox.Show("Debe Solicitar Ticket Afip. Rango Horario Vencido", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'Validaciones de contado
        If reser_contado = 1 Then
            Dim aux1 As Double = 0
            Dim aux2 As Double = 0

            aux1 = Math.Round(CDbl(MetroTextBox20.Text), 2)
            aux2 = Math.Round(CDbl(MetroTextBox1.Text) + CDbl(MetroTextBox4.Text) + CDbl(MetroTextBox51.Text) + CDbl(MetroTextBox5.Text) + CDbl(MetroTextBox6.Text) + CDbl(MetroTextBox7.Text), 2)

            If aux1 <> aux2 Then
                MetroFramework.MetroMessageBox.Show(Me, "Total de operación no corresponde con total de pago", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            aux1 = Math.Round(CDbl(MetroTextBox19.Text), 2)
            aux2 = Math.Round(CDbl(MetroTextBox7.Text), 2)

            If aux1 <> aux2 Then
                MetroFramework.MetroMessageBox.Show(Me, "Suma de valores no coincide con importe pago cheques", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'If CDbl(MetroTextBox1.Text.Trim) <> 0 Then
            '    '    If MetroTextBox3.Text.Trim = "" Then
            '    '        MetroFramework.MetroMessageBox.Show(Me, "Venta de Tarjeta. Debe especificar importe o cupón", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    '        Exit Sub
            '    '    End If
            'End If

            If CDbl(MetroTextBox4.Text.Trim) <> 0 Then
                If MetroTextBox2.Text.Trim = "" Then
                    MetroFramework.MetroMessageBox.Show(Me, "Venta de Tarjeta. Debe especificar importe o cupón. Tarjeta 2", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            If CDbl(MetroTextBox51.Text.Trim) <> 0 Then
                If MetroTextBox22.Text.Trim = "" Then
                    MetroFramework.MetroMessageBox.Show(Me, "Venta de Tarjeta. Debe especificar importe o cupón. Tarjeta 3", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
        End If

        If reser_contado = 0 Then

            If MetroTextBox9.Text.Trim = "" Or MetroTextBox10.Text.Trim = "" Then
                MetroFramework.MetroMessageBox.Show(Me, "Para cuenta corriente debe especificar cliente", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            MetroTextBox1.Text = "0.00"
            MetroTextBox3.Text = "0"
            MetroTextBox4.Text = "0.00"
            MetroTextBox2.Text = "0"
            MetroTextBox51.Text = "0.00"
            MetroTextBox22.Text = "0"

            MetroTextBox5.Text = "0.00"
            MetroTextBox6.Text = "0.00"
            MetroTextBox7.Text = "0.00"
        End If
        If reser_tipo_respo = 1 Or reser_tipo_respo = 4 Then
            MetroTextBox25.Text = "A"
        Else
            MetroTextBox25.Text = "B"
        End If

        MetroTextBox24.Text = MetroComboBox3.Text


        If logica_facturacion_fiscal() = False Then
            Exit Sub
        End If


        reser_letra_compro = MetroTextBox25.Text
        reser_numero_compro = Formatea_Numero_Comprobante(Val(MetroTextBox24.Text.Trim), Val(MetroTextBox23.Text.Trim))

        grabar_Comprobante_fiscal(reser_contado)

        grabarcaja(reser_contado)

        If reser_contado = 0 Then
            guardar_cuenta_corriente()
        End If

        guardar_iva_ventas()

        If CDbl(MetroTextBox7.Text) <> 0 Then
            guardar_valores()
        End If

        guardar_venta()
        marcar_ticket_facturado()

        imprimir_comprobante_actual


        If MetroTextBox21.Text.Trim <> "" Then
            enviar_comprobante_mail()
        End If

        'If reser_tipo_comprobante = 1 Then
        '    Call impresion_cupon_devolucion(reser_Ticket, 2)
        'End If

        Me.Close()

    End Sub
    Private Sub imprimir_comprobante_actual()
        Dim f As String = FormatDateTime(Date.Now, DateFormat.ShortDate)
        Dim c As Byte = 1
        Dim p As String = Val(MetroComboBox3.Text.Trim)
        Dim t As Byte = 0
        Dim l As String = reser_letra_compro
        Dim n As String = reser_numero_compro

        t = reser_tipo_comprobante

        If l = "A" Then
            Call impresion_comprobante_a(p, t, l, n, f, c, 1)
        Else
            'If i <= 12 Then
            '    Call impresion_comprobante_b(p, t, l, n, f, c, 2)
            'Else
            '    Call impresion_comprobante_b(p, t, l, n, f, c, 1)
            'End If
            Call impresion_comprobante_b(p, t, l, n, f, c, 1)
        End If

    End Sub
    Private Sub marcar_ticket_facturado()
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

            Sql = "Update Tickets SET Facturado=1,"
            Sql = Sql & "Ffa='" & j2 & "',Hfa='" & j3 & "',Ufa=" & j1 & " WHERE TicketNro= " & reser_Ticket & " "

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConSql.Close()
        End Try
    End Sub

    Private Sub MetroButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        If MetroTextBox9.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar Cliente Para Imputación Cuenta Corriente !!! ", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MetroTextBox9.Text.Trim <> "" Then
            Dim habilitado_ctacte = valida_habilitacion_ctacte(Convert.ToDouble(MetroTextBox9.Text.Trim))
            If habilitado_ctacte = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Cliente Inexistente", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If habilitado_ctacte = 2 Then
                MetroFramework.MetroMessageBox.Show(Me, "No posee Autorización Para Operar en Cuenta Corriente", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        If duplicacion_de_comprobante() = True Then
            Dim ok As Byte = 0
            ok = MetroFramework.MetroMessageBox.Show(Me, "Existe comprobante por este monto en este día. Confirme con seguridad !!! ", rsv_Modulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information)

            If ok <> 6 Then
                Exit Sub
            End If
        End If

        grabar_comprobante(2)

    End Sub
    Private Sub MetroButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton5.Click
        Me.Close()
    End Sub

    Private Function Formatea_Numero_Comprobante(ByVal x1 As Integer, ByVal x2 As Double) As String
        Dim c3 As String

        Dim xNumeroDe4 As String
        Dim xNumeroDe8 As String

        xNumeroDe4 = x1
        xNumeroDe4 = xNumeroDe4.PadLeft(4)
        xNumeroDe4 = xNumeroDe4.Replace(" ", "0")

        xNumeroDe8 = x2
        xNumeroDe8 = xNumeroDe8.PadLeft(8)
        xNumeroDe8 = xNumeroDe8.Replace(" ", "0")

        c3 = xNumeroDe4.ToString & "-" & xNumeroDe8.ToString

        Formatea_Numero_Comprobante = c3
    End Function
    Private Sub cargar_puntos_venta()
        Try
            Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
            Dim ConSql As New OleDbConnection(Conexion)

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim i As Integer = 1

            MetroComboBox3.Items.Clear()

            Dim cmdCombo As New OleDbCommand("Select * from Parametro_punto_de_venta where (Estado=0) order by Punto", ConSql)
            Dim drCombo As OleDbDataReader = cmdCombo.ExecuteReader
            If drCombo.HasRows Then 'Tiene filas
                Do While drCombo.Read
                    MetroComboBox3.Items.Add(New ValueDescriptionPair(i, drCombo("Punto").ToString))
                    i = i + 1
                Loop
            End If
            MetroComboBox3.SelectedIndex = 0
            drCombo.Close()
        Catch ex As Exception

            MessageBox.Show("Error al conectar o recuperar lo datos :" & vbCrLf &
                             ex.Message, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function logica_facturacion_fiscal() As Boolean
        Dim r As Boolean = False

        r = state_service_afip()
        If r = False Then
            MetroFramework.MetroMessageBox.Show(Me, "Problemas en los servicios de Afip", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            logica_facturacion_fiscal = r
            Exit Function
        End If

        TipoDocRecep_Afip = 0
        NroDocRecep_Afip = 0

        Dim txt_ptovta As String = ""
        Dim txt_tipo As String = ""
        Dim cod_err As Byte = 0
        Dim msg_err As String = ""

        txt_ptovta = MetroComboBox3.Text.Trim

        If MetroTextBox26.Text.Trim = "1" Or MetroTextBox26.Text.Trim = "4" Then
            If reser_tipo_comprobante = 1 Then
                txt_tipo = "01"
            End If
            If reser_tipo_comprobante = 2 Then
                txt_tipo = "02"
            End If
            If reser_tipo_comprobante = 3 Then
                txt_tipo = "03"
            End If
        Else
            If reser_tipo_comprobante = 1 Then
                txt_tipo = "06"
            End If
            If reser_tipo_comprobante = 2 Then
                txt_tipo = "07"
            End If
            If reser_tipo_comprobante = 3 Then
                txt_tipo = "08"
            End If

        End If

        r = False

        Dim txt_ultimo_num_comp As String = ""
        txt_ultimo_num_comp = consulta_ultimo_comprobante_afip(txt_ptovta, txt_tipo, cod_err, msg_err)

        If cod_err <> 0 Then
            MetroFramework.MetroMessageBox.Show(Me, "Problemas en Retornar Ultimo Nro. Comprobante " & msg_err, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            logica_facturacion_fiscal = r
            Exit Function
        End If

        If txt_ultimo_num_comp.Trim = "" Then
            r = False
            MetroFramework.MetroMessageBox.Show(Me, "Problemas en Retornar Ultimo Nro. Comprobante ", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            logica_facturacion_fiscal = r
            Exit Function
        End If

        If msg_err.Trim <> "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Mensaje Afip" & vbCrLf & msg_err, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Dim txt_token As String = ""
        Dim txt_sign As String = ""
        Dim txt_cuit As String = ""
        Dim arg_e As Byte = 0

        Call lectura_ticket(txt_token, txt_sign, txt_cuit, arg_e)

        If arg_e Then
            r = False
            MetroFramework.MetroMessageBox.Show(Me, "Problemas en lectura de Ticket", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            logica_facturacion_fiscal = r
            Exit Function
        End If

        If txt_token.Trim = "" Or txt_sign.Trim = "" Or txt_cuit = "" Then
            r = False
            MetroFramework.MetroMessageBox.Show(Me, "Problemas en lectura de Ticket", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            logica_facturacion_fiscal = r
            Exit Function
        End If

        MetroTextBox23.Text = CStr(Val(txt_ultimo_num_comp) + 1)

        logica_facturacion_fiscal = r

        Dim txt_con As String = "3"
        Dim txt_doctipo As String = ""
        Dim txt_docnro As String = ""
        Dim txt_cbtedes As String = CStr(Val(txt_ultimo_num_comp) + 1)
        Dim txt_cbtehas As String = CStr(Val(txt_ultimo_num_comp) + 1)
        Dim txt_cbteFch As String = DateTime.Now.ToString("yyyyMMdd")


        Dim txt_imptot As String = ""
        Dim txt_imptotconc As String = ""
        Dim txt_impneto As String = ""
        Dim txt_impopex As String = ""
        Dim txt_imptrib As String = ""
        Dim txt_impiva As String = ""


        Dim txt_fecserdes As String = DateTime.Now.ToString("yyyyMMdd")
        Dim txt_fecserhas As String = DateTime.Now.ToString("yyyyMMdd")
        Dim txt_fecvtopago As String = DateTime.Now.ToString("yyyyMMdd")
        Dim txt_monid As String = "PES"
        Dim txt_moncot As String = "1.0"

        Dim txt_iva_baseimp1 As String = ""
        Dim txt_iva_id1 As String = ""
        Dim txt_iva_imp1 As String = ""

        Dim txt_iva_baseimp2 As String = ""
        Dim txt_iva_id2 As String = ""
        Dim txt_iva_imp2 As String = ""

        Dim txt_letra_comp As String = ""
        Dim txt_nro_comp As String = ""

        Dim txt_cae_result As String = ""
        Dim txt_cae As String = ""
        Dim txt_Fec_vto_cae As String = ""
        Dim txt_msg_err As String = ""

        Dim txt_ImpInternos As String = ""
        Dim txt_IngBrutos As String = ""

        Dim Cant_Alic As Byte = 0

        txt_imptot = CStr(Total_Comprobante)
        txt_imptotconc = "0.0"

        txt_impneto = Total_Neto_105 + Total_Neto_21
        txt_impopex = Total_Exento
        txt_imptrib = "0.00"
        txt_imptrib = 0
        txt_impiva = Total_Iva_105 + Total_Iva_21

        txt_iva_id1 = "4"
        txt_iva_imp1 = Total_Iva_105
        txt_iva_baseimp1 = Total_Neto_105

        txt_iva_id2 = "5"
        txt_iva_imp2 = Total_Iva_21
        txt_iva_baseimp2 = Total_Neto_21

        If Convert.ToDouble(Total_Iva_105) <> 0 Then
            Cant_Alic = Cant_Alic + 1
        End If
        If Convert.ToDouble(Total_Iva_21) <> 0 Then
            Cant_Alic = Cant_Alic + 1
        End If

        'Comprobantes Asociados

        Dim Cant_CpteAsoc As Byte = 0

        Dim txt_CpteAsoc_Cuit1 As String = ""
        Dim txt_CpteAsoc_Nro1 As String = ""
        Dim txt_CpteAsoc_PtoVta1 As String = ""
        Dim txt_CpteAsoc_Tipo1 As String = ""
        Dim txt_CpteAsoc_Fecha1 As String = ""

        Dim txt_CpteAsoc_Cuit2 As String = ""
        Dim txt_CpteAsoc_Nro2 As String = ""
        Dim txt_CpteAsoc_PtoVta2 As String = ""
        Dim txt_CpteAsoc_Tipo2 As String = ""
        Dim txt_CpteAsoc_Fecha2 As String = ""

        Dim txt_CpteAsoc_Cuit3 As String = ""
        Dim txt_CpteAsoc_Nro3 As String = ""
        Dim txt_CpteAsoc_PtoVta3 As String = ""
        Dim txt_CpteAsoc_Tipo3 As String = ""
        Dim txt_CpteAsoc_Fecha3 As String = ""

        If (reser_tipo_comprobante = 2 Or reser_tipo_comprobante = 3) Then

            'Primer Comprobante Asociado
            If rsv_CpteAsoc_Nro1 <> 0 Then
                Cant_CpteAsoc = 1
                txt_CpteAsoc_Cuit1 = rsv_CpteAsoc_Cuit1
                txt_CpteAsoc_Tipo1 = "1"
                txt_CpteAsoc_PtoVta1 = rsv_CpteAsoc_Pto1
                txt_CpteAsoc_Nro1 = rsv_CpteAsoc_Nro1
                txt_CpteAsoc_Fecha1 = rsv_CpteAsoc_Fecha1.ToString("yyyyMMdd")

                If rsv_CpteAsoc_Tipo1.Trim.ToUpper = "FA" Then
                    If rsv_CpteAsoc_Letra1.Trim.ToUpper = "A" Then
                        txt_CpteAsoc_Tipo1 = "1"
                    End If
                    If rsv_CpteAsoc_Letra1.Trim.ToUpper = "B" Then
                        txt_CpteAsoc_Tipo1 = "6"
                    End If
                End If
                If rsv_CpteAsoc_Tipo1.Trim.ToUpper = "ND" Then
                    If rsv_CpteAsoc_Letra1.Trim.ToUpper = "A" Then
                        txt_CpteAsoc_Tipo1 = "2"
                    End If
                    If rsv_CpteAsoc_Letra1.Trim.ToUpper = "B" Then
                        txt_CpteAsoc_Tipo1 = "7"
                    End If
                End If
            End If

            If rsv_CpteAsoc_Nro2 <> 0 Then
                Cant_CpteAsoc = 2
                txt_CpteAsoc_Cuit2 = rsv_CpteAsoc_Cuit2
                txt_CpteAsoc_Tipo2 = "1"
                txt_CpteAsoc_PtoVta2 = rsv_CpteAsoc_Pto2
                txt_CpteAsoc_Nro2 = rsv_CpteAsoc_Nro2
                txt_CpteAsoc_Fecha2 = rsv_CpteAsoc_Fecha2.ToString("yyyyMMdd")

                If rsv_CpteAsoc_Tipo2.Trim.ToUpper = "FA" Then
                    If rsv_CpteAsoc_Letra2.Trim.ToUpper = "A" Then
                        txt_CpteAsoc_Tipo2 = "1"
                    End If
                    If rsv_CpteAsoc_Letra2.Trim.ToUpper = "B" Then
                        txt_CpteAsoc_Tipo2 = "6"
                    End If
                End If
                If rsv_CpteAsoc_Tipo2.Trim.ToUpper = "ND" Then
                    If rsv_CpteAsoc_Letra2.Trim.ToUpper = "A" Then
                        txt_CpteAsoc_Tipo2 = "2"
                    End If
                    If rsv_CpteAsoc_Letra2.Trim.ToUpper = "B" Then
                        txt_CpteAsoc_Tipo2 = "7"
                    End If
                End If
            End If

            If rsv_CpteAsoc_Nro3 <> 0 Then
                Cant_CpteAsoc = 3
                txt_CpteAsoc_Cuit3 = rsv_CpteAsoc_Cuit3
                txt_CpteAsoc_Tipo3 = "1"
                txt_CpteAsoc_PtoVta3 = rsv_CpteAsoc_Pto3
                txt_CpteAsoc_Nro3 = rsv_CpteAsoc_Nro3
                txt_CpteAsoc_Fecha3 = rsv_CpteAsoc_Fecha3.ToString("yyyyMMdd")

                If rsv_CpteAsoc_Tipo3.Trim.ToUpper = "FA" Then
                    If rsv_CpteAsoc_Letra3.Trim.ToUpper = "A" Then
                        txt_CpteAsoc_Tipo3 = "1"
                    End If
                    If rsv_CpteAsoc_Letra3.Trim.ToUpper = "B" Then
                        txt_CpteAsoc_Tipo3 = "6"
                    End If
                End If
                If rsv_CpteAsoc_Tipo3.Trim.ToUpper = "ND" Then
                    If rsv_CpteAsoc_Letra3.Trim.ToUpper = "A" Then
                        txt_CpteAsoc_Tipo3 = "2"
                    End If
                    If rsv_CpteAsoc_Letra3.Trim.ToUpper = "B" Then
                        txt_CpteAsoc_Tipo3 = "7"
                    End If
                End If
            End If

        End If


        If MetroTextBox25.Text.Trim.ToUpper = "A" Then
            txt_doctipo = "80"
            txt_docnro = MetroTextBox14.Text.Trim
        End If

        If MetroTextBox25.Text.Trim.ToUpper = "B" Then
            txt_doctipo = "99"
            txt_docnro = "0"

            If MetroTextBox26.Text.Trim = "2" Then
                txt_doctipo = "96"
                txt_docnro = MetroTextBox15.Text.Trim
            End If
            If MetroTextBox26.Text.Trim = "2" And MetroTextBox14.Text.Trim.Length = 11 Then
                txt_doctipo = "80"
                txt_docnro = MetroTextBox14.Text.Trim
            End If

            If MetroTextBox26.Text.Trim = "3" Then
                txt_doctipo = "80"
                txt_docnro = MetroTextBox14.Text.Trim
            End If
            'If MetroTextBox26.Text.Trim = "4" Then
            '    txt_doctipo = "80"
            '    txt_docnro = MetroTextBox14.Text.Trim
            'End If
        End If

        TipoDocRecep_Afip = Val(txt_doctipo)
        NroDocRecep_Afip = Val(txt_docnro)

        txt_letra_comp = MetroTextBox25.Text.Trim.ToUpper
        txt_nro_comp = Formatea_Numero_Comprobante(Val(MetroTextBox24.Text.Trim), Val(MetroTextBox23.Text.Trim))

        Call FECAESolicitar(txt_token, txt_sign,
                                             txt_cuit, txt_ptovta, txt_tipo,
                                             txt_con, txt_doctipo, txt_docnro, txt_cbtedes,
                                             txt_cbtehas, txt_cbteFch, txt_imptot, txt_imptotconc, txt_impneto,
                                             txt_impopex, txt_imptrib, txt_impiva, txt_fecserdes,
                                             txt_fecserhas, txt_fecvtopago, txt_monid, txt_moncot,
                                             txt_iva_baseimp1, txt_iva_id1, txt_iva_imp1,
                                             txt_iva_baseimp2, txt_iva_id2, txt_iva_imp2,
                                             txt_letra_comp, txt_nro_comp, Cant_Alic,
                                             Cant_CpteAsoc, txt_CpteAsoc_Cuit1, txt_CpteAsoc_Tipo1, txt_CpteAsoc_PtoVta1, txt_CpteAsoc_Nro1,
                                             txt_CpteAsoc_Cuit2, txt_CpteAsoc_Tipo2, txt_CpteAsoc_PtoVta2, txt_CpteAsoc_Nro2,
                                             txt_CpteAsoc_Cuit3, txt_CpteAsoc_Tipo3, txt_CpteAsoc_PtoVta3, txt_CpteAsoc_Nro3,
                                             txt_cae_result, txt_cae, txt_Fec_vto_cae, txt_msg_err)
        r = False

        If txt_cae_result = "A" Then
            Cae_Afip = txt_cae
            FecVtoCae_Afip = txt_Fec_vto_cae
            r = True
        End If
        If txt_msg_err <> "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Mensaje Afip" & vbCrLf & txt_msg_err, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        logica_facturacion_fiscal = r

    End Function
    Private Sub grabar_Comprobante_fiscal(ByVal xTipo As Byte)
        Try
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
            x1 = FormatDateTime(Now.Date, DateFormat.ShortDate)
            Dim x2 As String = ""
            x2 = reser_letra_compro
            Dim x3 As String = ""
            x3 = reser_numero_compro
            Dim x4 As Double = 0
            If MetroTextBox9.Text.Trim = "" Then
                x4 = 0
            Else
                x4 = Convert.ToDouble(MetroTextBox9.Text.Trim)
            End If

            Dim x5 As String = ""
            Dim x6 As String = ""
            Dim x7 As String = ""
            Dim x8 As String = ""
            Dim x9 As String = ""
            Dim x10 As Byte = 0
            Dim x11 As Byte = 0
            Dim x12 As Double = 0

            x5 = MetroTextBox10.Text.Trim
            x6 = MetroTextBox16.Text.Trim
            If x7.Trim = "" Then
                x7 = " "
            End If
            If x8.Trim = "" Then
                x8 = " "
            End If
            If x9.Trim = "" Then
                x9 = " "
            End If
            x10 = 0

            If reser_tipo_comprobante = 1 Then
                x11 = 1
            End If
            If reser_tipo_comprobante = 2 Then
                x11 = 2
            End If
            If reser_tipo_comprobante = 3 Then
                x11 = 3
            End If

            x12 = 0

            Dim InsSql As String = ""

            Dim x20 As Byte = 0
            Dim x21 As String = ""
            Dim x22 As String = ""
            Dim x23 As Double = 0
            Dim x24 As Integer = 0
            Dim x25 As Double = 0
            Dim x26 As Double = 0
            Dim x27 As Double = 0
            Dim x28 As Double = 0
            Dim x29 As Double = 0
            Dim x30 As Double = 0
            Dim x31 As Integer = 0
            Dim x32 As String = ""
            Dim x33 As String = ""
            Dim x41 As Double = 0
            Dim x42 As Double = 0
            Dim x43 As Double = 0
            Dim x44 As Double = 0
            Dim x45 As Double = 0
            Dim x46 As Double = 0
            Dim x47 As Double = 0
            Dim x48 As Double = 0
            Dim x49 As Double = 0

            If Val(MetroTextBox26.Text.Trim) = 1 Or Val(MetroTextBox26.Text.Trim) = 4 Then
                x41 = Total_Neto
                x42 = 0
                x43 = Total_Exento
                x44 = 0
                x45 = Total_Iva_105
                x46 = Total_Iva_21
                x47 = 0
                x48 = 0
                x49 = Total_Comprobante
            Else
                x41 = 0
                x42 = 0
                x43 = 0
                x44 = 0
                x45 = 0
                x46 = 0
                x47 = 0
                x48 = 0
                x49 = Total_Comprobante
            End If

            Dim x50 As String = ""
            Dim x51 As Byte = 0
            Dim x52 As Byte = 0
            Dim x53 As Double = 0
            Dim x54 As Double = 0
            Dim x55 As Double = 0
            Dim x56 As Double = 0
            x50 = " "

            If MetroTextBox1.Text.Trim <> "" Then
                If CDbl(MetroTextBox1.Text.Trim) <> 0 Then
                    x50 = "PAGO CON TARJETA >> " & MetroComboBox1.Text.Trim.ToUpper & " >>>> CUPON NRO >>>> " & MetroTextBox3.Text.Trim & " >>>> IMPORTE $ " & FormatNumber(CDbl(MetroTextBox1.Text.Trim), 2)
                End If
            End If
            If MetroTextBox4.Text.Trim <> "" Then
                If CDbl(MetroTextBox4.Text.Trim) <> 0 Then
                    If x50.Trim <> "" Then
                        x50 = x50 & ". >> TARJETA >> " & MetroComboBox2.Text.Trim.ToUpper & " >>>> CUPON NRO >>>> " & MetroTextBox2.Text.Trim & " >>>> IMPORTE $ " & FormatNumber(CDbl(MetroTextBox4.Text.Trim), 2)
                    Else
                        x50 = x50 & ". >> PAGO CON TARJETA >> " & MetroComboBox2.Text.Trim.ToUpper & " >>>> CUPON NRO >>>> " & MetroTextBox2.Text.Trim & " >>>> IMPORTE $ " & FormatNumber(CDbl(MetroTextBox4.Text.Trim), 2)
                    End If
                End If
            End If
            If MetroTextBox51.Text.Trim <> "" Then
                If CDbl(MetroTextBox51.Text.Trim) <> 0 Then
                    If x50.Trim <> "" Then
                        x50 = x50 & ". >> TARJETA >> " & MetroComboBox4.Text.Trim.ToUpper & " >>>> CUPON NRO >>>> " & MetroTextBox22.Text.Trim & " >>>> IMPORTE $ " & FormatNumber(CDbl(MetroTextBox51.Text.Trim), 2)
                    Else
                        x50 = x50 & ". >> PAGO CON TARJETA >> " & MetroComboBox4.Text.Trim.ToUpper & " >>>> CUPON NRO >>>> " & MetroTextBox22.Text.Trim & " >>>> IMPORTE $ " & FormatNumber(CDbl(MetroTextBox51.Text.Trim), 2)
                    End If
                End If
            End If

            If MetroTextBox5.Text.Trim <> "" Then
                If CDbl(MetroTextBox5.Text.Trim) <> 0 Then
                    x50 = x50 & ". >> PAGADO EN EFECTIVO  $$$ >> " & FormatNumber(CDbl(MetroTextBox5.Text.Trim), 2) & " <<<<"
                End If
            End If
            If MetroTextBox6.Text.Trim <> "" Then
                If CDbl(MetroTextBox6.Text.Trim) <> 0 Then
                    x50 = x50 & ". >> PAGADO CON TRANSFERENCIA  $$$ >> " & FormatNumber(CDbl(MetroTextBox6.Text.Trim), 2) & " <<<<"
                End If
            End If

            '--------------
            If MetroTextBox4.Text.Trim <> "" Then
                Dim cadena_valores As String = ""
                Dim cadena_val_aux As String = ""

                For Fila As Integer = 0 To metroGrid1.Rows.Count - 1
                    cadena_val_aux = "***" & Microsoft.VisualBasic.Left(metroGrid1.Rows(Fila).Cells("Detalle").Value.ToString.Trim, 30) & ">>>" &
                         FormatDateTime(metroGrid1.Rows(Fila).Cells("Fecha").Value, DateFormat.ShortDate) & ">>>" &
                         FormatDateTime(metroGrid1.Rows(Fila).Cells("Pago").Value, DateFormat.ShortDate) & ">>>" &
                         metroGrid1.Rows(Fila).Cells("Numero").Value.ToString.Trim & ">>>$" &
                         FormatNumber(CDbl(metroGrid1.Rows(Fila).Cells("Importe").Value), 2)
                    cadena_valores = cadena_valores & cadena_val_aux
                Next
                x50 = x50 & cadena_valores
            End If
            '--------------

            x51 = CType(MetroComboBox1.SelectedItem, ValueDescriptionPair).Value
            x52 = CType(MetroComboBox2.SelectedItem, ValueDescriptionPair).Value
            x53 = CDbl(MetroTextBox1.Text.Trim)
            x54 = CDbl(MetroTextBox4.Text.Trim)
            x55 = CDbl(MetroTextBox7.Text.Trim)
            x56 = CDbl(MetroTextBox5.Text.Trim)


            Dim x57 As Byte = 0
            Dim x58 As Double = 0
            Dim x59 As Byte

            x57 = CInt(MetroTextBox26.Text.Trim)


            If MetroTextBox14.Text.Trim = "" Then
                x58 = 0
            Else
                x58 = CDbl(MetroTextBox14.Text.Trim)
            End If

            x59 = xTipo

            Dim x60 As Integer = 0
            Dim x61 As Double = 0

            'x60 = 1
            'If MetroTextBox15.Text.Trim <> "" Then
            '    x61 = Val(MetroTextBox15.Text.Trim)
            'End If

            x60 = TipoDocRecep_Afip
            x61 = NroDocRecep_Afip

            If TipoDocRecep_Afip = 80 Then
                x61 = 0
            End If

            Dim x131 As String = " "
            Dim x132 As String = " "
            Dim x133 As String = " "
            Dim x134 As String = " "
            Dim x135 As String = " "
            Dim x136 As String = " "

            Dim x141 As String = " "
            Dim x142 As String = " "
            Dim x143 As String = " "
            Dim x144 As String = " "
            Dim x145 As String = " "
            Dim x146 As String = " "

            Dim x151 As String = " "
            Dim x152 As String = " "
            Dim x153 As String = " "
            Dim x154 As String = " "
            Dim x155 As String = " "
            Dim x156 As String = " "

            If rsv_CpteAsoc_Nro1 <> 0 Then
                x131 = rsv_CpteAsoc_Cuit1
                x132 = rsv_CpteAsoc_Tipo1
                x133 = rsv_CpteAsoc_Letra1
                x134 = rsv_CpteAsoc_Pto1
                x135 = rsv_CpteAsoc_Nro1
                x136 = rsv_CpteAsoc_Fecha1
            End If

            If rsv_CpteAsoc_Nro2 <> 0 Then
                x141 = rsv_CpteAsoc_Cuit2
                x142 = rsv_CpteAsoc_Tipo2
                x143 = rsv_CpteAsoc_Letra2
                x144 = rsv_CpteAsoc_Pto2
                x145 = rsv_CpteAsoc_Nro2
                x146 = rsv_CpteAsoc_Fecha2
            End If

            If rsv_CpteAsoc_Nro3 <> 0 Then
                x151 = rsv_CpteAsoc_Cuit3
                x152 = rsv_CpteAsoc_Tipo3
                x153 = rsv_CpteAsoc_Letra3
                x154 = rsv_CpteAsoc_Pto3
                x155 = rsv_CpteAsoc_Nro3
                x156 = rsv_CpteAsoc_Fecha3
            End If


            Dim i As Integer = 1

            For Each itemTicket As registro_ticket In ticket_ventas

                x20 = reser_tipo_comprobante
                x21 = itemTicket.Codigo
                x22 = itemTicket.Detalle

                x23 = itemTicket.Cantidad
                x24 = itemTicket.CodUnidadMedidaFiscal
                x25 = itemTicket.PrecioFiscal
                x26 = itemTicket.BonifFiscal
                x27 = itemTicket.ImporteBonifFiscal
                x28 = itemTicket.AlicuotaFiscal
                x29 = itemTicket.ImporteIvaFiscal
                x30 = itemTicket.SubTotalFiscal
                x31 = i
                x32 = " "
                x33 = "UNI"

                InsSql = ""
                InsSql = "Insert into Ventas_Detalle_afip ("
                InsSql = InsSql & "Fecha,LetraComprobante,NumeroComprobante,Cliente,Nombre,Domicilio,Ciudad,Provincia,Telefono,ClienteEspontaneo,Lista,TipoComprobante,"
                InsSql = InsSql & "Codigo,Producto,Cantidad,UnidadDeMedida,Precio,Descuento,ImporteDescuento,AlicuotaProducto,ImporteConAlicuota,SubTotal,Orden,Observacion,UnidadDeMedidaLiteral,"
                InsSql = InsSql & "NetoGravado,NetoNoGravado,Exento,Iva25,Iva105,Iva21,Iva27,OtrosImpuestos,ImporteTotal,"
                InsSql = InsSql & "DescripComprob,Tarj1,Tarj2,ImpTarj1,ImpTarj2,Efectivo,Valores,Contado,"
                InsSql = InsSql & "TipoResponsable,Cuit,NumeroOperacion,TipoDocumento,NumeroDocumento,CaeAfip,FechaVtoCaeAfip,"
                InsSql = InsSql & "AsocC_Cuit1,AsocC_Tipo1,AsocC_Letra1,AsocC_Pto1,AsocC_Nro1,AsocC_Fec1,"
                InsSql = InsSql & "AsocC_Cuit2,AsocC_Tipo2,AsocC_Letra2,AsocC_Pto2,AsocC_Nro2,AsocC_Fec2,"
                InsSql = InsSql & "AsocC_Cuit3,AsocC_Tipo3,AsocC_Letra3,AsocC_Pto3,AsocC_Nro3,AsocC_Fec3,"
                InsSql = InsSql & "UsuarioAlta,HoraAlta,FechaAlta,TipoDocRecepAfip,NroDocRecepAfip,Estado) Values ("
                InsSql = InsSql & "'" & x1 & "','" & x2 & "','" & x3 & "'," & x4 & ",'" & x5 & "','" & x6 & "','" & x7 & "','" & x8 & "','" & x9 & "'," & x10 & "," & x20 & "," & x11 & ","
                InsSql = InsSql & "'" & x21 & "','" & x22 & "'," & x23 & "," & x24 & "," & x25 & "," & x26 & "," & x27 & "," & x28 & "," & x29 & "," & x30 & "," & x31 & ",'" & x32 & "','" & x33 & "',"
                InsSql = InsSql & "" & x41 & "," & x42 & "," & x43 & "," & x44 & "," & x45 & "," & x46 & "," & x47 & "," & x48 & "," & x49 & ","
                InsSql = InsSql & "'" & x50 & "'," & x51 & "," & x52 & "," & x53 & "," & x54 & "," & x55 & "," & x56 & "," & x59 & ","
                InsSql = InsSql & "" & x57 & "," & x58 & "," & x12 & "," & x60 & "," & x61 & ",'" & Cae_Afip & "','" & FecVtoCae_Afip & "',"
                InsSql = InsSql & "'" & x131 & "','" & x132 & "','" & x133 & "','" & x134 & "','" & x135 & "','" & x136 & "',"
                InsSql = InsSql & "'" & x141 & "','" & x142 & "','" & x143 & "','" & x144 & "','" & x145 & "','" & x146 & "',"
                InsSql = InsSql & "'" & x151 & "','" & x152 & "','" & x153 & "','" & x154 & "','" & x155 & "','" & x156 & "',"
                InsSql = InsSql & "" & j1 & ",'" & j3 & "','" & j2 & "'," & TipoDocRecep_Afip & "," & NroDocRecep_Afip & ",0)"

                Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
                cmdActualizar.ExecuteNonQuery()
                cmdActualizar.Dispose()

                i = i + 1
            Next
            ConSql.Close()

            'Dim f As String = FormatDateTime(Date.Now, DateFormat.ShortDate)
            'Dim c As Byte = 1
            'Dim p As String = Val(MetroComboBox3.Text.Trim)
            'Dim t As Byte = 0
            'Dim l As String = x2
            'Dim n As String = x3

            't = reser_tipo_comprobante

            'If l = "A" Then
            '    Call impresion_comprobante_a(p, t, l, n, f, c, 1)
            'Else
            '    If i <= 12 Then
            '        Call impresion_comprobante_b(p, t, l, n, f, c, 2)
            '    Else
            '        Call impresion_comprobante_b(p, t, l, n, f, c, 1)
            '    End If
            'End If


            ticket_ventas.Clear()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub


    Private Sub cargar_Array_Venta()
        Try

            Dim Aux1 As Double = 0
            Dim Aux2 As Double = 0
            Dim Aux3 As Double = 0

            Dim AuxPrecio As Double = 0
            Dim AuxSubtotal As Double = 0
            Dim AuxTotal As Double = 0
            Dim AuxCantidad As Double = 0
            Dim AuxImporteDsto As Double = 0
            Dim AuxDsto As Double = 0
            Dim AuxPrecioConDsto As Double = 0

            Dim AuxAlicuota As Double = 0

            Dim calc_aux1 As Double = 0
            Dim calc_aux2 As Double = 0

            ticket_ventas = New ArrayList

            Dim itemTicket As registro_ticket

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim Sql As String = ""
            Sql = "Select * from Tickets WHERE (TicketNro= " & reser_Ticket & ") "

            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                Do While drRecordSet.Read
                    With itemTicket
                        .Codigo = drRecordSet("Codigo").ToString
                        .Detalle = drRecordSet("Detalle").ToString
                        .Precio = Math.Round(Convert.ToDouble(drRecordSet("Precio").ToString), 2)
                        .Cantidad = Math.Round(Convert.ToDouble(drRecordSet("Cantidad").ToString), 2)
                        .SubTotal = Math.Round(Convert.ToDouble(drRecordSet("SubTotal").ToString), 2)
                        .Dsto = Math.Round(Convert.ToDouble(drRecordSet("Dsto").ToString), 2)
                        .PrecioConDsto = Math.Round(Convert.ToDouble(drRecordSet("PrecioConDsto").ToString), 2)
                        .Total = Math.Round(Convert.ToDouble(drRecordSet("Total").ToString), 2)

                        AuxAlicuota = Math.Round(Convert.ToDouble(drRecordSet("Alicuota").ToString), 2)

                        If Val(MetroTextBox26.Text.Trim) = 1 Or Val(MetroTextBox26.Text.Trim) = 4 Then
                            .AlicuotaFiscal = AuxAlicuota
                            .UnidadMedidaFiscal = "UNI"
                            .ObservacionFiscal = " "
                            .ListaFiscal = 1
                            .CodUnidadMedidaFiscal = 1
                            .Dsto = Math.Round(Convert.ToDouble(drRecordSet("Dsto").ToString), 2)
                            .Cantidad = Math.Round(Convert.ToDouble(drRecordSet("Cantidad").ToString), 2)


                            'Calculos
                            AuxDsto = Math.Round(Convert.ToDouble(drRecordSet("Dsto").ToString), 2)
                            AuxCantidad = Math.Round(Convert.ToDouble(drRecordSet("Cantidad").ToString), 2)
                            AuxTotal = Math.Round(Convert.ToDouble(drRecordSet("Total").ToString), 2)
                            calc_aux1 = Math.Round(AuxTotal / (1 + (AuxAlicuota / 100)), 2)

                            .Total = AuxTotal
                            .ImporteIvaFiscal = Math.Round(AuxTotal - calc_aux1, 2)
                            .ImporteBonifFiscal = calc_aux1
                            .SubTotalFiscal = AuxTotal

                            If AuxDsto <> 0 Then
                                AuxImporteDsto = Math.Round(calc_aux1 * 100 / AuxDsto, 2)
                            Else
                                AuxImporteDsto = calc_aux1
                            End If

                            calc_aux1 = Math.Round(AuxImporteDsto / AuxCantidad, 2)

                            .PrecioConDsto = calc_aux1

                            .PrecioConIva = calc_aux1
                            .PrecioFinal = calc_aux1
                            .PrecioFiscal = calc_aux1
                            .Precio = calc_aux1
                            .BonifFiscal = AuxDsto


                            Aux1 = Aux1 + AuxTotal

                        Else
                            .UnidadMedidaFiscal = "UNI"
                            .PrecioFiscal = Math.Round(Convert.ToDouble(drRecordSet("Precio").ToString), 2)
                            .BonifFiscal = Math.Round(Convert.ToDouble(drRecordSet("Dsto").ToString), 2)
                            .ImporteBonifFiscal = Math.Round(Convert.ToDouble(drRecordSet("Total").ToString), 2)
                            .AlicuotaFiscal = AuxAlicuota
                            .ImporteIvaFiscal = 0
                            .SubTotalFiscal = Math.Round(Convert.ToDouble(drRecordSet("Total").ToString), 2)
                            .ObservacionFiscal = " "
                            .ListaFiscal = 1
                            .CodUnidadMedidaFiscal = 1

                            Aux1 = Aux1 + Math.Round(Convert.ToDouble(drRecordSet("Total").ToString), 2)
                            Aux3 = Aux3 + Math.Round(Convert.ToDouble(drRecordSet("Total").ToString), 2)

                        End If
                    End With
                    ticket_ventas.Add(itemTicket)

                Loop
            End If

            drRecordSet.Close()

            'If Val(MetroTextBox26.Text.Trim) = 1 Or Val(MetroTextBox26.Text.Trim) = 4 Then
            '    reser_total = Math.Round(Aux1, 2)
            '    reser_neto = Math.Round(Aux1 / (1 + (alicuota_empleada / 100)), 2)
            '    reser_importe_iva = Math.Round(Aux1 - reser_neto, 2)
            'Else
            '    reser_neto = Aux1
            '    reser_importe_iva = 0
            '    reser_total = Aux3
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Sub grabarcaja(ByVal xTipo As Byte)
        Try

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")


            Dim x_v1 As String = ""
            Dim x_v2 As Byte = 0
            Dim x_v3 As String = ""
            Dim x_v4 As String = ""
            Dim x_v5 As Integer = 0
            Dim x_v6 As String = ""
            Dim x_v7 As Byte = 0
            Dim x_v9 As Double = 0
            Dim x_v10 As Double = 0
            Dim x_v11 As Byte = 0
            Dim x_v12 As Integer = 0

            x_v1 = FormatDateTime(Now.Date, DateFormat.ShortDate) '10/01/2009
            If reser_tipo_comprobante = 1 Then
                x_v2 = 1
                x_v7 = 1
            End If
            If reser_tipo_comprobante = 2 Then
                x_v2 = 2
                x_v7 = 1
            End If
            If reser_tipo_comprobante = 3 Then
                x_v2 = 3
                x_v7 = 2
            End If
            x_v3 = MetroTextBox25.Text.Trim.ToUpper
            x_v4 = Formatea_Numero_Comprobante(Val(MetroTextBox24.Text.Trim), Val(MetroTextBox23.Text.Trim))

            If MetroTextBox9.Text.Trim = "" Then
                x_v5 = 0
            Else
                x_v5 = Convert.ToDouble(MetroTextBox9.Text.Trim)
            End If

            If MetroTextBox10.Text.Trim <> "" Then
                x_v6 = MetroTextBox10.Text.Trim
            Else
                x_v6 = MetroTextBox8.Text.Trim
            End If

            x_v9 = Total_Comprobante
            x_v10 = 0
            x_v12 = xTipo

            Dim Sql As String = ""

            Sql = "Insert Into MovimientosDeCajas (Fecha,TipoComprobante,LetraComprobante,NumeroComprobante,"
            Sql = Sql & "Cliente,Detalle,DebCre,Sistema,Importe,Numero,Estado,Contado,CodigoMovim,"
            Sql = Sql & "FechaAlta,HoraAlta,UsuarioAlta) Values ('" & x_v1 & "'," & x_v2 & ",'" & x_v3 & "','" & x_v4 & "',"
            Sql = Sql & "" & x_v5 & ",'" & x_v6 & "'," & x_v7 & ",1," & x_v9 & "," & x_v10 & ",0," & x_v12 & ",1,"
            Sql = Sql & "'" & j2 & "','" & j3 & "'," & j1 & ")"

            Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
            Dim ConSql As New OleDbConnection(Conexion)
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            ConSql.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try
    End Sub

    Private Sub MostarTicket()
        If IsNothing(ticket_ventas) = False Then
            Debug.Print("----------")
            Dim i As Integer
            For Each itemTicket As registro_ticket In ticket_ventas
                i += 1
                Debug.Print(i & ":" & itemTicket.Codigo & " " & itemTicket.Detalle)
            Next
        Else
            Debug.Print("No hay personas en la lista")
        End If
    End Sub

    Private Sub ultimos_numero_de_comprobantes()
        Dim txt_ptovta As String = ""
        Dim txt_tipo As String = ""
        Dim cod_err As Byte = 0
        Dim msg_err As String = ""

        Dim txt_ultimo_num_comp As String = ""

        MetroTextBox27.Text = "FA"
        MetroTextBox31.Text = "ND"
        MetroTextBox35.Text = "NC"

        MetroTextBox39.Text = "FA"
        MetroTextBox43.Text = "ND"
        MetroTextBox47.Text = "NC"

        MetroTextBox30.Text = "A"
        MetroTextBox34.Text = "A"
        MetroTextBox38.Text = "A"

        MetroTextBox42.Text = "B"
        MetroTextBox46.Text = "B"
        MetroTextBox50.Text = "B"

        MetroTextBox29.Text = Formatea_Numero_Comprobante_4(Val(MetroComboBox3.Text.Trim))
        MetroTextBox33.Text = MetroTextBox29.Text
        MetroTextBox37.Text = MetroTextBox29.Text
        MetroTextBox41.Text = MetroTextBox29.Text
        MetroTextBox45.Text = MetroTextBox29.Text
        MetroTextBox49.Text = MetroTextBox29.Text

        MetroTextBox28.Text = "00000000"
        MetroTextBox32.Text = "00000000"
        MetroTextBox36.Text = "00000000"
        MetroTextBox40.Text = "00000000"
        MetroTextBox44.Text = "00000000"
        MetroTextBox48.Text = "00000000"

        txt_ptovta = MetroComboBox3.Text.Trim
        txt_tipo = "01"
        cod_err = 0
        msg_err = ""

        txt_ultimo_num_comp = ""
        txt_ultimo_num_comp = consulta_ultimo_comprobante_afip(txt_ptovta, txt_tipo, cod_err, msg_err)

        If cod_err <> 0 Or txt_ultimo_num_comp.Trim = "" Or msg_err.Trim <> "" Then
            Exit Sub
        End If
        MetroTextBox28.Text = Formatea_Numero_Comprobante_8(Val(txt_ultimo_num_comp) + 1)

        txt_tipo = "02"
        cod_err = 0
        msg_err = ""
        txt_ultimo_num_comp = ""
        txt_ultimo_num_comp = consulta_ultimo_comprobante_afip(txt_ptovta, txt_tipo, cod_err, msg_err)

        If cod_err <> 0 Or txt_ultimo_num_comp.Trim = "" Or msg_err.Trim <> "" Then
            Exit Sub
        End If
        MetroTextBox32.Text = Formatea_Numero_Comprobante_8(Val(txt_ultimo_num_comp) + 1)

        txt_tipo = "03"
        cod_err = 0
        msg_err = ""
        txt_ultimo_num_comp = ""
        txt_ultimo_num_comp = consulta_ultimo_comprobante_afip(txt_ptovta, txt_tipo, cod_err, msg_err)

        If cod_err <> 0 Or txt_ultimo_num_comp.Trim = "" Or msg_err.Trim <> "" Then
            Exit Sub
        End If
        MetroTextBox36.Text = Formatea_Numero_Comprobante_8(Val(txt_ultimo_num_comp) + 1)

        txt_tipo = "06"
        cod_err = 0
        msg_err = ""
        txt_ultimo_num_comp = ""
        txt_ultimo_num_comp = consulta_ultimo_comprobante_afip(txt_ptovta, txt_tipo, cod_err, msg_err)

        If cod_err <> 0 Or txt_ultimo_num_comp.Trim = "" Or msg_err.Trim <> "" Then
            Exit Sub
        End If
        MetroTextBox40.Text = Formatea_Numero_Comprobante_8(Val(txt_ultimo_num_comp) + 1)

        txt_tipo = "07"
        cod_err = 0
        msg_err = ""
        txt_ultimo_num_comp = ""
        txt_ultimo_num_comp = consulta_ultimo_comprobante_afip(txt_ptovta, txt_tipo, cod_err, msg_err)

        If cod_err <> 0 Or txt_ultimo_num_comp.Trim = "" Or msg_err.Trim <> "" Then
            Exit Sub
        End If
        MetroTextBox44.Text = Formatea_Numero_Comprobante_8(Val(txt_ultimo_num_comp) + 1)

        txt_tipo = "08"
        cod_err = 0
        msg_err = ""
        txt_ultimo_num_comp = ""
        txt_ultimo_num_comp = consulta_ultimo_comprobante_afip(txt_ptovta, txt_tipo, cod_err, msg_err)

        If cod_err <> 0 Or txt_ultimo_num_comp.Trim = "" Or msg_err.Trim <> "" Then
            Exit Sub
        End If
        MetroTextBox48.Text = Formatea_Numero_Comprobante_8(Val(txt_ultimo_num_comp) + 1)

    End Sub
    Private Function Formatea_Numero_Comprobante_4(ByVal x As Integer) As String
        Dim c As String = ""

        Dim xNumero As String

        xNumero = x
        xNumero = xNumero.PadLeft(4)
        xNumero = xNumero.Replace(" ", "0")

        c = xNumero.ToString

        Formatea_Numero_Comprobante_4 = c
    End Function
    Private Function Formatea_Numero_Comprobante_8(ByVal x As Double) As String
        Dim c As String = ""
        Dim xNumero As String
        xNumero = x
        xNumero = xNumero.PadLeft(8)
        xNumero = xNumero.Replace(" ", "0")

        c = xNumero.ToString

        Formatea_Numero_Comprobante_8 = c
    End Function

    Private Function duplicacion_de_comprobante() As Boolean
        Dim r As Boolean = False

        Try
            Dim importeVenta As Double = CDbl(MetroTextBox20.Text)

            Dim xFecha As String = ""
            xFecha = FormatDateTime(Date.Now, DateFormat.ShortDate)
            xFecha = String.Format("{0:yyyyMMdd}", Convert.ToDateTime(xFecha))

            Dim insSql As String = "Select * from Iva_Ventas Where (FechaImputacion = '" & xFecha & "') And (Total= " & importeVenta & ") "

            Dim cmdRecordSet2 As New OleDbCommand(insSql, ConSql)
            Dim drRecordSet2 As OleDbDataReader = cmdRecordSet2.ExecuteReader
            If drRecordSet2.HasRows Then 'Tiene filas
                If drRecordSet2.Read Then
                    r = True
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            duplicacion_de_comprobante = r
        End Try
    End Function

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        reser_tipo_respo = Val(MetroTextBox26.Text)
        Dim Formulario_open As New Form400(reser_tipo_respo)
        Formulario_open.ShowDialog()
    End Sub

    Private Sub enviar_comprobante_mail()
        Try
            Dim archivo_pdf As String = My.Computer.FileSystem.CurrentDirectory.Trim
            Dim nom_file As String = ""

            If MetroTextBox10.Text.Trim <> "" Then
                nom_file = MetroTextBox10.Text.Trim
            End If
            If nom_file.Trim = "" Then
                nom_file = MetroTextBox8.Text.Trim
            End If
            If nom_file.Trim = "" Then
                nom_file = "COMPROBANTE"
            End If

            archivo_pdf = archivo_pdf & "\Pdf\" & nom_file & "_" & DateTime.Now.ToString("T").ToString.Replace(":", "") & ".pdf"
            If File.Exists(archivo_pdf) Then
                File.Delete(archivo_pdf)
            End If

            Dim f As String = FormatDateTime(Date.Now, DateFormat.ShortDate)
            Dim c As Byte = 1
            Dim p As String = Val(MetroComboBox3.Text.Trim)
            Dim t As Byte = 0
            Dim l As String = reser_letra_compro
            Dim n As String = reser_numero_compro

            t = reser_tipo_comprobante

            If l = "A" Then
                Call impresion_comprobante_a(p, t, l, n, f, c, 3, archivo_pdf)
            Else
                Call impresion_comprobante_b(p, t, l, n, f, c, 3, archivo_pdf)
            End If

            e_mail = MetroTextBox21.Text.Trim
            e_Asunto = "Adjuntamos comprobante de referencia"
            e_Texto = "Este en un correo automático, no intente comunicarse o reponder a esta dirección de correo electrónico. Atte "
            e_File = archivo_pdf

            id_Reg_log = 0
            Call log_mail_enviados(e_mail, e_Asunto, e_Texto, e_File, id_Reg_log)
            Call enviar_mail(e_mail, e_Asunto, e_Texto, e_File, " ", id_Reg_log)
            Call actualizar_mail_enviado(id_Reg_log)

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub MetroTextBox15_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox15.Validated
        If MetroTextBox9.Text.Trim = "" Then
            If MetroTextBox15.Text.Trim <> "11111111" And MetroTextBox15.Text.Trim <> "" Then
                Call buscar_mail_cliente_generico(Val(MetroTextBox15.Text.Trim))
            End If
        End If
    End Sub
    Private Sub buscar_mail_cliente_generico(ByVal xNumero As Long)
        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim cmdTemp As New OleDbCommand("Select * from Clientes_Mostrador_Mail WHERE Numero = " & xNumero & " ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    MetroTextBox21.Text = drTemp("Mail").ToString()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If MetroTextBox21.Text.Trim <> "" Then
            Dim x_ValidaMail = validacion_mail(MetroTextBox21.Text.Trim)
            If x_ValidaMail <> 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "El mail especificado es incorrecto !!!!.", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        If MetroTextBox9.Text.Trim <> "" Then
            actualiza_mail_cliente(Val(MetroTextBox9.Text.Trim), 1, MetroTextBox21.Text.Trim, " ")
        Else
            If MetroTextBox15.Text.Trim <> "11111111" And MetroTextBox15.Text.Trim <> "" Then
                actualiza_mail_cliente(Val(MetroTextBox15.Text.Trim), 2, MetroTextBox21.Text.Trim, MetroTextBox8.Text.Trim)
            End If
        End If
    End Sub
    Private Sub actualiza_mail_cliente(ByVal xNumero As Long, ByVal Tipo As Byte, ByVal xMail As String, ByVal xNombre As String)
        If ConSql.State = ConnectionState.Closed Then
            ConSql.Open()
        End If

        Dim Sql As String = ""
        If Tipo = 1 Then
            Sql = "Update Clientes SET eMail='" & xMail & "' WHERE Numero= " & xNumero & ""
        End If
        If Tipo = 2 Then
            If existe_mail_cliente_generico(xNumero) = True Then
                Sql = "Update Clientes_Mostrador_Mail SET Mail='" & xMail & "',Nombre= '" & xNombre & "' WHERE Numero= " & xNumero & ""
            Else
                Sql = "Insert Into Clientes_Mostrador_Mail (Numero,Mail,Nombre) Values (" & xNumero & ",'" & xMail & "','" & xNombre & "' )"
            End If
        End If

        Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
        cmdActualizar.ExecuteNonQuery()
        cmdActualizar.Dispose()
    End Sub

    Private Function existe_mail_cliente_generico(ByVal xNumero As Long) As Boolean
        Dim r As Boolean = False
        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim cmdTemp As New OleDbCommand("Select * from Clientes_Mostrador_Mail WHERE Numero = " & xNumero & " ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    r = True
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
        Finally
            existe_mail_cliente_generico = r
        End Try
    End Function
End Class

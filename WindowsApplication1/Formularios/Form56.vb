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


Public Class Form56
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

#Region "ControlText"

    Private Sub MetroTextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MetroTextBox1.KeyDown
        If e.KeyCode = Keys.F2 Then
            MetroTextBox1.Text = "999999"
            MetroTextBox2.Text = "CONSUMIDOR FINAL"
            MetroTextBox3.Text = ""
            MetroTextBox26.Text = "2"
            MetroTextBox4.Text = "CONSUMIDOR FINAL"
            MetroTextBox10.Text = "B"
            MetroTextBox13.Text = "21.00"
            MetroTextBox9.Text = ""

            Exit Sub
        End If

        If e.KeyCode <> Keys.F1 Then
            Exit Sub
        End If


        rsv_Io = 1
        rsv_Seleccion = ""
        Dim Formulario_open As New Form12
        Formulario_open.ShowDialog()

        If rsv_Seleccion.Trim <> "" Then
            MetroTextBox1.Text = rsv_Seleccion
            MetroTextBox1.Focus()
        End If

    End Sub
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

  


    Private Sub metroTextBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox10.KeyPress
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
    Private Sub metroTextBox12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox12.KeyPress
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
    Private Sub metroTextBox13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox13.KeyPress
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
    Private Sub metroTextBox16_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox16.KeyPress
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
    Private Sub metroTextBox19_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox19.KeyPress
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
    Private Sub metroTextBox20_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox20.KeyPress
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
    Private Sub metroTextBox23_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox23.KeyPress
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
    Private Sub metroTextBox24_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox24.KeyPress
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

#End Region
    Private Sub Form56_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        inicializa_form()
    End Sub
    Private Sub inicializa_form()

        MetroDateTime1.Value = Now.Date
        MetroDateTime2.Value = Now.Date

        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox4.Text = ""
     
        MetroTextBox9.Text = ""
        MetroTextBox10.Text = ""
        MetroTextBox11.Text = ""
        MetroTextBox26.Text = ""

        MetroTextBox12.Text = "0.00"
        MetroTextBox13.Text = "0.00"
        MetroTextBox14.Text = "0.00"
        MetroTextBox15.Text = "0.00"
        MetroTextBox16.Text = "0.00"
        MetroTextBox17.Text = "0.00"
        MetroTextBox18.Text = "0.00"
        MetroTextBox19.Text = "0.00"
        MetroTextBox20.Text = "0.00"
        MetroTextBox21.Text = "0.00"
        MetroTextBox22.Text = "0.00"
        MetroTextBox23.Text = "0.00"
        MetroTextBox24.Text = "0.00"
        MetroTextBox25.Text = "0.00"

        MetroRadioButton1.Checked = True

    End Sub



    Private Sub MetroTextBox11_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox11.Validated
        Dim xNumeroDe4 As String
        Dim xNumeroDe8 As String

        If MetroTextBox9.Text.Trim = "" Then
            MetroTextBox9.Text = "0000"
        End If
        If MetroTextBox11.Text.Trim = "" Then
            MetroTextBox11.Text = "00000000"
        End If


        xNumeroDe4 = Val(MetroTextBox9.Text.Trim)
        xNumeroDe4 = xNumeroDe4.PadLeft(4)
        xNumeroDe4 = xNumeroDe4.Replace(" ", "0")


        xNumeroDe8 = Val(MetroTextBox11.Text.Trim)
        xNumeroDe8 = xNumeroDe8.PadLeft(8)
        xNumeroDe8 = xNumeroDe8.Replace(" ", "0")

        MetroTextBox9.Text = xNumeroDe4
        MetroTextBox11.Text = xNumeroDe8


    End Sub



    Private Sub MetroTextBox13_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox13.Validated
        Dim aux As Double = 0
        MetroTextBox13.Text = CDbl(MetroTextBox13.Text.Trim)
        aux = CDbl(MetroTextBox13.Text.Trim)
        If aux <> 2.5 And aux <> 10.5 And aux <> 21 And aux <> 27 Then
            MetroFramework.MetroMessageBox.Show(Me, "Tasa de alícuota debe ser 2.5/10.5/21/27", rsv_modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            MetroTextBox13.Text = "21.00"
            Exit Sub
        End If

    End Sub

    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        inicializa_form()
    End Sub
    Private Sub MetroTextBox19_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox19.Validated
        If MetroTextBox19.Text.Trim = "" Then
            MetroTextBox19.Text = "0.00"
        End If
        MetroTextBox19.Text = CDbl(MetroTextBox19.Text)
        MetroTextBox19.Text = FormatNumber(CDbl(MetroTextBox19.Text), 2)
        parcialComprobante()
    End Sub
    Private Sub MetroTextBox20_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox20.Validated
        If MetroTextBox20.Text.Trim = "" Then
            MetroTextBox20.Text = "0.00"
        End If
        MetroTextBox20.Text = CDbl(MetroTextBox20.Text)
        MetroTextBox20.Text = FormatNumber(CDbl(MetroTextBox20.Text), 2)
        parcialComprobante()
    End Sub
    Private Sub MetroTextBox21_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox21.Validated
        If MetroTextBox21.Text.Trim = "" Then
            MetroTextBox21.Text = "0.00"
        End If
        MetroTextBox21.Text = CDbl(MetroTextBox21.Text)
        MetroTextBox21.Text = FormatNumber(CDbl(MetroTextBox21.Text), 2)
        parcialComprobante()
    End Sub
    Private Sub MetroTextBox22_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox22.Validated
        If MetroTextBox22.Text.Trim = "" Then
            MetroTextBox22.Text = "0.00"
        End If
        MetroTextBox22.Text = CDbl(MetroTextBox22.Text)
        MetroTextBox22.Text = FormatNumber(CDbl(MetroTextBox22.Text), 2)
        parcialComprobante()
    End Sub
    Private Sub parcialComprobante()
        If MetroTextBox14.Text.Trim = "" Then
            MetroTextBox14.Text = "0.00"
        End If
        If MetroTextBox15.Text.Trim = "" Then
            MetroTextBox15.Text = "0.00"
        End If
        If MetroTextBox16.Text.Trim = "" Then
            MetroTextBox16.Text = "0.00"
        End If
        If MetroTextBox17.Text.Trim = "" Then
            MetroTextBox17.Text = "0.00"
        End If
        If MetroTextBox18.Text.Trim = "" Then
            MetroTextBox18.Text = "0.00"
        End If
        If MetroTextBox23.Text.Trim = "" Then
            MetroTextBox23.Text = "0.00"
        End If
        If MetroTextBox24.Text.Trim = "" Then
            MetroTextBox24.Text = "0.00"
        End If


        If MetroTextBox19.Text.Trim = "" Then
            MetroTextBox19.Text = "0.00"
        End If
        If MetroTextBox20.Text.Trim = "" Then
            MetroTextBox20.Text = "0.00"
        End If
        If MetroTextBox21.Text.Trim = "" Then
            MetroTextBox21.Text = "0.00"
        End If
        If MetroTextBox22.Text.Trim = "" Then
            MetroTextBox22.Text = "0.00"
        End If


        Dim mTotalIva As Double
        mTotalIva = CDbl(MetroTextBox19.Text) + CDbl(MetroTextBox20.Text) + CDbl(MetroTextBox21.Text) + CDbl(MetroTextBox22.Text)


        MetroTextBox23.Text = mTotalIva
        MetroTextBox24.Text = mTotalIva

        MetroTextBox25.Text = CDbl(MetroTextBox14.Text) + CDbl(MetroTextBox15.Text) + CDbl(MetroTextBox16.Text) + CDbl(MetroTextBox17.Text) + _
                         CDbl(MetroTextBox18.Text) + mTotalIva
        MetroTextBox25.Text = FormatNumber(CDbl(MetroTextBox25.Text), 2)


        MetroTextBox23.Text = FormatNumber(CDbl(MetroTextBox23.Text), 2)
        MetroTextBox24.Text = FormatNumber(CDbl(MetroTextBox23.Text), 2)


    End Sub
    Private Function comprobanteExistenteIva(ByVal xfecha As Date, ByVal xCuit As Double, ByVal xCliente As Double, ByVal xLetra As String, ByVal xNumero As String) As Boolean
        Dim Retorno_funcion As Boolean
        Retorno_funcion = False

        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim xFecha2 As String
            xFecha2 = FormatDateTime(xfecha, DateFormat.ShortDate) '10/01/2009
            xFecha2 = String.Format("{0:yyyyMMdd}", Convert.ToDateTime(xFecha2))

            Dim cmdTemp As New OleDbCommand("Select * from Iva_Compras Where Fecha = '" & xFecha2 & "' And Cliente= " & xCliente & " And Cuit= " & xCuit & " And Letra = '" & xLetra & "' And NumeroDeComprobante = '" & xNumero & "'  And Estado = 0", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    Retorno_funcion = True
                End If
            End If
            drTemp.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
            ConSql.Close()
        Finally
            comprobanteExistenteIva = Retorno_funcion
        End Try
    End Function

    Private Sub validar_cliente()
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox26.Text = ""
        MetroTextBox4.Text = ""

        If MetroTextBox1.Text.Trim = "" Then
            Exit Sub
        End If

        Dim x1 As Double
        Dim x2 As String
        Dim x3 As Double
        Dim x4 As Byte

        x1 = CDbl(MetroTextBox1.Text.Trim)
        x2 = " "
        x3 = 0
        x4 = 0
        Call retornaCliente(x1, x2, x4, x3)
        If x4 <> 0 Then
            MetroTextBox2.Text = x2
            MetroTextBox3.Text = x3
            MetroTextBox26.Text = x4
            If x4 = 1 Then
                MetroTextBox10.Text = "A"
            Else
                MetroTextBox10.Text = "C"
            End If
        End If

    End Sub
    Private Sub retornaCliente(ByVal xCliente As Double, ByRef xDetalle As String, ByRef xTipoResponsable As Byte, ByRef xCuit As Double)
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim x1_Detalle As String
        Dim x1_Cuit As Double
        Dim x1_TipoResponsable As Byte
        x1_Detalle = " "
        x1_Cuit = 0
        x1_TipoResponsable = 0
        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdTemp As New OleDbCommand("Select * from Clientes where Numero= " & xCliente & " ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    x1_Detalle = drTemp("RazonSocial").ToString()
                    x1_Cuit = drTemp("Cuit").ToString()
                    x1_TipoResponsable = drTemp("Responsable").ToString()
                End If
            End If
            xDetalle = x1_Detalle
            xCuit = x1_Cuit
            xTipoResponsable = x1_TipoResponsable
            drTemp.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
            ConSql.Close()
        End Try
    End Sub



    Private Sub MetroTextBox10_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox10.Validated
        MetroTextBox10.Text = MetroTextBox10.Text.Trim.ToUpper
    End Sub



    Private Sub MetroTextBox14_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox14.Validated
        If MetroTextBox14.Text.Trim = "" Then
            MetroTextBox14.Text = "0.00"
        End If
        MetroTextBox14.Text = FormatNumber(CDbl(MetroTextBox14.Text), 2)

        MetroTextBox19.Text = "0.00"
        MetroTextBox20.Text = "0.00"
        MetroTextBox21.Text = "0.00"
        MetroTextBox22.Text = "0.00"

        If CDbl(MetroTextBox13.Text) = 2.5 Then
            MetroTextBox19.Text = Math.Round(CDbl(MetroTextBox14.Text) * 2.5 / 100, 2)
            MetroTextBox19.Text = FormatNumber(CDbl(MetroTextBox19.Text), 2)
        End If


        If CDbl(MetroTextBox13.Text) = 10.5 Then
            MetroTextBox20.Text = Math.Round(CDbl(MetroTextBox14.Text) * 10.5 / 100, 2)
            MetroTextBox20.Text = FormatNumber(CDbl(MetroTextBox20.Text), 2)
        End If

        If CDbl(MetroTextBox13.Text) = 21 Then
            MetroTextBox21.Text = Math.Round(CDbl(MetroTextBox14.Text) * 21 / 100, 2)
            MetroTextBox21.Text = FormatNumber(CDbl(MetroTextBox21.Text), 2)
        End If

        If CDbl(MetroTextBox13.Text) = 27 Then
            MetroTextBox22.Text = Math.Round(CDbl(MetroTextBox14.Text) * 27 / 100, 2)
            MetroTextBox22.Text = FormatNumber(CDbl(MetroTextBox22.Text), 2)
        End If


        MetroTextBox23.Text = CDbl(MetroTextBox19.Text) + CDbl(MetroTextBox20.Text) + CDbl(MetroTextBox21.Text) + CDbl(MetroTextBox22.Text)
        MetroTextBox23.Text = FormatNumber(CDbl(MetroTextBox23.Text), 2)
        MetroTextBox24.Text = FormatNumber(CDbl(MetroTextBox23.Text), 2)

        parcialComprobante()


    End Sub

   
    Private Sub MetroTextBox15_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox15.Validated
        If MetroTextBox15.Text.Trim = "" Then
            MetroTextBox15.Text = "0.00"
        End If
        MetroTextBox15.Text = FormatNumber(CDbl(MetroTextBox15.Text), 2)
        parcialComprobante()
    End Sub

    Private Sub MetroTextBox16_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox16.Validated
        If MetroTextBox16.Text.Trim = "" Then
            MetroTextBox16.Text = "0.00"
        End If
        MetroTextBox16.Text = FormatNumber(CDbl(MetroTextBox16.Text), 2)
        parcialComprobante()
    End Sub
    Private Sub MetroTextBox17_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox17.Validated
        If MetroTextBox17.Text.Trim = "" Then
            MetroTextBox17.Text = "0.00"
        End If
        MetroTextBox17.Text = FormatNumber(CDbl(MetroTextBox17.Text), 2)
        parcialComprobante()
    End Sub
    Private Sub MetroTextBox18_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox18.Validated
        If MetroTextBox18.Text.Trim = "" Then
            MetroTextBox18.Text = "0.00"
        End If
        MetroTextBox18.Text = FormatNumber(CDbl(MetroTextBox18.Text), 2)
        parcialComprobante()
    End Sub

    Private Sub MetroTextBox24_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox24.Validated
        If MetroTextBox24.Text.Trim = "" Then
            MetroTextBox24.Text = "0.00"
        End If
        MetroTextBox24.Text = FormatNumber(CDbl(MetroTextBox24.Text), 2)
        parcialComprobante()
    End Sub



    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        Call grabar_comprobante(True)
    End Sub

    Private Sub grabar_comprobante(ByVal xContado As Boolean)
        Dim ok As Boolean
        ok = True
        If MetroTextBox14.Text.Trim = "" Then
            MetroTextBox14.Text = "0.00"
        End If
        If MetroTextBox15.Text.Trim = "" Then
            MetroTextBox15.Text = "0.00"
        End If
        If MetroTextBox16.Text.Trim = "" Then
            MetroTextBox16.Text = "0.00"
        End If
        If MetroTextBox17.Text.Trim = "" Then
            MetroTextBox17.Text = "0.00"
        End If
        If MetroTextBox18.Text.Trim = "" Then
            MetroTextBox18.Text = "0.00"
        End If
        If MetroTextBox19.Text.Trim = "" Then
            MetroTextBox19.Text = "0.00"
        End If
        If MetroTextBox20.Text.Trim = "" Then
            MetroTextBox20.Text = "0.00"
        End If
        If MetroTextBox21.Text.Trim = "" Then
            MetroTextBox21.Text = "0.00"
        End If
        If MetroTextBox22.Text.Trim = "" Then
            MetroTextBox22.Text = "0.00"
        End If
        If MetroTextBox23.Text.Trim = "" Then
            MetroTextBox23.Text = "0.00"
        End If
        If MetroTextBox24.Text.Trim = "" Then
            MetroTextBox24.Text = "0.00"
        End If
        If MetroTextBox25.Text.Trim = "" Then
            MetroTextBox25.Text = "0.00"
        End If

        If xContado = False Then
            If MetroTextBox1.Text.Trim = "999999" Then
                MetroFramework.MetroMessageBox.Show(Me, "Contado. No es un movimiento de Cuenta Corriente", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        If CDbl(MetroTextBox25.Text.Trim) <> 0 Then
            If MetroTextBox12.Text.Trim = "" And ok = True Then
                MetroFramework.MetroMessageBox.Show(Me, "Importe Testigo Inválido", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ok = False
            End If
            If CDbl(MetroTextBox12.Text.Trim) = 0 And ok = True Then
                MetroFramework.MetroMessageBox.Show(Me, "Importe Testigo Inválido", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ok = False
            End If
        End If

        If MetroTextBox26.Text.Trim = "" And ok = True Then
            MetroFramework.MetroMessageBox.Show(Me, "Código de Responsable Inválido", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ok = False
        End If
        If MetroTextBox1.Text.Trim = "" Or MetroTextBox2.Text.Trim = "" And ok = True Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar Cliente para imputar comprobante", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ok = False
        End If
        If MetroTextBox10.Text.Trim = "" And ok = True Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar letra de comprobante. A o B", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ok = False
        End If
        If MetroTextBox11.Text.Trim = "" And ok = True Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar número de comprobante", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ok = False
        End If
        If MetroTextBox10.Text.Trim.ToUpper <> "A" And MetroTextBox10.Text.Trim.ToUpper <> "B" And ok = True Then
            MetroFramework.MetroMessageBox.Show(Me, "Letra de Comprobante Inválido para comprobante", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ok = False
        End If

        If ok = False Then
            Exit Sub
        End If

        Dim suma1 As Double

        suma1 = Math.Round(CDbl(MetroTextBox14.Text) + CDbl(MetroTextBox15.Text) + CDbl(MetroTextBox16.Text) + CDbl(MetroTextBox17.Text) + CDbl(MetroTextBox18.Text) + CDbl(MetroTextBox23.Text), 2)


        suma1 = Math.Round(CDbl(MetroTextBox19.Text) + CDbl(MetroTextBox20.Text) + CDbl(MetroTextBox21.Text) + CDbl(MetroTextBox22.Text), 2)

        If suma1 <> Math.Round(CDbl(MetroTextBox23.Text), 2) Then
            MetroFramework.MetroMessageBox.Show(Me, "Existe diferencia en el total de Iva y sumas parciales de Iva", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If suma1 <> Math.Round(CDbl(MetroTextBox24.Text), 2) Then
            MetroFramework.MetroMessageBox.Show(Me, "Existe diferencia en el total de Iva y sumas parciales de Iva", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        Call imputarIva()

        If xContado = False Then
            guardar_cuenta_corriente()
        End If

        nuevo_comprobante()

    End Sub
    Private Sub imputarIva()
        Try
            Dim sql As String = " "
            Dim xTipo As String = " "
            Dim xCuit As Double = 0
            Dim xCliente As Double = 0
            Dim xNombre As String = " "
         
            Dim x1 As Double
            Dim x2 As Double
            Dim x3 As Double
            Dim x4 As Double
            Dim x5 As Double
            Dim x6 As Double
            Dim x7 As Double
            Dim x8 As Double

            Dim x32 As Double
            Dim x33 As Double
            Dim x34 As Double

            Dim x35 As Double
            Dim x36 As Double
            Dim x37 As Double


            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")


            Dim a1 As String = ""
            a1 = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate) '10/01/2009
            Dim a2 As String = ""
            a2 = FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate) '10/01/2009

            xTipo = ""
            If MetroRadioButton1.Checked = True Then
                xTipo = "FA"
            End If
            If MetroRadioButton2.Checked = True Then
                xTipo = "ND"
            End If
            If MetroRadioButton3.Checked = True Then
                xTipo = "NC"
            End If

            Dim A9 As Integer = 0
            A9 = Val(MetroTextBox26.Text.Trim)
            Dim a7 As String = ""
            a7 = MetroTextBox10.Text.Trim
            Dim a8 As String = ""

            Dim xNumeroDe4 As String
            Dim xNumeroDe8 As String

            xNumeroDe4 = Val(MetroTextBox9.Text.Trim)
            xNumeroDe4 = xNumeroDe4.PadLeft(4)
            xNumeroDe4 = xNumeroDe4.Replace(" ", "0")

            xNumeroDe8 = Val(MetroTextBox11.Text.Trim)
            xNumeroDe8 = xNumeroDe8.PadLeft(8)
            xNumeroDe8 = xNumeroDe8.Replace(" ", "0")

            a8 = xNumeroDe4 & "-" & xNumeroDe8


            If MetroTextBox3.Text.Trim <> "" Then
                xCuit = CDbl(MetroTextBox3.Text.Trim)
            End If


            If MetroTextBox1.Text.Trim <> "" Then
                xCliente = CDbl(MetroTextBox1.Text.Trim)
            End If


            xCliente = CDbl(MetroTextBox1.Text.Trim)
            xNombre = MetroTextBox2.Text.Trim
            xNombre = Strings.Replace(xNombre, "'", " ")
            xNombre = Strings.Left(xNombre, 50)


            x1 = Math.Round(CDbl(MetroTextBox14.Text.Trim), 2)
            x2 = Math.Round(CDbl(MetroTextBox15.Text.Trim), 2) + Math.Round(CDbl(MetroTextBox17.Text.Trim), 2)

            x3 = Math.Round(CDbl(MetroTextBox16.Text.Trim), 2)
            x4 = 0
            x5 = Math.Round(CDbl(MetroTextBox18.Text.Trim), 2)
            x6 = Math.Round(CDbl(MetroTextBox23.Text.Trim), 2)
            x7 = Math.Round(CDbl(MetroTextBox24.Text.Trim), 2)
            x8 = Math.Round(CDbl(MetroTextBox25.Text.Trim), 2)

            x37 = Math.Round(CDbl(MetroTextBox19.Text.Trim), 2)
            x32 = Math.Round(CDbl(MetroTextBox20.Text.Trim), 2)
            x33 = Math.Round(CDbl(MetroTextBox21.Text.Trim), 2)
            x34 = Math.Round(CDbl(MetroTextBox22.Text.Trim), 2)

           

            'If MetroTextBox10.Text.Trim = "C" Then
            '    x1 = 0
            '    x2 = Math.Round(CDbl(MetroTextBox17.Text.Trim), 2)
            '    x3 = 0
            '    x4 = 0
            '    x5 = 0
            '    x6 = 0
            '    x7 = 0
            '    x8 = Math.Round(CDbl(MetroTextBox17.Text.Trim), 2)

            '    x32 = 0
            '    x33 = 0
            '    x34 = 0

            'End If


            x35 = 21
            x36 = 10.5

            If CDbl(MetroTextBox13.Text) = 2.5 Then
                x35 = 2.5
                x36 = 1.25
            End If

            If CDbl(MetroTextBox13.Text) = 10.5 Then
                x35 = 10.5
                x36 = 5.25
            End If
            If CDbl(MetroTextBox13.Text) = 21 Then
                x35 = 21
                x36 = 10.5
            End If
            If CDbl(MetroTextBox13.Text) = 27 Then
                x35 = 27
                x36 = 13.5
            End If



            sql = ""
            sql = "Insert Into Iva_Ventas (Fecha,FechaImputacion,TipoComprobante,"
            sql = sql & "TipoResponsable,Cuit,LetraComprobante,NumeroComprobante,"
            sql = sql & "Cliente,Nombre,NetoGravado,ConceptosNoGravados,"
            sql = sql & "Exento,Total,Retenciones,"
            sql = sql & "UsuarioAlta,FechaAlta,HoraAlta,Estado,"
            sql = sql & "Iva25,Iva105,Iva21,Iva27) Values ("
            sql = sql & "'" & a1 & "','" & a2 & "','" & xTipo & "',"
            sql = sql & "" & A9 & "," & xCuit & ",'" & a7 & "','" & a8 & "',"
            sql = sql & "" & xCliente & ",'" & xNombre & "'," & x1 & "," & x2 & ","
            sql = sql & "" & x3 & "," & x8 & "," & x5 & ","
            sql = sql & "" & j1 & ",'" & j2 & "','" & j3 & "',0, "
            sql = sql & "" & x37 & "," & x32 & "," & x33 & "," & x34 & ")"

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdActualizar As New OleDbCommand(sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try


    End Sub
    Private Sub nuevo_comprobante()
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox4.Text = ""
      
        MetroTextBox9.Text = ""
        MetroTextBox10.Text = ""
        MetroTextBox11.Text = ""
        MetroTextBox26.Text = ""

        MetroTextBox12.Text = "0.00"
        MetroTextBox13.Text = "0.00"
        MetroTextBox14.Text = "0.00"
        MetroTextBox15.Text = "0.00"
        MetroTextBox16.Text = "0.00"
        MetroTextBox17.Text = "0.00"
        MetroTextBox18.Text = "0.00"
        MetroTextBox19.Text = "0.00"
        MetroTextBox20.Text = "0.00"
        MetroTextBox21.Text = "0.00"
        MetroTextBox22.Text = "0.00"
        MetroTextBox23.Text = "0.00"
        MetroTextBox24.Text = "0.00"
        MetroTextBox25.Text = "0.00"

        MetroDateTime1.Focus()

    End Sub



    Private Sub MetroTextBox26_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox26.Validated
        MetroTextBox4.Text = ""
        Select Case MetroTextBox26.Text.Trim
            Case Is = "1"
                MetroTextBox4.Text = "RESPONSABLE INSCRIPTO"
            Case Is = "2"
                MetroTextBox4.Text = "CONSUMIDOR FINAL"
            Case Is = "3"
                MetroTextBox4.Text = "EXENTO"
            Case Is = "4"
                MetroTextBox4.Text = "MONOTRIBUTO"
        End Select
    End Sub


    Private Sub MetroTextBox1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox1.Validated
        If MetroTextBox1.Text.Trim = "999999" Then
            MetroTextBox11.Focus()
            Exit Sub
        End If


        validar_cliente()
    End Sub

    Private Sub MetroTextBox23_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox23.Validated
        If MetroTextBox23.Text.Trim = "" Then
            MetroTextBox23.Text = "0.00"
        End If
        MetroTextBox23.Text = FormatNumber(CDbl(MetroTextBox23.Text), 2)
        parcialComprobante()
    End Sub

    Private Sub MetroTextBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTextBox9.Click

    End Sub

    Private Sub MetroTextBox9_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox9.Validated
        Dim xNumeroDe4 As String
        Dim xNumeroDe8 As String

        If MetroTextBox9.Text.Trim = "" Then
            MetroTextBox9.Text = "0000"
        End If
        If MetroTextBox11.Text.Trim = "" Then
            MetroTextBox11.Text = "00000000"
        End If

        xNumeroDe4 = Val(MetroTextBox9.Text.Trim)
        xNumeroDe4 = xNumeroDe4.PadLeft(4)
        xNumeroDe4 = xNumeroDe4.Replace(" ", "0")


        xNumeroDe8 = Val(MetroTextBox11.Text.Trim)
        xNumeroDe8 = xNumeroDe8.PadLeft(8)
        xNumeroDe8 = xNumeroDe8.Replace(" ", "0")

        MetroTextBox9.Text = xNumeroDe4
        MetroTextBox11.Text = xNumeroDe8

    End Sub



    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        Call grabar_comprobante(False)
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

            x1 = CDbl(MetroTextBox1.Text.Trim)
            x2 = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate) '10/01/2009
            x3 = FormatDateTime(MetroDateTime2.Text, DateFormat.ShortDate) '10/01/2009

            Dim xNumeroDe4 As String
            Dim xNumeroDe8 As String

            xNumeroDe4 = Val(MetroTextBox9.Text.Trim)
            xNumeroDe4 = xNumeroDe4.PadLeft(4)
            xNumeroDe4 = xNumeroDe4.Replace(" ", "0")

            xNumeroDe8 = Val(MetroTextBox11.Text.Trim)
            xNumeroDe8 = xNumeroDe8.PadLeft(8)
            xNumeroDe8 = xNumeroDe8.Replace(" ", "0")



            If MetroRadioButton1.Checked = True Then
                x4 = 1
                x5 = 1
            End If
            If MetroRadioButton2.Checked = True Then
                x4 = 1
                x5 = 2
            End If
            If MetroRadioButton3.Checked = True Then
                x4 = 2
                x5 = 3
            End If

            x6 = MetroTextBox10.Text.Trim
            x7 = xNumeroDe4 & "-" & xNumeroDe8
            x8 = Convert.ToDouble(MetroTextBox25.Text.Trim)
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

            MetroRadioButton1.Checked = True

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

   
    Private Sub MetroTextBox12_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox12.Validated


        If MetroTextBox12.Text.Trim = "" Then
            MetroTextBox12.Text = "0.00"
        End If
        MetroTextBox12.Text = CDbl(MetroTextBox12.Text)

        MetroTextBox12.Text = FormatNumber(CDbl(MetroTextBox12.Text), 2)

        If MetroTextBox13.Text.Trim = "" Then
            MetroTextBox13.Text = "21.00"
        End If

        Dim Aux As Double = Convert.ToDouble(MetroTextBox12.Text)

        Aux = Math.Round(Aux / (1 + (Convert.ToDouble(MetroTextBox13.Text) / 100)), 2)

        MetroTextBox14.Text = FormatNumber(Aux, 2)

        MetroTextBox19.Text = "0.00"
        MetroTextBox20.Text = "0.00"
        MetroTextBox21.Text = "0.00"
        MetroTextBox22.Text = "0.00"

        If CDbl(MetroTextBox13.Text) = 2.5 Then
            MetroTextBox19.Text = Math.Round(CDbl(MetroTextBox14.Text) * 2.5 / 100, 2)
            MetroTextBox19.Text = FormatNumber(CDbl(MetroTextBox19.Text), 2)
        End If


        If CDbl(MetroTextBox13.Text) = 10.5 Then
            MetroTextBox20.Text = Math.Round(CDbl(MetroTextBox14.Text) * 10.5 / 100, 2)
            MetroTextBox20.Text = FormatNumber(CDbl(MetroTextBox20.Text), 2)
        End If

        If CDbl(MetroTextBox13.Text) = 21 Then
            MetroTextBox21.Text = Math.Round(CDbl(MetroTextBox14.Text) * 21 / 100, 2)
            MetroTextBox21.Text = FormatNumber(CDbl(MetroTextBox21.Text), 2)
        End If

        If CDbl(MetroTextBox13.Text) = 27 Then
            MetroTextBox22.Text = Math.Round(CDbl(MetroTextBox14.Text) * 27 / 100, 2)
            MetroTextBox22.Text = FormatNumber(CDbl(MetroTextBox22.Text), 2)
        End If


        MetroTextBox23.Text = CDbl(MetroTextBox19.Text) + CDbl(MetroTextBox20.Text) + CDbl(MetroTextBox21.Text) + CDbl(MetroTextBox22.Text)
        MetroTextBox23.Text = FormatNumber(CDbl(MetroTextBox23.Text), 2)
        MetroTextBox24.Text = FormatNumber(CDbl(MetroTextBox23.Text), 2)

        parcialComprobante()


    End Sub


End Class

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


Public Class Form14
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

#Region "ControlText"

    Private Sub MetroTextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MetroTextBox1.KeyDown
        If e.KeyCode <> Keys.F1 Then
            Exit Sub
        End If

        rsv_Io = 1
        rsv_Seleccion = ""
        Dim Formulario_open As New Form9
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

    Private Sub MetroTextBox5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MetroTextBox5.KeyDown

        If e.KeyCode <> Keys.F1 Then
            Exit Sub
        End If

        rsv_Io = 1
        rsv_Seleccion = ""
        Dim Formulario_open As New Form6(5)
        Formulario_open.ShowDialog()

        If rsv_Seleccion.Trim <> "" Then
            MetroTextBox5.Text = rsv_Seleccion
            MetroTextBox5.Focus()
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

    Private Sub MetroTextBox7_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MetroTextBox7.KeyDown
        If e.KeyCode <> Keys.F1 Then
            Exit Sub
        End If

        rsv_Io = 1
        rsv_Seleccion = ""
        Dim Formulario_open As New Form6(6)
        Formulario_open.ShowDialog()

        If rsv_Seleccion.Trim <> "" Then
            MetroTextBox7.Text = rsv_Seleccion
            MetroTextBox7.Focus()
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
    Private Sub metroTextBox27_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox27.KeyPress
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
    Private Sub metroTextBox28_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox28.KeyPress
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
    Private Sub metroTextBox29_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox29.KeyPress
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
    Private Sub metroTextBox30_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox30.KeyPress
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
    Private Sub metroTextBox31_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox31.KeyPress
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
    Private Sub metroTextBox32_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub metroTextBox33_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox33.KeyPress
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
    Private Sub metroTextBox34_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox34.KeyPress
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
    Private Sub metroTextBox35_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox35.KeyPress
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

    Private Sub metroTextBox36_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox36.KeyPress
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

    Private Sub metroTextBox37_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox37.KeyPress
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
    Private Sub metroTextBox38_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox38.KeyPress
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
    Private Sub metroTextBox39_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox39.KeyPress
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
    Private Sub metroTextBox40_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox40.KeyPress
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
    Private Sub metroTextBox41_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox41.KeyPress
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

    Private Sub metroTextBox42_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox42.KeyPress
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
    Private Sub Form14_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        inicializa_form()
    End Sub
    Private Sub inicializa_form()

        MetroDateTime1.Value = Now.Date
        MetroDateTime2.Value = Now.Date

        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox4.Text = ""
        MetroTextBox5.Text = ""
        MetroTextBox6.Text = ""
        MetroTextBox7.Text = ""
        MetroTextBox8.Text = ""
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

        MetroTextBox29.Text = "0.00"
        MetroTextBox27.Text = "0.00"
        MetroTextBox28.Text = "0.00"
        MetroTextBox34.Text = "0.00"
        MetroTextBox36.Text = "0.00"
        MetroTextBox38.Text = "0.00"
        MetroTextBox40.Text = "0.00"
        MetroTextBox42.Text = "0.00"
        MetroTextBox43.Text = "0.00"


        MetroTextBox30.Text = "0.00"
        MetroTextBox31.Text = "0.00"
        MetroTextBox33.Text = "0.00"
        MetroTextBox35.Text = "0.00"
        MetroTextBox37.Text = "0.00"
        MetroTextBox39.Text = "0.00"
        MetroTextBox41.Text = "0.00"

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
        Me.Close()
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

    Private Sub validarProveedor()
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
        Call retornaProveedor(x1, x2, x4, x3)
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

        If MetroTextBox29.Text.Trim = "" Then
            MetroTextBox29.Text = "0.00"
        End If
        If MetroTextBox27.Text.Trim = "" Then
            MetroTextBox27.Text = "0.00"
        End If
        If MetroTextBox28.Text.Trim = "" Then
            MetroTextBox28.Text = "0.00"
        End If
        If MetroTextBox30.Text.Trim = "" Then
            MetroTextBox30.Text = "0.00"
        End If
        If MetroTextBox31.Text.Trim = "" Then
            MetroTextBox31.Text = "0.00"
        End If

        If MetroTextBox34.Text.Trim = "" Then
            MetroTextBox34.Text = "0.00"
        End If
        If MetroTextBox36.Text.Trim = "" Then
            MetroTextBox36.Text = "0.00"
        End If
        If MetroTextBox38.Text.Trim = "" Then
            MetroTextBox38.Text = "0.00"
        End If
        If MetroTextBox40.Text.Trim = "" Then
            MetroTextBox40.Text = "0.00"
        End If
        If MetroTextBox42.Text.Trim = "" Then
            MetroTextBox42.Text = "0.00"
        End If
        If MetroTextBox33.Text.Trim = "" Then
            MetroTextBox33.Text = "0.00"
        End If
        If MetroTextBox35.Text.Trim = "" Then
            MetroTextBox35.Text = "0.00"
        End If
        If MetroTextBox37.Text.Trim = "" Then
            MetroTextBox37.Text = "0.00"
        End If
        If MetroTextBox39.Text.Trim = "" Then
            MetroTextBox39.Text = "0.00"
        End If
        If MetroTextBox41.Text.Trim = "" Then
            MetroTextBox41.Text = "0.00"
        End If



        If MetroTextBox12.Text.Trim = "" And ok = True Then
            MetroFramework.MetroMessageBox.Show(Me, "Importe Testigo Inválido", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ok = False
        End If
        If CDbl(MetroTextBox12.Text.Trim) = 0 And ok = True Then
            MetroFramework.MetroMessageBox.Show(Me, "Importe Testigo Inválido", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ok = False
        End If
        If MetroTextBox26.Text.Trim = "" And ok = True Then
            MetroFramework.MetroMessageBox.Show(Me, "Código de Responsable Inválido", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ok = False
        End If
        If MetroTextBox1.Text.Trim = "" Or MetroTextBox2.Text.Trim = "" And ok = True Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar proveedor para imputar comprobante", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If MetroTextBox10.Text.Trim.ToUpper <> "A" And MetroTextBox10.Text.Trim.ToUpper <> "C" And ok = True Then
            MetroFramework.MetroMessageBox.Show(Me, "Letra de Comprobante Inválido para comprobante", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ok = False
        End If

        If ok = False Then
            Exit Sub
        End If

        Dim suma1 As Double
        Dim suma2 As Double

        suma1 = Math.Round(CDbl(MetroTextBox14.Text) + CDbl(MetroTextBox15.Text) + CDbl(MetroTextBox16.Text) + CDbl(MetroTextBox17.Text) + CDbl(MetroTextBox18.Text) + CDbl(MetroTextBox23.Text), 2)
        suma2 = Math.Round(CDbl(MetroTextBox25.Text), 2)



        If suma1 <> suma2 Then
            MetroFramework.MetroMessageBox.Show(Me, "Existe diferencia en el total de comprobante y sumas parciales", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ok = False
        End If

        suma1 = Math.Round(CDbl(MetroTextBox19.Text) + CDbl(MetroTextBox20.Text) + CDbl(MetroTextBox21.Text) + CDbl(MetroTextBox22.Text), 2)

        If suma1 <> Math.Round(CDbl(MetroTextBox23.Text), 2) Then
            MetroFramework.MetroMessageBox.Show(Me, "Existe diferencia en el total de Iva y sumas parciales de Iva", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If suma1 <> Math.Round(CDbl(MetroTextBox24.Text), 2) Then
            MetroFramework.MetroMessageBox.Show(Me, "Existe diferencia en el total de Iva y sumas parciales de Iva", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        suma1 = Math.Round(CDbl(MetroTextBox12.Text), 2)
        suma2 = Math.Round(CDbl(MetroTextBox25.Text), 2)

        If suma1 <> suma2 Then
            MetroFramework.MetroMessageBox.Show(Me, "Difiere Importe Testigo de comprobante y Importe Total del Comprobante", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            Dim xRubro As Integer = 0
            Dim xCentro As Integer = 0

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


            xCuit = CDbl(MetroTextBox3.Text.Trim)
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

            xRubro = Val(MetroTextBox5.Text.Trim)
            xCentro = Val(MetroTextBox7.Text.Trim)

            If MetroTextBox10.Text.Trim = "C" Then
                x1 = 0
                x2 = Math.Round(CDbl(MetroTextBox17.Text.Trim), 2)
                x3 = 0
                x4 = 0
                x5 = 0
                x6 = 0
                x7 = 0
                x8 = Math.Round(CDbl(MetroTextBox17.Text.Trim), 2)

                x32 = 0
                x33 = 0
                x34 = 0

            End If


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
            sql = "Insert Into Iva_Compras (Fecha,FechaDeImputacion,TipoDeComprobante,"
            sql = sql & "TipoResponsable,Cuit,Letra,NumeroDeComprobante,"
            sql = sql & "Cliente,Nombre,NetoGravado,ConceptosNoGravados,"
            sql = sql & "IvaDiscriminado,IvaNoInscripto,Exento,Total,Retenciones,"
            sql = sql & "DebitoFiscal,IvaaComputar,ComprasaNoInscriptos,Rubro,CentroCosto,"
            sql = sql & "UsuarioAlta,FechaAlta,HoraAlta,Estado,"
            sql = sql & "Iva25,Iva105,Iva21,Iva27,AliRi,AliRni) Values ("
            sql = sql & "'" & a1 & "','" & a2 & "','" & xTipo & "',"
            sql = sql & "" & A9 & "," & xCuit & ",'" & a7 & "','" & a8 & "',"
            sql = sql & "" & xCliente & ",'" & xNombre & "'," & x1 & "," & x2 & ","
            sql = sql & "" & x6 & ",0," & x3 & "," & x8 & "," & x5 & ","
            sql = sql & "0," & x7 & "," & x4 & "," & xRubro & "," & xCentro & ","
            sql = sql & "" & j1 & ",'" & j2 & "','" & j3 & "',0, "
            sql = sql & "" & x37 & "," & x32 & "," & x33 & "," & x34 & "," & x35 & "," & x36 & " )"

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
        MetroTextBox5.Text = ""
        MetroTextBox6.Text = ""
        MetroTextBox7.Text = ""
        MetroTextBox8.Text = ""
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

        MetroTextBox29.Text = "0.00"
        MetroTextBox27.Text = "0.00"
        MetroTextBox28.Text = "0.00"
        MetroTextBox34.Text = "0.00"
        MetroTextBox36.Text = "0.00"
        MetroTextBox38.Text = "0.00"
        MetroTextBox40.Text = "0.00"
        MetroTextBox42.Text = "0.00"
        MetroTextBox43.Text = "0.00"


        MetroTextBox30.Text = "0.00"
        MetroTextBox31.Text = "0.00"
        MetroTextBox33.Text = "0.00"
        MetroTextBox35.Text = "0.00"
        MetroTextBox37.Text = "0.00"
        MetroTextBox39.Text = "0.00"
        MetroTextBox41.Text = "0.00"

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

    Private Sub MetroTextBox5_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox5.Validated
        MetroTextBox6.Text = ""
        If MetroTextBox5.Text.Trim = "" Then
            Exit Sub
        End If
        MetroTextBox6.Text = parametroSistema(5, Val(MetroTextBox5.Text.Trim))
    End Sub

    Private Sub MetroTextBox7_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox7.Validated
        MetroTextBox8.Text = ""
        If MetroTextBox7.Text.Trim = "" Then
            Exit Sub
        End If
        MetroTextBox8.Text = parametroSistema(6, Val(MetroTextBox7.Text.Trim))
    End Sub

   

    Private Sub MetroTextBox1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox1.Validated
        validarProveedor()
    End Sub

    Private Sub MetroTextBox12_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox12.Validated
        If MetroTextBox12.Text.Trim = "" Then
            MetroTextBox12.Text = "0.00"
        End If
        MetroTextBox12.Text = CDbl(MetroTextBox12.Text)
        MetroTextBox12.Text = FormatNumber(CDbl(MetroTextBox12.Text), 2)

    End Sub

    Private Sub MetroTextBox23_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox23.Validated
        If MetroTextBox23.Text.Trim = "" Then
            MetroTextBox23.Text = "0.00"
        End If
        MetroTextBox23.Text = FormatNumber(CDbl(MetroTextBox23.Text), 2)
        parcialComprobante()
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
            Dim x22 As Double = 0
            Dim x23 As Double = 0
            Dim x24 As Double = 0
            Dim x25 As Double = 0
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
            x10 = Convert.ToDouble(MetroTextBox18.Text.Trim)

            x11 = Convert.ToDouble(MetroTextBox29.Text.Trim)
            x12 = Convert.ToDouble(MetroTextBox27.Text.Trim)
            x13 = Convert.ToDouble(MetroTextBox34.Text.Trim)
            x14 = Convert.ToDouble(MetroTextBox36.Text.Trim)
            x15 = Convert.ToDouble(MetroTextBox38.Text.Trim)
            x16 = Convert.ToDouble(MetroTextBox40.Text.Trim)
            x17 = Convert.ToDouble(MetroTextBox42.Text.Trim)

            x18 = Convert.ToDouble(MetroTextBox28.Text.Trim)




            x19 = Convert.ToDouble(MetroTextBox30.Text.Trim)
            x20 = Convert.ToDouble(MetroTextBox31.Text.Trim)
            x21 = Convert.ToDouble(MetroTextBox33.Text.Trim)
            x22 = Convert.ToDouble(MetroTextBox35.Text.Trim)
            x23 = Convert.ToDouble(MetroTextBox37.Text.Trim)
            x24 = Convert.ToDouble(MetroTextBox39.Text.Trim)
            x25 = Convert.ToDouble(MetroTextBox41.Text.Trim)

            x26 = 0
            x27 = Convert.ToDouble(MetroTextBox43.Text.Trim)

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim InsSql As String = ""
            InsSql = ""
            InsSql = "Insert into Cuenta_Corriente_Proveedores ("
            InsSql = InsSql & "Cliente,Fecha,FechaImputado,DebCre,CodigoMovimiento,LetraComprobante,NumeroComprobante,Importe,Detalle,"
            InsSql = InsSql & "ImputaIva,Retenciones,Dr1,Dr2,Dr3,Dr4,Dr5,Dr6,Dr7,Dr8,Pr1,Pr2,Pr3,Pr4,Pr5,Pr6,Pr7,Pr8,T1,T2,"
            InsSql = InsSql & "UsuarioAlta,FechaAlta,HoraAlta,Estado) Values ("
            InsSql = InsSql & "" & x1 & ",'" & x2 & "','" & x3 & "'," & x4 & "," & x5 & ",'" & x6 & "','" & x7 & "'," & x8 & ",'" & x9 & "',"
            InsSql = InsSql & "1," & x10 & "," & x11 & "," & x12 & "," & x13 & "," & x14 & "," & x15 & "," & x16 & "," & x17 & "," & x18 & "," & x19 & "," & x20 & "," & x21 & "," & x22 & "," & x23 & "," & x24 & "," & x25 & "," & x26 & "," & x27 & "," & x18 & ","
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

    Private Sub MetroButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton4.Click
        Dim Formulario_open As New Form54
        Formulario_open.ShowDialog()
    End Sub
    Private Sub MetroTextBox30_Validated(sender As Object, e As System.EventArgs) Handles MetroTextBox30.Validated
        calculo_descuentos_por_pago()
    End Sub
    Private Sub calculo_descuentos_por_pago()
        If MetroTextBox25.Text.Trim = "" Then
            MetroTextBox25.Text = "0.00"
        End If
        If MetroTextBox30.Text.Trim = "" Then
            MetroTextBox30.Text = "0.00"
        End If
        If MetroTextBox31.Text.Trim = "" Then
            MetroTextBox31.Text = "0.00"
        End If
        If MetroTextBox33.Text.Trim = "" Then
            MetroTextBox33.Text = "0.00"
        End If
        If MetroTextBox35.Text.Trim = "" Then
            MetroTextBox35.Text = "0.00"
        End If
        If MetroTextBox37.Text.Trim = "" Then
            MetroTextBox37.Text = "0.00"
        End If
        If MetroTextBox39.Text.Trim = "" Then
            MetroTextBox39.Text = "0.00"
        End If
        If MetroTextBox41.Text.Trim = "" Then
            MetroTextBox41.Text = "0.00"
        End If



        If MetroTextBox18.Text.Trim = "" Then
            MetroTextBox18.Text = "0.00"
        End If

        Dim AuxBase As Double = 0
        Dim Aux As Double = 0
        Dim Descuen As Double = 0
        Dim x As Double = 0

        AuxBase = Math.Round(Convert.ToDouble(MetroTextBox25.Text.Trim) - Convert.ToDouble(MetroTextBox18.Text.Trim), 2)

        If Convert.ToDouble(MetroTextBox30.Text.Trim) > 0 Then
            x = 0
            x = AuxBase * Convert.ToDouble(MetroTextBox30.Text.Trim) / 100
            x = Math.Round(x, 2)
            x = AuxBase - x
            MetroTextBox29.Text = FormatNumber(x, 2)
            AuxBase = x
            Descuen = AuxBase
        Else
            MetroTextBox29.Text = "0.00"
        End If

        If Convert.ToDouble(MetroTextBox31.Text.Trim) > 0 Then
            x = 0
            x = AuxBase * Convert.ToDouble(MetroTextBox31.Text.Trim) / 100
            x = Math.Round(x, 2)
            x = AuxBase - x
            MetroTextBox27.Text = FormatNumber(x, 2)
            AuxBase = x
            Descuen = AuxBase
        Else
            MetroTextBox27.Text = "0.00"
        End If

        If Convert.ToDouble(MetroTextBox33.Text.Trim) > 0 Then
            x = 0
            x = AuxBase * Convert.ToDouble(MetroTextBox33.Text.Trim) / 100
            x = Math.Round(x, 2)
            x = AuxBase - x
            MetroTextBox34.Text = FormatNumber(x, 2)
            AuxBase = x
            Descuen = AuxBase
        Else
            MetroTextBox34.Text = "0.00"
        End If

        If Convert.ToDouble(MetroTextBox35.Text.Trim) > 0 Then
            x = 0
            x = AuxBase * Convert.ToDouble(MetroTextBox35.Text.Trim) / 100
            x = Math.Round(x, 2)
            x = AuxBase - x
            MetroTextBox36.Text = FormatNumber(x, 2)
            AuxBase = x
            Descuen = AuxBase
        Else
            MetroTextBox36.Text = "0.00"
        End If

        If Convert.ToDouble(MetroTextBox37.Text.Trim) > 0 Then
            x = 0
            x = AuxBase * Convert.ToDouble(MetroTextBox37.Text.Trim) / 100
            x = Math.Round(x, 2)
            x = AuxBase - x
            MetroTextBox38.Text = FormatNumber(x, 2)
            AuxBase = x
            Descuen = AuxBase
        Else
            MetroTextBox38.Text = "0.00"
        End If

        If Convert.ToDouble(MetroTextBox39.Text.Trim) > 0 Then
            x = 0
            x = AuxBase * Convert.ToDouble(MetroTextBox39.Text.Trim) / 100
            x = Math.Round(x, 2)
            x = AuxBase - x
            MetroTextBox40.Text = FormatNumber(x, 2)
            AuxBase = x
            Descuen = AuxBase
        Else
            MetroTextBox40.Text = "0.00"
        End If

        If Convert.ToDouble(MetroTextBox41.Text.Trim) > 0 Then
            x = 0
            x = AuxBase * Convert.ToDouble(MetroTextBox41.Text.Trim) / 100
            x = Math.Round(x, 2)
            x = AuxBase - x
            MetroTextBox42.Text = FormatNumber(x, 2)
            AuxBase = x
            Descuen = AuxBase
        Else
            MetroTextBox42.Text = "0.00"
        End If


        Aux = 0
        Aux = Descuen + Convert.ToDouble(MetroTextBox18.Text.Trim)

        MetroTextBox43.Text = FormatNumber(Aux, 2)

        MetroTextBox30.Text = FormatNumber(CDbl(MetroTextBox30.Text), 2)
        MetroTextBox31.Text = FormatNumber(CDbl(MetroTextBox31.Text), 2)
        MetroTextBox33.Text = FormatNumber(CDbl(MetroTextBox33.Text), 2)
        MetroTextBox35.Text = FormatNumber(CDbl(MetroTextBox35.Text), 2)
        MetroTextBox37.Text = FormatNumber(CDbl(MetroTextBox37.Text), 2)
        MetroTextBox39.Text = FormatNumber(CDbl(MetroTextBox39.Text), 2)
        MetroTextBox41.Text = FormatNumber(CDbl(MetroTextBox41.Text), 2)

    End Sub



    Private Sub MetroTextBox31_Validated(sender As Object, e As System.EventArgs) Handles MetroTextBox31.Validated
        calculo_descuentos_por_pago()
    End Sub
   
    Private Sub MetroTextBox33_Validated(sender As Object, e As System.EventArgs) Handles MetroTextBox33.Validated
        calculo_descuentos_por_pago()
    End Sub
    Private Sub MetroTextBox35_Validated(sender As Object, e As System.EventArgs) Handles MetroTextBox35.Validated
        calculo_descuentos_por_pago()
    End Sub
    Private Sub MetroTextBox37_Validated(sender As Object, e As System.EventArgs) Handles MetroTextBox37.Validated
        calculo_descuentos_por_pago()
    End Sub
    Private Sub MetroTextBox39_Validated(sender As Object, e As System.EventArgs) Handles MetroTextBox39.Validated
        calculo_descuentos_por_pago()
    End Sub
    Private Sub MetroTextBox41_Validated(sender As Object, e As System.EventArgs) Handles MetroTextBox41.Validated
        calculo_descuentos_por_pago()
    End Sub




    Private Sub MetroTextBox27_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox27.Validated
        If MetroTextBox27.Text.Trim = "" Then
            MetroTextBox27.Text = "0.00"
        End If
        MetroTextBox27.Text = CDbl(MetroTextBox27.Text)
        MetroTextBox27.Text = FormatNumber(CDbl(MetroTextBox27.Text), 2)
    End Sub

    Private Sub MetroTextBox28_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox28.Validated
        If MetroTextBox28.Text.Trim = "" Then
            MetroTextBox28.Text = "0.00"
        End If
        MetroTextBox28.Text = CDbl(MetroTextBox28.Text)
        MetroTextBox28.Text = FormatNumber(CDbl(MetroTextBox28.Text), 2)
    End Sub
    Private Sub MetroTextBox34_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox34.Validated
        If MetroTextBox34.Text.Trim = "" Then
            MetroTextBox34.Text = "0.00"
        End If
        MetroTextBox34.Text = CDbl(MetroTextBox34.Text)
        MetroTextBox34.Text = FormatNumber(CDbl(MetroTextBox34.Text), 2)
    End Sub
    Private Sub MetroTextBox36_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox36.Validated
        If MetroTextBox36.Text.Trim = "" Then
            MetroTextBox36.Text = "0.00"
        End If
        MetroTextBox36.Text = CDbl(MetroTextBox36.Text)
        MetroTextBox36.Text = FormatNumber(CDbl(MetroTextBox36.Text), 2)
    End Sub
    Private Sub MetroTextBox38_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox38.Validated
        If MetroTextBox38.Text.Trim = "" Then
            MetroTextBox38.Text = "0.00"
        End If
        MetroTextBox38.Text = CDbl(MetroTextBox38.Text)
        MetroTextBox38.Text = FormatNumber(CDbl(MetroTextBox38.Text), 2)
    End Sub
    Private Sub MetroTextBox40_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox40.Validated
        If MetroTextBox40.Text.Trim = "" Then
            MetroTextBox40.Text = "0.00"
        End If
        MetroTextBox40.Text = CDbl(MetroTextBox40.Text)
        MetroTextBox40.Text = FormatNumber(CDbl(MetroTextBox40.Text), 2)
    End Sub
    Private Sub MetroTextBox42_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox42.Validated
        If MetroTextBox42.Text.Trim = "" Then
            MetroTextBox42.Text = "0.00"
        End If
        MetroTextBox42.Text = CDbl(MetroTextBox42.Text)
        MetroTextBox42.Text = FormatNumber(CDbl(MetroTextBox42.Text), 2)
    End Sub

    Private Sub MetroTextBox29_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox29.Validated
        If MetroTextBox29.Text.Trim = "" Then
            MetroTextBox29.Text = "0.00"
        End If
        MetroTextBox29.Text = CDbl(MetroTextBox29.Text)
        MetroTextBox29.Text = FormatNumber(CDbl(MetroTextBox29.Text), 2)
    End Sub
   
   
    Private Sub MetroTextBox41_Click(sender As System.Object, e As System.EventArgs) Handles MetroTextBox41.Click

    End Sub

    Private Sub MetroTextBox32_Click(sender As System.Object, e As System.EventArgs)

    End Sub
End Class

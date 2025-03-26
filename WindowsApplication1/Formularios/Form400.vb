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


Public Class Form400
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Dim r_tipo_respo As Byte = 0

    Public Sub New(ByVal v_TipoRespo As Byte)
        InitializeComponent()
        r_tipo_respo = v_TipoRespo
    End Sub


    Private Sub Form400_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If r_tipo_respo = 1 Then
            MetroTextBox1.Text = "A"
            MetroTextBox4.Text = "A"
            MetroTextBox7.Text = "A"
        Else
            MetroTextBox1.Text = "B"
            MetroTextBox4.Text = "B"
            MetroTextBox7.Text = "B"
        End If

        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""

        MetroTextBox5.Text = ""
        MetroTextBox6.Text = ""

        MetroTextBox8.Text = ""
        MetroTextBox9.Text = ""

        MetroTextBox10.Text = "FA"
        MetroTextBox11.Text = "FA"
        MetroTextBox12.Text = "FA"

        MetroDateTime1.Value = Now.Date
        MetroDateTime2.Value = Now.Date
        MetroDateTime3.Value = Now.Date

        Call lectura_param()

        If rsv_CpteAsoc_Nro1 <> 0 Then
            MetroTextBox10.Text = rsv_CpteAsoc_Tipo1
            MetroTextBox1.Text = rsv_CpteAsoc_Letra1
            MetroTextBox2.Text = rsv_CpteAsoc_Pto1
            MetroTextBox3.Text = rsv_CpteAsoc_Nro1
            MetroDateTime1.Value = FormatDateTime(rsv_CpteAsoc_Fecha1, DateFormat.ShortDate)
        End If

        If rsv_CpteAsoc_Nro2 <> 0 Then
            MetroTextBox11.Text = rsv_CpteAsoc_Tipo2
            MetroTextBox4.Text = rsv_CpteAsoc_Letra2
            MetroTextBox5.Text = rsv_CpteAsoc_Pto2
            MetroTextBox6.Text = rsv_CpteAsoc_Nro2
            MetroDateTime2.Value = FormatDateTime(rsv_CpteAsoc_Fecha2, DateFormat.ShortDate)
        End If

        If rsv_CpteAsoc_Nro3 <> 0 Then
            MetroTextBox12.Text = rsv_CpteAsoc_Tipo3
            MetroTextBox7.Text = rsv_CpteAsoc_Letra3
            MetroTextBox8.Text = rsv_CpteAsoc_Pto3
            MetroTextBox9.Text = rsv_CpteAsoc_Nro3
            MetroDateTime3.Value = FormatDateTime(rsv_CpteAsoc_Fecha3, DateFormat.ShortDate)
        End If


    End Sub
    Private Sub lectura_param()

        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)

        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdTemp As New OleDbCommand("Select * from  Parametro_punto_de_venta", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then

                    metroTextBox13.Text = drTemp("Cuit").ToString()
                    metroTextBox14.Text = drTemp("Cuit").ToString()
                    metroTextBox15.Text = drTemp("Cuit").ToString()

                    metroTextBox2.Text = drTemp("Punto").ToString()
                    metroTextBox5.Text = drTemp("Punto").ToString()
                    metroTextBox8.Text = drTemp("Punto").ToString()

                End If
            End If
            drTemp.Close()


        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
            ConSql.Close()

        End Try

    End Sub


    Private Sub metroTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub metroTextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox4.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub metroTextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox7.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
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
    Private Sub metroTextBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox10.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub metroTextBox11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox11.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub metroTextBox12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox12.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
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
    Private Sub metroTextBox1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox1.Validated
        metroTextBox1.Text = validar_letra_entrada(metroTextBox1.Text)
    End Sub
    Private Sub metroTextBox4_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox4.Validated
        metroTextBox4.Text = validar_letra_entrada(metroTextBox4.Text)
    End Sub
    Private Sub metroTextBox7_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox7.Validated
        metroTextBox7.Text = validar_letra_entrada(metroTextBox7.Text)
    End Sub
    Private Sub metroTextBox10_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox10.Validated
        metroTextBox10.Text = validar_tipo_entrada(metroTextBox10.Text)
    End Sub
    Private Sub metroTextBox11_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox11.Validated
        metroTextBox11.Text = validar_tipo_entrada(metroTextBox11.Text)
    End Sub
    Private Sub metroTextBox12_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox12.Validated
        metroTextBox12.Text = validar_tipo_entrada(metroTextBox12.Text)
    End Sub
    Private Function validar_letra_entrada(ByVal xLetra As String) As String
        Dim r As String = xLetra.ToUpper.Trim
        If xLetra.Trim = "" Then
            r = "A"
        End If
        If xLetra.Trim.ToUpper <> "A" And xLetra.Trim.ToUpper <> "B" And xLetra.Trim.ToUpper <> "C" Then
            r = "A"
        End If
        validar_letra_entrada = r
    End Function
    Private Function validar_tipo_entrada(ByVal xTipo As String) As String
        Dim r As String = xTipo.ToUpper.Trim
        If xTipo.Trim = "" Then
            r = "FA"
        End If
        If xTipo.Trim.ToUpper <> "FA" And xTipo.Trim.ToUpper <> "ND" Then
            r = "FA"
        End If
        validar_tipo_entrada = r
    End Function

    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click

        inicializar_variables()

        If metroTextBox10.Text.Trim = "" Then
            metroTextBox10.Text = "FA"
        End If
        If metroTextBox11.Text.Trim = "" Then
            metroTextBox11.Text = "FA"
        End If
        If metroTextBox12.Text.Trim = "" Then
            metroTextBox12.Text = "FA"
        End If

        If metroTextBox1.Text.Trim = "" Then
            metroTextBox1.Text = "A"
        End If
        If metroTextBox4.Text.Trim = "" Then
            metroTextBox4.Text = "A"
        End If
        If metroTextBox7.Text.Trim = "" Then
            metroTextBox7.Text = "A"
        End If

        If cuitValido(MetroTextBox13.Text) = False Then
            MetroFramework.MetroMessageBox.Show(Me, "Número de Cuit Inválido para primer Comprobante informado !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If cuitValido(MetroTextBox14.Text) = False Then
            MetroFramework.MetroMessageBox.Show(Me, "Número de Cuit Inválido para segundo Comprobante informado !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If cuitValido(MetroTextBox15.Text) = False Then
            MetroFramework.MetroMessageBox.Show(Me, "Número de Cuit Inválido para tercer Comprobante informado !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'Primer Comprobante
        If metroTextBox10.Text.Trim <> "" Then
            If metroTextBox10.Text.Trim <> "FA" And metroTextBox10.Text.Trim <> "ND" Then
                MetroFramework.MetroMessageBox.Show(Me, "El Tipo de Comprobante es Inválido en primer Comprobante informado !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
        If metroTextBox1.Text.Trim <> "" Then
            If metroTextBox1.Text.Trim <> "A" And metroTextBox1.Text.Trim <> "B" And metroTextBox1.Text.Trim <> "C" Then
                MetroFramework.MetroMessageBox.Show(Me, "La Letra del Comprobante es Inválido en primer Comprobante informado !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
        If metroTextBox2.Text.Trim <> "" Then
            If Val(metroTextBox2.Text.Trim) = 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "El Punto de Venta del Comprobante es Inválido en primer Comprobante informado !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
        If metroTextBox3.Text.Trim <> "" Then
            If Val(metroTextBox3.Text.Trim) = 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "El Número del Comprobante es Inválido en primer Comprobante informado !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        'Segundo Comprobante
        If metroTextBox11.Text.Trim <> "" Then
            If metroTextBox11.Text.Trim <> "FA" And metroTextBox11.Text.Trim <> "ND" Then
                MetroFramework.MetroMessageBox.Show(Me, "El Tipo de Comprobante es Inválido en segundo Comprobante informado !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
        If metroTextBox4.Text.Trim <> "" Then
            If metroTextBox4.Text.Trim <> "A" And metroTextBox4.Text.Trim <> "B" And metroTextBox4.Text.Trim <> "C" Then
                MetroFramework.MetroMessageBox.Show(Me, "La Letra del Comprobante es Inválido en segundo Comprobante informado !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
        If metroTextBox5.Text.Trim <> "" Then
            If Val(metroTextBox5.Text.Trim) = 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "El Punto de Venta del Comprobante es Inválido en segundo Comprobante informado !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
        If metroTextBox6.Text.Trim <> "" Then
            If Val(metroTextBox6.Text.Trim) = 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "El Número del Comprobante es Inválido en segundo Comprobante informado !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        'Tercer Comprobante
        If metroTextBox12.Text.Trim <> "" Then
            If metroTextBox12.Text.Trim <> "FA" And metroTextBox12.Text.Trim <> "ND" Then
                MetroFramework.MetroMessageBox.Show(Me, "El Tipo de Comprobante es Inválido en segundo Comprobante informado !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
        If metroTextBox7.Text.Trim <> "" Then
            If metroTextBox7.Text.Trim <> "A" And metroTextBox7.Text.Trim <> "B" And metroTextBox7.Text.Trim <> "C" Then
                MetroFramework.MetroMessageBox.Show(Me, "La Letra del Comprobante es Inválido en tercer Comprobante informado !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
        If metroTextBox8.Text.Trim <> "" Then
            If Val(metroTextBox8.Text.Trim) = 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "El Punto de Venta del Comprobante es Inválido en tercer Comprobante informado !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
        If metroTextBox9.Text.Trim <> "" Then
            If Val(metroTextBox9.Text.Trim) = 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "El Número del Comprobante es Inválido en tercer Comprobante informado !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        If metroTextBox2.Text.Trim = "" And metroTextBox3.Text.Trim <> "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Informó Número de Comprobante pero no ha informado Punto de Venta  en primer Comprobante !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If metroTextBox5.Text.Trim = "" And metroTextBox6.Text.Trim <> "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Informó Número de Comprobante pero no ha informado Punto de Venta  en segundo Comprobante !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If metroTextBox8.Text.Trim = "" And metroTextBox9.Text.Trim <> "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Informó Número de Comprobante pero no ha informado Punto de Venta  en tercer Comprobante !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If metroTextBox13.Text.Trim = "" And metroTextBox3.Text.Trim <> "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Informó Número de Comprobante pero no ha informado Cuit en primer Comprobante !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If metroTextBox14.Text.Trim = "" And metroTextBox6.Text.Trim <> "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Informó Número de Comprobante pero no ha informado Cuit en segundo Comprobante !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If metroTextBox15.Text.Trim = "" And metroTextBox9.Text.Trim <> "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Informó Número de Comprobante pero no ha informado Cuit en tercer Comprobante !!!!", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        If metroTextBox3.Text.Trim <> "" Then
            rsv_CpteAsoc_Cuit1 = metroTextBox13.Text.Trim.ToUpper
            rsv_CpteAsoc_Tipo1 = metroTextBox10.Text.Trim.ToUpper
            rsv_CpteAsoc_Letra1 = metroTextBox1.Text.Trim.ToUpper
            rsv_CpteAsoc_Pto1 = Val(metroTextBox2.Text.Trim)
            rsv_CpteAsoc_Nro1 = Val(MetroTextBox3.Text.Trim)
            rsv_CpteAsoc_Fecha1 = MetroDateTime1.Value
        End If

        If metroTextBox6.Text.Trim <> "" Then
            rsv_CpteAsoc_Cuit2 = metroTextBox14.Text.Trim.ToUpper
            rsv_CpteAsoc_Tipo2 = metroTextBox11.Text.Trim.ToUpper
            rsv_CpteAsoc_Letra2 = metroTextBox4.Text.Trim.ToUpper
            rsv_CpteAsoc_Pto2 = Val(metroTextBox5.Text.Trim)
            rsv_CpteAsoc_Nro2 = Val(metroTextBox6.Text.Trim)
            rsv_CpteAsoc_Fecha2 = MetroDateTime2.Value
        End If

        If metroTextBox9.Text.Trim <> "" Then
            rsv_CpteAsoc_Cuit3 = metroTextBox15.Text.Trim.ToUpper
            rsv_CpteAsoc_Tipo3 = metroTextBox12.Text.Trim.ToUpper
            rsv_CpteAsoc_Letra3 = metroTextBox7.Text.Trim.ToUpper
            rsv_CpteAsoc_Pto3 = Val(metroTextBox8.Text.Trim)
            rsv_CpteAsoc_Nro3 = Val(metroTextBox9.Text.Trim)
            rsv_CpteAsoc_Fecha3 = MetroDateTime3.Value
        End If

        Me.Close()

    End Sub

    

    Private Sub inicializar_variables()
        rsv_CpteAsoc_Tipo1 = "FA"
        rsv_CpteAsoc_Letra1 = "A"
        rsv_CpteAsoc_Pto1 = 0
        rsv_CpteAsoc_Nro1 = 0
        MetroDateTime1.Value = Now.Date

        rsv_CpteAsoc_Tipo2 = "FA"
        rsv_CpteAsoc_Letra2 = "A"
        rsv_CpteAsoc_Pto2 = 0
        rsv_CpteAsoc_Nro2 = 0
        MetroDateTime2.Value = Now.Date

        rsv_CpteAsoc_Tipo3 = "FA"
        rsv_CpteAsoc_Letra3 = "A"
        rsv_CpteAsoc_Pto3 = 0
        rsv_CpteAsoc_Nro3 = 0
        MetroDateTime3.Value = Now.Date

    End Sub

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        inicializar_variables()
        Me.Close()
    End Sub

    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub

    
End Class

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


Public Class Form18
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)
    Dim reser_codigo As String = ""
    Dim reser_accion As Byte = 0

    Public Sub New(ByVal v_codigo As String, ByVal v_accion As Byte)
        InitializeComponent()
        reser_codigo = v_codigo
        reser_accion = v_accion
    End Sub

#Region "controles Text"
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

    Private Sub MetroTextBox0_CausesValidationChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub metroTextBox0_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub metroTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox1.KeyPress
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
    End Sub
    Private Sub metroTextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox3.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub metroTextBox20_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox20.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub metroTextBox21_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox21.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub MetroTextBox24_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MetroTextBox24.KeyDown
        If e.KeyCode <> Keys.F1 Then
            Exit Sub
        End If

        rsv_Io = 1
        rsv_Seleccion = ""
        Dim Formulario_open As New Form6(7)
        Formulario_open.ShowDialog()

        If rsv_Seleccion.Trim <> "" Then
            MetroTextBox24.Text = rsv_Seleccion
            MetroTextBox24.Focus()
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




#End Region


    Private Sub Form18_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MetroTextBox0.Text = reser_codigo
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox4.Text = ""
        MetroTextBox6.Text = ""
        MetroTextBox20.Text = ""
        MetroTextBox21.Text = ""
        MetroTextBox24.Text = ""
        MetroTextBox25.Text = ""

        MetroTextBox7.Text = "0.00"
        MetroTextBox8.Text = "0.00"
        MetroTextBox9.Text = "0.00"
        MetroTextBox10.Text = "0.00"
        MetroTextBox11.Text = "0.00"
        MetroTextBox12.Text = "0.00"
        MetroTextBox13.Text = "0.00"
        MetroTextBox14.Text = "0.00"
        MetroTextBox15.Text = "0.00"
        MetroTextBox16.Text = "0.00"
        MetroTextBox17.Text = "0.00"
        MetroTextBox18.Text = "0.00"
        MetroTextBox19.Text = "0.00"
        MetroTextBox22.Text = "0.00"
        MetroTextBox23.Text = "0.00"

        lectura_articulo()


    End Sub
    Private Sub lectura_articulo()
        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim param As String = MetroTextBox0.Text.Trim

            Dim Sql As String = ""
            Sql = "Select * from Articulos WHERE (Codigo= '" & reser_codigo & "') And (Estado=0) "


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then

                    MetroTextBox1.Text = drRecordSet("CodigoProveedor").ToString
                    MetroTextBox2.Text = drRecordSet("CodigoBarra").ToString
                    MetroTextBox3.Text = drRecordSet("Detalle").ToString
                    MetroTextBox4.Text = drRecordSet("Proveedor").ToString
                    MetroTextBox7.Text = FormatNumber(Convert.ToDouble(drRecordSet("PrecioCosto").ToString), 2)
                    MetroTextBox8.Text = FormatNumber(Convert.ToDouble(drRecordSet("Ganancia").ToString), 2)

                    If Val(drRecordSet("AplicaIva").ToString) = 1 Then
                        MetroCheckBox1.Checked = True
                    Else
                        MetroCheckBox1.Checked = False
                    End If

                    MetroTextBox9.Text = FormatNumber(Convert.ToDouble(drRecordSet("Alicuota").ToString), 2)
                    MetroTextBox10.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio1").ToString), 2)
                    MetroTextBox11.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio2").ToString), 2)
                    MetroTextBox12.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio3").ToString), 2)
                    MetroTextBox13.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio4").ToString), 2)
                    MetroTextBox14.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio5").ToString), 2)
                    MetroTextBox15.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio6").ToString), 2)
                    MetroTextBox16.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio7").ToString), 2)
                    MetroTextBox17.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio8").ToString), 2)
                    MetroTextBox18.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio9").ToString), 2)
                    MetroTextBox19.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio10").ToString), 2)

                    MetroTextBox20.Text = drRecordSet("Sector").ToString
                    MetroTextBox21.Text = drRecordSet("Estanteria").ToString

                    MetroTextBox22.Text = FormatNumber(Convert.ToDouble(drRecordSet("Existencia").ToString), 2)
                    MetroTextBox23.Text = FormatNumber(Convert.ToDouble(drRecordSet("ExisMini").ToString), 2)

                    MetroTextBox24.Text = drRecordSet("Rubro").ToString

                    If reser_accion = 1 Then
                        MetroCheckBox1.Enabled = True
                        MetroTextBox7.Enabled = True
                        MetroTextBox8.Enabled = True
                        MetroTextBox9.Enabled = True
                        MetroTextBox10.Enabled = True
                        MetroTextBox11.Enabled = True
                        MetroTextBox12.Enabled = True
                        MetroTextBox13.Enabled = True
                        MetroTextBox14.Enabled = True
                        MetroTextBox15.Enabled = True
                        MetroTextBox16.Enabled = True
                        MetroTextBox17.Enabled = True
                        MetroTextBox18.Enabled = True
                        MetroTextBox19.Enabled = True
                        MetroTextBox10.Focus()
                    End If
                    If reser_accion = 2 Then
                        MetroTextBox22.Enabled = True
                        MetroTextBox23.Enabled = True
                        MetroTextBox22.Focus()
                    End If
                End If
            End If

            drRecordSet.Close()

            If MetroTextBox4.Text.Trim <> "" Then
                MetroTextBox6.Text = valido_proveedor(MetroTextBox4.Text.Trim)
            End If
            If MetroTextBox24.Text.Trim <> "" Then
                MetroTextBox25.Text = parametroSistema(7, Val(MetroTextBox24.Text.Trim))
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub


    Private Sub MetroTextBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MetroTextBox4.KeyDown
        If e.KeyCode <> Keys.F1 Then
            Exit Sub
        End If

        rsv_Io = 1
        rsv_Seleccion = ""
        Dim Formulario_open As New Form9
        Formulario_open.ShowDialog()

        If rsv_Seleccion.Trim <> "" Then
            MetroTextBox4.Text = rsv_Seleccion
            MetroTextBox4.Focus()
        End If
    End Sub


    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        Try

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")

            Dim v0 As String = ""
            Dim v10 As Double = 0
            Dim v11 As Double = 0
            Dim v12 As Double = 0
            Dim v13 As Double = 0
            Dim v14 As Double = 0
            Dim v15 As Double = 0
            Dim v16 As Double = 0
            Dim v17 As Double = 0
            Dim v18 As Double = 0
            Dim v19 As Double = 0
            Dim v22 As Double = 0
            Dim v23 As Double = 0

            v0 = MetroTextBox0.Text.Trim
            If MetroTextBox10.Text.Trim <> "" Then
                v10 = CDbl(MetroTextBox10.Text.Trim)
            End If
            If MetroTextBox11.Text.Trim <> "" Then
                v11 = CDbl(MetroTextBox11.Text.Trim)
            End If
            If MetroTextBox12.Text.Trim <> "" Then
                v12 = CDbl(MetroTextBox12.Text.Trim)
            End If
            If MetroTextBox13.Text.Trim <> "" Then
                v13 = CDbl(MetroTextBox13.Text.Trim)
            End If
            If MetroTextBox14.Text.Trim <> "" Then
                v14 = CDbl(MetroTextBox14.Text.Trim)
            End If
            If MetroTextBox15.Text.Trim <> "" Then
                v15 = CDbl(MetroTextBox15.Text.Trim)
            End If
            If MetroTextBox16.Text.Trim <> "" Then
                v16 = CDbl(MetroTextBox16.Text.Trim)
            End If
            If MetroTextBox17.Text.Trim <> "" Then
                v17 = CDbl(MetroTextBox17.Text.Trim)
            End If
            If MetroTextBox18.Text.Trim <> "" Then
                v18 = CDbl(MetroTextBox18.Text.Trim)
            End If
            If MetroTextBox19.Text.Trim <> "" Then
                v19 = CDbl(MetroTextBox19.Text.Trim)
            End If
            If MetroTextBox22.Text.Trim <> "" Then
                v22 = CDbl(MetroTextBox22.Text.Trim)
            End If
            If MetroTextBox23.Text.Trim <> "" Then
                v23 = CDbl(MetroTextBox23.Text.Trim)
            End If
            Dim Sql As String = ""

            If reser_accion = 1 Then
                Sql = "Update Articulos SET "
                Sql = Sql & "Precio1=" & v10 & ",Precio2=" & v11 & ",Precio3=" & v12 & ",Precio4=" & v13 & ",Precio5=" & v14 & ","
                Sql = Sql & "Precio6=" & v15 & ",Precio7=" & v16 & ",Precio8=" & v17 & ",Precio9=" & v18 & ",Precio10=" & v19 & ","
                Sql = Sql & "Au=" & j1 & ",Af='" & j2 & "',Ah='" & j3 & "',Estado=0,UltimoPrecio='" & j2 & "'  "
                Sql = Sql & "WHERE Codigo = '" & v0 & "' "
            End If
            If reser_accion = 2 Then
                Sql = "Update Articulos SET "
                Sql = Sql & "Existencia=" & v22 & ",ExisMini=" & v23 & ","
                Sql = Sql & "Au=" & j1 & ",Af='" & j2 & "',Ah='" & j3 & "',Estado=0,UltimoPrecio='" & j2 & "' "
                Sql = Sql & "WHERE Codigo = '" & v0 & "' "
            End If


            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub


    Private Sub MetroTextBox7_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox7.Validated
        MetroTextBox7.Text = formatea_importe(MetroTextBox7.Text.Trim)
        logica_calculo_precios()
    End Sub
    Private Sub MetroTextBox8_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox8.Validated
        MetroTextBox8.Text = formatea_importe(MetroTextBox8.Text.Trim)
        logica_calculo_precios()
    End Sub
    Private Sub MetroTextBox9_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox9.Validated
        MetroTextBox9.Text = formatea_importe(MetroTextBox9.Text.Trim)
        logica_calculo_precios()
    End Sub
    Private Sub MetroTextBox22_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox22.Validated
        MetroTextBox22.Text = formatea_importe(MetroTextBox22.Text.Trim)
    End Sub
    Private Sub MetroTextBox23_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox23.Validated
        MetroTextBox23.Text = formatea_importe(MetroTextBox23.Text.Trim)
    End Sub
    Private Sub MetroTextBox10_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox10.Validated
        MetroTextBox10.Text = formatea_importe(MetroTextBox10.Text.Trim)
    End Sub
    Private Sub MetroTextBox11_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox11.Validated
        MetroTextBox11.Text = formatea_importe(MetroTextBox11.Text.Trim)
    End Sub
    Private Sub MetroTextBox12_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox12.Validated
        MetroTextBox12.Text = formatea_importe(MetroTextBox12.Text.Trim)
    End Sub
    Private Sub MetroTextBox13_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox13.Validated
        MetroTextBox13.Text = formatea_importe(MetroTextBox13.Text.Trim)
    End Sub
    Private Sub MetroTextBox14_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox14.Validated
        MetroTextBox14.Text = formatea_importe(MetroTextBox14.Text.Trim)
    End Sub
    Private Sub MetroTextBox15_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox15.Validated
        MetroTextBox15.Text = formatea_importe(MetroTextBox15.Text.Trim)
    End Sub
    Private Sub MetroTextBox16_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox16.Validated
        MetroTextBox16.Text = formatea_importe(MetroTextBox16.Text.Trim)
    End Sub
    Private Sub MetroTextBox17_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox17.Validated
        MetroTextBox17.Text = formatea_importe(MetroTextBox17.Text.Trim)
    End Sub
    Private Sub MetroTextBox18_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox18.Validated
        MetroTextBox18.Text = formatea_importe(MetroTextBox18.Text.Trim)
    End Sub
    Private Sub MetroTextBox19_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox19.Validated
        MetroTextBox19.Text = formatea_importe(MetroTextBox19.Text.Trim)
    End Sub
    Private Function formatea_importe(ByVal x As String) As String
        Dim r As String = ""
        Try
            If x.ToString.Trim = "" Then
                r = "0.00"
            Else
                r = x.ToString.Trim
            End If
            r = FormatNumber(CDbl(r), 2)

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            formatea_importe = r
        End Try
    End Function

    Private Sub MetroTextBox4_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox4.Validated

        MetroTextBox6.Text = ""

        If MetroTextBox4.Text.Trim = "" Then
            Exit Sub
        End If
        MetroTextBox6.Text = valido_proveedor(MetroTextBox4.Text.Trim)
    End Sub
    Private Function valido_proveedor(ByVal x As Double) As String
        Dim r As String = " "
        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim Sql As String = ""
            Sql = "Select * from Proveedores WHERE (Numero= " & x & ") And (Estado=0) "


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    r = drRecordSet("RazonSocial").ToString
                End If
            End If

            drRecordSet.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            valido_proveedor = r
        End Try

    End Function

    Private Sub MetroTextBox24_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox24.Validated
        MetroTextBox25.Text = ""
        If MetroTextBox24.Text.Trim = "" Then
            Exit Sub
        End If
        MetroTextBox25.Text = parametroSistema(7, Val(MetroTextBox24.Text.Trim))
    End Sub

    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub
    Private Sub logica_calculo_precios()
        Dim xCosto As Double = 0
        Dim xPorGanancia As Double = 0
        Dim xGanancia As Double = 0
        Dim xAlicuota As Double = 0
        Dim xPrecio As Double = 0
        Dim xAux As Double = 0

        If MetroTextBox7.Text.Trim <> "" Then
            xCosto = CDbl(MetroTextBox7.Text.Trim)
        End If
        If MetroTextBox8.Text.Trim <> "" Then
            xPorGanancia = CDbl(MetroTextBox8.Text.Trim)
        End If
        If MetroTextBox9.Text.Trim <> "" Then
            xAlicuota = CDbl(MetroTextBox9.Text.Trim)
        End If
        xGanancia = Math.Round(xCosto * xPorGanancia / 100, 2)
        xPrecio = Math.Round(xCosto + xGanancia, 2)
        If MetroCheckBox1.Checked = True Then
            If xAlicuota <> 0 Then
                xAux = Math.Round(xPrecio * xAlicuota / 100, 2)
            End If
        End If
        xPrecio = xPrecio + xAux
        MetroTextBox10.Text = formatea_importe(xPrecio)

    End Sub
    Private Sub MetroButton6_Click(sender As Object, e As EventArgs) Handles MetroButton6.Click
        MetroTextBox11.Text = MetroTextBox10.Text.Trim
        MetroTextBox12.Text = MetroTextBox10.Text.Trim
        MetroTextBox13.Text = MetroTextBox10.Text.Trim
        MetroTextBox14.Text = MetroTextBox10.Text.Trim
        MetroTextBox15.Text = MetroTextBox10.Text.Trim
        MetroTextBox16.Text = MetroTextBox10.Text.Trim
        MetroTextBox17.Text = MetroTextBox10.Text.Trim
        MetroTextBox18.Text = MetroTextBox10.Text.Trim
        MetroTextBox19.Text = MetroTextBox10.Text.Trim
    End Sub

    Private Sub MetroTextBox7_Click(sender As Object, e As EventArgs) Handles MetroTextBox7.Click

    End Sub

    Private Sub MetroTextBox8_Click(sender As Object, e As EventArgs) Handles MetroTextBox8.Click

    End Sub

    Private Sub MetroCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles MetroCheckBox1.CheckedChanged
        logica_calculo_precios()
    End Sub

    Private Sub MetroTextBox9_Click(sender As Object, e As EventArgs) Handles MetroTextBox9.Click

    End Sub
End Class

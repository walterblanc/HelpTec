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


Public Class Form71
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Dim reser_proveedor As Double = 0
    Dim reser_Letra As String = ""
    Dim reser_Tipo As String = ""
    Dim reser_Numero As String = ""

    Public Sub New(ByVal v_proveedor As Double, ByVal v_Letra As String, ByVal v_Tipo As String, ByVal v_Numero As String)
        InitializeComponent()
        reser_proveedor = v_proveedor
        reser_Letra = v_Letra
        reser_Tipo = v_Tipo
        reser_Numero = v_Numero
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
    Private Sub Form71_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        inicializo_variables()

        Call leo_comprobante()
    End Sub
    Private Sub inicializo_variables()

        MetroTextBox1.Text = "0.00"
        MetroTextBox2.Text = "0.00"
        MetroTextBox3.Text = "0.00"
        MetroTextBox4.Text = "0.00"

        MetroTextBox29.Text = "0.00"
        MetroTextBox27.Text = "0.00"
        MetroTextBox28.Text = "0.00"
        MetroTextBox34.Text = "0.00"
        MetroTextBox36.Text = "0.00"
        MetroTextBox38.Text = "0.00"
        MetroTextBox40.Text = "0.00"
        MetroTextBox42.Text = "0.00"


        MetroTextBox30.Text = "0.00"
        MetroTextBox31.Text = "0.00"
        MetroTextBox33.Text = "0.00"
        MetroTextBox35.Text = "0.00"
        MetroTextBox37.Text = "0.00"
        MetroTextBox39.Text = "0.00"
        MetroTextBox41.Text = "0.00"

        MetroTextBox2.Text = "0.00"

        rsv_Numero1 = 0
        rsv_Numero2 = 0
        rsv_Numero3 = 0

    End Sub
    Private Sub MetroButton3_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton3.Click

        rsv_Numero1 = 0
        rsv_Numero2 = 0
        rsv_Numero3 = 0


        If MetroCheckBox1.Checked = True Then
            rsv_Numero1 = Convert.ToDouble(MetroTextBox1.Text)
            rsv_Numero2 = Convert.ToDouble(MetroTextBox3.Text)
            rsv_Numero3 = Convert.ToDouble(MetroTextBox28.Text)
        End If


        Me.Close()
    End Sub
    Private Sub leo_comprobante()
        Dim r As Integer = 1
        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim x As Byte = 0

            If reser_Tipo = "FA" Then
                x = 1
            End If

            If reser_Tipo = "NC" Then
                x = 3
            End If

            Dim Sql As String = ""
            Sql = "Select * from Cuenta_Corriente_Proveedores WHERE (Cliente= " & reser_proveedor & ") And (LetraComprobante='" & reser_Letra & "') And "
            Sql = Sql & "(CodigoMovimiento='" & x & "') And (NumeroComprobante='" & reser_Numero & "')"


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    MetroTextBox29.Text = drRecordSet("Dr1").ToString
                    MetroTextBox27.Text = drRecordSet("Dr2").ToString
                    MetroTextBox34.Text = drRecordSet("Dr3").ToString
                    MetroTextBox36.Text = drRecordSet("Dr4").ToString
                    MetroTextBox38.Text = drRecordSet("Dr5").ToString
                    MetroTextBox40.Text = drRecordSet("Dr6").ToString
                    MetroTextBox42.Text = drRecordSet("Dr7").ToString
                    MetroTextBox28.Text = drRecordSet("Dr8").ToString


                    MetroTextBox30.Text = drRecordSet("Pr1").ToString
                    MetroTextBox31.Text = drRecordSet("Pr2").ToString
                    MetroTextBox33.Text = drRecordSet("Pr3").ToString
                    MetroTextBox35.Text = drRecordSet("Pr4").ToString
                    MetroTextBox37.Text = drRecordSet("Pr5").ToString
                    MetroTextBox39.Text = drRecordSet("Pr6").ToString
                    MetroTextBox41.Text = drRecordSet("Pr7").ToString


                    MetroTextBox2.Text = drRecordSet("Importe").ToString
                    MetroTextBox3.Text = drRecordSet("Retenciones").ToString
                    MetroTextBox4.Text = CDbl(drRecordSet("Importe").ToString) - CDbl(drRecordSet("Retenciones").ToString)

                    MetroTextBox1.Text = drRecordSet("T1").ToString


                End If
            End If

            MetroTextBox27.Text = FormatNumber(CDbl(MetroTextBox27.Text), 2)
            MetroTextBox28.Text = FormatNumber(CDbl(MetroTextBox28.Text), 2)
            MetroTextBox29.Text = FormatNumber(CDbl(MetroTextBox29.Text), 2)
            MetroTextBox30.Text = FormatNumber(CDbl(MetroTextBox30.Text), 2)
            MetroTextBox31.Text = FormatNumber(CDbl(MetroTextBox31.Text), 2)

            MetroTextBox33.Text = FormatNumber(CDbl(MetroTextBox33.Text), 2)
            MetroTextBox34.Text = FormatNumber(CDbl(MetroTextBox34.Text), 2)
            MetroTextBox35.Text = FormatNumber(CDbl(MetroTextBox35.Text), 2)
            MetroTextBox36.Text = FormatNumber(CDbl(MetroTextBox36.Text), 2)
            MetroTextBox37.Text = FormatNumber(CDbl(MetroTextBox37.Text), 2)
            MetroTextBox38.Text = FormatNumber(CDbl(MetroTextBox38.Text), 2)
            MetroTextBox39.Text = FormatNumber(CDbl(MetroTextBox39.Text), 2)
            MetroTextBox40.Text = FormatNumber(CDbl(MetroTextBox40.Text), 2)
            MetroTextBox41.Text = FormatNumber(CDbl(MetroTextBox41.Text), 2)
            MetroTextBox42.Text = FormatNumber(CDbl(MetroTextBox42.Text), 2)


            MetroTextBox2.Text = FormatNumber(CDbl(MetroTextBox2.Text), 2)
            MetroTextBox3.Text = FormatNumber(CDbl(MetroTextBox3.Text), 2)
            MetroTextBox4.Text = FormatNumber(CDbl(MetroTextBox4.Text), 2)


            MetroTextBox1.Text = FormatNumber(CDbl(MetroTextBox1.Text), 2)

            drRecordSet.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

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

    Private Sub MetroButton1_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton1.Click

        rsv_Numero1 = 0
        rsv_Numero2 = 0
        rsv_Numero3 = 0

        Me.Close()
    End Sub
    Private Sub MetroTextBox30_Validated(sender As Object, e As System.EventArgs) Handles MetroTextBox30.Validated
        calculo_descuentos_por_pago()
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


    Private Sub calculo_descuentos_por_pago()

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

        Dim AuxBase As Double = 0
        Dim Aux As Double = 0
        Dim Descuen As Double = 0
        Dim x As Double = 0


        AuxBase = Convert.ToDouble(MetroTextBox4.Text.Trim)

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
        Aux = Descuen + Convert.ToDouble(MetroTextBox3.Text.Trim)
        '  Aux = Descuen

        MetroTextBox1.Text = FormatNumber(Aux, 2)


        MetroTextBox30.Text = FormatNumber(CDbl(MetroTextBox30.Text), 2)
        MetroTextBox31.Text = FormatNumber(CDbl(MetroTextBox31.Text), 2)
        MetroTextBox33.Text = FormatNumber(CDbl(MetroTextBox33.Text), 2)
        MetroTextBox35.Text = FormatNumber(CDbl(MetroTextBox35.Text), 2)
        MetroTextBox37.Text = FormatNumber(CDbl(MetroTextBox37.Text), 2)
        MetroTextBox39.Text = FormatNumber(CDbl(MetroTextBox39.Text), 2)
        MetroTextBox41.Text = FormatNumber(CDbl(MetroTextBox41.Text), 2)
        MetroTextBox28.Text = FormatNumber(CDbl(MetroTextBox28.Text), 2)


    End Sub

    Private Sub MetroTextBox29_Click(sender As System.Object, e As System.EventArgs) Handles MetroTextBox29.Click

    End Sub
End Class

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


Public Class Form19
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Dim h As Integer = 0
    Dim reser_Ticket As Double = 0
    Dim reser_accion As Byte = 0

    Public Sub New(ByVal v_Ticket As Double, ByVal v_accion As Byte)
        InitializeComponent()
        reser_Ticket = v_Ticket
        reser_accion = v_accion
    End Sub
    Private Sub Form19_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        nuevo_tickets()
    End Sub
    Private Sub nuevo_tickets()

        MetroTextBox20.Text = "0.00"
        MetroTextBox21.Text = "0.00"
        MetroTextBox22.Text = "0.00"
        MetroTextBox23.Text = "0.00"


        MetroPanel1.Enabled = True
        MetroPanel2.Enabled = True
        MetroPanel3.Visible = False

        inicializo_parciales()
        inicializo_datos_ticket()
        h = 0
        definir_grilla()
        MetroTextBox18.Text = ""

        If reser_Ticket <> 0 And reser_accion = 1 Then
            MetroTextBox12.Text = reser_Ticket
            modifificacion_de_ticket()
        Else
            MetroTextBox12.Text = numeradorAutomatico(1, 1, 1)
        End If


    End Sub

    Private Sub modifificacion_de_ticket()
        Try

            Dim en As Boolean = False

            'Dim x1 As String = ""
            'Dim x2 As String = ""
            'Dim x3 As String = ""
            'Dim x4 As String = ""
            'Dim x5 As String = ""
            'Dim x6 As String = ""
            'Dim x7 As String = ""
            'Dim x8 As String = ""

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim Sql As String = ""
            Sql = "Select * from Tickets WHERE (TicketNro= " & reser_Ticket & ") Order by Orden"


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                Do While drRecordSet.Read
                    If en = False Then
                        MetroTextBox8.Text = drRecordSet("Nombre").ToString
                        MetroTextBox15.Text = drRecordSet("Documento").ToString
                        MetroTextBox9.Text = drRecordSet("Cliente").ToString
                        MetroTextBox10.Text = drRecordSet("ClienteNombre").ToString
                        MetroTextBox26.Text = drRecordSet("CalidadRespo").ToString
                        If Val(drRecordSet("Cuit").ToString) <> 0 Then
                            MetroTextBox14.Text = drRecordSet("Cuit").ToString
                        End If
                        If Val(drRecordSet("Contado").ToString) = 0 Then
                            MetroCheckBox1.Checked = True
                        Else
                            MetroCheckBox1.Checked = False
                        End If
                        en = True
                    End If

                    'x1 = MetroTextBox0.Text.Trim
                    'x2 = MetroTextBox1.Text.Trim
                    'x3 = MetroTextBox2.Text.Trim
                    'x4 = MetroTextBox3.Text.Trim
                    'x5 = MetroTextBox4.Text.Trim
                    'x6 = MetroTextBox5.Text.Trim
                    'x7 = MetroTextBox6.Text.Trim
                    'x8 = MetroTextBox7.Text.Trim


                    With metroGrid1
                        .Rows.Add()
                        .Item(0, h).Value = drRecordSet("Codigo").ToString
                        .Item(1, h).Value = drRecordSet("Lista").ToString
                        .Item(2, h).Value = drRecordSet("Detalle").ToString
                        .Item(3, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Alicuota").ToString), 2)
                        .Item(4, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Precio").ToString), 2)
                        .Item(5, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Cantidad").ToString), 2)
                        .Item(6, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Subtotal").ToString), 2)
                        .Item(7, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Dsto").ToString), 2)
                        .Item(8, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("PrecioConDsto").ToString), 2)
                        .Item(9, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Total").ToString), 2)
                        h = h + 1
                    End With
                Loop
            End If
            drRecordSet.Close()

            suma_grilla()
            inicializo_parciales()
            MetroTextBox0.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub inicializo_datos_ticket()
        MetroTextBox8.Text = ""
        MetroTextBox9.Text = ""
        MetroTextBox10.Text = ""
        MetroTextBox11.Text = ""
        MetroTextBox19.Text = ""
        MetroTextBox20.Text = ""
        MetroTextBox21.Text = ""
        MetroTextBox22.Text = ""
        MetroTextBox23.Text = ""

    End Sub
    Private Sub inicializo_parciales()
        MetroTextBox0.Text = ""
        MetroTextBox1.Text = "1"
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = "0.00"
        MetroTextBox24.Text = "0.00"
        MetroTextBox4.Text = "1.00"
        MetroTextBox5.Text = "0.00"
        MetroTextBox6.Text = "0.00"
        MetroTextBox7.Text = "0.00"
        MetroTextBox17.Text = "0.00"
        MetroTextBox2.Enabled = False
        MetroTextBox24.Enabled = False
    End Sub
    Private Sub definir_grilla()
        With metroGrid1
            .Columns.Clear()
            .Rows.Clear()
            .Refresh()
        End With

        With metroGrid1
            .Rows.Clear()
            .Columns.Add("Codigo", "Codigo")
            .Columns.Add("Lista", "Lta")
            .Columns.Add("Detalle", "Detalle")
            .Columns.Add("Iva", "Iva")
            .Columns.Add("Precio", "Precio")
            .Columns.Add("Cantidad", "Cant.")
            .Columns.Add("SubTotal", "SubTotal")
            .Columns.Add("Dsto", "Dsto.")
            .Columns.Add("PrecioConDsto", "P.C/Dsto")
            .Columns.Add("Total", "Total")
            .Columns(0).Width = 80
            .Columns(1).Width = 40
            .Columns(2).Width = 280
            .Columns(3).Width = 80
            .Columns(4).Width = 100
            .Columns(5).Width = 70
            .Columns(6).Width = 100
            .Columns(7).Width = 100
            .Columns(8).Width = 100
            .Columns(9).Width = 100
            '            .RowCount = 100
        End With
    End Sub
    Private Sub MetroButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton4.Click


        If MetroTextBox7.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Producto sin Valor", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If CDbl(MetroTextBox7.Text.Trim) = 0 Then
            MetroFramework.MetroMessageBox.Show(Me, "Producto sin Valor", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If CDbl(MetroTextBox3.Text.Trim) = 0 Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar precio", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If CDbl(MetroTextBox4.Text.Trim) = 0 Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar cantidad", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If CDbl(MetroTextBox24.Text.Trim) <> 0 And CDbl(MetroTextBox24.Text.Trim) <> 10.5 And CDbl(MetroTextBox24.Text.Trim) <> 21 Then
            MetroFramework.MetroMessageBox.Show(Me, "Tipo de Tarifa IVA inválida (0.00/10.50/21.00) ", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim x1 As String = ""
        Dim x2 As String = ""
        Dim x3 As String = ""
        Dim x4 As String = ""
        Dim x5 As String = ""
        Dim x6 As String = ""
        Dim x7 As String = ""
        Dim x8 As String = ""
        Dim x9 As String = ""
        Dim x10 As String = ""

        x1 = MetroTextBox0.Text.Trim
        x2 = MetroTextBox1.Text.Trim
        x3 = MetroTextBox2.Text.Trim
        x4 = MetroTextBox3.Text.Trim
        x5 = MetroTextBox4.Text.Trim
        x6 = MetroTextBox5.Text.Trim
        x7 = MetroTextBox6.Text.Trim
        x8 = MetroTextBox17.Text.Trim
        x9 = MetroTextBox7.Text.Trim
        x10 = MetroTextBox24.Text.Trim

        With metroGrid1
            .Rows.Add()
            .Item(0, h).Value = x1
            .Item(1, h).Value = x2
            .Item(2, h).Value = x3
            .Item(3, h).Value = x10
            .Item(4, h).Value = x4
            .Item(5, h).Value = x5
            .Item(6, h).Value = x6
            .Item(7, h).Value = x7
            .Item(8, h).Value = x8
            .Item(9, h).Value = x9
            h = h + 1
        End With
        suma_grilla()
        inicializo_parciales()
        MetroTextBox0.Focus()
    End Sub

    Private Sub MetroTextBox0_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MetroTextBox0.KeyDown
        If e.KeyCode <> Keys.F1 Then
            Exit Sub
        End If

        rsv_Io = 1
        rsv_Seleccion = ""
        Dim Formulario_open As New Form17
        Formulario_open.ShowDialog()

        If rsv_Seleccion.Trim <> "" Then
            MetroTextBox0.Text = rsv_Seleccion
            MetroTextBox0.Focus()
        End If

    End Sub

    Private Sub metroTextBox0_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox0.KeyPress
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
    Private Sub metroTextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox8.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub MetroTextBox9_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MetroTextBox9.KeyDown
        If e.KeyCode <> Keys.F1 Then
            Exit Sub
        End If

        rsv_Io = 1
        rsv_Seleccion = ""
        rsv_prg_orig = "Form19"
        Dim Formulario_open As New Form12
        Formulario_open.ShowDialog()

        If rsv_Seleccion.Trim <> "" Then
            MetroTextBox9.Text = rsv_Seleccion
            MetroTextBox9.Focus()
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

    Private Sub MetroTextBox3_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox3.Validated
        MetroTextBox3.Text = formatea_importe(MetroTextBox3.Text.Trim)
        parcial_calculos()
    End Sub
    Private Sub MetroTextBox4_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox4.Validated
        MetroTextBox4.Text = formatea_importe(MetroTextBox4.Text.Trim)
        parcial_calculos()

    End Sub
    Private Sub MetroTextBox6_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox6.Validated
        MetroTextBox6.Text = formatea_importe(MetroTextBox6.Text.Trim)
        parcial_calculos()

    End Sub
    Private Sub MetroTextBox7_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox7.Validated
        MetroTextBox7.Text = formatea_importe(MetroTextBox7.Text.Trim)
    End Sub
    Private Function formatea_importe(ByVal x As String) As String
        Dim r As String = ""
        Try
            If x.ToString.Trim = "." Then
                r = "0.00"
            End If

            If x.ToString.Trim = "" Then
                r = "0.00"
            End If

            r = x.ToString.Trim

            r = FormatNumber(CDbl(r), 2)

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            formatea_importe = r
        End Try
    End Function


    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        inicializo_parciales()
        MetroTextBox0.Focus()
    End Sub
    Private Sub parcial_calculos()

        MetroTextBox17.Text = "0.00"
        If MetroTextBox3.Text.Trim = "." Then
            MetroTextBox3.Text = "0.00"
        End If
        If MetroTextBox4.Text.Trim = "." Then
            MetroTextBox4.Text = "0.00"
        End If


        If MetroTextBox3.Text.Trim = "" Then
            MetroTextBox3.Text = "0.00"
        End If
        If MetroTextBox4.Text.Trim = "" Then
            MetroTextBox4.Text = "0.00"
        End If
        If MetroTextBox6.Text.Trim = "" Then
            MetroTextBox6.Text = "0.00"
        End If
        Dim a As Double = 0
        a = CDbl(MetroTextBox3.Text.Trim) * CDbl(MetroTextBox4.Text.Trim)
        MetroTextBox5.Text = FormatNumber(a, 2)
        Dim b As Double = 0

        b = CDbl(MetroTextBox6.Text.Trim)
       

        Dim d As Double = 0
        Dim e As Double = 0
        Dim f As Double = 0
        d = CDbl(MetroTextBox3.Text.Trim)
        e = Math.Round(d * b / 100, 2)
        f = Math.Round(d - e, 2)
        MetroTextBox17.Text = FormatNumber(f, 2)

        Dim g As Double = 0
        g = Math.Round(f * CDbl(MetroTextBox4.Text.Trim), 2)

        MetroTextBox7.Text = FormatNumber(g, 2)
    End Sub




    Private Sub lectura_articulo()
        Try

            If MetroTextBox1.Text.Trim = "" Then
                MetroTextBox1.Text = "1"
            End If
            MetroTextBox3.Text = "0.00"


            If MetroTextBox0.Text.ToUpper.Trim = "X" Then
                MetroTextBox2.Enabled = True
                MetroTextBox24.Enabled = True
                MetroTextBox24.Text = "0.00"
                MetroTextBox2.Focus()
                Exit Sub
            Else
                MetroTextBox2.Enabled = False
                MetroTextBox24.Enabled = False
            End If

            MetroTextBox2.Text = ""

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim param As String = MetroTextBox0.Text.Trim

            Dim Sql As String = ""
            Sql = "Select * from Articulos WHERE (Codigo= '" & param & "') And (Estado=0) "


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    MetroTextBox2.Text = drRecordSet("Detalle").ToString

                    If Val(MetroTextBox1.Text) = 1 Then
                        MetroTextBox3.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio1").ToString), 2)
                    End If
                    If Val(MetroTextBox1.Text) = 2 Then
                        MetroTextBox3.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio2").ToString), 2)
                    End If
                    If Val(MetroTextBox1.Text) = 3 Then
                        MetroTextBox3.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio3").ToString), 2)
                    End If
                    If Val(MetroTextBox1.Text) = 4 Then
                        MetroTextBox3.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio4").ToString), 2)
                    End If
                    If Val(MetroTextBox1.Text) = 5 Then
                        MetroTextBox3.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio5").ToString), 2)
                    End If
                    If Val(MetroTextBox1.Text) = 6 Then
                        MetroTextBox3.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio6").ToString), 2)
                    End If
                    If Val(MetroTextBox1.Text) = 7 Then
                        MetroTextBox3.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio7").ToString), 2)
                    End If
                    If Val(MetroTextBox1.Text) = 8 Then
                        MetroTextBox3.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio8").ToString), 2)
                    End If
                    If Val(MetroTextBox1.Text) = 9 Then
                        MetroTextBox3.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio9").ToString), 2)
                    End If
                    If Val(MetroTextBox1.Text) = 10 Then
                        MetroTextBox3.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio10").ToString), 2)
                    End If
                    MetroTextBox24.Text = FormatNumber(Convert.ToDouble(drRecordSet("Alicuota").ToString), 2)
                End If
            End If
            drRecordSet.Close()
            MetroTextBox3.Focus()


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
            h = h - 1
            suma_grilla()

        End If
    End Sub

    Private Sub suma_grilla()
        Try
            Dim x As Double = 0
            For Fila As Integer = 0 To metroGrid1.Rows.Count - 1
                x = x + Convert.ToDouble(metroGrid1.Rows(Fila).Cells("Total").Value)
            Next
            MetroTextBox11.Text = FormatNumber(x, 2)
            MetroTextBox19.Text = FormatNumber(x, 2)

            MetroTextBox18.Text = metroGrid1.Rows.Count

            verificar_descuento()
            verificar_incremento()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConSql.Close()

        End Try
    End Sub

    Private Sub MetroTextBox0_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox0.Validated
        lectura_articulo()
    End Sub



    Private Sub MetroButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        Try

            MetroPanel1.Enabled = False
            MetroPanel2.Enabled = False
            MetroPanel3.Visible = True

            '            MetroTextBox8.Text = nombreUsuario(rsv_Usuario).Trim & " " & TimeOfDay
            MetroTextBox8.Text = "CONSUMIDOR FINAL"
            MetroTextBox15.Text = "11111111"
            MetroTextBox9.Text = ""
            MetroTextBox10.Text = ""
            MetroTextBox16.Text = ""

            MetroTextBox26.Text = "2"
            MetroTextBox13.Text = "Consumidor Final"
            MetroTextBox14.Text = ""

            MetroCheckBox1.Checked = False

            Dim xImp1 As Double = 0
            Dim xImp2 As Double = 0

            Call retornaLimitesControladorFiscal(1, xImp1, xImp2)

            Dim xImpFac As Double = Convert.ToDouble(MetroTextBox19.Text.Trim)

            MetroLabel26.Text = ""
            MetroLabel27.Text = ""

            If xImpFac >= xImp1 Then
                MetroLabel26.Text = "Para Consumidor final debe identificar al Cliente con Número de Documento."
                MetroLabel27.Text = "Importe Minimo Pago Contado " & FormatNumber(xImp1, 2) & " Otro Medios Electrónicos " & FormatNumber(xImp2, 2)
            End If

            MetroTextBox8.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConSql.Close()

        End Try

    End Sub

    Private Sub MetroButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        Me.Close()
    End Sub

    Private Sub MetroButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton6.Click

        If MetroTextBox9.Text.Trim <> "" Then
            If MetroCheckBox1.Checked = True Then
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
        End If


        Call proceso_de_venta(1)
    End Sub
    Private Sub proceso_de_venta(ByVal proc_vta As Byte)
        If MetroTextBox26.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Especifique calidad de responsable fiscal", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim x As Byte = Val(MetroTextBox26.Text.Trim)
        If x < 1 Or x > 4 Then
            MetroFramework.MetroMessageBox.Show(Me, "Error en código de calidad de responsable fiscal", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If MetroTextBox13.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Especifique calidad de responsable fiscal", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If Val(MetroTextBox26.Text.Trim) <> 2 Then
            If MetroTextBox14.Text.Trim = "" Then
                MetroFramework.MetroMessageBox.Show(Me, "Debe especificar número de cuit para el cliente", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        Dim m As Double = 0
        '        m = CDbl(MetroTextBox11.Text.Trim)
        m = CDbl(MetroTextBox19.Text.Trim)
        If m > 208644 Then
            If Val(MetroTextBox26.Text.Trim) = 2 Then
                If MetroTextBox15.Text.Trim = "" Then
                    MetroFramework.MetroMessageBox.Show(Me, "Debe especificar número de documento para el cliente", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
        End If

        If MetroCheckBox1.Checked = True Then
            If MetroTextBox9.Text.Trim = "" Then
                MetroFramework.MetroMessageBox.Show(Me, "Debe especificar número de cliente para cuenta corriente", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        If MetroTextBox9.Text.Trim = "" Then
            If MetroTextBox8.Text.Trim = "" Then
                MetroFramework.MetroMessageBox.Show(Me, "Especifique Nombre del Cliente", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        Call grabar_venta(proc_vta)
        
    End Sub

    Private Sub grabar_venta(ByVal proc_vta As Byte)
        Try

            MetroTextBox12.Text = numeradorAutomatico(1, 1, 2)

            Dim sql As String = ""

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim v_1 As Double = 0
            Dim v_2 As Integer = 0
            Dim v_3 As String = ""
            Dim v_4 As Double = 0
            Dim v_5 As Double = 0
            Dim v_6 As Double = 0
            Dim v_7 As Double = 0
            Dim v_8 As Double = 0
            Dim v_9 As Double = 0
            Dim v_10 As String = ""
            Dim v_11 As Double = 0
            Dim v_12 As String = ""
            Dim v_13 As String = ""
            Dim v_14 As String = ""
            Dim v_15 As Integer = 0
            Dim v_16 As Double = 0
            Dim v_17 As Double = 0
            Dim v_18 As Byte = 0
            Dim v_19 As Byte = 0
            Dim v_20 As Double = 0


            Dim v_21 As Double = 0
            Dim v_22 As Double = 0
            Dim v_23 As Double = 0


            Dim v_24 As Double = 0
            Dim v_25 As Double = 0
            Dim v_26 As Double = 0

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String



            If MetroTextBox11.Text.Trim = "" Then
                v_9 = 0
            Else
                v_9 = CDbl(MetroTextBox11.Text.Trim)
            End If


            If MetroTextBox8.Text.Trim = "" Then
                v_10 = " "
            Else
                v_10 = MetroTextBox8.Text.Trim
            End If


            If MetroTextBox9.Text.Trim = "" Then
                v_11 = 0
            Else
                v_11 = Val(MetroTextBox9.Text.Trim)
            End If
            If MetroTextBox10.Text.Trim = "" Then
                v_12 = " "
            Else
                v_12 = MetroTextBox10.Text.Trim
            End If

            If MetroTextBox15.Text.Trim = "" Then
                v_16 = 0
            Else
                v_16 = CDbl(MetroTextBox15.Text.Trim)
            End If

            If MetroTextBox14.Text.Trim = "" Then
                v_17 = 0
            Else
                v_17 = CDbl(MetroTextBox14.Text.Trim)
            End If

            If MetroTextBox26.Text.Trim = "" Then
                v_18 = 2
            Else
                v_18 = CDbl(MetroTextBox26.Text.Trim)
            End If

            If MetroCheckBox1.Checked = True Then
                v_19 = 0
            Else
                v_19 = 1
            End If

            If MetroTextBox20.Text.Trim = "" Then
                v_21 = 0
            Else
                v_21 = CDbl(MetroTextBox20.Text.Trim)
            End If

            If MetroTextBox21.Text.Trim = "" Then
                v_22 = 0
            Else
                v_22 = CDbl(MetroTextBox21.Text.Trim)
            End If

            If MetroTextBox19.Text.Trim = "" Then
                v_23 = 0
            Else
                v_23 = CDbl(MetroTextBox19.Text.Trim)
            End If


            If MetroTextBox22.Text.Trim = "" Then
                v_24 = 0
            Else
                v_24 = CDbl(MetroTextBox22.Text.Trim)
            End If

            If MetroTextBox23.Text.Trim = "" Then
                v_25 = 0
            Else
                v_25 = CDbl(MetroTextBox23.Text.Trim)
            End If




            v_1 = Val(MetroTextBox12.Text.Trim)


            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")

            v_14 = j2

            For Fila As Integer = 0 To metroGrid1.Rows.Count - 1
                v_3 = metroGrid1.Rows(Fila).Cells("Codigo").Value
                v_13 = metroGrid1.Rows(Fila).Cells("Detalle").Value
                v_4 = Convert.ToDouble(metroGrid1.Rows(Fila).Cells("Precio").Value)
                v_5 = Convert.ToDouble(metroGrid1.Rows(Fila).Cells("Cantidad").Value)
                v_6 = Convert.ToDouble(metroGrid1.Rows(Fila).Cells("SubTotal").Value)
                v_7 = Convert.ToDouble(metroGrid1.Rows(Fila).Cells("Dsto").Value)
                v_8 = Convert.ToDouble(metroGrid1.Rows(Fila).Cells("Total").Value)
                v_2 = Convert.ToInt16(metroGrid1.Rows(Fila).Cells("Lista").Value)
                v_20 = Convert.ToDouble(metroGrid1.Rows(Fila).Cells("PrecioConDsto").Value)
                v_26 = Convert.ToDouble(metroGrid1.Rows(Fila).Cells("Iva").Value)

                v_15 = Fila + 1


                sql = ""
                sql = "Insert Into Tickets (TicketNro,Lista,Codigo,Detalle,Alicuota,Precio,Cantidad,Subtotal,Dsto,PrecioConDsto,"
                sql = sql & "Total,Totaloperacion,Nombre,Cliente,ClienteNombre,Fecha,Orden,Documento,Cuit,"
                sql = sql & "CalidadRespo,Contado,"
                sql = sql & "DstoGenerAplic,ImpDstoGenerAplic,IncGenerAplic,ImpIncGenerAplic,ImpConDstoGenerAplic,"
                sql = sql & "Ua,Fa,Ha,Estado) Values ("
                sql = sql & "" & v_1 & "," & v_2 & ",'" & v_3 & "','" & v_13 & "'," & v_26 & "," & v_4 & "," & v_5 & "," & v_6 & "," & v_7 & "," & v_20 & ","
                sql = sql & "" & v_8 & "," & v_9 & ",'" & v_10 & "'," & v_11 & ",'" & v_12 & "','" & v_14 & "'," & v_15 & "," & v_16 & "," & v_17 & ","
                sql = sql & "" & v_18 & "," & v_19 & ","
                sql = sql & "" & v_21 & "," & v_22 & "," & v_24 & "," & v_25 & "," & v_23 & ","
                sql = sql & "" & j1 & ",'" & j2 & "','" & j3 & "',0)"


                Dim cmdActualizar As New OleDbCommand(sql, ConSql)
                cmdActualizar.ExecuteNonQuery()
                cmdActualizar.Dispose()


            Next


            If proc_vta = 1 Then

                If reser_Ticket <> 0 And reser_accion = 1 Then
                    marcar_modificado()
                End If

                If reser_Ticket <> 0 And reser_accion = 1 Then
                    Me.Close()
                    Exit Sub
                End If

            End If

            If proc_vta = 2 Then

                If reser_Ticket <> 0 And reser_accion = 1 Then
                    marcar_modificado()
                End If

                Dim Formulario_open As New Form25(v_1, 1)
                Formulario_open.ShowDialog()

            End If

            If proc_vta = 3 Then

                Call impresion_cupon_devolucion(v_1, 2)

                If reser_Ticket <> 0 And reser_accion = 1 Then
                    marcar_modificado()
                End If

                If reser_Ticket <> 0 And reser_accion = 1 Then
                    Me.Close()
                    Exit Sub
                End If

            End If

            nuevo_tickets()



        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConSql.Close()

        End Try

    End Sub
    Private Sub marcar_modificado()
        Try

            Dim sql As String = ""

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")

            Sql = ""
            sql = "Update Tickets Set Estado=8,Ua=" & j1 & ",Fa='" & j2 & "',Ha='" & j3 & "' WHERE TicketNro= " & reser_Ticket & ""

            Dim cmdActualizar As New OleDbCommand(sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)


        End Try
    End Sub
    Private Sub MetroButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton5.Click
        MetroPanel1.Enabled = True
        MetroPanel2.Enabled = True
        MetroPanel3.Visible = False

        MetroTextBox0.Focus()


    End Sub



    Private Sub MetroTextBox26_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox26.Validated
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

    Private Sub MetroTextBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTextBox9.Click

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
                    MetroTextBox26.Text = drRecordSet("Responsable").ToString
                    MetroTextBox14.Text = drRecordSet("Cuit").ToString

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
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try


    End Sub

   
    Private Sub MetroButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton7.Click


        If MetroTextBox9.Text.Trim <> "" Then
            If MetroCheckBox1.Checked = True Then
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
        End If

        Call proceso_de_venta(2)
    End Sub

    Private Sub MetroTextBox20_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox20.Validated
        verificar_descuento()
    End Sub
    Private Sub verificar_descuento()

        MetroTextBox21.Text = "0.00"


        If MetroTextBox20.Text = "" Then
            MetroTextBox20.Text = "0.00"
        End If

        If MetroTextBox20.Text = "0" Then
            MetroTextBox20.Text = "0.00"
        End If

        If Convert.ToDouble(MetroTextBox20.Text) = 0 Then
            MetroTextBox19.Text = MetroTextBox11.Text
            Exit Sub
        End If
        If Convert.ToDouble(MetroTextBox11.Text) = 0 Then
            MetroTextBox19.Text = MetroTextBox11.Text
            Exit Sub
        End If


        Dim Aux As Double = 0
        Aux = Math.Round(Convert.ToDouble(MetroTextBox11.Text) * Convert.ToDouble(MetroTextBox20.Text) / 100, 2)
        MetroTextBox21.Text = FormatNumber(Aux, 2)
        Aux = Math.Round(Convert.ToDouble(MetroTextBox11.Text) - Aux, 2)
        MetroTextBox19.Text = FormatNumber(Aux, 2)
        MetroTextBox20.Text = FormatNumber(Convert.ToDouble(MetroTextBox20.Text), 2)


    End Sub

    Private Sub MetroTextBox22_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox22.Validated

        MetroTextBox23.Text = "0.00"

        If MetroTextBox20.Text = "" Then
            MetroTextBox20.Text = "0.00"
            MetroTextBox21.Text = "0.00"
        End If
        If MetroTextBox22.Text = "" Then
            MetroTextBox22.Text = "0.00"
            MetroTextBox23.Text = "0.00"
        End If

        If MetroTextBox22.Text = "0" Then
            MetroTextBox22.Text = "0.00"
            MetroTextBox23.Text = "0.00"
        End If

        If Convert.ToDouble(MetroTextBox20.Text.Trim) <> 0 Then
            MetroTextBox22.Text = "0.00"
            MetroTextBox23.Text = "0.00"
            Exit Sub
        End If

        verificar_incremento()
    End Sub
    Private Sub verificar_incremento()

        MetroTextBox23.Text = "0.00"


        If MetroTextBox22.Text = "" Then
            MetroTextBox22.Text = "0.00"
        End If
        If Convert.ToDouble(MetroTextBox22.Text) = 0 Then
            MetroTextBox19.Text = MetroTextBox11.Text
            Exit Sub
        End If
        If Convert.ToDouble(MetroTextBox11.Text) = 0 Then
            MetroTextBox19.Text = MetroTextBox11.Text
            Exit Sub
        End If


        Dim Aux As Double = 0
        Aux = Math.Round(Convert.ToDouble(MetroTextBox11.Text) * Convert.ToDouble(MetroTextBox22.Text) / 100, 2)
        MetroTextBox23.Text = FormatNumber(Aux, 2)
        Aux = Math.Round(Convert.ToDouble(MetroTextBox11.Text) + Aux, 2)
        MetroTextBox19.Text = FormatNumber(Aux, 2)
        MetroTextBox22.Text = FormatNumber(Convert.ToDouble(MetroTextBox22.Text), 2)


    End Sub
 

    Private Sub MetroButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton8.Click

        Dim Aux1 As Double = 0
        Dim Aux2 As Double = 0

        If MetroTextBox21.Text.Trim <> "" Then
            Aux1 = CDbl(MetroTextBox21.Text.Trim)
        End If
        If MetroTextBox23.Text.Trim <> "" Then
            Aux2 = CDbl(MetroTextBox23.Text.Trim)
        End If

        Dim x1 As String = ""
        Dim x2 As String = ""
        Dim x3 As String = ""
        Dim x4 As String = ""
        Dim x5 As String = ""
        Dim x6 As String = ""
        Dim x7 As String = ""
        Dim x8 As String = ""
        Dim x9 As String = ""
        Dim x10 As String = ""

        If Aux1 > 0 Then
            x1 = "D-A"
            x2 = "1"
            x3 = "DESCUENTO APLICADO"
            x4 = FormatNumber(Aux1 * -1, 2)
            x5 = "1.00"
            x6 = FormatNumber(Aux1 * -1, 2)
            x7 = "0.00"
            x8 = FormatNumber(Aux1 * -1, 2)
            x9 = FormatNumber(Aux1 * -1, 2)
            x10 = "21.00"


            With metroGrid1
                .Rows.Add()
                .Item(0, h).Value = x1
                .Item(1, h).Value = x2
                .Item(2, h).Value = x3
                .Item(3, h).Value = x10
                .Item(4, h).Value = x4
                .Item(5, h).Value = x5
                .Item(6, h).Value = x6
                .Item(7, h).Value = x7
                .Item(8, h).Value = x8
                .Item(9, h).Value = x9
                h = h + 1
            End With
        End If

        If Aux2 > 0 Then
            x1 = "I-A"
            x2 = "1"
            x3 = "INCREMENTO APLICADO"
            x4 = FormatNumber(Aux2, 2)
            x5 = "1.00"
            x6 = FormatNumber(Aux2, 2)
            x7 = "0.00"
            x8 = FormatNumber(Aux2, 2)
            x9 = FormatNumber(Aux2, 2)
            x10 = "21.00"


            With metroGrid1
                .Rows.Add()
                .Item(0, h).Value = x1
                .Item(1, h).Value = x2
                .Item(2, h).Value = x3
                .Item(3, h).Value = x10
                .Item(4, h).Value = x4
                .Item(5, h).Value = x5
                .Item(6, h).Value = x6
                .Item(7, h).Value = x7
                .Item(8, h).Value = x8
                .Item(9, h).Value = x9
                h = h + 1
            End With
        End If


        MetroTextBox20.Text = "0.00"
        MetroTextBox21.Text = "0.00"
        MetroTextBox22.Text = "0.00"
        MetroTextBox23.Text = "0.00"

        suma_grilla()
        inicializo_parciales()
        MetroTextBox0.Focus()
    End Sub

    Private Sub MetroButton9_Click(sender As Object, e As EventArgs) Handles MetroButton9.Click
        If MetroTextBox9.Text.Trim <> "" Then
            If MetroCheckBox1.Checked = True Then
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
        End If


        Call proceso_de_venta(3)
    End Sub

    Private Sub MetroTextBox3_Click(sender As Object, e As EventArgs) Handles MetroTextBox3.Click

    End Sub

    Private Sub MetroTextBox24_Click(sender As Object, e As EventArgs) Handles MetroTextBox24.Click

    End Sub

    Private Sub MetroTextBox24_Validated(sender As Object, e As EventArgs) Handles MetroTextBox24.Validated
        If MetroTextBox24.Text.Trim = "" Then
            MetroTextBox24.Text = "21.00"
        End If
        MetroTextBox24.Text = formatea_importe(MetroTextBox24.Text.Trim)
    End Sub

    Private Sub MetroTextBox0_Click(sender As Object, e As EventArgs) Handles MetroTextBox0.Click

    End Sub

    Private Sub MetroTextBox0_ContextMenuStripChanged(sender As Object, e As EventArgs) Handles MetroTextBox0.ContextMenuStripChanged

    End Sub
End Class

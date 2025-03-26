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


Public Class Form26
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)
    Dim reser_Ticket As Double = 0
    Dim reser_accion As Byte = 0

    Dim reser_neto As Double = 0
    Dim reser_importe_iva As Double = 0
    Dim reser_alicuota_iva As Double = 0
    Dim reser_total As Double = 0
    Dim reser_tipo_respo As Byte = 0
    Dim reser_letra_compro As String = " "
    Dim reser_numero_compro As String = " "
    Dim reser_contado As Byte = 0

    Dim h As Integer = 0
    Public Sub New(ByVal v_Ticket As Double, ByVal v_accion As Byte)
        InitializeComponent()
        reser_Ticket = v_Ticket
        reser_accion = v_accion
    End Sub
    Private Sub Form26_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        inicializa_form()
        lectura_ticket()
        If reser_accion = 3 Then
            Me.Text = "Generación de Presupuesto"
        End If
        If reser_accion = 4 Then
            Me.Text = "Generación de Remito"
        End If
    End Sub
    Private Sub inicializa_form()
        MetroTextBox8.Text = ""
        MetroTextBox15.Text = ""
        MetroTextBox26.Text = "2"
        MetroTextBox14.Text = ""
        MetroTextBox9.Text = ""
        MetroTextBox12.Text = ""
        MetroTextBox10.Text = ""
        MetroTextBox12.Text = ""
        MetroTextBox16.Text = ""
        MetroTextBox13.Text = "CONSUMIDOR FINAL"
    End Sub
    Private Sub lectura_ticket()
        Try

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim Sql As String = ""
            Sql = "Select * from Tickets WHERE (TicketNro= " & reser_Ticket & ") And (Orden=1)"


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    MetroTextBox8.Text = drRecordSet("Nombre").ToString
                    MetroTextBox15.Text = drRecordSet("Documento").ToString
                    MetroTextBox9.Text = drRecordSet("Cliente").ToString
                    MetroTextBox10.Text = drRecordSet("ClienteNombre").ToString
                    MetroTextBox26.Text = drRecordSet("CalidadRespo").ToString
                    If Val(drRecordSet("Cuit").ToString) <> 0 Then
                        MetroTextBox14.Text = drRecordSet("Cuit").ToString
                    End If
                    MetroTextBox20.Text = FormatNumber(Convert.ToDouble(drRecordSet("TotalOperacion").ToString), 2)
                    MetroTextBox1.Text = FormatNumber(Convert.ToDouble(drRecordSet("DstoGenerAplic").ToString), 2)
                    MetroTextBox2.Text = FormatNumber(Convert.ToDouble(drRecordSet("ImpDstoGenerAplic").ToString), 2)
                    MetroTextBox3.Text = FormatNumber(Convert.ToDouble(drRecordSet("ImpConDstoGenerAplic").ToString), 2)
                End If
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
        rsv_prg_orig = "Form26"
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
                    MetroTextBox26.Text = drRecordSet("Responsable").ToString
                    MetroTextBox14.Text = drRecordSet("Cuit").ToString
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
    
    
 

#Region "ControlText"
    
    
   
    Private Sub metroTextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox12.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
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


    Private Sub MetroButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton4.Click


        If MetroTextBox26.Text.Trim = "" Then
            MetroTextBox26.Text = 2
        End If

        If MetroTextBox10.Text.Trim = "" Then
            MetroTextBox10.Text = MetroTextBox8.Text.Trim
        End If


        reser_tipo_respo = Val(MetroTextBox26.Text)

        If reser_tipo_respo = 2 Then
            MetroTextBox14.Text = ""
        End If

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


        generacion_operacion()


    End Sub
    Private Sub generacion_operacion()
        Try

            Dim x1 As Double
            Dim x2 As Double
            Dim x3 As String
            Dim x4 As String
            Dim x5 As Double
            Dim x6 As Byte
            Dim x7 As Double
            Dim x8 As Double
            Dim x9 As String
            Dim x10 As String
            Dim x11 As Byte
            Dim x12 As String
            Dim x13 As String
            Dim x14 As Double
            Dim x15 As Double
            Dim x16 As Double
            Dim x17 As Double
            Dim x18 As Double
            Dim x19 As Double
            Dim x20 As String

            Dim x21 As Double
            Dim x22 As Double
            Dim x23 As Double


            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")

       
     
            x1 = reser_Ticket
            x2 = numeradorAutomatico(1, 2, 2)
            x3 = j2

            x4 = " "
            If MetroTextBox10.Text.Trim <> "" Then
                x4 = MetroTextBox10.Text.Trim
            End If

            x5 = 0
            If MetroTextBox15.Text.Trim <> "" Then
                x5 = CDbl(MetroTextBox15.Text.Trim)
            End If
            x6 = reser_tipo_respo
            x7 = 0
            If MetroTextBox14.Text.Trim <> "" Then
                x7 = CDbl(MetroTextBox14.Text.Trim)
            End If
            x8 = 0
            If MetroTextBox9.Text.Trim <> "" Then
                x8 = CDbl(MetroTextBox9.Text.Trim)
            End If
            x9 = " "
            If MetroTextBox10.Text.Trim <> "" Then
                x9 = MetroTextBox10.Text.Trim
            End If
            x10 = " "
            If MetroTextBox16.Text.Trim <> "" Then
                x10 = MetroTextBox16.Text.Trim
            End If

            x20 = " "
            If MetroTextBox12.Text.Trim <> "" Then
                x20 = MetroTextBox12.Text.Trim
            End If

            Dim h As Byte = 0

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

                    h = h + 1

                    x11 = Val(drRecordSet("Lista").ToString)
                    x12 = drRecordSet("Codigo").ToString
                    x13 = drRecordSet("Detalle").ToString
                    x14 = Convert.ToDouble(drRecordSet("Precio").ToString)
                    x15 = Convert.ToDouble(drRecordSet("Cantidad").ToString)
                    x16 = Convert.ToDouble(drRecordSet("Subtotal").ToString)
                    x17 = Convert.ToDouble(drRecordSet("Dsto").ToString)
                    x18 = Convert.ToDouble(drRecordSet("Total").ToString)
                    x19 = Convert.ToDouble(drRecordSet("TotalOperacion").ToString)

                    x21 = Convert.ToDouble(drRecordSet("DstoGenerAplic").ToString)
                    x22 = Convert.ToDouble(drRecordSet("ImpDstoGenerAplic").ToString)
                    x23 = Convert.ToDouble(drRecordSet("ImpConDstoGenerAplic").ToString)


                    If reser_accion = 3 Then
                        Sql = "Insert Into Presupuestos ("
                        Sql = Sql & "TicketNro, PresupuestoNro, Fecha, Nombre, Documento, TipoResponsable, Cuit,"
                        Sql = Sql & "Cliente, RazonSocial, Domicilio, Lista, Codigo, Detalle, Precio, Cantidad, SubTotal,"
                        Sql = Sql & "Dsto, Total, TotalOperacion, Observacion,Orden,DstoGenerAplic,ImpDstoGenerAplic,ImpConDstoGenerAplic,"
                        Sql = Sql & "Ua, Fa, Ha,Estado) Values ("
                        Sql = Sql & "" & x1 & "," & x2 & ",'" & x3 & "','" & x4 & "'," & x5 & "," & x6 & "," & x7 & ","
                        Sql = Sql & "" & x8 & ",'" & x9 & "','" & x10 & "'," & x11 & ",'" & x12 & "','" & x13 & "'," & x14 & "," & x15 & "," & x16 & ","
                        Sql = Sql & "" & x17 & "," & x18 & "," & x19 & ",'" & x20 & "'," & h & "," & x21 & "," & x22 & "," & x23 & ","
                        Sql = Sql & "" & j1 & ",'" & j2 & "','" & j3 & "',0)"
                    End If

                    If reser_accion = 4 Then
                        Sql = "Insert Into Remitos ("
                        Sql = Sql & "TicketNro, RemitoNro, Fecha, Nombre, Documento, TipoResponsable, Cuit,"
                        Sql = Sql & "Cliente, RazonSocial, Domicilio, Lista, Codigo, Detalle, Precio, Cantidad, SubTotal,"
                        Sql = Sql & "Dsto, Total, TotalOperacion, Observacion,Orden,DstoGenerAplic,ImpDstoGenerAplic,ImpConDstoGenerAplic,"
                        Sql = Sql & "Ua, Fa, Ha,Estado) Values ("
                        Sql = Sql & "" & x1 & "," & x2 & ",'" & x3 & "','" & x4 & "'," & x5 & "," & x6 & "," & x7 & ","
                        Sql = Sql & "" & x8 & ",'" & x9 & "','" & x10 & "'," & x11 & ",'" & x12 & "','" & x13 & "'," & x14 & "," & x15 & "," & x16 & ","
                        Sql = Sql & "" & x17 & "," & x18 & "," & x19 & ",'" & x20 & "'," & h & "," & x21 & "," & x22 & "," & x23 & ","
                        Sql = Sql & "" & j1 & ",'" & j2 & "','" & j3 & "',0)"
                    End If

                    Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
                    cmdActualizar.ExecuteNonQuery()
                    cmdActualizar.Dispose()

                Loop
            End If
            drRecordSet.Close()

            If reser_accion = 3 Then
                impresion_presupuesto(x2)
            End If

            If reser_accion = 4 Then
                impresion_remito(x2)
            End If

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

   
    Private Sub MetroButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton5.Click
        Me.Close()
    End Sub
End Class

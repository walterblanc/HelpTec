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


Public Class Form74
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

#Region "ControlText"
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
   
  
#End Region
    Private Sub Form74_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        inicializa_form()
    End Sub
    Private Sub inicializa_form()

        MetroDateTime1.Value = Now.Date
  
    
        MetroTextBox9.Text = ""
        MetroTextBox10.Text = ""
        MetroTextBox11.Text = ""
     
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


    Private Function comprobanteExistenteIva(ByVal xfecha As Date, ByVal xTipo As String, ByVal xLetra As String, ByVal xNumero As String) As Boolean
        Dim Retorno_funcion As Boolean
        Retorno_funcion = False

        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim cmdTemp As New OleDbCommand("Select * from Iva_Ventas Where TipoComprobante='" & xTipo & "' And LetraComprobante = '" & xLetra & "' And NumeroComprobante = '" & xNumero & "'  And Estado = 0", ConSql)
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

   

    Private Sub MetroTextBox10_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox10.Validated
        MetroTextBox10.Text = MetroTextBox10.Text.Trim.ToUpper
    End Sub



  
    
    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        Call grabar_comprobante(True)
    End Sub

    Private Sub grabar_comprobante(ByVal xContado As Boolean)
        Dim ok As Boolean
        ok = True
     

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

        Dim xTipo As String = ""
        If MetroRadioButton1.Checked = True Then
            xTipo = "FA"
        End If
        If MetroRadioButton2.Checked = True Then
            xTipo = "ND"
        End If
        If MetroRadioButton3.Checked = True Then
            xTipo = "NC"
        End If

        Dim xfec As String = ""
        Dim xlet As String = ""
        Dim xnro As String = ""
        xfec = FormatDateTime(MetroDateTime1.Text, DateFormat.ShortDate) '10/01/2009
        xnro = Formatea_Numero_Comprobante(Val(MetroTextBox9.Text.Trim), Val(MetroTextBox11.Text.Trim))
        xlet = MetroTextBox10.Text.Trim

        If comprobanteExistenteIva(xfec, xTipo, xlet, xnro) = True Then
            MetroFramework.MetroMessageBox.Show(Me, "El comprobante existe en el libro de iva ventas", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ok = False

        End If

        Call imputarIva()

        nuevo_comprobante()

    End Sub
    Private Sub imputarIva()
        Try
            Dim sql As String = " "
            Dim xTipo As String = " "
         

        
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

            Dim a7 As String = ""
            a7 = MetroTextBox10.Text.Trim
            Dim a8 As String = ""
            Dim a9 As Byte = 0

            a8 = Formatea_Numero_Comprobante(Val(MetroTextBox9.Text.Trim), Val(MetroTextBox11.Text.Trim))

            If a7 = "A" Then
                A9 = 1
            Else
                A9 = 2
            End If

            sql = ""
            sql = "Insert Into Iva_Ventas (Fecha,FechaImputacion,TipoComprobante,"
            sql = sql & "TipoResponsable,Cuit,LetraComprobante,NumeroComprobante,"
            sql = sql & "Cliente,Nombre,"
            sql = sql & "UsuarioAlta,FechaAlta,HoraAlta,Estado) "
            sql = sql & "Values ("
            sql = sql & "'" & a1 & "','" & a1 & "','" & xTipo & "',"
            sql = sql & "" & A9 & ",0,'" & a7 & "','" & a8 & "',"
            sql = sql & "0,'COMPROBANTE CANCELADO',"
            sql = sql & "" & j1 & ",'" & j2 & "','" & j3 & "',0)"
    
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

        MetroTextBox9.Text = ""
        MetroTextBox10.Text = ""
        MetroTextBox11.Text = ""
     
        MetroDateTime1.Focus()

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
    Private Sub MetroButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton4.Click
        Me.Close()
    End Sub

    
End Class

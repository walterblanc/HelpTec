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


Public Class Form22
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)
    Dim modalidad As Byte = 0
#Region "controles Text"
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

#End Region


    Private Sub Form22_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MetroTextBox0.Text = ""
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox4.Text = ""
        MetroTextBox5.Text = "1"
        MetroTextBox6.Text = ""
        MetroTextBox20.Text = ""
        MetroTextBox21.Text = ""
        MetroTextBox24.Text = ""
        MetroTextBox25.Text = ""

        MetroTextBox9.Text = "0.00"
        MetroTextBox10.Text = "0.00"
        MetroTextBox22.Text = "0.00"
        MetroTextBox23.Text = "0.00"

        MetroPanel1.Enabled = True
        MetroPanel2.Visible = False
    End Sub



    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        Me.Close()
    End Sub

  

    Private Sub MetroButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton4.Click
        If valida_existencia(MetroTextBox0.Text.Trim) = True Then
            modifica_articulo()
        End If

    End Sub
    Private Sub nuevo_articulo()
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox4.Text = ""
        MetroTextBox6.Text = ""
        MetroTextBox20.Text = ""
        MetroTextBox21.Text = ""
        MetroTextBox24.Text = ""
        MetroTextBox25.Text = ""

        MetroTextBox9.Text = "0.00"
        MetroTextBox10.Text = "0.00"
        MetroTextBox22.Text = "0.00"
        MetroTextBox23.Text = "0.00"

        MetroPanel1.Enabled = False
        MetroPanel2.Visible = True

        MetroTextBox1.Focus()

    End Sub
   
    Private Sub modifica_articulo()
        Try
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

                    MetroTextBox1.Text = drRecordSet("CodigoProveedor").ToString
                    MetroTextBox2.Text = drRecordSet("CodigoBarra").ToString
                    MetroTextBox3.Text = drRecordSet("Detalle").ToString
                    MetroTextBox4.Text = drRecordSet("Proveedor").ToString

                    If Val(drRecordSet("AplicaIva").ToString) = 1 Then
                        MetroCheckBox1.Checked = True
                    Else
                        MetroCheckBox1.Checked = False
                    End If

                    MetroTextBox9.Text = FormatNumber(Convert.ToDouble(drRecordSet("Alicuota").ToString), 2)


                    MetroTextBox10.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio1").ToString), 2)
                    If MetroTextBox5.Text.Trim = 1 Then
                        MetroTextBox10.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio1").ToString), 2)
                    End If
                    If MetroTextBox5.Text.Trim = 2 Then
                        MetroTextBox10.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio2").ToString), 2)
                    End If
                    If MetroTextBox5.Text.Trim = 3 Then
                        MetroTextBox10.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio3").ToString), 2)
                    End If
                    If MetroTextBox5.Text.Trim = 4 Then
                        MetroTextBox10.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio4").ToString), 2)
                    End If
                    If MetroTextBox5.Text.Trim = 5 Then
                        MetroTextBox10.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio5").ToString), 2)
                    End If
                    If MetroTextBox5.Text.Trim = 6 Then
                        MetroTextBox10.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio6").ToString), 2)
                    End If
                    If MetroTextBox5.Text.Trim = 7 Then
                        MetroTextBox10.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio7").ToString), 2)
                    End If
                    If MetroTextBox5.Text.Trim = 8 Then
                        MetroTextBox10.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio8").ToString), 2)
                    End If
                    If MetroTextBox5.Text.Trim = 9 Then
                        MetroTextBox10.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio9").ToString), 2)
                    End If
                    If MetroTextBox5.Text.Trim = 10 Then
                        MetroTextBox10.Text = FormatNumber(Convert.ToDouble(drRecordSet("Precio10").ToString), 2)
                    End If

                    MetroTextBox20.Text = drRecordSet("Sector").ToString
                    MetroTextBox21.Text = drRecordSet("Estanteria").ToString

                    MetroTextBox22.Text = FormatNumber(Convert.ToDouble(drRecordSet("Existencia").ToString), 2)
                    MetroTextBox23.Text = FormatNumber(Convert.ToDouble(drRecordSet("ExisMini").ToString), 2)

                    MetroTextBox24.Text = drRecordSet("Rubro").ToString


                    MetroPanel1.Enabled = False
                    MetroPanel2.Visible = True

                    MetroTextBox1.Focus()

                End If
            End If

            drRecordSet.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub MetroTextBox9_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox9.Validated
        MetroTextBox9.Text = formatea_importe(MetroTextBox9.Text.Trim)
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

    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        MetroPanel2.Visible = False
        MetroPanel1.Enabled = True
    End Sub

    Private Sub MetroTextBox0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTextBox0.Click

    End Sub
End Class

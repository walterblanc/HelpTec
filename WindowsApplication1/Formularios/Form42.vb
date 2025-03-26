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


Public Class Form42
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Dim reser_proveedor As Double = 0
    Public Sub New(ByVal v_proveedor As Double)
        InitializeComponent()
        reser_proveedor = v_proveedor
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

   

    Private Sub Form42_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        inicializo_formulario()
        cargarCOMBO(MetroComboBox1, 2)
        cargo_proveedor()
        GroupBox1.Enabled = False
    End Sub
    Private Sub inicializo_formulario()
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
        MetroTextBox12.Text = "0.00"

        MetroCheckBox1.Checked = True
        MetroCheckBox2.Checked = True
        MetroCheckBox3.Checked = True
        MetroCheckBox4.Checked = True
        MetroCheckBox5.Checked = True
        MetroCheckBox6.Checked = True
        MetroCheckBox7.Checked = True
        MetroCheckBox8.Checked = True
        MetroCheckBox9.Checked = True
        MetroCheckBox10.Checked = True


    End Sub
   
  
    Private Sub cargo_proveedor()
        Dim r As Integer = 1
        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim Sql As String = ""
            Sql = "Select * from Proveedores WHERE (Numero= " & reser_proveedor & ") And (Estado=0) "


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    MetroTextBox1.Text = drRecordSet("Numero").ToString
                    MetroTextBox2.Text = drRecordSet("RazonSocial").ToString
                    MetroTextBox3.Text = drRecordSet("Comercial").ToString
                    MetroTextBox4.Text = drRecordSet("Domicilio").ToString
                    MetroTextBox5.Text = drRecordSet("Ciudad").ToString
                    MetroTextBox6.Text = drRecordSet("Provincia").ToString
                    MetroTextBox7.Text = drRecordSet("Telefono").ToString
                    MetroTextBox8.Text = drRecordSet("Celular").ToString
                    MetroTextBox9.Text = drRecordSet("Contacto").ToString
                    MetroTextBox10.Text = drRecordSet("email").ToString
                    MetroTextBox11.Text = drRecordSet("Cuit").ToString


                    Call buscarCombo(MetroComboBox1, Val(drRecordSet("Responsable").ToString))

                    MetroTextBox1.Enabled = False
                    MetroTextBox2.Focus()



                End If
            End If

            drRecordSet.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
  
    Private Sub MetroButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub

    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        If MetroTextBox12.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar porcentaje de incremento", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If MetroCheckBox1.Checked = True Then
            Call actualizar_precios(Convert.ToDouble(MetroTextBox1.Text.Trim), Convert.ToDouble(MetroTextBox12.Text.Trim), 1)
        End If
        If MetroCheckBox2.Checked = True Then
            Call actualizar_precios(Convert.ToDouble(MetroTextBox1.Text.Trim), Convert.ToDouble(MetroTextBox12.Text.Trim), 2)
        End If
        If MetroCheckBox3.Checked = True Then
            Call actualizar_precios(Convert.ToDouble(MetroTextBox1.Text.Trim), Convert.ToDouble(MetroTextBox12.Text.Trim), 3)
        End If
        If MetroCheckBox4.Checked = True Then
            Call actualizar_precios(Convert.ToDouble(MetroTextBox1.Text.Trim), Convert.ToDouble(MetroTextBox12.Text.Trim), 4)
        End If
        If MetroCheckBox5.Checked = True Then
            Call actualizar_precios(Convert.ToDouble(MetroTextBox1.Text.Trim), Convert.ToDouble(MetroTextBox12.Text.Trim), 5)
        End If
        If MetroCheckBox6.Checked = True Then
            Call actualizar_precios(Convert.ToDouble(MetroTextBox1.Text.Trim), Convert.ToDouble(MetroTextBox12.Text.Trim), 6)
        End If
        If MetroCheckBox7.Checked = True Then
            Call actualizar_precios(Convert.ToDouble(MetroTextBox1.Text.Trim), Convert.ToDouble(MetroTextBox12.Text.Trim), 7)
        End If
        If MetroCheckBox8.Checked = True Then
            Call actualizar_precios(Convert.ToDouble(MetroTextBox1.Text.Trim), Convert.ToDouble(MetroTextBox12.Text.Trim), 8)
        End If
        If MetroCheckBox9.Checked = True Then
            Call actualizar_precios(Convert.ToDouble(MetroTextBox1.Text.Trim), Convert.ToDouble(MetroTextBox12.Text.Trim), 9)
        End If
        If MetroCheckBox10.Checked = True Then
            Call actualizar_precios(Convert.ToDouble(MetroTextBox1.Text.Trim), Convert.ToDouble(MetroTextBox12.Text.Trim), 10)
        End If

        MetroFramework.MetroMessageBox.Show(Me, "Listas Incrementadas", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)



    End Sub
    Private Sub actualizar_precios(ByVal xPr As Double, ByVal xIn As Double, ByVal xTip As Byte)
        Try

 
            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")



            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim Sql As String = ""

            If xTip = 1 Then
                Sql = "Update Articulos SET PRECIO1 = round(precio1 + (PRECIO1 * " & xIn & " /100),2) WHERE Proveedor = " & xPr & "  "
            End If
            If xTip = 2 Then
                Sql = "Update Articulos SET PRECIO2 = round(precio2 + (PRECIO2 * " & xIn & " /100),2) WHERE Proveedor = " & xPr & "  "
            End If
            If xTip = 3 Then
                Sql = "Update Articulos SET PRECIO3 = round(precio3 + (PRECIO3 * " & xIn & " /100),2) WHERE Proveedor = " & xPr & "  "
            End If
            If xTip = 4 Then
                Sql = "Update Articulos SET PRECIO4 = round(precio4 + (PRECIO4 * " & xIn & " /100),2) WHERE Proveedor = " & xPr & "  "
            End If
            If xTip = 5 Then
                Sql = "Update Articulos SET PRECIO5 = round(precio5 + (PRECIO5 * " & xIn & " /100),2) WHERE Proveedor = " & xPr & "  "
            End If


            If xTip = 6 Then
                Sql = "Update Articulos SET PRECIO6 = round(precio6 + (PRECIO6 * " & xIn & " /100),2) WHERE Proveedor = " & xPr & "  "
            End If
            If xTip = 7 Then
                Sql = "Update Articulos SET PRECIO7 = round(precio7 + (PRECIO7 * " & xIn & " /100),2) WHERE Proveedor = " & xPr & "  "
            End If
            If xTip = 8 Then
                Sql = "Update Articulos SET PRECIO8 = round(precio8 + (PRECIO8 * " & xIn & " /100),2) WHERE Proveedor = " & xPr & "  "
            End If
            If xTip = 9 Then
                Sql = "Update Articulos SET PRECIO9 = round(precio9 + (PRECIO9 * " & xIn & " /100),2) WHERE Proveedor = " & xPr & "  "
            End If
            If xTip = 10 Then
                Sql = "Update Articulos SET PRECIO10 = round(precio10 + (PRECIO10 * " & xIn & " /100),2) WHERE Proveedor = " & xPr & "  "
            End If


            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()


            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub MetroTextBox12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTextBox12.Click

    End Sub

   
    Private Sub MetroTextBox12_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox12.Validated
        If MetroTextBox12.Text.Trim <> "" Then
            MetroTextBox12.Text = FormatNumber(Convert.ToDouble(MetroTextBox12.Text.Trim), 2)
        End If
    End Sub
End Class

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


Public Class Form57
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)
    Dim reser_Id As Double = 0
   
    Dim h As Integer = 0
    Public Sub New(ByVal v_Id As Double)
        InitializeComponent()
        reser_Id = v_Id
    End Sub
    Private Sub Form57_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        inicializa_form()
        lectura_valor()
        lectura_cliente()
       
    End Sub
    Private Sub inicializa_form()

        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox4.Text = ""
        MetroTextBox5.Text = ""
        MetroTextBox6.Text = ""
        MetroTextBox7.Text = ""
        MetroTextBox9.Text = ""
        MetroTextBox10.Text = ""
        MetroTextBox16.Text = ""
        MetroTextBox17.Text = ""
        MetroTextBox18.Text = ""

        MetroTextBox8.Text = ""
        MetroTextBox15.Text = ""
        MetroTextBox26.Text = ""
        MetroTextBox13.Text = ""
        MetroTextBox14.Text = ""
        MetroTextBox11.Text = ""
        MetroTextBox12.Text = ""
        MetroCheckBox1.Checked = False

    End Sub
    Private Sub lectura_valor()
        Try

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim Sql As String = ""
            Sql = "Select * from Valores_recibidos_ventas WHERE (Id= " & reser_Id & ") "


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    MetroTextBox9.Text = drRecordSet("Cliente").ToString
                    MetroDateTime1.Value = drRecordSet("Fecha").ToString
                    MetroDateTime2.Value = drRecordSet("Emision").ToString
                    MetroDateTime3.Value = drRecordSet("Pago").ToString

                    If Val(drRecordSet("TipoComprobante").ToString) <> 0 Then
                        If Val(drRecordSet("TipoComprobante").ToString) = 1 Then
                            MetroTextBox1.Text = "FA"
                        End If
                        If Val(drRecordSet("TipoComprobante").ToString) = 2 Then
                            MetroTextBox1.Text = "ND"
                        End If
                        If Val(drRecordSet("TipoComprobante").ToString) = 3 Then
                            MetroTextBox1.Text = "FA"
                        End If
                        MetroTextBox2.Text = drRecordSet("LetraComprobante").ToString
                        MetroTextBox3.Text = drRecordSet("NumeroComprobante").ToString
                    End If

                    MetroTextBox4.Text = drRecordSet("Banco").ToString
                    MetroTextBox5.Text = parametroSistema(8, Val(drRecordSet("Banco").ToString))


                    MetroTextBox6.Text = drRecordSet("Numero").ToString
                    MetroTextBox7.Text = FormatNumber(Convert.ToDouble(drRecordSet("Importe").ToString), 2)


                    If Val(drRecordSet("Retirado").ToString) = 1 Then
                        MetroCheckBox1.Checked = True
                        MetroTextBox17.Text = drRecordSet("RetiradoNombre").ToString
                        MetroTextBox18.Text = FormatDateTime(drRecordSet("FechaRetiro").ToString, DateFormat.ShortDate)
                    End If

                End If
            End If
            drRecordSet.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    
    Private Sub lectura_cliente()
        Try

            If MetroTextBox9.Text.Trim = "" Then
                Exit Sub
            End If

            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim x As Double = Val(MetroTextBox9.Text.Trim)
            Dim Sql As String = ""
            Sql = "Select * from Clientes WHERE (Numero= " & x & ") And (Estado=0)"


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    MetroTextBox8.Text = drRecordSet("Comercial").ToString
                    MetroTextBox10.Text = drRecordSet("RazonSocial").ToString
                    MetroTextBox15.Text = drRecordSet("NumDoc").ToString
                    MetroTextBox16.Text = drRecordSet("Domicilio").ToString
                    MetroTextBox26.Text = drRecordSet("Responsable").ToString
                    MetroTextBox14.Text = drRecordSet("Cuit").ToString
                    MetroTextBox11.Text = drRecordSet("Telefono").ToString
                    MetroTextBox12.Text = drRecordSet("Celular").ToString
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
   

    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub
End Class

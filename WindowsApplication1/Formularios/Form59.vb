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


Public Class Form59
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)

    Dim h As Integer = 0
    Dim reser_Tipo As Integer = 0
    Dim reser_Letra As String = ""
    Dim reser_Nro As String = ""

    Public Sub New(ByVal v_Tipo As Integer, ByVal v_letra As String, ByVal v_nro As String)
        InitializeComponent()
        reser_Tipo = v_Tipo
        reser_Letra = v_letra
        reser_Nro = v_nro
    End Sub
    Private Sub Form59_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        inicio_formulario()
    End Sub
    Private Sub inicio_formulario()

       
   
        h = 0
        definir_grilla()

        lectura_resumen_ventas()
        lectura_detalle_ventas(1)
        lectura_detalle_ventas(2)


    End Sub
    Private Sub lectura_resumen_ventas()

        Try

         
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim Sql As String = ""
            Sql = "Select * from Ventas_resumen WHERE (Tipocomprobante= " & reser_Tipo & ") AND (LetraComprobante= '" & reser_Letra & "') AND (Numerocomprobante= '" & reser_Nro & "')"


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                Do While drRecordSet.Read

                    MetroTextBox1.Text = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)

                    If Convert.ToInt16(drRecordSet("Tipocomprobante").ToString) = 1 Then
                        MetroTextBox2.Text = "FA"
                    End If
                    If Convert.ToInt16(drRecordSet("Tipocomprobante").ToString) = 2 Then
                        MetroTextBox2.Text = "ND"
                    End If
                    If Convert.ToInt16(drRecordSet("Tipocomprobante").ToString) = 3 Then
                        MetroTextBox2.Text = "NC"
                    End If


                    If Convert.ToInt16(drRecordSet("Contado").ToString) = 1 Then
                        MetroCheckBox1.Checked = True
                    Else
                        MetroCheckBox1.Checked = False
                    End If


                    MetroTextBox2.Text = drRecordSet("Tipocomprobante").ToString
                    MetroTextBox3.Text = drRecordSet("LetraComprobante").ToString
                    MetroTextBox4.Text = drRecordSet("NumeroComprobante").ToString

                    If Val(drRecordSet("Cliente").ToString) <> 0 Then
                        MetroTextBox5.Text = drRecordSet("Cliente").ToString
                    Else
                        MetroTextBox5.Text = ""
                    End If

                    MetroTextBox6.Text = drRecordSet("RazonSocial").ToString
                    MetroTextBox7.Text = drRecordSet("Nombre").ToString
                    MetroTextBox8.Text = drRecordSet("Domicilio").ToString

                    MetroTextBox12.Text = FormatNumber(Convert.ToDouble(drRecordSet("TicketNro").ToString), 0)

                    MetroTextBox11.Text = FormatNumber(Convert.ToDouble(drRecordSet("Total").ToString), 2)

                    MetroTextBox9.Text = FormatNumber(Convert.ToDouble(drRecordSet("ImporteContado").ToString), 2)
                    MetroTextBox23.Text = FormatNumber(Convert.ToDouble(drRecordSet("Transferencia").ToString), 2)
                    MetroTextBox10.Text = FormatNumber(Convert.ToDouble(drRecordSet("Valores").ToString), 2)
                    MetroTextBox13.Text = FormatNumber(Convert.ToDouble(drRecordSet("Importe1").ToString) + Convert.ToDouble(drRecordSet("Importe2").ToString) + Convert.ToDouble(drRecordSet("Importe3").ToString), 2)

                    MetroTextBox14.Text = FormatNumber(Convert.ToDouble(drRecordSet("Neto105").ToString), 2)
                    MetroTextBox15.Text = FormatNumber(Convert.ToDouble(drRecordSet("Iva105").ToString), 2)
                    MetroTextBox16.Text = FormatNumber(Convert.ToDouble(drRecordSet("Neto21").ToString), 2)
                    MetroTextBox17.Text = FormatNumber(Convert.ToDouble(drRecordSet("Iva21").ToString), 2)
                    MetroTextBox22.Text = FormatNumber(Convert.ToDouble(drRecordSet("Exento").ToString), 2)

                Loop
            End If
            drRecordSet.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub lectura_detalle_ventas(ByVal x As Byte)

        Try


            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim Sql As String = ""

            If x = 1 Then
                Sql = "Select * from Ventas_detalle WHERE (Tipocomprobante= " & reser_Tipo & ") AND (LetraComprobante= '" & reser_Letra & "') AND (Numerocomprobante= '" & reser_Nro & "')"
            End If
            If x = 2 Then
                Sql = "Select * from Ventas_detalle_Afip WHERE (Tipocomprobante= " & reser_Tipo & ") AND (LetraComprobante= '" & reser_Letra & "') AND (Numerocomprobante= '" & reser_Nro & "')"
            End If


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                Do While drRecordSet.Read
                    With metroGrid1
                        .Rows.Add()
                        .Item(0, h).Value = drRecordSet("Codigo").ToString
                        .Item(1, h).Value = drRecordSet("Lista").ToString

                        If x = 1 Then
                            .Item(2, h).Value = drRecordSet("Detalle").ToString
                            .Item(3, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Precio").ToString), 2)
                            .Item(4, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Cantidad").ToString), 2)
                            .Item(5, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Subtotal").ToString), 2)
                            .Item(6, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Dsto").ToString), 2)
                            .Item(7, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("PrecioConDsto").ToString), 2)
                            .Item(8, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Total").ToString), 2)


                            MetroTextBox20.Text = FormatNumber(Convert.ToDouble(drRecordSet("DstoGenerAplic").ToString), 2)
                            MetroTextBox21.Text = FormatNumber(Convert.ToDouble(drRecordSet("ImpDstoGenerAplic").ToString), 2)
                            MetroTextBox19.Text = FormatNumber(Convert.ToDouble(drRecordSet("ImpConDstoGenerAplic").ToString), 2)
                        End If

                        If x = 2 Then
                            .Item(2, h).Value = drRecordSet("Producto").ToString
                            .Item(3, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Precio").ToString), 2)
                            .Item(4, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Cantidad").ToString), 2)
                            .Item(5, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Cantidad").ToString) * Convert.ToDouble(drRecordSet("Precio").ToString), 2)
                            .Item(6, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("Descuento").ToString), 2)
                            .Item(7, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("ImporteDescuento").ToString), 2)
                            .Item(8, h).Value = FormatNumber(Convert.ToDouble(drRecordSet("SubTotal").ToString), 2)


                            MetroTextBox20.Text = "0.00"
                            MetroTextBox21.Text = "0.00"
                            MetroTextBox19.Text = "0.00"
                        End If

                        h = h + 1
                    End With
                Loop
            End If
            drRecordSet.Close()

            MetroTextBox18.Text = metroGrid1.Rows.Count

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
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
            .Columns.Add("Lista", "Lista")
            .Columns.Add("Detalle", "Detalle")
            .Columns.Add("Precio", "Precio")
            .Columns.Add("Cantidad", "Cantidad")
            .Columns.Add("SubTotal", "SubTotal")
            .Columns.Add("Dsto", "Dsto.")
            .Columns.Add("PrecioConDsto", "P.C/Dsto")
            .Columns.Add("Total", "Total")
            .Columns(0).Width = 80
            .Columns(1).Width = 60
            .Columns(2).Width = 300
            .Columns(3).Width = 120
            .Columns(4).Width = 120
            .Columns(5).Width = 120
            .Columns(6).Width = 120
            .Columns(7).Width = 120
            .Columns(8).Width = 120
            '            .RowCount = 100
        End With
    End Sub
    Private Sub MetroButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        Me.Close()
    End Sub


End Class

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


Public Class Form171
    Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
    Dim ConSql As New OleDbConnection(Conexion)


  
    Private Sub Form171_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MetroTextBox1.Text = ""
        MetroLabel2.Text = ""
        MetroCheckBox1.Checked = True
        MetroCheckBox2.Checked = True

        NumericUpDown1.Minimum = 2000
        NumericUpDown1.Maximum = 3000
        NumericUpDown1.Value = 2018
        cargar_meses()

    End Sub
    Private Sub cargar_meses()
        Try
            MetroComboBox1.Items.Clear()
            MetroComboBox1.Items.Add(New ValueDescriptionPair(1, "Enero"))
            MetroComboBox1.Items.Add(New ValueDescriptionPair(2, "Febrero"))
            MetroComboBox1.Items.Add(New ValueDescriptionPair(3, "Marzo"))
            MetroComboBox1.Items.Add(New ValueDescriptionPair(4, "Abril"))
            MetroComboBox1.Items.Add(New ValueDescriptionPair(5, "Mayo"))
            MetroComboBox1.Items.Add(New ValueDescriptionPair(6, "Junio"))
            MetroComboBox1.Items.Add(New ValueDescriptionPair(7, "Julio"))
            MetroComboBox1.Items.Add(New ValueDescriptionPair(8, "Agosto"))
            MetroComboBox1.Items.Add(New ValueDescriptionPair(9, "Septiembre"))
            MetroComboBox1.Items.Add(New ValueDescriptionPair(10, "Octubre"))
            MetroComboBox1.Items.Add(New ValueDescriptionPair(11, "Noviembre"))
            MetroComboBox1.Items.Add(New ValueDescriptionPair(12, "Diciembre"))

            MetroComboBox1.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show("Error al conectar o recuperar lo datos :" & vbCrLf & _
                             ex.Message, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub MetroButton3_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton3.Click
        Me.Close()
    End Sub

    Private Sub MetroButton2_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton2.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            MetroTextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub MetroButton1_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton1.Click
        If MetroTextBox1.Text.Trim = "" Then
            MessageBox.Show("Debe especificar camino de generación de archivos", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        MetroLabel2.Text = ""
        Me.Refresh()


        Dim Per_mes As Byte = CType(MetroComboBox1.SelectedItem, ValueDescriptionPair).Value
        Dim Mes As String = MetroComboBox1.Text
        Dim Per_Anio As Integer = NumericUpDown1.Value



        If MetroTextBox1.Text.Trim = "" Then
            MessageBox.Show("Debe especificar ruta de generación de archivo", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        'If CheckBox1.Checked = True Then
        '    procesar_compras()
        'End If
        If MetroCheckBox2.Checked = True Then
            procesar_ventas_comprobante(Per_mes, Mes, Per_Anio)
            procesar_ventas_alicuotas(Per_mes, Mes, Per_Anio)
        End If
        MetroLabel2.Text = "Proceso finalizado ....."
        Me.Refresh()

    End Sub
    Private Sub procesar_ventas_comprobante(ByVal Per_mes As Byte, ByVal Mes As String, ByVal Per_Anio As Integer)

        Dim ConSql As New OleDbConnection(Conexion)
        If ConSql.State = ConnectionState.Closed Then
            ConSql.Open()
        End If

        Dim nombre_archivo As String = ""

        nombre_archivo = MetroTextBox1.Text.Trim & "\" & "Ventas_Comprobantes_" & MetroComboBox1.Text.Trim & "_" & NumericUpDown1.Value.ToString & ".prn"

        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(nombre_archivo, False, Encoding.ASCII)


        Dim f1 As String = ""
        Dim f2 As String = ""
        Dim f3 As String = ""
        Dim f4 As String = ""
        Dim f5 As String = ""
        Dim f6 As String = ""
        Dim f7 As String = ""
        Dim f8 As String = ""
        Dim f9 As String = ""
        Dim f10 As String = ""
        Dim f11 As String = ""
        Dim f12 As String = ""
        Dim f13 As String = ""
        Dim f14 As String = ""
        Dim f15 As String = ""
        Dim f16 As String = ""
        Dim f17 As String = ""
        Dim f18 As String = ""
        Dim f19 As String = ""
        Dim f20 As String = ""
        Dim f21 As String = ""
        Dim f22 As String = ""
        Dim f23 As String = ""
        Dim f24 As String = ""
        Dim f25 As String = ""

        Dim proc_reg As Boolean = True
        Dim proc_total_proces As Double = 0
        Dim var_aux_str As String = ""
        Dim var_aux_dbl As Double = 0
        Dim var_aux_lng As Long = 0
        Dim var_linea As String = ""

        Dim insSql As String = ""
        insSql = "Select * from Iva_Ventas Where month(FechaImputacion)= " & Per_mes & " And year(FechaImputacion)= " & Per_Anio & "  "
        insSql = insSql & "And (LetraComprobante='A' or letraComprobante='B') "
        insSql = insSql & "And (TipoComprobante='FA' or TipoComprobante='ND' or TipoComprobante='NC') "
        insSql = insSql & "Order By FechaImputacion,Tipocomprobante,LetraComprobante,NumeroComprobante"


        Dim cmdRecordSet2 As New OleDbCommand(insSql, ConSql)
        Dim drRecordSet2 As OleDbDataReader = cmdRecordSet2.ExecuteReader
        If drRecordSet2.HasRows Then 'Tiene filas
            MetroLabel2.Text = "Procesando movimientos de Ventas.... espere ....."
            Me.Refresh()
            Do While drRecordSet2.Read

                proc_reg = True

                If Convert.ToDouble(drRecordSet2("Total").ToString) = 0 Then
                    proc_reg = False
                End If

                If proc_reg = True Then
                    If drRecordSet2("TipoComprobante").ToString.Trim = "FA" Then
                        proc_total_proces = proc_total_proces + Convert.ToDouble(drRecordSet2("Total").ToString)
                    End If
                    If drRecordSet2("TipoComprobante").ToString.Trim = "ND" Then
                        proc_total_proces = proc_total_proces + Convert.ToDouble(drRecordSet2("Total").ToString)
                    End If
                    If drRecordSet2("TipoComprobante").ToString.Trim = "NC" Then
                        proc_total_proces = proc_total_proces - Convert.ToDouble(drRecordSet2("Total").ToString)
                    End If

                    'Campo 1 
                    Dim fec As Date
                    fec = FormatDateTime(drRecordSet2("FechaImputacion").ToString, DateFormat.ShortDate)
                    f1 = fec.ToString("yyyyMMdd")

                    'Campo 2
                    f2 = "001"
                    If drRecordSet2("LetraComprobante").ToString.Trim = "A" Then
                        If drRecordSet2("TipoComprobante").ToString.Trim = "FA" Then
                            f2 = "001"
                        End If
                        If drRecordSet2("TipoComprobante").ToString.Trim = "ND" Then
                            f2 = "002"
                        End If
                        If drRecordSet2("TipoComprobante").ToString.Trim = "NC" Then
                            f2 = "003"
                        End If
                    End If
                    If drRecordSet2("LetraComprobante").ToString.Trim = "B" Then
                        If drRecordSet2("TipoComprobante").ToString.Trim = "FA" Then
                            f2 = "006"
                        End If
                        If drRecordSet2("TipoComprobante").ToString.Trim = "ND" Then
                            f2 = "007"
                        End If
                        If drRecordSet2("TipoComprobante").ToString.Trim = "NC" Then
                            f2 = "008"
                        End If
                    End If

                    'Campo 3
                    var_aux_str = Microsoft.VisualBasic.Left(drRecordSet2("NumeroComprobante").ToString.Trim, 4)
                    var_aux_str = Formatea_Numero_zeros_izq(var_aux_str.Trim, 5)
                    f3 = var_aux_str

                    'Campo 4
                    var_aux_str = Microsoft.VisualBasic.Right(drRecordSet2("NumeroComprobante").ToString.Trim, 8)
                    var_aux_str = Formatea_Numero_zeros_izq(var_aux_str.Trim, 20)
                    f4 = var_aux_str

                    'Campo 5
                    var_aux_str = Microsoft.VisualBasic.Right(drRecordSet2("NumeroComprobante").ToString.Trim, 8)
                    var_aux_str = Formatea_Numero_zeros_izq(var_aux_str.Trim, 20)
                    f5 = var_aux_str

                    'Campo 6 y 7
                    'If Convert.ToDouble(drRecordSet2("Cuit").ToString) <> 0 Then
                    '    f6 = "80"
                    '    var_aux_str = drRecordSet2("Cuit").ToString.Trim
                    '    var_aux_str = Formatea_Numero_zeros_izq(var_aux_str.Trim, 20)
                    '    f7 = var_aux_str
                    'Else
                    '    If Convert.ToDouble(drRecordSet2("NumeroDocumento").ToString) <> 0 Then
                    '        f6 = "96"
                    '        var_aux_str = drRecordSet2("NumeroDocumento").ToString.Trim
                    '        var_aux_str = Formatea_Numero_zeros_izq(var_aux_str.Trim, 20)
                    '        f7 = var_aux_str
                    '    End If
                    '    If drRecordSet2("LetraComprobante").ToString.Trim = "B" And Convert.ToDouble(drRecordSet2("Total").ToString) < 1000 Then
                    '        f6 = "99"
                    '        var_aux_str = "00000000"
                    '        var_aux_str = Formatea_Numero_zeros_izq(var_aux_str.Trim, 20)
                    '        f7 = var_aux_str
                    '    End If
                    '    If f6.Trim = "" Then
                    '        f6 = "96"
                    '        var_aux_str = "11111111"
                    '        var_aux_str = Formatea_Numero_zeros_izq(var_aux_str.Trim, 20)
                    '        f7 = var_aux_str
                    '    End If
                    'End If

                    If Val(drRecordSet2("TipoResponsable").ToString) <> 2 Then
                        f6 = "80"
                        var_aux_str = drRecordSet2("Cuit").ToString.Trim
                        var_aux_str = Formatea_Numero_zeros_izq(var_aux_str.Trim, 20)
                        f7 = var_aux_str
                    End If
                    If Val(drRecordSet2("TipoResponsable").ToString) = 2 Then
                        If Convert.ToDouble(drRecordSet2("NumeroDocumento").ToString) <> 0 Then
                            f6 = "96"
                            var_aux_str = drRecordSet2("NumeroDocumento").ToString.Trim
                            var_aux_str = Formatea_Numero_zeros_izq(var_aux_str.Trim, 20)
                            f7 = var_aux_str
                        End If
                        If Convert.ToDouble(drRecordSet2("NumeroDocumento").ToString) = 0 And Convert.ToDouble(drRecordSet2("Total").ToString) < 1000 Then
                            f6 = "99"
                            var_aux_str = "00000000"
                            var_aux_str = Formatea_Numero_zeros_izq(var_aux_str.Trim, 20)
                            f7 = var_aux_str
                        End If
                        If Convert.ToDouble(drRecordSet2("NumeroDocumento").ToString) = 0 And Convert.ToDouble(drRecordSet2("Total").ToString) >= 1000 Then
                            f6 = "96"
                            var_aux_str = "11111111"
                            var_aux_str = Formatea_Numero_zeros_izq(var_aux_str.Trim, 20)
                            f7 = var_aux_str
                        End If
                    End If


                   'Campo 8
                    If drRecordSet2("Nombre").ToString.Trim <> "" Then
                        var_aux_str = Microsoft.VisualBasic.Left(drRecordSet2("Nombre").ToString.Trim, 30)
                    Else
                        var_aux_str = "Consumidor"
                    End If

                    var_aux_str = Formatea_parrafo_espacios_der(var_aux_str.Trim, 30)
                    f8 = var_aux_str


                    'Campo 9
                    var_aux_dbl = Convert.ToDouble(drRecordSet2("Total").ToString) * 100
                    var_aux_lng = Int(Convert.ToInt32(var_aux_dbl))
                    var_aux_str = var_aux_lng.ToString
                    var_aux_str = Formatea_Numero_zeros_izq(var_aux_lng, 15)
                    f9 = var_aux_str
                    'Campo 10
                    var_aux_dbl = Convert.ToDouble(drRecordSet2("ConceptosNoGravados").ToString) * 100
                    var_aux_lng = Int(Convert.ToInt32(var_aux_dbl))
                    var_aux_str = var_aux_lng.ToString
                    var_aux_str = Formatea_Numero_zeros_izq(var_aux_lng, 15)
                    f10 = var_aux_str
                    'Campo 11
                    var_aux_dbl = Convert.ToDouble(drRecordSet2("Percepciones").ToString) * 100
                    var_aux_lng = Int(Convert.ToInt32(var_aux_dbl))
                    var_aux_str = var_aux_lng.ToString
                    var_aux_str = Formatea_Numero_zeros_izq(var_aux_lng, 15)
                    f11 = var_aux_str
                    'Campo 12
                    var_aux_dbl = Convert.ToDouble(drRecordSet2("Exento").ToString) * 100
                    var_aux_lng = Int(Convert.ToInt32(var_aux_dbl))
                    var_aux_str = var_aux_lng.ToString
                    var_aux_str = Formatea_Numero_zeros_izq(var_aux_lng, 15)
                    f12 = var_aux_str
                    'Campo 13
                    var_aux_dbl = Convert.ToDouble(drRecordSet2("Percepciones").ToString) * 100
                    var_aux_lng = Int(Convert.ToInt32(var_aux_dbl))
                    var_aux_str = var_aux_lng.ToString
                    var_aux_str = Formatea_Numero_zeros_izq(var_aux_lng, 15)
                    f13 = var_aux_str
                    'Campo 14
                    var_aux_dbl = Convert.ToDouble(drRecordSet2("Retenciones").ToString) * 100
                    var_aux_lng = Int(Convert.ToInt32(var_aux_dbl))
                    var_aux_str = var_aux_lng.ToString
                    var_aux_str = Formatea_Numero_zeros_izq(var_aux_lng, 15)
                    f14 = var_aux_str
                    'Campo 15
                    var_aux_str = "0"
                    var_aux_str = Formatea_Numero_zeros_izq(var_aux_lng, 15)
                    f15 = var_aux_str
                    'Campo 16
                    var_aux_str = "0"
                    var_aux_str = Formatea_Numero_zeros_izq(var_aux_lng, 15)
                    f16 = var_aux_str
                    'Campo 17
                    f17 = "PES"
                    'Campo 18
                    f18 = "0001000000"
                    'Campo 19
                    f19 = "1"
                    'Campo 20
                    f20 = "0"
                    If Convert.ToDouble(drRecordSet2("NetoGravado").ToString) = 0 Then
                        f20 = "A"
                    End If
                    'Campo 21
                    var_aux_str = "0"
                    var_aux_str = Formatea_Numero_zeros_izq(var_aux_lng, 15)
                    f21 = var_aux_str
                    'Campo 22
                    var_aux_str = "0"
                    var_aux_str = Formatea_Numero_zeros_izq(var_aux_lng, 15)
                    f22 = var_aux_str
                    'Campo 23
                    var_aux_str = "0"
                    var_aux_str = Formatea_Numero_zeros_izq(var_aux_lng, 11)
                    f23 = var_aux_str
                    'Campo 24
                    var_aux_str = StrDup(30, " ")
                    f24 = var_aux_str
                    'Campo 25
                    var_aux_str = "0"
                    var_aux_str = Formatea_Numero_zeros_izq(var_aux_lng, 15)
                    f25 = var_aux_str

                    var_linea = f1 & f2 & f3 & f4 & f5 & f6 & f7 & f8 & f9 & f10 & f11 & f12 & f13 & f14 & _
                                f15 & f16 & f17 & f18 & f19 & f20 & f21 & f22 & f23 & f24 & f25




                    file.WriteLine(var_linea)
                    '      mensaje = Strings.Replace(mensaje, " ", "_")

                End If
            Loop
        End If

        file.Close()

    End Sub
    Private Sub procesar_ventas_alicuotas(ByVal Per_mes As Byte, ByVal Mes As String, ByVal Per_Anio As Integer)

    
        Dim ConSql As New OleDbConnection(Conexion)
        If ConSql.State = ConnectionState.Closed Then
            ConSql.Open()
        End If

        Dim nombre_archivo As String = ""

        nombre_archivo = MetroTextBox1.Text.Trim & "\" & "Ventas_alicuotas_" & MetroComboBox1.Text.Trim & "_" & NumericUpDown1.Value.ToString & ".prn"

        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(nombre_archivo, False, Encoding.ASCII)



        Dim f1 As String = ""
        Dim f2 As String = ""
        Dim f3 As String = ""
        Dim f4 As String = ""
        Dim f5 As String = ""
        Dim f6 As String = ""


        Dim proc_reg As Boolean = True
        Dim proc_total_proces As Double = 0
        Dim var_aux_str As String = ""
        Dim var_aux_dbl As Double = 0
        Dim var_aux_lng As Long = 0
        Dim var_linea As String = ""

        Dim insSql As String = ""
        insSql = "Select * from Iva_Ventas Where month(FechaImputacion)= " & Per_mes & " And year(FechaImputacion)= " & Per_Anio & "  "
        insSql = insSql & "And (LetraComprobante='A' or letraComprobante='B') "
        insSql = insSql & "And (TipoComprobante='FA' or TipoComprobante='ND' or TipoComprobante='NC') "
        insSql = insSql & "Order By FechaImputacion,Tipocomprobante,LetraComprobante,NumeroComprobante"


        Dim cmdRecordSet2 As New OleDbCommand(insSql, ConSql)
        Dim drRecordSet2 As OleDbDataReader = cmdRecordSet2.ExecuteReader
        If drRecordSet2.HasRows Then 'Tiene filas
            MetroLabel2.Text = "Procesando movimientos de Ventas.... espere ....."
            Me.Refresh()
            Do While drRecordSet2.Read

                proc_reg = True

                If Convert.ToDouble(drRecordSet2("Total").ToString) = 0 Then
                    proc_reg = False
                End If

                If proc_reg = True Then
                    If drRecordSet2("TipoComprobante").ToString.Trim = "FA" Then
                        proc_total_proces = proc_total_proces + Convert.ToDouble(drRecordSet2("Total").ToString)
                    End If
                    If drRecordSet2("TipoComprobante").ToString.Trim = "ND" Then
                        proc_total_proces = proc_total_proces + Convert.ToDouble(drRecordSet2("Total").ToString)
                    End If
                    If drRecordSet2("TipoComprobante").ToString.Trim = "NC" Then
                        proc_total_proces = proc_total_proces - Convert.ToDouble(drRecordSet2("Total").ToString)
                    End If

                    'Campo 1
                    f1 = "001"
                    If drRecordSet2("LetraComprobante").ToString.Trim = "A" Then
                        If drRecordSet2("TipoComprobante").ToString.Trim = "FA" Then
                            f1 = "001"
                        End If
                        If drRecordSet2("TipoComprobante").ToString.Trim = "ND" Then
                            f1 = "002"
                        End If
                        If drRecordSet2("TipoComprobante").ToString.Trim = "NC" Then
                            f1 = "003"
                        End If
                    End If
                    If drRecordSet2("LetraComprobante").ToString.Trim = "B" Then
                        If drRecordSet2("TipoComprobante").ToString.Trim = "FA" Then
                            f1 = "006"
                        End If
                        If drRecordSet2("TipoComprobante").ToString.Trim = "ND" Then
                            f1 = "007"
                        End If
                        If drRecordSet2("TipoComprobante").ToString.Trim = "NC" Then
                            f1 = "008"
                        End If
                    End If

                    'Campo 2
                    var_aux_str = Microsoft.VisualBasic.Left(drRecordSet2("NumeroComprobante").ToString.Trim, 4)
                    var_aux_str = Formatea_Numero_zeros_izq(var_aux_str.Trim, 5)
                    f2 = var_aux_str

                    'Campo 3
                    var_aux_str = Microsoft.VisualBasic.Right(drRecordSet2("NumeroComprobante").ToString.Trim, 8)
                    var_aux_str = Formatea_Numero_zeros_izq(var_aux_str.Trim, 20)
                    f3 = var_aux_str

                    'Campo 4
                    var_aux_dbl = Convert.ToDouble(drRecordSet2("NetoGravado").ToString) * 100
                    var_aux_lng = Int(Convert.ToInt32(var_aux_dbl))
                    var_aux_str = var_aux_lng.ToString
                    var_aux_str = Formatea_Numero_zeros_izq(var_aux_lng, 15)
                    f4 = var_aux_str

                    If Convert.ToDouble(drRecordSet2("Iva25").ToString) <> 0 Then
                        f5 = "0009"
                    End If
                    'If Convert.ToDouble(drRecordSet2("Iva5").ToString) <> 0 Then
                    '    f5 = "0008"
                    'End If
                    If Convert.ToDouble(drRecordSet2("Iva105").ToString) <> 0 Then
                        f5 = "0004"
                    End If
                    If Convert.ToDouble(drRecordSet2("Iva21").ToString) <> 0 Then
                        f5 = "0005"
                    End If
                    If Convert.ToDouble(drRecordSet2("Iva27").ToString) <> 0 Then
                        f5 = "0006"
                    End If

                    Dim iva_suma_total As Double = 0
                    'iva_suma_total = Convert.ToDouble(drRecordSet2("Iva25").ToString) + _
                    'Convert.ToDouble(drRecordSet2("Iva105").ToString) + Convert.ToDouble(drRecordSet2("Iva21").ToString) + _
                    'Convert.ToDouble(drRecordSet2("Iva27").ToString)

                    iva_suma_total = Convert.ToDouble(drRecordSet2("Iva21").ToString)

                    If iva_suma_total = 0 Then
                        f5 = "0003"
                    End If
                    
                    var_aux_dbl = iva_suma_total * 100
                    var_aux_lng = Int(Convert.ToInt32(var_aux_dbl))
                    var_aux_str = var_aux_lng.ToString
                    var_aux_str = Formatea_Numero_zeros_izq(var_aux_lng, 15)
                    f6 = var_aux_str


                    var_linea = f1 & f2 & f3 & f4 & f5 & f6


                    file.WriteLine(var_linea)
                    '      mensaje = Strings.Replace(mensaje, " ", "_")

                End If
            Loop
        End If

        file.Close()

    End Sub
    Private Function Formatea_Numero_zeros_izq(ByVal nro As String, cant_zeros As Long) As String
        Dim xNumero As String = ""
        xNumero = nro
        xNumero = xNumero.PadLeft(cant_zeros)
        xNumero = xNumero.Replace(" ", "0")

        Formatea_Numero_zeros_izq = xNumero
    End Function
    Private Function Formatea_Numero_zeros_der(ByVal nro As String, cant_zeros As Long) As String
        Dim xNumero As String = ""
        xNumero = nro
        xNumero = xNumero.PadRight(cant_zeros)
        xNumero = xNumero.Replace(" ", "0")

        Formatea_Numero_zeros_der = xNumero
    End Function
    Private Function Formatea_parrafo_espacios_der(ByVal parraf As String, cant_num As Long) As String
        Dim xParrafo As String = ""
        xParrafo = parraf
        xParrafo = xParrafo.PadRight(cant_num)

        Formatea_parrafo_espacios_der = xParrafo
    End Function
End Class

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
Imports Microsoft.Office.Interop.Excel

Public Class Form38
    Dim v_ubic As String = ""
 
    Private Sub Form38_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        v_ubic = parametro_ubicacion_listas()

        MetroTextBox1.Text = ""
        MetroTextBox2.Text = "1"
        MetroTextBox3.Text = "2"
        MetroTextBox4.Text = "3"
        MetroTextBox5.Text = "0.00"
        MetroTextBox6.Text = ""
        MetroTextBox7.Text = ""
        MetroTextBox8.Text = ""
        MetroTextBox9.Text = ""

        MetroTextBox6.Visible = False
        MetroTextBox7.Visible = False

    End Sub

    Private Sub MetroTextBox9_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MetroTextBox9.KeyDown
        If e.KeyCode <> Keys.F1 Then
            Exit Sub
        End If

        rsv_Io = 1
        rsv_Seleccion = ""
        Dim Formulario_open As New Form9
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

    Private Sub MetroTextBox9_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox9.Validated
        validarProveedor()
    End Sub
    Private Sub validarProveedor()
    
        MetroTextBox8.Text = ""

        If MetroTextBox9.Text.Trim = "" Then
            Exit Sub
        End If

        Dim x1 As Double
        Dim x2 As String
        Dim x3 As Double
        Dim x4 As Byte

        x1 = CDbl(MetroTextBox9.Text.Trim)
        x2 = " "
        x3 = 0
        x4 = 0
        Call retornaProveedor(x1, x2, x4, x3)
        If x4 <> 0 Then
            MetroTextBox8.Text = x2
        End If

    End Sub
    
    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        Me.Close()
    End Sub
    Private Sub metroTextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox2.KeyPress
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
    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        Try
            MetroTextBox1.Text = ""
            With OpenFileDialog1

                .Reset() ' resetea
                .Title = "Seleccionar una lista de precios"
                ' Path " Mis documentos " este es que estara seleccionado por defecto, puedes cambiarlo
                '                .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

                .InitialDirectory = v_ubic

                .Filter = "Archivos Excel (*.xls)|*.xls"
                '.RootFolder = Environment.SpecialFolder.Desktop
                '.RootFolder = Environment.SpecialFolder.StartMenu

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo

                ' si se presionó el botón aceptar ...
                If ret = DialogResult.OK Then
                    MetroTextBox1.Text = .FileName
                End If

                .Dispose()

            End With
        Catch oe As Exception
            MsgBox(oe.Message, MsgBoxStyle.Critical)
        End Try


    End Sub

    Private Sub MetroButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton4.Click

        If MetroTextBox1.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar archivo excel a procesar", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MetroTextBox9.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar Proveedor", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MetroTextBox2.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar fila para código", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MetroTextBox3.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar fila para detalle", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MetroTextBox4.Text.Trim = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Debe especificar fila para precio", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Try

            MetroTextBox6.Visible = True
            MetroTextBox7.Visible = True


            'Call actualiza_precios_lote()
            elimina_registros_temporales()

            Dim x_Incremento As Double = Convert.ToDouble(MetroTextBox5.Text.Trim)



            Dim excel As Application = New Application

            Dim file_excel As String = MetroTextBox1.Text.Trim
            Dim w As Workbook = excel.Workbooks.Open(file_excel)

            Dim proc_exec As Boolean = False

            For i As Integer = 1 To w.Sheets.Count
                Dim sheet As Worksheet = w.Sheets(i)
                Dim r As Range = sheet.UsedRange
                Dim array(,) As Object = r.Value(XlRangeValueDataType.xlRangeValueDefault)

                If array IsNot Nothing Then
                    ' MessageBox.Show("Lengh (0), " & array.Length)
                    Dim bound0 As Integer = array.GetUpperBound(0)
                    'Dim bound1 As Integer = array.GetUpperBound(1)

                    ' MessageBox.Show(bound0)

                    Dim x_Codigo As String = ""
                    Dim x_Detalle As String = ""
                    Dim x_Costo As Double = 0
                    Dim x_Precio As Double = 0

                    Dim aux As String = ""
                    For j As Integer = 1 To bound0
                        '                        For x As Integer = 1 To bound1

                        x_Codigo = ""
                        x_Detalle = ""
                        x_Costo = 0
                        x_Precio = 0

                        aux = ""

                        proc_exec = True

                        If String.IsNullOrEmpty(array(j, Val(MetroTextBox2.Text.Trim))) = True Then
                            proc_exec = False
                        End If

                        If proc_exec = True Then
                            If String.IsNullOrWhiteSpace(array(j, Val(MetroTextBox2.Text.Trim))) = True Then
                                proc_exec = False
                            End If
                        End If

                        If proc_exec = True Then
                            If String.IsNullOrEmpty(array(j, Val(MetroTextBox3.Text.Trim))) = True Then
                                proc_exec = False
                            End If
                        End If

                        If proc_exec = True Then
                            If String.IsNullOrWhiteSpace(array(j, Val(MetroTextBox3.Text.Trim))) = True Then
                                proc_exec = False
                            End If
                        End If

                        If proc_exec = True Then
                            If String.IsNullOrEmpty(array(j, Val(MetroTextBox3.Text.Trim))) = True Then
                                proc_exec = False
                            End If
                        End If

                        If proc_exec = True Then
                            If String.IsNullOrWhiteSpace(array(j, Val(MetroTextBox4.Text.Trim))) = True Then
                                proc_exec = False
                            End If
                        End If


                        If proc_exec = True Then
                            If String.IsNullOrEmpty(array(j, Val(MetroTextBox4.Text.Trim))) = True Then
                                proc_exec = False
                            End If
                        End If


                        If proc_exec = True Then
                            If array(j, Val(MetroTextBox2.Text.Trim)).ToString.Trim = "" Then
                                proc_exec = False
                            End If
                        End If

                        If proc_exec = True Then
                            If array(j, Val(MetroTextBox3.Text.Trim)).ToString.Trim = "" Then
                                proc_exec = False
                            End If
                        End If

                        If proc_exec = True Then
                            If array(j, Val(MetroTextBox4.Text.Trim)).ToString.Trim = "" Then
                                proc_exec = False
                            End If
                        End If

                        If proc_exec = True Then

                            If array(j, Val(MetroTextBox2.Text.Trim)).ToString <> "" Then
                                aux = array(j, Val(MetroTextBox2.Text.Trim))
                                x_Codigo = aux.Trim.ToUpper

                                If x_Codigo.Trim = "" Then
                                    x_Codigo = " "
                                End If
                                x_Codigo = Microsoft.VisualBasic.Left(x_Codigo, 15)
                                x_Codigo = x_Codigo.Replace("'", "")
                                x_Codigo = x_Codigo.Replace(System.Convert.ToChar(34), "")

                            End If

                            If array(j, Val(MetroTextBox3.Text.Trim)).ToString <> "" Then
                                aux = array(j, Val(MetroTextBox3.Text.Trim))
                                x_Detalle = aux.Trim.ToUpper

                                If x_Detalle.Trim = "" Then
                                    x_Detalle = " "
                                End If

                                x_Detalle = Microsoft.VisualBasic.Left(x_Detalle, 100)
                                x_Detalle = x_Detalle.Replace("'", "")
                                x_Detalle = x_Detalle.Replace(System.Convert.ToChar(34), "")
                                x_Detalle = x_Detalle.Replace("%", "")
                                x_Detalle = x_Detalle.Replace("&", "")
                            End If

                            aux = array(j, Val(MetroTextBox4.Text.Trim))

                            If aux.Trim <> "" Then
                                aux = aux.Trim.ToUpper
                                aux = aux.Replace(",", ".")
                                x_Costo = Convert.ToDouble(aux)
                                x_Precio = Convert.ToDouble(aux)
                            End If


                            ' MetroTextBox6.Text = x_Codigo & " " & x_Detalle & " " & FormatNumber(x_Precio, 2)

                            If x_Incremento <> 0 Then
                                x_Precio = Math.Round(x_Precio + (x_Precio * x_Incremento / 100), 2)
                            End If

                            If x_Costo <> 0 And x_Codigo.Trim <> "" Then
                                'If valida_existencia(x_Codigo) = True Then
                                '    Call actualiza_precio_articulo(x_Codigo, x_Detalle, x_Costo, x_Precio)
                                'Else
                                '    Call actualiza_articulos_lista_nuevo(x_Codigo, x_Detalle, x_Costo, x_Precio)
                                'End If
                                Call actualiza_articulos_Tabla_Temp_Nuevo(x_Codigo, x_Detalle, x_Costo, x_Precio, Val(MetroTextBox9.Text.Trim))
                            End If

                        End If
                    Next
                End If
            Next

            MetroFramework.MetroMessageBox.Show(Me, "Se Procederá a la Impactación de Precios", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)


            'Call actualiza_precios_lote()

            Call depuracion_articulos(1, 0)

            Call depuracion_articulos(2, Convert.ToDouble(MetroTextBox9.Text.Trim))

            Call inserta_nuevos_articulos()

            Call depuracion_articulos(1, 0)


            w.Close()


            System.Runtime.InteropServices.Marshal.ReleaseComObject(w)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel)



            MetroTextBox6.Visible = False
            MetroTextBox7.Visible = False

            MetroFramework.MetroMessageBox.Show(Me, "Proceso de Atualización Finalizado", rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
        End Try
    End Sub


    Private Sub MetroTextBox5_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MetroTextBox5.Validating
        If MetroTextBox5.Text.Trim <> "" Then
            MetroTextBox5.Text = FormatNumber(Convert.ToDouble(MetroTextBox5.Text.Trim), 2)
        End If
    End Sub

    Private Sub MetroTextBox9_Click(sender As System.Object, e As System.EventArgs) Handles MetroTextBox9.Click

    End Sub
End Class

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
Module ImpresionComprobantes


    Public Sub impresion_comprobante_a(ByVal xPunto As Integer, _
                                 ByVal xTipoComprobante As Byte, _
                                 ByVal xLetraComprobante As String, _
                                 ByVal xNumeroComprobante As String, _
                                 ByVal xFecha As String, ByVal xCopias As Byte, _
                                 ByVal xTipoImpresora As Byte, _
                                 Optional ByVal xNombreArchivo As String = "")

        Dim dts As New DataSet

        Try

            Dim rsv_PathLogo As String = My.Computer.FileSystem.CurrentDirectory

            Dim tabla As DataTable
            Dim campo As DataColumn
            Dim registro As DataRow
            tabla = New DataTable("estructuraComprobantes")
            campo = New DataColumn("Original", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("FechaEmision", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("LetraComprobante", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("CodigoComprobante", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("NumeroComprobante", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("TipoComprobante", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("CuitEmisor", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("IngresosBrutosEmisor", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("FechaInicioActividades", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EmpresaNombreComercial", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EmpresaRazonSocial", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EmpresaDomicilio", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EmpresaResponsable", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("PeriodoFacturadoDesde", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("PeriodoFacturadoHasta", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("FechaVtoPago", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ClienteNumero", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ClienteNombre", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ClienteDomicilio", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ClienteProvincia", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ClienteCuit", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ClienteResponsable", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("CondicionDeVenta", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("NumeroRemito", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)


            campo = New DataColumn("Codigo", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("Producto", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("Cantidad", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("UnidadMedida", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("PrecioUnitario", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Bonificacion", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("SubTotal", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("AlicuotaIva", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("SubTotalIva", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ImpInt", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("IngBru", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("CantidadUnidades", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)


            campo = New DataColumn("ImporteNetoGrabado", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Iva27", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Iva21", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Iva105", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Iva5", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Iva25", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Iva0", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("OtrosTributos", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ImporteTotal", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("PercepRetenGanan", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("PercepRetenIva", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("PercepRetenIngBru", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ImpuestosInternos", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ImpuestosMunicipales", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("OtrosImpuestos", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Cae", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("FechaVtoCae", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("CodigoBarras", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("DetalleCodigoBarras", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("NumeroDocumento", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Observacion1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Observacion2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("FacturaOrigen", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Mensaje01", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Imagen", GetType(System.Byte()))
            tabla.Columns.Add(campo)

            campo = New DataColumn("ImagenQr", GetType(System.Byte()))
            tabla.Columns.Add(campo)

            registro = tabla.NewRow

            Dim Param_1 As String = ""
            Dim Param_2 As String = ""
            Dim Param_3 As String = ""
            Dim Param_4 As String = ""
            Dim Param_5 As String = ""
            Dim Param_6 As String = ""
            Dim Param_7 As String = ""

            Call lectura_param_facturacion(xPunto, Param_1, Param_2, Param_3, Param_4, Param_5, Param_6, Param_7)

            If Param_1.Trim = "" Then
                MessageBox.Show("Problemas en el Parámetro de Punto de Venta", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim fecha_Qr As String = ""
            Dim puntoVta_Qr As String = ""
            Dim tipo_comprobante_Qr As String = ""
            Dim numero_comprobante_Qr As String = ""
            Dim importe_Qr As String = ""
            Dim moneda_Qr As String = ""
            Dim cotiz_Qr As String = ""
            Dim tipo_doc_recep_Qr As String = "80"
            Dim nro_doc_recep_Qr As String = ""
            Dim tipo_codigo_autor_qr As String = "E"
            Dim codigo_autor_qr As String = ""

            Dim p_vez As Boolean = True
            Dim rsv_Path_Qr As String = ""

            Dim mensaje_monotributo As String = " "

            Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
            Dim ConSql As New OleDbConnection(Conexion)
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim Sql As String = "Select * From Ventas_detalle_afip WHERE (TipoComprobante= " & xTipoComprobante & ") AND (LetraComprobante= '" & xLetraComprobante & "') AND (NumeroComprobante= '" & xNumeroComprobante & "') AND (Fecha='" & xFecha & "') And (Estado=0) Order by Orden"
            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                Do While drRecordSet.Read

                    'Qr
                    If p_vez = True Then
                        Dim f_qr As Date = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)
                        fecha_Qr = f_qr.ToString("yyyy-MM-dd")
                        puntoVta_Qr = Val(Microsoft.VisualBasic.Left(drRecordSet("NumeroComprobante").ToString.Trim, 4))
                        numero_comprobante_Qr = Val(Microsoft.VisualBasic.Right(drRecordSet("NumeroComprobante").ToString.Trim, 8))
                        importe_Qr = drRecordSet("ImporteTotal").ToString.Trim
                        moneda_Qr = "PES"
                        cotiz_Qr = "1"
                        codigo_autor_qr = drRecordSet("CaeAfip").ToString.Trim

                        tipo_doc_recep_Qr = drRecordSet("TipoDocRecepAfip").ToString.Trim
                        nro_doc_recep_Qr = drRecordSet("NroDocRecepAfip").ToString.Trim

                        If Val(drRecordSet("TipoComprobante").ToString) = 1 Then
                            tipo_comprobante_Qr = "1"
                        End If
                        If Val(drRecordSet("TipoComprobante").ToString) = 2 Then
                            tipo_comprobante_Qr = "2"
                        End If
                        If Val(drRecordSet("TipoComprobante").ToString) = 3 Then
                            tipo_comprobante_Qr = "3"
                        End If

                        Dim p1 As String = fecha_Qr
                        Dim p2 As String = Param_4
                        Dim p3 As String = puntoVta_Qr
                        Dim p4 As String = tipo_comprobante_Qr
                        Dim p5 As String = numero_comprobante_Qr
                        Dim p6 As String = importe_Qr
                        Dim p7 As String = moneda_Qr
                        Dim p8 As String = cotiz_Qr
                        Dim p9 As String = tipo_doc_recep_Qr
                        Dim p10 As String = nro_doc_recep_Qr
                        Dim p11 As String = tipo_codigo_autor_qr
                        Dim p12 As String = codigo_autor_qr

                        Dim valorFechaUnica As String = Now.ToString("ddMMyyyyhhmmssfff")
                        valorFechaUnica = "\qr\" & valorFechaUnica & ".bmp"

                        rsv_Path_Qr = My.Computer.FileSystem.CurrentDirectory & valorFechaUnica

                        If File.Exists(rsv_Path_Qr) Then
                            File.Delete(rsv_Path_Qr)
                        End If

                        Dim CadenaQr As String = especificaciones_qr(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12)

                        Call generar_archivo_qr(CadenaQr, rsv_Path_Qr)

                        mensaje_monotributo = " "

                        If Val(drRecordSet("TipoResponsable").ToString) = 4 Then
                            mensaje_monotributo = "El crédito fiscal discriminado en el presente comprobante sólo podrá ser computado a efectos del Régimen de Sostenimiento e Inclusión Fiscal para Pequeños Contribuyentes de la Ley Nº 27618"
                        End If

                        p_vez = False
                    End If


                    'Cabecera
                    registro = tabla.NewRow

                    If xCopias = 1 Then
                        registro("Original") = "ORIGINAL"
                    End If
                    If xCopias = 2 Then
                        registro("Original") = "DUPLICADO"
                    End If
                    If xCopias = 3 Then
                        registro("Original") = "TRIPLICADO"
                    End If

                    registro("FechaEmision") = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)
                    registro("LetraComprobante") = drRecordSet("LetraComprobante").ToString

                    If Val(drRecordSet("TipoComprobante").ToString) = 1 Then
                        registro("CodigoComprobante") = "01"
                    End If
                    If Val(drRecordSet("TipoComprobante").ToString) = 2 Then
                        registro("CodigoComprobante") = "02"
                    End If
                    If Val(drRecordSet("TipoComprobante").ToString) = 3 Then
                        registro("CodigoComprobante") = "03"
                    End If

                    registro("NumeroComprobante") = drRecordSet("NumeroComprobante").ToString
                    If Val(drRecordSet("TipoComprobante").ToString) = 1 Then
                        registro("TipoComprobante") = "FACTURA"
                    End If
                    If Val(drRecordSet("TipoComprobante").ToString) = 2 Then
                        registro("TipoComprobante") = "NOTA DE DEBITO"
                    End If
                    If Val(drRecordSet("TipoComprobante").ToString) = 3 Then
                        registro("TipoComprobante") = "NOTA DE CREDITO"
                    End If

                    registro("CuitEmisor") = Param_4
                    registro("IngresosBrutosEmisor") = Param_5
                    registro("FechaInicioActividades") = FormatDateTime(Param_6, DateFormat.ShortDate)
                    registro("EmpresaNombreComercial") = Param_2
                    registro("EmpresaRazonSocial") = Param_1
                    registro("EmpresaDomicilio") = Param_3
                    registro("EmpresaResponsable") = Param_7

                    registro("PeriodoFacturadoDesde") = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)
                    registro("PeriodoFacturadoHasta") = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)
                    registro("FechaVtoPago") = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)

                    If Val(drRecordSet("Cliente").ToString.Trim) <> 0 Then
                        registro("ClienteNumero") = drRecordSet("Cliente").ToString.Trim
                    End If

                    registro("ClienteNombre") = drRecordSet("Nombre").ToString.Trim.ToUpper
                    registro("ClienteDomicilio") = drRecordSet("Domicilio").ToString.Trim.ToUpper & " " & _
                                                   drRecordSet("Ciudad").ToString.Trim.ToUpper & " " & _
                                                   drRecordSet("Provincia").ToString.Trim.ToUpper()
                    registro("ClienteProvincia") = " "

                    If Convert.ToDouble(drRecordSet("TipoDocumento").ToString) = 80 Then
                        registro("ClienteCuit") = drRecordSet("Cuit").ToString
                        registro("NumeroDocumento") = 0
                    Else
                        registro("ClienteCuit") = " "
                        registro("NumeroDocumento") = 0
                    End If

                    If Convert.ToDouble(drRecordSet("TipoDocumento").ToString) = 96 Then
                        registro("NumeroDocumento") = drRecordSet("NumeroDocumento").ToString
                        registro("ClienteCuit") = " "
                    End If


                    registro("FacturaOrigen") = ""

                    registro("ClienteResponsable") = parametroSistema(2, Val(drRecordSet("TipoResponsable").ToString))


                    If Val(drRecordSet("Contado").ToString) = 1 Then
                        registro("CondicionDeVenta") = "CONTADO"
                    Else
                        registro("CondicionDeVenta") = "CUENTA CORRIENTE"
                    End If


                    If Val(drRecordSet("NumeroOperacion").ToString) = 0 Then
                        registro("NumeroRemito") = " "
                    Else
                        registro("NumeroRemito") = drRecordSet("NumeroOperacion").ToString
                    End If

                    'Pie
                    registro("ImporteNetoGrabado") = Convert.ToDouble(drRecordSet("NetoGravado").ToString)
                    '                        registro("Iva27") = Convert.ToDouble(drRecordSet("Iva27").ToString)

                    registro("Iva27") = Convert.ToDouble(drRecordSet("Exento").ToString)
                    registro("Iva21") = Convert.ToDouble(drRecordSet("Iva21").ToString)
                    registro("Iva105") = Convert.ToDouble(drRecordSet("Iva105").ToString)
                    registro("Iva5") = 0
                    registro("Iva25") = Convert.ToDouble(drRecordSet("Iva25").ToString)
                    registro("Iva0") = 0

                    '      registro("OtrosTributos") = Convert.ToDouble(drRecordSet("ImpuestosInternos").ToString) + Convert.ToDouble(drRecordSet("IngresosBrutos").ToString)
                    registro("OtrosTributos") = 0
                    registro("ImporteTotal") = Convert.ToDouble(drRecordSet("ImporteTotal").ToString)

                    registro("PercepRetenGanan") = 0
                    registro("PercepRetenIva") = 0
                    registro("PercepRetenIngBru") = 0
                    registro("ImpuestosInternos") = 0
                    registro("ImpuestosMunicipales") = 0
                    registro("OtrosImpuestos") = 0

                    registro("Cae") = drRecordSet("CaeAfip").ToString
                    registro("Observacion1") = drRecordSet("DescripComprob").ToString
                    registro("Observacion2") = " "

                    Dim fec_cae As String = Trim(drRecordSet("FechaVtoCaeaFIP").ToString)
                    Dim fec_cae_conv As String = fec_cae.Substring(6, 2) & "/" & fec_cae.Substring(4, 2) & "/" & fec_cae.Substring(0, 4)

                    registro("FechaVtoCae") = fec_cae_conv

                    Dim xCodigoBarra As String = Param_4 & _
                                                 registro("CodigoComprobante") & _
                                                 drRecordSet("NumeroComprobante").ToString.Substring(0, 4) & _
                                                 drRecordSet("CaeAfip").ToString.Trim & _
                                                 drRecordSet("FechaVtoCaeaFIP").ToString.Trim


                    xCodigoBarra = xCodigoBarra & CStr(generarDivitov(xCodigoBarra))

                    registro("CodigoBarras") = cadenaCode128(xCodigoBarra)
                    registro("DetalleCodigoBarras") = xCodigoBarra

                    registro("Imagen") = imageTobyte(Image.FromFile(rsv_PathLogo & "\logo1.jpg"))

                    registro("ImagenQr") = imageTobyte(Image.FromStream(New MemoryStream(File.ReadAllBytes(rsv_Path_Qr))))

                    registro("Codigo") = drRecordSet("Codigo").ToString
                    registro("Producto") = drRecordSet("Producto").ToString
                    registro("Cantidad") = Convert.ToDouble(drRecordSet("Cantidad").ToString)

                    '                        registro("UnidadMedida") = drRecordSet("UnidadDeMedidaLiteral").ToString
                    registro("UnidadMedida") = " "

                    registro("PrecioUnitario") = Convert.ToDouble(drRecordSet("Precio").ToString)
                    registro("Bonificacion") = Convert.ToDouble(drRecordSet("Descuento").ToString)
                    registro("SubTotal") = Convert.ToDouble(drRecordSet("ImporteDescuento").ToString)
                    registro("AlicuotaIva") = Convert.ToDouble(drRecordSet("AlicuotaProducto").ToString)
                    registro("ImpInt") = 0
                    registro("SubTotalIva") = Convert.ToDouble(drRecordSet("SubTotal").ToString)
                    registro("CantidadUnidades") = Convert.ToDouble(drRecordSet("Cantidad").ToString)
                    registro("IngBru") = 0
                    registro("Mensaje01") = mensaje_monotributo

                    tabla.Rows.Add(registro)


                Loop
            End If

            dts.Tables.Add(tabla)

            If xTipoImpresora = 0 Then
                Dim mi_CryResumen As New CrComprobantesA()
                mi_CryResumen.SetDataSource(dts.Tables("estructuraComprobantes"))

                Dim miForma As New Form1000()
                miForma.CrvReportes.ReportSource = mi_CryResumen
                miForma.ShowDialog()
                mi_CryResumen.Dispose()
            End If

            If xTipoImpresora = 1 Then
                Dim mi_CryResumen As New CrComprobantesA()
                mi_CryResumen.SetDataSource(dts.Tables("estructuraComprobantes"))
                Dim miForma As New Form1000()
                miForma.CrvReportes.ReportSource = mi_CryResumen
                mi_CryResumen.PrintOptions.PrinterName = rsv_Impresora_Defecto
                mi_CryResumen.PrintToPrinter(1, True, 0, 0)
                mi_CryResumen.Dispose()
            End If

            If xTipoImpresora = 2 Then
                Dim mi_CryResumen As New CrComprobantesA()
                mi_CryResumen.SetDataSource(dts.Tables("estructuraComprobantes"))
                Dim miForma As New Form1000()
                miForma.CrvReportes.ReportSource = mi_CryResumen
                mi_CryResumen.PrintOptions.PrinterName = rsv_impresora_Termica
                mi_CryResumen.PrintToPrinter(1, True, 0, 0)
                mi_CryResumen.Dispose()
            End If

            If xTipoImpresora = 3 Then
                Dim mi_CryResumen As New CrComprobantesA
                mi_CryResumen.SetDataSource(dts.Tables("estructuraComprobantes"))
                mi_CryResumen.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, xNombreArchivo)
                mi_CryResumen.Dispose()
            End If

            If System.IO.File.Exists(rsv_Path_Qr) = True Then
                System.IO.File.Delete(rsv_Path_Qr)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub


    Public Sub impresion_comprobante_b(ByVal xPunto As Integer, _
                                      ByVal xTipoComprobante As Byte, _
                                      ByVal xLetraComprobante As String, _
                                      ByVal xNumeroComprobante As String, _
                                      ByVal xFecha As String, ByVal xCopias As Byte, _
                                      ByVal xTipoImpresora As Byte, _
                                      Optional ByVal xNombreArchivo As String = "")



        Dim dts As New DataSet

        Try

            Dim rsv_PathLogo As String = My.Computer.FileSystem.CurrentDirectory

            Dim tabla As DataTable
            Dim campo As DataColumn
            Dim registro As DataRow
            tabla = New DataTable("estructuraComprobantes")
            campo = New DataColumn("Original", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("FechaEmision", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("LetraComprobante", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("CodigoComprobante", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("NumeroComprobante", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("TipoComprobante", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("CuitEmisor", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("IngresosBrutosEmisor", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("FechaInicioActividades", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EmpresaNombreComercial", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EmpresaRazonSocial", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EmpresaDomicilio", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EmpresaResponsable", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("PeriodoFacturadoDesde", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("PeriodoFacturadoHasta", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("FechaVtoPago", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ClienteNumero", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ClienteNombre", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ClienteDomicilio", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ClienteProvincia", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ClienteCuit", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ClienteResponsable", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("CondicionDeVenta", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("NumeroRemito", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Codigo", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("Producto", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("Cantidad", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("UnidadMedida", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("PrecioUnitario", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Bonificacion", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("SubTotal", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("AlicuotaIva", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("SubTotalIva", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ImpInt", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("IngBru", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("CantidadUnidades", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ImporteNetoGrabado", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Iva27", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Iva21", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Iva105", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Iva5", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Iva25", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Iva0", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("OtrosTributos", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ImporteTotal", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("PercepRetenGanan", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("PercepRetenIva", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("PercepRetenIngBru", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ImpuestosInternos", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ImpuestosMunicipales", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("OtrosImpuestos", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Cae", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("FechaVtoCae", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("CodigoBarras", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("DetalleCodigoBarras", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("NumeroDocumento", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Observacion1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Observacion2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("FacturaOrigen", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Mensaje01", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Imagen", GetType(System.Byte()))
            tabla.Columns.Add(campo)

            campo = New DataColumn("ImagenQr", GetType(System.Byte()))
            tabla.Columns.Add(campo)

            registro = tabla.NewRow


            Dim Param_1 As String = ""
            Dim Param_2 As String = ""
            Dim Param_3 As String = ""
            Dim Param_4 As String = ""
            Dim Param_5 As String = ""
            Dim Param_6 As String = ""
            Dim Param_7 As String = ""

            Call lectura_param_facturacion(xPunto, Param_1, Param_2, Param_3, Param_4, Param_5, Param_6, Param_7)

            If Param_1.Trim = "" Then
                MessageBox.Show("Problemas en el Parámetro de Punto de Venta", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim fecha_Qr As String = ""
            Dim puntoVta_Qr As String = ""
            Dim tipo_comprobante_Qr As String = ""
            Dim numero_comprobante_Qr As String = ""
            Dim importe_Qr As String = ""
            Dim moneda_Qr As String = ""
            Dim cotiz_Qr As String = ""
            Dim tipo_doc_recep_Qr As String = "80"
            Dim nro_doc_recep_Qr As String = ""
            Dim tipo_codigo_autor_qr As String = "E"
            Dim codigo_autor_qr As String = ""

            Dim p_vez As Boolean = True
            Dim rsv_Path_Qr As String = ""

            Dim aux_bonif As Double = 0

            Dim mensaje_monotributo As String = " "

            Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
            Dim ConSql As New OleDbConnection(Conexion)
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()


            Dim Cantidad_Registros As Integer = 0

            Dim Sql As String = "Select * From Ventas_detalle_Afip WHERE (TipoComprobante= " & xTipoComprobante & ") AND (LetraComprobante= '" & xLetraComprobante & "') AND (NumeroComprobante= '" & xNumeroComprobante & "') AND (Fecha='" & xFecha & "') And (Estado=0) Order by Orden"
            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                Do While drRecordSet.Read

                    'Qr
                    If p_vez = True Then
                        Dim f_qr As Date = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)
                        fecha_Qr = f_qr.ToString("yyyy-MM-dd")
                        puntoVta_Qr = Val(Microsoft.VisualBasic.Left(drRecordSet("NumeroComprobante").ToString.Trim, 4))
                        numero_comprobante_Qr = Val(Microsoft.VisualBasic.Right(drRecordSet("NumeroComprobante").ToString.Trim, 8))
                        importe_Qr = drRecordSet("ImporteTotal").ToString.Trim
                        moneda_Qr = "PES"
                        cotiz_Qr = "1"
                        codigo_autor_qr = drRecordSet("CaeAfip").ToString.Trim

                        tipo_doc_recep_Qr = drRecordSet("TipoDocRecepAfip").ToString.Trim
                        nro_doc_recep_Qr = drRecordSet("NroDocRecepAfip").ToString.Trim

                        If Val(drRecordSet("TipoComprobante").ToString) = 1 Then
                            tipo_comprobante_Qr = "6"
                        End If
                        If Val(drRecordSet("TipoComprobante").ToString) = 2 Then
                            tipo_comprobante_Qr = "7"
                        End If
                        If Val(drRecordSet("TipoComprobante").ToString) = 3 Then
                            tipo_comprobante_Qr = "8"
                        End If

                        Dim p1 As String = fecha_Qr
                        Dim p2 As String = Param_4
                        Dim p3 As String = puntoVta_Qr
                        Dim p4 As String = tipo_comprobante_Qr
                        Dim p5 As String = numero_comprobante_Qr
                        Dim p6 As String = importe_Qr
                        Dim p7 As String = moneda_Qr
                        Dim p8 As String = cotiz_Qr
                        Dim p9 As String = tipo_doc_recep_Qr
                        Dim p10 As String = nro_doc_recep_Qr
                        Dim p11 As String = tipo_codigo_autor_qr
                        Dim p12 As String = codigo_autor_qr

                        Dim valorFechaUnica As String = Now.ToString("ddMMyyyyhhmmssfff")
                        valorFechaUnica = "\qr\" & valorFechaUnica & ".bmp"

                        rsv_Path_Qr = My.Computer.FileSystem.CurrentDirectory & valorFechaUnica

                        If File.Exists(rsv_Path_Qr) Then
                            File.Delete(rsv_Path_Qr)
                        End If

                        Dim CadenaQr As String = especificaciones_qr(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12)

                        Call generar_archivo_qr(CadenaQr, rsv_Path_Qr)

                        mensaje_monotributo = " "

                        p_vez = False

                    End If


                    'Cabecera
                    registro = tabla.NewRow

                    If xCopias = 1 Then
                        registro("Original") = "ORIGINAL"
                    End If
                    If xCopias = 2 Then
                        registro("Original") = "DUPLICADO"
                    End If
                    If xCopias = 3 Then
                        registro("Original") = "TRIPLICADO"
                    End If

                    registro("FechaEmision") = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)
                    registro("LetraComprobante") = drRecordSet("LetraComprobante").ToString

                    If Val(drRecordSet("TipoComprobante").ToString) = 1 Then
                        registro("CodigoComprobante") = "06"
                    End If
                    If Val(drRecordSet("TipoComprobante").ToString) = 2 Then
                        registro("CodigoComprobante") = "07"
                    End If
                    If Val(drRecordSet("TipoComprobante").ToString) = 3 Then
                        registro("CodigoComprobante") = "08"
                    End If

                    registro("NumeroComprobante") = drRecordSet("NumeroComprobante").ToString
                    If Val(drRecordSet("TipoComprobante").ToString) = 1 Then
                        registro("TipoComprobante") = "FACTURA"
                    End If
                    If Val(drRecordSet("TipoComprobante").ToString) = 2 Then
                        registro("TipoComprobante") = "NOTA DE DEBITO"
                    End If
                    If Val(drRecordSet("TipoComprobante").ToString) = 3 Then
                        registro("TipoComprobante") = "NOTA DE CREDITO"
                    End If

                    registro("CuitEmisor") = Param_4
                    registro("IngresosBrutosEmisor") = Param_5
                    registro("FechaInicioActividades") = FormatDateTime(Param_6, DateFormat.ShortDate)
                    registro("EmpresaNombreComercial") = Param_2
                    registro("EmpresaRazonSocial") = Param_1
                    registro("EmpresaDomicilio") = Param_3
                    registro("EmpresaResponsable") = Param_7

                    registro("PeriodoFacturadoDesde") = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)
                    registro("PeriodoFacturadoHasta") = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)
                    registro("FechaVtoPago") = FormatDateTime(drRecordSet("Fecha").ToString, DateFormat.ShortDate)

                    If Val(drRecordSet("Cliente").ToString.Trim) <> 0 Then
                        registro("ClienteNumero") = drRecordSet("Cliente").ToString.Trim
                    End If

                    registro("ClienteNombre") = drRecordSet("Nombre").ToString.Trim.ToUpper
                    registro("ClienteDomicilio") = drRecordSet("Domicilio").ToString.Trim.ToUpper & " " & _
                                           drRecordSet("Ciudad").ToString.Trim.ToUpper & " " & _
                                           drRecordSet("Provincia").ToString.Trim.ToUpper
                    registro("ClienteProvincia") = " "

                    If Convert.ToDouble(drRecordSet("TipoDocumento").ToString) = 80 Then
                        registro("ClienteCuit") = drRecordSet("Cuit").ToString
                        registro("NumeroDocumento") = 0
                    Else
                        registro("ClienteCuit") = " "
                        registro("NumeroDocumento") = 0
                    End If

                    If Convert.ToDouble(drRecordSet("TipoDocumento").ToString) = 96 Then
                        registro("NumeroDocumento") = drRecordSet("NumeroDocumento").ToString
                        registro("ClienteCuit") = " "
                    End If

                    registro("FacturaOrigen") = ""

                    registro("ClienteResponsable") = parametroSistema(2, Val(drRecordSet("TipoResponsable").ToString))

                    If Val(drRecordSet("Contado").ToString) = 1 Then
                        registro("CondicionDeVenta") = "CONTADO"
                    Else
                        registro("CondicionDeVenta") = "CUENTA CORRIENTE"
                    End If

                    If Val(drRecordSet("NumeroOperacion").ToString) = 0 Then
                        registro("NumeroRemito") = " "
                    Else
                        registro("NumeroRemito") = drRecordSet("NumeroOperacion").ToString
                    End If

                    'Pie
                    registro("ImporteNetoGrabado") = Convert.ToDouble(drRecordSet("ImporteTotal").ToString)
                    registro("Iva27") = 0
                    registro("Iva21") = 0
                    registro("Iva105") = 0
                    registro("Iva5") = 0
                    registro("Iva25") = 0
                    registro("Iva0") = 0

            '                        registro("OtrosTributos") = Convert.ToDouble(drRecordSet("ImpuestosInternos").ToString) + Convert.ToDouble(drRecordSet("IngresosBrutos").ToString)
                    registro("OtrosTributos") = 0

                    registro("ImporteTotal") = Convert.ToDouble(drRecordSet("ImporteTotal").ToString)

                    registro("PercepRetenGanan") = 0
                    registro("PercepRetenIva") = 0
                    registro("PercepRetenIngBru") = 0
                    registro("ImpuestosInternos") = 0
                    registro("ImpuestosMunicipales") = 0
                    registro("OtrosImpuestos") = 0

                    registro("Observacion1") = drRecordSet("DescripComprob").ToString
                    registro("Observacion2") = " "

                    registro("Cae") = drRecordSet("CaeAfip").ToString

                    Dim fec_cae As String = Trim(drRecordSet("FechaVtoCaeaFIP").ToString)
                    Dim fec_cae_conv As String = fec_cae.Substring(6, 2) & "/" & fec_cae.Substring(4, 2) & "/" & fec_cae.Substring(0, 4)

                    registro("FechaVtoCae") = fec_cae_conv

                    Dim xCodigoBarra As String = Param_4 & _
                                         registro("CodigoComprobante") & _
                                         drRecordSet("NumeroComprobante").ToString.Substring(0, 4) & _
                                         drRecordSet("CaeAfip").ToString.Trim & _
                                         drRecordSet("FechaVtoCaeaFIP").ToString.Trim


                    xCodigoBarra = xCodigoBarra & CStr(generarDivitov(xCodigoBarra))

                    registro("CodigoBarras") = cadenaCode128(xCodigoBarra)
                    registro("DetalleCodigoBarras") = xCodigoBarra

                    registro("Imagen") = imageTobyte(Image.FromFile(rsv_PathLogo & "\logo1.jpg"))

                    registro("ImagenQr") = imageTobyte(Image.FromStream(New MemoryStream(File.ReadAllBytes(rsv_Path_Qr))))

                    aux_bonif = 0

                    registro("Codigo") = drRecordSet("Codigo").ToString
                    registro("Producto") = drRecordSet("Producto").ToString
                    registro("Cantidad") = Convert.ToDouble(drRecordSet("Cantidad").ToString)
            '                        registro("UnidadMedida") = drRecordSet("UnidadDeMedidaLiteral").ToString
                    registro("UnidadMedida") = " "

                    registro("PrecioUnitario") = Convert.ToDouble(drRecordSet("Precio").ToString)
                    registro("Bonificacion") = Convert.ToDouble(drRecordSet("Descuento").ToString)
                    registro("SubTotal") = aux_bonif
                    registro("AlicuotaIva") = Convert.ToDouble(drRecordSet("AlicuotaProducto").ToString)
                    registro("SubTotalIva") = Convert.ToDouble(drRecordSet("SubTotal").ToString)
                    registro("CantidadUnidades") = Convert.ToDouble(drRecordSet("Cantidad").ToString)
                    registro("IngBru") = 0
                    registro("Mensaje01") = mensaje_monotributo

                    tabla.Rows.Add(registro)

                    Cantidad_Registros = Cantidad_Registros + 1

                Loop
            End If

            dts.Tables.Add(tabla)

            If xTipoImpresora = 0 Then
                Dim mi_CryResumen As New CrComprobantesB()
                mi_CryResumen.SetDataSource(dts.Tables("estructuraComprobantes"))
                Dim miForma As New Form1000()
                miForma.CrvReportes.ReportSource = mi_CryResumen
                miForma.ShowDialog()
                mi_CryResumen.Dispose()
            End If

            If xTipoImpresora = 1 Then
                Dim mi_CryResumen As New CrComprobantesB()
                mi_CryResumen.SetDataSource(dts.Tables("estructuraComprobantes"))
                Dim miForma As New Form1000()
                miForma.CrvReportes.ReportSource = mi_CryResumen
                mi_CryResumen.PrintOptions.PrinterName = rsv_Impresora_Defecto
                mi_CryResumen.PrintToPrinter(1, True, 0, 0)
                mi_CryResumen.Dispose()
            End If

            If xTipoImpresora = 2 Then
                If Cantidad_Registros > 4 And Cantidad_Registros <= 12 Then
                    Dim mi_CryResumen As New CrComprobantesB_Ticket()
                    mi_CryResumen.SetDataSource(dts.Tables("estructuraComprobantes"))
                    Dim miForma As New Form1000()
                    miForma.CrvReportes.ReportSource = mi_CryResumen
                    mi_CryResumen.PrintOptions.PrinterName = rsv_impresora_Termica
                    mi_CryResumen.PrintToPrinter(1, True, 0, 0)
                    mi_CryResumen.Dispose()
                End If
                If Cantidad_Registros <= 4 Then
                    Dim mi_CryResumen As New CrComprobantesB_Ticket_Reducido()
                    mi_CryResumen.SetDataSource(dts.Tables("estructuraComprobantes"))
                    Dim miForma As New Form1000()
                    miForma.CrvReportes.ReportSource = mi_CryResumen
                    mi_CryResumen.PrintOptions.PrinterName = rsv_impresora_Termica
                    mi_CryResumen.PrintToPrinter(1, True, 0, 0)
                    mi_CryResumen.Dispose()
                End If
                If Cantidad_Registros > 12 Then
                    Dim mi_CryResumen As New CrComprobantesB()
                    mi_CryResumen.SetDataSource(dts.Tables("estructuraComprobantes"))
                    Dim miForma As New Form1000()
                    miForma.CrvReportes.ReportSource = mi_CryResumen
                    mi_CryResumen.PrintOptions.PrinterName = rsv_Impresora_Defecto
                    mi_CryResumen.PrintToPrinter(1, True, 0, 0)
                    mi_CryResumen.Dispose()
                End If

            End If

            If xTipoImpresora = 3 Then
                Dim mi_CryResumen As New CrComprobantesB()
                mi_CryResumen.SetDataSource(dts.Tables("estructuraComprobantes"))
                mi_CryResumen.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, xNombreArchivo)
                mi_CryResumen.Dispose()
            End If

            If System.IO.File.Exists(rsv_Path_Qr) = True Then
                System.IO.File.Delete(rsv_Path_Qr)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
    Private Sub lectura_param_facturacion(ByVal xPunto As Integer,
                                          ByRef Param_1 As String,
                                          ByRef Param_2 As String,
                                          ByRef Param_3 As String,
                                          ByRef Param_4 As String,
                                          ByRef Param_5 As String,
                                          ByRef Param_6 As String,
                                          ByRef Param_7 As String)

        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)


        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdTemp As New OleDbCommand("Select * from Parametro_punto_de_venta WHERE (Punto = " & xPunto & ") AND (Estado=0) ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    Param_1 = drTemp("RazonSocial").ToString()
                    Param_2 = drTemp("RazonComercial").ToString()
                    Param_3 = drTemp("Domicilio").ToString()

                    Param_4 = drTemp("Cuit").ToString()
                    Param_5 = drTemp("IngresosBrutos").ToString()
                    Param_6 = drTemp("FechaInicioActiv").ToString()
                    If drTemp("IvaResponsable").ToString() = 1 Then
                        Param_7 = "IVA Responsable Inscripto"
                    End If
                    If drTemp("IvaResponsable").ToString() = 2 Then
                        Param_7 = "Consumidor Final"
                    End If
                    If drTemp("IvaResponsable").ToString() = 3 Then
                        Param_7 = "IVA Sujeto Exento"
                    End If
                    If drTemp("IvaResponsable").ToString() = 4 Then
                        Param_7 = "Responsable Monotributo"
                    End If
                End If
            End If
            drTemp.Close()
            ConSql.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_Modulo, MessageBoxButtons.OK)
            ConSql.Close()
        End Try

    End Sub
    Public Sub impresion_cupon_devolucion(ByVal xNumero As Long,
                                          ByVal xTipoImpresora As Byte,
                                          Optional ByVal xNombreArchivo As String = "")



        Dim dts As New DataSet

        Try

            Dim tabla As DataTable
            Dim campo As DataColumn
            Dim registro As DataRow
            tabla = New DataTable("estructuraComprobantes")
            campo = New DataColumn("Original", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("FechaEmision", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("LetraComprobante", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("CodigoComprobante", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("NumeroComprobante", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("TipoComprobante", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("CuitEmisor", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("IngresosBrutosEmisor", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("FechaInicioActividades", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EmpresaNombreComercial", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EmpresaRazonSocial", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EmpresaDomicilio", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("EmpresaResponsable", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("PeriodoFacturadoDesde", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("PeriodoFacturadoHasta", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("FechaVtoPago", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ClienteNumero", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ClienteNombre", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ClienteDomicilio", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ClienteProvincia", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ClienteCuit", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("ClienteResponsable", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("CondicionDeVenta", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("NumeroRemito", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Codigo", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("Producto", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("Cantidad", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("UnidadMedida", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("PrecioUnitario", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Bonificacion", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("SubTotal", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("AlicuotaIva", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("SubTotalIva", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ImpInt", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("IngBru", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("CantidadUnidades", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("ImporteNetoGrabado", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Iva27", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Iva21", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Iva105", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Iva5", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Iva25", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Iva0", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("OtrosTributos", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ImporteTotal", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("PercepRetenGanan", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("PercepRetenIva", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("PercepRetenIngBru", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ImpuestosInternos", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("ImpuestosMunicipales", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("OtrosImpuestos", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)
            campo = New DataColumn("Cae", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("FechaVtoCae", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("CodigoBarras", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)
            campo = New DataColumn("DetalleCodigoBarras", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("NumeroDocumento", GetType(System.Double))
            campo.DefaultValue = 0
            tabla.Columns.Add(campo)

            campo = New DataColumn("Observacion1", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Observacion2", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("FacturaOrigen", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Mensaje01", GetType(System.String))
            campo.DefaultValue = " "
            tabla.Columns.Add(campo)

            campo = New DataColumn("Imagen", GetType(System.Byte()))
            tabla.Columns.Add(campo)

            campo = New DataColumn("ImagenQr", GetType(System.Byte()))
            tabla.Columns.Add(campo)

            registro = tabla.NewRow


            Dim Param_1 As String = ""
            Dim Param_2 As String = ""
            Dim Param_3 As String = ""
            Dim Param_4 As String = ""
            Dim Param_5 As String = ""
            Dim Param_6 As String = ""
            Dim Param_7 As String = ""

            Call lectura_param_facturacion(99, Param_1, Param_2, Param_3, Param_4, Param_5, Param_6, Param_7)

            If Param_1.Trim = "" Then
                MessageBox.Show("Problemas en el Parámetro de Punto de Venta", rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
            Dim ConSql As New OleDbConnection(Conexion)
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()


            Dim Cantidad_Registros As Integer = 0

            Dim Sql As String = "Select * From Tickets WHERE (TicketNro= " & xNumero & ") AND (Estado=0) Order by Id"
            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                Do While drRecordSet.Read
                    registro = tabla.NewRow
                    registro("FechaEmision") = FormatDateTime(Date.Now, DateFormat.ShortDate)
                    registro("NumeroComprobante") = drRecordSet("TicketNro").ToString
                    registro("TipoComprobante") = "CUPON DE DEVOLUCION"
                    registro("CuitEmisor") = Param_4
                    registro("IngresosBrutosEmisor") = Param_5
                    registro("FechaInicioActividades") = FormatDateTime(Param_6, DateFormat.ShortDate)
                    registro("EmpresaNombreComercial") = Param_2
                    registro("EmpresaRazonSocial") = Param_1
                    registro("EmpresaDomicilio") = Param_3
                    registro("EmpresaResponsable") = Param_7
                    registro("Producto") = drRecordSet("Codigo").ToString.Trim & " " & drRecordSet("Detalle").ToString.Trim
                    registro("Cantidad") = Convert.ToDouble(drRecordSet("Cantidad").ToString)

                    tabla.Rows.Add(registro)

                    Cantidad_Registros = Cantidad_Registros + 1

                Loop
            End If

            dts.Tables.Add(tabla)

            If xTipoImpresora = 2 Then
                If Cantidad_Registros < 5 Then
                    Dim mi_CryResumen As New CrCuponDevolucion_Reducido_Simple()
                    mi_CryResumen.SetDataSource(dts.Tables("estructuraComprobantes"))
                    Dim miForma As New Form1000()
                    miForma.CrvReportes.ReportSource = mi_CryResumen
                    mi_CryResumen.PrintOptions.PrinterName = rsv_impresora_Termica
                    mi_CryResumen.PrintToPrinter(1, True, 0, 0)
                    mi_CryResumen.Dispose()
                End If
                If Cantidad_Registros >= 5 And Cantidad_Registros <= 10 Then
                    Dim mi_CryResumen As New CrCuponDevolucion_Reducido()
                    mi_CryResumen.SetDataSource(dts.Tables("estructuraComprobantes"))
                    Dim miForma As New Form1000()
                    miForma.CrvReportes.ReportSource = mi_CryResumen
                    mi_CryResumen.PrintOptions.PrinterName = rsv_impresora_Termica
                    mi_CryResumen.PrintToPrinter(1, True, 0, 0)
                    mi_CryResumen.Dispose()
                End If
                If Cantidad_Registros > 10 Then
                    Dim mi_CryResumen As New CrCuponDevolucion()
                    mi_CryResumen.SetDataSource(dts.Tables("estructuraComprobantes"))
                    Dim miForma As New Form1000()
                    miForma.CrvReportes.ReportSource = mi_CryResumen
                    mi_CryResumen.PrintOptions.PrinterName = rsv_impresora_Termica
                    mi_CryResumen.PrintToPrinter(1, True, 0, 0)
                    mi_CryResumen.Dispose()
                End If
            End If

            If xTipoImpresora = 3 Then
                Dim mi_CryResumen As New CrCuponDevolucion_Reducido_Simple()
                mi_CryResumen.SetDataSource(dts.Tables("estructuraComprobantes"))

                Dim miForma As New Form1000()
                miForma.CrvReportes.ReportSource = mi_CryResumen
                miForma.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

End Module

Imports QRCoder
Module procedimientos_genera_qr
    'QR
    Public Function especificaciones_qr(ByVal xFecha As String, ByVal xCuit_Emisor As String, ByVal xPunto_Vta As String, _
                                          ByVal xTipo_Compro As String, ByVal xNro_Compro As String, ByVal xImporte As String, _
                                          ByVal xMoneda As String, ByVal xCotizacion As String, ByVal xTipo_Doc_Recep As String, _
                                          ByVal xNro_Doc_Recep As String, ByVal xTipo_Codigo_Autor As String, ByVal xCodigo_Autor As String) As String

        Dim r As String = ""
        Dim p1 As String = "2020-10-13"
        Dim p2 As String = "30000000007"
        Dim p3 As String = "10"
        Dim p4 As String = "1"
        Dim p5 As String = "94"
        Dim p6 As String = "12100"
        Dim p7 As String = "DOL"
        Dim p8 As String = "65"
        Dim p9 As String = "80"
        Dim p10 As String = "20000000001"
        Dim p11 As String = "E"
        Dim p12 As String = "70417054367476"


        p1 = xFecha
        p2 = xCuit_Emisor
        p3 = xPunto_Vta
        p4 = xTipo_Compro
        p5 = xNro_Compro
        p6 = xImporte
        p7 = xMoneda
        p8 = xCotizacion
        p9 = xTipo_Doc_Recep
        p10 = xNro_Doc_Recep
        p11 = xTipo_Codigo_Autor
        p12 = xCodigo_Autor

        Dim r1 As String = "{" & Chr(34) & "ver" & Chr(34) & ":1,"
        Dim r2 As String = Chr(34) & "fecha" & Chr(34) & ":" & Chr(34) & p1 & Chr(34) & ","
        Dim r3 As String = Chr(34) & "cuit" & Chr(34) & ":" & p2 & ","
        Dim r4 As String = Chr(34) & "ptoVta" & Chr(34) & ":" & p3 & ","
        Dim r5 As String = Chr(34) & "tipoCmp" & Chr(34) & ":" & p4 & ","
        Dim r6 As String = Chr(34) & "nroCmp" & Chr(34) & ":" & p5 & ","
        Dim r7 As String = Chr(34) & "importe" & Chr(34) & ":" & p6 & ","
        Dim r8 As String = Chr(34) & "moneda" & Chr(34) & ":" & Chr(34) & p7 & Chr(34) & ","
        Dim r9 As String = Chr(34) & "ctz" & Chr(34) & ":" & p8 & ","
        Dim r10 As String = Chr(34) & "tipoDocRec" & Chr(34) & ":" & p9 & ","
        Dim r11 As String = Chr(34) & "nroDocRec" & Chr(34) & ":" & p10 & ","
        Dim r12 As String = Chr(34) & "tipoCodAut" & Chr(34) & ":" & Chr(34) & p11 & Chr(34) & ","
        Dim r13 As String = Chr(34) & "codAut" & Chr(34) & ":" & p12 & "}"


        r = r1 & r2 & r3 & r4 & r5 & r6 & r7 & r8 & r9 & r10 & r11 & r12 & r13

        Dim p_url As String = "https://www.afip.gob.ar/fe/qr/" & "?p="
        Dim p_base_64 As String = EncodeStrToBase64(r)
        Dim p_qr As String = p_url & p_base_64

        especificaciones_qr = p_qr
    End Function

    Public Sub generar_archivo_qr(ByVal xCadenaQr As String, ByVal xNombreArchivoQr As String)

        'Dim generadoQr As BarcodeWriter = New BarcodeWriter
        'generadoQr.Format = BarcodeFormat.QR_CODE
        'Try

        '    Dim imagenQR As Bitmap = New Bitmap(generadoQr.Write(xCadenaQr), 400, 300)
        '    '            Dim rsv_Path_Qr As String = My.Computer.FileSystem.CurrentDirectory & "\qr\" & xNombreArchivoQr
        '    Dim rsv_Path_Qr As String = xNombreArchivoQr

        '    imagenQR.Save(rsv_Path_Qr)


        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


        Try
            Dim generadoQr As New QRCodeGenerator
            Dim data = generadoQr.CreateQrCode(xCadenaQr.Trim, QRCodeGenerator.ECCLevel.Q)
            Dim code As New QRCode(data)
            Dim obj_bitMap As New Bitmap(code.GetGraphic(6))
            With obj_bitMap
                .Save(xNombreArchivoQr, Imaging.ImageFormat.Bmp)
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
 
    End Sub
End Module

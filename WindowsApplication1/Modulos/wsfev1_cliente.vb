Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Module wsfev1_cliente
    Dim objWSFEV1 As New wsfev1.Service
    Dim FEAuthRequest As New wsfev1.FEAuthRequest

    Public Function state_service_afip() As Boolean
        Dim r As Boolean = False
        Dim objDummy As New wsfev1.DummyResponse


        If rsv_Afip_Homolog = 0 Then
            objWSFEV1.Url = "https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL"
        End If


        objDummy = objWSFEV1.FEDummy

        If objDummy.AppServer.ToString.Trim.ToUpper = "OK" And objDummy.AuthServer.ToString.Trim.ToUpper = "OK" And objDummy.DbServer.ToString.Trim.ToUpper = "OK" Then
            r = True
        End If
        state_service_afip = r
    End Function
    Public Function consulta_ultimo_comprobante_afip(ByVal txt_ptovta As String, ByVal txt_tipo As String, _
                                                     ByRef cod_err As Byte, ByRef msg_err As String) As String

        Dim r_Numero_Comprobante As String = ""

        Dim txt_Token As String = ""
        Dim txt_sign As String = ""
        Dim txt_cuit As String = ""
        Dim arg_e As Byte = 0
        Call lectura_ticket(txt_Token, txt_sign, txt_cuit, arg_e)
        If arg_e = 0 Then
            arg_e = 0
            Call FECompUltimoAutorizado(txt_Token, txt_sign, txt_cuit, txt_ptovta, txt_tipo, r_Numero_Comprobante, arg_e, msg_err)
        Else
            cod_err = 1
            msg_err = "Error en apertura de Ticket"
        End If

        consulta_ultimo_comprobante_afip = r_Numero_Comprobante
    End Function



    Private Sub FECompUltimoAutorizado(ByVal txt_token As String, _
                                       ByVal txt_sign As String, _
                                       ByVal txt_cuit As String, _
                                       ByVal txt_ptovta As String, _
                                       ByVal txt_tipo As String, _
                                       ByRef r_Numero_Comprobante As String, _
                                       ByRef arg_e As Byte, _
                                       ByRef msg_err As String)
        FEAuthRequest.Token = txt_token
        FEAuthRequest.Sign = txt_sign
        FEAuthRequest.Cuit = txt_cuit
        Dim PtoVta As Long = txt_ptovta
        Dim CbteTipo As Long = txt_tipo
        Dim objFERecuperaLastCbteResponse As wsfev1.FERecuperaLastCbteResponse

        ' Invoco al método FECompUltimoAutorizado
        Try

            If rsv_Afip_Homolog = 0 Then
                objWSFEV1.Url = "https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL"
            End If


            objFERecuperaLastCbteResponse = objWSFEV1.FECompUltimoAutorizado(FEAuthRequest, PtoVta, CbteTipo)
            If objFERecuperaLastCbteResponse IsNot Nothing Then
                r_Numero_Comprobante = objFERecuperaLastCbteResponse.CbteNro.ToString
                arg_e = 0
                msg_err = ""
                '                MessageBox.Show("objFERecuperaLastCbte.CbteNro: " + objFERecuperaLastCbteResponse.CbteNro.ToString + vbCrLf _
                '                , "objFERecuperaLastCbte.CbteNro")
            End If
            If objFERecuperaLastCbteResponse.Errors IsNot Nothing Then
                For i = 0 To objFERecuperaLastCbteResponse.Errors.Length - 1
                    msg_err = msg_err & objFERecuperaLastCbteResponse.Errors(i).Code.ToString & " " & objFERecuperaLastCbteResponse.Errors(i).Msg
                    r_Numero_Comprobante = ""
                    arg_e = 1
                    'MessageBox.Show("objFERecuperaLastCbte.Errors(i).Code: " + objFERecuperaLastCbteResponse.Errors(i).Code.ToString + vbCrLf +
                    '"objFERecuperaLastCbte.Errors(i).Msg: " + objFERecuperaLastCbteResponse.Errors(i).Msg)
                Next
            End If
            If objFERecuperaLastCbteResponse.Events IsNot Nothing Then
                For i = 0 To objFERecuperaLastCbteResponse.Events.Length - 1
                    msg_err = msg_err & objFERecuperaLastCbteResponse.Events(i).Code.ToString & " " & objFERecuperaLastCbteResponse.Events(i).Msg


                    'r_Numero_Comprobante = ""
                    'arg_e = 1
                    '                    MessageBox.Show("objFERecuperaLastCbte.Events(i).Code: " + objFERecuperaLastCbteResponse.Events(i).Code.ToString + vbCrLf +
                    '                    "objFERecuperaLastCbte.Events(i).Msg: " + objFERecuperaLastCbteResponse.Events(i).Msg)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Sub lectura_ticket(ByRef txt_token As String, ByRef txt_sign As String, ByRef txt_cuit As String, ByRef arg_e As Byte)

        If rsv_Afip_Homolog = 1 Then
            objWSFEV1.Url = "https://wswhomo.afip.gov.ar/wsfev1/service.asmx"
        Else
            objWSFEV1.Url = "https://servicios1.afip.gov.ar/wsfev1/service.asmx"
        End If

        '        Dim RUTATICKETACCESO = "C:\TicketAfip\TA.xml"      ' Debe indicar la Ruta de su Ticket de acceso
        Dim RUTATICKETACCESO = rsv_Afip_Tickets & "\TA.xml"      ' Debe indicar la Ruta de su Ticket de acceso
        Dim tokenBytes As Byte()
        Dim tokenString As String

        arg_e = 0

        If FileExists(RUTATICKETACCESO) Then
            Dim xmldCredentials As XmlDocument
            Dim xmlnlCredentials As XmlNodeList
            Dim xmlnCredentials As XmlNode
            xmldCredentials = New XmlDocument()
            xmldCredentials.Load(RUTATICKETACCESO)
            xmlnlCredentials = xmldCredentials.SelectNodes("/loginTicketResponse/credentials")
            For Each xmlnCredentials In xmlnlCredentials
                txt_token = xmlnCredentials.ChildNodes.Item(0).InnerText
                txt_sign = xmlnCredentials.ChildNodes.Item(1).InnerText

                tokenBytes = System.Convert.FromBase64String(xmlnCredentials.ChildNodes.Item(0).InnerText)
                tokenString = System.Text.Encoding.UTF8.GetString(tokenBytes)
                Dim xmldToken As XmlDocument
                Dim xmlnlToken As XmlNodeList
                Dim xmlnToken As XmlNode
                xmldToken = New XmlDocument()
                xmldToken.LoadXml(tokenString)
                xmlnlToken = xmldToken.SelectNodes("/sso/operation/login/relations/relation")
                For Each xmlnToken In xmlnlToken
                    txt_cuit = (xmlnToken.Attributes("key").InnerText)
                    Exit For
                Next
            Next
            '            FEAuthRequest.Token = txt_token.Text
            '            FEAuthRequest.Sign = txt_sign.Text
            '            FEAuthRequest.Cuit = cmb_cuit.Items(0)
        Else
            arg_e = 1
        End If
    End Sub
    Public Sub FEDummy_AppServer()
        Dim objDummy As New wsfev1.DummyResponse
        ' Invoco al método Dummy
        Try
            If rsv_Afip_Homolog = 0 Then
                objWSFEV1.Url = "https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL"
            End If
            objDummy = objWSFEV1.FEDummy
            MessageBox.Show(objDummy.AppServer, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub FEDummy_AuthServer()
        Dim objDummy As New wsfev1.DummyResponse
        ' Invoco al método Dummy
        Try
            If rsv_Afip_Homolog = 0 Then
                objWSFEV1.Url = "https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL"
            End If
            objDummy = objWSFEV1.FEDummy
            MessageBox.Show(objDummy.AuthServer, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub FEDummy_DbServer()
        Dim objDummy As New wsfev1.DummyResponse
        ' Invoco al método Dummy
        Try
            If rsv_Afip_Homolog = 0 Then
                objWSFEV1.Url = "https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL"
            End If
            objDummy = objWSFEV1.FEDummy
            MessageBox.Show(objDummy.DbServer, rsv_Modulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



    Public Sub FECAESolicitar(ByVal txt_token As String, ByVal txt_sign As String,
                              ByVal txt_cuit As String, ByVal txt_ptovta As String, ByVal txt_tipo As String,
                              ByVal txt_con As String, ByVal txt_doctipo As String, ByVal txt_docnro As String, ByVal txt_cbtedes As String,
                              ByVal txt_cbtehas As String, ByVal txt_cbteFch As String, ByVal txt_imptot As String, ByVal txt_imptotconc As String, ByVal txt_impneto As String,
                              ByVal txt_impopex As String, ByVal txt_imptrib As String, ByVal txt_impiva As String, ByVal txt_fecserdes As String,
                              ByVal txt_fecserhas As String, ByVal txt_fecvtopago As String, ByVal txt_monid As String, ByVal txt_moncot As String,
                              ByVal txt_iva_baseimp1 As String, ByVal txt_iva_id1 As String, ByVal txt_iva_imp1 As String,
                              ByVal txt_iva_baseimp2 As String, ByVal txt_iva_id2 As String, ByVal txt_iva_imp2 As String,
                              ByVal txt_letra_comp As String, ByVal txt_nro_comp As String, ByVal Cant_Alic As Byte,
                              ByVal Cant_CpteAsoc As Byte, ByVal txt_CpteAsoc_Cuit1 As String, ByVal txt_CpteAsoc_Tipo1 As String, ByVal txt_CpteAsoc_PtoVta1 As String, ByVal txt_CpteAsoc_Nro1 As String,
                              ByVal txt_CpteAsoc_Cuit2 As String, ByVal txt_CpteAsoc_Tipo2 As String, ByVal txt_CpteAsoc_PtoVta2 As String, ByVal txt_CpteAsoc_Nro2 As String,
                              ByVal txt_CpteAsoc_Cuit3 As String, ByVal txt_CpteAsoc_Tipo3 As String, ByVal txt_CpteAsoc_PtoVta3 As String, ByVal txt_CpteAsoc_Nro3 As String,
                              ByVal txt_CondicionIVAReceptorId As String,
                              ByRef txt_cae_result As String, ByRef txt_cae As String, ByRef txt_Fec_vto_cae As String, ByRef txt_msg_err As String)



        txt_cae_result = "EE"

        FEAuthRequest.Token = txt_token
        FEAuthRequest.Sign = txt_sign
        FEAuthRequest.Cuit = txt_cuit


        If rsv_Afip_Homolog = 0 Then
            objWSFEV1.Url = "https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL"
        End If



        Dim objFECAECabRequest As New wsfev1.FECAECabRequest
        Dim objFECAERequest As New wsfev1.FECAERequest
        Dim objFECAEResponse As New wsfev1.FECAEResponse

        Dim indicemax_arrayFECAEDetRequest As Integer = 0
        Dim d_arrayFECAEDetRequest As Integer = 0
        Dim arrayFECAEDetRequest(indicemax_arrayFECAEDetRequest) As wsfev1.FECAEDetRequest

        objFECAECabRequest.CantReg = "1"
        objFECAECabRequest.CbteTipo = txt_tipo
        objFECAECabRequest.PtoVta = txt_ptovta

        For d_arrayFECAEDetRequest = 0 To (indicemax_arrayFECAEDetRequest)
            Dim objFECAEDetRequest As New wsfev1.FECAEDetRequest
            With objFECAEDetRequest
                .Concepto = txt_con
                .DocTipo = txt_doctipo
                .DocNro = txt_docnro
                .CbteDesde = txt_cbtedes
                .CbteHasta = txt_cbtehas
                .CbteFch = txt_cbteFch
                .ImpTotal = txt_imptot
                .ImpTotConc = txt_imptotconc
                .ImpNeto = txt_impneto
                .ImpOpEx = txt_impopex
                .ImpTrib = txt_imptrib
                .ImpIVA = txt_impiva
                .FchServDesde = txt_fecserdes
                .FchServHasta = txt_fecserhas
                .FchVtoPago = txt_fecvtopago
                .MonId = txt_monid
                .MonCotiz = txt_moncot
                .MonCotizSpecified = True
                .CanMisMonExt = "N"
                .CondicionIVAReceptorId = Val(txt_CondicionIVAReceptorId)
                '           .CondicionIVAReceptorIdSpecified = True
            End With

            'Comprobantes Asociados Por Notas de Creditos y Notas de Debito

            If Cant_CpteAsoc <> 0 Then

                Cant_CpteAsoc = Cant_CpteAsoc - 1

                'Implementado
                Dim objFECPTEASOCrequest As New wsfev1.FECAERequest

                Dim indicemax_arrayFECPTEASOCDetRequest As Integer = Cant_CpteAsoc

                Dim d_arrayFECPTEASOCDetRequest As Integer = 0
                Dim arrayFECPTEASOCDetRequest(indicemax_arrayFECPTEASOCDetRequest) As wsfev1.CbteAsoc


                For d_arrayFECPTEASOCDetRequest = 0 To (indicemax_arrayFECPTEASOCDetRequest)
                    Dim objFECPTEASOCDetRequest As New wsfev1.CbteAsoc

                    If d_arrayFECPTEASOCDetRequest = 0 Then

                        With objFECPTEASOCDetRequest
                            .Cuit = txt_CpteAsoc_Cuit1
                            .Nro = txt_CpteAsoc_Nro1
                            .PtoVta = txt_CpteAsoc_PtoVta1
                            .Tipo = txt_CpteAsoc_Tipo1
                        End With
                    End If

                    If d_arrayFECPTEASOCDetRequest = 1 Then

                        With objFECPTEASOCDetRequest
                            .Cuit = txt_CpteAsoc_Cuit2
                            .Nro = txt_CpteAsoc_Nro2
                            .PtoVta = txt_CpteAsoc_PtoVta2
                            .Tipo = txt_CpteAsoc_Tipo2
                        End With

                    End If

                    If d_arrayFECPTEASOCDetRequest = 2 Then

                        With objFECPTEASOCDetRequest
                            .Cuit = txt_CpteAsoc_Cuit3
                            .Nro = txt_CpteAsoc_Nro3
                            .PtoVta = txt_CpteAsoc_PtoVta3
                            .Tipo = txt_CpteAsoc_Tipo3
                        End With

                    End If

                    arrayFECPTEASOCDetRequest(d_arrayFECPTEASOCDetRequest) = objFECPTEASOCDetRequest

                Next d_arrayFECPTEASOCDetRequest

                objFECAEDetRequest.CbtesAsoc = arrayFECPTEASOCDetRequest

            End If
            '''''''''''''''''''

            'Distintas Alicuotas de Iva
            If Cant_Alic <> 0 Then

                Cant_Alic = Cant_Alic - 1

                Dim txt_iva_baseimp_r As String = ""
                Dim txt_iva_id_r As String = ""
                Dim txt_iva_imp_r As String = ""


                'Implementado
                Dim objFEIVArequest As New wsfev1.FECAERequest

                Dim indicemax_arrayFEIVADetRequest As Integer = Cant_Alic

                Dim d_arrayFEIVADetRequest As Integer = 0
                Dim arrayFEIVADetRequest(indicemax_arrayFEIVADetRequest) As wsfev1.AlicIva


                For d_arrayFEIVADetRequest = 0 To (indicemax_arrayFEIVADetRequest)
                    Dim objFEIVADetRequest As New wsfev1.AlicIva

                    If d_arrayFEIVADetRequest = 0 Then

                        If Cant_Alic = 0 Or Cant_Alic = 1 Then

                            If Convert.ToDouble(txt_iva_baseimp1.Trim) <> 0 Then
                                txt_iva_baseimp_r = txt_iva_baseimp1
                                txt_iva_id_r = txt_iva_id1
                                txt_iva_imp_r = txt_iva_imp1
                            Else
                                If Convert.ToDouble(txt_iva_baseimp2.Trim) <> 0 Then
                                    txt_iva_baseimp_r = txt_iva_baseimp2
                                    txt_iva_id_r = txt_iva_id2
                                    txt_iva_imp_r = txt_iva_imp2
                                End If
                            End If

                        End If

                        With objFEIVADetRequest
                            .BaseImp = txt_iva_baseimp_r
                            .Id = txt_iva_id_r
                            .Importe = txt_iva_imp_r
                        End With
                    End If

                    If d_arrayFEIVADetRequest = 1 Then

                        If Cant_Alic = 1 Then
                            If Convert.ToDouble(txt_iva_baseimp2.Trim) <> 0 Then
                                txt_iva_baseimp_r = txt_iva_baseimp2
                                txt_iva_id_r = txt_iva_id2
                                txt_iva_imp_r = txt_iva_imp2
                            End If
                        End If

                        With objFEIVADetRequest
                            .BaseImp = txt_iva_baseimp_r
                            .Id = txt_iva_id_r
                            .Importe = txt_iva_imp_r
                        End With

                    End If

                    arrayFEIVADetRequest(d_arrayFEIVADetRequest) = objFEIVADetRequest

                Next d_arrayFEIVADetRequest

                objFECAEDetRequest.Iva = arrayFEIVADetRequest

            End If

            arrayFECAEDetRequest(d_arrayFECAEDetRequest) = objFECAEDetRequest

        Next d_arrayFECAEDetRequest

        With objFECAERequest
            .FeCabReq = objFECAECabRequest
            .FeDetReq = arrayFECAEDetRequest
        End With


        ' Invoco al método FECAESolicitar
        Try
            Dim File_Response As String = ""
            Dim file_fecha As String = fecha_hora_lineal()

            '            File_Response = "C:\TicketAfip\Respuestas\WSFEV1_Response_" & txt_letra_comp & "_" & txt_nro_comp & file_fecha & ".xml"
            File_Response = rsv_Afip_xml & "\" & "WSFEV1_Response_" & txt_letra_comp & "_" & txt_nro_comp & "_" & file_fecha & ".xml"
            objFECAEResponse = objWSFEV1.FECAESolicitar(FEAuthRequest, objFECAERequest)
            If objFECAEResponse IsNot Nothing Then

                txt_msg_err = ""

                Dim objStreamWriter As New StreamWriter(File_Response)
                Dim x As New XmlSerializer(objFECAEResponse.GetType)
                x.Serialize(objStreamWriter, objFECAEResponse)
                objStreamWriter.Close()

                Dim objRespuesta As New wsfev1.FECAEDetResponse
                Dim i As Integer
                For i = 0 To UBound(objFECAEResponse.FeDetResp)
                    objRespuesta = objFECAEResponse.FeDetResp(i)

                    txt_cae = objRespuesta.CAE
                    txt_Fec_vto_cae = objRespuesta.CAEFchVto
                    txt_cae_result = objRespuesta.Resultado
                Next

            End If
            If objFECAEResponse.Errors IsNot Nothing Then

                txt_msg_err = ""
                txt_cae_result = "E"

                Dim objStreamWriter As New StreamWriter(File_Response)
                Dim x As New XmlSerializer(objFECAEResponse.GetType)
                x.Serialize(objStreamWriter, objFECAEResponse)
                objStreamWriter.Close()
                For i = 0 To objFECAEResponse.Errors.Length - 1
                    txt_msg_err = txt_msg_err & " " & objFECAEResponse.Errors(i).Code.ToString & " " & objFECAEResponse.Errors(i).Msg
                Next
            End If
            If objFECAEResponse.Events IsNot Nothing Then
                txt_msg_err = ""
                '    txt_cae_result = "EE"

                Dim objStreamWriter As New StreamWriter(File_Response)
                Dim x As New XmlSerializer(objFECAEResponse.GetType)
                x.Serialize(objStreamWriter, objFECAEResponse)
                objStreamWriter.Close()
                For i = 0 To objFECAEResponse.Events.Length - 1
                    txt_msg_err = txt_msg_err & " " & objFECAEResponse.Events(i).Code.ToString & " " & objFECAEResponse.Events(i).Msg
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function FECompConsultar(ByVal txt_token As String, ByVal txt_sign As String, _
                               ByVal txt_cuit As String, ByVal txt_ptovta As String, _
                               ByVal txt_tipo As String, ByVal txt_nro As String) As String


        Dim Txt_Res As String = ""

        FEAuthRequest.Token = txt_token
        FEAuthRequest.Sign = txt_sign
        FEAuthRequest.Cuit = txt_cuit
        Dim objFECompConsultaReq As New wsfev1.FECompConsultaReq
        Dim objFECompConsultaResponse As wsfev1.FECompConsultaResponse
        objFECompConsultaReq.PtoVta = txt_ptovta
        objFECompConsultaReq.CbteTipo = txt_tipo
        objFECompConsultaReq.CbteNro = txt_nro

        ' Invoco al método FECompConsultar
        Try

            If rsv_Afip_Homolog = 0 Then
                objWSFEV1.Url = "https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL"
            End If

            objFECompConsultaResponse = objWSFEV1.FECompConsultar(FEAuthRequest, objFECompConsultaReq)
            If objFECompConsultaResponse IsNot Nothing Then


                'Dim objStreamWriter As New StreamWriter("C:\TicketAfip\WSFEV1_objFECompConsulta.xml")
                'Dim x As New XmlSerializer(objFECompConsultaResponse.GetType)
                'x.Serialize(objStreamWriter, objFECompConsultaResponse)
                'objStreamWriter.Close()
                'MessageBox.Show("Se generó el archivo C:\TicketAfip\WSFEV1_objFECompConsulta.xml")


                Dim x1 As New Xml.Serialization.XmlSerializer(objFECompConsultaResponse.GetType)
                Dim sw As New IO.StringWriter()
                Dim xw As New XmlTextWriter(sw)
                xw.Formatting = Formatting.None
                x1.Serialize(xw, objFECompConsultaResponse)
                Txt_Res = sw.ToString


            End If
            If objFECompConsultaResponse.Errors IsNot Nothing Then
                For i = 0 To objFECompConsultaResponse.Errors.Length - 1

                    Txt_Res = Txt_Res & "Error: " & objFECompConsultaResponse.Errors(i).Code.ToString & vbCrLf & objFECompConsultaResponse.Errors(i).Msg & vbCrLf
                    '                    MessageBox.Show("objFECompConsulta.Errors(i).Code: " + objFECompConsultaResponse.Errors(i).Code.ToString + vbCrLf +
                    '                    "objFECompConsulta.Errors(i).Msg: " + objFECompConsultaResponse.Errors(i).Msg)
                Next
            End If
            If objFECompConsultaResponse.Events IsNot Nothing Then
                For i = 0 To objFECompConsultaResponse.Events.Length - 1
                    Txt_Res = Txt_Res & "Error: " & objFECompConsultaResponse.Events(i).Code.ToString & vbCrLf & objFECompConsultaResponse.Events(i).Msg & vbCrLf

                    '                    MessageBox.Show("objFECompConsulta.Events(i).Code: " + objFECompConsultaResponse.Events(i).Code.ToString + vbCrLf +
                    '                    "objFECompConsulta.Events(i).Msg: " + objFECompConsultaResponse.Events(i).Msg)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            FECompConsultar = Txt_Res
        End Try
    End Function


End Module

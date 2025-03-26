Imports System.Net.Mail
Imports System.Net.Mail.Attachment
Imports System.Data.OleDb.OleDbDataReader
Imports System.Data.OleDb.OleDbDataAdapter
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Net


'Correo
'HelpTEC_lapampa@yahoo.com
'Pilchas20


Module procedimientos_mail
    Private Declare Function IsNetworkAlive Lib "SENSAPI.DLL" (ByRef lpdwFlags As Long) As Long

    Public Function enviar_mail(ByVal eMail As String, ByVal eTitulo As String, _
                                ByVal eTexto As String, ByVal eFile1 As String, ByVal eFile2 As String, _
                                ByVal eRegis As Long) As Byte
        Dim Ret As Byte = 1
        Try
            Dim xServidor As String = ""
            Dim xPuerto As String = ""
            Dim xCorreo As String = ""
            Dim xPass As String = ""

            Call retorna_parametros_correo(xServidor, xPuerto, xCorreo, xPass)

            If xServidor = "" Then
                Exit Function
            End If

            If IsNetworkAlive(Ret) <> 0 Then
                If eFile1.Trim <> "" Then
                    Dim MyMailMsg As New MailMessage
                    Dim HostName As String = My.Computer.Name
                    Dim AddFile1 As New Mail.Attachment(eFile1)
                    '         Dim AddFile2 As New Mail.Attachment(eFile2)

                    MyMailMsg.From = New MailAddress(xCorreo)
                    MyMailMsg.To.Add(eMail)
                    MyMailMsg.Subject = eTitulo
                    MyMailMsg.Attachments.Add(AddFile1)
                    '      MyMailMsg.Attachments.Add(AddFile2)
                    MyMailMsg.Body = (eTexto)
                    Dim SMTP As New SmtpClient(xServidor) 'para enviar por Hotmail, SMTP de Gmail (smtp.gmail.com) veo que en tu codigo te falto agregar "smtp"
                    SMTP.Port = Convert.ToInt16(xPuerto)
                    SMTP.EnableSsl = False
                    SMTP.Credentials = New System.Net.NetworkCredential(xCorreo, xPass)
                    SMTP.Send(MyMailMsg)
                    Ret = 0

                    Call mail_enviados_ok(eRegis)

                End If
                If eFile1.Trim = "" Then
                    Dim MyMailMsg As New MailMessage
                    Dim HostName As String = My.Computer.Name
                    MyMailMsg.From = New MailAddress(xCorreo)
                    MyMailMsg.To.Add(eMail)
                    MyMailMsg.Subject = eTitulo
                    MyMailMsg.Body = (eTexto)
                    Dim SMTP As New SmtpClient(xServidor) 'para enviar por Hotmail, SMTP de Gmail (smtp.gmail.com) veo que en tu codigo te falto agregar "smtp"
                    SMTP.Port = Convert.ToInt16(xPuerto)
                    SMTP.EnableSsl = False
                    SMTP.Credentials = New System.Net.NetworkCredential(xCorreo, xPass)
                    SMTP.Send(MyMailMsg)
                    Ret = 0
                    Call mail_enviados_ok(eRegis)
                End If


            End If


        Catch ex As Exception
            '            MsgBox(ex.InnerException.ToString)
        Finally
            enviar_mail = Ret
        End Try

    End Function

    Private Sub mail_enviados_ok(ByVal eRegis As Long)
        Try

            Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
            Dim ConSql As New OleDbConnection(Conexion)

            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If
 
            Dim Sql As String = "Update Seguimiento_Mail SET Ok=1 WHERE Id= " & eRegis & " "

            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()


        Catch ex As Exception
            MessageBox.Show("Error al conectar o recuperar lo datos :" & vbCrLf & _
                             ex.Message, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Error)


        End Try
    End Sub
    Private Sub retorna_parametros_correo(ByRef xServidor As String, ByRef xPuerto As String, ByRef xCorreo As String, _
                                          ByRef xPass As String)
        Dim eMail As String = ""
        Try
            Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
            Dim ConSql As New OleDbConnection(Conexion)

            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim cmdSql As New OleDbCommand("Select * from Servicio_Mail where Id=1", ConSql)
            Dim drSql As OleDbDataReader = cmdSql.ExecuteReader
            If drSql.HasRows Then 'Tiene filas
                If drSql.Read = True Then
                    xServidor = drSql("Servidor").ToString
                    xPuerto = drSql("Puerto").ToString
                    xCorreo = drSql("Correo").ToString
                    xPass = drSql("Clave").ToString
                End If
            End If
            drSql.Close()

        Catch ex As Exception
            MessageBox.Show("Error al conectar o recuperar lo datos :" & vbCrLf & _
                             ex.Message, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Error)


        End Try
    End Sub


    Public Sub log_mail_enviados(ByVal eMail As String, ByVal eTitulo As String, ByVal eTexto As String, ByVal eFile As String, ByRef eRegis As Long)
        Try
            Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
            Dim ConSql As New OleDbConnection(Conexion)
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim j1 As Integer
            Dim j2 As String
            Dim j3 As String

            j1 = rsv_Usuario

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            j2 = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
            j3 = TimeOfDay.ToString("hh:mm:ss")


            Dim Sql As String = ""
            Sql = "Insert Into  Seguimiento_Mail (Fecha,Usuario,Mail,Titulo,Texto,Archivo,Hora) Values ('" & j2 & "'," & j1 & ",'" & eMail & "','" & eTitulo & "','" & eTexto & "','" & eFile & "','" & j3 & "')"
            Sql = Sql & "SELECT SCOPE_IDENTITY()"

            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            eRegis = cmdActualizar.ExecuteScalar
            cmdActualizar.Dispose()


        Catch ex As Exception
            MessageBox.Show("Error al conectar o recuperar lo datos :" & vbCrLf & _
                             ex.Message, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Error)


        End Try
    End Sub
    Public Sub actualizar_mail_enviado(ByVal id_Reg As Long)
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)

        If ConSql.State = ConnectionState.Closed Then
            ConSql.Open()
        End If

        Dim InsSql As String = "Update Seguimiento_Mail SET oK=1  WHERE Id= " & id_Reg & ""

        Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
        cmdActualizar.ExecuteNonQuery()
        cmdActualizar.Dispose()
    End Sub

    Public Function validacion_mail(ByVal xMail As String) As Byte
        Dim r As Byte = 0
        Try
            Dim mail As New System.Net.Mail.MailAddress(xMail)
            r = 0
        Catch ex As Exception
            r = 1
        Finally
            validacion_mail = r
        End Try
    End Function
End Module

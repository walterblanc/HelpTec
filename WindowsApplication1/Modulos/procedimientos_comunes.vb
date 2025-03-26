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
Imports System.Windows.Forms


Module procedimientos_comunes
    Public rsv_NombreModulo As String = "Gestión Administrativa Comercial"
    Public rsv_Usuario As Integer
    Public rsv_Seleccion As String
    Public rsv_Io As Byte
    Public rsv_Terminal As Byte
    Public rsv_Habilitado As Boolean
    Public rsv_Numero As Double
    Public rsv_Servidor As String
    Public rsv_Modulo As String
    Public rsv_Database As String
    Public rsv_CambioClave As Boolean
    Public rsv_CambioClaveRealizado As Boolean
    Public rsv_prg_orig As String
    Public rsv_arr() As String
    Public rsv_Impresora_Defecto As String
    Public rsv_impresora_Termica As String

    Public rsv_Numero1 As Double
    Public rsv_Numero2 As Double
    Public rsv_Numero3 As Double

    Public rsv_CpteAsoc_Cuit1 As String = ""
    Public rsv_CpteAsoc_Tipo1 As String = ""
    Public rsv_CpteAsoc_Letra1 As String = ""
    Public rsv_CpteAsoc_Fecha1 As Date = Now.Date
    Public rsv_CpteAsoc_Pto1 As Integer = 0
    Public rsv_CpteAsoc_Nro1 As Integer = 0

    Public rsv_CpteAsoc_Cuit2 As String = ""
    Public rsv_CpteAsoc_Tipo2 As String = ""
    Public rsv_CpteAsoc_Letra2 As String = ""
    Public rsv_CpteAsoc_Fecha2 As Date = Now.Date
    Public rsv_CpteAsoc_Pto2 As Integer = 0
    Public rsv_CpteAsoc_Nro2 As Integer = 0

    Public rsv_CpteAsoc_Cuit3 As String = ""
    Public rsv_CpteAsoc_Tipo3 As String = ""
    Public rsv_CpteAsoc_Letra3 As String = ""
    Public rsv_CpteAsoc_Fecha3 As Date = Now.Date
    Public rsv_CpteAsoc_Pto3 As Integer = 0
    Public rsv_CpteAsoc_Nro3 As Integer = 0


    Public rsv_Afip_Homolog As Byte = 0
    Public rsv_Afip_Llave As String = ""
    Public rsv_Afip_Certif As String = ""
    Public rsv_Afip_Tickets As String = ""
    Public rsv_Afip_xml As String = ""

    Public Function parametroSistema(ByVal numeroTabla As Integer, ByVal numeroCodigo As Integer) As String
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim Retorno_funcion As String
        Retorno_funcion = ""

        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim cmdTemp As New OleDbCommand("Select * from Parametros where Param= " & _
                                          numeroTabla & " and Numero = " & numeroCodigo & " ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    Retorno_funcion = drTemp("Detalle").ToString()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
        Finally
            parametroSistema = Retorno_funcion
        End Try
    End Function
    Public Sub Codigo_Bancario(ByVal numeroCodigo As Integer, ByRef xDetalle As String, ByRef xDebCre As Integer)
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
       

        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim cmdTemp As New OleDbCommand("Select * from Codigos_Bancarios WHERE Codigo = " & numeroCodigo & " ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    xDetalle = drTemp("Detalle").ToString()
                    xDebCre = drTemp("Debcre").ToString()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
      
        End Try
    End Sub

    Public Function parametro_ubicacion_listas() As String
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim Retorno_funcion As String
        Retorno_funcion = ""

        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim cmdTemp As New OleDbCommand("Select * From Parametro_Ubicaciones WHERE ID=1", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    Retorno_funcion = drTemp("Param_Ubic_pre").ToString()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
        Finally
            parametro_ubicacion_listas = Retorno_funcion
        End Try
    End Function

    Public Function nombreSistema(ByVal numero As Integer) As String
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim Retorno_funcion As String
        Retorno_funcion = ""

        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdTemp As New OleDbCommand("Select * from Empresa where NumeroDeEmpresa= " & numero & " ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    Retorno_funcion = drTemp("Nombre").ToString()
                End If
            End If
            drTemp.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
            ConSql.Close()
        Finally
            nombreSistema = Retorno_funcion
        End Try
    End Function
    Public Function numeradorAutomatico(ByVal Sistema As Integer, ByVal TipoNumerador As Byte, ByVal Lectura As Byte) As Double
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim Numerador As Double
        Dim Result_bloqueo As Boolean
        Dim insSql As String

        Numerador = 0

        Result_bloqueo = bloqueoAutomatico(1, Sistema)

        If Result_bloqueo = False Then
            numeradorAutomatico = Numerador
            Exit Function
        End If


        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdTemp As New OleDbCommand("Select * from Numeradores where Sistema = " & Sistema & " ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    If TipoNumerador = 1 Then
                        Numerador = drTemp("Numero1").ToString()
                    End If
                    If TipoNumerador = 2 Then
                        Numerador = drTemp("Numero2").ToString()
                    End If
                    If TipoNumerador = 3 Then
                        Numerador = drTemp("Numero3").ToString()
                    End If
                    If TipoNumerador = 4 Then
                        Numerador = drTemp("Numero4").ToString()
                    End If
                    If TipoNumerador = 5 Then
                        Numerador = drTemp("Numero5").ToString()
                    End If
                End If
            End If
            drTemp.Close()

            If Lectura = 2 Then
                insSql = ""
                If TipoNumerador = 1 Then
                    insSql = ""
                    insSql = "Update Numeradores Set Numero1 = Numero1 + 1 where Sistema = " & Sistema & "  "
                End If
                If TipoNumerador = 2 Then
                    insSql = ""
                    insSql = "Update Numeradores Set Numero2 = Numero2 + 1 where Sistema = " & Sistema & "  "
                End If
                If TipoNumerador = 3 Then
                    insSql = ""
                    insSql = "Update Numeradores Set Numero3 = Numero3 + 1 where Sistema = " & Sistema & "  "
                End If
                If TipoNumerador = 4 Then
                    insSql = ""
                    insSql = "Update Numeradores Set Numero4 = Numero4 + 1 where Sistema = " & Sistema & "  "
                End If
                If TipoNumerador = 5 Then
                    insSql = ""
                    insSql = "Update Numeradores Set Numero5 = Numero5 + 1 where Sistema = " & Sistema & "  "
                End If

                If ConSql.State = ConnectionState.Open Then
                    ConSql.Close()
                End If
                ConSql.Open()
                Dim cmdActualizar As New OleDbCommand(insSql, ConSql)
                If (cmdActualizar.ExecuteNonQuery() < 1) Then
                    MessageBox.Show("      No se actualizaron los numeradores     ", rsv_NombreModulo, MessageBoxButtons.OK)
                End If
                cmdActualizar.Dispose()
            End If

            Result_bloqueo = bloqueoAutomatico(2, Sistema)

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
            ConSql.Close()
        Finally
            numeradorAutomatico = Numerador + 1
        End Try

    End Function

    Private Function bloqueoAutomatico(ByVal Tipo As Byte, ByVal Sistema As Integer) As Boolean
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim Con_Exito As Boolean
        Con_Exito = True
        Try
            Dim insSql As String

            Dim au1 As Byte
            Dim au2 As Byte

            If Tipo = 1 Then
                au1 = 1
                au2 = 0
            End If
            If Tipo = 2 Then
                au1 = 0
                au2 = 1
            End If

            insSql = ""
            insSql = "Update Numeradores Set Bloqueado = " & au1 & " where Bloqueado = " & au2 & " and Sistema = " & Sistema & "  "
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdActualizar As New OleDbCommand(insSql, ConSql)
            If (cmdActualizar.ExecuteNonQuery() < 1) Then
                If Tipo = 1 Then
                    MessageBox.Show("      Imposible Obtener bloqueo     ", rsv_NombreModulo, MessageBoxButtons.OK)
                Else
                    MessageBox.Show("      Imposible Obtener Desbloqueo     ", rsv_NombreModulo, MessageBoxButtons.OK)
                End If
                Con_Exito = False
            End If
            cmdActualizar.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
            ConSql.Close()
            Con_Exito = False
        Finally
            bloqueoAutomatico = Con_Exito
        End Try

    End Function
    Public Function NombreSocios(ByVal numero As Integer) As String
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim Retorno_funcion As String
        Retorno_funcion = ""

        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdTemp As New OleDbCommand("Select * from Socios where Numero= " & numero & " ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    Retorno_funcion = drTemp("Nombre").ToString()
                End If
            End If
            drTemp.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
            ConSql.Close()
        Finally
            NombreSocios = Retorno_funcion
        End Try
    End Function
    Public Function Formatea_Numero_Comprobante(ByVal x1 As Integer, ByVal x2 As Double) As String
        Dim c3 As String

        Dim xNumeroDe4 As String
        Dim xNumeroDe8 As String

        xNumeroDe4 = x1
        xNumeroDe4 = xNumeroDe4.PadLeft(4)
        xNumeroDe4 = xNumeroDe4.Replace(" ", "0")

        xNumeroDe8 = x2
        xNumeroDe8 = xNumeroDe8.PadLeft(8)
        xNumeroDe8 = xNumeroDe8.Replace(" ", "0")

        c3 = xNumeroDe4.ToString & "-" & xNumeroDe8.ToString

        Formatea_Numero_Comprobante = c3
    End Function
    Public Function NombreProveedor(ByVal numero As Double) As String
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim Retorno_funcion As String
        Retorno_funcion = ""

        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If
            Dim cmdTemp As New OleDbCommand("Select * from Proveedores where Numero= " & numero & " ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    Retorno_funcion = drTemp("RazonSocial").ToString()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
        Finally
            NombreProveedor = Retorno_funcion
        End Try
    End Function
    Public Function NombreCliente(ByVal numero As Double) As String
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim Retorno_funcion As String
        Retorno_funcion = ""

        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If
            Dim cmdTemp As New OleDbCommand("Select * from Clientes where Numero= " & numero & " ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    Retorno_funcion = drTemp("RazonSocial").ToString()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
        Finally
            NombreCliente = Retorno_funcion
        End Try
    End Function


    Public Function comprobanteExistenteIva(ByVal xfecha As Date, ByVal xCuit As Double, ByVal xLetra As String, ByVal xNumero As String) As Boolean
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim Retorno_funcion As Boolean
        Retorno_funcion = False

        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim xFecha2 As String
            xFecha2 = FormatDateTime(xfecha, DateFormat.ShortDate) '10/01/2009
            xFecha2 = String.Format("{0:yyyyMMdd}", Convert.ToDateTime(xFecha2))

            Dim cmdTemp As New OleDbCommand("Select * from Compras Where Fecha = '" & xFecha2 & "' And Cuit= " & xCuit & " And Letra = '" & xLetra & "' And NumeroDeComprobante = '" & xNumero & "'  ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    Retorno_funcion = True
                End If
            End If
            drTemp.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
            ConSql.Close()
        Finally
            comprobanteExistenteIva = Retorno_funcion
        End Try
    End Function


    Public Function SoloNumeros(ByVal Keyascii As Short) As Short
        If InStr("1234567890-.", Chr(Keyascii)) = 0 Then
            SoloNumeros = 0
        Else
            SoloNumeros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii
            Case 13
                SoloNumeros = Keyascii
        End Select
    End Function
    Public Sub cargarCOMBO(ByRef Lista As ComboBox, _
                         ByVal Tabla As Integer)


        Try
            Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
            Dim ConSql As New OleDbConnection(Conexion)

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim cmdCombo As New OleDbCommand("Select * from Parametros where Param= " & Tabla & " and Numero <> 0 order by detalle", ConSql)
            Dim drCombo As OleDbDataReader = cmdCombo.ExecuteReader
            If drCombo.HasRows Then 'Tiene filas
                Do While drCombo.Read
                    Lista.Items.Add(New ValueDescriptionPair(drCombo("Numero").ToString, drCombo("Detalle").ToString))
                Loop
            End If
            Lista.SelectedIndex = 1
            drCombo.Close()
        Catch ex As Exception

            MessageBox.Show("Error al conectar o recuperar lo datos :" & vbCrLf & _
                             ex.Message, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Error)


        End Try

    End Sub
    Public Function nombreUsuario(ByVal NumeroUsuario As Integer) As String
        Dim nombreRetornado As String
        nombreRetornado = " "
        Try
            Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
            Dim ConSql As New OleDbConnection(Conexion)

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim cmdSql As New OleDbCommand("Select * from Usuarios where Numero= " & NumeroUsuario & " ", ConSql)
            Dim drSql As OleDbDataReader = cmdSql.ExecuteReader
            If drSql.HasRows Then 'Tiene filas
                If drSql.Read = True Then
                    nombreRetornado = drSql("Nombre").ToString
                End If
            End If
            drSql.Close()

        Catch ex As Exception
            MessageBox.Show("Error al conectar o recuperar lo datos :" & vbCrLf & _
                             ex.Message, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            nombreUsuario = nombreRetornado

        End Try
    End Function
    Public Function cuitValido(ByVal NumeroCuit As String) As Boolean
        Dim s As Integer
        Dim coeficiente As String
        Dim cuitIngresado As String
        Dim R As Long
        Dim i As Byte
        Dim valido As Boolean

        coeficiente = "5432765432"

        If NumeroCuit.Trim.Length = 13 Then
            cuitIngresado = Left(NumeroCuit.ToString.Trim, 2) & Mid(NumeroCuit.ToString.Trim, 4, 8) & Right(NumeroCuit.ToString.Trim, 1)
        Else
            cuitIngresado = NumeroCuit.ToString.Trim
        End If
        s = 0
        For i = 1 To 10
            s = s + Val(Mid(cuitIngresado, i, 1)) * Val(Mid(coeficiente, i, 1))
        Next
        R = s Mod 11
        If R > 1 Then
            R = 11 - R
        End If
        If R = Right(cuitIngresado, 1) Then
            valido = True
        Else
            valido = False
        End If
        cuitValido = valido
    End Function
    Public Sub configuracioninicial()
        Dim mFicheroTxt As String
        Dim Cadena1 As String
        Dim Cadena2 As String

        rsv_Terminal = 0

        Cadena1 = ApplicationLocation() & "\" & "Cfg.Ini"
        Cadena2 = "file:\"
        mFicheroTxt = Cadena1.Replace(Cadena2, "")
        'mFicheroTxt = Replace(ApplicationLocation() & "\" & "SiCfg.Ini", "file:\", "")

        If System.IO.File.Exists(mFicheroTxt) = False Then
            MessageBox.Show("Archivo de Configuración Inexistente", _
                        rsv_NombreModulo, _
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End
        End If
        ' Leer el fichero usando la codificación de Windows
        ' pero pudiendo usar la marca de tipo de fichero (BOM)
        Dim sr As New System.IO.StreamReader( _
                    mFicheroTxt, _
                    System.Text.Encoding.Default, _
                    True)

        'While sr.Peek() <> -1
        '    ' Leer una líena del fichero
        '    Dim s As String = sr.ReadLine()
        '    ' Si no está vacía, añadirla al control
        '    ' Si está vacía, continuar el bucle
        '    If String.IsNullOrEmpty(s) Then
        '        Continue While
        '    End If

        'End While


        rsv_Servidor = ""
        rsv_Database = ""

        If sr.Peek() <> -1 Then
            rsv_Servidor = Trim(Mid(sr.ReadLine(), 5, 100))
        End If
        If sr.Peek() <> -1 Then
            rsv_Database = Trim(Mid(sr.ReadLine(), 5, 100))
        End If
        If sr.Peek() <> -1 Then
            rsv_Terminal = Val(Trim(Mid(sr.ReadLine(), 5, 100)))
        End If


        If rsv_Servidor = "" Or rsv_Database = "" Then
            MessageBox.Show("Problemas en Archivo de Configuración", _
                        rsv_NombreModulo, _
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End
        End If

        If rsv_Terminal = 0 Then
            MessageBox.Show("Problemas en Archivo de Configuración. Terminal", _
                        rsv_NombreModulo, _
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End
        End If

        sr.Close()
    End Sub
    Private Function ApplicationLocation() As String
        Dim camino As String
        camino = System.IO.Path.GetDirectoryName(Reflection.Assembly. _
        GetExecutingAssembly().GetName().CodeBase.ToString())
        ApplicationLocation = camino
    End Function
    Public Sub EntradaSistema()
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim InsSql As String = ""
        If ConSql.State = ConnectionState.Open Then
            ConSql.Close()
        End If
        ConSql.Open()


        Dim fechaHoy As String
        Dim horaActual As String
        fechaHoy = Today.ToString
        fechaHoy = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
        horaActual = TimeOfDay.ToString("hh:mm:ss")

        'InsSql = "Insert into logon (usuario,nombre,fecha,accion,sistema,hora) values ("
        'InsSql = InsSql & "" & FrmInicio.TextBox1.Text & ",'" & FrmInicio.TextBox2.Text & "','" & fechaHoy & "','Ingreso a Caja'," & rsv_Sistema & ",'" & horaActual & "' )"
        'Dim cmdConectar As New OleDbCommand(InsSql, ConSql)
        'cmdConectar.ExecuteNonQuery()
        'cmdConectar.Dispose()

    End Sub
    Public Sub saldos_por_obras(ByVal xObra As Integer, ByVal xTipo As Byte, ByRef xDebitos As Double, ByRef xCreditos As Double)
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim InsSql As String
        Dim m_Debitos As Double
        Dim m_Creditos As Double

        m_Debitos = 0
        m_Creditos = 0

        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            InsSql = ""
            InsSql = "Select sum(Importe) as Expr1 from MovimientosPorObras Where (Obra = " & xObra & " ) And "
            InsSql = InsSql & "(DebCre = 1 ) And ( Estado = 0 ) And ( ImputadoObra = " & xTipo & ") "

            Dim cmdDebitos As New OleDbCommand(InsSql, ConSql)
            Dim drDebitos As OleDbDataReader = cmdDebitos.ExecuteReader
            If drDebitos.Read = True Then
                m_Debitos = Val(drDebitos("Expr1").ToString)
            End If
            drDebitos.Close()


            InsSql = ""
            InsSql = "Select sum(Importe) as Expr1 from MovimientosPorObras Where (Obra = " & xObra & " ) And "
            InsSql = InsSql & "(DebCre = 2 ) And ( Estado = 0 ) And ( ImputadoObra = " & xTipo & ")  "


            Dim cmdCreditos As New OleDbCommand(InsSql, ConSql)
            Dim drCreditos As OleDbDataReader = cmdCreditos.ExecuteReader
            If drCreditos.Read = True Then
                m_Creditos = Val(drCreditos("Expr1").ToString)
            End If
            drCreditos.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConSql.Close()
        Finally
            xDebitos = m_Debitos
            xCreditos = m_Creditos
        End Try


    End Sub
    Public Sub saldos_caja(ByVal xTipo As Byte, ByRef xDebitos As Double, ByRef xCreditos As Double)
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim InsSql As String
        Dim m_Debitos As Double
        Dim m_Creditos As Double


        m_Debitos = 0
        m_Creditos = 0



        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            InsSql = ""
            InsSql = "Select sum(Importe) as Expr1 from MovimientosDeCajas Where "
            InsSql = InsSql & "(DebCre = 1 ) And ( Estado = 0 )  "

            Dim cmdDebitos As New OleDbCommand(InsSql, ConSql)
            Dim drDebitos As OleDbDataReader = cmdDebitos.ExecuteReader
            If drDebitos.Read = True Then
                m_Debitos = Val(drDebitos("Expr1").ToString)
            End If
            drDebitos.Close()


            InsSql = ""
            InsSql = "Select sum(Importe) as Expr1 from MovimientosDeCajas Where "
            InsSql = InsSql & "(DebCre = 2 ) And ( Estado = 0 ) "


            Dim cmdCreditos As New OleDbCommand(InsSql, ConSql)
            Dim drCreditos As OleDbDataReader = cmdCreditos.ExecuteReader
            If drCreditos.Read = True Then
                m_Creditos = Val(drCreditos("Expr1").ToString)
            End If
            drCreditos.Close()



        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConSql.Close()
        Finally
            xDebitos = m_Debitos
            xCreditos = m_Creditos
        End Try


    End Sub
    Public Sub SalidaSistema()
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        '        Dim InsSql As String
        If ConSql.State = ConnectionState.Open Then
            ConSql.Close()
        End If
        ConSql.Open()


        Dim fechaHoy As String
        Dim horaActual As String
        fechaHoy = Today.ToString
        fechaHoy = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009
        horaActual = TimeOfDay.ToString("hh:mm:ss")

        'InsSql = "Insert into logon (usuario,nombre,fecha,accion,sistema,hora) values ("
        'InsSql = InsSql & "" & FrmInicio.TextBox1.Text & ",'" & FrmInicio.TextBox2.Text & "','" & fechaHoy & "','Egreso de Caja'," & rsv_Sistema & ",'" & horaActual & "' )"
        'Dim cmdConectar As New OleDbCommand(InsSql, ConSql)
        'cmdConectar.ExecuteNonQuery()
        'cmdConectar.Dispose()

    End Sub
    Public Function numeradorAutomaticoUsuario(ByVal Sistema As Integer, ByVal TipoNumerador As Byte, ByVal Lectura As Byte, ByVal Cajero As Integer) As Double
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim Numerador As Double
        Dim Result_bloqueo As Boolean
        Dim insSql As String

        Numerador = 0

        Result_bloqueo = bloqueoAutomaticoUsuario(1, Sistema, Cajero)

        If Result_bloqueo = False Then
            numeradorAutomaticoUsuario = Numerador
            Exit Function
        End If


        Try
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdTemp As New OleDbCommand("Select * from NumeradoresPorUsuario where Sistema = " & Sistema & " and Usuario = " & Cajero & " ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    If TipoNumerador = 1 Then
                        Numerador = drTemp("NumeroA").ToString()
                    End If
                    If TipoNumerador = 2 Then
                        Numerador = drTemp("NumeroB").ToString()
                    End If
                    If TipoNumerador = 3 Then
                        Numerador = drTemp("NumeroC").ToString()
                    End If
                    If TipoNumerador = 4 Then
                        Numerador = drTemp("Numerador").ToString()
                    End If
                    If TipoNumerador = 5 Then
                        Numerador = drTemp("Recibo").ToString()
                    End If
                End If
            End If
            drTemp.Close()

            If Lectura = 2 Then
                insSql = ""
                If TipoNumerador = 1 Then
                    insSql = ""
                    insSql = "Update NumeradoresPorUsuario Set NumeroA = NumeroA + 1 where Sistema = " & Sistema & " and Usuario = " & Cajero & " "
                End If
                If TipoNumerador = 2 Then
                    insSql = ""
                    insSql = "Update NumeradoresPorUsuario Set NumeroB = NumeroB + 1 where Sistema = " & Sistema & " and Usuario = " & Cajero & " "
                End If
                If TipoNumerador = 3 Then
                    insSql = ""
                    insSql = "Update NumeradoresPorUsuario Set NumeroC = NumeroC + 1 where Sistema = " & Sistema & " and Usuario = " & Cajero & "  "
                End If
                If TipoNumerador = 4 Then
                    insSql = ""
                    insSql = "Update NumeradoresPorUsuario Set Numerador = Numerador + 1 where Sistema = " & Sistema & " and Usuario = " & Cajero & "  "
                End If
                If TipoNumerador = 5 Then
                    insSql = ""
                    insSql = "Update NumeradoresPorUsuario Set Recibo = Recibo + 1 where Sistema = " & Sistema & " and Usuario = " & Cajero & "  "
                End If

                If ConSql.State = ConnectionState.Open Then
                    ConSql.Close()
                End If
                ConSql.Open()
                Dim cmdActualizar As New OleDbCommand(insSql, ConSql)
                If (cmdActualizar.ExecuteNonQuery() < 1) Then
                    MessageBox.Show("      No se actualizaron los numeradores     ", rsv_NombreModulo, MessageBoxButtons.OK)
                End If
                cmdActualizar.Dispose()
            End If

            Result_bloqueo = bloqueoAutomaticoUsuario(2, Sistema, Cajero)

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
            ConSql.Close()
        Finally
            numeradorAutomaticoUsuario = Numerador + 1
        End Try

    End Function
    Private Function bloqueoAutomaticoUsuario(ByVal Tipo As Byte, ByVal Sistema As Integer, ByVal Cajero As Integer) As Boolean
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim Con_Exito As Boolean
        Con_Exito = True
        Try
            Dim insSql As String

            Dim au1 As Byte
            Dim au2 As Byte

            If Tipo = 1 Then
                au1 = 1
                au2 = 0
            End If
            If Tipo = 2 Then
                au1 = 0
                au2 = 1
            End If

            insSql = ""
            insSql = "Update NumeradoresPorUsuario Set Bloqueado = " & au1 & " where Bloqueado = " & au2 & " and Sistema = " & Sistema & " and Usuario = " & Cajero & "  "
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()
            Dim cmdActualizar As New OleDbCommand(insSql, ConSql)
            If (cmdActualizar.ExecuteNonQuery() < 1) Then
                If Tipo = 1 Then
                    MessageBox.Show("      Imposible Obtener bloqueo     ", rsv_NombreModulo, MessageBoxButtons.OK)
                Else
                    MessageBox.Show("      Imposible Obtener Desbloqueo     ", rsv_NombreModulo, MessageBoxButtons.OK)
                End If
                Con_Exito = False
            End If
            cmdActualizar.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
            ConSql.Close()
            Con_Exito = False
        Finally
            bloqueoAutomaticoUsuario = Con_Exito
        End Try

    End Function
    Public Function valida_existencia(ByVal param As String) As Boolean
        Dim r As Boolean = False
        Try
            Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
            Dim ConSql As New OleDbConnection(Conexion)

            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim Sql As String = ""
            Sql = "Select * from Articulos WHERE (Codigo= '" & param & "') And (Estado=0) "


            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    r = True
                End If
            End If

            drRecordSet.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            valida_existencia = r
        End Try
    End Function
    Private Function valida_existencia_articulos(ByVal param As String, ByVal provee As Double) As Boolean
        Dim r As Boolean = False
        Try
            Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
            Dim ConSql As New OleDbConnection(Conexion)

            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim Sql As String = ""
            Sql = "Select * from Articulos WHERE (Codigo= '" & param & "') And (Estado=0) and (CodigoProveedor=" & provee & ") "

            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    r = True
                End If
            End If

            drRecordSet.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            valida_existencia_articulos = r
        End Try
    End Function


    Public Sub actualiza_precio_articulo(ByVal x_Codigo As String, ByVal x_Detalle As String, ByVal x_Costo As Double, ByVal x_Precio As Double)
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim insSql As String

  
        Try
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            insSql = "Update Articulos SET PrecioCosto=" & x_Costo & ",Precio1=" & x_Precio & ",Precio2=" & x_Precio & ",Precio3=" & x_Precio & ",Precio4=" & x_Precio & ","
            insSql = insSql & "Precio5=" & x_Precio & ",Precio6=" & x_Precio & ",Precio7=" & x_Precio & ",Precio8=" & x_Precio & ",Precio9=" & x_Precio & ",Precio10=" & x_Precio & "  "
            insSql = insSql & "WHERE Codigo = '" & x_Codigo & "'"


            Dim cmdActualizar As New OleDbCommand(insSql, ConSql)
            If (cmdActualizar.ExecuteNonQuery() < 1) Then
                MessageBox.Show("      No se actualizaron los numeradores     ", rsv_NombreModulo, MessageBoxButtons.OK)
            End If
            cmdActualizar.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
            ConSql.Close()
        End Try

    End Sub
    Public Sub retornaProveedor(ByVal xProveedor As String, ByRef xDetalle As String, ByRef xTipoResponsable As Byte, ByRef xCuit As Double)
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)

        Dim x1_Detalle As String
        Dim x1_Cuit As Double
        Dim x1_TipoResponsable As Byte
        x1_Detalle = " "
        x1_Cuit = 0
        x1_TipoResponsable = 0
        Try
   
            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim cmdTemp As New OleDbCommand("Select * from Proveedores where Numero= " & xProveedor & " ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    x1_Detalle = drTemp("RazonSocial").ToString()
                    x1_Cuit = drTemp("Cuit").ToString()
                    x1_TipoResponsable = drTemp("Responsable").ToString()
                End If
            End If
            xDetalle = x1_Detalle
            xCuit = x1_Cuit
            xTipoResponsable = x1_TipoResponsable
            drTemp.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
        End Try
    End Sub

    Public Sub actualiza_articulos_lista_nuevo(ByVal x_Codigo As String, ByVal x_Detalle As String, ByVal x_Costo As Double, ByVal x_Precio As Double)
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim Sql As String


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

            Sql = "Insert Into Articulos(Codigo,CodigoProveedor,CodigoBarra,Detalle,Proveedor,"
            Sql = Sql & "PrecioCosto,Ganancia,AplicaIva,Alicuota,"
            Sql = Sql & "Precio1,Precio2,Precio3,Precio4,Precio5,"
            Sql = Sql & "Precio6,Precio7,Precio8,Precio9,Precio10,"
            Sql = Sql & "Sector,Estanteria,Existencia,ExisMini,Rubro,"
            Sql = Sql & "Au,Af,Ah,Estado) Values ("
            Sql = Sql & "'" & x_Codigo & "',' ',' ','" & x_Detalle & "',0,"
            Sql = Sql & "" & x_Costo & ",0,1,21,"
            Sql = Sql & "" & x_Precio & "," & x_Precio & "," & x_Precio & "," & x_Precio & "," & x_Precio & ","
            Sql = Sql & "" & x_Precio & "," & x_Precio & "," & x_Precio & "," & x_Precio & "," & x_Precio & ","
            Sql = Sql & "' ',' ',1,1,1,"
            Sql = Sql & "" & j1 & ",'" & j2 & "','" & j3 & "',0)"

            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            If (cmdActualizar.ExecuteNonQuery() < 1) Then
                MessageBox.Show("      No se actualizaron los numeradores     ", rsv_NombreModulo, MessageBoxButtons.OK)
            End If
            cmdActualizar.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
            ConSql.Close()
        End Try

    End Sub
    Public Sub elimina_registros_temporales()
        Try
            Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
            Dim ConSql As New OleDbConnection(Conexion)
            Dim Sql As String = ""

            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If
            Dim InsSql As String = ""
            InsSql = "truncate table Articulos_precios_temporal"
            Dim cmdActualizar As New OleDbCommand(InsSql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
        End Try
    End Sub
    Public Sub actualiza_articulos_Tabla_Temp_Nuevo(ByVal x_Codigo As String, ByVal x_Detalle As String, ByVal x_Costo As Double, ByVal x_Precio As Double, ByVal x_Proveedor As Double)
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim Sql As String


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

            Sql = "Insert Into Articulos_Precios_Temporal (Codigo,Detalle,Costo,Precio,Proveedor,Estado) Values ("
            Sql = Sql & "'" & x_Codigo & "','" & x_Detalle & "'," & x_Costo & "," & x_Precio & "," & x_Proveedor & ",0)"

            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Al ingresar Registros " & rsv_NombreModulo, MessageBoxButtons.OK)
        End Try

    End Sub
    Public Sub actualiza_precios_lote()
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim Sql As String = ""
        Try

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            fechaHoy = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009

            Sql = "Update Articulos"
            Sql = Sql & " set  Articulos.PrecioCosto  = Articulos_Precios_Temporal.Costo,"
            Sql = Sql & "Articulos.Precio1  = Articulos_Precios_Temporal.Precio,"
            Sql = Sql & "Articulos.Precio2  = Articulos_Precios_Temporal.Precio,"
            Sql = Sql & "Articulos.Precio3  = Articulos_Precios_Temporal.Precio,"
            Sql = Sql & "Articulos.Precio4  = Articulos_Precios_Temporal.Precio,"
            Sql = Sql & "Articulos.Precio5  = Articulos_Precios_Temporal.Precio,"
            Sql = Sql & "Articulos.Precio6  = Articulos_Precios_Temporal.Precio,"
            Sql = Sql & "Articulos.Precio7  = Articulos_Precios_Temporal.Precio,"
            Sql = Sql & "Articulos.Precio8  = Articulos_Precios_Temporal.Precio,"
            Sql = Sql & "Articulos.Precio9  = Articulos_Precios_Temporal.Precio,"
            Sql = Sql & "Articulos.Precio10 = Articulos_Precios_Temporal.Precio,"
            Sql = Sql & "Articulos.UltimoPrecio = '" & fechaHoy & "' "
            Sql = Sql & " from Articulos, Articulos_Precios_Temporal "
            Sql = Sql & " where Articulos.Codigo = Articulos_Precios_Temporal.Codigo And Articulos.CodigoProveedor = Articulos_Precios_Temporal.Proveedor"

            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If


            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Al ingresar Registros " & rsv_NombreModulo, MessageBoxButtons.OK)
        End Try
    End Sub
    Public Sub depuracion_articulos(ByVal x As Byte, ByVal P As Double)
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim Sql As String = ""
        Try

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            fechaHoy = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009

            If x = 1 Then
                Sql = "Delete From Articulos WHERE (Estado=9)"
            End If
            If x = 2 Then
                Sql = "Update Articulos SET Estado=9 WHERE (Proveedor=" & P & ")"
            End If

            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If


            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Al ingresar Registros " & rsv_NombreModulo, MessageBoxButtons.OK)
        End Try
    End Sub
    Public Sub incremento_decremento_stock(ByVal xTipo As Byte, ByVal xCodigo As String, ByVal xUnidades As Double)
        Try

            Dim Sql As String = ""


            If xTipo = 1 Then
                Sql = "Update Articulos Set Existencia=Existencia - " & xUnidades & " WHERE Codigo='" & xCodigo & "' And Estado=0 "
            End If
            If xTipo = 2 Then
                Sql = "Update Articulos Set Existencia=Existencia + " & xUnidades & " WHERE Codigo='" & xCodigo & "' And Estado=0"
            End If

            Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
            Dim ConSql As New OleDbConnection(Conexion)

            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()

            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try
    End Sub
    Public Sub retornaLimitesControladorFiscal(ByVal xId As String, ByRef xImp1 As Double, ByRef xImp2 As Double)
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)

        Try

            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim cmdTemp As New OleDbCommand("Select * from Parametros_Variables where Id= " & xId & " ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    xImp1 = Convert.ToDouble(drTemp("Imp1").ToString())
                    xImp2 = Convert.ToDouble(drTemp("Imp2").ToString())
                End If
            End If
            drTemp.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
        End Try
    End Sub

    Public Sub inserta_nuevos_articulos()
        Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
        Dim ConSql As New OleDbConnection(Conexion)
        Dim Sql As String = ""
        Try

            Dim fechaHoy As String
            fechaHoy = Today.ToString
            fechaHoy = FormatDateTime(fechaHoy, DateFormat.ShortDate) '10/01/2009


            Sql = "merge "
            Sql = Sql & "Into articulos T1 "
            Sql = Sql & "Using  Articulos_Precios_Temporal T2 "
            Sql = Sql & "On T1.Codigo=T2.Codigo "
            Sql = Sql & "AND "
            Sql = Sql & "T1.Proveedor = T2.Proveedor AND T1.Estado = T2.Estado "
            Sql = Sql & "WHEN  NOT MATCHED  THEN "
            Sql = Sql & " Insert(Codigo, Proveedor, Detalle, AplicaIva, Alicuota, Precio1, Precio2, Precio3, Precio4, Precio5, Precio6, Precio7, Precio8, Precio9, Precio10, UltimoPrecio) "
            Sql = Sql & " Values  (t2.Codigo,t2.proveedor,t2.detalle,1,21,t2.precio,t2.precio,t2.precio,t2.precio,t2.precio,t2.precio,t2.precio,t2.precio,t2.precio,t2.precio,'09/03/2017'); "


            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If


            Dim cmdActualizar As New OleDbCommand(Sql, ConSql)
            cmdActualizar.ExecuteNonQuery()
            cmdActualizar.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Al ingresar Registros " & rsv_NombreModulo, MessageBoxButtons.OK)
        End Try
    End Sub

    Public Function valida_habilitacion_ctacte(ByVal xCliente As Double) As Byte
        Dim r As Byte = 1
        Try
            Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
            Dim ConSql As New OleDbConnection(Conexion)

            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim Sql As String = ""
            Sql = "Select * from Clientes WHERE (Numero= " & xCliente & ") And (Estado=0) "

            Dim cmdRecordSet As New OleDbCommand(Sql, ConSql)
            Dim drRecordSet As OleDbDataReader = cmdRecordSet.ExecuteReader
            If drRecordSet.HasRows Then 'Tiene filas
                If drRecordSet.Read Then
                    If Val(drRecordSet("CtaCte").ToString) = 0 Then
                        r = 2
                    Else
                        r = 0
                    End If
                End If
            End If

            drRecordSet.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            valida_habilitacion_ctacte = r
        End Try


    End Function
    Public Function cadenaCode128(ByVal chaine As String) As String
        'V 2.0.0
        'Parametres : une chaine
        'Parameters : a string
        'Retour : * une chaine qui, affichee avec la police CODE128.TTF, donne le code barre
        '         * une chaine vide si parametre fourni incorrect
        'Return : * a string which give the bar code when it is dispayed with CODE128.TTF font
        '         * an empty string if the supplied parameter is no good
        Dim i As Integer = 0
        Dim checksum As Long = 0
        Dim mini As Integer = 0
        Dim dummy As Integer = 0
        Dim tableB As Boolean = False

        Dim Code128 As String = ""
        If chaine.Length > 0 Then
            'Verifier si caracteres valides
            'Check for valid characters
            For i = 1 To chaine.Length
                Select Case Asc(Mid$(chaine, i, 1))
                    Case 32 To 126, 203
                    Case Else
                        i = 0
                        Exit For
                End Select
            Next
            'Calculer la chaine de code en optimisant l'usage des tables B et C
            'Calculation of the code string with optimized use of tables B and C
            Code128 = ""
            tableB = True
            If i > 0 Then
                i = 1 'i devient l'index sur la chaine / i become the string index
                Do While i <= chaine.Length
                    If tableB Then
                        'Voir si interessant de passer en table C / See if interesting to switch to table C
                        'Oui pour 4 chiffres au debut ou a la fin, sinon pour 6 chiffres / yes for 4 digits at start or end, else if 6 digits
                        mini = IIf(i = 1 Or i + 3 = chaine.Length, 4, 6)

                        'si les mini caracteres a partir de i sont numeriques, alors mini=0
                        'if the mini characters from i are numeric, then mini=0
                        mini = mini - 1
                        If i + mini <= chaine.Length Then
                            Do While mini >= 0
                                If Asc(Mid$(chaine, i + mini, 1)) < 48 Or Asc(Mid$(chaine, i + mini, 1)) > 57 Then Exit Do
                                mini = mini - 1
                            Loop
                        End If


                        If mini < 0 Then 'Choix table C / Choice of table C
                            If i = 1 Then 'Debuter sur table C / Starting with table C
                                Code128 = Chr(210)
                            Else 'Commuter sur table C / Switch to table C
                                Code128 = Code128 & Chr(204)
                            End If
                            tableB = False
                        Else
                            If i = 1 Then Code128 = Chr(209) 'Debuter sur table B / Starting with table B
                        End If
                    End If
                    If Not tableB Then
                        'On est sur la table C, essayer de traiter 2 chiffres / We are on table C, try to process 2 digits
                        mini = 2

                        'si les mini caracteres a partir de i sont numeriques, alors mini=0
                        'if the mini characters from i are numeric, then mini=0
                        mini = mini - 1
                        If i + mini <= Len(chaine) Then
                            Do While mini >= 0
                                If Asc(Mid$(chaine, i + mini, 1)) < 48 Or Asc(Mid$(chaine, i + mini, 1)) > 57 Then Exit Do
                                mini = mini - 1
                            Loop
                        End If

                        If mini < 0 Then 'OK pour 2 chiffres, les traiter / OK for 2 digits, process it
                            dummy = Val(Mid$(chaine, i, 2))
                            dummy = IIf(dummy < 95, dummy + 32, dummy + 105)
                            Code128 = Code128 & Chr(dummy)
                            i = i + 2
                        Else 'On n'a pas 2 chiffres, repasser en table B / We haven't 2 digits, switch to table B
                            Code128 = Code128 & Chr(205)
                            tableB = True
                        End If
                    End If
                    If tableB Then
                        'Traiter 1 caractere en table B / Process 1 digit with table B
                        Code128 = Code128 & Mid$(chaine, i, 1)
                        i = i + 1
                    End If
                Loop
                'Calcul de la cle de controle / Calculation of the checksum
                For i = 1 To Len(Code128)
                    dummy = Asc(Mid$(Code128, i, 1))
                    dummy = IIf(dummy < 127, dummy - 32, dummy - 105)
                    If i = 1 Then checksum = dummy
                    checksum = (checksum + (i - 1) * dummy) Mod 103
                Next
                'Calcul du code ASCII de la cle / Calculation of the checksum ASCII code
                checksum = IIf(checksum < 95, checksum + 32, checksum + 105)
                'Ajout de la cle et du STOP / Add the checksum and the STOP
                Code128 = Code128 & Chr(checksum) & Chr(211)
            End If
        End If
        cadenaCode128 = Code128
        Exit Function
    End Function

    Public Function generarDivitov(ByVal xString As String) As Byte

        Dim Dv As Byte = 0

        Dim Su As Integer = 0

        Dim Nl As String = ""

        Dim i As Byte = 0
        Dim c1 As Integer = 0
        Dim c3 As Integer = 0
        Dim c5 As Integer = 0
        Dim c7 As Integer = 0
        Dim c9 As Integer = 0


        c1 = Val(xString.Substring(0, 1))

        For i = 1 To 38 Step 4
            c3 = c3 + (Val(xString.Substring(i, 1)) * 3)
        Next

        For i = 2 To 38 Step 4
            c5 = c5 + (Val(xString.Substring(i, 1)) * 5)
        Next

        For i = 3 To 38 Step 4
            c7 = c7 + (Val(xString.Substring(i, 1)) * 7)
        Next

        For i = 4 To 38 Step 4
            c9 = c9 + (Val(xString.Substring(i, 1)) * 9)
        Next

        Su = c1 + c3 + c5 + c7 + c9
        Su = Int(Su / 2)




        Dv = (Su Mod 10)
        generarDivitov = Dv


    End Function
    Public Function fecha_hora_lineal() As String
        Dim f As DateTime = Now
        Dim ff As String = f
        ff = ff.Replace("/", "")
        ff = ff.Replace(" ", "")
        ff = ff.Replace(":", "")

        fecha_hora_lineal = ff

    End Function
    Public Sub cargar_configuracion()
        Try
            Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
            Dim ConSql As New OleDbConnection(Conexion)
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()


            Dim cmdTemp As New OleDbCommand("Select * from Configuracion_Afip WHERE (Id = 1) ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    rsv_Afip_Homolog = Val(drTemp("Homologacion").ToString())
                    rsv_Afip_Certif = drTemp("Certificados").ToString.Trim
                    rsv_Afip_Tickets = drTemp("Tickets").ToString.Trim
                    rsv_Afip_xml = drTemp("ArchiXml").ToString.Trim
                    rsv_Afip_Llave = drTemp("Llave").ToString.Trim
                End If
            End If
            drTemp.Close()
            ConSql.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_Modulo, MessageBoxButtons.OK)
        End Try
    End Sub
    Public Function fecha_expir_ticket() As Boolean
        Dim r As Boolean = False
        Try

            Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
            Dim ConSql As New OleDbConnection(Conexion)
            If ConSql.State = ConnectionState.Open Then
                ConSql.Close()
            End If
            ConSql.Open()


            Dim cmdTemp As New OleDbCommand("Select * from AfipToken WHERE (Id = 1) ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then

                    Dim h1 As DateTime = drTemp("GenerTime").ToString
                    Dim h2 As DateTime = drTemp("ExpirTime").ToString

                    Dim h3 As DateTime = Now

                    If h3 > h1 And h3 < h2 Then
                        r = True
                    End If
                End If
            End If
            drTemp.Close()
            ConSql.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_Modulo, MessageBoxButtons.OK)
        Finally
            fecha_expir_ticket = r
        End Try
    End Function
    Public Function isOnline() As Boolean
        Dim r As Boolean = False
        Dim Url As New System.Uri("http://www.google.com.ar")
        Dim oWebReq As System.Net.WebRequest
        oWebReq = System.Net.WebRequest.Create(Url)
        Dim oResp As System.Net.WebResponse
        Try
            oResp = oWebReq.GetResponse
            oResp.Close()
            oWebReq = Nothing
            r = True
        Catch ex As Exception
            r = False
            oWebReq = Nothing
        Finally
            isOnline = r

        End Try
    End Function
    Public Function EncodeStrToBase64(ByVal valor As String) As String
        Dim myByte As Byte() = System.Text.Encoding.UTF8.GetBytes(valor)
        Dim myBase64 As String = Convert.ToBase64String(myByte)

        Return myBase64

    End Function

    Public Function imageTobyte(ByVal pImagen As Image) As Byte()
        Dim mImage() As Byte
        Try
            If Not IsNothing(pImagen) Then
                Dim ms As New System.IO.MemoryStream
                pImagen.Save(ms, pImagen.RawFormat)
                mImage = ms.GetBuffer
                ms.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            imageTobyte = mImage
        End Try
    End Function
    Public Function impresoras_disponibles(ByVal xTermi As Byte, ByVal xNumero As Byte) As String
        Dim r As String = ""
        Try
            Dim Conexion As String = "Provider=SQLOLEDB;data source = '" & rsv_Servidor & "'; initial catalog = '" & rsv_Database & "'; user id = 'usuariodb'; password = '12345678'"
            Dim ConSql As New OleDbConnection(Conexion)

            If ConSql.State = ConnectionState.Closed Then
                ConSql.Open()
            End If

            Dim cmdTemp As New OleDbCommand("Select * from Configuraciones_Impresoras WHERE Term= " & xTermi & " And Nro= " & xNumero & " ", ConSql)
            Dim drTemp As OleDbDataReader = cmdTemp.ExecuteReader
            If drTemp.HasRows Then 'Tiene filas
                If drTemp.Read = True Then
                    r = drTemp("Nombre").ToString()
                End If
            End If
            drTemp.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, rsv_NombreModulo, MessageBoxButtons.OK)
        Finally
            impresoras_disponibles = r
        End Try
    End Function

#Region "BuscarCombo"
    Public Sub buscarCombo(ByRef Lista As ComboBox, _
                           ByVal IdentificadorText As String)

        For Each vdp As ValueDescriptionPair In Lista.Items
            If vdp.Value = IdentificadorText Then
                Lista.SelectedItem = vdp
                Exit For
            End If
        Next
    End Sub
    Public Class ValueDescriptionPair
        Private m_Value As Object
        Private m_Description As String

        Public ReadOnly Property Value() As Object
            Get
                Return m_Value
            End Get
        End Property

        Public ReadOnly Property Description() As String
            Get
                Return m_Description
            End Get
        End Property

        Public Sub New(ByVal NewValue As Object, ByVal NewDescription As String)
            m_Value = NewValue
            m_Description = NewDescription
        End Sub

        Public Overrides Function ToString() As String
            Return m_Description
        End Function

    End Class
#End Region

End Module

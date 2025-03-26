<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits MetroFrameWork.Forms.MetroForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MetroStyleManager1 = New MetroFramework.Components.MetroStyleManager(Me.components)
        Me.MetroStyleExtender1 = New MetroFramework.Components.MetroStyleExtender(Me.components)
        Me.MetroTile2 = New MetroFramework.Controls.MetroTile()
        Me.MetroTile4 = New MetroFramework.Controls.MetroTile()
        Me.MetroTile5 = New MetroFramework.Controls.MetroTile()
        Me.MetroTile1 = New MetroFramework.Controls.MetroTile()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTile6 = New MetroFramework.Controls.MetroTile()
        Me.MetroTile7 = New MetroFramework.Controls.MetroTile()
        Me.MetroTile10 = New MetroFramework.Controls.MetroTile()
        Me.MetroTile11 = New MetroFramework.Controls.MetroTile()
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MetroStyleManager1
        '
        Me.MetroStyleManager1.Owner = Nothing
        Me.MetroStyleManager1.Style = MetroFramework.MetroColorStyle.Black
        '
        'MetroStyleExtender1
        '
        Me.MetroStyleExtender1.Theme = MetroFramework.MetroThemeStyle.Light
        '
        'MetroTile2
        '
        Me.MetroTile2.ActiveControl = Nothing
        Me.MetroTile2.Location = New System.Drawing.Point(325, 178)
        Me.MetroTile2.Name = "MetroTile2"
        Me.MetroTile2.Size = New System.Drawing.Size(146, 122)
        Me.MetroTile2.TabIndex = 1
        Me.MetroTile2.Text = "Parámetros." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.MetroTile2.UseSelectable = True
        '
        'MetroTile4
        '
        Me.MetroTile4.ActiveControl = Nothing
        Me.MetroTile4.Location = New System.Drawing.Point(495, 178)
        Me.MetroTile4.Name = "MetroTile4"
        Me.MetroTile4.Size = New System.Drawing.Size(146, 122)
        Me.MetroTile4.Style = MetroFramework.MetroColorStyle.Orange
        Me.MetroTile4.TabIndex = 3
        Me.MetroTile4.Text = "Ventas." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.MetroTile4.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroTile4.UseSelectable = True
        '
        'MetroTile5
        '
        Me.MetroTile5.ActiveControl = Nothing
        Me.MetroTile5.Location = New System.Drawing.Point(663, 178)
        Me.MetroTile5.Name = "MetroTile5"
        Me.MetroTile5.Size = New System.Drawing.Size(146, 122)
        Me.MetroTile5.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroTile5.TabIndex = 4
        Me.MetroTile5.Text = "Stock." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.MetroTile5.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroTile5.UseSelectable = True
        '
        'MetroTile1
        '
        Me.MetroTile1.ActiveControl = Nothing
        Me.MetroTile1.Location = New System.Drawing.Point(161, 178)
        Me.MetroTile1.Name = "MetroTile1"
        Me.MetroTile1.Size = New System.Drawing.Size(146, 122)
        Me.MetroTile1.Style = MetroFramework.MetroColorStyle.Teal
        Me.MetroTile1.TabIndex = 0
        Me.MetroTile1.Text = "Seguridad." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.MetroTile1.TileImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.MetroTile1.UseSelectable = True
        Me.MetroTile1.UseStyleColors = True
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(24, 512)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(314, 19)
        Me.MetroLabel1.TabIndex = 5
        Me.MetroLabel1.Text = "Sistema de gestión administrativo licenciado a HelpTEC."
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(24, 531)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(250, 19)
        Me.MetroLabel2.TabIndex = 6
        Me.MetroLabel2.Text = "CopyRight 2021. Soluciones Informáticas. "
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.FontSize = MetroFramework.MetroLabelSize.Small
        Me.MetroLabel3.Location = New System.Drawing.Point(1037, 535)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(35, 15)
        Me.MetroLabel3.TabIndex = 7
        Me.MetroLabel3.Text = "form1"
        '
        'MetroTile6
        '
        Me.MetroTile6.ActiveControl = Nothing
        Me.MetroTile6.Location = New System.Drawing.Point(831, 178)
        Me.MetroTile6.Name = "MetroTile6"
        Me.MetroTile6.Size = New System.Drawing.Size(146, 122)
        Me.MetroTile6.Style = MetroFramework.MetroColorStyle.Purple
        Me.MetroTile6.TabIndex = 8
        Me.MetroTile6.Text = "Proveedores." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.MetroTile6.UseSelectable = True
        '
        'MetroTile7
        '
        Me.MetroTile7.ActiveControl = Nothing
        Me.MetroTile7.Location = New System.Drawing.Point(161, 319)
        Me.MetroTile7.Name = "MetroTile7"
        Me.MetroTile7.Size = New System.Drawing.Size(146, 122)
        Me.MetroTile7.Style = MetroFramework.MetroColorStyle.Pink
        Me.MetroTile7.TabIndex = 9
        Me.MetroTile7.Text = "Clientes." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.MetroTile7.UseSelectable = True
        Me.MetroTile7.UseStyleColors = True
        '
        'MetroTile10
        '
        Me.MetroTile10.ActiveControl = Nothing
        Me.MetroTile10.Location = New System.Drawing.Point(495, 319)
        Me.MetroTile10.Name = "MetroTile10"
        Me.MetroTile10.Size = New System.Drawing.Size(146, 122)
        Me.MetroTile10.Style = MetroFramework.MetroColorStyle.Yellow
        Me.MetroTile10.TabIndex = 12
        Me.MetroTile10.Text = "Back Office." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.MetroTile10.UseSelectable = True
        Me.MetroTile10.UseStyleColors = True
        '
        'MetroTile11
        '
        Me.MetroTile11.ActiveControl = Nothing
        Me.MetroTile11.Location = New System.Drawing.Point(325, 319)
        Me.MetroTile11.Name = "MetroTile11"
        Me.MetroTile11.Size = New System.Drawing.Size(146, 122)
        Me.MetroTile11.Style = MetroFramework.MetroColorStyle.Red
        Me.MetroTile11.TabIndex = 15
        Me.MetroTile11.Text = "Afip. Configuración." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Factura Electrónica." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.MetroTile11.UseSelectable = True
        Me.MetroTile11.UseStyleColors = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1152, 612)
        Me.Controls.Add(Me.MetroTile11)
        Me.Controls.Add(Me.MetroTile10)
        Me.Controls.Add(Me.MetroTile7)
        Me.Controls.Add(Me.MetroTile6)
        Me.Controls.Add(Me.MetroLabel3)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.MetroTile5)
        Me.Controls.Add(Me.MetroTile4)
        Me.Controls.Add(Me.MetroTile2)
        Me.Controls.Add(Me.MetroTile1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Style = MetroFramework.MetroColorStyle.White
        Me.Text = "Menú Principal. "
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MetroStyleManager1 As MetroFramework.Components.MetroStyleManager
    Friend WithEvents MetroStyleExtender1 As MetroFramework.Components.MetroStyleExtender
    Friend WithEvents MetroTile1 As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroTile2 As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroTile4 As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroTile5 As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel3 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroTile6 As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroTile7 As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroTile10 As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroTile11 As MetroFramework.Controls.MetroTile

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form50
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form50))
        Me.MetroStyleManager1 = New MetroFramework.Components.MetroStyleManager(Me.components)
        Me.MetroStyleExtender1 = New MetroFramework.Components.MetroStyleExtender(Me.components)
        Me.MetroButton3 = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel12 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel22 = New MetroFramework.Controls.MetroLabel()
        Me.MetroDateTime2 = New MetroFramework.Controls.MetroDateTime()
        Me.MetroDateTime1 = New MetroFramework.Controls.MetroDateTime()
        Me.MetroLabel23 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBox10 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel4 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBox6 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroTextBox7 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroTextBox8 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel7 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLink6 = New MetroFramework.Controls.MetroLink()
        Me.MetroLink1 = New MetroFramework.Controls.MetroLink()
        Me.MetroLink2 = New MetroFramework.Controls.MetroLink()
        Me.MetroLink3 = New MetroFramework.Controls.MetroLink()
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
        'MetroButton3
        '
        Me.MetroButton3.Location = New System.Drawing.Point(36, 365)
        Me.MetroButton3.Name = "MetroButton3"
        Me.MetroButton3.Size = New System.Drawing.Size(94, 23)
        Me.MetroButton3.TabIndex = 16
        Me.MetroButton3.Text = "Salir"
        Me.MetroButton3.UseSelectable = True
        '
        'MetroLabel12
        '
        Me.MetroLabel12.AutoSize = True
        Me.MetroLabel12.FontSize = MetroFramework.MetroLabelSize.Small
        Me.MetroLabel12.Location = New System.Drawing.Point(1009, 395)
        Me.MetroLabel12.Name = "MetroLabel12"
        Me.MetroLabel12.Size = New System.Drawing.Size(43, 15)
        Me.MetroLabel12.TabIndex = 24
        Me.MetroLabel12.Text = "form50"
        '
        'MetroLabel22
        '
        Me.MetroLabel22.AutoSize = True
        Me.MetroLabel22.Location = New System.Drawing.Point(150, 185)
        Me.MetroLabel22.Name = "MetroLabel22"
        Me.MetroLabel22.Size = New System.Drawing.Size(81, 19)
        Me.MetroLabel22.TabIndex = 97
        Me.MetroLabel22.Text = "Fecha/Pago."
        '
        'MetroDateTime2
        '
        Me.MetroDateTime2.FontSize = MetroFramework.MetroDateTimeSize.Small
        Me.MetroDateTime2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MetroDateTime2.Location = New System.Drawing.Point(150, 207)
        Me.MetroDateTime2.MinimumSize = New System.Drawing.Size(0, 25)
        Me.MetroDateTime2.Name = "MetroDateTime2"
        Me.MetroDateTime2.Size = New System.Drawing.Size(108, 25)
        Me.MetroDateTime2.TabIndex = 95
        '
        'MetroDateTime1
        '
        Me.MetroDateTime1.FontSize = MetroFramework.MetroDateTimeSize.Small
        Me.MetroDateTime1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MetroDateTime1.Location = New System.Drawing.Point(36, 207)
        Me.MetroDateTime1.MinimumSize = New System.Drawing.Size(0, 25)
        Me.MetroDateTime1.Name = "MetroDateTime1"
        Me.MetroDateTime1.Size = New System.Drawing.Size(108, 25)
        Me.MetroDateTime1.TabIndex = 94
        '
        'MetroLabel23
        '
        Me.MetroLabel23.AutoSize = True
        Me.MetroLabel23.Location = New System.Drawing.Point(36, 185)
        Me.MetroLabel23.Name = "MetroLabel23"
        Me.MetroLabel23.Size = New System.Drawing.Size(46, 19)
        Me.MetroLabel23.TabIndex = 96
        Me.MetroLabel23.Text = "Fecha."
        '
        'MetroTextBox10
        '
        Me.MetroTextBox10.Enabled = False
        Me.MetroTextBox10.Lines = New String() {"MetroTextBox10"}
        Me.MetroTextBox10.Location = New System.Drawing.Point(652, 105)
        Me.MetroTextBox10.MaxLength = 100
        Me.MetroTextBox10.Name = "MetroTextBox10"
        Me.MetroTextBox10.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox10.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox10.SelectedText = ""
        Me.MetroTextBox10.Size = New System.Drawing.Size(311, 23)
        Me.MetroTextBox10.TabIndex = 102
        Me.MetroTextBox10.Text = "MetroTextBox10"
        Me.MetroTextBox10.UseSelectable = True
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(598, 83)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(48, 19)
        Me.MetroLabel2.TabIndex = 104
        Me.MetroLabel2.Text = "Banco."
        '
        'MetroLabel4
        '
        Me.MetroLabel4.AutoSize = True
        Me.MetroLabel4.Location = New System.Drawing.Point(216, 83)
        Me.MetroLabel4.Name = "MetroLabel4"
        Me.MetroLabel4.Size = New System.Drawing.Size(49, 19)
        Me.MetroLabel4.TabIndex = 103
        Me.MetroLabel4.Text = "Detalle"
        '
        'MetroTextBox6
        '
        Me.MetroTextBox6.Enabled = False
        Me.MetroTextBox6.Lines = New String() {"MetroTextBox6"}
        Me.MetroTextBox6.Location = New System.Drawing.Point(598, 105)
        Me.MetroTextBox6.MaxLength = 3
        Me.MetroTextBox6.Name = "MetroTextBox6"
        Me.MetroTextBox6.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox6.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox6.SelectedText = ""
        Me.MetroTextBox6.Size = New System.Drawing.Size(48, 23)
        Me.MetroTextBox6.TabIndex = 101
        Me.MetroTextBox6.Text = "MetroTextBox6"
        Me.MetroTextBox6.UseSelectable = True
        '
        'MetroTextBox7
        '
        Me.MetroTextBox7.Enabled = False
        Me.MetroTextBox7.Lines = New String() {"MetroTextBox7"}
        Me.MetroTextBox7.Location = New System.Drawing.Point(216, 105)
        Me.MetroTextBox7.MaxLength = 60
        Me.MetroTextBox7.Name = "MetroTextBox7"
        Me.MetroTextBox7.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox7.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox7.SelectedText = ""
        Me.MetroTextBox7.Size = New System.Drawing.Size(365, 23)
        Me.MetroTextBox7.TabIndex = 100
        Me.MetroTextBox7.Text = "MetroTextBox7"
        Me.MetroTextBox7.UseSelectable = True
        '
        'MetroTextBox8
        '
        Me.MetroTextBox8.Enabled = False
        Me.MetroTextBox8.Lines = New String() {"MetroTextBox8"}
        Me.MetroTextBox8.Location = New System.Drawing.Point(36, 105)
        Me.MetroTextBox8.MaxLength = 20
        Me.MetroTextBox8.Name = "MetroTextBox8"
        Me.MetroTextBox8.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox8.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox8.SelectedText = ""
        Me.MetroTextBox8.Size = New System.Drawing.Size(161, 23)
        Me.MetroTextBox8.TabIndex = 99
        Me.MetroTextBox8.Text = "MetroTextBox8"
        Me.MetroTextBox8.UseSelectable = True
        '
        'MetroLabel7
        '
        Me.MetroLabel7.AutoSize = True
        Me.MetroLabel7.Location = New System.Drawing.Point(36, 83)
        Me.MetroLabel7.Name = "MetroLabel7"
        Me.MetroLabel7.Size = New System.Drawing.Size(61, 19)
        Me.MetroLabel7.TabIndex = 98
        Me.MetroLabel7.Text = "Número."
        '
        'MetroLink6
        '
        Me.MetroLink6.Location = New System.Drawing.Point(22, 276)
        Me.MetroLink6.Name = "MetroLink6"
        Me.MetroLink6.Size = New System.Drawing.Size(208, 23)
        Me.MetroLink6.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroLink6.TabIndex = 105
        Me.MetroLink6.Text = "Resumen de cuenta corriente."
        Me.MetroLink6.UseSelectable = True
        Me.MetroLink6.UseStyleColors = True
        '
        'MetroLink1
        '
        Me.MetroLink1.Location = New System.Drawing.Point(30, 305)
        Me.MetroLink1.Name = "MetroLink1"
        Me.MetroLink1.Size = New System.Drawing.Size(235, 23)
        Me.MetroLink1.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroLink1.TabIndex = 106
        Me.MetroLink1.Text = "Resumen de movimientos pendientes."
        Me.MetroLink1.UseSelectable = True
        Me.MetroLink1.UseStyleColors = True
        '
        'MetroLink2
        '
        Me.MetroLink2.Location = New System.Drawing.Point(420, 276)
        Me.MetroLink2.Name = "MetroLink2"
        Me.MetroLink2.Size = New System.Drawing.Size(235, 23)
        Me.MetroLink2.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroLink2.TabIndex = 107
        Me.MetroLink2.Text = "Resumen de Saldos."
        Me.MetroLink2.UseSelectable = True
        Me.MetroLink2.UseStyleColors = True
        '
        'MetroLink3
        '
        Me.MetroLink3.Location = New System.Drawing.Point(430, 305)
        Me.MetroLink3.Name = "MetroLink3"
        Me.MetroLink3.Size = New System.Drawing.Size(225, 23)
        Me.MetroLink3.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroLink3.TabIndex = 108
        Me.MetroLink3.Text = "Cheques emitidos.       "
        Me.MetroLink3.UseSelectable = True
        Me.MetroLink3.UseStyleColors = True
        '
        'Form50
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1075, 442)
        Me.Controls.Add(Me.MetroLink3)
        Me.Controls.Add(Me.MetroLink2)
        Me.Controls.Add(Me.MetroLink1)
        Me.Controls.Add(Me.MetroLink6)
        Me.Controls.Add(Me.MetroTextBox10)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroLabel4)
        Me.Controls.Add(Me.MetroTextBox6)
        Me.Controls.Add(Me.MetroTextBox7)
        Me.Controls.Add(Me.MetroTextBox8)
        Me.Controls.Add(Me.MetroLabel7)
        Me.Controls.Add(Me.MetroLabel22)
        Me.Controls.Add(Me.MetroDateTime2)
        Me.Controls.Add(Me.MetroDateTime1)
        Me.Controls.Add(Me.MetroLabel23)
        Me.Controls.Add(Me.MetroLabel12)
        Me.Controls.Add(Me.MetroButton3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form50"
        Me.Style = MetroFramework.MetroColorStyle.Silver
        Me.Text = "Movimientos. "
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MetroStyleManager1 As MetroFramework.Components.MetroStyleManager
    Friend WithEvents MetroStyleExtender1 As MetroFramework.Components.MetroStyleExtender
    Friend WithEvents MetroButton3 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroLabel12 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel22 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroDateTime2 As MetroFramework.Controls.MetroDateTime
    Friend WithEvents MetroDateTime1 As MetroFramework.Controls.MetroDateTime
    Friend WithEvents MetroLabel23 As MetroFramework.Controls.MetroLabel
    Private WithEvents MetroTextBox10 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel4 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroTextBox6 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroTextBox7 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroTextBox8 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel7 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLink6 As MetroFramework.Controls.MetroLink
    Friend WithEvents MetroLink1 As MetroFramework.Controls.MetroLink
    Friend WithEvents MetroLink2 As MetroFramework.Controls.MetroLink
    Friend WithEvents MetroLink3 As MetroFramework.Controls.MetroLink


End Class

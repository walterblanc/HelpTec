<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form74
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form74))
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroStyleManager1 = New MetroFramework.Components.MetroStyleManager(Me.components)
        Me.MetroStyleExtender1 = New MetroFramework.Components.MetroStyleExtender(Me.components)
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.MetroDateTime1 = New MetroFramework.Controls.MetroDateTime()
        Me.MetroRadioButton1 = New MetroFramework.Controls.MetroRadioButton()
        Me.MetroRadioButton2 = New MetroFramework.Controls.MetroRadioButton()
        Me.MetroRadioButton3 = New MetroFramework.Controls.MetroRadioButton()
        Me.MetroLabel11 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBox9 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroTextBox10 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroTextBox11 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroButton4 = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(33, 71)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(46, 19)
        Me.MetroLabel1.TabIndex = 0
        Me.MetroLabel1.Text = "Fecha."
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
        'MetroButton1
        '
        Me.MetroButton1.Location = New System.Drawing.Point(21, 356)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(94, 23)
        Me.MetroButton1.TabIndex = 4
        Me.MetroButton1.Text = "Aceptar"
        Me.MetroButton1.UseSelectable = True
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.Location = New System.Drawing.Point(33, 147)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(141, 19)
        Me.MetroLabel3.TabIndex = 11
        Me.MetroLabel3.Text = "Tipo de comprobante."
        '
        'MetroDateTime1
        '
        Me.MetroDateTime1.FontSize = MetroFramework.MetroDateTimeSize.Small
        Me.MetroDateTime1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MetroDateTime1.Location = New System.Drawing.Point(33, 93)
        Me.MetroDateTime1.MinimumSize = New System.Drawing.Size(0, 25)
        Me.MetroDateTime1.Name = "MetroDateTime1"
        Me.MetroDateTime1.Size = New System.Drawing.Size(108, 25)
        Me.MetroDateTime1.TabIndex = 6
        '
        'MetroRadioButton1
        '
        Me.MetroRadioButton1.AutoSize = True
        Me.MetroRadioButton1.Location = New System.Drawing.Point(34, 180)
        Me.MetroRadioButton1.Name = "MetroRadioButton1"
        Me.MetroRadioButton1.Size = New System.Drawing.Size(65, 15)
        Me.MetroRadioButton1.Style = MetroFramework.MetroColorStyle.Silver
        Me.MetroRadioButton1.TabIndex = 7
        Me.MetroRadioButton1.Text = "Factura."
        Me.MetroRadioButton1.UseSelectable = True
        Me.MetroRadioButton1.UseStyleColors = True
        '
        'MetroRadioButton2
        '
        Me.MetroRadioButton2.AutoSize = True
        Me.MetroRadioButton2.Location = New System.Drawing.Point(117, 180)
        Me.MetroRadioButton2.Name = "MetroRadioButton2"
        Me.MetroRadioButton2.Size = New System.Drawing.Size(105, 15)
        Me.MetroRadioButton2.Style = MetroFramework.MetroColorStyle.Silver
        Me.MetroRadioButton2.TabIndex = 8
        Me.MetroRadioButton2.Text = "Nota de débito."
        Me.MetroRadioButton2.UseSelectable = True
        Me.MetroRadioButton2.UseStyleColors = True
        '
        'MetroRadioButton3
        '
        Me.MetroRadioButton3.AutoSize = True
        Me.MetroRadioButton3.Location = New System.Drawing.Point(250, 180)
        Me.MetroRadioButton3.Name = "MetroRadioButton3"
        Me.MetroRadioButton3.Size = New System.Drawing.Size(108, 15)
        Me.MetroRadioButton3.Style = MetroFramework.MetroColorStyle.Silver
        Me.MetroRadioButton3.TabIndex = 9
        Me.MetroRadioButton3.Text = "Nota de crédito."
        Me.MetroRadioButton3.UseSelectable = True
        Me.MetroRadioButton3.UseStyleColors = True
        '
        'MetroLabel11
        '
        Me.MetroLabel11.AutoSize = True
        Me.MetroLabel11.Location = New System.Drawing.Point(33, 238)
        Me.MetroLabel11.Name = "MetroLabel11"
        Me.MetroLabel11.Size = New System.Drawing.Size(95, 19)
        Me.MetroLabel11.TabIndex = 30
        Me.MetroLabel11.Text = "Comprobante."
        '
        'MetroTextBox9
        '
        Me.MetroTextBox9.Lines = New String() {"MetroTextBox9"}
        Me.MetroTextBox9.Location = New System.Drawing.Point(55, 260)
        Me.MetroTextBox9.MaxLength = 4
        Me.MetroTextBox9.Name = "MetroTextBox9"
        Me.MetroTextBox9.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox9.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox9.SelectedText = ""
        Me.MetroTextBox9.Size = New System.Drawing.Size(43, 23)
        Me.MetroTextBox9.TabIndex = 2
        Me.MetroTextBox9.Text = "MetroTextBox9"
        Me.MetroTextBox9.UseSelectable = True
        '
        'MetroTextBox10
        '
        Me.MetroTextBox10.Lines = New String() {"MetroTextBox10"}
        Me.MetroTextBox10.Location = New System.Drawing.Point(31, 260)
        Me.MetroTextBox10.MaxLength = 1
        Me.MetroTextBox10.Name = "MetroTextBox10"
        Me.MetroTextBox10.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox10.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox10.SelectedText = ""
        Me.MetroTextBox10.Size = New System.Drawing.Size(20, 23)
        Me.MetroTextBox10.TabIndex = 1
        Me.MetroTextBox10.Text = "MetroTextBox10"
        Me.MetroTextBox10.UseSelectable = True
        '
        'MetroTextBox11
        '
        Me.MetroTextBox11.Lines = New String() {"MetroTextBox11"}
        Me.MetroTextBox11.Location = New System.Drawing.Point(104, 260)
        Me.MetroTextBox11.MaxLength = 8
        Me.MetroTextBox11.Name = "MetroTextBox11"
        Me.MetroTextBox11.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox11.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox11.SelectedText = ""
        Me.MetroTextBox11.Size = New System.Drawing.Size(77, 23)
        Me.MetroTextBox11.TabIndex = 3
        Me.MetroTextBox11.Text = "MetroTextBox11"
        Me.MetroTextBox11.UseSelectable = True
        '
        'MetroButton4
        '
        Me.MetroButton4.Location = New System.Drawing.Point(121, 356)
        Me.MetroButton4.Name = "MetroButton4"
        Me.MetroButton4.Size = New System.Drawing.Size(94, 23)
        Me.MetroButton4.TabIndex = 5
        Me.MetroButton4.Text = "Salir"
        Me.MetroButton4.UseSelectable = True
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(23, 30)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(156, 19)
        Me.MetroLabel2.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroLabel2.TabIndex = 64
        Me.MetroLabel2.Text = "Comprobantes anulados."
        Me.MetroLabel2.UseStyleColors = True
        '
        'Form74
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(815, 424)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroButton4)
        Me.Controls.Add(Me.MetroTextBox11)
        Me.Controls.Add(Me.MetroTextBox9)
        Me.Controls.Add(Me.MetroTextBox10)
        Me.Controls.Add(Me.MetroLabel11)
        Me.Controls.Add(Me.MetroRadioButton3)
        Me.Controls.Add(Me.MetroRadioButton2)
        Me.Controls.Add(Me.MetroRadioButton1)
        Me.Controls.Add(Me.MetroDateTime1)
        Me.Controls.Add(Me.MetroLabel3)
        Me.Controls.Add(Me.MetroButton1)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form74"
        Me.Style = MetroFramework.MetroColorStyle.Silver
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroStyleManager1 As MetroFramework.Components.MetroStyleManager
    Friend WithEvents MetroStyleExtender1 As MetroFramework.Components.MetroStyleExtender
    Friend WithEvents MetroButton1 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroLabel3 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroDateTime1 As MetroFramework.Controls.MetroDateTime
    Friend WithEvents MetroRadioButton1 As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents MetroRadioButton2 As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents MetroRadioButton3 As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents MetroLabel11 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroTextBox9 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroTextBox10 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroTextBox11 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroButton4 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form13
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form13))
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBox1 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroStyleManager1 = New MetroFramework.Components.MetroStyleManager(Me.components)
        Me.MetroStyleExtender1 = New MetroFramework.Components.MetroStyleExtender(Me.components)
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel4 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBox2 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroTextBox3 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroTextBox4 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton2 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton3 = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel5 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel6 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBox5 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel7 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBox6 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel8 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBox7 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroComboBox1 = New MetroFramework.Controls.MetroComboBox()
        Me.MetroTextBox8 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel9 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBox9 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel10 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBox10 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel11 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel12 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBox11 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel13 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBox12 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel14 = New MetroFramework.Controls.MetroLabel()
        Me.MetroCheckBox1 = New MetroFramework.Controls.MetroCheckBox()
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(23, 74)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(61, 19)
        Me.MetroLabel1.TabIndex = 0
        Me.MetroLabel1.Text = "Número."
        '
        'MetroTextBox1
        '
        Me.MetroTextBox1.Lines = New String() {"MetroTextBox1"}
        Me.MetroTextBox1.Location = New System.Drawing.Point(23, 96)
        Me.MetroTextBox1.MaxLength = 11
        Me.MetroTextBox1.Name = "MetroTextBox1"
        Me.MetroTextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox1.SelectedText = ""
        Me.MetroTextBox1.Size = New System.Drawing.Size(161, 23)
        Me.MetroTextBox1.TabIndex = 1
        Me.MetroTextBox1.Text = "MetroTextBox1"
        Me.MetroTextBox1.UseSelectable = True
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
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(23, 135)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(66, 19)
        Me.MetroLabel2.TabIndex = 2
        Me.MetroLabel2.Text = "Dirección."
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.Location = New System.Drawing.Point(403, 135)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(54, 19)
        Me.MetroLabel3.TabIndex = 3
        Me.MetroLabel3.Text = "Ciudad."
        '
        'MetroLabel4
        '
        Me.MetroLabel4.AutoSize = True
        Me.MetroLabel4.Location = New System.Drawing.Point(23, 265)
        Me.MetroLabel4.Name = "MetroLabel4"
        Me.MetroLabel4.Size = New System.Drawing.Size(80, 19)
        Me.MetroLabel4.TabIndex = 4
        Me.MetroLabel4.Text = "Calidad IVA."
        '
        'MetroTextBox2
        '
        Me.MetroTextBox2.Lines = New String() {"MetroTextBox2"}
        Me.MetroTextBox2.Location = New System.Drawing.Point(203, 96)
        Me.MetroTextBox2.MaxLength = 100
        Me.MetroTextBox2.Name = "MetroTextBox2"
        Me.MetroTextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox2.SelectedText = ""
        Me.MetroTextBox2.Size = New System.Drawing.Size(365, 23)
        Me.MetroTextBox2.TabIndex = 2
        Me.MetroTextBox2.Text = "MetroTextBox2"
        Me.MetroTextBox2.UseSelectable = True
        '
        'MetroTextBox3
        '
        Me.MetroTextBox3.Lines = New String() {"MetroTextBox3"}
        Me.MetroTextBox3.Location = New System.Drawing.Point(585, 96)
        Me.MetroTextBox3.MaxLength = 100
        Me.MetroTextBox3.Name = "MetroTextBox3"
        Me.MetroTextBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox3.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox3.SelectedText = ""
        Me.MetroTextBox3.Size = New System.Drawing.Size(365, 23)
        Me.MetroTextBox3.TabIndex = 3
        Me.MetroTextBox3.Text = "MetroTextBox3"
        Me.MetroTextBox3.UseSelectable = True
        '
        'MetroTextBox4
        '
        Me.MetroTextBox4.Lines = New String() {"MetroTextBox4"}
        Me.MetroTextBox4.Location = New System.Drawing.Point(23, 157)
        Me.MetroTextBox4.MaxLength = 100
        Me.MetroTextBox4.Name = "MetroTextBox4"
        Me.MetroTextBox4.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox4.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox4.SelectedText = ""
        Me.MetroTextBox4.Size = New System.Drawing.Size(365, 23)
        Me.MetroTextBox4.TabIndex = 4
        Me.MetroTextBox4.Text = "MetroTextBox4"
        Me.MetroTextBox4.UseSelectable = True
        '
        'MetroButton1
        '
        Me.MetroButton1.Location = New System.Drawing.Point(23, 347)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(94, 23)
        Me.MetroButton1.TabIndex = 14
        Me.MetroButton1.Text = "Aceptar"
        Me.MetroButton1.UseSelectable = True
        '
        'MetroButton2
        '
        Me.MetroButton2.Location = New System.Drawing.Point(123, 347)
        Me.MetroButton2.Name = "MetroButton2"
        Me.MetroButton2.Size = New System.Drawing.Size(94, 23)
        Me.MetroButton2.TabIndex = 15
        Me.MetroButton2.Text = "Cancelar"
        Me.MetroButton2.UseSelectable = True
        '
        'MetroButton3
        '
        Me.MetroButton3.Location = New System.Drawing.Point(223, 347)
        Me.MetroButton3.Name = "MetroButton3"
        Me.MetroButton3.Size = New System.Drawing.Size(94, 23)
        Me.MetroButton3.TabIndex = 16
        Me.MetroButton3.Text = "Salir"
        Me.MetroButton3.UseSelectable = True
        '
        'MetroLabel5
        '
        Me.MetroLabel5.AutoSize = True
        Me.MetroLabel5.Location = New System.Drawing.Point(203, 74)
        Me.MetroLabel5.Name = "MetroLabel5"
        Me.MetroLabel5.Size = New System.Drawing.Size(86, 19)
        Me.MetroLabel5.TabIndex = 11
        Me.MetroLabel5.Text = "Razon Social."
        '
        'MetroLabel6
        '
        Me.MetroLabel6.AutoSize = True
        Me.MetroLabel6.Location = New System.Drawing.Point(585, 74)
        Me.MetroLabel6.Name = "MetroLabel6"
        Me.MetroLabel6.Size = New System.Drawing.Size(126, 19)
        Me.MetroLabel6.TabIndex = 12
        Me.MetroLabel6.Text = "Nombre Comercial."
        '
        'MetroTextBox5
        '
        Me.MetroTextBox5.Lines = New String() {"MetroTextBox5"}
        Me.MetroTextBox5.Location = New System.Drawing.Point(403, 157)
        Me.MetroTextBox5.MaxLength = 50
        Me.MetroTextBox5.Name = "MetroTextBox5"
        Me.MetroTextBox5.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox5.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox5.SelectedText = ""
        Me.MetroTextBox5.Size = New System.Drawing.Size(165, 23)
        Me.MetroTextBox5.TabIndex = 5
        Me.MetroTextBox5.Text = "MetroTextBox5"
        Me.MetroTextBox5.UseSelectable = True
        '
        'MetroLabel7
        '
        Me.MetroLabel7.AutoSize = True
        Me.MetroLabel7.Location = New System.Drawing.Point(585, 135)
        Me.MetroLabel7.Name = "MetroLabel7"
        Me.MetroLabel7.Size = New System.Drawing.Size(65, 19)
        Me.MetroLabel7.TabIndex = 14
        Me.MetroLabel7.Text = "Provincia."
        '
        'MetroTextBox6
        '
        Me.MetroTextBox6.Lines = New String() {"MetroTextBox6"}
        Me.MetroTextBox6.Location = New System.Drawing.Point(585, 157)
        Me.MetroTextBox6.MaxLength = 50
        Me.MetroTextBox6.Name = "MetroTextBox6"
        Me.MetroTextBox6.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox6.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox6.SelectedText = ""
        Me.MetroTextBox6.Size = New System.Drawing.Size(165, 23)
        Me.MetroTextBox6.TabIndex = 6
        Me.MetroTextBox6.Text = "MetroTextBox6"
        Me.MetroTextBox6.UseSelectable = True
        '
        'MetroLabel8
        '
        Me.MetroLabel8.AutoSize = True
        Me.MetroLabel8.Location = New System.Drawing.Point(766, 135)
        Me.MetroLabel8.Name = "MetroLabel8"
        Me.MetroLabel8.Size = New System.Drawing.Size(61, 19)
        Me.MetroLabel8.TabIndex = 16
        Me.MetroLabel8.Text = "Teléfono."
        '
        'MetroTextBox7
        '
        Me.MetroTextBox7.Lines = New String() {"MetroTextBox7"}
        Me.MetroTextBox7.Location = New System.Drawing.Point(766, 157)
        Me.MetroTextBox7.MaxLength = 50
        Me.MetroTextBox7.Name = "MetroTextBox7"
        Me.MetroTextBox7.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox7.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox7.SelectedText = ""
        Me.MetroTextBox7.Size = New System.Drawing.Size(184, 23)
        Me.MetroTextBox7.TabIndex = 7
        Me.MetroTextBox7.Text = "MetroTextBox7"
        Me.MetroTextBox7.UseSelectable = True
        '
        'MetroComboBox1
        '
        Me.MetroComboBox1.FontSize = MetroFramework.MetroComboBoxSize.Small
        Me.MetroComboBox1.FormattingEnabled = True
        Me.MetroComboBox1.ItemHeight = 19
        Me.MetroComboBox1.Location = New System.Drawing.Point(23, 287)
        Me.MetroComboBox1.Name = "MetroComboBox1"
        Me.MetroComboBox1.Size = New System.Drawing.Size(194, 25)
        Me.MetroComboBox1.TabIndex = 11
        Me.MetroComboBox1.UseSelectable = True
        '
        'MetroTextBox8
        '
        Me.MetroTextBox8.Lines = New String() {"MetroTextBox8"}
        Me.MetroTextBox8.Location = New System.Drawing.Point(23, 225)
        Me.MetroTextBox8.MaxLength = 50
        Me.MetroTextBox8.Name = "MetroTextBox8"
        Me.MetroTextBox8.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox8.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox8.SelectedText = ""
        Me.MetroTextBox8.Size = New System.Drawing.Size(194, 23)
        Me.MetroTextBox8.TabIndex = 8
        Me.MetroTextBox8.Text = "MetroTextBox8"
        Me.MetroTextBox8.UseSelectable = True
        '
        'MetroLabel9
        '
        Me.MetroLabel9.AutoSize = True
        Me.MetroLabel9.Location = New System.Drawing.Point(23, 203)
        Me.MetroLabel9.Name = "MetroLabel9"
        Me.MetroLabel9.Size = New System.Drawing.Size(51, 19)
        Me.MetroLabel9.TabIndex = 19
        Me.MetroLabel9.Text = "Celular."
        '
        'MetroTextBox9
        '
        Me.MetroTextBox9.Lines = New String() {"MetroTextBox9"}
        Me.MetroTextBox9.Location = New System.Drawing.Point(223, 225)
        Me.MetroTextBox9.MaxLength = 100
        Me.MetroTextBox9.Name = "MetroTextBox9"
        Me.MetroTextBox9.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox9.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox9.SelectedText = ""
        Me.MetroTextBox9.Size = New System.Drawing.Size(345, 23)
        Me.MetroTextBox9.TabIndex = 9
        Me.MetroTextBox9.Text = "MetroTextBox9"
        Me.MetroTextBox9.UseSelectable = True
        '
        'MetroLabel10
        '
        Me.MetroLabel10.AutoSize = True
        Me.MetroLabel10.Location = New System.Drawing.Point(223, 203)
        Me.MetroLabel10.Name = "MetroLabel10"
        Me.MetroLabel10.Size = New System.Drawing.Size(131, 19)
        Me.MetroLabel10.TabIndex = 21
        Me.MetroLabel10.Text = "Persona de contacto."
        '
        'MetroTextBox10
        '
        Me.MetroTextBox10.Lines = New String() {"MetroTextBox10"}
        Me.MetroTextBox10.Location = New System.Drawing.Point(585, 225)
        Me.MetroTextBox10.MaxLength = 100
        Me.MetroTextBox10.Name = "MetroTextBox10"
        Me.MetroTextBox10.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox10.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox10.SelectedText = ""
        Me.MetroTextBox10.Size = New System.Drawing.Size(365, 23)
        Me.MetroTextBox10.TabIndex = 10
        Me.MetroTextBox10.Text = "MetroTextBox10"
        Me.MetroTextBox10.UseSelectable = True
        '
        'MetroLabel11
        '
        Me.MetroLabel11.AutoSize = True
        Me.MetroLabel11.Location = New System.Drawing.Point(585, 203)
        Me.MetroLabel11.Name = "MetroLabel11"
        Me.MetroLabel11.Size = New System.Drawing.Size(50, 19)
        Me.MetroLabel11.TabIndex = 23
        Me.MetroLabel11.Text = "e-mail."
        '
        'MetroLabel12
        '
        Me.MetroLabel12.AutoSize = True
        Me.MetroLabel12.FontSize = MetroFramework.MetroLabelSize.Small
        Me.MetroLabel12.Location = New System.Drawing.Point(913, 358)
        Me.MetroLabel12.Name = "MetroLabel12"
        Me.MetroLabel12.Size = New System.Drawing.Size(41, 15)
        Me.MetroLabel12.TabIndex = 24
        Me.MetroLabel12.Text = "form13"
        '
        'MetroTextBox11
        '
        Me.MetroTextBox11.Lines = New String() {"MetroTextBox11"}
        Me.MetroTextBox11.Location = New System.Drawing.Point(223, 287)
        Me.MetroTextBox11.MaxLength = 11
        Me.MetroTextBox11.Name = "MetroTextBox11"
        Me.MetroTextBox11.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox11.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox11.SelectedText = ""
        Me.MetroTextBox11.Size = New System.Drawing.Size(120, 23)
        Me.MetroTextBox11.TabIndex = 12
        Me.MetroTextBox11.Text = "MetroTextBox11"
        Me.MetroTextBox11.UseSelectable = True
        '
        'MetroLabel13
        '
        Me.MetroLabel13.AutoSize = True
        Me.MetroLabel13.Location = New System.Drawing.Point(223, 265)
        Me.MetroLabel13.Name = "MetroLabel13"
        Me.MetroLabel13.Size = New System.Drawing.Size(35, 19)
        Me.MetroLabel13.TabIndex = 27
        Me.MetroLabel13.Text = "Cuit."
        '
        'MetroTextBox12
        '
        Me.MetroTextBox12.Lines = New String() {"MetroTextBox12"}
        Me.MetroTextBox12.Location = New System.Drawing.Point(349, 287)
        Me.MetroTextBox12.MaxLength = 8
        Me.MetroTextBox12.Name = "MetroTextBox12"
        Me.MetroTextBox12.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox12.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox12.SelectedText = ""
        Me.MetroTextBox12.Size = New System.Drawing.Size(92, 23)
        Me.MetroTextBox12.TabIndex = 13
        Me.MetroTextBox12.Text = "MetroTextBox12"
        Me.MetroTextBox12.UseSelectable = True
        '
        'MetroLabel14
        '
        Me.MetroLabel14.AutoSize = True
        Me.MetroLabel14.Location = New System.Drawing.Point(349, 265)
        Me.MetroLabel14.Name = "MetroLabel14"
        Me.MetroLabel14.Size = New System.Drawing.Size(80, 19)
        Me.MetroLabel14.TabIndex = 29
        Me.MetroLabel14.Text = "Documento."
        '
        'MetroCheckBox1
        '
        Me.MetroCheckBox1.AutoSize = True
        Me.MetroCheckBox1.FontSize = MetroFramework.MetroCheckBoxSize.Medium
        Me.MetroCheckBox1.Location = New System.Drawing.Point(502, 287)
        Me.MetroCheckBox1.Name = "MetroCheckBox1"
        Me.MetroCheckBox1.Size = New System.Drawing.Size(199, 19)
        Me.MetroCheckBox1.TabIndex = 17
        Me.MetroCheckBox1.Text = "Habilitado Cuenta Corriente."
        Me.MetroCheckBox1.UseSelectable = True
        Me.MetroCheckBox1.UseStyleColors = True
        '
        'Form13
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 393)
        Me.Controls.Add(Me.MetroCheckBox1)
        Me.Controls.Add(Me.MetroTextBox12)
        Me.Controls.Add(Me.MetroLabel14)
        Me.Controls.Add(Me.MetroTextBox11)
        Me.Controls.Add(Me.MetroLabel13)
        Me.Controls.Add(Me.MetroLabel12)
        Me.Controls.Add(Me.MetroTextBox10)
        Me.Controls.Add(Me.MetroLabel11)
        Me.Controls.Add(Me.MetroTextBox9)
        Me.Controls.Add(Me.MetroLabel10)
        Me.Controls.Add(Me.MetroTextBox8)
        Me.Controls.Add(Me.MetroLabel9)
        Me.Controls.Add(Me.MetroComboBox1)
        Me.Controls.Add(Me.MetroTextBox7)
        Me.Controls.Add(Me.MetroLabel8)
        Me.Controls.Add(Me.MetroTextBox6)
        Me.Controls.Add(Me.MetroLabel7)
        Me.Controls.Add(Me.MetroTextBox5)
        Me.Controls.Add(Me.MetroLabel6)
        Me.Controls.Add(Me.MetroLabel5)
        Me.Controls.Add(Me.MetroButton3)
        Me.Controls.Add(Me.MetroButton2)
        Me.Controls.Add(Me.MetroButton1)
        Me.Controls.Add(Me.MetroTextBox4)
        Me.Controls.Add(Me.MetroTextBox3)
        Me.Controls.Add(Me.MetroTextBox2)
        Me.Controls.Add(Me.MetroLabel4)
        Me.Controls.Add(Me.MetroLabel3)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroTextBox1)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form13"
        Me.Style = MetroFramework.MetroColorStyle.Silver
        Me.Text = "Clientes."
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroTextBox1 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroStyleManager1 As MetroFramework.Components.MetroStyleManager
    Friend WithEvents MetroStyleExtender1 As MetroFramework.Components.MetroStyleExtender
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel3 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel4 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroTextBox2 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroTextBox3 As MetroFramework.Controls.MetroTextBox
    Private WithEvents MetroTextBox4 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroButton1 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton2 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton3 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroLabel5 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel6 As MetroFramework.Controls.MetroLabel
    Private WithEvents MetroTextBox5 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel7 As MetroFramework.Controls.MetroLabel
    Private WithEvents MetroTextBox6 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel8 As MetroFramework.Controls.MetroLabel
    Private WithEvents MetroTextBox7 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroComboBox1 As MetroFramework.Controls.MetroComboBox
    Private WithEvents MetroTextBox8 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel9 As MetroFramework.Controls.MetroLabel
    Private WithEvents MetroTextBox9 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel10 As MetroFramework.Controls.MetroLabel
    Private WithEvents MetroTextBox10 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel11 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel12 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroTextBox11 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel13 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroTextBox12 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel14 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroCheckBox1 As MetroFramework.Controls.MetroCheckBox


End Class

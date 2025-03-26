<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form44fe
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form44fe))
        Me.metroGrid1 = New MetroFramework.Controls.MetroGrid()
        Me.MetroContextMenu1 = New MetroFramework.Controls.MetroContextMenu(Me.components)
        Me.ModificarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MetroLink1 = New MetroFramework.Controls.MetroLink()
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLink2 = New MetroFramework.Controls.MetroLink()
        Me.MetroDateTime2 = New MetroFramework.Controls.MetroDateTime()
        Me.MetroButton2 = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel10 = New MetroFramework.Controls.MetroLabel()
        Me.MetroDateTime1 = New MetroFramework.Controls.MetroDateTime()
        Me.MetroLabel15 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLink3 = New MetroFramework.Controls.MetroLink()
        Me.MetroLink4 = New MetroFramework.Controls.MetroLink()
        Me.MetroComboBox1 = New MetroFramework.Controls.MetroComboBox()
        Me.MetroLink5 = New MetroFramework.Controls.MetroLink()
        Me.MetroLink6 = New MetroFramework.Controls.MetroLink()
        Me.MetroLink7 = New MetroFramework.Controls.MetroLink()
        Me.MetroTextBox1 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLink8 = New MetroFramework.Controls.MetroLink()
        CType(Me.metroGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MetroContextMenu1.SuspendLayout()
        Me.SuspendLayout()
        '
        'metroGrid1
        '
        Me.metroGrid1.AllowUserToAddRows = False
        Me.metroGrid1.AllowUserToDeleteRows = False
        Me.metroGrid1.AllowUserToResizeColumns = False
        Me.metroGrid1.AllowUserToResizeRows = False
        Me.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.metroGrid1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.metroGrid1.ColumnHeadersHeight = 30
        Me.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.metroGrid1.ContextMenuStrip = Me.MetroContextMenu1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.metroGrid1.DefaultCellStyle = DataGridViewCellStyle2
        Me.metroGrid1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.metroGrid1.EnableHeadersVisualStyles = False
        Me.metroGrid1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.metroGrid1.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.metroGrid1.Location = New System.Drawing.Point(20, 121)
        Me.metroGrid1.Name = "metroGrid1"
        Me.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.metroGrid1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.metroGrid1.RowHeadersVisible = False
        Me.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.metroGrid1.Size = New System.Drawing.Size(1135, 322)
        Me.metroGrid1.TabIndex = 2
        '
        'MetroContextMenu1
        '
        Me.MetroContextMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModificarToolStripMenuItem, Me.EliminarToolStripMenuItem})
        Me.MetroContextMenu1.Name = "MetroContextMenu1"
        Me.MetroContextMenu1.Size = New System.Drawing.Size(126, 48)
        Me.MetroContextMenu1.Style = MetroFramework.MetroColorStyle.Magenta
        Me.MetroContextMenu1.UseStyleColors = True
        '
        'ModificarToolStripMenuItem
        '
        Me.ModificarToolStripMenuItem.Name = "ModificarToolStripMenuItem"
        Me.ModificarToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.ModificarToolStripMenuItem.Text = "Modificar"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'MetroLink1
        '
        Me.MetroLink1.Location = New System.Drawing.Point(411, 81)
        Me.MetroLink1.Name = "MetroLink1"
        Me.MetroLink1.Size = New System.Drawing.Size(192, 23)
        Me.MetroLink1.Style = MetroFramework.MetroColorStyle.Silver
        Me.MetroLink1.TabIndex = 4
        Me.MetroLink1.Text = "Reimpresión Original."
        Me.MetroLink1.UseSelectable = True
        Me.MetroLink1.UseStyleColors = True
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.FontSize = MetroFramework.MetroLabelSize.Small
        Me.MetroLabel3.Location = New System.Drawing.Point(1111, 457)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(52, 15)
        Me.MetroLabel3.TabIndex = 25
        Me.MetroLabel3.Text = "form44fe"
        '
        'MetroLink2
        '
        Me.MetroLink2.Location = New System.Drawing.Point(1001, 81)
        Me.MetroLink2.Name = "MetroLink2"
        Me.MetroLink2.Size = New System.Drawing.Size(154, 23)
        Me.MetroLink2.Style = MetroFramework.MetroColorStyle.Silver
        Me.MetroLink2.TabIndex = 26
        Me.MetroLink2.Text = "Consultar Afip."
        Me.MetroLink2.UseSelectable = True
        Me.MetroLink2.UseStyleColors = True
        '
        'MetroDateTime2
        '
        Me.MetroDateTime2.FontSize = MetroFramework.MetroDateTimeSize.Small
        Me.MetroDateTime2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MetroDateTime2.Location = New System.Drawing.Point(137, 79)
        Me.MetroDateTime2.MinimumSize = New System.Drawing.Size(0, 25)
        Me.MetroDateTime2.Name = "MetroDateTime2"
        Me.MetroDateTime2.Size = New System.Drawing.Size(108, 25)
        Me.MetroDateTime2.TabIndex = 50
        '
        'MetroButton2
        '
        Me.MetroButton2.Location = New System.Drawing.Point(251, 81)
        Me.MetroButton2.Name = "MetroButton2"
        Me.MetroButton2.Size = New System.Drawing.Size(94, 23)
        Me.MetroButton2.TabIndex = 47
        Me.MetroButton2.Text = "Refrescar"
        Me.MetroButton2.UseSelectable = True
        '
        'MetroLabel10
        '
        Me.MetroLabel10.AutoSize = True
        Me.MetroLabel10.Location = New System.Drawing.Point(137, 57)
        Me.MetroLabel10.Name = "MetroLabel10"
        Me.MetroLabel10.Size = New System.Drawing.Size(82, 19)
        Me.MetroLabel10.TabIndex = 51
        Me.MetroLabel10.Text = "Hasta Fecha."
        '
        'MetroDateTime1
        '
        Me.MetroDateTime1.FontSize = MetroFramework.MetroDateTimeSize.Small
        Me.MetroDateTime1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MetroDateTime1.Location = New System.Drawing.Point(23, 79)
        Me.MetroDateTime1.MinimumSize = New System.Drawing.Size(0, 25)
        Me.MetroDateTime1.Name = "MetroDateTime1"
        Me.MetroDateTime1.Size = New System.Drawing.Size(108, 25)
        Me.MetroDateTime1.TabIndex = 48
        '
        'MetroLabel15
        '
        Me.MetroLabel15.AutoSize = True
        Me.MetroLabel15.Location = New System.Drawing.Point(23, 57)
        Me.MetroLabel15.Name = "MetroLabel15"
        Me.MetroLabel15.Size = New System.Drawing.Size(86, 19)
        Me.MetroLabel15.TabIndex = 49
        Me.MetroLabel15.Text = "Desde Fecha."
        '
        'MetroLink3
        '
        Me.MetroLink3.Location = New System.Drawing.Point(792, 81)
        Me.MetroLink3.Name = "MetroLink3"
        Me.MetroLink3.Size = New System.Drawing.Size(172, 23)
        Me.MetroLink3.Style = MetroFramework.MetroColorStyle.Silver
        Me.MetroLink3.TabIndex = 52
        Me.MetroLink3.Text = "Reimpresión Ticket"
        Me.MetroLink3.UseSelectable = True
        Me.MetroLink3.UseStyleColors = True
        '
        'MetroLink4
        '
        Me.MetroLink4.Location = New System.Drawing.Point(594, 81)
        Me.MetroLink4.Name = "MetroLink4"
        Me.MetroLink4.Size = New System.Drawing.Size(192, 23)
        Me.MetroLink4.Style = MetroFramework.MetroColorStyle.Silver
        Me.MetroLink4.TabIndex = 53
        Me.MetroLink4.Text = "Reimpresión Duplicado."
        Me.MetroLink4.UseSelectable = True
        Me.MetroLink4.UseStyleColors = True
        '
        'MetroComboBox1
        '
        Me.MetroComboBox1.FontSize = MetroFramework.MetroComboBoxSize.Small
        Me.MetroComboBox1.FormattingEnabled = True
        Me.MetroComboBox1.ItemHeight = 19
        Me.MetroComboBox1.Location = New System.Drawing.Point(15, 453)
        Me.MetroComboBox1.Name = "MetroComboBox1"
        Me.MetroComboBox1.Size = New System.Drawing.Size(386, 25)
        Me.MetroComboBox1.TabIndex = 54
        Me.MetroComboBox1.UseSelectable = True
        '
        'MetroLink5
        '
        Me.MetroLink5.Location = New System.Drawing.Point(411, 52)
        Me.MetroLink5.Name = "MetroLink5"
        Me.MetroLink5.Size = New System.Drawing.Size(192, 23)
        Me.MetroLink5.Style = MetroFramework.MetroColorStyle.Silver
        Me.MetroLink5.TabIndex = 55
        Me.MetroLink5.Text = "Visualización Original."
        Me.MetroLink5.UseSelectable = True
        Me.MetroLink5.UseStyleColors = True
        '
        'MetroLink6
        '
        Me.MetroLink6.Location = New System.Drawing.Point(594, 52)
        Me.MetroLink6.Name = "MetroLink6"
        Me.MetroLink6.Size = New System.Drawing.Size(192, 23)
        Me.MetroLink6.Style = MetroFramework.MetroColorStyle.Silver
        Me.MetroLink6.TabIndex = 56
        Me.MetroLink6.Text = "Visualización Duplicado."
        Me.MetroLink6.UseSelectable = True
        Me.MetroLink6.UseStyleColors = True
        '
        'MetroLink7
        '
        Me.MetroLink7.Location = New System.Drawing.Point(815, 52)
        Me.MetroLink7.Name = "MetroLink7"
        Me.MetroLink7.Size = New System.Drawing.Size(106, 23)
        Me.MetroLink7.Style = MetroFramework.MetroColorStyle.Green
        Me.MetroLink7.TabIndex = 57
        Me.MetroLink7.Text = "Enviar por Mail."
        Me.MetroLink7.UseSelectable = True
        Me.MetroLink7.UseStyleColors = True
        '
        'MetroTextBox1
        '
        Me.MetroTextBox1.Lines = New String() {"MetroTextBox8"}
        Me.MetroTextBox1.Location = New System.Drawing.Point(411, 454)
        Me.MetroTextBox1.MaxLength = 150
        Me.MetroTextBox1.Name = "MetroTextBox1"
        Me.MetroTextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox1.SelectedText = ""
        Me.MetroTextBox1.Size = New System.Drawing.Size(656, 23)
        Me.MetroTextBox1.TabIndex = 58
        Me.MetroTextBox1.Text = "MetroTextBox8"
        Me.MetroTextBox1.UseSelectable = True
        '
        'MetroLink8
        '
        Me.MetroLink8.Location = New System.Drawing.Point(961, 52)
        Me.MetroLink8.Name = "MetroLink8"
        Me.MetroLink8.Size = New System.Drawing.Size(154, 23)
        Me.MetroLink8.Style = MetroFramework.MetroColorStyle.Green
        Me.MetroLink8.TabIndex = 59
        Me.MetroLink8.Text = "Seguimiento de mails"
        Me.MetroLink8.UseSelectable = True
        Me.MetroLink8.UseStyleColors = True
        '
        'Form44fe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1178, 487)
        Me.Controls.Add(Me.MetroLink8)
        Me.Controls.Add(Me.MetroTextBox1)
        Me.Controls.Add(Me.MetroLink7)
        Me.Controls.Add(Me.MetroLink6)
        Me.Controls.Add(Me.MetroLink5)
        Me.Controls.Add(Me.MetroComboBox1)
        Me.Controls.Add(Me.MetroLink4)
        Me.Controls.Add(Me.MetroLink3)
        Me.Controls.Add(Me.MetroDateTime2)
        Me.Controls.Add(Me.MetroButton2)
        Me.Controls.Add(Me.MetroLabel10)
        Me.Controls.Add(Me.MetroDateTime1)
        Me.Controls.Add(Me.MetroLabel15)
        Me.Controls.Add(Me.MetroLink2)
        Me.Controls.Add(Me.MetroLabel3)
        Me.Controls.Add(Me.metroGrid1)
        Me.Controls.Add(Me.MetroLink1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form44fe"
        Me.Style = MetroFramework.MetroColorStyle.Silver
        Me.Text = "Reimpresión de Comprobantes."
        CType(Me.metroGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MetroContextMenu1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents metroGrid1 As MetroFramework.Controls.MetroGrid
    Friend WithEvents MetroLink1 As MetroFramework.Controls.MetroLink
    Friend WithEvents MetroContextMenu1 As MetroFramework.Controls.MetroContextMenu
    Friend WithEvents ModificarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MetroLabel3 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLink2 As MetroFramework.Controls.MetroLink
    Friend WithEvents MetroDateTime2 As MetroFramework.Controls.MetroDateTime
    Friend WithEvents MetroButton2 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroLabel10 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroDateTime1 As MetroFramework.Controls.MetroDateTime
    Friend WithEvents MetroLabel15 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLink3 As MetroFramework.Controls.MetroLink
    Friend WithEvents MetroLink4 As MetroFramework.Controls.MetroLink
    Friend WithEvents MetroComboBox1 As MetroFramework.Controls.MetroComboBox
    Friend WithEvents MetroLink5 As MetroFramework.Controls.MetroLink
    Friend WithEvents MetroLink6 As MetroFramework.Controls.MetroLink
    Friend WithEvents MetroLink7 As MetroFramework.Controls.MetroLink
    Friend WithEvents MetroTextBox1 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLink8 As MetroFramework.Controls.MetroLink

End Class

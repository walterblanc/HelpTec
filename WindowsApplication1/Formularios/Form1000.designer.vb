<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1000
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1000))
        Me.MetroStyleManager1 = New MetroFramework.Components.MetroStyleManager(Me.components)
        Me.MetroStyleExtender1 = New MetroFramework.Components.MetroStyleExtender(Me.components)
        Me.CrvReportes = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
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
        'CrvReportes
        '
        Me.CrvReportes.ActiveViewIndex = -1
        Me.CrvReportes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrvReportes.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrvReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrvReportes.Location = New System.Drawing.Point(20, 60)
        Me.CrvReportes.Name = "CrvReportes"
        Me.CrvReportes.ShowCloseButton = False
        Me.CrvReportes.ShowGroupTreeButton = False
        Me.CrvReportes.ShowParameterPanelButton = False
        Me.CrvReportes.ShowRefreshButton = False
        Me.CrvReportes.Size = New System.Drawing.Size(984, 573)
        Me.CrvReportes.TabIndex = 0
        Me.CrvReportes.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Form1000
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 653)
        Me.Controls.Add(Me.CrvReportes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1000"
        Me.Style = MetroFramework.MetroColorStyle.Silver
        Me.Text = "Reporte."
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MetroStyleManager1 As MetroFramework.Components.MetroStyleManager
    Friend WithEvents MetroStyleExtender1 As MetroFramework.Components.MetroStyleExtender
    Friend WithEvents CrvReportes As CrystalDecisions.Windows.Forms.CrystalReportViewer

End Class

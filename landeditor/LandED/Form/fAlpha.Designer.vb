<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fAlpha
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fAlpha))
        Me.grpLayerSettings = New System.Windows.Forms.GroupBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.numAAAltitude = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.numMaxAlt = New System.Windows.Forms.NumericUpDown
        Me.numMinAlt = New System.Windows.Forms.NumericUpDown
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lstLandscapes = New System.Windows.Forms.ListBox
        Me.grpLayerSettings.SuspendLayout()
        CType(Me.numAAAltitude, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMaxAlt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMinAlt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpLayerSettings
        '
        Me.grpLayerSettings.Controls.Add(Me.txtName)
        Me.grpLayerSettings.Controls.Add(Me.Label8)
        Me.grpLayerSettings.Location = New System.Drawing.Point(12, 185)
        Me.grpLayerSettings.Name = "grpLayerSettings"
        Me.grpLayerSettings.Size = New System.Drawing.Size(210, 65)
        Me.grpLayerSettings.TabIndex = 43
        Me.grpLayerSettings.TabStop = False
        Me.grpLayerSettings.Text = "Alpha Layer Settings"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(6, 32)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(198, 20)
        Me.txtName.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Name"
        '
        'numAAAltitude
        '
        Me.numAAAltitude.Location = New System.Drawing.Point(135, 32)
        Me.numAAAltitude.Maximum = New Decimal(New Integer() {32, 0, 0, 0})
        Me.numAAAltitude.Name = "numAAAltitude"
        Me.numAAAltitude.Size = New System.Drawing.Size(63, 20)
        Me.numAAAltitude.TabIndex = 1
        Me.numAAAltitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(134, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Anti-Aliasing"
        '
        'numMaxAlt
        '
        Me.numMaxAlt.Location = New System.Drawing.Point(72, 32)
        Me.numMaxAlt.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numMaxAlt.Name = "numMaxAlt"
        Me.numMaxAlt.Size = New System.Drawing.Size(57, 20)
        Me.numMaxAlt.TabIndex = 3
        Me.numMaxAlt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numMaxAlt.Value = New Decimal(New Integer() {255, 0, 0, 0})
        '
        'numMinAlt
        '
        Me.numMinAlt.Location = New System.Drawing.Point(9, 32)
        Me.numMinAlt.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numMinAlt.Name = "numMinAlt"
        Me.numMinAlt.Size = New System.Drawing.Size(57, 20)
        Me.numMinAlt.TabIndex = 2
        Me.numMinAlt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.numAAAltitude)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.numMinAlt)
        Me.GroupBox1.Controls.Add(Me.numMaxAlt)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 256)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(210, 60)
        Me.GroupBox1.TabIndex = 44
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Altitude"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(69, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Maximum"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Minimum"
        '
        'btnGenerate
        '
        Me.btnGenerate.Enabled = False
        Me.btnGenerate.Image = CType(resources.GetObject("btnGenerate.Image"), System.Drawing.Image)
        Me.btnGenerate.Location = New System.Drawing.Point(12, 322)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(210, 30)
        Me.btnGenerate.TabIndex = 6
        Me.btnGenerate.Text = "Generate Alpha Layer"
        Me.btnGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lstLandscapes)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(210, 167)
        Me.GroupBox3.TabIndex = 47
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Landscapes"
        '
        'lstLandscapes
        '
        Me.lstLandscapes.FormattingEnabled = True
        Me.lstLandscapes.Location = New System.Drawing.Point(6, 19)
        Me.lstLandscapes.Name = "lstLandscapes"
        Me.lstLandscapes.Size = New System.Drawing.Size(198, 134)
        Me.lstLandscapes.TabIndex = 7
        '
        'fAlpha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(233, 364)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpLayerSettings)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fAlpha"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alpha Layer Generator"
        Me.grpLayerSettings.ResumeLayout(False)
        Me.grpLayerSettings.PerformLayout()
        CType(Me.numAAAltitude, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMaxAlt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMinAlt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpLayerSettings As System.Windows.Forms.GroupBox
    Friend WithEvents numMaxAlt As System.Windows.Forms.NumericUpDown
    Friend WithEvents numMinAlt As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lstLandscapes As System.Windows.Forms.ListBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents numAAAltitude As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

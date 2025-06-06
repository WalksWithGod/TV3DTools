<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fLandscapes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fLandscapes))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lstLandscapes = New System.Windows.Forms.ListBox
        Me.chkRender = New System.Windows.Forms.CheckBox
        Me.grpSettings = New System.Windows.Forms.GroupBox
        Me.cboMaterial = New System.Windows.Forms.ComboBox
        Me.numScale = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.numPosX = New System.Windows.Forms.NumericUpDown
        Me.numPosZ = New System.Windows.Forms.NumericUpDown
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnAddFlat = New System.Windows.Forms.Button
        Me.btnImport = New System.Windows.Forms.Button
        Me.btnExportTVM = New System.Windows.Forms.Button
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.btnExportBMP = New System.Windows.Forms.Button
        Me.grpPosition = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.grpSettings.SuspendLayout()
        CType(Me.numScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPosX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPosZ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPosition.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstLandscapes)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(206, 210)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Landscapes"
        '
        'lstLandscapes
        '
        Me.lstLandscapes.FormattingEnabled = True
        Me.lstLandscapes.Location = New System.Drawing.Point(6, 19)
        Me.lstLandscapes.Name = "lstLandscapes"
        Me.lstLandscapes.Size = New System.Drawing.Size(194, 186)
        Me.lstLandscapes.TabIndex = 1
        '
        'chkRender
        '
        Me.chkRender.AutoSize = True
        Me.chkRender.Location = New System.Drawing.Point(17, 36)
        Me.chkRender.Name = "chkRender"
        Me.chkRender.Size = New System.Drawing.Size(61, 17)
        Me.chkRender.TabIndex = 10
        Me.chkRender.Text = "Render"
        Me.chkRender.UseVisualStyleBackColor = True
        '
        'grpSettings
        '
        Me.grpSettings.Controls.Add(Me.chkRender)
        Me.grpSettings.Controls.Add(Me.cboMaterial)
        Me.grpSettings.Controls.Add(Me.numScale)
        Me.grpSettings.Controls.Add(Me.Label2)
        Me.grpSettings.Controls.Add(Me.Label1)
        Me.grpSettings.Location = New System.Drawing.Point(224, 12)
        Me.grpSettings.Name = "grpSettings"
        Me.grpSettings.Size = New System.Drawing.Size(206, 129)
        Me.grpSettings.TabIndex = 1
        Me.grpSettings.TabStop = False
        Me.grpSettings.Text = "Settings"
        '
        'cboMaterial
        '
        Me.cboMaterial.FormattingEnabled = True
        Me.cboMaterial.Location = New System.Drawing.Point(9, 97)
        Me.cboMaterial.Name = "cboMaterial"
        Me.cboMaterial.Size = New System.Drawing.Size(188, 21)
        Me.cboMaterial.TabIndex = 2
        '
        'numScale
        '
        Me.numScale.DecimalPlaces = 2
        Me.numScale.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numScale.Location = New System.Drawing.Point(103, 52)
        Me.numScale.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numScale.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numScale.Name = "numScale"
        Me.numScale.Size = New System.Drawing.Size(69, 20)
        Me.numScale.TabIndex = 2
        Me.numScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numScale.Value = New Decimal(New Integer() {100, 0, 0, 131072})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Material"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(100, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Scale"
        '
        'numPosX
        '
        Me.numPosX.Increment = New Decimal(New Integer() {256, 0, 0, 0})
        Me.numPosX.Location = New System.Drawing.Point(103, 41)
        Me.numPosX.Maximum = New Decimal(New Integer() {25600, 0, 0, 0})
        Me.numPosX.Minimum = New Decimal(New Integer() {25600, 0, 0, -2147483648})
        Me.numPosX.Name = "numPosX"
        Me.numPosX.Size = New System.Drawing.Size(88, 20)
        Me.numPosX.TabIndex = 7
        Me.numPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numPosZ
        '
        Me.numPosZ.Increment = New Decimal(New Integer() {256, 0, 0, 0})
        Me.numPosZ.Location = New System.Drawing.Point(9, 41)
        Me.numPosZ.Maximum = New Decimal(New Integer() {25600, 0, 0, 0})
        Me.numPosZ.Minimum = New Decimal(New Integer() {25600, 0, 0, -2147483648})
        Me.numPosZ.Name = "numPosZ"
        Me.numPosZ.Size = New System.Drawing.Size(88, 20)
        Me.numPosZ.TabIndex = 10
        Me.numPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "North / South"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(100, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "East / West"
        '
        'btnAddFlat
        '
        Me.btnAddFlat.Image = CType(resources.GetObject("btnAddFlat.Image"), System.Drawing.Image)
        Me.btnAddFlat.Location = New System.Drawing.Point(436, 12)
        Me.btnAddFlat.Name = "btnAddFlat"
        Me.btnAddFlat.Size = New System.Drawing.Size(100, 30)
        Me.btnAddFlat.TabIndex = 4
        Me.btnAddFlat.Text = "Add Flat"
        Me.btnAddFlat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAddFlat.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Image = CType(resources.GetObject("btnImport.Image"), System.Drawing.Image)
        Me.btnImport.Location = New System.Drawing.Point(436, 84)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(100, 30)
        Me.btnImport.TabIndex = 5
        Me.btnImport.Text = "Import TVM"
        Me.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnExportTVM
        '
        Me.btnExportTVM.Image = CType(resources.GetObject("btnExportTVM.Image"), System.Drawing.Image)
        Me.btnExportTVM.Location = New System.Drawing.Point(436, 120)
        Me.btnExportTVM.Name = "btnExportTVM"
        Me.btnExportTVM.Size = New System.Drawing.Size(100, 30)
        Me.btnExportTVM.TabIndex = 6
        Me.btnExportTVM.Text = "Export TVM"
        Me.btnExportTVM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExportTVM.UseVisualStyleBackColor = True
        '
        'btnGenerate
        '
        Me.btnGenerate.Image = CType(resources.GetObject("btnGenerate.Image"), System.Drawing.Image)
        Me.btnGenerate.Location = New System.Drawing.Point(436, 48)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(100, 30)
        Me.btnGenerate.TabIndex = 8
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Image = CType(resources.GetObject("btnRemove.Image"), System.Drawing.Image)
        Me.btnRemove.Location = New System.Drawing.Point(436, 192)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(100, 30)
        Me.btnRemove.TabIndex = 9
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnExportBMP
        '
        Me.btnExportBMP.Image = CType(resources.GetObject("btnExportBMP.Image"), System.Drawing.Image)
        Me.btnExportBMP.Location = New System.Drawing.Point(436, 156)
        Me.btnExportBMP.Name = "btnExportBMP"
        Me.btnExportBMP.Size = New System.Drawing.Size(100, 30)
        Me.btnExportBMP.TabIndex = 7
        Me.btnExportBMP.Text = "Export BMP"
        Me.btnExportBMP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExportBMP.UseVisualStyleBackColor = True
        '
        'grpPosition
        '
        Me.grpPosition.Controls.Add(Me.numPosZ)
        Me.grpPosition.Controls.Add(Me.Label4)
        Me.grpPosition.Controls.Add(Me.numPosX)
        Me.grpPosition.Controls.Add(Me.Label3)
        Me.grpPosition.Location = New System.Drawing.Point(224, 147)
        Me.grpPosition.Name = "grpPosition"
        Me.grpPosition.Size = New System.Drawing.Size(200, 75)
        Me.grpPosition.TabIndex = 10
        Me.grpPosition.TabStop = False
        Me.grpPosition.Text = "Position"
        '
        'fLandscapes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 236)
        Me.Controls.Add(Me.grpPosition)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnExportBMP)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.btnExportTVM)
        Me.Controls.Add(Me.grpSettings)
        Me.Controls.Add(Me.btnAddFlat)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fLandscapes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Landscapes"
        Me.GroupBox1.ResumeLayout(False)
        Me.grpSettings.ResumeLayout(False)
        Me.grpSettings.PerformLayout()
        CType(Me.numScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPosX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPosZ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPosition.ResumeLayout(False)
        Me.grpPosition.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstLandscapes As System.Windows.Forms.ListBox
    Friend WithEvents grpSettings As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboMaterial As System.Windows.Forms.ComboBox
    Friend WithEvents numScale As System.Windows.Forms.NumericUpDown
    Friend WithEvents numPosZ As System.Windows.Forms.NumericUpDown
    Friend WithEvents numPosX As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnAddFlat As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents btnExportTVM As System.Windows.Forms.Button
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnExportBMP As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkRender As System.Windows.Forms.CheckBox
    Friend WithEvents grpPosition As System.Windows.Forms.GroupBox
End Class

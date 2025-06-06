<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fWater
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fWater))
        Me.numPosX = New System.Windows.Forms.NumericUpDown
        Me.numPosZ = New System.Windows.Forms.NumericUpDown
        Me.grpPosition = New System.Windows.Forms.GroupBox
        Me.numAltitude = New System.Windows.Forms.NumericUpDown
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnRemove = New System.Windows.Forms.Button
        Me.grpSettings = New System.Windows.Forms.GroupBox
        Me.cboMaterial = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lstWater = New System.Windows.Forms.ListBox
        Me.btnAdd = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.grpScale = New System.Windows.Forms.GroupBox
        Me.numScaleX = New System.Windows.Forms.NumericUpDown
        Me.numScaleZ = New System.Windows.Forms.NumericUpDown
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnDefault = New System.Windows.Forms.Button
        CType(Me.numPosX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPosZ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPosition.SuspendLayout()
        CType(Me.numAltitude, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSettings.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpScale.SuspendLayout()
        CType(Me.numScaleX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScaleZ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'numPosX
        '
        Me.numPosX.DecimalPlaces = 2
        Me.numPosX.Location = New System.Drawing.Point(6, 71)
        Me.numPosX.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numPosX.Minimum = New Decimal(New Integer() {65535, 0, 0, -2147483648})
        Me.numPosX.Name = "numPosX"
        Me.numPosX.Size = New System.Drawing.Size(91, 20)
        Me.numPosX.TabIndex = 2
        Me.numPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numPosZ
        '
        Me.numPosZ.DecimalPlaces = 2
        Me.numPosZ.Location = New System.Drawing.Point(6, 32)
        Me.numPosZ.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numPosZ.Minimum = New Decimal(New Integer() {65535, 0, 0, -2147483648})
        Me.numPosZ.Name = "numPosZ"
        Me.numPosZ.Size = New System.Drawing.Size(91, 20)
        Me.numPosZ.TabIndex = 1
        Me.numPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grpPosition
        '
        Me.grpPosition.Controls.Add(Me.numAltitude)
        Me.grpPosition.Controls.Add(Me.Label5)
        Me.grpPosition.Controls.Add(Me.numPosX)
        Me.grpPosition.Controls.Add(Me.numPosZ)
        Me.grpPosition.Controls.Add(Me.Label4)
        Me.grpPosition.Controls.Add(Me.Label3)
        Me.grpPosition.Location = New System.Drawing.Point(218, 82)
        Me.grpPosition.Name = "grpPosition"
        Me.grpPosition.Size = New System.Drawing.Size(106, 142)
        Me.grpPosition.TabIndex = 22
        Me.grpPosition.TabStop = False
        Me.grpPosition.Text = "Position"
        '
        'numAltitude
        '
        Me.numAltitude.DecimalPlaces = 2
        Me.numAltitude.Location = New System.Drawing.Point(6, 110)
        Me.numAltitude.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.numAltitude.Name = "numAltitude"
        Me.numAltitude.Size = New System.Drawing.Size(91, 20)
        Me.numAltitude.TabIndex = 3
        Me.numAltitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Altitude"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "North / South"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "East / West"
        '
        'btnRemove
        '
        Me.btnRemove.Image = CType(resources.GetObject("btnRemove.Image"), System.Drawing.Image)
        Me.btnRemove.Location = New System.Drawing.Point(330, 230)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(105, 30)
        Me.btnRemove.TabIndex = 19
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'grpSettings
        '
        Me.grpSettings.Controls.Add(Me.btnDefault)
        Me.grpSettings.Controls.Add(Me.cboMaterial)
        Me.grpSettings.Controls.Add(Me.Label2)
        Me.grpSettings.Location = New System.Drawing.Point(218, 12)
        Me.grpSettings.Name = "grpSettings"
        Me.grpSettings.Size = New System.Drawing.Size(217, 64)
        Me.grpSettings.TabIndex = 21
        Me.grpSettings.TabStop = False
        Me.grpSettings.Text = "Settings"
        '
        'cboMaterial
        '
        Me.cboMaterial.FormattingEnabled = True
        Me.cboMaterial.Location = New System.Drawing.Point(6, 32)
        Me.cboMaterial.Name = "cboMaterial"
        Me.cboMaterial.Size = New System.Drawing.Size(143, 21)
        Me.cboMaterial.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Material"
        '
        'lstWater
        '
        Me.lstWater.FormattingEnabled = True
        Me.lstWater.Location = New System.Drawing.Point(6, 19)
        Me.lstWater.Name = "lstWater"
        Me.lstWater.Size = New System.Drawing.Size(188, 225)
        Me.lstWater.TabIndex = 8
        '
        'btnAdd
        '
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(218, 230)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(106, 30)
        Me.btnAdd.TabIndex = 18
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstWater)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 248)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Water Planes"
        '
        'grpScale
        '
        Me.grpScale.Controls.Add(Me.numScaleX)
        Me.grpScale.Controls.Add(Me.numScaleZ)
        Me.grpScale.Controls.Add(Me.Label6)
        Me.grpScale.Controls.Add(Me.Label7)
        Me.grpScale.Location = New System.Drawing.Point(330, 82)
        Me.grpScale.Name = "grpScale"
        Me.grpScale.Size = New System.Drawing.Size(105, 130)
        Me.grpScale.TabIndex = 23
        Me.grpScale.TabStop = False
        Me.grpScale.Text = "Size"
        '
        'numScaleX
        '
        Me.numScaleX.DecimalPlaces = 2
        Me.numScaleX.Location = New System.Drawing.Point(6, 92)
        Me.numScaleX.Maximum = New Decimal(New Integer() {1024, 0, 0, 0})
        Me.numScaleX.Name = "numScaleX"
        Me.numScaleX.Size = New System.Drawing.Size(91, 20)
        Me.numScaleX.TabIndex = 18
        Me.numScaleX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numScaleZ
        '
        Me.numScaleZ.DecimalPlaces = 2
        Me.numScaleZ.Location = New System.Drawing.Point(6, 46)
        Me.numScaleZ.Maximum = New Decimal(New Integer() {1024, 0, 0, 0})
        Me.numScaleZ.Name = "numScaleZ"
        Me.numScaleZ.Size = New System.Drawing.Size(91, 20)
        Me.numScaleZ.TabIndex = 17
        Me.numScaleZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Width"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Lenght"
        '
        'btnDefault
        '
        Me.btnDefault.Location = New System.Drawing.Point(155, 19)
        Me.btnDefault.Name = "btnDefault"
        Me.btnDefault.Size = New System.Drawing.Size(56, 36)
        Me.btnDefault.TabIndex = 6
        Me.btnDefault.Text = "Default"
        Me.btnDefault.UseVisualStyleBackColor = True
        '
        'fWater
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 276)
        Me.Controls.Add(Me.grpScale)
        Me.Controls.Add(Me.grpPosition)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.grpSettings)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fWater"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Water Planes"
        CType(Me.numPosX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPosZ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPosition.ResumeLayout(False)
        Me.grpPosition.PerformLayout()
        CType(Me.numAltitude, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSettings.ResumeLayout(False)
        Me.grpSettings.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.grpScale.ResumeLayout(False)
        Me.grpScale.PerformLayout()
        CType(Me.numScaleX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScaleZ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents numPosX As System.Windows.Forms.NumericUpDown
    Friend WithEvents numPosZ As System.Windows.Forms.NumericUpDown
    Friend WithEvents grpPosition As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents numAltitude As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents grpSettings As System.Windows.Forms.GroupBox
    Friend WithEvents cboMaterial As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lstWater As System.Windows.Forms.ListBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grpScale As System.Windows.Forms.GroupBox
    Friend WithEvents numScaleX As System.Windows.Forms.NumericUpDown
    Friend WithEvents numScaleZ As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnDefault As System.Windows.Forms.Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fLights
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fLights))
        Me.grpDirection = New System.Windows.Forms.GroupBox
        Me.numDirZ = New System.Windows.Forms.NumericUpDown
        Me.numDirY = New System.Windows.Forms.NumericUpDown
        Me.numDirX = New System.Windows.Forms.NumericUpDown
        Me.btnImport = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.grpColors = New System.Windows.Forms.GroupBox
        Me.picSpecular = New System.Windows.Forms.PictureBox
        Me.picDiffuse = New System.Windows.Forms.PictureBox
        Me.picAmbient = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lstLights = New System.Windows.Forms.ListBox
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnDel = New System.Windows.Forms.Button
        Me.grpPosition = New System.Windows.Forms.GroupBox
        Me.numPosZ = New System.Windows.Forms.NumericUpDown
        Me.numPosY = New System.Windows.Forms.NumericUpDown
        Me.numPosX = New System.Windows.Forms.NumericUpDown
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.grpSettings = New System.Windows.Forms.GroupBox
        Me.numDistance = New System.Windows.Forms.NumericUpDown
        Me.cbType = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.grpDirection.SuspendLayout()
        CType(Me.numDirZ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDirY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDirX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpColors.SuspendLayout()
        CType(Me.picSpecular, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDiffuse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAmbient, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.grpPosition.SuspendLayout()
        CType(Me.numPosZ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPosY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPosX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSettings.SuspendLayout()
        CType(Me.numDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDirection
        '
        Me.grpDirection.Controls.Add(Me.numDirZ)
        Me.grpDirection.Controls.Add(Me.numDirY)
        Me.grpDirection.Controls.Add(Me.numDirX)
        Me.grpDirection.Controls.Add(Me.btnImport)
        Me.grpDirection.Controls.Add(Me.Label11)
        Me.grpDirection.Controls.Add(Me.Label10)
        Me.grpDirection.Controls.Add(Me.Label9)
        Me.grpDirection.Location = New System.Drawing.Point(218, 170)
        Me.grpDirection.Name = "grpDirection"
        Me.grpDirection.Size = New System.Drawing.Size(200, 104)
        Me.grpDirection.TabIndex = 42
        Me.grpDirection.TabStop = False
        Me.grpDirection.Text = "Direction"
        '
        'numDirZ
        '
        Me.numDirZ.DecimalPlaces = 2
        Me.numDirZ.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numDirZ.Location = New System.Drawing.Point(135, 43)
        Me.numDirZ.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numDirZ.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.numDirZ.Name = "numDirZ"
        Me.numDirZ.Size = New System.Drawing.Size(56, 20)
        Me.numDirZ.TabIndex = 5
        Me.numDirZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numDirY
        '
        Me.numDirY.DecimalPlaces = 2
        Me.numDirY.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numDirY.Location = New System.Drawing.Point(71, 43)
        Me.numDirY.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numDirY.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.numDirY.Name = "numDirY"
        Me.numDirY.Size = New System.Drawing.Size(56, 20)
        Me.numDirY.TabIndex = 4
        Me.numDirY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numDirX
        '
        Me.numDirX.DecimalPlaces = 2
        Me.numDirX.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numDirX.Location = New System.Drawing.Point(7, 43)
        Me.numDirX.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numDirX.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.numDirX.Name = "numDirX"
        Me.numDirX.Size = New System.Drawing.Size(56, 20)
        Me.numDirX.TabIndex = 3
        Me.numDirX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(6, 69)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(184, 24)
        Me.btnImport.TabIndex = 38
        Me.btnImport.Text = "Import direction from camera"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(7, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 23)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "X"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(71, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 23)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Y"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(135, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 23)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Z"
        '
        'grpColors
        '
        Me.grpColors.Controls.Add(Me.picSpecular)
        Me.grpColors.Controls.Add(Me.picDiffuse)
        Me.grpColors.Controls.Add(Me.picAmbient)
        Me.grpColors.Controls.Add(Me.Label2)
        Me.grpColors.Controls.Add(Me.Label6)
        Me.grpColors.Controls.Add(Me.Label7)
        Me.grpColors.Location = New System.Drawing.Point(12, 170)
        Me.grpColors.Name = "grpColors"
        Me.grpColors.Size = New System.Drawing.Size(200, 104)
        Me.grpColors.TabIndex = 41
        Me.grpColors.TabStop = False
        Me.grpColors.Text = "Colors"
        '
        'picSpecular
        '
        Me.picSpecular.BackColor = System.Drawing.Color.White
        Me.picSpecular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picSpecular.Location = New System.Drawing.Point(136, 40)
        Me.picSpecular.Name = "picSpecular"
        Me.picSpecular.Size = New System.Drawing.Size(56, 56)
        Me.picSpecular.TabIndex = 6
        Me.picSpecular.TabStop = False
        '
        'picDiffuse
        '
        Me.picDiffuse.BackColor = System.Drawing.Color.White
        Me.picDiffuse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picDiffuse.Location = New System.Drawing.Point(72, 40)
        Me.picDiffuse.Name = "picDiffuse"
        Me.picDiffuse.Size = New System.Drawing.Size(56, 56)
        Me.picDiffuse.TabIndex = 4
        Me.picDiffuse.TabStop = False
        '
        'picAmbient
        '
        Me.picAmbient.BackColor = System.Drawing.Color.White
        Me.picAmbient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picAmbient.Location = New System.Drawing.Point(8, 40)
        Me.picAmbient.Name = "picAmbient"
        Me.picAmbient.Size = New System.Drawing.Size(56, 56)
        Me.picAmbient.TabIndex = 1
        Me.picAmbient.TabStop = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ambient"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(72, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 23)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Diffuse"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(136, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 23)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Specular"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstLights)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.btnDel)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 152)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lights"
        '
        'lstLights
        '
        Me.lstLights.Location = New System.Drawing.Point(8, 16)
        Me.lstLights.Name = "lstLights"
        Me.lstLights.Size = New System.Drawing.Size(184, 95)
        Me.lstLights.TabIndex = 29
        '
        'btnAdd
        '
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(8, 120)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(89, 24)
        Me.btnAdd.TabIndex = 30
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'btnDel
        '
        Me.btnDel.Image = CType(resources.GetObject("btnDel.Image"), System.Drawing.Image)
        Me.btnDel.Location = New System.Drawing.Point(103, 120)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(89, 24)
        Me.btnDel.TabIndex = 31
        Me.btnDel.Text = "Remove"
        Me.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'grpPosition
        '
        Me.grpPosition.Controls.Add(Me.numPosZ)
        Me.grpPosition.Controls.Add(Me.numPosY)
        Me.grpPosition.Controls.Add(Me.numPosX)
        Me.grpPosition.Controls.Add(Me.Label5)
        Me.grpPosition.Controls.Add(Me.Label4)
        Me.grpPosition.Controls.Add(Me.Label3)
        Me.grpPosition.Location = New System.Drawing.Point(218, 90)
        Me.grpPosition.Name = "grpPosition"
        Me.grpPosition.Size = New System.Drawing.Size(200, 74)
        Me.grpPosition.TabIndex = 39
        Me.grpPosition.TabStop = False
        Me.grpPosition.Text = "Position"
        '
        'numPosZ
        '
        Me.numPosZ.Location = New System.Drawing.Point(133, 35)
        Me.numPosZ.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numPosZ.Minimum = New Decimal(New Integer() {65535, 0, 0, -2147483648})
        Me.numPosZ.Name = "numPosZ"
        Me.numPosZ.Size = New System.Drawing.Size(56, 20)
        Me.numPosZ.TabIndex = 5
        Me.numPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numPosY
        '
        Me.numPosY.Location = New System.Drawing.Point(71, 35)
        Me.numPosY.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numPosY.Minimum = New Decimal(New Integer() {65535, 0, 0, -2147483648})
        Me.numPosY.Name = "numPosY"
        Me.numPosY.Size = New System.Drawing.Size(56, 20)
        Me.numPosY.TabIndex = 4
        Me.numPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numPosX
        '
        Me.numPosX.Location = New System.Drawing.Point(9, 35)
        Me.numPosX.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numPosX.Minimum = New Decimal(New Integer() {65535, 0, 0, -2147483648})
        Me.numPosX.Name = "numPosX"
        Me.numPosX.Size = New System.Drawing.Size(56, 20)
        Me.numPosX.TabIndex = 3
        Me.numPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(130, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Z"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(71, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Y"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "X"
        '
        'grpSettings
        '
        Me.grpSettings.Controls.Add(Me.numDistance)
        Me.grpSettings.Controls.Add(Me.cbType)
        Me.grpSettings.Controls.Add(Me.Label1)
        Me.grpSettings.Controls.Add(Me.Label8)
        Me.grpSettings.Location = New System.Drawing.Point(218, 12)
        Me.grpSettings.Name = "grpSettings"
        Me.grpSettings.Size = New System.Drawing.Size(200, 72)
        Me.grpSettings.TabIndex = 38
        Me.grpSettings.TabStop = False
        Me.grpSettings.Text = "Settings"
        '
        'numDistance
        '
        Me.numDistance.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numDistance.Location = New System.Drawing.Point(119, 35)
        Me.numDistance.Maximum = New Decimal(New Integer() {4000, 0, 0, 0})
        Me.numDistance.Name = "numDistance"
        Me.numDistance.Size = New System.Drawing.Size(72, 20)
        Me.numDistance.TabIndex = 3
        Me.numDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbType
        '
        Me.cbType.Items.AddRange(New Object() {"Directional", "Point", "Spot"})
        Me.cbType.Location = New System.Drawing.Point(9, 35)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(104, 21)
        Me.cbType.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Type"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(116, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 23)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Range"
        '
        'fLights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 287)
        Me.Controls.Add(Me.grpDirection)
        Me.Controls.Add(Me.grpColors)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpPosition)
        Me.Controls.Add(Me.grpSettings)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fLights"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lights"
        Me.grpDirection.ResumeLayout(False)
        CType(Me.numDirZ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDirY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDirX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpColors.ResumeLayout(False)
        CType(Me.picSpecular, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDiffuse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAmbient, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.grpPosition.ResumeLayout(False)
        Me.grpPosition.PerformLayout()
        CType(Me.numPosZ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPosY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPosX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSettings.ResumeLayout(False)
        CType(Me.numDistance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpDirection As System.Windows.Forms.GroupBox
    Friend WithEvents numDirZ As System.Windows.Forms.NumericUpDown
    Friend WithEvents numDirY As System.Windows.Forms.NumericUpDown
    Friend WithEvents numDirX As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents grpColors As System.Windows.Forms.GroupBox
    Friend WithEvents picSpecular As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents picDiffuse As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents picAmbient As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstLights As System.Windows.Forms.ListBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents grpPosition As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents numPosZ As System.Windows.Forms.NumericUpDown
    Friend WithEvents numPosY As System.Windows.Forms.NumericUpDown
    Friend WithEvents numPosX As System.Windows.Forms.NumericUpDown
    Friend WithEvents grpSettings As System.Windows.Forms.GroupBox
    Friend WithEvents numDistance As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fMaterials
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fMaterials))
        Me.numPower = New System.Windows.Forms.NumericUpDown
        Me.numOpacity = New System.Windows.Forms.NumericUpDown
        Me.btnAdd = New System.Windows.Forms.Button
        Me.lstMaterials = New System.Windows.Forms.ListBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnDel = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.grpSettings = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.picSpecular = New System.Windows.Forms.PictureBox
        Me.grpColors = New System.Windows.Forms.GroupBox
        Me.picEmissive = New System.Windows.Forms.PictureBox
        Me.picDiffuse = New System.Windows.Forms.PictureBox
        Me.picAmbient = New System.Windows.Forms.PictureBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        CType(Me.numPower, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSettings.SuspendLayout()
        CType(Me.picSpecular, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpColors.SuspendLayout()
        CType(Me.picEmissive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDiffuse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAmbient, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'numPower
        '
        Me.numPower.DecimalPlaces = 2
        Me.numPower.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numPower.Location = New System.Drawing.Point(112, 34)
        Me.numPower.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numPower.Name = "numPower"
        Me.numPower.Size = New System.Drawing.Size(72, 20)
        Me.numPower.TabIndex = 3
        Me.numPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numOpacity
        '
        Me.numOpacity.DecimalPlaces = 2
        Me.numOpacity.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numOpacity.Location = New System.Drawing.Point(25, 34)
        Me.numOpacity.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numOpacity.Name = "numOpacity"
        Me.numOpacity.Size = New System.Drawing.Size(72, 20)
        Me.numOpacity.TabIndex = 2
        Me.numOpacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAdd
        '
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(8, 120)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(80, 24)
        Me.btnAdd.TabIndex = 30
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'lstMaterials
        '
        Me.lstMaterials.Location = New System.Drawing.Point(8, 16)
        Me.lstMaterials.Name = "lstMaterials"
        Me.lstMaterials.Size = New System.Drawing.Size(194, 95)
        Me.lstMaterials.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(22, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 23)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Opacity"
        '
        'btnDel
        '
        Me.btnDel.Image = CType(resources.GetObject("btnDel.Image"), System.Drawing.Image)
        Me.btnDel.Location = New System.Drawing.Point(118, 120)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(80, 24)
        Me.btnDel.TabIndex = 31
        Me.btnDel.Text = "Remove"
        Me.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(109, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 24)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Power"
        '
        'grpSettings
        '
        Me.grpSettings.Controls.Add(Me.numPower)
        Me.grpSettings.Controls.Add(Me.numOpacity)
        Me.grpSettings.Controls.Add(Me.Label3)
        Me.grpSettings.Controls.Add(Me.Label4)
        Me.grpSettings.Location = New System.Drawing.Point(12, 170)
        Me.grpSettings.Name = "grpSettings"
        Me.grpSettings.Size = New System.Drawing.Size(208, 70)
        Me.grpSettings.TabIndex = 42
        Me.grpSettings.TabStop = False
        Me.grpSettings.Text = "Settings"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(5, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ambient"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(152, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 23)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Emissive"
        '
        'picSpecular
        '
        Me.picSpecular.BackColor = System.Drawing.Color.White
        Me.picSpecular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picSpecular.Location = New System.Drawing.Point(106, 40)
        Me.picSpecular.Name = "picSpecular"
        Me.picSpecular.Size = New System.Drawing.Size(43, 43)
        Me.picSpecular.TabIndex = 6
        Me.picSpecular.TabStop = False
        '
        'grpColors
        '
        Me.grpColors.Controls.Add(Me.picEmissive)
        Me.grpColors.Controls.Add(Me.Label1)
        Me.grpColors.Controls.Add(Me.picSpecular)
        Me.grpColors.Controls.Add(Me.picDiffuse)
        Me.grpColors.Controls.Add(Me.picAmbient)
        Me.grpColors.Controls.Add(Me.Label2)
        Me.grpColors.Controls.Add(Me.Label6)
        Me.grpColors.Controls.Add(Me.Label7)
        Me.grpColors.Location = New System.Drawing.Point(12, 246)
        Me.grpColors.Name = "grpColors"
        Me.grpColors.Size = New System.Drawing.Size(208, 92)
        Me.grpColors.TabIndex = 41
        Me.grpColors.TabStop = False
        Me.grpColors.Text = "Colors"
        '
        'picEmissive
        '
        Me.picEmissive.BackColor = System.Drawing.Color.White
        Me.picEmissive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picEmissive.Location = New System.Drawing.Point(155, 40)
        Me.picEmissive.Name = "picEmissive"
        Me.picEmissive.Size = New System.Drawing.Size(43, 43)
        Me.picEmissive.TabIndex = 8
        Me.picEmissive.TabStop = False
        '
        'picDiffuse
        '
        Me.picDiffuse.BackColor = System.Drawing.Color.White
        Me.picDiffuse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picDiffuse.Location = New System.Drawing.Point(57, 40)
        Me.picDiffuse.Name = "picDiffuse"
        Me.picDiffuse.Size = New System.Drawing.Size(43, 43)
        Me.picDiffuse.TabIndex = 4
        Me.picDiffuse.TabStop = False
        '
        'picAmbient
        '
        Me.picAmbient.BackColor = System.Drawing.Color.White
        Me.picAmbient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picAmbient.Location = New System.Drawing.Point(8, 40)
        Me.picAmbient.Name = "picAmbient"
        Me.picAmbient.Size = New System.Drawing.Size(43, 43)
        Me.picAmbient.TabIndex = 1
        Me.picAmbient.TabStop = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(54, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 23)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Diffuse"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(103, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 23)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Specular"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstMaterials)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.btnDel)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(208, 152)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Materials"
        '
        'fMaterials
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(233, 352)
        Me.Controls.Add(Me.grpSettings)
        Me.Controls.Add(Me.grpColors)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fMaterials"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Materials"
        CType(Me.numPower, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numOpacity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSettings.ResumeLayout(False)
        CType(Me.picSpecular, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpColors.ResumeLayout(False)
        CType(Me.picEmissive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDiffuse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAmbient, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents numPower As System.Windows.Forms.NumericUpDown
    Friend WithEvents numOpacity As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lstMaterials As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grpSettings As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picSpecular As System.Windows.Forms.PictureBox
    Friend WithEvents grpColors As System.Windows.Forms.GroupBox
    Friend WithEvents picEmissive As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents picDiffuse As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents picAmbient As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class

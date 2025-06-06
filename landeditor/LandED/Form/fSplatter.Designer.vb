<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fSplatter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fSplatter))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lstLandscapes = New System.Windows.Forms.ListBox
        Me.grpLayers = New System.Windows.Forms.GroupBox
        Me.lstLayers = New System.Windows.Forms.ListBox
        Me.btnMoveDown = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnDel = New System.Windows.Forms.Button
        Me.btnMoveUp = New System.Windows.Forms.Button
        Me.picTexture = New System.Windows.Forms.PictureBox
        Me.picAlpha = New System.Windows.Forms.PictureBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnExportAlpha = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.grpLayers.SuspendLayout()
        CType(Me.picTexture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAlpha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstLandscapes)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(176, 249)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "landscapes"
        '
        'lstLandscapes
        '
        Me.lstLandscapes.FormattingEnabled = True
        Me.lstLandscapes.Location = New System.Drawing.Point(6, 19)
        Me.lstLandscapes.Name = "lstLandscapes"
        Me.lstLandscapes.Size = New System.Drawing.Size(164, 225)
        Me.lstLandscapes.TabIndex = 1
        '
        'grpLayers
        '
        Me.grpLayers.Controls.Add(Me.lstLayers)
        Me.grpLayers.Controls.Add(Me.btnMoveDown)
        Me.grpLayers.Controls.Add(Me.btnAdd)
        Me.grpLayers.Controls.Add(Me.btnDel)
        Me.grpLayers.Controls.Add(Me.btnMoveUp)
        Me.grpLayers.Location = New System.Drawing.Point(194, 12)
        Me.grpLayers.Name = "grpLayers"
        Me.grpLayers.Size = New System.Drawing.Size(214, 249)
        Me.grpLayers.TabIndex = 46
        Me.grpLayers.TabStop = False
        Me.grpLayers.Text = "Layers"
        '
        'lstLayers
        '
        Me.lstLayers.Location = New System.Drawing.Point(6, 19)
        Me.lstLayers.Name = "lstLayers"
        Me.lstLayers.Size = New System.Drawing.Size(164, 186)
        Me.lstLayers.TabIndex = 29
        '
        'btnMoveDown
        '
        Me.btnMoveDown.Image = CType(resources.GetObject("btnMoveDown.Image"), System.Drawing.Image)
        Me.btnMoveDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMoveDown.Location = New System.Drawing.Point(176, 176)
        Me.btnMoveDown.Name = "btnMoveDown"
        Me.btnMoveDown.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnMoveDown.Size = New System.Drawing.Size(29, 29)
        Me.btnMoveDown.TabIndex = 55
        Me.btnMoveDown.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(6, 211)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(79, 32)
        Me.btnAdd.TabIndex = 30
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'btnDel
        '
        Me.btnDel.Image = CType(resources.GetObject("btnDel.Image"), System.Drawing.Image)
        Me.btnDel.Location = New System.Drawing.Point(91, 211)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(79, 32)
        Me.btnDel.TabIndex = 31
        Me.btnDel.Text = "Remove"
        Me.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'btnMoveUp
        '
        Me.btnMoveUp.Image = CType(resources.GetObject("btnMoveUp.Image"), System.Drawing.Image)
        Me.btnMoveUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMoveUp.Location = New System.Drawing.Point(176, 19)
        Me.btnMoveUp.Name = "btnMoveUp"
        Me.btnMoveUp.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnMoveUp.Size = New System.Drawing.Size(29, 29)
        Me.btnMoveUp.TabIndex = 54
        Me.btnMoveUp.UseVisualStyleBackColor = True
        '
        'picTexture
        '
        Me.picTexture.BackColor = System.Drawing.Color.White
        Me.picTexture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picTexture.Location = New System.Drawing.Point(6, 19)
        Me.picTexture.Name = "picTexture"
        Me.picTexture.Size = New System.Drawing.Size(72, 72)
        Me.picTexture.TabIndex = 1
        Me.picTexture.TabStop = False
        '
        'picAlpha
        '
        Me.picAlpha.BackColor = System.Drawing.Color.White
        Me.picAlpha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picAlpha.Location = New System.Drawing.Point(6, 19)
        Me.picAlpha.Name = "picAlpha"
        Me.picAlpha.Size = New System.Drawing.Size(72, 72)
        Me.picAlpha.TabIndex = 1
        Me.picAlpha.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.picTexture)
        Me.GroupBox2.Location = New System.Drawing.Point(414, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(84, 98)
        Me.GroupBox2.TabIndex = 52
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Texture"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnExportAlpha)
        Me.GroupBox3.Controls.Add(Me.picAlpha)
        Me.GroupBox3.Location = New System.Drawing.Point(414, 116)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(84, 145)
        Me.GroupBox3.TabIndex = 53
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Alpha"
        '
        'btnExportAlpha
        '
        Me.btnExportAlpha.Image = CType(resources.GetObject("btnExportAlpha.Image"), System.Drawing.Image)
        Me.btnExportAlpha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportAlpha.Location = New System.Drawing.Point(6, 97)
        Me.btnExportAlpha.Name = "btnExportAlpha"
        Me.btnExportAlpha.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnExportAlpha.Size = New System.Drawing.Size(72, 42)
        Me.btnExportAlpha.TabIndex = 57
        Me.btnExportAlpha.Text = "Export Alpha"
        Me.btnExportAlpha.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExportAlpha.UseVisualStyleBackColor = True
        '
        'fSplatter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 276)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grpLayers)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fSplatter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "landscape Texture Layers"
        Me.GroupBox1.ResumeLayout(False)
        Me.grpLayers.ResumeLayout(False)
        CType(Me.picTexture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAlpha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstLandscapes As System.Windows.Forms.ListBox
    Friend WithEvents grpLayers As System.Windows.Forms.GroupBox
    Friend WithEvents lstLayers As System.Windows.Forms.ListBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents picTexture As System.Windows.Forms.PictureBox
    Friend WithEvents picAlpha As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnMoveUp As System.Windows.Forms.Button
    Friend WithEvents btnMoveDown As System.Windows.Forms.Button
    Friend WithEvents btnExportAlpha As System.Windows.Forms.Button
End Class

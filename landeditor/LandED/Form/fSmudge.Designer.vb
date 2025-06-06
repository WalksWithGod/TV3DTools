<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fSmudge
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fSmudge))
        Me.btnAB = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.numStrength = New System.Windows.Forms.NumericUpDown
        Me.cboB = New System.Windows.Forms.ComboBox
        Me.cboA = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.numStrength, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAB
        '
        Me.btnAB.Location = New System.Drawing.Point(12, 160)
        Me.btnAB.Name = "btnAB"
        Me.btnAB.Size = New System.Drawing.Size(151, 24)
        Me.btnAB.TabIndex = 38
        Me.btnAB.Text = "Smudge Land A on Land B"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.numStrength)
        Me.GroupBox1.Controls.Add(Me.cboB)
        Me.GroupBox1.Controls.Add(Me.cboA)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(151, 142)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Settings"
        '
        'numStrength
        '
        Me.numStrength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numStrength.Location = New System.Drawing.Point(6, 112)
        Me.numStrength.Maximum = New Decimal(New Integer() {32, 0, 0, 0})
        Me.numStrength.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numStrength.Name = "numStrength"
        Me.numStrength.Size = New System.Drawing.Size(56, 20)
        Me.numStrength.TabIndex = 26
        Me.numStrength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numStrength.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cboB
        '
        Me.cboB.Enabled = False
        Me.cboB.Location = New System.Drawing.Point(6, 72)
        Me.cboB.Name = "cboB"
        Me.cboB.Size = New System.Drawing.Size(136, 21)
        Me.cboB.TabIndex = 33
        '
        'cboA
        '
        Me.cboA.Location = New System.Drawing.Point(6, 32)
        Me.cboA.Name = "cboA"
        Me.cboA.Size = New System.Drawing.Size(136, 21)
        Me.cboA.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Landscape A"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Landscape B"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Smudge Strength"
        '
        'fSmudge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(176, 196)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnAB)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fSmudge"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Smudge Altitudes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numStrength, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAB As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboB As System.Windows.Forms.ComboBox
    Friend WithEvents cboA As System.Windows.Forms.ComboBox
    Friend WithEvents numStrength As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

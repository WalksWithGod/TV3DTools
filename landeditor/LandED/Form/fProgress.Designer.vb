<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fProgress
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
        Me.proBar = New System.Windows.Forms.ProgressBar
        Me.lblDebug = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'proBar
        '
        Me.proBar.Location = New System.Drawing.Point(12, 12)
        Me.proBar.Maximum = 1
        Me.proBar.Name = "proBar"
        Me.proBar.Size = New System.Drawing.Size(270, 34)
        Me.proBar.Step = 1
        Me.proBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.proBar.TabIndex = 0
        Me.proBar.Value = 1
        '
        'lblDebug
        '
        Me.lblDebug.AutoSize = True
        Me.lblDebug.Location = New System.Drawing.Point(12, 58)
        Me.lblDebug.Name = "lblDebug"
        Me.lblDebug.Size = New System.Drawing.Size(0, 13)
        Me.lblDebug.TabIndex = 1
        '
        'fProgress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(294, 58)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblDebug)
        Me.Controls.Add(Me.proBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "fProgress"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Progress"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents proBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDebug As System.Windows.Forms.Label
End Class

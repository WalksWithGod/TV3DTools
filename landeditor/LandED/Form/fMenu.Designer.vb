<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fMenu))
        Me.btnOpenProject = New System.Windows.Forms.Button
        Me.btnNewProject = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lstProjects = New System.Windows.Forms.ListBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOpenProject
        '
        Me.btnOpenProject.Image = CType(resources.GetObject("btnOpenProject.Image"), System.Drawing.Image)
        Me.btnOpenProject.Location = New System.Drawing.Point(121, 230)
        Me.btnOpenProject.Name = "btnOpenProject"
        Me.btnOpenProject.Size = New System.Drawing.Size(100, 30)
        Me.btnOpenProject.TabIndex = 8
        Me.btnOpenProject.Text = "Open Project"
        Me.btnOpenProject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOpenProject.UseVisualStyleBackColor = True
        '
        'btnNewProject
        '
        Me.btnNewProject.Image = CType(resources.GetObject("btnNewProject.Image"), System.Drawing.Image)
        Me.btnNewProject.Location = New System.Drawing.Point(12, 230)
        Me.btnNewProject.Name = "btnNewProject"
        Me.btnNewProject.Size = New System.Drawing.Size(100, 30)
        Me.btnNewProject.TabIndex = 7
        Me.btnNewProject.Text = "New Project"
        Me.btnNewProject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNewProject.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Location = New System.Drawing.Point(227, 230)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(100, 30)
        Me.btnDelete.TabIndex = 9
        Me.btnDelete.Text = "Delete Project"
        Me.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstProjects)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(315, 212)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Project List"
        '
        'lstProjects
        '
        Me.lstProjects.FormattingEnabled = True
        Me.lstProjects.Location = New System.Drawing.Point(6, 19)
        Me.lstProjects.Name = "lstProjects"
        Me.lstProjects.Size = New System.Drawing.Size(303, 186)
        Me.lstProjects.TabIndex = 0
        '
        'fMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(343, 271)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnOpenProject)
        Me.Controls.Add(Me.btnNewProject)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Project Management"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOpenProject As System.Windows.Forms.Button
    Friend WithEvents btnNewProject As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstProjects As System.Windows.Forms.ListBox
End Class

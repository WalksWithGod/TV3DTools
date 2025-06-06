<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fRender
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fRender))
        Me.picRender = New System.Windows.Forms.PictureBox
        Me.toolMain = New System.Windows.Forms.ToolStrip
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnAltitude = New System.Windows.Forms.ToolStripButton
        Me.btnRender = New System.Windows.Forms.ToolStripButton
        Me.btnWalk = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.btnlandscapes = New System.Windows.Forms.ToolStripButton
        Me.btnWater = New System.Windows.Forms.ToolStripButton
        Me.btnMaterials = New System.Windows.Forms.ToolStripButton
        Me.btnLights = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.btnSplatter = New System.Windows.Forms.ToolStripButton
        Me.btnAlpha = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnSelect = New System.Windows.Forms.ToolStripButton
        Me.btnPaint = New System.Windows.Forms.ToolStripButton
        Me.btnSmudge = New System.Windows.Forms.ToolStripButton
        Me.btnManual = New System.Windows.Forms.ToolStripButton
        Me.btnFlatten = New System.Windows.Forms.ToolStripButton
        Me.btnSmooth = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.btnRaise = New System.Windows.Forms.ToolStripButton
        Me.btnLower = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.btnSquare = New System.Windows.Forms.ToolStripButton
        Me.btnCircle = New System.Windows.Forms.ToolStripButton
        Me.btnLineNS = New System.Windows.Forms.ToolStripButton
        Me.btnLineWE = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnSingle = New System.Windows.Forms.ToolStripButton
        Me.btnSmall = New System.Windows.Forms.ToolStripButton
        Me.btnMedium = New System.Windows.Forms.ToolStripButton
        Me.btnLarge = New System.Windows.Forms.ToolStripButton
        Me.splitRender = New System.Windows.Forms.SplitContainer
        Me.grpAltitude = New System.Windows.Forms.GroupBox
        Me.numAltitude = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.grpPaint = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.trkAlpha = New System.Windows.Forms.TrackBar
        Me.lstLandscapes = New System.Windows.Forms.ListBox
        Me.lstLayers = New System.Windows.Forms.ListBox
        Me.grpSpeed = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.trkStep = New System.Windows.Forms.TrackBar
        CType(Me.picRender, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolMain.SuspendLayout()
        Me.splitRender.Panel1.SuspendLayout()
        Me.splitRender.Panel2.SuspendLayout()
        Me.splitRender.SuspendLayout()
        Me.grpAltitude.SuspendLayout()
        CType(Me.numAltitude, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPaint.SuspendLayout()
        CType(Me.trkAlpha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSpeed.SuspendLayout()
        CType(Me.trkStep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picRender
        '
        Me.picRender.BackColor = System.Drawing.Color.Black
        Me.picRender.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picRender.InitialImage = CType(resources.GetObject("picRender.InitialImage"), System.Drawing.Image)
        Me.picRender.Location = New System.Drawing.Point(0, 0)
        Me.picRender.Name = "picRender"
        Me.picRender.Size = New System.Drawing.Size(292, 529)
        Me.picRender.TabIndex = 0
        Me.picRender.TabStop = False
        '
        'toolMain
        '
        Me.toolMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.ToolStripSeparator2, Me.btnAltitude, Me.btnRender, Me.btnWalk, Me.ToolStripSeparator5, Me.btnlandscapes, Me.btnWater, Me.btnMaterials, Me.btnLights, Me.ToolStripSeparator4, Me.btnSplatter, Me.btnAlpha, Me.ToolStripButton2, Me.btnSelect, Me.btnPaint, Me.btnSmudge, Me.btnManual, Me.btnFlatten, Me.btnSmooth, Me.ToolStripSeparator6, Me.btnRaise, Me.btnLower, Me.ToolStripSeparator8, Me.btnSquare, Me.btnCircle, Me.btnLineNS, Me.btnLineWE, Me.ToolStripSeparator1, Me.btnSingle, Me.btnSmall, Me.btnMedium, Me.btnLarge})
        Me.toolMain.Location = New System.Drawing.Point(0, 0)
        Me.toolMain.Name = "toolMain"
        Me.toolMain.Size = New System.Drawing.Size(802, 25)
        Me.toolMain.TabIndex = 2
        '
        'btnSave
        '
        Me.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(23, 22)
        Me.btnSave.Text = "Save Project"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnAltitude
        '
        Me.btnAltitude.Checked = True
        Me.btnAltitude.CheckOnClick = True
        Me.btnAltitude.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnAltitude.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAltitude.Image = CType(resources.GetObject("btnAltitude.Image"), System.Drawing.Image)
        Me.btnAltitude.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAltitude.Name = "btnAltitude"
        Me.btnAltitude.Size = New System.Drawing.Size(23, 22)
        Me.btnAltitude.Text = "Show Altitude"
        '
        'btnRender
        '
        Me.btnRender.Checked = True
        Me.btnRender.CheckOnClick = True
        Me.btnRender.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnRender.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRender.Image = CType(resources.GetObject("btnRender.Image"), System.Drawing.Image)
        Me.btnRender.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRender.Name = "btnRender"
        Me.btnRender.Size = New System.Drawing.Size(23, 22)
        Me.btnRender.Text = "Render Mode"
        '
        'btnWalk
        '
        Me.btnWalk.CheckOnClick = True
        Me.btnWalk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnWalk.Image = CType(resources.GetObject("btnWalk.Image"), System.Drawing.Image)
        Me.btnWalk.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnWalk.Name = "btnWalk"
        Me.btnWalk.Size = New System.Drawing.Size(23, 22)
        Me.btnWalk.Text = "Walk Mode"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'btnlandscapes
        '
        Me.btnlandscapes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnlandscapes.Image = CType(resources.GetObject("btnlandscapes.Image"), System.Drawing.Image)
        Me.btnlandscapes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnlandscapes.Name = "btnlandscapes"
        Me.btnlandscapes.Size = New System.Drawing.Size(23, 22)
        Me.btnlandscapes.Text = "Landscapes"
        '
        'btnWater
        '
        Me.btnWater.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnWater.Image = CType(resources.GetObject("btnWater.Image"), System.Drawing.Image)
        Me.btnWater.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnWater.Name = "btnWater"
        Me.btnWater.Size = New System.Drawing.Size(23, 22)
        Me.btnWater.Text = "Water"
        '
        'btnMaterials
        '
        Me.btnMaterials.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnMaterials.Image = CType(resources.GetObject("btnMaterials.Image"), System.Drawing.Image)
        Me.btnMaterials.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMaterials.Name = "btnMaterials"
        Me.btnMaterials.Size = New System.Drawing.Size(23, 22)
        Me.btnMaterials.Text = "Materials"
        '
        'btnLights
        '
        Me.btnLights.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLights.Image = CType(resources.GetObject("btnLights.Image"), System.Drawing.Image)
        Me.btnLights.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLights.Name = "btnLights"
        Me.btnLights.Size = New System.Drawing.Size(23, 22)
        Me.btnLights.Text = "Lights"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'btnSplatter
        '
        Me.btnSplatter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSplatter.Image = CType(resources.GetObject("btnSplatter.Image"), System.Drawing.Image)
        Me.btnSplatter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSplatter.Name = "btnSplatter"
        Me.btnSplatter.Size = New System.Drawing.Size(23, 22)
        Me.btnSplatter.Text = "Textures Layers"
        '
        'btnAlpha
        '
        Me.btnAlpha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAlpha.Image = CType(resources.GetObject("btnAlpha.Image"), System.Drawing.Image)
        Me.btnAlpha.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAlpha.Name = "btnAlpha"
        Me.btnAlpha.Size = New System.Drawing.Size(23, 22)
        Me.btnAlpha.Text = "Generate Alpha Layer"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(6, 25)
        '
        'btnSelect
        '
        Me.btnSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSelect.Image = CType(resources.GetObject("btnSelect.Image"), System.Drawing.Image)
        Me.btnSelect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(23, 22)
        Me.btnSelect.Text = "Select"
        '
        'btnPaint
        '
        Me.btnPaint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPaint.Image = CType(resources.GetObject("btnPaint.Image"), System.Drawing.Image)
        Me.btnPaint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPaint.Name = "btnPaint"
        Me.btnPaint.Size = New System.Drawing.Size(23, 22)
        Me.btnPaint.Text = "Paint on Ground"
        '
        'btnSmudge
        '
        Me.btnSmudge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSmudge.Image = CType(resources.GetObject("btnSmudge.Image"), System.Drawing.Image)
        Me.btnSmudge.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSmudge.Name = "btnSmudge"
        Me.btnSmudge.Size = New System.Drawing.Size(23, 22)
        Me.btnSmudge.Text = "Smudge Altitudes"
        '
        'btnManual
        '
        Me.btnManual.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnManual.Image = CType(resources.GetObject("btnManual.Image"), System.Drawing.Image)
        Me.btnManual.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnManual.Name = "btnManual"
        Me.btnManual.Size = New System.Drawing.Size(23, 22)
        Me.btnManual.Text = "Manual Altitude Adjustment"
        '
        'btnFlatten
        '
        Me.btnFlatten.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFlatten.Image = CType(resources.GetObject("btnFlatten.Image"), System.Drawing.Image)
        Me.btnFlatten.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFlatten.Name = "btnFlatten"
        Me.btnFlatten.Size = New System.Drawing.Size(23, 22)
        Me.btnFlatten.Text = "Flatten Altitude"
        '
        'btnSmooth
        '
        Me.btnSmooth.CheckOnClick = True
        Me.btnSmooth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSmooth.Image = CType(resources.GetObject("btnSmooth.Image"), System.Drawing.Image)
        Me.btnSmooth.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSmooth.Name = "btnSmooth"
        Me.btnSmooth.Size = New System.Drawing.Size(23, 22)
        Me.btnSmooth.Text = "Smooth Altitude"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'btnRaise
        '
        Me.btnRaise.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRaise.Image = CType(resources.GetObject("btnRaise.Image"), System.Drawing.Image)
        Me.btnRaise.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRaise.Name = "btnRaise"
        Me.btnRaise.Size = New System.Drawing.Size(23, 22)
        Me.btnRaise.Text = "Increase Altitude"
        '
        'btnLower
        '
        Me.btnLower.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLower.Image = CType(resources.GetObject("btnLower.Image"), System.Drawing.Image)
        Me.btnLower.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLower.Name = "btnLower"
        Me.btnLower.Size = New System.Drawing.Size(23, 22)
        Me.btnLower.Text = "Decrease Altitude"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'btnSquare
        '
        Me.btnSquare.Checked = True
        Me.btnSquare.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnSquare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSquare.Image = CType(resources.GetObject("btnSquare.Image"), System.Drawing.Image)
        Me.btnSquare.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSquare.Name = "btnSquare"
        Me.btnSquare.Size = New System.Drawing.Size(23, 22)
        Me.btnSquare.Text = "Square Brush"
        '
        'btnCircle
        '
        Me.btnCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCircle.Image = CType(resources.GetObject("btnCircle.Image"), System.Drawing.Image)
        Me.btnCircle.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCircle.Name = "btnCircle"
        Me.btnCircle.Size = New System.Drawing.Size(23, 22)
        Me.btnCircle.Text = "Circle Brush"
        '
        'btnLineNS
        '
        Me.btnLineNS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLineNS.Image = CType(resources.GetObject("btnLineNS.Image"), System.Drawing.Image)
        Me.btnLineNS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLineNS.Name = "btnLineNS"
        Me.btnLineNS.Size = New System.Drawing.Size(23, 22)
        Me.btnLineNS.Text = "Line N-S Brush"
        '
        'btnLineWE
        '
        Me.btnLineWE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLineWE.Image = CType(resources.GetObject("btnLineWE.Image"), System.Drawing.Image)
        Me.btnLineWE.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLineWE.Name = "btnLineWE"
        Me.btnLineWE.Size = New System.Drawing.Size(23, 22)
        Me.btnLineWE.Text = "Line W-E Brush"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnSingle
        '
        Me.btnSingle.Checked = True
        Me.btnSingle.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnSingle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSingle.Image = CType(resources.GetObject("btnSingle.Image"), System.Drawing.Image)
        Me.btnSingle.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSingle.Name = "btnSingle"
        Me.btnSingle.Size = New System.Drawing.Size(23, 22)
        Me.btnSingle.Text = "Single Brush"
        '
        'btnSmall
        '
        Me.btnSmall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSmall.Image = CType(resources.GetObject("btnSmall.Image"), System.Drawing.Image)
        Me.btnSmall.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSmall.Name = "btnSmall"
        Me.btnSmall.Size = New System.Drawing.Size(23, 22)
        Me.btnSmall.Text = "Small Brush"
        '
        'btnMedium
        '
        Me.btnMedium.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnMedium.Image = CType(resources.GetObject("btnMedium.Image"), System.Drawing.Image)
        Me.btnMedium.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMedium.Name = "btnMedium"
        Me.btnMedium.Size = New System.Drawing.Size(23, 22)
        Me.btnMedium.Text = "Medium Brush"
        '
        'btnLarge
        '
        Me.btnLarge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLarge.Image = CType(resources.GetObject("btnLarge.Image"), System.Drawing.Image)
        Me.btnLarge.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLarge.Name = "btnLarge"
        Me.btnLarge.Size = New System.Drawing.Size(23, 22)
        Me.btnLarge.Text = "Large Brush"
        '
        'splitRender
        '
        Me.splitRender.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitRender.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitRender.Location = New System.Drawing.Point(0, 25)
        Me.splitRender.Name = "splitRender"
        '
        'splitRender.Panel1
        '
        Me.splitRender.Panel1.Controls.Add(Me.grpAltitude)
        Me.splitRender.Panel1.Controls.Add(Me.grpSpeed)
        Me.splitRender.Panel1.Controls.Add(Me.grpPaint)
        '
        'splitRender.Panel2
        '
        Me.splitRender.Panel2.Controls.Add(Me.picRender)
        Me.splitRender.Size = New System.Drawing.Size(802, 529)
        Me.splitRender.SplitterDistance = 507
        Me.splitRender.SplitterWidth = 3
        Me.splitRender.TabIndex = 3
        '
        'grpAltitude
        '
        Me.grpAltitude.Controls.Add(Me.numAltitude)
        Me.grpAltitude.Controls.Add(Me.Label3)
        Me.grpAltitude.Enabled = False
        Me.grpAltitude.Location = New System.Drawing.Point(3, 82)
        Me.grpAltitude.Name = "grpAltitude"
        Me.grpAltitude.Size = New System.Drawing.Size(191, 39)
        Me.grpAltitude.TabIndex = 51
        Me.grpAltitude.TabStop = False
        Me.grpAltitude.Text = "Altitude"
        '
        'numAltitude
        '
        Me.numAltitude.DecimalPlaces = 1
        Me.numAltitude.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numAltitude.Location = New System.Drawing.Point(110, 14)
        Me.numAltitude.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numAltitude.Name = "numAltitude"
        Me.numAltitude.Size = New System.Drawing.Size(67, 20)
        Me.numAltitude.TabIndex = 4
        Me.numAltitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Set Flatting Altitude"
        '
        'grpPaint
        '
        Me.grpPaint.Controls.Add(Me.Label5)
        Me.grpPaint.Controls.Add(Me.Label4)
        Me.grpPaint.Controls.Add(Me.trkAlpha)
        Me.grpPaint.Controls.Add(Me.lstLandscapes)
        Me.grpPaint.Controls.Add(Me.lstLayers)
        Me.grpPaint.Enabled = False
        Me.grpPaint.Location = New System.Drawing.Point(3, 127)
        Me.grpPaint.Name = "grpPaint"
        Me.grpPaint.Size = New System.Drawing.Size(191, 224)
        Me.grpPaint.TabIndex = 50
        Me.grpPaint.TabStop = False
        Me.grpPaint.Text = "Paintbrush"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(140, 201)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Opaque"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Transparent"
        '
        'trkAlpha
        '
        Me.trkAlpha.Location = New System.Drawing.Point(6, 169)
        Me.trkAlpha.Name = "trkAlpha"
        Me.trkAlpha.Size = New System.Drawing.Size(179, 45)
        Me.trkAlpha.TabIndex = 31
        '
        'lstLandscapes
        '
        Me.lstLandscapes.FormattingEnabled = True
        Me.lstLandscapes.Location = New System.Drawing.Point(6, 19)
        Me.lstLandscapes.Name = "lstLandscapes"
        Me.lstLandscapes.Size = New System.Drawing.Size(179, 69)
        Me.lstLandscapes.TabIndex = 30
        '
        'lstLayers
        '
        Me.lstLayers.Location = New System.Drawing.Point(6, 94)
        Me.lstLayers.Name = "lstLayers"
        Me.lstLayers.Size = New System.Drawing.Size(179, 69)
        Me.lstLayers.TabIndex = 29
        '
        'grpSpeed
        '
        Me.grpSpeed.Controls.Add(Me.Label2)
        Me.grpSpeed.Controls.Add(Me.Label1)
        Me.grpSpeed.Controls.Add(Me.trkStep)
        Me.grpSpeed.Enabled = False
        Me.grpSpeed.Location = New System.Drawing.Point(3, 3)
        Me.grpSpeed.Name = "grpSpeed"
        Me.grpSpeed.Size = New System.Drawing.Size(191, 73)
        Me.grpSpeed.TabIndex = 5
        Me.grpSpeed.TabStop = False
        Me.grpSpeed.Text = "Tool Speed"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(158, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Fast"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Slow"
        '
        'trkStep
        '
        Me.trkStep.LargeChange = 1
        Me.trkStep.Location = New System.Drawing.Point(6, 19)
        Me.trkStep.Minimum = 1
        Me.trkStep.Name = "trkStep"
        Me.trkStep.Size = New System.Drawing.Size(179, 45)
        Me.trkStep.TabIndex = 3
        Me.trkStep.Value = 1
        '
        'fRender
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 554)
        Me.Controls.Add(Me.splitRender)
        Me.Controls.Add(Me.toolMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "fRender"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LandED"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.picRender, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toolMain.ResumeLayout(False)
        Me.toolMain.PerformLayout()
        Me.splitRender.Panel1.ResumeLayout(False)
        Me.splitRender.Panel2.ResumeLayout(False)
        Me.splitRender.ResumeLayout(False)
        Me.grpAltitude.ResumeLayout(False)
        Me.grpAltitude.PerformLayout()
        CType(Me.numAltitude, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPaint.ResumeLayout(False)
        Me.grpPaint.PerformLayout()
        CType(Me.trkAlpha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSpeed.ResumeLayout(False)
        Me.grpSpeed.PerformLayout()
        CType(Me.trkStep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picRender As System.Windows.Forms.PictureBox
    Friend WithEvents toolMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnLights As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnMaterials As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnlandscapes As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnWater As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAltitude As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRender As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnManual As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRaise As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLower As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnFlatten As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSmudge As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSelect As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnWalk As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSmooth As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSquare As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCircle As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLineNS As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLineWE As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSingle As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSmall As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnMedium As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLarge As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSplatter As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnAlpha As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPaint As System.Windows.Forms.ToolStripButton
    Friend WithEvents splitRender As System.Windows.Forms.SplitContainer
    Friend WithEvents grpSpeed As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents trkStep As System.Windows.Forms.TrackBar
    Friend WithEvents grpPaint As System.Windows.Forms.GroupBox
    Friend WithEvents lstLayers As System.Windows.Forms.ListBox
    Friend WithEvents lstLandscapes As System.Windows.Forms.ListBox
    Friend WithEvents grpAltitude As System.Windows.Forms.GroupBox
    Friend WithEvents numAltitude As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents trkAlpha As System.Windows.Forms.TrackBar
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
End Class

Public Class fRender
    Private eBrushMode As cBrush.Enum_BrushMode
    Private _bChangesEnabled As Boolean

    Private Sub fEditorRender_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Select Case MsgBox("Do you want to SAVE your project before leaving?", MsgBoxStyle.YesNoCancel)
            Case MsgBoxResult.Yes
                Main_Save()
                CoreStatus = EnumCoreStatus.Editor_Quit
            Case MsgBoxResult.No
                CoreStatus = EnumCoreStatus.Editor_Quit
            Case MsgBoxResult.Cancel
        End Select
    End Sub

    Private Sub btnlandscapes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlandscapes.Click
        Dim frmLandscapes As New fLandscapes
        frmLandscapes.ShowDialog()
    End Sub

    Private Sub btnAltitude_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltitude.Click
        If btnAltitude.CheckState = CheckState.Checked Then clsGUI.DisplayAltitude(True) Else clsGUI.DisplayAltitude(False)
    End Sub

    Private Sub btnMaterials_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaterials.Click
        Dim frmMaterials As New fMaterials
        frmMaterials.ShowDialog()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Main_Save()
    End Sub

    Private Sub fEditorRender_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        picRender.Width = splitRender.Panel1.Width - 6
        picRender.Height = splitRender.Panel1.Height - 6
        clsEngine.Resize()
    End Sub

    Private Sub btnRender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRender.Click
        If btnRender.CheckState = CheckState.Checked Then clsScene.RenderSolid(True) Else clsScene.RenderSolid(False)
    End Sub

    Private Sub btnLights_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLights.Click
        Dim frmLights As New fLights
        frmLights.ShowDialog()
    End Sub

    Private Sub btnSmudge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSmudge.Click
        Dim frmSmudge As New fSmudge
        frmSmudge.ShowDialog()
    End Sub

    Private Sub btnManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManual.Click

        ' Mode
        eBrushMode = cBrush.Enum_BrushMode.Mode_Manual

        ' Buttons
        btnSmooth.Checked = False
        btnSelect.Checked = False
        btnManual.Checked = True
        btnRaise.Checked = False
        btnLower.Checked = False
        btnFlatten.Checked = False
        btnPaint.Checked = False

        ' Groups
        grpSpeed.Enabled = True
        grpPaint.Enabled = False
        grpAltitude.Enabled = False

    End Sub

    Private Sub btnRaise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRaise.Click

        ' Mode
        eBrushMode = cBrush.Enum_BrushMode.Mode_Increase

        ' Buttons
        btnSmooth.Checked = False
        btnSelect.Checked = False
        btnManual.Checked = False
        btnRaise.Checked = True
        btnLower.Checked = False
        btnFlatten.Checked = False
        btnPaint.Checked = False

        ' Groups
        grpSpeed.Enabled = True
        grpPaint.Enabled = False
        grpAltitude.Enabled = False

    End Sub

    Private Sub btnLower_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLower.Click

        ' Mode
        eBrushMode = cBrush.Enum_BrushMode.Mode_Decrease

        ' Buttons
        btnSmooth.Checked = False
        btnSelect.Checked = False
        btnManual.Checked = False
        btnRaise.Checked = False
        btnLower.Checked = True
        btnFlatten.Checked = False
        btnPaint.Checked = False

        ' Groups
        grpSpeed.Enabled = True
        grpPaint.Enabled = False
        grpAltitude.Enabled = False

    End Sub

    Private Sub btnFlatten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFlatten.Click

        ' Mode
        eBrushMode = cBrush.Enum_BrushMode.Mode_Flatten

        ' Buttons
        btnSmooth.Checked = False
        btnSelect.Checked = False
        btnManual.Checked = False
        btnRaise.Checked = False
        btnLower.Checked = False
        btnFlatten.Checked = False
        btnPaint.Checked = False

        ' Groups
        grpSpeed.Enabled = False
        grpPaint.Enabled = False
        grpAltitude.Enabled = True

    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click

        ' Mode
        eBrushMode = cBrush.Enum_BrushMode.Mode_Select

        ' Buttons
        btnSmooth.Checked = False
        btnSelect.Checked = True
        btnManual.Checked = False
        btnRaise.Checked = False
        btnLower.Checked = False
        btnFlatten.Checked = False
        btnPaint.Checked = False

        ' Groups
        grpSpeed.Enabled = False
        grpPaint.Enabled = False
        grpAltitude.Enabled = False

    End Sub

    Private Sub btnSmooth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSmooth.Click

        ' Mode
        eBrushMode = cBrush.Enum_BrushMode.Mode_Smooth

        ' Buttons
        btnSmooth.Checked = True
        btnSelect.Checked = False
        btnManual.Checked = False
        btnRaise.Checked = False
        btnLower.Checked = False
        btnFlatten.Checked = False
        btnPaint.Checked = False

        ' Groups
        grpSpeed.Enabled = True
        grpPaint.Enabled = False
        grpAltitude.Enabled = False

    End Sub

    Private Sub btnPaint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaint.Click

        ' Mode
        eBrushMode = cBrush.Enum_BrushMode.Mode_Paint

        ' Buttons
        btnSmooth.Checked = False
        btnSelect.Checked = False
        btnManual.Checked = False
        btnRaise.Checked = False
        btnLower.Checked = False
        btnFlatten.Checked = False
        btnPaint.Checked = True

        ' Groups
        grpSpeed.Enabled = False
        grpPaint.Enabled = True
        grpAltitude.Enabled = False
        trkAlpha.Value = CInt(clsBrush.BrushOpacity * 10)

        ' Clear painter
        clsBrush.PaintSelect("", "")

        ' List Landscapes
        lstLandscapes.Items.Clear()
        lstLandscapes.Sorted = True
        lstLayers.Items.Clear()
        lstLayers.Sorted = False
        Dim sList() As String = Nothing
        sList = clsLandManager.GetList
        If Not sList Is Nothing Then
            For i As Integer = 0 To UBound(sList)
                lstLandscapes.Items.Add(sList(i))
            Next
        End If

    End Sub

    Private Sub btnWalk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWalk.Click
        If btnWalk.CheckState = CheckState.Checked Then clsCamera.Walk(True) Else clsCamera.Walk(False)
    End Sub

    Private Sub btnSquare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSquare.Click
        clsBrush.BrushShape = cBrush.Enum_BrushShape.Shape_Square
        btnSquare.Checked = True
        btnCircle.Checked = False
        btnLineNS.Checked = False
        btnLineWE.Checked = False
    End Sub

    Private Sub btnCircle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCircle.Click
        clsBrush.BrushShape = cBrush.Enum_BrushShape.Shape_Circle
        btnSquare.Checked = False
        btnCircle.Checked = True
        btnLineNS.Checked = False
        btnLineWE.Checked = False
    End Sub

    Private Sub btnLineNS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLineNS.Click
        clsBrush.BrushShape = cBrush.Enum_BrushShape.Shape_LineNS
        btnSquare.Checked = False
        btnCircle.Checked = False
        btnLineNS.Checked = True
        btnLineWE.Checked = False
    End Sub

    Private Sub btnLineWE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLineWE.Click
        clsBrush.BrushShape = cBrush.Enum_BrushShape.Shape_LineWE
        btnSquare.Checked = False
        btnCircle.Checked = False
        btnLineNS.Checked = False
        btnLineWE.Checked = True
    End Sub

    Private Sub btnSingle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSingle.Click
        clsBrush.BrushSize = cBrush.Enum_BrushSize.Size_Single
        btnSingle.Checked = True
        btnSmall.Checked = False
        btnMedium.Checked = False
        btnLarge.Checked = False
    End Sub

    Private Sub btnSmall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSmall.Click
        clsBrush.BrushSize = cBrush.Enum_BrushSize.Size_Small
        btnSingle.Checked = False
        btnSmall.Checked = True
        btnMedium.Checked = False
        btnLarge.Checked = False
    End Sub

    Private Sub btnMedium_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMedium.Click
        clsBrush.BrushSize = cBrush.Enum_BrushSize.Size_Medium
        btnSingle.Checked = False
        btnSmall.Checked = False
        btnMedium.Checked = True
        btnLarge.Checked = False
    End Sub

    Private Sub btnLarge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLarge.Click
        clsBrush.BrushSize = cBrush.Enum_BrushSize.Size_Large
        btnSingle.Checked = False
        btnSmall.Checked = False
        btnMedium.Checked = False
        btnLarge.Checked = True
    End Sub

    Private Sub btnSplatter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSplatter.Click
        Dim frmSplatter As New fSplatter
        frmSplatter.ShowDialog()
    End Sub

    Private Sub btnWater_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWater.Click
        Dim frmWater As New fWater
        frmWater.ShowDialog()
    End Sub

    Private Sub btnAlpha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlpha.Click
        Dim frmAlpha As New fAlpha
        frmAlpha.showdialog()
    End Sub

    Private Sub trkStep_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trkStep.Scroll
        clsBrush.BrushStep = CSng(trkStep.Value / 10)
    End Sub

    Private Sub numAltitude_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numAltitude.ValueChanged
        clsBrush.BrushFlatten = numAltitude.Value
    End Sub

    Private Sub lstLandscapes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLandscapes.SelectedIndexChanged

        ' Clear
        lstLayers.Items.Clear()
        lstLayers.Sorted = False

        ' Update layers list
        Dim sList() As String = Nothing
        sList = clsLandManager.Splatting_GetList(lstLandscapes.SelectedItem.ToString)
        If Not sList Is Nothing Then
            For i As Integer = 0 To UBound(sList)
                lstLayers.Items.Add(sList(i))
            Next
        End If

    End Sub

    Private Sub lstLayers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLayers.SelectedIndexChanged
        clsBrush.PaintSelect(lstLandscapes.SelectedItem.ToString, lstLayers.SelectedItem.ToString)
    End Sub

    Private Sub picRender_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles picRender.MouseEnter
        clsBrush.BrushMode = eBrushMode
        picRender.Focus()
    End Sub

    Private Sub picRender_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles picRender.MouseLeave
        eBrushMode = clsBrush.BrushMode
        clsBrush.BrushMode = cBrush.Enum_BrushMode.Mode_Nothing
    End Sub

    Private Sub trkAlpha_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trkAlpha.Scroll
        clsBrush.BrushOpacity = CSng(trkAlpha.Value / 10)
    End Sub

    Private Sub fRender_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        splitRender.IsSplitterFixed = True
        splitRender.SplitterDistance = 193
    End Sub

End Class
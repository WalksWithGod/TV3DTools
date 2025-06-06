Public Class fLandscapes
    Private _nChangesEnabled As Boolean

    Private Sub fLandscapes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim sOverlap As String = clsLandManager.CheckOverlap()
        If sOverlap <> "" Then
            e.Cancel = True
            MsgBox(sOverlap)
        End If
    End Sub

    Private Sub flandscapes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshList()
    End Sub

    Private Sub RefreshList()

        ' Disable
        _nChangesEnabled = False

        ' List
        lstLandscapes.Items.Clear()
        lstLandscapes.Sorted = True
        Dim strList() As String = Nothing
        strList = clsLandManager.GetList
        If Not strList Is Nothing Then
            For i As Integer = 0 To UBound(strList)
                lstLandscapes.Items.Add(strList(i))
            Next
        End If

        ' Materials
        cboMaterial.Items.Clear()
        cboMaterial.Sorted = True
        Dim strMat() As String = clsMaterials.GetList
        If Not strMat Is Nothing Then
            For i As Integer = 0 To UBound(strMat)
                If strMat(i) <> "" Then cboMaterial.Items.Add(strMat(i))
            Next
        End If

        ' Disable
        grpSettings.Enabled = False
        grpPosition.Enabled = False
        btnExportTVM.Enabled = False
        btnExportBMP.Enabled = False
        btnRemove.Enabled = False
        chkRender.Checked = False

        ' Enable
        _nChangesEnabled = True

    End Sub

    Private Sub lstLandscapes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLandscapes.SelectedIndexChanged

        ' Disable
        _nChangesEnabled = False

        ' Fill
        numScale.Value = CDec(clsLandManager.GetScale(lstLandscapes.SelectedItem.ToString))
        numPosX.Value = CDec(clsLandManager.GetPositionX(lstLandscapes.SelectedItem.ToString))
        numPosZ.Value = CDec(clsLandManager.GetPositionZ(lstLandscapes.SelectedItem.ToString))
        cboMaterial.Text = clsMaterials.GetMaterialName(clsLandManager.GetMaterial(lstLandscapes.SelectedItem.ToString))
        chkRender.Checked = clsLandManager.GetEnabled(lstLandscapes.SelectedItem.ToString)

        ' Enable       
        grpSettings.Enabled = True
        grpPosition.Enabled = True
        btnExportTVM.Enabled = True
        btnExportBMP.Enabled = True
        btnRemove.Enabled = True

        ' Enable
        _nChangesEnabled = True

    End Sub

    Private Sub btnAddFlat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFlat.Click
        Dim sName As String = InputBox("Enter name for new Landscape").Replace(" ", "")
        If sName = "" Then
            MsgBox("You must provide a name for the new Landscape!")
        Else
            If clsLandManager.CheckAvailable(sName) = False Then
                MsgBox("Landscape's name allready in use!")
            Else
                clsLandManager.AddFlat(sName)
                RefreshList()
            End If
        End If
        Main_Render()
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If MsgBox("Are you sure you want to remove the Landscape named '" & lstLandscapes.SelectedItem.ToString & "' ?", MsgBoxStyle.YesNo, "Remove Landscape") = MsgBoxResult.Yes Then
            clsLandManager.Remove(lstLandscapes.SelectedItem.ToString)
            RefreshList()
        End If
        Main_Render()
    End Sub

    Private Sub numPosX_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numPosX.ValueChanged
        If _nChangesEnabled Then
            clsLandManager.SetPositionX(lstLandscapes.SelectedItem.ToString, numPosX.Value)
            Main_Render()
        End If
    End Sub

    Private Sub numPosZ_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numPosZ.ValueChanged
        If _nChangesEnabled Then
            clsLandManager.SetPositionZ(lstLandscapes.SelectedItem.ToString, numPosZ.Value)
            Main_Render()
        End If
    End Sub

    Private Sub numScale_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numScale.ValueChanged
        If _nChangesEnabled Then
            clsLandManager.SetScale(lstLandscapes.SelectedItem.ToString, numScale.Value)
            Main_Render()
        End If
    End Sub

    Private Sub btnExportTVM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportTVM.Click
        clsLandManager.ExportTVM(lstLandscapes.SelectedItem.ToString)
        Main_Render()
    End Sub

    Private Sub btnExportBMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportBMP.Click
        clsLandManager.ExportBMP(lstLandscapes.SelectedItem.ToString)
        Main_Render()
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Dim OFD As New OpenFileDialog
        OFD.Filter = "TVM Files (*.tvm)|*.tvm"
        OFD.InitialDirectory = sCorePath & "Media\Landscape\Heightmap TVM\"
        If OFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim strName As String = InputBox("Enter name for new Landscape").Replace(" ", "")
            If strName = "" Then
                MsgBox("You must provide a name for the new Landscape!")
            Else
                If clsLandManager.CheckAvailable(strName) = False Then
                    MsgBox("Landscape's name allready in use!")
                Else
                    clsLandManager.ImportTVM(strName, OFD.FileName)
                    RefreshList()
                End If
            End If
        End If
        Main_Render()
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Dim frmGenerate As New fGenerate
        frmGenerate.ShowDialog()
        RefreshList()
        Main_Render()
    End Sub

    Private Sub cboMaterial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMaterial.SelectedIndexChanged
        If _nChangesEnabled Then
            Dim iMaterial As Integer = clsMaterials.GetMaterialFromName(cboMaterial.SelectedItem.ToString)
            clsLandManager.SetMaterial(lstLandscapes.SelectedItem.ToString, iMaterial)
            Main_Render()
        End If
    End Sub

    Private Sub fLandscapes_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        Main_Render()
    End Sub

    Private Sub chkRender_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRender.CheckedChanged
        If _nChangesEnabled Then
            clsLandManager.SetEnabled(lstLandscapes.SelectedItem.ToString, chkRender.Checked)
            Main_Render()
        End If
    End Sub

End Class
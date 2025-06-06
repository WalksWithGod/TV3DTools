Public Class fWater
    Private _nChangesEnabled As Boolean

    Private Sub fWater_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        Main_Render()
    End Sub

    Private Sub fWater_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshList()
    End Sub

    Private Sub RefreshList()

        ' Disable
        _nChangesEnabled = False

        ' List
        lstWater.Items.Clear()
        lstWater.Sorted = True
        Dim strList() As String = Nothing
        strList = clsWaterManager.GetList
        If Not strList Is Nothing Then
            For i As Integer = 0 To UBound(strList)
                lstWater.Items.Add(strList(i))
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
        btnRemove.Enabled = False
        grpSettings.Enabled = False
        grpPosition.Enabled = False
        grpScale.Enabled = False

        ' Enable
        _nChangesEnabled = True

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim sName As String = InputBox("Enter name for new Water Plane").Replace(" ", "")
        If sName = "" Then
            MsgBox("You must provide a name for the new Water Plane!")
        Else
            If clsWaterManager.CheckAvailable(sName) = False Then
                MsgBox("Water Plane's name allready in use!")
            Else
                ' Add water plane 
                clsWaterManager.Add(sName)
                RefreshList()
            End If
        End If
        Main_Render()
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If MsgBox("Are you sure you want to remove the Water Plane named '" & lstWater.SelectedItem.ToString & "' ?", MsgBoxStyle.YesNo, "Remove Landscape") = MsgBoxResult.Yes Then
            clsWaterManager.Remove(lstWater.SelectedItem.ToString)
            RefreshList()
        End If
        Main_Render()
    End Sub

    Private Sub lstWater_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstWater.SelectedIndexChanged

        ' Disable
        _nChangesEnabled = False

        ' Fill
        cboMaterial.Text = clsMaterials.GetMaterialName(clsWaterManager.GetMaterial(lstWater.SelectedItem.ToString))
        numPosX.Value = CDec(clsWaterManager.GetPositionX(lstWater.SelectedItem.ToString))
        numPosZ.Value = CDec(clsWaterManager.GetPositionZ(lstWater.SelectedItem.ToString))
        numAltitude.Value = CDec(clsWaterManager.GetAltitude(lstWater.SelectedItem.ToString))
        numScaleX.Value = CDec(clsWaterManager.GetScaleX(lstWater.SelectedItem.ToString))
        numScaleZ.Value = CDec(clsWaterManager.GetScaleZ(lstWater.SelectedItem.ToString))

        ' Enable       
        btnRemove.Enabled = True
        grpSettings.Enabled = True
        grpPosition.Enabled = True
        grpScale.Enabled = True

        ' Enable
        _nChangesEnabled = True

    End Sub

    Private Sub cboMaterial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMaterial.SelectedIndexChanged
        If _nChangesEnabled Then
            Dim iMaterial As Integer = clsMaterials.GetMaterialFromName(cboMaterial.SelectedItem.ToString)
            clsWaterManager.SetMaterial(lstWater.SelectedItem.ToString, iMaterial)
            Main_Render()
        End If
    End Sub

    Private Sub numPosZ_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numPosZ.ValueChanged
        If _nChangesEnabled Then
            clsWaterManager.SetPositionZ(lstWater.SelectedItem.ToString, numPosZ.Value)
            Main_Render()
        End If
    End Sub

    Private Sub numPosX_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numPosX.ValueChanged
        If _nChangesEnabled Then
            clsWaterManager.SetPositionX(lstWater.SelectedItem.ToString, numPosX.Value)
            Main_Render()
        End If
    End Sub

    Private Sub numAltitude_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numAltitude.ValueChanged
        If _nChangesEnabled Then
            clsWaterManager.SetAltitude(lstWater.SelectedItem.ToString, numAltitude.Value)
            Main_Render()
        End If
    End Sub

    Private Sub numScaleZ_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numScaleZ.ValueChanged
        If _nChangesEnabled Then
            clsWaterManager.Setscalez(lstWater.SelectedItem.ToString, numScaleZ.Value)
            Main_Render()
        End If
    End Sub

    Private Sub numScaleX_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numScaleX.ValueChanged
        If _nChangesEnabled Then
            clsWaterManager.SetScaleX(lstWater.SelectedItem.ToString, numScaleX.Value)
            Main_Render()
        End If
    End Sub

    Private Sub btnDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDefault.Click
        If _nChangesEnabled Then
            clsWaterManager.SetMaterial(lstWater.SelectedItem.ToString, clsMaterials.GetMaterialFromName("defaultwater"))
            Main_Render()
        End If

    End Sub

End Class
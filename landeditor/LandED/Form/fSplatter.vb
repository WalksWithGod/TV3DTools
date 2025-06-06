Public Class fSplatter
    Private _nChangesEnabled As Boolean
    Private _sSelectedLayer As String

    Private Sub fSplatter_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        Main_Render()
    End Sub

    Private Sub fSplatter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshList()
    End Sub

    Private Sub RefreshList()
        _nChangesEnabled = False

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

        ' Disable
        grpLayers.Enabled = False
        btnAdd.Enabled = False
        btnDel.Enabled = False
        btnMoveUp.Enabled = False
        btnMoveDown.Enabled = False
        btnExportAlpha.Enabled = False

        ' Changes
        _nChangesEnabled = True
    End Sub

    Private Sub RefreshLayersList()

        ' Clear picture
        picAlpha.Image = Nothing
        picTexture.Image = Nothing

        ' Clear list
        lstLayers.Items.Clear()
        lstLayers.Sorted = False
        Dim sList() As String = Nothing
        sList = clsLandManager.Splatting_GetList(lstLandscapes.SelectedItem.ToString)
        If Not sList Is Nothing Then
            For i As Integer = 0 To UBound(sList)
                lstLayers.Items.Add(sList(i))
            Next
        End If
        If _sSelectedLayer <> "" Then lstLayers.SelectedItem = _sSelectedLayer

    End Sub

    Private Sub lstLandscapes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLandscapes.SelectedIndexChanged
        _nChangesEnabled = False

        ' Fill
        RefreshLayersList()

        ' Enable
        grpLayers.Enabled = True
        btnAdd.Enabled = True
        btnDel.Enabled = False
        btnMoveUp.Enabled = False
        btnMoveDown.Enabled = False
        btnExportAlpha.Enabled = False

        _nChangesEnabled = True
    End Sub

    Private Sub lstLayers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLayers.SelectedIndexChanged
        Dim img As Image, iTexture As Integer
        _nChangesEnabled = False

        ' Fill
        iTexture = clsLandManager.Splatting_GetTexture(lstLandscapes.SelectedItem.ToString, lstLayers.SelectedItem.ToString)
        img = Image.FromFile(clsTexture.GetFilePath(iTexture))
        picTexture.Image = img.GetThumbnailImage(picTexture.Width, picTexture.Height, Nothing, Nothing)

        ' Fill
        iTexture = clsLandManager.Splatting_GetAlpha(lstLandscapes.SelectedItem.ToString, lstLayers.SelectedItem.ToString)
        img = Image.FromFile(clsTexture.GetFilePath(iTexture))
        picAlpha.Image = img.GetThumbnailImage(picAlpha.Width, picAlpha.Height, Nothing, Nothing)

        ' Enable
        btnDel.Enabled = True
        btnMoveUp.Enabled = True
        btnMoveDown.Enabled = True
        btnExportAlpha.Enabled = True

        _nChangesEnabled = True
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim frmSplattingLayer As New fSplattingLayer
        frmSplattingLayer.sLandscape = lstLandscapes.SelectedItem.ToString
        frmSplattingLayer.ShowDialog()
        _sSelectedLayer = ""
        RefreshLayersList()
        Main_Render()
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        clsLandManager.Splatting_RemoveLayer(lstLandscapes.SelectedItem.ToString, lstLayers.SelectedItem.ToString)
        _sSelectedLayer = ""
        RefreshLayersList()
        Main_Render()
    End Sub

    Private Sub btnMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveUp.Click
        clsLandManager.Splatting_MoveLayerUp(lstLandscapes.SelectedItem.ToString, lstLayers.SelectedItem.ToString)
        _sSelectedLayer = lstLayers.SelectedItem.ToString
        RefreshLayersList()
        Main_Render()
    End Sub

    Private Sub btnMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveDown.Click
        clsLandManager.Splatting_MoveLayerDown(lstLandscapes.SelectedItem.ToString, lstLayers.SelectedItem.ToString)
        _sSelectedLayer = lstLayers.SelectedItem.ToString
        RefreshLayersList()
        Main_Render()
    End Sub

End Class
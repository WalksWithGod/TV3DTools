Public Class fAlpha
    Private _bChangesEnabled As Boolean

    Private Sub numMinAlt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numMinAlt.ValueChanged
        If numMinAlt.Value > numMaxAlt.Value Then numMaxAlt.Value = numMinAlt.Value
    End Sub

    Private Sub numMaxAlt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numMaxAlt.ValueChanged
        If numMaxAlt.Value < numMinAlt.Value Then numMinAlt.Value = numMaxAlt.Value
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click

        ' Check
        If txtName.Text.Replace(" ", "") = "" Then
            MsgBox("You need to set a name for the Alpha Layer!")
        Else

            ' Generate
            clsLandManager.GenerateLayer(lstLandscapes.SelectedItem.ToString, txtName.Text.Replace(" ", ""), CSng(numMinAlt.Value), CSng(numMaxAlt.Value), CSng(numAAAltitude.Value))

        End If

    End Sub

    Private Sub fAlpha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Fill List
        lstLandscapes.Items.Clear()
        lstLandscapes.Sorted = True
        Dim strList() As String = Nothing
        strList = clsLandManager.GetList
        If Not strList Is Nothing Then
            For i As Integer = 0 To UBound(strList)
                lstLandscapes.Items.Add(strList(i))
            Next
        End If

        ' Disable 
        btnGenerate.Enabled = False
        _bChangesEnabled = True

    End Sub

    Private Sub lstLandscapes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLandscapes.SelectedIndexChanged
        If _bChangesEnabled Then btnGenerate.Enabled = True
    End Sub

    Private Sub fAlpha_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        Main_Render()
    End Sub

End Class
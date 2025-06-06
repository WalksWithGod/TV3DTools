Public Class fSmudge

    Private Sub btnAB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAB.Click
        If cboA.SelectedItem Is Nothing Or cboB.SelectedItem Is Nothing Then
            MsgBox("You must select landscapes to smudge!")
        Else
            ' Smudge
            Me.Text = "Smudging..."
            clsLandManager.Smudge(cboA.SelectedItem.ToString, cboB.SelectedItem.ToString, CInt(numStrength.Value * 4))
            Me.Text = "Smudge Altitudes"

            ' Render
            System.Windows.Forms.Application.DoEvents()
            Main_Render()

        End If
    End Sub

    Private Sub fSmudge_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboA.Sorted = True
        cboB.Sorted = True

        ' Fill A
        Dim sList() As String = clsLandManager.GetList
        If Not sList Is Nothing Then
            For i As Integer = 0 To UBound(sList)
                cboA.Items.Add(sList(i))
            Next
        End If
    End Sub

    Private Sub cboA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboA.SelectedIndexChanged

        ' Clear B
        With cboB
            .Enabled = True
            .Items.Clear()
            .SelectedItem = Nothing
            .Text = ""
        End With

        ' Fill B        
        Dim sList() As String = clsLandManager.GetSurrounding(cboA.SelectedItem.ToString)
        If Not sList Is Nothing Then
            For i As Integer = 0 To UBound(sList)
                cboB.Items.Add(sList(i))
            Next
        End If

    End Sub

    Private Sub fSmudge_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        Main_Render()
    End Sub

End Class
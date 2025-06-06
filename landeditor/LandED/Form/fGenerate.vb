Public Class fGenerate
    Private sFile As String
    Private eAffine As MTV3D65.CONST_TV_LANDSCAPE_AFFINE

    Private Sub picImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picImage.Click
        Dim i As Image
        Dim ofd As New OpenFileDialog

        With ofd
            .Filter = "TV3D Readable Files (*.bmp, *.dds, *.jpg, *.png, *.tga, *.tif)|*.bmp; *.dds; *.jpg; *.png; *.tga; *.tif"
            .InitialDirectory = sCorePath & "Media\Landscape\Heightmap BMP\"
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                i = Image.FromFile(ofd.FileName)
                picImage.Image = i.GetThumbnailImage(picImage.Width, picImage.Height, Nothing, Nothing)
                sFile = .FileName
            End If
        End With
    End Sub

    Private Sub cboAffine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAffine.SelectedIndexChanged
        Select Case cboAffine.SelectedItem.ToString
            Case "High" : eAffine = MTV3D65.CONST_TV_LANDSCAPE_AFFINE.TV_AFFINE_HIGH
            Case "Low" : eAffine = MTV3D65.CONST_TV_LANDSCAPE_AFFINE.TV_AFFINE_LOW
            Case "None" : eAffine = MTV3D65.CONST_TV_LANDSCAPE_AFFINE.TV_AFFINE_NO
        End Select
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If txtName.Text.Replace(" ", "") = "" Then
            MsgBox("You must provide a name for the new Landscape!")
        Else
            If sFile = "" Then
                MsgBox("You must select a heightmap file to generate the Landscape!")
            Else
                If clsLandManager.CheckAvailable(txtName.Text.Replace(" ", "")) = False Then
                    MsgBox("Landscape's name allready in use!")
                Else
                    clsLandManager.Generate(txtName.Text, sFile, eAffine)
                    Me.Close()
                End If
            End If
        End If
    End Sub

End Class
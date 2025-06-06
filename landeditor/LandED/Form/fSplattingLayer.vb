Public Class fSplattingLayer
    Public sLandscape As String
    Private sTexture As String
    Private sAlpha As String = sCorePath & "Media\Landscape\Template\Alpha.bmp"

    Private Sub picImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picImage.Click
        Dim i As Image
        Dim ofd As New OpenFileDialog
        With ofd
            .Filter = "TV3D Readable Files (*.bmp, *.dds, *.jpg, *.png, *.tga, *.tif)|*.bmp; *.dds; *.jpg; *.png; *.tga; *.tif"
            .InitialDirectory = sCorePath & "Media\Landscape\Textures\"
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                i = Image.FromFile(ofd.FileName)
                picImage.Image = i.GetThumbnailImage(picImage.Width, picImage.Height, Nothing, Nothing)
                sTexture = .FileName
            End If
        End With
        Main_Render()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If txtName.Text.Replace(" ", "") = "" Then
            MsgBox("You must provide a name for the texture layer!")
        Else
            If sTexture = "" Then
                MsgBox("You must select a texture file!")
            Else
                If clsLandManager.Splatting_CheckAvailable(sLandscape, txtName.Text.Replace(" ", "")) = False Then
                    MsgBox("Texture layer's name allready in use!")
                Else
                    clsLandManager.Splatting_AddLayer(sLandscape, txtName.Text, sTexture, sAlpha, CSng(numScale.Value))
                    Me.Close()
                End If
            End If
        End If
        Main_Render()
    End Sub

    Private Sub picAlpha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picAlpha.Click
        Dim i As Image
        Dim ofd As New OpenFileDialog
        With ofd
            .Filter = "TV3D Readable Files (*.bmp, *.dds, *.jpg, *.png, *.tga, *.tif)|*.bmp; *.dds; *.jpg; *.png; *.tga; *.tif"
            .InitialDirectory = sCorePath & "Media\Export\Alpha\"
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                i = Image.FromFile(ofd.FileName)
                picAlpha.Image = i.GetThumbnailImage(picAlpha.Width, picAlpha.Height, Nothing, Nothing)
                sAlpha = .FileName
            End If
        End With
        Main_Render()
    End Sub

    Private Sub fSplattingLayer_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        Main_Render()
    End Sub

End Class
Public Class fPreview
    Private _sFile As String

    Public Sub SetFile(ByVal sFile As String)
        _sFile = sFile
    End Sub

    Private Sub fPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Image = Image.FromFile(_sFile)
        picPreview.Image = i.GetThumbnailImage(picPreview.Width, picPreview.Height, Nothing, Nothing)
    End Sub

    Private Sub fPreview_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        Main_Render()
    End Sub

End Class
Public Class cLayer
    Private _sLayerName As String
    Private _iTexture As Integer
    Private _iAlpha As Integer
    Private _fScale As Single

    Public Sub Add(ByVal sName As String, ByVal sTexture As String, ByVal sAlpha As String, ByVal fScale As Single)
        _iTexture = clsTexture.Add(sTexture)
        _iAlpha = clsTexture.AddAlpha(sAlpha)
        _fScale = fScale
        _sLayerName = sName
    End Sub

    Public Sub Rebuild(ByVal sName As String, ByVal iTexture As Integer, ByVal iAlpha As Integer, ByVal fScale As Single)
        _iTexture = iTexture
        _iAlpha = iAlpha
        _fScale = fScale
        _sLayerName = sName
    End Sub

    Public Sub Quit()
        clsTexture.Remove(_iTexture)
        clsTexture.Remove(_iAlpha)
    End Sub

    Public Sub Save(ByVal sPath As String, ByVal sLandscape As String)

        ' Get texture/alpha filename
        Dim sTexture As String = clsFiles.GetFileFromPath(clsTexture.GetFilePath(_iTexture))
        Dim sAlpha As String = clsFiles.GetFileFromPath(clsTexture.GetFilePath(_iAlpha))

        ' Remove the prefix to prevent Grid_Grid_Grid_Texture.bmp...
        If sTexture.StartsWith(sLandscape & "_" & _sLayerName & "_") Then
            sTexture = sTexture.Substring(sLandscape.Length + _sLayerName.Length + 2)
            sAlpha = sAlpha.Substring(sLandscape.Length + _sLayerName.Length + 2)
        End If

        ' Add layer name prefix
        sTexture = sLandscape & "_" & _sLayerName & "_" & sTexture
        sAlpha = sLandscape & "_" & _sLayerName & "_" & sAlpha

        ' Save texture/alpha
        clsTexture.SaveTextureBMP(_iTexture, sPath, sTexture)
        clsTexture.SaveTextureAlphaBMP(_iAlpha, sPath, sAlpha)

    End Sub

    Public Function GetName() As String
        Return _sLayerName
    End Function

    Public Function GetTexture() As Integer
        Return _iTexture
    End Function

    Public Function GetAlpha() As Integer
        Return _iAlpha
    End Function

    Public Function GetScale() As Single
        Return _fScale
    End Function

End Class

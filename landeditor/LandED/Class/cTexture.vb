Public Class cTexture
    Private _TVTexture As MTV3D65.TVTextureFactory

    Public Sub Init()
        _TVTexture = New MTV3D65.TVTextureFactory
        _TVTexture.SetTextureMode(MTV3D65.CONST_TV_TEXTUREMODE.TV_TEXTUREMODE_BETTER)
    End Sub

    Public Sub Quit()
        _TVTexture = Nothing
    End Sub

    Public Function Add(ByVal sPath As String, Optional ByVal ColorKey As MTV3D65.CONST_TV_COLORKEY = MTV3D65.CONST_TV_COLORKEY.TV_COLORKEY_USE_ALPHA_CHANNEL) As Integer
        Return _TVTexture.LoadTexture(sPath, "", 0, 0, ColorKey)
    End Function

    Public Function AddAlpha(ByVal sPath As String) As Integer
        Return _TVTexture.LoadAlphaTexture(sPath)
    End Function

    Public Sub Remove(ByVal iTexture As Integer)
        _TVTexture.DeleteTexture(iTexture)
    End Sub

    Public Function GetFilePath(ByVal iTexture As Integer) As String
        If iTexture = -1 Then
            Return ""
        ElseIf iTexture = 0 Then
            Return ""
        Else
            Return _TVTexture.GetTextureInfo(iTexture).Filename
        End If
    End Function

    Public Sub SaveTextureBMP(ByVal iTexture As Integer, ByVal sPath As String, ByVal sFile As String)
        _TVTexture.SaveTexture(iTexture, sPath & sFile, MTV3D65.CONST_TV_IMAGEFORMAT.TV_IMAGE_BMP)
    End Sub

    Public Sub SaveTextureAlphaBMP(ByVal iTexture As Integer, ByVal sPath As String, ByVal sFile As String)

        ' Progress
        Dim iProgress As Integer
        Dim iTimer As Integer
        Dim frmProgress As New fProgress
        With frmProgress
            .proBar.Maximum = 256 * 256
            .Text = "Exporting '" & sFile & "'"
            .Show()
        End With

        ' Because you can't export an alpha texture, copy to a black/white texture and save
        Dim iWidth As Integer = _TVTexture.GetTextureInfo(iTexture).Width
        Dim iHeight As Integer = _TVTexture.GetTextureInfo(iTexture).Height

        ' Create a render surface
        Dim rs As MTV3D65.TVRenderSurface
        rs = clsScene.CreateRenderSurface(iWidth, iHeight, False)

        ' Start rendering
        rs.StartRender()
        clsGUI.Immediate_Begin()

        ' Draw on RS
        For x As Integer = 0 To iWidth
            For y As Integer = 0 To iHeight

                ' Progress
                iProgress += 1
                iTimer += 1
                If iTimer > 1000 Then
                    iTimer = 0
                    frmProgress.proBar.Value = iProgress
                End If

                ' Get pixel from alpha texture                
                Dim iPixel As Integer
                With _TVTexture
                    .LockTexture(iTexture)
                    iPixel = .GetPixel(iTexture, x, y)
                    .UnlockTexture(iTexture)
                End With

                ' Get alpha value of pixel
                Dim fAlpha As Single = clsGlobals.GetColorAlpha(iPixel)

                ' Draw on new texture
                clsGUI.DrawPoint(CSng(x), CSng(y), clsGlobals.GetColor(fAlpha, fAlpha, fAlpha, 1))

            Next
        Next

        ' End
        clsGUI.Immediate_End()
        rs.EndRender()

        ' Save texture
        _TVTexture.SaveTexture(rs.GetTexture, sPath & sFile, MTV3D65.CONST_TV_IMAGEFORMAT.TV_IMAGE_BMP)

        ' Unload
        frmProgress.Close()
        frmProgress = Nothing
        rs.Destroy()
        rs = Nothing

    End Sub

    Public Function GetPixel(ByVal iTexture As Integer, ByVal iX As Integer, ByVal iY As Integer) As Integer
        With _TVTexture
            .LockTexture(iTexture)
            Return .GetPixel(iTexture, iX, iY)
            .UnlockTexture(iTexture)
        End With
    End Function

    Public Sub SetPixel(ByVal iTexture As Integer, ByVal iX As Integer, ByVal iY As Integer, ByVal iColor As Integer)
        With _TVTexture
            .LockTexture(iTexture)
            .SetPixel(iTexture, iX, iY, iColor)
            .UnlockTexture(iTexture)
        End With
    End Sub

End Class

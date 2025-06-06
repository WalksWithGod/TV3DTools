Public Class cGlobals
    Private _TVGlobals As MTV3D65.TVGlobals

    Public Sub Init()
        _TVGlobals = New MTV3D65.TVGlobals
    End Sub

    Public Sub Quit()
        _TVGlobals = Nothing
    End Sub

    Public Function GetColor(ByVal fRed As Single, ByVal fGreen As Single, ByVal fBlue As Single, ByVal fAlpha As Single) As Integer
        Return _TVGlobals.RGBA(fRed, fGreen, fBlue, fAlpha)
    End Function

    Public Function GetColorAlpha(ByVal iColor As Integer) As Single
        Return _TVGlobals.DecodeRGBA(iColor).a
    End Function

End Class

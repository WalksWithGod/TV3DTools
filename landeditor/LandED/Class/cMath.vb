Public Class cMath
    Private _TVMath As MTV3D65.TVMathLibrary

    Public Sub Init()
        _TVMath = New MTV3D65.TVMathLibrary
    End Sub

    Public Sub Quit()
        _TVMath = Nothing
    End Sub

    Public Function VScale(ByVal vec As MTV3D65.TV_3DVECTOR, ByVal fScale As Single) As MTV3D65.TV_3DVECTOR
        Return _TVMath.VScale(vec, fScale)
    End Function

    Public Function Project3dpointTo2D(ByVal vecPoi As MTV3D65.TV_3DVECTOR) As MTV3D65.TV_3DVECTOR
        Dim v As MTV3D65.TV_3DVECTOR
        _TVMath.Project3dpointTo2D(vecPoi, v.x, v.y, False)
        Return v
    End Function

End Class

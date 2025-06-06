Public Class cScene
    Private _TVScene As MTV3D65.TVScene

    Public Sub Init()
        Dim i As Integer
        _TVScene = New MTV3D65.TVScene
        With _TVScene
            .SetShadowParameters(i, True)
            .SetShadeMode(MTV3D65.CONST_TV_SHADEMODE.TV_SHADEMODE_PHONG)
            .SetTextureFilter(MTV3D65.CONST_TV_TEXTUREFILTER.TV_FILTER_ANISOTROPIC)
        End With
    End Sub

    Public Sub Quit()
        _TVScene = Nothing
    End Sub

    Public Sub RenderSolid(ByVal nEnable As Boolean)
        If nEnable Then
            _TVScene.SetRenderMode(MTV3D65.CONST_TV_RENDERMODE.TV_SOLID)
        Else
            _TVScene.SetRenderMode(MTV3D65.CONST_TV_RENDERMODE.TV_LINE)
        End If
    End Sub

    Public Function CreateRenderSurface(ByVal iWidth As Integer, ByVal iHeight As Integer, ByVal bDepthBuffer As Boolean) As MTV3D65.TVRenderSurface
        Return _TVScene.CreateRenderSurface(iWidth, iHeight, bDepthBuffer, MTV3D65.CONST_TV_RENDERSURFACEFORMAT.TV_TEXTUREFORMAT_DEFAULT)
    End Function

    Public Function CreateMesh() As MTV3D65.TVMesh
        Return _TVScene.CreateMeshBuilder()
    End Function

    Public Function CreateLandScape(ByVal name As String) As MTV3D65.TVLandscape
        Return _TVScene.CreateLandscape(name)
    End Function

    Public Function MousePick(ByVal eObjectType As Integer) As MTV3D65.TVCollisionResult
        Dim x As Integer = clsInput.GetMouseAbsX
        Dim y As Integer = clsInput.GetMouseAbsY
        Dim col As MTV3D65.TVCollisionResult = _TVScene.MousePick(x, y, eObjectType, MTV3D65.CONST_TV_TESTTYPE.TV_TESTTYPE_ACCURATETESTING)
        Return col
    End Function

    Public Function AdvancedCollision(ByVal vecStart As MTV3D65.TV_3DVECTOR, ByVal vecEnd As MTV3D65.TV_3DVECTOR, ByVal eObjectType As Integer) As MTV3D65.TV_COLLISIONRESULT
        Dim res As MTV3D65.TV_COLLISIONRESULT
        _TVScene.AdvancedCollision(vecStart, vecEnd, res, eObjectType, MTV3D65.CONST_TV_TESTTYPE.TV_TESTTYPE_ACCURATETESTING, 1)
        Return res
    End Function

End Class

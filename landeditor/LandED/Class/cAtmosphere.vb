Public Class cAtmosphere
    Private _TVAtmosphere As MTV3D65.TVAtmosphere

    Public Sub Init()
        _TVAtmosphere = New MTV3D65.TVAtmosphere
        With _TVAtmosphere
            .SkySphere_Enable(True)
            .SkySphere_SetTexture(clsTexture.Add(sCorePath & "Media\SkySphere\Blue_Horizon.bmp"))
            .SkySphere_SetPolyCount(32)
        End With
    End Sub

    Public Sub Quit()
        _TVAtmosphere = Nothing
    End Sub

    Public Sub Render()
        _TVAtmosphere.SkySphere_Render()
    End Sub

End Class

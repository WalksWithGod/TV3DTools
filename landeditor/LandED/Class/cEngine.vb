Public Class cEngine
    Private _TVEngine As MTV3D65.TVEngine
    Private _nEngineLoaded As Boolean = False

    Public Sub Init()
        'Dim sUser As String = GetTV3DKey("LicenseUser", "Please enter your 'TV3D User Name'")
        'Dim sKey As String = GetTV3DKey("LicenseKey", "Please enter your 'Personal Beta Key'")
        _TVEngine = New MTV3D65.TVEngine
        With _TVEngine
            '.SetBetaKey(sUser, sKey)
            .SetAngleSystem(MTV3D65.CONST_TV_ANGLE.TV_ANGLE_DEGREE)
            .DisplayFPS(True)
            Dim frmRender As New fRender
            frmRender.Show()
            .Init3DWindowed(frmRender.picRender.Handle, True)
            clsFiles.File_Delete(sCorePath & "System\Debug.txt")
            .SetDebugMode(True)
            .SetDebugFile(sCorePath & "System\Debug.txt")
            .EnableProfiler(False)
        End With
        _nEngineLoaded = True
    End Sub

    Public Sub Quit()
        _TVEngine = Nothing
    End Sub

    Public Sub RenderBegin()
        _TVEngine.Clear()
    End Sub

    Public Sub RenderEnd()
        _TVEngine.RenderToScreen()
    End Sub

    Public Function GetTick() As Single
        Return _TVEngine.TimeElapsed
    End Function

    Public Function GetScreenWidth() As Integer
        Dim h As Integer, w As Integer, f As Integer
        _TVEngine.GetVideoMode(w, h, f)
        Return w
    End Function

    Public Function GetScreenHeight() As Integer
        Dim h As Integer, w As Integer, f As Integer
        _TVEngine.GetVideoMode(w, h, f)
        Return h
    End Function

    Public Function GetFPS() As Integer
        Return _TVEngine.GetFPS
    End Function

    Public Sub Resize()
        If _nEngineLoaded Then _TVEngine.ResizeDevice()
    End Sub

End Class

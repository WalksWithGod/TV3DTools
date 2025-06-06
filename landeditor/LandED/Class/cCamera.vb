Public Class cCamera
    Private _TVCamera As MTV3D65.TVCamera
    Private _fTurn As Single, _fTilt As Single
    Private _fPosX As Single
    Private _fPosY As Single = 10.0!
    Private _fPosZ As Single
    Private _fLookAtX As Single, _fLookAtY As Single, _fLookAtZ As Single
    Private _bWalk As Boolean
    Private _fFOV As Single = 60.0!
    Private _fDistance As Single = 3000.0!
    Private _fNear As Single = 0.1!

    Public Sub Init()
        _TVCamera = New MTV3D65.TVCamera
        _TVCamera.SetViewFrustum(_fFOV, _fDistance, _fNear)
    End Sub

    Public Sub Quit()
        _TVCamera = Nothing
    End Sub

    Public Sub Rotate(ByVal fTurn As Single, ByVal fTilt As Single)
        _fTurn += fTurn * 0.1!
        _fTilt += fTilt * 0.1!
        _TVCamera.SetRotation(_fTilt, _fTurn, 0)
    End Sub

    Public Sub Move(ByVal fForward As Single, ByVal fUp As Single, ByVal fLeft As Single, ByVal nFastMovement As Boolean)
        Dim fSpeed As Single

        ' Set movement speed
        If _bWalk Then
            If nFastMovement Then fSpeed = clsEngine.GetTick * 0.1! Else fSpeed = clsEngine.GetTick * 0.01!
        Else
            If nFastMovement Then fSpeed = clsEngine.GetTick * 0.5! Else fSpeed = clsEngine.GetTick * 0.05!
        End If

        ' The hell with this formula, using move and strafe at the same time!
        Dim fA1 As Single = CSng(_fTurn / 360.0! * Math.PI * 2.0!)
        Dim fA2 As Single = CSng((_fTurn + 90.0!) / 360.0! * Math.PI * 2.0!)
        _fPosZ += CSng((Math.Cos(fA1) * fSpeed * fLeft) + (Math.Cos(fA2) * fSpeed * fForward))
        _fPosX += CSng((Math.Sin(fA1) * fSpeed * fLeft) + (Math.Sin(fA2) * fSpeed * fForward))
        _fPosY += fSpeed * fUp

    End Sub

    Public Sub Update()
        If _bWalk Then _fPosY = clsLandManager.GetAltitude(_fPosX, _fPosZ) + 2
        _TVCamera.SetPosition(_fPosX, _fPosY, _fPosZ)
    End Sub

    Public Function GetMatrix() As MTV3D65.TV_3DMATRIX
        Return _TVCamera.GetMatrix()
    End Function

    Public Sub Walk(ByVal bWalk As Boolean)
        _bWalk = bWalk
    End Sub

    Public Function GetAngle() As Single
        Return _fTurn
    End Function

End Class

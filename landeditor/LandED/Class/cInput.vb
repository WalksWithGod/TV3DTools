Public Class cInput
    Private _TVInput As MTV3D65.TVInputEngine
    Private _iMouseAbsX As Integer, _iMouseAbsY As Integer
    Private _iMouseX As Integer, _iMouseY As Integer

    Public Sub Init()
        _TVInput = New MTV3D65.TVInputEngine
        _TVInput.Initialize(True, True)
    End Sub

    Public Sub Quit()
        _TVInput = Nothing
    End Sub

    Public Sub Update()
        Dim nMouse(4) As Boolean, iMouseRoll As Integer
        Dim _nShift As Boolean

        With _TVInput
            .GetAbsMouseState(_iMouseAbsX, _iMouseAbsY, nMouse(1), nMouse(2), nMouse(3), nMouse(4), iMouseRoll)
            .GetMouseState(_iMouseX, _iMouseY)

            ' Camera movement
            If .IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_LEFTSHIFT) Then
                _nShift = True
            ElseIf .IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_RIGHTSHIFT) Then
                _nShift = True
            Else
                _nShift = False
            End If
            If .IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_S) Then clsCamera.Move(0, 0, -1, _nShift)
            If .IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_W) Then clsCamera.Move(0, 0, 1, _nShift)
            If .IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_A) Then clsCamera.Move(-1, 0, 0, _nShift)
            If .IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_D) Then clsCamera.Move(1, 0, 0, _nShift)
            If .IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_E) Then clsCamera.Move(0, 1, 0, _nShift)
            If .IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_Q) Then clsCamera.Move(0, -1, 0, _nShift)
            If .IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_DOWNARROW) Then clsCamera.Move(0, 0, -1, _nShift)
            If .IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_UPARROW) Then clsCamera.Move(0, 0, 1, _nShift)
            If .IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_LEFTARROW) Then clsCamera.Move(-1, 0, 0, _nShift)
            If .IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_RIGHTARROW) Then clsCamera.Move(1, 0, 0, _nShift)
            If .IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_PAGEUP) Then clsCamera.Move(0, 1, 0, _nShift)
            If .IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_PAGEDOWN) Then clsCamera.Move(0, -1, 0, _nShift)

            ' Camera rotate / unselect
            If nMouse(2) Then clsCamera.Rotate(_iMouseX, _iMouseY)

            ' Select mouse over if not allready water locked
            If clsWaterManager.LockWater = False Then
                If clsBrush.BrushMode = cBrush.Enum_BrushMode.Mode_Select Then
                    clsWaterManager.CheckSelection()
                End If
            End If

            ' Select / brush / move
            If nMouse(1) Then
                Select Case clsBrush.BrushMode
                    Case cBrush.Enum_BrushMode.Mode_Select
                        clsWaterManager.LockWater = True
                        clsWaterManager.MoveSelected(_iMouseX, _iMouseY, _nShift)
                    Case cBrush.Enum_BrushMode.Mode_Decrease
                        clsBrush.DecreaseAltitude()
                    Case cBrush.Enum_BrushMode.Mode_Increase
                        clsBrush.IncreaseAltitude()
                    Case cBrush.Enum_BrushMode.Mode_Manual
                        clsBrush.LockPointers(True)
                        clsBrush.ManualAltitude(_iMouseY)
                    Case cBrush.Enum_BrushMode.Mode_Flatten
                        clsBrush.LockPointers(True)
                        clsBrush.FlattenAltitude()
                    Case cBrush.Enum_BrushMode.Mode_Smooth
                        clsBrush.SmoothAltitude()
                    Case cBrush.Enum_BrushMode.Mode_Paint
                        clsBrush.Paint()
                End Select
            Else
                clsBrush.LockPointers(False)
                clsWaterManager.LockWater = False
            End If

        End With
    End Sub

    Public Function GetMouseAbsX() As Integer
        Return _iMouseAbsX
    End Function

    Public Function GetMouseAbsY() As Integer
        Return _iMouseAbsY
    End Function

End Class

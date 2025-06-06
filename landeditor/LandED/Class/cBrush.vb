Public Class cBrush

    Public Enum Enum_BrushSize
        Size_Single
        Size_Small
        Size_Medium
        Size_Large
    End Enum

    Public Enum Enum_BrushMode
        Mode_Nothing
        Mode_Increase
        Mode_Decrease
        Mode_Flatten
        Mode_Manual
        Mode_Select
        Mode_Smooth
        Mode_Paint
    End Enum

    Public Enum Enum_BrushShape
        Shape_Square
        Shape_Circle
        Shape_LineWE
        Shape_LineNS
    End Enum

    ' Modes
    Private _eBrushSize As Enum_BrushSize = Enum_BrushSize.Size_Single
    Private _eBrushMode As Enum_BrushMode = Enum_BrushMode.Mode_Nothing
    Private _eBrushShape As Enum_BrushShape = Enum_BrushShape.Shape_Square

    ' Brush
    Private _fBrushStep As Single = 0.1
    Private _fBrushOpacity As Single = 1
    Private _fBrushFlatten As Single = 0

    ' Pointers
    Private _meshPointer(24) As MTV3D65.TVMesh
    Private _nPointersLocked As Boolean

    ' Timers to update pointer (collision delay)
    Private _fTimer As Single
    Private Const _MaxTimer As Single = 100

    ' For paintbrush
    Private _sLayerSelected As String
    Private _sLandSelected As String

    Public Sub Init()

        ' The pointers are the round thingies that helps the user to adjust the altitude of a vertex
        _meshPointer(0) = clsScene.CreateMesh()
        With _meshPointer(0)
            .SetLightingMode(MTV3D65.CONST_TV_LIGHTINGMODE.TV_LIGHTING_MANAGED)
            .CreateSphere(0.3, 8, 8)
            .Enable(False)
            .SetMaterial(clsMaterials.GetMaterialFromName("brushmiddle"))
            .SetCullMode(MTV3D65.CONST_TV_CULLING.TV_BACK_CULL)
            .ComputeNormals()
            .ComputeBoundings()
            .ComputeOctree()
            .SetCollisionEnable(False)
        End With
        For i As Integer = 1 To 24
            _meshPointer(i) = _meshPointer(0).Duplicate
            _meshPointer(i).SetMaterial(clsMaterials.GetMaterialFromName("brusharound"))
        Next

    End Sub

    Public Sub Quit()
        For i As Integer = 0 To 24
            _meshPointer(i) = Nothing
        Next
    End Sub

    Public Sub Update()
        Dim fX As Single, fZ As Single

        ' Reset Pointers
        Pointers_Reset()

        ' Check if we can move the pointers (manual alt. = no)
        If _nPointersLocked = False Then

            ' Get mouse collision 
            Dim col As MTV3D65.TVCollisionResult
            col = clsScene.MousePick(2)

            ' ...with landscape
            If col.IsCollision Then

                ' Place depending the brush
                Select Case BrushMode
                    Case Enum_BrushMode.Mode_Paint
                        fX = CInt(col.GetCollisionImpact.x) + 0.5!
                        fZ = CInt(col.GetCollisionImpact.z) + 0.5!
                        Pointers_SetPosition(fX, fZ)
                    Case Else
                        fX = CInt(col.GetCollisionImpact.x / 4) * 4
                        fZ = CInt(col.GetCollisionImpact.z / 4) * 4
                        Pointers_SetPosition(CInt(fX), CInt(fZ))
                End Select

            Else

                ' No collision
                Pointers_DisableAll()

            End If
        End If

        ' Now theyre placed, just set the altitude
        Pointers_CheckAltitude()

    End Sub

    Public Sub Render()
        For i As Integer = 0 To 24
            _meshPointer(i).Render()
        Next
    End Sub

    Private Sub Pointers_SetPosition(ByVal X As Single, ByVal Z As Single)
        Dim vPointer(24) As MTV3D65.TV_3DVECTOR
        Dim fDistance As Single = 0

        ' Set distance between pointers
        Select Case BrushMode
            Case Enum_BrushMode.Mode_Paint
                fDistance = 1.0!
            Case Else
                fDistance = 4.0!
        End Select

        ' Set center Pointer
        With vPointer(0)
            .x = X
            .z = Z
        End With

        ' Set other Pointers - Small
        If _eBrushSize = Enum_BrushSize.Size_Small Or _eBrushSize = Enum_BrushSize.Size_Medium Or _eBrushSize = Enum_BrushSize.Size_Large Then
            Select Case _eBrushShape
                Case Enum_BrushShape.Shape_Square
                    vPointer(1).x = X + fDistance
                    vPointer(1).z = Z
                    vPointer(2).x = X + fDistance
                    vPointer(2).z = Z + fDistance
                    vPointer(3).x = X
                    vPointer(3).z = Z + fDistance
                Case Enum_BrushShape.Shape_Circle
                    vPointer(1).x = X - fDistance
                    vPointer(1).z = Z
                    vPointer(2).x = X
                    vPointer(2).z = Z - fDistance
                    vPointer(3).x = X + fDistance
                    vPointer(3).z = Z
                    vPointer(4).x = X
                    vPointer(4).z = Z + fDistance
                Case Enum_BrushShape.Shape_LineNS
                    vPointer(1).x = X + fDistance
                    vPointer(1).z = Z
                Case Enum_BrushShape.Shape_LineWE
                    vPointer(1).x = X
                    vPointer(1).z = Z + fDistance
            End Select
        End If

        ' Set other Pointers - Medium
        If _eBrushSize = Enum_BrushSize.Size_Medium Or _eBrushSize = Enum_BrushSize.Size_Large Then
            Select Case _eBrushShape
                Case Enum_BrushShape.Shape_Square
                    vPointer(4).x = X - fDistance
                    vPointer(4).z = Z + fDistance
                    vPointer(5).x = X - fDistance
                    vPointer(5).z = Z
                    vPointer(6).x = X - fDistance
                    vPointer(6).z = Z - fDistance
                    vPointer(7).x = X
                    vPointer(7).z = Z - fDistance
                    vPointer(8).x = X + fDistance
                    vPointer(8).z = Z - fDistance
                Case Enum_BrushShape.Shape_Circle
                    vPointer(5).x = X + fDistance
                    vPointer(5).z = Z - fDistance
                    vPointer(6).x = X + (2 * fDistance)
                    vPointer(6).z = Z
                    vPointer(7).x = X + (2 * fDistance)
                    vPointer(7).z = Z + fDistance
                    vPointer(8).x = X + fDistance
                    vPointer(8).z = Z + fDistance
                    vPointer(9).x = X + fDistance
                    vPointer(9).z = Z + (2 * fDistance)
                    vPointer(10).x = X
                    vPointer(10).z = Z + (2 * fDistance)
                    vPointer(11).x = X - fDistance
                    vPointer(11).z = Z + fDistance
                Case Enum_BrushShape.Shape_LineNS
                    vPointer(2).x = X - fDistance
                    vPointer(2).z = Z
                Case Enum_BrushShape.Shape_LineWE
                    vPointer(2).x = X
                    vPointer(2).z = Z - fDistance
            End Select
        End If

        ' Set other Pointers - Large
        If _eBrushSize = Enum_BrushSize.Size_Large Then
            Select Case _eBrushShape
                Case Enum_BrushShape.Shape_Square
                    vPointer(9).x = X + (2 * fDistance)
                    vPointer(9).z = Z - fDistance
                    vPointer(10).x = X + (2 * fDistance)
                    vPointer(10).z = Z
                    vPointer(11).x = X + (2 * fDistance)
                    vPointer(11).z = Z + fDistance
                    vPointer(12).x = X + (2 * fDistance)
                    vPointer(12).z = Z + (2 * fDistance)
                    vPointer(13).x = X + fDistance
                    vPointer(13).z = Z + (2 * fDistance)
                    vPointer(14).x = X
                    vPointer(14).z = Z + (2 * fDistance)
                    vPointer(15).x = X - fDistance
                    vPointer(15).z = Z + (2 * fDistance)
                    vPointer(16).x = X - (2 * fDistance)
                    vPointer(16).z = Z + (2 * fDistance)
                    vPointer(17).x = X - (2 * fDistance)
                    vPointer(17).z = Z + fDistance
                    vPointer(18).x = X - (2 * fDistance)
                    vPointer(18).z = Z
                    vPointer(19).x = X - (2 * fDistance)
                    vPointer(19).z = Z - fDistance
                    vPointer(20).x = X - (2 * fDistance)
                    vPointer(20).z = Z - (2 * fDistance)
                    vPointer(21).x = X - fDistance
                    vPointer(21).z = Z - (2 * fDistance)
                    vPointer(22).x = X
                    vPointer(22).z = Z - (2 * fDistance)
                    vPointer(23).x = X + fDistance
                    vPointer(23).z = Z - (2 * fDistance)
                    vPointer(24).x = X + (2 * fDistance)
                    vPointer(24).z = Z - (2 * fDistance)
                Case Enum_BrushShape.Shape_Circle
                    vPointer(12).x = X - fDistance
                    vPointer(12).z = Z + (2 * fDistance)
                    vPointer(13).x = X - (2 * fDistance)
                    vPointer(13).z = Z + fDistance
                    vPointer(14).x = X - (2 * fDistance)
                    vPointer(14).z = Z
                    vPointer(15).x = X - (2 * fDistance)
                    vPointer(15).z = Z - fDistance
                    vPointer(16).x = X - fDistance
                    vPointer(16).z = Z - fDistance
                    vPointer(17).x = X - fDistance
                    vPointer(17).z = Z - (2 * fDistance)
                    vPointer(18).x = X
                    vPointer(18).z = Z - (2 * fDistance)
                    vPointer(19).x = X + fDistance
                    vPointer(19).z = Z - (2 * fDistance)
                    vPointer(20).x = X + (2 * fDistance)
                    vPointer(20).z = Z - fDistance
                Case Enum_BrushShape.Shape_LineNS
                    vPointer(3).x = X + (2 * fDistance)
                    vPointer(3).z = Z
                Case Enum_BrushShape.Shape_LineWE
                    vPointer(3).x = X
                    vPointer(3).z = Z + (2 * fDistance)
            End Select
        End If

        ' Place mesh
        For i As Integer = 0 To 24
            With vPointer(i)
                _meshPointer(i).SetPosition(.x, 0, .z)
            End With
        Next

    End Sub

    Private Sub Pointers_CheckAltitude()
        Dim res As MTV3D65.TV_COLLISIONRESULT
        Dim vStart As MTV3D65.TV_3DVECTOR, vEnd As MTV3D65.TV_3DVECTOR
        For i As Integer = 0 To 24

            ' Update only enabled pointers
            If _meshPointer(i).IsEnabled Then
                vStart = _meshPointer(i).GetPosition
                vEnd = _meshPointer(i).GetPosition
                vStart.y = 1000
                vEnd.y = -1000

                ' Check if collision with landscape
                res = clsScene.AdvancedCollision(vStart, vEnd, MTV3D65.CONST_TV_OBJECT_TYPE.TV_OBJECT_LANDSCAPE)
                If res.bHasCollided Then

                    ' Collided, hten its over a landscape
                    _meshPointer(i).SetPosition(res.vCollisionImpact.x, res.vCollisionImpact.y, res.vCollisionImpact.z)

                Else

                    ' No collision, Pointer is floating in the nothingness, dont render
                    _meshPointer(i).Enable(False)

                End If
            End If
        Next
    End Sub

    Private Sub Pointers_DisableAll()
        For i As Integer = 0 To 24
            _meshPointer(i).Enable(False)
        Next
    End Sub

    Private Sub Pointers_Reset()
        Dim i As Integer

        ' Disable all
        For i = 0 To 24 : _meshPointer(i).Enable(False) : Next

        ' Enable used Pointers depending on the form
        Select Case _eBrushMode
            Case Enum_BrushMode.Mode_Select
            Case Enum_BrushMode.Mode_Nothing
            Case Enum_BrushMode.Mode_Paint
                Select Case _eBrushSize
                    Case Enum_BrushSize.Size_Single
                        _meshPointer(0).Enable(True)
                    Case Enum_BrushSize.Size_Small
                        Select Case _eBrushShape
                            Case Enum_BrushShape.Shape_Square
                                For i = 0 To 3 : _meshPointer(i).Enable(True) : Next
                            Case Enum_BrushShape.Shape_Circle
                                For i = 0 To 4 : _meshPointer(i).Enable(True) : Next
                            Case Enum_BrushShape.Shape_LineNS
                                For i = 0 To 1 : _meshPointer(i).Enable(True) : Next
                            Case Enum_BrushShape.Shape_LineWE
                                For i = 0 To 1 : _meshPointer(i).Enable(True) : Next
                        End Select
                    Case Enum_BrushSize.Size_Medium
                        Select Case _eBrushShape
                            Case Enum_BrushShape.Shape_Square
                                For i = 0 To 8 : _meshPointer(i).Enable(True) : Next
                            Case Enum_BrushShape.Shape_Circle
                                For i = 0 To 11 : _meshPointer(i).Enable(True) : Next
                            Case Enum_BrushShape.Shape_LineNS
                                For i = 0 To 2 : _meshPointer(i).Enable(True) : Next
                            Case Enum_BrushShape.Shape_LineWE
                                For i = 0 To 2 : _meshPointer(i).Enable(True) : Next
                        End Select
                    Case Enum_BrushSize.Size_Large
                        Select Case _eBrushShape
                            Case Enum_BrushShape.Shape_Square
                                For i = 0 To 15 : _meshPointer(i).Enable(True) : Next
                            Case Enum_BrushShape.Shape_Circle
                                For i = 0 To 20 : _meshPointer(i).Enable(True) : Next
                            Case Enum_BrushShape.Shape_LineNS
                                For i = 0 To 3 : _meshPointer(i).Enable(True) : Next
                            Case Enum_BrushShape.Shape_LineWE
                                For i = 0 To 3 : _meshPointer(i).Enable(True) : Next
                        End Select
                End Select
            Case Else
                Select Case _eBrushSize
                    Case Enum_BrushSize.Size_Single
                        _meshPointer(0).Enable(True)
                    Case Enum_BrushSize.Size_Small
                        Select Case _eBrushShape
                            Case Enum_BrushShape.Shape_Square
                                For i = 0 To 3 : _meshPointer(i).Enable(True) : Next
                            Case Enum_BrushShape.Shape_Circle
                                For i = 0 To 4 : _meshPointer(i).Enable(True) : Next
                            Case Enum_BrushShape.Shape_LineNS
                                For i = 0 To 1 : _meshPointer(i).Enable(True) : Next
                            Case Enum_BrushShape.Shape_LineWE
                                For i = 0 To 1 : _meshPointer(i).Enable(True) : Next
                        End Select
                    Case Enum_BrushSize.Size_Medium
                        Select Case _eBrushShape
                            Case Enum_BrushShape.Shape_Square
                                For i = 0 To 8 : _meshPointer(i).Enable(True) : Next
                            Case Enum_BrushShape.Shape_Circle
                                For i = 0 To 11 : _meshPointer(i).Enable(True) : Next
                            Case Enum_BrushShape.Shape_LineNS
                                For i = 0 To 2 : _meshPointer(i).Enable(True) : Next
                            Case Enum_BrushShape.Shape_LineWE
                                For i = 0 To 2 : _meshPointer(i).Enable(True) : Next
                        End Select
                    Case Enum_BrushSize.Size_Large
                        Select Case _eBrushShape
                            Case Enum_BrushShape.Shape_Square
                                For i = 0 To 24 : _meshPointer(i).Enable(True) : Next
                            Case Enum_BrushShape.Shape_Circle
                                For i = 0 To 20 : _meshPointer(i).Enable(True) : Next
                            Case Enum_BrushShape.Shape_LineNS
                                For i = 0 To 3 : _meshPointer(i).Enable(True) : Next
                            Case Enum_BrushShape.Shape_LineWE
                                For i = 0 To 3 : _meshPointer(i).Enable(True) : Next
                        End Select
                End Select
        End Select

    End Sub

    Public Property BrushSize() As Enum_BrushSize
        Get
            Return _eBrushSize
        End Get
        Set(ByVal value As Enum_BrushSize)
            _eBrushSize = value
        End Set
    End Property

    Public Property BrushMode() As Enum_BrushMode
        Get
            Return _eBrushMode
        End Get
        Set(ByVal value As Enum_BrushMode)
            _eBrushMode = value
        End Set
    End Property

    Public Property BrushShape() As Enum_BrushShape
        Get
            Return _eBrushShape
        End Get
        Set(ByVal value As Enum_BrushShape)
            _eBrushShape = value
        End Set
    End Property

    Public Property BrushStep() As Single
        Get
            Return _fBrushStep
        End Get
        Set(ByVal value As Single)
            _fBrushStep = value
        End Set
    End Property

    Public Property BrushOpacity() As Single
        Get
            Return _fBrushOpacity
        End Get
        Set(ByVal value As Single)
            _fBrushOpacity = value
        End Set
    End Property

    Public Property BrushFlatten() As Single
        Get
            Return _fBrushFlatten
        End Get
        Set(ByVal value As Single)
            _fBrushFlatten = value
        End Set
    End Property

    Public Sub IncreaseAltitude()
        Dim fX As Single, fY As Single, fZ As Single
        For i As Integer = 0 To 24
            If _meshPointer(i).IsEnabled Then
                fX = _meshPointer(i).GetPosition.x
                fZ = _meshPointer(i).GetPosition.z
                fY = _meshPointer(i).GetPosition.y + (_fBrushStep * clsEngine.GetTick * 0.01!)
                clsLandManager.AdjustAltitude(fX, fY, fZ)
            End If
        Next
    End Sub

    Public Sub DecreaseAltitude()
        Dim fX As Single, fY As Single, fZ As Single
        For i As Integer = 0 To 24
            If _meshPointer(i).IsEnabled Then
                fX = _meshPointer(i).GetPosition.x
                fZ = _meshPointer(i).GetPosition.z
                fY = _meshPointer(i).GetPosition.y - (_fBrushStep * clsEngine.GetTick * 0.01!)
                clsLandManager.AdjustAltitude(fX, fY, fZ)
            End If
        Next
    End Sub

    Public Sub FlattenAltitude()
        Dim fX As Single, fY As Single, fZ As Single
        For i As Integer = 0 To 24
            If _meshPointer(i).IsEnabled Then
                fX = _meshPointer(i).GetPosition.x
                fZ = _meshPointer(i).GetPosition.z
                fY = _fBrushFlatten
                clsLandManager.AdjustAltitude(fX, fY, fZ)
            End If
        Next
    End Sub

    Public Sub ManualAltitude(ByVal fAdjust As Single)
        Dim fX As Single, fY As Single, fZ As Single
        For i As Integer = 0 To 24
            If _meshPointer(i).IsEnabled Then
                fX = _meshPointer(i).GetPosition.x
                fZ = _meshPointer(i).GetPosition.z
                fY = CSng(_meshPointer(i).GetPosition.y - (fAdjust * _fBrushStep * clsEngine.GetTick * 0.001))
                clsLandManager.AdjustAltitude(fX, fY, fZ)
            End If
        Next
    End Sub

    Public Sub SmoothAltitude()
        Dim fX As Single, fY As Single, fZ As Single
        Dim iEnabled As Integer
        Dim fTotalAltitude As Single

        ' Calculate the average altitude
        For i As Integer = 0 To 24
            If _meshPointer(i).IsEnabled Then
                iEnabled += 1
                fTotalAltitude += _meshPointer(i).GetPosition.y
            End If
        Next
        Dim fAverage As Single = fTotalAltitude / iEnabled

        ' Apply
        For i As Integer = 0 To 24
            If _meshPointer(i).IsEnabled Then
                fX = _meshPointer(i).GetPosition.x
                fZ = _meshPointer(i).GetPosition.z
                fY = CSng((_fBrushStep * clsEngine.GetTick * 0.001 * (fAverage - _meshPointer(i).GetPosition.y)) + _meshPointer(i).GetPosition.y)
                clsLandManager.AdjustAltitude(fX, fY, fZ)
            End If
        Next

    End Sub

    Public Sub LockPointers(ByVal nLocked As Boolean)
        _nPointersLocked = nLocked
    End Sub

    Public Function Pointer_IsEnabled(ByVal iPointer As Integer) As Boolean
        Return _meshPointer(iPointer).IsEnabled
    End Function

    Public Function Pointer_GetPosition(ByVal iPointer As Integer) As MTV3D65.TV_3DVECTOR
        Return _meshPointer(iPointer).GetPosition
    End Function

    Public Function GetSelectedLandscape() As String
        Return _sLandSelected
    End Function

    Public Function GetSelectedLayer() As String
        Return _sLayerSelected
    End Function

    Public Sub PaintSelect(ByVal sLandscape As String, ByVal sLayer As String)
        _sLandSelected = sLandscape
        _sLayerSelected = sLayer
    End Sub

    Public Sub Paint()

        ' Check if layer selected
        If _sLandSelected = "" Or _sLayerSelected = "" Then
            MsgBox("You need to select a layer to paint on first!")
        Else

            ' Select texture to paint alpha
            Dim iAlpha As Integer = clsLandManager.Splatting_GetAlpha(_sLandSelected, _sLayerSelected)

            ' Set color of main pointer
            Dim iColor As Integer = clsGlobals.GetColor(0, 0, 0, _fBrushOpacity)

            ' Paint
            For i As Integer = 0 To 24
                If _meshPointer(i).IsEnabled Then clsTexture.SetPixel(iAlpha, CInt(_meshPointer(i).GetPosition.x - 0.5!), CInt(_meshPointer(i).GetPosition.z + 0.5!), iColor)
            Next

            ' Re-apply texture
            clsLandManager.Splatting_RefreshAlpha(_sLandSelected, _sLayerSelected)

        End If

    End Sub

End Class

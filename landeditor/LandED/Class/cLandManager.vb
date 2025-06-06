Public Class cLandManager
    Private _colLand As Collection

    Public Sub Init()
        _colLand = New Collection
    End Sub

    Public Sub Quit()
        For Each inst As cLandscape In _colLand
            inst.Quit()
            inst = Nothing
        Next
        _colLand = Nothing
    End Sub

    Public Sub Render()
        For Each inst As cLandscape In _colLand
            inst.Render()
        Next
    End Sub

    Public Sub Save()
        Dim sFile As String = sProjectPath & "\Landscapes.txt"

        ' Fill new file
        For Each inst As cLandscape In _colLand
            clsFiles.File_InsertLine(sFile, inst.GetName)
        Next

        ' Save each Landscape
        For Each inst As cLandscape In _colLand
            inst.Save()
        Next

    End Sub

    Public Sub Load()

        ' Make sure file exists
        If clsFiles.File_CheckExist(sProjectPath & "\Landscapes.txt") Then

            ' Read file
            Dim sFile() As String = clsFiles.File_Read(sProjectPath & "\Landscapes.txt")

            ' Load Landscapes
            For i As Integer = 0 To UBound(sFile)
                If sFile(i) <> "" Then
                    Dim inst As New cLandscape
                    inst.Load(sProjectPath & sFile(i) & "\")
                    _colLand.Add(inst, sFile(i))
                End If
            Next
        End If

    End Sub

    Public Function GetList() As String()
        Dim sList() As String = Nothing, i As Integer = -1
        If _colLand.Count > 0 Then
            For Each inst As cLandscape In _colLand
                i += 1
                ReDim Preserve sList(i)
                sList(i) = inst.GetName
            Next
        End If
        Return sList
    End Function

    Public Function CheckAvailable(ByVal sName As String) As Boolean
        Dim bAvailable As Boolean = True
        If _colLand.Count > 0 Then
            For Each inst As cLandscape In _colLand
                If inst.GetName = sName Then bAvailable = False
            Next
        End If
        Return bAvailable
    End Function

    Public Function GetName(ByVal fPosX As Single, ByVal fPosZ As Single) As String
        Dim sName As String = ""
        For Each inst As cLandscape In _colLand
            If inst.CheckInbound(fPosX, fPosZ) Then sName = inst.GetName
        Next
        Return sName
    End Function

    Public Sub AddFlat(ByVal sName As String)
        Dim inst As New cLandscape
        inst.AddFlat(sName)
        _colLand.Add(inst, sName)
    End Sub

    Public Sub ImportTVM(ByVal sName As String, ByVal sFile As String)
        Dim inst As New cLandscape
        inst.ImportTVM(sName, sFile)
        _colLand.Add(inst, sName)
    End Sub

    Public Sub Generate(ByVal sName As String, ByVal sFile As String, ByVal eAffine As MTV3D65.CONST_TV_LANDSCAPE_AFFINE)
        Dim inst As New cLandscape
        inst.Generate(sName, sFile, eAffine)
        _colLand.Add(inst, sName)
    End Sub

    Public Sub Remove(ByVal sLandscape As String)
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then
                inst.Quit()
                inst = Nothing
            End If
        Next
        _colLand.Remove(sLandscape)
    End Sub

    Public Sub ExportTVM(ByVal sLandscape As String)
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then inst.ExportTVM()
        Next
    End Sub

    Public Sub ExportBMP(ByVal sLandscape As String)
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then inst.ExportBMP()
        Next
    End Sub

    Public Function CheckOverlap() As String
        For Each inst As cLandscape In _colLand
            Dim sLandscape As String = CStr(IsLandscapeOverlap(inst.GetName, inst.GetPositionX, inst.GetPositionZ))
            If sLandscape <> "" Then
                Return "Error! Landscapes overlapping: " & Chr(13) & "  " & inst.GetName & Chr(13) & "  " & sLandscape
                Exit Function
            End If
        Next
        CheckOverlap = Nothing
    End Function

    Private Function IsLandscapeOverlap(ByVal sLandscape As String, ByVal fX As Single, ByVal fZ As Single) As String
        Dim sOverlap As String = ""
        For Each inst As cLandscape In _colLand
            If inst.GetName <> sLandscape Then
                If fX = inst.GetPositionX And fZ = inst.GetPositionZ Then sOverlap = inst.GetName
            End If
        Next
        Return sOverlap
    End Function

    Public Function GetMaterial(ByVal sLandscape As String) As Integer
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then Return inst.GetMaterial
        Next
    End Function

    Public Sub SetMaterial(ByVal sLandscape As String, ByVal iMaterial As Integer)
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then inst.SetMaterial(iMaterial)
        Next
    End Sub

    Public Sub SetEnabled(ByVal sLandscape As String, ByVal bEnabled As Boolean)
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then inst.SetEnabled(bEnabled)
        Next
    End Sub

    Public Function GetEnabled(ByVal sLandscape As String) As Boolean
        Dim bEnabled As Boolean = False
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then bEnabled = inst.GetEnabled
        Next
        Return bEnabled
    End Function

    Public Function GetScale(ByVal sLandscape As String) As Single
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then Return inst.GetScale
        Next
    End Function

    Public Sub SetScale(ByVal sLandscape As String, ByVal fScale As Single)
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then inst.SetScale(fScale)
        Next
    End Sub

    Public Function GetPositionX(ByVal sLandscape As String) As Single
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then Return inst.GetPositionX
        Next
    End Function

    Public Function GetPositionZ(ByVal sLandscape As String) As Single
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then Return inst.GetPositionZ
        Next
    End Function

    Public Sub SetPositionX(ByVal sLandscape As String, ByVal fPosition As Single)
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then inst.SetPositionX(fPosition)
        Next
    End Sub

    Public Sub SetPositionZ(ByVal sLandscape As String, ByVal fPosition As Single)
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then inst.SetPositionZ(fPosition)
        Next
    End Sub

    Public Function GetSurrounding(ByVal sLandscape As String) As String()
        Dim sSurround() As String = Nothing
        Dim i As Integer = -1, X As Single, Z As Single

        ' Get Landscape's position
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then
                X = inst.GetPositionX
                Z = inst.GetPositionZ
            End If
        Next

        ' Check surround
        For Each inst As cLandscape In _colLand
            If inst.GetName <> sLandscape Then

                ' Is surround?
                Dim bSurround As Boolean = False

                ' Check West / East / North / South
                If inst.GetPositionX = X - 256 And inst.GetPositionZ = Z Then bSurround = True
                If inst.GetPositionX = X + 256 And inst.GetPositionZ = Z Then bSurround = True
                If inst.GetPositionX = X And inst.GetPositionZ = Z + 256 Then bSurround = True
                If inst.GetPositionX = X And inst.GetPositionZ = Z - 256 Then bSurround = True

                ' Add
                If bSurround Then
                    i += 1
                    ReDim Preserve sSurround(i)
                    sSurround(i) = inst.GetName
                End If

            End If
        Next

        ' Return
        Return sSurround

    End Function

    Public Sub Smudge(ByVal sLandscapeA As String, ByVal sLandscapeB As String, ByVal iStrength As Integer)
        Dim fPosXLandA As Single, fPosZLandA As Single
        Dim fPosXLandB As Single, fPosZLandB As Single
        Dim sSide As String = ""
        Dim fX As Single, fZ As Single
        Dim fY1 As Single, fY2 As Single, fY3 As Single, fYNew As Single

        ' Progress
        Dim iProgress As Integer
        Dim iTimer As Integer      

        ' Calculate maximum
        Dim iMax As Integer
        For iZ As Integer = 0 To iStrength Step 4
            For iX As Integer = 0 To 256 Step 4
                iMax += 1
            Next
        Next

        ' Set progress form
        Dim frmProgress As New fProgress
        frmProgress.proBar.Maximum = iMax
        frmProgress.Show()

        ' Get LandA position
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscapeA Then
                fPosXLandA = inst.GetPositionX
                fPosZLandA = inst.GetPositionZ
            End If
        Next

        ' Get LandB position
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscapeB Then
                fPosXLandB = inst.GetPositionX
                fPosZLandB = inst.GetPositionZ
            End If
        Next

        ' Check position from LandA => LandB
        If fPosXLandB - fPosXLandA = 256 And fPosZLandB - fPosZLandA = 0 Then sSide = "EAST"
        If fPosXLandB - fPosXLandA = -256 And fPosZLandB - fPosZLandA = 0 Then sSide = "WEST"
        If fPosXLandB - fPosXLandA = 0 And fPosZLandB - fPosZLandA = 256 Then sSide = "NORTH"
        If fPosXLandB - fPosXLandA = 0 And fPosZLandB - fPosZLandA = -256 Then sSide = "SOUTH"

        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscapeA Then
                Select Case sSide
                    Case "NORTH"
                        For iZ As Integer = 0 To iStrength Step 4 ' Deepness
                            For iX As Integer = 0 To 256 Step 4 ' Each vertex

                                ' Calculate smudge sength factor
                                Dim fFactor As Single = CSng((iStrength - iZ) / iStrength)

                                ' Set vertex
                                For Each instB As cLandscape In _colLand
                                    If instB.GetName = sLandscapeB Then

                                        ' Progress
                                        iProgress += 1
                                        iTimer += 1
                                        If iTimer > 64 Then
                                            iTimer = 0
                                            frmProgress.proBar.Value = iProgress
                                        End If

                                        ' Get altitude
                                        fX = inst.GetPositionX + iX
                                        fZ = inst.GetPositionZ + 256 + iZ
                                        fY1 = inst.GetAltitude(fX, fZ)
                                        fY2 = instB.GetAltitude(fX, fZ)
                                        fY3 = fY1 - fY2

                                        ' Calculate and set new altitude
                                        fYNew = fY2 + (fY3 * fFactor)
                                        instB.SetAltitude(fX, fYNew, fZ)

                                    End If
                                Next
                            Next
                        Next

                    Case "SOUTH"
                        For iZ As Integer = 0 To iStrength Step 4 ' Deepness
                            For iX As Integer = 0 To 256 Step 4 ' Each vertex

                                ' Calculate smudge sength factor
                                Dim fFactor As Single = CSng((iStrength - iZ) / iStrength)

                                ' Set vertex
                                For Each instB As cLandscape In _colLand
                                    If instB.GetName = sLandscapeB Then

                                        ' Progress
                                        iProgress += 1
                                        iTimer += 1
                                        If iTimer > 64 Then
                                            iTimer = 0
                                            frmProgress.proBar.Value = iProgress
                                        End If

                                        ' Get altitude
                                        fX = inst.GetPositionX + iX
                                        fZ = inst.GetPositionZ - iZ
                                        fY1 = inst.GetAltitude(fX, fZ)
                                        fY2 = instB.GetAltitude(fX, fZ)
                                        fY3 = fY1 - fY2

                                        ' Calculate and set new altitude
                                        fYNew = fY2 + (fY3 * fFactor)
                                        instB.SetAltitude(fX, fYNew, fZ)

                                    End If
                                Next
                            Next
                        Next

                    Case "EAST"
                        For iX As Integer = 0 To iStrength Step 4 ' Deepness
                            For iZ As Integer = 0 To 256 Step 4 ' Each vertex

                                ' Calculate smudge sength factor
                                Dim fFactor As Single = CSng((iStrength - iX) / iStrength)

                                ' Set vertex
                                For Each instB As cLandscape In _colLand
                                    If instB.GetName = sLandscapeB Then

                                        ' Progress
                                        iProgress += 1
                                        iTimer += 1
                                        If iTimer > 64 Then
                                            iTimer = 0
                                            frmProgress.proBar.Value = iProgress
                                        End If

                                        ' Get altitude
                                        fX = inst.GetPositionX + 256 + iX
                                        fZ = inst.GetPositionZ + iZ
                                        fY1 = inst.GetAltitude(fX, fZ)
                                        fY2 = instB.GetAltitude(fX, fZ)
                                        fY3 = fY1 - fY2

                                        ' Calculate and set new altitude
                                        fYNew = fY2 + (fY3 * fFactor)
                                        instB.SetAltitude(fX, fYNew, fZ)

                                    End If
                                Next
                            Next
                        Next

                    Case "WEST"

                        For iX As Integer = 0 To iStrength Step 4 ' Deepness
                            For iZ As Integer = 0 To 256 Step 4 ' Each vertex

                                ' Calculate smudge sength factor
                                Dim fFactor As Single = CSng((iStrength - iX) / iStrength)

                                ' Set vertex
                                For Each instB As cLandscape In _colLand
                                    If instB.GetName = sLandscapeB Then

                                        ' Progress
                                        iProgress += 1
                                        iTimer += 1
                                        If iTimer > 64 Then
                                            iTimer = 0
                                            frmProgress.proBar.Value = iProgress
                                        End If

                                        ' Get altitude
                                        fX = inst.GetPositionX - iX
                                        fZ = inst.GetPositionZ + iZ
                                        fY1 = inst.GetAltitude(fX, fZ)
                                        fY2 = instB.GetAltitude(fX, fZ)
                                        fY3 = fY1 - fY2

                                        ' Calculate and set new altitude
                                        fYNew = fY2 + (fY3 * fFactor)
                                        instB.SetAltitude(fX, fYNew, fZ)

                                    End If
                                Next
                            Next
                        Next

                End Select

            End If
        Next

        ' Recalculate normals
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscapeA Then inst.RefreshNormals()
        Next
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscapeB Then inst.RefreshNormals()
        Next

        ' Unload
        frmProgress.Close()
        frmProgress = Nothing

    End Sub

    Public Sub AdjustAltitude(ByVal fX As Single, ByVal fY As Single, ByVal fZ As Single)
        For Each inst As cLandscape In _colLand
            If inst.CheckInbound(fX, fZ) Then
                inst.SetAltitude(fX, fY, fZ)
            End If
        Next
    End Sub

    Public Function GetAltitude(ByVal fX As Single, ByVal fZ As Single) As Single
        For Each inst As cLandscape In _colLand
            If inst.CheckInbound(fX, fZ) Then Return inst.GetAltitude(fX, fZ)
        Next
    End Function

    Public Function GetNormal(ByVal fX As Single, ByVal fZ As Single) As MTV3D65.TV_3DVECTOR
        For Each inst As cLandscape In _colLand
            If inst.CheckInbound(fX, fZ) Then Return inst.GetNormal(fX, fZ)
        Next
    End Function

    Public Function CheckMaterialInUse(ByVal sMaterial As String) As Boolean
        Dim nInUse As Boolean = False
        For Each inst As cLandscape In _colLand
            If inst.GetMaterialName = sMaterial Then nInUse = True
        Next
        Return nInUse
    End Function

    Public Sub GenerateLayer(ByVal sLandscape As String, ByVal sAlphaName As String, ByVal fMinimum As Single, ByVal fMaximum As Single, ByVal fAntiAliasing As Single)

        ' Progress
        Dim iProgress As Integer
        Dim iTimer As Integer
        Dim frmProgress As New fProgress
        frmProgress.proBar.Maximum = 257 * 257
        frmProgress.Show()

        ' Calculate Anti-Alias power
        Dim fAAPower As Single = 1.0!
        If fAntiAliasing > 0 Then fAAPower = 1.0! / fAntiAliasing

        ' Get landscape position
        Dim fLandX As Single = clsLandManager.GetPositionX(sLandscape)
        Dim fLandZ As Single = clsLandManager.GetPositionZ(sLandscape)

        ' Create a render surface
        Dim rs As MTV3D65.TVRenderSurface
        rs = clsScene.CreateRenderSurface(256, 256, False)

        ' Start
        rs.StartRender()
        clsGUI.Immediate_Begin()

        ' Pass each altitude
        For fX As Single = 0 To 255
            For fZ As Single = 0 To 255

                ' Progress
                iProgress += 1
                iTimer += 1
                If iTimer > 1000 Then
                    iTimer = 0
                    frmProgress.proBar.Value = iProgress
                End If

                ' Get altitude
                Dim fAltitude As Single = clsLandManager.GetAltitude(fLandX + fX + 0.5!, fLandZ + fZ + 0.5!)

                ' Draw pixel with antialiasing
                If fAltitude > fMaximum And fAltitude < fMaximum + fAntiAliasing Then
                    Dim fAA As Single = (fMaximum + fAntiAliasing - fAltitude) * fAAPower
                    clsGUI.DrawPoint(fX, fZ, clsGlobals.GetColor(1, 1, 1, fAA))
                ElseIf fAltitude >= fMinimum And fAltitude <= fMaximum Then
                    clsGUI.DrawPoint(fX, fZ, clsGlobals.GetColor(1, 1, 1, 1))
                ElseIf fAltitude > fMinimum - fAntiAliasing And fAltitude < fMinimum Then
                    Dim fAA As Single = (fAltitude - (fMinimum - fAntiAliasing)) * fAAPower
                    clsGUI.DrawPoint(fX, fZ, clsGlobals.GetColor(1, 1, 1, fAA))
                End If

            Next
        Next

        ' End
        clsGUI.Immediate_End()
        rs.EndRender()

        ' Save texture
        clsTexture.SaveTextureBMP(rs.GetTexture, sCorePath & "Media\Export\Alpha\", sAlphaName & ".bmp")

        ' Unload
        frmProgress.Close()
        frmProgress = Nothing
        rs.Destroy()
        rs = Nothing

        ' Pop generated layer
        Dim frmPreview As New fPreview
        frmPreview.SetFile(sCorePath & "Media\Export\Alpha\" & sAlphaName & ".bmp")
        frmPreview.ShowDialog()

    End Sub

    Public Sub Splatting_AddLayer(ByVal sLandscape As String, ByVal sLayerName As String, ByVal sTexture As String, ByVal sAlpha As String, ByVal fTiling As Single)
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then inst.Splatting_AddLayer(sLayerName, sTexture, sAlpha, fTiling)
        Next
    End Sub

    Public Function Splatting_GetList(ByVal sLandscape As String) As String()
        Dim sList() As String = Nothing
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then sList = inst.Splatting_GetList()
        Next
        Return sList
    End Function

    Public Function Splatting_GetTexture(ByVal sLandscape As String, ByVal sLayer As String) As Integer
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then Return inst.Splatting_GetTexture(sLayer)
        Next
    End Function

    Public Function Splatting_GetAlpha(ByVal sLandscape As String, ByVal sLayer As String) As Integer
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then Return inst.Splatting_GetAlpha(sLayer)
        Next
    End Function

    Public Function Splatting_CheckAvailable(ByVal sLandscape As String, ByVal sLayer As String) As Boolean
        Dim bAvailable As Boolean = True
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then bAvailable = inst.Splatting_CheckAvailable(sLayer)
        Next
        Return bAvailable
    End Function

    Public Sub Splatting_RemoveLayer(ByVal sLandscape As String, ByVal sLayerName As String)
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then inst.Splatting_RemoveLayer(sLayerName)
        Next
    End Sub

    Public Sub Splatting_MoveLayerUp(ByVal sLandscape As String, ByVal sLayerName As String)
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then inst.Splatting_MoveLayerUp(sLayerName)
        Next
    End Sub

    Public Sub Splatting_MoveLayerDown(ByVal sLandscape As String, ByVal sLayerName As String)
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then inst.Splatting_MoveLayerDown(sLayerName)
        Next
    End Sub

    Public Sub Splatting_RefreshAlpha(ByVal sLandscape As String, ByVal sLayer As String)
        For Each inst As cLandscape In _colLand
            If inst.GetName = sLandscape Then inst.Splatting_RefreshAlpha(sLayer)
        Next
    End Sub

End Class

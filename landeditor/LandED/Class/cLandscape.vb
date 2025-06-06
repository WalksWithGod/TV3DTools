Public Class cLandscape
    Private _TVLandscape As MTV3D65.TVLandscape
    Private _colLayers As New Collection
    Private _bEnabled As Boolean = True

    Public Sub Quit()
        _TVLandscape.DeleteAll()
        _TVLandscape = Nothing
    End Sub

    Public Sub Render()
        If _bEnabled Then _TVLandscape.Render()
    End Sub

    Public Sub Save()
        Dim sPath As String = sProjectPath & "\" & GetName() & "\"

        ' Landscape file
        Dim sLandscapeFile As String = sPath & "landscape.txt"
        With clsFiles

            ' Delete actual file
            .File_Delete(slandscapeFile)

            ' Create folder
            .Folder_Create(sPath)

            ' Fill the file
            .File_InsertLine(sLandscapeFile, _TVLandscape.GetName)                                         ' 0 
            .File_InsertLine(slandscapeFile, CStr(_TVLandscape.GetPosition.x))                             ' 1
            .File_InsertLine(slandscapeFile, CStr(_TVLandscape.GetPosition.z))                             ' 2
            .File_InsertLine(slandscapeFile, clsMaterials.GetMaterialName(_TVLandscape.GetMaterial))       ' 3
            .File_InsertLine(slandscapeFile, CStr(_TVLandscape.GetScale.y))                                ' 4
        End With

        ' Export heightmap
        _TVLandscape.SaveTerrainData(sPath & "heightmap.tvm", MTV3D65.CONST_TV_LANDSAVE.TV_LANDSAVE_ALL)

        ' Texture layers file
        Dim sLayersFile As String = sPath & "layers.txt"
        With clsFiles

            ' Delete actual file
            .File_Delete(sLayersFile)

            ' Pass all of them
            For Each inst As cLayer In _colLayers

                ' Remove the prefix to prevent Grid_Grid_Grid_Texture.bmp...
                Dim sTexture As String = clsFiles.GetFileFromPath(clsTexture.GetFilePath(inst.GetTexture))
                Dim sAlpha As String = clsFiles.GetFileFromPath(clsTexture.GetFilePath(inst.GetAlpha))
                If sTexture.StartsWith(_TVLandscape.GetName & "_" & inst.GetName & "_") Then
                    sTexture = sTexture.Substring(_TVLandscape.GetName.Length + inst.GetName.Length + 2)
                    sAlpha = sAlpha.Substring(_TVLandscape.GetName.Length + inst.GetName.Length + 2)
                End If

                ' Fill the file
                .File_InsertLine(sLayersFile, inst.GetName)
                .File_InsertLine(sLayersFile, CStr(_TVLandscape.GetName & "_" & inst.GetName & "_" & sTexture))
                .File_InsertLine(sLayersFile, CStr(_TVLandscape.GetName & "_" & inst.GetName & "_" & sAlpha))
                .File_InsertLine(sLayersFile, CStr(inst.GetScale))

                ' Export texture and alpha
                inst.Save(sPath, _TVLandscape.GetName)

            Next

        End With

    End Sub

    Public Sub Load(ByVal sPath As String)

        ' Landscape file
        Dim sLandscapeFile() As String = clsFiles.File_Read(sPath & "landscape.txt")
        _TVLandscape = mCore.clsScene.CreateLandScape(sPath & "landscape.txt")
        With _TVLandscape
            .LoadTerrainData(sPath & "heightmap.tvm")
            .SetPosition(CSng(sLandscapeFile(1)), 0.0!, CSng(sLandscapeFile(2)))
            .SetName(sLandscapeFile(0))
            .SetScale(1.0!, CSng(sLandscapeFile(4)), 1.0!)
            .SetMaterial(clsMaterials.GetMaterialFromName(sLandscapeFile(3)))
            .ComputeNormals()
            .Enable(True)
            .SetSplattingEnable(True)
            .SetSplattingMode(True)
        End With

        ' Texture layers
        If CInt(slandscapeFile(5)) > -1 Then

            ' Read file
            Dim sLayersFile() As String = clsFiles.File_Read(sPath & "layers.txt")

            ' Create temp landscape folder
            clsFiles.Folder_Create(sCorePath & "temp\" & sLandscapeFile(0))

            ' Files management
            For iLayer As Integer = 0 To UBound(sLayersFile) - 1 Step 4

                ' Copy files to temp
                clsFiles.File_Copy(sPath & sLayersFile(iLayer + 1), sCorePath & "temp\" & sLandscapeFile(0))
                clsFiles.File_Copy(sPath & sLayersFile(iLayer + 2), sCorePath & "temp\" & sLandscapeFile(0))

                ' Add layers
                Dim sTexture As String = sCorePath & "temp\" & sLandscapeFile(0) & "\" & sLayersFile(iLayer + 1)
                Dim sAlpha As String = sCorePath & "temp\" & sLandscapeFile(0) & "\" & sLayersFile(iLayer + 2)
                Splatting_AddLayer(sLayersFile(iLayer), sTexture, sAlpha, CSng(sLayersFile(iLayer + 3)))

            Next
        End If

    End Sub

    Public Sub AddFlat(ByVal sName As String)
        _TVLandscape = mCore.clsScene.CreateLandScape(sName)
        With _TVLandscape
            .CreateEmptyTerrain(MTV3D65.CONST_TV_LANDSCAPE_PRECISION.TV_PRECISION_BEST, 1, 1, 0, 0, 0)
            .SetName(sName)
            .Enable(True)
            .SetSplattingEnable(True)
            .SetSplattingMode(True)
        End With
        Splatting_AddLayer("Grid", sCorePath & "Media\Landscape\Template\Texture.bmp", sCorePath & "Media\Landscape\Template\Alpha.bmp", 64.0!)
    End Sub

    Public Sub Generate(ByVal sName As String, ByVal sFile As String, ByVal eAffine As MTV3D65.CONST_TV_LANDSCAPE_AFFINE)
        _TVLandscape = mCore.clsScene.CreateLandScape(sName)
        With _TVLandscape
            .SetAffineLevel(eAffine)
            .GenerateTerrain(sFile, MTV3D65.CONST_TV_LANDSCAPE_PRECISION.TV_PRECISION_BEST, 1, 1, 0, 0, 0)
            .SetName(sName)
            .Enable(True)
            .SetSplattingEnable(True)
            .SetSplattingMode(True)
        End With
        Splatting_AddLayer("Grid", sCorePath & "Media\Landscape\Template\Texture.bmp", sCorePath & "Media\Landscape\Template\Alpha.bmp", 64.0!)
    End Sub

    Public Sub ExportBMP()
        Dim fAltitude As Single

        ' Get landscape position
        Dim fLandX As Single = _TVLandscape.GetPosition.x
        Dim fLandZ As Single = _TVLandscape.GetPosition.z

        ' Progress
        Dim iProgress As Integer
        Dim iTimer As Integer
        Dim frmProgress As New fProgress
        frmProgress.proBar.Maximum = 256 * 256
        frmProgress.Show()

        ' Create texture
        Dim rs As MTV3D65.TVRenderSurface
        rs = clsScene.CreateRenderSurface(256, 256, False)
        With rs

            ' Start
            .StartRender()
            clsGUI.Immediate_Begin()

            ' Draw
            For col As Single = 0 To 256
                For row As Single = 0 To 256

                    ' Progress
                    iProgress += 1
                    iTimer += 1
                    If iTimer > 1000 Then
                        iTimer = 0
                        frmProgress.proBar.Value = iProgress
                    End If

                    ' Get altitude
                    fAltitude = _TVLandscape.GetHeight(fLandX + col, fLandZ + row) / 255

                    ' Draw on texture
                    clsGUI.DrawPoint(col, row, clsGlobals.GetColor(fAltitude, fAltitude, fAltitude, 1))

                Next
            Next

            ' End
            clsGUI.Immediate_End()
            .EndRender()

            ' Save texture
            clsTexture.SaveTextureBMP(rs.GetTexture, sCorePath & "Media\Export\Heightmap\", _TVLandscape.GetName & ".bmp")

        End With

        ' Unload
        frmProgress.Close()
        frmProgress = Nothing
        rs.Destroy()
        rs = Nothing

    End Sub

    Public Sub ExportTVM()
        _TVLandscape.SaveTerrainData(sCorePath & "Media\Landscape\Heightmap TVM\" & _TVLandscape.GetName & ".tvm", MTV3D65.CONST_TV_LANDSAVE.TV_LANDSAVE_ALL)
        MsgBox(_TVLandscape.GetName & ".tvm exported!")
    End Sub

    Public Sub ImportTVM(ByVal sName As String, ByVal sFile As String)
        _TVLandscape = mCore.clsScene.CreateLandScape(sName)
        With _TVLandscape
            .LoadTerrainData(sFile)
            .SetName(sName)
            .Enable(True)
            .SetCullMode(MTV3D65.CONST_TV_CULLING.TV_FRONT_CULL)
            .SetSplattingEnable(True)
            .SetSplattingMode(True)
        End With
        Splatting_AddLayer("Grid", sCorePath & "Media\Landscape\Template\Texture.bmp", sCorePath & "Media\Landscape\Template\Alpha.bmp", 64.0!)
    End Sub

    Public Function GetName() As String
        Return _TVLandscape.GetName
    End Function

    Public Sub SetEnabled(ByVal bEnabled As Boolean)
        _bEnabled = bEnabled
    End Sub

    Public Function GetEnabled() As Boolean
        Return _bEnabled
    End Function

    Public Function GetScale() As Single
        Return _TVLandscape.GetScale.y
    End Function

    Public Sub SetScale(ByVal fScale As Single)
        _TVLandscape.SetScale(1, fScale, 1)
    End Sub

    Public Function GetPositionX() As Single
        Return _TVLandscape.GetPosition.x
    End Function

    Public Function GetPositionZ() As Single
        Return _TVLandscape.GetPosition.z
    End Function

    Public Sub SetPositionX(ByVal fPosition As Single)
        Dim fX As Single, fY As Single, fZ As Single
        fX = _TVLandscape.GetPosition.x
        fY = _TVLandscape.GetPosition.y
        fZ = _TVLandscape.GetPosition.z
        _TVLandscape.SetPosition(fPosition, fY, fZ)
    End Sub

    Public Sub SetPositionZ(ByVal fPosition As Single)
        Dim fX As Single, fY As Single, fZ As Single
        fX = _TVLandscape.GetPosition.x
        fY = _TVLandscape.GetPosition.y
        fZ = _TVLandscape.GetPosition.z
        _TVLandscape.SetPosition(fX, fY, fPosition)
    End Sub

    Public Function GetMaterialName() As String
        Return clsMaterials.GetMaterialName(_TVLandscape.GetMaterial)
    End Function

    Public Function GetMaterial() As Integer
        Return _TVLandscape.GetMaterial
    End Function

    Public Sub SetMaterial(ByVal iMaterial As Integer)
        _TVLandscape.SetMaterial(iMaterial)
    End Sub

    Public Function GetAltitude(ByVal fX As Single, ByVal fZ As Single) As Single
        Return _TVLandscape.GetHeight(fX, fZ)
    End Function

    Public Sub SetAltitude(ByVal fX As Single, ByVal fY As Single, ByVal fZ As Single)
        If fY < 0 Then fY = 0
        If fY > 255 Then fY = 255
        _TVLandscape.SetHeight(fX, fZ, fY, False, False)
        _TVLandscape.ComputeNormals(True)
    End Sub

    Public Function GetNormal(ByVal fX As Single, ByVal fZ As Single) As MTV3D65.TV_3DVECTOR
        Return _TVLandscape.GetNormal(fX, fZ)
    End Function

    Public Sub RefreshNormals()
        _TVLandscape.ComputeNormals(True)
    End Sub

    Public Function CheckInbound(ByVal fX As Single, ByVal fZ As Single) As Boolean
        If fX >= _TVLandscape.GetPosition.x And _
           fX <= _TVLandscape.GetPosition.x + 256 And _
           fZ >= _TVLandscape.GetPosition.z And _
           fZ <= _TVLandscape.GetPosition.z + 256 Then
            Return True
        End If
    End Function

    Private Sub Splatting_RefreshLayers()
        With _TVLandscape

            ' Clear layers
            .ClearAllSplattingLayers()

            ' Rebuild layers
            For Each inst As cLayer In _colLayers
                .AddSplattingTexture(inst.GetTexture, 0, inst.GetScale, inst.GetScale)
                .ExpandSplattingTexture(inst.GetAlpha, inst.GetTexture)
            Next

            ' Optimize
            .OptimizeSplatting()

        End With
    End Sub

    Public Function Splatting_GetList() As String()
        Dim sList() As String = Nothing, i As Integer = -1
        If _colLayers.Count > 0 Then
            For Each inst As cLayer In _colLayers
                i += 1
                ReDim Preserve sList(i)
                sList(i) = inst.GetName
            Next
        End If
        Return sList
    End Function

    Public Function Splatting_GetTexture(ByVal sLayer As String) As Integer
        For Each inst As cLayer In _colLayers
            If sLayer = inst.GetName Then Return inst.GetTexture
        Next
    End Function

    Public Function Splatting_GetAlpha(ByVal sLayer As String) As Integer
        For Each inst As cLayer In _colLayers
            If sLayer = inst.GetName Then Return inst.GetAlpha
        Next
    End Function

    Public Function Splatting_CheckAvailable(ByVal sLayer As String) As Boolean
        Dim bAvailable As Boolean = True
        For Each inst As cLayer In _colLayers
            If sLayer = inst.GetName Then Return bAvailable = False
        Next
        Return bAvailable
    End Function

    Public Sub Splatting_AddLayer(ByVal sLayerName As String, ByVal sTexture As String, ByVal sAlpha As String, ByVal fScale As Single)

        ' Add layer
        Dim inst As New cLayer
        inst.Add(sLayerName, sTexture, sAlpha, fScale)
        _colLayers.Add(inst, sLayerName)

        ' Add to landscape layer
        With _TVLandscape
            .AddSplattingTexture(inst.GetTexture, 0, inst.GetScale, inst.GetScale)
            .ExpandSplattingTexture(inst.GetAlpha, inst.GetTexture)
        End With
        Splatting_RefreshLayers()

    End Sub

    Public Sub Splatting_RemoveLayer(ByVal sLayer As String)

        ' Remove
        For Each inst As cLayer In _colLayers
            If inst.GetName = sLayer Then
                inst.Quit()
                inst = Nothing
            End If
        Next
        _colLayers.Remove(sLayer)

        ' Refresh 
        Splatting_RefreshLayers()

    End Sub

    Public Sub Splatting_RebuildLayer(ByVal sLayerName As String, ByVal iTexture As Integer, ByVal iAlpha As Integer, ByVal fScale As Single)

        ' Add layer
        Dim inst As New cLayer
        inst.Rebuild(sLayerName, iTexture, iAlpha, fScale)
        _colLayers.Add(inst, sLayerName)

        ' Add to landscape layer
        With _TVLandscape
            .AddSplattingTexture(inst.GetTexture, 0, inst.GetScale, inst.GetScale)
            .ExpandSplattingTexture(inst.GetAlpha, inst.GetTexture)
        End With

    End Sub

    Public Sub Splatting_MoveLayerUp(ByVal sLayer As String)
        Dim sName() As String = Nothing
        Dim iTexture() As Integer = Nothing
        Dim iAlpha() As Integer = Nothing
        Dim fScale() As Single = Nothing
        Dim iLayer As Integer = -1

        ' Dump all layers into an array
        For Each inst As cLayer In _colLayers
            iLayer += 1
            ReDim Preserve sName(iLayer)
            ReDim Preserve iTexture(iLayer)
            ReDim Preserve iAlpha(iLayer)
            ReDim Preserve fScale(iLayer)
            sName(iLayer) = inst.GetName
            iTexture(iLayer) = inst.GetTexture
            iAlpha(iLayer) = inst.GetAlpha
            fScale(iLayer) = inst.GetScale
        Next

        ' Find which layer has to be moved
        Dim iSelected As Integer
        For i As Integer = 0 To iLayer
            If sName(i) = sLayer Then iSelected = i
        Next

        ' Make sure its not the 1st layer were trying to move
        If iSelected > 0 Then

            ' Create a temp layer, copy from the future overwritten
            Dim iTempTexture As Integer = iTexture(iSelected - 1)
            Dim iTempAlpha As Integer = iAlpha(iSelected - 1)
            Dim fTempScale As Single = fScale(iSelected - 1)
            Dim sTempName As String = sName(iSelected - 1)

            ' Move up
            iTexture(iSelected - 1) = iTexture(iSelected)
            iAlpha(iSelected - 1) = iAlpha(iSelected)
            fScale(iSelected - 1) = fScale(iSelected)
            sName(iSelected - 1) = sName(iSelected)

            ' Copy from temp layer
            iTexture(iSelected) = iTempTexture
            iAlpha(iSelected) = iTempAlpha
            fScale(iSelected) = fTempScale
            sName(iSelected) = sTempName

            ' Clear collection
            _colLayers.Clear()

            ' Dump array to collection
            For i As Integer = 0 To iLayer
                Splatting_RebuildLayer(sName(i), iTexture(i), iAlpha(i), fScale(i))
            Next

        End If

        ' Refresh
        Splatting_RefreshLayers()

    End Sub

    Public Sub Splatting_MoveLayerDown(ByVal sLayer As String)
        Dim sName() As String = Nothing
        Dim iTexture() As Integer = Nothing
        Dim iAlpha() As Integer = Nothing
        Dim fScale() As Single = Nothing
        Dim iLayer As Integer = -1

        ' Dump all layers into an array
        For Each inst As cLayer In _colLayers
            iLayer += 1
            ReDim Preserve sName(iLayer)
            ReDim Preserve iTexture(iLayer)
            ReDim Preserve iAlpha(iLayer)
            ReDim Preserve fScale(iLayer)
            sName(iLayer) = inst.GetName
            iTexture(iLayer) = inst.GetTexture
            iAlpha(iLayer) = inst.GetAlpha
            fScale(iLayer) = inst.GetScale
        Next

        ' Find which layer has to be moved
        Dim iSelected As Integer
        For i As Integer = 0 To iLayer
            If sName(i) = sLayer Then iSelected = i
        Next

        ' Make sure its not the 1st layer were trying to move
        If iSelected < iLayer Then

            ' Create a temp layer, copy from the future overwritten
            Dim iTempTexture As Integer = iTexture(iSelected + 1)
            Dim iTempAlpha As Integer = iAlpha(iSelected + 1)
            Dim fTempScale As Single = fScale(iSelected + 1)
            Dim sTempName As String = sName(iSelected + 1)

            ' Move up
            iTexture(iSelected + 1) = iTexture(iSelected)
            iAlpha(iSelected + 1) = iAlpha(iSelected)
            fScale(iSelected + 1) = fScale(iSelected)
            sName(iSelected + 1) = sName(iSelected)

            ' Copy from temp layer
            iTexture(iSelected) = iTempTexture
            iAlpha(iSelected) = iTempAlpha
            fScale(iSelected) = fTempScale
            sName(iSelected) = sTempName

            ' Clear collection
            _colLayers.Clear()

            ' Dump array to collection
            For i As Integer = 0 To iLayer
                Splatting_RebuildLayer(sName(i), iTexture(i), iAlpha(i), fScale(i))
            Next

        End If

        ' Refresh
        Splatting_RefreshLayers()

    End Sub

    Public Sub Splatting_RefreshAlpha(ByVal sLayer As String)
        For Each inst As cLayer In _colLayers
            If inst.GetName = sLayer Then
                _TVLandscape.ExpandSplattingTexture(inst.GetAlpha, inst.GetTexture)
            End If
        Next
    End Sub

End Class

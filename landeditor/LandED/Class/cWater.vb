Public Class cWater
    Private _meshWater As MTV3D65.TVMesh
    Private _iMaterial As Integer
    Private iii As Integer

    Public Sub Init(ByVal sName As String, ByVal fPosX As Single, ByVal fPosZ As Single)

        ' Create
        _meshWater = clsScene.CreateMesh()
        With _meshWater
            .SetLightingMode(MTV3D65.CONST_TV_LIGHTINGMODE.TV_LIGHTING_MANAGED)
            .AddFloor(0, 0, 0, 4, 4)
            .SetPosition(fPosX, clsLandManager.GetAltitude(fPosX, fPosZ), fPosZ)
            .Enable(True)
            .SetMeshName(sName)
            _iMaterial = clsMaterials.GetMaterialFromName("defaultwater")
            .SetMaterial(_iMaterial)
            .SetBlendingMode(MTV3D65.CONST_TV_BLENDINGMODE.TV_BLEND_ALPHA)
            .SetAlphaTest(False)
            .SetCullMode(MTV3D65.CONST_TV_CULLING.TV_BACK_CULL)
            .ComputeNormals()
            .ComputeBoundings()
            .ComputeOctree()
            .SetCollisionEnable(True)
        End With

    End Sub

    Public Sub Quit()
        _meshWater.Destroy()
        _meshWater = Nothing
    End Sub

    Public Sub Save()
        Dim sPath As String = sProjectPath & "\" & GetName() & "\"

        ' Watere file
        Dim sWaterFile As String = sPath & "water.txt"
        With clsFiles

            ' Delete actual file
            .File_Delete(sWaterFile)

            ' Create folder
            .Folder_Create(sPath)

            ' Fill the file
            .File_InsertLine(sWaterFile, _meshWater.GetMeshName)                                    ' 0
            .File_InsertLine(sWaterFile, clsLandManager.GetName(_meshWater.GetPosition.x, _meshWater.GetPosition.z))
            .File_InsertLine(sWaterFile, CStr(_meshWater.GetPosition.x))                            ' 2
            .File_InsertLine(sWaterFile, CStr(_meshWater.GetPosition.y))                            ' 3
            .File_InsertLine(sWaterFile, CStr(_meshWater.GetPosition.z))                            ' 4
            .File_InsertLine(sWaterFile, clsMaterials.GetMaterialName(_iMaterial))                  ' 5
            .File_InsertLine(sWaterFile, CStr(_meshWater.GetScale.x))                               ' 6
            .File_InsertLine(sWaterFile, CStr(_meshWater.GetScale.z))                               ' 7

        End With

    End Sub

    Public Sub Load(ByVal sPath As String)

        ' Water file
        Dim sWaterFile() As String = clsFiles.File_Read(sPath & "water.txt")
        _meshWater = clsScene.CreateMesh()
        With _meshWater
            .SetLightingMode(MTV3D65.CONST_TV_LIGHTINGMODE.TV_LIGHTING_MANAGED)
            .AddFloor(0, 0, 0, 4, 4)
            .SetPosition(CSng(sWaterFile(2)), CSng(sWaterFile(3)), CSng(sWaterFile(4)))
            .SetScale(CSng(sWaterFile(6)), 1, CSng(sWaterFile(7)))
            .Enable(True)
            .SetMeshName(sWaterFile(0))
            _iMaterial = clsMaterials.GetMaterialFromName(sWaterFile(5))
            .SetMaterial(_iMaterial)
            .SetBlendingMode(MTV3D65.CONST_TV_BLENDINGMODE.TV_BLEND_ALPHA)
            .SetAlphaTest(False)
            .SetCullMode(MTV3D65.CONST_TV_CULLING.TV_BACK_CULL)
            .ComputeNormals()
            .ComputeBoundings()
            .ComputeOctree()
            .SetCollisionEnable(True)
        End With

    End Sub

    Public Sub Render()
        _meshWater.Render()
    End Sub

    Public Function GetName() As String
        Return _meshWater.GetMeshName
    End Function

    Public Sub SetScaleX(ByVal fScale As Single)
        Dim fTemp As Single = _meshWater.GetScale.z
        _meshWater.SetScale(fScale, 1, fTemp)
    End Sub

    Public Function GetScaleX() As Single
        Return _meshWater.GetScale.x
    End Function

    Public Sub SetScaleZ(ByVal fScale As Single)
        Dim fTemp As Single = _meshWater.GetScale.x
        _meshWater.SetScale(fTemp, 1, fScale)
    End Sub

    Public Function GetScaleZ() As Single
        Return _meshWater.GetScale.z
    End Function

    Public Sub SetMaterial(ByVal iMaterial As Integer)
        _iMaterial = iMaterial
        _meshWater.SetMaterial(iMaterial)
    End Sub

    Public Function GetMaterial() As Integer
        Return _iMaterial
    End Function

    Public Sub ResetMaterial()
        _meshWater.SetMaterial(_iMaterial)
    End Sub

    Public Sub SetPositionX(ByVal fPosition As Single)
        Dim fX As Single, fY As Single, fZ As Single
        fX = _meshWater.GetPosition.x
        fY = _meshWater.GetPosition.y
        fZ = _meshWater.GetPosition.z
        _meshWater.SetPosition(fPosition, fY, fZ)
    End Sub

    Public Sub SetPositionZ(ByVal fPosition As Single)
        Dim fX As Single, fY As Single, fZ As Single
        fX = _meshWater.GetPosition.x
        fY = _meshWater.GetPosition.y
        fZ = _meshWater.GetPosition.z
        _meshWater.SetPosition(fX, fY, fPosition)
    End Sub

    Public Function GetPositionX() As Single
        Return _meshWater.GetPosition.x
    End Function

    Public Function GetPositionZ() As Single
        Return _meshWater.GetPosition.z
    End Function

    Public Sub SetAltitude(ByVal fPosition As Single)
        Dim fX As Single, fY As Single, fZ As Single
        fX = _meshWater.GetPosition.x
        fY = _meshWater.GetPosition.y
        fZ = _meshWater.GetPosition.z
        _meshWater.SetPosition(fX, fPosition, fZ)
    End Sub

    Public Function GetAltitude() As Single
        Return _meshWater.GetPosition.y
    End Function

End Class

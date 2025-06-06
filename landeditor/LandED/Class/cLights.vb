Public Class cLights
    Private _TVLight As MTV3D65.TVLightEngine

    Public Sub Init()
        _TVLight = New MTV3D65.TVLightEngine
        _TVLight.SetSpecularLighting(True)
    End Sub

    Public Sub Quit()
        _TVLight.DeleteAllLights()
        _TVLight = Nothing
    End Sub

    Public Sub Save()

        ' Set path
        Dim sFile As String = sProjectPath & "\Lights.txt"

        ' Crete a temp light
        Dim eLight As New MTV3D65.TV_LIGHT

        ' Check if we have at least one light
        If _TVLight.GetActiveCount > 0 Then
            For i As Integer = 0 To _TVLight.GetActiveCount - 1

                ' Copy to temp light
                _TVLight.GetLight(i, eLight)

                ' Fille the light file
                With clsFiles
                    .File_InsertLine(sFile, _TVLight.GetLightName(i))
                    .File_InsertLine(sFile, CStr(eLight.ambient.r))
                    .File_InsertLine(sFile, CStr(eLight.ambient.g))
                    .File_InsertLine(sFile, CStr(eLight.ambient.b))
                    .File_InsertLine(sFile, CStr(eLight.ambient.a))
                    .File_InsertLine(sFile, CStr(eLight.diffuse.r))
                    .File_InsertLine(sFile, CStr(eLight.diffuse.g))
                    .File_InsertLine(sFile, CStr(eLight.diffuse.b))
                    .File_InsertLine(sFile, CStr(eLight.diffuse.a))
                    .File_InsertLine(sFile, CStr(eLight.specular.r))
                    .File_InsertLine(sFile, CStr(eLight.specular.g))
                    .File_InsertLine(sFile, CStr(eLight.specular.b))
                    .File_InsertLine(sFile, CStr(eLight.specular.a))
                    .File_InsertLine(sFile, CStr(eLight.direction.x))
                    .File_InsertLine(sFile, CStr(eLight.direction.y))
                    .File_InsertLine(sFile, CStr(eLight.direction.z))
                    .File_InsertLine(sFile, CStr(eLight.position.x))
                    .File_InsertLine(sFile, CStr(eLight.position.y))
                    .File_InsertLine(sFile, CStr(eLight.position.z))
                    .File_InsertLine(sFile, CStr(eLight.range))
                    .File_InsertLine(sFile, CStr(eLight.phi))
                    .File_InsertLine(sFile, CStr(eLight.bManaged))
                    .File_InsertLine(sFile, CStr(eLight.theta))
                    .File_InsertLine(sFile, CStr(eLight.type))
                End With
            Next
        End If
    End Sub

    Public Sub Load()
        Dim eLight As New MTV3D65.TV_LIGHT

        ' Check if a light file exists
        If clsFiles.File_CheckExist(sProjectPath & "\lights.txt") Then

            ' Clear
            _TVLight.DeleteAllLights()

            ' Read the file
            Dim sFile() As String = clsFiles.File_Read(sProjectPath & "\lights.txt")

            ' Add the lights
            For i As Integer = 0 To UBound(sFile) - 1 Step 24
                With eLight
                    .ambient.r = CSng(sFile(i + 1))
                    .ambient.g = CSng(sFile(i + 2))
                    .ambient.b = CSng(sFile(i + 3))
                    .ambient.a = CSng(sFile(i + 4))
                    .diffuse.r = CSng(sFile(i + 5))
                    .diffuse.g = CSng(sFile(i + 6))
                    .diffuse.b = CSng(sFile(i + 7))
                    .diffuse.a = CSng(sFile(i + 8))
                    .specular.r = CSng(sFile(i + 9))
                    .specular.g = CSng(sFile(i + 10))
                    .specular.b = CSng(sFile(i + 11))
                    .specular.a = CSng(sFile(i + 12))
                    .direction.x = CSng(sFile(i + 13))
                    .direction.y = CSng(sFile(i + 14))
                    .direction.z = CSng(sFile(i + 15))
                    .position.x = CSng(sFile(i + 16))
                    .position.y = CSng(sFile(i + 17))
                    .position.z = CSng(sFile(i + 18))
                    .range = CSng(sFile(i + 19))
                    .phi = CSng(sFile(i + 20))
                    .bManaged = CBool(sFile(i + 21))
                    .theta = CSng(sFile(i + 22))
                    Select Case sFile(i + 23)
                        Case "1" : .type = MTV3D65.CONST_TV_LIGHTTYPE.TV_LIGHT_POINT
                        Case "2" : .type = MTV3D65.CONST_TV_LIGHTTYPE.TV_LIGHT_SPOT
                        Case "3" : .type = MTV3D65.CONST_TV_LIGHTTYPE.TV_LIGHT_DIRECTIONAL
                    End Select
                End With

                ' Add light to TVLight
                Add(sFile(i + 0), eLight)

            Next
        End If
    End Sub

    Public Sub Add(ByVal sName As String, ByVal eLight As MTV3D65.TV_LIGHT)
        Dim iLight As Integer = _TVLight.CreateLight(eLight, sName)
        _TVLight.SetLightProperties(iLight, True, True, True)
    End Sub

    Public Sub Remove(ByVal sName As String)
        Dim iLight As Integer = _TVLight.GetLightFromName(sName)
        _TVLight.DeleteLight(iLight)
    End Sub

    Public Function GetList() As String()
        Dim sList() As String = Nothing
        For i As Integer = 0 To _TVLight.GetCount - 1
            ReDim Preserve sList(i)
            sList(i) = _TVLight.GetLightName(i)
        Next
        Return sList
    End Function

    Public Function GetLight(ByVal sName As String) As MTV3D65.TV_LIGHT
        Dim iLight As Integer = _TVLight.GetLightFromName(sName)
        Dim eLight As New MTV3D65.TV_LIGHT
        _TVLight.GetLight(iLight, eLight)
        Return eLight
    End Function

    Public Function CheckAvailable(ByVal sName As String) As Boolean
        Dim bAvailable As Boolean = True
        If _TVLight.GetCount > 0 Then
            For i As Integer = 0 To _TVLight.GetCount - 1
                If _TVLight.GetLightName(i) = sName Then bAvailable = False
            Next
        End If
        Return bAvailable
    End Function

    Public Sub Update(ByVal sName As String, ByVal eLight As MTV3D65.TV_LIGHT)
        Dim iLight As Integer = _TVLight.GetLightFromName(sName)
        _TVLight.SetLight(iLight, eLight)
    End Sub

End Class

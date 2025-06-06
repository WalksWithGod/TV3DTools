Public Class cMaterials
    Private _TVMaterial As MTV3D65.TVMaterialFactory

    Structure TV_Material
        Public Ambient As MTV3D65.TV_COLOR
        Public Diffuse As MTV3D65.TV_COLOR
        Public Emissive As MTV3D65.TV_COLOR
        Public Specular As MTV3D65.TV_COLOR
        Public Power As Single
        Public Opacity As Single
    End Structure

    Public Sub Init()
        _TVMaterial = New MTV3D65.TVMaterialFactory

        ' Add default materials
        Dim eMaterial As TV_Material

        ' Add blank
        With eMaterial
            .Ambient.r = 1
            .Ambient.g = 1
            .Ambient.b = 1
            .Ambient.a = 1
            .Diffuse.r = 1
            .Diffuse.g = 1
            .Diffuse.b = 1
            .Diffuse.a = 1
            .Specular.r = 1
            .Specular.g = 1
            .Specular.b = 1
            .Specular.a = 1
            .Power = 1
            .Opacity = 1
        End With
        Add("blank", eMaterial)

        ' Add middle
        With eMaterial
            .Ambient.r = 1
            .Ambient.g = 0.2
            .Ambient.b = 0
            .Ambient.a = 1
            .Diffuse.r = 1
            .Diffuse.g = 0.2
            .Diffuse.b = 0
            .Diffuse.a = 1
            .Specular.r = 1
            .Specular.g = 0.2
            .Specular.b = 0
            .Specular.a = 1
            .Power = 1
            .Opacity = 1
        End With
        Add("brushmiddle", eMaterial)

        ' Add around
        With eMaterial
            .Ambient.r = 1
            .Ambient.g = 0.5
            .Ambient.b = 0
            .Ambient.a = 1
            .Diffuse.r = 1
            .Diffuse.g = 0.5
            .Diffuse.b = 0
            .Diffuse.a = 1
            .Specular.r = 1
            .Specular.g = 0.5
            .Specular.b = 0
            .Specular.a = 1
            .Power = 1
            .Opacity = 1
        End With
        Add("brusharound", eMaterial)

        ' Add water
        With eMaterial
            .Ambient.r = 0.1
            .Ambient.g = 0.3
            .Ambient.b = 1
            .Ambient.a = 1
            .Diffuse.r = 0
            .Diffuse.g = 0
            .Diffuse.b = 0
            .Diffuse.a = 1
            .Specular.r = 0
            .Specular.g = 0
            .Specular.b = 0
            .Specular.a = 1
            .Power = 1
            .Opacity = 0.5
        End With
        Add("defaultwater", eMaterial)

    End Sub

    Public Sub Quit()
        _TVMaterial.DeleteAllMaterials()
        _TVMaterial = Nothing
    End Sub

    Public Sub Save()

        ' Set file
        Dim sFile As String = sProjectPath & "\Materials.txt"

        ' Create a temp material
        Dim eMaterial As New cMaterials.TV_Material

        ' Check if we have to dump at least one material
        If _TVMaterial.GetActiveCount > 1 Then
            For i As Integer = 1 To _TVMaterial.GetActiveCount - 1

                ' Make sure this material ain't the basic one
                If _TVMaterial.GetMaterialName(i) <> "blank" And _
                   _TVMaterial.GetMaterialName(i) <> "brushmiddle" And _
                   _TVMaterial.GetMaterialName(i) <> "brusharound" And _
                   _TVMaterial.GetMaterialName(i) <> "defaultwater" Then

                    ' Copy to temp material
                    eMaterial = GetMaterial(_TVMaterial.GetMaterialName(i))

                    ' Fill the file
                    With clsFiles
                        .File_InsertLine(sFile, _TVMaterial.GetMaterialName(i))
                        .File_InsertLine(sFile, CStr(eMaterial.Ambient.r))
                        .File_InsertLine(sFile, CStr(eMaterial.Ambient.g))
                        .File_InsertLine(sFile, CStr(eMaterial.Ambient.b))
                        .File_InsertLine(sFile, CStr(eMaterial.Ambient.a))
                        .File_InsertLine(sFile, CStr(eMaterial.Diffuse.r))
                        .File_InsertLine(sFile, CStr(eMaterial.Diffuse.g))
                        .File_InsertLine(sFile, CStr(eMaterial.Diffuse.b))
                        .File_InsertLine(sFile, CStr(eMaterial.Diffuse.a))
                        .File_InsertLine(sFile, CStr(eMaterial.Specular.r))
                        .File_InsertLine(sFile, CStr(eMaterial.Specular.g))
                        .File_InsertLine(sFile, CStr(eMaterial.Specular.b))
                        .File_InsertLine(sFile, CStr(eMaterial.Specular.a))
                        .File_InsertLine(sFile, CStr(eMaterial.Emissive.r))
                        .File_InsertLine(sFile, CStr(eMaterial.Emissive.g))
                        .File_InsertLine(sFile, CStr(eMaterial.Emissive.b))
                        .File_InsertLine(sFile, CStr(eMaterial.Emissive.a))
                        .File_InsertLine(sFile, CStr(eMaterial.Power))
                        .File_InsertLine(sFile, CStr(eMaterial.Opacity))
                    End With
                End If
            Next
        End If
    End Sub

    Public Sub Load()
        Dim eMaterial As New cMaterials.TV_Material

        ' Check if theres a file to load 
        If clsFiles.File_CheckExist(sProjectPath & "\materials.txt") Then

            ' Clear actual materials
            Reset()

            ' Read the file
            Dim sFile() As String = clsFiles.File_Read(sProjectPath & "\materials.txt")

            ' Create materials
            For i As Integer = 0 To UBound(sFile) - 1 Step 19
                If sFile(i) <> "" Then
                    With eMaterial
                        .Ambient.r = CSng(sFile(i + 1))
                        .Ambient.g = CSng(sFile(i + 2))
                        .Ambient.b = CSng(sFile(i + 3))
                        .Ambient.a = CSng(sFile(i + 4))
                        .Diffuse.r = CSng(sFile(i + 5))
                        .Diffuse.g = CSng(sFile(i + 6))
                        .Diffuse.b = CSng(sFile(i + 7))
                        .Diffuse.a = CSng(sFile(i + 8))
                        .Specular.r = CSng(sFile(i + 9))
                        .Specular.g = CSng(sFile(i + 10))
                        .Specular.b = CSng(sFile(i + 11))
                        .Specular.a = CSng(sFile(i + 12))
                        .Emissive.r = CSng(sFile(i + 13))
                        .Emissive.g = CSng(sFile(i + 14))
                        .Emissive.b = CSng(sFile(i + 15))
                        .Emissive.a = CSng(sFile(i + 16))
                        .Power = CSng(sFile(i + 17))
                        .Opacity = CSng(sFile(i + 18))
                    End With

                    ' Add material to TVMaterials
                    Add(sFile(i + 0), eMaterial)

                End If
            Next
        End If
    End Sub

    Public Sub Add(ByVal sName As String, ByVal eMaterial As TV_Material)
        _TVMaterial = New MTV3D65.TVMaterialFactory
        Dim iMaterial As Integer = _TVMaterial.CreateMaterial(sName)
        With eMaterial
            _TVMaterial.SetAmbient(iMaterial, .Ambient.r, .Ambient.g, .Ambient.b, .Ambient.a)
            _TVMaterial.SetDiffuse(iMaterial, .Diffuse.r, .Diffuse.g, .Diffuse.b, .Diffuse.a)
            _TVMaterial.SetEmissive(iMaterial, .Emissive.r, .Emissive.g, .Emissive.b, .Emissive.a)
            _TVMaterial.SetSpecular(iMaterial, .Specular.r, .Specular.g, .Specular.b, .Specular.a)
            _TVMaterial.SetPower(iMaterial, .Power)
            _TVMaterial.SetOpacity(iMaterial, .Opacity)
        End With
    End Sub

    Public Sub Remove(ByVal sName As String)
        Dim iMaterial As Integer = _TVMaterial.GetMaterialByName(sName)
        If _TVMaterial.IsMaterialActive(iMaterial) Then _TVMaterial.DeleteMaterial(iMaterial)
    End Sub

    Public Sub Reset()

        ' Delete current materials BUT the basics
        For i As Integer = 1 To _TVMaterial.GetActiveCount - 1

            ' Make sure this material ain't a basic one
            If _TVMaterial.GetMaterialName(i).ToString <> "blank" And _
               _TVMaterial.GetMaterialName(i).ToString <> "brushmiddle" And _
               _TVMaterial.GetMaterialName(i).ToString <> "brusharound" And _
               _TVMaterial.GetMaterialName(i).ToString <> "defaultwater" Then

                ' Remove if active
                If _TVMaterial.IsMaterialActive(i) Then _TVMaterial.DeleteMaterial(i)

            End If

        Next

    End Sub

    Public Function GetList() As String()

        ' Create a list
        Dim sList() As String = Nothing, iMat As Integer

        ' Check how many materials we have
        For i As Integer = 1 To _TVMaterial.GetCount
            If _TVMaterial.IsMaterialActive(i - 1) Then
                If _TVMaterial.GetMaterialName(i - 1) <> "blank" And _
                   _TVMaterial.GetMaterialName(i - 1) <> "brushmiddle" And _
                   _TVMaterial.GetMaterialName(i - 1) <> "brusharound" And _
                   _TVMaterial.GetMaterialName(i - 1) <> "defaultwater" Then

                    iMat += 1
                    ReDim Preserve sList(iMat)
                    sList(iMat) = _TVMaterial.GetMaterialName(i - 1)
                End If
            End If
        Next
        Return sList
    End Function

    Public Function GetMaterial(ByVal sName As String) As TV_Material
        Dim iMaterial As Integer = _TVMaterial.GetMaterialByName(sName)
        Dim eMaterial As New TV_Material
        With eMaterial
            .Ambient = _TVMaterial.GetAmbient(iMaterial)
            .Specular = _TVMaterial.GetSpecular(iMaterial)
            .Diffuse = _TVMaterial.GetDiffuse(iMaterial)
            .Emissive = _TVMaterial.GetEmissive(iMaterial)
            .Power = _TVMaterial.GetPower(iMaterial)
            .Opacity = _TVMaterial.GetOpacity(iMaterial)
        End With
        Return eMaterial
    End Function

    Public Function GetMaterialName(ByVal iMaterial As Integer) As String
        Return _TVMaterial.GetMaterialName(iMaterial)
    End Function

    Public Function GetMaterialFromName(ByVal sMaterial As String) As Integer
        Return _TVMaterial.GetMaterialByName(sMaterial)
    End Function

    Public Sub Update(ByVal sName As String, ByVal eMaterial As TV_Material)
        Dim iMaterial As Integer = _TVMaterial.GetMaterialByName(sName)
        With _TVMaterial
            .SetAmbient(iMaterial, eMaterial.Ambient.r, eMaterial.Ambient.g, eMaterial.Ambient.b, 1)
            .SetDiffuse(iMaterial, eMaterial.Diffuse.r, eMaterial.Diffuse.g, eMaterial.Diffuse.b, 1)
            .SetSpecular(iMaterial, eMaterial.Specular.r, eMaterial.Specular.g, eMaterial.Specular.b, 1)
            .SetEmissive(iMaterial, eMaterial.Emissive.r, eMaterial.Emissive.g, eMaterial.Emissive.b, 1)
            .SetOpacity(iMaterial, eMaterial.Opacity)
            .SetPower(iMaterial, eMaterial.Power)
        End With
    End Sub

    Public Function CheckAvailable(ByVal sName As String) As Boolean
        Dim bAvailable As Boolean = True
        If _TVMaterial.GetCount > 0 Then
            For i As Integer = 0 To _TVMaterial.GetCount - 1
                If _TVMaterial.GetMaterialName(i) = sName Then bAvailable = False
            Next
        End If
        Return bAvailable
    End Function

    Public Function CheckInUse(ByVal sMaterial As String) As Boolean
        Dim nInUse As Boolean = False
        If clsLandManager.CheckMaterialInUse(sMaterial) Then nInUse = True
        Return nInUse
    End Function

End Class

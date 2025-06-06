Public Class cWaterManager
    Private _colWater As Collection
    Private _sSelected As String = ""
    Private _bWaterPlaneLocked As Boolean

    Public Sub Init()
        _colWater = New Collection
    End Sub

    Public Sub Quit()
        For Each inst As cWater In _colWater
            inst.Quit()
            inst = Nothing
        Next
        _colWater = Nothing
    End Sub

    Public Sub Render()
        For Each inst As cWater In _colWater
            inst.Render()
        Next
    End Sub

    Public Sub Load()

        ' Make sure file exists
        If clsFiles.File_CheckExist(sProjectPath & "\Water.txt") Then

            ' Read file
            Dim sFile() As String = clsFiles.File_Read(sProjectPath & "\Water.txt")

            ' Load water
            For i As Integer = 0 To UBound(sFile)
                If sFile(i) <> "" Then
                    Dim inst As New cWater
                    inst.Load(sProjectPath & sFile(i) & "\")
                    _colWater.Add(inst, sFile(i))
                End If
            Next
        End If

    End Sub

    Public Sub Save()
        Dim sFile As String = sProjectPath & "\Water.txt"

        ' Fill new file
        For Each inst As cWater In _colWater
            clsFiles.File_InsertLine(sFile, inst.GetName)
        Next

        ' Save each waterplane
        For Each inst As cWater In _colWater
            inst.Save()
        Next

    End Sub

    Public Sub Add(ByVal sName As String)
        Dim inst As New cWater
        inst.Init(sName, 0, 0)
        _colWater.Add(inst, sName)
    End Sub

    Public Sub Remove(ByVal sWater As String)
        For Each inst As cWater In _colWater
            If inst.GetName = sWater Then
                inst.Quit()
                inst = Nothing
            End If
        Next
        _colWater.Remove(sWater)
    End Sub

    Public Sub CheckSelection()

        ' Check if mouse if over a water plane
        Dim col As MTV3D65.TVCollisionResult
        col = clsScene.MousePick(1)

        ' If its over...
        If col.IsCollision Then

            ' Get the name of the plane
            _sSelected = col.GetCollisionMesh.GetMeshName()

            ' Change waterplane material to red
            col.GetCollisionMesh.SetMaterial(clsMaterials.GetMaterialFromName("brushmiddle"))

        Else

            ' Reset selection
            _sSelected = ""

            ' Reset materials
            For Each inst As cWater In _colWater
                inst.resetmaterial()
            Next

        End If


    End Sub

    Public Property LockWater() As Boolean
        Get
            Return _bWaterPlaneLocked
        End Get
        Set(ByVal value As Boolean)
            _bWaterPlaneLocked = value
        End Set
    End Property

    Public Sub MoveSelected(ByVal iX As Integer, ByVal iZ As Integer, ByVal bFast As Boolean)

        ' Move if we have one selected
        If _sSelected <> "" Then
            For Each inst As cWater In _colWater

                ' Move selected
                If inst.GetName = _sSelected Then

                    ' Set speed
                    Dim fSpeed As Single
                    If bFast Then fSpeed = 0.01! * clsEngine.GetTick Else fSpeed = 0.001! * clsEngine.GetTick

                    ' Same hellish code than the camera
                    Dim fA1 As Single = CSng(clsCamera.GetAngle / 360.0! * Math.PI * 2.0!)
                    Dim fA2 As Single = CSng((clsCamera.GetAngle + 90.0!) / 360.0! * Math.PI * 2.0!)
                    Dim fPosX As Single = inst.GetPositionX
                    Dim fPosZ As Single = inst.GetPositionZ
                    fPosX += CSng((Math.Cos(fA1) * fSpeed * iX) + (Math.Cos(fA2) * fSpeed * iZ))
                    fPosZ -= CSng((Math.Sin(fA1) * fSpeed * iX) + (Math.Sin(fA2) * fSpeed * iZ))
                    inst.SetPositionX(fPosX)
                    inst.SetPositionZ(fPosZ)

                End If

            Next
        End If
    End Sub

    Public Function CheckAvailable(ByVal sName As String) As Boolean
        Dim bAvailable As Boolean = True
        If _colWater.Count > 0 Then
            For Each inst As cWater In _colWater
                If inst.GetName = sName Then bAvailable = False
            Next
        End If
        Return bAvailable
    End Function

    Public Function GetList() As String()
        Dim sList() As String = Nothing, i As Integer = -1
        If _colWater.Count > 0 Then
            For Each inst As cWater In _colWater
                i += 1
                ReDim Preserve sList(i)
                sList(i) = inst.GetName
            Next
        End If
        Return sList
    End Function

    Public Function GetMaterial(ByVal sName As String) As Integer
        For Each inst As cWater In _colWater
            If inst.GetName = sName Then Return inst.GetMaterial
        Next
    End Function

    Public Sub SetMaterial(ByVal sName As String, ByVal iMaterial As Integer)
        For Each inst As cWater In _colWater
            If inst.GetName = sName Then inst.SetMaterial(iMaterial)
        Next
    End Sub

    Public Sub SetPositionX(ByVal sName As String, ByVal fPosition As Single)
        For Each inst As cWater In _colWater
            If inst.GetName = sName Then inst.SetPositionX(fPosition)
        Next
    End Sub

    Public Sub SetPositionZ(ByVal sName As String, ByVal fPosition As Single)
        For Each inst As cWater In _colWater
            If inst.GetName = sName Then inst.SetPositionZ(fPosition)
        Next
    End Sub

    Public Function GetPositionX(ByVal sName As String) As Single
        For Each inst As cWater In _colWater
            If inst.GetName = sName Then Return inst.GetPositionX
        Next
    End Function

    Public Function GetPositionZ(ByVal sName As String) As Single
        For Each inst As cWater In _colWater
            If inst.GetName = sName Then Return inst.GetPositionZ
        Next
    End Function

    Public Sub SetAltitude(ByVal sName As String, ByVal fPosition As Single)
        For Each inst As cWater In _colWater
            If inst.GetName = sName Then inst.SetAltitude(fPosition)
        Next
    End Sub

    Public Function GetAltitude(ByVal sName As String) As Single
        For Each inst As cWater In _colWater
            If inst.GetName = sName Then Return inst.GetAltitude()
        Next
    End Function

    Public Sub SetScaleX(ByVal sName As String, ByVal fScale As Single)
        For Each inst As cWater In _colWater
            If inst.GetName = sName Then inst.SetScaleX(fScale)
        Next
    End Sub

    Public Sub SetScaleZ(ByVal sName As String, ByVal fScale As Single)
        For Each inst As cWater In _colWater
            If inst.GetName = sName Then inst.SetScaleZ(fScale)
        Next
    End Sub

    Public Function GetScaleX(ByVal sName As String) As Single
        For Each inst As cWater In _colWater
            If inst.GetName = sName Then Return inst.GetScaleX
        Next
    End Function

    Public Function GetScaleZ(ByVal sName As String) As Single
        For Each inst As cWater In _colWater
            If inst.GetName = sName Then Return inst.GetScaleZ
        Next
    End Function

End Class

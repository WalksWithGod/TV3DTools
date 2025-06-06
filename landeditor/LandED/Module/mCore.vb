Module mCore

    Enum EnumCoreStatus
        Editor_Init
        Editor_Load
        Editor_Loop
        Editor_Quit
    End Enum

    Public CoreStatus As EnumCoreStatus
    Public iCustomColors(15) As Integer
    Private RegisyKey As Microsoft.Win32.RegistryKey
    Private sPathTV3D As String = "SOFTWARE\\Truevision3D65Beta"

    Public sCorePath As String = System.Windows.Forms.Application.StartupPath & "\..\"
    Public sProjectPath As String
    Public sProjectName As String

    Public clsFiles As New cFiles
    Public clsEngine As New cEngine
    Public clsInput As New cInput
    Public clsTexture As New cTexture
    Public clsScene As New cScene
    Public clsGlobals As New cGlobals
    Public clsMath As New cMath
    Public clsCamera As New cCamera
    Public clsAtmosphere As New cAtmosphere
    Public clsGUI As New cGUI
    Public clsMaterials As New cMaterials
    Public clsLights As New cLights
    Public clsLandManager As New cLandManager
    Public clsWaterManager As New cWaterManager
    Public clsBrush As New cBrush

    Private Sub Settings_Save()
        clsFiles.File_Delete(sCorePath & "System\Settings.txt")
        For i As Integer = 0 To 15
            clsFiles.File_InsertLine(sCorePath & "System\Settings.txt", CStr(iCustomColors(i)))
        Next
    End Sub

    Private Sub Settings_Load()
        Dim sLine() As String = clsFiles.File_Read(sCorePath & "System\Settings.txt")
        For i As Integer = 0 To 15
            iCustomColors(i) = CInt(sLine(i))
        Next
    End Sub

    ' obsolete - TV3D no longer uses beta registration keys and instead uses .lic files
    'Public Function GetTV3DKey(ByVal sKey As String, ByVal sKeyDescription As String) As String

    '    ' Open regisy
    '    RegisyKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(sPathTV3D)

    '    ' Create subkey
    '    If RegisyKey Is Nothing Then
    '        RegisyKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE", True)
    '        Dim sSubKey As String = sPathTV3D.Substring(sPathTV3D.LastIndexOf("\") + 1)
    '        RegisyKey.CreateSubKey(sSubKey)
    '    End If

    '    ' Get key
    '    Dim sRet As String = CStr(RegisyKey.GetValue(sKey))

    '    ' Set new key
    '    If sRet = "" Then
    '        RegisyKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(sPathTV3D, True)
    '        sRet = InputBox(sKeyDescription)
    '        RegisyKey.SetValue(sKey, sRet)
    '    End If

    '    ' Close
    '    Return sRet
    '    RegisyKey.Close()

    'End Function

    Sub Main()
        Main_Init()
        Main_Load()
        Main_Loop()
        Main_Quit()
        End
    End Sub

    Public Sub Main_Init()

        ' Set status
        CoreStatus = EnumCoreStatus.Editor_Init

        ' Get project
        Dim frmMenu As New fMenu
        frmMenu.ShowDialog()

        ' Start init
        clsEngine.Init()
        clsScene.Init()
        clsGlobals.Init()
        clsMath.Init()
        clsInput.Init()
        clsTexture.Init()
        clsGUI.Init()
        clsMaterials.Init()
        clsLights.Init()
        clsCamera.Init()
        clsAtmosphere.Init()
        clsLandManager.Init()
        clsWaterManager.Init()
        clsBrush.Init()

    End Sub

    Public Sub Main_Quit()

        ' Set status
        CoreStatus = EnumCoreStatus.Editor_Quit

        ' Save
        Settings_Save()

        ' Unload
        clsBrush.Quit()
        clsAtmosphere.Quit()
        clsWaterManager.Quit()
        clsLandManager.Quit()
        clsCamera.Quit()
        clsLights.Quit()
        clsMaterials.Quit()
        clsGUI.Quit()
        clsTexture.Quit()
        clsInput.Quit()
        clsMath.Quit()
        clsGlobals.Quit()
        clsScene.Quit()
        clsEngine.Quit()

        ' Flush temp files
        clsFiles.Folder_Delete(sCorePath & "temp\")

    End Sub

    Public Sub Main_Loop()

        ' Set status
        CoreStatus = EnumCoreStatus.Editor_Loop
        Do

            ' Windows
            System.Windows.Forms.Application.DoEvents()

            ' Updates
            clsInput.Update()
            clsCamera.Update()
            clsBrush.Update()         

            ' Render
            Main_Render()

        Loop Until CoreStatus = EnumCoreStatus.Editor_Quit
    End Sub

    Public Sub Main_Render()
        clsEngine.RenderBegin()
        clsAtmosphere.Render()
        clsLandManager.Render()
        clsWaterManager.Render()
        clsBrush.Render()
        clsGUI.Render()
        clsEngine.RenderEnd()
    End Sub

    Public Sub Main_RenderSurfaces()
        clsLandManager.Render()
    End Sub

    Public Sub Main_Save()

        ' Delete/Create actual folder
        clsFiles.Folder_Delete(sProjectPath)
        clsFiles.Folder_Create(sProjectPath)

        ' Now save
        clsLandManager.Save()
        clsWaterManager.Save()
        clsMaterials.Save()
        clsLights.Save()

        ' Tada!
        MsgBox("Project '" & sProjectName & ".project' Saved!")

    End Sub

    Public Sub Main_Load()

        ' Set status
        CoreStatus = EnumCoreStatus.Editor_Load

        ' Delete/Create temp folder
        clsFiles.Folder_Create(sCorePath & "\Temp")

        ' Start loading
        Settings_Load()
        clsMaterials.Load()
        clsLights.Load()
        clsLandManager.Load()
        clsWaterManager.Load()

    End Sub

End Module

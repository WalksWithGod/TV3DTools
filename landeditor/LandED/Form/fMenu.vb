Public Class fMenu

    Private Sub btnNewProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewProject.Click
        Dim sName As String = InputBox("Enter name of your new project").Replace(" ", "")
        If sName <> "" Then

            ' Check if project allready exists
            If clsFiles.Folder_CheckExist(sCorePath & "Projects\" & sName) Then
                MsgBox("Project name allready exist! Please use another one.")
            Else

                ' Create a project file and folder
                clsFiles.File_Create(sCorePath & "Projects\" & sName & ".project")
                clsFiles.Folder_Create(sCorePath & "Projects\" & sName)

                ' Set project
                sProjectName = sName
                sProjectPath = sCorePath & "Projects\" & sName
                Me.Close()

            End If
        End If
    End Sub

    Private Sub btnOpenProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenProject.Click

        ' Set project
        sProjectName = Mid(lstProjects.SelectedItem.ToString, 1, clsFiles.GetFileFromPath(lstProjects.SelectedItem.ToString).Length - 8)
        sProjectPath = sCorePath & "projects\" & sProjectName & "\"
        Me.Close()

    End Sub

    Private Sub fMenuEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshList()
    End Sub

    Private Sub RefreshList()

        ' Disable
        btnOpenProject.Enabled = False
        btnDelete.Enabled = False

        ' Fill
        lstProjects.Items.Clear()
        Dim sFiles() As String = System.IO.Directory.GetFiles(sCorePath & "\projects", "*.project")
        If Not sFiles Is Nothing Then
            For i As Integer = 0 To UBound(sFiles)
                lstProjects.Items.Add(clsFiles.GetFileFromPath(sFiles(i)))
            Next
        End If

    End Sub

    Private Sub lstProjects_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstProjects.SelectedIndexChanged
        btnOpenProject.Enabled = True
        btnDelete.Enabled = True
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you SURE you want to DELETE the project named '" & lstProjects.SelectedItem.ToString & "' ?", MsgBoxStyle.YesNo, "Delete Project?") = MsgBoxResult.Yes Then
            clsFiles.File_Delete(sCorePath & "\projects\" & lstProjects.SelectedItem.ToString)
            clsFiles.Folder_Delete(sCorePath & "\projects\" & Mid(lstProjects.SelectedItem.ToString, 1, clsFiles.GetFileFromPath(lstProjects.SelectedItem.ToString).Length - 8))
            RefreshList()
        End If
    End Sub

End Class
Public Class cFiles

    Public Function GetFileFromPath(ByVal sPath As String) As String
        Return System.IO.Path.GetFileName(sPath)
    End Function

    Public Function Folder_CheckExist(ByVal sPath As String) As Boolean
        Return System.IO.Directory.Exists(sPath)
    End Function

    Public Sub Folder_Create(ByVal sPath As String)
        System.IO.Directory.CreateDirectory(sPath)
    End Sub

    Public Sub Folder_Delete(ByVal sPath As String)
        System.IO.Directory.Delete(sPath, True)
    End Sub

    Public Function File_CheckExist(ByVal sFile As String) As Boolean
        Return System.IO.File.Exists(sFile)
    End Function

    Public Sub File_Create(ByVal sFile As String)
        System.IO.File.Create(sFile)
    End Sub

    Public Sub File_InsertLine(ByVal sFile As String, ByVal sText As String)
        Dim fs As New System.IO.FileStream(sFile, System.IO.FileMode.Append, System.IO.FileAccess.Write)
        Dim sw As New System.IO.StreamWriter(fs)

        ' insert a line of text at the end of the file (append)
        With sw
            .BaseStream.Seek(0, System.IO.SeekOrigin.End)
            .WriteLine(sText)
            .Close()
        End With

    End Sub

    Public Sub File_Delete(ByVal sFile As String)
        If File_CheckExist(sFile) Then System.IO.File.Delete(sFile)
    End Sub

    Public Sub File_Copy(ByVal sSource As String, ByVal sDestination As String)
        Dim sFileOnly As String = sSource.Substring(sSource.LastIndexOf("\"))
        System.IO.File.Copy(sSource, sDestination & sFileOnly, True)
    End Sub

    Public Sub File_CopyPrefix(ByVal sSource As String, ByVal sDestination As String, ByVal sPrefix As String)
        Dim sFileOnly As String = sSource.Substring(sSource.LastIndexOf("\") + 1)
        System.IO.File.Copy(sSource, sDestination & "\" & sPrefix & "_" & sFileOnly, True)
    End Sub

    Public Function File_Read(ByVal sFile As String) As String()
        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(sFile)
        Dim sLine() As String, i As Integer = -1
        Do ' read every line
            i += 1
            ReDim Preserve sLine(i)
            sLine(i) = sr.ReadLine()
        Loop Until sLine(i) Is Nothing
        sr.Close()
        Return sLine
    End Function

End Class

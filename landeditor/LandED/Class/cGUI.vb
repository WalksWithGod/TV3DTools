Public Class cGUI
    Private _TVImmediate As MTV3D65.TVScreen2DImmediate
    Private _TVText As MTV3D65.TVScreen2DText
    Private _bAltitude As Boolean = True
    Private _iFontPointers As Integer
    Private _iFontFPS As Integer

    Public Sub Init()
        _TVImmediate = New MTV3D65.TVScreen2DImmediate
        _TVText = New MTV3D65.TVScreen2DText
        _iFontPointers = _TVText.TextureFont_Create("Arial", "Arial", 10, True, False, False, False)
    End Sub

    Public Sub Quit()
        _TVImmediate = Nothing
        _TVText = Nothing
    End Sub

    Public Sub Render()
        Dim iColor As Integer
        Dim vPointer As MTV3D65.TV_3DVECTOR
        Dim vRet As MTV3D65.TV_3DVECTOR

        ' Draw altitude of all pointers        
        If _bAltitude Then
            For i As Integer = 0 To 24
                If clsBrush.Pointer_IsEnabled(i) Then

                    ' Get position
                    vPointer = clsBrush.Pointer_GetPosition(i)
                    vRet = clsMath.Project3dpointTo2D(vPointer)

                    ' Altitude
                    Dim sAltitude As String = CStr(vPointer.y + 0.01!)

                    ' Manipulate to get XX.XX
                    If sAltitude.Contains(".") Then
                        sAltitude += "00"
                        Dim sSuffix As String = sAltitude.Substring(sAltitude.LastIndexOf(".") + 1, 2)
                        Dim sPrefix As String = sAltitude.Substring(0, sAltitude.LastIndexOf("."))
                        sAltitude = sPrefix & "." & sSuffix
                    Else
                        sAltitude += ".00"
                    End If

                    ' Get length in pixel of sAltitude text
                    Dim fWidth As Single, fHeight As Single
                    _TVText.TextureFont_GetTextSize(sAltitude, _iFontPointers, fWidth, fHeight)

                    ' Draw a box                    
                    With _TVImmediate
                        .Action_Begin2D()
                        iColor = clsGlobals.GetColor(0, 0, 0, 0.5)
                        Dim x1 As Single = vRet.x - 3 - fWidth * 0.5!
                        Dim y1 As Single = vRet.y - fHeight * 0.5!
                        Dim x2 As Single = vRet.x + fWidth + 2 - fWidth * 0.5!
                        Dim y2 As Single = vRet.y + fHeight - fHeight * 0.5! - 2
                        .Draw_FilledBox(x1, y1, x2, y2, iColor)
                        .Action_End2D()
                    End With

                    ' Draw text
                    iColor = clsGlobals.GetColor(1, 1, 1, 0.5)
                    With _TVText
                        .Action_BeginText()
                        Dim x3 As Single = vRet.x - fWidth * 0.5!
                        Dim y3 As Single = vRet.y - fHeight * 0.5!
                        .TextureFont_DrawText(sAltitude, x3, y3, iColor, _iFontPointers)
                        .Action_EndText()
                    End With

                End If
            Next
        End If


    End Sub

    Public Sub DisplayAltitude(ByVal nEnabled As Boolean)
        _bAltitude = nEnabled
    End Sub

    Public Sub DrawPoint(ByVal fX As Single, ByVal fY As Single, ByVal iColor As Integer)
        _TVImmediate.Draw_Point(fX, fY, iColor)
    End Sub

    Public Sub Immediate_Begin()
        _TVImmediate.Action_Begin2D()
    End Sub

    Public Sub Immediate_End()
        _TVImmediate.Action_End2D()
    End Sub

End Class

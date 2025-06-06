Public Class fLights
    Private _nChangeEnabled As Boolean

    Private Sub fLights_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshList()
    End Sub

    Private Sub RefreshList()

        ' Changes
        _nChangeEnabled = False

        ' List
        lstLights.Items.Clear()
        lstLights.Sorted = True
        Dim sList() As String = clsLights.GetList
        If Not sList Is Nothing Then
            For i As Integer = 0 To UBound(sList)
                If sList(i) <> "" Then lstLights.Items.Add(sList(i))
            Next
        End If

        ' Disable
        grpSettings.Enabled = False
        grpPosition.Enabled = False
        grpDirection.Enabled = False
        grpColors.Enabled = False
        picAmbient.BackColor = Color.White
        picDiffuse.BackColor = Color.White
        picSpecular.BackColor = Color.White
        btnImport.Enabled = False

        ' Render
        System.Windows.Forms.Application.DoEvents()
        Main_Render()

        ' Enable
        _nChangeEnabled = True

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim strName As String = InputBox("Enter name of new light").Replace(" ", "")
        If strName = "" Then
            MsgBox("You must provide a name for this new light!")
        Else

            'Check if name available
            If clsLights.CheckAvailable(strName) Then

                ' Set light
                Dim eLight As MTV3D65.TV_LIGHT
                With eLight
                    .ambient.r = 0.3!
                    .ambient.g = 0.3!
                    .ambient.b = 0.3!
                    .ambient.a = 1
                    .diffuse.r = 1
                    .diffuse.g = 1
                    .diffuse.b = 1
                    .diffuse.a = 1
                    .specular.r = 0
                    .specular.g = 0
                    .specular.b = 0
                    .specular.a = 1
                    .range = 1024
                    .bManaged = True
                    .type = MTV3D65.CONST_TV_LIGHTTYPE.TV_LIGHT_DIRECTIONAL
                End With

                ' Add light
                clsLights.Add(strName, eLight)

            Else
                MsgBox("Name of light allready in use!")
            End If

            ' Refresh
            RefreshList()
        End If
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click

        ' Remove
        clsLights.Remove(lstLights.SelectedItem.ToString)

        ' Refresh
        RefreshList()

    End Sub

    Private Sub lstLights_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLights.SelectedIndexChanged
        Dim eLight As MTV3D65.TV_LIGHT

        ' Disable changes
        _nChangeEnabled = False

        ' Enable
        grpSettings.Enabled = True
        grpPosition.Enabled = True
        grpDirection.Enabled = True
        grpColors.Enabled = True
        btnImport.Enabled = True

        ' Get light
        eLight = clsLights.GetLight(lstLights.SelectedItem.ToString)

        ' Fill
        With eLight
            picAmbient.BackColor = Color.FromArgb(CInt(.ambient.r * 255), CInt(.ambient.g * 255), CInt(.ambient.b * 255))
            picDiffuse.BackColor = Color.FromArgb(CInt(.diffuse.r * 255), CInt(.diffuse.g * 255), CInt(.diffuse.b * 255))
            picSpecular.BackColor = Color.FromArgb(CInt(.specular.r * 255), CInt(.specular.g * 255), CInt(.specular.b * 255))
            numDistance.Value = CDec(.range)
            numPosX.Value = CDec(.position.x)
            numPosY.Value = CDec(.position.y)
            numPosZ.Value = CDec(.position.z)
            numDirX.Value = CDec(.direction.x)
            numDirY.Value = CDec(.direction.y)
            numDirZ.Value = CDec(.direction.z)
            Select Case .type
                Case MTV3D65.CONST_TV_LIGHTTYPE.TV_LIGHT_DIRECTIONAL : cbType.Text = "Directional"
                Case MTV3D65.CONST_TV_LIGHTTYPE.TV_LIGHT_POINT : cbType.Text = "Point"
                Case MTV3D65.CONST_TV_LIGHTTYPE.TV_LIGHT_SPOT : cbType.Text = "Spot"
            End Select
        End With

        ' Enable changes
        _nChangeEnabled = True

    End Sub

    Private Sub picAmbient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picAmbient.Click
        Dim cd As New ColorDialog

        ' Fill
        With cd
            .CustomColors = iCustomColors
            .Color = picAmbient.BackColor
            .FullOpen = True
        End With

        ' Set/Save 
        If cd.ShowDialog = Windows.Forms.DialogResult.OK Then

            ' Pic
            picAmbient.BackColor = cd.Color

            ' Light
            Dim eLight As MTV3D65.TV_LIGHT = clsLights.GetLight(lstLights.SelectedItem.ToString)
            With eLight
                .ambient.r = picAmbient.BackColor.R / 255.0!
                .ambient.g = picAmbient.BackColor.G / 255.0!
                .ambient.b = picAmbient.BackColor.B / 255.0!
            End With
            clsLights.Update(lstLights.SelectedItem.ToString, eLight)

        End If

        ' Render
        System.Windows.Forms.Application.DoEvents()
        Main_Render()

        ' Save
        iCustomColors = cd.CustomColors

    End Sub

    Private Sub picDiffuse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picDiffuse.Click
        Dim cd As New ColorDialog

        ' Fill
        With cd
            .CustomColors = iCustomColors
            .Color = picDiffuse.BackColor
            .FullOpen = True
        End With

        ' Set/Save 
        If cd.ShowDialog = Windows.Forms.DialogResult.OK Then

            ' Pic
            picDiffuse.BackColor = cd.Color

            ' Light
            Dim eLight As MTV3D65.TV_LIGHT = clsLights.GetLight(lstLights.SelectedItem.ToString)
            With eLight
                .diffuse.r = picDiffuse.BackColor.R / 255.0!
                .diffuse.g = picDiffuse.BackColor.G / 255.0!
                .diffuse.b = picDiffuse.BackColor.B / 255.0!
            End With
            clsLights.Update(lstLights.SelectedItem.ToString, eLight)

        End If

        ' Render
        System.Windows.Forms.Application.DoEvents()
        Main_Render()

        ' Save
        iCustomColors = cd.CustomColors

    End Sub

    Private Sub picSpecular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picSpecular.Click
        Dim cd As New ColorDialog

        ' Fill
        With cd
            .CustomColors = iCustomColors
            .Color = picSpecular.BackColor
            .FullOpen = True
        End With

        ' Set/Save 
        If cd.ShowDialog = Windows.Forms.DialogResult.OK Then

            ' Pic
            picSpecular.BackColor = cd.Color

            ' Light
            Dim eLight As MTV3D65.TV_LIGHT = clsLights.GetLight(lstLights.SelectedItem.ToString)
            With eLight
                .specular.r = picSpecular.BackColor.R / 255.0!
                .specular.g = picSpecular.BackColor.G / 255.0!
                .specular.b = picSpecular.BackColor.B / 255.0!
            End With
            clsLights.Update(lstLights.SelectedItem.ToString, eLight)

        End If

        ' Render
        System.Windows.Forms.Application.DoEvents()
        Main_Render()

        ' Save
        iCustomColors = cd.CustomColors

    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        If lstLights.SelectedItem.ToString <> "" Then

            ' Get camera matrix            
            Dim mCamera As MTV3D65.TV_3DMATRIX = clsCamera.GetMatrix

            ' Set direction
            Dim vDirection As MTV3D65.TV_3DVECTOR
            With vDirection
                .x = mCamera.m31
                .y = mCamera.m32
                .z = mCamera.m33
            End With

            ' Invert direction
            vDirection = clsMath.VScale(vDirection, -1)

            ' Light
            Dim eLight As MTV3D65.TV_LIGHT = clsLights.GetLight(lstLights.SelectedItem.ToString)
            With eLight
                .direction = vDirection
                numDirX.Value = CDec(.direction.x)
                numDirY.Value = CDec(.direction.y)
                numDirZ.Value = CDec(.direction.z)
            End With
            clsLights.Update(lstLights.SelectedItem.ToString, eLight)

        End If

        ' Render
        System.Windows.Forms.Application.DoEvents()
        Main_Render()

    End Sub

    Private Sub cbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbType.SelectedIndexChanged
        If _nChangeEnabled Then

            ' Light
            Dim eLight As MTV3D65.TV_LIGHT = clsLights.GetLight(lstLights.SelectedItem.ToString)
            Select Case cbType.SelectedItem.ToString
                Case "Directional"
                    eLight.type = MTV3D65.CONST_TV_LIGHTTYPE.TV_LIGHT_DIRECTIONAL
                    grpDirection.Enabled = True
                Case "Poi"
                    eLight.type = MTV3D65.CONST_TV_LIGHTTYPE.TV_LIGHT_POINT
                    grpDirection.Enabled = False
                Case "Spot"
                    eLight.type = MTV3D65.CONST_TV_LIGHTTYPE.TV_LIGHT_SPOT
                    grpDirection.Enabled = True
            End Select
            clsLights.Update(lstLights.SelectedItem.ToString, eLight)

            ' Render
            System.Windows.Forms.Application.DoEvents()
            Main_Render()

        End If
    End Sub

    Private Sub numDistance_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numDistance.ValueChanged
        If _nChangeEnabled Then

            ' Light
            Dim eLight As MTV3D65.TV_LIGHT = clsLights.GetLight(lstLights.SelectedItem.ToString)
            eLight.range = numDistance.Value
            clsLights.Update(lstLights.SelectedItem.ToString, eLight)

            ' Render
            System.Windows.Forms.Application.DoEvents()
            Main_Render()

        End If
    End Sub

    Private Sub numPosX_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numPosX.ValueChanged
        If _nChangeEnabled Then

            ' Light
            Dim eLight As MTV3D65.TV_LIGHT = clsLights.GetLight(lstLights.SelectedItem.ToString)
            eLight.position.x = numPosX.Value
            clsLights.Update(lstLights.SelectedItem.ToString, eLight)

            ' Render
            System.Windows.Forms.Application.DoEvents()
            Main_Render()

        End If
    End Sub

    Private Sub numPosY_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numPosY.ValueChanged
        If _nChangeEnabled Then

            ' Light
            Dim eLight As MTV3D65.TV_LIGHT = clsLights.GetLight(lstLights.SelectedItem.ToString)
            eLight.position.y = numPosY.Value
            clsLights.Update(lstLights.SelectedItem.ToString, eLight)

            ' Render
            System.Windows.Forms.Application.DoEvents()
            Main_Render()

        End If
    End Sub

    Private Sub numPosZ_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numPosZ.ValueChanged
        If _nChangeEnabled Then

            ' Light
            Dim eLight As MTV3D65.TV_LIGHT = clsLights.GetLight(lstLights.SelectedItem.ToString)
            eLight.position.z = numPosZ.Value
            clsLights.Update(lstLights.SelectedItem.ToString, eLight)

            ' Render
            System.Windows.Forms.Application.DoEvents()
            Main_Render()

        End If
    End Sub

    Private Sub numDirX_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numDirX.ValueChanged
        If _nChangeEnabled Then

            ' Light
            Dim eLight As MTV3D65.TV_LIGHT = clsLights.GetLight(lstLights.SelectedItem.ToString)
            eLight.direction.x = numDirX.Value
            clsLights.Update(lstLights.SelectedItem.ToString, eLight)

            ' Render
            System.Windows.Forms.Application.DoEvents()
            Main_Render()

        End If
    End Sub

    Private Sub numDirY_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numDirY.ValueChanged
        If _nChangeEnabled Then

            ' Light
            Dim eLight As MTV3D65.TV_LIGHT = clsLights.GetLight(lstLights.SelectedItem.ToString)
            eLight.direction.y = numDirY.Value
            clsLights.Update(lstLights.SelectedItem.ToString, eLight)

            ' Render
            System.Windows.Forms.Application.DoEvents()
            Main_Render()

        End If
    End Sub

    Private Sub numDirZ_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numDirZ.ValueChanged
        If _nChangeEnabled Then

            ' Light
            Dim eLight As MTV3D65.TV_LIGHT = clsLights.GetLight(lstLights.SelectedItem.ToString)
            eLight.direction.z = numDirZ.Value
            clsLights.Update(lstLights.SelectedItem.ToString, eLight)

            ' Render
            System.Windows.Forms.Application.DoEvents()
            Main_Render()

        End If
    End Sub

    Private Sub fLights_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        Main_Render()
    End Sub

End Class
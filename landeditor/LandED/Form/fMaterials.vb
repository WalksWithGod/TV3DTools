Public Class fMaterials
    Private _nChangeEnabled As Boolean

    Private Sub fMaterials_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshList()
    End Sub

    Private Sub RefreshList()

        ' Changes
        _nChangeEnabled = False

        ' List
        lstMaterials.Items.Clear()
        lstMaterials.Sorted = True
        Dim sList() As String = clsMaterials.GetList
        If Not sList Is Nothing Then
            For i As Integer = 1 To UBound(sList)
                If sList(i) <> "" And sList(i) <> "blank" Then lstMaterials.Items.Add(sList(i))
            Next
        End If

        ' Disable
        grpSettings.Enabled = False
        grpColors.Enabled = False
        picAmbient.BackColor = Color.White
        picDiffuse.BackColor = Color.White
        picSpecular.BackColor = Color.White
        picEmissive.BackColor = Color.White

        ' Render
        System.Windows.Forms.Application.DoEvents()
        Main_Render()

        ' Changes
        _nChangeEnabled = True

    End Sub

    Private Sub lstMaterials_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMaterials.SelectedIndexChanged
        Dim eMaterial As cMaterials.TV_Material

        ' Disable changes
        _nChangeEnabled = False

        ' Enable
        grpSettings.Enabled = True
        grpColors.Enabled = True

        ' Get light
        eMaterial = clsMaterials.GetMaterial(lstMaterials.SelectedItem.ToString)

        ' Fill
        With eMaterial
            picAmbient.BackColor = Color.FromArgb(CInt(.Ambient.r * 255), CInt(.Ambient.g * 255), CInt(.Ambient.b * 255))
            picDiffuse.BackColor = Color.FromArgb(CInt(.Diffuse.r * 255), CInt(.Diffuse.g * 255), CInt(.Diffuse.b * 255))
            picSpecular.BackColor = Color.FromArgb(CInt(.Specular.r * 255), CInt(.Specular.g * 255), CInt(.Specular.b * 255))
            picEmissive.BackColor = Color.FromArgb(CInt(.Emissive.r * 255), CInt(.Emissive.g * 255), CInt(.Emissive.b * 255))
            numPower.Value = CDec(.Power)
            numOpacity.Value = CDec(.Opacity)
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

            ' Material
            Dim eMaterial As cMaterials.TV_Material = clsMaterials.GetMaterial(lstMaterials.SelectedItem.ToString)
            With eMaterial
                .Ambient.r = picAmbient.BackColor.R / 255.0!
                .Ambient.g = picAmbient.BackColor.G / 255.0!
                .Ambient.b = picAmbient.BackColor.B / 255.0!
            End With
            clsMaterials.Update(lstMaterials.SelectedItem.ToString, eMaterial)

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

            ' Material
            Dim eMaterial As cMaterials.TV_Material = clsMaterials.GetMaterial(lstMaterials.SelectedItem.ToString)
            With eMaterial
                .Diffuse.r = picDiffuse.BackColor.R / 255.0!
                .Diffuse.g = picDiffuse.BackColor.G / 255.0!
                .Diffuse.b = picDiffuse.BackColor.B / 255.0!
            End With
            clsMaterials.Update(lstMaterials.SelectedItem.ToString, eMaterial)

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

            ' Material
            Dim eMaterial As cMaterials.TV_Material = clsMaterials.GetMaterial(lstMaterials.SelectedItem.ToString)
            With eMaterial
                .Specular.r = picSpecular.BackColor.R / 255.0!
                .Specular.g = picSpecular.BackColor.G / 255.0!
                .Specular.b = picSpecular.BackColor.B / 255.0!
            End With
            clsMaterials.Update(lstMaterials.SelectedItem.ToString, eMaterial)

        End If

        ' Render
        System.Windows.Forms.Application.DoEvents()
        Main_Render()

        ' Save
        iCustomColors = cd.CustomColors

    End Sub

    Private Sub picEmissive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picEmissive.Click
        Dim cd As New ColorDialog

        ' Fill
        With cd
            .CustomColors = iCustomColors
            .Color = picEmissive.BackColor
            .FullOpen = True
        End With

        ' Set/Save 
        If cd.ShowDialog = Windows.Forms.DialogResult.OK Then

            ' Pic
            picEmissive.BackColor = cd.Color

            ' Material
            Dim eMaterial As cMaterials.TV_Material = clsMaterials.GetMaterial(lstMaterials.SelectedItem.ToString)
            With eMaterial
                .Emissive.r = picEmissive.BackColor.R / 255.0!
                .Emissive.g = picEmissive.BackColor.G / 255.0!
                .Emissive.b = picEmissive.BackColor.B / 255.0!
            End With
            clsMaterials.Update(lstMaterials.SelectedItem.ToString, eMaterial)

        End If

        ' Render
        System.Windows.Forms.Application.DoEvents()
        Main_Render()

        ' Save
        iCustomColors = cd.CustomColors

    End Sub

    Private Sub numPower_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numPower.ValueChanged
        If _nChangeEnabled Then
            Dim eMaterial As cMaterials.TV_Material = clsMaterials.GetMaterial(lstMaterials.SelectedItem.ToString)
            eMaterial.Power = numPower.Value
            clsMaterials.Update(lstMaterials.SelectedItem.ToString, eMaterial)

            ' Render
            System.Windows.Forms.Application.DoEvents()
            Main_Render()

        End If
    End Sub

    Private Sub numOpacity_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numOpacity.ValueChanged
        If _nChangeEnabled Then

            ' Get material
            Dim eMaterial As cMaterials.TV_Material = clsMaterials.GetMaterial(lstMaterials.SelectedItem.ToString)

            ' Opacity is the transparency/alpha
            eMaterial.Opacity =  numOpacity.Value
            clsMaterials.Update(lstMaterials.SelectedItem.ToString, eMaterial)

            ' Render
            System.Windows.Forms.Application.DoEvents()
            Main_Render()

        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim strName As String = InputBox("Enter name of new material").Replace(" ", "")
        If strName = "" Then
            MsgBox("You must provide a name for this new material")
        Else

            'Check if name available
            If clsMaterials.CheckAvailable(strName) Then

                ' Set material
                Dim eMaterial As cMaterials.TV_Material
                With eMaterial
                    .Ambient.r = 0.3!
                    .Ambient.g = 0.3!
                    .Ambient.b = 0.3!
                    .Ambient.a = 1
                    .Diffuse.r = 1
                    .Diffuse.g = 1
                    .Diffuse.b = 1
                    .Diffuse.a = 1
                    .Specular.r = 0
                    .Specular.g = 0
                    .Specular.b = 0
                    .Specular.a = 1
                    .Emissive.r = 0
                    .Emissive.g = 0
                    .Emissive.b = 0
                    .Emissive.a = 1
                    .Power = 1
                    .Opacity = 1
                End With

                ' Add material
                clsMaterials.Add(strName, eMaterial)

            Else
                MsgBox("Name of material allready in use!")
            End If

            ' Refresh
            RefreshList()

        End If
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        If clsMaterials.CheckInUse(lstMaterials.SelectedItem.ToString) Then
            MsgBox("Impossible to remove this material, it's currently in use!")
        Else
            clsMaterials.Remove(lstMaterials.SelectedItem.ToString)
            RefreshList()
        End If
    End Sub

    Private Sub fMaterials_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        Main_Render()
    End Sub

End Class
' Import the MTV3D65 library.
Imports MTV3D65



Public Class frmMain

    Inherits System.Windows.Forms.Form

    ' TV Variables.
    Public TV As TVEngine
    Public Scene As TVScene
    Public Inp As TVInputEngine

    Public bDoLoop As Boolean

    Declare Function GetFocus Lib "user32" () As Integer


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Name = "frmMain"
        Me.Text = "TV3D SDK 6.5 Template"

    End Sub

#End Region

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Create the TV Interface first:
        TV = New TVEngine

        ' Set the debug file/options.
        ' Do this before the 3D init so it can log any errors found during init.
        TV.SetDebugMode(True, True)
        TV.SetDebugFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\debugfile.txt")

        ' Set your beta-key/license:
        ' TV.SetLicenseKey TV_LICENSE_COMMERCIAL, "username", "key"
        'TV.SetLicenseKey(CONST_TV_LICENSEMODE.TV_LICENSE_COMMERCIAL, "Makosoft", "385D6EDA-F791AEEF-06455CC2-2FD1D1F0")
        TV.SetBetaKey("Hypnotron", "4036CD48-60432A1B-F75B95EA-125B63E1")
        Console.OpenStandardError()
        ' After setting the beta-key/license its time to init the engine:
        TV.Init3DWindowed(Me.Handle, False)
        TV.Init3DFullscreen(800, 600, 24, True, False, MTV3D65.CONST_TV_DEPTHBUFFERFORMAT.TV_DEPTHBUFFER_32BITS, 1, Me.Handle)
        'TV.Init3DFullscreen(800, 600)
        ' Something good to do is to enable the auto-resize feature:
        ' Get the default viewport and set autoresize to true for it:
        TV.GetViewport.SetAutoResize(True)

        ' Lets display the FPS:
        TV.DisplayFPS(True)

        ' Set the prefered angle system:
        TV.SetAngleSystem(MTV3D65.CONST_TV_ANGLE.TV_ANGLE_DEGREE)

        ' Now after we are done initializing the TVEngine component lets continue:
        ' Create any other components after TV init.

        Scene = New TVScene

        ' Input has an additional init method to call.
        Inp = New TVInputEngine
        ' Lets init both keyboard and mouse:
        Inp.Initialize(True, True)

        ' Now we have setup the most basic of components.
        ' Something to think about, if the component has a diffrent construct method
        ' then the Set Object = New TV<NAME>, use that one instead.

        ' For example:
        ' Dim Mesh as TVMesh;
        ' Mesh = Scene.CreateMeshBuilder "MyMesh" <- Instead of Set Mesh = new TVMesh
        ' Same goes for RenderSurface, Viewport etc.

        ' Lets setup the Loop:
        bDoLoop = True        

        ' Display the Form
        Me.Show()
        Me.Focus()

        Do While bDoLoop
            ' Check if the application has focus, if yes thats when we process the loop.
            If GetFocus = Me.Handle.ToInt32 Then
                ' The actual render loop:
                TV.Clear(False)
                ' Render Everything
                Scene.RenderAll(True)
                TV.RenderToScreen()

                ' Lets check if the user presses ESC key, if yes we will quit the app.
                If Inp.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_ESCAPE) Then bDoLoop = False
            Else
                ' So we dont call DoEvents to many times if we arent using full CPU power.
                System.Threading.Thread.Sleep(100)
            End If

            ' Process any messages Windows has for the application, do this last:
            Application.DoEvents()
        Loop

        ' Additional Info:
        '
        ' Normally you dont have to keep track of the TV component and free it on closing.
        ' When you free the TV ATL Interface on close it will automatically clean all the internal
        ' objects aswell. Such as Mesh's, Textures etc.

        ' Though it might be good to know you do have the ability to destroy and nil objects
        ' for re-creation or cleanup during runtime if you want that.

        ' There are several methods for destroying and cleaning up objects.

        ' TV<NAME>.Destroy , DestroyAll exists for some objects aswell if it is a Factory of some sort.

        ' Some other good destroy methods are:
        ' TVScene.DestroyAllMeshs.
        ' TVTextureFactory.DeleteAllTextures.

        ' And others...


        ' Set TV to Nothing
        TV = Nothing

        ' End the application
        End

    End Sub

    Private Sub frmMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ' If we close the application stop the loop.
        bDoLoop = False
    End Sub
End Class

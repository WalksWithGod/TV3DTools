VERSION 5.00
Begin VB.Form frmMain 
   Caption         =   "TV3D SDK 6.5 Template"
   ClientHeight    =   7200
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   9600
   LinkTopic       =   "Form1"
   ScaleHeight     =   7200
   ScaleWidth      =   9600
   StartUpPosition =   3  'Windows Default
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public TV As TVEngine
Public Scene As TVScene
Public Inp As TVInputEngine

Public bDoLoop As Boolean

' Function to check if the form has focus
Private Declare Function GetFocus Lib "user32" () As Long
Private Declare Sub Sleep Lib "kernel32" (ByVal dwmilliseconds As Long)

Private Sub Form_Load()
  ' Create the TV Interface first:
  Set TV = New TVEngine
  
  ' Set the debug file/options.
  ' Do this before the 3D init so it can log any errors found during init.
  TV.SetDebugMode True, True
  TV.SetDebugFile App.Path + "\debugfile.txt"
  
  ' Set your beta-key/license:
  ' TV.SetLicenseKey TV_LICENSE_COMMERCIAL, "username", "key"
  TV.SetBetaKey "", ""

  ' After setting the beta-key/license its time to init the engine:
  TV.Init3DWindowed frmMain.hWnd, True

  ' Something good to do is to enable the auto-resize feature:
  ' Get the default viewport and set autoresize to true for it:
  TV.GetViewport.SetAutoResize True

  ' Lets display the FPS:
  TV.DisplayFPS True

  ' Set the prefered angle system:
  TV.SetAngleSystem TV_ANGLE_DEGREE

  ' Now after we are done initializing the TVEngine component lets continue:
  ' Create any other components after TV init.

  Set Scene = New TVScene
  
  ' Input has an additional init method to call.
  Set Inp = New TVInputEngine
  ' Lets init both keyboard and mouse:
  Inp.Initialize True, True

  ' Now we have setup the most basic of components.
  ' Something to think about, if the component has a diffrent ATL init method
  ' then the Set Object = New TV<NAME>, use that one instead.

  ' For example:
  ' Dim Mesh as TVMesh;
  ' Mesh = Scene.CreateMeshBuilder "MyMesh" <- Instead of Set Mesh = new TVMesh
  ' Same goes for RenderSurface, Viewport etc.

  ' Lets setup the Loop:
  bDoLoop = True
  
  ' Display the Form
  frmMain.Show
  
  Do While bDoLoop
    ' Check if the application has focus, if yes thats when we process the loop.
    If GetFocus = frmMain.hWnd Then
        ' The actual render loop:
        TV.Clear False
            ' Render Everything
            Scene.RenderAll True
        TV.RenderToScreen
        
        ' Lets check if the user presses ESC key, if yes we will quit the app.
        If Inp.IsKeyPressed(TV_KEY_ESCAPE) Then bDoLoop = False
    Else
        ' So we dont call DoEvents to many times if we arent using full CPU power.
        Sleep 100
    End If
    
    ' Process any messages Windows has for the application, do this last:
    DoEvents
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
  Set TV = Nothing
  
  ' End the application
  End
    
End Sub

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
    ' If we close the form lets stop the loop.
    bDoLoop = False
End Sub

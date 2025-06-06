unit uMain;

interface

// Add the TV3D65 Type Library into the uses clause. (TV3D65_TLB).
uses
  Windows, Messages, SysUtils, Classes, Forms, Dialogs, TV3D65_TLB;

type
  TfrmMain = class(TForm)
    procedure FormCreate(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
  private
    { Private declarations }
  public
    { Public declarations }

    // Declare the TV Variables:
    TV : TVEngine;
    Scene : TVScene;
    Input : TVInputEngine;
    Globals : TVGlobals;

    Procedure AppIdle(sender : TObject; var done : boolean);
  end;

var
  frmMain: TfrmMain;

implementation

{$R *.dfm}

procedure TfrmMain.FormCreate(Sender: TObject);
begin
  // Create the TV Interface first:
  TV := CoTVEngine.Create;

  // Set the debug file/options.
  // Do this before the 3D init so it can log any errors found during init.
  TV.SetDebugMode(true, true);
  TV.SetDebugFile(ExtractFilePath(Application.ExeName) + 'debugfile.txt');
  
  // Set your beta-key/license:
  // TV.SetLicenseKey(TV_LICENSE_COMMERCIAL, 'username', 'key');
  TV.SetBetaKey('', '');

  // After setting the beta-key/license its time to init the engine:
  TV.Init3DWindowed(frmMain.Handle, true);

  // Something good to do is to enable the auto-resize feature:
  // Get the default viewport and set autoresize to true for it:
  TV.GetViewport.SetAutoResize(true);

  // Lets display the FPS:
  TV.DisplayFPS(true);

  // Set the prefered angle system:
  TV.SetAngleSystem(TV_ANGLE_DEGREE);

  // Now after we are done initializing the TVEngine component lets continue:
  // Create any other components after TV init.

  Scene := CoTVScene.Create;

  Globals := CoTVGlobals.Create;

  // Input has an additional init method to call.
  Input := CoTVInputEngine.Create;
  // Lets init both keyboard and mouse:
  Input.Initialize(true, true);

  // Now we have setup the most basic of components.
  // Something to think about, if the component has a diffrent ATL init method
  // then the CoTV<NAME>.Create, use that one instead.

  // For example:
  // Mesh : TVMesh;
  // Mesh := Scene.CreateMeshBuilder('MyMesh'); <- Instead of Mesh := CoTVMesh.Create;
  // Same goes for RenderSurface, Viewport etc.

  // Lets setup the Loop:
  Application.OnIdle := AppIdle;
end;

procedure TfrmMain.AppIdle(sender : TObject; var done : boolean);
begin

  // Check if the application has focus, if yes thats when we process the loop.
  if frmMain.Focused then
  begin
    // This tells Windows it isnt done, so it will continue to loop.
    done := false;

    // The actual render loop:
    TV.Clear(false);
      // Render Everything:
      Scene.RenderAll(true);
    TV.RenderToScreen;

    // Lets check if the user presses ESC key, if yes we will quit the app.
    If Input.IsKeyPressed(TV_KEY_ESCAPE) then Close();

    // Process any messages Windows has for the application, do this last:
    Application.ProcessMessages;
  end;

end;

procedure TfrmMain.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  // Additional Info:
  {
    Normally you dont have to keep track of the TV component and free it on closing.
    Delphi will free the ATL Interface on close and thus automatically all the internal
    objects will be free'd. Such as Mesh's, Textures etc.

    Though it might be good to know you do have the ability to destroy and nil objects
    for re-creation or cleanup during runtime if you want that.

    TV := Nil;

    Will free all of the internal objects automatically.
    There are several other Destroy methods such as:

    TV<NAME>.Destroy , DestroyAll exists for some objects aswell if it is a Factory of some sort.

    Some other good destroy methods are:
    TVScene.DestroyAllMeshs.
    TVTextureFactory.DeleteAllTextures.

    And others...
  }

  TV := nil;
end;

end.



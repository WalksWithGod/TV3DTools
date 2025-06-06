program Template;

uses
  Forms,
  uMain in 'uMain.pas' {frmMain};

{$R *.res}

begin
  Application.Initialize;
  Application.Title := 'TV3D SDK 6.5 Template';
  Application.CreateForm(TfrmMain, frmMain);
  Application.Run;
end.

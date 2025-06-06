using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;
using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ParticleEditor
{
	[StandardModule]
	internal sealed class modMain
	{
		// Constructors
		static modMain ()
		{
			modMain.oScr2D = new TVScreen2DImmediate();
			modMain.oScr2Dt = new TVScreen2DText();
			modMain.fMain = new frmMain();
			modMain.sHAngle = 45.00F;
			modMain.sVAngle = -20.00F;
			modMain.sZoom = 400.00F;
		}
		
		
		// Methods
		[STAThread]
		public static void Main ()
		{
			string[] textArray1 = Environment.GetCommandLineArgs();
			modLocalize.ForceRegionalSettings();
			modOptions.LoadOptions();
			modMain.fMain.Show();
			Application.DoEvents();
			modMain.Init(modMain.fMain._picRender);
			if (textArray1.Length > 1)
			{
				modMain.fMain.sFilename = textArray1[1];
				modMain.fMain.SetTitle();
				modParticleXML.LoadSystem(textArray1[1]);
			}
			modMain.Run();
			modMain.fMain.Hide();
			Application.DoEvents();
			modMain.fMain = null;
		}
		
		public static void Init ([Optional]PictureBox picRender/* = null*/)
		{
			bool flag1 = false;
			if (File.Exists("debug.txt"))
			{
				File.Delete("debug.txt");
			}
			modMain.oEngine = new TVEngine();
			modMain.oEngine.AllowMultithreading(true);
			if (picRender == null)
			{
				flag1 = modMain.oEngine.Init3DFullscreen(0x400, 0x300);
			}
			else
			{
				flag1 = modMain.oEngine.Init3DWindowed(picRender.Handle);
			}
			modMain.oScene = new TVScene();
			modMain.oTex = new TVTextureFactory();
			modMain.oMat = new TVMaterialFactory();
			modMain.oInput = new TVInputEngine();
			modMain.oScr2D = new TVScreen2DImmediate();
			modMain.oScr2Dt = new TVScreen2DText();
			modMain.oMath = new TVMathLibrary();
			modMain.oGlobal = new TVGlobals();
			if (!flag1)
			{
                Interaction.MsgBox("Unable to init TV3D Engine", MsgBoxStyle.OkOnly, null);
				ProjectData.EndApp();
			}
			modMain.oInput.Initialize(true, true);
			modMain.oEngine.SetDebugFile("debug.txt");
			modMain.oEngine.DisplayFPS(true);
			modMain.oEngine.GetViewport().SetAutoResize(true);
			modMain.oEngine.SetAngleSystem(CONST_TV_ANGLE.TV_ANGLE_DEGREE);
			cColor color1 = new cColor(StringType.FromObject(modOptions.GetOption("background-color", "0,0,0,0")));
			modMain.oScene.SetBackgroundColor(color1.r, color1.g, color1.b);
			modMain.oScene.SetAutoTransColor(-327764);
			modMain.mMarker = modMain.oScene.CreateMeshBuilder("marker");
			modMain.mMarker.CreateSphere(3.00F);
			modMain.mMarker.SetLightingMode(CONST_TV_LIGHTINGMODE.TV_LIGHTING_MANAGED);
			modMain.oMat.CreateMaterialQuick(0.00F, 0.00F, 1.00F, 1.00F, "blue");
			modMain.oMat.CreateMaterialQuick(1.00F, 0.00F, 0.00F, 1.00F, "red");
			modMain.oMat.CreateMaterialQuick(0.00F, 1.00F, 0.00F, 1.00F, "green");
			modMain.iFont = modMain.oScr2Dt.TextureFont_Create("verdana", "verdana", 12, true, false, false, false);
			modParticleXML.ClearSystem(true, true);
		}
		
		public static void Run ()
		{
			modMain.bRun = true;
			while (modMain.bRun)
			{
				if ((modMain.fMain.WindowState != FormWindowState.Minimized) & (Form.ActiveForm != null))
				{
					modMain.pSystem.Update();
					modMain.oEngine.Clear();
					modParticleXML.RenderParticleSystem();
					int num2 = 0x19;
					if (modMain.iDebug > 0)
					{
						int num1;
						modMain.oScr2Dt.Action_BeginText();
						modMain.oScr2Dt.TextureFont_DrawText("Total Emitters: " + StringType.FromInteger(modMain.pSystem.GetEmitterCount()), 10.00F, (float) num2, modMain.oGlobal.RGBA(0.00F, 1.00F, 0.00F, 1.00F));
						num2 += 14;
						modMain.oScr2Dt.TextureFont_DrawText("Total Attractors: " + StringType.FromInteger(modMain.pSystem.GetAttractorCount()), 10.00F, (float) num2, modMain.oGlobal.RGBA(0.00F, 1.00F, 0.00F, 1.00F));
						num2 += 14;
						modMain.oScr2Dt.TextureFont_DrawText("Total Particles: " + StringType.FromInteger(modMain.pSystem.GetGlobalParticleCount()), 10.00F, (float) num2, modMain.oGlobal.RGBA(0.00F, 1.00F, 0.00F, 1.00F));
						num2 += 14;
						if (modMain.iDebug == 2)
						{
							int num4 = modMain.pSystem.GetEmitterCount() - 1;
							for (int iEmitter = 0;iEmitter <= num4; iEmitter++)
							{
								IEnumerator enumerator1;
								modMain.oScr2Dt.TextureFont_DrawText("Emitter #" + StringType.FromInteger(iEmitter) + ": " + StringType.FromInteger(modMain.pSystem.GetEmitterParticleCount(iEmitter)), 25.00F, (float) num2, modMain.oGlobal.RGBA(0.00F, 0.80F, 0.00F, 1.00F));
								num2 += 14;
								Collection collection1 = modemitterUtils.GetEmitterErrors(iEmitter);
								try
								{
									enumerator1 = collection1.GetEnumerator();
									while (enumerator1.MoveNext())
									{
										string sText = StringType.FromObject(enumerator1.Current);
										modMain.oScr2Dt.TextureFont_DrawText(sText, 25.00F, (float) num2, modMain.oGlobal.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
										num2 += 14;
									}
								}
								finally
								{
                                    //if (enumerator1 is IDisposable)
                                    //{
                                    //    ((IDisposable) enumerator1).Dispose();
                                    //}
								}
							}
						}
						modMain.oScr2Dt.Action_EndText();
						modMain.oScr2D.Action_Begin2D();
						modMain.oScr2D.Draw_Line3D(0.00F, 0.00F, 0.00F, 50.00F, 0.00F, 0.00F, modMain.oGlobal.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
						modMain.oScr2D.Draw_Line3D(0.00F, 0.00F, 0.00F, 0.00F, 50.00F, 0.00F, modMain.oGlobal.RGBA(0.00F, 1.00F, 0.00F, 1.00F));
						modMain.oScr2D.Draw_Line3D(0.00F, 0.00F, 0.00F, 0.00F, 0.00F, 50.00F, modMain.oGlobal.RGBA(0.00F, 0.00F, 1.00F, 1.00F));
						modMain.oScr2D.Action_End2D();
						if (modMain.iDebug == 2)
						{
							modMain.oScr2Dt.Action_BeginText();
							modMain.oScr2Dt.TextureFont_DrawBillboardText("X", 50.00F, -5.00F, 0.00F, modMain.oGlobal.RGBA(1.00F, 0.00F, 0.00F, 1.00F), modMain.iFont, 5.00F, 5.00F);
							modMain.oScr2Dt.TextureFont_DrawBillboardText("Y", -5.00F, 50.00F, 0.00F, modMain.oGlobal.RGBA(0.00F, 1.00F, 0.00F, 1.00F), modMain.iFont, 5.00F, 5.00F);
							modMain.oScr2Dt.TextureFont_DrawBillboardText("Z", 0.00F, -5.00F, 50.00F, modMain.oGlobal.RGBA(0.00F, 0.00F, 1.00F, 1.00F), modMain.iFont, 5.00F, 5.00F);
							modMain.oScr2Dt.Action_EndText();
						}
						num2 = modMain.oEngine.GetViewport().GetHeight() - 0x1e;
						if (modMain.fMain.bViewMode)
						{
							modMain.oScr2Dt.Action_BeginText();
							modMain.oScr2Dt.TextureFont_DrawText("View Mode", 15.00F, (float) num2, modMain.oGlobal.RGBA(1.00F, 0.00F, 0.00F, 1.00F), modMain.iFont);
							modMain.oScr2Dt.Action_EndText();
							modMain.oScr2D.Action_Begin2D();
							modMain.oScr2D.Draw_Box(10.00F, (float) (num2 - 5), 115.00F, (float) (num2 + 0x16), modMain.oGlobal.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
							modMain.oScr2D.Action_End2D();
							num1 = 0x73;
						}
						else
						{
							if (modMain.fMain.bInputMode)
							{
								modMain.oScr2Dt.Action_BeginText();
								modMain.oScr2Dt.TextureFont_DrawText("Interactive Mode", 15.00F, (float) num2, modMain.oGlobal.RGBA(1.00F, 0.00F, 0.00F, 1.00F), modMain.iFont);
								modMain.oScr2Dt.Action_EndText();
								modMain.oScr2D.Action_Begin2D();
								modMain.oScr2D.Draw_Box(10.00F, (float) (num2 - 5), 170.00F, (float) (num2 + 0x16), modMain.oGlobal.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
								modMain.oScr2D.Action_End2D();
								num1 = 0xb4;
							}
							else
							{
								modMain.oScr2Dt.Action_BeginText();
								modMain.oScr2Dt.TextureFont_DrawText("Edit Mode", 15.00F, (float) num2, modMain.oGlobal.RGBA(1.00F, 0.00F, 0.00F, 1.00F), modMain.iFont);
								modMain.oScr2Dt.Action_EndText();
								modMain.oScr2D.Action_Begin2D();
								modMain.oScr2D.Draw_Box(10.00F, (float) (num2 - 5), 105.00F, (float) (num2 + 0x16), modMain.oGlobal.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
								modMain.oScr2D.Action_End2D();
								num1 = 0x73;
							}
						}
						if (modParticleXML.bNeedsReloading | modParticleXML.bNeedsSaving)
						{
							modMain.oScr2Dt.Action_BeginText();
							modMain.oScr2Dt.TextureFont_DrawText("System Modified", (float) num1, (float) num2, modMain.oGlobal.RGBA(1.00F, 0.00F, 0.00F, 1.00F), modMain.iFont);
							modMain.oScr2Dt.Action_EndText();
							modMain.oScr2D.Action_Begin2D();
							modMain.oScr2D.Draw_Box((float) (num1 - 5), (float) (num2 - 5), (float) (num1 + 0x93), (float) (num2 + 0x16), modMain.oGlobal.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
							modMain.oScr2D.Action_End2D();
						}
					}
					modMain.oEngine.RenderToScreen();
					if (modMain.fMain.bInputMode | modMain.fMain.bViewMode)
					{
						if (modMain.oInput.IsKeyPressed(CONST_TV_KEY.TV_KEY_LEFTARROW))
						{
							modMain.sHAngle += (float) (modMain.oEngine.AccurateTimeElapsed() * 0.1);
						}
						if (modMain.oInput.IsKeyPressed(CONST_TV_KEY.TV_KEY_RIGHTARROW))
						{
							modMain.sHAngle -= (float) (modMain.oEngine.AccurateTimeElapsed() * 0.1);
						}
						if (modMain.oInput.IsKeyPressed(CONST_TV_KEY.TV_KEY_UPARROW))
						{
							modMain.sVAngle += (float) (modMain.oEngine.AccurateTimeElapsed() * 0.1);
						}
						if (modMain.oInput.IsKeyPressed(CONST_TV_KEY.TV_KEY_DOWNARROW))
						{
							modMain.sVAngle -= (float) (modMain.oEngine.AccurateTimeElapsed() * 0.1);
						}
						if (modMain.oInput.IsKeyPressed(CONST_TV_KEY.TV_KEY_HOME))
						{
							modMain.sHAngle = 50.00F;
							modMain.sVAngle = -20.00F;
							modMain.sZoom = 400.00F;
						}
						if (modMain.oInput.IsKeyPressed(CONST_TV_KEY.TV_KEY_PAGEDOWN))
						{
							modMain.sZoom += (float) (modMain.oEngine.AccurateTimeElapsed() * 0.1);
						}
						if (modMain.oInput.IsKeyPressed(CONST_TV_KEY.TV_KEY_PRIOR))
						{
							modMain.sZoom -= (float) (modMain.oEngine.AccurateTimeElapsed() * 0.1);
						}
					}
					if (!modMain.fMain.bViewMode)
					{
						if (modMain.oInput.IsKeyPressed(CONST_TV_KEY.TV_KEY_DELETE))
						{
							if (modMain.fMain._dcSysTree.ActiveControl == null)
							{
								modMain.fMain.DeleteKey();
							}
							else
							{
								if (StringType.StrCmp(modMain.fMain._dcSysTree.ActiveControl.Name, "propSystem", false) != 0)
								{
									modMain.fMain.DeleteKey();
								}
							}
						}
						if (modMain.oInput.IsKeyPressed(CONST_TV_KEY.TV_KEY_INSERT))
						{
							modMain.fMain.InsertKey();
						}
					}
					if (modMain.sHAngle > 360.00F)
					{
						modMain.sHAngle -= 360.00F;
					}
					if (modMain.sHAngle < 1.00F)
					{
						modMain.sHAngle += 360.00F;
					}
					if (modMain.sVAngle > 80.00F)
					{
						modMain.sVAngle = 80.00F;
					}
					if (modMain.sVAngle < -80.00F)
					{
						modMain.sVAngle = -80.00F;
					}
					if (modMain.sZoom > 1000.00F)
					{
						modMain.sZoom = 1000.00F;
					}
					if (modMain.sZoom < 50.00F)
					{
						modMain.sZoom = 50.00F;
					}
					TV_3DVECTOR tv_dvector1 = modMain.oMath.MoveAroundPoint(modMain.oGlobal.Vector3(0.00F, 0.00F, 0.00F), modMain.sZoom, modMain.sHAngle, modMain.sVAngle);
					modMain.oScene.GetCamera().SetCamera(tv_dvector1.x, tv_dvector1.y, tv_dvector1.z, 0.00F, 0.00F, 0.00F);
					if (modParticleXML.bNeedsReloading & modMain.fMain._MenuItem24.Checked)
					{
						modParticleXML.ReloadSystem(false);
					}
				}
				Application.DoEvents();
			}
			if (!modMain.fMain.bViewMode)
			{
				modOptions.SaveOptions();
			}
		}
		
		public static void Cleanup ()
		{
			modMain.mMarker = null;
			modMain.pSystem = null;
			modMain.oGlobal = null;
			modMain.oMath = null;
			modMain.oScr2D = null;
			modMain.oScr2Dt = null;
			modMain.oInput = null;
			modMain.oTex = null;
			modMain.oMat = null;
			modMain.oScene = null;
			modMain.oEngine = null;
		}
		
		
		// Constants
		public const int const_StartHAngle = 0x2d;
		public const int const_StartVAngle = -20;
		public const int const_StartZoom = 0x190;
		
		// Statics
		public static TVEngine oEngine;
		public static TVScene oScene;
		public static TVTextureFactory oTex;
		public static TVMaterialFactory oMat;
		public static TVInputEngine oInput;
		public static TVScreen2DImmediate oScr2D;
		public static TVScreen2DText oScr2Dt;
		public static TVMathLibrary oMath;
		public static TVGlobals oGlobal;
		public static frmMain fMain;
		public static TVMesh mMarker;
		public static TVParticleSystem pSystem;
		public static bool bRun;
		public static short iDebug;
		public static float sHAngle;
		public static float sVAngle;
		public static float sZoom;
		public static int iFont;
	}
}

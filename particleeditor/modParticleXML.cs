using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Xml;

namespace ParticleEditor
{
	[StandardModule]
	internal sealed class modParticleXML
	{
        // Statics
        public static XmlDocument xDoc;
        public static XmlElement xParent;
        public static bool bNeedsReloading;
        public static bool bNeedsSaving;

		// Constructors
		static modParticleXML ()
		{
			modParticleXML.xDoc = new XmlDocument();
			modParticleXML.bNeedsReloading = false;
			modParticleXML.bNeedsSaving = false;
		}
		
		
		// Methods
		public static string GetValue (XmlElement xNode, string sName, [Optional]string sDefault/* = null*/)
		{
			if (xNode.HasAttribute(sName))
			{
				return xNode.GetAttribute(sName);
			}
			return sDefault;
		}
		
		public static void ClearSystem ([Optional]bool bClearXML/* = true*/, [Optional]bool bRecreateSystem/* = true*/)
		{
			if (modMain.pSystem != null)
			{
				foreach (XmlElement element1 in modParticleXML.xParent.ChildNodes)
				{
					if ((StringType.StrCmp(element1.Name, "emitter", false) != 0) || (StringType.StrCmp(element1.GetAttribute("type"), "minimesh", false) != 0))
					{
						continue;
					}
					TVMiniMesh mesh1 = modMain.oGlobal.GetMiniMesh("minimesh" + element1.GetAttribute("id"));
					if (mesh1 != null)
					{
						modMain.oEngine.AddToLog("Destroy: minimesh" + element1.GetAttribute("id"));
						mesh1.Destroy();
					}
				}
				modMain.pSystem.Destroy();
				modMain.pSystem = null;
			}
			if (bRecreateSystem)
			{
				modMain.pSystem = modMain.oScene.CreateParticleSystem();
			}
			if (bClearXML)
			{
				modParticleXML.xDoc.LoadXml("<particle-system></particle-system>");
				modParticleXML.xParent = (XmlElement) modParticleXML.xDoc.SelectSingleNode("/particle-system");
				modMain.fMain.nodeParent.Nodes.Clear();
			}
		}
		
		public static void SaveSystem (string sFilename)
		{
			if (modParticleXML.bNeedsReloading)
			{
				modParticleXML.bNeedsReloading = false;
				modParticleXML.ReloadSystem(false);
			}
			if (modParticleXML.bNeedsSaving)
			{
				modParticleXML.xDoc.Save(sFilename);
			}
			modParticleXML.bNeedsSaving = false;
		}
		
		public static void LoadSystem (string sFilename)
		{
			try
			{
				ProjectData.ClearProjectError();
				modMain.fMain.bViewMode = false;
				modMain.oEngine.SetSearchDirectory(sFilename.Substring(0, sFilename.LastIndexOf(@"\")));
				if (StringType.StrCmp(sFilename.Substring(sFilename.Length - 4).ToLower(), ".tvp", false) == 0)
				{
					modMain.fMain.SetViewMode(true);
					modParticleXML.ClearSystem(true, true);
					if (!modMain.pSystem.Load(sFilename))
					{
						Interaction.MsgBox("Unable to load TVP, file is not a valid Truevision3D Particle System.", MsgBoxStyle.Information, null);
					}
				    return;
				}
				modMain.fMain.SetViewMode(false);
				modParticleXML.ClearSystem(true, true);
				modParticleXML.xDoc.Load(sFilename);
				modParticleXML.xParent = (XmlElement) modParticleXML.xDoc.SelectSingleNode("/particle-system");
				modParticleXML.ReloadSystem(true);

			}
            catch (Exception exception2) 
			{

				ProjectData.SetProjectError(exception2);

                       Interaction.MsgBox("Invalid TVParticleSystem Project\r\n\r\n" + exception2.Message, MsgBoxStyle.Information, null);
                        modParticleXML.ClearSystem(true, true);
					
				ProjectData.ClearProjectError();
			}
		}
		
		public static void ReloadSystem ([Optional]bool bResetTree/* = false*/)
		{
			IEnumerator enumerator1;
			modParticleXML.bNeedsReloading = false;
			modParticleXML.ClearSystem(false, true);
			try
			{
				enumerator1 = modParticleXML.xParent.ChildNodes.GetEnumerator();
				while (enumerator1.MoveNext())
				{
					XmlElement xNode = (XmlElement) enumerator1.Current;
					string text1 = xNode.Name;
					if (StringType.StrCmp(text1, "emitter", false) == 0)
					{
						modemitterUtils.CreateEmitter(xNode, bResetTree);
						continue;
					}
					if (StringType.StrCmp(text1, "attractor", false) == 0)
					{
						modAttractorUtils.CreateAttractor(xNode, bResetTree);
						continue;
					}
					if (StringType.StrCmp(text1, "header", false) == 0)
					{
						modParticleXML.DisplayHeader(xNode);
						continue;
					}
					Interaction.MsgBox("Unknown element type: (" + xNode.Name + ")", 0, null);
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
		
		public static void RenderParticleSystem ()
		{
			if (modMain.iDebug > 0)
			{
				foreach (XmlElement element1 in modParticleXML.xParent.ChildNodes)
				{
					cVector vector1 = new cVector(element1.GetAttribute("location"));
					string text1 = element1.Name;
					if (StringType.StrCmp(text1, "emitter", false) == 0)
					{
						modMain.mMarker.SetMaterial(modMain.oGlobal.GetMat("blue"));
						modMain.mMarker.SetPosition(vector1.x, vector1.y, vector1.z);
						modMain.mMarker.Render();
						continue;
					}
					if (StringType.StrCmp(text1, "attractor", false) == 0)
					{
						int num1;
						if (element1.HasAttribute("repulsionconst"))
						{
							num1 = IntegerType.FromString(element1.GetAttribute("repulsionconst"));
						}
						else
						{
							num1 = 0;
						}
						if (num1 > 0)
						{
							modMain.mMarker.SetMaterial(modMain.oGlobal.GetMat("red"));
						}
						else
						{
							modMain.mMarker.SetMaterial(modMain.oGlobal.GetMat("green"));
						}
						modMain.mMarker.SetPosition(vector1.x, vector1.y, vector1.z);
						modMain.mMarker.Render();
					}
				}
			}
			try
			{
				modMain.pSystem.Render();
			}
			catch (Exception exception2)
			{
				ProjectData.SetProjectError(exception2);
				Exception exception1 = exception2;
				ProjectData.ClearProjectError();
				return;
			}
		}
		
		public static int IDFromName (string sName)
		{
			int num2 = Strings.InStr(sName, " (", 0);
			if (num2 != 0)
			{
				sName = Strings.Left(sName, num2 - 1);
			}
			string[] textArray1 = Strings.Split(sName, "#", -1, 0);
			if ((Information.UBound(textArray1, 1) == 1) && Information.IsNumeric(textArray1[1]))
			{
				return IntegerType.FromString(textArray1[1]);
			}
			return -1;
		}
		
		public static void DisplayHeader (XmlElement xNode)
		{
			string text1="";
			string text2 = "";
			foreach (XmlElement element1 in xNode.ChildNodes)
			{
				string text3 = element1.Name;
				if (StringType.StrCmp(text3, "title", false) == 0)
				{
					text2 = element1.InnerText;
					continue;
				}
				if (StringType.StrCmp(text3, "description", false) == 0)
				{
					text1 = element1.InnerText;
				}
			}
			frmHeader header1 = new frmHeader(text2, text1);
			header1.ShowDialog();
			header1 = null;
		}
	}
}

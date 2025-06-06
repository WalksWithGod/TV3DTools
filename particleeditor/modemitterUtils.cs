using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;
using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ParticleEditor
{
	[StandardModule]
	internal sealed class modemitterUtils
	{
		// Methods
		public static XmlElement GetEmitterNode (int iID)
		{
			return (XmlElement) modParticleXML.xParent.SelectSingleNode("emitter[@id=" + StringType.FromInteger(iID) + "]");
		}
		
		public static TreeNode GetEmitterTreeNode (int iID)
		{
			foreach (TreeNode node2 in modMain.fMain.nodeParent.Nodes)
			{
				if (StringType.StrCmp(Strings.Left(node2.Text, Strings.Len("Emitter #" + StringType.FromInteger(iID))), "Emitter #" + StringType.FromInteger(iID), false) == 0)
				{
					return node2;
				}
			}
			return null;
		}
		
		public static void DeleteEmitter (int iID)
		{
			XmlElement oldChild = modemitterUtils.GetEmitterNode(iID);
			if (oldChild != null)
			{
				modParticleXML.xParent.RemoveChild(oldChild);
			}
			TreeNode node1 = modemitterUtils.GetEmitterTreeNode(iID);
			if (node1 != null)
			{
				node1.Remove();
			}
		}
		
		public static void AddEmitter (CONST_TV_EMITTERTYPE eType, int iMaxParticles)
		{
			if (modParticleXML.bNeedsReloading)
			{
				modParticleXML.ReloadSystem(false);
			}
			XmlElement xNode = modParticleXML.xDoc.CreateElement("emitter");
			switch (eType)
			{
				case CONST_TV_EMITTERTYPE.TV_EMITTER_POINTSPRITE:
				{
					xNode.SetAttribute("type", "pointsprite");
					goto Label_0065;
				}
				case CONST_TV_EMITTERTYPE.TV_EMITTER_BILLBOARD:
				{
					xNode.SetAttribute("type", "billboard");
					goto Label_0065;
				}
				case CONST_TV_EMITTERTYPE.TV_EMITTER_MINIMESH:
				{
					modParticleXML.bNeedsSaving = true;
					break;
				}
				default:
				{
					goto Label_0065;
				}
			}
			xNode.SetAttribute("type", "minimesh");
		Label_0065:
			xNode.SetAttribute("max-particles", StringType.FromInteger(iMaxParticles));
			modemitterUtils.CreateEmitter(xNode, true);
			modemitterUtils.LoadEmitterProps(xNode);
			modParticleXML.xParent.AppendChild(xNode);
		}
		
		public static void LoadEmitterProps (int iId)
		{
			XmlElement xNode = (XmlElement) modParticleXML.xParent.SelectSingleNode("emitter[@id=" + StringType.FromInteger(iId) + "]");
			modemitterUtils.LoadEmitterProps(xNode);
		}
		
		public static void LoadEmitterProps (XmlElement xNode)
		{
			if (xNode != null)
			{
				CONST_TV_EMITTERTYPE const_tv_emittertype1;
				int num1;
				propEmitter emitter1 = null;
				string text1 = xNode.GetAttribute("type");
				if (StringType.StrCmp(text1, "pointsprite", false) == 0)
				{
					const_tv_emittertype1 = CONST_TV_EMITTERTYPE.TV_EMITTER_POINTSPRITE;
					emitter1 = new propEmitter();
				}
				else if (StringType.StrCmp(text1, "billboard", false) == 0)
				{
					const_tv_emittertype1 = CONST_TV_EMITTERTYPE.TV_EMITTER_BILLBOARD;
					emitter1 = new propEmitterBillboard();
					if (xNode.HasAttribute("size"))
					{
						((propEmitterBillboard) emitter1).BillboardSize = SingleType.FromString(xNode.GetAttribute("size"));
					}
					else
					{
						((propEmitterBillboard) emitter1).BillboardSize = 16.00F;
					}
				}
				else
				{
					if (StringType.StrCmp(text1, "minimesh", false) == 0)
					{
						const_tv_emittertype1 = CONST_TV_EMITTERTYPE.TV_EMITTER_MINIMESH;
						emitter1 = new propEmitterMinimesh();
						((propEmitterMinimesh) emitter1).MiniMesh = modParticleXML.GetValue(xNode, "modelfile", "");
						((propEmitterMinimesh) emitter1).Scale = new cVector(modParticleXML.GetValue(xNode, "scale", ""));
					}
				}
				modMain.fMain._propSystem.SelectedObject = emitter1;
				if (xNode.HasAttribute("max-particles"))
				{
					num1 = IntegerType.FromString(xNode.GetAttribute("max-particles"));
				}
				else
				{
					num1 = 0x40;
				}
				if (num1 == 0)
				{
					num1 = 0x40;
				}
				emitter1.ID = IntegerType.FromString(xNode.GetAttribute("id"));
			    emitter1.Type = CONST_TV_EMITTERTYPE.TV_EMITTER_POINTSPRITE; //const_tv_emittertype1;
				emitter1.Location = new cVector(modParticleXML.GetValue(xNode, "location", "0/0/0"));
				emitter1.MainDirection = new cVector(modParticleXML.GetValue(xNode, "direction", "0/0/0"));
				emitter1.Directional = BooleanType.FromString(modParticleXML.GetValue(xNode, "directional", "false"));
				emitter1.RandomDirectionFactor = new cVector(modParticleXML.GetValue(xNode, "randomdirectionfactor", "0/0/0"));
				emitter1.Power = SingleType.FromString(modParticleXML.GetValue(xNode, "power", "1"));
				emitter1.Lifetime = SingleType.FromString(modParticleXML.GetValue(xNode, "lifetime", "5"));
				emitter1.Shape = (CONST_TV_EMITTERSHAPE) IntegerType.FromString(modParticleXML.GetValue(xNode, "shape", StringType.FromInteger(0)));
				emitter1.Texture = modParticleXML.GetValue(xNode, "texture", "");
				emitter1.Color = new cColor(modParticleXML.GetValue(xNode, "color", "0,0,0,1"));
				emitter1.Speed = SingleType.FromString(modParticleXML.GetValue(xNode, "speed", "100"));
				emitter1.UseGravity = BooleanType.FromString(modParticleXML.GetValue(xNode, "usegravity", "true"));
				emitter1.Gravity = new cVector(modParticleXML.GetValue(xNode, "gravity", "0/-0.5/0"));
				emitter1.MaxParticles = num1;
				emitter1.AlphaChange = (CONST_TV_PARTICLECHANGE) IntegerType.FromString(modParticleXML.GetValue(xNode, "alphachange", StringType.FromInteger(1)));
				emitter1.AlphaBlending = (CONST_TV_BLENDINGMODE) IntegerType.FromString(modParticleXML.GetValue(xNode, "alphablending", StringType.FromInteger(1)));
				emitter1.EnableAlphaTest = BooleanType.FromString(modParticleXML.GetValue(xNode, "alphatest", "true"));
				emitter1.AlphaReference = SingleType.FromString(modParticleXML.GetValue(xNode, "alpharef", "0"));
				emitter1.DepthWrite = BooleanType.FromString(modParticleXML.GetValue(xNode, "alphadepthwrite", "0"));
				emitter1.BoxSize = new cVector(modParticleXML.GetValue(xNode, "boxsize", "0/0/0"));
				emitter1.SphereRadius = SingleType.FromString(modParticleXML.GetValue(xNode, "sphereradius", "0"));
				emitter1.Looping = BooleanType.FromString(modParticleXML.GetValue(xNode, "looping", "true"));
				modMain.fMain._propSystem.ExpandAllGridItems();
			}
		}
		
		public static void CreateEmitter (XmlElement xNode, bool bAddToTree)
		{
			if (xNode != null)
			{
				TreeNode node2 = null;
				CONST_TV_EMITTERTYPE eEmitterType =  CONST_TV_EMITTERTYPE.TV_EMITTER_POINTSPRITE;
				int iMaxParticles;
				IEnumerator enumerator1;
				string text2 = xNode.GetAttribute("type");
				if (StringType.StrCmp(text2, "pointsprite", false) == 0)
				{
					eEmitterType = CONST_TV_EMITTERTYPE.TV_EMITTER_POINTSPRITE;
				}
				else if (StringType.StrCmp(text2, "billboard", false) == 0)
				{
					eEmitterType = CONST_TV_EMITTERTYPE.TV_EMITTER_BILLBOARD;
				}
				else
				{
					if (StringType.StrCmp(text2, "minimesh", false) == 0)
					{
						eEmitterType = CONST_TV_EMITTERTYPE.TV_EMITTER_MINIMESH;
					}
				}
				if (xNode.HasAttribute("max-particles"))
				{
					iMaxParticles = IntegerType.FromString(xNode.GetAttribute("max-particles"));
				}
				else
				{
					iMaxParticles = 0x40;
				}
				if (iMaxParticles == 0)
				{
					iMaxParticles = 0x40;
				}
				int iEmitter = modMain.pSystem.CreateEmitter(eEmitterType, iMaxParticles);
				xNode.SetAttribute("id", StringType.FromInteger(iEmitter));
				if ((eEmitterType == CONST_TV_EMITTERTYPE.TV_EMITTER_MINIMESH) && (StringType.StrCmp(xNode.GetAttribute("modelfile"), "", false) != 0))
				{
					TVMesh pMesh = modMain.oScene.CreateMeshBuilder("mesh" + StringType.FromInteger(iEmitter));
					if (StringType.StrCmp(xNode.GetAttribute("scale"), "0/0/0", false) != 0)
					{
						cVector vector1 = new cVector(xNode.GetAttribute("scale"));
						pMesh.SetScale(vector1.x, vector1.y, vector1.z);
					}
					if (StringType.StrCmp(Strings.Right(xNode.GetAttribute("modelfile"), 4).ToUpper(), ".TVM", false) == 0)
					{
						pMesh.LoadTVM(xNode.GetAttribute("modelfile"));
					}
					else
					{
						if (StringType.StrCmp(Strings.Right(xNode.GetAttribute("modelfile"), 2).ToUpper(), ".X", false) == 0)
						{
							pMesh.LoadXFile(xNode.GetAttribute("modelfile"));
						}
						else
						{
							Interaction.MsgBox("Invalid mini-mesh format, must be TVM or X.", MsgBoxStyle.OkOnly , null);
							xNode.SetAttribute("modelfile", "");
							return;
						}
					}
					modMain.oEngine.AddToLog("Create: minimesh" + StringType.FromInteger(iEmitter));
					TVMiniMesh pMiniMesh = modMain.oScene.CreateMiniMesh(iMaxParticles, "minimesh" + StringType.FromInteger(iEmitter));
					int num3 = pMiniMesh.CreateFromMesh(pMesh);
					modMain.pSystem.SetMiniMesh(iEmitter, pMiniMesh);
					pMesh.Enable(false);
				}
				if (!modemitterUtils.SetEmitterTexture(ref xNode, xNode.GetAttribute("texture")))
				{
					xNode.SetAttribute("texture-missing", "true");
				}
				else
				{
					if (xNode.HasAttribute("texture-missing"))
					{
						xNode.RemoveAttribute("texture-missing");
					}
				}
				modMain.pSystem.SetEmitterPosition(iEmitter, new cVector(xNode.GetAttribute("location")).ToTVVector());
				if (StringType.StrCmp(xNode.GetAttribute("directional").ToUpper(), "TRUE", false) == 0)
				{
					modMain.pSystem.SetEmitterDirection(iEmitter, BooleanType.FromString(xNode.GetAttribute("directional")), new cVector(xNode.GetAttribute("direction")).ToTVVector(), new cVector(xNode.GetAttribute("randomdirectionfactor")).ToTVVector());
				}
				modMain.pSystem.SetEmitterPower(iEmitter, modUtil.ToNumeric(xNode.GetAttribute("power")), modUtil.ToNumeric(xNode.GetAttribute("lifetime")));
				modMain.pSystem.SetEmitterSpeed(iEmitter, modUtil.ToNumeric(xNode.GetAttribute("speed")));
				modMain.pSystem.SetParticleDefaultColor(iEmitter, new cColor(xNode.GetAttribute("color")).ToTVColor());
				string text1 = xNode.GetAttribute("shape");
				if (StringType.StrCmp(text1, "0", false) == 0)
				{
					modMain.pSystem.SetEmitterShape(iEmitter, CONST_TV_EMITTERSHAPE.TV_EMITTERSHAPE_POINT);
				}
				else if (StringType.StrCmp(text1, "1", false) == 0)
				{
					modMain.pSystem.SetEmitterShape(iEmitter, CONST_TV_EMITTERSHAPE.TV_EMITTERSHAPE_SPHEREVOLUME);
					modMain.pSystem.SetEmitterSphereRadius(iEmitter, modUtil.ToNumeric(xNode.GetAttribute("sphereradius")));
				}
				else if (StringType.StrCmp(text1, "2", false) == 0)
				{
					modMain.pSystem.SetEmitterShape(iEmitter, CONST_TV_EMITTERSHAPE.TV_EMITTERSHAPE_BOXVOLUME);
					modMain.pSystem.SetEmitterBoxSize(iEmitter, new cVector(xNode.GetAttribute("boxsize")).ToTVVector());
				}
				else if (StringType.StrCmp(text1, "3", false) == 0)
				{
					modMain.pSystem.SetEmitterShape(iEmitter, CONST_TV_EMITTERSHAPE.TV_EMITTERSHAPE_SPHERESURFACE);
					modMain.pSystem.SetEmitterSphereRadius(iEmitter, modUtil.ToNumeric(xNode.GetAttribute("sphereradius")));
				}
				else
				{
					if (StringType.StrCmp(text1, "4", false) == 0)
					{
						modMain.pSystem.SetEmitterShape(iEmitter, CONST_TV_EMITTERSHAPE.TV_EMITTERSHAPE_BOXSURFACE);
						modMain.pSystem.SetEmitterBoxSize(iEmitter, new cVector(xNode.GetAttribute("boxsize")).ToTVVector());
					}
				}
				if (StringType.StrCmp(xNode.GetAttribute("usegravity").ToUpper(), "TRUE", false) == 0)
				{
					modMain.pSystem.SetEmitterGravity(iEmitter, BooleanType.FromString(xNode.GetAttribute("usegravity")), new cVector(xNode.GetAttribute("gravity")).ToTVVector());
				}
				if ((StringType.StrCmp(xNode.GetAttribute("alphatest").ToUpper(), "TRUE", false) == 0) & (StringType.StrCmp(xNode.GetAttribute("alphadepthwrite").ToUpper(), "", false) != 0))
				{
					modMain.pSystem.SetEmitterAlphaTest(iEmitter, BooleanType.FromString(xNode.GetAttribute("alphatest")), (int) Math.Round((double) modUtil.ToNumeric(xNode.GetAttribute("alpharef"))), BooleanType.FromString(xNode.GetAttribute("alphadepthwrite")));
					modMain.pSystem.SetEmitterAlphaBlending(iEmitter, (CONST_TV_PARTICLECHANGE) ((int) Math.Round((double) modUtil.ToNumeric(xNode.GetAttribute("alphachange")))), (CONST_TV_BLENDINGMODE) ((int) Math.Round((double) modUtil.ToNumeric(xNode.GetAttribute("alphablending")))));
				}
				if (StringType.StrCmp(xNode.GetAttribute("looping").ToUpper(), "TRUE", false) == 0)
				{
					modMain.pSystem.SetEmitterLooping(iEmitter, true);
				}
				else
				{
					modMain.pSystem.SetEmitterLooping(iEmitter, false);
				}
				if (bAddToTree)
				{
					node2 = modMain.fMain.nodeParent.Nodes.Add(string.Concat(new string[]{"Emitter #", StringType.FromInteger(iEmitter), " (", xNode.GetAttribute("type"), ")"}));
					modMain.fMain.nodeParent.ExpandAll();
					modMain.fMain._treeSystem.SelectedNode = node2;
				}
				try
				{
					enumerator1 = xNode.ChildNodes.GetEnumerator();
					while (enumerator1.MoveNext())
					{
						TreeNode pNode = null;
						XmlElement element1 = (XmlElement) enumerator1.Current;
						if ((StringType.StrCmp(element1.Name, "emitter-keyframes", false) == 0) & (element1.ChildNodes.Count > 0))
						{
							if (bAddToTree)
							{
								pNode = node2.Nodes.Add("Emitter Keyframes");
							}
							else
							{
								pNode = null;
							}
							modEmitterKeyframeUtils.CreateEmitterKeyframes(iEmitter, pNode);
							continue;
						}
						if ((StringType.StrCmp(element1.Name, "particle-keyframes", false) == 0) & (element1.ChildNodes.Count > 0))
						{
							if (bAddToTree)
							{
								pNode = node2.Nodes.Add("Particle Keyframes");
							}
							else
							{
								pNode = null;
							}
							modParticleKeyframeUtils.CreateParticleKeyframes(iEmitter, pNode);
						}
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
		
		public static Collection GetEmitterErrors (int iID)
		{
			Collection collection1 = new Collection();
			XmlElement element1 = modemitterUtils.GetEmitterNode(iID);
			if (element1 != null)
			{
				if ((StringType.StrCmp(element1.GetAttribute("type"), "pointsprite", false) == 0) | (StringType.StrCmp(element1.GetAttribute("type"), "billboard", false) == 0))
				{
					if ((StringType.StrCmp(Strings.Left(element1.GetAttribute("color"), 6), "0,0,0,", false) == 0) | !element1.HasAttribute("color"))
					{
						collection1.Add("Emitter has no default color specified.", null, null, null);
					}
					else
					{
						if (StringType.StrCmp(Strings.Right(element1.GetAttribute("color"), 1), "0", false) == 0)
						{
							collection1.Add("Emitter has an alpha value of 0.", null, null, null);
						}
					}
					if ((StringType.StrCmp(element1.GetAttribute("texture"), "", false) == 0) | !element1.HasAttribute("texture"))
					{
						collection1.Add("Emitter does not have a texture specified.", null, null, null);
					}
					if (element1.HasAttribute("texture-missing"))
					{
						collection1.Add("Emitter texture is missing or invalid.", null, null, null);
					}
					if ((StringType.StrCmp(element1.GetAttribute("type"), "billboard", false) == 0) && (modUtil.ToNumeric(element1.GetAttribute("size")) <= 0.00F))
					{
						collection1.Add("Billboard size should be greater than 0.", null, null, null);
					}
				}
				if ((StringType.StrCmp(element1.GetAttribute("type"), "minimesh", false) == 0) && ((StringType.StrCmp(element1.GetAttribute("modelfile"), "", false) == 0) | !element1.HasAttribute("modelfile")))
				{
					collection1.Add("Emitter has no model loaded.", null, null, null);
				}
				if (((modUtil.ToNumeric(element1.GetAttribute("shape")) == 3.00F) | (modUtil.ToNumeric(element1.GetAttribute("shape")) == 1.00F)) && (modUtil.ToNumeric(element1.GetAttribute("sphereradius")) <= 0.00F))
				{
					collection1.Add("Emitter sphere radius should be greater than 0.", null, null, null);
				}
				if (((modUtil.ToNumeric(element1.GetAttribute("shape")) == 4.00F) | (modUtil.ToNumeric(element1.GetAttribute("shape")) == 2.00F)) && (StringType.StrCmp(element1.GetAttribute("boxsize"), "0/0/0", false) == 0))
				{
					collection1.Add("Emitter box size is 0/0/0.", null, null, null);
				}
			}
			if (collection1.Count == 0)
			{
				modMain.pSystem.SetEmitterEnable(iID, true);
				return collection1;
			}
			modMain.pSystem.SetEmitterEnable(iID, false);
			return collection1;
		}
		
		public static bool SetEmitterTexture (ref XmlElement xNode, string sFile)
		{
			int iTexture = -1;
			if (StringType.StrCmp(sFile, "", false) == 0)
			{
				return false;
			}
			if (!(File.Exists(sFile) | File.Exists(Application.StartupPath + @"\" + sFile)))
			{
				return false;
			}
			if (sFile.IndexOf(@":\") == -1)
			{
				sFile = Application.StartupPath + @"\" + sFile;
			}
			string[] textArray1 = Strings.Split(sFile, @"\", -1, 0);
			string sTextureName = textArray1[Information.UBound(textArray1, 1)];
			iTexture = modMain.oTex.LoadTexture(sFile, sTextureName, 0, 0, CONST_TV_COLORKEY.TV_COLORKEY_USE_ALPHA_CHANNEL);
			string text2 = xNode.GetAttribute("type");
			if (StringType.StrCmp(text2, "pointsprite", false) == 0)
			{
				modMain.pSystem.SetPointSprite(IntegerType.FromString(xNode.GetAttribute("id")), iTexture);
			}
			else if (StringType.StrCmp(text2, "billboard", false) == 0)
			{
				modMain.pSystem.SetBillboard(IntegerType.FromString(xNode.GetAttribute("id")), iTexture, SingleType.FromString(xNode.GetAttribute("size")), SingleType.FromString(xNode.GetAttribute("size")));
			}
			else
			{
				if (StringType.StrCmp(text2, "minimesh", false) == 0)
				{
					TVMiniMesh mesh1 = modMain.oGlobal.GetMiniMesh("minimesh" + xNode.GetAttribute("id"));
					if (mesh1 != null)
					{
						mesh1.SetTexture(iTexture);
					}
				}
			}
			return true;
		}
		
	}
}

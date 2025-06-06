using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;
using System;
using System.Collections;
using System.Windows.Forms;
using System.Xml;

namespace ParticleEditor
{
	[StandardModule]
	internal sealed class modEmitterKeyframeUtils
	{
		// Methods
		public static XmlElement GetEmitterKeyframeNode (int iEmitter, int iID)
		{
			return (XmlElement) modParticleXML.xParent.SelectSingleNode(string.Concat(new string[]{"emitter[@id=", StringType.FromInteger(iEmitter), "]/emitter-keyframes/keyframe[@id=", StringType.FromInteger(iID), "]"}));
		}
		
		public static void DeleteEmitterKeyframe (int iEmitter, int iID)
		{
			TreeNode node3 = null;
			XmlElement element2 = (XmlElement) modParticleXML.xParent.SelectSingleNode("emitter[@id=" + StringType.FromInteger(iEmitter) + "]/emitter-keyframes");
			XmlElement oldChild = modEmitterKeyframeUtils.GetEmitterKeyframeNode(iEmitter, iID);
			if ((oldChild != null) & (modParticleXML.xParent != null))
			{
				element2.RemoveChild(oldChild);
			}
			TreeNode node2 = modemitterUtils.GetEmitterTreeNode(iEmitter);
			foreach (TreeNode node4 in node2.Nodes)
			{
				if (StringType.StrCmp(node4.Text, "Emitter Keyframes", false) == 0)
				{
				    node3 = node4;
					break;
				}
			}
			if (node3 != null)
			{
				IEnumerator enumerator1;
				try
				{
					enumerator1 = node3.Nodes.GetEnumerator();
					while (enumerator1.MoveNext())
					{
						TreeNode node1 = (TreeNode) enumerator1.Current;
						if (StringType.StrCmp(node1.Text, "Emitter Keyframe #" + StringType.FromInteger(iID), false) == 0)
						{
							node1.Remove();
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
			if (element2.ChildNodes.Count == 0)
			{
				modemitterUtils.GetEmitterNode(iEmitter).RemoveChild(element2);
			}
			if ((node3 != null) && (node3.GetNodeCount(true) == 0))
			{
				node3.Remove();
			}
			modParticleXML.bNeedsReloading = true;
			modParticleXML.bNeedsSaving = true;
		}
		
		public static void AddEmitterKeyframe (XmlElement xEmitter)
		{
			XmlElement newChild = (XmlElement) xEmitter.SelectSingleNode("emitter-keyframes");
			if (newChild == null)
			{
				newChild = modParticleXML.xDoc.CreateElement("emitter-keyframes");
				xEmitter.AppendChild(newChild);
			}
			int num1 = xEmitter.SelectSingleNode("emitter-keyframes").ChildNodes.Count;
			XmlElement element1 = modParticleXML.xDoc.CreateElement("keyframe");
			element1.SetAttribute("id", StringType.FromInteger(num1));
			newChild.AppendChild(element1);
			TreeNode node1 = modemitterUtils.GetEmitterTreeNode(IntegerType.FromString(xEmitter.GetAttribute("id")));
			if (node1 == null)
			{
				Interaction.MsgBox("Unable to find Emitter TreeNode to add keyframe, please restart.", 0, null);
			}
			else
			{
				TreeNode node2 = null;
				foreach (TreeNode node3 in node1.Nodes)
				{
					if (StringType.StrCmp(node3.Text, "Emitter Keyframes", false) == 0)
					{
					    node2 = node3;
						break;
					}
				}
				if (node2 == null)
				{
					node2 = node1.Nodes.Add("Emitter Keyframes");
				}
				node2.Nodes.Add("Emitter Keyframe #" + StringType.FromInteger(num1));
				modMain.fMain._treeSystem.ExpandAll();
				modParticleXML.bNeedsReloading = true;
				modParticleXML.bNeedsSaving = true;
			}
		}
		
		public static void LoadEmitterKeyframeProps (int iEmitter, int iID)
		{
			XmlElement xNode = (XmlElement) modParticleXML.xParent.SelectSingleNode(string.Concat(new string[]{"emitter[@id=", StringType.FromInteger(iEmitter), "]/emitter-keyframes/keyframe[@id=", StringType.FromInteger(iID), "]"}));
			if (xNode != null)
			{
				propEmitterKeyframe keyframe1 = new propEmitterKeyframe();
				keyframe1.Parent = iEmitter;
				keyframe1.ID = iID;
				keyframe1.BoxSize = new cVector(modParticleXML.GetValue(xNode, "boxsize", "0/0/0"));
				keyframe1.Color = new cColor(modParticleXML.GetValue(xNode, "color", "0,0,0,0"));
				keyframe1.KeyFrame = SingleType.FromString(modParticleXML.GetValue(xNode, "key", "0"));
				keyframe1.Lifetime = SingleType.FromString(modParticleXML.GetValue(xNode, "lifetime", "0"));
				keyframe1.Location = new cVector(modParticleXML.GetValue(xNode, "location", "0/0/0"));
				keyframe1.MainDirection = new cVector(modParticleXML.GetValue(xNode, "direction", "0/0/0"));
				keyframe1.Power = SingleType.FromString(modParticleXML.GetValue(xNode, "power", "0"));
				keyframe1.Speed = SingleType.FromString(modParticleXML.GetValue(xNode, "speed", "0"));
				keyframe1.SphereRadius = SingleType.FromString(modParticleXML.GetValue(xNode, "sphereradius", "0"));
				modMain.fMain._propSystem.SelectedObject = keyframe1;
				modMain.fMain._propSystem.ExpandAllGridItems();
			}
		}
		
		public static void CreateEmitterKeyframes (int iEmt, TreeNode pNode)
		{
			int iNumKeyFrames = 0;
			int eEmitterKeyUsage = 0;
			XmlNodeList list1 = modemitterUtils.GetEmitterNode(iEmt).SelectSingleNode("emitter-keyframes").ChildNodes;
			TV_PARTICLEEMITTER_KEYFRAME[] pFirstKeyFrameArray = new TV_PARTICLEEMITTER_KEYFRAME[(list1.Count - 1) + 1];
			foreach (XmlElement xNode in list1)
			{
				xNode.SetAttribute("id", StringType.FromInteger(iNumKeyFrames));
				if (StringType.StrCmp(modParticleXML.GetValue(xNode, "sphereradius", "0"), "0", false) != 0)
				{
					pFirstKeyFrameArray[iNumKeyFrames].fGeneratorSphereRadius = SingleType.FromString(modParticleXML.GetValue(xNode, "sphereradius", ""));
					eEmitterKeyUsage = 8 | eEmitterKeyUsage;
				}
				if (StringType.StrCmp(modParticleXML.GetValue(xNode, "key", "0"), "0", false) != 0)
				{
					pFirstKeyFrameArray[iNumKeyFrames].fKey = SingleType.FromString(modParticleXML.GetValue(xNode, "key", ""));
				}
				if (StringType.StrCmp(modParticleXML.GetValue(xNode, "lifetime", "0"), "0", false) != 0)
				{
					pFirstKeyFrameArray[iNumKeyFrames].fParticleLifeTime = SingleType.FromString(modParticleXML.GetValue(xNode, "lifetime", ""));
					eEmitterKeyUsage = 0x20 | eEmitterKeyUsage;
				}
				if (StringType.StrCmp(modParticleXML.GetValue(xNode, "power", "0"), "0", false) != 0)
				{
					pFirstKeyFrameArray[iNumKeyFrames].fPower = SingleType.FromString(modParticleXML.GetValue(xNode, "power", ""));
					eEmitterKeyUsage = 0x40 | eEmitterKeyUsage;
				}
				if (StringType.StrCmp(modParticleXML.GetValue(xNode, "speed", "0"), "0", false) != 0)
				{
					pFirstKeyFrameArray[iNumKeyFrames].fSpeed = SingleType.FromString(modParticleXML.GetValue(xNode, "speed", ""));
					eEmitterKeyUsage = 0x10 | eEmitterKeyUsage;
				}
				if (StringType.StrCmp(modParticleXML.GetValue(xNode, "color", "0,0,0,0"), "0,0,0,0", false) != 0)
				{
					pFirstKeyFrameArray[iNumKeyFrames].vDefaultColor = new cColor(modParticleXML.GetValue(xNode, "color", "")).ToTVColor();
					eEmitterKeyUsage = 4 | eEmitterKeyUsage;
				}
				if (StringType.StrCmp(modParticleXML.GetValue(xNode, "boxsize", "0/0/0"), "0/0/0", false) != 0)
				{
					pFirstKeyFrameArray[iNumKeyFrames].vGeneratorBoxSize = new cVector(modParticleXML.GetValue(xNode, "boxsize", "")).ToTVVector();
					eEmitterKeyUsage = 0x80 | eEmitterKeyUsage;
				}
				if (StringType.StrCmp(modParticleXML.GetValue(xNode, "location", "0/0/0"), "0/0/0", false) != 0)
				{
					pFirstKeyFrameArray[iNumKeyFrames].vLocalPosition = new cVector(modParticleXML.GetValue(xNode, "location", "")).ToTVVector();
					eEmitterKeyUsage = 1 | eEmitterKeyUsage;
				}
				if (StringType.StrCmp(modParticleXML.GetValue(xNode, "direction", "0/0/0"), "0/0/0", false) != 0)
				{
					pFirstKeyFrameArray[iNumKeyFrames].vMainDirection = new cVector(modParticleXML.GetValue(xNode, "direction", "")).ToTVVector();
					eEmitterKeyUsage = 2 | eEmitterKeyUsage;
				}
				if (pNode != null)
				{
					pNode.Nodes.Add("Emitter Keyframe #" + StringType.FromInteger(iNumKeyFrames));
				}
				iNumKeyFrames++;
			}
			modMain.pSystem.SetEmitterKeyFrames(iEmt, eEmitterKeyUsage, iNumKeyFrames, pFirstKeyFrameArray);
			modMain.fMain.nodeParent.ExpandAll();
		}
		
	}
}

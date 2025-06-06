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
	internal sealed class modParticleKeyframeUtils
	{
		// Methods
		public static XmlElement GetParticleKeyframeNode (int iEmitter, int iID)
		{
			return (XmlElement) modParticleXML.xParent.SelectSingleNode(string.Concat(new string[]{"emitter[@id=", StringType.FromInteger(iEmitter), "]/particle-keyframes/keyframe[@id=", StringType.FromInteger(iID), "]"}));
		}
		
		public static void DeleteParticleKeyframe (int iEmitter, int iID)
		{
			TreeNode node3 = null;
			XmlElement element2 = (XmlElement) modParticleXML.xParent.SelectSingleNode("emitter[@id=" + StringType.FromInteger(iEmitter) + "]/particle-keyframes");
			XmlElement oldChild = modParticleKeyframeUtils.GetParticleKeyframeNode(iEmitter, iID);
			if ((oldChild != null) & (modParticleXML.xParent != null))
			{
				element2.RemoveChild(oldChild);
			}
			TreeNode node2 = modemitterUtils.GetEmitterTreeNode(iEmitter);
			
            foreach (TreeNode node4 in node2.Nodes)
			{
				if (StringType.StrCmp(node4.Text, "Particle Keyframes", false) == 0)
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
						if (StringType.StrCmp(node1.Text, "Particle Keyframe #" + StringType.FromInteger(iID), false) == 0)
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
		
		public static void AddParticleKeyframe (XmlElement xEmitter)
		{
			XmlElement newChild = (XmlElement) xEmitter.SelectSingleNode("particle-keyframes");
			if (newChild == null)
			{
				newChild = modParticleXML.xDoc.CreateElement("particle-keyframes");
				xEmitter.AppendChild(newChild);
			}
			int num1 = xEmitter.SelectSingleNode("particle-keyframes").ChildNodes.Count;
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
					if (StringType.StrCmp(node3.Text, "Particle Keyframes", false) == 0)
					{
					    node2 = node3;
						break;
					}
				}
				if (node2 == null)
				{
					node2 = node1.Nodes.Add("Particle Keyframes");
				}
				node2.Nodes.Add("Particle Keyframe #" + StringType.FromInteger(num1));
				modMain.fMain._treeSystem.ExpandAll();
				modParticleXML.bNeedsReloading = true;
				modParticleXML.bNeedsSaving = true;
			}
		}
		
		public static void LoadParticleKeyframeProps (int iEmitter, int iID)
		{
			XmlElement xNode = (XmlElement) modParticleXML.xParent.SelectSingleNode(string.Concat(new string[]{"emitter[@id=", StringType.FromInteger(iEmitter), "]/particle-keyframes/keyframe[@id=", StringType.FromInteger(iID), "]"}));
			if (xNode != null)
			{
				propParticleKeyframe keyframe1 = new propParticleKeyframe();
				keyframe1.Parent = iEmitter;
				keyframe1.ID = iID;
				keyframe1.Color = new cColor(modParticleXML.GetValue(xNode, "color", "0,0,0,0"));
				keyframe1.KeyFrame = SingleType.FromString(modParticleXML.GetValue(xNode, "key", "0"));
				keyframe1.Size = new cVector(modParticleXML.GetValue(xNode, "size", "0/0/0"));
				modMain.fMain._propSystem.SelectedObject = keyframe1;
				modMain.fMain._propSystem.ExpandAllGridItems();
			}
		}
		
		public static void CreateParticleKeyframes (int iEmt, TreeNode pNode)
		{
			int iNumKeyFrames=0;
			int eParticleKeyUsage = -1;
			XmlNodeList list1 = modemitterUtils.GetEmitterNode(iEmt).SelectSingleNode("particle-keyframes").ChildNodes;
			TV_PARTICLE_KEYFRAME[] pFirstKeyFrameArray = new TV_PARTICLE_KEYFRAME[(list1.Count - 1) + 1];
			foreach (XmlElement xNode in list1)
			{
				xNode.SetAttribute("id", StringType.FromInteger(iNumKeyFrames));
				if (StringType.StrCmp(modParticleXML.GetValue(xNode, "key", "0"), "0", false) != 0)
				{
					pFirstKeyFrameArray[iNumKeyFrames].fKey = SingleType.FromString(modParticleXML.GetValue(xNode, "key", ""));
				}
				if (StringType.StrCmp(modParticleXML.GetValue(xNode, "size", "0/0/0"), "0/0/0", false) != 0)
				{
					pFirstKeyFrameArray[iNumKeyFrames].fSize = new cVector(modParticleXML.GetValue(xNode, "size", "")).ToTVVector();
					modUtil.SetBit(ref eParticleKeyUsage, CONST_TV_PARTICLE_KEYUSAGE.TV_PARTICLE_KEYUSAGE_SIZE);
				}
				if (StringType.StrCmp(modParticleXML.GetValue(xNode, "color", "0,0,0,0"), "0,0,0,0", false) != 0)
				{
					pFirstKeyFrameArray[iNumKeyFrames].cColor = new cColor(modParticleXML.GetValue(xNode, "color", "")).ToTVColor();
					modUtil.SetBit(ref eParticleKeyUsage, CONST_TV_PARTICLE_KEYUSAGE.TV_PARTICLE_KEYUSAGE_COLOR);
				}
				if (pNode != null)
				{
					pNode.Nodes.Add("Particle Keyframe #" + StringType.FromInteger(iNumKeyFrames));
				}
				iNumKeyFrames++;
			}
			modMain.pSystem.SetParticleKeyFrames(iEmt, eParticleKeyUsage, iNumKeyFrames, pFirstKeyFrameArray);
			modMain.fMain.nodeParent.ExpandAll();
		}
		
	}
}

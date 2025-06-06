using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;
using System;
using System.Windows.Forms;
using System.Xml;

namespace ParticleEditor
{
	[StandardModule]
	internal sealed class modAttractorUtils
	{
		// Methods
		public static XmlElement GetAttractorNode (int iID)
		{
			return (XmlElement) modParticleXML.xParent.SelectSingleNode("attractor[@id=" + StringType.FromInteger(iID) + "]");
		}
		
		public static TreeNode GetAttractorTreeNode (int iID)
		{
			foreach (TreeNode node2 in modMain.fMain.nodeParent.Nodes)
			{
				if (StringType.StrCmp(Strings.Left(node2.Text, Strings.Len("Attractor #" + StringType.FromInteger(iID))), "Attractor #" + StringType.FromInteger(iID), false) == 0)
				{
					return node2;
				}
			}
			return null;
		}
		
		public static void DeleteAttractor (int iID)
		{
			XmlElement oldChild = modAttractorUtils.GetAttractorNode(iID);
			if (oldChild != null)
			{
				modParticleXML.xParent.RemoveChild(oldChild);
			}
			TreeNode node1 = modAttractorUtils.GetAttractorTreeNode(iID);
			if (node1 != null)
			{
				node1.Remove();
			}
		}
		
		public static void AddAttractor ()
		{
			if (modParticleXML.bNeedsReloading)
			{
				modParticleXML.ReloadSystem(false);
			}
			XmlElement xNode = modParticleXML.xDoc.CreateElement("attractor");
			xNode.SetAttribute("directional", "false");
			modAttractorUtils.CreateAttractor(xNode, true);
			modAttractorUtils.LoadAttractorProps(xNode);
			modParticleXML.xParent.AppendChild(xNode);
			modParticleXML.bNeedsSaving = true;
		}
		
		public static void LoadAttractorProps (int iID)
		{
			XmlElement xNode = (XmlElement) modParticleXML.xParent.SelectSingleNode("attractor[@id=" + StringType.FromInteger(iID) + "]");
			modAttractorUtils.LoadAttractorProps(xNode);
		}
		
		public static void LoadAttractorProps (XmlElement xNode)
		{
			propAttractor attractor1 = new propAttractor();
			modMain.fMain._propSystem.SelectedObject = attractor1;
			attractor1.ID = IntegerType.FromString(xNode.GetAttribute("id"));
			attractor1.Location = new cVector(modParticleXML.GetValue(xNode, "location", ""));
			attractor1.Attenuation = new cVector(modParticleXML.GetValue(xNode, "attenuation", "1/0/0"));
			attractor1.Directional = BooleanType.FromString(modParticleXML.GetValue(xNode, "directional", "false"));
			attractor1.FieldDirection = new cVector(modParticleXML.GetValue(xNode, "fielddirection", "0/1/0"));
			attractor1.RepulsionConstant = SingleType.FromString(modParticleXML.GetValue(xNode, "repulsionconst", StringType.FromInteger(1)));
			attractor1.VelocityDependency = (CONST_TV_ATTRACTORVELOCITYPOWER) IntegerType.FromString(modParticleXML.GetValue(xNode, "velocitydepend", StringType.FromInteger(0)));
			attractor1.Radius = SingleType.FromString(modParticleXML.GetValue(xNode, "radius", StringType.FromInteger(10)));
			modMain.fMain._propSystem.ExpandAllGridItems();
		}
		
		public static void CreateAttractor (XmlElement xNode, bool bAddToTree)
		{
			if (xNode != null)
			{
				propAttractor attractor1 = new propAttractor();
				int iAttractor = modMain.pSystem.CreateAttractor(BooleanType.FromString(xNode.GetAttribute("directional")));
				xNode.SetAttribute("id", StringType.FromInteger(iAttractor));
				modMain.pSystem.SetAttractorPosition(iAttractor, new cVector(modParticleXML.GetValue(xNode, "location", "")).ToTVVector());
				modMain.pSystem.SetAttractorAttenuation(iAttractor, new cVector(modParticleXML.GetValue(xNode, "attenuation", "1/0/0")).ToTVVector());
				modMain.pSystem.SetAttractorRadius(iAttractor, SingleType.FromString(modParticleXML.GetValue(xNode, "radius", StringType.FromInteger(10))));
				modMain.pSystem.SetAttractorParameters(iAttractor, SingleType.FromString(modParticleXML.GetValue(xNode, "repulsionconst", StringType.FromInteger(1))), (CONST_TV_ATTRACTORVELOCITYPOWER) IntegerType.FromString(modParticleXML.GetValue(xNode, "velocitydepend", StringType.FromInteger(0))));
				modMain.pSystem.SetAttractorFieldDirection(iAttractor, new cVector(modParticleXML.GetValue(xNode, "fielddirection", "0/1/0")).ToTVVector());
				if (bAddToTree)
				{
					modMain.fMain.nodeParent.Nodes.Add("Attractor #" + StringType.FromInteger(iAttractor));
					modMain.fMain.nodeParent.ExpandAll();
				}
			}
		}
		
	}
}

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;

namespace ParticleEditor
{
	[StandardModule]
	internal sealed class modOptions
	{
        // Statics
        private static XmlDocument xOptions;
        private static XmlElement xParent;
        private static string sOptionsFile;

		// Constructors
		static modOptions ()
		{
			modOptions.xOptions = new XmlDocument();
			modOptions.sOptionsFile = Application.StartupPath + @"\options.xml";
		}
		
		
		// Methods
		public static void LoadOptions ()
		{
			int num1;
			int num2;
            try
            {
                ProjectData.ClearProjectError();
                num2 = 1;
                modOptions.xOptions.Load(modOptions.sOptionsFile);
                modOptions.xParent = (XmlElement)modOptions.xOptions.SelectSingleNode("/options");
            }
            catch (Exception exception2)
            {
                modOptions.xOptions.LoadXml("<options></options>");
                modOptions.xParent = (XmlElement) modOptions.xOptions.SelectSingleNode("/options");
            }
		}
		
		public static void SaveOptions ()
		{
			modOptions.xOptions.Save(modOptions.sOptionsFile);
		}
		
		public static object GetOption (string sName, [Optional]string sDefault/* = null*/)
		{
			XmlElement element1 = (XmlElement) modOptions.xParent.SelectSingleNode(sName);
			if (element1 == null)
			{
				return sDefault;
			}
			return element1.GetAttribute("value");
		}
		
		public static void SetOption (string sName, string sVal)
		{
			XmlElement newChild = (XmlElement) modOptions.xParent.SelectSingleNode(sName);
			if (newChild == null)
			{
				newChild = modOptions.xOptions.CreateElement(sName);
				modOptions.xParent.AppendChild(newChild);
			}
			newChild.SetAttribute("value", sVal);
		}
	}
}

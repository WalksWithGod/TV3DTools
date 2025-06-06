#region

using System;
using System.Runtime.InteropServices;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

#endregion

namespace ModelView
{
    [StandardModule]
    internal sealed class mOptions
    {
        // Constructors
        static mOptions()
        {
            xOptions = new XmlDocument();
        }


        // Methods
        public static void LoadOptions()
        {
            try
            {
                ProjectData.ClearProjectError();
                xOptions.Load(mGlobalProperties.sOptionsFile);
                xParent = (XmlElement) xOptions.SelectSingleNode("/options");
                
            }
            catch (Exception)
            {
                // Hypnotron : bad decompile... guessing what should happen here is 
                // try an alternate version of loading the options with nested try/catch
                try
                {
                    xOptions.LoadXml("<options></options>");
                    xParent = (XmlElement)xOptions.SelectSingleNode("/options");

                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        public static void SaveOptions()
        {
            xOptions.Save(mGlobalProperties.sOptionsFile);
        }

        public static object GetOption(string sName, [Optional] string sDefault /* = null*/)
        {
            XmlElement element1 = (XmlElement) xParent.SelectSingleNode(sName);
            if (element1 == null)
            {
                return sDefault;
            }
            return element1.GetAttribute("value");
        }

        public static void SetOption(string sName, string sVal)
        {
            XmlElement newChild = (XmlElement) xParent.SelectSingleNode(sName);
            if (newChild == null)
            {
                newChild = xOptions.CreateElement(sName);
                xParent.AppendChild(newChild);
            }
            newChild.SetAttribute("value", sVal);
        }


        // Statics
        private static XmlDocument xOptions;
        private static XmlElement xParent;
    }
}
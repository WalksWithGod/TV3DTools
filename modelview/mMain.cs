#region

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

#endregion

namespace ModelView
{
    [StandardModule]
    internal sealed class mMain
    {
        // Methods
        [STAThread]
        public static void Main(string[] sArgs)
        {
            modLocalize.ForceRegionalSettings();
            mComponents.InitComponents();
            mComponents.eDoRender = mComponents.enumDoRender.Normal;
            if (sArgs.Length > 0)
            {
                if (StringType.StrCmp(Strings.UCase(Strings.Right(sArgs[0], 4)), ".TVM", false) == 0)
                {
                    mTV3D.OpenFile(sArgs[0], mTV3D.CONST_TV_FORMAT.TV_FORMAT_TVM);
                }
                else if (StringType.StrCmp(Strings.UCase(Strings.Right(sArgs[0], 4)), ".TVA", false) == 0)
                {
                    mTV3D.OpenFile(sArgs[0], mTV3D.CONST_TV_FORMAT.TV_FORMAT_TVA);
                }
                else
                {
                    if (StringType.StrCmp(Strings.UCase(Strings.Right(sArgs[0], 2)), ".X", false) == 0)
                    {
                        mTV3D.OpenFile(sArgs[0], mTV3D.CONST_TV_FORMAT.TV_FORMAT_DX);
                    }
                }
            }
            do
            {
                if (mComponents.eDoRender != mComponents.enumDoRender.Pause)
                {
                    if (mGlobalProperties.bDoInput)
                    {
                        mTV3D.HandleInput();
                    }
                    mTV3D.Render();
                }
                else
                {
                    Thread.Sleep(0x64);
                }
                Application.DoEvents();
            } while (!((mComponents.eDoRender == mComponents.enumDoRender.Quit) | mComponents.bClosingApp));
            mComponents.DestroyComponents();
            ProjectData.EndApp();
        }

        public static string GetFileContents(string FullPath, [Optional] ref string ErrInfo /* = null*/)
        {
            string text1 = "";
            try
            {
                StreamReader reader1 = new StreamReader(FullPath);
                string text2 = reader1.ReadToEnd();
                reader1.Close();
                text1 = text2;
            }
            catch (Exception exception2)
            {
                ProjectData.SetProjectError(exception2);
                Exception exception1 = exception2;
                ErrInfo = exception1.Message;
                ProjectData.ClearProjectError();
            }
            return text1;
        }

        public static bool SaveTextToFile(string strData, string FullPath, [Optional] string ErrInfo /* = null*/)
        {
            bool flag1 = false;
            try
            {
                StreamWriter writer1 = new StreamWriter(FullPath);
                writer1.Write(strData);
                writer1.Close();
                flag1 = true;
            }
            catch (Exception exception2)
            {
                ProjectData.SetProjectError(exception2);
                Exception exception1 = exception2;
                ErrInfo = exception1.Message;
                ProjectData.ClearProjectError();
            }
            return flag1;
        }
    }
}
#region

using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

#endregion

namespace ModelView
{
    public class cMorphTargetProperties
    {
        // Instance Fields
        internal string sName;
        internal string sPoseMesh;
        internal int iComboIndex;
        internal int iArrayIndex;
        internal bool bReference;
        internal int iReference;

        // Constructors
        public cMorphTargetProperties()
        {
            sName = "NewMorph";
        }


        // Properties
        [Category("Morph Targets"), DesignOnly(false), Browsable(true), ReadOnly(false)]
        public string Name
        {
            get { return sName; }
            set
            {
                sName = value;
                mComponents.pFrmMorphTargets.comboMorphTargets.Items[iComboIndex] = value;
            }
        }

        [DesignOnly(false), Category("Morph Targets"), Editor(typeof (FileNameEditor), typeof (UITypeEditor)),
         ReadOnly(false), Browsable(true)]
        public string PoseMesh
        {
            get { return sPoseMesh; }
            set
            {
                if (StringType.StrCmp(Strings.UCase(Strings.Right(value, 3)), "TVM", false) == 0)
                {
                    mComponents.arrayMeshPose[iArrayIndex].ResetMesh();
                    mComponents.arrayMeshPose[iArrayIndex].LoadTVM(value, false, false);
                    sPoseMesh = value;
                }
                else if (StringType.StrCmp(Strings.UCase(Strings.Right(value, 1)), "X", false) == 0)
                {
                    mComponents.arrayMeshPose[iArrayIndex].ResetMesh();
                    mComponents.arrayMeshPose[iArrayIndex].LoadXFile(value, false, false);
                    sPoseMesh = value;
                }
                else
                {
                    Interaction.MsgBox("Please load a model of format X or TVM.", 0, null);
                }
            }
        }

        [Browsable(true), DesignOnly(false), Category("Morph Targets"), ReadOnly(true)]
        public int Index
        {
            get { return iArrayIndex; }
            set { iArrayIndex = value; }
        }

        [Category("Morph Targets"), DesignOnly(false), ReadOnly(false), Browsable(true)]
        public bool Reference
        {
            get
            {
                if (iReference != mGlobalProperties.iReferenceModelIndex)
                {
                    bReference = false;
                }
                return bReference;
            }
            set
            {
                bReference = value;
                mGlobalProperties.iReferenceModelIndex = iReference;
            }
        }
    }
}
#region

using System;
using System.ComponentModel;
using Microsoft.VisualBasic;

#endregion

namespace ModelView
{
    public class cAnimationRangeProperties
    {
        // Instance Fields
        internal string sName;
        internal float fStartFrame;
        internal float fEndFrame;
        internal int iComboIndex;
        internal int iArrayIndex;
        internal Collection collSourceAnimation;
        internal int iSrcAnimation;
        internal float fSrcAnimationLength;

        // Constructors
        public cAnimationRangeProperties()
        {
            sName = "New Animation";
            collSourceAnimation = new Collection();
            fSrcAnimationLength = mComponents.pActor.GetAnimationLength(0);
        }

        // Properties
        [Browsable(true), ReadOnly(false), Category("Animation Ranges"), DesignOnly(false)]
        public string Name
        {
            get { return sName; }
            set { sName = value; }
        }

        [Browsable(true), Category("Animation Ranges"), ReadOnly(false), DesignOnly(false)]
        public float FrameStart
        {
            get { return fStartFrame; }
            set { fStartFrame = value; }
        }

        [Browsable(true), ReadOnly(false), Category("Animation Ranges"), DesignOnly(false)]
        public float FrameEnd
        {
            get { return fEndFrame; }
            set
            {
                if (value > fSrcAnimationLength)
                {
                    Interaction.MsgBox("End frame is out of animation length bounds.", 0, "Error");
                }
                else
                {
                    fEndFrame = value;
                }
            }
        }

        [Category("Animation Ranges"), ReadOnly(false), Browsable(true), DesignOnly(false)]
        public int SourceAnimationID
        {
            get { return iSrcAnimation; }
            set
            {
                if (value > (mComponents.pActor.GetAnimationCount() - 1))
                {
                    Interaction.MsgBox("You cannot choose a non existant animation ID.", 0, "Error");
                }
                else
                {
                    iSrcAnimation = value;
                    fSrcAnimationLength = mComponents.pActor.GetAnimationLength(value);
                    mComponents.pFrmAnimationRanges.propertiesAnimationRange.Refresh();
                }
            }
        }

        [ReadOnly(true), Browsable(true), DesignOnly(false), Category("Animation Ranges")]
        private int Index
        {
            get { return iArrayIndex; }
            set { iArrayIndex = value; }
        }

        [ReadOnly(true), Browsable(true), Category("Animation Ranges"), DesignOnly(false)]
        public int SourceAnimationLength
        {
            get { return (int) Math.Round(fSrcAnimationLength); }
            set { fSrcAnimationLength = value; }
        }
    }
}
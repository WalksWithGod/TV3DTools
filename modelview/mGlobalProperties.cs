#region

using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;

#endregion

namespace ModelView
{
    [StandardModule]
    internal sealed class mGlobalProperties
    {
        // Statics
        public static CONST_TV_LIGHTINGMODE eLightMode;
        public static int iTriangles;
        public static int iVertexes;
        public static string sModelFileName;
        public static int iReferenceModelIndex;
        public static string sDockLayout;
        public static string sDockLayoutDefault;
        public static int iSelectedGroup;
        public static bool bInitedDone;
        public static bool bDoInput;
        public static bool bDenySaveAs;
        public static bool bPlayBackwards;
        public static int meshIndex;
        public static bool bLightCollision;
        public static bool bGlowDone;
        public static bool bGlow;
        public static bool bDOF;
        public static bool bMotionBlur;
        public static bool bShowGrid;
        public static bool bShowBoundingBox;
        public static bool bShowSkeleton;
        public static bool bShowBoneNames;
        public static string sOptionsFile;
        public static bool bMouseInRender;

        // Constructors
        static mGlobalProperties()
        {
            eLightMode = 0;
            iSelectedGroup = -1;
            bInitedDone = false;
            bDoInput = true;
            bDenySaveAs = false;
            bPlayBackwards = false;
            bLightCollision = false;
            bGlowDone = false;
            bGlow = false;
            bDOF = false;
            bMotionBlur = false;
            bShowGrid = true;
            bShowBoundingBox = false;
            bShowSkeleton = false;
            bShowBoneNames = false;
        }
    }
}
#region

using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;

#endregion

namespace ModelView
{
    public class cMeshProperties
    {
        // Instance Fields
        internal string sTexture;
        internal string sHeightMap;
        internal string sNormalMap;
        internal string sBumpMap;
        internal string sDetailMap;
        internal string sEmissiveMap;
        internal string sLightmap;
        internal string sSpecularmap;
        internal string sStage0;
        internal string sStage1;
        internal string sStage2;
        internal string sStage3;
        internal string sShader;
        internal string sAlphaMap;
        internal int iAlphaMap;
        internal int iTexture;
        internal int iHeightMap;
        internal int iNormalMap;
        internal int iBumpMap;
        internal int iDetailMap;
        internal int iEmissiveMap;
        internal int iLightmap;
        internal int iSpecularmap;
        internal int iAlphaTex;
        internal int iStage0;
        internal int iStage1;
        internal int iStage2;
        internal int iStage3;
        internal int iShader;
        internal int iOldStage1;
        internal bool bEnablePRTSubs;
        internal TV_COLOR eAbsorption;
        internal TV_COLOR eReducedScattering;
        internal float fRefractionIndexRatio;
        internal CONST_TV_BLENDINGMODE eBlendingMode;
        internal bool bAlphaTest;
        internal int iAlphaRef;
        internal CONST_TV_CULLING eCullMode;

        // Constructors
        public cMeshProperties()
        {
            eAbsorption = mComponents.pG.TVColor(0.00F, 0.00F, 0.00F, 0.00F);
            eReducedScattering = mComponents.pG.TVColor(0.00F, 0.00F, 0.00F, 0.00F);
            eBlendingMode = 0;
            eCullMode = CONST_TV_CULLING.TV_BACK_CULL;
            sTexture = "";
            sHeightMap = "";
            sNormalMap = "";
            sAlphaMap = "";
            iTexture = 0;
            iHeightMap = 0;
            iNormalMap = 0;
            iAlphaMap = 0;
            iOldStage1 = 0;
        }


        // Properties
        [ReadOnly(false), Category("Alpha blending"), DesignOnly(false), Browsable(true)]
        public CONST_TV_BLENDINGMODE BlendingMode
        {
            get { return eBlendingMode; }
            set
            {
                eBlendingMode = value;
                mComponents.pMesh.SetBlendingMode(value);
            }
        }

        [Browsable(true), Category("Alpha blending"), ReadOnly(false), DesignOnly(false)]
        public int AlphaTestRef
        {
            get { return iAlphaRef; }
            set
            {
                iAlphaRef = value;
                mComponents.pMesh.SetAlphaTest(bAlphaTest, iAlphaRef);
            }
        }

        [Browsable(true), DesignOnly(false), Category("Alpha blending"), ReadOnly(false)]
        public bool AlphaTest
        {
            get { return bAlphaTest; }
            set
            {
                bAlphaTest = value;
                mComponents.pMesh.SetAlphaTest(bAlphaTest, iAlphaRef);
            }
        }

        [Browsable(true), Category("Rendering"), ReadOnly(false), DesignOnly(false)]
        public CONST_TV_CULLING Culling
        {
            get { return eCullMode; }
            set
            {
                eCullMode = value;
                mComponents.pMesh.SetCullMode(value);
            }
        }

        [DesignOnly(false), ReadOnly(false), Category("Stages"), Editor(typeof (FileNameEditor), typeof (UITypeEditor)),
         Browsable(true)]
        public string Stage0_Texture
        {
            get { return sTexture; }
            set
            {
                sTexture = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iTexture = mComponents.pTextureFactory.LoadTexture(value);
                    mComponents.pMesh.SetTexture(iTexture, mGlobalProperties.iSelectedGroup);
                    sStage0 = "";
                    iStage0 = iTexture;
                }
                else
                {
                    mComponents.pMesh.SetTexture(0, mGlobalProperties.iSelectedGroup);
                    iStage0 = 0;
                }
            }
        }

        [Browsable(true), Editor(typeof (FileNameEditor), typeof (UITypeEditor)), DesignOnly(false),
         Category("Manual Stages"), ReadOnly(false)]
        public string Stage0
        {
            get { return sStage0; }
            set
            {
                sStage0 = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iStage0 = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                    mComponents.pMesh.SetTextureEx(0, iStage0, mGlobalProperties.iSelectedGroup);
                }
                else
                {
                    mComponents.pMesh.SetTextureEx(0, 0, mGlobalProperties.iSelectedGroup);
                    iStage0 = 0;
                }
            }
        }

        [ReadOnly(false), Editor(typeof (FileNameEditor), typeof (UITypeEditor)), Browsable(true),
         Category("Manual Stages"), DesignOnly(false)]
        public string Stage1
        {
            get { return sStage1; }
            set
            {
                sStage1 = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iStage1 = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                    mComponents.pMesh.SetTextureEx(1, iStage1, mGlobalProperties.iSelectedGroup);
                }
                else
                {
                    mComponents.pMesh.SetTextureEx(1, 0, mGlobalProperties.iSelectedGroup);
                    iStage1 = 0;
                    if (iAlphaMap != 0)
                    {
                        sAlphaMap = "";
                        iAlphaMap = 0;
                    }
                }
            }
        }

        [ReadOnly(false), Browsable(true), Category("Manual Stages"),
         Editor(typeof (FileNameEditor), typeof (UITypeEditor)), DesignOnly(false)]
        public string Stage2
        {
            get { return sStage2; }
            set
            {
                sStage2 = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iStage2 = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                    mComponents.pMesh.SetTextureEx(2, iStage2, mGlobalProperties.iSelectedGroup);
                }
                else
                {
                    mComponents.pMesh.SetTextureEx(2, 0, mGlobalProperties.iSelectedGroup);
                    iStage2 = 0;
                }
            }
        }

        [DesignOnly(false), Editor(typeof (FileNameEditor), typeof (UITypeEditor)), Browsable(true),
         Category("Manual Stages"), ReadOnly(false)]
        public string Stage3
        {
            get { return sStage3; }
            set
            {
                sStage3 = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iStage3 = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                    mComponents.pMesh.SetTextureEx(3, iStage3, mGlobalProperties.iSelectedGroup);
                }
                else
                {
                    mComponents.pMesh.SetTextureEx(3, 0, mGlobalProperties.iSelectedGroup);
                    iStage3 = 0;
                }
            }
        }

        [Editor(typeof (FileNameEditor), typeof (UITypeEditor)), Category("Stages"), DesignOnly(false), ReadOnly(false),
         Browsable(true)]
        public string Stage1_NormalMap
        {
            get { return sNormalMap; }
            set
            {
                sNormalMap = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iNormalMap = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                    mComponents.pMesh.SetTextureEx(0x84, iNormalMap, mGlobalProperties.iSelectedGroup);
                    sStage1 = "";
                    iStage1 = iNormalMap;
                }
                else
                {
                    mComponents.pMesh.SetTextureEx(0x84, 0, mGlobalProperties.iSelectedGroup);
                    iStage1 = 0;
                    if (iAlphaMap != 0)
                    {
                        sAlphaMap = "";
                        iAlphaMap = 0;
                        mComponents.pFrmMain._propertiesMain.Refresh();
                    }
                }
            }
        }

        [Editor(typeof (FileNameEditor), typeof (UITypeEditor)), ReadOnly(false), Browsable(true), DesignOnly(false),
         Category("Stages")]
        public string Stage1_AlphaMap
        {
            get { return sAlphaMap; }
            set
            {
                sAlphaMap = value;
                if ((StringType.StrCmp(value, "", false) != 0) & (iStage1 != 0))
                {
                    iAlphaMap = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO );
                    iAlphaMap = mComponents.pTextureFactory.AddAlphaChannel(iStage1, iAlphaMap, "");
                    mComponents.pMesh.SetTextureEx(1, iAlphaMap, mGlobalProperties.iSelectedGroup);
                    iOldStage1 = iStage1;
                    iStage1 = iAlphaMap;
                }
                else
                {
                    if ((StringType.StrCmp(value, "", false) != 0) & (iStage1 == 0))
                    {
                        Interaction.MsgBox(
                            "Please load a Stage1 texture first before adding an texture to the alpha channel of it.",
                            MsgBoxStyle.OkOnly, null);
                        sAlphaMap = "";
                    }
                    else
                    {
                        iStage1 = iOldStage1;
                        iOldStage1 = 0;
                        iAlphaMap = 0;
                        mComponents.pMesh.SetTextureEx(1, iStage1, mGlobalProperties.iSelectedGroup);
                    }
                }
            }
        }

        [DesignOnly(false), Editor(typeof (FileNameEditor), typeof (UITypeEditor)), ReadOnly(false), Browsable(true),
         Category("Stages")]
        public string Stage3_EmissiveMap
        {
            get { return sEmissiveMap; }
            set
            {
                sEmissiveMap = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iEmissiveMap = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                    mComponents.pMesh.SetTextureEx(0x87, iEmissiveMap, mGlobalProperties.iSelectedGroup);
                    sStage3 = "";
                    iStage3 = iEmissiveMap;
                }
                else
                {
                    mComponents.pMesh.SetTextureEx(0x87, 0, mGlobalProperties.iSelectedGroup);
                    iStage3 = 0;
                }
            }
        }

        [Editor(typeof (FileNameEditor), typeof (UITypeEditor)), Category("Stages"), DesignOnly(false), ReadOnly(false),
         Browsable(true)]
        public string Stage1_LightMap
        {
            get { return sLightmap; }
            set
            {
                sLightmap = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iLightmap = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                    mComponents.pMesh.SetTextureEx(0x80, iLightmap, mGlobalProperties.iSelectedGroup);
                    sStage1 = "";
                    iStage1 = iLightmap;
                }
                else
                {
                    mComponents.pMesh.SetTextureEx(0x80, 0, mGlobalProperties.iSelectedGroup);
                    iStage1 = 0;
                    if (iAlphaMap != 0)
                    {
                        sAlphaMap = "";
                        iAlphaMap = 0;
                        mComponents.pFrmMain._propertiesMain.Refresh();
                    }
                }
            }
        }

        [DesignOnly(false), ReadOnly(false), Browsable(true), Category("Stages"),
         Editor(typeof (FileNameEditor), typeof (UITypeEditor))]
        public string Stage1_SpecularMap
        {
            get { return sSpecularmap; }
            set
            {
                sSpecularmap = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iSpecularmap = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                    mComponents.pMesh.SetTextureEx(0x86, iSpecularmap, mGlobalProperties.iSelectedGroup);
                    sStage1 = "";
                    iStage1 = iSpecularmap;
                }
                else
                {
                    mComponents.pMesh.SetTextureEx(0x86, 0, mGlobalProperties.iSelectedGroup);
                    iStage1 = 0;
                    if (iAlphaMap != 0)
                    {
                        sAlphaMap = "";
                        iAlphaMap = 0;
                        mComponents.pFrmMain._propertiesMain.Refresh();
                    }
                }
            }
        }

        [Category("Stages"), Browsable(true), Editor(typeof (FileNameEditor), typeof (UITypeEditor)), DesignOnly(false),
         ReadOnly(false)]
        public string Stage1_DetailMap
        {
            get { return sDetailMap; }
            set
            {
                sDetailMap = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iDetailMap = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                    mComponents.pMesh.SetTextureEx(0x83, iDetailMap, mGlobalProperties.iSelectedGroup);
                    sStage1 = "";
                    iStage1 = iDetailMap;
                }
                else
                {
                    mComponents.pMesh.SetTextureEx(0x83, 0, mGlobalProperties.iSelectedGroup);
                    iStage1 = 0;
                    if (iAlphaMap != 0)
                    {
                        sAlphaMap = "";
                        iAlphaMap = 0;
                        mComponents.pFrmMain._propertiesMain.Refresh();
                    }
                }
            }
        }

        [ReadOnly(false), Category("Stages"), Editor(typeof (FileNameEditor), typeof (UITypeEditor)), DesignOnly(false),
         Browsable(true)]
        public string Stage1_BumpMap
        {
            get { return sBumpMap; }
            set
            {
                sBumpMap = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iBumpMap = mComponents.pTextureFactory.LoadBumpTexture(value, "", -1, -1);
                    mComponents.pMesh.SetTextureEx(0x85, iBumpMap, mGlobalProperties.iSelectedGroup);
                    sStage1 = "";
                    iStage1 = iBumpMap;
                }
                else
                {
                    mComponents.pMesh.SetTextureEx(0x85, 0, mGlobalProperties.iSelectedGroup);
                    iStage1 = 0;
                    if (iAlphaMap != 0)
                    {
                        sAlphaMap = "";
                        iAlphaMap = 0;
                        mComponents.pFrmMain._propertiesMain.Refresh();
                    }
                }
            }
        }

        [Editor(typeof (FileNameEditor), typeof (UITypeEditor)), Category("Stages"), ReadOnly(false), Browsable(true),
         DesignOnly(false)]
        public string Stage2_HeightMap
        {
            get { return sHeightMap; }
            set
            {
                sHeightMap = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iHeightMap = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                    mComponents.pMesh.SetTextureEx(0x81, iHeightMap, mGlobalProperties.iSelectedGroup);
                    sStage2 = "";
                    iStage2 = iHeightMap;
                }
                else
                {
                    mComponents.pMesh.SetTextureEx(0x81, 0, mGlobalProperties.iSelectedGroup);
                    iStage2 = 0;
                }
            }
        }

        [Category("Info"), DesignOnly(false), ReadOnly(true), Browsable(true)]
        public int Triangles
        {
            get { return mGlobalProperties.iTriangles; }
            set { mGlobalProperties.iTriangles = value; }
        }

        [Browsable(true), ReadOnly(true), Category("Info"), DesignOnly(false)]
        public int Vertexes
        {
            get { return mGlobalProperties.iVertexes; }
            set { mGlobalProperties.iVertexes = value; }
        }

        [Category("Lights and Materials"), Editor(typeof (FileNameEditor), typeof (UITypeEditor)), Browsable(true),
         DesignOnly(false), ReadOnly(false)]
        public CONST_TV_LIGHTINGMODE LightingMode
        {
            get { return mGlobalProperties.eLightMode; }
            set
            {
                if (mGlobalProperties.iSelectedGroup == -1)
                {
                    mGlobalProperties.eLightMode = value;
                    mComponents.pMesh.SetLightingMode(value, 2, 8);
                }
                else
                {
                    if (value != 0)
                    {
                        mGlobalProperties.eLightMode = value;
                        int Value = mComponents.pMesh.GetGroupCount();
                        for (int i = 0; i <= Value; i++)
                        {
                            mComponents.pMesh.SetMaterial(mComponents.arrayMaterials[i], i);
                        }
                        mComponents.pMesh.SetMaterial(mComponents.pG.GetMat("MaterialSelected"),
                                                      mGlobalProperties.iSelectedGroup);
                        mComponents.pMesh.SetLightingMode(value, 2, 8);
                    }
                    else
                    {
                        mGlobalProperties.eLightMode = 0;
                        mComponents.pMesh.SetLightingMode((CONST_TV_LIGHTINGMODE)1, 2, 8);
                        int num3 = mComponents.pMesh.GetGroupCount();
                        for (int j = 0; j <= num3; j++)
                        {
                            mComponents.pMesh.SetMaterial(mComponents.arrayMaterials[j], j);
                        }
                        mComponents.pMesh.SetMaterial(mComponents.pG.GetMat("MaterialSelected"),
                                                      mGlobalProperties.iSelectedGroup);
                    }
                }
            }
        }

        [Browsable(true), ReadOnly(false), Category("Shaders"), Editor(typeof (FileNameEditor), typeof (UITypeEditor)),
         DesignOnly(false)]
        public string FX
        {
            get { return sShader; }
            set
            {
                sShader = value;
                int Value = mComponents.pFrmMain._comboGroups.SelectedIndex;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    mComponents.pMesh.SetMeshFormat(0x11);
                    mComponents.arrayShaders[Value] = null;
                    mComponents.arrayShaders[Value] = mComponents.pScene.CreateShader();
                    if (mComponents.arrayShaders[Value].CreateFromEffectFile(value))
                    {
                        mComponents.pMesh.SetShaderEx(mComponents.arrayShaders[Value], false,
                                                      mGlobalProperties.iSelectedGroup);
                    }
                    else
                    {
                        Interaction.MsgBox(mComponents.arrayShaders[Value].GetLastError(), MsgBoxStyle.OkOnly, "Load Failed");
                        mComponents.arrayShaders[Value] = null;
                        sShader = "";
                    }
                }
                else
                {
                    mComponents.pMesh.SetShaderEx(null, false, mGlobalProperties.iSelectedGroup);
                    mComponents.arrayShaders[Value] = null;
                    mComponents.pMesh.SetLightingMode(mGlobalProperties.eLightMode, 2, 8);
                }
                mTV3D.PopulateShaderParams();
            }
        }

        [Browsable(true), DesignOnly(false), ReadOnly(false), Category("PRT SubSurface")]
        public bool Enable
        {
            get { return bEnablePRTSubs; }
            set
            {
                bEnablePRTSubs = value;
                mComponents.pMaterialFactory.EnablePRTSubSurface(
                    mComponents.pMesh.GetMaterial(mGlobalProperties.iSelectedGroup), bEnablePRTSubs);
            }
        }

        [ReadOnly(false), Category("PRT SubSurface"), Browsable(true), DesignOnly(false)]
        public float AbsorptionRed
        {
            get { return eAbsorption.r; }
            set
            {
                eAbsorption.r = value;
                mComponents.pMaterialFactory.SetPRTSubSurfAbsorption(
                    mComponents.pMesh.GetMaterial(mGlobalProperties.iSelectedGroup), eAbsorption.r,
                    eAbsorption.g, eAbsorption.b);
            }
        }

        [Browsable(true), ReadOnly(false), DesignOnly(false), Category("PRT SubSurface")]
        public float AbsorptionGreen
        {
            get { return eAbsorption.g; }
            set
            {
                eAbsorption.g = value;
                mComponents.pMaterialFactory.SetPRTSubSurfAbsorption(
                    mComponents.pMesh.GetMaterial(mGlobalProperties.iSelectedGroup), eAbsorption.r,
                    eAbsorption.g, eAbsorption.b);
            }
        }

        [Category("PRT SubSurface"), DesignOnly(false), ReadOnly(false), Browsable(true)]
        public float AbsorptionBlue
        {
            get { return eAbsorption.b; }
            set
            {
                eAbsorption.b = value;
                mComponents.pMaterialFactory.SetPRTSubSurfAbsorption(
                    mComponents.pMesh.GetMaterial(mGlobalProperties.iSelectedGroup), eAbsorption.r,
                    eAbsorption.g, eAbsorption.b);
            }
        }

        [ReadOnly(false), DesignOnly(false), Browsable(true), Category("PRT SubSurface")]
        public float ReducedScatteringRed
        {
            get { return eReducedScattering.r; }
            set
            {
                eReducedScattering.r = value;
                mComponents.pMaterialFactory.SetPRTSubSurfReducedScattering(
                    mComponents.pMesh.GetMaterial(mGlobalProperties.iSelectedGroup), eReducedScattering.r,
                    eReducedScattering.g, eReducedScattering.b);
            }
        }

        [Browsable(true), ReadOnly(false), DesignOnly(false), Category("PRT SubSurface")]
        public float ReducedScatteringGreen
        {
            get { return eReducedScattering.g; }
            set
            {
                eReducedScattering.g = value;
                mComponents.pMaterialFactory.SetPRTSubSurfReducedScattering(
                    mComponents.pMesh.GetMaterial(mGlobalProperties.iSelectedGroup), eReducedScattering.r,
                    eReducedScattering.g, eReducedScattering.b);
            }
        }

        [Category("PRT SubSurface"), DesignOnly(false), ReadOnly(false), Browsable(true)]
        public float ReducedScatteringBlue
        {
            get { return eReducedScattering.b; }
            set
            {
                eReducedScattering.b = value;
                mComponents.pMaterialFactory.SetPRTSubSurfReducedScattering(
                    mComponents.pMesh.GetMaterial(mGlobalProperties.iSelectedGroup), eReducedScattering.r,
                    eReducedScattering.g, eReducedScattering.b);
            }
        }

        [Browsable(true), DesignOnly(false), ReadOnly(false), Category("PRT SubSurface")]
        public float RefractionIndexRatio
        {
            get { return fRefractionIndexRatio; }
            set
            {
                fRefractionIndexRatio = value;
                mComponents.pMaterialFactory.SetPRTSubSurfRefractionIndexRatio(
                    mComponents.pMesh.GetMaterial(mGlobalProperties.iSelectedGroup), fRefractionIndexRatio);
            }
        }
    }
}
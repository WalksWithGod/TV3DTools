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
    public class cActorProperties
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
        internal int iTexture;
        internal int iHeightMap;
        internal int iNormalMap;
        internal int iBumpMap;
        internal int iDetailMap;
        internal int iEmissiveMap;
        internal int iLightmap;
        internal int iSpecularmap;
        internal int iStage0;
        internal int iStage1;
        internal int iStage2;
        internal int iStage3;
        internal CONST_TV_BLENDINGMODE eBlendingMode;
        internal bool bAlphaTest;
        internal int iAlphaRef;
        internal CONST_TV_CULLING eCullMode;
        internal CONST_TV_ACTORMODE eActorMode;

        // Constructors
        public cActorProperties()
        {
            eBlendingMode = 0;
            eCullMode = CONST_TV_CULLING.TV_BACK_CULL;
            sTexture = "";
            sHeightMap = "";
            sNormalMap = "";
            iTexture = 0;
            iHeightMap = 0;
            iNormalMap = 0;
        }

        // Properties
        [Category("Alpha blending"), DesignOnly(false), ReadOnly(false), Browsable(true)]
        public CONST_TV_BLENDINGMODE BlendingMode
        {
            get { return eBlendingMode; }
            set
            {
                eBlendingMode = value;
                mComponents.pActor.SetBlendingMode(value);
            }
        }

        [Browsable(true), DesignOnly(false), Category("Alpha blending"), ReadOnly(false)]
        public int AlphaTestRef
        {
            get { return iAlphaRef; }
            set
            {
                iAlphaRef = value;
                mComponents.pActor.SetAlphaTest(bAlphaTest, iAlphaRef);
            }
        }

        [DesignOnly(false), Browsable(true), Category("Alpha blending"), ReadOnly(false)]
        public bool AlphaTest
        {
            get { return bAlphaTest; }
            set
            {
                bAlphaTest = value;
                mComponents.pActor.SetAlphaTest(bAlphaTest, iAlphaRef);
            }
        }

        [DesignOnly(false), Category("Rendering"), ReadOnly(false), Browsable(true)]
        public CONST_TV_CULLING Culling
        {
            get { return eCullMode; }
            set
            {
                eCullMode = value;
                mComponents.pActor.SetCullMode(value);
            }
        }

        [ReadOnly(false), Category("Stages"), Browsable(true), Editor(typeof (FileNameEditor), typeof (UITypeEditor)),
         DesignOnly(false)]
        public string Texture
        {
            get { return sTexture; }
            set
            {
                sTexture = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iTexture = mComponents.pTextureFactory.LoadTexture(value);
                    mComponents.pActor.SetTexture(iTexture, mGlobalProperties.iSelectedGroup);
                }
                else
                {
                    mComponents.pActor.SetTexture(0, mGlobalProperties.iSelectedGroup);
                }
            }
        }

        [Editor(typeof (FileNameEditor), typeof (UITypeEditor)), Category("Manual Stages"), DesignOnly(false),
         ReadOnly(false), Browsable(true)]
        public string Stage0
        {
            get { return sStage0; }
            set
            {
                sStage0 = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iStage0 = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                    mComponents.pActor.SetTextureEx(0, iStage0, mGlobalProperties.iSelectedGroup);
                }
                else
                {
                    mComponents.pActor.SetTextureEx(0, 0, mGlobalProperties.iSelectedGroup);
                }
            }
        }

        [Browsable(true), Category("Manual Stages"), Editor(typeof (FileNameEditor), typeof (UITypeEditor)),
         DesignOnly(false), ReadOnly(false)]
        public string Stage1
        {
            get { return sStage1; }
            set
            {
                sStage1 = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iStage1 = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1,
                                                                           CONST_TV_COLORKEY.TV_COLORKEY_NO);
                    mComponents.pActor.SetTextureEx(1, iStage1, mGlobalProperties.iSelectedGroup);
                }
                else
                {
                    mComponents.pActor.SetTextureEx(1, 0, mGlobalProperties.iSelectedGroup);
                }
            }
        }

        [Browsable(true), Category("Manual Stages"), Editor(typeof (FileNameEditor), typeof (UITypeEditor)),
         DesignOnly(false), ReadOnly(false)]
        public string Stage2
        {
            get { return sStage2; }
            set
            {
                sStage2 = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iStage2 = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                    mComponents.pActor.SetTextureEx(2, iStage2, mGlobalProperties.iSelectedGroup);
                }
                else
                {
                    mComponents.pActor.SetTextureEx(2, 0, mGlobalProperties.iSelectedGroup);
                }
            }
        }

        [Editor(typeof (FileNameEditor), typeof (UITypeEditor)), Browsable(true), Category("Manual Stages"),
         ReadOnly(false), DesignOnly(false)]
        public string Stage3
        {
            get { return sStage3; }
            set
            {
                sStage3 = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iStage3 = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                    mComponents.pActor.SetTextureEx(3, iStage3, mGlobalProperties.iSelectedGroup);
                }
                else
                {
                    mComponents.pActor.SetTextureEx(3, 0, mGlobalProperties.iSelectedGroup);
                }
            }
        }

        [Editor(typeof (FileNameEditor), typeof (UITypeEditor)), DesignOnly(false), ReadOnly(false), Browsable(true),
         Category("Stages")]
        public string NormalMap
        {
            get { return sNormalMap; }
            set
            {
                sNormalMap = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    if (StringType.StrCmp(sSpecularmap, "", false) == 0)
                    {
                        iNormalMap = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                    }
                    else
                    {
                        iNormalMap = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                        iNormalMap = mComponents.pTextureFactory.AddAlphaChannel(iNormalMap, iSpecularmap,
                                                                                      "");
                    }
                    mComponents.pActor.SetTextureEx(0x84, iNormalMap, mGlobalProperties.iSelectedGroup);
                }
                else
                {
                    mComponents.pActor.SetTextureEx(0x84, 0, mGlobalProperties.iSelectedGroup);
                }
            }
        }

        [Category("Stages"), Editor(typeof (FileNameEditor), typeof (UITypeEditor)), DesignOnly(false), ReadOnly(false),
         Browsable(true)]
        public string EmissiveMap
        {
            get { return sEmissiveMap; }
            set
            {
                sEmissiveMap = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iEmissiveMap = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                    mComponents.pActor.SetTextureEx(0x87, iEmissiveMap, mGlobalProperties.iSelectedGroup);
                }
                else
                {
                    mComponents.pActor.SetTextureEx(0x87, 0, mGlobalProperties.iSelectedGroup);
                }
            }
        }

        [ReadOnly(false), Category("Stages"), Editor(typeof (FileNameEditor), typeof (UITypeEditor)), DesignOnly(false),
         Browsable(true)]
        public string LightMap
        {
            get { return sLightmap; }
            set
            {
                sLightmap = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iLightmap = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                    mComponents.pActor.SetTextureEx(0x80, iLightmap, mGlobalProperties.iSelectedGroup);
                }
                else
                {
                    mComponents.pActor.SetTextureEx(0x80, 0, mGlobalProperties.iSelectedGroup);
                }
            }
        }

        [Browsable(true), ReadOnly(false), Category("Stages"), Editor(typeof (FileNameEditor), typeof (UITypeEditor)),
         DesignOnly(false)]
        public string SpecularMap
        {
            get { return sSpecularmap; }
            set
            {
                sSpecularmap = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    if (StringType.StrCmp(sNormalMap, "", false) == 0)
                    {
                        iSpecularmap = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                    }
                    else
                    {
                        iSpecularmap = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                        iSpecularmap = mComponents.pTextureFactory.AddAlphaChannel(iNormalMap,
                                                                                        iSpecularmap, "");
                    }
                    mComponents.pActor.SetTextureEx(0x86, iSpecularmap, mGlobalProperties.iSelectedGroup);
                }
                else
                {
                    mComponents.pActor.SetTextureEx(0x86, 0, mGlobalProperties.iSelectedGroup);
                }
            }
        }

        [Editor(typeof (FileNameEditor), typeof (UITypeEditor)), Category("Stages"), ReadOnly(false), DesignOnly(false),
         Browsable(true)]
        public string DetailMap
        {
            get { return sDetailMap; }
            set
            {
                sDetailMap = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iDetailMap = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                    mComponents.pActor.SetTextureEx(0x83, iDetailMap, mGlobalProperties.iSelectedGroup);
                }
                else
                {
                    mComponents.pActor.SetTextureEx(0x83, 0, mGlobalProperties.iSelectedGroup);
                }
            }
        }

        [Editor(typeof (FileNameEditor), typeof (UITypeEditor)), Category("Stages"), DesignOnly(false), ReadOnly(false),
         Browsable(true)]
        public string BumpMap
        {
            get { return sBumpMap; }
            set
            {
                sBumpMap = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iBumpMap = mComponents.pTextureFactory.LoadBumpTexture(value, "", -1, -1);
                    mComponents.pActor.SetTextureEx(0x85, iBumpMap, mGlobalProperties.iSelectedGroup);
                }
                else
                {
                    mComponents.pActor.SetTextureEx(0x85, 0, mGlobalProperties.iSelectedGroup);
                }
            }
        }

        [DesignOnly(false), ReadOnly(false), Browsable(true), Category("Stages"),
         Editor(typeof (FileNameEditor), typeof (UITypeEditor))]
        public string HeightMap
        {
            get { return sHeightMap; }
            set
            {
                sHeightMap = value;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    iHeightMap = mComponents.pTextureFactory.LoadTexture(value, "", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
                    mComponents.pActor.SetTextureEx(0x81, iHeightMap, mGlobalProperties.iSelectedGroup);
                }
                else
                {
                    mComponents.pActor.SetTextureEx(0x81, 0, mGlobalProperties.iSelectedGroup);
                }
            }
        }

        [DesignOnly(false), Editor(typeof (FileNameEditor), typeof (UITypeEditor)), ReadOnly(true), Browsable(true),
         Category("Info")]
        public int Triangles
        {
            get { return mGlobalProperties.iTriangles; }
            set { mGlobalProperties.iTriangles = value; }
        }

        [Browsable(true), Category("Info"), DesignOnly(false), ReadOnly(true)]
        public int Vertexes
        {
            get { return mGlobalProperties.iVertexes; }
            set { mGlobalProperties.iVertexes = value; }
        }

        [Browsable(true), Category("Lights and Materials"), DesignOnly(false), ReadOnly(false),
         Editor(typeof (FileNameEditor), typeof (UITypeEditor))]
        public CONST_TV_LIGHTINGMODE LightingMode
        {
            get { return mGlobalProperties.eLightMode; }
            set
            {
                if (mGlobalProperties.iSelectedGroup == -1)
                {
                    mGlobalProperties.eLightMode = value;
                    mComponents.pActor.SetLightingMode(value, 2, 8);
                }
                else
                {
                    if (value != 0)
                    {
                        mGlobalProperties.eLightMode = value;
                        int Value = mComponents.pActor.GetGroupCount();
                        for (int i = 0; i <= Value; i++)
                        {
                            mComponents.pActor.SetMaterial(mComponents.arrayMaterials[i], i);
                        }
                        mComponents.pActor.SetMaterial(mComponents.pG.GetMat("MaterialSelected"),
                                                       mGlobalProperties.iSelectedGroup);
                        mComponents.pActor.SetLightingMode((CONST_TV_LIGHTINGMODE)Value, 2, 8);
                    }
                    else
                    {
                        mGlobalProperties.eLightMode = 0;
                        mComponents.pActor.SetLightingMode((CONST_TV_LIGHTINGMODE)1, 2, 8);
                        int num3 = mComponents.pActor.GetGroupCount();
                        for (int j = 0; j <= num3; j++)
                        {
                            mComponents.pActor.SetMaterial(mComponents.arrayMaterials[j], j);
                        }
                        mComponents.pActor.SetMaterial(mComponents.pG.GetMat("MaterialSelected"),
                                                       mGlobalProperties.iSelectedGroup);
                    }
                }
            }
        }

        [ReadOnly(false), Category("Lights and Materials"), Browsable(true),
         Editor(typeof (FileNameEditor), typeof (UITypeEditor)), DesignOnly(false)]
        public CONST_TV_ACTORMODE ActorMode
        {
            get { return eActorMode; }
            set
            {
                eActorMode = value;
                mComponents.pActor.SetActorMode(eActorMode);
            }
        }

        [Category("Shaders"), Editor(typeof (FileNameEditor), typeof (UITypeEditor)), DesignOnly(false), ReadOnly(false)
        , Browsable(true)]
        public string FX
        {
            get { return sShader; }
            set
            {
                sShader = value;
                int Value = mComponents.pFrmMain._comboGroups.SelectedIndex;
                if (StringType.StrCmp(value, "", false) != 0)
                {
                    mComponents.arrayShaders[Value] = null;
                    mComponents.arrayShaders[Value] = mComponents.pScene.CreateShader();
                    if (mComponents.arrayShaders[Value].CreateFromEffectFile(value))
                    {
                        mComponents.pActor.SetShaderEx(mComponents.arrayShaders[Value], false,
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
                    mComponents.pActor.SetShaderEx(null, false, mGlobalProperties.iSelectedGroup);
                    mComponents.arrayShaders[Value] = null;
                }
                mTV3D.PopulateShaderParams();
            }
        }
    }
}
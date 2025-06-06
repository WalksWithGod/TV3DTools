#region

using System.ComponentModel;
using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;

#endregion

namespace ModelView
{
    public class cSceneProperties
    {
        // Instance Fields
        internal CONST_TV_TEXTUREFILTER eTextureFilter;
        internal CONST_TV_DEPTHBUFFER eDepthBuffer;
        internal TV_COLOR eBackgroundColor;
        internal CONST_TV_RENDERMODE eRenderMode;
        internal float fFOV;
        internal float fFarPlane;
        internal float fMipMapPrecision;
        internal object fMotionBlurAmp;
        internal float fFocalRange;
        internal float fFocalPlane;
        internal float fDOFBlurFactor;
        internal TV_COLOR eTintGlow;
        internal float fGlowIntensity;
        internal float fGlowOffsetScale;
        internal bool bEnableSpecular;

        // Constructors
        public cSceneProperties()
        {
            eTextureFilter = CONST_TV_TEXTUREFILTER.TV_FILTER_BILINEAR;
            eDepthBuffer = CONST_TV_DEPTHBUFFER.TV_ZBUFFER;
            eBackgroundColor = mComponents.pG.TVColor(0.15F, 0.15F, 0.15F, 1.00F);
            eRenderMode = CONST_TV_RENDERMODE.TV_SOLID;
            fFOV = 45.00F;
            fFarPlane = 10000.00F;
            fMipMapPrecision = 0.00F;
            fMotionBlurAmp = 1;
            fFocalRange = 8.00F;
            fFocalPlane = 54.00F;
            fDOFBlurFactor = 3.00F;
            eTintGlow = mComponents.pG.TVColor(1.00F, 1.00F, 1.00F, 1.00F);
            fGlowIntensity = 1.00F;
            fGlowOffsetScale = 1.00F;
            bEnableSpecular = false;
        }


        // Properties
        [DesignOnly(false), Browsable(true), Category("Scene"), ReadOnly(false)]
        public bool DisplayGrid
        {
            get { return mGlobalProperties.bShowGrid; }
            set { mGlobalProperties.bShowGrid = value; }
        }

        [Category("Scene"), Browsable(true), DesignOnly(false), ReadOnly(false)]
        public bool DisplayBoneNames
        {
            get { return mGlobalProperties.bShowBoneNames; }
            set { mGlobalProperties.bShowBoneNames = value; }
        }

        [Category("Scene"), Browsable(true), DesignOnly(false), ReadOnly(false)]
        public bool DisplaySkeleton
        {
            get { return mGlobalProperties.bShowSkeleton; }
            set { mGlobalProperties.bShowSkeleton = value; }
        }

        [Category("Scene"), DesignOnly(false), ReadOnly(false), Browsable(true)]
        public bool DisplayBoundingBox
        {
            get { return mGlobalProperties.bShowBoundingBox; }
            set { mGlobalProperties.bShowBoundingBox = value; }
        }

        [Category("Motion Blur"), DesignOnly(false), ReadOnly(false), Browsable(true)]
        public bool EnableMotionBlur
        {
            get { return mGlobalProperties.bMotionBlur; }
            set
            {
                mGlobalProperties.bMotionBlur = value;
                if (mTV3D.bActorOpen)
                {
                    mComponents.pActor.EnableMotionBlur(value);
                }
            }
        }

        [Category("Motion Blur"), DesignOnly(false), ReadOnly(false), Browsable(true)]
        public float MotionBlurAmp
        {
            get { return SingleType.FromObject(fMotionBlurAmp); }
            set
            {
                fMotionBlurAmp = value;
                mComponents.pGraphicEffect.SetMotionBlurParameters(value);
            }
        }

        [ReadOnly(false), DesignOnly(false), Category("Glow"), Browsable(true)]
        public bool EnableGlow
        {
            get { return mGlobalProperties.bGlow; }
            set { mGlobalProperties.bGlow = value; }
        }

        [DesignOnly(false), Category("Glow"), ReadOnly(false), Browsable(true)]
        public float GlowIntensity
        {
            get { return fGlowIntensity; }
            set
            {
                fGlowIntensity = value;
                mComponents.pGraphicEffect.SetGlowParameters(eTintGlow, fGlowIntensity, fGlowOffsetScale);
            }
        }

        [DesignOnly(false), Category("Glow"), ReadOnly(false), Browsable(true)]
        public float OffsetScale
        {
            get { return fGlowOffsetScale; }
            set
            {
                fGlowOffsetScale = value;
                mComponents.pGraphicEffect.SetGlowParameters(eTintGlow, fGlowIntensity, fGlowOffsetScale);
            }
        }

        [ReadOnly(false), DesignOnly(false), Category("Glow Tint"), Browsable(true)]
        public float TintRed
        {
            get { return eTintGlow.r; }
            set
            {
                eTintGlow.r = value;
                mComponents.pGraphicEffect.SetGlowParameters(eTintGlow, fGlowIntensity, fGlowOffsetScale);
            }
        }

        [DesignOnly(false), Category("Glow Tint"), ReadOnly(false), Browsable(true)]
        public float TintGreen
        {
            get { return eTintGlow.g; }
            set
            {
                eTintGlow.g = value;
                mComponents.pGraphicEffect.SetGlowParameters(eTintGlow, fGlowIntensity, fGlowOffsetScale);
            }
        }

        [DesignOnly(false), Category("Glow Tint"), ReadOnly(false), Browsable(true)]
        public float TintBlue
        {
            get { return eTintGlow.b; }
            set
            {
                eTintGlow.b = value;
                mComponents.pGraphicEffect.SetGlowParameters(eTintGlow, fGlowIntensity, fGlowOffsetScale);
            }
        }

        [Browsable(true), Category("DepthOfField"), DesignOnly(false), ReadOnly(false)]
        public bool EnableDOF
        {
            get { return mGlobalProperties.bDOF; }
            set { mGlobalProperties.bDOF = value; }
        }

        [DesignOnly(false), Browsable(true), Category("DepthOfField"), ReadOnly(false)]
        public float FocalRange
        {
            get { return fFocalRange; }
            set
            {
                fFocalRange = value;
                mComponents.pGraphicEffect.SetDepthOfFieldParameters(fFocalPlane, fFocalRange,
                                                                     fDOFBlurFactor);
            }
        }

        [ReadOnly(false), Browsable(true), Category("DepthOfField"), DesignOnly(false)]
        public float FocalPlane
        {
            get { return fFocalPlane; }
            set
            {
                fFocalPlane = value;
                mComponents.pGraphicEffect.SetDepthOfFieldParameters(fFocalPlane, fFocalRange,
                                                                     fDOFBlurFactor);
            }
        }

        [Category("DepthOfField"), Browsable(true), ReadOnly(false), DesignOnly(false)]
        public float BlurFactor
        {
            get { return fDOFBlurFactor; }
            set
            {
                fDOFBlurFactor = value;
                mComponents.pGraphicEffect.SetDepthOfFieldParameters(fFocalPlane, fFocalRange,
                                                                     fDOFBlurFactor);
            }
        }

        [Category("Scene"), DesignOnly(false), Browsable(true), ReadOnly(false)]
        public bool EnableSpecular
        {
            get { return bEnableSpecular; }
            set
            {
                bEnableSpecular = value;
                mComponents.pLightEngine.SetSpecularLighting(value);
            }
        }

        [Category("Scene"), DesignOnly(false), ReadOnly(false), Browsable(true)]
        public CONST_TV_TEXTUREFILTER TextureFilter
        {
            get { return eTextureFilter; }
            set
            {
                eTextureFilter = value;
                mComponents.pScene.SetTextureFilter(value);
            }
        }

        [ReadOnly(false), DesignOnly(false), Category("View Frustum"), Browsable(true)]
        public float FOVAngleDegree
        {
            get { return fFOV; }
            set
            {
                fFOV = value;
                mComponents.pScene.GetCamera().SetViewFrustum(fFOV, fFarPlane, 0.01F);
            }
        }

        [DesignOnly(false), Category("View Frustum"), ReadOnly(false), Browsable(true)]
        public float FarPlane
        {
            get { return fFarPlane; }
            set
            {
                fFarPlane = value;
                mComponents.pScene.GetCamera().SetViewFrustum(fFOV, fFarPlane, 0.01F);
            }
        }

        [Browsable(true), DesignOnly(false), Category("Scene"), ReadOnly(false)]
        public float MipMapPrecision
        {
            get { return fMipMapPrecision; }
            set
            {
                fMipMapPrecision = value;
                mComponents.pScene.SetMipmappingPrecision(fMipMapPrecision);
            }
        }

        [Category("Scene"), Browsable(true), ReadOnly(false), DesignOnly(false)]
        public CONST_TV_DEPTHBUFFER DepthBuffer
        {
            get { return eDepthBuffer; }
            set
            {
                eDepthBuffer = value;
                mComponents.pScene.SetDepthBuffer(value);
            }
        }

        [Category("Background Color"), DesignOnly(false), ReadOnly(false), Browsable(true)]
        public float Red
        {
            get { return eBackgroundColor.r; }
            set
            {
                eBackgroundColor.r = value;
                mComponents.pScene.SetBackgroundColor(eBackgroundColor.r, eBackgroundColor.g,
                                                      eBackgroundColor.b);
            }
        }

        [Category("Background Color"), DesignOnly(false), ReadOnly(false), Browsable(true)]
        public float Green
        {
            get { return eBackgroundColor.g; }
            set
            {
                eBackgroundColor.g = value;
                mComponents.pScene.SetBackgroundColor(eBackgroundColor.r, eBackgroundColor.g,
                                                      eBackgroundColor.b);
            }
        }

        [Category("Background Color"), DesignOnly(false), ReadOnly(false), Browsable(true)]
        public float Blue
        {
            get { return eBackgroundColor.b; }
            set
            {
                eBackgroundColor.b = value;
                mComponents.pScene.SetBackgroundColor(eBackgroundColor.r, eBackgroundColor.g,
                                                      eBackgroundColor.b);
            }
        }

        [ReadOnly(false), Browsable(true), Category("Rendering"), DesignOnly(false)]
        public CONST_TV_RENDERMODE RenderMode
        {
            get { return eRenderMode; }
            set
            {
                eRenderMode = value;
                mComponents.pScene.SetRenderMode(value);
            }
        }
    }
}
#region

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;

#endregion

namespace ModelView
{
    [StandardModule]
    internal sealed class mComponents
    {
        // Statics
        [AccessedThroughProperty("pFrmNormalmapGen")] private static frmNormalmapGen _pFrmNormalmapGen;
        [AccessedThroughProperty("pFrmPRTGen")] private static frmPRTGen _pFrmPRTGen;
        [AccessedThroughProperty("pFrmMain")] private static frmMain _pFrmMain;
        [AccessedThroughProperty("pFrmAnimationRanges")] private static frmAnimationRanges _pFrmAnimationRanges;
        [AccessedThroughProperty("pFrmMorphTargets")] private static frmMorphTargets _pFrmMorphTargets;
        public static TVEngine pTV;
        public static TVScene pScene;
        public static TVTextureFactory pTextureFactory;
        public static TVInputEngine pInputEngine;
        public static TVCamera pCamera;
        public static TVMesh pMesh;
        public static TVMesh pMeshHigh;
        public static TVActor pActor;
        public static TVGlobals pG;
        public static TVLightEngine pLightEngine;
        public static TVMaterialFactory pMaterialFactory;
        public static TVScreen2DImmediate pScreen2DImmediate;
        public static TVMathLibrary pMathLibrary;
        public static TVGraphicEffect pGraphicEffect;
        public static TVCollisionResult pCollisionResult;
        public static TVScreen2DText pText;
        public static TVRenderSurface pMBRenderSurface;
        public static TVRenderSurface pGlowRenderSurface;
        public static TVRenderSurface pDOFRenderSurface;
        public static cMeshProperties[] arrayCMeshProperties;
        public static cActorProperties[] arrayCActorProperties;
        public static cLightProperties[] arrayCLightProperties;
        public static cMorphTargetProperties[] arrayCMorphTargetProperties;
        public static cAnimationRangeProperties[] arrayCAnimationRangeProperties;
        public static cSceneProperties pCSceneProperties;
        public static TV_LIGHT[] arrayTV_LIGHT;
        public static TVMesh[] arrayMeshPose;
        public static int[] arrayMaterials;
        public static TVMesh[] arrayLightMesh;
        public static TVShader[] arrayShaders;
        public static bool bClosingApp;
        public static bool bPlayingAnimation;
        public static bool bRotateModel;
        public static bool bRotateCamera;
        public static float fRadius;
        public static float fLightRadius;
        public static enumDoRender eDoRender;

        // Nested Types
        public enum enumDoRender
        {
            Normal = 0,
            Pause = 1,
            Quit = 2
        }

        // Methods
        public static void InitComponents()
        {
            pFrmMain = new frmMain();
            pFrmNormalmapGen = new frmNormalmapGen();
            pFrmMorphTargets = new frmMorphTargets();
            pFrmAnimationRanges = new frmAnimationRanges();
            pFrmPRTGen = new frmPRTGen();
            pTV = new TVEngine();
            TVEngine engine3 = pTV;
            engine3.SetVSync(true);
            engine3.Init3DWindowed(pFrmMain.fRender.Handle);
            engine3.SetInternalShaderVersion(CONST_TV_SHADERMODEL.TV_SHADERMODEL_BEST);
            engine3.SetAngleSystem(CONST_TV_ANGLE.TV_ANGLE_DEGREE);
            engine3.DisplayFPS(false);
            engine3.GetViewport().SetAutoResize(true);
            engine3.SetSearchDirectory(Application.StartupPath);
            pScene = new TVScene();
            TVScene scene1 = pScene;
            scene1.SetTextureFilter(CONST_TV_TEXTUREFILTER.TV_FILTER_BILINEAR);
            scene1.SetMipmappingPrecision(0.00F);
            scene1.SetBackgroundColor(0.15F, 0.15F, 0.15F);

            pTextureFactory = new TVTextureFactory();
            TVTextureFactory factory2 = pTextureFactory;
            factory2.SetTextureMode(CONST_TV_TEXTUREMODE.TV_TEXTUREMODE_16BITS);
            factory2.LoadTexture("lightglow.dds", "LightGlow", -1, -1, CONST_TV_COLORKEY.TV_COLORKEY_NO);
            pInputEngine = new TVInputEngine();
            pInputEngine.Initialize(true, true);
            pCamera = new TVCamera();
            TVCamera camera1 = pCamera;
            camera1.SetCamera(20.00F, 20.00F, -40.00F, 0.00F, 0.00F, 0.00F);
            camera1.SetViewFrustum(45.00F, 1000.00F, 0.01F);
            pG = new TVGlobals();
            pLightEngine = new TVLightEngine();
            pLightEngine.SetGlobalAmbient(0.00F, 0.00F, 0.00F);
            pText = new TVScreen2DText();
            pMaterialFactory = new TVMaterialFactory();
            TVMaterialFactory factory1 = pMaterialFactory;
            factory1.SetPower(factory1.CreateLightMaterial(1.00F, 1.00F, 1.00F, 1.00F, 0.00F, 0.20F, "Material1"),
                              16.00F);
            factory1.CreateMaterial("MaterialSelected");
            factory1.SetDiffuse(pG.GetMat("MaterialSelected"), 1.00F, 0.00F, 0.00F, 0.30F);
            factory1.SetAmbient(pG.GetMat("MaterialSelected"), 1.00F, 0.00F, 0.00F, 0.30F);
            factory1.SetEmissive(pG.GetMat("MaterialSelected"), 1.00F, 0.00F, 0.00F, 0.30F);
            factory1.CreateMaterial("MaterialNone");
            factory1.SetDiffuse(pG.GetMat("MaterialNone"), 1.00F, 1.00F, 1.00F, 0.30F);
            factory1.SetAmbient(pG.GetMat("MaterialNone"), 1.00F, 1.00F, 1.00F, 0.30F);
            factory1.SetEmissive(pG.GetMat("MaterialNone"), 1.00F, 1.00F, 1.00F, 0.30F);

            pScreen2DImmediate = new TVScreen2DImmediate();
            pMathLibrary = new TVMathLibrary();
            pGraphicEffect = new TVGraphicEffect();
            pCollisionResult = new TVCollisionResult();
            pGlowRenderSurface = pScene.CreateRenderSurface(0x100, 0x100, true);
            pGlowRenderSurface.SetBackgroundColor(0);
            pGraphicEffect.InitGlowEffect(pGlowRenderSurface);
            pDOFRenderSurface = pScene.CreateAlphaRenderSurface(0x200, 0x200, true);
            pGraphicEffect.InitDepthOfField(8, pDOFRenderSurface);
            pGraphicEffect.SetDepthOfFieldParameters(54.00F, 10.00F, 3.00F);
            pMBRenderSurface = pScene.CreateRenderSurfaceEx(0x200, 0x200, 0, true, true, 1.00F);
            pGraphicEffect.InitMotionBlur(pMBRenderSurface);
            mGlobalProperties.bDoInput = true;
            mGlobalProperties.bInitedDone = true;
            bRotateModel = false;
            bRotateCamera = true;
            pCamera.SetLookAt(0.00F, 0.00F, 0.00F);
            pFrmMain.Show();
        }

        public static void DestroyComponents()
        {
            pGlowRenderSurface = null;
            pGraphicEffect = null;
            pMathLibrary = null;
            pScreen2DImmediate = null;
            pMaterialFactory.DeleteAllMaterials();
            pMaterialFactory = null;
            pLightEngine.DeleteAllLights();
            pLightEngine = null;
            pG = null;
            pCamera = null;
            pInputEngine = null;
            pTextureFactory = null;
            pScene.DestroyAllMeshes();
            pScene = null;
            pTV.AddToLog("ModelView: UNLOADED");
            pTV = null;
        }


        // Properties
        public static frmMain pFrmMain
        {
            get { return _pFrmMain; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pFrmMain != null)
                {
                }
                _pFrmMain = value;
                if (_pFrmMain != null)
                {
                }
            }
        }

        public static frmNormalmapGen pFrmNormalmapGen
        {
            get { return _pFrmNormalmapGen; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pFrmNormalmapGen != null)
                {
                }
                _pFrmNormalmapGen = value;
                if (_pFrmNormalmapGen != null)
                {
                }
            }
        }

        public static frmMorphTargets pFrmMorphTargets
        {
            get { return _pFrmMorphTargets; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pFrmMorphTargets != null)
                {
                }
                _pFrmMorphTargets = value;
                if (_pFrmMorphTargets != null)
                {
                }
            }
        }

        public static frmAnimationRanges pFrmAnimationRanges
        {
            get { return _pFrmAnimationRanges; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pFrmAnimationRanges != null)
                {
                }
                _pFrmAnimationRanges = value;
                if (_pFrmAnimationRanges != null)
                {
                }
            }
        }

        public static frmPRTGen pFrmPRTGen
        {
            get { return _pFrmPRTGen; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pFrmPRTGen != null)
                {
                }
                _pFrmPRTGen = value;
                if (_pFrmPRTGen != null)
                {
                }
            }
        }
    }
}
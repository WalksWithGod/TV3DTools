#region

using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;

#endregion

namespace ModelView
{
    [StandardModule]
    internal sealed class mTV3D
    {

        // Statics
        public static bool bMeshHighOpen;
        public static bool bMeshOpen;
        public static bool bActorOpen;
        public static bool MB1;
        public static bool MB2;
        public static bool MB3;
        public static bool CollCheck;
        public static long mousewheel;
        public static float fGridRatio;
        private static TV_3DVECTOR vLookAt;
        private static int MouseX;
        private static int MouseY;
        private static float AngleX;
        private static float AngleY;
        private static float fTotalAngleX;
        private static float fTotalAngleY;
        private static float Zoom;
        private static float oldAngX;
        private static float oldAngY;
        private static TV_3DVECTOR vCenter;
        private static TV_3DVECTOR lookat;
        private static TV_3DMATRIX retMatrix1;
        private static TV_3DMATRIX retMatrix2;
        private static TV_3DMATRIX retMatrix3;
        private static TV_3DMATRIX retMatrix4;
        private static TV_3DMATRIX finalMatrix;
        private static TV_3DMATRIX rotMatrix1;
        private static TV_3DMATRIX rotMatrix2;
        private static TV_3DMATRIX rotMatrixX;
        private static TV_3DMATRIX rotMatrixY;

        // Nested Types
        public enum CONST_TV_FORMAT
        {
            TV_FORMAT_TVM = 0,
            TV_FORMAT_TVA = 1,
            TV_FORMAT_SX = 2,
            TV_FORMAT_DX = 3
        }

        // Constructors
        static mTV3D()
        {
            fGridRatio = 1.00F;
        }


        // Methods
        internal static void RenderGrid()
        {
        }

        public static void PopulateShaderParams()
        {
            //CONST_TV_SHADERPARAMETERTYPE const_TV_SHADERPARAMETERTYPE;
            //TreeNode treeNode1, treeNode2, treeNode3, treeNode4, treeNode5, treeNode6, treeNode7, treeNode8, treeNode9;


            //mComponents.pFrmMain._comboShaderTechnique.Items.Clear();
            //mComponents.pFrmMain._treeShaderParams.Nodes.Clear();
            //int i1 = mComponents.pFrmMain._comboGroups.SelectedIndex;
            //if (mComponents.arrayShaders[i1] != null)
            //{
            //    int i5 = checked(mComponents.arrayShaders[i1].GetTechniqueCount() - 1);
            //    for (int i2 = 0; i2 <= i5; i2 = checked(i2 + 1))
            //    {
            //        mComponents.pFrmMain._comboShaderTechnique.Items.Add(mComponents.arrayShaders[i1].GetTechniqueName(i2));
            //    }
            //    mComponents.pFrmMain._comboShaderTechnique.SelectedIndex = 0;
            //    int i4 = checked(mComponents.arrayShaders[i1].GetEffectParameterCount() - 1);
            //    for (int i3 = 0; i3 <= i4; i3 = checked(i3 + 1))
            //    {
            //        switch (mComponents.arrayShaders[i1].GetEffectParamType(i3))
            //        {
            //            case CONST_TV_SHADERPARAMETERTYPE.TV_SHADERPARAMETER_bool:
            //                if (treeNode1 == null)
            //                {
            //                    treeNode1 = mComponents.pFrmMain._treeShaderParams.Nodes.Add("BOOL");
            //                    treeNode4 = treeNode1.Nodes.Add(mComponents.arrayShaders[i1].GetEffectParamName(i3));
            //                    continue;
            //                }
            //                treeNode4 = treeNode1.Nodes.Add(mComponents.arrayShaders[i1].GetEffectParamName(i3));
            //                break;

            //            case CONST_TV_SHADERPARAMETERTYPE.TV_SHADERPARAMETER_FLOAT:
            //                if (treeNode2 == null)
            //                {
            //                    treeNode2 = mComponents.pFrmMain._treeShaderParams.Nodes.Add("FLOAT");
            //                    treeNode4 = treeNode2.Nodes.Add(mComponents.arrayShaders[i1].GetEffectParamName(i3));
            //                }
            //                else
            //                {
            //                    treeNode4 = treeNode2.Nodes.Add(mComponents.arrayShaders[i1].GetEffectParamName(i3));
            //                }
            //                treeNode4.Nodes.Add(StringType.FromSingle(mComponents.arrayShaders[i1].GetEffectParamFloat(mComponents.arrayShaders[i1].GetEffectParamName(i3))));
            //                break;

            //            case CONST_TV_SHADERPARAMETERTYPE.TV_SHADERPARAMETER_INTEGER:
            //                if (treeNode3 == null)
            //                {
            //                    treeNode3 = mComponents.pFrmMain._treeShaderParams.Nodes.Add("INTEGER");
            //                    treeNode4 = treeNode3.Nodes.Add(mComponents.arrayShaders[i1].GetEffectParamName(i3));
            //                }
            //                else
            //                {
            //                    treeNode4 = treeNode3.Nodes.Add(mComponents.arrayShaders[i1].GetEffectParamName(i3));
            //                }
            //                treeNode4.Nodes.Add(StringType.FromInteger(mComponents.arrayShaders[i1].GetEffectParamInteger(mComponents.arrayShaders[i1].GetEffectParamName(i3))));
            //                break;

            //            case CONST_TV_SHADERPARAMETERTYPE.TV_SHADERPARAMETER_MATRIX:
            //                if (treeNode5 == null)
            //                {
            //                    treeNode5 = mComponents.pFrmMain._treeShaderParams.Nodes.Add("MATRIX");
            //                    treeNode4 = treeNode5.Nodes.Add(mComponents.arrayShaders[i1].GetEffectParamName(i3));
            //                    continue;
            //                }
            //                treeNode4 = treeNode5.Nodes.Add(mComponents.arrayShaders[i1].GetEffectParamName(i3));
            //                break;

            //            case CONST_TV_SHADERPARAMETERTYPE.TV_SHADERPARAMETER_STRING:
            //                if (treeNode6 == null)
            //                {
            //                    treeNode6 = mComponents.pFrmMain._treeShaderParams.Nodes.Add("STRING");
            //                    treeNode4 = treeNode6.Nodes.Add(mComponents.arrayShaders[i1].GetEffectParamName(i3));
            //                }
            //                else
            //                {
            //                    treeNode4 = treeNode6.Nodes.Add(mComponents.arrayShaders[i1].GetEffectParamName(i3));
            //                }
            //                treeNode4.Nodes.Add(mComponents.arrayShaders[i1].GetEffectParamString(mComponents.arrayShaders[i1].GetEffectParamName(i3)));
            //                break;

            //            case CONST_TV_SHADERPARAMETERTYPE.TV_SHADERPARAMETER_TEXTURE:
            //                if (treeNode7 == null)
            //                {
            //                    treeNode7 = mComponents.pFrmMain._treeShaderParams.Nodes.Add("TEXTURE");
            //                    treeNode4 = treeNode7.Nodes.Add(mComponents.arrayShaders[i1].GetEffectParamName(i3));
            //                }
            //                else
            //                {
            //                    treeNode4 = treeNode7.Nodes.Add(mComponents.arrayShaders[i1].GetEffectParamName(i3));
            //                }
            //                TV_TEXTURE tv_TEXTURE = mComponents.pTextureFactory.GetTextureInfo(mComponents.arrayShaders[i1].GetEffectParamTexture(mComponents.arrayShaders[i1].GetEffectParamName(i3)));
            //                treeNode4.Nodes.Add(tv_TEXTURE.Filename);
            //                break;

            //            case CONST_TV_SHADERPARAMETERTYPE.TV_SHADERPARAMETER_UNKNOWN:
            //                if (treeNode8 == null)
            //                {
            //                    treeNode8 = mComponents.pFrmMain._treeShaderParams.Nodes.Add("UNKNOWN");
            //                    treeNode4 = treeNode8.Nodes.Add(mComponents.arrayShaders[i1].GetEffectParamName(i3));
            //                    continue;
            //                }
            //                treeNode4 = treeNode8.Nodes.Add(mComponents.arrayShaders[i1].GetEffectParamName(i3));
            //                break;

            //            case CONST_TV_SHADERPARAMETERTYPE.TV_SHADERPARAMETER_VECTOR:
            //                if (treeNode9 == null)
            //                {
            //                    treeNode9 = mComponents.pFrmMain._treeShaderParams.Nodes.Add("VECTOR");
            //                    treeNode4 = treeNode9.Nodes.Add(mComponents.arrayShaders[i1].GetEffectParamName(i3));
            //                }
            //                else
            //                {
            //                    treeNode4 = treeNode9.Nodes.Add(mComponents.arrayShaders[i1].GetEffectParamName(i3));
            //                }
            //                TV_4DVECTOR tv_4DVECTOR = mComponents.arrayShaders[i1].GetEffectParamVector(mComponents.arrayShaders[i1].GetEffectParamName(i3));
            //                treeNode4.Nodes.Add("x").Nodes.Add(StringType.FromSingle(tv_4DVECTOR.x));
            //                treeNode4.Nodes.Add("y").Nodes.Add(StringType.FromSingle(tv_4DVECTOR.y));
            //                treeNode4.Nodes.Add("z").Nodes.Add(StringType.FromSingle(tv_4DVECTOR.z));
            //                treeNode4.Nodes.Add("w").Nodes.Add(StringType.FromSingle(tv_4DVECTOR.w));
            //                break;
            //        }
            //    }
            //}
            //else
            //{
            //    mComponents.pFrmMain._treeShaderParams.Nodes.Add("No shader loaded for this group.");
            //    mComponents.pFrmMain._comboShaderTechnique.Items.Clear();
            //}
        }

        public static void TranslateLights(float changeratio)
        {
            int num2 = mComponents.pLightEngine.GetActiveCount() - 1;
            for (int i = 0; i <= num2; i++)
            {
                mComponents.arrayCLightProperties[i].PositionX *= changeratio;
                mComponents.arrayCLightProperties[i].PositionY *= changeratio;
                mComponents.arrayCLightProperties[i].PositionZ *= changeratio;
                mComponents.arrayCLightProperties[i].Range *= changeratio;
                mComponents.arrayCLightProperties[i].Att2 = (1.00F/mComponents.arrayCLightProperties[i].Range)*10.00F;
                mComponents.arrayLightMesh[i].SetScale((float) (mComponents.fRadius*0.2),
                                                       (float) (mComponents.fRadius*0.2),
                                                       (float) (mComponents.fRadius*0.2));
                mComponents.pFrmMain._propertiesLights.Refresh();
            }
        }

        internal static void Render()
        {
            if ((mComponents.eDoRender == mComponents.enumDoRender.Normal) & !mComponents.bClosingApp)
            {
                if (bMeshOpen)
                {
                    mComponents.pMesh.ShowBoundingBox(mGlobalProperties.bShowBoundingBox);
                }
                if (bActorOpen)
                {
                    mComponents.pActor.ShowBoundingBox(mGlobalProperties.bShowBoundingBox);
                }
                if (mGlobalProperties.bGlow)
                {
                    mComponents.pGlowRenderSurface.StartRender(false);
                    if (bMeshOpen)
                    {
                        mComponents.pMesh.Render();
                    }
                    if (bActorOpen)
                    {
                        mComponents.pActor.Render(false);
                    }
                    mComponents.pGlowRenderSurface.EndRender();
                    mComponents.pGraphicEffect.UpdateGlow();
                }
                if (mGlobalProperties.bDOF)
                {
                    mComponents.pDOFRenderSurface.StartRender(false);
                    if (mGlobalProperties.bGlow)
                    {
                        mComponents.pGraphicEffect.DrawGlow();
                        mGlobalProperties.bGlowDone = true;
                    }
                    Render3D();
                    Render2D();
                    mComponents.pGraphicEffect.UpdateDepthOfField();
                    mComponents.pDOFRenderSurface.EndRender();
                }
                if (mGlobalProperties.bMotionBlur)
                {
                    mComponents.pMBRenderSurface.StartRender(false);
                    if (mGlobalProperties.bDOF)
                    {
                        mComponents.pGraphicEffect.DrawDepthOfField();
                    }
                    else
                    {
                        Render3D();
                        Render2D();
                    }
                    if (mGlobalProperties.bGlow & !mGlobalProperties.bGlowDone)
                    {
                        mComponents.pGraphicEffect.DrawGlow();
                    }
                    mComponents.pMBRenderSurface.EndRender();
                    mComponents.pGraphicEffect.StartRenderMotionBlur();
                    if (bMeshOpen)
                    {
                        mComponents.pMesh.Render();
                    }
                    if (bActorOpen)
                    {
                        mComponents.pActor.Render(false);
                    }
                    mComponents.pGraphicEffect.EndRenderMotionBlur();
                }
                mComponents.pTV.Clear(false);
                if (!mGlobalProperties.bDOF & !mGlobalProperties.bMotionBlur)
                {
                    Render3D();
                }
                if (!mGlobalProperties.bDOF & !mGlobalProperties.bMotionBlur)
                {
                    Render2D();
                }
                if (mGlobalProperties.bGlow & !mGlobalProperties.bGlowDone)
                {
                    mComponents.pGraphicEffect.DrawGlow();
                }
                if (mGlobalProperties.bDOF & !mGlobalProperties.bMotionBlur)
                {
                    mComponents.pGraphicEffect.DrawDepthOfField();
                }
                if (mGlobalProperties.bMotionBlur)
                {
                    mComponents.pGraphicEffect.DrawMotionBlur();
                }
                mGlobalProperties.bGlowDone = false;
                mComponents.pTV.RenderToScreen();
                if (mComponents.pFrmMain._dockBottom.Visible)
                {
                    mComponents.pFrmMain._statusBarMain.Panels[2].Text = "KeyFrame: " +
                                                                        StringType.FromInteger(
                                                                            mComponents.pFrmMain._scrollAnimation.Value);
                }
                mComponents.pFrmMain._statusBarMain.Panels[3].Text = "FPS: " +
                                                                    StringType.FromInteger(mComponents.pTV.GetFPS());
            }
        }

        internal static void CloseModel()
        {
            if (bMeshHighOpen)
            {
                mComponents.pMeshHigh.Destroy();
                mComponents.pMeshHigh = null;
            }
            if (bMeshOpen)
            {
                mComponents.pMesh.Destroy();
                mComponents.pMesh = null;
                mComponents.arrayCMeshProperties = null;
                bMeshOpen = false;
            }
            else
            {
                if (bActorOpen)
                {
                    mComponents.pActor.Destroy();
                    mComponents.pActor = null;
                    mComponents.arrayCActorProperties = null;
                    bActorOpen = false;
                }
            }
            mComponents.arrayMaterials = null;
            mComponents.pFrmMain._propertiesMain.SelectedObjects = null;
            mComponents.pTV.SetInternalShaderVersion(CONST_TV_SHADERMODEL.TV_SHADERMODEL_BEST );
            mComponents.pFrmMain._dockBottom.Visible = false;
            mGlobalProperties.bPlayBackwards = false;
            mComponents.pFrmMain._statusBarMain.Panels[2].Text = "KeyFrame: 0";
        }

        internal static void OpenFile(string filename, CONST_TV_FORMAT type)
        {
            CloseModel();
            mComponents.pScene.SetAutoTransColor(-327764);
            if (type == CONST_TV_FORMAT.TV_FORMAT_TVM)
            {
                mComponents.pMesh = mComponents.pScene.CreateMeshBuilder("");
                if (!mComponents.pMesh.LoadTVM(filename))
                {
                    Interaction.MsgBox("Failed to load the model.", MsgBoxStyle.Exclamation, "Error");
                    mComponents.pMesh = null;
                    bMeshOpen = false;
                }
                else
                {
                    bMeshOpen = true;
                }
            }
            else if (type == CONST_TV_FORMAT.TV_FORMAT_TVA)
            {
                mComponents.pActor = mComponents.pScene.CreateActor("");
                if (!mComponents.pActor.LoadTVA(filename, true, false))
                {
                    Interaction.MsgBox("Failed to load the model.", MsgBoxStyle.Exclamation, "Error");
                    mComponents.pActor = null;
                    bActorOpen = false;
                }
                else
                {
                    bActorOpen = true;
                }
            }
            else if (type == CONST_TV_FORMAT.TV_FORMAT_SX)
            {
                mComponents.pMesh = mComponents.pScene.CreateMeshBuilder("");
                if (!mComponents.pMesh.LoadXFile(filename, true, true))
                {
                    Interaction.MsgBox("Failed to load the model.", MsgBoxStyle.Exclamation, "Error");
                    mComponents.pMesh = null;
                    bMeshOpen = false;
                }
                else
                {
                    bMeshOpen = true;
                    mGlobalProperties.bDenySaveAs = true;
                }
            }
            else
            {
                if (type == CONST_TV_FORMAT.TV_FORMAT_DX)
                {
                    mComponents.pTV.SetInternalShaderVersion(CONST_TV_SHADERMODEL.TV_SHADERMODEL_NOSHADER); // todo: Hypnotron is this right?
                    mComponents.pActor = mComponents.pScene.CreateActor("");
                    if (!mComponents.pActor.LoadXFile(filename, true, true))
                    {
                        Interaction.MsgBox("Failed to load the model.", MsgBoxStyle.Exclamation, "Error");
                        mComponents.pActor = null;
                        bActorOpen = false;
                    }
                    else
                    {
                        bActorOpen = true;
                        mGlobalProperties.bDenySaveAs = true;
                    }
                }
            }
            mComponents.fLightRadius = mComponents.fRadius;
            if (bMeshOpen)
            {
                mComponents.arrayCMeshProperties = new cMeshProperties[mComponents.pMesh.GetGroupCount() + 1];
                mComponents.arrayShaders = new TVShader[mComponents.pMesh.GetGroupCount() + 1];
                int num14 = Information.UBound(mComponents.arrayCMeshProperties, 1);
                int num2 = 0;
                while (num2 <= num14)
                {
                    mComponents.arrayCMeshProperties[num2] = new cMeshProperties();
                    num2++;
                }
                mComponents.pFrmMain._propertiesMain.SelectedObject = mComponents.arrayCMeshProperties[0];
                mComponents.arrayMaterials = new int[mComponents.pMesh.GetGroupCount() + 1];
                int num13 = Information.UBound(mComponents.arrayMaterials, 1);
                num2 = 0;
                while (num2 <= num13)
                {
                    mComponents.arrayMaterials[num2] = mComponents.pMesh.GetMaterial(num2);
                    num2++;
                }
                mComponents.pMesh.SetLightingMode(0);
                mComponents.pMesh.GetBoundingSphere(ref vCenter, ref mComponents.fRadius, true);
                rotMatrix2 = mComponents.pMesh.GetRotationMatrix();
                Zoom = mComponents.fRadius*3.00F;
                int num12 = mComponents.pMesh.GetGroupCount();
                for (int i = 1; i <= num12; i++)
                {
                    mComponents.arrayCMeshProperties[i].iStage0 = mComponents.pMesh.GetTextureEx(0, i - 1);
                    TV_TEXTURE tv_texture1 =
                        mComponents.pTextureFactory.GetTextureInfo(mComponents.arrayCMeshProperties[i].iStage0);
                    mComponents.arrayCMeshProperties[i].sStage0 = tv_texture1.Filename;
                    if (StringType.StrCmp(mComponents.arrayCMeshProperties[i].sStage0, "blank", false) == 0)
                    {
                        mComponents.arrayCMeshProperties[i].sStage0 = "";
                    }
                    mComponents.arrayCMeshProperties[i].iStage1 = mComponents.pMesh.GetTextureEx(1, i - 1);
                    tv_texture1 = mComponents.pTextureFactory.GetTextureInfo(mComponents.arrayCMeshProperties[i].iStage1);
                    mComponents.arrayCMeshProperties[i].sStage1 = tv_texture1.Filename;
                    if (StringType.StrCmp(mComponents.arrayCMeshProperties[i].sStage1, "blank", false) == 0)
                    {
                        mComponents.arrayCMeshProperties[i].sStage1 = "";
                    }
                    mComponents.arrayCMeshProperties[i].iStage2 = mComponents.pMesh.GetTextureEx(2, i - 1);
                    tv_texture1 = mComponents.pTextureFactory.GetTextureInfo(mComponents.arrayCMeshProperties[i].iStage2);
                    mComponents.arrayCMeshProperties[i].sStage2 = tv_texture1.Filename;
                    if (StringType.StrCmp(mComponents.arrayCMeshProperties[i].sStage2, "blank", false) == 0)
                    {
                        mComponents.arrayCMeshProperties[i].sStage2 = "";
                    }
                    mComponents.arrayCMeshProperties[i].iStage3 = mComponents.pMesh.GetTextureEx(3, i - 1);
                    tv_texture1 = mComponents.pTextureFactory.GetTextureInfo(mComponents.arrayCMeshProperties[i].iStage3);
                    mComponents.arrayCMeshProperties[i].sStage3 = tv_texture1.Filename;
                    if (StringType.StrCmp(mComponents.arrayCMeshProperties[i].sStage3, "blank", false) == 0)
                    {
                        mComponents.arrayCMeshProperties[i].sStage3 = "";
                    }
                }
                mComponents.pFrmMain._comboGroups.Items.Clear();
                mComponents.pFrmMain._comboGroups.Items.Add("All Groups");
                if (mComponents.pMesh.GetGroupCount() == 1)
                {
                    mComponents.arrayCMeshProperties[0] = mComponents.arrayCMeshProperties[1];
                    mComponents.arrayCMeshProperties =
                        (cMeshProperties[]) Utils.CopyArray(mComponents.arrayCMeshProperties, new cMeshProperties[1]);
                }
                else
                {
                    int num11 = mComponents.pMesh.GetGroupCount();
                    for (num2 = 1; num2 <= num11; num2++)
                    {
                        mComponents.pFrmMain._comboGroups.Items.Add(num2 - 1);
                    }
                }
                mComponents.pFrmMain._comboGroups.SelectedIndex = 0;
                mGlobalProperties.iTriangles = mComponents.pMesh.GetTriangleCount();
                mGlobalProperties.iVertexes = mComponents.pMesh.GetVertexCount();
                mComponents.pFrmMain._dockBottom.Visible = false;
                mComponents.pFrmMain._statusBarMain.Panels[1].Text = "No Animation";
            }
            else
            {
                if (bActorOpen)
                {
                    mComponents.arrayCActorProperties = new cActorProperties[mComponents.pActor.GetGroupCount() + 1];
                    mComponents.arrayShaders = new TVShader[mComponents.pActor.GetGroupCount() + 1];
                    int num10 = Information.UBound(mComponents.arrayCActorProperties, 1);
                    int num4 = 0;
                    while (num4 <= num10)
                    {
                        mComponents.arrayCActorProperties[num4] = new cActorProperties();
                        num4++;
                    }
                    mComponents.pFrmMain._propertiesMain.SelectedObject = mComponents.arrayCActorProperties[0];
                    mComponents.arrayMaterials = new int[mComponents.pActor.GetGroupCount() + 1];
                    int num9 = Information.UBound(mComponents.arrayMaterials, 1);
                    num4 = 0;
                    while (num4 <= num9)
                    {
                        mComponents.arrayMaterials[num4] = mComponents.pActor.GetMaterial(num4);
                        num4++;
                    }
                    mComponents.pActor.SetLightingMode(0);
                    mComponents.pActor.GetBoundingSphere(ref vCenter, ref mComponents.fRadius, true);
                    rotMatrix2 = mComponents.pActor.GetRotationMatrix();
                    Zoom = mComponents.fRadius*3.00F;
                    int num8 = mComponents.pActor.GetGroupCount();
                    for (int j = 1; j <= num8; j++)
                    {
                        mComponents.arrayCActorProperties[j].iStage0 = mComponents.pActor.GetTextureEx(0, j - 1);
                        TV_TEXTURE tv_texture2 =
                            mComponents.pTextureFactory.GetTextureInfo(mComponents.arrayCActorProperties[j].iStage0);
                        mComponents.arrayCActorProperties[j].sStage0 = tv_texture2.Filename;
                        if (StringType.StrCmp(mComponents.arrayCActorProperties[j].sStage0, "blank", false) == 0)
                        {
                            mComponents.arrayCActorProperties[j].sStage0 = "";
                        }
                        mComponents.arrayCActorProperties[j].iStage1 = mComponents.pActor.GetTextureEx(1, j - 1);
                        tv_texture2 =
                            mComponents.pTextureFactory.GetTextureInfo(mComponents.arrayCActorProperties[j].iStage1);
                        mComponents.arrayCActorProperties[j].sStage1 = tv_texture2.Filename;
                        if (StringType.StrCmp(mComponents.arrayCActorProperties[j].sStage1, "blank", false) == 0)
                        {
                            mComponents.arrayCActorProperties[j].sStage1 = "";
                        }
                        mComponents.arrayCActorProperties[j].iStage2 = mComponents.pActor.GetTextureEx(2, j - 1);
                        tv_texture2 =
                            mComponents.pTextureFactory.GetTextureInfo(mComponents.arrayCActorProperties[j].iStage2);
                        mComponents.arrayCActorProperties[j].sStage2 = tv_texture2.Filename;
                        if (StringType.StrCmp(mComponents.arrayCActorProperties[j].sStage2, "blank", false) == 0)
                        {
                            mComponents.arrayCActorProperties[j].sStage2 = "";
                        }
                        mComponents.arrayCActorProperties[j].iStage3 = mComponents.pActor.GetTextureEx(3, j - 1);
                        tv_texture2 =
                            mComponents.pTextureFactory.GetTextureInfo(mComponents.arrayCActorProperties[j].iStage3);
                        mComponents.arrayCActorProperties[j].sStage3 = tv_texture2.Filename;
                        if (StringType.StrCmp(mComponents.arrayCActorProperties[j].sStage3, "blank", false) == 0)
                        {
                            mComponents.arrayCActorProperties[j].sStage3 = "";
                        }
                    }
                    mComponents.pFrmMain._comboGroups.Items.Clear();
                    mComponents.pFrmMain._comboGroups.Items.Add("All Groups");
                    if (mComponents.pActor.GetGroupCount() == 1)
                    {
                        mComponents.arrayCActorProperties[0] = mComponents.arrayCActorProperties[1];
                        mComponents.arrayCActorProperties =
                            (cActorProperties[])
                            Utils.CopyArray(mComponents.arrayCActorProperties, new cActorProperties[1]);
                    }
                    else
                    {
                        int num7 = mComponents.pActor.GetGroupCount();
                        for (num4 = 1; num4 <= num7; num4++)
                        {
                            mComponents.pFrmMain._comboGroups.Items.Add(num4 - 1);
                        }
                    }
                    mComponents.pFrmMain._comboGroups.SelectedIndex = 0;
                    mGlobalProperties.iTriangles = mComponents.pActor.GetTriangleCount();
                    mGlobalProperties.iVertexes = mComponents.pActor.GetVertexCount();
                    if (mComponents.pActor.MorphTarget_GetCount() != 0)
                    {
                        mComponents.pActor.MorphTarget_Enable(true, true);
                    }
                    if (mComponents.pActor.GetAnimationCount() > 0)
                    {
                        mComponents.pFrmMain._comboAnimations.Items.Clear();
                        int num6 = mComponents.pActor.GetAnimationCount() - 1;
                        for (num4 = 0; num4 <= num6; num4++)
                        {
                            if (StringType.StrCmp(mComponents.pActor.GetAnimationName(num4), "", false) == 0)
                            {
                                mComponents.pFrmMain._comboAnimations.Items.Add("Animation" + num4);
                            }
                            else
                            {
                                mComponents.pFrmMain._comboAnimations.Items.Add(mComponents.pActor.GetAnimationName(num4));
                            }
                        }
                        mComponents.pFrmMain._comboAnimations.SelectedIndex = 0;
                        mComponents.pFrmMain._scrollAnimation.Maximum =
                            (int) Math.Round(mComponents.pActor.GetAnimationLength(0));
                        mComponents.pActor.StopAnimation();
                        mComponents.pFrmMain._dockBottom.Visible = true;
                        mComponents.pFrmMain._statusBarMain.Panels[1].Text = "Stopped";
                    }
                }
            }
            mGlobalProperties.eLightMode = 0;
            fGridRatio = (float) (mComponents.fRadius*0.15);
            TranslateLights(mComponents.fRadius/mComponents.fLightRadius);
            mComponents.fLightRadius = mComponents.fRadius;
        }

        internal static void RefreshAnimationList()
        {
            int num1 = mComponents.pFrmMain._comboAnimations.SelectedIndex;
            mComponents.pFrmMain._comboAnimations.Items.Clear();
            long num3 = mComponents.pActor.GetAnimationCount() - 1;
            for (long i = 0; i <= num3; i += 1)
            {
                if (StringType.StrCmp(mComponents.pActor.GetAnimationName((int) i), "", false) == 0)
                {
                    mComponents.pFrmMain._comboAnimations.Items.Add("Animation" + i);
                }
                else
                {
                    mComponents.pFrmMain._comboAnimations.Items.Add(mComponents.pActor.GetAnimationName((int)i));
                }
            }
            if ((num1 >= 0) & (num1 < mComponents.pFrmMain._comboAnimations.Items.Count))
            {
                mComponents.pFrmMain._comboAnimations.SelectedIndex = num1;
            }
        }

        internal static void Render3D()
        {
            int num2;
            Exception exception1;
            int num3;
            int num4;
            Label_0000:
            try
            {
                if (mComponents.pMesh != null)
                    mComponents.pMesh.Render();
                else if (mComponents.pActor != null)
                {
                    mComponents.pActor.Render();
                    if (mComponents.bPlayingAnimation)
                    {
                        // update the scroller position
                        mComponents.pFrmMain._scrollAnimation.Value = (int)Math.Round(mComponents.pActor.GetKeyFrame());
                    }
                }


                //// render light srcs  // todo:
                //int num5 = mComponents.pLightEngine.GetActiveCount() - 1;
                //for (int i = 0; i < num5; i++)
                //{
                //    if (!((mComponents.arrayTV_LIGHT[num1].type == (CONST_TV_LIGHTTYPE)1) | (mComponents.arrayTV_LIGHT[num1].type == (CONST_TV_LIGHTTYPE)2)))
                //    {
                //        mComponents.arrayLightMesh[i].Render();
                //    }
                //}
            }
            catch { }
            Application.DoEvents (); // sucks but oh well
            
        }

        // todo: Hypnotron - i had to comment this nasty decompiled routine out.  The decompiler
        // made what should have been a simple routine into something completely asinine.
        // However it should be trivial for any contributor to just wipe it out and add your own grid function
        // and whatever other 2d drawing code you want in there
        internal static void Render2D()
        {
            DrawGrid(10, 10, 10, 200);
            //int num2;
            //Exception exception1;
            //int num3;
            //int num4;
            //Label_0000:
            //try
            //{
            //    float single1 = -1;
            //    float single2 = -1;
            //    ProjectData.ClearProjectError();
            //    num4 = 1;
            //    Label_0008:
            //    num2 = 1;
            //    int num7 = mComponents.pLightEngine.GetActiveCount() - 1;
            //    int num1 = 0;
            //    goto Label_0178;
            //    Label_0020:
            //    num2 = 2;
            //    if (!((mComponents.arrayTV_LIGHT[num1].type == (CONST_TV_LIGHTTYPE)1) | (mComponents.arrayTV_LIGHT[num1].type == (CONST_TV_LIGHTTYPE)2)))
            //    {
            //        goto Label_0171;
            //    }
            //    Label_004F:
            //    num2 = 3;
            //    if (mComponents.arrayTV_LIGHT[num1].type != (CONST_TV_LIGHTTYPE)2)
            //    {
            //        goto Label_0171;
            //    }
            //    Label_0068:
            //    num2 = 4;
            //    TV_3DVECTOR tv_dvector9 = mComponents.arrayLightMesh[num1].GetPosition();
            //    TV_3DVECTOR tv_dvector8 = mComponents.arrayLightMesh[num1].GetPosition();
            //    TV_3DVECTOR tv_dvector7 = mComponents.arrayLightMesh[num1].GetPosition();
            //    TV_3DVECTOR tv_dvector6 = mComponents.arrayLightMesh[num1].GetPosition();
            //    TV_3DVECTOR tv_dvector5 = mComponents.arrayLightMesh[num1].GetPosition();
            //    TV_3DVECTOR tv_dvector4 = mComponents.arrayLightMesh[num1].GetPosition();
            //    mComponents.pScreen2DImmediate.Draw_Line3D(tv_dvector9.x, tv_dvector8.y, tv_dvector7.z,
            //                                               tv_dvector6.x +
            //                                               ((float)
            //                                                (mComponents.arrayTV_LIGHT[num1].direction.x*
            //                                                 (mComponents.fRadius*0.3))),
            //                                               tv_dvector5.y +
            //                                               ((float)
            //                                                (mComponents.arrayTV_LIGHT[num1].direction.y*
            //                                                 (mComponents.fRadius*0.3))),
            //                                               tv_dvector4.z +
            //                                               ((float)
            //                                                (mComponents.arrayTV_LIGHT[num1].direction.z*
            //                                                 (mComponents.fRadius*0.3))));
            //    Label_0171:
            //    num2 = 7;
            //    num1++;
            //    Label_0178:
            //    if (num1 <= num7)
            //    {
            //        goto Label_0020;
            //    }
            //    Label_0180:
            //    num2 = 8;
            //    mComponents.pScreen2DImmediate.Action_Begin2D();
            //    Label_018D:
            //    num2 = 9;
            //    if (!mGlobalProperties.bShowGrid)
            //    {
            //        goto Label_0867;
            //    }
            //    Label_019B:
            //    num2 = 10;
            //    mComponents.pScreen2DImmediate.Draw_Line3D(-8.00F*fGridRatio, 0.00F, -8.00F*fGridRatio,
            //                                               -8.00F*fGridRatio, 0.00F, 8.00F*fGridRatio,
            //                                               mComponents.pG.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
            //    Label_01FD:
            //    num2 = 11;
            //    mComponents.pScreen2DImmediate.Draw_Line3D(-6.00F*fGridRatio, 0.00F, -8.00F*fGridRatio,
            //                                               -6.00F*fGridRatio, 0.00F, 8.00F*fGridRatio,
            //                                               mComponents.pG.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
            //    Label_025F:
            //    num2 = 12;
            //    mComponents.pScreen2DImmediate.Draw_Line3D(-4.00F*fGridRatio, 0.00F, -8.00F*fGridRatio,
            //                                               -4.00F*fGridRatio, 0.00F, 8.00F*fGridRatio,
            //                                               mComponents.pG.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
            //    Label_02C1:
            //    num2 = 13;
            //    mComponents.pScreen2DImmediate.Draw_Line3D(-2.00F*fGridRatio, 0.00F, -8.00F*fGridRatio,
            //                                               -2.00F*fGridRatio, 0.00F, 8.00F*fGridRatio,
            //                                               mComponents.pG.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
            //    Label_0323:
            //    num2 = 14;
            //    mComponents.pScreen2DImmediate.Draw_Line3D(0.00F, 0.00F, -8.00F*fGridRatio, 0.00F, 0.00F,
            //                                               8.00F*fGridRatio,
            //                                               mComponents.pG.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
            //    Label_0379:
            //    num2 = 15;
            //    mComponents.pScreen2DImmediate.Draw_Line3D(2.00F*fGridRatio, 0.00F, -8.00F*fGridRatio, 2.00F*fGridRatio,
            //                                               0.00F, 8.00F*fGridRatio,
            //                                               mComponents.pG.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
            //    Label_03DB:
            //    num2 = 0x10;
            //    mComponents.pScreen2DImmediate.Draw_Line3D(4.00F*fGridRatio, 0.00F, -8.00F*fGridRatio, 4.00F*fGridRatio,
            //                                               0.00F, 8.00F*fGridRatio,
            //                                               mComponents.pG.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
            //    Label_043D:
            //    num2 = 0x11;
            //    mComponents.pScreen2DImmediate.Draw_Line3D(6.00F*fGridRatio, 0.00F, -8.00F*fGridRatio, 6.00F*fGridRatio,
            //                                               0.00F, 8.00F*fGridRatio,
            //                                               mComponents.pG.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
            //    Label_049F:
            //    num2 = 0x12;
            //    mComponents.pScreen2DImmediate.Draw_Line3D(8.00F*fGridRatio, 0.00F, -8.00F*fGridRatio, 8.00F*fGridRatio,
            //                                               0.00F, 8.00F*fGridRatio,
            //                                               mComponents.pG.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
            //    Label_0501:
            //    num2 = 0x13;
            //    mComponents.pScreen2DImmediate.Draw_Line3D(-8.00F*fGridRatio, 0.00F, -8.00F*fGridRatio, 8.00F*fGridRatio,
            //                                               0.00F, -8.00F*fGridRatio,
            //                                               mComponents.pG.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
            //    Label_0563:
            //    num2 = 0x14;
            //    mComponents.pScreen2DImmediate.Draw_Line3D(-8.00F*fGridRatio, 0.00F, -6.00F*fGridRatio, 8.00F*fGridRatio,
            //                                               0.00F, -6.00F*fGridRatio,
            //                                               mComponents.pG.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
            //    Label_05C5:
            //    num2 = 0x15;
            //    mComponents.pScreen2DImmediate.Draw_Line3D(-8.00F*fGridRatio, 0.00F, -4.00F*fGridRatio, 8.00F*fGridRatio,
            //                                               0.00F, -4.00F*fGridRatio,
            //                                               mComponents.pG.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
            //    Label_0627:
            //    num2 = 0x16;
            //    mComponents.pScreen2DImmediate.Draw_Line3D(-8.00F*fGridRatio, 0.00F, -2.00F*fGridRatio, 8.00F*fGridRatio,
            //                                               0.00F, -2.00F*fGridRatio,
            //                                               mComponents.pG.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
            //    Label_0689:
            //    num2 = 0x17;
            //    mComponents.pScreen2DImmediate.Draw_Line3D(-8.00F*fGridRatio, 0.00F, 0.00F, 8.00F*fGridRatio, 0.00F,
            //                                               0.00F, mComponents.pG.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
            //    Label_06DF:
            //    num2 = 0x18;
            //    mComponents.pScreen2DImmediate.Draw_Line3D(-8.00F*fGridRatio, 0.00F, 2.00F*fGridRatio, 8.00F*fGridRatio,
            //                                               0.00F, 2.00F*fGridRatio,
            //                                               mComponents.pG.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
            //    Label_0741:
            //    num2 = 0x19;
            //    mComponents.pScreen2DImmediate.Draw_Line3D(-8.00F*fGridRatio, 0.00F, 4.00F*fGridRatio, 8.00F*fGridRatio,
            //                                               0.00F, 4.00F*fGridRatio,
            //                                               mComponents.pG.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
            //    Label_07A3:
            //    num2 = 0x1a;
            //    mComponents.pScreen2DImmediate.Draw_Line3D(-8.00F*fGridRatio, 0.00F, 6.00F*fGridRatio, 8.00F*fGridRatio,
            //                                               0.00F, 6.00F*fGridRatio,
            //                                               mComponents.pG.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
            //    Label_0805:
            //    num2 = 0x1b;
            //    mComponents.pScreen2DImmediate.Draw_Line3D(-8.00F*fGridRatio, 0.00F, 8.00F*fGridRatio, 8.00F*fGridRatio,
            //                                               0.00F, 8.00F*fGridRatio,
            //                                               mComponents.pG.RGBA(1.00F, 0.00F, 0.00F, 1.00F));
            //    Label_0867:
            //    num2 = 0x1d;
            //    mComponents.pScreen2DImmediate.Action_End2D();
            //    Label_0875:
            //    num2 = 0x1e;
            //    mComponents.pScreen2DImmediate.Settings_Set3DLineParameters(false);
            //    Label_0884:
            //    num2 = 0x1f;
            //    mComponents.pScreen2DImmediate.Action_Begin2D();
            //    Label_0892:
            //    num2 = 0x20;
            //    if (!mGlobalProperties.bShowSkeleton)
            //    {
            //        goto Label_0956;
            //    }
            //    Label_08A0:
            //    num2 = 0x21;
            //    if (!bActorOpen)
            //    {
            //        goto Label_0956;
            //    }
            //    Label_08AE:
            //    num2 = 0x22;
            //    int num6 = mComponents.pActor.GetBoneCount() - 1;
            //    num1 = 0;
            //    goto Label_094E;
            //    Label_08C7:
            //    num2 = 0x23;
            //    if (mComponents.pActor.GetBoneParent(num1) < 0)
            //    {
            //        goto Label_0946;
            //    }
            //    Label_08D9:
            //    num2 = 0x24;
            //    TV_3DVECTOR tv_dvector1 = mComponents.pActor.GetBonePosition(num1);
            //    Label_08E9:
            //    num2 = 0x25;
            //    TV_3DVECTOR tv_dvector2 = mComponents.pActor.GetBonePosition(mComponents.pActor.GetBoneParent(num1));
            //    Label_0904:
            //    num2 = 0x26;
            //    mComponents.pScreen2DImmediate.Draw_Line3D(tv_dvector1.x, tv_dvector1.y, tv_dvector1.z, tv_dvector2.x,
            //                                               tv_dvector2.y, tv_dvector2.z, -65536, -28528);
            //    Label_0946:
            //    num2 = 0x28;
            //    num1++;
            //    Label_094E:
            //    if (num1 <= num6)
            //    {
            //        goto Label_08C7;
            //    }
            //    Label_0956:
            //    num2 = 0x2b;
            //    mComponents.pScreen2DImmediate.Action_End2D();
            //    Label_0964:
            //    num2 = 0x2c;
            //    mComponents.pScreen2DImmediate.Action_Begin2D();
            //    Label_0972:
            //    num2 = 0x2d;
            //    if (!mGlobalProperties.bShowBoneNames)
            //    {
            //        goto Label_0A5F;
            //    }
            //    Label_0980:
            //    num2 = 0x2e;
            //    int num5 = mComponents.pActor.GetBoneCount() - 1;
            //    num1 = 0;
            //    goto Label_0A57;
            //    Label_0999:
            //    num2 = 0x2f;
            //    TV_3DVECTOR tv_dvector3 = mComponents.pActor.GetBonePosition(num1);
            //    Label_09AA:
            //    num2 = 0x30;
            //    if (
            //        !(((((num1 > 0) & (mComponents.pActor.GetBoneParent(num1) == 0)) & (tv_dvector3.x == 0.00F)) &
            //           (tv_dvector3.y == 0.00F)) & (tv_dvector3.z == 0.00F)))
            //    {
            //        goto Label_09F6;
            //    }
            //    Label_09F0:
            //    num2 = 0x31;
            //    goto Label_0A4F;
            //    Label_09F6:
            //    num2 = 0x32;
            //    if (!mComponents.pScreen2DImmediate.Math_3DPointTo2D(tv_dvector3, ref single1, ref single2, true))
            //    {
            //        goto Label_0A4F;
            //    }
            //    Label_0A0D:
            //    num2 = 0x33;
            //    mComponents.pScreen2DImmediate.Draw_Circle(single1, single2, 5.00F, 0x14, -65536);
            //    Label_0A29:
            //    num2 = 0x34;
            //    mComponents.pText.TextureFont_DrawText(mComponents.pActor.GetBoneName(num1), single1 + 10.00F, single2,
            //                                           -65536);
            //    Label_0A4F:
            //    num2 = 0x36;
            //    num1++;
            //    Label_0A57:
            //    if (num1 <= num5)
            //    {
            //        goto Label_0999;
            //    }
            //    Label_0A5F:
            //    num2 = 0x38;
            //    mComponents.pScreen2DImmediate.Action_End2D();
            //    Label_0A6D:
            //    num2 = 0x39;
            //    mComponents.pScreen2DImmediate.Settings_Set3DLineParameters(true);
            //    //goto Label_0BC4;
            //    num3 = 0;
            //    switch (num3 + 1)
            //    {
            //        case 0:
            //            {
            //                goto Label_0000;
            //            }
            //        case 1:
            //            {
            //                goto Label_0008;
            //            }
            //        case 2:
            //            {
            //                goto Label_0020;
            //            }
            //        case 3:
            //            {
            //                goto Label_004F;
            //            }
            //        case 4:
            //            {
            //                goto Label_0068;
            //            }
            //        case 5:
            //        case 6:
            //        case 7:
            //            {
            //                goto Label_0171;
            //            }
            //        case 8:
            //            {
            //                goto Label_0180;
            //            }
            //        case 9:
            //            {
            //                goto Label_018D;
            //            }
            //        case 10:
            //            {
            //                goto Label_019B;
            //            }
            //        case 11:
            //            {
            //                goto Label_01FD;
            //            }
            //        case 12:
            //            {
            //                goto Label_025F;
            //            }
            //        case 13:
            //            {
            //                goto Label_02C1;
            //            }
            //        case 14:
            //            {
            //                goto Label_0323;
            //            }
            //        case 15:
            //            {
            //                goto Label_0379;
            //            }
            //        case 0x10:
            //            {
            //                goto Label_03DB;
            //            }
            //        case 0x11:
            //            {
            //                goto Label_043D;
            //            }
            //        case 0x12:
            //            {
            //                goto Label_049F;
            //            }
            //        case 0x13:
            //            {
            //                goto Label_0501;
            //            }
            //        case 0x14:
            //            {
            //                goto Label_0563;
            //            }
            //        case 0x15:
            //            {
            //                goto Label_05C5;
            //            }
            //        case 0x16:
            //            {
            //                goto Label_0627;
            //            }
            //        case 0x17:
            //            {
            //                goto Label_0689;
            //            }
            //        case 0x18:
            //            {
            //                goto Label_06DF;
            //            }
            //        case 0x19:
            //            {
            //                goto Label_0741;
            //            }
            //        case 0x1a:
            //            {
            //                goto Label_07A3;
            //            }
            //        case 0x1b:
            //            {
            //                goto Label_0805;
            //            }
            //        case 0x1c:
            //        case 0x1d:
            //            {
            //                goto Label_0867;
            //            }
            //        case 0x1e:
            //            {
            //                goto Label_0875;
            //            }
            //        case 0x1f:
            //            {
            //                goto Label_0884;
            //            }
            //        case 0x20:
            //            {
            //                goto Label_0892;
            //            }
            //        case 0x21:
            //            {
            //                goto Label_08A0;
            //            }
            //        case 0x22:
            //            {
            //                goto Label_08AE;
            //            }
            //        case 0x23:
            //            {
            //                goto Label_08C7;
            //            }
            //        case 0x24:
            //            {
            //                goto Label_08D9;
            //            }
            //        case 0x25:
            //            {
            //                goto Label_08E9;
            //            }
            //        case 0x26:
            //            {
            //                goto Label_0904;
            //            }
            //        case 0x27:
            //        case 0x28:
            //            {
            //                goto Label_0946;
            //            }
            //        case 0x29:
            //        case 0x2a:
            //        case 0x2b:
            //            {
            //                goto Label_0956;
            //            }
            //        case 0x2c:
            //            {
            //                goto Label_0964;
            //            }
            //        case 0x2d:
            //            {
            //                goto Label_0972;
            //            }
            //        case 0x2e:
            //            {
            //                goto Label_0980;
            //            }
            //        case 0x2f:
            //            {
            //                goto Label_0999;
            //            }
            //        case 0x30:
            //            {
            //                goto Label_09AA;
            //            }
            //        case 0x31:
            //            {
            //                goto Label_09F0;
            //            }
            //        case 0x32:
            //            {
            //                goto Label_09F6;
            //            }
            //        case 0x33:
            //            {
            //                goto Label_0A0D;
            //            }
            //        case 0x34:
            //            {
            //                goto Label_0A29;
            //            }
            //        case 0x35:
            //        case 0x36:
            //            {
            //                goto Label_0A4F;
            //            }
            //        case 0x37:
            //        case 0x38:
            //            {
            //                goto Label_0A5F;
            //            }
            //        case 0x39:
            //            {
            //                goto Label_0A6D;
            //            }
            //        case 0x3a:
            //            {
            //                goto Label_0BC4;
            //            }
            //    }
            //}
            //catch (Exception ex)
            //{
            ////    ProjectData.SetProjectError(ex);
            ////    if (num3 != 0)
            ////    {
            ////        goto Label_0BC1;
            ////    }
            ////    num3 = num2;
            ////    switch (num4)
            ////    {
            ////        case 0:
            ////            {
            ////                goto Label_0BBF;
            ////            }
            ////        case 1:
            ////            {
            ////                goto Label_0A81;
            ////            }
            ////    }
            ////    Label_0BBF:
            ////    throw;
            ////}
            ////Label_0BC1:
            ////throw exception1;
            //Label_0BC4:
            ////if (num3 != 0)
            ////{
            //    ProjectData.ClearProjectError();
            //}
        }

        // Steve - below is a grid drawing function iuse in my own project but i didnt want to screw around and get it working here.. im tired of this :)

        public static void DrawGrid(uint rows, uint columns, float spacing, int color)
        {
            float r = spacing;
            for (int x = -10; x <= 10; x++)
                mComponents.pScreen2DImmediate.Draw_Line3D(x * r, 0, -10 * r, x * r, 0, 10 * r, color);
            for (int x = -10; x <= 10; x++)
                mComponents.pScreen2DImmediate.Draw_Line3D(-10 * r, 0, x * r, 10 * r, 0, x * r);

        }

        internal static void ProcessShader()
        {
        }

        internal static void HandleInput()
        {
            if (mGlobalProperties.bMouseInRender)
            {
                TV_3DMATRIX tv_dmatrix1;
                TV_3DMATRIX tv_dmatrix2;
                TV_3DMATRIX tv_dmatrix3;
                mComponents.pInputEngine.GetAbsMouseState(ref MouseX, ref MouseY, ref MB1);
                if (MB1 & !CollCheck)
                {
                    mComponents.pCollisionResult = mComponents.pScene.MousePick(MouseX, MouseY);
                    if (mComponents.pCollisionResult.GetCollisionObjectType() ==  CONST_TV_OBJECT_TYPE.TV_OBJECT_ALL )
                    {
                        int num5 = mComponents.pLightEngine.GetActiveCount() - 1;
                        for (int i = 0; i <= num5; i++)
                        {
                            mComponents.arrayLightMesh[i].ShowBoundingBox(false);
                        }
                        if (
                            StringType.StrCmp(mComponents.pCollisionResult.GetCollisionMesh().GetMeshName(), "", false) !=
                            0)
                        {
                            mComponents.pCollisionResult.GetCollisionMesh().ShowBoundingBox(true);
                            mGlobalProperties.meshIndex =
                                IntegerType.FromString(mComponents.pCollisionResult.GetCollisionMesh().GetMeshName());
                            mComponents.pFrmMain._comboLights.SelectedIndex = mGlobalProperties.meshIndex;
                            CollCheck = true;
                            mComponents.bRotateCamera = false;
                            mGlobalProperties.bLightCollision = true;
                        }
                        else
                        {
                            mComponents.bRotateCamera = true;
                        }
                    }
                    else
                    {
                        if (mComponents.pCollisionResult.GetCollisionObjectType() == CONST_TV_OBJECT_TYPE.TV_OBJECT_MESH)
                        {
                            int num4 = mComponents.pLightEngine.GetActiveCount() - 1;
                            for (int j = 0; j <= num4; j++)
                            {
                                mComponents.arrayLightMesh[j].ShowBoundingBox(false);
                            }
                            mComponents.bRotateCamera = true;
                            mGlobalProperties.bLightCollision = false;
                        }
                    }
                }
                else
                {
                    if (!MB1)
                    {
                        CollCheck = false;
                        mGlobalProperties.bLightCollision = false;
                    }
                }
                bool flag1 = false;
                int num3 = (int) mousewheel;
                mComponents.pInputEngine.GetMouseState(ref MouseX, ref MouseY, ref MB1, ref MB2, ref MB3, ref flag1,
                                                       ref num3);
                mousewheel = num3;
                if (mComponents.bRotateCamera)
                {
                    Zoom += (float) ((mousewheel*mComponents.fRadius)*0.001);
                    if (MB1)
                    {
                        CollCheck = true;
                        AngleX = ((MouseX)/mComponents.pTV.AccurateTimeElapsed())*2.00F;
                        AngleY = ((MouseY)/mComponents.pTV.AccurateTimeElapsed())*2.00F;
                        if (mComponents.bRotateCamera)
                        {
                            fTotalAngleX += AngleX;
                            fTotalAngleY += AngleY;
                        }
                    }
                    else if (MB2)
                    {
                        Zoom += (float) ((((MouseY)/mComponents.pTV.TimeElapsed())*mComponents.fRadius)*0.1);
                    }
                    else
                    {
                        if (MB3)
                        {
                            tv_dmatrix3 = mComponents.pCamera.GetRotationMatrix();
                            tv_dmatrix2 = mComponents.pCamera.GetRotationMatrix();
                            tv_dmatrix1 = mComponents.pCamera.GetRotationMatrix();
                            TV_3DVECTOR tv_dvector2 = mComponents.pG.Vector(tv_dmatrix3.m21*-1.00F,
                                                                            tv_dmatrix2.m22*-1.00F,
                                                                            tv_dmatrix1.m23*-1.00F);
                            tv_dmatrix1 = mComponents.pCamera.GetRotationMatrix();
                            tv_dmatrix2 = mComponents.pCamera.GetRotationMatrix();
                            tv_dmatrix3 = mComponents.pCamera.GetRotationMatrix();
                            TV_3DVECTOR tv_dvector1 = mComponents.pG.Vector(tv_dmatrix1.m11, tv_dmatrix2.m12,
                                                                            tv_dmatrix3.m13);
                            lookat.x =
                                (float)
                                ((lookat.x -
                                  (tv_dvector2.x*
                                   (((MouseY)/mComponents.pTV.AccurateTimeElapsed())*(Math.Abs(Zoom)*0.02)))) -
                                 (tv_dvector1.x*(((MouseX)/mComponents.pTV.AccurateTimeElapsed())*(Math.Abs(Zoom)*0.02))));
                            lookat.y =
                                (float)
                                ((lookat.y -
                                  (tv_dvector2.y*
                                   (((MouseY)/mComponents.pTV.AccurateTimeElapsed())*(Math.Abs(Zoom)*0.02)))) -
                                 (tv_dvector1.y*(((MouseX)/mComponents.pTV.AccurateTimeElapsed())*(Math.Abs(Zoom)*0.02))));
                            lookat.z =
                                (float)
                                ((lookat.z -
                                  (tv_dvector2.z*
                                   (((MouseY)/mComponents.pTV.AccurateTimeElapsed())*(Math.Abs(Zoom)*0.02)))) -
                                 (tv_dvector1.z*(((MouseX)/mComponents.pTV.AccurateTimeElapsed())*(Math.Abs(Zoom)*0.02))));
                        }
                    }
                }
                TVInputEngine engine1 = null;
                if (mGlobalProperties.bLightCollision)
                {
                    tv_dmatrix1 = mComponents.pCamera.GetRotationMatrix();
                    tv_dmatrix2 = mComponents.pCamera.GetRotationMatrix();
                    tv_dmatrix3 = mComponents.pCamera.GetRotationMatrix();
                    TV_3DVECTOR tv_dvector4 = mComponents.pG.Vector(tv_dmatrix1.m21*-1.00F, tv_dmatrix2.m22*-1.00F,
                                                                    tv_dmatrix3.m23*-1.00F);
                    tv_dmatrix1 = mComponents.pCamera.GetRotationMatrix();
                    tv_dmatrix2 = mComponents.pCamera.GetRotationMatrix();
                    tv_dmatrix3 = mComponents.pCamera.GetRotationMatrix();
                    TV_3DVECTOR tv_dvector3 = mComponents.pG.Vector(tv_dmatrix1.m11, tv_dmatrix2.m12, tv_dmatrix3.m13);
                    TV_3DVECTOR tv_dvector5 = mComponents.arrayLightMesh[mGlobalProperties.meshIndex].GetPosition();
                    mComponents.arrayCLightProperties[mGlobalProperties.meshIndex].PositionX =
                        (float)
                        ((tv_dvector5.x +
                          (tv_dvector4.x*(((MouseY)/mComponents.pTV.AccurateTimeElapsed())*(Math.Abs(Zoom)*0.02)))) +
                         (tv_dvector3.x*(((MouseX)/mComponents.pTV.AccurateTimeElapsed())*(Math.Abs(Zoom)*0.02))));
                    tv_dvector5 = mComponents.arrayLightMesh[mGlobalProperties.meshIndex].GetPosition();
                    mComponents.arrayCLightProperties[mGlobalProperties.meshIndex].PositionY =
                        (float)
                        ((tv_dvector5.y +
                          (tv_dvector4.y*(((MouseY)/mComponents.pTV.AccurateTimeElapsed())*(Math.Abs(Zoom)*0.02)))) +
                         (tv_dvector3.y*(((MouseX)/mComponents.pTV.AccurateTimeElapsed())*(Math.Abs(Zoom)*0.02))));
                    tv_dvector5 = mComponents.arrayLightMesh[mGlobalProperties.meshIndex].GetPosition();
                    mComponents.arrayCLightProperties[mGlobalProperties.meshIndex].PositionZ =
                        (float)
                        ((tv_dvector5.z +
                          (tv_dvector4.z*(((MouseY)/mComponents.pTV.AccurateTimeElapsed())*(Math.Abs(Zoom)*0.02)))) +
                         (tv_dvector3.z*(((MouseX)/mComponents.pTV.AccurateTimeElapsed())*(Math.Abs(Zoom)*0.02))));
                    mComponents.pFrmMain._propertiesLights.Refresh();
                }
                if (mComponents.bRotateCamera & (bActorOpen | bMeshOpen))
                {
                    RotateCamera();
                }
            }
        }

        internal static void RotateCamera()
        {
            if (fTotalAngleX > 360.00F)
            {
                fTotalAngleX -= 360.00F;
            }
            if (fTotalAngleX < 0.00F)
            {
                fTotalAngleX += 360.00F;
            }
            if (fTotalAngleY > 89.9)
            {
                fTotalAngleY = 89.90F;
            }
            if (fTotalAngleY < -89.9)
            {
                fTotalAngleY = -89.90F;
            }
            TV_3DVECTOR tv_dvector1 = mComponents.pMathLibrary.MoveAroundPoint(lookat, -Zoom*2.00F, fTotalAngleX,
                                                                               fTotalAngleY);
            Console.WriteLine(fTotalAngleX);
            Console.WriteLine(fTotalAngleY);
            mComponents.pCamera.SetPosition(tv_dvector1.x, tv_dvector1.y, tv_dvector1.z);
            mComponents.pCamera.SetLookAt(lookat.x, lookat.y, lookat.z);
        }

        internal static void RotateModel()
        {
            if (bMeshOpen)
            {
                mComponents.pMathLibrary.TVMatrixTranslation(ref retMatrix1, -vCenter.x, -vCenter.y, -vCenter.z);
                mComponents.pMathLibrary.TVMatrixTranslation(ref retMatrix2, vCenter.x, vCenter.y, vCenter.z);
                mComponents.pMathLibrary.TVMatrixTranslation(ref retMatrix4, vLookAt.x, vLookAt.y, vLookAt.z);
                if (MB1)
                {
                    mComponents.pMathLibrary.TVMatrixRotationX(ref rotMatrixX, -AngleX);
                    mComponents.pMathLibrary.TVMatrixRotationY(ref rotMatrixY, -AngleY);
                }
                else
                {
                    mComponents.pMathLibrary.TVMatrixRotationX(ref rotMatrixX, 0.00F);
                    mComponents.pMathLibrary.TVMatrixRotationY(ref rotMatrixY, 0.00F);
                }
                mComponents.pMathLibrary.TVMatrixMultiply(ref rotMatrix1, rotMatrixX, rotMatrixY);
                mComponents.pMathLibrary.TVMatrixMultiply(ref rotMatrix1, rotMatrix2, rotMatrix1);
                rotMatrix2 = rotMatrix1;
                mComponents.pMathLibrary.TVMatrixMultiply(ref retMatrix3, retMatrix1, rotMatrix1);
                mComponents.pMathLibrary.TVMatrixMultiply(ref finalMatrix, retMatrix3, retMatrix2);
                mComponents.pMathLibrary.TVMatrixMultiply(ref finalMatrix, finalMatrix, retMatrix4);
                mComponents.pMesh.SetMatrix(finalMatrix);
            }
            else
            {
                if (bActorOpen)
                {
                    mComponents.pMathLibrary.TVMatrixTranslation(ref retMatrix1, -vCenter.x, -vCenter.y, -vCenter.z);
                    mComponents.pMathLibrary.TVMatrixTranslation(ref retMatrix2, vCenter.x, vCenter.y, vCenter.z);
                    mComponents.pMathLibrary.TVMatrixTranslation(ref retMatrix4, vLookAt.x, vLookAt.y, vLookAt.z);
                    if (MB1)
                    {
                        mComponents.pMathLibrary.TVMatrixRotationX(ref rotMatrixX, -AngleX);
                        mComponents.pMathLibrary.TVMatrixRotationY(ref rotMatrixY, -AngleY);
                    }
                    else
                    {
                        mComponents.pMathLibrary.TVMatrixRotationX(ref rotMatrixX, 0.00F);
                        mComponents.pMathLibrary.TVMatrixRotationY(ref rotMatrixY, 0.00F);
                    }
                    mComponents.pMathLibrary.TVMatrixMultiply(ref rotMatrix1, rotMatrixX, rotMatrixY);
                    mComponents.pMathLibrary.TVMatrixMultiply(ref rotMatrix1, rotMatrix2, rotMatrix1);
                    rotMatrix2 = rotMatrix1;
                    mComponents.pMathLibrary.TVMatrixMultiply(ref retMatrix3, retMatrix1, rotMatrix1);
                    mComponents.pMathLibrary.TVMatrixMultiply(ref finalMatrix, retMatrix3, retMatrix2);
                    mComponents.pMathLibrary.TVMatrixMultiply(ref finalMatrix, finalMatrix, retMatrix4);
                    mComponents.pActor.SetMatrix(finalMatrix);
                }
            }
        }

        public static void AddLight()
        {
            if (!(!bMeshOpen & !bActorOpen))
            {
                int activeCount = mComponents.pLightEngine.GetActiveCount();
                Random random = new Random();
                mComponents.arrayTV_LIGHT = (TV_LIGHT[])Utils.CopyArray((Array)mComponents.arrayTV_LIGHT, new TV_LIGHT[activeCount + 1]);
                mComponents.arrayTV_LIGHT[activeCount] = new TV_LIGHT();
                mComponents.arrayTV_LIGHT[activeCount].type =  CONST_TV_LIGHTTYPE.TV_LIGHT_DIRECTIONAL ;
                mComponents.arrayTV_LIGHT[activeCount].specular = mComponents.pG.TVColor(1f, 1f, 1f, 1f);
                mComponents.arrayTV_LIGHT[activeCount].ambient = mComponents.pG.TVColor(0.4f, 0.4f, 0.4f, 0.8f);
                mComponents.arrayTV_LIGHT[activeCount].range = mComponents.fRadius * 10f;
                mComponents.arrayTV_LIGHT[activeCount].attenuation = mComponents.pG.Vector(0f, (1f / mComponents.arrayTV_LIGHT[activeCount].range) * 10f, 0f);
                mComponents.arrayTV_LIGHT[activeCount].diffuse.r = (float)random.NextDouble();
                mComponents.arrayTV_LIGHT[activeCount].diffuse.g = (float)random.NextDouble();
                mComponents.arrayTV_LIGHT[activeCount].diffuse.b = (float)random.NextDouble();
                mComponents.arrayTV_LIGHT[activeCount].diffuse.a = 1f;
                mComponents.arrayTV_LIGHT[activeCount].direction = mComponents.pG.Vector(0f, -0.5f, 1f);
                mComponents.arrayTV_LIGHT[activeCount].position.x = (float)((mComponents.fRadius * random.NextDouble()) * random.Next(-1, 2));
                mComponents.arrayTV_LIGHT[activeCount].position.y = (float)(mComponents.fRadius * (1.3 + random.NextDouble()));
                mComponents.arrayTV_LIGHT[activeCount].position.z = (float)((mComponents.fRadius * random.NextDouble()) * random.Next(-1, 2));
                mComponents.arrayCLightProperties = (cLightProperties[])Utils.CopyArray((Array)mComponents.arrayCLightProperties, new cLightProperties[activeCount + 1]);
                mComponents.arrayCLightProperties[activeCount] = new cLightProperties();
                mComponents.arrayCLightProperties[activeCount].iLightIndex = mComponents.pLightEngine.CreateLight(ref mComponents.arrayTV_LIGHT[activeCount], "");
                mComponents.arrayCLightProperties[activeCount].UpdateLight();
                mComponents.arrayLightMesh = (TVMesh[])Utils.CopyArray((Array)mComponents.arrayLightMesh, new TVMesh[activeCount + 1]);
                mComponents.arrayLightMesh[activeCount] = mComponents.pScene.CreateBillboard(mComponents.pG.GetTex("LightGlow"), mComponents.arrayTV_LIGHT[activeCount].position.x, mComponents.arrayTV_LIGHT[activeCount].position.y, mComponents.arrayTV_LIGHT[activeCount].position.z, -1f, -1f, StringType.FromInteger(activeCount), true);
                mComponents.arrayLightMesh[activeCount].SetScale((float)(mComponents.fRadius * 0.2), (float)(mComponents.fRadius * 0.2), (float)(mComponents.fRadius * 0.2));
                mComponents.arrayLightMesh[activeCount].SetBillboardType(0);
                mComponents.arrayLightMesh[activeCount].SetBlendingMode(CONST_TV_BLENDINGMODE.TV_BLEND_NO); // todo: Hypnotron yes?
                mComponents.arrayLightMesh[activeCount].SetLightingMode( CONST_TV_LIGHTINGMODE.TV_LIGHTING_MANAGED);
                mComponents.arrayLightMesh[activeCount].SetColor(mComponents.pG.RGBA(mComponents.arrayTV_LIGHT[activeCount].diffuse.r, mComponents.arrayTV_LIGHT[activeCount].diffuse.g, mComponents.arrayTV_LIGHT[activeCount].diffuse.b, mComponents.arrayTV_LIGHT[activeCount].diffuse.a), false);
                mComponents.pFrmMain._comboLights.Items.Add("New Light ");
                mComponents.arrayCLightProperties[activeCount].iComboIndex = activeCount;
                mComponents.pFrmMain._comboLights.SelectedIndex = activeCount;
                mComponents.pFrmMain._propertiesLights.SelectedObject = mComponents.arrayCLightProperties[activeCount];
            }

        }

        // todo: rewrite using List<> instead of arrays
        public static void DeleteLight()
        {
            //int activeCount = mComponents.pLightEngine.GetActiveCount();
            //int num5 = activeCount - 1;
            //for (int i = 0; i <= num5; i++)
            //{
            //    if (mComponents.arrayCLightProperties[i].iComboIndex == mComponents.pFrmMain.comboLights.SelectedIndex)
            //    {
            //        mComponents.pLightEngine.DeleteLight(mComponents.arrayCLightProperties[i].iLightIndex);
            //        mComponents.arrayTV_LIGHT[i] = null;
            //        mComponents.arrayCLightProperties[i] = null;
            //        mComponents.arrayLightMesh[i] = null;
            //        int num4 = activeCount - 1;
            //        for (int j = i; j <= num4; j++)
            //        {
            //            if (j != (activeCount - 1))
            //            {
            //                mComponents.arrayTV_LIGHT[j] = mComponents.arrayTV_LIGHT[j + 1];
            //                mComponents.arrayCLightProperties[j] = mComponents.arrayCLightProperties[j + 1];
            //                mComponents.arrayCLightProperties[j].iComboIndex--;
            //                mComponents.arrayLightMesh[j] = mComponents.arrayLightMesh[j + 1];
            //                mComponents.arrayLightMesh[j].SetMeshName(StringType.FromInteger(j));
            //            }
            //            else
            //            {
            //                mComponents.arrayTV_LIGHT[j] = null;
            //                mComponents.arrayTV_LIGHT = (TV_LIGHT[])Utils.CopyArray((Array)mComponents.arrayTV_LIGHT, new TV_LIGHT[(j - 1) + 1]);
            //                mComponents.arrayCLightProperties[j] = null;
            //                mComponents.arrayCLightProperties = (cLightProperties[])Utils.CopyArray((Array)mComponents.arrayCLightProperties, new cLightProperties[(j - 1) + 1]);
            //                mComponents.arrayLightMesh[j] = null;
            //                mComponents.arrayLightMesh = (TVMesh[])Utils.CopyArray((Array)mComponents.arrayLightMesh, new TVMesh[(j - 1) + 1]);
            //            }
            //        }
            //        break;
            //    }
            //}

        }
    }
}
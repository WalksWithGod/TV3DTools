#region

using System.ComponentModel;
using MTV3D65;

#endregion

namespace ModelView
{
    public class cLightProperties
    {
        // Instance Fields
        internal CONST_TV_LIGHTTYPE eType;
        internal TV_COLOR eAmbient;
        internal TV_COLOR eDiffuse;
        internal TV_3DVECTOR vAttenuation;
        internal TV_3DVECTOR vPosition;
        internal TV_3DVECTOR vDirection;
        internal float fPhi;
        internal float fTheta;
        internal float fRange;
        internal TV_COLOR eSpecular;
        internal bool bEnable;
        internal string sLocalName;
        internal int iLightIndex;
        internal int iComboIndex;

        // Constructors
        public cLightProperties()
        {
            eType = CONST_TV_LIGHTTYPE.TV_LIGHT_DIRECTIONAL;
            eAmbient = mComponents.pG.TVColor(0.40F, 0.40F, 0.40F, 0.80F);
            eDiffuse = mComponents.pG.TVColor(1.00F, 1.00F, 1.00F, 1.00F);
            vAttenuation = mComponents.pG.Vector(0.00F, 0.01F, 0.00F);
            vPosition = mComponents.pG.Vector(0.00F, 0.00F, 0.00F);
            vDirection = mComponents.pG.Vector(0.00F, -0.50F, 1.00F);
            fPhi = 0.00F;
            fTheta = 0.00F;
            fRange = 100.00F;
            eSpecular = mComponents.pG.TVColor(1.00F, 1.00F, 1.00F, 1.00F);
            bEnable = true;
            sLocalName = "New Light";
        }


        // Methods
        public void UpdateLight()
        {
            eType = mComponents.arrayTV_LIGHT[iLightIndex].type;
            eAmbient = mComponents.arrayTV_LIGHT[iLightIndex].ambient;
            eDiffuse = mComponents.arrayTV_LIGHT[iLightIndex].diffuse;
            vAttenuation = mComponents.arrayTV_LIGHT[iLightIndex].attenuation;
            vPosition = mComponents.arrayTV_LIGHT[iLightIndex].position;
            vDirection = mComponents.arrayTV_LIGHT[iLightIndex].direction;
            fPhi = mComponents.arrayTV_LIGHT[iLightIndex].phi;
            fTheta = mComponents.arrayTV_LIGHT[iLightIndex].theta;
            fRange = mComponents.arrayTV_LIGHT[iLightIndex].range;
            eSpecular = mComponents.arrayTV_LIGHT[iLightIndex].specular;
        }


        // Properties
        [Browsable(true), Category("Rendering"), ReadOnly(false), DesignOnly(false)]
        public CONST_TV_LIGHTTYPE Type
        {
            get { return eType; }
            set
            {
                eType = value;
                mComponents.arrayTV_LIGHT[iComboIndex].type = value;
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [Browsable(true), DesignOnly(false), Category("Ambient"), ReadOnly(false)]
        public float AmbientRed
        {
            get { return eAmbient.r; }
            set
            {
                eAmbient.r = value;
                mComponents.arrayTV_LIGHT[iComboIndex].ambient.r = value;
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [Browsable(true), Category("Ambient"), ReadOnly(false), DesignOnly(false)]
        public float AmbientGreen
        {
            get { return eAmbient.g; }
            set
            {
                eAmbient.g = value;
                mComponents.arrayTV_LIGHT[iComboIndex].ambient.g = value;
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [ReadOnly(false), Category("Ambient"), DesignOnly(false), Browsable(true)]
        public float AmbientBlue
        {
            get { return eAmbient.b; }
            set
            {
                eAmbient.b = value;
                mComponents.arrayTV_LIGHT[iComboIndex].ambient.b = value;
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [Category("Ambient"), DesignOnly(false), ReadOnly(false), Browsable(true)]
        public float AmbientAlpha
        {
            get { return eAmbient.a; }
            set
            {
                eAmbient.a = value;
                mComponents.arrayTV_LIGHT[iComboIndex].ambient.a = value;
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [ReadOnly(false), Category("Diffuse"), DesignOnly(false), Browsable(true)]
        public float DiffuseRed
        {
            get { return eDiffuse.r; }
            set
            {
                eDiffuse.r = value;
                mComponents.arrayTV_LIGHT[iComboIndex].diffuse.r = value;
                mComponents.arrayLightMesh[iComboIndex].SetColor(
                    mComponents.pG.RGBA(eDiffuse.r, eDiffuse.g, eDiffuse.b, eDiffuse.a), false);
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [ReadOnly(false), Category("Diffuse"), Browsable(true), DesignOnly(false)]
        public float DiffuseGreen
        {
            get { return eDiffuse.g; }
            set
            {
                eDiffuse.g = value;
                mComponents.arrayTV_LIGHT[iComboIndex].diffuse.g = value;
                mComponents.arrayLightMesh[iComboIndex].SetColor(
                    mComponents.pG.RGBA(eDiffuse.r, eDiffuse.g, eDiffuse.b, eDiffuse.a), false);
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [ReadOnly(false), DesignOnly(false), Category("Diffuse"), Browsable(true)]
        public float DiffuseBlue
        {
            get { return eDiffuse.b; }
            set
            {
                eDiffuse.b = value;
                mComponents.arrayTV_LIGHT[iComboIndex].diffuse.b = value;
                mComponents.arrayLightMesh[iComboIndex].SetColor(
                    mComponents.pG.RGBA(eDiffuse.r, eDiffuse.g, eDiffuse.b, eDiffuse.a), false);
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [DesignOnly(false), Category("Diffuse"), ReadOnly(false), Browsable(true)]
        public float DiffuseAlpha
        {
            get { return eDiffuse.a; }
            set
            {
                eDiffuse.a = value;
                mComponents.arrayTV_LIGHT[iComboIndex].diffuse.a = value;
                mComponents.arrayLightMesh[iComboIndex].SetColor(
                    mComponents.pG.RGBA(eDiffuse.r, eDiffuse.g, eDiffuse.b, eDiffuse.a), false);
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [ReadOnly(false), Category("Specular"), DesignOnly(false), Browsable(true)]
        public float SpecularRed
        {
            get { return eSpecular.r; }
            set
            {
                eSpecular.r = value;
                mComponents.arrayTV_LIGHT[iComboIndex].specular.r = value;
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [Category("Specular"), Browsable(true), DesignOnly(false), ReadOnly(false)]
        public float SpecularGreen
        {
            get { return eSpecular.g; }
            set
            {
                eSpecular.g = value;
                mComponents.arrayTV_LIGHT[iComboIndex].specular.g = value;
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [Browsable(true), Category("Specular"), DesignOnly(false), ReadOnly(false)]
        public float SpecularBlue
        {
            get { return eSpecular.b; }
            set
            {
                eSpecular.b = value;
                mComponents.arrayTV_LIGHT[iComboIndex].specular.b = value;
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [DesignOnly(false), Browsable(true), Category("Specular"), ReadOnly(false)]
        public float SpecularAlpha
        {
            get { return eSpecular.a; }
            set
            {
                eSpecular.a = value;
                mComponents.arrayTV_LIGHT[iComboIndex].specular.a = value;
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [Browsable(true), Category("Attenuation"), DesignOnly(false), ReadOnly(false)]
        public float Att1
        {
            get { return vAttenuation.x; }
            set
            {
                vAttenuation.x = value;
                mComponents.arrayTV_LIGHT[iComboIndex].attenuation.x = value;
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [Category("Attenuation"), Browsable(true), DesignOnly(false), ReadOnly(false)]
        public float Att2
        {
            get { return vAttenuation.y; }
            set
            {
                vAttenuation.y = value;
                mComponents.arrayTV_LIGHT[iComboIndex].attenuation.y = value;
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [DesignOnly(false), Browsable(true), Category("Attenuation"), ReadOnly(false)]
        public float Att3
        {
            get { return vAttenuation.z; }
            set
            {
                vAttenuation.z = value;
                mComponents.arrayTV_LIGHT[iComboIndex].attenuation.z = value;
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [Category("Position"), Browsable(true), ReadOnly(false), DesignOnly(false)]
        public float PositionX
        {
            get { return vPosition.x; }
            set
            {
                vPosition.x = value;
                mComponents.arrayTV_LIGHT[iComboIndex].position.x = value;
                mComponents.arrayLightMesh[iComboIndex].SetPosition(vPosition.x, vPosition.y,
                                                                         vPosition.z);
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [ReadOnly(false), DesignOnly(false), Category("Position"), Browsable(true)]
        public float PositionY
        {
            get { return vPosition.y; }
            set
            {
                vPosition.y = value;
                mComponents.arrayTV_LIGHT[iComboIndex].position.y = value;
                mComponents.arrayLightMesh[iComboIndex].SetPosition(vPosition.x, vPosition.y,
                                                                         vPosition.z);
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [Category("Position"), ReadOnly(false), Browsable(true), DesignOnly(false)]
        public float PositionZ
        {
            get { return vPosition.z; }
            set
            {
                vPosition.z = value;
                mComponents.arrayTV_LIGHT[iComboIndex].position.z = value;
                mComponents.arrayLightMesh[iComboIndex].SetPosition(vPosition.x, vPosition.y,
                                                                         vPosition.z);
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [Browsable(true), ReadOnly(false), Category("Direction"), DesignOnly(false)]
        public float DirectionX
        {
            get { return vDirection.x; }
            set
            {
                vDirection.x = value;
                mComponents.arrayTV_LIGHT[iComboIndex].direction.x = value;
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [Category("Direction"), DesignOnly(false), ReadOnly(false), Browsable(true)]
        public float DirectionY
        {
            get { return vDirection.y; }
            set
            {
                vDirection.y = value;
                mComponents.arrayTV_LIGHT[iComboIndex].direction.y = value;
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [Category("Direction"), DesignOnly(false), ReadOnly(false), Browsable(true)]
        public float DirectionZ
        {
            get { return vDirection.z; }
            set
            {
                vDirection.z = value;
                mComponents.arrayTV_LIGHT[iComboIndex].direction.z = value;
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [Category("SpotAngles"), DesignOnly(false), ReadOnly(false), Browsable(true)]
        public float Phi
        {
            get { return fPhi; }
            set
            {
                fPhi = value;
                mComponents.arrayTV_LIGHT[iComboIndex].phi = value;
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [DesignOnly(false), ReadOnly(false), Category("SpotAngles"), Browsable(true)]
        public float Theta
        {
            get { return fTheta; }
            set
            {
                fTheta = value;
                mComponents.arrayTV_LIGHT[iComboIndex].theta = value;
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [ReadOnly(false), Browsable(true), Category("Rendering"), DesignOnly(false)]
        public float Range
        {
            get { return fRange; }
            set
            {
                fRange = value;
                mComponents.arrayTV_LIGHT[iComboIndex].range = value;
                mComponents.pLightEngine.SetLight(iLightIndex, ref mComponents.arrayTV_LIGHT[iComboIndex]);
            }
        }

        [Browsable(true), DesignOnly(false), Category("Rendering"), ReadOnly(false)]
        public bool Enable
        {
            get { return bEnable; }
            set
            {
                bEnable = value;
                mComponents.pLightEngine.EnableLight(iLightIndex, value);
            }
        }

        [Browsable(true), ReadOnly(true), Category("Rendering"), DesignOnly(false)]
        public int Index
        {
            get { return iLightIndex; }
            set { iLightIndex = value; }
        }

        [Category("Rendering"), DesignOnly(false), ReadOnly(false), Browsable(true)]
        public string Name
        {
            get { return sLocalName; }
            set
            {
                sLocalName = value;
                mComponents.pFrmMain._comboLights.Items[iComboIndex] = value;
            }
        }

        [DesignOnly(false), ReadOnly(true), Category("LightMesh"), Browsable(true)]
        public string MeshName
        {
            get { return mComponents.arrayLightMesh[iComboIndex].GetMeshName(); }
        }
    }
}
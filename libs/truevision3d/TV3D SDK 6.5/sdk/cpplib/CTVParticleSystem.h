#pragma once
#include "tv_types.h"
#include "CTVMiniMesh.h"

class EXPORTCLASS CTVParticleSystem
{
public:
	int iParticleSystemIndex;

	bool LoadFromScript(char* sDataSource);
	bool Load(char* sBinaryDataSource);
	bool Save(char* sBinaryDataPlace, bool bSaveTextures = true);
	
	int GetEmitterCount();
	int GetAttractorCount();
	
	int GetGlobalParticleCount();
	int GetEmitterParticleCount(int iEmitter);

	int CreateEmitter(cCONST_TV_EMITTERTYPE eEmitterType = cTV_EMITTER_POINTSPRITE, int iMaxParticles = 64);
	
	void SetBillboard(int iEmitter, int iTexture, float fDefaultWidth = 1.0f, float fDefaultHeight = 1.0f);
	void SetBillboardShader(int iEmitter, CTVShader* pShader);
	void SetMiniMesh(int iEmitter, CTVMiniMesh* pMiniMesh);
	void SetPointSprite(int iEmitter, int iTexture, float fDefaultSize = 32); 
	
	void SetEmitterShape(int iEmitter, cCONST_TV_EMITTERSHAPE eShape = cTV_EMITTERSHAPE_POINT);
	void SetEmitterBoxSize(int iEmitter, cTV_3DVECTOR* bSize);
	void SetEmitterSphereRadius(int iEmitter, float fRadius );
	void SetEmitterDirection(int iEmitter, bool bEnableMainDirection, cTV_3DVECTOR* vMainDirection, cTV_3DVECTOR* vRandomDirectionFactor);

	void SetEmitterPower(int iEmitter, float fPower, float fParticleLifeTime);
	void SetEmitterSpeed(int iEmitter, float fGenerationSpeedMS);

	void SetEmitterKeyFrames(int iEmitter, int eEmitterKeyUsage, int iNumKeyFrames, cTV_PARTICLEEMITTER_KEYFRAME* pFirstKeyFrameArray);
	void SetParticleKeyFrames(int iEmitter, int eParticleKeyUsage, int iNumKeyFrames, cTV_PARTICLE_KEYFRAME* pFirstKeyFrameArray);
 
	void SetEmitterAlphaBlending(int iEmitter, cCONST_TV_PARTICLECHANGE eChange = cTV_CHANGE_ALPHA, cCONST_TV_BLENDINGMODE eBlending = cTV_BLEND_ALPHA );
	void SetEmitterAlphaTest(int iEmitter, bool bAlphaTest, int iAlphaRef = 8, bool bDepthWrite = false);
	void MoveEmitter(int iEmitter, cTV_3DVECTOR* vEmitterPosition);
	void SetEmitterMatrix(int iEmitter, cTV_3DMATRIX* mMatrix);

	void SetParticleDefaultColor(int iEmitter, cTV_COLOR* cColor);
	void SetEmitterGravity(int iEmitter, bool bUseGravity, cTV_3DVECTOR* vGravityVector);
 

	void Update();
	void Render(); 

	// attractor support.
	int CreateAttractor(bool bDirectionalField = false);
	void SetAttractorFieldDirection(int iAttractor, cTV_3DVECTOR* vDirection);
	void SetAttractorParameters(int iAttractor, float fAttractionRepulsionConstant, cCONST_TV_ATTRACTORVELOCITYPOWER eVelocityDependency = cTV_ATTRACTORPOWER_CONSTANT);
	void SetAttractorAttenuation(int iAttractor, cTV_3DVECTOR* vAttenuationVector);
	void SetAttractorEnable(int iAttractor, bool bEnable);
	void SetAttractorPosition(int iAttractor, cTV_3DVECTOR* vAttractorPosition);
	void SetAttractorRadius(int iAttractor, float fRadius);
	void Destroy();

	void AttachTo(int iEmitter, cCONST_TV_NODETYPE eObjectType, int iObjectIndex, int iSubIndex, bool bKeepMatrix = true);
	void SetParent(int iEmitter, cCONST_TV_NODETYPE eObjectType, int iObjectIndex, int iSubIndex);
	void SetParentEx(int iEmitter, cCONST_TV_NODETYPE eObjectType, int iObjectIndex, int iSubIndex, float fTranslationOffsetX = 0.0f, float fTranslationOffsetY = 0.0f, float fTranslationOffsetZ = 0.0f, float fRotationOffsetX = 0.0f, float fRotationOffsetY = 0.0f, float fRotationOffsetZ = 0.0f);
    void SetEmitterPosition(int iEmitter, cTV_3DVECTOR* vPosition);
	void SetEmitterEnable(int iEmitter, bool bEnable);
	void DestroyEmitter(int iEmitterIndex);
	void DestroyAttractor(int iAttractor);
	void SetEmitterLooping(int iEmitter, bool bLooping);
	void ResetEmitter(int iEmitter);
	void ResetAll();
	cTV_3DVECTOR GetEmitterPosition(int iEmitter);
	cTV_3DVECTOR GetEmitterDirection(int iEmitter); 

	void UpdateEx(int iEmitter, float fTimeSeconds);
	void PreGenerate(int iEmitter,int iNumParticles);
	void SetEmitterDirectionCubeMask(int iEmitter,bool bEnableCubeTextureMask, int iCubeTextureMask);
	cTV_3DVECTOR GetAttractorPosition(int iAttractor);
	cTV_3DVECTOR GetAttractorAttenuation(int iAttractor);
	float GetAttractorRadius(int iAttractor);

	cTV_COLOR GetEmitterDefaultColor(int iEmitter);
	cCONST_TV_EMITTERTYPE GetEmitterType(int iEmitter);
	cTV_2DVECTOR GetEmitterDefaultBillboardSize(int iEmitter);
	void SetEmitterDirectionRandomFactor(int iEmitter, cTV_3DVECTOR* vRandomDirectionFactor);

	void SetGlobalPosition(float fX, float fY, float fZ);
	void SetGlobalRotation(float fAngleX, float fAngleY, float fAngleZ);
	void SetGlobalMatrix(cTV_3DMATRIX* mMatrix);
	cTV_3DVECTOR GetGlobalPosition();
	cTV_3DMATRIX GetGlobalMatrix();

	bool GetParent(int iEmitter, int* retNodeType, int* retObjectIndex, int* retSubIndex);
	int GetEmitterTexture(int iEmitter);
	CTVShader* GetBillboardShader(int iEmitter);

	char* GetName();
	void SetName(const char* sNewName);

	CTVParticleSystem* Duplicate(char* sNewName= NULL);


	CTVParticleSystem(void);
	~CTVParticleSystem(void);
};

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;
using System;
using System.ComponentModel;

namespace ParticleEditor
{
	[TypeConverter(typeof(cQuaternionConverter))]
	public class cQuaternion
	{

        // Instance Fields
        private float _Yaw;
        private float _Pitch;
        private float _Roll;

		// Constructors
		public cQuaternion ()
		{
		}
		
		public cQuaternion (string sQuaternion)
		{
			try
			{
				string[] textArray1 = Strings.Split(sQuaternion, "/", -1, 0);
				if (!Information.IsNothing(textArray1))
				{
					this._Yaw = SingleType.FromString(textArray1[0]);
					this._Pitch = SingleType.FromString(textArray1[1]);
					this._Roll = SingleType.FromString(textArray1[2]);
				    return;
				}
			}
			catch (Exception exception2) 
			{
	            this._Yaw = 0.00F;
				this._Pitch = 0.00F;
				this._Roll = 0.00F;
			
			}
		}
		
		public cQuaternion (TV_3DQUATERNION tQuat)
		{
		}
		
		
		// Methods
		public TV_3DQUATERNION ToTVQuaternion ()
		{
		    TV_3DQUATERNION tv_dquaternion2 = new TV_3DQUATERNION( );
			modMain.oMath.TVQuaternionRotationYawPitchRoll(ref tv_dquaternion2, this._Yaw, this._Pitch, this._Roll);
			return tv_dquaternion2;
		}
		
		public override string ToString ()
		{
			return string.Concat(new string[]{StringType.FromSingle(this._Yaw), "/", StringType.FromSingle(this._Pitch), "/", StringType.FromSingle(this._Roll)});
		}
		
		
		// Properties
		[PropertyOrder(1), Description(null)]
		public float Yaw
		{
			get
			{
				return this._Yaw;
			}
			set
			{
				this._Yaw = value;
			}
		}
		
		[Description(null), PropertyOrder(2)]
		public float Pitch
		{
			get
			{
				return this._Pitch;
			}
			set
			{
                this._Pitch = value;
			}
		}
		
		[Description(null), PropertyOrder(3)]
		public float Roll
		{
			get
			{
				return this._Roll;
			}
			set
			{
                this._Roll = value;
			}
		}
	}
}

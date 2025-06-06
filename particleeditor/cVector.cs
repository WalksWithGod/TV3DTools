using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;
using System;
using System.ComponentModel;

namespace ParticleEditor
{
	[TypeConverter(typeof(cVectorConverter))]
	public class cVector
	{

        // Instance Fields
        private TV_3DVECTOR _Vector;

		// Constructors
		public cVector ()
		{
			this._Vector = new TV_3DVECTOR();
		}
		
		public cVector (string sVector)
		{
			int num1;
			int num2;
            try
            {
                string[] textArray1 = Strings.Split(sVector, "/", -1, 0);
                if (!Information.IsNothing(textArray1))
                {
                    this._Vector.x = SingleType.FromString(textArray1[0]);
                    this._Vector.y = SingleType.FromString(textArray1[1]);
                    this._Vector.z = SingleType.FromString(textArray1[2]);
                    return;
                }
            }
            catch (Exception ex)
            {
                this._Vector.x = 0.00F;
                this._Vector.y = 0.00F;
                this._Vector.z = 0.00F;
            }
		}
		
		public cVector (TV_3DVECTOR tVector)
		{
			this._Vector = new TV_3DVECTOR();
			this._Vector.x = tVector.x;
			this._Vector.y = tVector.y;
			this._Vector.z = tVector.z;
		}
		
		
		// Methods
		public TV_3DVECTOR ToTVVector ()
		{
			TV_3DVECTOR tv_dvector2;
			tv_dvector2.x = this._Vector.x;
			tv_dvector2.y = this._Vector.y;
			tv_dvector2.z = this._Vector.z;
			return tv_dvector2;
		}
		
		public override string ToString ()
		{
			return string.Concat(new string[]{StringType.FromSingle(this._Vector.x), "/", StringType.FromSingle(this._Vector.y), "/", StringType.FromSingle(this._Vector.z)});
		}
		
		
		// Properties
		[Description("x coordinate of vector")]
		public float x
		{
			get
			{
				return this._Vector.x;
			}
			set
			{
				this._Vector.x = value;
			}
		}
		
		[Description("y coordinate of vector")]
		public float y
		{
			get
			{
				return this._Vector.y;
			}
			set
			{
                this._Vector.y = value;
			}
		}
		
		[Description("z coordinate of vector")]
		public float z
		{
			get
			{
				return this._Vector.z;
			}
			set
			{
                this._Vector.z = value;
			}
		}
	}
}

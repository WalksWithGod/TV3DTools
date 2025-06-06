using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace ParticleEditor
{
	public class cVectorConverter : ExpandableObjectConverter
	{
		// Constructors
		public cVectorConverter ()
		{
		}
		
		
		// Methods
		public override bool CanConvertTo (ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(cVector))
			{
				return true;
			}
			return base.CanConvertFrom(context, destinationType);
		}
		
		public override bool CanConvertFrom (ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
			{
				return true;
			}
			if (sourceType == typeof(TV_3DVECTOR))
			{
				return true;
			}
			return base.CanConvertFrom(context, sourceType);
		}
		
		public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			try
			{
				if (value is string)
				{
					string[] textArray1 = Strings.Split(StringType.FromObject(value), "/", -1, 0);
					if (Information.IsNothing(textArray1))
					{
						goto Label_0141;
					}
					cVector vector1 = new cVector();
					if (!Information.IsNothing(textArray1[0]))
					{
						vector1.x = SingleType.FromString(textArray1[0]);
					}
					if (!Information.IsNothing(textArray1[1]))
					{
						vector1.y = SingleType.FromString(textArray1[1]);
					}
					if (!Information.IsNothing(textArray1[2]))
					{
						vector1.z = SingleType.FromString(textArray1[2]);
					}
					return vector1;
				}
				if (value is TV_3DVECTOR)
				{
					cVector vector2 = new cVector();
					TV_3DVECTOR tv_dvector1 = (TV_3DVECTOR) (value ?? Activator.CreateInstance(typeof(TV_3DVECTOR)));
					vector2.x = tv_dvector1.x;
					tv_dvector1 = (TV_3DVECTOR) (value ?? Activator.CreateInstance(typeof(TV_3DVECTOR)));
					vector2.y = tv_dvector1.y;
					tv_dvector1 = (TV_3DVECTOR) (value ?? Activator.CreateInstance(typeof(TV_3DVECTOR)));
					vector2.z = tv_dvector1.z;
					return vector2;
				}
			}
			catch (Exception exception2)
			{
				ProjectData.SetProjectError(exception2);
				Exception exception1 = exception2;
				throw new ArgumentException(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("Can not convert '", value), "' to type cVector")));
			}
		Label_0141:
			return base.ConvertFrom(context, culture, RuntimeHelpers.GetObjectValue(value));
		}
		
		public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			TV_3DVECTOR tv_dvector1;
			if (value == null)
			{
			    return null;
			}
			if ((destinationType == typeof(string)) & (value is cVector))
			{
				cVector vector1 = (cVector) value;
				return string.Concat(new string[]{StringType.FromSingle(vector1.x), "/", StringType.FromSingle(vector1.y), "/", StringType.FromSingle(vector1.z)});
			}
			if (!((destinationType == typeof(TV_3DVECTOR)) & (value is cVector)))
			{
				return base.ConvertTo(context, culture, RuntimeHelpers.GetObjectValue(value), destinationType);
			}
			cVector vector2 = (cVector) value;
			TV_3DVECTOR tv_dvector2 = (TV_3DVECTOR) (value ?? Activator.CreateInstance(typeof(TV_3DVECTOR)));
			tv_dvector1.x = tv_dvector2.x;
			tv_dvector2 = (TV_3DVECTOR) (value ?? Activator.CreateInstance(typeof(TV_3DVECTOR)));
			tv_dvector1.y = tv_dvector2.y;
			tv_dvector2 = (TV_3DVECTOR) (value ?? Activator.CreateInstance(typeof(TV_3DVECTOR)));
			tv_dvector1.z = tv_dvector2.z;
			return tv_dvector1;
		}
		
	}
}

using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace ParticleEditor
{
	public class cQuaternionConverter : PropSorter
	{
		// Constructors
		public cQuaternionConverter ()
		{
		}
		
		
		// Methods
		public override bool CanConvertTo (ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(cQuaternion))
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
			if (sourceType == typeof(TV_3DQUATERNION))
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
					return new cQuaternion(StringType.FromObject(value));
				}
			}
			catch (Exception exception2)
			{
				ProjectData.SetProjectError(exception2);
				Exception exception1 = exception2;
				throw new ArgumentException(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("Can not convert '", value), "' to type cQuaternion")));
			}
			return base.ConvertFrom(context, culture, RuntimeHelpers.GetObjectValue(value));
		}
		
		public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (value == null)
			{
				return null;
			}

			if ((destinationType == typeof(string)) & (value is cVector))
			{
				cQuaternion quaternion1 = (cQuaternion) value;
				return string.Concat(new string[]{StringType.FromSingle(quaternion1.Yaw), "/", StringType.FromSingle(quaternion1.Pitch), "/", StringType.FromSingle(quaternion1.Roll)});
			}
			return base.ConvertTo(context, culture, RuntimeHelpers.GetObjectValue(value), destinationType);
		}
		
	}
}

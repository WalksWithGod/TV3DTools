using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace ParticleEditor
{
	public class cColorConverter : PropSorter
	{
		// Constructors
		public cColorConverter ()
		{
		}
		
		
		// Methods
		public override bool CanConvertTo (ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(cColor))
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
			if (sourceType == typeof(TV_COLOR))
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
					string[] textArray1 = Strings.Split(StringType.FromObject(value), ",", -1, 0);
					if (Information.IsNothing(textArray1))
					{
						goto Label_0189;
					}
					cColor color1 = new cColor();
					if (!Information.IsNothing(textArray1[0]))
					{
						color1.r = SingleType.FromString(textArray1[0]);
					}
					if (!Information.IsNothing(textArray1[1]))
					{
						color1.g = SingleType.FromString(textArray1[1]);
					}
					if (!Information.IsNothing(textArray1[2]))
					{
						color1.b = SingleType.FromString(textArray1[2]);
					}
					if (!Information.IsNothing(textArray1[3]))
					{
						color1.a = SingleType.FromString(textArray1[3]);
					}
					return color1;
				}
				if (value is TV_COLOR)
				{
					cColor color2 = new cColor();
					TV_COLOR tv_color1 = (TV_COLOR) (value ?? Activator.CreateInstance(typeof(TV_COLOR)));
					color2.r = tv_color1.r;
					tv_color1 = (TV_COLOR) (value ?? Activator.CreateInstance(typeof(TV_COLOR)));
					color2.g = tv_color1.g;
					tv_color1 = (TV_COLOR) (value ?? Activator.CreateInstance(typeof(TV_COLOR)));
					color2.b = tv_color1.b;
					tv_color1 = (TV_COLOR) (value ?? Activator.CreateInstance(typeof(TV_COLOR)));
					color2.a = tv_color1.a;
					return color2;
				}
			}
			catch (Exception exception2)
			{
				ProjectData.SetProjectError(exception2);
				Exception exception1 = exception2;
				throw new ArgumentException(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("Can not convert '", value), "' to type cColor")));
			}
		Label_0189:
			return base.ConvertFrom(context, culture, RuntimeHelpers.GetObjectValue(value));
		}
		
		public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			TV_COLOR tv_color1;
			if (value == null)
			{
			    return null;
			}
			if ((destinationType == typeof(string)) & (value is cVector))
			{
				cColor color1 = (cColor) value;
				return string.Concat(new string[]{StringType.FromSingle(color1.r), ",", StringType.FromSingle(color1.g), ",", StringType.FromSingle(color1.b), ",", StringType.FromSingle(color1.a)});
			}
			if (!((destinationType == typeof(TV_3DVECTOR)) & (value is cVector)))
			{
				return base.ConvertTo(context, culture, RuntimeHelpers.GetObjectValue(value), destinationType);
			}
			cColor color2 = (cColor) value;
			TV_COLOR tv_color2 = (TV_COLOR) (value ?? Activator.CreateInstance(typeof(TV_COLOR)));
			tv_color1.r = tv_color2.r;
			tv_color2 = (TV_COLOR) (value ?? Activator.CreateInstance(typeof(TV_COLOR)));
			tv_color1.g = tv_color2.g;
			tv_color2 = (TV_COLOR) (value ?? Activator.CreateInstance(typeof(TV_COLOR)));
			tv_color1.b = tv_color2.b;
			tv_color2 = (TV_COLOR) (value ?? Activator.CreateInstance(typeof(TV_COLOR)));
			tv_color1.a = tv_color2.a;
			return tv_color1;
		}
		
	}
}

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;
using System;
using System.ComponentModel;

namespace ParticleEditor
{
	[TypeConverter(typeof(cColorConverter))]
	public class cColor
	{
        // Instance Fields
        private TV_COLOR _Color;

		// Constructors
		public cColor ()
		{
			_Color = new TV_COLOR();
		}
		
		public cColor (string sColor)
		{
			int num1;
			int num2;
			try
			{

				_Color = new TV_COLOR();
				ProjectData.ClearProjectError();
				num2 = 1;
				string[] textArray1 = Strings.Split(sColor, ",", -1, 0);
				if (!Information.IsNothing(textArray1))
				{
					_Color.r = SingleType.FromString(textArray1[0]);
					_Color.g = SingleType.FromString(textArray1[1]);
					_Color.b = SingleType.FromString(textArray1[2]);
					_Color.a = SingleType.FromString(textArray1[3]);
				}
			}
			catch (Exception exception2) 
			{

				_Color.r = 0.00F;
				_Color.g = 0.00F;
				_Color.b = 0.00F;
				_Color.a = 0.00F;
			}
		}
		
		public cColor (TV_COLOR tColor)
		{
			_Color = new TV_COLOR();
			_Color.r = tColor.r;
			_Color.g = tColor.g;
			_Color.b = tColor.b;
			_Color.a = tColor.a;
		}
		
		
		// Methods
		public TV_COLOR ToTVColor ()
		{
			TV_COLOR tv_color1;
			tv_color1.r = _Color.r;
			tv_color1.g = _Color.g;
			tv_color1.b = _Color.b;
			tv_color1.a = _Color.a;
			return tv_color1;
		}
		
		public override string ToString ()
		{
			return string.Concat(new string[]{StringType.FromSingle(_Color.r), ",", StringType.FromSingle(_Color.g), ",", StringType.FromSingle(_Color.b), ",", StringType.FromSingle(this._Color.a)});
		}
		
		
		// Properties
		[PropertyOrder(1), Description("Red portion of color")]
		public float r
		{
			get
			{
				return _Color.r;
			}
			set
			{
				_Color.r = value;
			}
		}
		
		[PropertyOrder(2), Description("Green portion of color")]
		public float g
		{
			get
			{
				return _Color.g;
			}
			set
			{
                _Color.g = value;
			}
		}
		
		[PropertyOrder(3), Description("Blue portion of color")]
		public float b
		{
			get
			{
				return _Color.b;
			}
			set
			{
                _Color.b = value;
			}
		}
		
		[Description("Alpha portion of color"), PropertyOrder(4)]
		public float a
		{
			get
			{
				return _Color.a;
			}
			set
			{
                _Color.a = value;
			}
		}
	}
}

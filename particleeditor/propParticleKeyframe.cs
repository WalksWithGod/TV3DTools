using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Xml;

namespace ParticleEditor
{
	[DefaultProperty("Title")]
	public class propParticleKeyframe
	{
        // Instance Fields
        internal int _ID;
        internal int _Parent;
        internal float _Key;
        internal cVector _Size;
        internal cColor _Color;

		// Constructors
		public propParticleKeyframe ()
		{
			_Size = new cVector();
			_Color = new cColor();
		}
		
		
		// Methods
		public void UpdateXML ()
		{
			if (modMain.fMain._propSystem.SelectedObject == this)
			{
				XmlElement element1 = modParticleKeyframeUtils.GetParticleKeyframeNode(this._Parent, this._ID);
				if (element1 != null)
				{
					element1.SetAttribute("key", StringType.FromSingle(this._Key));
					element1.SetAttribute("size", _Size.ToString());
					element1.SetAttribute("color", _Color.ToString());
				}
				modParticleXML.bNeedsReloading = true;
				modParticleXML.bNeedsSaving = true;
			}
		}
		
		
		// Properties
		[Description("Internal Keyframe ID"), ReadOnly(true), Browsable(true), Category("Internal")]
		public int ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}
		
		[ReadOnly(true), Browsable(true), Category("Internal"), Description("Internal Parent emitter ID")]
		public int Parent
		{
			get
			{
				return _Parent;
			}
			set
			{
				_Parent = value;
			}
		}
		
		[Category("Particle Properties"), Description("The size of the particles this keyframe."), ReadOnly(false), Browsable(true)]
		public cVector Size
		{
			get
			{
				return _Size;
			}
			set
			{
				_Size = value;
			}
		}
		
		[Description("Specifies the color of particles for this keyframe."), Category("Particle Properties"), ReadOnly(false), Browsable(true)]
		public cColor Color
		{
			get
			{
				return _Color;
			}
			set
			{
				_Color = value;
			}
		}
		
		[ReadOnly(false), Browsable(true), Category("Internal"), Description("Time in seconds that this keyframe becomes fully active, it will slowly interpolate from the previous keyframe.")]
		public float KeyFrame
		{
			get
			{
				return _Key;
			}
			set
			{
				_Key = value;
			}
		}
	
	}
}

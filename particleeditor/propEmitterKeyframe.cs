using Microsoft.VisualBasic.CompilerServices;
using System.ComponentModel;
using System.Xml;

namespace ParticleEditor
{
	[DefaultProperty("Title")]
	public class propEmitterKeyframe
	{

        // Instance Fields
        internal int _ID;
        internal int _Parent;
        internal float _Key;
        internal cVector _Location;
        internal cVector _MainDirection;
        internal float _Power;
        internal float _Lifetime;
        internal cVector _BoxSize;
        internal float _SphereRadius;
        internal float _Speed;
        internal cColor _Color;

		// Constructors
		public propEmitterKeyframe ()
		{
			_Location = new cVector();
			_MainDirection = new cVector();
			_Power = 0.00F;
			_Lifetime = 100.00F;
			_BoxSize = new cVector();
			_Color = new cColor();
		}
		
		
		// Methods
		public void UpdateXML ()
		{
			if (modMain.fMain._propSystem.SelectedObject == this)
			{
				XmlElement element1 = modEmitterKeyframeUtils.GetEmitterKeyframeNode(_Parent, _ID);
				if (element1 != null)
				{
					element1.SetAttribute("key", StringType.FromSingle(_Key));
					element1.SetAttribute("location", _Location.ToString());
					element1.SetAttribute("direction", _MainDirection.ToString());
					element1.SetAttribute("power", StringType.FromSingle(_Power));
					element1.SetAttribute("lifetime", StringType.FromSingle(_Lifetime));
					element1.SetAttribute("color", _Color.ToString());
					element1.SetAttribute("speed", StringType.FromSingle(_Speed));
					element1.SetAttribute("boxsize", _BoxSize.ToString());
					element1.SetAttribute("sphereradius", StringType.FromSingle(_SphereRadius));
				}
				modParticleXML.bNeedsReloading = true;
				modParticleXML.bNeedsSaving = true;
			}
		}
		
		
		// Properties
		[Category("Internal"), Description("Internal Keyframe ID"), ReadOnly(true), Browsable(true)]
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
		
		[ReadOnly(true), Category("Internal"), Description("Internal Parent emitter ID"), Browsable(true)]
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
		
		[Description("Specifies the location of this emitter in worldspace"), Browsable(true), ReadOnly(false), Category("Emitter Properties")]
		public cVector Location
		{
			get
			{
				return _Location;
			}
			set
			{
				_Location = value;
			}
		}
		
		[Description("Main direction of particles created from this emitter"), Category("Emitter Direction"), Browsable(true), ReadOnly(false)]
		public cVector MainDirection
		{
			get
			{
				return _MainDirection;
			}
			set
			{
				_MainDirection = value;
			}
		}
		
		[Browsable(true), Category("Emitter Direction"), ReadOnly(false), Description("The initial force applied to particles when created from this emitter.")]
		public float Power
		{
			get
			{
				return _Power;
			}
			set
			{
                _Power = value;
			}
		}
		
		[Category("Particle Properties"), ReadOnly(false), Browsable(true), Description("The amount of time particles will live for this emitter.")]
		public float Lifetime
		{
			get
			{
				return _Lifetime;
			}
			set
			{
                _Lifetime = value;
			}
		}
		
		[Description("The number of milliseconds between the creation of each new particle from this emitter."), ReadOnly(false), Browsable(true), Category("Emitter Properties")]
		public float Speed
		{
			get
			{
				return _Speed;
			}
			set
			{
                _Speed = value;
			}
		}
		
		[Category("Particle Properties"), ReadOnly(false), Browsable(true), Description("Specifies the default color of particles for this emitter.")]
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
		
		[Browsable(true), ReadOnly(false), Category("Emitter Shape"), Description("Box size of this emitter centered on emitter location.")]
		public cVector BoxSize
		{
			get
			{
				return _BoxSize;
			}
			set
			{
                _BoxSize = value;
			}
		}
		
		[Browsable(true), Category("Emitter Shape"), ReadOnly(false), Description("Sphere radius of this emitter centered on emitter location.")]
		public float SphereRadius
		{
			get
			{
				return _SphereRadius;
			}
			set
			{
                _SphereRadius = value;
			}
		}
		
		[Browsable(true), ReadOnly(false), Category("Internal"), Description("Time in seconds that this keyframe becomes fully active, it will slowly interpolate from the previous keyframe.")]
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

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;

namespace ParticleEditor
{
	[DefaultProperty("Title")]
	public class propEmitter
	{
        // Instance Fields
        internal int _ID;
        internal int _MaxParticles;
        internal CONST_TV_EMITTERTYPE _Type;
        internal cVector _Location;
        internal cVector _MainDirection;
        internal bool _Directional;
        internal cVector _RandomDirectionFactor;
        internal float _Power;
        internal float _Lifetime;
        internal CONST_TV_EMITTERSHAPE _Shape;
        internal cVector _BoxSize;
        internal float _SphereRadius;
        internal float _Speed;
        internal string _Texture;
        internal string _TextureName;
        internal cVector _Gravity;
        internal bool _UseGravity;
        internal cColor _Color;
        internal CONST_TV_PARTICLECHANGE _AlphaChange;
        internal CONST_TV_BLENDINGMODE _AlphaBlending;
        internal bool _AlphaTest;
        internal int _AlphaRef;
        internal bool _AlphaDepthWrite;
        internal bool _Looping;

		// Constructors
		public propEmitter ()
		{
			_Location = new cVector();
			_MainDirection = new cVector();
			_Directional = false;
			_RandomDirectionFactor = new cVector();
			_Power = 0.00F;
			_Lifetime = 100.00F;
			_BoxSize = new cVector();
			_Gravity = new cVector();
			_Color = new cColor();
		}
		
		
		// Methods
		public virtual void UpdateXML ()
		{
			if (modMain.fMain._propSystem.SelectedObject == this)
			{
				XmlElement element1 = modemitterUtils.GetEmitterNode(_ID);
				if (element1 != null)
				{
					element1.SetAttribute("location", _Location.ToString());
					element1.SetAttribute("direction", _MainDirection.ToString());
					element1.SetAttribute("directional", _Directional.ToString());
					element1.SetAttribute("randomdirectionfactor", _RandomDirectionFactor.ToString());
					element1.SetAttribute("power", StringType.FromSingle(_Power));
					element1.SetAttribute("lifetime", StringType.FromSingle(_Lifetime));
					element1.SetAttribute("shape", StringType.FromInteger((int) _Shape));
					element1.SetAttribute("texture", _Texture);
					element1.SetAttribute("color", _Color.ToString());
					element1.SetAttribute("speed", StringType.FromSingle(_Speed));
					element1.SetAttribute("max-particles", StringType.FromInteger(_MaxParticles));
					element1.SetAttribute("usegravity", StringType.FromBoolean(_UseGravity));
					element1.SetAttribute("gravity", _Gravity.ToString());
					element1.SetAttribute("alphachange", StringType.FromInteger((int) _AlphaChange));
					element1.SetAttribute("alphablending", StringType.FromInteger((int) _AlphaBlending));
					element1.SetAttribute("alphatest", StringType.FromBoolean(_AlphaTest));
					element1.SetAttribute("alpharef", StringType.FromInteger(_AlphaRef));
					element1.SetAttribute("alphadepthwrite", StringType.FromBoolean(_AlphaDepthWrite));
					element1.SetAttribute("boxsize", _BoxSize.ToString());
					element1.SetAttribute("sphereradius", StringType.FromSingle(_SphereRadius));
					element1.SetAttribute("looping", StringType.FromBoolean(_Looping));
				}
				modParticleXML.bNeedsReloading = true;
				modParticleXML.bNeedsSaving = true;
			}
		}
		
		
		// Properties
		[Description("Internal Emitter ID"), Browsable(true), Category("Internal"), ReadOnly(true)]
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
		
		[Category("Internal"), Browsable(true), ReadOnly(true), Description("Internal Emitter Type")]
		public CONST_TV_EMITTERTYPE Type
		{
			get
			{
				return _Type;
			}
			set
			{
                _Type = value;
			}
		}
		
		[Category("Emitter Properties"), Browsable(true), Description("Maximum number of particles"), ReadOnly(false)]
		public int MaxParticles
		{
			get
			{
				return _MaxParticles;
			}
			set
			{
                _MaxParticles = value;
			}
		}
		
		[ReadOnly(false), Browsable(true), Category("Emitter Properties"), Description("Specifies the location of this emitter in worldspace")]
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
		
		[Category("Emitter Direction"), Description("Main direction of particles created from this emitter"), ReadOnly(false), Browsable(true)]
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
		
		[ReadOnly(false), Browsable(true), Category("Emitter Direction"), Description("Determines if this emitter uses the main direction vector for new particles")]
		public bool Directional
		{
			get
			{
				return _Directional;
			}
			set
			{
                _Directional = value;
			}
		}
		
		[ReadOnly(false), Browsable(true), Category("Emitter Direction"), Description("Random vector factor applied to new particles for this emitter")]
		public cVector RandomDirectionFactor
		{
			get
			{
				return _RandomDirectionFactor;
			}
			set
			{
                _RandomDirectionFactor = value;
			}
		}
		
		[Browsable(true), ReadOnly(false), Description("The initial force applied to particles when created from this emitter."), Category("Emitter Direction")]
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
		
		[Category("Particle Properties"), ReadOnly(false), Description("The amount of time in seconds particles will live for this emitter."), Browsable(true)]
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
		
		[Description("The number of milliseconds between the creation of each new particle from this emitter."), Category("Emitter Properties"), ReadOnly(false), Browsable(true)]
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
		
		[Description("Shape of this emitter for particle generation."), Browsable(true), Category("Emitter Shape"), ReadOnly(false)]
		public CONST_TV_EMITTERSHAPE Shape
		{
			get
			{
				return _Shape;
			}
			set
			{
                _Shape = value;
			}
		}
		
		[Editor(typeof(FileNameEditor), typeof(UITypeEditor)), Description("Texture for particles this emitter generates."), ReadOnly(false), Browsable(true), Category("Particle Properties")]
		public virtual string Texture
		{
			get
			{
				return _Texture;
			}
			set
			{
                value = Strings.Replace(value, Application.StartupPath + @"\", "", 1, -1, 0);
                _Texture = value;
			}
		}
		
		[Browsable(true), Category("Internal"), Description("Internal texture name for particles this emitter generates.  This name is auto-generated from the texture filename that you assign to the emitter."), ReadOnly(true)]
		public string TextureName
		{
			get
			{
				return _TextureName;
			}
		}
		
		[Description("Specifies the default color of particles for this emitter."), ReadOnly(false), Browsable(true), Category("Particle Properties")]
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
		
		[Category("Emitter Gravity"), Description("Gravity vector for this emitters particles."), ReadOnly(false), Browsable(true)]
		public cVector Gravity
		{
			get
			{
				return _Gravity;
			}
			set
			{
                _Gravity = value;
			}
		}
		
		[Category("Emitter Gravity"), ReadOnly(false), Browsable(true), Description("Determines if gravity is applied to this emitters particles.")]
		public bool UseGravity
		{
			get
			{
				return _UseGravity;
			}
			set
			{
                _UseGravity = value;
			}
		}
		
		[ReadOnly(false), Description("Box size of this emitter centered on emitter location."), Category("Emitter Shape"), Browsable(true)]
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
		
		[ReadOnly(false), Browsable(true), Category("Emitter Shape"), Description("Sphere radius of this emitter centered on emitter location.")]
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
		
		[ReadOnly(false), Category("Particle Alpha-Blending"), Description(null), Browsable(true)]
		public CONST_TV_PARTICLECHANGE AlphaChange
		{
			get
			{
				return _AlphaChange;
			}
			set
			{
                _AlphaChange = value;
			}
		}
		
		[Category("Particle Alpha-Blending"), Description(null), ReadOnly(false), Browsable(true)]
		public CONST_TV_BLENDINGMODE AlphaBlending
		{
			get
			{
				return _AlphaBlending;
			}
			set
			{
                _AlphaBlending = value;
			}
		}
		
		[Browsable(true), Description("Determines whether or not to use the AlphaReference value for particle rendering from this emitter."), Category("Particle Alpha-Test"), ReadOnly(false)]
		public bool EnableAlphaTest
		{
			get
			{
				return _AlphaTest;
			}
			set
			{
                _AlphaTest = value;
			}
		}
		
		[ReadOnly(false), Browsable(true), Category("Particle Alpha-Test"), Description("If the particles alpha value falls below this value it will not be rendered.")]
		public float AlphaReference
		{
			get
			{
				return _AlphaRef;
			}
			set
			{
                _AlphaRef = (int)Math.Round(value);
			}
		}
		
		[Category("Particle Alpha-Test"), Description("Determines whether or not this emitter renders to the Z-Buffer or not."), ReadOnly(false), Browsable(true)]
		public bool DepthWrite
		{
			get
			{
				return _AlphaDepthWrite;
			}
			set
			{
                _AlphaDepthWrite = value;
			}
		}
		
		[Description("Determines if this emitter keeps generating particles, or stops once it reaches its maximum"), ReadOnly(false), Browsable(true), Category("Emitter Properties")]
		public bool Looping
		{
			get
			{
				return _Looping;
			}
			set
			{
                _Looping = value;
			}
		}
	}
}

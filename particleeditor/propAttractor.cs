using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;
using System.ComponentModel;
using System.Xml;

namespace ParticleEditor
{
	[DefaultProperty("Title")]
	public class propAttractor
	{

        // Instance Fields
        private int _ID;
        private cVector _Location;
        private cVector _Attenuation;
        private bool _Directional;
        private cVector _FieldDirection;
        private float _RepulsionConst;
        private CONST_TV_ATTRACTORVELOCITYPOWER _VelocityDepend;
        private float _Radius;

		// Constructors
		public propAttractor ()
		{
			_Location = new cVector();
			_Attenuation = new cVector();
			_FieldDirection = new cVector();
		}
		
		
		// Methods
		public void UpdateXML ()
		{
			if (modMain.fMain._propSystem.SelectedObject == this)
			{
				XmlElement element1 = modAttractorUtils.GetAttractorNode(_ID);
				if (element1 != null)
				{
					element1.SetAttribute("location", _Location.ToString());
					element1.SetAttribute("attenuation", _Attenuation.ToString());
					element1.SetAttribute("directional", _Directional.ToString());
					element1.SetAttribute("fielddirection", _FieldDirection.ToString());
					element1.SetAttribute("repulsionconst", StringType.FromSingle(_RepulsionConst));
					element1.SetAttribute("velocitydepend", StringType.FromInteger((int) _VelocityDepend));
					element1.SetAttribute("radius", StringType.FromSingle(_Radius));
				}
				modParticleXML.bNeedsReloading = true;
				modParticleXML.bNeedsSaving = true;
			}
		}
		
		
		// Properties
		[ReadOnly(true), Description("Internal Attractor ID"), Browsable(true), Category("Internal")]
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
		
		[ReadOnly(false), Description("Specifies the location of this attractor in worldspace"), Category("Attractor Properties"), Browsable(true)]
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
		
		[Description("Specifies the attenuation of this attractor"), Category("Attractor Properties"), ReadOnly(false), Browsable(true)]
		public cVector Attenuation
		{
			get
			{
				return _Attenuation;
			}
			set
			{
                _Attenuation = value;
			}
		}
		
		[Category("Attractor Direction Properties"), Description("Specifies the field direction of this attractor"), ReadOnly(false), Browsable(true)]
		public cVector FieldDirection
		{
			get
			{
				return _FieldDirection;
			}
			set
			{
                _FieldDirection = value;
			}
		}
		
		[Browsable(true), Category("Attractor Direction Properties"), Description("Determine if this attractor is directional and uses the FieldDirection property"), ReadOnly(false)]
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
		
		[ReadOnly(false), Description("Specifies the radius of the attractor"), Browsable(true), Category("Attractor Properties")]
		public float Radius
		{
			get
			{
				return _Radius;
			}
			set
			{
                _Radius = value;
			}
		}
		
		[ReadOnly(false), Description("Specifies the repulsion constant of the attractor"), Category("Attractor Properties"), Browsable(true)]
		public float RepulsionConstant
		{
			get
			{
				return _RepulsionConst;
			}
			set
			{
                _RepulsionConst = value;
			}
		}
		
		[ReadOnly(false), Description("Specifies the radius of the attractor"), Browsable(true), Category("Attractor Properties")]
		public CONST_TV_ATTRACTORVELOCITYPOWER VelocityDependency
		{
			get
			{
				return _VelocityDepend;
			}
			set
			{
                _VelocityDepend = value;
			}
		}
	}
}

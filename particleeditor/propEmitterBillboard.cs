using Microsoft.VisualBasic.CompilerServices;
using System.ComponentModel;
using System.Xml;

namespace ParticleEditor
{
	[DefaultProperty("Title")]
	public class propEmitterBillboard : propEmitter
	{
        // Instance Fields
        internal float _Size;

		// Constructors
		public propEmitterBillboard ()
		{
		}
		
		
		// Methods
		public override void UpdateXML ()
		{
			if (modMain.fMain._propSystem.SelectedObject == this)
			{
				XmlElement element1 = modemitterUtils.GetEmitterNode(_ID);
				if (element1 != null)
				{
					element1.SetAttribute("size", StringType.FromSingle(_Size));
				}
				base.UpdateXML();
			}
		}
		
		
		// Properties
		[Category("Emitter Properties"), Browsable(true), Description("Specifies the default size of the billboards created by this emitter"), ReadOnly(false)]
		public float BillboardSize
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
	}
}

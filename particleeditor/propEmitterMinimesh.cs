using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;

namespace ParticleEditor
{
	[DefaultProperty("Title")]
	public class propEmitterMinimesh : propEmitter
	{

        // Instance Fields
        internal string _ModelFile;
        internal string _ModelName;
        internal cVector _Scale;

		// Constructors
		public propEmitterMinimesh ()
		{
			_Scale = new cVector();
		}
		
		
		// Methods
		public override void UpdateXML ()
		{
			if (modMain.fMain._propSystem.SelectedObject == this)
			{
				XmlElement element1 = modemitterUtils.GetEmitterNode(_ID);
				if (element1 != null)
				{
					element1.SetAttribute("modelfile", _ModelFile);
					element1.SetAttribute("scale", _Scale.ToString());
				}
				base.UpdateXML();
			}
		}
		
		
		// Properties
		[Category("Particle Properties"), Description("Specifies the minimesh model created by this emitter"), Browsable(true), Editor(typeof(FileNameEditor), typeof(UITypeEditor)), ReadOnly(false)]
		public string MiniMesh
		{
			get
			{
				return _ModelFile;
			}
			set
			{
				_ModelFile = value;
			}
		}
		
		[Browsable(true), Description("Internal model name for particles this emitter generates.  This name is auto-generated from the model filename that you assign to the emitter."), ReadOnly(true), Category("Internal")]
		public string ModelName
		{
			get
			{
				return _ModelName;
			}
		}
		
		[Description("Texture for the minimesh particles this emitter generates."), Browsable(true), Category("Particle Properties"), ReadOnly(false), Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
		public override string Texture
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
		
		[Browsable(true), Description("Specifies the default scale of the minimesh"), ReadOnly(false), Category("Particle Properties")]
		public cVector Scale
		{
			get
			{
				return _Scale;
			}
			set
			{
                _Scale = value;
			}
		}
	}
}

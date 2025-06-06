using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ParticleEditor
{
	public class frmEmitter : Form
	{
        // Instance Fields
        private Label _Label1;
        private Button _btnOk;
        private TextBox _txtMaxParticles;
        private Label _lblInfo;
        private Button _btnCancel;
        private Label _Label2;
        private RadioButton _radioPointsprite;
        private RadioButton _radioMinimesh;
        private RadioButton _radioBillboard;
        private IContainer components;

		// Constructors
		public frmEmitter ()
		{
			this.InitializeComponent();
		}
		
		// Methods
		protected override void Dispose (bool disposing)
		{
			if (disposing && (this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		
		[DebuggerStepThrough]
		private void InitializeComponent ()
		{
            this.SuspendLayout();
			_btnCancel = new Button();
			_btnOk = new Button();
			_radioPointsprite = new RadioButton();
			_Label1 = new Label();
			_radioMinimesh = new RadioButton();
			_radioBillboard = new RadioButton();
			_Label2 = new Label();
			_txtMaxParticles = new TextBox();
			_lblInfo = new Label();

//			_btnCancel.DialogResult = DialogResult.Cancel;
			_btnCancel.Location = new Point(0xf0, 0xa0);
		//	_btnCancel.Name = "btnCancel";
			_btnCancel.TabIndex = 5;
			_btnCancel.Text = "&Cancel";
			_btnOk.Location = new Point(0x98, 0xa0);
		//	_btnOk.Name = "btnOk";
			_btnOk.TabIndex = 6;
			_btnOk.Text = "&Ok";
			_radioPointsprite.Location = new Point(0x18, 0x18);
		//	_radioPointsprite.Name = "radioPointsprite";
			_radioPointsprite.TabIndex = 1;
			_radioPointsprite.TabStop = true;
			_radioPointsprite.Text = "Point-Sprite";
			_Label1.Location = new Point(0x10, 8);
	//		_Label1.Name = "Label1";
			_Label1.Size = new Size(0x64, 0x10);
			_Label1.TabIndex = 3;
			_Label1.Text = "Emitter Type:";
			_radioMinimesh.Location = new Point(0x18, 0x48);
	//		_radioMinimesh.Name = "radioMinimesh";
			_radioMinimesh.TabIndex = 3;
			_radioMinimesh.TabStop = true;
			_radioMinimesh.Text = "Mini-Mesh";
			_radioBillboard.Location = new Point(0x18, 0x30);
		//	_radioBillboard.Name = "radioBillboard";
			_radioBillboard.TabIndex = 2;
			_radioBillboard.TabStop = true;
			_radioBillboard.Text = "Billboard";
			_Label2.Location = new Point(0x10, 0x68);
			//_Label2.Name = "Label2";
			_Label2.Size = new Size(0x88, 0x17);
			_Label2.TabIndex = 6;
			_Label2.Text = "Max Particles:";
			_txtMaxParticles.Location = new Point(0x10, 0x78);
	//		_txtMaxParticles.Name = "txtMaxParticles";
			_txtMaxParticles.Size = new Size(0x58, 0x14);
			_txtMaxParticles.TabIndex = 4;
			_txtMaxParticles.Text = "64";
			_lblInfo.BorderStyle = BorderStyle.Fixed3D;
			_lblInfo.Location = new Point(0x88, 8);
		//	_lblInfo.Name = "lblInfo";
			_lblInfo.Size = new Size(0xb0, 0x88);
			_lblInfo.TabIndex = 8;
			this.AcceptButton = _btnOk;
			this.AutoScaleBaseSize = new Size(5, 13);
			this.CancelButton = _btnCancel;
			this.ClientSize = new Size(0x142, 0xc2);
			this.Controls.Add(_lblInfo);
			this.Controls.Add(_txtMaxParticles);
			this.Controls.Add(_Label2);
			this.Controls.Add(_radioBillboard);
			this.Controls.Add(_radioMinimesh);
			this.Controls.Add(_Label1);
			this.Controls.Add(_radioPointsprite);
			this.Controls.Add(_btnOk);
			this.Controls.Add(_btnCancel);
//			this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			this.Name = "frmEmitter";
			this.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Add emitter...";
			this.ResumeLayout(false);


            this._btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this._btnOk.Click += new EventHandler(this.btnOk_Click);
            this._txtMaxParticles.GotFocus += new EventHandler(this.txtMaxParticles_GotFocus);
            this._radioPointsprite.CheckedChanged += new EventHandler(this.radioPointsprite_CheckedChanged);
            this._radioMinimesh.CheckedChanged += new EventHandler(this.radioMinimesh_CheckedChanged);
            this._radioBillboard.CheckedChanged += new EventHandler(this.radioBillboard_CheckedChanged);
		}
		
		private void btnCancel_Click (object sender, EventArgs e)
		{
			this.Close();
		}
		
		private void btnOk_Click (object sender, EventArgs e)
		{
			if (!Information.IsNumeric(_txtMaxParticles.Text))
			{
				Interaction.MsgBox("Max Particles has to be a numeric value greater than 0.", 0, null);
			}
			else
			{
				if (IntegerType.FromString(_txtMaxParticles.Text) <= 0)
				{
					Interaction.MsgBox("Max Particles has to be a numeric value greater than 0.", 0, null);
				}
				else if (_radioPointsprite.Checked)
				{
					modemitterUtils.AddEmitter(CONST_TV_EMITTERTYPE.TV_EMITTER_POINTSPRITE, IntegerType.FromString(_txtMaxParticles.Text));
				}
				else if (_radioBillboard.Checked)
				{
					modemitterUtils.AddEmitter(CONST_TV_EMITTERTYPE.TV_EMITTER_BILLBOARD, IntegerType.FromString(_txtMaxParticles.Text));
				}
				else
				{
					if (_radioMinimesh.Checked)
					{
						modemitterUtils.AddEmitter(CONST_TV_EMITTERTYPE.TV_EMITTER_MINIMESH, IntegerType.FromString(_txtMaxParticles.Text));
					}
				}
			}
		}
		
		private void radioPointsprite_CheckedChanged (object sender, EventArgs e)
		{
			_lblInfo.Text = "Point Sprite emitters are very inexpensive for rendering, but their scale is the same size no matter their distance from the camera, making them suitable for only minor effects.";
		}
		
		private void radioBillboard_CheckedChanged (object sender, EventArgs e)
		{
			_lblInfo.Text = "Billboard emitters use the internal TV3D camera-aligned billboard system to create particles scale properly with distance.  This is the most common particle type used.";
		}
		
		private void radioMinimesh_CheckedChanged (object sender, EventArgs e)
		{
			_lblInfo.Text = "Mini-Mesh use the internal TV3D mini-mesh system to create complex particle effects using existing models.";
		}
		
		private void txtMaxParticles_GotFocus (object sender, EventArgs e)
		{
			_lblInfo.Text = "The max particle setting determines the maximum number of particles this emitter will create at any given time.  The lifetime, power, and speed settings will affect the number of particles that actually get rendering during a given pass, however.";
		}
		


		
	}
}

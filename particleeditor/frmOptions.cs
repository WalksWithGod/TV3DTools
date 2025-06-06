using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ParticleEditor
{
	public class frmOptions : Form
	{
        // Instance Fields
        private GroupBox _GroupBox3;
        private GroupBox _GroupBox4;
        private CheckBox _CheckBox2;
        private ComboBox _comboPaths;
        private ComboBox _comboBackgrounds;
        private GroupBox _GroupBox2;
        private RadioButton _RadioButton3;
        private RadioButton _RadioButton2;
        private ColorDialog _dlgColor;
        private RadioButton _RadioButton1;
        private GroupBox _GroupBox1;
        private Label _Label2;
        private Label _Label1;
        private Button _btnChooseColor;
        private PictureBox _picBackground;
        private CheckBox _CheckBox1;
        private Button _btnCancel;
        private Label _Label3;
        private Button _btnOk;
        private IContainer components;

		// Constructors
		public frmOptions ()
		{
			base.Load += new EventHandler(this.frmOptions_Load);
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
			_btnOk = new Button();
			_btnCancel = new Button();
			_GroupBox1 = new GroupBox();
			_Label3 = new Label();
			_Label2 = new Label();
			_Label1 = new Label();
			_RadioButton3 = new RadioButton();
			_RadioButton2 = new RadioButton();
			_RadioButton1 = new RadioButton();
			_GroupBox2 = new GroupBox();
			_picBackground = new PictureBox();
			_btnChooseColor = new Button();
			_comboBackgrounds = new ComboBox();
			_dlgColor = new ColorDialog();
			_GroupBox3 = new GroupBox();
			_CheckBox1 = new CheckBox();
			_GroupBox4 = new GroupBox();
			_comboPaths = new ComboBox();
			_CheckBox2 = new CheckBox();
			_GroupBox1.SuspendLayout();
			_GroupBox2.SuspendLayout();
			_GroupBox3.SuspendLayout();
			_GroupBox4.SuspendLayout();

			_btnOk.Location = new Point(0xa0, 0x1a0);
		//	_btnOk.Name = "btnOk";
			_btnOk.TabIndex = 8;
			_btnOk.Text = "&Ok";
//			_btnCancel.DialogResult = DialogResult.Cancel;
			_btnCancel.Location = new Point(0xf8, 0x1a0);
		//	_btnCancel.Name = "btnCancel";
			_btnCancel.TabIndex = 7;
			_btnCancel.Text = "&Cancel";
			_GroupBox1.Controls.Add(_Label3);
			_GroupBox1.Controls.Add(_Label2);
			_GroupBox1.Controls.Add(_Label1);
			_GroupBox1.Controls.Add(_RadioButton3);
			_GroupBox1.Controls.Add(_RadioButton2);
			_GroupBox1.Controls.Add(_RadioButton1);
			_GroupBox1.FlatStyle = FlatStyle.System;
			_GroupBox1.Location = new Point(8, 0xe8);
		//	_GroupBox1.Name = "GroupBox1";
			_GroupBox1.Size = new Size(0x138, 0x60);
			_GroupBox1.TabIndex = 9;
			_GroupBox1.TabStop = false;
			_GroupBox1.Text = "Debug Mode";
			_Label3.Location = new Point(0x58, 0x40);
		//	_Label3.Name = "Label3";
			_Label3.Size = new Size(0xd8, 0x17);
			_Label3.TabIndex = 5;
			_Label3.Text = "No debug info rendered";
			_Label3.TextAlign = ContentAlignment.MiddleLeft;
			_Label2.Location = new Point(0x58, 0x29);
		//	_Label2.Name = "Label2";
			_Label2.Size = new Size(0xd8, 0x17);
			_Label2.TabIndex = 4;
			_Label2.Text = "No debug info rendered";
			_Label2.TextAlign = ContentAlignment.MiddleLeft;
			_Label1.Location = new Point(0x58, 0x10);
		//	_Label1.Name = "Label1";
			_Label1.Size = new Size(0xd8, 0x17);
			_Label1.TabIndex = 3;
			_Label1.Text = "No debug info rendered";
			_Label1.TextAlign = ContentAlignment.MiddleLeft;
			_RadioButton3.Location = new Point(0x18, 0x40);
		//	_RadioButton3.Name = "RadioButton3";
			_RadioButton3.Size = new Size(0x38, 0x18);
			_RadioButton3.TabIndex = 2;
			_RadioButton3.Text = "Full";
			_RadioButton2.Location = new Point(0x18, 0x28);
		//	_RadioButton2.Name = "RadioButton2";
			_RadioButton2.Size = new Size(0x38, 0x18);
			_RadioButton2.TabIndex = 1;
			_RadioButton2.Text = "Partial";
			_RadioButton1.Location = new Point(0x18, 0x10);
			//_RadioButton1.Name = "RadioButton1";
			_RadioButton1.Size = new Size(0x38, 0x18);
			_RadioButton1.TabIndex = 0;
			_RadioButton1.Text = "Off";
			_GroupBox2.Controls.Add(_picBackground);
			_GroupBox2.Controls.Add(_btnChooseColor);
			_GroupBox2.Controls.Add(_comboBackgrounds);
			_GroupBox2.FlatStyle = FlatStyle.System;
			_GroupBox2.Location = new Point(8, 0x70);
		//	_GroupBox2.Name = "GroupBox2";
			_GroupBox2.Size = new Size(0x138, 0x70);
			_GroupBox2.TabIndex = 10;
			_GroupBox2.TabStop = false;
			_GroupBox2.Text = "Background";
			_picBackground.BorderStyle = BorderStyle.Fixed3D;
			_picBackground.Location = new Point(0xe0, 0x30);
		//	_picBackground.Name = "picBackground";
			_picBackground.Size = new Size(0x40, 0x38);
			_picBackground.TabIndex = 11;
			_picBackground.TabStop = false;
			_btnChooseColor.Location = new Point(0x18, 0x30);
		//	_btnChooseColor.Name = "btnChooseColor";
			_btnChooseColor.TabIndex = 9;
			_btnChooseColor.Text = "Choose...";
			_comboBackgrounds.Location = new Point(0x14, 0x12);
		//	_comboBackgrounds.Name = "comboBackgrounds";
			_comboBackgrounds.Size = new Size(0x110, 0x15);
			_comboBackgrounds.TabIndex = 4;
			_GroupBox3.Controls.Add(_CheckBox1);
			_GroupBox3.FlatStyle = FlatStyle.System;
			_GroupBox3.Location = new Point(8, 8);
		//	_GroupBox3.Name = "GroupBox3";
			_GroupBox3.Size = new Size(0x138, 0x60);
			_GroupBox3.TabIndex = 11;
			_GroupBox3.TabStop = false;
			_GroupBox3.Text = "General";
			_CheckBox1.Location = new Point(0x10, 0x10);
		//	_CheckBox1.Name = "CheckBox1";
			_CheckBox1.Size = new Size(0x110, 0x18);
			_CheckBox1.TabIndex = 1;
			_CheckBox1.Text = "Auto-Reset Particle System on Modification";
			_GroupBox4.Controls.Add(_comboPaths);
			_GroupBox4.Controls.Add(_CheckBox2);
			_GroupBox4.FlatStyle = FlatStyle.System;
			_GroupBox4.Location = new Point(8, 0x150);
		//	_GroupBox4.Name = "GroupBox4";
			_GroupBox4.Size = new Size(0x138, 0x48);
			_GroupBox4.TabIndex = 12;
			_GroupBox4.TabStop = false;
			_GroupBox4.Text = "Movement";
			_comboPaths.Location = new Point(0x18, 0x28);
		//	_comboPaths.Name = "comboPaths";
			_comboPaths.Size = new Size(0x110, 0x15);
			_comboPaths.TabIndex = 3;
			_CheckBox2.Location = new Point(0x10, 0x10);
		//	_CheckBox2.Name = "CheckBox2";
			_CheckBox2.Size = new Size(0x110, 0x18);
			_CheckBox2.TabIndex = 2;
			_CheckBox2.Text = "Enable Path Movement";
			this.AutoScaleBaseSize = new Size(5, 13);
			this.ClientSize = new Size(0x14a, 0x1c2);
			this.Controls.Add(_GroupBox4);
			this.Controls.Add(_GroupBox3);
			this.Controls.Add(_GroupBox2);
			this.Controls.Add(_GroupBox1);
			this.Controls.Add(_btnOk);
			this.Controls.Add(_btnCancel);
//			this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			this.Name = "frmOptions";
			this.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Options...";
			_GroupBox1.ResumeLayout(false);
			_GroupBox2.ResumeLayout(false);
			_GroupBox3.ResumeLayout(false);
			_GroupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

            this._btnOk.Click += new EventHandler(this.btnOk_Click);
            this._btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this._btnChooseColor.Click += new EventHandler(this.btnChooseColor_Click);
		}
		
		private void frmOptions_Load (object sender, EventArgs e)
		{
		}
		
		private void btnOk_Click (object sender, EventArgs e)
		{
			modOptions.SaveOptions();
			this.Close();
		}
		
		private void btnCancel_Click (object sender, EventArgs e)
		{
			this.Close();
		}
		
		private void UpdateFromOptions ()
		{
			modMain.iDebug = 0;
			modMain.iDebug = 1;
			modMain.iDebug = 2;
		}
		
		private void btnChooseColor_Click (object sender, EventArgs e)
		{
			_dlgColor.AllowFullOpen = false;
			_dlgColor.FullOpen = false;
			if (_dlgColor.ShowDialog() == DialogResult.OK)
			{
				_picBackground.BackColor = _dlgColor.Color;
			}
		}
	}
}

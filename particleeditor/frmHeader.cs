using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ParticleEditor
{
	public class frmHeader : Form
	{
        // Instance Fields
        private Label _lblTitle;
        private Label _lblDesc;
        private Button _btnClose;
        private IContainer components;

		// Constructors
		public frmHeader ()
		{
			this.InitializeComponent();
		}
		
		public frmHeader (string sTitle, string sDesc)
		{
			this.InitializeComponent();
			_lblTitle.Text = sTitle;
			_lblDesc.Text = sDesc;
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
			_lblTitle = new Label();
			_btnClose = new Button();
			_lblDesc = new Label();
			
			_lblTitle.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			_lblTitle.Location = new Point(5, 8);
			_lblTitle.Name = "lblTitle";
			_lblTitle.Size = new Size(0xf8, 0x17);
			_lblTitle.TabIndex = 2;
			_lblTitle.TextAlign = ContentAlignment.TopCenter;
//			_btnClose.DialogResult = DialogResult.Cancel;
			_btnClose.Location = new Point(0x5c, 0x70);
			_btnClose.Name = "btnClose";
			_btnClose.TabIndex = 3;
			_btnClose.Text = "&Close";
			_lblDesc.Location = new Point(5, 0x18);
			_lblDesc.Name = "lblDesc";
			_lblDesc.Size = new Size(0xf8, 0x58);
			_lblDesc.TabIndex = 4;
			_lblDesc.TextAlign = ContentAlignment.TopCenter;
			this.AcceptButton = _btnClose;
			this.AutoScaleBaseSize = new Size(5, 13);
			this.CancelButton = _btnClose;
			this.ClientSize = new Size(0x102, 0x8a);
			this.Controls.Add(_lblDesc);
			this.Controls.Add(_btnClose);
			this.Controls.Add(_lblTitle);
//			this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmHeader";
			this.ShowInTaskbar = false;
			this.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Particle System Information...";
			this.TopMost = true;
			this.ResumeLayout(false);

            this._btnClose.Click += new EventHandler(this.btnClose_Click);
		}
		
		private void btnClose_Click (object sender, EventArgs e)
		{
			this.Close();
		}
	}
}

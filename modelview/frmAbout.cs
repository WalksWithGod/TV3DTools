#region

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#endregion

namespace ModelView
{
    public class frmAbout : Form
    {
        // Instance Fields
        [AccessedThroughProperty("PictureBox1")] private PictureBox _PictureBox1;
        [AccessedThroughProperty("LinkLabel1")] private LinkLabel _LinkLabel1;
        [AccessedThroughProperty("btnClose")] private Button _btnClose;
        [AccessedThroughProperty("lblVersion")] private Label _lblVersion;
        [AccessedThroughProperty("Label3")] private Label _Label3;
        [AccessedThroughProperty("lblAppName")] private Label _lblAppName;
        private IContainer components;

        // Constructors
        public frmAbout()
        {
            base.Load += frmAbout_Load;
            InitializeComponent();
        }


        // Methods
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            _btnClose = new Button();
            _lblAppName = new Label();
            _lblVersion = new Label();
            _PictureBox1 = new PictureBox();
            _Label3 = new Label();
            _LinkLabel1 = new LinkLabel();
            SuspendLayout();
            //btnClose.DialogResult = DialogResult.Cancel;
            _btnClose.Location = new Point(0xf8, 0x80);
            _btnClose.Name = "btnClose";
            _btnClose.TabIndex = 0;
            _btnClose.Text = "&Close";
            _lblAppName.Font = new Font("Arial", 12.00F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _lblAppName.Location = new Point(0x70, 8);
            _lblAppName.Name = "lblAppName";
            _lblAppName.Size = new Size(0xd8, 0x12);
            _lblAppName.TabIndex = 1;
            _lblAppName.Text = "ProductName";
            _lblAppName.TextAlign = ContentAlignment.TopCenter;
            _lblVersion.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _lblVersion.Location = new Point(0xc0, 0x18);
            _lblVersion.Name = "lblVersion";
            _lblVersion.Size = new Size(0x88, 0x18);
            _lblVersion.TabIndex = 2;
            _lblVersion.Text = "ProductVersion";
            _lblVersion.TextAlign = ContentAlignment.TopRight;
            _PictureBox1.BorderStyle = BorderStyle.Fixed3D;
          //  _PictureBox1.Image = (Image)new ResourceManager(typeof(frmAbout)).GetObject("PictureBox1.Image");
            _PictureBox1.Location = new Point(8, 7);
            _PictureBox1.Name = "PictureBox1";
            _PictureBox1.Size = new Size(0x64, 0x90);
            _PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            _PictureBox1.TabIndex = 3;
            _PictureBox1.TabStop = false;
            _Label3.Location = new Point(0x78, 0x30);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(0xd0, 0x28);
            _Label3.TabIndex = 4;
            _Label3.Text =
                "This program is part of the TV3D SDK, and is Copyright 2006-2008 by Truevision3D, LLC  All Rights Reserved";
            _Label3.TextAlign = ContentAlignment.MiddleCenter;
            _LinkLabel1.Location = new Point(0x78, 0x60);
            _LinkLabel1.Name = "LinkLabel1";
            _LinkLabel1.Size = new Size(0xc8, 0x17);
            _LinkLabel1.TabIndex = 5;
            _LinkLabel1.TabStop = true;
            _LinkLabel1.Text = "http://www.truevision3d.com";
            _LinkLabel1.TextAlign = ContentAlignment.TopCenter;
            AcceptButton = _btnClose;
            AutoScaleBaseSize = new Size(5, 13);
            CancelButton = _btnClose;
            ClientSize = new Size(0x150, 0x9d);
            Controls.Add(_lblAppName);
            Controls.Add(_LinkLabel1);
            Controls.Add(_Label3);
            Controls.Add(_PictureBox1);
            Controls.Add(_lblVersion);
            Controls.Add(_btnClose);
          //  FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAbout";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            Text = "About " + Application.ProductName + "...";
            lblAppName.Text = Application.ProductName;
            lblVersion.Text = "Version " + Application.ProductVersion;
        }


        // Properties
        internal virtual Button btnClose
        {
            get { return _btnClose; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClose != null)
                {
                    _btnClose.Click -= btnClose_Click;
                }
                _btnClose = value;
                if (_btnClose != null)
                {
                    _btnClose.Click += btnClose_Click;
                }
            }
        }

        internal virtual PictureBox PictureBox1
        {
            get { return _PictureBox1; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PictureBox1 != null)
                {
                }
                _PictureBox1 = value;
                if (_PictureBox1 != null)
                {
                }
            }
        }

        internal virtual Label Label3
        {
            get { return _Label3; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label3 != null)
                {
                }
                _Label3 = value;
                if (_Label3 != null)
                {
                }
            }
        }

        internal virtual LinkLabel LinkLabel1
        {
            get { return _LinkLabel1; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LinkLabel1 != null)
                {
                }
                _LinkLabel1 = value;
                if (_LinkLabel1 != null)
                {
                }
            }
        }

        internal virtual Label lblVersion
        {
            get { return _lblVersion; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblVersion != null)
                {
                }
                _lblVersion = value;
                if (_lblVersion != null)
                {
                }
            }
        }

        internal virtual Label lblAppName
        {
            get { return _lblAppName; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAppName != null)
                {
                }
                _lblAppName = value;
                if (_lblAppName != null)
                {
                }
            }
        }
    }
}
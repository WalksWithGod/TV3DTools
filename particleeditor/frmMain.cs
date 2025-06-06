using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TD.SandDock;

namespace ParticleEditor
{
	public class frmMain : Form
	{
        // Instance Fields
        private MenuItem _MenuItem12;
        private MenuItem _MenuItem17;
        private OpenFileDialog _dlgOpen;
        private MenuItem _MenuItem18;
        private MenuItem _MenuItem19;
        internal MainMenu _menuMain;
        private SaveFileDialog _dlgSave;
        private MenuItem _MenuItem20;
        private ColorDialog _dlgColor;
        private MenuItem _MenuItem21;
        private MenuItem _MenuItem26;
        private MenuItem _MenuItem23;
        private MenuItem _MenuItem22;
        internal ContextMenu _menuContext;
        private MenuItem _MenuItem27;
        private MenuItem _MenuItem16;
        private MenuItem _MenuItem28;
        private MenuItem _MenuItem15;
        private MenuItem _MenuItem45;
        private MenuItem _MenuItem25;
        private MenuItem _MenuItem14;
        private MenuItem _MenuItem29;
        private MenuItem _MenuItem10;
        private MenuItem _MenuItem13;
        private MenuItem _MenuItem1;
        private MenuItem _MenuItem11;
        private MenuItem _MenuItem30;
        private MenuItem _MenuItem31;
        internal TreeView _treeSystem;
        private DockContainer _topSandDock;
        private MenuItem _MenuItem32;
        private DockContainer _bottomSandDock;
        private MenuItem _MenuItem33;
        private MenuItem _MenuItem34;
        private DockContainer _rightSandDock;
        internal MenuItem _MenuItem24;
        private MenuItem _MenuItem35;
        private DockContainer _leftSandDock;
        private MenuItem _MenuItem36;
        private SandDockManager _dockManager;
        internal DockableWindow _dcSysTree;
        internal PropertyGrid _propSystem;
        internal PictureBox _picRender;
        private MenuItem _MenuItem37;
        private MenuItem _MenuItem38;
        private MenuItem _MenuItem9;
        private MenuItem _MenuItem44;
        private MenuItem _MenuItem8;
        private MenuItem _MenuItem39;
        private MenuItem _MenuItem40;
        private MenuItem _MenuItem7;
        private MenuItem _MenuItem41;
        private MenuItem _MenuItem42;
        private MenuItem _MenuItem6;
        private MenuItem _MenuItem5;
        private MenuItem _MenuItem43;
        private MenuItem _MenuItem4;
        private MenuItem _MenuItem3;
        private MenuItem _MenuItem2;
        private IContainer components;
        public TreeNode nodeParent;
        public string sFilename;
        public bool bInputMode;
        public bool bViewMode;
        public int iSelectedID;

		// Constructors
		public frmMain ()
		{
			base.Closing += new CancelEventHandler(this.frmMain_Closing);
			base.Load += new EventHandler(this.frmMain_Load);
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
			_menuMain = new MainMenu();
			_MenuItem1 = new MenuItem();
			_MenuItem2 = new MenuItem();
			_MenuItem3 = new MenuItem();
			_MenuItem4 = new MenuItem();
			_MenuItem5 = new MenuItem();
			_MenuItem6 = new MenuItem();
			_MenuItem23 = new MenuItem();
			_MenuItem22 = new MenuItem();
			_MenuItem7 = new MenuItem();
			_MenuItem8 = new MenuItem();
			_MenuItem20 = new MenuItem();
			_MenuItem21 = new MenuItem();
			_MenuItem27 = new MenuItem();
			_MenuItem28 = new MenuItem();
			_MenuItem9 = new MenuItem();
			_MenuItem26 = new MenuItem();
			_MenuItem24 = new MenuItem();
			_MenuItem35 = new MenuItem();
			_MenuItem36 = new MenuItem();
			_MenuItem11 = new MenuItem();
			_MenuItem25 = new MenuItem();
			_MenuItem29 = new MenuItem();
			_MenuItem13 = new MenuItem();
			_MenuItem15 = new MenuItem();
			_MenuItem16 = new MenuItem();
			_MenuItem31 = new MenuItem();
			_MenuItem33 = new MenuItem();
			_MenuItem14 = new MenuItem();
			_MenuItem37 = new MenuItem();
			_MenuItem38 = new MenuItem();
			_MenuItem39 = new MenuItem();
			_MenuItem40 = new MenuItem();
			_MenuItem41 = new MenuItem();
			_MenuItem42 = new MenuItem();
			_MenuItem43 = new MenuItem();
			_MenuItem44 = new MenuItem();
			_picRender = new PictureBox();
			_menuContext = new ContextMenu();
			_MenuItem10 = new MenuItem();
			_MenuItem30 = new MenuItem();
			_MenuItem12 = new MenuItem();
			_MenuItem18 = new MenuItem();
			_MenuItem19 = new MenuItem();
			_MenuItem32 = new MenuItem();
			_MenuItem34 = new MenuItem();
			_MenuItem17 = new MenuItem();
			_dockManager = new SandDockManager();
			_leftSandDock = new DockContainer();
			_rightSandDock = new DockContainer();
			_dcSysTree = new DockableWindow();
			_propSystem = new PropertyGrid();
			_treeSystem = new TreeView();
			_bottomSandDock = new DockContainer();
			_topSandDock = new DockContainer();
			_dlgColor = new ColorDialog();
			_dlgSave = new SaveFileDialog();
			_dlgOpen = new OpenFileDialog();
			_MenuItem45 = new MenuItem();
			_rightSandDock.SuspendLayout();
			_dcSysTree.SuspendLayout();
			this.SuspendLayout();

			_MenuItem1.Index = 0;
			_MenuItem1.MenuItems.AddRange(new MenuItem[]{_MenuItem2, _MenuItem3, _MenuItem4, _MenuItem5, _MenuItem6, _MenuItem23, _MenuItem22, _MenuItem7});
			_MenuItem1.Text = "&File";
			_MenuItem2.Index = 0;
			_MenuItem2.Text = "&New";
			_MenuItem3.Index = 1;
			_MenuItem3.Shortcut = Shortcut.CtrlO;
			_MenuItem3.Text = "&Open...";
			_MenuItem4.Index = 2;
			_MenuItem4.Shortcut = Shortcut.CtrlS;
			_MenuItem4.Text = "&Save";
			_MenuItem5.Index = 3;
			_MenuItem5.Text = "Save &As...";
			_MenuItem6.Index = 4;
			_MenuItem6.Text = "-";
			_MenuItem23.Index = 5;
			_MenuItem23.Text = "Export as TVP...";
			_MenuItem22.Index = 6;
			_MenuItem22.Text = "-";
			_MenuItem7.Index = 7;
			_MenuItem7.Text = "E&xit";
			_MenuItem8.Index = 1;
			_MenuItem8.MenuItems.AddRange(new MenuItem[]{_MenuItem20, _MenuItem9, _MenuItem26, _MenuItem24, _MenuItem35, _MenuItem36, _MenuItem45});
			_MenuItem8.Text = "&Options";
			_MenuItem20.Index = 0;
			_MenuItem20.MenuItems.AddRange(new MenuItem[]{_MenuItem21, _MenuItem27, _MenuItem28});
			_MenuItem20.Text = "Display &Debug Info";
			_MenuItem21.Index = 0;
			_MenuItem21.Text = "&Off";
			_MenuItem27.Index = 1;
			_MenuItem27.Text = "&Partial";
			_MenuItem28.Index = 2;
			_MenuItem28.Text = "&Full";
			_MenuItem9.Index = 1;
			_MenuItem9.Text = "Display &Tree View";
			_MenuItem26.Index = 2;
			_MenuItem26.Text = "&Background Color...";
			_MenuItem24.Index = 3;
			_MenuItem24.Text = "&Auto-Reset Particle System";
			_MenuItem35.Index = 4;
			_MenuItem35.Text = "-";
			_MenuItem36.Index = 5;
			_MenuItem36.Shortcut = Shortcut.F6;
			_MenuItem36.Text = "&Reset Camera";
			_MenuItem11.Index = 2;
			_MenuItem11.MenuItems.AddRange(new MenuItem[]{_MenuItem25, _MenuItem29, _MenuItem13, _MenuItem14});
			_MenuItem11.Text = "&Particle System";
			_MenuItem25.Index = 0;
			_MenuItem25.Shortcut = Shortcut.F5;
			_MenuItem25.Text = "&Reset";
			_MenuItem29.Index = 1;
			_MenuItem29.Text = "-";
			_MenuItem13.Index = 2;
			_MenuItem13.MenuItems.AddRange(new MenuItem[]{_MenuItem15, _MenuItem16, _MenuItem31, _MenuItem33});
			_MenuItem13.Text = "&Add";
			_MenuItem15.Index = 0;
			_MenuItem15.Text = "&Emitter...";
			_MenuItem16.Index = 1;
			_MenuItem16.Text = "&Attractor...";
			_MenuItem31.Index = 2;
			_MenuItem31.Text = "Emitter &Keyframe...";
			_MenuItem33.Index = 3;
			_MenuItem33.Text = "&Particle Keyframe...";
			_MenuItem14.Index = 3;
			_MenuItem14.Text = "&Delete";
			_MenuItem37.Index = 3;
			_MenuItem37.MenuItems.AddRange(new MenuItem[]{_MenuItem38, _MenuItem39, _MenuItem40, _MenuItem41, _MenuItem42, _MenuItem43, _MenuItem44});
			_MenuItem37.Text = "&Help";
			_MenuItem38.Index = 0;
			_MenuItem38.Shortcut = Shortcut.F1;
			_MenuItem38.Text = "&Help Topics";
			_MenuItem39.Index = 1;
			_MenuItem39.Text = "-";
			_MenuItem40.Index = 2;
			_MenuItem40.Text = "&Contents...";
			_MenuItem41.Index = 3;
			_MenuItem41.Text = "&Index...";
			_MenuItem42.Index = 4;
			_MenuItem42.Text = "&Search...";
			_MenuItem43.Index = 5;
			_MenuItem43.Text = "-";
			_MenuItem44.Index = 6;
			_MenuItem44.Text = "&About TV3D Particle Editor...";
			_picRender.ContextMenu = _menuContext;
			_picRender.Dock = DockStyle.Fill;
			_picRender.Location = new Point(0, 0);
			//_picRender.Name = "picRender";
			_picRender.Size = new Size(0x2ba, 0x2cd);
			_picRender.TabIndex = 0;
			_picRender.TabStop = false;
			_menuContext.MenuItems.AddRange(new MenuItem[]{_MenuItem10, _MenuItem30, _MenuItem12, _MenuItem17});
			_MenuItem10.Index = 0;
			_MenuItem10.Text = "&Reset";
			_MenuItem30.Index = 1;
			_MenuItem30.Text = "-";
			_MenuItem12.Index = 2;
			_MenuItem12.MenuItems.AddRange(new MenuItem[]{_MenuItem18, _MenuItem19, _MenuItem32, _MenuItem34});
			_MenuItem12.Text = "&Add";
			_MenuItem18.Index = 0;
			_MenuItem18.Text = "&Emitter...";
			_MenuItem19.Index = 1;
			_MenuItem19.Text = "&Attractor...";
			_MenuItem32.Index = 2;
			_MenuItem32.Text = "Emitter &Keyframe...";
			_MenuItem34.Index = 3;
			_MenuItem34.Text = "&Particle Keyframe...";
			_MenuItem17.Index = 3;
			_MenuItem17.Text = "&Delete";

			_rightSandDock.Size = new Size(0xfe, 0x2cd);
			_rightSandDock.TabIndex = 2;
			_dcSysTree.AllowDockBottom=false;
			_dcSysTree.AllowDockTop = false;
			_dcSysTree.Controls.Add(_propSystem);
			_dcSysTree.Controls.Add(_treeSystem);
			_dcSysTree.Guid =new Guid("c88dd1f0-e946-4d55-9fce-10634f8148b6");
			_dcSysTree.Location = new Point(4, 0x10);
			//_dcSysTree.Name = "dcSysTree";
			_dcSysTree.Size =  new Size(0xfa, 0x2a5);
			_dcSysTree.TabIndex = 0;
			_dcSysTree.Text = "Particle System Tree";
			_propSystem.CommandsVisibleIfAvailable = true;
			_propSystem.Cursor = Cursors.HSplit;
			_propSystem.Dock = DockStyle.Fill;
			_propSystem.LargeButtons = false;
			_propSystem.LineColor = SystemColors.ScrollBar;
			_propSystem.Location = new Point(0, 0xf8);
			//_propSystem.Name = "propSystem";
			_propSystem.Size = new Size(0xfa, 0x1ad);
			_propSystem.TabIndex = 6;
			_propSystem.TabStop = false;
			_propSystem.Text = "gridProps";
			_propSystem.ViewBackColor = SystemColors.Window;
			_propSystem.ViewForeColor = SystemColors.WindowText;
			_treeSystem.Dock = DockStyle.Top;
			_treeSystem.FullRowSelect = true;
			_treeSystem.HideSelection = false;
			_treeSystem.ImageIndex = -1;
			_treeSystem.Location = new Point(0, 0);
			//_treeSystem.Name = "treeSystem";
			_treeSystem.SelectedImageIndex = -1;
			_treeSystem.Size = new Size(0xfa, 0xf8);
			_treeSystem.TabIndex = 0;
			_treeSystem.TabStop = false;
		    _bottomSandDock.Dock = DockStyle.Bottom;
			_bottomSandDock.LayoutSystem = new SplitLayoutSystem(0xfa, 0x190, Orientation.Horizontal , new LayoutSystemBase[0]);
			_bottomSandDock.Location = new Point(0, 0x2cd);
			_bottomSandDock.Manager = _dockManager;
			//_bottomSandDock.Name = "bottomSandDock";
			_bottomSandDock.Size = new Size(0x3b8, 0);
			_bottomSandDock.TabIndex = 3;
		    _topSandDock.Dock = DockStyle.Top;
            _topSandDock.LayoutSystem = new SplitLayoutSystem(0xfa, 0x190, Orientation.Horizontal, new LayoutSystemBase[0]);
			_topSandDock.Location = new Point(0, 0);
			_topSandDock.Manager = _dockManager;
			//_topSandDock.Name = "topSandDock";
			_topSandDock.Size = new Size(0x3b8, 0);
			_topSandDock.TabIndex = 4;
            _dockManager.AllowKeyboardNavigation = false;
            _dockManager.DockSystemContainer = (Control)this;
            _dockManager.OwnerForm = (Form)this;
            _dockManager.SerializeTabbedDocuments = true;
            _leftSandDock.Dock = DockStyle.Left;
            _leftSandDock.LayoutSystem = new SplitLayoutSystem(0xfa, 0x190, Orientation.Vertical, new LayoutSystemBase[0]);
            _leftSandDock.Location = new Point(0, 0);
            _leftSandDock.Manager = _dockManager;
            //_leftSandDock.Name = "leftSandDock";
            _leftSandDock.Size = new Size(0, 0x2cd);
            _leftSandDock.TabIndex = 1;
            _rightSandDock.Controls.Add(_dcSysTree);
            _rightSandDock.Dock = DockStyle.Right;
            _rightSandDock.LayoutSystem = new SplitLayoutSystem(0xfa, 0x190, Orientation.Vertical, new LayoutSystemBase[] { new ControlLayoutSystem(0xfa, 0x2cd, new DockControl[] { _dcSysTree }, _dcSysTree) });
            _rightSandDock.Location = new Point(0x2ba, 0);
            _rightSandDock.Manager = _dockManager;
            //_rightSandDock.Name = "rightSandDock";
			_dlgColor.AnyColor = true;
			_dlgColor.FullOpen = true;
			_dlgColor.SolidColorOnly = true;
			_dlgSave.Filter = "TVParticleSystem Projects (*.tvpj) | *.tvpj | All Files (*.*) | *.*";
			_dlgSave.Title = "Save Project As...";
			_dlgOpen.DefaultExt = "*.tvpj";
			_dlgOpen.Filter = "TVParticleSystem Projects (*.tvpj) | *.tvpj | All Files (*.*) | *.*";
			_dlgOpen.Title = "Open TVParticleSystem Project...";
			_MenuItem45.Index = 6;
			_MenuItem45.Text = "&Options...";
            _menuMain.MenuItems.AddRange(new MenuItem[] { _MenuItem1, _MenuItem8, _MenuItem11, _MenuItem37 });
			this.AutoScaleBaseSize = new Size(5, 13);
			this.ClientSize = new Size(0x3b8, 0x2cd);
			this.Controls.Add(_picRender);
			this.Controls.Add(_leftSandDock);
			this.Controls.Add(_rightSandDock);
			this.Controls.Add(_bottomSandDock);
			this.Controls.Add(_topSandDock);
//			this.Icon = (Icon) new ResourceManager(typeof(frmMain)).GetObject("$this.Icon");
			this.Menu = _menuMain;
			this.Name = "frmMain";
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "TV3D Particle Editor";
			this.WindowState = FormWindowState.Maximized;
			_rightSandDock.ResumeLayout(false);
			_dcSysTree.ResumeLayout(false);
			this.ResumeLayout(false);


            this._MenuItem2.Click += new EventHandler(this.MenuItem2_Click);
            this._MenuItem3.Click += new EventHandler(this.MenuItem3_Click);
            this._MenuItem4.Click += new EventHandler(this.MenuItem4_Click);
            this._MenuItem5.Click += new EventHandler(this.MenuItem5_Click);
            this._MenuItem7.Click += new EventHandler(this.MenuItem7_Click);
            this._MenuItem9.Click += new EventHandler(this.MenuItem9_Click);
            this._picRender.Click += new EventHandler(this.picRender_Click);
            this._picRender.GotFocus += new EventHandler(this.picRender_GotFocus);
            this._dockManager.DockControlActivated += new DockControlEventHandler(this.dockManager_DockControlActivated);
            this._treeSystem.MouseUp += new MouseEventHandler(this.treeSystem_MouseUp);
            this._treeSystem.AfterSelect += new TreeViewEventHandler(this.treeSystem_AfterSelect);
            this._MenuItem14.Click += new EventHandler(this.MenuItem14_Click);
            this._MenuItem15.Click += new EventHandler(this.MenuItem15_Click);
            this._MenuItem16.Click += new EventHandler(this.MenuItem16_Click);
            this._MenuItem23.Click += new EventHandler(this.MenuItem23_Click);
            this._MenuItem26.Click += new EventHandler(this.MenuItem26_Click);
            this._MenuItem17.Click += new EventHandler(this.MenuItem17_Click);
            this._MenuItem18.Click += new EventHandler(this.MenuItem18_Click);
            this._MenuItem19.Click += new EventHandler(this.MenuItem19_Click);
            this._MenuItem21.Click += new EventHandler(this.MenuItem21_Click);
            this._MenuItem27.Click += new EventHandler(this.MenuItem27_Click);
            this._MenuItem28.Click += new EventHandler(this.MenuItem28_Click);
            this._MenuItem25.Click += new EventHandler(this.MenuItem25_Click);
            this._MenuItem10.Click += new EventHandler(this.MenuItem10_Click);
            this._MenuItem31.Click += new EventHandler(this.MenuItem31_Click);
            this._MenuItem32.Click += new EventHandler(this.MenuItem32_Click);
            this._MenuItem33.Click += new EventHandler(this.MenuItem33_Click);
            this._MenuItem34.Click += new EventHandler(this.MenuItem34_Click);
            this._MenuItem24.Click += new EventHandler(this.MenuItem24_Click);
            this._MenuItem36.Click += new EventHandler(this.MenuItem36_Click);
            this._dcSysTree.Closing += new DockControlClosingEventHandler(this.dcSysTree_Closing);
            this._propSystem.PropertyValueChanged += new PropertyValueChangedEventHandler(this.propSystem_PropertyValueChanged);
            this._MenuItem44.Click += new EventHandler(this.MenuItem44_Click);
            this._MenuItem45.Click += new EventHandler(this.MenuItem45_Click);
		}
		
		private void SaveAs ()
		{
			_dlgSave.Filter = "TVParticleSystem Project Files (*.TVPJ)|*.TVPJ";
			DialogResult result1 = _dlgSave.ShowDialog();
			if (result1 != DialogResult.Cancel)
			{
				this.sFilename = _dlgSave.FileName;
				modParticleXML.SaveSystem(this.sFilename);
			}
		}
		
		private void Save ()
		{
			if (StringType.StrCmp(this.sFilename, "", false) == 0)
			{
				this.SaveAs();
			}
			else
			{
				modParticleXML.SaveSystem(this.sFilename);
			}
			this.SetTitle();
		}
		
		private void frmMain_Closing (object sender, CancelEventArgs e)
		{
			if (modParticleXML.bNeedsSaving)
			{
				MsgBoxResult result1 = Interaction.MsgBox("Particle system has changed, would you like to save?", MsgBoxStyle.YesNo , null);
				if (result1 == MsgBoxResult.Yes)
				{
					this.Save();
				}
			}
			modMain.bRun = false;
			e.Cancel = true;
		}
		
		private void frmMain_Load (object sender, EventArgs e)
		{
			this.ResetTree();
			if (ObjectType.ObjTst(modOptions.GetOption("systree", "open"), "closed", false) == 0)
			{
				_MenuItem9.Checked = true;
			}
			this.MenuItem9_Click(RuntimeHelpers.GetObjectValue(sender), e);
			if (ObjectType.ObjTst(modOptions.GetOption("autoreset", "true"), "false", false) == 0)
			{
				_MenuItem24.Checked = true;
			}
			this.MenuItem24_Click(RuntimeHelpers.GetObjectValue(sender), e);
			object obj1 = modOptions.GetOption("debug", "full");
			if (ObjectType.ObjTst(obj1, "off", false) == 0)
			{
				this.MenuItem21_Click(RuntimeHelpers.GetObjectValue(sender), e);
			}
			else if (ObjectType.ObjTst(obj1, "partial", false) == 0)
			{
				this.MenuItem27_Click(RuntimeHelpers.GetObjectValue(sender), e);
			}
			else
			{
				if (ObjectType.ObjTst(obj1, "full", false) == 0)
				{
					this.MenuItem28_Click(RuntimeHelpers.GetObjectValue(sender), e);
				}
			}
		}
		
		private void ResetTree ()
		{
			_treeSystem.Nodes.Clear();
			this.nodeParent = _treeSystem.Nodes.Add("Particle System");
		}
		
		private void MenuItem23_Click (object sender, EventArgs e)
		{
			_dlgSave.Filter = "TVParticleSystem Binary Data (*.TVP)|*.TVP";
			DialogResult result1 = _dlgSave.ShowDialog();
			if (result1 != DialogResult.Cancel)
			{
				modMain.pSystem.Save(_dlgSave.FileName);
				modParticleXML.bNeedsSaving = false;
			}
		}
		
		private void treeSystem_AfterSelect (object sender, TreeViewEventArgs e)
		{
			bool bEnable = false;
			this.iSelectedID = modParticleXML.IDFromName(_treeSystem.SelectedNode.Text);
			if (Strings.InStr(_treeSystem.SelectedNode.Text, "Emitter #", 0) > 0)
			{
				modemitterUtils.LoadEmitterProps(this.iSelectedID);
				bEnable = true;
			}
			else if (Strings.InStr(_treeSystem.SelectedNode.Text, "Attractor #", 0) > 0)
			{
				modAttractorUtils.LoadAttractorProps(this.iSelectedID);
				bEnable = true;
			}
			else if (Strings.InStr(_treeSystem.SelectedNode.Text, "Emitter Keyframe #", 0) > 0)
			{
				modEmitterKeyframeUtils.LoadEmitterKeyframeProps(modParticleXML.IDFromName(_treeSystem.SelectedNode.Parent.Parent.Text), this.iSelectedID);
				bEnable = true;
			}
			else if (Strings.InStr(_treeSystem.SelectedNode.Text, "Particle Keyframe #", 0) > 0)
			{
				modParticleKeyframeUtils.LoadParticleKeyframeProps(modParticleXML.IDFromName(_treeSystem.SelectedNode.Parent.Parent.Text), this.iSelectedID);
				bEnable = true;
			}
			else
			{
				bEnable = false;
			}
			modMenu.DisableMenuItem("&Delete", bEnable);
			modMenu.DisableMenuItem("Emitter &Keyframe...", bEnable);
			modMenu.DisableMenuItem("&Particle Keyframe...", bEnable);
		}
		
		private void MenuItem26_Click (object sender, EventArgs e)
		{
			DialogResult result1 = _dlgColor.ShowDialog();
			Color color1 = _dlgColor.Color;
			modMain.oScene.SetBackgroundColor((float) (((double) color1.R) / 255), (float) (((double) color1.G) / 255), (float) (((double) color1.B) / 255));
			modOptions.SetOption("background-color", string.Concat(new string[]{StringType.FromDouble(((double) color1.R) / 255), ",", StringType.FromDouble(((double) color1.G) / 255), ",", StringType.FromDouble(((double) color1.B) / 255), ",0"}));
		}
		
		private void MenuItem5_Click (object sender, EventArgs e)
		{
			this.SaveAs();
		}
		
		private void MenuItem4_Click (object sender, EventArgs e)
		{
			this.Save();
		}
		
		private void MenuItem3_Click (object sender, EventArgs e)
		{
			_dlgOpen.Filter = "TVParticleSystem Project Files (*.TVPJ)|*.TVPJ|TVParticleSystem Files (*.TVP)|*.TVP";
			DialogResult result1 = _dlgOpen.ShowDialog();
			if (result1 != DialogResult.Cancel)
			{
				this.sFilename = _dlgOpen.FileName;
				modParticleXML.LoadSystem(this.sFilename);
				modParticleXML.bNeedsSaving = false;
				this.SetTitle();
			}
		}
		
		private void MenuItem2_Click (object sender, EventArgs e)
		{
			this.sFilename = "";
			modParticleXML.ClearSystem(true, true);
			this.SetTitle();
		}
		
		private void propSystem_PropertyValueChanged (object s, PropertyValueChangedEventArgs e)
		{
			this.UpdateXML();
		}
		
		private void MenuItem7_Click (object sender, EventArgs e)
		{
			ProjectData.EndApp();
		}
		
		private void MenuItem17_Click (object sender, EventArgs e)
		{
			if (StringType.StrCmp(_treeSystem.SelectedNode.Text, "Particle System", false) != 0)
			{
				MsgBoxResult result1 = Interaction.MsgBox("Are you sure you want to delete " + _treeSystem.SelectedNode.Text + "?", MsgBoxStyle.YesNo , null);
				if (result1 == MsgBoxResult.Yes)
				{
					if (Strings.InStr(_treeSystem.SelectedNode.Text, "Emitter #", 0) > 0)
					{
						modemitterUtils.DeleteEmitter(this.iSelectedID);
					}
					else if (Strings.InStr(_treeSystem.SelectedNode.Text, "Attractor #", 0) > 0)
					{
						modAttractorUtils.DeleteAttractor(this.iSelectedID);
					}
					else if (Strings.InStr(_treeSystem.SelectedNode.Text, "Emitter Keyframe #", 0) > 0)
					{
						modEmitterKeyframeUtils.DeleteEmitterKeyframe(modParticleXML.IDFromName(_treeSystem.SelectedNode.Parent.Parent.Text), this.iSelectedID);
					}
					else
					{
						if (Strings.InStr(_treeSystem.SelectedNode.Text, "Particle Keyframe #", 0) > 0)
						{
							modParticleKeyframeUtils.DeleteParticleKeyframe(modParticleXML.IDFromName(_treeSystem.SelectedNode.Parent.Parent.Text), this.iSelectedID);
						}
					}
					modParticleXML.bNeedsReloading = true;
					modParticleXML.bNeedsSaving = true;
					_propSystem.SelectedObject = null;
					_treeSystem.SelectedNode = _treeSystem.Nodes[0];
				}
			}
		}
		
		private void MenuItem14_Click (object sender, EventArgs e)
		{
			this.MenuItem17_Click(RuntimeHelpers.GetObjectValue(sender), e);
		}
		
		private void MenuItem18_Click (object sender, EventArgs e)
		{
			frmEmitter emitter1 = new frmEmitter();
			emitter1.ShowDialog();
			emitter1 = null;
		}
		
		private void MenuItem15_Click (object sender, EventArgs e)
		{
			this.MenuItem18_Click(RuntimeHelpers.GetObjectValue(sender), e);
		}
		
		private void MenuItem19_Click (object sender, EventArgs e)
		{
			modAttractorUtils.AddAttractor();
		}
		
		private void MenuItem16_Click (object sender, EventArgs e)
		{
			this.MenuItem19_Click(RuntimeHelpers.GetObjectValue(sender), e);
		}
		
		private void MenuItem21_Click (object sender, EventArgs e)
		{
			modMain.iDebug = 0;
			_MenuItem21.Checked = true;
			_MenuItem27.Checked = false;
			_MenuItem28.Checked = false;
			modOptions.SetOption("debug", "off");
		}
		
		private void MenuItem27_Click (object sender, EventArgs e)
		{
			modMain.iDebug = 1;
			_MenuItem21.Checked = false;
			_MenuItem27.Checked = true;
			_MenuItem28.Checked = false;
			modOptions.SetOption("debug", "partial");
		}
		
		private void MenuItem28_Click (object sender, EventArgs e)
		{
			modMain.iDebug = 2;
			_MenuItem21.Checked = false;
			_MenuItem27.Checked = false;
			_MenuItem28.Checked = true;
			modOptions.SetOption("debug", "full");
		}
		
		public void SetTitle ()
		{
			if (StringType.StrCmp(this.sFilename, "", false) == 0)
			{
				this.Text = "TV3D Particle Editor";
			}
			else
			{
				this.Text = "TV3D Particle Editor (" + this.sFilename + ")";
			}
		}
		
		private void MenuItem25_Click (object sender, EventArgs e)
		{
			this.UpdateXML();
			modParticleXML.ReloadSystem(false);
		}
		
		private void picRender_GotFocus (object sender, EventArgs e)
		{
			this.bInputMode = true;
		}
		
		private void dockManager_DockControlActivated (object sender, DockControlEventArgs e)
		{
			this.bInputMode = false;
		}
		
		private void MenuItem9_Click (object sender, EventArgs e)
		{
			if (_MenuItem9.Checked)
			{
				_dcSysTree.Close();
				_MenuItem9.Checked = false;
				modOptions.SetOption("systree", "closed");
			}
			else
			{
				_dcSysTree.Open();
				_MenuItem9.Checked = true;
				modOptions.SetOption("systree", "open");
			}
		}
		
		private void MenuItem10_Click (object sender, EventArgs e)
		{
			this.MenuItem25_Click(RuntimeHelpers.GetObjectValue(sender), e);
		}
		
		private void picRender_Click (object sender, EventArgs e)
		{
			_picRender.Focus();
		}
		
		private void MenuItem31_Click (object sender, EventArgs e)
		{
			modEmitterKeyframeUtils.AddEmitterKeyframe(modemitterUtils.GetEmitterNode(this.iSelectedID));
			modParticleXML.bNeedsReloading = true;
			modParticleXML.bNeedsSaving = true;
		}
		
		private void MenuItem33_Click (object sender, EventArgs e)
		{
			modParticleKeyframeUtils.AddParticleKeyframe(modemitterUtils.GetEmitterNode(this.iSelectedID));
			modParticleXML.bNeedsReloading = true;
			modParticleXML.bNeedsSaving = true;
		}
		
		private void MenuItem32_Click (object sender, EventArgs e)
		{
			this.MenuItem31_Click(RuntimeHelpers.GetObjectValue(sender), e);
		}
		
		private void MenuItem34_Click (object sender, EventArgs e)
		{
			this.MenuItem33_Click(RuntimeHelpers.GetObjectValue(sender), e);
		}
		
		private void MenuItem24_Click (object sender, EventArgs e)
		{
			if (_MenuItem24.Checked)
			{
				_MenuItem24.Checked = false;
				modOptions.SetOption("autoreset", "false");
			}
			else
			{
				_MenuItem24.Checked = true;
				modOptions.SetOption("autoreset", "true");
			}
		}
		
		private void dcSysTree_Closing (object sender, DockControlClosingEventArgs e)
		{
			_MenuItem9.Checked = false;
			modOptions.SetOption("systree", "closed");
		}
		
		private void UpdateXML ()
		{
			if (_propSystem.SelectedObject != null)
			{
				if (_propSystem.SelectedObject.GetType() == typeof(propEmitter))
				{
					((propEmitter) _propSystem.SelectedObject).UpdateXML();
				}
				else if (_propSystem.SelectedObject.GetType() == typeof(propEmitterBillboard))
				{
					((propEmitterBillboard) _propSystem.SelectedObject).UpdateXML();
				}
				else if (_propSystem.SelectedObject.GetType() == typeof(propEmitterMinimesh))
				{
					((propEmitterMinimesh) _propSystem.SelectedObject).UpdateXML();
				}
				else if (_propSystem.SelectedObject.GetType() == typeof(propAttractor))
				{
					((propAttractor) _propSystem.SelectedObject).UpdateXML();
				}
				else if (_propSystem.SelectedObject.GetType() == typeof(propEmitterKeyframe))
				{
					((propEmitterKeyframe) _propSystem.SelectedObject).UpdateXML();
				}
				else
				{
					if (_propSystem.SelectedObject.GetType() == typeof(propParticleKeyframe))
					{
						((propParticleKeyframe) _propSystem.SelectedObject).UpdateXML();
					}
				}
			}
		}
		
		private void MenuItem36_Click (object sender, EventArgs e)
		{
			modMain.sHAngle = 45.00F;
			modMain.sVAngle = -20.00F;
			modMain.sZoom = 400.00F;
		}
		
		private void treeSystem_MouseUp (object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				Point p = new Point(e.X, e.Y);
				_treeSystem.PointToClient(p);
				TreeNode node1 = _treeSystem.GetNodeAt(p);
				if (node1 != null)
				{
					if ((StringType.StrCmp(node1.Text, "Particle Keyframes", false) == 0) | (StringType.StrCmp(node1.Text, "Emitter Keyframes", false) == 0))
					{
						node1 = node1.Parent;
					}
					_treeSystem.SelectedNode = node1;
				}
				_menuContext.Show(_treeSystem, p);
			}
		}
		
		public void DeleteKey ()
		{
			this.MenuItem17_Click(null, null);
		}
		
		public void InsertKey ()
		{
			this.MenuItem18_Click(null, null);
		}
		
		private void MenuItem44_Click (object sender, EventArgs e)
		{
			frmAbout about1 = new frmAbout();
			about1.ShowDialog();
			about1 = null;
		}
		
		public void SetViewMode (bool bMode)
		{
			this.bViewMode = bMode;
			if (bMode)
			{
				_MenuItem11.Enabled = false;
				_MenuItem4.Enabled = false;
				_MenuItem5.Enabled = false;
				_MenuItem23.Enabled = false;
				_dcSysTree.Close();
			}
			else
			{
				_MenuItem11.Enabled = true;
				_MenuItem4.Enabled = true;
				_MenuItem5.Enabled = true;
				_MenuItem23.Enabled = true;
				if (!_MenuItem9.Checked)
				{
					_dcSysTree.Open();
				}
			}
		}
		
		private void MenuItem45_Click (object sender, EventArgs e)
		{
			new frmOptions().ShowDialog();
		}
		
	}
}

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TD.SandDock;

namespace ModelView
{
	public class frmMain : Form
	{
        // Instance Fields
        private MenuItem _MenuItem2;
        private Label _labelGlobalTools;
        private MenuItem _MenuItem3;
        private MenuItem _menuShowScene;
        private Button _Button1;
        private MenuItem _MenuItem4;
        private MenuItem _MenuItem5;
        private ToolBarButton _ToolBarRotateModel;
        private Button _btnAddMorphTargets;
        private Label _labelActorTools;
        private Label _labelMeshTools;
        private Button _btnSaveLightXML;
        private PropertyGrid _propertiesScene;
        internal PropertyGrid _propertiesLights;
        private ToolBarButton _ToolBarRotateCamera;
        private SandDockManager _dockManager;
        private Button _btnLoadLightXML;
        private Button _btnLoadSceneFromFile;
        private ToolBarButton _ToolBarSeparator1;
        internal PropertyGrid _propertiesMain;
        private Button _btnSaveSceneToFile;
        private Button _btnComputeNormals;
        private Button _btnResetDefault;
        internal StatusBar _statusBarMain;
        internal ComboBox _comboAnimations;
        private MenuItem _mnAbout;
        private NumericUpDown _numericAnimationSpeed;
        private Button _btnSaveAsDefault;
        private MenuItem _menuHelp;
        private Button _btnPlayForward;
        private MenuItem _mnShowAllWindows;
        private PictureBox _fRender;
        private MenuItem _mnDivide1;
        private Button _Button5;
        private Label _Label1;
        private Button _btnAnimationControl;
        private MenuItem _mnShowTools;
        private Button _Button4;
        private MenuItem _mnShowLights;
        private Button _Button3;
        private ToolBar _mainToolBar;
        private MenuItem _mnShowProperties;
        private Button _Button2;
        private MenuItem _menuView;
        private Button _btnStopAnimation;
        internal ComboBox _comboShaderTechnique;
        private MenuItem _MenuItem6;
        private ContextMenu _contextTreeView;
        internal TreeView _treeShaderParams;
        private MenuItem _mnDivide2;
        private ToolBarButton _ToolBarOpen;
        private MenuItem _menuFile;
        private MainMenu _menuMain;
        private DockableWindow _dockShaderProperties;
        private Button _btnPlayBackwards;
        private Button _btnRemoveUV;
        private ToolBarButton _ToolBarSave;
        private ToolBarButton _ToolBarSaveAs;
        private Button _btnWeld;
        private Button _btnNormalmapGen;
        internal TrackBar _scrollAnimation;
        private Button _btnAddLight;
        private DockableWindow _dockAnimation;
        private Button _btnDeleteLight;
        internal ComboBox _comboGroups;
        internal ComboBox _comboLights;
        private DockContainer _rightSandDock;
        private Button _btnApplyDefaultMat;
        private ImageList _imageListToolBar;
        private DockContainer _leftSandDock;
        internal SaveFileDialog _dlgSave;
        private MenuItem _mnCloseModel;
        private DockableWindow _DockableWindow1;
        private ToolBarButton _ToolBarCloseModel;
        internal OpenFileDialog _dlgOpen;
        internal DockContainer _dockBottom;
        private StatusBarPanel _StatusBarPanelModel;
        private MenuItem _mnQuit;
        private StatusBarPanel _StatusBarPanelAnimation;
        private StatusBarPanel _StatusBarPanelFPS;
        private MenuItem _mnSaveAs;
        private MenuItem _mnSave;
        private ImageList _ImageListAnimation;
        private MenuItem _MenuItem1;
        private MenuItem _mnOpen;
        private StatusBarPanel _StatusBarPanelKeyFrame;
        private DockableWindow _dockProperties;
        private DockableWindow _dockScene;
        private DockableWindow _dockLights;
        private DockableWindow _dockTools;
        private Button _btnGeneratePRT;
        private IContainer components;
        private ResourceManager manager1= new ResourceManager(typeof(frmMain));
		// Constructors
		public frmMain ()
		{
			base.Activated += new EventHandler(this.frmMain_Activated);
			base.Deactivate += new EventHandler(this.frmMain_Deactivate);
			base.Closing += new CancelEventHandler(this.frmMain_Closing);
			base.Closed += new EventHandler(this.frmMain_Closed);
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
            this.components = new System.ComponentModel.Container();
            this._menuMain = new System.Windows.Forms.MainMenu(this.components);
            this._menuFile = new System.Windows.Forms.MenuItem();
            this._mnOpen = new System.Windows.Forms.MenuItem();
            this._mnSave = new System.Windows.Forms.MenuItem();
            this._mnSaveAs = new System.Windows.Forms.MenuItem();
            this._mnDivide2 = new System.Windows.Forms.MenuItem();
            this._mnCloseModel = new System.Windows.Forms.MenuItem();
            this._mnQuit = new System.Windows.Forms.MenuItem();
            this._menuView = new System.Windows.Forms.MenuItem();
            this._mnShowProperties = new System.Windows.Forms.MenuItem();
            this._mnShowLights = new System.Windows.Forms.MenuItem();
            this._menuShowScene = new System.Windows.Forms.MenuItem();
            this._mnShowTools = new System.Windows.Forms.MenuItem();
            this._mnDivide1 = new System.Windows.Forms.MenuItem();
            this._mnShowAllWindows = new System.Windows.Forms.MenuItem();
            this._MenuItem1 = new System.Windows.Forms.MenuItem();
            this._MenuItem2 = new System.Windows.Forms.MenuItem();
            this._MenuItem3 = new System.Windows.Forms.MenuItem();
            this._MenuItem4 = new System.Windows.Forms.MenuItem();
            this._MenuItem5 = new System.Windows.Forms.MenuItem();
            this._menuHelp = new System.Windows.Forms.MenuItem();
            this._mnAbout = new System.Windows.Forms.MenuItem();
            this._statusBarMain = new System.Windows.Forms.StatusBar();
            this._StatusBarPanelModel = new System.Windows.Forms.StatusBarPanel();
            this._StatusBarPanelAnimation = new System.Windows.Forms.StatusBarPanel();
            this._StatusBarPanelKeyFrame = new System.Windows.Forms.StatusBarPanel();
            this._StatusBarPanelFPS = new System.Windows.Forms.StatusBarPanel();
            this._dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this._dlgSave = new System.Windows.Forms.SaveFileDialog();
            this._propertiesMain = new System.Windows.Forms.PropertyGrid();
            this._comboGroups = new System.Windows.Forms.ComboBox();
            this._treeShaderParams = new System.Windows.Forms.TreeView();
            this._contextTreeView = new System.Windows.Forms.ContextMenu();
            this._MenuItem6 = new System.Windows.Forms.MenuItem();
            this._comboShaderTechnique = new System.Windows.Forms.ComboBox();
            this._btnAddMorphTargets = new System.Windows.Forms.Button();
            this._Button1 = new System.Windows.Forms.Button();
            this._btnAnimationControl = new System.Windows.Forms.Button();
            this._labelActorTools = new System.Windows.Forms.Label();
            this._btnGeneratePRT = new System.Windows.Forms.Button();
            this._btnNormalmapGen = new System.Windows.Forms.Button();
            this._btnWeld = new System.Windows.Forms.Button();
            this._btnRemoveUV = new System.Windows.Forms.Button();
            this._labelMeshTools = new System.Windows.Forms.Label();
            this._btnComputeNormals = new System.Windows.Forms.Button();
            this._btnApplyDefaultMat = new System.Windows.Forms.Button();
            this._Button5 = new System.Windows.Forms.Button();
            this._labelGlobalTools = new System.Windows.Forms.Label();
            this._Button4 = new System.Windows.Forms.Button();
            this._Button3 = new System.Windows.Forms.Button();
            this._Button2 = new System.Windows.Forms.Button();
            this._Label1 = new System.Windows.Forms.Label();
            this._leftSandDock = new TD.SandDock.DockContainer();
            this._dockTools = new TD.SandDock.DockableWindow();
            this._dockBottom = new TD.SandDock.DockContainer();
            this._dockAnimation = new TD.SandDock.DockableWindow();
            this._dockShaderProperties = new TD.SandDock.DockableWindow();
            this._dockProperties = new TD.SandDock.DockableWindow();
            this._dockManager = new TD.SandDock.SandDockManager();
            this._rightSandDock = new TD.SandDock.DockContainer();
            this._dockScene = new TD.SandDock.DockableWindow();
            this._propertiesScene = new System.Windows.Forms.PropertyGrid();
            this._btnSaveAsDefault = new System.Windows.Forms.Button();
            this._btnResetDefault = new System.Windows.Forms.Button();
            this._btnSaveSceneToFile = new System.Windows.Forms.Button();
            this._btnLoadSceneFromFile = new System.Windows.Forms.Button();
            this._dockLights = new TD.SandDock.DockableWindow();
            this._propertiesLights = new System.Windows.Forms.PropertyGrid();
            this._btnAddLight = new System.Windows.Forms.Button();
            this._btnDeleteLight = new System.Windows.Forms.Button();
            this._btnSaveLightXML = new System.Windows.Forms.Button();
            this._btnLoadLightXML = new System.Windows.Forms.Button();
            this._comboLights = new System.Windows.Forms.ComboBox();
            this._comboAnimations = new System.Windows.Forms.ComboBox();
            this._numericAnimationSpeed = new System.Windows.Forms.NumericUpDown();
            this._btnPlayForward = new System.Windows.Forms.Button();
            this._ImageListAnimation = new System.Windows.Forms.ImageList(this.components);
            this._btnStopAnimation = new System.Windows.Forms.Button();
            this._btnPlayBackwards = new System.Windows.Forms.Button();
            this._scrollAnimation = new System.Windows.Forms.TrackBar();
            this._DockableWindow1 = new TD.SandDock.DockableWindow();
            this._fRender = new System.Windows.Forms.PictureBox();
            this._mainToolBar = new System.Windows.Forms.ToolBar();
            this._ToolBarOpen = new System.Windows.Forms.ToolBarButton();
            this._ToolBarSave = new System.Windows.Forms.ToolBarButton();
            this._ToolBarSaveAs = new System.Windows.Forms.ToolBarButton();
            this._ToolBarCloseModel = new System.Windows.Forms.ToolBarButton();
            this._ToolBarSeparator1 = new System.Windows.Forms.ToolBarButton();
            this._ToolBarRotateModel = new System.Windows.Forms.ToolBarButton();
            this._ToolBarRotateCamera = new System.Windows.Forms.ToolBarButton();
            this._imageListToolBar = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._StatusBarPanelModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._StatusBarPanelAnimation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._StatusBarPanelKeyFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._StatusBarPanelFPS)).BeginInit();
            this._dockTools.SuspendLayout();
            this._dockShaderProperties.SuspendLayout();
            this._dockProperties.SuspendLayout();
            this._rightSandDock.SuspendLayout();
            this._dockScene.SuspendLayout();
            this._dockLights.SuspendLayout();
            this._dockBottom.SuspendLayout();
            this._dockAnimation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numericAnimationSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._scrollAnimation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._fRender)).BeginInit();
            this.SuspendLayout();
            // 
            // _menuMain
            // 
            this._menuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuFile,
            this._menuView,
            this._MenuItem1,
            this._menuHelp});
            // 
            // _menuFile
            // 
            this._menuFile.Index = 0;
            this._menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._mnOpen,
            this._mnSave,
            this._mnSaveAs,
            this._mnDivide2,
            this._mnCloseModel,
            this._mnQuit});
            this._menuFile.Text = "&File";
            // 
            // _mnOpen
            // 
            this._mnOpen.Index = 0;
            this._mnOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this._mnOpen.Text = "&Open";
            this._mnOpen.Click += new System.EventHandler(this.mnOpen_Click);
            // 
            // _mnSave
            // 
            this._mnSave.Index = 1;
            this._mnSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this._mnSave.Text = "&Save";
            this._mnSave.Click += new System.EventHandler(this.mnSave_Click);
            // 
            // _mnSaveAs
            // 
            this._mnSaveAs.Index = 2;
            this._mnSaveAs.Text = "Save &As";
            this._mnSaveAs.Click += new System.EventHandler(this.mnSaveAs_Click);
            // 
            // _mnDivide2
            // 
            this._mnDivide2.Index = 3;
            this._mnDivide2.Text = "-";
            // 
            // _mnCloseModel
            // 
            this._mnCloseModel.Index = 4;
            this._mnCloseModel.Text = "&Close Model";
            this._mnCloseModel.Click += new System.EventHandler(this.mnCloseModel_Click);
            // 
            // _mnQuit
            // 
            this._mnQuit.Index = 5;
            this._mnQuit.Text = "E&xit";
            this._mnQuit.Click += new System.EventHandler(this.mnQuit_Click);
            // 
            // _menuView
            // 
            this._menuView.Index = 1;
            this._menuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._mnShowProperties,
            this._mnShowLights,
            this._menuShowScene,
            this._mnShowTools,
            this._mnDivide1,
            this._mnShowAllWindows});
            this._menuView.Text = "&View";
            // 
            // _mnShowProperties
            // 
            this._mnShowProperties.Index = 0;
            this._mnShowProperties.Text = "Model Properties";
            this._mnShowProperties.Click += new System.EventHandler(this.mnShowProperties_Click);
            // 
            // _mnShowLights
            // 
            this._mnShowLights.Index = 1;
            this._mnShowLights.Text = "Light Properties";
            this._mnShowLights.Click += new System.EventHandler(this.mnShowLights_Click);
            // 
            // _menuShowScene
            // 
            this._menuShowScene.Index = 2;
            this._menuShowScene.Text = "Scene Properties";
            this._menuShowScene.Click += new System.EventHandler(this.menuShowScene_Click);
            // 
            // _mnShowTools
            // 
            this._mnShowTools.Index = 3;
            this._mnShowTools.Text = "Tool Window";
            this._mnShowTools.Click += new System.EventHandler(this.mnShowTools_Click);
            // 
            // _mnDivide1
            // 
            this._mnDivide1.Index = 4;
            this._mnDivide1.Text = "-";
            // 
            // _mnShowAllWindows
            // 
            this._mnShowAllWindows.Index = 5;
            this._mnShowAllWindows.Text = "All Windows";
            this._mnShowAllWindows.Click += new System.EventHandler(this.mnShowAllWindows_Click);
            // 
            // _MenuItem1
            // 
            this._MenuItem1.Index = 2;
            this._MenuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._MenuItem2,
            this._MenuItem3,
            this._MenuItem4,
            this._MenuItem5});
            this._MenuItem1.Text = "&Interface";
            // 
            // _MenuItem2
            // 
            this._MenuItem2.Index = 0;
            this._MenuItem2.Text = "Save Default UI";
            // 
            // _MenuItem3
            // 
            this._MenuItem3.Index = 1;
            this._MenuItem3.Text = "Reset Default UI";
            // 
            // _MenuItem4
            // 
            this._MenuItem4.Index = 2;
            this._MenuItem4.Text = "Save UI";
            // 
            // _MenuItem5
            // 
            this._MenuItem5.Index = 3;
            this._MenuItem5.Text = "Load UI";
            // 
            // _menuHelp
            // 
            this._menuHelp.Index = 3;
            this._menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._mnAbout});
            this._menuHelp.Text = "&Help";
            // 
            // _mnAbout
            // 
            this._mnAbout.Index = 0;
            this._mnAbout.Text = "About ModelView";
            this._mnAbout.Click += new System.EventHandler(this.mnAbout_Click);
            // 
            // _statusBarMain
            // 
            this._statusBarMain.Location = new System.Drawing.Point(0, 603);
            this._statusBarMain.Name = "_statusBarMain";
            this._statusBarMain.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this._StatusBarPanelModel,
            this._StatusBarPanelAnimation,
            this._StatusBarPanelKeyFrame,
            this._StatusBarPanelFPS});
            this._statusBarMain.ShowPanels = true;
            this._statusBarMain.Size = new System.Drawing.Size(760, 22);
            this._statusBarMain.TabIndex = 0;
            // 
            // _StatusBarPanelModel
            // 
            this._StatusBarPanelModel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this._StatusBarPanelModel.Name = "_StatusBarPanelModel";
            this._StatusBarPanelModel.Text = "No Model Open ...";
            this._StatusBarPanelModel.Width = 543;
            // 
            // _StatusBarPanelAnimation
            // 
            this._StatusBarPanelAnimation.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this._StatusBarPanelAnimation.Name = "_StatusBarPanelAnimation";
            this._StatusBarPanelAnimation.Text = "No Animation";
            this._StatusBarPanelAnimation.Width = 82;
            // 
            // _StatusBarPanelKeyFrame
            // 
            this._StatusBarPanelKeyFrame.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this._StatusBarPanelKeyFrame.Name = "_StatusBarPanelKeyFrame";
            this._StatusBarPanelKeyFrame.Text = "KeyFrame: 0";
            this._StatusBarPanelKeyFrame.Width = 79;
            // 
            // _StatusBarPanelFPS
            // 
            this._StatusBarPanelFPS.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this._StatusBarPanelFPS.Name = "_StatusBarPanelFPS";
            this._StatusBarPanelFPS.Text = "FPS:";
            this._StatusBarPanelFPS.Width = 39;
            // 
            // _propertiesMain
            // 
            this._propertiesMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._propertiesMain.HelpVisible = false;
            this._propertiesMain.LineColor = System.Drawing.SystemColors.ScrollBar;
            this._propertiesMain.Location = new System.Drawing.Point(0, 21);
            this._propertiesMain.Name = "_propertiesMain";
            this._propertiesMain.Size = new System.Drawing.Size(250, 499);
            this._propertiesMain.TabIndex = 10;
            this._propertiesMain.ToolbarVisible = false;
            // 
            // _comboGroups
            // 
            this._comboGroups.Dock = System.Windows.Forms.DockStyle.Top;
            this._comboGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboGroups.Location = new System.Drawing.Point(0, 0);
            this._comboGroups.Name = "_comboGroups";
            this._comboGroups.Size = new System.Drawing.Size(250, 21);
            this._comboGroups.TabIndex = 11;
            this._comboGroups.SelectedIndexChanged += new System.EventHandler(this.comboGroups_SelectedIndexChanged);
            // 
            // _treeShaderParams
            // 
            this._treeShaderParams.ContextMenu = this._contextTreeView;
            this._treeShaderParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeShaderParams.LineColor = System.Drawing.Color.Empty;
            this._treeShaderParams.Location = new System.Drawing.Point(0, 21);
            this._treeShaderParams.Name = "_treeShaderParams";
            this._treeShaderParams.Size = new System.Drawing.Size(250, 499);
            this._treeShaderParams.Sorted = true;
            this._treeShaderParams.TabIndex = 0;
            this._treeShaderParams.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeShaderParams_AfterLabelEdit);
            this._treeShaderParams.DoubleClick += new System.EventHandler(this.treeShaderParams_DoubleClick);
            // 
            // _contextTreeView
            // 
            this._contextTreeView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._MenuItem6});
            // 
            // _MenuItem6
            // 
            this._MenuItem6.Index = 0;
            this._MenuItem6.Text = "Clear Texture";
            this._MenuItem6.Click += new System.EventHandler(this.MenuItem6_Click);
            // 
            // _comboShaderTechnique
            // 
            this._comboShaderTechnique.Dock = System.Windows.Forms.DockStyle.Top;
            this._comboShaderTechnique.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboShaderTechnique.Location = new System.Drawing.Point(0, 0);
            this._comboShaderTechnique.Name = "_comboShaderTechnique";
            this._comboShaderTechnique.Size = new System.Drawing.Size(250, 21);
            this._comboShaderTechnique.TabIndex = 1;
            this._comboShaderTechnique.SelectedIndexChanged += new System.EventHandler(this.comboShaderTechnique_SelectedIndexChanged);
            // 
            // _dockTools
            // 
            this._dockTools.AllowDockBottom = false;
            this._dockTools.AllowDockTop = false;
            this._dockTools.AutoScroll = true;
            this._dockTools.Controls.Add(this._btnAddMorphTargets);
            this._dockTools.Controls.Add(this._Button1);
            this._dockTools.Controls.Add(this._btnAnimationControl);
            this._dockTools.Controls.Add(this._labelActorTools);
            this._dockTools.Controls.Add(this._btnGeneratePRT);
            this._dockTools.Controls.Add(this._btnNormalmapGen);
            this._dockTools.Controls.Add(this._btnWeld);
            this._dockTools.Controls.Add(this._btnRemoveUV);
            this._dockTools.Controls.Add(this._labelMeshTools);
            this._dockTools.Controls.Add(this._btnComputeNormals);
            this._dockTools.Controls.Add(this._btnApplyDefaultMat);
            this._dockTools.Controls.Add(this._Button5);
            this._dockTools.Controls.Add(this._labelGlobalTools);
            this._dockTools.Controls.Add(this._Button4);
            this._dockTools.Controls.Add(this._Button3);
            this._dockTools.Controls.Add(this._Button2);
            this._dockTools.Controls.Add(this._Label1);
            this._dockTools.Guid = new System.Guid("cb3d55ff-1e57-4860-90fd-a7e2bcc053bc");
            this._dockTools.Location = new System.Drawing.Point(0, 16);
            this._dockTools.Name = "_dockTools";
            this._dockTools.ShowOptions = false;
            this._dockTools.Size = new System.Drawing.Size(250, 520);
            this._dockTools.TabIndex = 1;
            this._dockTools.Text = "Tools";
            this._dockTools.Closing += new TD.SandDock.DockControlClosingEventHandler(this.dockTools_Closing);
            // 
            // _btnAddMorphTargets
            // 
            this._btnAddMorphTargets.Dock = System.Windows.Forms.DockStyle.Top;
            this._btnAddMorphTargets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAddMorphTargets.Location = new System.Drawing.Point(0, 375);
            this._btnAddMorphTargets.Name = "_btnAddMorphTargets";
            this._btnAddMorphTargets.Size = new System.Drawing.Size(250, 23);
            this._btnAddMorphTargets.TabIndex = 5;
            this._btnAddMorphTargets.Text = "Add Morph Targets";
            this._btnAddMorphTargets.Click += new System.EventHandler(this.btnAddMorphTargets_Click);
            // 
            // _Button1
            // 
            this._Button1.Dock = System.Windows.Forms.DockStyle.Top;
            this._Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Button1.Location = new System.Drawing.Point(0, 352);
            this._Button1.Name = "_Button1";
            this._Button1.Size = new System.Drawing.Size(250, 23);
            this._Button1.TabIndex = 6;
            this._Button1.Text = "Control Morph Weight";
            this._Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // _btnAnimationControl
            // 
            this._btnAnimationControl.Dock = System.Windows.Forms.DockStyle.Top;
            this._btnAnimationControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAnimationControl.Location = new System.Drawing.Point(0, 329);
            this._btnAnimationControl.Name = "_btnAnimationControl";
            this._btnAnimationControl.Size = new System.Drawing.Size(250, 23);
            this._btnAnimationControl.TabIndex = 9;
            this._btnAnimationControl.Text = "Animation Ranges";
            this._btnAnimationControl.Click += new System.EventHandler(this.btnAnimationControl_Click);
            // 
            // _labelActorTools
            // 
            this._labelActorTools.Dock = System.Windows.Forms.DockStyle.Top;
            this._labelActorTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelActorTools.Location = new System.Drawing.Point(0, 306);
            this._labelActorTools.Name = "_labelActorTools";
            this._labelActorTools.Size = new System.Drawing.Size(250, 23);
            this._labelActorTools.TabIndex = 4;
            this._labelActorTools.Text = "Actor Tools:";
            // 
            // _btnGeneratePRT
            // 
            this._btnGeneratePRT.Dock = System.Windows.Forms.DockStyle.Top;
            this._btnGeneratePRT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnGeneratePRT.Location = new System.Drawing.Point(0, 282);
            this._btnGeneratePRT.Name = "_btnGeneratePRT";
            this._btnGeneratePRT.Size = new System.Drawing.Size(250, 24);
            this._btnGeneratePRT.TabIndex = 16;
            this._btnGeneratePRT.Text = "Generate PRT";
            this._btnGeneratePRT.Click += new System.EventHandler(this.btnGeneratePRT_Click);
            // 
            // _btnNormalmapGen
            // 
            this._btnNormalmapGen.Dock = System.Windows.Forms.DockStyle.Top;
            this._btnNormalmapGen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnNormalmapGen.Location = new System.Drawing.Point(0, 258);
            this._btnNormalmapGen.Name = "_btnNormalmapGen";
            this._btnNormalmapGen.Size = new System.Drawing.Size(250, 24);
            this._btnNormalmapGen.TabIndex = 0;
            this._btnNormalmapGen.Text = "Generate Normalmap";
            this._btnNormalmapGen.Click += new System.EventHandler(this.btnNormalmapGen_Click);
            // 
            // _btnWeld
            // 
            this._btnWeld.Dock = System.Windows.Forms.DockStyle.Top;
            this._btnWeld.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnWeld.Location = new System.Drawing.Point(0, 235);
            this._btnWeld.Name = "_btnWeld";
            this._btnWeld.Size = new System.Drawing.Size(250, 23);
            this._btnWeld.TabIndex = 1;
            this._btnWeld.Text = "Weld Mesh";
            this._btnWeld.Click += new System.EventHandler(this.btnWeld_Click);
            // 
            // _btnRemoveUV
            // 
            this._btnRemoveUV.Dock = System.Windows.Forms.DockStyle.Top;
            this._btnRemoveUV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnRemoveUV.Location = new System.Drawing.Point(0, 212);
            this._btnRemoveUV.Name = "_btnRemoveUV";
            this._btnRemoveUV.Size = new System.Drawing.Size(250, 23);
            this._btnRemoveUV.TabIndex = 2;
            this._btnRemoveUV.Text = "Remove UV";
            this._btnRemoveUV.Click += new System.EventHandler(this.btnRemoveUV_Click);
            // 
            // _labelMeshTools
            // 
            this._labelMeshTools.Dock = System.Windows.Forms.DockStyle.Top;
            this._labelMeshTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelMeshTools.Location = new System.Drawing.Point(0, 189);
            this._labelMeshTools.Name = "_labelMeshTools";
            this._labelMeshTools.Size = new System.Drawing.Size(250, 23);
            this._labelMeshTools.TabIndex = 3;
            this._labelMeshTools.Text = "Mesh Tools:";
            // 
            // _btnComputeNormals
            // 
            this._btnComputeNormals.Dock = System.Windows.Forms.DockStyle.Top;
            this._btnComputeNormals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnComputeNormals.Location = new System.Drawing.Point(0, 166);
            this._btnComputeNormals.Name = "_btnComputeNormals";
            this._btnComputeNormals.Size = new System.Drawing.Size(250, 23);
            this._btnComputeNormals.TabIndex = 10;
            this._btnComputeNormals.Text = "Compute Normals";
            this._btnComputeNormals.Click += new System.EventHandler(this.btnComputeNormals_Click);
            // 
            // _btnApplyDefaultMat
            // 
            this._btnApplyDefaultMat.Dock = System.Windows.Forms.DockStyle.Top;
            this._btnApplyDefaultMat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnApplyDefaultMat.Location = new System.Drawing.Point(0, 142);
            this._btnApplyDefaultMat.Name = "_btnApplyDefaultMat";
            this._btnApplyDefaultMat.Size = new System.Drawing.Size(250, 24);
            this._btnApplyDefaultMat.TabIndex = 8;
            this._btnApplyDefaultMat.Text = "Apply Default Material";
            this._btnApplyDefaultMat.Click += new System.EventHandler(this.btnComputeShadowData_Click);
            // 
            // _Button5
            // 
            this._Button5.Dock = System.Windows.Forms.DockStyle.Top;
            this._Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Button5.Location = new System.Drawing.Point(0, 118);
            this._Button5.Name = "_Button5";
            this._Button5.Size = new System.Drawing.Size(250, 24);
            this._Button5.TabIndex = 15;
            this._Button5.Text = "Save Stage1 Texture";
            this._Button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // _labelGlobalTools
            // 
            this._labelGlobalTools.Dock = System.Windows.Forms.DockStyle.Top;
            this._labelGlobalTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelGlobalTools.Location = new System.Drawing.Point(0, 95);
            this._labelGlobalTools.Name = "_labelGlobalTools";
            this._labelGlobalTools.Size = new System.Drawing.Size(250, 23);
            this._labelGlobalTools.TabIndex = 7;
            this._labelGlobalTools.Text = "Global Tools:";
            // 
            // _Button4
            // 
            this._Button4.Dock = System.Windows.Forms.DockStyle.Top;
            this._Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Button4.Location = new System.Drawing.Point(0, 71);
            this._Button4.Name = "_Button4";
            this._Button4.Size = new System.Drawing.Size(250, 24);
            this._Button4.TabIndex = 13;
            this._Button4.Text = "Flip Normalmap Binormal to DX";
            this._Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // _Button3
            // 
            this._Button3.Dock = System.Windows.Forms.DockStyle.Top;
            this._Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Button3.Location = new System.Drawing.Point(0, 47);
            this._Button3.Name = "_Button3";
            this._Button3.Size = new System.Drawing.Size(250, 24);
            this._Button3.TabIndex = 12;
            this._Button3.Text = "Flip Normalmap Normals";
            this._Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // _Button2
            // 
            this._Button2.Dock = System.Windows.Forms.DockStyle.Top;
            this._Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Button2.Location = new System.Drawing.Point(0, 23);
            this._Button2.Name = "_Button2";
            this._Button2.Size = new System.Drawing.Size(250, 24);
            this._Button2.TabIndex = 11;
            this._Button2.Text = "Flip Normalmap Tangent";
            this._Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // _Label1
            // 
            this._Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this._Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label1.Location = new System.Drawing.Point(0, 0);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(250, 23);
            this._Label1.TabIndex = 14;
            this._Label1.Text = "Normalmap Tools:";
            // 
            // _leftSandDock
            // 
            this._leftSandDock.LayoutSystem = new TD.SandDock.SplitLayoutSystem(250, 400, System.Windows.Forms.Orientation.Horizontal, new TD.SandDock.LayoutSystemBase[0]);
            this._leftSandDock.Location = new System.Drawing.Point(0, 0);
            this._leftSandDock.Manager = null;
            this._leftSandDock.Name = "_leftSandDock";
            this._leftSandDock.Size = new System.Drawing.Size(0, 0);
            this._leftSandDock.TabIndex = 14;
            // 
            // _dockShaderProperties
            // 
            this._dockShaderProperties.Controls.Add(this._treeShaderParams);
            this._dockShaderProperties.Controls.Add(this._comboShaderTechnique);
            this._dockShaderProperties.Guid = new System.Guid("5aeea28e-4e73-4a2e-8612-73d6aebc08da");
            this._dockShaderProperties.Location = new System.Drawing.Point(0, 16);
            this._dockShaderProperties.Name = "_dockShaderProperties";
            this._dockShaderProperties.Size = new System.Drawing.Size(250, 520);
            this._dockShaderProperties.TabIndex = 4;
            this._dockShaderProperties.Text = "Shader Parameters";
            // 
            // _dockProperties
            // 
            this._dockProperties.AllowDockBottom = false;
            this._dockProperties.AllowDockTop = false;
            this._dockProperties.Controls.Add(this._propertiesMain);
            this._dockProperties.Controls.Add(this._comboGroups);
            this._dockProperties.Guid = new System.Guid("f21c565c-ded4-4609-8754-a5c0481113e2");
            this._dockProperties.Location = new System.Drawing.Point(0, 16);
            this._dockProperties.Name = "_dockProperties";
            this._dockProperties.ShowOptions = false;
            this._dockProperties.Size = new System.Drawing.Size(250, 520);
            this._dockProperties.TabIndex = 0;
            this._dockProperties.Text = "Properties";
            // 
            // _dockManager
            // 
            this._dockManager.DockSystemContainer = this;
            this._dockManager.OwnerForm = this;
            // 
            // _rightSandDock
            // 
            this._rightSandDock.Controls.Add(this._dockScene);
            this._rightSandDock.Controls.Add(this._dockLights);
            this._rightSandDock.Dock = System.Windows.Forms.DockStyle.Right;
            this._rightSandDock.LayoutSystem = new TD.SandDock.SplitLayoutSystem(250, 400, System.Windows.Forms.Orientation.Vertical, new TD.SandDock.LayoutSystemBase[] {
            ((TD.SandDock.LayoutSystemBase)(new TD.SandDock.ControlLayoutSystem(250, 560, new TD.SandDock.DockControl[] {
                        ((TD.SandDock.DockControl)(this._dockScene)),
                        ((TD.SandDock.DockControl)(this._dockLights))}, this._dockLights)))});
            this._rightSandDock.Location = new System.Drawing.Point(506, 43);
            this._rightSandDock.Manager = this._dockManager;
            this._rightSandDock.Name = "_rightSandDock";
            this._rightSandDock.Size = new System.Drawing.Size(254, 560);
            this._rightSandDock.TabIndex = 10;
            // 
            // _dockScene
            // 
            this._dockScene.AllowDockBottom = false;
            this._dockScene.AllowDockTop = false;
            this._dockScene.Controls.Add(this._propertiesScene);
            this._dockScene.Controls.Add(this._btnSaveAsDefault);
            this._dockScene.Controls.Add(this._btnResetDefault);
            this._dockScene.Controls.Add(this._btnSaveSceneToFile);
            this._dockScene.Controls.Add(this._btnLoadSceneFromFile);
            this._dockScene.Guid = new System.Guid("edf1e578-5744-445b-a477-e1502c8f172e");
            this._dockScene.Location = new System.Drawing.Point(4, 16);
            this._dockScene.Name = "_dockScene";
            this._dockScene.ShowOptions = false;
            this._dockScene.Size = new System.Drawing.Size(250, 520);
            this._dockScene.TabIndex = 3;
            this._dockScene.Text = "Scene";
            // 
            // _propertiesScene
            // 
            this._propertiesScene.Dock = System.Windows.Forms.DockStyle.Fill;
            this._propertiesScene.HelpVisible = false;
            this._propertiesScene.LineColor = System.Drawing.SystemColors.ScrollBar;
            this._propertiesScene.Location = new System.Drawing.Point(0, 0);
            this._propertiesScene.Name = "_propertiesScene";
            this._propertiesScene.Size = new System.Drawing.Size(250, 424);
            this._propertiesScene.TabIndex = 11;
            this._propertiesScene.ToolbarVisible = false;
            // 
            // _btnSaveAsDefault
            // 
            this._btnSaveAsDefault.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._btnSaveAsDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSaveAsDefault.Location = new System.Drawing.Point(0, 424);
            this._btnSaveAsDefault.Name = "_btnSaveAsDefault";
            this._btnSaveAsDefault.Size = new System.Drawing.Size(250, 24);
            this._btnSaveAsDefault.TabIndex = 15;
            this._btnSaveAsDefault.Text = "Save as Default";
            this._btnSaveAsDefault.Click += new System.EventHandler(this.btnSaveAsDefault_Click);
            // 
            // _btnResetDefault
            // 
            this._btnResetDefault.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._btnResetDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnResetDefault.Location = new System.Drawing.Point(0, 448);
            this._btnResetDefault.Name = "_btnResetDefault";
            this._btnResetDefault.Size = new System.Drawing.Size(250, 24);
            this._btnResetDefault.TabIndex = 14;
            this._btnResetDefault.Text = "Reset Default";
            this._btnResetDefault.Click += new System.EventHandler(this.btnResetDefault_Click);
            // 
            // _btnSaveSceneToFile
            // 
            this._btnSaveSceneToFile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._btnSaveSceneToFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSaveSceneToFile.Location = new System.Drawing.Point(0, 472);
            this._btnSaveSceneToFile.Name = "_btnSaveSceneToFile";
            this._btnSaveSceneToFile.Size = new System.Drawing.Size(250, 24);
            this._btnSaveSceneToFile.TabIndex = 13;
            this._btnSaveSceneToFile.Text = "Save to File";
            this._btnSaveSceneToFile.Click += new System.EventHandler(this.btnSaveSceneToFile_Click);
            // 
            // _btnLoadSceneFromFile
            // 
            this._btnLoadSceneFromFile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._btnLoadSceneFromFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnLoadSceneFromFile.Location = new System.Drawing.Point(0, 496);
            this._btnLoadSceneFromFile.Name = "_btnLoadSceneFromFile";
            this._btnLoadSceneFromFile.Size = new System.Drawing.Size(250, 24);
            this._btnLoadSceneFromFile.TabIndex = 12;
            this._btnLoadSceneFromFile.Text = "Load from File";
            this._btnLoadSceneFromFile.Click += new System.EventHandler(this.btnLoadSceneFromFile_Click);
            // 
            // _dockLights
            // 
            this._dockLights.AllowDockBottom = false;
            this._dockLights.AllowDockTop = false;
            this._dockLights.Controls.Add(this._propertiesLights);
            this._dockLights.Controls.Add(this._btnAddLight);
            this._dockLights.Controls.Add(this._btnDeleteLight);
            this._dockLights.Controls.Add(this._btnSaveLightXML);
            this._dockLights.Controls.Add(this._btnLoadLightXML);
            this._dockLights.Controls.Add(this._comboLights);
            this._dockLights.Guid = new System.Guid("487fb39d-ce59-4c66-88c5-189db8cf558c");
            this._dockLights.Location = new System.Drawing.Point(4, 18);
            this._dockLights.Name = "_dockLights";
            this._dockLights.ShowOptions = false;
            this._dockLights.Size = new System.Drawing.Size(250, 518);
            this._dockLights.TabIndex = 2;
            this._dockLights.Text = "Lights";
            // 
            // _propertiesLights
            // 
            this._propertiesLights.Dock = System.Windows.Forms.DockStyle.Fill;
            this._propertiesLights.HelpVisible = false;
            this._propertiesLights.LineColor = System.Drawing.SystemColors.ScrollBar;
            this._propertiesLights.Location = new System.Drawing.Point(0, 21);
            this._propertiesLights.Name = "_propertiesLights";
            this._propertiesLights.Size = new System.Drawing.Size(250, 405);
            this._propertiesLights.TabIndex = 0;
            this._propertiesLights.ToolbarVisible = false;
            // 
            // _btnAddLight
            // 
            this._btnAddLight.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._btnAddLight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAddLight.Location = new System.Drawing.Point(0, 426);
            this._btnAddLight.Name = "_btnAddLight";
            this._btnAddLight.Size = new System.Drawing.Size(250, 23);
            this._btnAddLight.TabIndex = 3;
            this._btnAddLight.Text = "Add Light";
            this._btnAddLight.Click += new System.EventHandler(this.btnAddLight_Click);
            // 
            // _btnDeleteLight
            // 
            this._btnDeleteLight.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._btnDeleteLight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnDeleteLight.Location = new System.Drawing.Point(0, 449);
            this._btnDeleteLight.Name = "_btnDeleteLight";
            this._btnDeleteLight.Size = new System.Drawing.Size(250, 23);
            this._btnDeleteLight.TabIndex = 2;
            this._btnDeleteLight.Text = "Delete Light";
            this._btnDeleteLight.Click += new System.EventHandler(this.btnDeleteLight_Click);
            // 
            // _btnSaveLightXML
            // 
            this._btnSaveLightXML.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._btnSaveLightXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSaveLightXML.Location = new System.Drawing.Point(0, 472);
            this._btnSaveLightXML.Name = "_btnSaveLightXML";
            this._btnSaveLightXML.Size = new System.Drawing.Size(250, 23);
            this._btnSaveLightXML.TabIndex = 4;
            this._btnSaveLightXML.Text = "Save to File";
            this._btnSaveLightXML.Click += new System.EventHandler(this.btnSaveLightXML_Click);
            // 
            // _btnLoadLightXML
            // 
            this._btnLoadLightXML.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._btnLoadLightXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnLoadLightXML.Location = new System.Drawing.Point(0, 495);
            this._btnLoadLightXML.Name = "_btnLoadLightXML";
            this._btnLoadLightXML.Size = new System.Drawing.Size(250, 23);
            this._btnLoadLightXML.TabIndex = 5;
            this._btnLoadLightXML.Text = "Load from File";
            this._btnLoadLightXML.Click += new System.EventHandler(this.btnLoadLightXML_Click);
            // 
            // _comboLights
            // 
            this._comboLights.Dock = System.Windows.Forms.DockStyle.Top;
            this._comboLights.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboLights.Location = new System.Drawing.Point(0, 0);
            this._comboLights.Name = "_comboLights";
            this._comboLights.Size = new System.Drawing.Size(250, 21);
            this._comboLights.TabIndex = 1;
            this._comboLights.SelectedIndexChanged += new System.EventHandler(this.comboLights_SelectedIndexChanged);
            // 
            // _dockBottom
            // 
            this._dockBottom.Controls.Add(this._dockAnimation);
            this._dockBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._dockBottom.LayoutSystem = new TD.SandDock.SplitLayoutSystem(250, 400, System.Windows.Forms.Orientation.Horizontal, new TD.SandDock.LayoutSystemBase[] {
            ((TD.SandDock.LayoutSystemBase)(new TD.SandDock.ControlLayoutSystem(506, 100, new TD.SandDock.DockControl[] {
                        ((TD.SandDock.DockControl)(this._dockAnimation))}, this._dockAnimation)))});
            this._dockBottom.Location = new System.Drawing.Point(0, 499);
            this._dockBottom.Manager = this._dockManager;
            this._dockBottom.Name = "_dockBottom";
            this._dockBottom.Size = new System.Drawing.Size(506, 104);
            this._dockBottom.TabIndex = 13;
            this._dockBottom.Visible = false;
            this._dockBottom.Resize += new System.EventHandler(this.dockBottom_Resize);
            // 
            // _dockAnimation
            // 
            this._dockAnimation.AllowClose = false;
            this._dockAnimation.AllowCollapse = false;
            this._dockAnimation.AllowDockBottom = false;
            this._dockAnimation.AllowDockLeft = false;
            this._dockAnimation.AllowDockRight = false;
            this._dockAnimation.AllowDockTop = false;
            this._dockAnimation.AllowFloat = false;
            this._dockAnimation.Controls.Add(this._comboAnimations);
            this._dockAnimation.Controls.Add(this._numericAnimationSpeed);
            this._dockAnimation.Controls.Add(this._btnPlayForward);
            this._dockAnimation.Controls.Add(this._btnStopAnimation);
            this._dockAnimation.Controls.Add(this._btnPlayBackwards);
            this._dockAnimation.Controls.Add(this._scrollAnimation);
            this._dockAnimation.Guid = new System.Guid("1ecf9625-8a88-4f3f-b6a6-46dbc37986ac");
            this._dockAnimation.Location = new System.Drawing.Point(0, 22);
            this._dockAnimation.Name = "_dockAnimation";
            this._dockAnimation.ShowOptions = false;
            this._dockAnimation.Size = new System.Drawing.Size(506, 58);
            this._dockAnimation.TabIndex = 4;
            this._dockAnimation.Text = "Animation Control";
            // 
            // _comboAnimations
            // 
            this._comboAnimations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._comboAnimations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboAnimations.Location = new System.Drawing.Point(9, 5);
            this._comboAnimations.Name = "_comboAnimations";
            this._comboAnimations.Size = new System.Drawing.Size(294, 21);
            this._comboAnimations.TabIndex = 18;
            this._comboAnimations.SelectedIndexChanged += new System.EventHandler(this.comboAnimations_SelectedIndexChanged);
            // 
            // _numericAnimationSpeed
            // 
            this._numericAnimationSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._numericAnimationSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._numericAnimationSpeed.Location = new System.Drawing.Point(309, 5);
            this._numericAnimationSpeed.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._numericAnimationSpeed.Name = "_numericAnimationSpeed";
            this._numericAnimationSpeed.Size = new System.Drawing.Size(59, 20);
            this._numericAnimationSpeed.TabIndex = 17;
            this._numericAnimationSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._numericAnimationSpeed.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this._numericAnimationSpeed.ValueChanged += new System.EventHandler(this.numericAnimationSpeed_ValueChanged_1);
            this._numericAnimationSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericAnimationSpeed_KeyPress);
            // 
            // _btnPlayForward
            // 
            this._btnPlayForward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnPlayForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnPlayForward.ImageList = this._ImageListAnimation;
            this._btnPlayForward.Location = new System.Drawing.Point(453, 3);
            this._btnPlayForward.Name = "_btnPlayForward";
            this._btnPlayForward.Size = new System.Drawing.Size(40, 24);
            this._btnPlayForward.TabIndex = 16;
            this._btnPlayForward.Click += new System.EventHandler(this.btnPlayForward_Click_1);
            // 
            // _ImageListAnimation
            // 
            this._ImageListAnimation.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this._ImageListAnimation.ImageSize = new System.Drawing.Size(16, 16);
            this._ImageListAnimation.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // _btnStopAnimation
            // 
            this._btnStopAnimation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnStopAnimation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnStopAnimation.ImageList = this._ImageListAnimation;
            this._btnStopAnimation.Location = new System.Drawing.Point(414, 3);
            this._btnStopAnimation.Name = "_btnStopAnimation";
            this._btnStopAnimation.Size = new System.Drawing.Size(40, 24);
            this._btnStopAnimation.TabIndex = 15;
            this._btnStopAnimation.Click += new System.EventHandler(this.btnStopAnimation_Click_1);
            // 
            // _btnPlayBackwards
            // 
            this._btnPlayBackwards.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnPlayBackwards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnPlayBackwards.ImageList = this._ImageListAnimation;
            this._btnPlayBackwards.Location = new System.Drawing.Point(375, 3);
            this._btnPlayBackwards.Name = "_btnPlayBackwards";
            this._btnPlayBackwards.Size = new System.Drawing.Size(40, 24);
            this._btnPlayBackwards.TabIndex = 14;
            this._btnPlayBackwards.Click += new System.EventHandler(this.btnPlayBackwards_Click_1);
            // 
            // _scrollAnimation
            // 
            this._scrollAnimation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._scrollAnimation.AutoSize = false;
            this._scrollAnimation.LargeChange = 1;
            this._scrollAnimation.Location = new System.Drawing.Point(1, 29);
            this._scrollAnimation.Maximum = 100;
            this._scrollAnimation.Name = "_scrollAnimation";
            this._scrollAnimation.Size = new System.Drawing.Size(499, 21);
            this._scrollAnimation.TabIndex = 19;
            this._scrollAnimation.TickStyle = System.Windows.Forms.TickStyle.None;
            this._scrollAnimation.Scroll += new System.EventHandler(this.scrollAnimation_Scroll_1);
            // 
            // _DockableWindow1
            // 
            this._DockableWindow1.Guid = new System.Guid("341e3131-7aa5-42ea-808e-7c504bb8dc7c");
            this._DockableWindow1.Location = new System.Drawing.Point(0, 0);
            this._DockableWindow1.Name = "_DockableWindow1";
            this._DockableWindow1.Size = new System.Drawing.Size(250, 400);
            this._DockableWindow1.TabIndex = 0;
            this._DockableWindow1.Text = "DockableWindow1";

            //
            // _leftSandDock
            //
            _leftSandDock.Controls.Add(_dockProperties);
			_leftSandDock.Controls.Add(_dockShaderProperties);
			_leftSandDock.Controls.Add(_dockTools);
		    _leftSandDock.Dock = DockStyle.Left;
            //LayoutSystemBase baseArray3 = new LayoutSystemBase[1];
            //DockControl controlArray3 = new DockControl[] { _dockProperties, _dockShaderProperties, _dockTools };
            //ControlLayoutSystem baseArray3[0] = new ControlLayoutSystem(, , controlArray3 , _dockTools);

            
            
            this._leftSandDock.LayoutSystem = new TD.SandDock.SplitLayoutSystem(0xfa, 0x190, System.Windows.Forms.Orientation.Vertical, new TD.SandDock.LayoutSystemBase[] {
            ((TD.SandDock.LayoutSystemBase)(new TD.SandDock.ControlLayoutSystem(0xfa, 0x230, new TD.SandDock.DockControl[] {
                        ((TD.SandDock.DockControl)(this._dockProperties)),
                        ((TD.SandDock.DockControl)(this._dockShaderProperties)),
                        ((TD.SandDock.DockControl)(this._dockTools))}, this._dockTools)))});
            
            _leftSandDock.Location = new Point(10, 0x2b);
            _leftSandDock.Manager = _dockManager;
            _leftSandDock.Size = new Size(0xfe, 0x230);
            //_leftSandDock.TabIndex = 9;
            // 
            // _fRender
            // 
            this._fRender.BackColor = System.Drawing.Color.Silver;
            this._fRender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._fRender.Dock = System.Windows.Forms.DockStyle.Fill;
            this._fRender.Location = new System.Drawing.Point(0, 43);
            this._fRender.Name = "_fRender";
            this._fRender.Size = new System.Drawing.Size(506, 456);
            this._fRender.TabIndex = 3;
            this._fRender.TabStop = false;
            // 
            // _mainToolBar
            // 
            this._mainToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this._mainToolBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._mainToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this._ToolBarOpen,
            this._ToolBarSave,
            this._ToolBarSaveAs,
            this._ToolBarCloseModel,
            this._ToolBarSeparator1,
            this._ToolBarRotateModel,
            this._ToolBarRotateCamera});
            this._mainToolBar.DropDownArrows = true;
            this._mainToolBar.ImageList = this._imageListToolBar;
            this._mainToolBar.Location = new System.Drawing.Point(0, 0);
            this._mainToolBar.Name = "_mainToolBar";
            this._mainToolBar.ShowToolTips = true;
            this._mainToolBar.Size = new System.Drawing.Size(760, 43);
            this._mainToolBar.TabIndex = 11;
            this._mainToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.mainToolBar_ButtonClick);
            // 
            // _ToolBarOpen
            // 
            this._ToolBarOpen.ImageIndex = 0;
            this._ToolBarOpen.Name = "_ToolBarOpen";
            this._ToolBarOpen.Text = "Open";
            this._ToolBarOpen.ToolTipText = "Open a Model File";
            // 
            // _ToolBarSave
            // 
            this._ToolBarSave.ImageIndex = 1;
            this._ToolBarSave.Name = "_ToolBarSave";
            this._ToolBarSave.Text = "Save";
            this._ToolBarSave.ToolTipText = "Save the Model File";
            // 
            // _ToolBarSaveAs
            // 
            this._ToolBarSaveAs.ImageIndex = 2;
            this._ToolBarSaveAs.Name = "_ToolBarSaveAs";
            this._ToolBarSaveAs.Text = "Save As";
            this._ToolBarSaveAs.ToolTipText = "Save your Model As...";
            // 
            // _ToolBarCloseModel
            // 
            this._ToolBarCloseModel.ImageIndex = 3;
            this._ToolBarCloseModel.Name = "_ToolBarCloseModel";
            this._ToolBarCloseModel.Text = "Close Model";
            // 
            // _ToolBarSeparator1
            // 
            this._ToolBarSeparator1.Name = "_ToolBarSeparator1";
            this._ToolBarSeparator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this._ToolBarSeparator1.Visible = false;
            // 
            // _ToolBarRotateModel
            // 
            this._ToolBarRotateModel.Name = "_ToolBarRotateModel";
            this._ToolBarRotateModel.Pushed = true;
            this._ToolBarRotateModel.Text = "Rotate Model";
            this._ToolBarRotateModel.Visible = false;
            // 
            // _ToolBarRotateCamera
            // 
            this._ToolBarRotateCamera.Name = "_ToolBarRotateCamera";
            this._ToolBarRotateCamera.Text = "Rotate Camera";
            this._ToolBarRotateCamera.Visible = false;
            // 
            // _imageListToolBar
            // 
            this._imageListToolBar.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this._imageListToolBar.ImageSize = new System.Drawing.Size(16, 16);
            this._imageListToolBar.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(760, 625);
            this.Controls.Add(this._fRender);
            this.Controls.Add(this._dockBottom);
            this.Controls.Add(this._rightSandDock);
            this.Controls.Add(this._leftSandDock);
            this.Controls.Add(this._mainToolBar);
            this.Controls.Add(this._statusBarMain);
            this.Menu = this._menuMain;
            this.Name = "frmMain";
            this.Text = "TV3D Model Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this._StatusBarPanelModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._StatusBarPanelAnimation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._StatusBarPanelKeyFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._StatusBarPanelFPS)).EndInit();
            this._dockTools.ResumeLayout(false);
            this._dockShaderProperties.ResumeLayout(false);
            this._dockProperties.ResumeLayout(false);
            this._rightSandDock.ResumeLayout(false);
            this._dockScene.ResumeLayout(false);
            this._dockLights.ResumeLayout(false);
            this._dockBottom.ResumeLayout(false);
            this._dockAnimation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._numericAnimationSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._scrollAnimation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._fRender)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		
		private void frmMain_Closed (object sender, EventArgs e)
		{
			mComponents.eDoRender = mComponents.enumDoRender.Quit;
		}
		
		private void frmMain_Load (object sender, EventArgs e)
		{
			_propertiesMain.ToolbarVisible = true;
			_propertiesLights.ToolbarVisible = true;
			_propertiesScene.ToolbarVisible = true;
			mComponents.pCSceneProperties = new cSceneProperties();
			_propertiesScene.SelectedObject = mComponents.pCSceneProperties;
			mGlobalProperties.sDockLayoutDefault = _dockManager.GetLayout();
			if (File.Exists(Application.StartupPath + @"\default.mvui"))
			{
				string text1 = "";
				mGlobalProperties.sDockLayout = mMain.GetFileContents(Application.StartupPath + @"\default.mvui", ref text1);
				try
				{
					_dockManager.SetLayout(mGlobalProperties.sDockLayout);
				}
				catch (Exception exception2)
				{
					ProjectData.SetProjectError(exception2);
					Exception exception1 = exception2;
					_dockManager.SetLayout(mGlobalProperties.sDockLayoutDefault);
					mMain.SaveTextToFile(mGlobalProperties.sDockLayoutDefault, Application.StartupPath + @"\default.mvui", "");
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				mMain.SaveTextToFile(mGlobalProperties.sDockLayoutDefault, Application.StartupPath + @"\default.mvui", "");
			}
			if (File.Exists(Application.StartupPath + @"\default.mvsp"))
			{
				this.GetSceneOption(Application.StartupPath + @"\default.mvsp");
			}
			else
			{
				this.SetSceneOption(Application.StartupPath + @"\default.mvsp");
			}
			//File file1 = null;
		}
		
		private void mnQuit_Click (object sender, EventArgs e)
		{
			mComponents.eDoRender = mComponents.enumDoRender.Quit;
		}
		
		private void mnOpen_Click (object sender, EventArgs e)
		{
			this.dlgOpenFile();
		}
		
		private void dlgOpenFile ()
		{
			_dlgOpen.Filter = "TV3D Files *.TVM, *.TVA|*.TVM;*.TVA|TVM Model *.TVM|*.TVM|TVA Model *.TVA|*.TVA|Static X Model *.X|*.X|Animated X Model *.X|*.X";
			if (_dlgOpen.ShowDialog(this) == DialogResult.OK)
			{
				Array.Clear(_propertiesMain.SelectedObjects, 0, _propertiesMain.SelectedObjects.Length);
				if (StringType.StrCmp(Strings.Right(Strings.UCase(_dlgOpen.FileName), 3), "TVM", false) == 0)
				{
					mTV3D.OpenFile(_dlgOpen.FileName, mTV3D.CONST_TV_FORMAT.TV_FORMAT_TVM);
				}
				else if (StringType.StrCmp(Strings.Right(Strings.UCase(_dlgOpen.FileName), 3), "TVA", false) == 0)
				{
					mTV3D.OpenFile(_dlgOpen.FileName, mTV3D.CONST_TV_FORMAT.TV_FORMAT_TVA);
				}
				else if ((StringType.StrCmp(Strings.Right(Strings.UCase(_dlgOpen.FileName), 1), "X", false) == 0) & (_dlgOpen.FilterIndex == 4))
				{
					mTV3D.OpenFile(_dlgOpen.FileName, mTV3D.CONST_TV_FORMAT.TV_FORMAT_SX);
				}
				else
				{
					if ((StringType.StrCmp(Strings.Right(Strings.UCase(_dlgOpen.FileName), 1), "X", false) == 0) & (_dlgOpen.FilterIndex == 5))
					{
						mTV3D.OpenFile(_dlgOpen.FileName, mTV3D.CONST_TV_FORMAT.TV_FORMAT_DX);
					}
				}
				mGlobalProperties.sModelFileName = _dlgOpen.FileName;
				_statusBarMain.Panels[0].Text = "Model Open: " + _dlgOpen.FileName;
			}
		}
		
		private void mnNormalMapGen_Click (object sender, EventArgs e)
		{
			mComponents.eDoRender = mComponents.enumDoRender.Pause;
			mComponents.pFrmNormalmapGen.ShowDialog();
		}
		
		private void mnCloseModel_Click (object sender, EventArgs e)
		{
			this.dlgCloseModel();
		}
		
		private void dlgCloseModel ()
		{
			_comboGroups.Items.Clear();
			_comboShaderTechnique.Items.Clear();
			_treeShaderParams.Nodes.Clear();
			mTV3D.CloseModel();
		}
		
		private void comboGroups_SelectedIndexChanged (object sender, EventArgs e)
		{
			if (_comboGroups.SelectedIndex == 0)
			{
				mGlobalProperties.iSelectedGroup = -1;
				if (mTV3D.bMeshOpen)
				{
					_propertiesMain.SelectedObject = mComponents.arrayCMeshProperties[0];
					int num12 = mComponents.pMesh.GetGroupCount();
					for (int i = 0;i <= num12; i++)
					{
						mComponents.pMesh.SetMaterial(mComponents.arrayMaterials[i], i);
					}
					if (mGlobalProperties.eLightMode == 0)
					{
						mComponents.pMesh.SetLightingMode(0);
					}
				}
				else
				{
					if (mTV3D.bActorOpen)
					{
						_propertiesMain.SelectedObject = mComponents.arrayCActorProperties[0];
						int num11 = mComponents.pActor.GetGroupCount();
						for (int j = 0;j <= num11; j++)
						{
							mComponents.pActor.SetMaterial(mComponents.arrayMaterials[j], j);
						}
						if (mGlobalProperties.eLightMode == 0)
						{
							mComponents.pActor.SetLightingMode(0);
						}
					}
				}
			}
			else
			{
				mGlobalProperties.iSelectedGroup = _comboGroups.SelectedIndex - 1;
				if (mTV3D.bMeshOpen)
				{
					_propertiesMain.SelectedObject = mComponents.arrayCMeshProperties[mGlobalProperties.iSelectedGroup + 1];
					if (mGlobalProperties.eLightMode == 0)
					{
						mComponents.pMesh.SetLightingMode(CONST_TV_LIGHTINGMODE.TV_LIGHTING_MANAGED );
						int num10 = mComponents.pMesh.GetGroupCount();
						for (int z = 0;z <= num10; z++)
						{
							mComponents.pMesh.SetMaterial(mComponents.arrayMaterials[z], z);
						}
						mComponents.pMesh.SetMaterial(mComponents.pG.GetMat("MaterialSelected"), mGlobalProperties.iSelectedGroup);
					}
					else
					{
						int num9 = mComponents.pMesh.GetGroupCount();
						for (int k = 0;k <= num9; k++)
						{
							mComponents.pMesh.SetMaterial(mComponents.arrayMaterials[k], k);
						}
						mComponents.pMesh.SetMaterial(mComponents.pG.GetMat("MaterialSelected"), mGlobalProperties.iSelectedGroup);
					}
				}
				else
				{
					if (mTV3D.bActorOpen)
					{
						_propertiesMain.SelectedObject = mComponents.arrayCActorProperties[mGlobalProperties.iSelectedGroup + 1];
						if (mGlobalProperties.eLightMode == 0)
						{
                            mComponents.pActor.SetLightingMode(CONST_TV_LIGHTINGMODE.TV_LIGHTING_MANAGED);
							int num8 = mComponents.pActor.GetGroupCount();
							for (int l = 0;l <= num8; l++)
							{
								mComponents.pActor.SetMaterial(mComponents.arrayMaterials[l], l);
							}
							mComponents.pActor.SetMaterial(mComponents.pG.GetMat("MaterialSelected"), mGlobalProperties.iSelectedGroup);
						}
						else
						{
							int num7 = mComponents.pActor.GetGroupCount();
							for (int a = 0;a <= num7; a++)
							{
								mComponents.pActor.SetMaterial(mComponents.arrayMaterials[a], a);
							}
							mComponents.pActor.SetMaterial(mComponents.pG.GetMat("MaterialSelected"), mGlobalProperties.iSelectedGroup);
						}
					}
				}
			}
			mTV3D.PopulateShaderParams();
		}
		
		private void btnNormalmapGen_Click (object sender, EventArgs e)
		{
			if (mTV3D.bMeshOpen)
			{
				mComponents.eDoRender = mComponents.enumDoRender.Pause;
				mComponents.pFrmNormalmapGen.ShowDialog();
			}
			else
			{
				Interaction.MsgBox("Please open a mesh before using this tool.", 0, null);
			}
		}
		
		private void btnWeld_Click (object sender, EventArgs e)
		{
			if (mTV3D.bMeshOpen)
			{
				mComponents.pMesh.WeldVertices(0.00F, 0.00F);
			}
			else
			{
				Interaction.MsgBox("Please open a mesh before using this tool.", 0, null);
			}
		}
		
		private void btnRemoveUV_Click (object sender, EventArgs e)
		{
			if (mTV3D.bMeshOpen)
			{
				mComponents.pMesh.SetMeshFormat(0x100);
			}
			else
			{
				Interaction.MsgBox("Please open a mesh before using this tool.", 0, null);
			}
		}
		
		private void btnAddLight_Click (object sender, EventArgs e)
		{
			mTV3D.AddLight();
		}
		
		private void comboLights_SelectedIndexChanged (object sender, EventArgs e)
		{
			if (mGlobalProperties.bInitedDone)
			{
				int num4 = Information.UBound(mComponents.arrayCLightProperties, 1);
				for (int i = 0;i <= num4; i++)
				{
					if (mComponents.arrayCLightProperties[i].iComboIndex == _comboLights.SelectedIndex)
					{
						_propertiesLights.SelectedObject = mComponents.arrayCLightProperties[i];
						int num3 = mComponents.pLightEngine.GetActiveCount() - 1;
						for (int j = 0;j <= num3; j++)
						{
							mComponents.arrayLightMesh[j].ShowBoundingBox(false);
						}
						mComponents.arrayLightMesh[i].ShowBoundingBox(true);
						return;
					}
				}
			}
		}
		
		private void btnDeleteLight_Click (object sender, EventArgs e)
		{
			if (mComponents.pLightEngine.GetActiveCount() != 0)
			{
				mTV3D.DeleteLight();
				int index = _comboLights.SelectedIndex;
				if ((index == 0) & (_comboLights.Items.Count != 0))
				{
					_comboLights.Items.RemoveAt(index);
					if (_comboLights.Items.Count != 0)
					{
						_comboLights.SelectedIndex = index;
					}
					else
					{
						_propertiesLights.SelectedObject = null;
					}
				}
				else
				{
					if (_comboLights.Items.Count != 0)
					{
						_comboLights.SelectedIndex = index - 1;
						_comboLights.Items.RemoveAt(index);
					}
				}
			}
		}
		
		private void btnAddMorphTargets_Click (object sender, EventArgs e)
		{
			if (mTV3D.bActorOpen)
			{
				mComponents.eDoRender = mComponents.enumDoRender.Pause;
				mComponents.pFrmMorphTargets.ShowDialog();
			}
			else
			{
				Interaction.MsgBox("Please open a actor-mesh before using this tool.", 0, null);
			}
		}
		
		private void mnSave_Click (object sender, EventArgs e)
		{
			this.dlgSaveFile();
		}
		
		private void dlgSaveFile ()
		{
			if (!mGlobalProperties.bDenySaveAs)
			{
				if (mTV3D.bMeshOpen)
				{
					mComponents.pMesh.SaveTVM(mGlobalProperties.sModelFileName);
				}
				if (mTV3D.bActorOpen)
				{
					mComponents.pActor.SaveTVA(mGlobalProperties.sModelFileName);
				}
			}
			else if (mTV3D.bActorOpen)
			{
				_dlgSave.Filter = "TVA Model *.TVA|*.TVA";
				if (_dlgSave.ShowDialog(this) == DialogResult.OK)
				{
					mComponents.pActor.SaveTVA(_dlgSave.FileName);
					_statusBarMain.Text = "Model Open: " + _dlgSave.FileName;
					mGlobalProperties.bDenySaveAs = false;
				}
			}
			else
			{
				if (mTV3D.bMeshOpen)
				{
					_dlgSave.Filter = "TVM Model *.TVM|*.TVM";
					if (_dlgSave.ShowDialog(this) == DialogResult.OK)
					{
						mComponents.pMesh.SaveTVM(_dlgSave.FileName);
						_statusBarMain.Text = "Model Open: " + _dlgSave.FileName;
						mGlobalProperties.bDenySaveAs = false;
					}
				}
			}
		}
		
		private void Button1_Click (object sender, EventArgs e)
		{
			if (mTV3D.bActorOpen)
			{
				if ((mComponents.pActor.MorphTarget_GetCount() == 0) | (mComponents.pActor.MorphTarget_GetCount() == 1))
				{
					Interaction.MsgBox("Please add at least one morph target before using this tool.", 0, null);
				}
				else
				{
					new frmMorphSlider().Show();
				}
			}
			else
			{
				Interaction.MsgBox("Please open a actor-mesh before using this tool.", 0, null);
			}
		}
		
		private void fRender_MouseDown (object sender, MouseEventArgs e)
		{
			mGlobalProperties.bDoInput = true;
		}
		
		private void btnComputeShadowData_Click (object sender, EventArgs e)
		{
			if (mTV3D.bMeshOpen)
			{
				mComponents.pMesh.SetMaterial(mComponents.pG.GetMat("Material1"));
			}
			if (mTV3D.bActorOpen)
			{
				mComponents.pActor.SetMaterial(mComponents.pG.GetMat("Material1"));
			}
		}
		
		private void mnShowProperties_Click (object sender, EventArgs e)
		{
			_dockProperties.Open();
		}
		
		private void mnShowLights_Click (object sender, EventArgs e)
		{
			_dockLights.Open();
		}
		
		private void mnShowTools_Click (object sender, EventArgs e)
		{
			_dockTools.Open();
		}
		
		private void menuShowScene_Click (object sender, EventArgs e)
		{
			_dockScene.Open();
		}
		
		private void mnShowAllWindows_Click (object sender, EventArgs e)
		{
			_dockProperties.Open();
			_dockLights.Open();
			_dockTools.Open();
			_dockScene.Open();
		}
		
		private void mnSaveUI_Click (object sender, EventArgs e)
		{
			_dlgSave.Filter = "GUI Files *.MVUI|*.MVUI";
			if (_dlgSave.ShowDialog() == DialogResult.OK)
			{
				mGlobalProperties.sDockLayout = _dockManager.GetLayout();
				if (!mMain.SaveTextToFile(mGlobalProperties.sDockLayout, _dlgSave.FileName, ""))
				{
                    Interaction.MsgBox("Failed to save to file.", MsgBoxStyle.Exclamation, null);
				}
			}
		}
		
		private void mnLoadUI_Click (object sender, EventArgs e)
		{
			_dockManager.SetLayout(mGlobalProperties.sDockLayout);
			_dlgOpen.Filter = "GUI Files *.MVUI|*.MVUI";
			if (_dlgOpen.ShowDialog() == DialogResult.OK)
			{
				string text1 = "";
				mGlobalProperties.sDockLayout = mMain.GetFileContents(_dlgOpen.FileName, ref text1);
				_dockManager.SetLayout(mGlobalProperties.sDockLayout);
			}
		}
		
		private void menuSaveDefaultUI_Click (object sender, EventArgs e)
		{
			mGlobalProperties.sDockLayout = _dockManager.GetLayout();
			mMain.SaveTextToFile(mGlobalProperties.sDockLayout, Application.StartupPath + @"\default.mvui", "");
		}
		
		private void menuResetDefaultUI_Click (object sender, EventArgs e)
		{
			if (File.Exists(Application.StartupPath + @"\default.mvui"))
			{
				string text1 = "";
				mGlobalProperties.sDockLayout = mMain.GetFileContents(Application.StartupPath + @"\default.mvui", ref text1);
				_dockManager.SetLayout(mGlobalProperties.sDockLayout);
			}
			else
			{
				mGlobalProperties.sDockLayout = _dockManager.GetLayout();
				mMain.SaveTextToFile(mGlobalProperties.sDockLayout, Application.StartupPath + @"\default.mvui", "");
			}
			//File file1 = null;
		}
		
		private void btnSaveLightXML_Click (object sender, EventArgs e)
		{
			_dlgSave.Filter = "Light Files *.MDLT|*.MDLT";
			if (_comboLights.Items.Count > 0)
			{
				if ((_dlgSave.ShowDialog() == DialogResult.OK) && mGlobalProperties.bInitedDone)
				{
					mGlobalProperties.sOptionsFile = _dlgSave.FileName;
					mOptions.LoadOptions();
					mOptions.SetOption("iLightCount", StringType.FromInteger(Information.UBound(mComponents.arrayCLightProperties, 1)));
					mOptions.SetOption("fLightRadius", StringType.FromSingle(mComponents.fLightRadius));
					int num2 = Information.UBound(mComponents.arrayCLightProperties, 1);
					for (int i = 0;i <= num2; i++)
					{
						string str0 = "light" + StringType.FromInteger(i);
						mOptions.SetOption(str0 + "." + "bEnable", StringType.FromBoolean(mComponents.arrayCLightProperties[i].bEnable));
						mOptions.SetOption(str0 + "." + "eAmbient.r", StringType.FromSingle(mComponents.arrayCLightProperties[i].eAmbient.r));
						mOptions.SetOption(str0 + "." + "eAmbient.g", StringType.FromSingle(mComponents.arrayCLightProperties[i].eAmbient.g));
						mOptions.SetOption(str0 + "." + "eAmbient.b", StringType.FromSingle(mComponents.arrayCLightProperties[i].eAmbient.b));
						mOptions.SetOption(str0 + "." + "eAmbient.a", StringType.FromSingle(mComponents.arrayCLightProperties[i].eAmbient.a));
						mOptions.SetOption(str0 + "." + "eDiffuse.r", StringType.FromSingle(mComponents.arrayCLightProperties[i].eDiffuse.r));
						mOptions.SetOption(str0 + "." + "eDiffuse.g", StringType.FromSingle(mComponents.arrayCLightProperties[i].eDiffuse.g));
						mOptions.SetOption(str0 + "." + "eDiffuse.b", StringType.FromSingle(mComponents.arrayCLightProperties[i].eDiffuse.b));
						mOptions.SetOption(str0 + "." + "eDiffuse.a", StringType.FromSingle(mComponents.arrayCLightProperties[i].eDiffuse.a));
						mOptions.SetOption(str0 + "." + "eSpecular.r", StringType.FromSingle(mComponents.arrayCLightProperties[i].eSpecular.r));
						mOptions.SetOption(str0 + "." + "eSpecular.g", StringType.FromSingle(mComponents.arrayCLightProperties[i].eSpecular.g));
						mOptions.SetOption(str0 + "." + "eSpecular.b", StringType.FromSingle(mComponents.arrayCLightProperties[i].eSpecular.b));
						mOptions.SetOption(str0 + "." + "eSpecular.a", StringType.FromSingle(mComponents.arrayCLightProperties[i].eSpecular.a));
						mOptions.SetOption(str0 + "." + "eType", StringType.FromInteger((int)mComponents.arrayCLightProperties[i].eType));
						mOptions.SetOption(str0 + "." + "fPhi", StringType.FromSingle(mComponents.arrayCLightProperties[i].fPhi));
						mOptions.SetOption(str0 + "." + "fRange", StringType.FromSingle(mComponents.arrayCLightProperties[i].fRange));
						mOptions.SetOption(str0 + "." + "fTheta", StringType.FromSingle(mComponents.arrayCLightProperties[i].fTheta));
						mOptions.SetOption(str0 + "." + "sLocalName", mComponents.arrayCLightProperties[i].sLocalName);
						mOptions.SetOption(str0 + "." + "vAttenuation.x", StringType.FromSingle(mComponents.arrayCLightProperties[i].vAttenuation.x));
						mOptions.SetOption(str0 + "." + "vAttenuation.y", StringType.FromSingle(mComponents.arrayCLightProperties[i].vAttenuation.y));
						mOptions.SetOption(str0 + "." + "vAttenuation.z", StringType.FromSingle(mComponents.arrayCLightProperties[i].vAttenuation.z));
						mOptions.SetOption(str0 + "." + "vDirection.x", StringType.FromSingle(mComponents.arrayCLightProperties[i].vDirection.x));
						mOptions.SetOption(str0 + "." + "vDirection.y", StringType.FromSingle(mComponents.arrayCLightProperties[i].vDirection.y));
						mOptions.SetOption(str0 + "." + "vDirection.z", StringType.FromSingle(mComponents.arrayCLightProperties[i].vDirection.z));
						mOptions.SetOption(str0 + "." + "vPosition.x", StringType.FromSingle(mComponents.arrayCLightProperties[i].vPosition.x));
						mOptions.SetOption(str0 + "." + "vPosition.y", StringType.FromSingle(mComponents.arrayCLightProperties[i].vPosition.y));
						mOptions.SetOption(str0 + "." + "vPosition.z", StringType.FromSingle(mComponents.arrayCLightProperties[i].vPosition.z));
					}
					mOptions.SaveOptions();
				}
			}
			else
			{
				Interaction.MsgBox("Please Load or Add a light first.", MsgBoxStyle.OkOnly, null);
			}
		}
		
		private void btnLoadLightXML_Click (object sender, EventArgs e)
		{
			if (mTV3D.bMeshOpen | mTV3D.bActorOpen)
			{
				_dlgOpen.Filter = "Light Files *.MDLT|*.MDLT";
				if (_dlgOpen.ShowDialog() == DialogResult.OK)
				{
					mGlobalProperties.sOptionsFile = _dlgOpen.FileName;
					mOptions.LoadOptions();
					int num3 = Convert.ToInt32(RuntimeHelpers.GetObjectValue(mOptions.GetOption("iLightCount", "")));
					for (int i = 0;i <= num3; i++)
					{
						mTV3D.AddLight();
						int num2 = _comboLights.Items.Count - 1;
						string str0 = "light" + StringType.FromInteger(i);
						mComponents.arrayCLightProperties[num2].Enable = BooleanType.FromObject(mOptions.GetOption(str0 + "." + "bEnable", ""));
						mComponents.arrayCLightProperties[num2].AmbientRed = SingleType.FromObject(mOptions.GetOption(str0 + "." + "eAmbient.r", ""));
						mComponents.arrayCLightProperties[num2].AmbientGreen = SingleType.FromObject(mOptions.GetOption(str0 + "." + "eAmbient.g", ""));
						mComponents.arrayCLightProperties[num2].AmbientBlue = SingleType.FromObject(mOptions.GetOption(str0 + "." + "eAmbient.b", ""));
						mComponents.arrayCLightProperties[num2].AmbientAlpha = SingleType.FromObject(mOptions.GetOption(str0 + "." + "eAmbient.a", ""));
						mComponents.arrayCLightProperties[num2].DiffuseRed = SingleType.FromObject(mOptions.GetOption(str0 + "." + "eDiffuse.r", ""));
						mComponents.arrayCLightProperties[num2].DiffuseGreen = SingleType.FromObject(mOptions.GetOption(str0 + "." + "eDiffuse.g", ""));
						mComponents.arrayCLightProperties[num2].DiffuseBlue = SingleType.FromObject(mOptions.GetOption(str0 + "." + "eDiffuse.b", ""));
						mComponents.arrayCLightProperties[num2].DiffuseAlpha = SingleType.FromObject(mOptions.GetOption(str0 + "." + "eDiffuse.a", ""));
						mComponents.arrayCLightProperties[num2].SpecularRed = SingleType.FromObject(mOptions.GetOption(str0 + "." + "eSpecular.r", ""));
						mComponents.arrayCLightProperties[num2].SpecularGreen = SingleType.FromObject(mOptions.GetOption(str0 + "." + "eSpecular.g", ""));
						mComponents.arrayCLightProperties[num2].SpecularBlue = SingleType.FromObject(mOptions.GetOption(str0 + "." + "eSpecular.b", ""));
						mComponents.arrayCLightProperties[num2].SpecularAlpha = SingleType.FromObject(mOptions.GetOption(str0 + "." + "eSpecular.a", ""));
						mComponents.arrayCLightProperties[num2].Type = (CONST_TV_LIGHTTYPE) IntegerType.FromObject(mOptions.GetOption(str0 + "." + "eType", ""));
						mComponents.arrayCLightProperties[num2].Phi = SingleType.FromObject(mOptions.GetOption(str0 + "." + "fPhi", ""));
						mComponents.arrayCLightProperties[num2].Range = SingleType.FromObject(mOptions.GetOption(str0 + "." + "fRange", ""));
						mComponents.arrayCLightProperties[num2].Theta = SingleType.FromObject(mOptions.GetOption(str0 + "." + "fTheta", ""));
						mComponents.arrayCLightProperties[num2].Name = StringType.FromObject(mOptions.GetOption(str0 + "." + "sLocalName", ""));
						mComponents.arrayCLightProperties[num2].Att1 = SingleType.FromObject(mOptions.GetOption(str0 + "." + "vAttenuation.x", ""));
						mComponents.arrayCLightProperties[num2].Att2 = SingleType.FromObject(mOptions.GetOption(str0 + "." + "vAttenuation.y", ""));
						mComponents.arrayCLightProperties[num2].Att3 = SingleType.FromObject(mOptions.GetOption(str0 + "." + "vAttenuation.z", ""));
						mComponents.arrayCLightProperties[num2].DirectionX = SingleType.FromObject(mOptions.GetOption(str0 + "." + "vDirection.x", ""));
						mComponents.arrayCLightProperties[num2].DirectionY = SingleType.FromObject(mOptions.GetOption(str0 + "." + "vDirection.y", ""));
						mComponents.arrayCLightProperties[num2].DirectionZ = SingleType.FromObject(mOptions.GetOption(str0 + "." + "vDirection.z", ""));
						mComponents.arrayCLightProperties[num2].PositionX = SingleType.FromObject(mOptions.GetOption(str0 + "." + "vPosition.x", ""));
						mComponents.arrayCLightProperties[num2].PositionY = SingleType.FromObject(mOptions.GetOption(str0 + "." + "vPosition.y", ""));
						mComponents.arrayCLightProperties[num2].PositionZ = SingleType.FromObject(mOptions.GetOption(str0 + "." + "vPosition.z", ""));
					}
					mComponents.fLightRadius = Convert.ToSingle(RuntimeHelpers.GetObjectValue(mOptions.GetOption("fLightRadius", "")));
					mTV3D.TranslateLights(mComponents.fRadius / mComponents.fLightRadius);
					mComponents.fLightRadius = mComponents.fRadius;
					_propertiesLights.Update();
				}
			}
		}
		
		private void GetSceneOption (string sOptionsFileName)
		{
			mGlobalProperties.sOptionsFile = sOptionsFileName;
			mOptions.LoadOptions();
			mComponents.pCSceneProperties.TextureFilter = (CONST_TV_TEXTUREFILTER) IntegerType.FromObject(mOptions.GetOption("eTextureFilter", ""));
			mComponents.pCSceneProperties.DepthBuffer = (CONST_TV_DEPTHBUFFER) IntegerType.FromObject(mOptions.GetOption("eDepthBuffer", ""));
			mComponents.pCSceneProperties.Red = SingleType.FromObject(mOptions.GetOption("eBackgroundColor.r", ""));
			mComponents.pCSceneProperties.Green = SingleType.FromObject(mOptions.GetOption("eBackgroundColor.g", ""));
			mComponents.pCSceneProperties.Blue = SingleType.FromObject(mOptions.GetOption("eBackgroundColor.b", ""));
			mComponents.pCSceneProperties.RenderMode = (CONST_TV_RENDERMODE) IntegerType.FromObject(mOptions.GetOption("eRenderMode", ""));
			mComponents.pCSceneProperties.FOVAngleDegree = SingleType.FromObject(mOptions.GetOption("fFOV", ""));
			mComponents.pCSceneProperties.FarPlane = SingleType.FromObject(mOptions.GetOption("fFarPlane", ""));
			mComponents.pCSceneProperties.MipMapPrecision = SingleType.FromObject(mOptions.GetOption("fMipMapPrecision", ""));
			mComponents.pCSceneProperties.EnableSpecular = BooleanType.FromObject(mOptions.GetOption("bEnableSpecular", ""));
			mGlobalProperties.bGlow = BooleanType.FromObject(mOptions.GetOption("bGlow", ""));
			mComponents.pCSceneProperties.eTintGlow.r = SingleType.FromObject(mOptions.GetOption("eTintGlowRED", ""));
			mComponents.pCSceneProperties.eTintGlow.g = SingleType.FromObject(mOptions.GetOption("eTintGlowGREEN", ""));
			mComponents.pCSceneProperties.eTintGlow.b = SingleType.FromObject(mOptions.GetOption("eTintGlowBLUE", ""));
			mComponents.pCSceneProperties.fGlowIntensity = SingleType.FromObject(mOptions.GetOption("fGlowIntensity", ""));
			mComponents.pCSceneProperties.fGlowOffsetScale = SingleType.FromObject(mOptions.GetOption("fGlowOffsetScale", ""));
			mComponents.pCSceneProperties.FocalRange = SingleType.FromObject(mOptions.GetOption("fFocalRange", ""));
			mComponents.pCSceneProperties.FocalPlane = SingleType.FromObject(mOptions.GetOption("fFocalPlane", ""));
			mComponents.pCSceneProperties.BlurFactor = SingleType.FromObject(mOptions.GetOption("fDOFBlurFactor", ""));
			mGlobalProperties.bDOF = BooleanType.FromObject(mOptions.GetOption("bDOF", ""));
			_propertiesScene.SelectedObject = mComponents.pCSceneProperties;
		}
		
		private void SetSceneOption (string sOptionsFileName)
		{
			mGlobalProperties.sOptionsFile = sOptionsFileName;
			mOptions.LoadOptions();
			mOptions.SetOption("eTextureFilter", StringType.FromInteger((int)mComponents.pCSceneProperties.eTextureFilter));
            mOptions.SetOption("eDepthBuffer", StringType.FromInteger((int)mComponents.pCSceneProperties.eDepthBuffer));
			mOptions.SetOption("eBackgroundColor.r", StringType.FromSingle(mComponents.pCSceneProperties.eBackgroundColor.r));
			mOptions.SetOption("eBackgroundColor.g", StringType.FromSingle(mComponents.pCSceneProperties.eBackgroundColor.g));
			mOptions.SetOption("eBackgroundColor.b", StringType.FromSingle(mComponents.pCSceneProperties.eBackgroundColor.b));
            mOptions.SetOption("eRenderMode", StringType.FromInteger((int)mComponents.pCSceneProperties.eRenderMode));
			mOptions.SetOption("fFOV", StringType.FromSingle(mComponents.pCSceneProperties.fFOV));
			mOptions.SetOption("fFarPlane", StringType.FromSingle(mComponents.pCSceneProperties.fFarPlane));
			mOptions.SetOption("fMipMapPrecision", StringType.FromSingle(mComponents.pCSceneProperties.fMipMapPrecision));
			mOptions.SetOption("bEnableSpecular", StringType.FromBoolean(mComponents.pCSceneProperties.bEnableSpecular));
			mOptions.SetOption("bGlow", StringType.FromBoolean(mGlobalProperties.bGlow));
			mOptions.SetOption("eTintGlowRED", StringType.FromSingle(mComponents.pCSceneProperties.eTintGlow.r));
			mOptions.SetOption("eTintGlowGREEN", StringType.FromSingle(mComponents.pCSceneProperties.eTintGlow.g));
			mOptions.SetOption("eTintGlowBLUE", StringType.FromSingle(mComponents.pCSceneProperties.eTintGlow.b));
			mOptions.SetOption("fGlowIntensity", StringType.FromSingle(mComponents.pCSceneProperties.fGlowIntensity));
			mOptions.SetOption("fGlowOffsetScale", StringType.FromSingle(mComponents.pCSceneProperties.fGlowOffsetScale));
			mOptions.SetOption("fFocalRange", StringType.FromSingle(mComponents.pCSceneProperties.fFocalRange));
			mOptions.SetOption("fFocalPlane", StringType.FromSingle(mComponents.pCSceneProperties.fFocalPlane));
			mOptions.SetOption("fDOFBlurFactor", StringType.FromSingle(mComponents.pCSceneProperties.fDOFBlurFactor));
			mOptions.SetOption("bDOF", StringType.FromBoolean(mGlobalProperties.bDOF));
			mOptions.SaveOptions();
		}
		
		private void btnSaveAsDefault_Click (object sender, EventArgs e)
		{
			SetSceneOption(Application.StartupPath + @"\default.mvsp");
		}
		
		private void btnResetDefault_Click (object sender, EventArgs e)
		{
			this.GetSceneOption(Application.StartupPath + @"\default.mvsp");
		}
		
		private void btnSaveSceneToFile_Click (object sender, EventArgs e)
		{
			_dlgSave.Filter = "Scene Properties File *.MDSP|*.MDSP";
			if (_dlgSave.ShowDialog() == DialogResult.OK)
			{
				this.SetSceneOption(_dlgSave.FileName);
			}
		}
		
		private void btnLoadSceneFromFile_Click (object sender, EventArgs e)
		{
			_dlgOpen.Filter = "Scene Properties File *.MDSP|*.MDSP";
			if (_dlgOpen.ShowDialog() == DialogResult.OK)
			{
				this.GetSceneOption(_dlgOpen.FileName);
			}
		}
		
		private void mnSaveAs_Click (object sender, EventArgs e)
		{
			this.dlgSaveAsFile();
		}
		
		private void dlgSaveAsFile ()
		{
			if (mTV3D.bActorOpen)
			{
				_dlgSave.Filter = "TVA Model *.TVA|*.TVA";
				if (_dlgSave.ShowDialog(this) == DialogResult.OK)
				{
					mComponents.pActor.SaveTVA(_dlgSave.FileName);
				}
			}
			else
			{
				if (mTV3D.bMeshOpen)
				{
					_dlgSave.Filter = "TVM Model *.TVM|*.TVM";
					if (_dlgSave.ShowDialog(this) == DialogResult.OK)
					{
						mComponents.pMesh.SaveTVM(_dlgSave.FileName);
					}
				}
			}
		}
		
		private void btnAnimationControl_Click (object sender, EventArgs e)
		{
			if (mTV3D.bActorOpen)
			{
				mComponents.pFrmAnimationRanges.Show();
				mComponents.pFrmAnimationRanges.LoadRanges(true);
			}
			else
			{
				Interaction.MsgBox("Please open a animated actor before using this tool.", 0, null);
			}
		}
		
		private void fRender_MouseHover (object sender, EventArgs e)
		{
			mGlobalProperties.bMouseInRender = true;
		}
		
		private void fRender_MouseMove (object sender, MouseEventArgs e)
		{
			mGlobalProperties.bMouseInRender = true;
		}
		
		private void fRender_MouseLeave (object sender, EventArgs e)
		{
			mGlobalProperties.bMouseInRender = false;
		}
		
		private void frmMain_Activated (object sender, EventArgs e)
		{
			mComponents.eDoRender = mComponents.enumDoRender.Normal;
		}
		
		private void frmMain_Deactivate (object sender, EventArgs e)
		{
			if (mComponents.bClosingApp)
			{
				mComponents.eDoRender = mComponents.enumDoRender.Quit;
			}
			else
			{
				mComponents.eDoRender = mComponents.enumDoRender.Pause;
			}
		}
		
		private void frmMain_Closing (object sender, CancelEventArgs e)
		{
			mMain.SaveTextToFile(mGlobalProperties.sDockLayoutDefault, Application.StartupPath + @"\default.mvui", "");
			mComponents.bClosingApp = true;
			mComponents.eDoRender = mComponents.enumDoRender.Quit;
		}
		
		private void mainToolBar_ButtonClick (object sender, ToolBarButtonClickEventArgs e)
		{
			if (StringType.StrCmp(e.Button.Text, "Open", false) == 0)
			{
				this.dlgOpenFile();
			}
			if (StringType.StrCmp(e.Button.Text, "Save", false) == 0)
			{
				this.dlgSaveFile();
			}
			if (StringType.StrCmp(e.Button.Text, "Save As", false) == 0)
			{
				this.dlgSaveAsFile();
			}
			if (StringType.StrCmp(e.Button.Text, "Close Model", false) == 0)
			{
				this.dlgCloseModel();
			}
			if (StringType.StrCmp(e.Button.Text, "Rotate Model", false) == 0)
			{
				if (!e.Button.Pushed)
				{
					e.Button.Pushed = true;
					_mainToolBar.Buttons[6].Pushed = false;
					mComponents.bRotateModel = true;
					mComponents.bRotateCamera = false;
				}
			}
			else
			{
				if ((StringType.StrCmp(e.Button.Text, "Rotate Camera", false) == 0) && !e.Button.Pushed)
				{
					e.Button.Pushed = true;
					_mainToolBar.Buttons[5].Pushed = false;
					mComponents.bRotateModel = false;
					mComponents.bRotateCamera = true;
				}
			}
		}
		
		private void fRender_MouseUp (object sender, MouseEventArgs e)
		{
		}
		
		private void fRender_Click (object sender, EventArgs e)
		{
			mGlobalProperties.bDoInput = true;
		}
		
		private void numericAnimationSpeed_ValueChanged (object sender, EventArgs e)
		{
			if (mTV3D.bActorOpen)
			{
				mComponents.pActor.PlayAnimation((float) (DoubleType.FromString(_numericAnimationSpeed.Text) * 0.001));
			}
		}
		
		private void btnComputeNormals_Click (object sender, EventArgs e)
		{
			if (mTV3D.bMeshOpen | mTV3D.bActorOpen)
			{
				if (mTV3D.bMeshOpen)
				{
					mComponents.pMesh.ComputeNormals();
				}
				if (mTV3D.bActorOpen)
				{
					mComponents.pActor.ComputeNormals();
				}
			}
			else
			{
				Interaction.MsgBox("Please open a mesh or actor before using this tool.", 0, null);
			}
		}
		
		private void dockBottom_Resize (object sender, EventArgs e)
		{
			_dockBottom.Height = 0x50;
		}
		
		private void btnPlayForward_Click_1 (object sender, EventArgs e)
		{
			mGlobalProperties.bPlayBackwards = false;
			mComponents.pActor.SetAnimationLoop(true);
			mComponents.pActor.SetAnimationID(_comboAnimations.SelectedIndex);
			mComponents.pActor.SetKeyFrame((float) _scrollAnimation.Value);
			mComponents.pActor.Update();
			mComponents.pActor.PlayAnimation((float) (1 * (IntegerType.FromString(_numericAnimationSpeed.Text) * 0.01)));
			mComponents.bPlayingAnimation = true;
			_statusBarMain.Panels[1].Text = "Playing";
		}
		
		private void btnStopAnimation_Click_1 (object sender, EventArgs e)
		{
			mComponents.pActor.StopAnimation();
			mComponents.bPlayingAnimation = false;
			_statusBarMain.Panels[1].Text = "Stopped";
		}
		
		private void btnPlayBackwards_Click_1 (object sender, EventArgs e)
		{
			mGlobalProperties.bPlayBackwards = true;
			mComponents.pActor.SetAnimationLoop(true);
			mComponents.pActor.SetAnimationID(_comboAnimations.SelectedIndex);
			mComponents.pActor.SetKeyFrame((float) _scrollAnimation.Value);
			mComponents.pActor.Update();
			mComponents.pActor.PlayAnimation((float) -(1 * (IntegerType.FromString(_numericAnimationSpeed.Text) * 0.01)));
			mComponents.bPlayingAnimation = true;
			_statusBarMain.Panels[1].Text = "Playing";
		}
		
		private void numericAnimationSpeed_ValueChanged_1 (object sender, EventArgs e)
		{
			if (mTV3D.bActorOpen & mComponents.bPlayingAnimation)
			{
				if (mGlobalProperties.bPlayBackwards)
				{
					mComponents.pActor.PlayAnimation((float) -(1 * (IntegerType.FromString(_numericAnimationSpeed.Text) * 0.01)));
				}
				else
				{
					mComponents.pActor.PlayAnimation((float) (1 * (IntegerType.FromString(_numericAnimationSpeed.Text) * 0.01)));
				}
			}
		}
		
		private void numericAnimationSpeed_KeyPress (object sender, KeyPressEventArgs e)
		{
			if (!char.IsNumber(e.KeyChar) & (e.KeyChar.GetHashCode() != 0x80008))
			{
				e.Handled = true;
			}
		}
		
		private void scrollAnimation_Scroll_1 (object sender, EventArgs e)
		{
			if (mTV3D.bActorOpen)
			{
				if (mComponents.bPlayingAnimation)
				{
					mComponents.pActor.StopAnimation();
					mComponents.bPlayingAnimation = false;
					_statusBarMain.Panels[1].Text = "Stopped";
					mComponents.pActor.PlayAnimation();
					mComponents.pActor.SetKeyFrame((float) _scrollAnimation.Value);
					mComponents.pActor.Update();
					mComponents.pActor.StopAnimation();
				}
				else
				{
					mComponents.pActor.PlayAnimation();
					mComponents.pActor.SetKeyFrame((float) _scrollAnimation.Value);
					mComponents.pActor.Update();
					mComponents.pActor.StopAnimation();
				}
			}
		}
		
		private void treeShaderParams_DoubleClick (object sender, EventArgs e)
		{
			if ((_treeShaderParams.GetNodeCount(true) > 1) && (_treeShaderParams.SelectedNode.GetNodeCount(true) == 0))
			{
				string text1 = _treeShaderParams.SelectedNode.FullPath.Split(new char[]{'\\'})[0];
				if ((((StringType.StrCmp(text1, "UNKNOWN", false) != 0) & (StringType.StrCmp(text1, "MATRIX", false) != 0)) & (StringType.StrCmp(text1, "STRING", false) != 0)) & (StringType.StrCmp(text1, "TEXTURE", false) != 0))
				{
					_treeShaderParams.LabelEdit = true;
					_treeShaderParams.SelectedNode.BeginEdit();
				}
				if (StringType.StrCmp(text1, "TEXTURE", false) == 0)
				{
					_dlgOpen.Filter = "BMP,JPG,TGA *.BMP,*.JPG,*.TGA|*.BMP;*.JPG;*.TGA";
					if (_dlgOpen.ShowDialog(this) == DialogResult.OK)
					{
						int num1 = mComponents.pTextureFactory.LoadTexture(_dlgOpen.FileName);
						mComponents.arrayShaders[_comboGroups.SelectedIndex].SetEffectParamTexture(_treeShaderParams.SelectedNode.Parent.Text, num1);
						TV_TEXTURE tv_texture1 = mComponents.pTextureFactory.GetTextureInfo(num1);
						_treeShaderParams.SelectedNode.Text = tv_texture1.Filename;
					}
				}
			}
		}
		
		private void treeShaderParams_AfterLabelEdit (object sender, NodeLabelEditEventArgs e)
		{
        //    int num1;
        //    Exception exception1;
        //    int num2;
        //    int num3;
        //Label_0000:
        //    try
        //    {
        //        TV_4DVECTOR tv_dvector1;
        //        num1 = 0;
        //        if (_treeShaderParams.GetNodeCount(true) <= 1)
        //        {
        //            goto Label_0359;
        //        }
        //    Label_0018:
        //        num1 = 1;
        //        if (_treeShaderParams.SelectedNode.GetNodeCount(true) != 0)
        //        {
        //            goto Label_0359;
        //        }
        //    Label_0035:
        //        ProjectData.ClearProjectError();
        //        num3 = 1;
        //    Label_003D:
        //        num1 = 3;
        //        string text1 = _treeShaderParams.SelectedNode.FullPath.Split(new char[]{'\\'})[0];
        //    Label_006B:
        //        num1 = 4;
        //        e.Node.Text = e.Label;
        //    Label_007E:
        //        num1 = 5;
        //        _treeShaderParams.LabelEdit = false;
        //    Label_0090:
        //        num1 = 6;
        //        if (StringType.StrCmp(text1, "FLOAT", false) != 0)
        //        {
        //            goto Label_00D8;
        //        }
        //    Label_00A1:
        //        num1 = 7;
        //        mComponents.arrayShaders[_comboGroups.SelectedIndex].SetEffectParamFloat(e.Node.Parent.Text, SingleType.FromString(e.Label));
        //    Label_00D8:
        //        num1 = 9;
        //        if (StringType.StrCmp(text1, "INTEGER", false) != 0)
        //        {
        //            goto Label_0122;
        //        }
        //    Label_00EA:
        //        num1 = 10;
        //        mComponents.arrayShaders[_comboGroups.SelectedIndex].SetEffectParamInteger(e.Node.Parent.Text, IntegerType.FromString(e.Label));
        //    Label_0122:
        //        num1 = 12;
        //        if (StringType.StrCmp(text1, "BOOL", false) != 0)
        //        {
        //            goto Label_016C;
        //        }
        //    Label_0134:
        //        num1 = 13;
        //        mComponents.arrayShaders[_comboGroups.SelectedIndex].SetEffectParamBoolean(e.Node.Parent.Text, BooleanType.FromString(e.Label));
        //    Label_016C:
        //        num1 = 15;
        //        if (StringType.StrCmp(text1, "VECTOR", false) != 0)
        //        {
        //            goto Label_0359;
        //        }
        //    Label_0181:
        //        num1 = 0x10;
        //        tv_dvector1.w = SingleType.FromString(e.Node.Parent.Parent.Nodes[0].Nodes[0].Text);
        //    Label_01BB:
        //        num1 = 0x11;
        //        tv_dvector1.x = SingleType.FromString(e.Node.Parent.Parent.Nodes[1].Nodes[0].Text);
        //    Label_01F5:
        //        num1 = 0x12;
        //        tv_dvector1.y = SingleType.FromString(e.Node.Parent.Parent.Nodes[2].Nodes[0].Text);
        //    Label_022F:
        //        num1 = 0x13;
        //        tv_dvector1.z = SingleType.FromString(e.Node.Parent.Parent.Nodes[3].Nodes[0].Text);
        //    Label_0269:
        //        num1 = 0x14;
        //        mComponents.arrayShaders[_comboGroups.SelectedIndex].SetEffectParamVector4(e.Node.Parent.Parent.Text, tv_dvector1);
        //        goto Label_0359;
        //    Label_02A1:
        //        num2 = 0;
        //        switch (num2 + 1)
        //        {
        //            case 0:
        //            {
        //                goto Label_0000;
        //            }
        //            case 1:
        //            {
        //                goto Label_0018;
        //            }
        //            case 2:
        //            {
        //                goto Label_0035;
        //            }
        //            case 3:
        //            {
        //                goto Label_003D;
        //            }
        //            case 4:
        //            {
        //                goto Label_006B;
        //            }
        //            case 5:
        //            {
        //                goto Label_007E;
        //            }
        //            case 6:
        //            {
        //                goto Label_0090;
        //            }
        //            case 7:
        //            {
        //                goto Label_00A1;
        //            }
        //            case 8:
        //            case 9:
        //            {
        //                goto Label_00D8;
        //            }
        //            case 10:
        //            {
        //                goto Label_00EA;
        //            }
        //            case 11:
        //            case 12:
        //            {
        //                goto Label_0122;
        //            }
        //            case 13:
        //            {
        //                goto Label_0134;
        //            }
        //            case 14:
        //            case 15:
        //            {
        //                goto Label_016C;
        //            }
        //            case 0x10:
        //            {
        //                goto Label_0181;
        //            }
        //            case 0x11:
        //            {
        //                goto Label_01BB;
        //            }
        //            case 0x12:
        //            {
        //                goto Label_01F5;
        //            }
        //            case 0x13:
        //            {
        //                goto Label_022F;
        //            }
        //            case 0x14:
        //            {
        //                goto Label_0269;
        //            }
        //            case 0x15:
        //            case 0x16:
        //            case 0x17:
        //            case 0x18:
        //            {
        //                goto Label_0359;
        //            }
        //        }
        //    }
        //    catch (Exception exception2) 
        //    {
        //        ProjectData.SetProjectError(exception2);
        //        if (num2 != 0)
        //        {
        //            goto Label_0357;
        //        }
        //        num2 = num1;
        //        switch (num3)
        //        {
        //            case 0:
        //            {
        //                goto Label_0355;
        //            }
        //            case 1:
        //            {
        //                goto Label_02A1;
        //            }
        //        }
        //    Label_0355:
        //        throw;
        //    }
        //Label_0357:
        //    throw exception1;
        //Label_0359:
        //    if (num2 != 0)
        //    {
        //        ProjectData.ClearProjectError();
        //    }
		}
		
		private void MenuItem6_Click (object sender, EventArgs e)
		{
			if ((_treeShaderParams.GetNodeCount(true) > 1) && (_treeShaderParams.SelectedNode.GetNodeCount(true) == 0))
			{
				string text1 = _treeShaderParams.SelectedNode.FullPath.Split(new char[]{'\\'})[0];
				if (StringType.StrCmp(text1, "TEXTURE", false) == 0)
				{
					mComponents.arrayShaders[_comboGroups.SelectedIndex].SetEffectParamTexture(_treeShaderParams.SelectedNode.Parent.Text, 0);
					_treeShaderParams.SelectedNode.Text = "blank";
				}
			}
		}
		
		private void comboShaderTechnique_SelectedIndexChanged (object sender, EventArgs e)
		{
			if (_comboShaderTechnique.Items.Count > 0)
			{
				mComponents.arrayShaders[_comboGroups.SelectedIndex].SetTechniqueByID(_comboShaderTechnique.SelectedIndex);
			}
		}
		
		private void Button2_Click (object sender, EventArgs e)
		{
			if (!(!mTV3D.bMeshOpen & !mTV3D.bActorOpen) && (((StringType.StrCmp(mComponents.arrayCMeshProperties[_comboGroups.SelectedIndex].sNormalMap, "", false) != 0) | (StringType.StrCmp(mComponents.arrayCMeshProperties[_comboGroups.SelectedIndex].sStage1, "", false) != 0)) && mTV3D.bMeshOpen))
			{
				mComponents.pTextureFactory.ConvertNormalMap(mComponents.arrayCMeshProperties[_comboGroups.SelectedIndex].iStage1, false, false, true);
			}
		}
		
		private void Button3_Click (object sender, EventArgs e)
		{
			if (!(!mTV3D.bMeshOpen & !mTV3D.bActorOpen) && (((StringType.StrCmp(mComponents.arrayCMeshProperties[_comboGroups.SelectedIndex].sNormalMap, "", false) != 0) | (StringType.StrCmp(mComponents.arrayCMeshProperties[_comboGroups.SelectedIndex].sStage1, "", false) != 0)) && mTV3D.bMeshOpen))
			{
				mComponents.pTextureFactory.ConvertNormalMap(mComponents.arrayCMeshProperties[_comboGroups.SelectedIndex].iStage1, false, true, false);
			}
		}
		
		private void Button4_Click (object sender, EventArgs e)
		{
			if (!(!mTV3D.bMeshOpen & !mTV3D.bActorOpen) && (((StringType.StrCmp(mComponents.arrayCMeshProperties[_comboGroups.SelectedIndex].sNormalMap, "", false) != 0) | (StringType.StrCmp(mComponents.arrayCMeshProperties[_comboGroups.SelectedIndex].sStage1, "", false) != 0)) && mTV3D.bMeshOpen))
			{
				mComponents.pTextureFactory.ConvertNormalMap(mComponents.arrayCMeshProperties[_comboGroups.SelectedIndex].iStage1, true, false, false);
			}
		}
		
		private void Button5_Click (object sender, EventArgs e)
		{
			if ((mTV3D.bMeshOpen | mTV3D.bActorOpen) && ((StringType.StrCmp(mComponents.arrayCMeshProperties[_comboGroups.SelectedIndex].sNormalMap, "", false) != 0) | (StringType.StrCmp(mComponents.arrayCMeshProperties[_comboGroups.SelectedIndex].sStage1, "", false) != 0)))
			{
				_dlgSave.Filter = "JPG *.JPG|*.JPG|BMP *.BMP|*.BMP|DDS *.DDS|*.DDS";
				if (_dlgSave.ShowDialog() == DialogResult.OK)
				{
					string text1 = _dlgSave.FileName;
					if (_dlgSave.FilterIndex == 0)
					{
						mComponents.pTextureFactory.SaveTexture(mComponents.arrayCMeshProperties[_comboGroups.SelectedIndex].iStage1, text1, CONST_TV_IMAGEFORMAT.TV_IMAGE_JPG   );
					}
					else if (_dlgSave.FilterIndex == 1)
					{
						mComponents.pTextureFactory.SaveTexture(mComponents.arrayCMeshProperties[_comboGroups.SelectedIndex].iStage1, text1, CONST_TV_IMAGEFORMAT.TV_IMAGE_BMP );
					}
					else
					{
						mComponents.pTextureFactory.SaveTexture(mComponents.arrayCMeshProperties[_comboGroups.SelectedIndex].iStage1, text1, CONST_TV_IMAGEFORMAT.TV_IMAGE_DDS);
					}
				}
			}
		}
		
		private void btnGeneratePRT_Click (object sender, EventArgs e)
		{
			if (mTV3D.bMeshOpen)
			{
				mComponents.eDoRender = mComponents.enumDoRender.Pause;
				mComponents.pFrmPRTGen.ShowDialog();
			}
			else
			{
				Interaction.MsgBox("Please open a mesh before using this tool.", 0, null);
			}
		}
		
		private void comboAnimations_SelectedIndexChanged (object sender, EventArgs e)
		{
			_scrollAnimation.Maximum = (int) Math.Round((double) mComponents.pActor.GetAnimationLength(_comboAnimations.SelectedIndex));
			if (mComponents.bPlayingAnimation)
			{
				mComponents.pActor.BlendAnimationTo(_comboAnimations.SelectedIndex, 2.00F);
			}
			else
			{
				mComponents.pActor.SetAnimationID(_comboAnimations.SelectedIndex);
				mComponents.pActor.Update();
				mComponents.pActor.StopAnimation();
				_scrollAnimation.Value = 0;
				_statusBarMain.Panels[1].Text = "Stopped";
			}
		}
		
		private void dockTools_Closing (object sender, DockControlClosingEventArgs e)
		{
		}
		
		private void mnAbout_Click (object sender, EventArgs e)
		{
			frmAbout about1 = new frmAbout();
			about1.ShowDialog();
			about1 = null;
		}


		public virtual PictureBox fRender
		{
			get
			{
				return this._fRender;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._fRender != null)
				{
					this._fRender.MouseDown -= new MouseEventHandler(this.fRender_MouseDown);
					this._fRender.Click -= new EventHandler(this.fRender_Click);
					this._fRender.MouseUp -= new MouseEventHandler(this.fRender_MouseUp);
					this._fRender.MouseLeave -= new EventHandler(this.fRender_MouseLeave);
					this._fRender.MouseMove -= new MouseEventHandler(this.fRender_MouseMove);
					this._fRender.MouseHover -= new EventHandler(this.fRender_MouseHover);
				}
				this._fRender = value;
				if (this._fRender != null)
				{
					this._fRender.MouseDown += new MouseEventHandler(this.fRender_MouseDown);
					this._fRender.Click += new EventHandler(this.fRender_Click);
					this._fRender.MouseUp += new MouseEventHandler(this.fRender_MouseUp);
					this._fRender.MouseLeave += new EventHandler(this.fRender_MouseLeave);
					this._fRender.MouseMove += new MouseEventHandler(this.fRender_MouseMove);
					this._fRender.MouseHover += new EventHandler(this.fRender_MouseHover);
				}
			}
		}
	}
}

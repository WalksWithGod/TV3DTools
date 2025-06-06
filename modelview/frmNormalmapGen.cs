#region

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

#endregion

namespace ModelView
{
    public class frmNormalmapGen : Form
    {
        // Instance Fields
        [AccessedThroughProperty("btnGenerate")] private Button _btnGenerate;
        [AccessedThroughProperty("txtHighPoly")] private TextBox _txtHighPoly;
        [AccessedThroughProperty("btnBrowseHighPoly")] private Button _btnBrowseHighPoly;
        [AccessedThroughProperty("Label1")] private Label _Label1;
        [AccessedThroughProperty("labelStatus")] private Label _labelStatus;
        [AccessedThroughProperty("ProgressBar1")] private ProgressBar _ProgressBar1;
        [AccessedThroughProperty("cbAddHeight")] private CheckBox _cbAddHeight;
        [AccessedThroughProperty("btnCancel")] private Button _btnCancel;
        [AccessedThroughProperty("btnBrowseNormalmap")] private Button _btnBrowseNormalmap;
        [AccessedThroughProperty("cbSize")] private ComboBox _cbSize;
        [AccessedThroughProperty("txtNormalMap")] private TextBox _txtNormalMap;
        [AccessedThroughProperty("Label2")] private Label _Label2;
        [AccessedThroughProperty("Label4")] private Label _Label4;
        [AccessedThroughProperty("chkAntialias")] private CheckBox _chkAntialias;
        private int iHeight;
        private int iWidth;
        private object iIndex;
        private Thread t;
        private Thread t2;
        private bool bThreadStarted;
        private int iTime;
        private IContainer components;

        // Constructors
        public frmNormalmapGen()
        {
            base.Load += frmNormalmapGen_Load;
            base.Closing += frmNormalmapGen_Closing;
            iIndex = 3;
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
            Label1 = new Label();
            txtHighPoly = new TextBox();
            btnBrowseHighPoly = new Button();
            btnBrowseNormalmap = new Button();
            txtNormalMap = new TextBox();
            Label2 = new Label();
            btnCancel = new Button();
            btnGenerate = new Button();
            chkAntialias = new CheckBox();
            Label4 = new Label();
            cbSize = new ComboBox();
            cbAddHeight = new CheckBox();
            ProgressBar1 = new ProgressBar();
            labelStatus = new Label();
            SuspendLayout();
            Point point1 = new Point(0x18, 0x46);
            Label1.Location = point1;
            Label1.Name = "Label1";
            Size size1 = new Size(0x78, 0x17);
            Label1.Size = size1;
            Label1.TabIndex = 0;
            Label1.Text = "High Polyogon Model:";
            txtHighPoly.Enabled = false;
            point1 = new Point(0x98, 0x46);
            txtHighPoly.Location = point1;
            txtHighPoly.Name = "txtHighPoly";
            size1 = new Size(0xd0, 0x14);
            txtHighPoly.Size = size1;
            txtHighPoly.TabIndex = 1;
            txtHighPoly.Text = "";
            point1 = new Point(0x175, 0x46);
            btnBrowseHighPoly.Location = point1;
            btnBrowseHighPoly.Name = "btnBrowseHighPoly";
            btnBrowseHighPoly.TabIndex = 2;
            btnBrowseHighPoly.Text = "Browse...";
            point1 = new Point(0x175, 0x76);
            btnBrowseNormalmap.Location = point1;
            btnBrowseNormalmap.Name = "btnBrowseNormalmap";
            btnBrowseNormalmap.TabIndex = 5;
            btnBrowseNormalmap.Text = "Save...";
            txtNormalMap.Enabled = false;
            point1 = new Point(0x98, 0x76);
            txtNormalMap.Location = point1;
            txtNormalMap.Name = "txtNormalMap";
            size1 = new Size(0xd0, 0x14);
            txtNormalMap.Size = size1;
            txtNormalMap.TabIndex = 4;
            txtNormalMap.Text = "";
            point1 = new Point(0x18, 0x76);
            Label2.Location = point1;
            Label2.Name = "Label2";
            size1 = new Size(0x78, 0x17);
            Label2.Size = size1;
            Label2.TabIndex = 3;
            Label2.Text = "Save Normal Map:";
            point1 = new Point(0x11d, 0xa8);
            btnCancel.Location = point1;
            btnCancel.Name = "btnCancel";
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            point1 = new Point(0x175, 0xa8);
            btnGenerate.Location = point1;
            btnGenerate.Name = "btnGenerate";
            btnGenerate.TabIndex = 7;
            btnGenerate.Text = "Generate";
            point1 = new Point(0x1a, 0x15);
            chkAntialias.Location = point1;
            chkAntialias.Name = "chkAntialias";
            size1 = new Size(0x56, 0x18);
            chkAntialias.Size = size1;
            chkAntialias.TabIndex = 8;
            chkAntialias.Text = "Antialiasing";
            point1 = new Point(0x11d, 0x1b);
            Label4.Location = point1;
            Label4.Name = "Label4";
            size1 = new Size(0x1e, 0x10);
            Label4.Size = size1;
            Label4.TabIndex = 12;
            Label4.Text = "Size:";
            cbSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSize.Items.AddRange(new object[] {"64x64", "128x128", "256x256", "512x512", "1024x1024", "2048x2048"});
            point1 = new Point(0x13a, 0x18);
            cbSize.Location = point1;
            cbSize.Name = "cbSize";
            size1 = new Size(0x88, 0x15);
            cbSize.Size = size1;
            cbSize.TabIndex = 14;
            point1 = new Point(0x88, 0x17);
            cbAddHeight.Location = point1;
            cbAddHeight.Name = "cbAddHeight";
            size1 = new Size(0x78, 0x18);
            cbAddHeight.Size = size1;
            cbAddHeight.TabIndex = 15;
            cbAddHeight.Text = "Add Height Detail";
            point1 = new Point(0x18, 0xc8);
            ProgressBar1.Location = point1;
            ProgressBar1.Name = "ProgressBar1";
            size1 = new Size(0x1a8, 0x17);
            ProgressBar1.Size = size1;
            ProgressBar1.TabIndex = 0x10;
            point1 = new Point(0x18, 0xb0);
            labelStatus.Location = point1;
            labelStatus.Name = "labelStatus";
            size1 = new Size(0xe0, 0x17);
            labelStatus.Size = size1;
            labelStatus.TabIndex = 0x11;
            size1 = new Size(5, 13);
            AutoScaleBaseSize = size1;
            size1 = new Size(0x1da, 0xf2);
            ClientSize = size1;
            Controls.Add(labelStatus);
            Controls.Add(ProgressBar1);
            Controls.Add(cbAddHeight);
            Controls.Add(cbSize);
            Controls.Add(Label4);
            Controls.Add(chkAntialias);
            Controls.Add(btnGenerate);
            Controls.Add(btnCancel);
            Controls.Add(btnBrowseNormalmap);
            Controls.Add(txtNormalMap);
            Controls.Add(txtHighPoly);
            Controls.Add(Label2);
            Controls.Add(btnBrowseHighPoly);
            Controls.Add(Label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmNormalmapGen";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Normalmap Generation Tool";
            ResumeLayout(false);
        }

        private void btnBrowseHighPoly_Click(object sender, EventArgs e)
        {
            mComponents.pFrmMain._dlgOpen.Filter = "TVM Model *.TVM|*.TVM|Static X Model *.X|*.X";
            if (mComponents.pFrmMain._dlgOpen.ShowDialog(this) == DialogResult.OK)
            {
                txtHighPoly.Text = mComponents.pFrmMain._dlgOpen.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (bThreadStarted)
            {
                mComponents.pMesh.CancelGeneration();
                labelStatus.Text = "";
                Cursor = Cursors.Arrow;
            }
            else
            {
                mComponents.eDoRender = mComponents.enumDoRender.Normal;
                Close();
            }
        }

        private void btnBrowseNormalmap_Click(object sender, EventArgs e)
        {
            mComponents.pFrmMain._dlgSave.Filter = "BMP File *.BMP|*.BMP";
            if (mComponents.pFrmMain._dlgSave.ShowDialog(this) == DialogResult.OK)
            {
                txtNormalMap.Text = mComponents.pFrmMain._dlgSave.FileName;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!mTV3D.bMeshOpen | mTV3D.bActorOpen)
            {
                Interaction.MsgBox("Please open a model before generating a normalmap.", MsgBoxStyle.OkOnly, "Error");
                mComponents.eDoRender = mComponents.enumDoRender.Normal;
                Close();
            }
            else if ((StringType.StrCmp(txtHighPoly.Text, "", false) == 0) |
                     (StringType.StrCmp(txtNormalMap.Text, "", false) == 0))
            {
                Interaction.MsgBox("Please select a high polygon model and a location to save the normalmap to.",
                                   MsgBoxStyle.OkOnly, "Error");
            }
            else
            {
                if (!bThreadStarted)
                {
                    t = new Thread(GenerateNormalMap);
                    t.Name = "Generation";
                    t.Start();
                }
            }
        }

        private void ProgressBar()
        {
            ProgressBar1.Value = 0;
            labelStatus.Text = "Processing Octree";
            btnCancel.Enabled = false;
            while (t.IsAlive & bThreadStarted)
            {
                Thread.Sleep(0x64);
                ProgressBar1.Value = (int) Math.Round((mComponents.pMesh.GetNormalMapGenerationProgress()*100.00F));
                if (ProgressBar1.Value != 0)
                {
                    int num1 =
                        (int)
                        Math.Round(((0x64 - ProgressBar1.Value)*
                                    ((((double) mComponents.pTV.TickCount())/1000000) -
                                     ((iTime)/((double) ProgressBar1.Value))))/1000);
                    labelStatus.Text = "Estimated Time Left: " + StringType.FromInteger(num1) + " seconds.";
                    btnCancel.Enabled = true;
                    continue;
                }
                labelStatus.Text = "Processing Octree";
            }
            labelStatus.Text = "";
        }

        private void GenerateNormalMap()
        {
            //int num1;
            //btnGenerate.Enabled = false;
            //bThreadStarted = true;
            //iTime = (int) Math.Round(((double) mComponents.pTV.TickCount())/1000000);
            //Cursor = Cursors.WaitCursor;
            //t2 = new Thread(ProgressBar);
            //t2.Name = "ProgressBar";
            //t2.Start();
            //mComponents.pMeshHigh = mComponents.pScene.CreateMeshBuilder("");
            //if (StringType.StrCmp(Strings.UCase(Strings.Right(txtHighPoly.Text, 4)), ".TVM", false) == 0)
            //{
            //    mComponents.pMeshHigh.LoadTVM(txtHighPoly.Text, false, false);
            //    mTV3D.bMeshHighOpen = true;
            //}
            //else
            //{
            //    if (StringType.StrCmp(Strings.UCase(Strings.Right(txtHighPoly.Text, 2)), ".X", false) == 0)
            //    {
            //        mComponents.pMeshHigh.LoadXFile(txtHighPoly.Text, false, false);
            //        mTV3D.bMeshHighOpen = true;
            //    }
            //}
            //if (!mTV3D.bMeshHighOpen)
            //{
            //    return;
            //}
            //switch (cbSize.SelectedIndex)
            //{
            //    case 0:
            //        {
            //            iWidth = 0x40;
            //            iHeight = 0x40;
            //            iIndex = 0;
            //            goto Label_0219;
            //        }
            //    case 1:
            //        {
            //            iWidth = 0x80;
            //            iHeight = 0x80;
            //            iIndex = 1;
            //            goto Label_0219;
            //        }
            //    case 2:
            //        {
            //            iWidth = 0x100;
            //            iHeight = 0x100;
            //            iIndex = 2;
            //            goto Label_0219;
            //        }
            //    case 3:
            //        {
            //            iWidth = 0x200;
            //            iHeight = 0x200;
            //            iIndex = 3;
            //            goto Label_0219;
            //        }
            //    case 4:
            //        {
            //            iWidth = 0x400;
            //            iHeight = 0x400;
            //            iIndex = 4;
            //            goto Label_0219;
            //        }
            //    case 5:
            //        {
            //            if (num1 != 0)
            //            {
            //                mGlobalProperties.eLightMode = (MTV3D65.CONST_TV_LIGHTINGMODE)4;
            //                mComponents.eDoRender = mComponents.enumDoRender.Normal;
            //                Close();
            //            }
            //            break;
            //        }
            //    default:
            //        {
            //            goto Label_0219;
            //        }
            //}
            //iWidth = 0x800;
            //iHeight = 0x800;
            //iIndex = 5;
            //Label_0219:
            //mComponents.pMeshHigh.SetMeshFormat(0x100);
            //mComponents.pMeshHigh.WeldVertices(0.00F, 0.00F);
            //mComponents.pMeshHigh.ComputeNormals();
            //num1 = mComponents.pMesh.GenerateNormalMap(mComponents.pMeshHigh, true, iWidth, iHeight,
            //                                           chkAntialias.Checked, cbAddHeight.Checked);
            //if (num1 != 0)
            //{
            //    ProgressBar1.Value = 0x64;
            //    Cursor = Cursors.Arrow;
            //    if (mComponents.pFrmMain._comboGroups.Items.Count > 1)
            //    {
            //        object obj1 = txtNormalMap.Text.Substring(0, txtNormalMap.Text.Length - 4);
            //        int num3 = mComponents.pFrmMain._comboGroups.Items.Count - 2;
            //        for (int i = 0; i <= num3; i++)
            //        {
            //            if (mComponents.pTextureFactory.SaveTexture(mComponents.pMesh.GetTextureEx(0x84, i),
            //                                                        StringType.FromObject(
            //                                                            ObjectType.AddObj(
            //                                                                ObjectType.AddObj(
            //                                                                    ObjectType.AddObj(obj1, "_group"),
            //                                                                    StringType.FromInteger(i)), ".BMP")), 0))
            //            {
            //                mComponents.arrayCMeshProperties[i + 1].Stage1 =
            //                    StringType.FromObject(
            //                        ObjectType.AddObj(
            //                            ObjectType.AddObj(ObjectType.AddObj(obj1, "_group"), StringType.FromInteger(i)),
            //                            ".BMP"));
            //                Interaction.MsgBox(
            //                    "Normalmap for group " + StringType.FromInteger(i) + " was successfully saved.", MsgBoxStyle.OkOnly,
            //                    "Success");
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (mComponents.pTextureFactory.SaveTexture(mComponents.pMesh.GetTextureEx(0x84, -1),
            //                                                    txtNormalMap.Text, 0))
            //        {
            //            mComponents.arrayCMeshProperties[0].Stage1 = txtNormalMap.Text;
            //            Interaction.MsgBox("Normalmap was successfully saved.", MsgBoxStyle.OkOnly, "Success");
            //        }
            //    }
            //}
            //mComponents.pMeshHigh.Destroy();
            //mComponents.pMeshHigh = null;
            //mTV3D.bMeshHighOpen = false;
            //bThreadStarted = false;
            //btnGenerate.Enabled = true;
        }

        private void frmNormalmapGen_Load(object sender, EventArgs e)
        {
            cbSize.SelectedIndex = IntegerType.FromObject(iIndex);
            ProgressBar1.Value = 0;
            labelStatus.Text = "";
        }

        private void frmNormalmapGen_Closing(object sender, CancelEventArgs e)
        {
            mComponents.eDoRender = mComponents.enumDoRender.Normal;
            Hide();
            e.Cancel = true;
        }


        // Properties
        internal virtual Label Label1
        {
            get { return _Label1; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label1 != null)
                {
                }
                _Label1 = value;
                if (_Label1 != null)
                {
                }
            }
        }

        internal virtual TextBox txtHighPoly
        {
            get { return _txtHighPoly; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtHighPoly != null)
                {
                }
                _txtHighPoly = value;
                if (_txtHighPoly != null)
                {
                }
            }
        }

        internal virtual Button btnBrowseHighPoly
        {
            get { return _btnBrowseHighPoly; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnBrowseHighPoly != null)
                {
                    _btnBrowseHighPoly.Click -= btnBrowseHighPoly_Click;
                }
                _btnBrowseHighPoly = value;
                if (_btnBrowseHighPoly != null)
                {
                    _btnBrowseHighPoly.Click += btnBrowseHighPoly_Click;
                }
            }
        }

        internal virtual Button btnBrowseNormalmap
        {
            get { return _btnBrowseNormalmap; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnBrowseNormalmap != null)
                {
                    _btnBrowseNormalmap.Click -= btnBrowseNormalmap_Click;
                }
                _btnBrowseNormalmap = value;
                if (_btnBrowseNormalmap != null)
                {
                    _btnBrowseNormalmap.Click += btnBrowseNormalmap_Click;
                }
            }
        }

        internal virtual TextBox txtNormalMap
        {
            get { return _txtNormalMap; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNormalMap != null)
                {
                }
                _txtNormalMap = value;
                if (_txtNormalMap != null)
                {
                }
            }
        }

        internal virtual Label Label2
        {
            get { return _Label2; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label2 != null)
                {
                }
                _Label2 = value;
                if (_Label2 != null)
                {
                }
            }
        }

        internal virtual Button btnCancel
        {
            get { return _btnCancel; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCancel != null)
                {
                    _btnCancel.Click -= btnCancel_Click;
                }
                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnCancel_Click;
                }
            }
        }

        internal virtual Button btnGenerate
        {
            get { return _btnGenerate; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnGenerate != null)
                {
                    _btnGenerate.Click -= btnGenerate_Click;
                }
                _btnGenerate = value;
                if (_btnGenerate != null)
                {
                    _btnGenerate.Click += btnGenerate_Click;
                }
            }
        }

        internal virtual CheckBox chkAntialias
        {
            get { return _chkAntialias; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkAntialias != null)
                {
                }
                _chkAntialias = value;
                if (_chkAntialias != null)
                {
                }
            }
        }

        internal virtual Label Label4
        {
            get { return _Label4; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label4 != null)
                {
                }
                _Label4 = value;
                if (_Label4 != null)
                {
                }
            }
        }

        internal virtual ComboBox cbSize
        {
            get { return _cbSize; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbSize != null)
                {
                }
                _cbSize = value;
                if (_cbSize != null)
                {
                }
            }
        }

        internal virtual CheckBox cbAddHeight
        {
            get { return _cbAddHeight; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbAddHeight != null)
                {
                }
                _cbAddHeight = value;
                if (_cbAddHeight != null)
                {
                }
            }
        }

        internal virtual ProgressBar ProgressBar1
        {
            get { return _ProgressBar1; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ProgressBar1 != null)
                {
                }
                _ProgressBar1 = value;
                if (_ProgressBar1 != null)
                {
                }
            }
        }

        internal virtual Label labelStatus
        {
            get { return _labelStatus; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_labelStatus != null)
                {
                }
                _labelStatus = value;
                if (_labelStatus != null)
                {
                }
            }
        }
    }
}
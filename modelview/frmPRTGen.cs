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
    public class frmPRTGen : Form
    {
        // Instance Fields
        [AccessedThroughProperty("Label5")] private Label _Label5;
        [AccessedThroughProperty("rbVertex")] private RadioButton _rbVertex;
        [AccessedThroughProperty("rbPerPixel")] private RadioButton _rbPerPixel;
        [AccessedThroughProperty("btnBrowseNormalmap")] private Button _btnBrowseNormalmap;
        [AccessedThroughProperty("Label3")] private Label _Label3;
        [AccessedThroughProperty("txtNormalMap")] private TextBox _txtNormalMap;
        [AccessedThroughProperty("Label2")] private Label _Label2;
        [AccessedThroughProperty("btnCancel")] private Button _btnCancel;
        [AccessedThroughProperty("btnGenerate")] private Button _btnGenerate;
        [AccessedThroughProperty("chkSSS")] private CheckBox _chkSSS;
        [AccessedThroughProperty("Label4")] private Label _Label4;
        [AccessedThroughProperty("Label1")] private Label _Label1;
        [AccessedThroughProperty("cbSize")] private ComboBox _cbSize;
        [AccessedThroughProperty("rayOrder")] private TextBox _rayOrder;
        [AccessedThroughProperty("txtRays")] private TextBox _txtRays;
        [AccessedThroughProperty("ProgressBar1")] private ProgressBar _ProgressBar1;
        [AccessedThroughProperty("txtBounces")] private TextBox _txtBounces;
        [AccessedThroughProperty("labelStatus")] private Label _labelStatus;
        [AccessedThroughProperty("chkUV")] private CheckBox _chkUV;
        private int iHeight;
        private int iWidth;
        private object iIndex;
        private Thread t;
        private Thread t2;
        private bool bThreadStarted;
        private int iTime;
        private IContainer components;

        // Constructors
        public frmPRTGen()
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
            btnBrowseNormalmap = new Button();
            txtNormalMap = new TextBox();
            Label2 = new Label();
            btnCancel = new Button();
            btnGenerate = new Button();
            Label4 = new Label();
            chkSSS = new CheckBox();
            cbSize = new ComboBox();
            rbPerPixel = new RadioButton();
            rbVertex = new RadioButton();
            Label1 = new Label();
            Label3 = new Label();
            Label5 = new Label();
            rayOrder = new TextBox();
            txtRays = new TextBox();
            txtBounces = new TextBox();
            chkUV = new CheckBox();
            labelStatus = new Label();
            ProgressBar1 = new ProgressBar();
            SuspendLayout();
            btnBrowseNormalmap.Enabled = false;
            Point point1 = new Point(0x175, 0xa0);
            btnBrowseNormalmap.Location = point1;
            btnBrowseNormalmap.Name = "btnBrowseNormalmap";
            btnBrowseNormalmap.TabIndex = 5;
            btnBrowseNormalmap.Text = "Save...";
            btnBrowseNormalmap.Visible = false;
            txtNormalMap.Enabled = false;
            point1 = new Point(0x98, 0xa0);
            txtNormalMap.Location = point1;
            txtNormalMap.Name = "txtNormalMap";
            Size size1 = new Size(0xd0, 0x14);
            txtNormalMap.Size = size1;
            txtNormalMap.TabIndex = 4;
            txtNormalMap.Text = "";
            txtNormalMap.Visible = false;
            Label2.Enabled = false;
            point1 = new Point(0x18, 0xa0);
            Label2.Location = point1;
            Label2.Name = "Label2";
            size1 = new Size(0x78, 0x17);
            Label2.Size = size1;
            Label2.TabIndex = 3;
            Label2.Text = "Save PRT Texture:";
            Label2.Visible = false;
            point1 = new Point(0x12d, 0x38);
            btnCancel.Location = point1;
            btnCancel.Name = "btnCancel";
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            point1 = new Point(0x185, 0x38);
            btnGenerate.Location = point1;
            btnGenerate.Name = "btnGenerate";
            btnGenerate.TabIndex = 7;
            btnGenerate.Text = "Generate";
            Label4.Enabled = false;
            point1 = new Point(0x18, 0xe0);
            Label4.Location = point1;
            Label4.Name = "Label4";
            size1 = new Size(0x1e, 0x10);
            Label4.Size = size1;
            Label4.TabIndex = 12;
            Label4.Text = "Size:";
            point1 = new Point(0x14c, 0x10);
            chkSSS.Location = point1;
            chkSSS.Name = "chkSSS";
            size1 = new Size(0x90, 0x18);
            chkSSS.Size = size1;
            chkSSS.TabIndex = 13;
            chkSSS.Text = "Sub Surface Scattering";
            cbSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSize.Enabled = false;
            cbSize.Items.AddRange(new object[] {"64x64", "128x128", "256x256", "512x512", "1024x1024", "2048x2048"});
            point1 = new Point(0x38, 0xe0);
            cbSize.Location = point1;
            cbSize.Name = "cbSize";
            size1 = new Size(0x68, 0x15);
            cbSize.Size = size1;
            cbSize.TabIndex = 14;
            point1 = new Point(0x18, 0xc0);
            rbPerPixel.Location = point1;
            rbPerPixel.Name = "rbPerPixel";
            size1 = new Size(0x48, 0x18);
            rbPerPixel.Size = size1;
            rbPerPixel.TabIndex = 15;
            rbPerPixel.Text = "Per Pixel";
            rbPerPixel.Visible = false;
            rbVertex.Checked = true;
            point1 = new Point(0x128, 0xc0);
            rbVertex.Location = point1;
            rbVertex.Name = "rbVertex";
            size1 = new Size(0x38, 0x18);
            rbVertex.Size = size1;
            rbVertex.TabIndex = 0x10;
            rbVertex.TabStop = true;
            rbVertex.Text = "Vertex";
            rbVertex.Visible = false;
            point1 = new Point(0x10, 0x18);
            Label1.Location = point1;
            Label1.Name = "Label1";
            size1 = new Size(0x28, 0x17);
            Label1.Size = size1;
            Label1.TabIndex = 0x11;
            Label1.Text = "Order:";
            point1 = new Point(0xd0, 0x18);
            Label3.Location = point1;
            Label3.Name = "Label3";
            size1 = new Size(0x38, 0x17);
            Label3.Size = size1;
            Label3.TabIndex = 0x12;
            Label3.Text = "Bounces:";
            point1 = new Point(0x68, 0x18);
            Label5.Location = point1;
            Label5.Name = "Label5";
            size1 = new Size(0x28, 0x17);
            Label5.Size = size1;
            Label5.TabIndex = 0x13;
            Label5.Text = "Rays:";
            point1 = new Point(0x38, 0x10);
            rayOrder.Location = point1;
            rayOrder.Name = "rayOrder";
            size1 = new Size(0x20, 0x14);
            rayOrder.Size = size1;
            rayOrder.TabIndex = 0x14;
            rayOrder.Text = "6";
            point1 = new Point(0x90, 0x10);
            txtRays.Location = point1;
            txtRays.Name = "txtRays";
            size1 = new Size(0x30, 0x14);
            txtRays.Size = size1;
            txtRays.TabIndex = 0x15;
            txtRays.Text = "1024";
            point1 = new Point(0x108, 0x10);
            txtBounces.Location = point1;
            txtBounces.Name = "txtBounces";
            size1 = new Size(0x20, 0x14);
            txtBounces.Size = size1;
            txtBounces.TabIndex = 0x16;
            txtBounces.Text = "1";
            chkUV.Checked = true;
            chkUV.CheckState = CheckState.Checked;
            chkUV.Enabled = false;
            point1 = new Point(0x90, 0xc0);
            chkUV.Location = point1;
            chkUV.Name = "chkUV";
            size1 = new Size(0x90, 0x18);
            chkUV.Size = size1;
            chkUV.TabIndex = 0x17;
            chkUV.Text = "Unique UV";
            chkUV.Visible = false;
            point1 = new Point(0x10, 0x40);
            labelStatus.Location = point1;
            labelStatus.Name = "labelStatus";
            size1 = new Size(0xe0, 0x17);
            labelStatus.Size = size1;
            labelStatus.TabIndex = 0x19;
            point1 = new Point(0x10, 0x58);
            ProgressBar1.Location = point1;
            ProgressBar1.Name = "ProgressBar1";
            size1 = new Size(0x1c0, 0x17);
            ProgressBar1.Size = size1;
            ProgressBar1.TabIndex = 0x18;
            size1 = new Size(5, 13);
            AutoScaleBaseSize = size1;
            size1 = new Size(0x1e2, 0x7a);
            ClientSize = size1;
            Controls.Add(labelStatus);
            Controls.Add(ProgressBar1);
            Controls.Add(chkUV);
            Controls.Add(txtBounces);
            Controls.Add(txtRays);
            Controls.Add(rayOrder);
            Controls.Add(txtNormalMap);
            Controls.Add(Label5);
            Controls.Add(Label3);
            Controls.Add(Label1);
            Controls.Add(rbVertex);
            Controls.Add(rbPerPixel);
            Controls.Add(cbSize);
            Controls.Add(chkSSS);
            Controls.Add(Label4);
            Controls.Add(btnGenerate);
            Controls.Add(btnCancel);
            Controls.Add(btnBrowseNormalmap);
            Controls.Add(Label2);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmPRTGen";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PRT Generation Tool";
            ResumeLayout(false);
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
            mComponents.pFrmMain._dlgSave.Filter = "DDS File *.DDS|*.DDS";
            if (mComponents.pFrmMain._dlgSave.ShowDialog(this) == DialogResult.OK)
            {
                txtNormalMap.Text = mComponents.pFrmMain._dlgSave.FileName;
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
                ProgressBar1.Value = (int) Math.Round((mComponents.pMesh.GetPRTComputationProgress()*100.00F));
                if (ProgressBar1.Value != 0)
                {
                    int num1 =
                        (int)
                        Math.Round(((0x64 - ProgressBar1.Value)*
                                    ((((double) mComponents.pTV.TickCount())/1000000) -
                                     ((iTime)/((double) ProgressBar1.Value))))/1000);
                    btnCancel.Enabled = true;
                    continue;
                }
                labelStatus.Text = "Processing Octree... Please wait.";
            }
            labelStatus.Text = "";
        }

        private void GenerateNormalMap()
        {
            //bool flag1;
            //btnGenerate.Enabled = false;
            //bThreadStarted = true;
            //iTime = (int) Math.Round(((double) mComponents.pTV.TickCount())/1000000);
            //Cursor = Cursors.WaitCursor;
            //t2 = new Thread(ProgressBar);
            //t2.Name = "ProgressBar";
            //t2.Start();
            //switch (cbSize.SelectedIndex)
            //{
            //    case 0:
            //        {
            //            iWidth = 0x40;
            //            iHeight = 0x40;
            //            iIndex = 0;
            //            goto Label_0175;
            //        }
            //    case 1:
            //        {
            //            iWidth = 0x80;
            //            iHeight = 0x80;
            //            iIndex = 1;
            //            goto Label_0175;
            //        }
            //    case 2:
            //        {
            //            iWidth = 0x100;
            //            iHeight = 0x100;
            //            iIndex = 2;
            //            goto Label_0175;
            //        }
            //    case 3:
            //        {
            //            iWidth = 0x200;
            //            iHeight = 0x200;
            //            iIndex = 3;
            //            goto Label_0175;
            //        }
            //    case 4:
            //        {
            //            iWidth = 0x400;
            //            iHeight = 0x400;
            //            iIndex = 4;
            //            goto Label_0175;
            //        }
            //    case 5:
            //        {
            //            if (flag1)
            //            {
            //                mGlobalProperties.eLightMode = (MTV3D65.CONST_TV_LIGHTINGMODE)6;
            //                mComponents.eDoRender = mComponents.enumDoRender.Normal;
            //                Close();
            //            }
            //            break;
            //        }
            //    default:
            //        {
            //            goto Label_0175;
            //        }
            //}
            //iWidth = 0x800;
            //iHeight = 0x800;
            //iIndex = 5;
            //Label_0175:
            //if (chkUV.Checked)
            //{
            //    mComponents.pMesh.GenerateUV(iWidth, iHeight, 0, 1);
            //}
            //if (rbVertex.Checked)
            //{
            //    flag1 = mComponents.pMesh.ComputePRT(chkSSS.Checked, Convert.ToInt32(rayOrder.Text),
            //                                         Convert.ToInt32(txtRays.Text),
            //                                         Convert.ToInt32(txtBounces.Text));
            //}
            //else
            //{
            //    flag1 = mComponents.pMesh.ComputePerPixelPRT(iWidth, iHeight, chkSSS.Checked,
            //                                                 Convert.ToInt32(rayOrder.Text),
            //                                                 Convert.ToInt32(txtRays.Text),
            //                                                 Convert.ToInt32(txtBounces.Text));
            //}
            //if (flag1)
            //{
            //    ProgressBar1.Value = 0x64;
            //    Cursor = Cursors.Arrow;
            //    if (!rbVertex.Checked)
            //    {
            //        object obj1 = txtNormalMap.Text.Substring(0, txtNormalMap.Text.Length - 4);
            //        int num1 = 1;
            //        do
            //        {
            //            mComponents.pTextureFactory.SaveTexture(mComponents.pMesh.GetTextureEx(num1),
            //                                                    StringType.FromObject(
            //                                                        ObjectType.AddObj(
            //                                                            ObjectType.AddObj(
            //                                                                ObjectType.AddObj(obj1, "_PRT"),
            //                                                                StringType.FromInteger(num1)), ".DDS")), MTV3D65.CONST_TV_IMAGEFORMAT.TV_IMAGE_DDS);
            //            num1++;
            //        } while (num1 <= 3);
            //        int num3 = mComponents.pFrmMain._comboGroups.Items.Count - 1;
            //        for (int i = 0; i <= num3; i++)
            //        {
            //            mComponents.arrayCMeshProperties[i].Stage1 =
            //                StringType.FromObject(ObjectType.AddObj(obj1, "_PRT1.DDS"));
            //            mComponents.arrayCMeshProperties[i].Stage2 =
            //                StringType.FromObject(ObjectType.AddObj(obj1, "_PRT2.DDS"));
            //            mComponents.arrayCMeshProperties[i].Stage3 =
            //                StringType.FromObject(ObjectType.AddObj(obj1, "_PRT3.DDS"));
            //        }
            //        Interaction.MsgBox("PRT textures for were successfully saved.", MsgBoxStyle.OkOnly, "Success");
            //    }
            //}
            //bThreadStarted = false;
            //btnGenerate.Enabled = true;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!rbVertex.Checked & (StringType.StrCmp(txtNormalMap.Text, "", false) == 0))
            {
                Interaction.MsgBox("Please select a location to save the PRT map to.", MsgBoxStyle.OkOnly, "Error");
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

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Label4.Enabled = true;
            cbSize.Enabled = true;
            Label2.Enabled = true;
            chkUV.Enabled = true;
            btnBrowseNormalmap.Enabled = true;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Label4.Enabled = false;
            cbSize.Enabled = false;
            Label2.Enabled = false;
            chkUV.Enabled = false;
            btnBrowseNormalmap.Enabled = false;
        }

        private void rayOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Information.IsNumeric(e.KeyChar) && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }

        private void rayOrder_TextChanged(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(rayOrder.Text) < 2) | (Convert.ToInt32(rayOrder.Text) > 6))
            {
                rayOrder.Text = StringType.FromInteger(6);
            }
        }

        private void txtRays_TextChanged(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(txtRays.Text) < 0x40) | (Convert.ToInt32(txtRays.Text) > 0x1000))
            {
                txtRays.Text = StringType.FromInteger(0x400);
            }
        }

        private void txtRays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Information.IsNumeric(e.KeyChar) && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }

        private void txtBounces_TextChanged(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(txtBounces.Text) < 1) | (Convert.ToInt32(txtBounces.Text) > 2))
            {
                txtBounces.Text = StringType.FromInteger(1);
            }
        }

        private void txtBounces_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Information.IsNumeric(e.KeyChar) && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }


        // Properties
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

        internal virtual CheckBox chkSSS
        {
            get { return _chkSSS; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkSSS != null)
                {
                }
                _chkSSS = value;
                if (_chkSSS != null)
                {
                }
            }
        }

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

        internal virtual Label Label5
        {
            get { return _Label5; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label5 != null)
                {
                }
                _Label5 = value;
                if (_Label5 != null)
                {
                }
            }
        }

        internal virtual TextBox rayOrder
        {
            get { return _rayOrder; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rayOrder != null)
                {
                    _rayOrder.TextChanged -= rayOrder_TextChanged;
                    _rayOrder.KeyPress -= rayOrder_KeyPress;
                }
                _rayOrder = value;
                if (_rayOrder != null)
                {
                    _rayOrder.TextChanged += rayOrder_TextChanged;
                    _rayOrder.KeyPress += rayOrder_KeyPress;
                }
            }
        }

        internal virtual TextBox txtRays
        {
            get { return _txtRays; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtRays != null)
                {
                    _txtRays.KeyPress -= txtRays_KeyPress;
                    _txtRays.TextChanged -= txtRays_TextChanged;
                }
                _txtRays = value;
                if (_txtRays != null)
                {
                    _txtRays.KeyPress += txtRays_KeyPress;
                    _txtRays.TextChanged += txtRays_TextChanged;
                }
            }
        }

        internal virtual TextBox txtBounces
        {
            get { return _txtBounces; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtBounces != null)
                {
                    _txtBounces.KeyPress -= txtBounces_KeyPress;
                    _txtBounces.TextChanged -= txtBounces_TextChanged;
                }
                _txtBounces = value;
                if (_txtBounces != null)
                {
                    _txtBounces.KeyPress += txtBounces_KeyPress;
                    _txtBounces.TextChanged += txtBounces_TextChanged;
                }
            }
        }

        internal virtual CheckBox chkUV
        {
            get { return _chkUV; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkUV != null)
                {
                }
                _chkUV = value;
                if (_chkUV != null)
                {
                }
            }
        }

        internal virtual RadioButton rbPerPixel
        {
            get { return _rbPerPixel; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rbPerPixel != null)
                {
                    _rbPerPixel.CheckedChanged -= RadioButton1_CheckedChanged;
                }
                _rbPerPixel = value;
                if (_rbPerPixel != null)
                {
                    _rbPerPixel.CheckedChanged += RadioButton1_CheckedChanged;
                }
            }
        }

        internal virtual RadioButton rbVertex
        {
            get { return _rbVertex; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rbVertex != null)
                {
                    _rbVertex.CheckedChanged -= RadioButton2_CheckedChanged;
                }
                _rbVertex = value;
                if (_rbVertex != null)
                {
                    _rbVertex.CheckedChanged += RadioButton2_CheckedChanged;
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
    }
}
#region

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

#endregion

namespace ModelView
{
    public class frmAnimationRanges : Form
    {
        // Instance Fields
        [AccessedThroughProperty("btnAddAnimationRange")] private Button _btnAddAnimationRange;
        [AccessedThroughProperty("comboAnimationRanges")] private ComboBox _comboAnimationRanges;
        [AccessedThroughProperty("btnDeleteAnimationRange")] private Button _btnDeleteAnimationRange;
        [AccessedThroughProperty("btnCompileAnimationRanges")] private Button _btnCompileAnimationRanges;
        [AccessedThroughProperty("propertiesAnimationRange")] private PropertyGrid _propertiesAnimationRange;
        private IContainer components;

        // Constructors
        public frmAnimationRanges()
        {
            base.Closing += frmAnimationRanges_Closing;
            base.Load += frmAnimationRanges_Load;
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
            _propertiesAnimationRange = new PropertyGrid();
            _comboAnimationRanges = new ComboBox();
            _btnCompileAnimationRanges = new Button();
            _btnDeleteAnimationRange = new Button();
            _btnAddAnimationRange = new Button();
            SuspendLayout();
            _propertiesAnimationRange.CommandsVisibleIfAvailable = true;
            _propertiesAnimationRange.Dock = DockStyle.Fill;
            _propertiesAnimationRange.HelpVisible = false;
            _propertiesAnimationRange.LargeButtons = false;
            _propertiesAnimationRange.LineColor = SystemColors.ScrollBar;
            _propertiesAnimationRange.Location = new Point(0, 0x15);
            _propertiesAnimationRange.Name = "propertiesAnimationRange";
            _propertiesAnimationRange.Size = new Size(0x192, 0x73);
            _propertiesAnimationRange.TabIndex = 0;
            _propertiesAnimationRange.Text = "Morph Target Properties";
            _propertiesAnimationRange.ToolbarVisible = false;
            _propertiesAnimationRange.ViewBackColor = SystemColors.Window;
            _propertiesAnimationRange.ViewForeColor = SystemColors.WindowText;
            _comboAnimationRanges.Dock = DockStyle.Top;
            _comboAnimationRanges.DropDownStyle = ComboBoxStyle.DropDownList;
            _comboAnimationRanges.Location = new Point(0, 0);
            _comboAnimationRanges.Name = "comboAnimationRanges";
            _comboAnimationRanges.Size = new Size(0x192, 0x15);
            _comboAnimationRanges.TabIndex = 1;
            _btnCompileAnimationRanges.Dock = DockStyle.Bottom;
            _btnCompileAnimationRanges.FlatStyle = FlatStyle.Flat;
            _btnCompileAnimationRanges.Location = new Point(0, 0xb8);
            _btnCompileAnimationRanges.Name = "btnCompileAnimationRanges";
            _btnCompileAnimationRanges.Size = new Size(0x192, 0x18);
            _btnCompileAnimationRanges.TabIndex = 4;
            _btnCompileAnimationRanges.Text = "Close window";
            _btnDeleteAnimationRange.Dock = DockStyle.Bottom;
            _btnDeleteAnimationRange.FlatStyle = FlatStyle.Flat;
            _btnDeleteAnimationRange.Location = new Point(0, 0xa0);
            _btnDeleteAnimationRange.Name = "btnDeleteAnimationRange";
            _btnDeleteAnimationRange.Size = new Size(0x192, 0x18);
            _btnDeleteAnimationRange.TabIndex = 3;
            _btnDeleteAnimationRange.Text = "Delete Animation range";
            _btnAddAnimationRange.Dock = DockStyle.Bottom;
            _btnAddAnimationRange.FlatStyle = FlatStyle.Flat;
            _btnAddAnimationRange.Location = new Point(0, 0x88);
            _btnAddAnimationRange.Name = "btnAddAnimationRange";
            _btnAddAnimationRange.Size = new Size(0x192, 0x18);
            _btnAddAnimationRange.TabIndex = 2;
            _btnAddAnimationRange.Text = "Add Animation range";
            AutoScaleBaseSize = new Size(5, 13);
            ClientSize = new Size(0x192, 0xd0);
            Controls.Add(_propertiesAnimationRange);
            Controls.Add(_btnAddAnimationRange);
            Controls.Add(_btnDeleteAnimationRange);
            Controls.Add(_btnCompileAnimationRanges);
            Controls.Add(_comboAnimationRanges);
            Font = new Font("Microsoft Sans Serif", 8.00F);
//            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmAnimationRanges";
            Text = "Animation Ranges Tool";
            TopMost = true;
            ResumeLayout(false);
        }

        private void btnAddMorphTarget_Click(object sender, EventArgs e)
        {
            mComponents.pActor.AddAnimationRange(0, 0.00F, mComponents.pActor.GetAnimationLength(0),
                                                 "Animation" +
                                                 StringType.FromInteger(mComponents.pActor.GetAnimationCount()));
            LoadRanges(false);
            comboAnimationRanges.SelectedIndex = comboAnimationRanges.Items.Count - 1;
            propertiesAnimationRange.SelectedObject =
                mComponents.arrayCAnimationRangeProperties[comboAnimationRanges.Items.Count - 1];
            mTV3D.RefreshAnimationList();
        }

        private void comboAnimationRanges_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mGlobalProperties.bInitedDone)
            {
                int num1 = comboAnimationRanges.SelectedIndex;
                propertiesAnimationRange.SelectedObject = mComponents.arrayCAnimationRangeProperties[num1];
            }
        }

        private void btnDeleteMorphTarget_Click(object sender, EventArgs e)
        {
            object obj1 = comboAnimationRanges.Items.Count;
            if (BooleanType.FromObject(ObjectType.NotObj(ObjectType.ObjTst(obj1, 0, false) == 0)))
            {
                mComponents.pActor.DeleteAnimationRange(
                    mComponents.arrayCAnimationRangeProperties[comboAnimationRanges.SelectedIndex].iArrayIndex);
                mComponents.arrayCAnimationRangeProperties[comboAnimationRanges.SelectedIndex] = null;
                LoadRanges(false);
                if (comboAnimationRanges.Items.Count > 0)
                {
                    comboAnimationRanges.SelectedIndex = 0;
                }
                else
                {
                    propertiesAnimationRange.SelectedObject = null;
                }
                mTV3D.RefreshAnimationList();
            }
        }

        private void btnCompileMorphTargets_Click(object sender, EventArgs e)
        {
            comboAnimationRanges.Items.Clear();
            int num2 = Information.UBound(mComponents.arrayCAnimationRangeProperties, 1);
            for (int i = 0; i <= num2; i++)
            {
                mComponents.arrayCAnimationRangeProperties[i] = null;
            }
            mComponents.eDoRender = mComponents.enumDoRender.Normal;
            Close();
        }

        private void frmAnimationRanges_Closing(object sender, CancelEventArgs e)
        {
            mComponents.eDoRender = mComponents.enumDoRender.Normal;
            Hide();
            e.Cancel = true;
        }

        private void frmAnimationRanges_Load(object sender, EventArgs e)
        {
            LoadRanges(false);
        }

        public void LoadRanges([Optional] bool loadfirst /* = false*/)
        {
            comboAnimationRanges.Items.Clear();
            mComponents.arrayCAnimationRangeProperties =
                (cAnimationRangeProperties[])
                Utils.CopyArray(mComponents.arrayCAnimationRangeProperties, new cAnimationRangeProperties[1]);
            if (mTV3D.bActorOpen)
            {
                int num4 = mComponents.pActor.GetAnimationCount() - 1;
                for (int AnimationID = 0; AnimationID <= num4; AnimationID += 1)
                {
                    float anend = -1;
                    float anstart =-1;
                    int sourceid = -1;

                    if (mComponents.pActor.GetAnimationRangeInfo(AnimationID, ref sourceid, ref anstart, ref anend))
                    {
                        AddRange(mComponents.pActor.GetAnimationName(AnimationID), anstart, anend, sourceid,
                                      AnimationID);
                    }
                }
            }
            if (loadfirst)
            {
                if (comboAnimationRanges.Items.Count > 0)
                {
                    comboAnimationRanges.SelectedIndex = 0;
                }
                else
                {
                    propertiesAnimationRange.SelectedObject = null;
                }
            }
        }

        private void AddRange(string name, float anstart, float anend, long sourceid, long AnimationID)
        {
            object obj1 = comboAnimationRanges.Items.Count;
            mComponents.arrayCAnimationRangeProperties =
                (cAnimationRangeProperties[])
                Utils.CopyArray(mComponents.arrayCAnimationRangeProperties,
                                new cAnimationRangeProperties[IntegerType.FromObject(obj1) + 1]);
            mComponents.arrayCAnimationRangeProperties[IntegerType.FromObject(obj1)] = new cAnimationRangeProperties();
            mComponents.arrayCAnimationRangeProperties[IntegerType.FromObject(obj1)].iArrayIndex = (int) AnimationID;
            mComponents.arrayCAnimationRangeProperties[IntegerType.FromObject(obj1)].fEndFrame = anend;
            mComponents.arrayCAnimationRangeProperties[IntegerType.FromObject(obj1)].fStartFrame = anstart;
            mComponents.arrayCAnimationRangeProperties[IntegerType.FromObject(obj1)].iSrcAnimation = (int) sourceid;
            mComponents.arrayCAnimationRangeProperties[IntegerType.FromObject(obj1)].fSrcAnimationLength =
                mComponents.pActor.GetAnimationLength((int) sourceid);
            mComponents.arrayCAnimationRangeProperties[IntegerType.FromObject(obj1)].sName = name;
            comboAnimationRanges.Items.Add(name);
        }

        private void propertiesAnimationRange_Click(object sender, EventArgs e)
        {
        }

        private void propertiesAnimationRange_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            UpdateAnimation(comboAnimationRanges.SelectedIndex);
        }

        public void UpdateAnimation(long rangeid)
        {
            int num1 = mComponents.arrayCAnimationRangeProperties[(int) rangeid].iArrayIndex;
            mComponents.pActor.RenameAnimation(num1, mComponents.arrayCAnimationRangeProperties[(int) rangeid].sName);
            mComponents.pActor.SetAnimationRangeInfo(num1,
                                                     mComponents.arrayCAnimationRangeProperties[(int) rangeid].
                                                         iSrcAnimation,
                                                     mComponents.arrayCAnimationRangeProperties[(int) rangeid].
                                                         fStartFrame,
                                                     mComponents.arrayCAnimationRangeProperties[(int) rangeid].fEndFrame);
            comboAnimationRanges.Items[(int) rangeid] =
                mComponents.arrayCAnimationRangeProperties[(int) rangeid].sName;
            mTV3D.RefreshAnimationList();
        }


        // Properties
        internal virtual PropertyGrid propertiesAnimationRange
        {
            get { return _propertiesAnimationRange; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_propertiesAnimationRange != null)
                {
                    _propertiesAnimationRange.PropertyValueChanged -=
                        propertiesAnimationRange_PropertyValueChanged;
                    _propertiesAnimationRange.Click -= propertiesAnimationRange_Click;
                }
                _propertiesAnimationRange = value;
                if (_propertiesAnimationRange != null)
                {
                    _propertiesAnimationRange.PropertyValueChanged +=
                        propertiesAnimationRange_PropertyValueChanged;
                    _propertiesAnimationRange.Click += propertiesAnimationRange_Click;
                }
            }
        }

        internal virtual ComboBox comboAnimationRanges
        {
            get { return _comboAnimationRanges; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_comboAnimationRanges != null)
                {
                    _comboAnimationRanges.SelectedIndexChanged -= comboAnimationRanges_SelectedIndexChanged;
                }
                _comboAnimationRanges = value;
                if (_comboAnimationRanges != null)
                {
                    _comboAnimationRanges.SelectedIndexChanged += comboAnimationRanges_SelectedIndexChanged;
                }
            }
        }

        internal virtual Button btnCompileAnimationRanges
        {
            get { return _btnCompileAnimationRanges; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCompileAnimationRanges != null)
                {
                    _btnCompileAnimationRanges.Click -= btnCompileMorphTargets_Click;
                }
                _btnCompileAnimationRanges = value;
                if (_btnCompileAnimationRanges != null)
                {
                    _btnCompileAnimationRanges.Click += btnCompileMorphTargets_Click;
                }
            }
        }

        internal virtual Button btnDeleteAnimationRange
        {
            get { return _btnDeleteAnimationRange; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeleteAnimationRange != null)
                {
                    _btnDeleteAnimationRange.Click -= btnDeleteMorphTarget_Click;
                }
                _btnDeleteAnimationRange = value;
                if (_btnDeleteAnimationRange != null)
                {
                    _btnDeleteAnimationRange.Click += btnDeleteMorphTarget_Click;
                }
            }
        }

        internal virtual Button btnAddAnimationRange
        {
            get { return _btnAddAnimationRange; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddAnimationRange != null)
                {
                    _btnAddAnimationRange.Click -= btnAddMorphTarget_Click;
                }
                _btnAddAnimationRange = value;
                if (_btnAddAnimationRange != null)
                {
                    _btnAddAnimationRange.Click += btnAddMorphTarget_Click;
                }
            }
        }
    }
}
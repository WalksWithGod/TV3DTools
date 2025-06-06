#region

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MTV3D65;

#endregion

namespace ModelView
{
    public class frmMorphTargets : Form
    {
        // Instance Fields
        [AccessedThroughProperty("btnAddMorphTarget")] private Button _btnAddMorphTarget;
        [AccessedThroughProperty("btnCompileMorphTargets")] private Button _btnCompileMorphTargets;
        [AccessedThroughProperty("propertiesMorphTarget")] private PropertyGrid _propertiesMorphTarget;
        [AccessedThroughProperty("btnDeleteMorphTarget")] private Button _btnDeleteMorphTarget;
        [AccessedThroughProperty("comboMorphTargets")] private ComboBox _comboMorphTargets;
        private IContainer components;

        // Constructors
        public frmMorphTargets()
        {
            base.Closing += frmMorphTargets_Closing;
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
            propertiesMorphTarget = new PropertyGrid();
            comboMorphTargets = new ComboBox();
            btnCompileMorphTargets = new Button();
            btnDeleteMorphTarget = new Button();
            btnAddMorphTarget = new Button();
            SuspendLayout();
            propertiesMorphTarget.CommandsVisibleIfAvailable = true;
            propertiesMorphTarget.Dock = DockStyle.Fill;
            propertiesMorphTarget.HelpVisible = false;
            propertiesMorphTarget.LargeButtons = false;
            propertiesMorphTarget.LineColor = SystemColors.ScrollBar;
            Point point1 = new Point(0, 0x15);
            propertiesMorphTarget.Location = point1;
            propertiesMorphTarget.Name = "propertiesMorphTarget";
            Size size1 = new Size(0x198, 0x6d);
            propertiesMorphTarget.Size = size1;
            propertiesMorphTarget.TabIndex = 0;
            propertiesMorphTarget.Text = "Morph Target Properties";
            propertiesMorphTarget.ToolbarVisible = false;
            propertiesMorphTarget.ViewBackColor = SystemColors.Window;
            propertiesMorphTarget.ViewForeColor = SystemColors.WindowText;
            comboMorphTargets.Dock = DockStyle.Top;
            comboMorphTargets.DropDownStyle = ComboBoxStyle.DropDownList;
            point1 = new Point(0, 0);
            comboMorphTargets.Location = point1;
            comboMorphTargets.Name = "comboMorphTargets";
            size1 = new Size(0x198, 0x15);
            comboMorphTargets.Size = size1;
            comboMorphTargets.TabIndex = 1;
            btnCompileMorphTargets.Dock = DockStyle.Bottom;
            btnCompileMorphTargets.FlatStyle = FlatStyle.Flat;
            point1 = new Point(0, 0xb2);
            btnCompileMorphTargets.Location = point1;
            btnCompileMorphTargets.Name = "btnCompileMorphTargets";
            size1 = new Size(0x198, 0x18);
            btnCompileMorphTargets.Size = size1;
            btnCompileMorphTargets.TabIndex = 4;
            btnCompileMorphTargets.Text = "Compile";
            btnDeleteMorphTarget.Dock = DockStyle.Bottom;
            btnDeleteMorphTarget.FlatStyle = FlatStyle.Flat;
            point1 = new Point(0, 0x9a);
            btnDeleteMorphTarget.Location = point1;
            btnDeleteMorphTarget.Name = "btnDeleteMorphTarget";
            size1 = new Size(0x198, 0x18);
            btnDeleteMorphTarget.Size = size1;
            btnDeleteMorphTarget.TabIndex = 3;
            btnDeleteMorphTarget.Text = "Delete Morph Target";
            btnAddMorphTarget.Dock = DockStyle.Bottom;
            btnAddMorphTarget.FlatStyle = FlatStyle.Flat;
            point1 = new Point(0, 0x82);
            btnAddMorphTarget.Location = point1;
            btnAddMorphTarget.Name = "btnAddMorphTarget";
            size1 = new Size(0x198, 0x18);
            btnAddMorphTarget.Size = size1;
            btnAddMorphTarget.TabIndex = 2;
            btnAddMorphTarget.Text = "Add Morph Target";
            size1 = new Size(5, 13);
            AutoScaleBaseSize = size1;
            size1 = new Size(0x198, 0xca);
            ClientSize = size1;
            Controls.Add(propertiesMorphTarget);
            Controls.Add(btnAddMorphTarget);
            Controls.Add(btnDeleteMorphTarget);
            Controls.Add(btnCompileMorphTargets);
            Controls.Add(comboMorphTargets);
            Font = new Font("Microsoft Sans Serif", 8.00F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmMorphTargets";
            Text = "Morph Target Tool";
            ResumeLayout(false);
        }

        private void btnAddMorphTarget_Click(object sender, EventArgs e)
        {
            object obj1 = comboMorphTargets.Items.Count;
            mComponents.arrayCMorphTargetProperties =
                (cMorphTargetProperties[])
                Utils.CopyArray(mComponents.arrayCMorphTargetProperties,
                                new cMorphTargetProperties[IntegerType.FromObject(obj1) + 1]);
            mComponents.arrayCMorphTargetProperties[IntegerType.FromObject(obj1)] = new cMorphTargetProperties();
            mComponents.arrayMeshPose =
                (TVMesh[]) Utils.CopyArray(mComponents.arrayMeshPose, new TVMesh[IntegerType.FromObject(obj1) + 1]);
            mComponents.arrayMeshPose[IntegerType.FromObject(obj1)] = mComponents.pScene.CreateMeshBuilder("");
            comboMorphTargets.Items.Add("NewMorph");
            mComponents.arrayCMorphTargetProperties[IntegerType.FromObject(obj1)].iComboIndex =
                comboMorphTargets.Items.Count - 1;
            mComponents.arrayCMorphTargetProperties[IntegerType.FromObject(obj1)].iArrayIndex =
                IntegerType.FromObject(obj1);
            mComponents.arrayCMorphTargetProperties[IntegerType.FromObject(obj1)].iReference =
                IntegerType.FromObject(obj1);
            comboMorphTargets.SelectedIndex = comboMorphTargets.Items.Count - 1;
            propertiesMorphTarget.SelectedObject =
                mComponents.arrayCMorphTargetProperties[IntegerType.FromObject(obj1)];
        }

        private void comboMorphTargets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mGlobalProperties.bInitedDone)
            {
                int num2 = Information.UBound(mComponents.arrayCMorphTargetProperties, 1);
                for (int i = 0; i <= num2; i++)
                {
                    if (mComponents.arrayCMorphTargetProperties[i].iComboIndex == comboMorphTargets.SelectedIndex)
                    {
                        propertiesMorphTarget.SelectedObject = mComponents.arrayCMorphTargetProperties[i];
                        return;
                    }
                }
            }
        }

        private void btnDeleteMorphTarget_Click(object sender, EventArgs e)
        {
            object obj1 = comboMorphTargets.Items.Count;
            if (BooleanType.FromObject(ObjectType.NotObj(ObjectType.ObjTst(obj1, 0, false) == 0)))
            {
                int num5 = IntegerType.FromObject(ObjectType.SubObj(obj1, 1));
                for (int i = 0; i <= num5; i++)
                {
                    if (mComponents.arrayCMorphTargetProperties[i].iComboIndex == comboMorphTargets.SelectedIndex)
                    {
                        mComponents.arrayMeshPose[i].Destroy();
                        mComponents.arrayMeshPose[i] = null;
                        mComponents.arrayCMorphTargetProperties[i] = null;
                        int num4 = IntegerType.FromObject(ObjectType.SubObj(obj1, 1));
                        for (int j = i; j <= num4; j++)
                        {
                            if (
                                BooleanType.FromObject(
                                    ObjectType.NotObj(ObjectType.ObjTst(j, ObjectType.SubObj(obj1, 1), false) == 0)))
                            {
                                mComponents.arrayMeshPose[j] = mComponents.arrayMeshPose[j + 1];
                                mComponents.arrayCMorphTargetProperties[j] =
                                    mComponents.arrayCMorphTargetProperties[j + 1];
                                mComponents.arrayCMorphTargetProperties[j].iComboIndex--;
                                mComponents.arrayCMorphTargetProperties[j].iArrayIndex--;
                            }
                            else
                            {
                                if (i != j)
                                {
                                    mComponents.arrayMeshPose[j].Destroy();
                                }
                                mComponents.arrayMeshPose[j] = null;
                                mComponents.arrayMeshPose =
                                    (TVMesh[]) Utils.CopyArray(mComponents.arrayMeshPose, new TVMesh[(j - 1) + 1]);
                                mComponents.arrayCMorphTargetProperties[j] = null;
                                mComponents.arrayCMorphTargetProperties =
                                    (cMorphTargetProperties[])
                                    Utils.CopyArray(mComponents.arrayCMorphTargetProperties,
                                                    new cMorphTargetProperties[(j - 1) + 1]);
                            }
                        }
                        break;
                    }
                }
                int index = comboMorphTargets.SelectedIndex;
                if ((index == 0) & (comboMorphTargets.Items.Count != 0))
                {
                    comboMorphTargets.Items.RemoveAt(index);
                    if (comboMorphTargets.Items.Count != 0)
                    {
                        comboMorphTargets.SelectedIndex = index;
                    }
                    else
                    {
                        propertiesMorphTarget.SelectedObject = null;
                    }
                }
                else
                {
                    if (comboMorphTargets.Items.Count != 0)
                    {
                        comboMorphTargets.SelectedIndex = index - 1;
                        comboMorphTargets.Items.RemoveAt(index);
                    }
                }
            }
        }

        private void btnCompileMorphTargets_Click(object sender, EventArgs e)
        {
            if (comboMorphTargets.Items.Count != 0)
            {
                int num3 = Information.UBound(mComponents.arrayMeshPose, 1);
                int num1 = 0;
                while (num1 <= num3)
                {
                    mComponents.pActor.MorphTargetCompiler_AddMorphTargetMesh(
                        mComponents.arrayCMorphTargetProperties[num1].sName, mComponents.arrayMeshPose[num1],
                        mComponents.arrayCMorphTargetProperties[num1].bReference);
                    num1++;
                }
                mComponents.pActor.MorphTargetCompiler_Compile();
                mComponents.pActor.MorphTarget_Enable(true, true);
                mComponents.pActor.MorphTarget_SetWeight(1, 0.70F);
                propertiesMorphTarget.SelectedObject = null;
                comboMorphTargets.Items.Clear();
                int num2 = Information.UBound(mComponents.arrayMeshPose, 1);
                for (num1 = 0; num1 <= num2; num1++)
                {
                    mComponents.arrayMeshPose[num1].Destroy();
                    mComponents.arrayMeshPose[num1] = null;
                    mComponents.arrayCMorphTargetProperties[num1] = null;
                }
            }
            mComponents.arrayMeshPose = new TVMesh[1];
            mComponents.arrayCMorphTargetProperties = new cMorphTargetProperties[1];
            mComponents.eDoRender = mComponents.enumDoRender.Normal;
            Close();
        }

        private void frmMorphTargets_Closing(object sender, CancelEventArgs e)
        {
            mComponents.eDoRender = mComponents.enumDoRender.Normal;
            Close();
        }


        // Properties
        internal virtual PropertyGrid propertiesMorphTarget
        {
            get { return _propertiesMorphTarget; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_propertiesMorphTarget != null)
                {
                }
                _propertiesMorphTarget = value;
                if (_propertiesMorphTarget != null)
                {
                }
            }
        }

        internal virtual ComboBox comboMorphTargets
        {
            get { return _comboMorphTargets; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_comboMorphTargets != null)
                {
                    _comboMorphTargets.SelectedIndexChanged -= comboMorphTargets_SelectedIndexChanged;
                }
                _comboMorphTargets = value;
                if (_comboMorphTargets != null)
                {
                    _comboMorphTargets.SelectedIndexChanged += comboMorphTargets_SelectedIndexChanged;
                }
            }
        }

        internal virtual Button btnCompileMorphTargets
        {
            get { return _btnCompileMorphTargets; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCompileMorphTargets != null)
                {
                    _btnCompileMorphTargets.Click -= btnCompileMorphTargets_Click;
                }
                _btnCompileMorphTargets = value;
                if (_btnCompileMorphTargets != null)
                {
                    _btnCompileMorphTargets.Click += btnCompileMorphTargets_Click;
                }
            }
        }

        internal virtual Button btnDeleteMorphTarget
        {
            get { return _btnDeleteMorphTarget; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeleteMorphTarget != null)
                {
                    _btnDeleteMorphTarget.Click -= btnDeleteMorphTarget_Click;
                }
                _btnDeleteMorphTarget = value;
                if (_btnDeleteMorphTarget != null)
                {
                    _btnDeleteMorphTarget.Click += btnDeleteMorphTarget_Click;
                }
            }
        }

        internal virtual Button btnAddMorphTarget
        {
            get { return _btnAddMorphTarget; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddMorphTarget != null)
                {
                    _btnAddMorphTarget.Click -= btnAddMorphTarget_Click;
                }
                _btnAddMorphTarget = value;
                if (_btnAddMorphTarget != null)
                {
                    _btnAddMorphTarget.Click += btnAddMorphTarget_Click;
                }
            }
        }
    }
}
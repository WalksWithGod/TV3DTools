#region

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#endregion

namespace ModelView
{
    public class frmMorphSlider : Form
    {
        // Instance Fields
        [AccessedThroughProperty("sliderMorph")] private TrackBar _sliderMorph;
        [AccessedThroughProperty("comboMorphTargets")] private ComboBox _comboMorphTargets;
        private IContainer components;

        // Constructors
        public frmMorphSlider()
        {
            base.Load += frmMorphSlider_Load;
            base.Closing += frmMorphSlider_Closing;
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
            comboMorphTargets = new ComboBox();
            sliderMorph = new TrackBar();
            sliderMorph.BeginInit();
            SuspendLayout();
            comboMorphTargets.Dock = DockStyle.Top;
            comboMorphTargets.DropDownStyle = ComboBoxStyle.DropDownList;
            Point point1 = new Point(0, 0);
            comboMorphTargets.Location = point1;
            comboMorphTargets.Name = "comboMorphTargets";
            Size size1 = new Size(0x12a, 0x15);
            comboMorphTargets.Size = size1;
            comboMorphTargets.TabIndex = 0;
            sliderMorph.Dock = DockStyle.Fill;
            point1 = new Point(0, 0x15);
            sliderMorph.Location = point1;
            sliderMorph.Maximum = 0x64;
            sliderMorph.Name = "sliderMorph";
            size1 = new Size(0x12a, 0x28);
            sliderMorph.Size = size1;
            sliderMorph.TabIndex = 1;
            size1 = new Size(5, 13);
            AutoScaleBaseSize = size1;
            size1 = new Size(0x12a, 0x3d);
            ClientSize = size1;
            Controls.Add(sliderMorph);
            Controls.Add(comboMorphTargets);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmMorphSlider";
            StartPosition = FormStartPosition.Manual;
            TopMost = true;
            sliderMorph.EndInit();
            ResumeLayout(false);
        }

        private void frmMorphSlider_Load(object sender, EventArgs e)
        {
            int num2 = mComponents.pActor.MorphTarget_GetCount() - 1;
            for (int i = 1; i <= num2; i++)
            {
                comboMorphTargets.Items.Add("POSE: " + mComponents.pActor.MorphTarget_GetName(i));
            }
            comboMorphTargets.SelectedIndex = 0;
            Text = mComponents.pActor.MorphTarget_GetName(1);
            sliderMorph.Value = (int) Math.Round((mComponents.pActor.MorphTarget_GetWeight(1)*100.00F));
        }

        private void sliderMorph_Scroll(object sender, EventArgs e)
        {
            mComponents.pActor.MorphTarget_SetWeight(comboMorphTargets.SelectedIndex + 1,
                                                     (float) (((double) sliderMorph.Value)/100));
        }

        private void comboMorphTargets_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveForm.Text = mComponents.pActor.MorphTarget_GetName(comboMorphTargets.SelectedIndex + 1);
            sliderMorph.Value =
                (int)
                Math.Round((mComponents.pActor.MorphTarget_GetWeight(comboMorphTargets.SelectedIndex + 1)*100.00F));
        }

        private void frmMorphSlider_Closing(object sender, CancelEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }


        // Properties
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

        internal virtual TrackBar sliderMorph
        {
            get { return _sliderMorph; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_sliderMorph != null)
                {
                    _sliderMorph.Scroll -= sliderMorph_Scroll;
                }
                _sliderMorph = value;
                if (_sliderMorph != null)
                {
                    _sliderMorph.Scroll += sliderMorph_Scroll;
                }
            }
        }
    }
}
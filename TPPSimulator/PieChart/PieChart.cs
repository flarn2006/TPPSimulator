using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPPSimulator.PieChart
{
    public partial class PieChart : Control
    {
        private PieSliceCollection slices;
        private int margin = 12;

        public PieChart()
        {
            InitializeComponent();
            slices = new PieSliceCollection(this);
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            int radius = Math.Min(Width, Height) / 2 - PieMargin;
            Rectangle rect = new Rectangle(Width / 2 - radius, Height / 2 - radius, 2 * radius, 2 * radius);

            double total = 0.0;
            foreach (PieSlice slice in PieSlices) {
                total += slice.Value;
            }

            if (total > 0) {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                double angle = 0.0;
                double angleFactor = 360.0 / total;

                if (Height > 1) {
                    foreach (PieSlice slice in PieSlices) {
                        double sliceAngle = slice.Value * angleFactor;
                        pe.Graphics.FillPie(new SolidBrush(slice.FillColor), rect, (float)angle, (float)sliceAngle);
                        angle += sliceAngle;
                    }

                    angle = 0.0;

                    foreach (PieSlice slice in PieSlices) {
                        double sliceAngle = slice.Value * angleFactor;

                        if (slice.BorderColor.A > 0) {
                            Pen borderPen = new Pen(slice.BorderColor, 2.0f);
                            borderPen.Alignment = PenAlignment.Inset;
                            pe.Graphics.DrawPie(new Pen(slice.BorderColor, 2.0f), rect, (float)angle, (float)sliceAngle);
                        }

                        angle += sliceAngle;
                    }
                }
            }
        }

        [Category("Data"), Description("The collection containing the pie chart's slices.")]
        public PieSliceCollection PieSlices
        {
            get { return slices; }
        }

        [DefaultValue(12), Category("Appearance"), Description("Indicates how much space to leave on the edges of the control.")]
        public int PieMargin
        {
            get { return margin; }
            set { margin = value; }
        }
    }
}

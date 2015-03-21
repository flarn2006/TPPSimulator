using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPPSimulator
{
    public partial class Ruler : Control
    {
        private static Font numberFont;
        
        static Ruler()
        {
            numberFont = new Font("Arial", 8.0f);
        }

        private int unitSize = 16;
        private Ruler otherRuler = null;

        public Ruler()
        {
            InitializeComponent();
        }

        [DefaultValue(16), Category("Appearance")]
        public int UnitSize
        {
            get { return unitSize; }
            set { unitSize = value; Invalidate(); }
        }

        [DefaultValue(null), Category("Appearance")]
        public Ruler OtherRuler
        {
            get { return otherRuler; }
            set { otherRuler = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.FillRectangle(Brushes.White, pe.ClipRectangle);

            bool horizontal = (Width > Height);
            int tickCount;
            if (horizontal) {
                tickCount = Width / UnitSize + 1;
            } else {
                tickCount = Height / UnitSize + 1;
            }

            int offset = 0;
            if (otherRuler != null) {
                if (horizontal) {
                    offset = otherRuler.Width;
                    pe.Graphics.FillRectangle(Brushes.Gray, 0, 0, offset + 1, Height);
                } else {
                    offset = otherRuler.Height;
                    pe.Graphics.FillRectangle(Brushes.Gray, 0, 0, Width, offset + 1);
                }
            }

            for (int i = 0; i < tickCount; i++) {
                bool major = (i % 10 == 0);
                Pen pen = major ? Pens.Gray : Pens.LightGray;
                if (horizontal) {
                    pe.Graphics.DrawLine(pen, offset + i * UnitSize, 0, offset + i * UnitSize, Height - 1);
                    pe.Graphics.DrawString(i.ToString(), numberFont, Brushes.Black, offset + i * UnitSize, 0);
                } else {
                    pe.Graphics.DrawLine(pen, 0, offset + i * UnitSize, Width - 1, offset + i * UnitSize);
                    pe.Graphics.DrawString(i.ToString(), numberFont, Brushes.Black, 0, offset + i * UnitSize);
                }
            }
        }
    }
}

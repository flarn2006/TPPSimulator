using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPPSimulator.PieChart
{
    public class PieSlice
    {
        private double value = 1;
        private Color fillColor = Color.Black;
        private Color borderColor = Color.Transparent;

        public event EventHandler Changed;

        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null) Changed(this, e);
        }

        protected void OnChanged()
        {
            OnChanged(EventArgs.Empty);
        }

        [DefaultValue(1), Category("Data"), Description("The value of the slice. All slices need not total any specific value.")]
        public double Value
        {
            get { return value; }
            set { this.value = value; OnChanged(); }
        }

        [DefaultValue(typeof(Color), "Black"), Category("Appearance"), Description("Indicates the fill color of the slice.")]
        public Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; OnChanged(); }
        }

        [DefaultValue(typeof(Color), "Transparent"), Category("Appearance"), Description("Indicates the border color of the slice.")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; OnChanged(); }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TPPSimulator
{
    [DefaultEvent("ValueDrag")]
    public class ValueDragLabel : Label
    {
        private bool dragging = false;
        private Point last = Point.Empty;

        public class ValueDragEventArgs : EventArgs
        {
            private int delta = 0;

            public ValueDragEventArgs(int delta)
            {
                this.delta = delta;
            }

            public int Delta
            {
                get { return delta; }
            }
        }

        public event EventHandler<ValueDragEventArgs> ValueDrag;
        protected virtual void OnValueDrag(int delta)
        {
            if (ValueDrag != null)
                ValueDrag(this, new ValueDragEventArgs(delta));
        }

        public ValueDragLabel()
            : base()
        {
            Cursor = Cursors.SizeWE;
            MouseDown += new MouseEventHandler(this_MouseDown);
            MouseMove += new MouseEventHandler(this_MouseMove);
            MouseUp += new MouseEventHandler(this_MouseUp);
        }

        public void this_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                dragging = true;
                last = e.Location;
            }
        }

        public void this_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging) {
                OnValueDrag(e.Location.X - last.X);
                last = e.Location;
            }
        }

        public void this_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                dragging = false;
            }
        }
    }
}

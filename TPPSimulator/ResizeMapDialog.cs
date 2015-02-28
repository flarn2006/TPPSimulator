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
    public partial class ResizeMapDialog : Form
    {
        private int oldWidth = 0;
        private int oldHeight = 0;

        public ResizeMapDialog()
        {
            InitializeComponent();
        }

        public static DialogResult PromptToResize(TileGrid tileGrid)
        {
            ResizeMapDialog dlg = new ResizeMapDialog();
            dlg.udWidth.Value = dlg.oldWidth = tileGrid.Columns;
            dlg.udHeight.Value = dlg.oldHeight = tileGrid.Rows;
            DialogResult result = dlg.ShowDialog();

            if (result == DialogResult.OK) {
                tileGrid.ResizeGrid((int)dlg.udWidth.Value, (int)dlg.udHeight.Value);
                if (tileGrid.Player.Location.X > tileGrid.Columns || tileGrid.Player.Location.Y > tileGrid.Rows)
                    tileGrid.Player.Location = Point.Empty;
                if (tileGrid.GoalLocation.X > tileGrid.Columns || tileGrid.GoalLocation.Y > tileGrid.Rows)
                    tileGrid.GoalLocation = Point.Empty;
            }

            return result;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool proceed = true;

            if (udWidth.Value < oldWidth || udHeight.Value < oldHeight) {
                proceed = (MessageBox.Show("The size you chose is smaller than the current size; some clipping will occur.", "Warning",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK);
            }

            if (proceed) DialogResult = DialogResult.OK;
        }

        private void udWidthHeight_Enter(object sender, EventArgs e)
        {
            NumericUpDown s = (NumericUpDown)sender;
            s.Select(0, s.Value.ToString().Length);
        }
    }
}

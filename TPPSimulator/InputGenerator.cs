using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPPSimulator
{
    public interface IInputGenerator
    {
        Input GetNextInput();
    }

    public partial class InputGenerator : UserControl, IInputGenerator
    {
        private static Random rng;

        static InputGenerator()
        {
            rng = new Random();
        }

        private Queue<Input> inputQueue;

        public InputGenerator()
        {
            InitializeComponent();
            inputQueue = new Queue<Input>();
        }

        public event EventHandler StepIntervalChanged;

        protected virtual void OnStepIntervalChanged(EventArgs e)
        {
            if (StepIntervalChanged != null) StepIntervalChanged(this, e);
        }

        protected void OnStepIntervalChanged()
        {
            OnStepIntervalChanged(EventArgs.Empty);
        }

        public Input GetPathInput()
        {
            throw new NotImplementedException();
        }

        public Input GetNextInputForQueue()
        {
            TrackBar[] sliders = new TrackBar[] { tbPath, tbUp, tbDown, tbLeft, tbRight, tbA, tbB, tbSelect, tbStart, tbNone };
            Input[] inputs = new Input[] { Input.None, Input.Up, Input.Down, Input.Left, Input.Right, Input.A, Input.B, Input.Select, Input.Start, Input.None };

            int total = 0;
            foreach (TrackBar tb in sliders) {
                total += tb.Value;
            }

            if (total == 0) return Input.None;

            int random = rng.Next(total);

            total = 0;
            for (int i = 0; i < 10; i++) {
                total += sliders[i].Value;
                if (random < total) {
                    if (i == 0)
                        return GetPathInput();
                    else
                        return inputs[i];
                }
            }

            throw new Exception("Only way code should reach here is if the random number wasn't in the correct range.");
        }

        public void UpdateProgressBar()
        {
            if (udStreamDelay.Value == 0) {
                queueBar.Value = queueBar.Maximum;
                btnClearQueue.Enabled = false;
                btnFillQueue.Enabled = false;
            } else {
                queueBar.Maximum = (int)udStreamDelay.Value;
                queueBar.Value = inputQueue.Count;
                btnClearQueue.Enabled = (inputQueue.Count > 0);
                btnFillQueue.Enabled = (inputQueue.Count < udStreamDelay.Value);
            }
        }

        public Input GetNextInput()
        {
            Input result;
            UpdateProgressBar();
            if (udStreamDelay.Value == 0) {
                result = GetNextInputForQueue();
            } else {
                if (inputQueue.Count < udStreamDelay.Value) {
                    inputQueue.Enqueue(GetNextInputForQueue());
                    result = Input.None;
                } else {
                    if (inputQueue.Count == udStreamDelay.Value) {
                        inputQueue.Enqueue(GetNextInputForQueue());
                    }
                    result = inputQueue.Dequeue();
                }
            }

            if (result != Input.None) {
                lastInputs.Items.Insert(0, result);
                if (lastInputs.Items.Count > (lastInputs.Height / lastInputs.ItemHeight)) {
                    lastInputs.Items.RemoveAt(lastInputs.Items.Count - 1);
                }
            }

            return result;
        }

        private void AdjustUpDownAndClamp(NumericUpDown control, decimal delta)
        {
            decimal newValue = control.Value + delta;
            if (newValue < control.Minimum) newValue = control.Minimum;
            else if (newValue > control.Maximum) newValue = control.Maximum;
            control.Value = newValue;
        }

        private void vdlStepInterval_ValueDrag(object sender, ValueDragLabel.ValueDragEventArgs e)
        {
            AdjustUpDownAndClamp(udStepInterval, 10 * e.Delta);
        }

        private void vdlStreamDelay_ValueDrag(object sender, ValueDragLabel.ValueDragEventArgs e)
        {
            AdjustUpDownAndClamp(udStreamDelay, 10 * e.Delta);
        }

        private void udStepInterval_ValueChanged(object sender, EventArgs e)
        {
            UpdateStreamDelayLabel();
            OnStepIntervalChanged(e);
        }

        [DefaultValue(125)]
        public int StepInterval
        {
            get { return (int)udStepInterval.Value; }
            set { udStepInterval.Value = value; }
        }

        private void udStreamDelay_ValueChanged(object sender, EventArgs e)
        {
            UpdateStreamDelayLabel();
            UpdateProgressBar();
        }

        private void UpdateStreamDelayLabel()
        {
            if (udStreamDelay.Value == 0) {
                streamDelayLabel.Text = "Stream delay: (none)";
            } else {
                streamDelayLabel.Text = String.Format("Stream delay: {0} sec", udStreamDelay.Value * udStepInterval.Value / 1000);
            }
        }

        private void pathLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"This controls the weight to give whatever input is determined to be ""best"" according to a pathfinding algorithm.
Note that this slider's maximum is 10 times more than the others.
This function is not yet implemented.", "Explanation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFillQueue_Click(object sender, EventArgs e)
        {
            while (inputQueue.Count < udStreamDelay.Value) {
                GetNextInput();
            }
            UpdateProgressBar();
        }

        private void clearQueueBtn_Click(object sender, EventArgs e)
        {
            inputQueue.Clear();
            UpdateProgressBar();
        }
    }
}

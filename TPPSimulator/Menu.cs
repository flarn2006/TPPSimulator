using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPPSimulator
{
    public class Menu
    {
        private static Image emptyImage;
        private static Random rng;

        static Menu()
        {
            emptyImage = new Bitmap(1, 1);
            ((Bitmap)emptyImage).SetPixel(0, 0, Color.Transparent);
            rng = new Random();
        }

        private MenuState state = null;
        private Dictionary<string, MenuState> stateTable;
        private string mainStateID = "main_0";
        private int delay;

        public Menu()
        {
            stateTable = new Dictionary<string,MenuState>();
            try {
                StreamReader sr = new StreamReader("Menu/Menu.csv");
                while (!sr.EndOfStream) {
                    string[] fields = sr.ReadLine().Split(',');
                    if (fields[0][0] == '#') continue;
                    stateTable.Add(fields[0], new MenuState {
                        StateID = fields[0],
                        ImageName = fields[1],
                        CursorPos = new System.Drawing.Point(Int32.Parse(fields[2]), Int32.Parse(fields[3])),
                        Delay = Int32.Parse(fields[4]),
                        Action = fields[5],
                        UpStateID = fields[6],
                        DownStateID = fields[7],
                        LeftStateID = fields[8],
                        RightStateID = fields[9],
                        AStateID = fields[10],
                        BStateID = fields[11],
                        StartStateID = fields[12],
                        SelectStateID = fields[13]
                    });
                }
                sr.Close();
            } catch (FileNotFoundException ex) {
                throw new FileNotFoundException(String.Format("Cannot find file needed for menu: \"{0}\"", ex.Message), ex);
            }
        }

        public event EventHandler StateChanged;
        public event EventHandler Cut;

        protected virtual void OnStateChanged(EventArgs e)
        {
            if (StateChanged != null) StateChanged(this, e);
        }

        protected void OnStateChanged()
        {
            OnStateChanged(EventArgs.Empty);
        }

        protected virtual void OnCut(EventArgs e)
        {
            if (Cut != null) Cut(this, e);
        }

        protected void OnCut()
        {
            OnCut(EventArgs.Empty);
        }

        public MenuState State
        {
            get { return state; }
            set
            {
                state = value;
                OnStateChanged();
                if (state != null) {
                    if (state.StateID.StartsWith("main_")) mainStateID = state.StateID;
                    PerformAction(state.Action);
                    delay = state.Delay;
                }
            }
        }

        public string StateID
        {
            get { return state.StateID; }
            set
            {
                MenuState newState;
                if (value.Equals("-")) {
                    // do nothing
                } else if (value[0] == '!') {
                    PerformAction(value.Substring(1));
                } else {
                    if (stateTable.TryGetValue(value, out newState)) {
                        State = newState;
                    } else {
                        throw new KeyNotFoundException(String.Format("State with ID \"{0}\" not found.", value));
                    }
                }
            }
        }

        public Image Image
        {
            get
            {
                if (State == null) {
                    return emptyImage;
                } else {
                    return State.Image;
                }
            }
        }

        public void PerformAction(string action)
        {
            if (action.Equals("exit")) {
                State = null;
            } else if (action.Equals("cry")) {
                SoundPlayer.Play((rng.Next(20) == 0) ? Properties.Resources.kricketune : Properties.Resources.bulbasaur);
            } else if (action.Equals("cut")) {
                OnCut();
            } else if (action.Equals("cry_charmander")) {
                SoundPlayer.Play(Properties.Resources.charmander);
            }
        }

        public void Input(Input input)
        {
            if (delay == 0) {
                StateID = State.StateIDForInput(input);
            } else {
                delay--;
            }
        }

        public void Open()
        {
            StateID = mainStateID;
        }
    }
}

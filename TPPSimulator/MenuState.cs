using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TPPSimulator
{
    public class MenuState
    {
        private static Dictionary<string, Image> imageCache;
        private static Image cursorImage;

        static MenuState()
        {
            imageCache = new Dictionary<string, Image>();
            cursorImage = GetImage("cursor.png");
        }

        private static Image GetImage(string filename)
        {
            Image result;
            filename = System.IO.Path.Combine(Menu.MenuPath, filename);
            if (!imageCache.TryGetValue(filename, out result)) {
                Bitmap original_bitmap = (Bitmap) Image.FromFile(filename);
                result = new Bitmap(original_bitmap.Width, original_bitmap.Height);
                Graphics graphics = Graphics.FromImage(result);
                graphics.DrawImage(original_bitmap, 0, 0);
                imageCache.Add(filename, result);
            }
            return result;
        }

        private string stateID;
        private string imageName;
        private int cursorX = -1, cursorY = -1;
        private int delay = 0;
        private string action = "-";
        private string upState = "-";
        private string downState = "-";
        private string leftState = "-";
        private string rightState = "-";
        private string aState = "-";
        private string bState = "-";
        private string startState = "-";
        private string selectState = "-";

        #region Basic Properties

        public string StateID
        {
            get { return stateID; }
            set { stateID = value; }
        }

        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; UpdateImage(); }
        }

        public Point CursorPos
        {
            get { return new Point(cursorX, cursorY); }
            set { cursorX = value.X; cursorY = value.Y; UpdateImage(); }
        }

        public int Delay
        {
            get { return delay; }
            set { delay = value; }
        }

        public string Action
        {
            get { return action; }
            set { action = value; }
        }

        public string UpStateID
        {
            get { return upState; }
            set { upState = value; }
        }

        public string DownStateID
        {
            get { return downState; }
            set { downState = value; }
        }

        public string LeftStateID
        {
            get { return leftState; }
            set { leftState = value; }
        }

        public string RightStateID
        {
            get { return rightState; }
            set { rightState = value; }
        }

        public string AStateID
        {
            get { return aState; }
            set { aState = value; }
        }

        public string BStateID
        {
            get { return bState; }
            set { bState = value; }
        }

        public string StartStateID
        {
            get { return startState; }
            set { startState = value; }
        }

        public string SelectStateID
        {
            get { return selectState; }
            set { selectState = value; }
        }

        #endregion

        private Image image;
        
        private void UpdateImage()
        {
            image = (Image)GetImage(imageName).Clone();
            Graphics.FromImage(image).DrawImage(cursorImage, 8 * cursorX, 8 * cursorY);
        }

        public Image Image
        {
            get { return image; }
        }

        public string StateIDForInput(Input input)
        {
            switch (input) {
                case Input.Up: return upState;
                case Input.Down: return downState;
                case Input.Left: return leftState;
                case Input.Right: return rightState;
                case Input.A: return aState;
                case Input.B: return bState;
                case Input.Start: return startState;
                case Input.Select: return selectState;
                default: return "-";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace TPPSimulator
{
    static class SoundPlayer
    {
        private static System.Media.SoundPlayer player;
        private static bool enabled = true;

        static SoundPlayer()
        {
            player = new System.Media.SoundPlayer();
        }

        public static void Play(Stream stream)
        {
            if (enabled) {
                player.Stream = stream;
                player.Play();
            }
        }

        public static bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
    }
}

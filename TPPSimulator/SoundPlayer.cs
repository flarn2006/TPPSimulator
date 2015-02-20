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

        static SoundPlayer()
        {
            player = new System.Media.SoundPlayer();
        }

        public static void Play(Stream stream)
        {
            player.Stream = stream;
            player.Play();
        }
    }
}

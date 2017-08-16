using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpr314Lib
{
    public static class CprMusic
    {
        private static bool canbeep = true;

        public static bool CanBeep
        {
            get
            {
                return canbeep;
            }
        }

        public enum SoundNames
        {
            Do = 262,
            Re = 294,
            Mi = 330,
            Fa = 349,
            Sol = 392,
            La = 440,
            Si = 494
        }

        public static void Beep(int frequency, int duration)
        {
            if (canbeep) Console.Beep(frequency, duration);
        }

        public static void Beep(SoundNames s, int duration)
        {
            if (canbeep) Console.Beep((int)s, duration);
        }

        public static void Quiet(int duration)
        {
            canbeep = false;
            Task.Delay(duration).Wait();
            canbeep = true;
        }

        public static void Forced(bool canbeep)
            => CprMusic.canbeep = canbeep;
    }
}

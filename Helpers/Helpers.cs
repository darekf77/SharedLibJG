using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibJG.Helpers
{
    public class Helpers
    {
        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

        private const float _defaultDPI = 96;


        static Bitmap tmpb = new Bitmap(1, 1);
        static Graphics gg = Graphics.FromImage(tmpb);



        public static int getResponsiveFontSize(int fontsize)
        {
            float dpi = Math.Min(gg.DpiX, gg.DpiY);
            return (int)(_defaultDPI * (float)fontsize / dpi);
        }


        public static long UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalMilliseconds;
        }

        public static int mostPopular(int[] numbers)
        {
            var counts = new Dictionary<int, int>();
            foreach (int number in numbers)
            {
                int count;
                counts.TryGetValue(number, out count);
                count++;
                counts[number] = count;
            }
            int mostCommonNumber = 0, occurrences = 0;
            foreach (var pair in counts)
            {
                if (pair.Value > occurrences)
                {
                    occurrences = pair.Value;
                    mostCommonNumber = pair.Key;
                }
            }
            return mostCommonNumber;
        }

    }
}

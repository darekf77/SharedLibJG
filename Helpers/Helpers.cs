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

    }
}

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Render3D
{

    //https://stackoverflow.com/questions/24701703/c-sharp-faster-alternatives-to-setpixel-and-getpixel-for-bitmaps-for-windows-f

    public class DirectBitmap : IDisposable
    {
        public Bitmap bitmap { get; private set; }
        public Int32[] bits { get; private set; }
        public bool disposed { get; private set; }
        public int height { get; private set; }
        public int width { get; private set; }

        protected GCHandle bitsHandle { get; private set; }

        public DirectBitmap(int width, int height)
        {
            this.width = width;
            this.height = height;
            bits = new Int32[width * height];
            bitsHandle = GCHandle.Alloc(bits, GCHandleType.Pinned);
            bitmap = new Bitmap(width, height, width * 4, System.Drawing.Imaging.PixelFormat.Format32bppPArgb, bitsHandle.AddrOfPinnedObject());
        }

        public void SetPixel(int x, int y, Color c)
        {
            int index = x + (y * width);
            int color = c.ToArgb();

            bits[index] = color;
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * width);
            int color = bits[index];
            return Color.FromArgb(color);
        }

        public void Dispose()
        {
            if (disposed) return;
            disposed = true;
            bitmap.Dispose();
            bitsHandle.Free();
        }

    }
}

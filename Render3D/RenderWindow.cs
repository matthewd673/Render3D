using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Render3D
{
    public class RenderWindow
    {

        private Form window;

        public bool open { get; private set; }

        public RenderWindow(int width, int height)
        {
            window = new Form();
            window.Width = width;
            window.Height = height;
            window.BackColor = Color.Black;
            window.Text = "Render3D Viewer";
        }

        //[STAThread]
        public void Display()
        {
            window.FormClosed += Window_FormClosed;
            window.Show();
            open = true;
        }

        private void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            open = false;
        }

        public void UpdateGraphics(DirectBitmap dBmp)
        {
            window.BackgroundImage = dBmp.bitmap;
        }

    }
}

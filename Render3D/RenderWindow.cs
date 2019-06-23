using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Render3D
{
    public class RenderWindow
    {

        public Form window;

        public Camera c;

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
            //window.FormClosing += Window_FormClosing;
            //window.KeyUp += Window_KeyDown;
            window.Activate();
            window.Show();
            window.Enabled = true;
            window.Focus();
            window.Visible = true;

        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            window.Hide();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            int i = 1;

            if (e.KeyCode == Keys.W)
                c.z += i;
            if (e.KeyCode == Keys.S)
                c.z -= i;
            if (e.KeyCode == Keys.A)
                c.x -= i;
            if (e.KeyCode == Keys.D)
                c.x += i;
            if (e.KeyCode == Keys.Q)
                c.y -= i;
            if (e.KeyCode == Keys.E)
                c.y += i;
        }

        public void UpdateGraphics(DirectBitmap dBmp)
        {
            window.BackgroundImage = dBmp.bitmap;
        }

        public void SetCamera(Camera c)
        {
            this.c = c;
        }

    }
}

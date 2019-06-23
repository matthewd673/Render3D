using System;
using System.Drawing;
using System.Windows.Forms;

namespace Render3D
{
    public class Viewer : Form
    {

        Bitmap backImage;
        Renderer r;

        float dT;

        public Viewer(Renderer r)
        {
            this.r = r;
            backImage = r.Draw().bitmap;
            Initialize();
        }        

        public void View()
        {
            Application.EnableVisualStyles();
            Application.Run(new Viewer(r));
        }

        private void Initialize()
        {
            SuspendLayout();
            Text = "Render3D Viewer";
            Width = 800;
            Height = 600;
            BackColor = Color.Black;
            BackgroundImage = backImage;
            Click += Viewer_Click;
            KeyDown += Viewer_KeyDown;
            KeyUp += Viewer_KeyUp;
            FormClosing += Viewer_FormClosing;
            ResumeLayout();
        }

        private void Viewer_KeyDown(object sender, KeyEventArgs e)
        {
            Camera currentCam = r.GetCamera();

            switch (e.KeyCode)
            {
                case Keys.A:
                    currentCam.x -= 1;
                    break;
                case Keys.D:
                    currentCam.x += 1;
                    break;
                case Keys.W:
                    currentCam.z += 1;
                    break;
                case Keys.S:
                    currentCam.z -= 1;
                    break;
                case Keys.Q:
                    currentCam.y += 1;
                    break;
                case Keys.E:
                    currentCam.y -= 1;
                    break;
            }


            r.SetCamera(currentCam);

            UpdateFrame(r.Draw());

        }

        private void Viewer_KeyUp(object sender, KeyEventArgs e)
        {
            //dT
        }

        private void Viewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Closing view...");
        }

        private void Viewer_Click(object sender, EventArgs e)
        {
            Console.WriteLine("(click): setting new camera to 'out' position");
            r.SetCamera(new Camera(-6, -6, -5, 0, 0));
            UpdateFrame(r.Draw());
        }

        public void UpdateFrame(DirectBitmap dBmp)
        {
            BackgroundImage = dBmp.bitmap;
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Render3D
{
    public class Viewer : Form
    {

        Bitmap backImage;

        public Viewer(Bitmap frame)
        {
            backImage = frame;
            Initialize();
        }        

        public void View()
        {
            Application.EnableVisualStyles();
            Application.Run(new Viewer(backImage));
        }

        private void Initialize()
        {
            this.SuspendLayout();
            Text = "Render3D Viewer";
            Width = 800;
            Height = 600;
            BackColor = Color.Black;
            BackgroundImage = backImage;
            this.ResumeLayout();
        }

    }
}

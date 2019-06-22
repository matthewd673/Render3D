using System;
using System.Threading;
using System.Windows.Forms;

namespace Render3D
{
    class Program
    {

        static RenderWindow display;

        [STAThread]
        static void Main(string[] args)
        {
            display = new RenderWindow(800, 600);

            while (display.open)
            {
                Application.DoEvents();
                display.Display();
            }
        }

    }
}

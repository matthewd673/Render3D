using System;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Render3D
{
    class Program
    {

        static RenderWindow display;

        static Renderer r;

        [STAThread]
        static void Main(string[] args)
        {
            Console.Title = "Render3D Toolset";
            Console.WriteLine("Launching render viewer");
            display = new RenderWindow(800, 600);
            //display.open = true;

            //display.SetCamera(new Camera(0, 0, 0, 0, 0));

            Console.WriteLine("Initializing model data");
            r = new Renderer(800, 600, display);
            r.NewVertex(-1, -1, -1);
            r.NewVertex(1, -1, -1);
            r.NewVertex(1, 1, -1);
            r.NewVertex(-1, 1, -1);
            r.NewVertex(-1, -1, 1);
            r.NewVertex(1, -1, 1);
            r.NewVertex(1, 1, 1);
            r.NewVertex(-1, 1, 1);

            r.NewEdge(0, 1);
            r.NewEdge(1, 2);
            r.NewEdge(2, 3);
            r.NewEdge(3, 0);
            r.NewEdge(4, 5);
            r.NewEdge(5, 6);
            r.NewEdge(6, 7);
            r.NewEdge(7, 4);
            r.NewEdge(0, 4);
            r.NewEdge(1, 5);
            r.NewEdge(2, 6);
            r.NewEdge(7, 3);

            Console.WriteLine("Ready. Open a render viewer with 'render'");

            while (true)
            {
                InputLoop();
            }

        }

        static void InputLoop()
        {
            string input = Console.ReadLine();
            if (input == "view")
            {
                display = new RenderWindow(800, 600);
                Application.EnableVisualStyles();
                r.SetCamera(new Camera(2, 2, -5, 0, 0));
                display.UpdateGraphics(r.Draw());
                Application.Run(display.window);
            }
            if (input == "render")
            {
                r.SetCamera(new Camera(1, 1, -5, 0, 0));
                display.UpdateGraphics(r.Draw());
            }

            Console.ReadKey();
        }

            /*
            while (display.open)
            {
                string input = Console.ReadLine();
                if (input == "up")
                    display.c.x++;
                Application.DoEvents();
                display.Display();
                display.UpdateGraphics(r.Draw());
            }
            */
        //}

    }
}

using System;
using System.Collections.Generic;
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
            

            Console.WriteLine("Ready. Open a render viewer with 'render'");

            while (true)
            {
                InputLoop();
            }

        }

        static void InputLoop()
        {
            Console.Write(": ");
            string input = Console.ReadLine();
            /* LEGACY VIEWER
            if (input == "view legacy")
            {
                Console.WriteLine("Initializing display");
                display = new RenderWindow(800, 600);
                Application.EnableVisualStyles();
                r.SetCamera(new Camera(2, 2, -5, 0, 0));
                display.UpdateGraphics(r.Draw());
                Application.Run(display.window);
            }
            */
            switch (input.ToLower())
            {
                case "setm":
                    Console.WriteLine("Populating render mesh");
                    PopulateRenderMesh();
                    break;
                case "setc":
                    Console.WriteLine("Setting default camera at origin");
                    r.SetCamera(new Camera(0, 0, 0, 0, 0));
                    break;
                case "setc out":
                    Console.WriteLine("Moving camera to draw default mesh intersecting frame bounds");
                    r.SetCamera(new Camera(-6, -6, -5, 0, 0));
                    break;
                case "view":
                    Console.WriteLine("Initializing viewer");
                    Viewer view = new Viewer(r);
                    view.View();
                    break;
                case "ezinit":
                    Console.WriteLine("Running the EZ Initializer");
                    PopulateRenderMesh();
                    r.SetCamera(new Camera(0, 0, 0, 0, 0));
                    Console.WriteLine("Prepared mesh and camera, 'view' to launch render viewer or 'export' to output image frame.");
                    break;
                case "export":
                    Console.WriteLine("Exporting render to render.png. Pass 'onblack' for backcolor.");
                    r.Draw().bitmap.Save("render.png", System.Drawing.Imaging.ImageFormat.Png);
                    break;
                case "export onblack":
                    Console.WriteLine("Exporting render on black to render.png");
                    int w = r.Draw().width; //yeah, not the most efficient...
                    int h = r.Draw().height;
                    Bitmap blackBack = new Bitmap(w, h);
                    Graphics bG = Graphics.FromImage(blackBack);
                    bG.FillRectangle(Brushes.Black, 0, 0, w, h);
                    bG.DrawImage(r.Draw().bitmap, 0, 0);
                    bG.Flush();
                    blackBack.Save("render.png", System.Drawing.Imaging.ImageFormat.Png);
                    break;
                case "setm obj test":
                    Console.WriteLine("Populating render mesh from hard-coded test OBJ");
                    r.SetVertices(Importer.LoadVerticesFromObj(@"antler.obj"));
                    Console.WriteLine("Building edge list from vertices & OBJ data");
                    r.SetEdges(Importer.BuildObjEdgesFromVertices(@"antler.obj", r.GetVertices()));
                    break;
                case "setm clear":
                    Console.WriteLine("Clearing mesh");
                    r.SetVertices(new List<Vertex>());
                    r.SetEdges(new List<Edge>());
                    break;
            }
        }

        static void PopulateRenderMesh()
        {
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
        }

            /* LEGACY WINDOW MANAGER
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
using System;
using System.Drawing;

namespace Render3D
{
    public class Vertex2D
    {

        public int x;
        public int y;
        public Color c;

        public Vertex2D(int x, int y, Color c)
        {
            this.x = x;
            this.y = y;
            this.c = c;
        }

    }
}

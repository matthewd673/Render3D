using System;
using System.Drawing;

namespace Render3D
{
    public class Vertex
    {

        public int x;
        public int y;
        public int z;
        public Color c;

        public Vertex(int x, int y, int z, Color c = new Color())
        {
            this.x = x;
            this.y = y;
            this.z = z;

            if (c == new Color())
                this.c = Color.White;

        }

    }
}

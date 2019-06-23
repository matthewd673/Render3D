using System;
using System.Drawing;

namespace Render3D
{
    public class Vertex
    {

        public float x;
        public float y;
        public float z;
        public Color c;

        public Vertex(float x, float y, float z, Color c = new Color())
        {
            this.x = x;
            this.y = y;
            this.z = z;

            if (c == new Color())
                this.c = Color.White;

        }

    }
}

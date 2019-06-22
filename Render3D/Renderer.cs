using System;
using System.Collections.Generic;
using System.Drawing;

namespace Render3D
{
    public class Renderer
    {

        DirectBitmap dBmp;
        List<Vertex> vertices = new List<Vertex>();

        public Renderer(int width, int height)
        {
            dBmp = new DirectBitmap(width, height);
        }

        public void NewVertex(int x, int y, int z, Color c = new Color())
        {
            vertices.Add(new Vertex(x, y, z, c));
        }

        public DirectBitmap Draw()
        {
            //set pixels on dBmp
            return dBmp;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Render3D
{
    public class Renderer
    {

        DirectBitmap dBmp;
        List<Vertex> vertices = new List<Vertex>();
        List<Edge> edges = new List<Edge>();

        private int mX;
        private int mY;

        int w;
        int h;

        RenderWindow parent;

        Camera cam;

        public Renderer(int width, int height, RenderWindow parent)
        {
            w = width;
            h = height;
            dBmp = new DirectBitmap(width, height);
            this.parent = parent;
            cam = parent.c;
        }

        public void NewVertex(int x, int y, int z, Color c = new Color())
        {
            vertices.Add(new Vertex(x, y, z, c));
        }

        public void NewEdge(int vId1, int vId2)
        {
            edges.Add(new Edge(vertices[vId1], vertices[vId2]));
        }

        public void SetVertices(List<Vertex> vertices)
        {
            this.vertices = vertices;
        }

        public List<Vertex> GetVertices()
        {
            return vertices;
        }

        public void SetEdges(List<Edge> edges)
        {
            this.edges = edges;
        }

        public DirectBitmap Draw()
        {

            dBmp = new DirectBitmap(w, h);

            mX = dBmp.width / 2;
            mY = dBmp.height / 2;

            for (int i = 0; i < vertices.Count; i++)
            {
                Vertex v = vertices[i];

                float x = v.x;
                float y = v.y;
                float z = v.z;
                Color c = v.c;

                z += 5; //shift towards camera;

                float depth = (dBmp.width / 2) / z;

                x *= depth;
                y *= depth;

                Vertex2D rCoords = GetRenderCoordinates(v);

                //dBmp.SetPixel(cX + (int)x, cY + (int)y, c);
                if(SafeCoord(rCoords.x, rCoords.y))
                    dBmp.SetPixel(rCoords.x, rCoords.y, c);

            }

            for (int i = 0; i < edges.Count; i++)
            {
                Edge e = edges[i];

                Vertex2D rC1 = GetRenderCoordinates(e.v1);
                Vertex2D rC2 = GetRenderCoordinates(e.v2);

                DrawLine(rC1, rC2);

            }

            return dBmp;
        }

        Vertex2D GetRenderCoordinates(Vertex v)
        {

            //Console.WriteLine("cam: {0},{1},{2}", cam.x, cam.y, cam.z);

            int scale = 10;

            int x = (int)(v.x * scale) - cam.x;
            int y = (int)(v.y * scale) - cam.y;
            int z = (int)(v.z * scale) - cam.z;

            //int adjZ = z + 5; //shift z forward

            //to get around dividing by 0 below (kinda temporary)
            if (z == 0)
                z = 1;

            float depth = (mX / 2) / z; //cX is the halfway point, so we can use it as the width

            return new Vertex2D((int)(x * depth) + mX, (int)(y * depth) + mY, v.c);
        }

        void DrawLine(Vertex2D v1, Vertex2D v2)
        {
            for(float t = 0f; t < 1f; t += .001f)
            {
                int x = (int)(v1.x + (v2.x - v1.x)*t);
                int y = (int)(v1.y + (v2.y - v1.y)*t);
                if(SafeCoord(x, y))
                    dBmp.SetPixel(x, y, v1.c);
            }
        }

        bool SafeCoord(int x, int y) { return (x > 0 && y > 0 && x < dBmp.width && y < dBmp.height); }

        public void SetCamera(Camera c)
        {
            this.cam = c;
        }

        public Camera GetCamera() { return cam; }

    }
}

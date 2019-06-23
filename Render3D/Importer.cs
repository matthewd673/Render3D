using System;
using System.Collections.Generic;
using System.IO;

namespace Render3D
{
    public static class Importer
    {

        public static List<Vertex> LoadVerticesFromObj(string path)
        {
            string[] objContents = File.ReadAllLines(path);

            List<Vertex> vertices = new List<Vertex>();

            foreach(string line in objContents)
            {
                if(line.StartsWith("v "))
                {
                    string[] points = line.Split(' ');
                    if (points.Length > 3) //who cares if its too long, we just want to grab the most basic info available
                    {
                        decimal x = 0;
                        decimal y = 0;
                        decimal z = 0;

                        if (!Decimal.TryParse(points[1], out x))
                            Console.WriteLine("Invalid x coordinate {0}", points[1]);
                        if (!Decimal.TryParse(points[2], out y))
                            Console.WriteLine("Invalid y coordinate {0}", points[2]);
                        if (!Decimal.TryParse(points[3], out z))
                            Console.WriteLine("Invalid z coordinate {0}", points[3]);

                        vertices.Add(new Vertex((int)x, (int)y, (int)z));
                    }
                }
            }

            return vertices;
        }

        public static List<Edge> BuildObjEdgesFromVertices(string path, List<Vertex> vertices)
        {
            List<Edge> edges = new List<Edge>();

            string[] objContents = File.ReadAllLines(path);

            foreach(string line in objContents)
            {
                if(line.StartsWith("f "))
                {

                    string[] verts = line.Split(' ');

                    if (verts.Length > 3)
                    {
                        int[] extVerts = new int[verts.Length - 1];

                        for (int i = 1; i < verts.Length; i++)
                        {
                            if (verts[i].Contains("/"))
                                extVerts[i - 1] = Convert.ToInt32(verts[i].Split('/')[0]) - 1;
                            else
                                extVerts[i - 1] = Convert.ToInt32(verts[i]) - 1;

                            if (i < verts.Length - 1)
                                edges.Add(new Edge(vertices[extVerts[i - 1]], vertices[extVerts[i]]));
                            else
                                edges.Add(new Edge(vertices[extVerts[i - 1]], vertices[extVerts[0]]));

                        }

                        edges.Add(new Edge(vertices[extVerts[0]], vertices[extVerts[1]]));
                        edges.Add(new Edge(vertices[extVerts[1]], vertices[extVerts[2]]));
                        edges.Add(new Edge(vertices[extVerts[2]], vertices[extVerts[0]]));

                    }
                    

                }
            }

            return edges;

        }

    }
}

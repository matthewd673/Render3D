using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D
{
    public class Edge
    {

        public Vertex v1;
        public Vertex v2;

        public Edge(Vertex v1, Vertex v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

    }
}

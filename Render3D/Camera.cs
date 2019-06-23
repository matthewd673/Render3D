using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D
{
    public class Camera
    {

        public int x;
        public int y;
        public int z;

        public int yaw;
        public int pitch;

        public Camera(int x, int y, int z, int yaw, int pitch)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.yaw = yaw;
            this.pitch = pitch;
        }

    }
}

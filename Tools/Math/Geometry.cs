using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Math
{
    public class Geometry
    {
        public class Line
        {
            public Vector3D Position { get; set; }
            public Vector3D Direction { get; set; }
        }

        public class Plane
        {
            public Vector3D Position { get; set; }
            public Vector3D Normal { get; set; }
        }

        public class Hole
        {
            public Plane SurfacePlane { get; set; }
            public Vector3D Center { get; set; }
        }

        public class Sphere
        {
            public Vector3D Position { get; set; }
            public double Radius { get; set; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orakel
{
    public struct Ray
    {
        public Vector3 Origin;
        public Vector3 Direction;

        public Ray Unit
        {
            get
            {
                return new Ray(this.Origin, this.Direction.Unit);
            }
        }

        public Ray(Vector3 a, Vector3 b)
        {
            Origin = a;
            Direction = b;
        }
    }
}

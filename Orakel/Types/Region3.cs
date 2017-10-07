using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orakel
{
    public struct Region3
    {
        private Vector3 _min;
        private Vector3 _max;

        public Vector3 Position;
        public Vector3 Size;

        public bool IsEntityInside(BaseEntity ent)
        {
            return true;
        }

        public Region3(Vector3 min, Vector3 max)
        {
            _min = min;
            _max = max;
            Size = new Vector3(
                Math.Abs(min.X - max.X),
                Math.Abs(min.Y - max.Y),
                Math.Abs(min.Z - max.Z)
            );
            Position = new Vector3(
                min.X - max.X,
                min.Y - max.Y,
                min.Z - max.Z
            );
        }
    }
}

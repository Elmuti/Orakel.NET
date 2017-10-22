using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orakel
{
    public struct RayResult
    {
        public BaseEntity Hit;
        public Vector3 Position;
        public Vector3 Normal;
        public Material Material;

        public RayResult(BaseEntity hit, Vector3 pos, Vector3 norm, Material mat)
        {
            Hit = hit;
            Position = pos;
            Normal = norm;
            Material = mat;
        }
    }
}




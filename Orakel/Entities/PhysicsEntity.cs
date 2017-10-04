using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Platform;
using OpenTK.Graphics.OpenGL;
using BulletSharp;

namespace Orakel.Entities
{
    public class PhysicsEntity : BaseEntity
    {
        public bool Anchored = true;

        public PhysicsEntity()
        {
            BoxShape shape = new BoxShape(new Vector3(1, 1, 1));
        }
    }
}

using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Platform;
using OpenTK.Graphics.OpenGL;
using BulletSharp;

namespace Orakel
{
    public abstract class GuiBase2d
    {
        private Vector2 absPosition = Vector2.Zero;
        private Vector2 absSize = Vector2.Zero;
        private float absRot = 0f;


        public Vector2 AbsolutePosition
        {
            get { return absPosition; }
        }
        
        public Vector2 AbsoluteSize
        {
            get { return absSize; }
        }

        public float AbsoluteRotation
        {
            get { return absRot; }
        }
    }
}

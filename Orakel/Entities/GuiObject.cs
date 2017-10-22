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
    public abstract class GuiObject : GuiBase2d
    {
        private bool _beingTweened = false;
        private bool _interrupt = false;
        /// <summary>
        /// Determines whether mouse events fall through to 3D space.
        /// </summary>
        public bool Active = true;

        /// <summary>
        /// Sets the origin point of the GuiObject, relative to its absolute size.
        /// </summary>
        public Vector2 AnchorPoint = Vector2.Zero;

        public Color4 BackgroundColor = Color4.White;
        public Color4 BorderColor = Color4.Black;
        public int BorderSizePixel = 1;
        public bool ClipsDescendants = false;
        public bool Draggable = false;

        public UDim2 Position = new UDim2(0, 0, 0, 0);
        public UDim2 Size = new UDim2(0, 0, 0, 0);
        public float Rotation = 0f;
        public bool Visible = true;

        /// <summary>
        /// Smoothly moves a GUI to a new UDim2 position in the specified time using the specified EasingDirection and EasingStyle.
        /// </summary>
        /// <returns></returns>
        public bool TweenPosition(UDim2 endPos, EasingDirection easingDirection = EasingDirection.Out, EasingStyle easingStyle = EasingStyle.Quad, float time = 1f, bool oride = false)
        {
            if (oride && _beingTweened)
                _interrupt = true;

            // TODO: add an actual tween in render loop

            return false;
        }
    }
}

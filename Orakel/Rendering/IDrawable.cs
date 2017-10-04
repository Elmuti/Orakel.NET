using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Orakel.Graphics
{
    interface IDrawable
    {
        int ZIndex { get; set; }
        void Draw(Time time);
    }
}

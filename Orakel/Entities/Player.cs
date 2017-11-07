using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Platform;
using OpenTK.Graphics.OpenGL;
using BulletSharp;
using NLua;
using Orakel.Input;

namespace Orakel
{
    public class Player : BaseEntity
    {
        //Character _character;
        PlayerMouse _mouse;

        public PlayerMouse Mouse   { get { return _mouse; } }

        public void Kick(string message = "")
        {

        }
    }
}

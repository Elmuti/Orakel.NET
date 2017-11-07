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

namespace Orakel
{
    /// <summary>
    /// Players-service singleton
    /// </summary>
    public class Players : BaseEntity
    {
        Player _localplayer;
        int _maxplayers;

        public ScriptSignal PlayerAdded = new ScriptSignal();
        public ScriptSignal PlayerRemoved = new ScriptSignal();

        public int NumPlayers { get { return GetPlayers().Length; } }
        public Player LocalPlayer  { get { return _localplayer; } }

        public Player[] GetPlayers()
        {
            return Children.OfType<Player>().ToArray();
        }

        protected override void AddChild<C>(C ent)
        {
            base.AddChild(ent);
            if (ent is Player)
            {
                PlayerAdded.Fire(ent);
            }
        }

        public Players()
        {

        }
    }
}

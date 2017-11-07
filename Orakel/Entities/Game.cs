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
    public class Game : BaseEntity
    {
        Lua _state;
        string _jobId;
        Workspace _workspace;
        Players _players;

        internal Lua LuaState        { get { return _state; } }

        public string JobId          { get { return _jobId; } }
        public Workspace Workspace   { get { return _workspace; } }
        public Players Players       { get { return _players; } }

        public object ObjectFromString(string obj)
        {
            var res = LuaState.DoString("return " + obj + "()")[0] as object;
            return res;
        }

        protected virtual void OnLoad()
        {

        }

        protected virtual void Initialize()
        {

        }


        protected virtual new void Update(Time time)
        {
            base.Update(time);
        }

        protected virtual void Draw(Time time)
        {

        }

        public Game(string jobId)
        {
            _workspace = new Workspace();
            _players = new Players();
            _state = new Lua();
            Initialize();
        }
    }
}

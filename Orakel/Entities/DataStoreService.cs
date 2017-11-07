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
    public class DataStore
    {

        public ScriptSignal OnUpdate = new ScriptSignal();

        public object GetAsync(string key)
        {
            return new object();
        }

        public object IncrementAsync(string key, int delta = 1)
        {
            return new object();
        }

        public object RemoveAsync(string key)
        {
            return new object();
        }

        public void SetAsync(string key, object value)
        {

        }

        public object UpdateAsync(string key, LuaFunction transformFunction)
        {
            return new object();
        }

        public DataStore()
        {

        }
    }


    public class DataStoreService
    {
        public DataStore GetDataStore(string name, string scope = "global")
        {
            return new DataStore();
        }
    }
}

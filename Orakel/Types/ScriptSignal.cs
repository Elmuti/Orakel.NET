using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;

namespace Orakel
{
    public class ScriptSignal
    {
        private bool _connected = false;
        private List<ScriptConnection> _connections = new List<ScriptConnection>();

        public bool Connected { get { return _connected; } }

        public ScriptConnection Connect(object func)
        {
            var cf = func as LuaFunction;
            ScriptConnection con = new ScriptConnection(this, cf);
            _connections.Add(con);
            _connected = true;
            return con;
        }

        public void Disconnect(ScriptConnection con)
        {
            _connections.Remove(con);
            if (_connections.Count <= 0)
                _connected = false;
        }

        public void Fire(params object[] list)
        {
            foreach(ScriptConnection con in _connections)
            {
                con.Fire(list);
            }
        }

        public ScriptSignal()
        {

        }
    }

    public class ScriptConnection
    {
        private ScriptSignal _signal;
        private bool _connected = true;
        private LuaFunction _function = null;
        public bool Connected  { get { return _connected; } }

        public void Disconnect()
        {
            _connected = false;
            _signal.Disconnect(this);
        }

        public void Fire(params object[] list)
        {
            if (_connected)
                _function.Call(list);
        }

        public ScriptConnection(ScriptSignal signal, LuaFunction f)
        {
            _signal = signal;
            _function = f;
        }
    }
}

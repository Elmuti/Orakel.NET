using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;

namespace Orakel
{
    public class Script : BaseEntity
    {
        protected Lua _state;
        protected bool _enabled = true;
        protected string _source = "";

        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        public string Source
        {
            get { return _source; }
            set {
                _source = value;
                _state.DoString(_source);
            }
        }

        public Script(Lua state, string source)
        {
            Name = "Script";
            _source = source;
            _state = state;
            _state.DoString(_source);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;

namespace Orakel
{
    public class ModuleScript : Script
    {
        public ModuleScript(Lua state, string source)
        :base(state, source) {
            Name = "Script";
            _source = source;
            _state = state;
            _state.DoString(_source);
        }
    }
}

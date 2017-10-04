using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orakel
{
    public static class ObjectHelper
    {
        public static int GetHashCode(params object[] objects)
        {
            if ( objects.Length == 1 ) return objects[0].GetHashCode();
    
            int hc = objects.Length;
            for ( int i = 0; i<objects.Length; ++i )
            {
                hc = unchecked( hc* 314159 + objects[i].GetHashCode() );
            }
    
            return hc;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace Orakel
{
    public struct Time
    {
        public static readonly Time Zero = new Time();

        private TimeSpan _upd;
        private TimeSpan _start;

        public TimeSpan SinceLastUpdate
        {
            get { return _upd; }
        }

        public TimeSpan SinceStartOfGame
        {
            get { return _start; }
        }

        internal Time(TimeSpan fromUpdate, TimeSpan fromStart)
        {
            _upd = fromUpdate;
            _start = fromStart;
        }
 
         internal Time( GameTime gameTime )
             : this( gameTime.ElapsedGameTime, gameTime.TotalGameTime )
         {
         }
 
         internal void Advance( GameTime gameTime )
         {
             _upd = gameTime.ElapsedGameTime;
             _start += gameTime.ElapsedGameTime;
         }


    }
}
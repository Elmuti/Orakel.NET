using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BulletSharp;

namespace Orakel
{
    /// <summary>
    /// Interface for updatable entities.
    /// </summary>
    interface IUpdatable
    {
        bool IsUpdated { get; }
        void Update(Time time);
    }
}

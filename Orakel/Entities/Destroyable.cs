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
    /// Interface for destroyable entities.
    /// </summary>
    interface Destroyable
    {
        bool IsDestroyable { get; }
        void Destroy();
    }
}

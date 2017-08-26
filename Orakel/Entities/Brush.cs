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
    /// 
    /// </summary>
    public class Brush : Updatable, Destroyable
    {
        internal static float BRUSH_MIN_SIZE = 0.001f;
        internal static float BRUSH_MAX_SIZE = 5120f;

        bool Updatable.IsUpdated { get; }
        bool Destroyable.IsDestroyable { get; }

        void Updatable.Update(Time time)
        {

        }

        void Destroyable.Destroy()
        {

        }



        public Vector3 _position = Vector3.Zero;
        public Vector3 _size = Vector3.One;
        //public Texture3D _texture;


        public Vector3 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Vector3 Size
        {
            get { return _size; }
            set
            {
                _size = new Vector3(
                    Utils.Clamp(value.X, BRUSH_MIN_SIZE, BRUSH_MAX_SIZE),
                    Utils.Clamp(value.Y, BRUSH_MIN_SIZE, BRUSH_MAX_SIZE),
                    Utils.Clamp(value.Z, BRUSH_MIN_SIZE, BRUSH_MAX_SIZE)
                );
            }
        }

        public Brush()
        {

        }
    }
}

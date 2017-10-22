using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Xna;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Platform;
using OpenTK.Graphics.OpenGL;
using BulletSharp;

namespace Orakel
{
    public struct Vector2
    {
        private float _x;
        private float _y;

        public float X { get { return _x; } }
        public float Y { get { return _y; } }

        public static Vector2 Zero { get { return new Vector2(0, 0); } }

        /// <summary>
        /// Normalized copy of the vector
        /// </summary>
        public Vector2 Unit
        {
            get
            {
                if (this.Magnitude == 0f)
                {
                    return this;
                }
                return new Vector2(this._x / this.Magnitude, this._y / this.Magnitude);
            }
        }

        /// <summary>
        /// Magnitude of the vector
        /// </summary>
        public float Magnitude
        {
            get { return (float)Math.Sqrt(this.MagnitudeSquared); }
        }

        public float MagnitudeSquared
        {
            get { return this._x * this._x + this._y * this._y; }
        }

        /// <summary>
        /// Returns the Dot-product of two vectors
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public float Dot(Vector2 other)
        {
            return this.Y * other.Y + this.X * other.X;
        }

        /// <summary>
        /// Returns the angle between two vectors, in radians
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public float AngleBetween(Vector2 other)
        {
            return (float)Math.Acos(this.Unit.Dot(other.Unit));
        }
        
        /// <summary>
        /// Given two vectors, returns if they are parallel or not
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsParallelWith(Vector2 other)
        {
            return Math.Abs(this.Unit.Dot(other.Unit)) == 1;
        }

        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X + right.X, left.Y + right.Y);
        }

        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X - right.X, left.Y - right.Y);
        }

        public static Vector2 operator *(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X * right.X, left.Y * right.Y);
        }

        public static Vector2 operator /(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X / right.X, left.Y / right.Y);
        }

        public static Vector2 operator *(Vector2 source, float scalar)
        {
            return new Vector2(source.X * scalar, source.Y * scalar);
        }

        public static Vector2 operator *(float scalar, Vector2 source)
        {
            return source * scalar;
        }

        public static Vector2 operator /(Vector2 source, float scalar)
        {
            //Let's not implement this using operator* in order to avoid rounding errors
            return new Vector2(source.X / scalar, source.Y / scalar);
        }

        public static Vector2 operator -(Vector2 source)
        {
            return new Vector2(-source.X, -source.Y);
        }

        public override bool Equals(object obj)
        {
            float x, y;
            if (obj is Vector2)
            {
                x = ((Vector2)obj).X;
                y = ((Vector2)obj).Y;
            }
            else if (obj is Microsoft.Xna.Framework.Vector2)
            {
                x = ((Microsoft.Xna.Framework.Vector2)obj).X;
                y = ((Microsoft.Xna.Framework.Vector2)obj).Y;
            }
            else if (obj is OpenTK.Vector2)
            {
                x = ((OpenTK.Vector2)obj).X;
                y = ((OpenTK.Vector2)obj).Y;
            }
            else
                return false;

            return (Math.Abs(this.X - x) < float.Epsilon) && (Math.Abs(this.Y - y) < float.Epsilon);
        }

        public override int GetHashCode()
        {
            return ObjectHelper.GetHashCode(X.GetHashCode(), Y.GetHashCode());
        }

        public override string ToString()
        {
            return this.X + ", " + this.Y;
        }

        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return (Math.Abs(left.X - right.X) < float.Epsilon) && (Math.Abs(left.Y - right.Y) < float.Epsilon);
        }

        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !(left == right);
        }

        public static implicit operator OpenTK.Vector2(Vector2 other)
        {
            return new OpenTK.Vector2(other.X, other.Y);
        }

        public static implicit operator Microsoft.Xna.Framework.Vector2(Vector2 other)
        {
            return new Microsoft.Xna.Framework.Vector2(other.X, other.Y);
        }

        public static implicit operator Vector2(Microsoft.Xna.Framework.Vector2 other)
        {
            return new Vector2(other.X, other.Y);
        }

        public static implicit operator Vector2(OpenTK.Vector2 other)
        {
            return new Vector2(other.X, other.Y);
        }



        /// <summary>
        /// Creates a new Vector2 from x,y,z components
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector2(float x, float y)
        {
            this._x = x;
            this._y = y;
        }
    }
}

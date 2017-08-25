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
    /// <summary>
    /// UDim stands for Universal Dimension, and uses 2 coordinates; Scale and an Offset. These are used to figure out where exactly the UDim's position is.
    /// </summary>
    public class UDim
    {
        private int _offset = 0;
        private float _scale = 0f;

        /// <summary>
        /// The offset value.
        /// </summary>
        public int Offset { get { return _offset; } }

        /// <summary>
        /// The scale value.
        /// </summary>
        public float Scale { get { return _scale; } }

        /// <summary>
        /// Returns a UDim interpolated between this, and the goal.
        /// </summary>
        /// <param name="goal"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public UDim Lerp(UDim goal, float alpha)
        {
            return new UDim(
                Scale + (goal.Scale - Scale) * alpha,
                (int)((Offset + (goal.Offset - Offset)) * alpha)
            );
        }


        /// <summary>
        /// Creates a new UDim from the specified components.
        /// </summary>
        /// <param name="scale"></param>
        /// <param name="offset"></param>
        public UDim(float scale, int offset)
        {
            _scale = scale;
            _offset = offset;
        }

        /// <summary>
        /// Returns a new UDim with each component added individually.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static UDim operator +(UDim left, UDim right)
        {
            return new UDim(left.Scale + right.Scale, left.Offset + right.Offset);
        }
    }
}

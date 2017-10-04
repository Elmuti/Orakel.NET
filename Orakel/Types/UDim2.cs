using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.Serialization;

namespace Orakel
{
    /// <summary>
    /// A UDim2 is a Data Type composed of two UDims, one for the X coordinate and one for the Y coordinate, used to position and size GUIs.
    /// </summary>
    [Serializable]
    public class UDim2
    {
        /// <summary>
        /// The x-dimension scale and offset.
        /// </summary>
        public UDim X = new UDim(0f, 0);

        /// <summary>
        /// The y-dimension scale and offset.
        /// </summary>
        public UDim Y = new UDim(0f, 0);

        /// <summary>
        /// Returns a UDim2 interpolated between this, and the goal.
        /// </summary>
        /// <param name="goal"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public UDim2 Lerp(UDim2 goal, float alpha)
        {
            return new UDim2(
                X.Lerp(goal.X, alpha),
                Y.Lerp(goal.Y, alpha)
            );
        }

        /// <summary>
        /// Creates a new UDim2 whose values are all set to zero.
        /// </summary>
        public UDim2()
        {
        }

        /// <summary>
        /// Creates a new UDim2, using two pairs of UDim coordinates.
        /// </summary>
        /// <param name="xScale"></param>
        /// <param name="xOffset"></param>
        /// <param name="yScale"></param>
        /// <param name="yOffset"></param>
        public UDim2(float xScale, int xOffset, float yScale, int yOffset)
        {
            X = new UDim(xScale, xOffset);
            Y = new UDim(yScale, yOffset);
        }

        /// <summary>
        /// Creates a new UDim2, using two UDim coordinates.
        /// </summary>
        /// <param name="xDim"></param>
        /// <param name="yDim"></param>
        public UDim2(UDim xDim, UDim yDim)
        {
            X = xDim;
            Y = yDim;
        }

        /// <summary>
        /// Returns a new UDim2, with each component added individually.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static UDim2 operator +(UDim2 left, UDim2 right)
        {
            return new UDim2(left.X + right.X, left.Y + right.Y);
        }
    }
}

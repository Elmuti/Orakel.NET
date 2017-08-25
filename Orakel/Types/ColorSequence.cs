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
    /// A ColorSequenceKeypoint represents an individual keypoint in a ColorSequence.
    /// </summary>
    public class ColorSequenceKeypoint
    {
        private float _time = 0f;
        private Color _value = Color.White;

        /// <summary>
        /// The timestamp of this ColorSequenceKeypoint.
        /// </summary>
        public float Time { get { return _time; } }

        /// <summary>
        /// The color of this ColorSequenceKeypoint.
        /// </summary>
        public Color Value { get { return _value; } }

        /// <summary>
        /// Constructs a ColorSequenceKeypoint with the specified time and color
        /// </summary>
        /// <param name="time"></param>
        /// <param name="value"></param>
        public ColorSequenceKeypoint(float time, Color value)
        {
            _time = time;
            _value = value;
        }
    }

    /// <summary>
    /// A ColorSequence is a sequence of Color values representing a change in color over time.
    /// </summary>
    public class ColorSequence
    {
        /// <summary>
        /// A List containing ColorSequenceKeypoint values for the ColorSequence.
        /// </summary>
        public List<ColorSequenceKeypoint> Keypoints = new List<ColorSequenceKeypoint>();

        /// <summary>
        /// Creates a sequence of two keypoints with 'color' for each value.
        /// </summary>
        /// <param name="color"></param>
        public ColorSequence(Color color)
        {
            Keypoints.Add(new ColorSequenceKeypoint(0f, color));
            Keypoints.Add(new ColorSequenceKeypoint(1f, color));
        }

        /// <summary>
        /// Creates a sequence of two keypoints with 'c0' and 'c1' as the value.
        /// </summary>
        /// <param name="c0"></param>
        /// <param name="c1"></param>
        public ColorSequence(Color c0, Color c1)
        {
            Keypoints.Add(new ColorSequenceKeypoint(0f, c0));
            Keypoints.Add(new ColorSequenceKeypoint(1f, c1));
        }

        /// <summary>
        /// Creates a sequence of ColorSequenceKeypoints.
        /// </summary>
        /// <param name="keypoints"></param>
        public ColorSequence(List<ColorSequenceKeypoint> keypoints)
        {
            Keypoints = keypoints;
        }


        /// <summary>
        /// Creates a sequence of ColorSequenceKeypoints.
        /// </summary>
        /// <param name="keypoints"></param>
        public ColorSequence(params ColorSequenceKeypoint[] keypoints)
        {
            foreach (ColorSequenceKeypoint kp in keypoints)
            {
                Keypoints.Add(kp);
            }
        }
    }
}

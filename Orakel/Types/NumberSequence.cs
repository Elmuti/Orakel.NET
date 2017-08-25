using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orakel
{
    /// <summary>
    /// A NumberSequenceKeypoint represents a timestamp in a NumberSequence whose actual value randomly lies around: keypoint.Value ± keypoint.Envelope
    /// </summary>
    public class NumberSequenceKeypoint
    {
        private float _envelope = 0f;
        private float _time = 0f;
        private float _value = 0f;

        /// <summary>
        /// Determines how much the value can randomly deviate from the base value.
        /// </summary>
        public float Envelope { get { return _envelope; } }

        /// <summary>
        /// The timestamp of this keypoint.
        /// </summary>
        public float Time { get { return _time; } }

        /// <summary>
        /// The base value of this keypoint.
        /// </summary>
        public float Value { get { return _value; } }

        /// <summary>
        /// Creates a new NumberSequenceKeypoint with all properties initialized to 0.
        /// </summary>
        public NumberSequenceKeypoint()
        {
        }

        /// <summary>
        /// Creates a new NumberSequenceKeypoint from time, value, and envelope
        /// </summary>
        /// <param name="time"></param>
        /// <param name="value"></param>
        /// <param name="envelope"></param>
        public NumberSequenceKeypoint(float time, float value, float envelope)
        {
            _envelope = envelope;
            _time = time;
            _value = value;
        }
    }

    public class NumberSequence
    {
        /// <summary>
        /// A List containing keypoint values for the NumberSequence.
        /// </summary>
        public List<NumberSequenceKeypoint> Keypoints = new List<NumberSequenceKeypoint>();

        /// <summary>
        /// Creates a sequence of two keypoints with 'val' for each value.
        /// </summary>
        /// <param name="val"></param>
        public NumberSequence(float val)
        {
            Keypoints.Add(new NumberSequenceKeypoint(0f, val, 0f));
            Keypoints.Add(new NumberSequenceKeypoint(1f, val, 0f));
        }

        /// <summary>
        /// Creates a sequence from a list of keypoints.
        /// </summary>
        /// <param name="keypoints"></param>
        public NumberSequence(List<NumberSequenceKeypoint> keypoints)
        {
            Keypoints = keypoints;
        }

        /// <summary>
        /// Creates a sequence from a list of keypoints.
        /// </summary>
        /// <param name="keypoints"></param>
        public NumberSequence(params NumberSequenceKeypoint[] keypoints)
        {
            foreach(NumberSequenceKeypoint kp in keypoints)
            {
                Keypoints.Add(kp);
            }
        }

    }
}

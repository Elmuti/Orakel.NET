using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orakel
{
    public class NumberRange
    {
        private float _min = 0f;
        private float _max = 0f;

        public float Min { get { return _min; } set { _min = value; } }
        public float Max { get { return _max; } set { _max = value; } }

        public NumberRange()
        {

        }

        public NumberRange(float min, float max)
        {
            _min = min;
            _max = max;
        }

        public NumberRange(float max)
        {
            _max = max;
        }
    }
}

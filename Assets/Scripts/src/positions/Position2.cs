using UnityEngine;
using UnityEngine.Rendering;

namespace src.positions
{
    public class Position2
    {
        public float X, Y;

        public Position2() : this(0, 0)
        {
        }

        public Position2(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
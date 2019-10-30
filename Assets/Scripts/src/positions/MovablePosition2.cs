using System;
using System.Diagnostics;
using UnityEngine;

namespace src.positions
{
    public class MovablePosition2 : Position2
    {
        protected Vector2 _vector2;

        public new float X
        {
            get => _vector2.x;
            set => _vector2.x = value;
        }

        public new float Y
        {
            get => _vector2.y;
            set => _vector2.y = value;
        }

        public MovablePosition2(Vector2 position) : base(position.x, position.y)
        {
            _vector2 = position;
        }

        public MovablePosition2 Move(float x, float y, float speed, long elapsedMilliSeconds)
        {
            var radius = Math.Atan2(y, x);
            X += (float) Math.Cos(radius) * speed * elapsedMilliSeconds / 100;
            Y += (float) Math.Sin(radius) * speed * elapsedMilliSeconds / 100;
            return this;
        }

        public MovablePosition2 Move(Vector2 vector, float speed, long elapsedMilliSeconds)
        {
            Move(vector.x, vector.y, speed, elapsedMilliSeconds);
            return this;
        }
    }
}
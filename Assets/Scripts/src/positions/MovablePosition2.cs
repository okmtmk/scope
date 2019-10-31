using System;
using UnityEngine;

namespace src.positions
{
    public class MovablePosition2 : Position2
    {
        protected Vector2 _vector2;
        protected float _movableDistance;

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

        public bool IsOutside => Math.Sqrt(X * X + Y * Y) > _movableDistance;

        public Vector2 Vector2 => _vector2;

        public MovablePosition2(Vector2 position, float movableDistance) : base(position.x, position.y)
        {
            _vector2 = position;
            _movableDistance = movableDistance;
        }

        public MovablePosition2 Move(double radius, float speed, long elapsedMilliSeconds)
        {
            X += (float) Math.Cos(radius) * speed * elapsedMilliSeconds / 1000;
            Y += (float) Math.Sin(radius) * speed * elapsedMilliSeconds / 1000;
            return this;
        }

        public MovablePosition2 Move(float x, float y, float speed, long elapsedMilliSeconds)
        {
            var radius = Math.Atan2(y, x);
            return Move(radius, speed, elapsedMilliSeconds);
        }

        public MovablePosition2 Move(Vector2 vector, float speed, long elapsedMilliSeconds)
        {
            return Move(vector.x, vector.y, speed, elapsedMilliSeconds);
        }

        public void FitMovableArea()
        {
            if (IsOutside)
            {
                var radius = Math.Atan2(Y, X);
                X = (float) Math.Cos(radius) * _movableDistance;
                Y = (float) Math.Sin(radius) * _movableDistance;
            }
        }
    }
}
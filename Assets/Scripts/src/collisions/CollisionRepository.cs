using System;

namespace src.collisions
{
    public static class CollisionRepository
    {
        public static bool IsColliding(ICollidable a, ICollidable b)
        {
            return Math.Abs(a.X - b.X) < a.Width / 2 + b.Width / 2 &&
                   Math.Abs(a.Y - b.Y) < a.Height / 2 + b.Height / 2;
        }
    }
}
using UnityEngine;

namespace src.collisions
{
    public interface ICollidable
    {
        float X { get; }
        float Y { get; }

        float Width { get; }
        float Height { get; }

        void OnCollide(ICollidable collidable);
    }
}
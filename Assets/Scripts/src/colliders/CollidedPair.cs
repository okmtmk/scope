using Components.simpleColliders;

namespace src.colliders
{
    public class CollidedPair
    {
        private readonly SpriteCollider2D _a;
        private readonly SpriteCollider2D _b;

        public CollidedPair(SpriteCollider2D a, SpriteCollider2D b)
        {
            _a = a;
            _b = b;
        }

        public bool IsEquals(SpriteCollider2D a, SpriteCollider2D b)
        {
            return _a == a && _b == b || _a == b && _b == a;
        }

        public bool IsContains(SpriteCollider2D obj)
        {
            return _a == obj || _b == obj;
        }
    }
}
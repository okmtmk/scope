using NUnit.Framework;
using src.collisions;

namespace Editor.tests.unit.collisions
{
    public class TestCollidableObject : Collidable
    {
        public TestCollidableObject(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public float X { get; }

        public float Y { get; }
        public float Width { get; }
        public float Height { get; }

        public void OnCollide(Collidable collidable)
        {
            Assert.True(true, "当たり判定出ました！！");
        }
    }
}
using NUnit.Framework;
using src.collisions;

namespace Editor.tests.unit.collisions
{
    public class CollisionTest
    {
        [Test]
        public void TestCollisionWhenColliding()
        {
            var objA = new TestCollidableObject(25, 25, 100, 100);
            var objB = new TestCollidableObject(-25, -25, 100, 100);
            
            Assert.True(CollisionRepository.IsColliding(objA,objB));
        }

        [Test]
        public void TestCollisionWhenNotColliding()
        {
            var objA = new TestCollidableObject(51, 51, 100, 100);
            var objB = new TestCollidableObject(-51, -51, 100, 100);
            
            Assert.False(CollisionRepository.IsColliding(objA,objB));
        }
    }
}
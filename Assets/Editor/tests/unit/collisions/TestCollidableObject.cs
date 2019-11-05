using System;
using NUnit.Framework;
using src.collisions;
using UnityEngine;

namespace Editor.tests.unit.collisions
{
    public class TestCollidableObject : ICollidable
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

        public void OnCollide(ICollidable collidable)
        {
            Assert.True(true, "当たり判定出ました！！");
        }

        public void OnEnterCollider(ICollidable collidable)
        {
        }

        public void OnExitCollider(ICollidable collidable)
        {
        }
    }
}
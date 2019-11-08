using System;
using System.Collections.Generic;
using System.Linq;
using Components.simpleColliders;
using src.colliders;
using UnityEngine;

namespace Components.models
{
    public class CollisionDecider : MonoBehaviour
    {
        [NonSerialized] public static readonly List<SpriteCollider2D> Colliders
            = new List<SpriteCollider2D>();

        [NonSerialized] private static readonly List<CollidedPair> CollidedPairs
            = new List<CollidedPair>();


        private void Update()
        {
            var decideds = new List<CollidedPair>();
            var listA = new List<SpriteCollider2D>(Colliders);

            listA.ForEach(a =>
            {
                var listB = new List<SpriteCollider2D>(listA);
                listB.Remove(a);

                listB.ForEach(b =>
                {
                    if (!IsPairCollided(decideds, a, b))
                    {
                        if (IsColliding(a, b))
                        {
                            decideds.Add(new CollidedPair(a, b));
                            HandleColliding(a, b);
                        }
                        else if (IsPairCollided(CollidedPairs, a, b))
                        {
                            HandleColliderExit(a, b);
                        }
                    }
                });
            });

            Debug.Log($"size : {CollidedPairs.Count}");
        }

        private static bool IsColliding(SpriteCollider2D a, SpriteCollider2D b)
        {
            return Math.Abs(a.X - b.X) < a.Width / 2 + b.Width / 2 &&
                   Math.Abs(a.Y - b.Y) < a.Height / 2 + b.Height / 2;
        }

        private void HandleColliding(SpriteCollider2D a, SpriteCollider2D b)
        {
            if (!IsPairCollided(CollidedPairs, a, b))
            {
                a.onColliderEnter.Invoke(b);
                b.onColliderEnter.Invoke(a);

                CollidedPairs.Add(new CollidedPair(a, b));
            }

            a.onColliding.Invoke(b);
            b.onColliding.Invoke(a);
        }

        private void HandleColliderExit(SpriteCollider2D a, SpriteCollider2D b)
        {
            RemoveCollidedPair(a, b);
            a.onColliderExit.Invoke(b);
            b.onColliderExit.Invoke(a);
        }

        private static bool IsPairCollided(List<CollidedPair> list, SpriteCollider2D a, SpriteCollider2D b)
        {
            return list.Any(it => it.IsEquals(a, b));
        }

        private void RemoveCollidedPair(SpriteCollider2D a, SpriteCollider2D b)
        {
            CollidedPair target = null;
            foreach (var it in CollidedPairs.Where(it => it.IsEquals(a, b)))
            {
                target = it;
            }

            if (target != null)
            {
                CollidedPairs.Remove(target);
            }
        }

        public static void RemoveContainCollidedPair(SpriteCollider2D obj)
        {
            var num = 0;
            CollidedPairs.ForEach(it =>
            {
                if (it.IsContains(obj))
                {
                    num++;
                }
            });

            Debug.Log($"contains : {num}");
        }
    }
}
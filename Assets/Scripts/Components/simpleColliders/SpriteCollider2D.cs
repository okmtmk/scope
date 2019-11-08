using System;
using System.Collections.Generic;
using System.Linq;
using src.colliders;
using UnityEngine;
using UnityEngine.Events;

namespace Components.simpleColliders
{
    [Serializable]
    public class ColliderEvent : UnityEvent<SpriteCollider2D>
    {
    }

    /**
     * 矩形同士のシンプルな当たり判定処理
     */
    public class SpriteCollider2D : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprite;

        [SerializeField] private ColliderEvent onColliderEnter = new ColliderEvent();
        [SerializeField] private ColliderEvent onColliding = new ColliderEvent();
        [SerializeField] private ColliderEvent onColliderExit = new ColliderEvent();

        [NonSerialized] private static readonly List<SpriteCollider2D> Colliders
            = new List<SpriteCollider2D>();

        [NonSerialized] private static readonly List<CollidedPair> CollidedPairs
            = new List<CollidedPair>();

        private float X => gameObject.transform.position.x;
        private float Y => gameObject.transform.position.y;

        private float Width => sprite.bounds.size.x;
        private float Height => sprite.bounds.size.y;

        private void OnEnable()
        {
            Colliders.Add(this);
        }

        private void OnDisable()
        {
            Colliders.Remove(this);

            foreach (var it in CollidedPairs.Where(it => it.IsContains(this)))
            {
                CollidedPairs.Remove(it);
                break;
            }
        }

        private void Update()
        {
            var dicideds = new List<CollidedPair>();
            var listA = new List<SpriteCollider2D>(Colliders);

            listA.ForEach(a =>
            {
                var listB = new List<SpriteCollider2D>(listA);
                listB.Remove(a);

                listB.ForEach(b =>
                {
                    if (IsPairCollided(dicideds, a, b))
                    {
                        return;
                    }

                    if (IsColliding(a, b))
                    {
                        dicideds.Add(new CollidedPair(a, b));
                        HandleColliding(a, b);
                    }
                    else if (IsPairCollided(CollidedPairs, a, b))
                    {
                        HandleColliderExit(a, b);
                    }
                });
            });
        }

        private static bool IsColliding(SpriteCollider2D a, SpriteCollider2D b)
        {
            return Math.Abs(a.X - b.X) < a.Width / 2 + b.Width / 2 &&
                   Math.Abs(a.Y - b.Y) < a.Height / 2 + b.Height / 2;
        }

        private static void HandleColliding(SpriteCollider2D a, SpriteCollider2D b)
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

        private static void HandleColliderExit(SpriteCollider2D a, SpriteCollider2D b)
        {
            a.onColliderExit.Invoke(b);
            b.onColliderExit.Invoke(a);
        }

        private static bool IsPairCollided(List<CollidedPair> list, SpriteCollider2D a, SpriteCollider2D b)
        {
            return list.Any(it => it.IsEquals(a, b));
        }
    }
}
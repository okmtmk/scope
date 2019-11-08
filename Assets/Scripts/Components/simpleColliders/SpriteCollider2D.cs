using System;
using System.Collections.Generic;
using System.Linq;
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

        [NonSerialized] private static readonly Dictionary<SpriteCollider2D, SpriteCollider2D> Collideds
            = new Dictionary<SpriteCollider2D, SpriteCollider2D>();

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

            if (Collideds.ContainsKey(this))
            {
                Collideds.Remove(this);
            }

            if (Collideds.ContainsValue(this))
            {
                foreach (var spriteCollider2D in Collideds.Where(spriteCollider2D => spriteCollider2D.Value == this))
                {
                    Collideds.Remove(spriteCollider2D.Key);
                    break;
                }
            }
        }

        private void Update()
        {
            var listA = new List<SpriteCollider2D>(Colliders);
            var decideds = new List<SpriteCollider2D>();

            listA.ForEach(a =>
            {
                if (decideds.Contains(a))
                {
                    return;
                }

                var listB = new List<SpriteCollider2D>(listA);
                listB.Remove(a);

                listB.ForEach(b =>
                {
                    if (IsColliding(a, b))
                    {
                        HandleColliding(a, b);
                        decideds.Add(b);
                    }
                    else
                    {
                        HandleColliderExit(a);
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
            if (!Collideds.ContainsKey(a))
            {
                a.onColliderEnter.Invoke(b);
                Collideds.Add(a, b);
            }

            if (!Collideds.ContainsKey(b))
            {
                b.onColliderEnter.Invoke(a);
                Collideds.Add(b, a);
            }

            a.onColliding.Invoke(b);
            b.onColliding.Invoke(a);
        }

        private static void HandleColliderExit(SpriteCollider2D obj)
        {
            if (Collideds.ContainsKey(obj))
            {
                var target = Collideds[obj];
                obj.onColliderExit.Invoke(target);
                Collideds.Remove(obj);
            }
        }
    }
}
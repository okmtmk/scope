using System;
using System.Collections.Generic;
using System.Linq;
using Components.models;
using src.colliders;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

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

        [SerializeField] public ColliderEvent onColliderEnter = new ColliderEvent();
        [SerializeField] public ColliderEvent onColliding = new ColliderEvent();
        [SerializeField] public ColliderEvent onColliderExit = new ColliderEvent();

        public float X => gameObject.transform.position.x;
        public float Y => gameObject.transform.position.y;

        public float Width => sprite.bounds.size.x;
        public float Height => sprite.bounds.size.y;

        [NonSerialized] private static readonly List<SpriteCollider2D> Colliders
            = new List<SpriteCollider2D>();

        [NonSerialized] private static readonly List<CollidedPair> CollidedPairs
            = new List<CollidedPair>();


        private void OnEnable()
        {
            Colliders.Add(this);
        }

        private void OnDisable()
        {
            RemoveContainCollidedPair();
            Colliders.Remove(this);
        }

        private void Update()
        {
            var list = new List<SpriteCollider2D>(Colliders);
            list.Remove(this);

            list.ForEach(b =>
            {
                if (IsColliding(b))
                {
                    HandleColliding(b);
                }
                else if (IsCollidedPair(b))
                {
                    HandleColliderExit(b);
                }
            });
        }
        
        private bool IsColliding(SpriteCollider2D other)
        {
            return Math.Abs(X - other.X) < Width / 2 + other.Width / 2 &&
                   Math.Abs(Y - other.Y) < Height / 2 + other.Height / 2;
        }
        
        private void HandleColliding(SpriteCollider2D other)
        {
            if (!IsCollidedPair(other))
            {
                CollidedPairs.Add(new CollidedPair(this, other));

                onColliderEnter.Invoke(other);
                other.onColliderEnter.Invoke(this);
            }

            onColliding.Invoke(other);
            other.onColliding.Invoke(this);
        }
        
        private void HandleColliderExit(SpriteCollider2D other)
        {
            RemoveCollidedPair(other);

            onColliderExit.Invoke(other);
            other.onColliderExit.Invoke(this);
        }
        
        private bool IsCollidedPair(SpriteCollider2D other)
        {
            return CollidedPairs.Any(it => it.IsEquals(this, other));
        }

        private void RemoveCollidedPair(SpriteCollider2D other)
        {
            CollidedPair target = null;
            foreach (var it in CollidedPairs.Where(it => it.IsEquals(this, other)))
            {
                target = it;
            }

            if (target != null)
            {
                CollidedPairs.Remove(target);
            }
        }

        private void RemoveContainCollidedPair()
        {
            var list = CollidedPairs.Where(it => it.IsContains(this)).ToList();
            list.ForEach(it => CollidedPairs.Remove(it));
        }
    }
}
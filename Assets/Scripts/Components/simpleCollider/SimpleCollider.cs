using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Components.simpleCollider
{
    public class SimpleCollider : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private UnityEvent<SimpleCollider> onColliderEnter;
        [SerializeField] private UnityEvent<SimpleCollider> onColliding;
        [SerializeField] private UnityEvent<SimpleCollider> onColliderExit;

        [NonSerialized] private static readonly List<SimpleCollider> Colliders
            = new List<SimpleCollider>();

        [NonSerialized] private static readonly Dictionary<SimpleCollider, SimpleCollider> Collideds
            = new Dictionary<SimpleCollider, SimpleCollider>();

        private float X => gameObject.transform.position.x;
        private float Y => gameObject.transform.position.y;

        private float Width => sprite.bounds.size.x;
        private float Height => sprite.bounds.size.y;

        private void Start()
        {
            Colliders.Add(this);
        }

        private void Update()
        {
            var listA = new List<SimpleCollider>(Colliders);
            var decideds = new List<SimpleCollider>();

            listA.ForEach(a =>
            {
                if (decideds.Contains(a))
                {
                    return;
                }

                var listB = new List<SimpleCollider>(listA);
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

        private static bool IsColliding(SimpleCollider a, SimpleCollider b)
        {
            return Math.Abs(a.X - b.X) < a.Width / 2 + b.Width / 2 &&
                   Math.Abs(a.Y - b.Y) < a.Height / 2 + b.Height / 2;
        }

        private static void HandleColliding(SimpleCollider a, SimpleCollider b)
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

        private static void HandleColliderExit(SimpleCollider obj)
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
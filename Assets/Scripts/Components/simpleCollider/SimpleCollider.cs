using System;
using System.Collections.Generic;
using src.collisions;
using UnityEngine;
using UnityEngine.Events;

namespace Components.simpleCollider
{
    public class SimpleCollider : MonoBehaviour
    {
        [SerializeField] private Sprite sprite;
        [SerializeField] private UnityEvent<GameObject> onColliderEnter;
        [SerializeField] private UnityEvent<GameObject> onColliding;
        [SerializeField] private UnityEvent<GameObject> onColliderExit;

        [NonSerialized] private static List<SimpleCollider> _colliders
            = new List<SimpleCollider>();

        [NonSerialized] private static Dictionary<SimpleCollider, SimpleCollider> _collideds
            = new Dictionary<SimpleCollider, SimpleCollider>();

        private float X => gameObject.transform.position.x;
        private float Y => gameObject.transform.position.y;

        private float Width => sprite.bounds.size.x;
        private float Height => sprite.bounds.size.y;

        private void Start()
        {
            _colliders.Add(this);
        }

        private void Update()
        {
            var decideds = new List<SimpleCollider>();
            
            
        }
    }
}
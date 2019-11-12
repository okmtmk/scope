using System;
using System.Diagnostics;
using Components.simpleColliders;
using UnityEngine;

namespace Components.models
{
    public class Enemy : MonoBehaviour
    {
        [NonSerialized] private readonly Stopwatch _stopwatch = new Stopwatch();

        private void Start()
        {
            _stopwatch.Start();
        }

        private void Update()
        {
            if (_stopwatch.ElapsedMilliseconds > 5000)
            {
                Destroy(gameObject);
            }
        }

        public void OnColliderEnter(SpriteCollider2D other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                Destroy(gameObject);
            }
        }
    }
}
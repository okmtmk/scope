using System;
using System.Collections;
using System.Diagnostics;
using Components.effects;
using Components.simpleColliders;
using Components.utilities;
using UnityEngine;

namespace Components.models
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private DestroyParticleEmmiter effect;
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
                ScoreViewer.Score += 10;
                effect.PlayEffect();
                Destroy(gameObject);
            }
        }
    }
}
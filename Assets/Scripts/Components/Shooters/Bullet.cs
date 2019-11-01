using System;
using System.Diagnostics;
using src.collisions;
using src.positions;
using UnityEngine;

namespace Components.Shooters
{
    public class Bullet : CollidableBehaviour
    {
        [NonSerialized] public float Speed = 50;
        [NonSerialized] public double Radius;
        [NonSerialized] private MovablePosition2 _position;
        [NonSerialized] private readonly Stopwatch _stopwatch = new Stopwatch();

        protected override void Start()
        {
            base.Start();

            _position = new MovablePosition2(gameObject.transform.position, 20);
            _stopwatch.Start();
        }

        private void Update()
        {
            if (_position.IsOutside)
            {
                Destroy(gameObject);
            }

            _position.Move(Radius, Speed, _stopwatch.ElapsedMilliseconds);
            gameObject.transform.position = new Vector3(_position.Vector2.x, _position.Vector2.y, 1);

            _stopwatch.Restart();
        }

        public override void OnCollide(ICollidable collidable)
        {
            if (collidable is Enemy)
            {
                Destroy(gameObject);
            }
        }
    }
}
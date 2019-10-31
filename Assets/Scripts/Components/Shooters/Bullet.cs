using System;
using System.Diagnostics;
using src.positions;
using UnityEngine;

namespace Components.Shooters
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 50;

        [NonSerialized] public double Radius;
        [NonSerialized] private MovablePosition2 _position;
        [NonSerialized] private readonly Stopwatch _stopwatch = new Stopwatch();


        private void Start()
        {
            _position = new MovablePosition2(gameObject.transform.position, 20);
            _stopwatch.Start();
        }

        private void Update()
        {
            if (_position.IsOutside)
            {
                Destroy(gameObject);
            }

            _position.Move(Radius, speed, _stopwatch.ElapsedMilliseconds);
            gameObject.transform.position = new Vector3(_position.Vector2.x, _position.Vector2.y, 1);

            _stopwatch.Restart();
        }
    }
}